using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {

    /// <summary>
    /// Base class for a Host
    /// </summary>
    public abstract class JPCHost {

        /// <summary>
        /// Dispatch Class. Reads input from the provided reader and attempts to
        /// dispatch a method in response. Note that the calling routine may throw 
        /// an error. This must be caught and processed by the host dispatch class.
        /// </summary>
        /// <param name="Service">The service that is to handle the request.</param>
        /// <param name="JSONReader"></param>
        /// <returns>The response to the request.</returns>
        public abstract Goedel.Protocol.JSONObject Dispatch(JPCService Service,
                        JSONReader JSONReader);

        }


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
