#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion

using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {


    public partial class HostCatalogItem {

        /////<summary>Dummy property used to force initialization.</summary>
        //public static object Initialize => null;

        //static HostCatalogItem() => AddDictionary(ref _TagDictionary);
        }

    public partial class CatalogedMachine {

        ///<summary>The unique identifier.</summary>
        public override string _PrimaryKey => Id;

        ///<summary>The device profile</summary>
        public virtual ProfileDevice ProfileDevice => throw new NYI();

        }


    public partial class CatalogedStandard {

        ///<summary>The device profile (from <see cref="CatalogedDevice"/>)</summary>
        public override ProfileDevice ProfileDevice => CatalogedDevice?.ProfileDevice;


        }

    //public partial class CatalogedAdmin {

    //    ///<summary>The device profile (from <see cref="CatalogedDevice"/>)</summary>
    //    public override ProfileDevice ProfileDevice => CatalogedDevice?.ProfileDevice;

    //    /// <summary>
    //    /// Default constructor used for deserialization.
    //    /// </summary>
    //    public CatalogedAdmin() {
    //        }

    //    }


    public partial class CatalogedPending {

        ///<summary>The decoded device profile (from <see cref="EnvelopedProfileDevice"/>)</summary>
        public override ProfileDevice ProfileDevice =>
                    ProfileDevice.Decode(EnvelopedProfileDevice);


        /// <summary>
        /// Cached convenience accessor returning the decoded <see cref="MessageConnectionResponse"/>.
        /// </summary>
        public Message MessageConnectionResponse => messageConnectionResponse ??
            Message.Decode(EnvelopedAcknowledgeConnection).
                CacheValue(out messageConnectionResponse);
        Message messageConnectionResponse;

        ///<summary>Return the corresponding response identifier.</summary>
        public string GetResponseID() => MessageConnectionResponse switch {
            AcknowledgeConnection acknowledgeConnection => acknowledgeConnection.GetResponseId(),
            MessageClaim messageClaim => messageClaim.GetResponseId(),
            _ => throw new NYI()
            };

        }
    public partial class CatalogedPreconfigured {
        ///<summary>The decoded device profile (from <see cref="EnvelopedProfileDevice"/>)</summary>
        public override ProfileDevice ProfileDevice =>
                    EnvelopedProfileDevice.Decode();
        ///<summary>The decoded connection device</summary> 
        public ConnectionService ConnectionDevice =>
                    EnvelopedConnectionDevice.Decode();

        //            (var account, var key) = MeshUri.ParseConnectUri(devicePreconfiguration.ConnectUri);
        }
    }