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
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.KeyFile;

using System.Reflection.Emit;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Mesh;

/// <summary>
/// Static extensions class.
/// </summary>
public static partial class Extensions {

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
    public static void Report(this DareEnvelope envelope, StringBuilder builder, int indent = 0) {
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
    public static string AddUniqueKeyed<T>(this Dictionary<string, T> dictionary, string tagBase, T value) {
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
    /// Add the Mesh profilr <paramref name="profile"/>to the contact
    /// <paramref name="contact"/> under the service type <paramref name="serviceId"/>.
    /// </summary>
    /// <param name="contact">The contact to add the profile to.</param>
    /// <param name="profile">The profile to add.</param>

    public static void AddMesh(this JsContact contact, ProfileAccount profile) {

        if (profile is null) {
            return;
            }
        var uri = profile.AccountHandle is null ? null : "handle:" + profile.AccountHandle;
        var cryptoData = profile.DataUri();
        contact.AddServiceKeyData(profile.DirectAddressUri,
            "Mesh", uri, profile.AccountAddress, profile.Description, null,
            cryptoData, profile.IanaMediaType);
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
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddGroup(this JsContact contact, CatalogedGroup application) {
        var profile = application.EnvelopedProfileGroup.EnvelopedObject;
        contact.AddMesh(profile);
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
            Label = application.Description 
            };
        contact.Emails ??= [];
        var id = contact.Emails.AddUniqueKeyed("mail", emailAddress);


        // ToDo: need to read the encoded JSContact OpenPGP/SMIME keys and check they can actually be used.
        // Conditionally add the S/MIME keys
        contact.AddServiceKeyData(application.SmimeSign, "SMime", null, id, null, ["sign"], id);
        contact.AddServiceKeyData(application.SmimeEncrypt, "SMime_encrypt", null, id, null, ["encrypt"], id);

        // Conditionally add the OpenPGP keys
        contact.AddServiceKeyData(application.OpenpgpSign, "OpenPGP", null, id, null, ["sign"], id);
        contact.AddServiceKeyData(application.OpenpgpEncrypt, "OpenPGP_sub", null, id, null, ["encrypt"], id);

        contact.Update();
        }

    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddSsh(this JsContact contact, CatalogedApplicationSsh application) {

        contact.AddServiceKeyData(application.ClientKey, "Ssh", application.AccountAddress);
        contact.Update();
        }

    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddCredential(this JsContact contact, CatalogedApplicationCredential application) {
        var contexts = new List<string> { "sign" };
        if (application.Kind is not null) {
            contexts.Add(application.Kind);
            }
        contact.AddServiceKeyData(application.Primary, "Credential", application.Description, contexts: contexts);

        contact.Update();
        }


    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddDeveloper(this JsContact contact, CatalogedApplicationDeveloper application) {
        var service = new OnlineService() {
            Service = "Group",
            Label = application.Description
            };

        contact.OnlineServices ??= [];
        var key = contact.OnlineServices.AddUniqueKeyed("Group", service);


        contact.ClaimGroups(key, application.Ssh);
        contact.ClaimGroups(key, application.Commit);
        contact.ClaimGroups(key, application.Code);

        }


    static void ClaimGroups(this JsContact contact, string group, List<string> members) {
        foreach (var member in members) {
            var key = "udf:" + member;

            if (contact.Emails?.TryGetValue(key, out var email) == true) {
                email.Groups ??= [];
                email.Groups.Add(group);

                }
            else if (contact.OnlineServices?.TryGetValue(key, out var service) == true) {
                service.Groups ??= [];
                service.Groups.Add(group);
                }
            else {
                if (contact.GroupClaim.TryGetValue(key, out var groups)) {
                    groups.Add(group);
                    }
                else {
                    contact.GroupClaim.Add(key, [group]);
                    }
                }
            }
        }

    static List<string> CheckClaim(this JsContact contact, string member) {
        if (!contact.GroupClaim.TryGetValue(member, out var groups)) {
            return null; 
            }
        return groups;
        }


    /// <summary>
    /// Add the application <paramref name="application"/> to the contact <paramref name="contact"/>
    /// </summary>
    /// <param name="contact">The contact to add the application details to.</param>
    /// <param name="application">The application to add.</param>
    public static void AddService(this JsContact contact, CatalogedApplicationService application) {
        var protocol = application?.Protocol;
        contact.AddService(protocol, application.AccountAddress, application.Address, application.Description);
        }


    /// <summary>
    /// Add the key <paramref name="keyData"/> to the contact <paramref name="contact"/>.
    /// </summary>
    /// <param name="contact">The contact to add the key to.</param>
    /// <param name="serviceId">The Sevice type.</param>
    /// <param name="accountAddress">The account address to specify.</param>
    public static void AddService(
                this JsContact contact,
                string serviceId,
                string accountAddress,
                string uri,
                string label) {
        var service = new OnlineService() {
            Service = serviceId,
            User = accountAddress,
            Uri = uri,
            Label = label
            };
        contact.OnlineServices ??= [];
        contact.OnlineServices.AddUniqueKeyed(serviceId, service);
        }


    public static OnlineService? AddServiceKeyData(
                this JsContact contact,
                KeyData keyData,
                string serviceId,
                string label,
                string user = null,
                string uri = null,
                List<string> contexts = null, 
                string parent = null) {
        if (keyData is null) {
            return null;
            }
        var key = "udf:" + keyData.Udf;
        var (media, cryptoData) = keyData.GetDataUri();
        return contact.AddServiceKeyData(key, serviceId, uri, user, label, contexts, cryptoData, media, parent);
        }



    /// <summary>
    /// Add the key <paramref name="keyData"/> to the contact <paramref name="contact"/>.
    /// </summary>
    public static OnlineService? AddServiceKeyData(
                    this JsContact contact,
                    string key,
                    string serviceId,
                    string uri,
                    string user,
                    string label,
                    List<string> contexts,
                    string cryptoData,
                    string mediaType,
                    string parent = null) {

        var contextsD = new Dictionary<string, bool>();
        if (contexts != null) {
            foreach (var context in contexts) {
                contextsD.AddSafe(context, true);
                }
            }

        var groups = contact.CheckClaim(key);

        var service = new OnlineService() {
            Service = serviceId,
            User = user,
            Uri = uri,
            Label = label,
            Contexts = contextsD,
            Groups = groups
            };

        contact.OnlineServices ??= [];
        contact.OnlineServices.AddUniqueKeyed(key, service);

        var cryptoKey = new CryptoKey() {
            Uri = cryptoData,
            MediaType = mediaType,
            };

        contact.CryptoKeys ??= [];
        contact.CryptoKeys.Add(key, cryptoKey);

        if (parent != null) {
            service.Groups ??= [];
            service.Groups.Add(parent);
            }

        return service;
        }




    /// <summary>
    /// Add the key <paramref name="keyData"/> to the contact <paramref name="contact"/>.
    /// </summary>
    /// <param name="contact">The contact to add the key to.</param>
    /// <param name="keyData">The key data to add.</param>
    /// <param name="serviceId">The Sevice type.</param>
    /// <param name="accountAddress">The account address to specify.</param>
    /// <param name="contexts">The contexts in which the identifier is to be used.</param>
    public static void AddKeyData(
                    this JsContact contact,
                    KeyData keyData,
                    string serviceId,
                    string accountAddress,
                    List<string> contexts = null) {

        var key = "udf:" + keyData.Udf;

        var (media, uri) = keyData.GetDataUri();
        var cryptoKey = new CryptoKey() {
            Uri = uri,
            MediaType = media,
            Kind= serviceId
            };
        if (contexts != null) {
            cryptoKey.Contexts ??= [];
            foreach (var context in contexts) {
                cryptoKey.Contexts.Add(context, true);
                }
            }
        contact.CryptoKeys ??= [];
        contact.CryptoKeys.Add(key, cryptoKey);
        }
    }
