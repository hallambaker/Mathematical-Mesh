
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
using Goedel.Mesh;


namespace Goedel.Recrypt {


	/// <summary>
	///
	/// Mesh/Recrypt Profile Schema
	/// Mesh profile for Recrypt applications.
	/// </summary>
	public abstract partial class MeshRecrypt : global::Goedel.Protocol.JSONObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MeshRecrypt";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JSONFactoryDelegate> _TagDictionary = 
				new Dictionary<string, JSONFactoryDelegate> () {

			{"RecryptionGroup", RecryptionGroup._Factory},
			{"RecryptionKey", RecryptionKey._Factory},
			{"MemberEntry", MemberEntry._Factory},
			{"UserDecryptionEntry", UserDecryptionEntry._Factory},
			{"RecryptProfile", RecryptProfile._Factory},
			{"RecryptProfilePrivate", RecryptProfilePrivate._Factory},
			{"RecryptDevicePublic", RecryptDevicePublic._Factory},
			{"RecryptDevicePrivate", RecryptDevicePrivate._Factory}			};

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
	/// Describes a recryption group and set of members.
	/// </summary>
	public partial class RecryptionGroup : MeshRecrypt {
        /// <summary>
        ///A user friendly account name in RFC821 format (user@example.com).
        /// </summary>

		public virtual string						GroupName  {get; set;}
        /// <summary>
        ///Persistent master profile.
        /// </summary>

		public virtual MasterProfile						Master  {get; set;}
        /// <summary>
        ///Member of a recryption group
        /// </summary>

		public virtual List<MemberEntry>				Members  {get; set;}
        /// <summary>
        ///The set of past encryption keys associated with the group.
        /// </summary>

		public virtual List<PublicKey>				ArchivedKeys  {get; set;}
        /// <summary>
        ///The current group encryption key signed under the Master Profile
        /// </summary>

		public virtual JoseWebSignature						CurrentEncryptionKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RecryptionGroup";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new RecryptionGroup();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (GroupName != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("GroupName", 1);
					_Writer.WriteString (GroupName);
				}
			if (Master != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Master", 1);
					Master.Serialize (_Writer, false);
				}
			if (Members != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Members", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Members) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (ArchivedKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("ArchivedKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in ArchivedKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (CurrentEncryptionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("CurrentEncryptionKey", 1);
					CurrentEncryptionKey.Serialize (_Writer, false);
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
        public static new RecryptionGroup FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptionGroup;
				}
		    var Result = new RecryptionGroup ();
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
				case "GroupName" : {
					GroupName = JSONReader.ReadString ();
					break;
					}
				case "Master" : {
					// An untagged structure
					Master = new MasterProfile ();
					Master.Deserialize (JSONReader);
 
					break;
					}
				case "Members" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Members = new List <MemberEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  MemberEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new MemberEntry (JSONReader);
						Members.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "ArchivedKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					ArchivedKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						ArchivedKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "CurrentEncryptionKey" : {
					// An untagged structure
					CurrentEncryptionKey = new JoseWebSignature ();
					CurrentEncryptionKey.Deserialize (JSONReader);
 
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
	/// Describes a recryption key with optional additional description.
	/// </summary>
	public partial class RecryptionKey : MeshRecrypt {
        /// <summary>
        ///The current group encryption key
        /// </summary>

		public virtual PublicKey						EncryptionKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RecryptionKey";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new RecryptionKey();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (EncryptionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptionKey", 1);
					EncryptionKey.Serialize (_Writer, false);
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
        public static new RecryptionKey FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptionKey;
				}
		    var Result = new RecryptionKey ();
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
				case "EncryptionKey" : {
					// An untagged structure
					EncryptionKey = new PublicKey ();
					EncryptionKey.Deserialize (JSONReader);
 
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
	/// Describes a member of a recryption group
	/// </summary>
	public partial class MemberEntry : MeshRecrypt {
        /// <summary>
        ///UDF fingerprint of the user's master profile
        /// </summary>

		public virtual string						UDF  {get; set;}
        /// <summary>
        ///UDF fingerprint of the user's recryption profile
        /// </summary>

		public virtual string						RecryptUDF  {get; set;}
        /// <summary>
        ///User friendly account name
        /// </summary>

		public virtual string						Name  {get; set;}
        /// <summary>
        ///A list of privileges assigned to the user.
        ///Currently defined privileges are RECRYPT, ADMIN and SUPER. 
        ///Recrypt grants a user the right to request decryption of 
        ///data encrypted under the group key. ADMIN grants the right to
        ///add or remove users from the group. SUPER grants the right to
        ///add or remove administrators and super-administrators from the 
        ///group.
        ///Note that being granted the necessary privilege does not
        ///in itself confer the ability to decrypt messages as this requires
        ///access to the master private key.
        /// </summary>

		public virtual List<string>				Privileges  {get; set;}
        /// <summary>
        ///A list of quotas assigned to the user.
        ///Each quota is described by the UDF fingerprint of the quota 
        ///service.
        /// </summary>

		public virtual List<string>				Quotas  {get; set;}
        /// <summary>
        ///Member status. Valid values are ACTIVE, REVOKED and SUSPENDED.
        ///Once added to a recryption group, a user can never be 'deleted'.
        ///Instead their member record is marked as REVOKED or SUSPENDED which
        ///causes the recryption service to refuse further recryption requests.
        ///Note that it is entirely valid for newly created recryption group to
        ///contain member entries that are inactive. This allows a key administrator
        ///to generate key material for group members in anticipation of them requiring
        ///access without immediately granting that access.
        /// </summary>

		public virtual string						Status  {get; set;}
        /// <summary>
        ///Decryption entry for a particular user and group key
        /// </summary>

		public virtual List<UserDecryptionEntry>				Entries  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "MemberEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new MemberEntry();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (UDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("UDF", 1);
					_Writer.WriteString (UDF);
				}
			if (RecryptUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptUDF", 1);
					_Writer.WriteString (RecryptUDF);
				}
			if (Name != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Name", 1);
					_Writer.WriteString (Name);
				}
			if (Privileges != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Privileges", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Privileges) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Quotas != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Quotas", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Quotas) {
					_Writer.WriteArraySeparator (ref _firstarray);
					_Writer.WriteString (_index);
					}
				_Writer.WriteArrayEnd ();
				}

			if (Status != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Status", 1);
					_Writer.WriteString (Status);
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
                    //_Writer.WriteToken(_index._Tag, 1);
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
        public static new MemberEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as MemberEntry;
				}
		    var Result = new MemberEntry ();
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
				case "UDF" : {
					UDF = JSONReader.ReadString ();
					break;
					}
				case "RecryptUDF" : {
					RecryptUDF = JSONReader.ReadString ();
					break;
					}
				case "Name" : {
					Name = JSONReader.ReadString ();
					break;
					}
				case "Privileges" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Privileges = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Privileges.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Quotas" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Quotas = new List <string> ();
					while (_Going) {
						string _Item = JSONReader.ReadString ();
						Quotas.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "Status" : {
					Status = JSONReader.ReadString ();
					break;
					}
				case "Entries" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					Entries = new List <UserDecryptionEntry> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  UserDecryptionEntry ();
						_Item.Deserialize (JSONReader);
						// var _Item = new UserDecryptionEntry (JSONReader);
						Entries.Add (_Item);
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
	///
	/// Decryption entry for a particular user and group key
	/// </summary>
	public partial class UserDecryptionEntry : MeshRecrypt {
        /// <summary>
        ///Fingerprint of the encryption key to which this recryption data
        ///corresponds
        /// </summary>

		public virtual string						EncryptionKeyUDF  {get; set;}
        /// <summary>
        ///Fingerprint of the user's key
        /// </summary>

		public virtual string						MemberKeyUDF  {get; set;}
        /// <summary>
        ///The recryption key to be used to recrypt for this user.
        /// </summary>

		public virtual Key						RecryptionKey  {get; set;}
        /// <summary>
        ///The user's decryption key encrypted under a one or more encryption
        ///keys held by the user. The encrypted content is a PrivateKey structure
        ///specifying the decryption key for the user.
        /// </summary>

		public virtual JoseWebEncryption						DecryptionKey  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "UserDecryptionEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new UserDecryptionEntry();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			if (EncryptionKeyUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptionKeyUDF", 1);
					_Writer.WriteString (EncryptionKeyUDF);
				}
			if (MemberKeyUDF != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("MemberKeyUDF", 1);
					_Writer.WriteString (MemberKeyUDF);
				}
			if (RecryptionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("RecryptionKey", 1);
					// expand this to a tagged structure
					//RecryptionKey.Serialize (_Writer, false);
					{
						_Writer.WriteObjectStart();
						_Writer.WriteToken(RecryptionKey._Tag, 1);
						bool firstinner = true;
						RecryptionKey.Serialize (_Writer, true, ref firstinner);
						_Writer.WriteObjectEnd();
						}
				}
			if (DecryptionKey != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DecryptionKey", 1);
					DecryptionKey.Serialize (_Writer, false);
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
        public static new UserDecryptionEntry FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as UserDecryptionEntry;
				}
		    var Result = new UserDecryptionEntry ();
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
				case "EncryptionKeyUDF" : {
					EncryptionKeyUDF = JSONReader.ReadString ();
					break;
					}
				case "MemberKeyUDF" : {
					MemberKeyUDF = JSONReader.ReadString ();
					break;
					}
				case "RecryptionKey" : {
					RecryptionKey = Key.FromJSON (JSONReader, true) ;  // A tagged structure
					break;
					}
				case "DecryptionKey" : {
					// An untagged structure
					DecryptionKey = new JoseWebEncryption ();
					DecryptionKey.Deserialize (JSONReader);
 
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
	/// Application profile for Confirm
	/// </summary>
	public partial class RecryptProfile : ApplicationProfile {
        /// <summary>
        ///The account to which the profile is bound
        /// </summary>

		public virtual string						Account  {get; set;}
        /// <summary>
        ///Recryption blob encryption key. A user MAY have multiple decryption 
        ///keys to allow keys to be bound to specific devices.
        /// </summary>

		public virtual List<PublicKey>				EncryptKeys  {get; set;}
        /// <summary>
        ///A public keypair to verify group profile signatures. Multiple keys
        ///MAY be provided so as to allow multiple devices to sign with device
        ///specific keys
        /// </summary>

		public virtual List<PublicKey>				AuthKeys  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RecryptProfile";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new RecryptProfile();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfile)this).SerializeX(_Writer, false, ref _first);
			if (Account != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("Account", 1);
					_Writer.WriteString (Account);
				}
			if (EncryptKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("EncryptKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in EncryptKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (AuthKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("AuthKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in AuthKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
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
        public static new RecryptProfile FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptProfile;
				}
		    var Result = new RecryptProfile ();
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
				case "Account" : {
					Account = JSONReader.ReadString ();
					break;
					}
				case "EncryptKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					EncryptKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						EncryptKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "AuthKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					AuthKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						AuthKeys.Add (_Item);
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
	/// Private portion of profile. This is unused. Decryption keys are 
	/// provisioned on a per device basis to allow the use of co-generation techniques.
	/// </summary>
	public partial class RecryptProfilePrivate : ApplicationProfilePrivate {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RecryptProfilePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new RecryptProfilePrivate();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationProfilePrivate)this).SerializeX(_Writer, false, ref _first);
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
        public static new RecryptProfilePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptProfilePrivate;
				}
		    var Result = new RecryptProfilePrivate ();
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
	/// Contains public device description. This is unused as there is
	/// no requirement to disclose the binding of keys to devices.
	/// </summary>
	public partial class RecryptDevicePublic : ApplicationDevicePublic {
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RecryptDevicePublic";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new RecryptDevicePublic();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationDevicePublic)this).SerializeX(_Writer, false, ref _first);
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
        public static new RecryptDevicePublic FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptDevicePublic;
				}
		    var Result = new RecryptDevicePublic ();
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
	/// Private data specific to the device
	/// </summary>
	public partial class RecryptDevicePrivate : ApplicationDevicePrivate {
        /// <summary>
        ///Device specific recryption blob decryption key(s) or key contributions
        /// </summary>

		public virtual List<PublicKey>				DecryptKeys  {get; set;}
        /// <summary>
        ///Device specific group profile signing key(s) or key contributions
        /// </summary>

		public virtual List<PublicKey>				SignKeys  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RecryptDevicePrivate";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JSONObject _Factory () => new RecryptDevicePrivate();


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
			if (_wrap) {
				_Writer.WriteObjectStart ();
				}
			((ApplicationDevicePrivate)this).SerializeX(_Writer, false, ref _first);
			if (DecryptKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("DecryptKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DecryptKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_Writer, true, ref firstinner);
                    //_Writer.WriteObjectEnd();
					}
				_Writer.WriteArrayEnd ();
				}

			if (SignKeys != null) {
				_Writer.WriteObjectSeparator (ref _first);
				_Writer.WriteToken ("SignKeys", 1);
				_Writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in SignKeys) {
					_Writer.WriteArraySeparator (ref _firstarray);
					// This is an untagged structure. Cannot inherit.
                    //_Writer.WriteObjectStart();
                    //_Writer.WriteToken(_index._Tag, 1);
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
        public static new RecryptDevicePrivate FromJSON (JSONReader JSONReader, bool Tagged=true) {
			if (JSONReader == null) {
				return null;
				}
			if (Tagged) {
				var Out = JSONReader.ReadTaggedObject (_TagDictionary);
				return Out as RecryptDevicePrivate;
				}
		    var Result = new RecryptDevicePrivate ();
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
				case "DecryptKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					DecryptKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						DecryptKeys.Add (_Item);
						_Going = JSONReader.NextArray ();
						}
					break;
					}
				case "SignKeys" : {
					// Have a sequence of values
					bool _Going = JSONReader.StartArray ();
					SignKeys = new List <PublicKey> ();
					while (_Going) {
						// an untagged structure.
						var _Item = new  PublicKey ();
						_Item.Deserialize (JSONReader);
						// var _Item = new PublicKey (JSONReader);
						SignKeys.Add (_Item);
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

	}

