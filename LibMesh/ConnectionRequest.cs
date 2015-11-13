using System;
using System.Collections.Generic;
using Goedel.Cryptography.Jose;
using Goedel.CryptoLibNG;
using Goedel.Protocol;

namespace Goedel.Mesh {

    public enum ConnectionStatus {
        Accepted,
        Rejected,
        Pending,
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

        *
        */



        ConnectionResult _Signed;

        public ConnectionResult Data {
            get { if (_Signed == null) _Signed = Unpack(); return _Signed; }
            }

        public ConnectionResult Unpack() {
            _Signed = null;

            var Reader = JSONReader.OfData(SignedData.Payload);

            _Signed = ConnectionResult.FromTagged(Reader);
            return _Signed;
            }


        public static string PrimaryKey(string UniqueID) {
            return "Result-" + UniqueID;
            }

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

        public ConnectionRequest Data {
            get { if (_Signed == null) _Signed = Unpack(); return _Signed; }
            }

        public ConnectionRequest Unpack() {
            _Signed = null;


            var Reader = JSONReader.OfData(SignedData.Payload);
            var Profile = ConnectionRequest.FromTagged(Reader);

            _Signed = Profile;
            return _Signed;
            }


        public SignedConnectionRequest (ConnectionRequest ConnectionRequest) {
            var SignedDeviceProfile = ConnectionRequest.Device;
            var DeviceProfile = SignedDeviceProfile.Data;

            Identifier = DeviceProfile.UDF;

            var PrivateKey = DeviceProfile.DeviceSignatureKey.PrivateKey;
            SignedData = new JoseWebSignature(ConnectionRequest.GetBytes(), PrivateKey);
            }

        }


    public partial class ConnectionRequest {

        public SignedConnectionRequest Signed {
            get { return new SignedConnectionRequest(this); }
            }


        public string UniqueID {
            get { return ParentUDF;  }
            }



        public ConnectionRequest (Account Account, SignedDeviceProfile Device) {

            ParentUDF = Account.UserProfileUDF;
            this.Device = Device;


            }

        public ConnectionRequest(string AccountID, SignedDeviceProfile Device) {

            ParentUDF = AccountID;
            this.Device = Device;


            }


        }



    public partial class ConnectionsPending {
        public override string UniqueID {
            get { return UserProfileUDF; }
            }

        public static new string PrimaryKey(string UniqueID) {
            return "Pending-" + UniqueID;
            }

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
