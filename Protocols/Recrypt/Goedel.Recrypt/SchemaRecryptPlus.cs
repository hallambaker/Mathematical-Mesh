using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Protocol;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;

namespace Goedel.Recrypt {

    /// <summary>
    ///
    /// Mesh profile for Recrypt applications.
    /// </summary>
    public abstract partial class MeshRecrypt {

        static bool _Initialized = false;

        /// <summary>Initialize the Mesh/Recrypt libraries.</summary>
        public static void Initialize () {
            if (!_Initialized) {
                MeshItem.Append(_TagDictionary);
                }
            _Initialized = true;
            }

        }


    public partial class RecryptionGroup {
        /// <summary>The primary key for this object </summary>
        public override string _PrimaryKey  => PrimaryKey(GroupName); 
        
        /// <summary>The primary key for an object</summary>
        /// <param name="GroupName">The group name</param>
        /// <returns>The primary key</returns>
        public static string PrimaryKey (string GroupName) => "Group$" + GroupName;
        }


    //public partial class CombinedToGroup {
    //    public override string _PrimaryKey { get => PrimaryKey(EncryptionKeyUDF, MemberKeyUDF); }
    //    public static string PrimaryKey (string GroupKey, string MemberKey) =>
    //        "Member$" + GroupKey + "$" + MemberKey;
    //    }


    public partial class UserDecryptionEntry {

        /// <summary>The primary key for this object </summary>
   
        public override string _PrimaryKey  => PrimaryKey(EncryptionKeyUDF, MemberKeyUDF);

        /// <summary>The primary key for an object </summary>
        /// <param name="GroupKey">The group key</param>
        /// <param name="MemberKey">The member key.</param>
        /// <returns>The primary key.</returns>
        public static string PrimaryKey (string GroupKey, string MemberKey) =>
            "Member$" + GroupKey + "$" + MemberKey;

        /// <summary>
        /// Perform a RecryptData transaction.
        /// </summary>
        /// <param name="Request">The request object</param>
        /// <returns>The response object</returns>
        public RecryptDataResponse RecryptData (RecryptDataRequest Request) {

            var EphemeralKey = Request.EphemeralKey.GetKeyPair() ;
            var RecryptKey = RecryptionKey.GetKeyPair();


            var Agreement = RecryptKey.Agreement(EphemeralKey);

            var Result = KeyAgreement.Factory(Agreement);

            var RecryptDataResponse = new RecryptDataResponse() {
                Partial = Result.GetJson(),
                DecryptionKey = DecryptionKey
                };

            return RecryptDataResponse;
            }


        }


    public partial class RecryptResponse {

        /// <summary>The tag dictionary.</summary>
        public static new Dictionary<string, JSONFactoryDelegate> _TagDictionary =
            Merge(Message._TagDictionary, RecryptProtocol._TagDictionary);  // Hack: should fix the generator


        /// <summary>
        /// Numeric status return code value
        /// </summary>
        public override int StatusCode {
            get { return Status; }
            set { Status = value; }
            }

        /// <summary>
        /// Description of the status code (for debugging).
        /// </summary>
        public override string StatusDescriptionCode {
            get {
                return StatusDescription;
                }
            set {
                StatusDescription = value;
                }
            }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecryptResponse () {
            StatusCode = 201;
            StatusDescriptionCode = "Operation completed successfully";
            }

        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy () {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = FromJSON(Text.JSONReader());

            return Result;
            }
        }

    public partial class RecryptRequest {

        /// <summary>The tag dictionary.</summary>
        public static new Dictionary<string, JSONFactoryDelegate> _TagDictionary =
            Merge(Message._TagDictionary, RecryptProtocol._TagDictionary);  // Hack: should fix the generator

        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy () {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = FromJSON(Text.JSONReader());

            return Result;
            }
        }
    }
