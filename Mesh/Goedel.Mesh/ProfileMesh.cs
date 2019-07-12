using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {

    public partial class ActivationAccount {
        public ConnectionAccount AssertionAccountConnection => assertionAccountConnection ??
            ConnectionAccount.Decode(
                    EnvelopedAssertionAccountConnection).CacheValue(out assertionAccountConnection);
        ConnectionAccount assertionAccountConnection;

        }
    public partial class ConnectionAccount {
        public static new ConnectionAccount Decode(DareEnvelope message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }
        }

    public partial class ProfileAccount {

        public override string _PrimaryKey => UDF;
        public string UDF => KeyEncryption.UDF;
        //public byte[] UDFBytes => ProfileMaster.UDFBytes;


        //public ProfileMaster ProfileMaster => profileMaster ??
        //    ProfileMaster.Decode(MasterProfile).CacheValue(out profileMaster);
        //ProfileMaster profileMaster = null;


        public static new ProfileAccount Decode(DareEnvelope message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }
    }
