using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {




    public class JHost {

        public JHost () {
            }

        public HostService AddService (JPCHost Service) {
            return null;
            }

        public HostPort AddHTTP(string Domain) {
            return AddHTTP (Domain, 80);
            }

        public HostPort AddHTTP (string Domain, int Port) {
            return null;
            }

        public HostPort AddUDP(string Domain, int Port) {
            return null;
            }

        public ServicePort AddPort (JPCHost Service, HostPort Port) {
            return null;
            }

        public void Start() {
            }

        public void Stop() {
            }

        }

    public class HostService {
        public ServicePort AddPort(HostPort Port) {
            return null;
            }
        }

    public class HostPort {
        }

    public class ServicePort {
        }

    }
