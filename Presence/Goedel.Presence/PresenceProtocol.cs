
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
//  This file was automatically generated at 06-Feb-23 6:17:29 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1015
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.19042.0
//  
//  
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Goedel.Protocol;
using Goedel.Utilities;

#pragma warning disable IDE0079
#pragma warning disable IDE1006
#pragma warning disable CA2255 // The 'ModuleInitializer' attribute should not be used in libraries

using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;


namespace Goedel.Presence;


	/// <summary>
	///
	/// Callsign Registrar protocol supporting query function.
	/// Protocol interactions supported by the Mesh Service.
	/// </summary>
public abstract partial class PresenceProtocol : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceProtocol";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"PresenceFromClient", PresenceFromClient._Factory},
	    {"PresenceConnectRequest", PresenceConnectRequest._Factory},
	    {"PresenceHeartbeat", PresenceHeartbeat._Factory},
	    {"PresenceEndpointRequest", PresenceEndpointRequest._Factory},
	    {"PresenceAcknowledge", PresenceAcknowledge._Factory},
	    {"PresenceResolveRequest", PresenceResolveRequest._Factory},
	    {"PresenceFromService", PresenceFromService._Factory},
	    {"PresenceConnectResponse", PresenceConnectResponse._Factory},
	    {"PresenceErrorInvalidSerial", PresenceErrorInvalidSerial._Factory},
	    {"PresenceStatus", PresenceStatus._Factory},
	    {"PresenceEndpointResponse", PresenceEndpointResponse._Factory},
	    {"PresenceNotify", PresenceNotify._Factory},
	    {"PresenceResolveResponse", PresenceResolveResponse._Factory},
	    {"SessionRequest", SessionRequest._Factory},
	    {"SessionResponse", SessionResponse._Factory},
	    {"SessionEndpoint", SessionEndpoint._Factory},
	    {"UdpEndpoint", UdpEndpoint._Factory}
		};

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
	/// Base class for all requests made to a registrar
	/// </summary>
public partial class PresenceFromClient : Goedel.Protocol.Request {
        /// <summary>
        ///Monotonically increasing counter used to prevent replay
        ///attacks on client request.
        /// </summary>

	public virtual int?						Serial  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Acknowledge  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Serial" : {
				if (value is TokenValueInteger32 vvalue) {
					Serial = vvalue.Value;
					}
				break;
				}
			case "Acknowledge" : {
				if (value is TokenValueInteger32 vvalue) {
					Acknowledge = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Serial" : {
				return new TokenValueInteger32 (Serial);
				}
			case "Acknowledge" : {
				return new TokenValueInteger32 (Acknowledge);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Serial", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Acknowledge", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Protocol.Request._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceFromClient";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceFromClient();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceFromClient FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceFromClient;
			}
		var Result = new PresenceFromClient ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Register connection request. 
	/// </summary>
public partial class PresenceConnectRequest : PresenceFromClient {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromClient._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceConnectRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceConnectRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceConnectRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceConnectRequest;
			}
		var Result = new PresenceConnectRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceHeartbeat : PresenceFromClient {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromClient._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceHeartbeat";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceHeartbeat();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceHeartbeat FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceHeartbeat;
			}
		var Result = new PresenceHeartbeat ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceEndpointRequest : PresenceFromClient {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromClient._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceEndpointRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceEndpointRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceEndpointRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceEndpointRequest;
			}
		var Result = new PresenceEndpointRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceAcknowledge : PresenceFromClient {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromClient._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceAcknowledge";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceAcknowledge();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceAcknowledge FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceAcknowledge;
			}
		var Result = new PresenceAcknowledge ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceResolveRequest : PresenceFromClient {
        /// <summary>
        /// </summary>

	public virtual byte[]						DnsRequest  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "DnsRequest" : {
				if (value is TokenValueBinary vvalue) {
					DnsRequest = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "DnsRequest" : {
				return new TokenValueBinary (DnsRequest);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DnsRequest", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromClient._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceResolveRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceResolveRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceResolveRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceResolveRequest;
			}
		var Result = new PresenceResolveRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Base class for all response messages. Contains only the
	/// status code and status description fields.
	/// </summary>
public partial class PresenceFromService : Goedel.Protocol.Response {
        /// <summary>
        /// </summary>

	public virtual UdpEndpoint						EndPoint  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						Now  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Acknowledge  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "EndPoint" : {
				if (value is TokenValueStructObject vvalue) {
					EndPoint = vvalue.Value as UdpEndpoint;
					}
				break;
				}
			case "Now" : {
				if (value is TokenValueDateTime vvalue) {
					Now = vvalue.Value;
					}
				break;
				}
			case "Acknowledge" : {
				if (value is TokenValueInteger32 vvalue) {
					Acknowledge = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "EndPoint" : {
				return new TokenValueStruct<UdpEndpoint> (EndPoint);
				}
			case "Now" : {
				return new TokenValueDateTime (Now);
				}
			case "Acknowledge" : {
				return new TokenValueInteger32 (Acknowledge);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "EndPoint", new Property ( typeof(TokenValueStruct), false,
					()=>new UdpEndpoint(), ()=>new UdpEndpoint(), false)} ,
			{ "Now", new Property (typeof(TokenValueDateTime), false)} ,
			{ "Acknowledge", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Goedel.Protocol.Response._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceFromService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceFromService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceFromService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceFromService;
			}
		var Result = new PresenceFromService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Return the result of a connection request
	/// </summary>
public partial class PresenceConnectResponse : PresenceFromService {
        /// <summary>
        ///The time after which the presence service will start to 
        ///assume the device has disconnected in milliseconds.
        /// </summary>

	public virtual int?						ConnectionTimeout  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "ConnectionTimeout" : {
				if (value is TokenValueInteger32 vvalue) {
					ConnectionTimeout = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "ConnectionTimeout" : {
				return new TokenValueInteger32 (ConnectionTimeout);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "ConnectionTimeout", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromService._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceConnectResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceConnectResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceConnectResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceConnectResponse;
			}
		var Result = new PresenceConnectResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceErrorInvalidSerial : PresenceFromService {
        /// <summary>
        /// </summary>

	public virtual int?						Serial  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Serial" : {
				if (value is TokenValueInteger32 vvalue) {
					Serial = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Serial" : {
				return new TokenValueInteger32 (Serial);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Serial", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromService._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceErrorInvalidSerial";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceErrorInvalidSerial();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceErrorInvalidSerial FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceErrorInvalidSerial;
			}
		var Result = new PresenceErrorInvalidSerial ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceStatus : PresenceFromService {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromService._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceStatus";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceStatus();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceStatus FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceStatus;
			}
		var Result = new PresenceStatus ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceEndpointResponse : PresenceFromService {


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromService._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceEndpointResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceEndpointResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceEndpointResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceEndpointResponse;
			}
		var Result = new PresenceEndpointResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceNotify : PresenceFromService {
        /// <summary>
        /// </summary>

	public virtual byte[]						Bitmask  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Serial  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Bitmask" : {
				if (value is TokenValueBinary vvalue) {
					Bitmask = vvalue.Value;
					}
				break;
				}
			case "Serial" : {
				if (value is TokenValueInteger32 vvalue) {
					Serial = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Bitmask" : {
				return new TokenValueBinary (Bitmask);
				}
			case "Serial" : {
				return new TokenValueInteger32 (Serial);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Bitmask", new Property (typeof(TokenValueBinary), false)} ,
			{ "Serial", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromService._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceNotify";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceNotify();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceNotify FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceNotify;
			}
		var Result = new PresenceNotify ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PresenceResolveResponse : PresenceFromService {
        /// <summary>
        /// </summary>

	public virtual byte[]						DnsResponse  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "DnsResponse" : {
				if (value is TokenValueBinary vvalue) {
					DnsResponse = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "DnsResponse" : {
				return new TokenValueBinary (DnsResponse);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "DnsResponse", new Property (typeof(TokenValueBinary), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, PresenceFromService._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "PresenceResolveResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PresenceResolveResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PresenceResolveResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PresenceResolveResponse;
			}
		var Result = new PresenceResolveResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class SessionRequest : Message {
        /// <summary>
        /// </summary>

	public virtual string						Protocol  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Options  {get; set;}
        /// <summary>
        /// </summary>

	public virtual UdpEndpoint						Inbound  {get; set;}
        /// <summary>
        /// </summary>

	public virtual DateTime?						Expires  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Protocol" : {
				if (value is TokenValueString vvalue) {
					Protocol = vvalue.Value;
					}
				break;
				}
			case "Options" : {
				if (value is TokenValueListString vvalue) {
					Options = vvalue.Value;
					}
				break;
				}
			case "Inbound" : {
				if (value is TokenValueStructObject vvalue) {
					Inbound = vvalue.Value as UdpEndpoint;
					}
				break;
				}
			case "Expires" : {
				if (value is TokenValueDateTime vvalue) {
					Expires = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Protocol" : {
				return new TokenValueString (Protocol);
				}
			case "Options" : {
				return new TokenValueListString (Options);
				}
			case "Inbound" : {
				return new TokenValueStruct<UdpEndpoint> (Inbound);
				}
			case "Expires" : {
				return new TokenValueDateTime (Expires);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Protocol", new Property (typeof(TokenValueString), false)} ,
			{ "Options", new Property (typeof(TokenValueListString), true)} ,
			{ "Inbound", new Property ( typeof(TokenValueStruct), false,
					()=>new UdpEndpoint(), ()=>new UdpEndpoint(), false)} ,
			{ "Expires", new Property (typeof(TokenValueDateTime), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SessionRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SessionRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SessionRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SessionRequest;
			}
		var Result = new SessionRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class SessionResponse : Message {
        /// <summary>
        /// </summary>

	public virtual bool?						Accept  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Protocol  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Options  {get; set;}
        /// <summary>
        /// </summary>

	public virtual UdpEndpoint						Inbound  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "Accept" : {
				if (value is TokenValueBoolean vvalue) {
					Accept = vvalue.Value;
					}
				break;
				}
			case "Protocol" : {
				if (value is TokenValueString vvalue) {
					Protocol = vvalue.Value;
					}
				break;
				}
			case "Options" : {
				if (value is TokenValueListString vvalue) {
					Options = vvalue.Value;
					}
				break;
				}
			case "Inbound" : {
				if (value is TokenValueStructObject vvalue) {
					Inbound = vvalue.Value as UdpEndpoint;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "Accept" : {
				return new TokenValueBoolean (Accept);
				}
			case "Protocol" : {
				return new TokenValueString (Protocol);
				}
			case "Options" : {
				return new TokenValueListString (Options);
				}
			case "Inbound" : {
				return new TokenValueStruct<UdpEndpoint> (Inbound);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "Accept", new Property (typeof(TokenValueBoolean), false)} ,
			{ "Protocol", new Property (typeof(TokenValueString), false)} ,
			{ "Options", new Property (typeof(TokenValueListString), true)} ,
			{ "Inbound", new Property ( typeof(TokenValueStruct), false,
					()=>new UdpEndpoint(), ()=>new UdpEndpoint(), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties =
			Combine(_StaticProperties, Message._StaticAllProperties);


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SessionResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SessionResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SessionResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SessionResponse;
			}
		var Result = new SessionResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class SessionEndpoint : PresenceProtocol {
        /// <summary>
        /// </summary>

	public virtual byte[]						IpAddress  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Port  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string						Protocol  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>				Options  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "IpAddress" : {
				if (value is TokenValueBinary vvalue) {
					IpAddress = vvalue.Value;
					}
				break;
				}
			case "Port" : {
				if (value is TokenValueInteger32 vvalue) {
					Port = vvalue.Value;
					}
				break;
				}
			case "Protocol" : {
				if (value is TokenValueString vvalue) {
					Protocol = vvalue.Value;
					}
				break;
				}
			case "Options" : {
				if (value is TokenValueListString vvalue) {
					Options = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "IpAddress" : {
				return new TokenValueBinary (IpAddress);
				}
			case "Port" : {
				return new TokenValueInteger32 (Port);
				}
			case "Protocol" : {
				return new TokenValueString (Protocol);
				}
			case "Options" : {
				return new TokenValueListString (Options);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "IpAddress", new Property (typeof(TokenValueBinary), false)} ,
			{ "Port", new Property (typeof(TokenValueInteger32), false)} ,
			{ "Protocol", new Property (typeof(TokenValueString), false)} ,
			{ "Options", new Property (typeof(TokenValueListString), true)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "SessionEndpoint";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new SessionEndpoint();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new SessionEndpoint FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as SessionEndpoint;
			}
		var Result = new SessionEndpoint ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class UdpEndpoint : PresenceProtocol {
        /// <summary>
        /// </summary>

	public virtual byte[]						IpAddress  {get; set;}
        /// <summary>
        /// </summary>

	public virtual int?						Port  {get; set;}


    ///<inheritdoc/>
	public override void Setter(
			string tag, TokenValue value) { 
		switch (tag) {
			case "IpAddress" : {
				if (value is TokenValueBinary vvalue) {
					IpAddress = vvalue.Value;
					}
				break;
				}
			case "Port" : {
				if (value is TokenValueInteger32 vvalue) {
					Port = vvalue.Value;
					}
				break;
				}

			default: {
				base.Setter(tag, value);
				break;
				}
			}
		}

    ///<inheritdoc/>
    public override TokenValue Getter(
            string tag) {
        switch (tag) {
			case "IpAddress" : {
				return new TokenValueBinary (IpAddress);
				}
			case "Port" : {
				return new TokenValueInteger32 (Port);
				}

            default: {
                return base.Getter(tag);
                }
            }
        }


    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = new() {

			{ "IpAddress", new Property (typeof(TokenValueBinary), false)} ,
			{ "Port", new Property (typeof(TokenValueInteger32), false)} 
        };

	///<summary>Dictionary describing the serializable properties.</summary> 
	public readonly static new Dictionary<string, Property> _StaticAllProperties = _StaticProperties;


    ///<inheritdoc/>
	public override Dictionary<string, Property> _AllProperties => _StaticAllProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _Properties => _StaticProperties;

    ///<inheritdoc/>
    public override Dictionary<string, Property> _ParentProperties => base._Properties;



	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag => __Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "UdpEndpoint";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new UdpEndpoint();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new UdpEndpoint FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as UdpEndpoint;
			}
		var Result = new UdpEndpoint ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



