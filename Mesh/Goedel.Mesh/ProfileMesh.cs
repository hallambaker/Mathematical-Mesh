﻿using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {
    public partial class AssertionAccount {

        public override string _PrimaryKey => UDF;
        public string UDF => AccountEncryptionKey.UDF;
        public byte[] UDFBytes => ProfileMaster.UDFBytes;


        /// <summary>
        /// The signed device profile
        /// </summary>
        public override DareMessage DareMessage => ProfileMeshSigned;

        /// <summary>
        /// The signed device profile
        /// </summary>
        public DareMessage ProfileMeshSigned { get; private set; }

        public ProfileMaster ProfileMaster => profileMaster ??
            ProfileMaster.Decode(MasterProfile).CacheValue(out profileMaster);
        ProfileMaster profileMaster = null;


        public void Sign(KeyPair signingKeyPair)=> ProfileMeshSigned=
            DareMessage.Encode(GetBytes(true), signingKey: signingKeyPair);


        public static AssertionAccount Decode(DareMessage message) {
            var result = FromJSON(message.GetBodyReader(), true);
            result.ProfileMeshSigned = message;
            return result;
            }

        }
    }
