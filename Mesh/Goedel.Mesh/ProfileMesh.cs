using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {
    public partial class ProfileMesh {

        public override string _PrimaryKey => Account;

        public ProfileDevice ProfileDevice => profileDevice ??
            ProfileDevice.Decode(DeviceProfile).CacheValue(out profileDevice);

        ProfileDevice profileDevice = null;


        public static ProfileMesh Decode(DareMessage message) =>
                FromJSON(message.GetBodyReader(), true);
        }
    }
