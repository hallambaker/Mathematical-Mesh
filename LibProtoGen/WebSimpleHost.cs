using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Protocol {


    public class PortRegistration {

        }


    public class HostRegistration {
        JPCServer JPCServer;
        JPCHost JPCHost;

        public HostRegistration (JPCServer JPCServer, JPCHost JPCHost) {
            this.JPCServer = JPCServer;
            }

        public PortRegistration AddHTTP () {
            return null;
            }

        public PortRegistration AddUDP() {
            return null;
            }

        }


    public class JPCServer {

        public JPCServer() {

            }

        public HostRegistration Add(JPCHost JPCHost) {
            var Registration = new HostRegistration(this, JPCHost);

            return Registration;
            }

        public void Start () {

            }

        public void Stop () {

            }


        }
    }
