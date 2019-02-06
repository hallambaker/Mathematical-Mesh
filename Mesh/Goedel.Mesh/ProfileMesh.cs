using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {
    public partial class ProfileMesh {

        public override string _PrimaryKey => Account;
        public string UDF => ProfileMaster.UDF;
        public byte[] UDFBytes => ProfileMaster.UDFBytes;


        public ProfileMaster ProfileMaster => profileMaster ??
            ProfileMaster.Decode(MasterProfile).CacheValue(out profileMaster);
        ProfileMaster profileMaster = null;



        public static ProfileMesh Decode(DareMessage message) =>
                FromJSON(message.GetBodyReader(), true);
        }
    }
