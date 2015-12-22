//Sample license text.
using System;
using System.Collections.Generic;
using Goedel.Cryptography.Jose;
using Goedel.LibCrypto;
using Goedel.Protocol;

namespace Goedel.Mesh {

    /// <summary>
    /// Tracks the status of a device profile connection request.
    /// </summary>
    public enum ConnectionStatus {
        /// <summary>
        /// Request was accepted.
        /// </summary>
        Accepted,

        /// <summary>
        /// Request has been rejected.
        /// </summary>
        Rejected,

        /// <summary>
        /// Request is pending.
        /// </summary>
        Pending,

        /// <summary>
        /// Status is not known.
        /// </summary>
        Unknown,
        }


    public partial class SignedConnectionResult {
        /*
        *
        * Should consistently tag all profiles /toplevel items in both stores

            SignedProfile
                Inner -> The inner signed object as toplevel
                Data -> The inner signed object in that type
                new (Profile, key) Construct by signing Profile with specified Key
                new (Profile) Construct by signing Profile with implied key


            Profile
                Signed -> Singed object wrapping this one
                

            UniqueID - A key uniquely identifying objects of this type
            PrimaryKey (string) - wrap specified identifier to create globally unique key

            Override comparison operators so List<t> methods work right.

        */



        ConnectionResult _Signed;

        /// <summary>
        /// Get the inner connection result data.
        /// </summary>
        public ConnectionResult Data {
            get { if (_Signed == null) _Signed = Unpack(); return _Signed; }
            }

        /// <summary>
        /// Unpack the connection result.
        /// </summary>
        /// <returns>The unpacked request</returns>
        public ConnectionResult Unpack() {
            _Signed = null;

            var Reader = JSONReader.OfData(SignedData.Payload);

            _Signed = ConnectionResult.FromTagged(Reader);
            return _Signed;
            }

        /// <summary>
        /// Construct a primary key ID.
        /// </summary>
        /// <param name="UniqueID"></param>
        /// <returns></returns>
        public static string PrimaryKey(string UniqueID) {
            return "Result-" + UniqueID;
            }

        /// <summary>
        /// Create a signed connection result.
        /// </summary>
        /// <param name="ConnectionResult">Data to sign.</param>
        /// <param name="AdminKey">Signing key.</param>
        public SignedConnectionResult(ConnectionResult ConnectionResult,
                    KeyPair AdminKey) {
            var SignedDeviceProfile = ConnectionResult.Device;
            var DeviceProfile = SignedDeviceProfile.Data;

            Identifier = DeviceProfile.UDF;
            SignedData = new JoseWebSignature(ConnectionResult.GetBytes(), AdminKey);
            }

        }


    public partial class SignedConnectionRequest {

        ConnectionRequest _Signed;

        /// <summary>
        /// Get the connection request data.
        /// </summary>
        public ConnectionRequest Data {
            get { if (_Signed == null) _Signed = Unpack(); return _Signed; }
            }

        /// <summary>
        /// Unpack the connection request data.
        /// </summary>
        /// <returns>The unpacked request.</returns>
        public ConnectionRequest Unpack() {
            _Signed = null;


            var Reader = JSONReader.OfData(SignedData.Payload);
            var Profile = ConnectionRequest.FromTagged(Reader);

            _Signed = Profile;
            return _Signed;
            }

        /// <summary>
        /// Sign a connection request.
        /// </summary>
        /// <param name="ConnectionRequest">Connection request to sign.</param>
        public SignedConnectionRequest (ConnectionRequest ConnectionRequest) {
            var SignedDeviceProfile = ConnectionRequest.Device;
            var DeviceProfile = SignedDeviceProfile.Data;

            Identifier = DeviceProfile.UDF;

            var PrivateKey = DeviceProfile.DeviceSignatureKey.PrivateKey;
            SignedData = new JoseWebSignature(ConnectionRequest.GetBytes(), PrivateKey);
            }

        }


    public partial class ConnectionRequest {

        /// <summary>
        /// Return a signed version of the data.
        /// </summary>
        public SignedConnectionRequest Signed {
            get { return new SignedConnectionRequest(this); }
            }

        /// <summary>
        /// A unique object ID.
        /// </summary>
        public string UniqueID {
            get { return ParentUDF;  }
            }


        /// <summary>
        /// Construct a connection request to attach a device to the 
        /// personal profile of the specified account.
        /// </summary>
        /// <param name="Account">Account to request connection to.</param>
        /// <param name="Device">Device to connect.</param>
        public ConnectionRequest (Account Account, SignedDeviceProfile Device) {

            ParentUDF = Account.UserProfileUDF;
            this.Device = Device;


            }

        /// <summary>
        /// Construct a connection request to attach a device to the 
        /// personal profile of the specified account.
        /// </summary>
        /// <param name="AccountID">Account to request connection to.</param>
        /// <param name="Device">Device to connect.</param>
        public ConnectionRequest(string AccountID, SignedDeviceProfile Device) {

            ParentUDF = AccountID;
            this.Device = Device;


            }


        }



    public partial class ConnectionsPending {
        /// <summary>
        /// Unique identifier for connections pending object.
        /// </summary>
        public override string UniqueID {
            get { return UserProfileUDF; }
            }

        /// <summary>
        /// Get the primary key.
        /// </summary>
        /// <param name="UniqueID">ID of object to construct key for.</param>
        /// <returns>The constructed key.</returns>
        public static new string PrimaryKey(string UniqueID) {
            return "Pending-" + UniqueID;
            }

        /// <summary>
        /// Construct object for the specified account.
        /// </summary>
        /// <param name="AccountID"></param>
        public ConnectionsPending (string AccountID) {
            this.AccountID = AccountID;
            Requests = new List<SignedConnectionRequest>();
            }

        /// <summary>
        /// Purge expired requests (currently a placeholder);
        /// </summary>
        public void Purge () {

            }

        }

    }
