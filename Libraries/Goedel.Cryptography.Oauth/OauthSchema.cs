
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
//  This file was automatically generated at 2/13/2025 1:01:51 PM
//   
//  Changes to this file may be overwritten without warning
//  
//  Generator:  protogen version 3.0.0.1141
//      Goedel Script Version : 0.1   Generated 
//      Goedel Schema Version : 0.1   Generated
//  
//      Copyright : © 2015-2021
//  
//  Build Platform: Win32NT 10.0.26100.0
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



namespace Goedel.Cryptography.Oauth;


	/// <summary>
	///
	/// Support classes for OAUTH2 via ATproto
	/// </summary>
public abstract partial class Oauth : global::Goedel.Protocol.JsonObject {

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public override string _Tag =>__Tag;

	/// <summary>
    /// Tag identifying this class
    /// </summary>
	public new const string __Tag = "Oauth";

	/// <summary>
    /// Dictionary mapping tags to factory methods
    /// </summary>
	public static Dictionary<string, JsonFactoryDelegate> _TagDictionary=> _tagDictionary;
	static Dictionary<string, JsonFactoryDelegate> _tagDictionary = 
			new () {

	    {"ResourceServerMetadata", ResourceServerMetadata._Factory},
	    {"AuthorizationServerMetadata", AuthorizationServerMetadata._Factory},
	    {"AuthorizationRequest", AuthorizationRequest._Factory},
	    {"AuthorizationRequest2", AuthorizationRequest2._Factory},
	    {"PushedAuthorizationResponse", PushedAuthorizationResponse._Factory},
	    {"AuthorizationResponse", AuthorizationResponse._Factory},
	    {"ErrorResponse", ErrorResponse._Factory},
	    {"ClientMetadata", ClientMetadata._Factory},
	    {"DidDocument", DidDocument._Factory},
	    {"AuthorizationCodeGrant", AuthorizationCodeGrant._Factory},
	    {"ClientCredentialsGrant", ClientCredentialsGrant._Factory},
	    {"RefreshTokenGrant", RefreshTokenGrant._Factory},
	    {"DidVerificationMethod", DidVerificationMethod._Factory},
	    {"DidService", DidService._Factory},
	    {"AuthenticationResponse", AuthenticationResponse._Factory},
	    {"JWKS", JWKS._Factory},
	    {"JWK", JWK._Factory},
	    {"JwtHeader", JwtHeader._Factory},
	    {"DpopPayload", DpopPayload._Factory},
	    {"DpopConfirmation", DpopConfirmation._Factory},
	    {"JwtDpop", JwtDpop._Factory}
		};

    // [ModuleInitializer]
	
	public static bool _Initialized => true;

	static Oauth() {
		_Initialize();
		}

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
public partial class ResourceServerMetadata : Oauth {
        /// <summary>
        /// </summary>

	public virtual string?						Resource  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					AuthorizationServers  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					ScopesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					BearerMethodsSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						ResourceDocumentation  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "resource", new PropertyString ("resource", 
					(IBinding data, string? value) => {(data as ResourceServerMetadata).Resource = value;}, (IBinding data) => (data as ResourceServerMetadata).Resource )},
			{ "authorization_servers", new PropertyListString ("authorization_servers", 
					(IBinding data, List<string>? value) => {(data as ResourceServerMetadata).AuthorizationServers = value;}, (IBinding data) => (data as ResourceServerMetadata).AuthorizationServers )},
			{ "scopes_supported", new PropertyListString ("scopes_supported", 
					(IBinding data, List<string>? value) => {(data as ResourceServerMetadata).ScopesSupported = value;}, (IBinding data) => (data as ResourceServerMetadata).ScopesSupported )},
			{ "bearer_methods_supported", new PropertyListString ("bearer_methods_supported", 
					(IBinding data, List<string>? value) => {(data as ResourceServerMetadata).BearerMethodsSupported = value;}, (IBinding data) => (data as ResourceServerMetadata).BearerMethodsSupported )},
			{ "resource_documentation", new PropertyString ("resource_documentation", 
					(IBinding data, string? value) => {(data as ResourceServerMetadata).ResourceDocumentation = value;}, (IBinding data) => (data as ResourceServerMetadata).ResourceDocumentation )}
        }, __Tag,() => new ResourceServerMetadata(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "ResourceServerMetadata";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ResourceServerMetadata();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ResourceServerMetadata FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ResourceServerMetadata;
			}
		var Result = new ResourceServerMetadata ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// AuthorizationServerMetadata2
	/// </summary>
public partial class AuthorizationServerMetadata : Oauth {
        /// <summary>
        /// </summary>

	public virtual string?						Issuer  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					ScopesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					SubjectTypesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					ResponseTypesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					ResponseModesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					GrantTypesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					CodeChallengeMethodsSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					UiLocalesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					DisplayValuesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						AuthorizationResponseIssParameterSupported  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					RequestObjectSigningAlgValuesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					RequestObjectEncryptionAlgValuesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					RequestObjectEncryptionEncValuesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						RequestParameterSupported  {get; set;}

        /// <summary>
        /// </summary>

	public virtual bool?						RequestUriParameterSupported  {get; set;}

        /// <summary>
        /// </summary>

	public virtual bool?						RequireRequestUriRegistration  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						JwksUri  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						AuthorizationEndpoint  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						TokenEndpoint  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					TokenEndpointAuthMethodsSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					TokenEndpointAuthSigningAlgValuesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						RevocationEndpoint  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						IntrospectionEndpoint  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						PushedAuthorizationRequestEndpoint  {get; set;}

        /// <summary>
        /// </summary>

	public virtual bool?						RequirePushedAuthorizationRequests  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					DpopSigningAlgValuesSupported  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						ClientIdMetadataDocumentSupported  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "issuer", new PropertyString ("issuer", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).Issuer = value;}, (IBinding data) => (data as AuthorizationServerMetadata).Issuer )},
			{ "scopes_supported", new PropertyListString ("scopes_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).ScopesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).ScopesSupported )},
			{ "subject_types_supported", new PropertyListString ("subject_types_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).SubjectTypesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).SubjectTypesSupported )},
			{ "response_types_supported", new PropertyListString ("response_types_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).ResponseTypesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).ResponseTypesSupported )},
			{ "response_modes_supported", new PropertyListString ("response_modes_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).ResponseModesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).ResponseModesSupported )},
			{ "grant_types_supported", new PropertyListString ("grant_types_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).GrantTypesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).GrantTypesSupported )},
			{ "code_challenge_methods_supported", new PropertyListString ("code_challenge_methods_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).CodeChallengeMethodsSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).CodeChallengeMethodsSupported )},
			{ "ui_locales_supported", new PropertyListString ("ui_locales_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).UiLocalesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).UiLocalesSupported )},
			{ "display_values_supported", new PropertyListString ("display_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).DisplayValuesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).DisplayValuesSupported )},
			{ "authorization_response_iss_parameter_supported", new PropertyBoolean ("authorization_response_iss_parameter_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).AuthorizationResponseIssParameterSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).AuthorizationResponseIssParameterSupported )},
			{ "request_object_signing_alg_values_supported", new PropertyListString ("request_object_signing_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).RequestObjectSigningAlgValuesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RequestObjectSigningAlgValuesSupported )},
			{ "request_object_encryption_alg_values_supported", new PropertyListString ("request_object_encryption_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).RequestObjectEncryptionAlgValuesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RequestObjectEncryptionAlgValuesSupported )},
			{ "request_object_encryption_enc_values_supported", new PropertyListString ("request_object_encryption_enc_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).RequestObjectEncryptionEncValuesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RequestObjectEncryptionEncValuesSupported )},
			{ "request_parameter_supported", new PropertyBoolean ("request_parameter_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequestParameterSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RequestParameterSupported )},
			{ "request_uri_parameter_supported", new PropertyBoolean ("request_uri_parameter_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequestUriParameterSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RequestUriParameterSupported )},
			{ "require_request_uri_registration", new PropertyBoolean ("require_request_uri_registration", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequireRequestUriRegistration = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RequireRequestUriRegistration )},
			{ "jwks_uri", new PropertyString ("jwks_uri", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).JwksUri = value;}, (IBinding data) => (data as AuthorizationServerMetadata).JwksUri )},
			{ "authorization_endpoint", new PropertyString ("authorization_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).AuthorizationEndpoint = value;}, (IBinding data) => (data as AuthorizationServerMetadata).AuthorizationEndpoint )},
			{ "token_endpoint", new PropertyString ("token_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).TokenEndpoint = value;}, (IBinding data) => (data as AuthorizationServerMetadata).TokenEndpoint )},
			{ "token_endpoint_auth_methods_supported", new PropertyListString ("token_endpoint_auth_methods_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).TokenEndpointAuthMethodsSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).TokenEndpointAuthMethodsSupported )},
			{ "token_endpoint_auth_signing_alg_values_supported", new PropertyListString ("token_endpoint_auth_signing_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).TokenEndpointAuthSigningAlgValuesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).TokenEndpointAuthSigningAlgValuesSupported )},
			{ "revocation_endpoint", new PropertyString ("revocation_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).RevocationEndpoint = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RevocationEndpoint )},
			{ "introspection_endpoint", new PropertyString ("introspection_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).IntrospectionEndpoint = value;}, (IBinding data) => (data as AuthorizationServerMetadata).IntrospectionEndpoint )},
			{ "pushed_authorization_request_endpoint", new PropertyString ("pushed_authorization_request_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).PushedAuthorizationRequestEndpoint = value;}, (IBinding data) => (data as AuthorizationServerMetadata).PushedAuthorizationRequestEndpoint )},
			{ "require_pushed_authorization_requests", new PropertyBoolean ("require_pushed_authorization_requests", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequirePushedAuthorizationRequests = value;}, (IBinding data) => (data as AuthorizationServerMetadata).RequirePushedAuthorizationRequests )},
			{ "dpop_signing_alg_values_supported", new PropertyListString ("dpop_signing_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).DpopSigningAlgValuesSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).DpopSigningAlgValuesSupported )},
			{ "client_id_metadata_document_supported", new PropertyBoolean ("client_id_metadata_document_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).ClientIdMetadataDocumentSupported = value;}, (IBinding data) => (data as AuthorizationServerMetadata).ClientIdMetadataDocumentSupported )}
        }, __Tag,() => new AuthorizationServerMetadata(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "AuthorizationServerMetadata";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AuthorizationServerMetadata();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AuthorizationServerMetadata FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AuthorizationServerMetadata;
			}
		var Result = new AuthorizationServerMetadata ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Authorization Request
	/// </summary>
public partial class AuthorizationRequest : Oauth {
        /// <summary>
        ///Identifies the client software
        /// </summary>

	public virtual string?						ClientId  {get; set;}

        /// <summary>
        /// must be code
        /// </summary>

	public virtual string?						ResponseType  {get; set;}

        /// <summary>
        /// the PKCE challenge value. 
        /// </summary>

	public virtual string?						CodeChallenge  {get; set;}

        /// <summary>
        ///which code challenge method is used, for example S256
        /// </summary>

	public virtual string?						CodeChallengeMethod  {get; set;}

        /// <summary>
        ///random token used to verify the authorization request against the response
        /// </summary>

	public virtual string?						State  {get; set;}

        /// <summary>
        ///Must match against URIs declared in client metadata and have a format consistent 
        ///with the application_type declared in the client metadata
        /// </summary>

	public virtual string?						RedirectUri  {get; set;}

        /// <summary>
        ///Must be a subset of the scopes declared in client metadata. Must include atproto
        /// </summary>

	public virtual string?						Scope  {get; set;}

        /// <summary>
        ///Used by confidential clients to describe the client authentication mechanism
        /// </summary>

	public virtual string?						ClientAssertionType  {get; set;}

        /// <summary>
        ///Only used for confidential clients
        /// </summary>

	public virtual string?						ClientAssertion  {get; set;}

        /// <summary>
        ///Account identifier to be used for login
        /// </summary>

	public virtual string?						LoginHint  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "client_id", new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ClientId = value;}, (IBinding data) => (data as AuthorizationRequest).ClientId )},
			{ "response_type", new PropertyString ("response_type", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ResponseType = value;}, (IBinding data) => (data as AuthorizationRequest).ResponseType )},
			{ "code_challenge", new PropertyString ("code_challenge", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).CodeChallenge = value;}, (IBinding data) => (data as AuthorizationRequest).CodeChallenge )},
			{ "code_challenge_method", new PropertyString ("code_challenge_method", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).CodeChallengeMethod = value;}, (IBinding data) => (data as AuthorizationRequest).CodeChallengeMethod )},
			{ "state", new PropertyString ("state", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).State = value;}, (IBinding data) => (data as AuthorizationRequest).State )},
			{ "redirect_uri", new PropertyString ("redirect_uri", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).RedirectUri = value;}, (IBinding data) => (data as AuthorizationRequest).RedirectUri )},
			{ "scope", new PropertyString ("scope", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).Scope = value;}, (IBinding data) => (data as AuthorizationRequest).Scope )},
			{ "client_assertion_type", new PropertyString ("client_assertion_type", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ClientAssertionType = value;}, (IBinding data) => (data as AuthorizationRequest).ClientAssertionType )},
			{ "client_assertion", new PropertyString ("client_assertion", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ClientAssertion = value;}, (IBinding data) => (data as AuthorizationRequest).ClientAssertion )},
			{ "login_hint", new PropertyString ("login_hint", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).LoginHint = value;}, (IBinding data) => (data as AuthorizationRequest).LoginHint )}
        }, __Tag,() => new AuthorizationRequest(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "AuthorizationRequest";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AuthorizationRequest();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AuthorizationRequest FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AuthorizationRequest;
			}
		var Result = new AuthorizationRequest ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class AuthorizationRequest2 : Oauth {
        /// <summary>
        ///Identifies the client software
        /// </summary>

	public virtual string?						ClientId  {get; set;}

        /// <summary>
        ///The RequestUri returned by the server
        /// </summary>

	public virtual string?						RequestUri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "client_id", new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as AuthorizationRequest2).ClientId = value;}, (IBinding data) => (data as AuthorizationRequest2).ClientId )},
			{ "request_uri", new PropertyString ("request_uri", 
					(IBinding data, string? value) => {(data as AuthorizationRequest2).RequestUri = value;}, (IBinding data) => (data as AuthorizationRequest2).RequestUri )}
        }, __Tag,() => new AuthorizationRequest2(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "AuthorizationRequest2";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AuthorizationRequest2();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AuthorizationRequest2 FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AuthorizationRequest2;
			}
		var Result = new AuthorizationRequest2 ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class PushedAuthorizationResponse : Oauth {
        /// <summary>
        ///A JSON number that represents the lifetime of the request URI in seconds as a
        ///positive integer. The request URI lifetime is at the discretion of the 
        ///authorization server but will typically be relatively short (e.g., between 
        ///5 and 600 seconds).
        /// </summary>

	public virtual int?						ExpiresIn  {get; set;}

        /// <summary>
        ///REQUIRED The request URI corresponding to the authorization request posted. 
        ///This URI is a single-use reference to the respective request data in the 
        ///subsequent authorization request. The way the authorization process obtains 
        ///the authorization request data is at the discretion of the authorization 
        ///server and is out of scope of this specification. There is no need to make 
        ///the authorization request data available to other parties via this URI.
        /// </summary>

	public virtual string?						RequestUri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "expires_in", new PropertyInteger32 ("expires_in", 
					(IBinding data, int? value) => {(data as PushedAuthorizationResponse).ExpiresIn = value;}, (IBinding data) => (data as PushedAuthorizationResponse).ExpiresIn )},
			{ "request_uri", new PropertyString ("request_uri", 
					(IBinding data, string? value) => {(data as PushedAuthorizationResponse).RequestUri = value;}, (IBinding data) => (data as PushedAuthorizationResponse).RequestUri )}
        }, __Tag,() => new PushedAuthorizationResponse(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "PushedAuthorizationResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new PushedAuthorizationResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new PushedAuthorizationResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as PushedAuthorizationResponse;
			}
		var Result = new PushedAuthorizationResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	///
	/// Authorization Request
	/// </summary>
public partial class AuthorizationResponse : Oauth {
        /// <summary>
        ///The authorization code is generated by the authorization server and opaque 
        ///to the client. The authorization code MUST expire shortly after it is issued 
        ///to mitigate the risk of leaks. A maximum authorization code lifetime of 10 
        ///minutes is RECOMMENDED. The authorization code is bound to the client identifier,
        ///code challenge and redirect URI.
        /// </summary>

	public virtual string?						Code  {get; set;}

        /// <summary>
        ///REQUIRED if the state parameter was present in the client authorization request.
        ///The exact value received from the client.
        /// </summary>

	public virtual string?						State  {get; set;}

        /// <summary>
        ///The identifier of the authorization server which the client can use to prevent
        ///mix-up attacks, if the client interacts with more than one authorization server.
        /// </summary>

	public virtual string?						Iss  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "code", new PropertyString ("code", 
					(IBinding data, string? value) => {(data as AuthorizationResponse).Code = value;}, (IBinding data) => (data as AuthorizationResponse).Code )},
			{ "state", new PropertyString ("state", 
					(IBinding data, string? value) => {(data as AuthorizationResponse).State = value;}, (IBinding data) => (data as AuthorizationResponse).State )},
			{ "iss", new PropertyString ("iss", 
					(IBinding data, string? value) => {(data as AuthorizationResponse).Iss = value;}, (IBinding data) => (data as AuthorizationResponse).Iss )}
        }, __Tag,() => new AuthorizationResponse(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "AuthorizationResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AuthorizationResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AuthorizationResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AuthorizationResponse;
			}
		var Result = new AuthorizationResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ErrorResponse : Oauth {
        /// <summary>
        /// A single ASCII [USASCII] error code from the following
        ///"invalid_request": The request is missing a required parameter, includes an 
        ///invalid parameter value, includes a parameter more than once, or is otherwise malformed.
        ///"unauthorized_client": The client is not authorized to request an authorization code 
        ///using this method.
        ///"access_denied": The resource owner or authorization server denied the request.
        ///"unsupported_response_type": The authorization server does not support obtaining an 
        ///authorization code using this method.
        ///"invalid_scope": The requested scope is invalid, unknown, or malformed.
        ///"server_error": The authorization server encountered an unexpected condition that 
        ///prevented it from fulfilling the request. (This error code is needed because a 500 
        ///Internal Server Error HTTP status code cannot be returned to the client via an HTTP redirect.)
        ///"temporarily_unavailable": The authorization server is currently unable to handle 
        ///the request due to a temporary overloading or maintenance of the server. (This 
        ///error code is needed because a 503 Service Unavailable HTTP status code cannot 
        ///be returned to the client via an HTTP redirect.)
        /// </summary>

	public virtual string?						Error  {get; set;}

        /// <summary>
        /// Human-readable ASCII [USASCII] text providing additional information, used to 
        ///assist the client developer in understanding the error that occurred. Values for
        ///the error_description parameter MUST NOT include characters outside the set 
        ///%x20-21 / %x23-5B / %x5D-7E.
        /// </summary>

	public virtual string?						ErrorDescription  {get; set;}

        /// <summary>
        ///A URI identifying a human-readable web page with information about the error, 
        ///used to provide the client developer with additional information about the error. 
        ///Values for the error_uri parameter MUST conform to the URI-reference syntax and 
        ///thus MUST NOT include characters outside the set %x21 / %x23-5B / %x5D-7E
        /// </summary>

	public virtual string?						ErrorUri  {get; set;}

        /// <summary>
        ///REQUIRED if a state parameter was present in the client authorization request. 
        ///The exact value received from the client
        /// </summary>

	public virtual string?						State  {get; set;}

        /// <summary>
        ///The identifier of the authorization server which the client can use to prevent
        ///mix-up attacks, if the client interacts with more than one authorization server.
        /// </summary>

	public virtual string?						Iss  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "error", new PropertyString ("error", 
					(IBinding data, string? value) => {(data as ErrorResponse).Error = value;}, (IBinding data) => (data as ErrorResponse).Error )},
			{ "errorDescription", new PropertyString ("errorDescription", 
					(IBinding data, string? value) => {(data as ErrorResponse).ErrorDescription = value;}, (IBinding data) => (data as ErrorResponse).ErrorDescription )},
			{ "errorUri", new PropertyString ("errorUri", 
					(IBinding data, string? value) => {(data as ErrorResponse).ErrorUri = value;}, (IBinding data) => (data as ErrorResponse).ErrorUri )},
			{ "state", new PropertyString ("state", 
					(IBinding data, string? value) => {(data as ErrorResponse).State = value;}, (IBinding data) => (data as ErrorResponse).State )},
			{ "iss", new PropertyString ("iss", 
					(IBinding data, string? value) => {(data as ErrorResponse).Iss = value;}, (IBinding data) => (data as ErrorResponse).Iss )}
        }, __Tag,() => new ErrorResponse(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "ErrorResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ErrorResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ErrorResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ErrorResponse;
			}
		var Result = new ErrorResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ClientMetadata : Oauth {
        /// <summary>
        /// </summary>

	public virtual string?						ClientId  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						ApplicationType  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					GrantTypes  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						Scope  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					ResponseTypes  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<string>?					RedirectUris  {get; set;}
        /// <summary>
        /// </summary>

	public virtual bool?						DpopBoundAccessTokens  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						TokenEndpointAuthMethod  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						TokenEndpointAuthSigningAlg  {get; set;}

        /// <summary>
        /// </summary>

	public virtual JWKS?						Jwks  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						ClientName  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						ClientUri  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						LogoUri  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						TosUri  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						PolicyUri  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "client_id", new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as ClientMetadata).ClientId = value;}, (IBinding data) => (data as ClientMetadata).ClientId )},
			{ "application_type", new PropertyString ("application_type", 
					(IBinding data, string? value) => {(data as ClientMetadata).ApplicationType = value;}, (IBinding data) => (data as ClientMetadata).ApplicationType )},
			{ "grant_types", new PropertyListString ("grant_types", 
					(IBinding data, List<string>? value) => {(data as ClientMetadata).GrantTypes = value;}, (IBinding data) => (data as ClientMetadata).GrantTypes )},
			{ "scope", new PropertyString ("scope", 
					(IBinding data, string? value) => {(data as ClientMetadata).Scope = value;}, (IBinding data) => (data as ClientMetadata).Scope )},
			{ "response_types", new PropertyListString ("response_types", 
					(IBinding data, List<string>? value) => {(data as ClientMetadata).ResponseTypes = value;}, (IBinding data) => (data as ClientMetadata).ResponseTypes )},
			{ "redirect_uris", new PropertyListString ("redirect_uris", 
					(IBinding data, List<string>? value) => {(data as ClientMetadata).RedirectUris = value;}, (IBinding data) => (data as ClientMetadata).RedirectUris )},
			{ "dpop_bound_access_tokens", new PropertyBoolean ("dpop_bound_access_tokens", 
					(IBinding data, bool? value) => {(data as ClientMetadata).DpopBoundAccessTokens = value;}, (IBinding data) => (data as ClientMetadata).DpopBoundAccessTokens )},
			{ "token_endpoint_auth_method", new PropertyString ("token_endpoint_auth_method", 
					(IBinding data, string? value) => {(data as ClientMetadata).TokenEndpointAuthMethod = value;}, (IBinding data) => (data as ClientMetadata).TokenEndpointAuthMethod )},
			{ "token_endpoint_auth_signing_alg", new PropertyString ("token_endpoint_auth_signing_alg", 
					(IBinding data, string? value) => {(data as ClientMetadata).TokenEndpointAuthSigningAlg = value;}, (IBinding data) => (data as ClientMetadata).TokenEndpointAuthSigningAlg )},
			{ "jwks", new PropertyStruct ("jwks", 
					(IBinding data, object? value) => {(data as ClientMetadata).Jwks = value as JWKS?;}, (IBinding data) => (data as ClientMetadata).Jwks,
					false, ()=>new  JWKS?(), ()=>new JWKS())} ,
			{ "client_name", new PropertyString ("client_name", 
					(IBinding data, string? value) => {(data as ClientMetadata).ClientName = value;}, (IBinding data) => (data as ClientMetadata).ClientName )},
			{ "client_uri", new PropertyString ("client_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).ClientUri = value;}, (IBinding data) => (data as ClientMetadata).ClientUri )},
			{ "logo_uri", new PropertyString ("logo_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).LogoUri = value;}, (IBinding data) => (data as ClientMetadata).LogoUri )},
			{ "tos_uri", new PropertyString ("tos_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).TosUri = value;}, (IBinding data) => (data as ClientMetadata).TosUri )},
			{ "policy_uri", new PropertyString ("policy_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).PolicyUri = value;}, (IBinding data) => (data as ClientMetadata).PolicyUri )}
        }, __Tag,() => new ClientMetadata(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "ClientMetadata";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ClientMetadata();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ClientMetadata FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ClientMetadata;
			}
		var Result = new ClientMetadata ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DidDocument : Oauth {
        /// <summary>
        /// </summary>

	public virtual List<string>?					Contexts  {get; set;}
        /// <summary>
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        /// </summary>

	public virtual List<string>?					AlsoKnownAs  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<DidVerificationMethod>?					VerificationMethod  {get; set;}
        /// <summary>
        /// </summary>

	public virtual List<DidService>?					Service  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "@context", new PropertyListString ("@context", 
					(IBinding data, List<string>? value) => {(data as DidDocument).Contexts = value;}, (IBinding data) => (data as DidDocument).Contexts )},
			{ "id", new PropertyString ("id", 
					(IBinding data, string? value) => {(data as DidDocument).Id = value;}, (IBinding data) => (data as DidDocument).Id )},
			{ "alsoKnownAs", new PropertyListString ("alsoKnownAs", 
					(IBinding data, List<string>? value) => {(data as DidDocument).AlsoKnownAs = value;}, (IBinding data) => (data as DidDocument).AlsoKnownAs )},
			{ "verificationMethod", new PropertyListStruct ("verificationMethod", 
					(IBinding data, object? value) => {(data as DidDocument).VerificationMethod = value as List<DidVerificationMethod>?;}, (IBinding data) => (data as DidDocument).VerificationMethod,
					false, ()=>new  List<DidVerificationMethod>?(), ()=>new DidVerificationMethod())} ,
			{ "service", new PropertyListStruct ("service", 
					(IBinding data, object? value) => {(data as DidDocument).Service = value as List<DidService>?;}, (IBinding data) => (data as DidDocument).Service,
					false, ()=>new  List<DidService>?(), ()=>new DidService())} 
        }, __Tag,() => new DidDocument(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "DidDocument";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DidDocument();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DidDocument FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DidDocument;
			}
		var Result = new DidDocument ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class AuthorizationCodeGrant : Oauth {
        /// <summary>
        ///"authorization_code"
        /// </summary>

	public virtual string?						GrantType  {get; set;}

        /// <summary>
        ///The authorization code received from the authorization server.
        /// </summary>

	public virtual string?						Code  {get; set;}

        /// <summary>
        ///REQUIRED, if the code_challenge parameter was included in the 
        ///authorization request. MUST NOT be used otherwise. The original code 
        ///verifier string.
        /// </summary>

	public virtual string?						CodeVerifier  {get; set;}

        /// <summary>
        ///Identifies the client software
        /// </summary>

	public virtual string?						ClientId  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "grant_type", new PropertyString ("grant_type", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).GrantType = value;}, (IBinding data) => (data as AuthorizationCodeGrant).GrantType )},
			{ "code", new PropertyString ("code", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).Code = value;}, (IBinding data) => (data as AuthorizationCodeGrant).Code )},
			{ "code_verifier", new PropertyString ("code_verifier", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).CodeVerifier = value;}, (IBinding data) => (data as AuthorizationCodeGrant).CodeVerifier )},
			{ "client_id", new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).ClientId = value;}, (IBinding data) => (data as AuthorizationCodeGrant).ClientId )}
        }, __Tag,() => new AuthorizationCodeGrant(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "AuthorizationCodeGrant";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AuthorizationCodeGrant();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AuthorizationCodeGrant FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AuthorizationCodeGrant;
			}
		var Result = new AuthorizationCodeGrant ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class ClientCredentialsGrant : Oauth {
        /// <summary>
        ///REQUIRED. "client_credentials"
        /// </summary>

	public virtual string?						GrantType  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "grant_type", new PropertyString ("grant_type", 
					(IBinding data, string? value) => {(data as ClientCredentialsGrant).GrantType = value;}, (IBinding data) => (data as ClientCredentialsGrant).GrantType )}
        }, __Tag,() => new ClientCredentialsGrant(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "ClientCredentialsGrant";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new ClientCredentialsGrant();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new ClientCredentialsGrant FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as ClientCredentialsGrant;
			}
		var Result = new ClientCredentialsGrant ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class RefreshTokenGrant : Oauth {
        /// <summary>
        ///REQUIRED. "refresh_token"
        /// </summary>

	public virtual string?						GrantType  {get; set;}

        /// <summary>
        ///REQUIRED. "client_credentials"
        /// </summary>

	public virtual string?						refresh_token  {get; set;}

        /// <summary>
        ///Must be a subset of the scopes declared in client metadata. Must include atproto
        /// </summary>

	public virtual string?						Scope  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "grant_type", new PropertyString ("grant_type", 
					(IBinding data, string? value) => {(data as RefreshTokenGrant).GrantType = value;}, (IBinding data) => (data as RefreshTokenGrant).GrantType )},
			{ "refresh_token", new PropertyString ("refresh_token", 
					(IBinding data, string? value) => {(data as RefreshTokenGrant).refresh_token = value;}, (IBinding data) => (data as RefreshTokenGrant).refresh_token )},
			{ "scope", new PropertyString ("scope", 
					(IBinding data, string? value) => {(data as RefreshTokenGrant).Scope = value;}, (IBinding data) => (data as RefreshTokenGrant).Scope )}
        }, __Tag,() => new RefreshTokenGrant(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "RefreshTokenGrant";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new RefreshTokenGrant();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new RefreshTokenGrant FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as RefreshTokenGrant;
			}
		var Result = new RefreshTokenGrant ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DidVerificationMethod : Oauth {
        /// <summary>
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Controller  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						PublicKeyMultibase  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "id", new PropertyString ("id", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).Id = value;}, (IBinding data) => (data as DidVerificationMethod).Id )},
			{ "type", new PropertyString ("type", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).Type = value;}, (IBinding data) => (data as DidVerificationMethod).Type )},
			{ "controller", new PropertyString ("controller", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).Controller = value;}, (IBinding data) => (data as DidVerificationMethod).Controller )},
			{ "publicKeyMultibase", new PropertyString ("publicKeyMultibase", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).PublicKeyMultibase = value;}, (IBinding data) => (data as DidVerificationMethod).PublicKeyMultibase )}
        }, __Tag,() => new DidVerificationMethod(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "DidVerificationMethod";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DidVerificationMethod();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DidVerificationMethod FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DidVerificationMethod;
			}
		var Result = new DidVerificationMethod ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DidService : Oauth {
        /// <summary>
        /// </summary>

	public virtual string?						Id  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Type  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						ServiceEndpoint  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "id", new PropertyString ("id", 
					(IBinding data, string? value) => {(data as DidService).Id = value;}, (IBinding data) => (data as DidService).Id )},
			{ "type", new PropertyString ("type", 
					(IBinding data, string? value) => {(data as DidService).Type = value;}, (IBinding data) => (data as DidService).Type )},
			{ "serviceEndpoint", new PropertyString ("serviceEndpoint", 
					(IBinding data, string? value) => {(data as DidService).ServiceEndpoint = value;}, (IBinding data) => (data as DidService).ServiceEndpoint )}
        }, __Tag,() => new DidService(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "DidService";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DidService();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DidService FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DidService;
			}
		var Result = new DidService ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class AuthenticationResponse : Oauth {
        /// <summary>
        /// </summary>

	public virtual string?						Iss  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						State  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Code  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "iss", new PropertyString ("iss", 
					(IBinding data, string? value) => {(data as AuthenticationResponse).Iss = value;}, (IBinding data) => (data as AuthenticationResponse).Iss )},
			{ "state", new PropertyString ("state", 
					(IBinding data, string? value) => {(data as AuthenticationResponse).State = value;}, (IBinding data) => (data as AuthenticationResponse).State )},
			{ "code", new PropertyString ("code", 
					(IBinding data, string? value) => {(data as AuthenticationResponse).Code = value;}, (IBinding data) => (data as AuthenticationResponse).Code )}
        }, __Tag,() => new AuthenticationResponse(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "AuthenticationResponse";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new AuthenticationResponse();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new AuthenticationResponse FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as AuthenticationResponse;
			}
		var Result = new AuthenticationResponse ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class JWKS : Oauth {
        /// <summary>
        /// </summary>

	public virtual List<JWK>?					Keys  {get; set;}


    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "keys", new PropertyListStruct ("keys", 
					(IBinding data, object? value) => {(data as JWKS).Keys = value as List<JWK>?;}, (IBinding data) => (data as JWKS).Keys,
					false, ()=>new  List<JWK>?(), ()=>new JWK())} 
        }, __Tag,() => new JWKS(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "JWKS";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JWKS();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new JWKS FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JWKS;
			}
		var Result = new JWKS ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class JWK : Oauth {
        /// <summary>
        /// </summary>

	public virtual string?						Kid  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						KeyType  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Use  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Curve  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						X  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						Y  {get; set;}

        /// <summary>
        /// </summary>

	public virtual string?						D  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "kid", new PropertyString ("kid", 
					(IBinding data, string? value) => {(data as JWK).Kid = value;}, (IBinding data) => (data as JWK).Kid )},
			{ "kty", new PropertyString ("kty", 
					(IBinding data, string? value) => {(data as JWK).KeyType = value;}, (IBinding data) => (data as JWK).KeyType )},
			{ "use", new PropertyString ("use", 
					(IBinding data, string? value) => {(data as JWK).Use = value;}, (IBinding data) => (data as JWK).Use )},
			{ "crv", new PropertyString ("crv", 
					(IBinding data, string? value) => {(data as JWK).Curve = value;}, (IBinding data) => (data as JWK).Curve )},
			{ "x", new PropertyString ("x", 
					(IBinding data, string? value) => {(data as JWK).X = value;}, (IBinding data) => (data as JWK).X )},
			{ "y", new PropertyString ("y", 
					(IBinding data, string? value) => {(data as JWK).Y = value;}, (IBinding data) => (data as JWK).Y )},
			{ "d", new PropertyString ("d", 
					(IBinding data, string? value) => {(data as JWK).D = value;}, (IBinding data) => (data as JWK).D )}
        }, __Tag,() => new JWK(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "JWK";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JWK();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new JWK FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JWK;
			}
		var Result = new JWK ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class JwtHeader : Oauth {
        /// <summary>
        ///Another IANA content type parameter
        /// </summary>

	public virtual string?						Typ  {get; set;}

        /// <summary>
        ///Key exchange algorithm
        /// </summary>

	public virtual string?						Alg  {get; set;}

        /// <summary>
        ///JSON Web Key		
        /// </summary>

	public virtual JWK?						Jwk  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "typ", new PropertyString ("typ", 
					(IBinding data, string? value) => {(data as JwtHeader).Typ = value;}, (IBinding data) => (data as JwtHeader).Typ )},
			{ "alg", new PropertyString ("alg", 
					(IBinding data, string? value) => {(data as JwtHeader).Alg = value;}, (IBinding data) => (data as JwtHeader).Alg )},
			{ "jwk", new PropertyStruct ("jwk", 
					(IBinding data, object? value) => {(data as JwtHeader).Jwk = value as JWK?;}, (IBinding data) => (data as JwtHeader).Jwk,
					false, ()=>new  JWK?(), ()=>new JWK())} 
        }, __Tag,() => new JwtHeader(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "JwtHeader";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwtHeader();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new JwtHeader FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JwtHeader;
			}
		var Result = new JwtHeader ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DpopPayload : Oauth {
        /// <summary>
        ///Unique identifier for the DPoP proof JWT. The value MUST be assigned such 
        ///that there is a negligible probability that the same value will be assigned 
        ///to any other DPoP proof used in the same context during the time window of 
        ///validity. Such uniqueness can be accomplished by encoding (base64url or any 
        ///other suitable encoding) at least 96 bits of pseudorandom data or by using 
        ///a version 4 Universally Unique Identifier (UUID) string according to 
        ///[RFC4122]. The jti can be used by the server for replay detection and 
        ///prevention; see Section 11.1.
        /// </summary>

	public virtual string?						JTI  {get; set;}

        /// <summary>
        ///The value of the HTTP method (Section 9.1 of [RFC9110]) of the request to
        ///which the JWT is attached.
        /// </summary>

	public virtual string?						HTM  {get; set;}

        /// <summary>
        ///The HTTP target URI (Section 7.1 of [RFC9110]) of the request to which 
        ///the JWT is attached, without query and fragment parts.
        /// </summary>

	public virtual string?						HTU  {get; set;}

        /// <summary>
        ///Creation timestamp of the JWT (Section 4.1.6 of [RFC7519])
        /// </summary>

	public virtual string?						IAT  {get; set;}

        /// <summary>
        ///Hash of the access token. The value MUST be the result of a base64url encoding 
        ///(as defined in Section 2 of [RFC7515]) the SHA-256 [SHS] hash of the ASCII 
        ///encoding of the associated access token's value.
        /// </summary>

	public virtual string?						ATH  {get; set;}

        /// <summary>
        ///A recent nonce provided via the DPoP-Nonce HTTP header.
        /// </summary>

	public virtual string?						Nonce  {get; set;}

        /// <summary>
        ///Confirmation
        /// </summary>

	public virtual DpopConfirmation?						Confirm  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "jti", new PropertyString ("jti", 
					(IBinding data, string? value) => {(data as DpopPayload).JTI = value;}, (IBinding data) => (data as DpopPayload).JTI )},
			{ "htm", new PropertyString ("htm", 
					(IBinding data, string? value) => {(data as DpopPayload).HTM = value;}, (IBinding data) => (data as DpopPayload).HTM )},
			{ "htu", new PropertyString ("htu", 
					(IBinding data, string? value) => {(data as DpopPayload).HTU = value;}, (IBinding data) => (data as DpopPayload).HTU )},
			{ "iat", new PropertyString ("iat", 
					(IBinding data, string? value) => {(data as DpopPayload).IAT = value;}, (IBinding data) => (data as DpopPayload).IAT )},
			{ "ath", new PropertyString ("ath", 
					(IBinding data, string? value) => {(data as DpopPayload).ATH = value;}, (IBinding data) => (data as DpopPayload).ATH )},
			{ "nonce", new PropertyString ("nonce", 
					(IBinding data, string? value) => {(data as DpopPayload).Nonce = value;}, (IBinding data) => (data as DpopPayload).Nonce )},
			{ "cnf", new PropertyStruct ("cnf", 
					(IBinding data, object? value) => {(data as DpopPayload).Confirm = value as DpopConfirmation?;}, (IBinding data) => (data as DpopPayload).Confirm,
					false, ()=>new  DpopConfirmation?(), ()=>new DpopConfirmation())} 
        }, __Tag,() => new DpopPayload(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "DpopPayload";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DpopPayload();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DpopPayload FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DpopPayload;
			}
		var Result = new DpopPayload ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class DpopConfirmation : Oauth {
        /// <summary>
        ///JWK SHA-256 Thumbprint confirmation method. The value of the jkt member 
        ///MUST be the base64url encoding (as defined in [RFC7515]) of the JWK SHA-256 
        ///Thumbprint (according to [RFC7638]) of the DPoP public key (in JWK format) 
        ///to which the access token is bound.
        /// </summary>

	public virtual string?						JKT  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "jkt", new PropertyString ("jkt", 
					(IBinding data, string? value) => {(data as DpopConfirmation).JKT = value;}, (IBinding data) => (data as DpopConfirmation).JKT )}
        }, __Tag,() => new DpopConfirmation(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "DpopConfirmation";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new DpopConfirmation();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new DpopConfirmation FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as DpopConfirmation;
			}
		var Result = new DpopConfirmation ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}

	/// <summary>
	/// </summary>
public partial class JwtDpop : Oauth {
        /// <summary>
        /// </summary>

	public virtual JwtHeader?						Header  {get; set;}

        /// <summary>
        /// </summary>

	public virtual DpopPayload?						Payload  {get; set;}

        /// <summary>
        /// </summary>

	public virtual byte[]?						Signature  {get; set;}



    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	static protected new Binding _binding = new (
			new() {

			{ "header", new PropertyStruct ("header", 
					(IBinding data, object? value) => {(data as JwtDpop).Header = value as JwtHeader?;}, (IBinding data) => (data as JwtDpop).Header,
					false, ()=>new  JwtHeader?(), ()=>new JwtHeader())} ,
			{ "payload", new PropertyStruct ("payload", 
					(IBinding data, object? value) => {(data as JwtDpop).Payload = value as DpopPayload?;}, (IBinding data) => (data as JwtDpop).Payload,
					false, ()=>new  DpopPayload?(), ()=>new DpopPayload())} ,
			{ "signature", new PropertyBinary ("signature", 
					(IBinding data, byte[]? value) => {(data as JwtDpop).Signature = value;}, (IBinding data) => (data as JwtDpop).Signature )}
        }, __Tag,() => new JwtDpop(), null);

    ///<summary>Dictionary describing the serializable properties.</summary> 
    public readonly static new Dictionary<string, Property> _StaticProperties = _binding.Properties;

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
	public new const string __Tag = "JwtDpop";

	/// <summary>
    /// Factory method
    /// </summary>
    /// <returns>Object of this type</returns>
	public static new JsonObject _Factory () => new JwtDpop();


    /// <summary>
    /// Deserialize a tagged stream
    /// </summary>
    /// <param name="jsonReader">The input stream</param>
	/// <param name="tagged">If true, the input is wrapped in a tag specifying the type</param>
    /// <returns>The created object.</returns>		
    public static new JwtDpop FromJson (JsonReader jsonReader, bool tagged=true) {
		if (jsonReader == null) {
			return null;
			}
		if (tagged) {
			var Out = jsonReader.ReadTaggedObject (_TagDictionary);
			return Out as JwtDpop;
			}
		var Result = new JwtDpop ();
		Result.Deserialize (jsonReader);
		Result.PostDecode();
		return Result;
		}


	}



