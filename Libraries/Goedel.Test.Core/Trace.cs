using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Mesh.Client;
using Goedel.Mesh;
using Goedel.Cryptography;
using System.Collections.Generic;
using Goedel.Protocol.Presentation;
using Goedel.Cryptography.Jose;

namespace Goedel.Test.Core {
    public class Trace {

        public byte[] Request;
        public byte[] Response;
        public Response ResponseObject;
        public Request RequestObject;

        public string XMLRequest => GetRequest();
        public string XMLResponse => GetResponse();

        public string GetRequest() => RequestText;
        public string GetResponse() => ResponseText;

        public string RequestText;
        public string ResponseText;
        public Trace(byte[] request, byte[] response, JsonObject requestObject) {
            Request = request;
            Response = response;
            RequestText = Request.ToUTF8();
            ResponseText = Response.ToUTF8();
            RequestObject = requestObject as Request;
            ResponseObject = Goedel.Protocol.Response.FromJson(Response.JsonReader(), true);
            }

        }

    public class TestCredential : Credential {

        public const string CredentialTag = "TestCredential";

        KeyPairAdvanced keySign;
        KeyPairAdvanced keyExchange;

        public TestCredential() {
            keySign = KeyPair.Factory(CryptoAlgorithmId.Ed448, KeySecurity.Device) as KeyPairAdvanced;
            keyExchange = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            }

        public TestCredential(byte[] encodedCredential) => keyExchange = new KeyPairX448(encodedCredential, KeySecurity.Public);

        ///<inheritdoc/>
        public override void AddCredentials(List<PacketExtension> extensions) =>
                extensions.Add(new PacketExtension() {
                    Tag = CredentialTag,
                    Value = keyExchange.IKeyAdvancedPublic.Encoding
                    });



        /// <summary>
        /// Add an extension containing this credential to <paramref name="extensions"/>.
        /// </summary>
        /// <param name="extensions">List of extensions to add the credential to.</param>
        public override Credential GetCredentials(
                    List<PacketExtension> extensions
                    ) {
            foreach (var extension in extensions) {
                if (extension.Tag == CredentialTag) {
                    return new TestCredential(extension.Value);
                    }

                if (extension.Tag == MeshCredential.CredentialTag) {
                    return new MeshCredential(extension.Value);
                    }
                }
            throw new NYI();

            }


        ///<inheritdoc/>
        public override void AddEphemerals(List<PacketExtension> extensions,
                        ref List<KeyPairAdvanced> ephmeralsOffered) {

            KeyPairAdvanced ephemeral;

            if (ephmeralsOffered != null) {
                ephemeral = ephmeralsOffered[0];
                Screen.WriteLine($"Re-Offer of = {ephemeral}");

                }
            else {
                ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
                ephmeralsOffered = new List<KeyPairAdvanced> { ephemeral };
                Screen.WriteLine($"Make Offer of = {ephemeral}");
                }

            var extension = new PacketExtension() {
                Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
                Value = ephemeral.IKeyAdvancedPublic.Encoding
                };


            extensions.Add(extension);

            }

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<PacketExtension> extensions) {
            foreach (var extension in extensions) {
                if (extension.Tag == "X448") {
                    var ephemeral = new KeyPairX448(extension.Value, KeySecurity.Public);
                    Screen.WriteLine($"Select = {ephemeral}");
                    return (keyExchange, ephemeral);
                    }
                }
            throw new NYI();
            }

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(string keyId, byte[] ephemeral) =>
                    (keyExchange, new KeyPairX448(ephemeral, KeySecurity.Public));

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey() {


            var ephemeralKey = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            return (ephemeralKey, keyExchange);

            }

        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
                    List<KeyPairAdvanced> ephemerals,
                    string keyId) => (ephemerals[0], keyExchange);

        }




    public class MeshCredentialTraced : MeshCredential {
        ///<summary>The account address (Account@Domain or @callsign)</summary>
        public virtual string AccountAddress { get; }

        public List<Trace> MeshProtocolMessages { get; }


        ///<inheritdoc/>
        public override Credential GetCredentials(
                    List<PacketExtension> extensions) {
            foreach (var extension in extensions) {

                if (extension.Tag == TestCredential.CredentialTag) {
                    return new TestCredential(extension.Value);
                    }

                if (extension.Tag == MeshCredential.CredentialTag) {

                    //var valueString = extension.Value.ToUTF8();


                    return new MeshCredential(extension.Value);
                    }

                }

            throw new NYI();
            }



        public MeshCredentialTraced(
            ContextUser contextUser) : base(contextUser) {
            }


        public MeshCredentialTraced(Connection connection,
                    KeyPair authenticationPrivate) : base(connection, authenticationPrivate) {
            }

        public MeshCredentialTraced(
            string accountAddress, List<Trace> meshProtocolMessages
            ) {
            AccountAddress = accountAddress;
            MeshProtocolMessages = meshProtocolMessages;
                }


        }
    }
