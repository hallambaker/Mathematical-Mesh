using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {

    public enum ConnectionState {
        Pending,
        Connected,
        Rejected
        }

    /// <summary>
    /// Class that represents an administrator device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public class ContextAdministrator : ContextDevice {


        public ContextAdministrator(IMeshMachine machine = null, string accountID = null, string profileID = null)   :
            base (machine,accountID, profileID){
            }

        public void Register(string account) => throw new NYI();

        public void ConnectionResponse (string fingerprint, ConnectionState state) => throw new NYI();


        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage Add(ProfileDevice profile) => throw new NYI();

        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage Add(ProfileApplication profile) => throw new NYI();

        }
    }
