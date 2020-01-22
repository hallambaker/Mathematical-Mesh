using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using System;

namespace Goedel.Mesh {


    //public partial class PKIXPrivateKeyUDF : IPKIXPrivateKey {
    //    public IPKIXPublicKey PublicParameters => throw new System.NotImplementedException();

    //    public int[] OID => throw new System.NotImplementedException();

    //    public byte[] DER() => throw new System.NotImplementedException();
    //    public SubjectPublicKeyInfo SubjectPublicKeyInfo(int[] OID = null) => throw new System.NotImplementedException();
    //    }





    public partial class ProfileMesh {

        public static int DefaultMasterKeyBits = 256;

        public string UDF => KeyOfflineSignature.UDF;
        public byte[] UDFBytes => KeyOfflineSignature.KeyPair.PKIXPublicKey.UDFBytes(512);

        public override string _PrimaryKey => KeyOfflineSignature.UDF;


        public const string MeshKeySign = "mmm/KeySign";
        public const string MeshKeyEscrow = "mmm/KeyEscrow";
        public const string MeshKeyEncrypt = "mmm/KeyEncrypt";

        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ProfileMesh() {
            }


        public ProfileMesh(
                    KeyPair keySign, KeyPair keyEscrow, KeyPair keyEncrypt) {
            KeyOfflineSignature = new PublicKey(keySign.KeyPairPublic());
            KeyEncryption = new PublicKey(keyEncrypt.KeyPairPublic());
            //MasterEscrowKeys = new List<PublicKey> { new PublicKey(keyEscrow.KeyPairPublic()) };
            }

        public static ProfileMesh Generate(
                    IMeshMachine meshMachine,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                    byte[] masterSecret=null,
                    bool? persist = null) {

            

            // generate the master secret (defaults to DefaultMasterKeyBits bits)
            masterSecret ??= Platform.GetRandomBits(DefaultMasterKeyBits);
            masterSecret[0] = masterSecret[0] == 0 ? (byte)1 : masterSecret[0];
            var masterUDF = Cryptography.UDF.DerivedKey(UDFAlgorithmIdentifier.MeshProfileMaster, data: masterSecret);

            
            // Generate the subordinate keys.
            GetKeySet(meshMachine, masterUDF, out var keySign, out var keyEscrow, out var keyEncrypt,
                algorithmSign, algorithmEncrypt);

            
            // Check to see if we should persist the data
            persist ??= masterSecret != null;
            if (persist==true) {
                // Store the master UDF under the UDF of the signature key generated from it.
                var privateKeyUDF = new PrivateKeyUDFMaster() {
                    PrivateValue = masterUDF,
                    Exportable = true,

                    };
                meshMachine.KeyCollection.Persist(keySign.UDF, privateKeyUDF, true);
                }
            Console.WriteLine($"Mesh Profile {keySign.UDF}");
            return new ProfileMesh(keySign, keyEscrow, keyEncrypt);
            }

        static void GetKeySet(IMeshMachine meshMachine, string masterUDF,
            out KeyPair keySign, out KeyPair keyEscrow, out KeyPair keyEncrypt,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default
            ) {

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();

            keySign = Cryptography.UDF.DeriveKey(masterUDF, meshMachine.KeyCollection,
                KeySecurity.Ephemeral, keyUses: KeyUses.Sign, algorithmSign, MeshKeySign);
            keyEscrow = Cryptography.UDF.DeriveKey(masterUDF, meshMachine.KeyCollection,
                KeySecurity.Ephemeral, keyUses: KeyUses.Sign, algorithmSign, MeshKeyEscrow);
            keyEncrypt = Cryptography.UDF.DeriveKey(masterUDF, meshMachine.KeyCollection,
                KeySecurity.Ephemeral, keyUses: KeyUses.Sign, algorithmSign, MeshKeyEncrypt);
            }



        public static new ProfileMesh Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }

    }
