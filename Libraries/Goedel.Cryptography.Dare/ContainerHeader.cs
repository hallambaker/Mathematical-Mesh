using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Cryptography.Dare {
    public partial class ContainerHeader {

        /// <summary>The container payload. Note that this is not a serialized field of the container
        /// header.</summary>
        public byte[] Payload;

        //ExchangePosition

        /// <summary>
        /// Use information from the specified 
        /// </summary>
        /// <param name="DAREHeader"></param>
        public override void SetDefaultContext(DAREHeader DAREHeader) {
            if (DAREHeader.Encrypt) {
                base.SetDefaultContext(DAREHeader);
                if (DAREHeader as ContainerHeader != null) {
                    ExchangePosition = (DAREHeader as ContainerHeader).Index;
                    }
                }
            }




        }
    }
