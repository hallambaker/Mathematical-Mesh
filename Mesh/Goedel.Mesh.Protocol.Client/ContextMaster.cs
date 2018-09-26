using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {

    /// <summary>
    /// Class that represents an administrator device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public class ContextMaster : ContextAdministrator {


        public ContextMaster(
                    IMeshMachine machine = null, string accountID = null, string profileID = null) : 
                base (machine, accountID, profileID){
            }

        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage MakeAdministrator(ProfileDevice Profile) => throw new NYI();


        public static ProfileMaster Recover(DareMessage escrow, KeyShare[] shares) => throw new NYI();

        public (DareMessage, KeyShare[]) Escrow(int shares, int quorum) => throw new NYI();

        }
    }
