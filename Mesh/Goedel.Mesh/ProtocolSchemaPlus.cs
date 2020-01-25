using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    public partial class MeshProtocol {

        ///<summary>Initialization property. Access this property to force initialization 
        ///of the static method.</summary>
        public static object Initialize => null;

        static MeshProtocol() {
            AddDictionary(ref Goedel.Protocol.Message._TagDictionary);
            AddDictionary(ref _TagDictionary);
            }
        }


    public partial class MeshResponse {

        /// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
        public new static Dictionary<string, JSONFactoryDelegate> _TagDictionary { get; set; } =
                MeshProtocol._TagDictionary;


        /// <summary>
        /// Default constructor
        /// </summary>

        public MeshResponse(Exception exception = null) {
            if (exception == null) {
                StatusCode = 201;
                StatusDescriptionCode = "Operation completed successfully";
                return;
                }

            // Goal: extend Exceptional preprocessor to enable these to be handled internally

            StatusCode = 400;
            StatusDescriptionCode = "Error occurred";
            switch (exception) {
                case ObjectIdentifierNotUnique e: {
                    StatusDescriptionCode = "Account already registered.";
                    StatusExtended = 1;
                    return;
                    }

                }

            }


        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy() {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = MeshResponse.FromJSON(Text.JSONReader());

            return Result;
            }
        }

    public partial class MeshRequest {

        /// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
        public static new Dictionary<string, JSONFactoryDelegate> _TagDictionary { get; set; } =
                MeshProtocol._TagDictionary;

        /// <summary>
        /// Performs a deep recursive copy of the structure.
        /// </summary>
        /// <returns>Deep copy of the object with all referenced objects
        /// copied.</returns>
        public override JSONObject DeepCopy() {
            // Convert this object to text:
            var Text = ToString();

            // Convert text back to an object:
            var Result = MeshRequest.FromJSON(Text.JSONReader());

            return Result;
            }
        }


    public partial class CreateResponse {
        public CreateResponse(Exception exception = null) : base(exception) {
            }
        }


    public partial class DeleteResponse {
        public DeleteResponse(Exception exception = null) : base(exception) {
            }
        }


    public partial class StatusResponse {
        public StatusResponse(Exception exception = null) : base(exception) {
            }

        public override void ToBuilder(StringBuilder builder, int indent = 0) {
            builder.AppendIndent(indent, "Status");
            if (ContainerStatus != null) {
                foreach (var status in ContainerStatus) {
                    status.ToBuilder(builder, indent + 1);
                    }
                }

            }


        }

    public partial class ContainerStatus {
        public override void ToBuilder(StringBuilder builder, int indent = 0) =>
            builder.AppendIndent(indent, $"{Container}:  {Index} {Digest?.ToStringBase64url()}");
        }


    public partial class ContainerUpdate {
        public override void ToBuilder(StringBuilder builder, int indent = 0) =>
            builder.AppendIndent(indent, $"{Container}:  {Index}+{Envelopes.Count} {Digest?.ToStringBase64url()}");
        }

    public partial class UploadResponse {
        public UploadResponse(Exception exception = null) : base(exception) {
            }
        }

    public partial class PostResponse {
        public PostResponse(Exception exception = null) : base(exception) {
            }
        }

    public partial class DownloadResponse {
        public DownloadResponse(Exception exception = null) : base(exception) {
            }
        }

    public partial class ConnectResponse {
        public ConnectResponse(Exception exception = null) : base(exception) {
            }
        }

    public partial class CompleteResponse {
        public CompleteResponse(Exception exception = null) : base(exception) {
            }
        }
    }
