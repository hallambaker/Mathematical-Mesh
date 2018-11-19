using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {

    public partial class MeshProtocol {

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
        public MeshResponse() {
            StatusCode = 201;
            StatusDescriptionCode = "Operation completed successfully";
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

        public CreateResponse() :base () {
            }
        public CreateResponse(Exception exception) {
            switch (exception) {
                case ObjectIdentifierNotUnique e: {
                    StatusCode = 400;
                    StatusDescriptionCode = "Account already registered.";

                    return;
                    }

                }

            }
        }


    public partial class DeleteResponse {

        public DeleteResponse() : base() {
            }
        public DeleteResponse(Exception exception) {
            StatusCode = 400;
            switch (exception) {
                case ObjectIdentifierNotUnique e: {
                    StatusDescriptionCode = "Account already registered.";
                    return;
                    }

                }

            }
        }


    public partial class StatusResponse {

        public StatusResponse() : base() {
            }
        public StatusResponse(Exception exception) {
            StatusCode = 400;
            switch (exception) {
                case ObjectIdentifierNotUnique e: {
                    StatusDescriptionCode = "Account already registered.";
                    return;
                    }

                }

            }
        }

    }
