using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Goedel.DNS;

namespace Goedel.Omnibroker {
    public class OmniServiceCriteria {
        public int MinorVersionMinimum;
        public int MajorVersionMinimum;
        public int MinorVersionMaximum;
        public int MajorVersionMaximum;


        public OmniServiceCriteria (int MajorVersionMinimum, int MinorVersionMinimum,
                int MajorVersionMaximum, int MinorVersionMaximum) {
            this.MajorVersionMinimum = MajorVersionMinimum;
            this.MinorVersionMinimum = MinorVersionMinimum;
            this.MajorVersionMaximum = MajorVersionMaximum;
            this.MinorVersionMaximum = MinorVersionMaximum;
            }

        public bool MetBy (DNSServiceDescription ServiceDescription) {
            return true;
            }
        }    


    public partial class DNSServiceDescription {
        public IPAddress        IPAddress;
        public int              Port;
        public string           ServiceName;
        public string           Advice;

        public int              Weight;
        public int              Priority;

        public bool             Acceptable = true;
        public int              Index = -1;
        }
    
    public partial class DNSServiceDescriptionList {
        static Random Random = new Random ();

        public List <DNSServiceDescription>     Entries;
        int Weight = 0;
        int Priority = 0x10000; // Lower than the lowest possible priority

        // Each time the 
        public DNSServiceDescriptionList(DNSClient DNSClient, string hostname, string service) {

            }

        // Each time the Next constructor is called we attempt to find the next highest priority
        // entry in the list.
        public DNSServiceDescription Next() {
            Weight = -1;
            foreach (DNSServiceDescription Entry in Entries) {
                if (Entry.Index < 0) {    // Ignore entry if it has already been matched.
                    if ((Entry.Priority < Priority) & (Weight > 0)) {
                        Priority = Entry.Priority;
                        Weight = Entry.Weight;
                        }
                    else if (Entry.Priority == Priority) {
                        Weight += Entry.Weight;
                        }
                    }
                }
            if (Weight < 0) {
                return null; // run out of entries.
                }
            int choice = Random.Next (Weight);
                        foreach (DNSServiceDescription Entry in Entries) {
                if (Entry.Index < 0) {    // Ignore entry if it has already been matched.
                    if (Entry.Priority == Priority) {
                        if (choice < Entry.Weight) {
                            Entry.Index = 1;
                            return Entry;
                            }
                        choice -= Entry.Weight;
                        }
                    }
                }
            return null;
            }


        public void Reset() {
            }

        }


    class OmniTCPClient : TcpClient {

        public int MaximumAttempts = 5;

        public OmniTCPClient () :base () {
            }
        public OmniTCPClient (IPEndPoint localEP) : base (localEP) {
            }
        public OmniTCPClient (string hostname, int port) : base (hostname, port) {
            }
        public OmniTCPClient (string hostname, string service) :base () {
            Connect (hostname, service);
            }
        public OmniTCPClient (string hostname, string service, OmniServiceCriteria Criteria) :base () {
            Connect (hostname, service, Criteria);
            }
        public OmniTCPClient (DNSClient DNSClient, string hostname, string service, 
                    OmniServiceCriteria Criteria) :base () {
            Connect (DNSClient, hostname, service, Criteria);
            }

        public void Connect (string hostname, string service) {
            Connect (hostname, service, null);
            }
        public void Connect (string hostname, string service, OmniServiceCriteria Criteria) {
            DNSClient DNSClient = new DNS.DNSClient ();
            Connect (DNSClient, hostname, service, Criteria);
            }
        public void Connect (DNSClient DNSClient, string hostname, string service) {
            Connect (DNSClient, hostname, service, null);
            }

        public void Connect (DNSClient DNSClient, string hostname, string service, OmniServiceCriteria Criteria) {
            DNSServiceDescriptionList ServiceDescriptionList = 
                        new DNSServiceDescriptionList (DNSClient, hostname, service);
            
            for (int trial = 0; trial < MaximumAttempts ; trial ++) {
                DNSServiceDescription ServiceDescription = ServiceDescriptionList.Next ();

                if (ServiceDescription == null) throw new Exception ("Connection failed");
                Connect (ServiceDescription.IPAddress, ServiceDescription.Port);
                }
            }
        }


    class OmniClient {
        static DNSClient DNSClient = new DNSClient ();

        public OmniClient() {
            }

        public OmniClient(List<IPAddress> Addresses) {
            }

        public OmniClient(List<string> Brokers) {
            }




        }
    }
