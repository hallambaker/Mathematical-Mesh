using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Registry;
using Goedel.Protocol;

namespace Goedel.Protocol {
    public partial class Seed : _Choice {
        Cryptography.Key _MasterSeed;
        
        public Cryptography.Key MasterSeed {
            get { 
                if (_MasterSeed != null) return _MasterSeed;
                if (Data != null) {
                    byte [] KeyData = BaseConvert.FromBase64urlString (Data);
                    _MasterSeed = new Cryptography.Key (
                        KeyData, Cryptography.Authentication.Unknown, Cryptography.Encryption.Unknown);
                    return _MasterSeed;
                    }
                return null;
                }
            set { _MasterSeed = value;
                Data = Convert.ToBase64String (_MasterSeed.KeyData); }
            }

        public Seed(int ExpiryHours) : base () {
            MasterSeed = new Cryptography.Key ();
            //Expiry = "ExpiryTime" + ExpiryHours.ToString ();
            }
        public Seed()
            : base() {
            }
        }


    }
