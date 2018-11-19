using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;


namespace Goedel.Mesh.Protocol.Client {
    public partial class ContextDevice {


        public void Process(DareMessage dareMessage) {
            // check signature(s)

            // unpack
            var meshMessage = MeshMessage.FromJSON(dareMessage.GetBodyReader());

            // dispatch

            switch (meshMessage) {
                case MessageConnectionRequest request:
                    Process(request);
                    break;
                case MessageContactRequest request:
                    Process(request);
                    break;
                }
            }



        public void Process(MessageConnectionRequest request) {
            var device = request.DeviceProfile;
            var entry = new CatalogEntryDevice() { DeviceProfile = device };
            CatalogDevice.Add(entry);
            }

        public void Process(MessageContactRequest request) {
            //var contact = request.Contact;
            //var entry = new CatalogEntryContact(contact);
            //CatalogDevice.Add(entry);
            }



        }
    }
