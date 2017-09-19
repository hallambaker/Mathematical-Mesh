
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
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Protocol;



using Goedel.Cryptography.Jose;


namespace Goedel.Mesh {


	/// <summary>
	/// </summary>
	public abstract partial class MeshCatalog : global::Goedel.Protocol.JSONObject {

        /// <summary>
        /// Schema tag.
        /// </summary>
        /// <returns>The tag value</returns>
		public override string Tag () {
			return _Tag;
			}

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "MeshCatalog";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"ApplicationProfileCatalog", ApplicationProfileCatalog._Factory},
			{"CatalogEntry", CatalogEntry._Factory},
			{"TypedData", TypedData._Factory},
			{"CredentialProfile", CredentialProfile._Factory},
			{"CredentialProfilePrivate", CredentialProfilePrivate._Factory},
			{"CredentialEntry", CredentialEntry._Factory},
			{"BookmarkProfile", BookmarkProfile._Factory},
			{"BookmarkProfilePrivate", BookmarkProfilePrivate._Factory},
			{"BookmarkEntry", BookmarkEntry._Factory},
			{"ContactProfile", ContactProfile._Factory},
			{"ContactProfilePrivate", ContactProfilePrivate._Factory},
			{"ContactEntry", ContactEntry._Factory},
			{"PersonalName", PersonalName._Factory},
			{"Address", Address._Factory},
			{"Internet", Internet._Factory},
			{"Postal", Postal._Factory},
			{"ContactPerson", ContactPerson._Factory},
			{"ContactOrganization", ContactOrganization._Factory}			};

		/// <summary>
        /// Construct an instance from the specified tagged JSONReader stream.
        /// </summary>
        /// <param name="JSONReader">Input stream</param>
        /// <param name="Out">The created object</param>
        public static void Deserialize(JSONReader JSONReader, out JSONObject Out) {
			Out = JSONReader.ReadTaggedObject (_TagDictionary);
            }
		}



		// Service Dispatch Classes



		// Transaction Classes
	/// <summary>
	///
	/// Base class for all application profiles that are tied to an 
	/// account profile
	/// </summary>
	abstract public partial class ApplicationProfileCatalog : ApplicationProfile {
        /// <summary>
        ///The account to which this profile is bound
        /// </summary>

		public virtual string						AccountIdentifier  {get; set;}
        /// <summary>
        ///The person to which this profile is bound
        /// </summary>

		public virtual string						PersonalUDF  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ApplicationProfileCatalog";

		/// <summary>
        /// Factory method. Throws exception as this is an abstract class.
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			throw new CannotCreateAbstract();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfile)this).SerializeX(_Writer, false, ref _first);
			if (AccountIdentifier != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AccountIdentifier", 1);
					_Writer.WriteString (AccountIdentifier);
				}
			if (PersonalUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("PersonalUDF", 1);
					_Writer.WriteString (PersonalUDF);
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
        public static new ApplicationProfileCatalog FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ApplicationProfileCatalog;
				}
			throw new CannotCreateAbstract();
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "AccountIdentifier" : {
					AccountIdentifier = JSONReader.ReadString ();
					break;
					}
				case "PersonalUDF" : {
					PersonalUDF = JSONReader.ReadString ();
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
	/// </summary>
	public partial class CatalogEntry : MeshCatalog {
        /// <summary>
        ///Unique identifier for the entry. If present, overrides the identifier 
        ///specified in the entry.
        /// </summary>

		public virtual string						ID  {get; set;}
        /// <summary>
        ///The time the site was added
        /// </summary>

		public virtual DateTime?						Added  {get; set;}
        /// <summary>
        ///The last time the entry was updated
        /// </summary>

		public virtual DateTime?						Updated  {get; set;}
        /// <summary>
        ///The last time the entry was updated
        /// </summary>

		public virtual DateTime?						Deleted  {get; set;}
        /// <summary>
        ///Labels identifying the group(s) that the entry is filed under
        /// </summary>

		public virtual List<string>				Label  {get; set;}
        /// <summary>
        ///Source data for the entry
        /// </summary>

		public virtual List<TypedData>				Source  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CatalogEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CatalogEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (ID != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ID", 1);
					_Writer.WriteString (ID);
				}
			if (Added != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Added", 1);
					_Writer.WriteDateTime (Added);
				}
			if (Updated != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Updated", 1);
					_Writer.WriteDateTime (Updated);
				}
			if (Deleted != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Deleted", 1);
					_Writer.WriteDateTime (Deleted);
				}
			if (Label != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Label", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Label) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Source != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Source", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Source) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
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
        public static new CatalogEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CatalogEntry;
				}
		    var Result = new CatalogEntry ();
			Result.Deserialize (JSONReader);
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
				case "Added" : {
					Added = JSONReader.ReadDateTime ();
					break;
					}
				case "Updated" : {
					Updated = JSONReader.ReadDateTime ();
					break;
					}
				case "Deleted" : {
					Deleted = JSONReader.ReadDateTime ();
					break;
					}
				case "Label" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Label = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Label.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Source" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Source = new List <TypedData> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  TypedData ();
						_Item.Deserialize (JSONReader);
						// var _Item = new TypedData (JSONReader);
						Source.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// </summary>
	public partial class TypedData : MeshCatalog {
        /// <summary>
        ///IANA Content Type identifier
        /// </summary>

		public virtual string						ContentType  {get; set;}
        /// <summary>
        ///The described data
        /// </summary>

		public virtual byte[]						Data  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "TypedData";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new TypedData();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (ContentType != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ContentType", 1);
					_Writer.WriteString (ContentType);
				}
			if (Data != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Data", 1);
					_Writer.WriteBinary (Data);
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
        public static new TypedData FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as TypedData;
				}
		    var Result = new TypedData ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "ContentType" : {
					ContentType = JSONReader.ReadString ();
					break;
					}
				case "Data" : {
					Data = JSONReader.ReadBinary ();
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
	/// Stores usernames and passwords. There are no public fields.
	/// </summary>
	public partial class CredentialProfile : ApplicationProfileCatalog {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CredentialProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CredentialProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfileCatalog)this).SerializeX(_Writer, false, ref _first);
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
        public static new CredentialProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CredentialProfile;
				}
		    var Result = new CredentialProfile ();
			Result.Deserialize (JSONReader);
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
	/// Private part of the profile.
	/// </summary>
	public partial class CredentialProfilePrivate : ApplicationProfilePrivate {
		bool								__AutoGenerate = false;
		private bool						_AutoGenerate;
        /// <summary>
        ///If true, a client MAY offer to automatically generate strong
        ///(i.e. not memorable) passwords for a user. A user would not
        ///normally want to use this feature unless they have access to
        ///Mesh password management on every device they use to browse
        ///the Web
        /// </summary>

		public virtual bool						AutoGenerate {
			get {return _AutoGenerate;}
			set {_AutoGenerate = value; __AutoGenerate = true; }
			}
        /// <summary>
        ///A list of password credential entries.
        /// </summary>

		public virtual List<CredentialEntry>				Entries  {get; set;}
        /// <summary>
        ///A list of domain names of sites for which clients MUST NOT
        ///ask to store passwords for.
        /// </summary>

		public virtual List<string>				NeverAsk  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CredentialProfilePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CredentialProfilePrivate();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfilePrivate)this).SerializeX(_Writer, false, ref _first);
			if (__AutoGenerate){
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AutoGenerate", 1);
					_Writer.WriteBoolean (AutoGenerate);
				}
			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (NeverAsk != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("NeverAsk", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in NeverAsk) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
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
        public static new CredentialProfilePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CredentialProfilePrivate;
				}
		    var Result = new CredentialProfilePrivate ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "AutoGenerate" : {
					AutoGenerate = JSONReader.ReadBoolean ();
					break;
					}
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <CredentialEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  CredentialEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new CredentialEntry (JSONReader);
						Entries.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "NeverAsk" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					NeverAsk = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						NeverAsk.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// Username password entry for a single site
	/// </summary>
	public partial class CredentialEntry : CatalogEntry {
        /// <summary>
        ///DNS name of site *.example.com matches www.example.com
        ///etc.
        /// </summary>

		public virtual List<string>				Sites  {get; set;}
        /// <summary>
        ///Case sensitive username
        /// </summary>

		public virtual string						Username  {get; set;}
        /// <summary>
        ///Case sensitive password.
        /// </summary>

		public virtual string						Password  {get; set;}
        /// <summary>
        ///Protocol identifier, e.g. http, sftp, ssh, etc.
        /// </summary>

		public virtual string						Protocol  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "CredentialEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new CredentialEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogEntry)this).SerializeX(_Writer, false, ref _first);
			if (Sites != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Sites", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Sites) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Username != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Username", 1);
					_Writer.WriteString (Username);
				}
			if (Password != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Password", 1);
					_Writer.WriteString (Password);
				}
			if (Protocol != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Protocol", 1);
					_Writer.WriteString (Protocol);
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
        public static new CredentialEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as CredentialEntry;
				}
		    var Result = new CredentialEntry ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Sites" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Sites = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Sites.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Username" : {
					Username = JSONReader.ReadString ();
					break;
					}
				case "Password" : {
					Password = JSONReader.ReadString ();
					break;
					}
				case "Protocol" : {
					Protocol = JSONReader.ReadString ();
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
	/// Stores Web site bookmarks in a hierarchical 
	/// </summary>
	public partial class BookmarkProfile : ApplicationProfileCatalog {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "BookmarkProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new BookmarkProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfileCatalog)this).SerializeX(_Writer, false, ref _first);
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
        public static new BookmarkProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as BookmarkProfile;
				}
		    var Result = new BookmarkProfile ();
			Result.Deserialize (JSONReader);
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
	/// Private part of the profile.
	/// </summary>
	public partial class BookmarkProfilePrivate : ApplicationProfilePrivate {
        /// <summary>
        ///The bookmark entries
        /// </summary>

		public virtual List<BookmarkEntry>				Entries  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "BookmarkProfilePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new BookmarkProfilePrivate();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfilePrivate)this).SerializeX(_Writer, false, ref _first);
			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
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
        public static new BookmarkProfilePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as BookmarkProfilePrivate;
				}
		    var Result = new BookmarkProfilePrivate ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <BookmarkEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  BookmarkEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new BookmarkEntry (JSONReader);
						Entries.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// Bookmark entry for a single site
	/// </summary>
	public partial class BookmarkEntry : CatalogEntry {
        /// <summary>
        ///The resource name
        /// </summary>

		public virtual string						Title  {get; set;}
        /// <summary>
        ///The resource identifier
        /// </summary>

		public virtual string						Uri  {get; set;}
        /// <summary>
        ///UDF fingerprint of related favicon image
        /// </summary>

		public virtual List<string>				ImageUDF  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "BookmarkEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new BookmarkEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogEntry)this).SerializeX(_Writer, false, ref _first);
			if (Title != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Title", 1);
					_Writer.WriteString (Title);
				}
			if (Uri != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Uri", 1);
					_Writer.WriteString (Uri);
				}
			if (ImageUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ImageUDF", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in ImageUDF) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
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
        public static new BookmarkEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as BookmarkEntry;
				}
		    var Result = new BookmarkEntry ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Title" : {
					Title = JSONReader.ReadString ();
					break;
					}
				case "Uri" : {
					Uri = JSONReader.ReadString ();
					break;
					}
				case "ImageUDF" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					ImageUDF = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						ImageUDF.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// Stores Web site bookmarks in a hierarchical 
	/// </summary>
	public partial class ContactProfile : ApplicationProfileCatalog {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContactProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContactProfile();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfileCatalog)this).SerializeX(_Writer, false, ref _first);
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
        public static new ContactProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContactProfile;
				}
		    var Result = new ContactProfile ();
			Result.Deserialize (JSONReader);
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
	/// Private part of the profile.
	/// </summary>
	public partial class ContactProfilePrivate : ApplicationProfilePrivate {
        /// <summary>
        ///The contact entries
        /// </summary>

		public virtual List<ContactEntry>				Entries  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContactProfilePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContactProfilePrivate();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfilePrivate)this).SerializeX(_Writer, false, ref _first);
			if (Entries != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Entries", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
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
        public static new ContactProfilePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContactProfilePrivate;
				}
		    var Result = new ContactProfilePrivate ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <ContactEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  ContactEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new ContactEntry (JSONReader);
						Entries.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// Contact entry
	/// </summary>
	public partial class ContactEntry : CatalogEntry {
        /// <summary>
        /// </summary>

		public virtual List<PersonalName>				Personals  {get; set;}
        /// <summary>
        ///List of mesh profiles fingerprints for the user.
        /// </summary>

		public virtual List<string>				MeshUDFs  {get; set;}
        /// <summary>
        ///List of Internet, telephone, etc addresses for contacting this party
        /// </summary>

		public virtual List<Internet>				Internets  {get; set;}
        /// <summary>
        ///List of postal addresses for this party
        /// </summary>

		public virtual List<Postal>				Postals  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContactEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContactEntry();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((CatalogEntry)this).SerializeX(_Writer, false, ref _first);
			if (Personals != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Personals", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Personals) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (MeshUDFs != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MeshUDFs", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in MeshUDFs) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Internets != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Internets", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Internets) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (Postals != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Postals", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Postals) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index.Tag(), 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
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
        public static new ContactEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContactEntry;
				}
		    var Result = new ContactEntry ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Personals" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Personals = new List <PersonalName> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PersonalName ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PersonalName (JSONReader);
						Personals.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "MeshUDFs" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					MeshUDFs = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						MeshUDFs.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Internets" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Internets = new List <Internet> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Internet ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Internet (JSONReader);
						Internets.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Postals" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Postals = new List <Postal> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  Postal ();
						_Item.Deserialize (JSONReader);
						// var _Item = new Postal (JSONReader);
						Postals.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// </summary>
	public partial class PersonalName : MeshCatalog {
        /// <summary>
        /// </summary>

		public virtual string						First  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Last  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Midle  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "PersonalName";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new PersonalName();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (First != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("First", 1);
					_Writer.WriteString (First);
				}
			if (Last != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Last", 1);
					_Writer.WriteString (Last);
				}
			if (Midle != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Midle", 1);
					_Writer.WriteString (Midle);
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
        public static new PersonalName FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as PersonalName;
				}
		    var Result = new PersonalName ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "First" : {
					First = JSONReader.ReadString ();
					break;
					}
				case "Last" : {
					Last = JSONReader.ReadString ();
					break;
					}
				case "Midle" : {
					Midle = JSONReader.ReadString ();
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
	/// </summary>
	public partial class Address : MeshCatalog {
        /// <summary>
        ///Labels identifying the modes in which the label may be used
        ///e.g. Home, Business, Mobile		
        /// </summary>

		public virtual List<string>				Label  {get; set;}
        /// <summary>
        ///Attributes describing the mode in which the contact address may be used.
        /// </summary>

		public virtual List<string>				Attributes  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Address";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new Address();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (Label != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Label", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Label) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Attributes != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Attributes", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Attributes) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
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
        public static new Address FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Address;
				}
		    var Result = new Address ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Label" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Label = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Label.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Attributes" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Attributes = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Attributes.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// </summary>
	public partial class Internet : Address {
        /// <summary>
        ///The resource identifier describing the mode of contact
        /// </summary>

		public virtual string						Uri  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Internet";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new Internet();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Address)this).SerializeX(_Writer, false, ref _first);
			if (Uri != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Uri", 1);
					_Writer.WriteString (Uri);
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
        public static new Internet FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Internet;
				}
		    var Result = new Internet ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Uri" : {
					Uri = JSONReader.ReadString ();
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
	/// </summary>
	public partial class Postal : Address {
        /// <summary>
        ///The postal name
        /// </summary>

		public virtual string						Adressee  {get; set;}
        /// <summary>
        ///Street name and number
        /// </summary>

		public virtual string						Street  {get; set;}
        /// <summary>
        ///Name of town or city
        /// </summary>

		public virtual string						Town  {get; set;}
        /// <summary>
        ///State, county, department or other government unit.
        /// </summary>

		public virtual string						Region  {get; set;}
        /// <summary>
        ///The country name
        /// </summary>

		public virtual string						Country  {get; set;}
        /// <summary>
        ///The ISO 3 letter country code
        /// </summary>

		public virtual string						Code  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "Postal";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new Postal();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((Address)this).SerializeX(_Writer, false, ref _first);
			if (Adressee != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Adressee", 1);
					_Writer.WriteString (Adressee);
				}
			if (Street != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Street", 1);
					_Writer.WriteString (Street);
				}
			if (Town != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Town", 1);
					_Writer.WriteString (Town);
				}
			if (Region != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Region", 1);
					_Writer.WriteString (Region);
				}
			if (Country != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Country", 1);
					_Writer.WriteString (Country);
				}
			if (Code != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Code", 1);
					_Writer.WriteString (Code);
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
        public static new Postal FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as Postal;
				}
		    var Result = new Postal ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "Adressee" : {
					Adressee = JSONReader.ReadString ();
					break;
					}
				case "Street" : {
					Street = JSONReader.ReadString ();
					break;
					}
				case "Town" : {
					Town = JSONReader.ReadString ();
					break;
					}
				case "Region" : {
					Region = JSONReader.ReadString ();
					break;
					}
				case "Country" : {
					Country = JSONReader.ReadString ();
					break;
					}
				case "Code" : {
					Code = JSONReader.ReadString ();
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
	/// Contact entry for a single person
	/// </summary>
	public partial class ContactPerson : ContactEntry {
        /// <summary>
        ///The name of the person
        /// </summary>

		public virtual string						FullName  {get; set;}
        /// <summary>
        ///The name of the organizations the person is associated with
        /// </summary>

		public virtual List<string>				Organization  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContactPerson";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContactPerson();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ContactEntry)this).SerializeX(_Writer, false, ref _first);
			if (FullName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("FullName", 1);
					_Writer.WriteString (FullName);
				}
			if (Organization != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Organization", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Organization) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
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
        public static new ContactPerson FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContactPerson;
				}
		    var Result = new ContactPerson ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "FullName" : {
					FullName = JSONReader.ReadString ();
					break;
					}
				case "Organization" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Organization = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Organization.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
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
	/// Contact entry for a single organization
	/// </summary>
	public partial class ContactOrganization : ContactEntry {
        /// <summary>
        ///The name of the organization
        /// </summary>

		public virtual string						FullName  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag { get; } = "ContactOrganization";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () {
			return new ContactOrganization();
			}


        /// <summary>
        /// Serialize this object to the specified output stream.
        /// </summary>
        /// <param name="Writer">Output stream</param>
        /// <param name="wrap">If true, output is wrapped with object
        /// start and end sequences '{ ... }'.</param>
        /// <param name="first">If true, item is the first entry in a list.</param>
		public override void Serialize (Writer Writer, bool wrap, ref bool first) {
			SerializeX (Writer, wrap, ref first);
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
		public new void SerializeX (Writer _Writer, bool _wrap, ref bool _first) {
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ContactEntry)this).SerializeX(_Writer, false, ref _first);
			if (FullName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("FullName", 1);
					_Writer.WriteString (FullName);
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
        public static new ContactOrganization FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as ContactOrganization;
				}
		    var Result = new ContactOrganization ();
			Result.Deserialize (JSONReader);
			return Result;
			}

        /// <summary>
        /// Having read a tag, process the corresponding value data.
        /// </summary>
        /// <param name="JSONReader">The input stream</param>
        /// <param name="Tag">The tag</param>
		public override void DeserializeToken (JSONReader JSONReader, string Tag) {
			
			switch (Tag) {
				case "FullName" : {
					FullName = JSONReader.ReadString ();
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

