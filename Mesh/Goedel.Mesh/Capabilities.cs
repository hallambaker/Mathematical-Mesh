using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh {
    public partial class CryptographicCapability {

        ///<summary>The primary key is the value of the <see cref="Id"/> property.</summary>
        public override string _PrimaryKey => Id;

        public CryptographicCapability() {

            }

        public CryptographicCapability(KeyPair keyPair) {
            KeySignature = new KeyData(keyPair);
            }


        public IKeyAdvancedPrivate GetKeyPairAdvancedPrivate() {
            var keypair = KeyEncryption.GetKeyPair() as KeyPairAdvanced;
            return keypair.IKeyAdvancedPrivate;


            }


        }


    }
