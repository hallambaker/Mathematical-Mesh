using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;

namespace Goedel.Protocol {

    // Transaction Classes
    /// <summary>
    /// The base class for transaction requests
    /// </summary>
    public abstract class Request : JSONObject {

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag() {
            return "Request";
            }


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize(Writer Writer, bool wrap, ref bool first) {
            SerializeX(Writer, wrap, ref first);
            }

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX(Writer _Writer, bool _wrap, ref bool _first) {
            if (_wrap) {
                _Writer.WriteObjectStart();
                }
            if (_wrap) {
                _Writer.WriteObjectEnd();
                }
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken(JSONReader JSONReader, string Tag) {
            // Don't have any default elements.
            return;
            }


        }

    /// <summary>
    /// </summary>
    public abstract class Response : JSONObject {
        bool __Status = true;
        private int _Status = 201;  // Default value for status is success
        /// <summary>
        /// Numeric status return code value
        /// </summary>
		public int Status {
            get { return _Status; }
            set { _Status = value; __Status = true; }
            }

        public string _Event;
        /// <summary>
        /// Event name.
        /// </summary>
		public string Event {
            get { return _Event; }
            set { _Event = value; }
            }

        /// <summary>
        /// Describes the status code (ignored by processors)
        /// </summary>
		public string StatusDescription;

        /// <summary>
        /// Tag identifying this class.
        /// </summary>
        /// <returns>The tag</returns>
		public override string Tag() {
            return "Response";
            }

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize(Writer Writer, bool wrap, ref bool first) {
            SerializeX(Writer, wrap, ref first);
            }

        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX(Writer _Writer, bool _wrap, ref bool _first) {
            if (_wrap) {
                _Writer.WriteObjectStart();
                }
            if (__Status) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("Status", 1);
                _Writer.WriteInteger32(Status);
                }
            if (StatusDescription != null) {
                _Writer.WriteObjectSeparator(ref _first);
                _Writer.WriteToken("StatusDescription", 1);
                _Writer.WriteString(StatusDescription);
                }
            if (_wrap) {
                _Writer.WriteObjectEnd();
                }
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="JSONReader"></param>
        /// <param name="Tag"></param>
		public override void DeserializeToken(JSONReader JSONReader, string Tag) {

            switch (Tag) {
                case "Status":
                        {
                        Status = JSONReader.ReadInteger32();
                        break;
                        }
                case "StatusDescription":
                        {
                        StatusDescription = JSONReader.ReadString();
                        break;
                        }
                default:
                        {
                        break;
                        }
                }
            }
        }
    }
