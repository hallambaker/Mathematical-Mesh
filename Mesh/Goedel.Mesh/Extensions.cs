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



    public static void AddUniqueKeyed<T>(this Dictionary<string, T> dictionary, string tagBase, T value) {
        var i = 1;

        while (true) {
            var tag = $"{tagBase}{i}";
            if (!dictionary.ContainsKey(tag)) {
                dictionary.Add(tag, value);
                return;
                };
            i++;
            }
        }



    public static void AddMesh(this JsContact contact, ProfileAccount profile, string serviceId="Mesh") {

        if (profile is null) {
            return;
            }

        var serviceTag = serviceId.ToLower();
        var directUri = profile.DirectAddressUri;

        var service = new OnlineService() {
            Service = serviceId,
            User = profile.AccountAddress,
            Uri = directUri
            };

        contact.OnlineServices ??= [];
        contact.OnlineServices.AddUniqueKeyed(serviceTag, service);

        if (profile.AccountHandle is not null) {
            var servicehandle = new OnlineService() {
                Service = serviceId,
                User = profile.AccountHandle,
                Uri = directUri
                };

            contact.OnlineServices.AddUniqueKeyed(serviceTag, servicehandle);
            }

        var uri = profile.DataUri();

        var cryptoKey = new CryptoKey() {
            Uri = uri,
            MediaType = profile.IanaMediaType,
            Kind = profile._Tag
            };

        contact.CryptoKeys ??= [];
        contact.CryptoKeys.Add(directUri, cryptoKey);

        contact.Update();

        var asString = contact.ToString();
        }

    public static void AddApplication(this JsContact contact, CatalogedApplication application) {
        switch (application) {
            case CatalogedGroup catalogedGroup: {
                AddGroup (contact, catalogedGroup); 
                break;
                }
            case CatalogedApplicationPkix catalogedPkix: {
                AddPkix(contact, catalogedPkix);
                break;
                }
            case CatalogedApplicationMail catalogedmail: {
                AddMail(contact, catalogedmail);
                break;
                }
            case CatalogedApplicationOpenPgp catalogedOpenPgp: {
                AddOpenPgp(contact, catalogedOpenPgp);
                break;
                }
            case CatalogedApplicationSsh catalogedSsh: {
                AddSsh(contact, catalogedSsh);
                break;
                }

            }
        }

    public static void AddGroup(this JsContact contact, CatalogedGroup application) {
        var profile = application.EnvelopedProfileGroup.EnvelopedObject;
        contact.AddMesh(profile);
        }

    public static void AddMail(this JsContact contact, CatalogedApplicationMail application) {

        // add Email entry for application.AccountAddress
        var emailAddress = new EmailAddress() {
            Address = application.AccountAddress
            };
        contact.Emails ??= [];
        contact.Emails.AddUniqueKeyed("mail", emailAddress);

        contact.AddKeyData(application.SmimeSign, "S/Mime", application.AccountAddress, ["sign"]);
        contact.AddKeyData(application.SmimeEncrypt, "S/Mime", application.AccountAddress,["encrypt"]);
        contact.AddKeyData(application.OpenpgpSign, "OpenPGP", application.AccountAddress, ["sign"]);
        contact.AddKeyData(application.OpenpgpEncrypt, "OpenPGP", application.AccountAddress, ["encrypt"]);

        contact.Update();
        }

    public static void AddSsh(this JsContact contact, CatalogedApplicationSsh application) {
        contact.AddKeyData(application.ClientKey, "Ssh", application.AccountAddress);
        contact.Update();
        }

    public static void AddPkix(this JsContact contact, CatalogedApplicationPkix application) {
        contact.AddKeyData(application.Certificate, application.Kind, application.AccountAddress, application.Contexts);
        contact.Update();
        }

    public static void AddOpenPgp(this JsContact contact, CatalogedApplicationOpenPgp application) {
        contact.AddKeyData(application.Public, application.Kind, application.AccountAddress, application.Contexts);
        foreach (var key in application.SubKey) {
            contact.AddKeyData(key, application.Kind, application.AccountAddress, application.Contexts);
            }

        contact.Update();
        }

    public static void AddDeveloper(this JsContact contact, CatalogedApplicationDeveloper application) {
        contact.AddServices(application.Kind, application.AccountAddress, application.Ssh);
        contact.AddServices(application.Kind, application.AccountAddress, application.Commit);
        contact.AddServices(application.Kind, application.AccountAddress, application.Sign);
        }


    public static void AddServices(
                this JsContact contact,
                string serviceId,
                string accountAddress,
                List<string> keys) {
        if (keys is not null) {
            }
        }


    public static void AddService(
                this JsContact contact,
                string serviceId,
                string accountAddress,
                string key) {
        var service = new OnlineService() {
            Service = serviceId,
            User = accountAddress,
            Uri = key
            };
        contact.OnlineServices ??= [];
        contact.OnlineServices.AddUniqueKeyed(serviceId, service);
        }

    public static void AddKeyData(
                    this JsContact contact, 
                    KeyData keyData, 
                    string serviceId,
                    string accountAddress,
                    List<string> contexts = null) {
        if (keyData is null) {
            return;
            }

        var key = "udf:" + keyData.Udf;

        contact.AddService(serviceId, accountAddress, key);

        var (media, uri) = keyData.GetDataUri();
        var cryptoKey = new CryptoKey() {
            Uri = uri,
            MediaType = media
            };
        if (contexts != null) {
            foreach (var context in contexts) {
                cryptoKey.Contexts.Add(context, true);
                }
            }
        contact.CryptoKeys ??= [];
        contact.CryptoKeys.Add(key, cryptoKey);


        }



    }
