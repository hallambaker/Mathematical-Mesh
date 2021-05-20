
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
//  
//  This file was automatically generated at 5/19/2021 10:46:58 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.615
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2019
//  
//  Build Platform: Win32NT 10.0.18362.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Goedel.Protocol;


#pragma warning disable IDE1006


using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh.Client {


	/// <summary>
	///
	/// An entry in the Mesh linked logchain.
	/// </summary>
	public abstract partial class HostCatalogItem : global::Goedel.Protocol.JsonObject {

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
		public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
		static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
				new Dictionary<string, JsonFactoryDelegate> () {

			{"CatalogedMachine", CatalogedMachine._Factory},
			{"CatalogedStandard", CatalogedStandard._Factory},
			{"CatalogedPending", CatalogedPending._Factory},
			{"CatalogedPreconfigured", CatalogedPreconfigured._Factory}			};

        [ModuleInitializer]
        internal static void _Initialize() => AddDictionary(ref _tagDictionary);


		/// <summary>
        /// Construct an instance from the specified tagged JsonReader stream.
        /// </summary>
        /// <param name="jsonReader">Input stream</param>
        /// <param name="result">The created object</param>
        public static void Deserialize(JsonReader jsonReader, out JsonObject result) => 
			result = jsonReader.ReadTaggedObject(_TagDictionary);

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

		public virtual string						Id  {get; set;}
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

		public virtual Enveloped<ProfileAccount>						EnvelopedProfileAccount  {get; set;}
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
		public static new JsonObject _Factory () => new CatalogedMachine();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			if (Id != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Id", 1);
					_writer.WriteString (Id);
				}
			if (Local != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Local", 1);
					_writer.WriteString (Local);
				}
			if (__Default){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Default", 1);
					_writer.WriteBoolean (Default);
				}
			if (EnvelopedProfileAccount != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileAccount", 1);
					EnvelopedProfileAccount.Serialize (_writer, false);
				}
			if (CatalogedDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("CatalogedDevice", 1);
					CatalogedDevice.Serialize (_writer, false);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
		/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedMachine FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedMachine;
				}
		    var Result = new CatalogedMachine ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "Id" : {
					Id = jsonReader.ReadString ();
					break;
					}
				case "Local" : {
					Local = jsonReader.ReadString ();
					break;
					}
				case "Default" : {
					Default = jsonReader.ReadBoolean ();
					break;
					}
				case "EnvelopedProfileAccount" : {
					// An untagged structure
					EnvelopedProfileAccount = new Enveloped<ProfileAccount> ();
					EnvelopedProfileAccount.Deserialize (jsonReader);
 
					break;
					}
				case "CatalogedDevice" : {
					// An untagged structure
					CatalogedDevice = new CatalogedDevice ();
					CatalogedDevice.Deserialize (jsonReader);
 
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
		public static new JsonObject _Factory () => new CatalogedStandard();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CatalogedMachine)this).SerializeX(_writer, false, ref _first);
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
		/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedStandard FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedStandard;
				}
		    var Result = new CatalogedStandard ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				default : {
					base.DeserializeToken(jsonReader, tag);
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

		public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The response returned by the service when the registration was requested.
        /// </summary>

		public virtual Enveloped<AcknowledgeConnection>						EnvelopedAcknowledgeConnection  {get; set;}
        /// <summary>
        ///The account at which the request is pending.
        /// </summary>

		public virtual string						AccountAddress  {get; set;}
		
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
		public static new JsonObject _Factory () => new CatalogedPending();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CatalogedMachine)this).SerializeX(_writer, false, ref _first);
			if (DeviceUDF != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceUDF", 1);
					_writer.WriteString (DeviceUDF);
				}
			if (EnvelopedProfileDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_writer, false);
				}
			if (EnvelopedAcknowledgeConnection != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedAcknowledgeConnection", 1);
					EnvelopedAcknowledgeConnection.Serialize (_writer, false);
				}
			if (AccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddress", 1);
					_writer.WriteString (AccountAddress);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
		/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedPending FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedPending;
				}
		    var Result = new CatalogedPending ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "DeviceUDF" : {
					DeviceUDF = jsonReader.ReadString ();
					break;
					}
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new Enveloped<ProfileDevice> ();
					EnvelopedProfileDevice.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedAcknowledgeConnection" : {
					// An untagged structure
					EnvelopedAcknowledgeConnection = new Enveloped<AcknowledgeConnection> ();
					EnvelopedAcknowledgeConnection.Deserialize (jsonReader);
 
					break;
					}
				case "AccountAddress" : {
					AccountAddress = jsonReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	/// <summary>
	///
	/// Describes a preconfigured Device Profile bound to a remote 
	/// manufacturer profile.
	/// </summary>
	public partial class CatalogedPreconfigured : CatalogedMachine {
        /// <summary>
        ///The device profile presented to the service.
        /// </summary>

		public virtual Enveloped<ProfileDevice>						EnvelopedProfileDevice  {get; set;}
        /// <summary>
        ///The device connection used to authenticate to the service.
        /// </summary>

		public virtual Enveloped<ConnectionDevice>						EnvelopedConnectionDevice  {get; set;}
        /// <summary>
        ///The account to which claims will be posted
        /// </summary>

		public virtual string						AccountAddress  {get; set;}
        /// <summary>
        ///The publication identifier
        /// </summary>

		public virtual string						PublicationId  {get; set;}
        /// <summary>
        ///Authenticator key used to authenticate claim to the service.
        /// </summary>

		public virtual string						ServiceAuthenticator  {get; set;}
        /// <summary>
        ///Authenticator key used to authenticate claim to the device.	
        /// </summary>

		public virtual string						DeviceAuthenticator  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "CatalogedPreconfigured";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new CatalogedPreconfigured();


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer writer, bool wrap, ref bool first) =>
			SerializeX (writer, wrap, ref first);


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// Unlike the Serlialize() method, this method is not inherited from the
        /// parent class allowing a specific version of the method to be called.
        /// </summary>
        /// <param name="_writer">Output stream</param>
        /// <param name="_wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="_first">If true, item is the first entry in a list.</param>
		public new void SerializeX (Writer _writer, bool _wrap, ref bool _first) {
			PreEncode();
			if (_wrap) {
				_writer.WriteObjectStart ();
				}
			((CatalogedMachine)this).SerializeX(_writer, false, ref _first);
			if (EnvelopedProfileDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedProfileDevice", 1);
					EnvelopedProfileDevice.Serialize (_writer, false);
				}
			if (EnvelopedConnectionDevice != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("EnvelopedConnectionDevice", 1);
					EnvelopedConnectionDevice.Serialize (_writer, false);
				}
			if (AccountAddress != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("AccountAddress", 1);
					_writer.WriteString (AccountAddress);
				}
			if (PublicationId != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("PublicationId", 1);
					_writer.WriteString (PublicationId);
				}
			if (ServiceAuthenticator != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ServiceAuthenticator", 1);
					_writer.WriteString (ServiceAuthenticator);
				}
			if (DeviceAuthenticator != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceAuthenticator", 1);
					_writer.WriteString (DeviceAuthenticator);
				}
			if (_wrap) {
				_writer.WriteObjectEnd ();
				}
			}

        /// <summary>
        /// Deserialize a tagged stream
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
		/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
        /// <returns>The created object.</returns>		
        public static new CatalogedPreconfigured FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogedPreconfigured;
				}
		    var Result = new CatalogedPreconfigured ();
			Result.Deserialize (jsonReader);
			Result.PostDecode();
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="jsonReader">The input stream</param>
        /// <param name="tag">The tag</param>
		public override void DeserializeToken (JsonReader jsonReader, string tag) {
			
			switch (tag) {
				case "EnvelopedProfileDevice" : {
					// An untagged structure
					EnvelopedProfileDevice = new Enveloped<ProfileDevice> ();
					EnvelopedProfileDevice.Deserialize (jsonReader);
 
					break;
					}
				case "EnvelopedConnectionDevice" : {
					// An untagged structure
					EnvelopedConnectionDevice = new Enveloped<ConnectionDevice> ();
					EnvelopedConnectionDevice.Deserialize (jsonReader);
 
					break;
					}
				case "AccountAddress" : {
					AccountAddress = jsonReader.ReadString ();
					break;
					}
				case "PublicationId" : {
					PublicationId = jsonReader.ReadString ();
					break;
					}
				case "ServiceAuthenticator" : {
					ServiceAuthenticator = jsonReader.ReadString ();
					break;
					}
				case "DeviceAuthenticator" : {
					DeviceAuthenticator = jsonReader.ReadString ();
					break;
					}
				default : {
					base.DeserializeToken(jsonReader, tag);
					break;
					}
				}
			// check up that all the required elements are present
			}


		}

	}

