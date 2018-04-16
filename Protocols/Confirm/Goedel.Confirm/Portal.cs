using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.Protocol;


namespace Goedel.Confirm {

        /// <summary>
        /// Abstract interface to a service that supports the MeshPortal API calls.
        /// Mostly for useful in test code where the ability to switch between a
        /// direct and indirect portal connection is desirable. 
        /// </summary>
        public abstract class ConfirmPortal {

        /// <summary>
        /// Return a RecryptService object for the named portal service.
        /// </summary>
        /// <param name="Address">Address of the portal service.</param>
        /// <returns>Recrypt service object for API access to the service.</returns>
        public virtual ConfirmService GetService (string Address) {
            Address.SplitAccountIDService(out var Service, out var Account);
            return GetService(Service, Account);
            }

        /// <summary>
        /// Return a RecryptService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <param name="Account">Account name.</param>
        /// <returns>Recrypt service object for API access to the service.</returns>
        public abstract ConfirmService GetService (string Portal, string Account);

            private static ConfirmPortal _Default;
            /// <summary>
            /// Specify the default portal. If not overriden, the default default is to
            /// make a remote connection.
            /// </summary>
            public static ConfirmPortal Default {
                get {
                    if (_Default == null) {
                        _Default = new ConfirmPortalRemote();
                        }
                    return _Default;
                    }

                set {
                    _Default = value;
                    }
                }

            /// <summary>
            /// May be set to the default RecryptService by a calling application.
            /// </summary>
            public ConfirmService ConfirmServiceClient;

            }

        /// <summary>
        /// Connection to network service using HTTP client.
        /// </summary>
        public class ConfirmPortalRemote : ConfirmPortal {

            /// <summary>
            /// Default constructor.
            /// </summary>
            public ConfirmPortalRemote () {

                }


            /// <summary>
            /// Return a RecryptService object for the named portal service.
            /// </summary>
            /// <param name="Account">The account to get.</param>
            /// <param name="Domain">The DNS name of the service to get the service from.</param> 
            /// <returns>The service instance</returns>
            public override ConfirmService GetService (string Domain, string Account) {
                //var URI = JPCProvider.WellKnownToURI(Service, RecryptService.WellKnown, 
                //            RecryptService.Discovery, false, true);

                //var Session = new WebRemoteSession(URI, Service, Account);

                var Session = new WebRemoteSession(Domain, ConfirmService.WellKnown, Account);
                ConfirmServiceClient = new ConfirmServiceClient(Session);
                return ConfirmServiceClient;
                }
            }

        }
