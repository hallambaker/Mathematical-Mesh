
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
//  This file was automatically generated at 6/7/2025 7:22:25 PM
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
using System.Text.Json;
using System.Text.Json.Serialization;
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
    /// Dictionary mapping types to bindings
    /// </summary>
	public static Dictionary<System.Type, Binding> _BindingDictionary=> _bindingDictionary;
	static Dictionary<System.Type, Binding> _bindingDictionary = 
			new () {

	    {typeof(ResourceServerMetadata), ResourceServerMetadata._binding},
	    {typeof(AuthorizationServerMetadata), AuthorizationServerMetadata._binding},
	    {typeof(AuthorizationRequest), AuthorizationRequest._binding},
	    {typeof(AuthorizationRequest2), AuthorizationRequest2._binding},
	    {typeof(PushedAuthorizationResponse), PushedAuthorizationResponse._binding},
	    {typeof(AuthorizationResponse), AuthorizationResponse._binding},
	    {typeof(ErrorResponse), ErrorResponse._binding},
	    {typeof(ClientMetadata), ClientMetadata._binding},
	    {typeof(DidDocument), DidDocument._binding},
	    {typeof(AuthorizationCodeGrant), AuthorizationCodeGrant._binding},
	    {typeof(ClientCredentialsGrant), ClientCredentialsGrant._binding},
	    {typeof(RefreshTokenGrant), RefreshTokenGrant._binding},
	    {typeof(DidVerificationMethod), DidVerificationMethod._binding},
	    {typeof(DidService), DidService._binding},
	    {typeof(AuthenticationResponse), AuthenticationResponse._binding},
	    {typeof(DpopPayload), DpopPayload._binding},
	    {typeof(DpopConfirmation), DpopConfirmation._binding},
	    {typeof(JwtDpop), JwtDpop._binding}
		};

	///<summary>Variable used to force static initialization</summary> 
	public static bool _Initialized => true;

	static Oauth() {
		_Initialize();
		}

    internal static void _Initialize() {
		AddDictionary(ref _bindingDictionary);
		}

	}



// Service Dispatch Classes



	// Transaction Classes

	/// <summary>
	/// </summary>
public partial class ResourceServerMetadata : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("resource")]
	public virtual string?					Resource  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("authorization_servers")]
	public virtual List<string>?					AuthorizationServers  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("scopes_supported")]
	public virtual List<string>?					ScopesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("bearer_methods_supported")]
	public virtual List<string>?					BearerMethodsSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("resource_documentation")]
	public virtual string?					ResourceDocumentation  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("resource", 
					(IBinding data, string? value) => {(data as ResourceServerMetadata).Resource = value;}, 
					(IBinding data) => (data as ResourceServerMetadata).Resource ),
		new PropertyListString ("authorization_servers", 
					(IBinding data, List<string>? value) => {(data as ResourceServerMetadata).AuthorizationServers = value;}, 
					(IBinding data) => (data as ResourceServerMetadata).AuthorizationServers ),
		new PropertyListString ("scopes_supported", 
					(IBinding data, List<string>? value) => {(data as ResourceServerMetadata).ScopesSupported = value;}, 
					(IBinding data) => (data as ResourceServerMetadata).ScopesSupported ),
		new PropertyListString ("bearer_methods_supported", 
					(IBinding data, List<string>? value) => {(data as ResourceServerMetadata).BearerMethodsSupported = value;}, 
					(IBinding data) => (data as ResourceServerMetadata).BearerMethodsSupported ),
		new PropertyString ("resource_documentation", 
					(IBinding data, string? value) => {(data as ResourceServerMetadata).ResourceDocumentation = value;}, 
					(IBinding data) => (data as ResourceServerMetadata).ResourceDocumentation )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ResourceServerMetadata> _binding = new (
			new() {
			{ "resource", _properties [0]},
			{ "authorization_servers", _properties [1]},
			{ "scopes_supported", _properties [2]},
			{ "bearer_methods_supported", _properties [3]},
			{ "resource_documentation", _properties [4]}}, __Tag,
		() => new ResourceServerMetadata(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// AuthorizationServerMetadata2
	/// </summary>
public partial class AuthorizationServerMetadata : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("issuer")]
	public virtual string?					Issuer  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("scopes_supported")]
	public virtual List<string>?					ScopesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("subject_types_supported")]
	public virtual List<string>?					SubjectTypesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("response_types_supported")]
	public virtual List<string>?					ResponseTypesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("response_modes_supported")]
	public virtual List<string>?					ResponseModesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("grant_types_supported")]
	public virtual List<string>?					GrantTypesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("code_challenge_methods_supported")]
	public virtual List<string>?					CodeChallengeMethodsSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("ui_locales_supported")]
	public virtual List<string>?					UiLocalesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("display_values_supported")]
	public virtual List<string>?					DisplayValuesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("authorization_response_iss_parameter_supported")]
	public virtual bool?					AuthorizationResponseIssParameterSupported  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("request_object_signing_alg_values_supported")]
	public virtual List<string>?					RequestObjectSigningAlgValuesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("request_object_encryption_alg_values_supported")]
	public virtual List<string>?					RequestObjectEncryptionAlgValuesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("request_object_encryption_enc_values_supported")]
	public virtual List<string>?					RequestObjectEncryptionEncValuesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("request_parameter_supported")]
	public virtual bool?					RequestParameterSupported  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("request_uri_parameter_supported")]
	public virtual bool?					RequestUriParameterSupported  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("require_request_uri_registration")]
	public virtual bool?					RequireRequestUriRegistration  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("jwks_uri")]
	public virtual string?					JwksUri  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("authorization_endpoint")]
	public virtual string?					AuthorizationEndpoint  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("token_endpoint")]
	public virtual string?					TokenEndpoint  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("token_endpoint_auth_methods_supported")]
	public virtual List<string>?					TokenEndpointAuthMethodsSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("token_endpoint_auth_signing_alg_values_supported")]
	public virtual List<string>?					TokenEndpointAuthSigningAlgValuesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("revocation_endpoint")]
	public virtual string?					RevocationEndpoint  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("introspection_endpoint")]
	public virtual string?					IntrospectionEndpoint  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("pushed_authorization_request_endpoint")]
	public virtual string?					PushedAuthorizationRequestEndpoint  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("require_pushed_authorization_requests")]
	public virtual bool?					RequirePushedAuthorizationRequests  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("dpop_signing_alg_values_supported")]
	public virtual List<string>?					DpopSigningAlgValuesSupported  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("client_id_metadata_document_supported")]
	public virtual bool?					ClientIdMetadataDocumentSupported  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("issuer", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).Issuer = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).Issuer ),
		new PropertyListString ("scopes_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).ScopesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).ScopesSupported ),
		new PropertyListString ("subject_types_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).SubjectTypesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).SubjectTypesSupported ),
		new PropertyListString ("response_types_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).ResponseTypesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).ResponseTypesSupported ),
		new PropertyListString ("response_modes_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).ResponseModesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).ResponseModesSupported ),
		new PropertyListString ("grant_types_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).GrantTypesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).GrantTypesSupported ),
		new PropertyListString ("code_challenge_methods_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).CodeChallengeMethodsSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).CodeChallengeMethodsSupported ),
		new PropertyListString ("ui_locales_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).UiLocalesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).UiLocalesSupported ),
		new PropertyListString ("display_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).DisplayValuesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).DisplayValuesSupported ),
		new PropertyBoolean ("authorization_response_iss_parameter_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).AuthorizationResponseIssParameterSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).AuthorizationResponseIssParameterSupported ),
		new PropertyListString ("request_object_signing_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).RequestObjectSigningAlgValuesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RequestObjectSigningAlgValuesSupported ),
		new PropertyListString ("request_object_encryption_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).RequestObjectEncryptionAlgValuesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RequestObjectEncryptionAlgValuesSupported ),
		new PropertyListString ("request_object_encryption_enc_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).RequestObjectEncryptionEncValuesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RequestObjectEncryptionEncValuesSupported ),
		new PropertyBoolean ("request_parameter_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequestParameterSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RequestParameterSupported ),
		new PropertyBoolean ("request_uri_parameter_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequestUriParameterSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RequestUriParameterSupported ),
		new PropertyBoolean ("require_request_uri_registration", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequireRequestUriRegistration = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RequireRequestUriRegistration ),
		new PropertyString ("jwks_uri", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).JwksUri = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).JwksUri ),
		new PropertyString ("authorization_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).AuthorizationEndpoint = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).AuthorizationEndpoint ),
		new PropertyString ("token_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).TokenEndpoint = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).TokenEndpoint ),
		new PropertyListString ("token_endpoint_auth_methods_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).TokenEndpointAuthMethodsSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).TokenEndpointAuthMethodsSupported ),
		new PropertyListString ("token_endpoint_auth_signing_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).TokenEndpointAuthSigningAlgValuesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).TokenEndpointAuthSigningAlgValuesSupported ),
		new PropertyString ("revocation_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).RevocationEndpoint = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RevocationEndpoint ),
		new PropertyString ("introspection_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).IntrospectionEndpoint = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).IntrospectionEndpoint ),
		new PropertyString ("pushed_authorization_request_endpoint", 
					(IBinding data, string? value) => {(data as AuthorizationServerMetadata).PushedAuthorizationRequestEndpoint = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).PushedAuthorizationRequestEndpoint ),
		new PropertyBoolean ("require_pushed_authorization_requests", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).RequirePushedAuthorizationRequests = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).RequirePushedAuthorizationRequests ),
		new PropertyListString ("dpop_signing_alg_values_supported", 
					(IBinding data, List<string>? value) => {(data as AuthorizationServerMetadata).DpopSigningAlgValuesSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).DpopSigningAlgValuesSupported ),
		new PropertyBoolean ("client_id_metadata_document_supported", 
					(IBinding data, bool? value) => {(data as AuthorizationServerMetadata).ClientIdMetadataDocumentSupported = value;}, 
					(IBinding data) => (data as AuthorizationServerMetadata).ClientIdMetadataDocumentSupported )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AuthorizationServerMetadata> _binding = new (
			new() {
			{ "issuer", _properties [0]},
			{ "scopes_supported", _properties [1]},
			{ "subject_types_supported", _properties [2]},
			{ "response_types_supported", _properties [3]},
			{ "response_modes_supported", _properties [4]},
			{ "grant_types_supported", _properties [5]},
			{ "code_challenge_methods_supported", _properties [6]},
			{ "ui_locales_supported", _properties [7]},
			{ "display_values_supported", _properties [8]},
			{ "authorization_response_iss_parameter_supported", _properties [9]},
			{ "request_object_signing_alg_values_supported", _properties [10]},
			{ "request_object_encryption_alg_values_supported", _properties [11]},
			{ "request_object_encryption_enc_values_supported", _properties [12]},
			{ "request_parameter_supported", _properties [13]},
			{ "request_uri_parameter_supported", _properties [14]},
			{ "require_request_uri_registration", _properties [15]},
			{ "jwks_uri", _properties [16]},
			{ "authorization_endpoint", _properties [17]},
			{ "token_endpoint", _properties [18]},
			{ "token_endpoint_auth_methods_supported", _properties [19]},
			{ "token_endpoint_auth_signing_alg_values_supported", _properties [20]},
			{ "revocation_endpoint", _properties [21]},
			{ "introspection_endpoint", _properties [22]},
			{ "pushed_authorization_request_endpoint", _properties [23]},
			{ "require_pushed_authorization_requests", _properties [24]},
			{ "dpop_signing_alg_values_supported", _properties [25]},
			{ "client_id_metadata_document_supported", _properties [26]}}, __Tag,
		() => new AuthorizationServerMetadata(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	///
	/// Authorization Request
	/// </summary>
public partial class AuthorizationRequest : Oauth {
    /// <summary>
    ///Identifies the client software
    /// </summary>

	[JsonPropertyName("client_id")]
	public virtual string?					ClientId  {get; set;} //

    /// <summary>
    /// must be code
    /// </summary>

	[JsonPropertyName("response_type")]
	public virtual string?					ResponseType  {get; set;} //

    /// <summary>
    /// the PKCE challenge value. 
    /// </summary>

	[JsonPropertyName("code_challenge")]
	public virtual string?					CodeChallenge  {get; set;} //

    /// <summary>
    ///which code challenge method is used, for example S256
    /// </summary>

	[JsonPropertyName("code_challenge_method")]
	public virtual string?					CodeChallengeMethod  {get; set;} //

    /// <summary>
    ///random token used to verify the authorization request against the response
    /// </summary>

	[JsonPropertyName("state")]
	public virtual string?					State  {get; set;} //

    /// <summary>
    ///Must match against URIs declared in client metadata and have a format consistent 
    ///with the application_type declared in the client metadata
    /// </summary>

	[JsonPropertyName("redirect_uri")]
	public virtual string?					RedirectUri  {get; set;} //

    /// <summary>
    ///Must be a subset of the scopes declared in client metadata. Must include atproto
    /// </summary>

	[JsonPropertyName("scope")]
	public virtual string?					Scope  {get; set;} //

    /// <summary>
    ///Used by confidential clients to describe the client authentication mechanism
    /// </summary>

	[JsonPropertyName("client_assertion_type")]
	public virtual string?					ClientAssertionType  {get; set;} //

    /// <summary>
    ///Only used for confidential clients
    /// </summary>

	[JsonPropertyName("client_assertion")]
	public virtual string?					ClientAssertion  {get; set;} //

    /// <summary>
    ///Account identifier to be used for login
    /// </summary>

	[JsonPropertyName("login_hint")]
	public virtual string?					LoginHint  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ClientId = value;}, 
					(IBinding data) => (data as AuthorizationRequest).ClientId ),
		new PropertyString ("response_type", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ResponseType = value;}, 
					(IBinding data) => (data as AuthorizationRequest).ResponseType ),
		new PropertyString ("code_challenge", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).CodeChallenge = value;}, 
					(IBinding data) => (data as AuthorizationRequest).CodeChallenge ),
		new PropertyString ("code_challenge_method", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).CodeChallengeMethod = value;}, 
					(IBinding data) => (data as AuthorizationRequest).CodeChallengeMethod ),
		new PropertyString ("state", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).State = value;}, 
					(IBinding data) => (data as AuthorizationRequest).State ),
		new PropertyString ("redirect_uri", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).RedirectUri = value;}, 
					(IBinding data) => (data as AuthorizationRequest).RedirectUri ),
		new PropertyString ("scope", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).Scope = value;}, 
					(IBinding data) => (data as AuthorizationRequest).Scope ),
		new PropertyString ("client_assertion_type", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ClientAssertionType = value;}, 
					(IBinding data) => (data as AuthorizationRequest).ClientAssertionType ),
		new PropertyString ("client_assertion", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).ClientAssertion = value;}, 
					(IBinding data) => (data as AuthorizationRequest).ClientAssertion ),
		new PropertyString ("login_hint", 
					(IBinding data, string? value) => {(data as AuthorizationRequest).LoginHint = value;}, 
					(IBinding data) => (data as AuthorizationRequest).LoginHint )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AuthorizationRequest> _binding = new (
			new() {
			{ "client_id", _properties [0]},
			{ "response_type", _properties [1]},
			{ "code_challenge", _properties [2]},
			{ "code_challenge_method", _properties [3]},
			{ "state", _properties [4]},
			{ "redirect_uri", _properties [5]},
			{ "scope", _properties [6]},
			{ "client_assertion_type", _properties [7]},
			{ "client_assertion", _properties [8]},
			{ "login_hint", _properties [9]}}, __Tag,
		() => new AuthorizationRequest(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class AuthorizationRequest2 : Oauth {
    /// <summary>
    ///Identifies the client software
    /// </summary>

	[JsonPropertyName("client_id")]
	public virtual string?					ClientId  {get; set;} //

    /// <summary>
    ///The RequestUri returned by the server
    /// </summary>

	[JsonPropertyName("request_uri")]
	public virtual string?					RequestUri  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as AuthorizationRequest2).ClientId = value;}, 
					(IBinding data) => (data as AuthorizationRequest2).ClientId ),
		new PropertyString ("request_uri", 
					(IBinding data, string? value) => {(data as AuthorizationRequest2).RequestUri = value;}, 
					(IBinding data) => (data as AuthorizationRequest2).RequestUri )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AuthorizationRequest2> _binding = new (
			new() {
			{ "client_id", _properties [0]},
			{ "request_uri", _properties [1]}}, __Tag,
		() => new AuthorizationRequest2(), () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("expires_in")]
	public virtual int?					ExpiresIn  {get; set;} //

    /// <summary>
    ///REQUIRED The request URI corresponding to the authorization request posted. 
    ///This URI is a single-use reference to the respective request data in the 
    ///subsequent authorization request. The way the authorization process obtains 
    ///the authorization request data is at the discretion of the authorization 
    ///server and is out of scope of this specification. There is no need to make 
    ///the authorization request data available to other parties via this URI.
    /// </summary>

	[JsonPropertyName("request_uri")]
	public virtual string?					RequestUri  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyInteger32 ("expires_in", 
					(IBinding data, int? value) => {(data as PushedAuthorizationResponse).ExpiresIn = value;}, 
					(IBinding data) => (data as PushedAuthorizationResponse).ExpiresIn ),
		new PropertyString ("request_uri", 
					(IBinding data, string? value) => {(data as PushedAuthorizationResponse).RequestUri = value;}, 
					(IBinding data) => (data as PushedAuthorizationResponse).RequestUri )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<PushedAuthorizationResponse> _binding = new (
			new() {
			{ "expires_in", _properties [0]},
			{ "request_uri", _properties [1]}}, __Tag,
		() => new PushedAuthorizationResponse(), () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("code")]
	public virtual string?					Code  {get; set;} //

    /// <summary>
    ///REQUIRED if the state parameter was present in the client authorization request.
    ///The exact value received from the client.
    /// </summary>

	[JsonPropertyName("state")]
	public virtual string?					State  {get; set;} //

    /// <summary>
    ///The identifier of the authorization server which the client can use to prevent
    ///mix-up attacks, if the client interacts with more than one authorization server.
    /// </summary>

	[JsonPropertyName("iss")]
	public virtual string?					Iss  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("code", 
					(IBinding data, string? value) => {(data as AuthorizationResponse).Code = value;}, 
					(IBinding data) => (data as AuthorizationResponse).Code ),
		new PropertyString ("state", 
					(IBinding data, string? value) => {(data as AuthorizationResponse).State = value;}, 
					(IBinding data) => (data as AuthorizationResponse).State ),
		new PropertyString ("iss", 
					(IBinding data, string? value) => {(data as AuthorizationResponse).Iss = value;}, 
					(IBinding data) => (data as AuthorizationResponse).Iss )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AuthorizationResponse> _binding = new (
			new() {
			{ "code", _properties [0]},
			{ "state", _properties [1]},
			{ "iss", _properties [2]}}, __Tag,
		() => new AuthorizationResponse(), () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("error")]
	public virtual string?					Error  {get; set;} //

    /// <summary>
    /// Human-readable ASCII [USASCII] text providing additional information, used to 
    ///assist the client developer in understanding the error that occurred. Values for
    ///the error_description parameter MUST NOT include characters outside the set 
    ///%x20-21 / %x23-5B / %x5D-7E.
    /// </summary>

	[JsonPropertyName("errorDescription")]
	public virtual string?					ErrorDescription  {get; set;} //

    /// <summary>
    ///A URI identifying a human-readable web page with information about the error, 
    ///used to provide the client developer with additional information about the error. 
    ///Values for the error_uri parameter MUST conform to the URI-reference syntax and 
    ///thus MUST NOT include characters outside the set %x21 / %x23-5B / %x5D-7E
    /// </summary>

	[JsonPropertyName("errorUri")]
	public virtual string?					ErrorUri  {get; set;} //

    /// <summary>
    ///REQUIRED if a state parameter was present in the client authorization request. 
    ///The exact value received from the client
    /// </summary>

	[JsonPropertyName("state")]
	public virtual string?					State  {get; set;} //

    /// <summary>
    ///The identifier of the authorization server which the client can use to prevent
    ///mix-up attacks, if the client interacts with more than one authorization server.
    /// </summary>

	[JsonPropertyName("iss")]
	public virtual string?					Iss  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("error", 
					(IBinding data, string? value) => {(data as ErrorResponse).Error = value;}, 
					(IBinding data) => (data as ErrorResponse).Error ),
		new PropertyString ("errorDescription", 
					(IBinding data, string? value) => {(data as ErrorResponse).ErrorDescription = value;}, 
					(IBinding data) => (data as ErrorResponse).ErrorDescription ),
		new PropertyString ("errorUri", 
					(IBinding data, string? value) => {(data as ErrorResponse).ErrorUri = value;}, 
					(IBinding data) => (data as ErrorResponse).ErrorUri ),
		new PropertyString ("state", 
					(IBinding data, string? value) => {(data as ErrorResponse).State = value;}, 
					(IBinding data) => (data as ErrorResponse).State ),
		new PropertyString ("iss", 
					(IBinding data, string? value) => {(data as ErrorResponse).Iss = value;}, 
					(IBinding data) => (data as ErrorResponse).Iss )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ErrorResponse> _binding = new (
			new() {
			{ "error", _properties [0]},
			{ "errorDescription", _properties [1]},
			{ "errorUri", _properties [2]},
			{ "state", _properties [3]},
			{ "iss", _properties [4]}}, __Tag,
		() => new ErrorResponse(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ClientMetadata : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("client_id")]
	public virtual string?					ClientId  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("application_type")]
	public virtual string?					ApplicationType  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("grant_types")]
	public virtual List<string>?					GrantTypes  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("scope")]
	public virtual string?					Scope  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("response_types")]
	public virtual List<string>?					ResponseTypes  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("redirect_uris")]
	public virtual List<string>?					RedirectUris  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("dpop_bound_access_tokens")]
	public virtual bool?					DpopBoundAccessTokens  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("token_endpoint_auth_method")]
	public virtual string?					TokenEndpointAuthMethod  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("token_endpoint_auth_signing_alg")]
	public virtual string?					TokenEndpointAuthSigningAlg  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("jwks")]
	public virtual JWKS?					Jwks  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("client_name")]
	public virtual string?					ClientName  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("client_uri")]
	public virtual string?					ClientUri  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("logo_uri")]
	public virtual string?					LogoUri  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("tos_uri")]
	public virtual string?					TosUri  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("policy_uri")]
	public virtual string?					PolicyUri  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as ClientMetadata).ClientId = value;}, 
					(IBinding data) => (data as ClientMetadata).ClientId ),
		new PropertyString ("application_type", 
					(IBinding data, string? value) => {(data as ClientMetadata).ApplicationType = value;}, 
					(IBinding data) => (data as ClientMetadata).ApplicationType ),
		new PropertyListString ("grant_types", 
					(IBinding data, List<string>? value) => {(data as ClientMetadata).GrantTypes = value;}, 
					(IBinding data) => (data as ClientMetadata).GrantTypes ),
		new PropertyString ("scope", 
					(IBinding data, string? value) => {(data as ClientMetadata).Scope = value;}, 
					(IBinding data) => (data as ClientMetadata).Scope ),
		new PropertyListString ("response_types", 
					(IBinding data, List<string>? value) => {(data as ClientMetadata).ResponseTypes = value;}, 
					(IBinding data) => (data as ClientMetadata).ResponseTypes ),
		new PropertyListString ("redirect_uris", 
					(IBinding data, List<string>? value) => {(data as ClientMetadata).RedirectUris = value;}, 
					(IBinding data) => (data as ClientMetadata).RedirectUris ),
		new PropertyBoolean ("dpop_bound_access_tokens", 
					(IBinding data, bool? value) => {(data as ClientMetadata).DpopBoundAccessTokens = value;}, 
					(IBinding data) => (data as ClientMetadata).DpopBoundAccessTokens ),
		new PropertyString ("token_endpoint_auth_method", 
					(IBinding data, string? value) => {(data as ClientMetadata).TokenEndpointAuthMethod = value;}, 
					(IBinding data) => (data as ClientMetadata).TokenEndpointAuthMethod ),
		new PropertyString ("token_endpoint_auth_signing_alg", 
					(IBinding data, string? value) => {(data as ClientMetadata).TokenEndpointAuthSigningAlg = value;}, 
					(IBinding data) => (data as ClientMetadata).TokenEndpointAuthSigningAlg ),
		new PropertyStruct ("jwks", typeof (JWKS),
					(IBinding data, object? value) => {(data as ClientMetadata).Jwks = value as JWKS;}, 
					(IBinding data) => (data as ClientMetadata).Jwks,
					false, ()=>new  JWKS(), ()=>new JWKS()),
		new PropertyString ("client_name", 
					(IBinding data, string? value) => {(data as ClientMetadata).ClientName = value;}, 
					(IBinding data) => (data as ClientMetadata).ClientName ),
		new PropertyString ("client_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).ClientUri = value;}, 
					(IBinding data) => (data as ClientMetadata).ClientUri ),
		new PropertyString ("logo_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).LogoUri = value;}, 
					(IBinding data) => (data as ClientMetadata).LogoUri ),
		new PropertyString ("tos_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).TosUri = value;}, 
					(IBinding data) => (data as ClientMetadata).TosUri ),
		new PropertyString ("policy_uri", 
					(IBinding data, string? value) => {(data as ClientMetadata).PolicyUri = value;}, 
					(IBinding data) => (data as ClientMetadata).PolicyUri )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ClientMetadata> _binding = new (
			new() {
			{ "client_id", _properties [0]},
			{ "application_type", _properties [1]},
			{ "grant_types", _properties [2]},
			{ "scope", _properties [3]},
			{ "response_types", _properties [4]},
			{ "redirect_uris", _properties [5]},
			{ "dpop_bound_access_tokens", _properties [6]},
			{ "token_endpoint_auth_method", _properties [7]},
			{ "token_endpoint_auth_signing_alg", _properties [8]},
			{ "jwks", _properties [9]},
			{ "client_name", _properties [10]},
			{ "client_uri", _properties [11]},
			{ "logo_uri", _properties [12]},
			{ "tos_uri", _properties [13]},
			{ "policy_uri", _properties [14]}}, __Tag,
		() => new ClientMetadata(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class DidDocument : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("@context")]
	public virtual List<string>?					Contexts  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("alsoKnownAs")]
	public virtual List<string>?					AlsoKnownAs  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("verificationMethod")]
	public virtual List<DidVerificationMethod>?					VerificationMethod  {get; set;}
    /// <summary>
    /// </summary>

	[JsonPropertyName("service")]
	public virtual List<DidService>?					Service  {get; set;}

    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyListString ("@context", 
					(IBinding data, List<string>? value) => {(data as DidDocument).Contexts = value;}, 
					(IBinding data) => (data as DidDocument).Contexts ),
		new PropertyString ("id", 
					(IBinding data, string? value) => {(data as DidDocument).Id = value;}, 
					(IBinding data) => (data as DidDocument).Id ),
		new PropertyListString ("alsoKnownAs", 
					(IBinding data, List<string>? value) => {(data as DidDocument).AlsoKnownAs = value;}, 
					(IBinding data) => (data as DidDocument).AlsoKnownAs ),
		new PropertyListStruct ("verificationMethod", typeof (DidVerificationMethod),
					(IBinding data, object? value) => {(data as DidDocument).VerificationMethod = value as List<DidVerificationMethod>;}, 
					(IBinding data) => (data as DidDocument).VerificationMethod,
					false, ()=>new  List<DidVerificationMethod>(), ()=>new DidVerificationMethod()),
		new PropertyListStruct ("service", typeof (DidService),
					(IBinding data, object? value) => {(data as DidDocument).Service = value as List<DidService>;}, 
					(IBinding data) => (data as DidDocument).Service,
					false, ()=>new  List<DidService>(), ()=>new DidService())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DidDocument> _binding = new (
			new() {
			{ "@context", _properties [0]},
			{ "id", _properties [1]},
			{ "alsoKnownAs", _properties [2]},
			{ "verificationMethod", _properties [3]},
			{ "service", _properties [4]}}, __Tag,
		() => new DidDocument(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class AuthorizationCodeGrant : Oauth {
    /// <summary>
    ///"authorization_code"
    /// </summary>

	[JsonPropertyName("grant_type")]
	public virtual string?					GrantType  {get; set;} //

    /// <summary>
    ///The authorization code received from the authorization server.
    /// </summary>

	[JsonPropertyName("code")]
	public virtual string?					Code  {get; set;} //

    /// <summary>
    ///REQUIRED, if the code_challenge parameter was included in the 
    ///authorization request. MUST NOT be used otherwise. The original code 
    ///verifier string.
    /// </summary>

	[JsonPropertyName("code_verifier")]
	public virtual string?					CodeVerifier  {get; set;} //

    /// <summary>
    ///Identifies the client software
    /// </summary>

	[JsonPropertyName("client_id")]
	public virtual string?					ClientId  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("grant_type", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).GrantType = value;}, 
					(IBinding data) => (data as AuthorizationCodeGrant).GrantType ),
		new PropertyString ("code", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).Code = value;}, 
					(IBinding data) => (data as AuthorizationCodeGrant).Code ),
		new PropertyString ("code_verifier", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).CodeVerifier = value;}, 
					(IBinding data) => (data as AuthorizationCodeGrant).CodeVerifier ),
		new PropertyString ("client_id", 
					(IBinding data, string? value) => {(data as AuthorizationCodeGrant).ClientId = value;}, 
					(IBinding data) => (data as AuthorizationCodeGrant).ClientId )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AuthorizationCodeGrant> _binding = new (
			new() {
			{ "grant_type", _properties [0]},
			{ "code", _properties [1]},
			{ "code_verifier", _properties [2]},
			{ "client_id", _properties [3]}}, __Tag,
		() => new AuthorizationCodeGrant(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class ClientCredentialsGrant : Oauth {
    /// <summary>
    ///REQUIRED. "client_credentials"
    /// </summary>

	[JsonPropertyName("grant_type")]
	public virtual string?					GrantType  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("grant_type", 
					(IBinding data, string? value) => {(data as ClientCredentialsGrant).GrantType = value;}, 
					(IBinding data) => (data as ClientCredentialsGrant).GrantType )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<ClientCredentialsGrant> _binding = new (
			new() {
			{ "grant_type", _properties [0]}}, __Tag,
		() => new ClientCredentialsGrant(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class RefreshTokenGrant : Oauth {
    /// <summary>
    ///REQUIRED. "refresh_token"
    /// </summary>

	[JsonPropertyName("grant_type")]
	public virtual string?					GrantType  {get; set;} //

    /// <summary>
    ///REQUIRED. "client_credentials"
    /// </summary>

	[JsonPropertyName("refresh_token")]
	public virtual string?					refresh_token  {get; set;} //

    /// <summary>
    ///Must be a subset of the scopes declared in client metadata. Must include atproto
    /// </summary>

	[JsonPropertyName("scope")]
	public virtual string?					Scope  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("grant_type", 
					(IBinding data, string? value) => {(data as RefreshTokenGrant).GrantType = value;}, 
					(IBinding data) => (data as RefreshTokenGrant).GrantType ),
		new PropertyString ("refresh_token", 
					(IBinding data, string? value) => {(data as RefreshTokenGrant).refresh_token = value;}, 
					(IBinding data) => (data as RefreshTokenGrant).refresh_token ),
		new PropertyString ("scope", 
					(IBinding data, string? value) => {(data as RefreshTokenGrant).Scope = value;}, 
					(IBinding data) => (data as RefreshTokenGrant).Scope )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<RefreshTokenGrant> _binding = new (
			new() {
			{ "grant_type", _properties [0]},
			{ "refresh_token", _properties [1]},
			{ "scope", _properties [2]}}, __Tag,
		() => new RefreshTokenGrant(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class DidVerificationMethod : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("controller")]
	public virtual string?					Controller  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("publicKeyMultibase")]
	public virtual string?					PublicKeyMultibase  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("id", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).Id = value;}, 
					(IBinding data) => (data as DidVerificationMethod).Id ),
		new PropertyString ("type", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).Type = value;}, 
					(IBinding data) => (data as DidVerificationMethod).Type ),
		new PropertyString ("controller", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).Controller = value;}, 
					(IBinding data) => (data as DidVerificationMethod).Controller ),
		new PropertyString ("publicKeyMultibase", 
					(IBinding data, string? value) => {(data as DidVerificationMethod).PublicKeyMultibase = value;}, 
					(IBinding data) => (data as DidVerificationMethod).PublicKeyMultibase )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DidVerificationMethod> _binding = new (
			new() {
			{ "id", _properties [0]},
			{ "type", _properties [1]},
			{ "controller", _properties [2]},
			{ "publicKeyMultibase", _properties [3]}}, __Tag,
		() => new DidVerificationMethod(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class DidService : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("id")]
	public virtual string?					Id  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("type")]
	public virtual string?					Type  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("serviceEndpoint")]
	public virtual string?					ServiceEndpoint  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("id", 
					(IBinding data, string? value) => {(data as DidService).Id = value;}, 
					(IBinding data) => (data as DidService).Id ),
		new PropertyString ("type", 
					(IBinding data, string? value) => {(data as DidService).Type = value;}, 
					(IBinding data) => (data as DidService).Type ),
		new PropertyString ("serviceEndpoint", 
					(IBinding data, string? value) => {(data as DidService).ServiceEndpoint = value;}, 
					(IBinding data) => (data as DidService).ServiceEndpoint )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DidService> _binding = new (
			new() {
			{ "id", _properties [0]},
			{ "type", _properties [1]},
			{ "serviceEndpoint", _properties [2]}}, __Tag,
		() => new DidService(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class AuthenticationResponse : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("iss")]
	public virtual string?					Iss  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("state")]
	public virtual string?					State  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("code")]
	public virtual string?					Code  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("iss", 
					(IBinding data, string? value) => {(data as AuthenticationResponse).Iss = value;}, 
					(IBinding data) => (data as AuthenticationResponse).Iss ),
		new PropertyString ("state", 
					(IBinding data, string? value) => {(data as AuthenticationResponse).State = value;}, 
					(IBinding data) => (data as AuthenticationResponse).State ),
		new PropertyString ("code", 
					(IBinding data, string? value) => {(data as AuthenticationResponse).Code = value;}, 
					(IBinding data) => (data as AuthenticationResponse).Code )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<AuthenticationResponse> _binding = new (
			new() {
			{ "iss", _properties [0]},
			{ "state", _properties [1]},
			{ "code", _properties [2]}}, __Tag,
		() => new AuthenticationResponse(), () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("jti")]
	public virtual string?					JTI  {get; set;} //

    /// <summary>
    ///The value of the HTTP method (Section 9.1 of [RFC9110]) of the request to
    ///which the JWT is attached.
    /// </summary>

	[JsonPropertyName("htm")]
	public virtual string?					HTM  {get; set;} //

    /// <summary>
    ///The HTTP target URI (Section 7.1 of [RFC9110]) of the request to which 
    ///the JWT is attached, without query and fragment parts.
    /// </summary>

	[JsonPropertyName("htu")]
	public virtual string?					HTU  {get; set;} //

    /// <summary>
    ///Creation timestamp of the JWT (Section 4.1.6 of [RFC7519])
    /// </summary>

	[JsonPropertyName("iat")]
	public virtual string?					IAT  {get; set;} //

    /// <summary>
    ///Hash of the access token. The value MUST be the result of a base64url encoding 
    ///(as defined in Section 2 of [RFC7515]) the SHA-256 [SHS] hash of the ASCII 
    ///encoding of the associated access token's value.
    /// </summary>

	[JsonPropertyName("ath")]
	public virtual string?					ATH  {get; set;} //

    /// <summary>
    ///A recent nonce provided via the DPoP-Nonce HTTP header.
    /// </summary>

	[JsonPropertyName("nonce")]
	public virtual string?					Nonce  {get; set;} //

    /// <summary>
    ///Confirmation
    /// </summary>

	[JsonPropertyName("cnf")]
	public virtual DpopConfirmation?					Confirm  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("jti", 
					(IBinding data, string? value) => {(data as DpopPayload).JTI = value;}, 
					(IBinding data) => (data as DpopPayload).JTI ),
		new PropertyString ("htm", 
					(IBinding data, string? value) => {(data as DpopPayload).HTM = value;}, 
					(IBinding data) => (data as DpopPayload).HTM ),
		new PropertyString ("htu", 
					(IBinding data, string? value) => {(data as DpopPayload).HTU = value;}, 
					(IBinding data) => (data as DpopPayload).HTU ),
		new PropertyString ("iat", 
					(IBinding data, string? value) => {(data as DpopPayload).IAT = value;}, 
					(IBinding data) => (data as DpopPayload).IAT ),
		new PropertyString ("ath", 
					(IBinding data, string? value) => {(data as DpopPayload).ATH = value;}, 
					(IBinding data) => (data as DpopPayload).ATH ),
		new PropertyString ("nonce", 
					(IBinding data, string? value) => {(data as DpopPayload).Nonce = value;}, 
					(IBinding data) => (data as DpopPayload).Nonce ),
		new PropertyStruct ("cnf", typeof (DpopConfirmation),
					(IBinding data, object? value) => {(data as DpopPayload).Confirm = value as DpopConfirmation;}, 
					(IBinding data) => (data as DpopPayload).Confirm,
					false, ()=>new  DpopConfirmation(), ()=>new DpopConfirmation())
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DpopPayload> _binding = new (
			new() {
			{ "jti", _properties [0]},
			{ "htm", _properties [1]},
			{ "htu", _properties [2]},
			{ "iat", _properties [3]},
			{ "ath", _properties [4]},
			{ "nonce", _properties [5]},
			{ "cnf", _properties [6]}}, __Tag,
		() => new DpopPayload(), () => [], () => [], null, Generic: false);


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

	[JsonPropertyName("jkt")]
	public virtual string?					JKT  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyString ("jkt", 
					(IBinding data, string? value) => {(data as DpopConfirmation).JKT = value;}, 
					(IBinding data) => (data as DpopConfirmation).JKT )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<DpopConfirmation> _binding = new (
			new() {
			{ "jkt", _properties [0]}}, __Tag,
		() => new DpopConfirmation(), () => [], () => [], null, Generic: false);


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

	}


	/// <summary>
	/// </summary>
public partial class JwtDpop : Oauth {
    /// <summary>
    /// </summary>

	[JsonPropertyName("header")]
	public virtual JwtHeader?					Header  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("payload")]
	public virtual DpopPayload?					Payload  {get; set;} //

    /// <summary>
    /// </summary>

	[JsonPropertyName("signature")]
	public virtual byte[]?					Signature  {get; set;} //


    ///<summary>Implement IBinding</summary> 
	public override Property[] _Properties => _properties;

	///<summary>Binding</summary> 
	static readonly Property[] _properties = [
		new PropertyStruct ("header", typeof (JwtHeader),
					(IBinding data, object? value) => {(data as JwtDpop).Header = value as JwtHeader;}, 
					(IBinding data) => (data as JwtDpop).Header,
					false, ()=>new  JwtHeader(), ()=>new JwtHeader()),
		new PropertyStruct ("payload", typeof (DpopPayload),
					(IBinding data, object? value) => {(data as JwtDpop).Payload = value as DpopPayload;}, 
					(IBinding data) => (data as JwtDpop).Payload,
					false, ()=>new  DpopPayload(), ()=>new DpopPayload()),
		new PropertyBinary ("signature", 
					(IBinding data, byte[]? value) => {(data as JwtDpop).Signature = value;}, 
					(IBinding data) => (data as JwtDpop).Signature )
		];

    ///<summary>Implement IBinding</summary> 
	public override Binding _Binding => _binding;

	///<summary>Binding</summary> 
	public static readonly new Binding<JwtDpop> _binding = new (
			new() {
			{ "header", _properties [0]},
			{ "payload", _properties [1]},
			{ "signature", _properties [2]}}, __Tag,
		() => new JwtDpop(), () => [], () => [], null, Generic: false);


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

	}



