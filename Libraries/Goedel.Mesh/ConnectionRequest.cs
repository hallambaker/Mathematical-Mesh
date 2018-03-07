//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography;
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

        ConnectionResult _Signed;

        /// <summary>
        /// Get the inner connection result data.
        /// </summary>
        public ConnectionResult Data {
            get {
                _Signed = _Signed ?? UnpackConnectionResult();
                return _Signed;
                }
            }

        /// <summary>
        /// Unpack the connection result.
        /// </summary>
        /// <returns>The unpacked request</returns>
        public  ConnectionResult UnpackConnectionResult() {
            _Signed = null;

            var Reader = JSONReader.OfData(SignedData.Payload);

            _Signed = ConnectionResult.FromJSON(Reader);
            return _Signed;
            }

        /// <summary>
        /// Construct a primary key ID.
        /// </summary>
        /// <param name="UniqueID">The unique key</param>
        /// <returns>The key as an ID</returns>
        public static string PrimaryKey(string UniqueID) {
            return "Result-" + UniqueID;
            }


        /// <summary>
        /// The primary key
        /// </summary>
        public override string _PrimaryKey => PrimaryKey(Identifier);

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SignedConnectionResult () { }

        /// <summary>
        /// Create a signed connection result.
        /// </summary>
        /// <param name="ConnectionResult">Data to sign.</param>
        /// <param name="AdminKey">Signing key.</param>
        public SignedConnectionResult(ConnectionResult ConnectionResult,
                    KeyPair AdminKey) {
            var SignedDeviceProfile = ConnectionResult.Device;
            var DeviceProfile = SignedDeviceProfile.DeviceProfile;

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
            get {
                _Signed = _Signed ?? UnpackConnectionRequest();
                return _Signed;
                }
            }

        /// <summary>
        /// Unpack the connection request data.
        /// </summary>
        /// <returns>The unpacked request.</returns>
        public ConnectionRequest UnpackConnectionRequest() {
            _Signed = null;


            var Reader = JSONReader.OfData(SignedData.Payload);
            var Profile = ConnectionRequest.FromJSON(Reader);

            _Signed = Profile;
            return _Signed;
            }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SignedConnectionRequest () { }

        /// <summary>
        /// Sign a connection request.
        /// </summary>
        /// <param name="ConnectionRequest">Connection request to sign.</param>
        public SignedConnectionRequest (ConnectionRequest ConnectionRequest) {
            var SignedDeviceProfile = ConnectionRequest.Device;
            var DeviceProfile = SignedDeviceProfile.DeviceProfile;

            Identifier = DeviceProfile.UDF;

            var PrivateKey = DeviceProfile.DeviceSignatureKey.PrivateKey;
            SignedData = new JoseWebSignature(ConnectionRequest.GetBytes(), PrivateKey);
            }

        }


    public partial class ConnectionRequest {

        /// <summary>
        /// Return a signed version of the data.
        /// </summary>
        public SignedConnectionRequest SignedConnectionRequest => new SignedConnectionRequest(this); 


        }


    /// <summary>
    /// Track connections pending.
    /// </summary>
    public partial class ConnectionsPending {

        /// <summary>
        /// The primary key
        /// </summary>
        public override string _PrimaryKey => PrimaryKey(AccountID);


        /// <summary>
        /// Get the primary key.
        /// </summary>
        /// <param name="UniqueID">ID of object to construct key for.</param>
        /// <returns>The constructed key.</returns>
        public static new string PrimaryKey (string UniqueID) {
            return "Pending-" + UniqueID;
            }

        ///// <summary>
        ///// Construct object for the specified account.
        ///// </summary>
        ///// <param name="AccountID"></param>
        //public ConnectionsPending (string AccountID) {
        //    this.AccountID = AccountID;
        //    Requests = new List<SignedConnectionRequest>();
        //    }

        /// <summary>
        /// Purge expired requests (currently a placeholder);
        /// </summary>
        public void Purge () {

            }

        }

    }
