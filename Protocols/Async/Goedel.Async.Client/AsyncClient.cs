using System;
using Goedel.Protocol;
using Goedel.Async;

namespace Goedel.Async.Client {
    public class AsyncClient {
        AsyncService Service;

        /// <summary>The service address</summary>
        public string Address;

        /// <summary>
        /// Coinstruct a RecryptClient for the specified service.
        /// </summary>
        /// <param name="Address">The recryption service to connect to.</param>
        public AsyncClient(string Address) {
            Service = AsyncPortal.Default.GetService(Address);
            this.Address = Address;
            }

        ///// <summary>
        ///// Construct a RecryptClient for the specified service.
        ///// </summary>
        ///// <param name="RecryptProfile">The recryption profile.</param>
        //public AsyncClient(RecryptProfile RecryptProfile) => Service = RecryptPortal.Default.GetService(RecryptProfile.Account);


        /// <summary>
        /// Check protocol version.
        /// </summary>
        /// <returns>The service response</returns>
        public HelloResponse Hello() {
            var Request = new HelloRequest() { };
            return Service.Hello(Request);
            }


        /// <summary>
        /// PrePost Request
        /// </summary>
        /// <returns>The service response</returns>
        public PostResponse PrePost() {
            var Request = new PostRequest() { };
            return Service.Post(Request);
            }

        /// <summary>
        /// Check protocol version.
        /// </summary>
        /// <returns>The service response</returns>
        public PostResponse Post() {
            var Request = new PostRequest() { };
            return Service.Post(Request);
            }

        /// <summary>
        /// Check protocol version.
        /// </summary>
        /// <returns>The service response</returns>
        public StatusResponse Status() {
            var Request = new StatusRequest() { };
            return Service.Status(Request);
            }

        }
    }