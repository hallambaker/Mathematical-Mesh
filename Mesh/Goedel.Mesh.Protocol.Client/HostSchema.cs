
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

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;



using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh.Client {


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
	public abstract partial class HostCatalogItem : global::Goedel.Protocol.JSONObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "HostCatalogItem";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"CatalogedMachine", CatalogedMachine._Factory},
			{"CatalogedStandard", CatalogedStandard._Factory},
			{"CatalogedAdmin", CatalogedAdmin._Factory},
			{"CatalogedPending", CatalogedPending._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) => 
			Out = JSONReader.ReadTaggedObject(_TagDictionary);

		}



		// Service Dispatch Classes



		// Transaction Classes
	/// <summary>
	///
	/// Describes a current or pending connection to a Mesh
	/// </summary>
	public partial class CatalogedMachine : HostCatalogItem {
        /// <summary>
        ///Unique object instance identifier.
        /// </summary>

		public virtual string						ID  {get; set;}
        /// <summary>
        ///Local short name for the profile
        /// </summary>

		public virtual string						Local  {get; set;}
		bool								__Default = false;
		private bool						_Default;
        /// <summary>
        ///If true, this is the default for the profile type (master, account)
        /// </summary>

		public virtual bool						Default {
			get => _Default;
			set {_Default = value; __Default = true; }
			}
        /// <summary>
        ///The master profile that provides the root of trust for this Mesh
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileMaster  {get; set;}
        /// <summary>
        ///The cataloged device profile
        /// </summary>

		public virtual CatalogedDevice						CatalogedDevice  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedMachine";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedMachine();


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
			if (ID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ID", 1);
					_Writer.WriteString (ID);
				}
			if (Local != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Local", 1);
					_Writer.WriteString (Local);
				}
			if (__Default){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Default", 1);
					_Writer.WriteBoolean (Default);
				}
			if (EnvelopedProfileMaster != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedProfileMaster", 1);
					EnvelopedProfileMaster.Serialize (_Writer, false);
				}
			if (CatalogedDevice != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("CatalogedDevice", 1);
					CatalogedDevice.Serialize (_Writer, false);
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
        public static new CatalogedMachine FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedMachine;
				}
		    var Result = new CatalogedMachine ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ID" : {
					ID = JSONReader.ReadString ();
					break;
					}
				case "Local" : {
					Local = JSONReader.ReadString ();
					break;
					}
				case "Default" : {
					Default = JSONReader.ReadBoolean ();
					break;
					}
				case "EnvelopedProfileMaster" : {
					// An untagged structure
					EnvelopedProfileMaster = new DareEnvelope ();
					EnvelopedProfileMaster.Deserialize (JSONReader);
 
					break;
					}
				case "CatalogedDevice" : {
					// An untagged structure
					CatalogedDevice = new CatalogedDevice ();
					CatalogedDevice.Deserialize (JSONReader);
 
					break;
					}
				default : {
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes an ordinary device connected to a Mesh
	/// </summary>
	public partial class CatalogedStandard : CatalogedMachine {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedStandard";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedStandard();


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
			((CatalogedMachine)this).SerializeX(_Writer, false, ref _first);
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
        public static new CatalogedStandard FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedStandard;
				}
		    var Result = new CatalogedStandard ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Information enabling administration of a Master profile. It adds an overlay key
	/// for the administration key.
	/// </summary>
	public partial class CatalogedAdmin : CatalogedMachine {
        /// <summary>
        ///Overlay for the signature key.
        /// </summary>

		public virtual KeyOverlay						SignatureKey  {get; set;}
        /// <summary>
        ///UDF of the connected device
        /// </summary>

		public virtual string						DeviceUDF  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedAdmin";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedAdmin();


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
			((CatalogedMachine)this).SerializeX(_Writer, false, ref _first);
			if (SignatureKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignatureKey", 1);
					SignatureKey.Serialize (_Writer, false);
				}
			if (DeviceUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceUDF", 1);
					_Writer.WriteString (DeviceUDF);
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
        public static new CatalogedAdmin FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedAdmin;
				}
		    var Result = new CatalogedAdmin ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "SignatureKey" : {
					// An untagged structure
					SignatureKey = new KeyOverlay ();
					SignatureKey.Deserialize (JSONReader);
 
					break;
					}
				case "DeviceUDF" : {
					DeviceUDF = JSONReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes a pending connection to a Mesh account believed to have been 
	/// created and posted to a service.
	/// </summary>
	public partial class CatalogedPending : CatalogedMachine {
        /// <summary>
        ///UDF of the connected device
        /// </summary>

		public virtual string						DeviceUDF  {get; set;}
        /// <summary>
        ///The device profile presented to the service.
        /// </summary>

		public virtual DareEnvelope						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The response returned by the service when the registration was requested.
        /// </summary>

		public virtual DareEnvelope						EnvelopedMessageConnectionResponse  {get; set;}
        /// <summary>
        ///The current account assertion
        /// </summary>

		public virtual DareEnvelope						EnvelopedAccountAssertion  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedPending";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new CatalogedPending();


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
			((CatalogedMachine)this).SerializeX(_Writer, false, ref _first);
			if (DeviceUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DeviceUDF", 1);
					_Writer.WriteString (DeviceUDF);
				}
			if (EnvelopedProfileDevice != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_Writer, false);
				}
			if (EnvelopedMessageConnectionResponse != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedMessageConnectionResponse", 1);
					EnvelopedMessageConnectionResponse.Serialize (_Writer, false);
				}
			if (EnvelopedAccountAssertion != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EnvelopedAccountAssertion", 1);
					EnvelopedAccountAssertion.Serialize (_Writer, false);
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
        public static new CatalogedPending FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedPending;
				}
		    var Result = new CatalogedPending ();
			Result.Deserialize (JSONReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "DeviceUDF" : {
					DeviceUDF = JSONReader.ReadString ();
					break;
					}
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new DareEnvelope ();
					EnvelopedProfileDevice.Deserialize (JSONReader);
 
					break;
					}
				case "EnvelopedMessageConnectionResponse" : {
					// An untagged structure
					EnvelopedMessageConnectionResponse = new DareEnvelope ();
					EnvelopedMessageConnectionResponse.Deserialize (JSONReader);
 
					break;
					}
				case "EnvelopedAccountAssertion" : {
					// An untagged structure
					EnvelopedAccountAssertion = new DareEnvelope ();
					EnvelopedAccountAssertion.Deserialize (JSONReader);
 
					break;
					}
				default : {
					base.DeserializeToken(JSONReader, Tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

