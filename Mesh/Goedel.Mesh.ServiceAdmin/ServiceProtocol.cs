
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
//  This file was automatically generated at 9/1/2021 12:12:33 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.652
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


namespace Goedel.Mesh.ServiceAdmin {


	/// <summary>
	///
	/// Host and Service configuration tile.
	/// </summary>
	public abstract partial class ServiceConfig : global::Goedel.Protocol.JsonObject {

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag =>__Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ServiceConfig";

		/// <summary>
        /// Dictionary mapping tags to factory methods
        /// </summary>
		public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
		static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
				new Dictionary<string, JsonFactoryDelegate> () {

			{"Configuration", Configuration._Factory},
			{"ConfigurationEntry", ConfigurationEntry._Factory},
			{"ServiceConfiguration", ServiceConfiguration._Factory},
			{"HostConfiguration", HostConfiguration._Factory},
			{"LogEntry", LogEntry._Factory},
			{"LocalLog", LocalLog._Factory},
			{"RemoteLog", RemoteLog._Factory}			};

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
	/// </summary>
	public partial class Configuration : ServiceConfig {
        /// <summary>
        ///Configuration identifier
        /// </summary>

		public virtual string						Name  {get; set;}
        /// <summary>
        ///Used to distinguish between multiple service instances for test purposes.
        /// </summary>

		public virtual string						Instance  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<ConfigurationEntry>				Entries  {get; set;}
        /// <summary>
        ///Strong name of service identifier.
        /// </summary>

		public virtual List<string>				Administrators  {get; set;}
        /// <summary>
        /// </summary>

		public virtual string						Address  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "Configuration";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new Configuration();


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
			if (Name != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Name", 1);
					_writer.WriteString (Name);
				}
			if (Instance != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Instance", 1);
					_writer.WriteString (Instance);
				}
			if (Entries != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Entries", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Entries) {
					_writer.WriteArraySeparator (ref _firstarray);
                    _writer.WriteObjectStart();
                    _writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    _writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (Administrators != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Administrators", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Administrators) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Address != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Address", 1);
					_writer.WriteString (Address);
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
        public static new Configuration FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as Configuration;
				}
		    var Result = new Configuration ();
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
				case "Name" : {
					Name = jsonReader.ReadString ();
					break;
					}
				case "Instance" : {
					Instance = jsonReader.ReadString ();
					break;
					}
				case "Entries" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Entries = new List <ConfigurationEntry> ();
					while (_Going) {
						var _Item = ConfigurationEntry.FromJson (jsonReader, true); // a tagged structure
						Entries.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Administrators" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Administrators = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Administrators.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Address" : {
					Address = jsonReader.ReadString ();
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
	public partial class ConfigurationEntry : ServiceConfig {
        /// <summary>
        ///Configuration identifier
        /// </summary>

		public virtual string						Id  {get; set;}
        /// <summary>
        ///UDF fingerprint of the profile specifying the entity.
        /// </summary>

		public virtual string						ProfileUdf  {get; set;}
        /// <summary>
        ///Description of the configuration
        /// </summary>

		public virtual string						Description  {get; set;}
        /// <summary>
        ///Path to the directory where service data is stored.
        /// </summary>

		public virtual string						Path  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<LogEntry>				Logs  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<string>				DNS  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ConfigurationEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new ConfigurationEntry();


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
			if (ProfileUdf != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("ProfileUdf", 1);
					_writer.WriteString (ProfileUdf);
				}
			if (Description != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Description", 1);
					_writer.WriteString (Description);
				}
			if (Path != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Path", 1);
					_writer.WriteString (Path);
				}
			if (Logs != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Logs", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Logs) {
					_writer.WriteArraySeparator (ref _firstarray);
                    _writer.WriteObjectStart();
                    _writer.WriteToken(_index._Tag, 1);
					bool firstinner = true;
					_index.Serialize (_writer, true, ref firstinner);
                    _writer.WriteObjectEnd();
					}
				_writer.WriteArrayEnd ();
				}

			if (DNS != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DNS", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in DNS) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
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
        public static new ConfigurationEntry FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ConfigurationEntry;
				}
		    var Result = new ConfigurationEntry ();
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
				case "ProfileUdf" : {
					ProfileUdf = jsonReader.ReadString ();
					break;
					}
				case "Description" : {
					Description = jsonReader.ReadString ();
					break;
					}
				case "Path" : {
					Path = jsonReader.ReadString ();
					break;
					}
				case "Logs" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Logs = new List <LogEntry> ();
					while (_Going) {
						var _Item = LogEntry.FromJson (jsonReader, true); // a tagged structure
						Logs.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "DNS" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					DNS = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						DNS.Add (_Item);
						_Going = jsonReader.NextArray ();
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
	public partial class ServiceConfiguration : ConfigurationEntry {
        /// <summary>
        /// </summary>

		public virtual List<string>				Addresses  {get; set;}
        /// <summary>
        ///The well known service identifier of the service
        /// </summary>

		public virtual string						WellKnown  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "ServiceConfiguration";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new ServiceConfiguration();


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
			((ConfigurationEntry)this).SerializeX(_writer, false, ref _first);
			if (Addresses != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Addresses", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Addresses) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (WellKnown != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("WellKnown", 1);
					_writer.WriteString (WellKnown);
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
        public static new ServiceConfiguration FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as ServiceConfiguration;
				}
		    var Result = new ServiceConfiguration ();
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
				case "Addresses" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Addresses = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Addresses.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "WellKnown" : {
					WellKnown = jsonReader.ReadString ();
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
	/// </summary>
	public partial class HostConfiguration : ConfigurationEntry {
        /// <summary>
        ///UDF fingerprint of the device profile.
        /// </summary>

		public virtual string						DeviceUdf  {get; set;}
		bool								__Process = false;
		private int						_Process;
        /// <summary>
        /// </summary>

		public virtual int						Process {
			get => _Process;
			set {_Process = value; __Process = true; }
			}
		bool								__Storage = false;
		private int						_Storage;
        /// <summary>
        /// </summary>

		public virtual int						Storage {
			get => _Storage;
			set {_Storage = value; __Storage = true; }
			}
        /// <summary>
        /// </summary>

		public virtual string						Role  {get; set;}
		bool								__Port = false;
		private int						_Port;
        /// <summary>
        /// </summary>

		public virtual int						Port {
			get => _Port;
			set {_Port = value; __Port = true; }
			}
        /// <summary>
        /// </summary>

		public virtual List<string>				IP  {get; set;}
        /// <summary>
        /// </summary>

		public virtual List<string>				Services  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "HostConfiguration";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new HostConfiguration();


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
			((ConfigurationEntry)this).SerializeX(_writer, false, ref _first);
			if (DeviceUdf != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("DeviceUdf", 1);
					_writer.WriteString (DeviceUdf);
				}
			if (__Process){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Process", 1);
					_writer.WriteInteger32 (Process);
				}
			if (__Storage){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Storage", 1);
					_writer.WriteInteger32 (Storage);
				}
			if (Role != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Role", 1);
					_writer.WriteString (Role);
				}
			if (__Port){
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Port", 1);
					_writer.WriteInteger32 (Port);
				}
			if (IP != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("IP", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in IP) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
				}

			if (Services != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Services", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Services) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
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
        public static new HostConfiguration FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as HostConfiguration;
				}
		    var Result = new HostConfiguration ();
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
				case "DeviceUdf" : {
					DeviceUdf = jsonReader.ReadString ();
					break;
					}
				case "Process" : {
					Process = jsonReader.ReadInteger32 ();
					break;
					}
				case "Storage" : {
					Storage = jsonReader.ReadInteger32 ();
					break;
					}
				case "Role" : {
					Role = jsonReader.ReadString ();
					break;
					}
				case "Port" : {
					Port = jsonReader.ReadInteger32 ();
					break;
					}
				case "IP" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					IP = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						IP.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
					break;
					}
				case "Services" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Services = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Services.Add (_Item);
						_Going = jsonReader.NextArray ();
						}
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
	/// </summary>
	public partial class LogEntry : ServiceConfig {
        /// <summary>
        ///The data facets to be recorded to this log, 'error', 'event', 'append', 'sync'.
        /// </summary>

		public virtual List<string>				Events  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "LogEntry";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new LogEntry();


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
			if (Events != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Events", 1);
				_writer.WriteArrayStart ();
				bool _firstarray = true;
				foreach (var _index in Events) {
					_writer.WriteArraySeparator (ref _firstarray);
					_writer.WriteString (_index);
					}
				_writer.WriteArrayEnd ();
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
        public static new LogEntry FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as LogEntry;
				}
		    var Result = new LogEntry ();
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
				case "Events" : {
					// Have a sequence of values
					bool _Going = jsonReader.StartArray ();
					Events = new List <string> ();
					while (_Going) {
						string _Item = jsonReader.ReadString ();
						Events.Add (_Item);
						_Going = jsonReader.NextArray ();
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
	public partial class LocalLog : LogEntry {
        /// <summary>
        ///Path specifying the directory to which the log is to be written.
        /// </summary>

		public virtual string						Path  {get; set;}
        /// <summary>
        ///Specifies the interval at which the log file is to be
        ///closed and a new file started. This may be in units of 
        ///time h(our), d(ay), m(onth), y(ear), or in units of events
        ///(e(vent).
        /// </summary>

		public virtual string						Roll  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "LocalLog";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new LocalLog();


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
			((LogEntry)this).SerializeX(_writer, false, ref _first);
			if (Path != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Path", 1);
					_writer.WriteString (Path);
				}
			if (Roll != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Roll", 1);
					_writer.WriteString (Roll);
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
        public static new LocalLog FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as LocalLog;
				}
		    var Result = new LocalLog ();
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
				case "Path" : {
					Path = jsonReader.ReadString ();
					break;
					}
				case "Roll" : {
					Roll = jsonReader.ReadString ();
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
	/// </summary>
	public partial class RemoteLog : LogEntry {
        /// <summary>
        ///Path specifying the filename
        /// </summary>

		public virtual string						Uri  {get; set;}
		
		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public override string _Tag => __Tag;

		/// <summary>
        /// Tag identifying this class
        /// </summary>
		public new const string __Tag = "RemoteLog";

		/// <summary>
        /// Factory method
        /// </summary>
        /// <returns>Object of this type</returns>
		public static new JsonObject _Factory () => new RemoteLog();


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
			((LogEntry)this).SerializeX(_writer, false, ref _first);
			if (Uri != null) {
				_writer.WriteObjectSeparator (ref _first);
				_writer.WriteToken ("Uri", 1);
					_writer.WriteString (Uri);
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
        public static new RemoteLog FromJson (JsonReader jsonReader, bool tagged=true) {
			if (jsonReader == null) {
				return null;
				}
			if (tagged) {
				var Out = jsonReader.ReadTaggedObject (_TagDictionary);
				return Out as RemoteLog;
				}
		    var Result = new RemoteLog ();
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
				case "Uri" : {
					Uri = jsonReader.ReadString ();
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

