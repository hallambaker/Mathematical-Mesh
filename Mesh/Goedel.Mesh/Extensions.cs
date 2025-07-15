#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion



using Goedel.Contacts;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.KeyFile;
using Goedel.Discovery;

using System;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Mesh;

/// <summary>
/// Static extensions class.
/// </summary>
public static partial class Extensions {

    public static MeshOnboardData? GetMeshOnboard(this JsDevice jsDevice) {


        var network = jsDevice.GetNetworkType(ContactConstant.OnlineServiceOnboard);
        if (!network.Keys.TryGetKey(ContactConstant.CryptoKeySeed, out var keyId)) {
            return null;
            }
        if (!jsDevice.CryptoKeys.TryGetValue(keyId, out var publicKey)) {
            return null;
            }

        var publicJWK = publicKey as JsonWebKeySet;

        var envelope = JsonObject.StreamParse<Enveloped>(publicJWK.Data);
        var profileDevice = ProfileDevice.Decode(envelope);

        //throw new NYI();
        return new MeshOnboardData(network, profileDevice, keyId);

        }



    //delegate void ToBuilderDelegate (StringBuilder builder, int indent);

    /// <summary>
    /// Returns <code>true</code> if <paramref name="spoolMessageState"/> represents an open
    /// state, otherwise false.
    /// </summary>
    /// <param name="spoolMessageState">The state to evaluate.</param>
    /// <returns>Return value is <code>true</code> if <paramref name="spoolMessageState"/> represents an open
    /// state, otherwise false.</returns>
    public static bool IsOpen(this StateSpoolMessage spoolMessageState) =>
        spoolMessageState switch {
            StateSpoolMessage.Read => true,
            StateSpoolMessage.Initial => true,
            _ => false
            };

    /// <summary>
    /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
    /// a leading indent of <paramref name="indent"/> units.
    /// </summary>
    /// <param name="meshItem">The item to present.</param>
    /// <param name="builder">The string builder to write to.</param>
    /// <param name="indent">The number of units to indent the presentation.</param>
    /// <param name="nullText">Text to provide if the item is null.</param>
    public static void ToBuilder(this MeshItem meshItem, StringBuilder builder,
            int indent, string nullText) {
        if (meshItem == null) {
            builder.AppendLine(nullText);
            }
        else {
            meshItem.ItemToBuilder(builder, indent);
            }
        }

    /// <summary>
    /// Locate a keypair in the set <paramref name="publicKeys"/> that has a private key in 
    /// <paramref name="keyCollection"/>
    /// </summary>
    /// <param name="keyCollection">The key collection to search.</param>
    /// <param name="publicKeys">The list of public keys to match</param>
    /// <returns>The key pair if found, otherwise <see langword="false"/></returns>
    public static CryptographicKey LocatePrivate(this IKeyCollection keyCollection, List<KeyData> publicKeys) {

        foreach (var publicKey in publicKeys) {
            if (keyCollection.LocatePrivateKeyPair(publicKey.Udf, out var keyPair)) {
                return keyPair;
                }

            }
        return null;

        }

    /// <summary>
    /// Write a formatted version of the DareEnvelope <paramref name="envelope"/> to the
    /// string builder <paramref name="builder"/> indented by <paramref name="indent"/> 
    /// units of two spaces.
    /// </summary>
    /// <param name="envelope">The envelope to present.</param>
    /// <param name="builder">The string builder.</param>
    /// <param name="indent">The indentation level.</param>
    public static void Report(this Enveloped envelope, StringBuilder builder, int indent = 0) {
        if (envelope != null) {

            Report(envelope.Header, builder, indent);
            Report(envelope.Trailer, builder, indent);
            }
        else {
            builder.AppendIndent(indent, $"[No Envelope]");
            }

        }

    /// <summary>
    /// Write a formatted version of the DareHeader <paramref name="header"/> to the
    /// string builder <paramref name="builder"/> indented by <paramref name="indent"/> 
    /// units of two spaces.
    /// </summary>
    /// <param name="header">The header to present.</param>
    /// <param name="builder">The string builder.</param>
    /// <param name="indent">The indentation level.</param>
    public static void Report(this DareHeader header, StringBuilder builder, int indent = 0) {
        if (header.Recipients != null) {
            foreach (var recipient in header.Recipients) {
                builder.AppendIndent(indent, $"Encrypted: {recipient.KeyIdentifier}");
                }
            }
        }

    /// <summary>
    /// Write a formatted version of the DareTrailer <paramref name="trailer"/> to the
    /// string builder <paramref name="builder"/> indented by <paramref name="indent"/> 
    /// units of two spaces.
    /// </summary>
    /// <param name="trailer">The trailer to present.</param>
    /// <param name="builder">The string builder.</param>
    /// <param name="indent">The indentation level.</param>
    public static void Report(this DareTrailer trailer, StringBuilder builder, int indent = 0) {
        if (trailer?.Signatures != null) {
            foreach (var signature in trailer.Signatures) {
                builder.AppendIndent(indent, $"Signed by: {signature.KeyIdentifier}");
                }
            }
        }


    /// <summary>
    /// Convert key pair to specified format
    /// </summary>
    /// <param name="keyData">Keypair to convert</param>
    /// <param name="filename">Name of the file to be created.</param>
    /// <param name="KeyFileFormat">Format to convert to</param>
    /// <param name="passphrase">Optional encryption passphrase.</param>
    /// <returns>The keyfile data</returns>
    public static void ToKeyFile(
            this KeyData keyData,
            string filename,
            KeyFileFormat KeyFileFormat = KeyFileFormat.Default,
            string passphrase = null) {
        var data = keyData.GetKeyPair(KeySecurity.Exportable).ToKeyFile(KeyFileFormat);

        filename.WriteFileNew(data);
        }


    /// <summary>
    /// Convert key pair to specified format
    /// </summary>
    /// <param name="keyPair">Keypair to convert</param>
    /// <param name="filename">Name of the file to be created.</param>
    /// <param name="KeyFileFormat">Format to convert to</param>
    /// <param name="passphrase">Optional encryption passphrase.</param>
    /// <returns>The keyfile data</returns>
    public static long ToKeyFile(
            this KeyPair keyPair,
            string filename,
            KeyFileFormat KeyFileFormat = KeyFileFormat.Default,
            string passphrase = null) {
        var data = keyPair.ToKeyFile(KeyFileFormat);

        return filename.WriteFileNew(data);
        }


    /// <summary>
    /// Add the value <paramref name="value"/> to the dictionary <paramref name="dictionary"/>
    /// under a unique tag formed by appending an integer the base <paramref name="tagBase"/>.
    /// </summary>
    /// <typeparam name="T">The type of the values stored in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to add the value to.</param>
    /// <param name="tagBase">The base from which a unique tag is to be formed</param>
    /// <param name="value">The value to add.</param>
    public static string AddUniqueKeyed<T>(
                    this Dictionary<string, T> dictionary, 
                    string tagBase, T value) {
        var i = 1;

        while (true) {
            var tag = $"{tagBase}{i}";
            if (!dictionary.ContainsKey(tag)) {
                dictionary.Add(tag, value);
                return tag;
                };
            i++;
            }
        }



    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddApplication(this JsContact contact, CatalogedApplication application) {
        switch (application) {
            case CatalogedGroup catalogedGroup: {
                AddGroup (contact, catalogedGroup); 
                break;
                }
            case CatalogedApplicationCredential catalogedPkix: {
                AddCredential(contact, catalogedPkix);
                break;
                }
            case CatalogedApplicationMail catalogedmail: {
                AddMail(contact, catalogedmail);
                break;
                }
            case CatalogedApplicationSsh catalogedSsh: {
                AddSsh(contact, catalogedSsh);
                break;
                }
            case CatalogedApplicationDeveloper catalogedDeveloper: {
                AddDeveloper(contact, catalogedDeveloper);
                break;
                }
            case CatalogedApplicationService catalogedService: {
                AddService(contact, catalogedService);
                break;
                }
            }
        }


    /// <summary>
    /// Add the Mesh profilr <paramref name="profile"/>to the contact
    /// <paramref name="contact"/> .
    /// </summary>
    /// <param name="contact">The contact to add the profile to.</param>
    /// <param name="profile">The profile to add.</param>

    public static void AddMesh(this JsContact contact, ProfileAccount profile) {
        if (profile is null) {
            return;
            }
        var uri = profile.AccountHandle is null ? null : "handle:" + profile.AccountHandle;
        var cryptoData = profile.GetEnvelopedBytes();

        contact.AddServiceKeyData(profile.UdfString, ContactConstant.OnlineServiceMesh, uri: uri, user: profile.AccountAddress, label: null, contexts: [],
             mediaType: profile.IanaMediaType, cryptoData: cryptoData);
        }


    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddGroup(this JsContact contact, CatalogedGroup application) {
        var profile = application.ProfileGroup;
        contact.AddMesh(profile);

        throw new NYI();
        }


    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddMail(this JsContact contact, CatalogedApplicationMail application) {

        // add Email entry for application.AccountAddress
        var emailAddress = new EmailAddress() {
            Address = application.AccountAddress,
            Label = application.Description ,
            CryptoKeyIds = new()
            };
        contact.Emails ??= [];
        var id = contact.Emails.AddUniqueKeyed("mail", emailAddress);


        // ToDo: need to read the encoded JSContact OpenPGP/SMIME keys and check they can actually be used.
        // Conditionally add the S/MIME keys
        contact.AddKeyData(application.SmimeSign, ContactConstant.OnlineServiceSmime, emailAddress.CryptoKeyIds, ["sig"]);
        contact.AddKeyData(application.SmimeEncrypt, ContactConstant.OnlineServiceSmime, emailAddress.CryptoKeyIds, ["enc"]);

        // Conditionally add the OpenPGP keys
        contact.AddKeyData(application.OpenpgpSign, ContactConstant.OnlineServiceOpenPgp, emailAddress.CryptoKeyIds, ["sig"]);
        contact.AddKeyData(application.OpenpgpEncrypt, ContactConstant.OnlineServiceOpenPgp, emailAddress.CryptoKeyIds, ["enc"]);

        contact.Update();
        }

    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddSsh(this JsContact contact, CatalogedApplicationSsh application) {

        var service = new OnlineService() {
            Service = "ssh",
            User = application.AccountAddress,
            Label = application.Description,
            CryptoKeyIds = []
            };
        contact.OnlineServices ??= [];
        contact.OnlineServices.Add(application.Key, service);

        contact.AddKeyData(application.ClientKey, ContactConstant.OnlineServiceSsh, service.CryptoKeyIds, ["auth"]);


        contact.Update();
        }

    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddCredential(this JsContact contact, CatalogedApplicationCredential application) {
        Dictionary<string, bool>? contexts = null;
        if (application.Contexts is not null) {
            contexts = new();
            foreach (var context in application.Contexts) {
                contexts.Add(context, true);
                }
            }
            
        var service = new OnlineService() {
            Service = application.Kind ?? "credential",
            User = application.AccountAddress,
            Label = application.Description,
            CryptoKeyIds = [],
            Contexts = contexts
            };
        contact.OnlineServices ??= [];
        contact.OnlineServices.Add(application.Key, service);

        contact.AddKeyData(application.Primary, ContactConstant.OnlineServiceCredential, service.CryptoKeyIds, ["sign"]);
        contact.Update();
        }


    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddDeveloper(this JsContact contact, CatalogedApplicationDeveloper application) {
        var group = new Contacts.ServiceGroup() {
            Label = application.Description,
            Members = []
            };
        
        contact.ServiceGroups ??= [];
        contact.ServiceGroups.Add(application.Key, group);

        AddMembers (group, application.Ssh);
        AddMembers(group, application.Commit);
        AddMembers(group, application.Code);

        }

    static void AddMembers(Contacts.ServiceGroup group, List<string> members) {
        if (members is null) {
            return;
            }
        foreach (var member in members) {
            group.Members.Add(member, true);
            
            }

        }


    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static OnlineService AddService(this JsContact contact, CatalogedApplicationService application) {
        var protocol = application?.Protocol;

        var service = new OnlineService() {
            Service = protocol,
            User = application.AccountAddress,
            Uri = application.Address,
            Label = application.Description
            };
        contact.OnlineServices ??= [];
        contact.OnlineServices.Add(application.Key, service);

        return service;
        }



    /// <summary>
    /// Add a service with the specified parameters and credential <paramref name="cryptoUri"/> to 
    /// the contact with separate service and CryptoKey entries.
    /// </summary>
    /// <param name="contact">The contact to add the key to.</param>
    /// <param name="key">The key the service is added under.</param>
    /// <param name="serviceId">The Sevice type.</param>
    /// <param name="user"></param>
    /// <param name="uri">The service URI</param>
    /// <param name="label">The service description.</param>
    /// <param name="contexts">Contexts in which the service is to be used.</param>
    /// <param name="parent">Parent service if a member of a group.</param>
    /// <param name="cryptoUri">The CryptoData representing the key.</param>
    /// <param name="mediaType">The Key media type.</param>
    /// <param name="cryptoData">The associated cryptographic keys.</param>
    /// <returns>The service entry.</returns>
    public static void AddServiceKeyData(
                    this JsContact contact,
                    string key,
                    string serviceId,
                    string uri,
                    string user,
                    string label,
                    List<string> contexts,
                    string mediaType,
                    string cryptoUri=null,
                    byte[] cryptoData = null, string parent = null) {

        var contextsD = new Dictionary<string, bool>();
        if (contexts != null) {
            foreach (var context in contexts) {
                contextsD.AddSafe(context, true);
                }
            }


        var service = contact.AddServiceData(key, serviceId, uri, user, label, contexts);

        var jwks = new JsonWebKeySet() {
            Uri = cryptoUri,
            Data = cryptoData,
            MediaType = mediaType
            };
        contact.CryptoKeys ??= [];
        contact.CryptoKeys.Add(key, jwks);                                                                                                                                                     

        service.CryptoKeyIds.Add(key, serviceId);

        //var groups = contact.CheckClaim(key);



        //var service = new OnlineService() {
        //    Service = serviceId,
        //    User = user,
        //    Uri = uri,
        //    Label = label,
        //    Contexts = contextsD,
        //    Keys = []
        //    //Groups = groups
        //    };
        ////service.Keys.Add(key, "");
        //contact.OnlineServices ??= [];
        //contact.OnlineServices.AddUniqueKeyed(key, service);

        return;
        }


    /// <summary>
    /// Add a service with the specified parameters and credentials
    /// the contact with separate service and CryptoKey entries.
    /// </summary>
    /// <param name="contact">The contact to add the key to.</param>
    /// <param name="key">The key the service is added under.</param>
    /// <param name="serviceId">The Sevice type.</param>
    /// <param name="user"></param>
    /// <param name="uri">The service URI</param>
    /// <param name="label">The service description.</param>
    /// <param name="contexts">Contexts in which the service is to be used.</param>
    /// <returns>The service entry.</returns>
    public static OnlineService AddServiceData(
                    this JsContact contact,
                    string key,
                    string serviceId,
                    string uri,
                    string user,
                    string label,
                    List<string> contexts) {

        var contextsD = new Dictionary<string, bool>();
        if (contexts != null) {
            foreach (var context in contexts) {
                contextsD.AddSafe(context, true);
                }
            }

        var service = new OnlineService() {
            Service = serviceId,
            User = user,
            Uri = uri,
            Label = label,
            Contexts = contextsD,
            CryptoKeyIds = []
            };
        contact.OnlineServices ??= [];
        contact.OnlineServices.AddUniqueKeyed(key, service);

        return service;
        }


    /// <summary>
    /// Add the key <paramref name="keyData"/> to the contact <paramref name="contact"/>.
    /// </summary>
    /// <param name="contact">The contact to add the key to.</param>
    /// <param name="keyData">The key data to add.</param>
    /// <param name="serviceId">The Sevice type.</param>
    /// <param name="keys">Dictionary mapping key identifiers to uses.</param>
    /// <param name="contexts">The contexts in which the identifier is to be used.</param>
    public static void AddKeyData(
                    this JsContact contact,
                    KeyData? keyData,
                    string serviceId,
                    Dictionary<string, string> keys,
                    List<string> contexts = null) {
        if (keyData is null) {
            return;
            }
        var key = keyData.Udf;
        //var (media, cryptoData) = keyData.GetDataUri();

        var jwk = JWK.Factory(keyData.GetKeyPair());
        var jwks = new JsonWebKeySet() {
            JsonWebKeys = [jwk]
            };
        contact.CryptoKeys ??= [];
        contact.CryptoKeys.Add(key, jwks);

        keys.Add(key, serviceId);


        }




    public static ProfileAccount GetProfileAccount(this JsContact contact, OnlineService onlineService) {

        // get the key recor
        string keyId = null;
        foreach (var key in onlineService.CryptoKeyIds) {
            if (key.Value == ContactConstant.OnlineServiceMesh) {
                keyId = key.Key;
                }
            }
        if (!contact.CryptoKeys.TryGetValue(keyId, out var crypotoKey)) {
            return null;
            }

        var webKeySet = crypotoKey as JsonWebKeySet;

        var enveloped = JsonObject.StreamParseTag<Enveloped>(webKeySet.Data);

        var profile = JsonObject.StreamParseTag<ProfileAccount>(enveloped.Body);
        //Console.WriteLine(webKeySet.Data.ToUTF8());


        return profile;

        }


    }
