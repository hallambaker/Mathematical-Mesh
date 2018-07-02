using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.Catalog;

namespace Goedel.Catalog.Client {
    public class CatalogClient {
        CatalogService Service;

        /// <summary>The service address</summary>
        public string Address;

        /// <summary>
        /// Coinstruct a RecryptClient for the specified service.
        /// </summary>
        /// <param name="Address">The recryption service to connect to.</param>
        public CatalogClient(string Address) {
            Service = CatalogPortal.Default.GetService(Address);
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



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns>The service response</returns>
        //public AddResponse Add(List<CatalogEntry> CatalogEntries) {
        //    var Request = new AddRequest() { };
        //    return Service.Add(Request);
        //    }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns>The service response</returns>
        //public UpdateResponse Update(List<CatalogEntry> CatalogEntries) {
        //    var Request = new UpdateRequest() { };
        //    return Service.Update(Request);
        //    }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns>The service response</returns>
        //public DeleteResponse Delete(string ID) {
        //    var Request = new DeleteRequest() { };
        //    return Service.Delete(Request);
        //    }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns>The service response</returns>
        //public GetResponse Get(string ID) {
        //    var Request = new GetRequest() { };
        //    return Service.Get(Request);
        //    }
        }
    }
