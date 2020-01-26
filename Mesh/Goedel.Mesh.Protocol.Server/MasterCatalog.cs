
//  Copyright (c) 2016 by .
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
//  #% var InheritsOverride = "override"; // "virtual"

using System.Collections.Generic;
using Goedel.Protocol;
#pragma warning disable IDE1006


using Goedel.Cryptography.Dare;


namespace Goedel.Mesh.Server {


    /// <summary>
    ///
    /// An entry in the Mesh linked logchain.
    /// </summary>
    public abstract partial class CatalogItem : global::Goedel.Protocol.JSONObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogItem";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"AccountEntry", AccountEntry._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="jsonReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader jsonReader, out JSONObject Out) => 
			Out = jsonReader.ReadTaggedObject(_TagDictionary);

		}



		// Service Dispatch Classes



		// Transaction Classes
	/// <summary>
	///
	/// Represents a Mesh Account.
	/// </summary>
	public partial class AccountEntry : CatalogItem {
        /// <summary>
        ///Subdirectory containing the catalogs and spools for the account.
        /// </summary>

		public virtual string						Directory  {get; set;}
        /// <summary>
        ///The service account to bind to.
        /// </summary>

		public virtual string						ServiceID  {get; set;}
        /// <summary>
        ///The persistent profile that will be used to validate changes to the
        ///account assertion.
        /// </summary>

		public virtual DareEnvelope						SignedProfileMesh  {get; set;}
        /// <summary>
        ///The signed assertion describing the account.
        /// </summary>

		public virtual DareEnvelope						SignedAssertionAccount  {get; set;}
        /// <summary>
        ///The profile status. Valid values are "Pending", "Connected", "Blocked"
        /// </summary>

		public virtual string						Status  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "AccountEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new AccountEntry();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) =>
			SerializeX (Writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_Writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Directory != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Directory", 1);
					_Writer.WriteString (Directory);
				}
			if (ServiceID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ServiceID", 1);
					_Writer.WriteString (ServiceID);
				}
			if (SignedProfileMesh != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedProfileMesh", 1);
					SignedProfileMesh.Serialize (_Writer, false);
				}
			if (SignedAssertionAccount != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignedAssertionAccount", 1);
					SignedAssertionAccount.Serialize (_Writer, false);
				}
			if (Status != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Status", 1);
					_Writer.WriteString (Status);
				}
			if (_wrap) {
				_Writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
		/// <param name="Tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new AccountEntry FromJSON (JSONReader jsonReader, bool Tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as AccountEntry;
				}
		    var Result = new AccountEntry ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader jsonReader, string Tag) {
			
			switch (Tag) {
				case "Directory" : {
					Directory = jsonReader.ReadString ();
					break;
					}
				case "ServiceID" : {
					ServiceID = jsonReader.ReadString ();
					break;
					}
				case "SignedProfileMesh" : {
					// An untagged structure
					SignedProfileMesh = new DareEnvelope ();
					SignedProfileMesh.Deserialize (jsonReader);
 
					break;
					}
				case "SignedAssertionAccount" : {
					// An untagged structure
					SignedAssertionAccount = new DareEnvelope ();
					SignedAssertionAccount.Deserialize (jsonReader);
 
					break;
					}
				case "Status" : {
					Status = jsonReader.ReadString ();
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

