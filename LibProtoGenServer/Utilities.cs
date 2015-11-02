using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Goedel.Protocol;

namespace NewServer.cs {
    public partial class Utilities {

        public Cryptography.Encryption GetEncryption (List<string> Algs) {
            return Cryptography.Encryption.A128CBC;
            }

        public Cryptography.Authentication GetAuthentication (List<string> Algs) {
            return Cryptography.Authentication.HS256;
            }     
        }
    }
