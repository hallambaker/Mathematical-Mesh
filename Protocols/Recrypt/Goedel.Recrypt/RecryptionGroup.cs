using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Mesh;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

namespace Goedel.Recrypt {
    public partial class RecryptionGroup {
        
        /// <summary>The recryption service provider.</summary>
        public CryptoProviderRecryption RecryptionProvider;
        
        /// <summary>The recryption key pair.</summary>
        public PublicKey RecryptionKeyPair;

        /// <summary>
        /// Initialize a newly created Recryption group.
        /// </summary>
        /// <param name="DeviceProfile">Initial device profile.</param>
        public void Generate () {
            Master = new MasterProfile(CryptoCatalog.Default);

            RecryptionProvider = new CryptoProviderExchangeDH(KeySecurity: KeySecurity.Application);
            RecryptionKeyPair = new PublicKey(RecryptionProvider.KeyPair);


            var EncryptionKey = new PublicKey() {
                PublicParameters = RecryptionKeyPair.PublicParameters
                };

            var WrappedEncryptionKey = new RecryptionKey() {
                EncryptionKey = EncryptionKey
                };

            CurrentEncryptionKey = new JoseWebSignature(WrappedEncryptionKey, SigningKey: Master.AdministrationKey);

            }

        /// <summary>Get the current encryption key.</summary>
        public KeyPair ValidatedCurrentEncryptionKey  => GetValidatedCurrentEncryptionKey(); 

        KeyPair _ValidatedCurrentEncryptionKey;
        KeyPair GetValidatedCurrentEncryptionKey () {
            if (_ValidatedCurrentEncryptionKey == null) {


                // NYI check the signature chain on current encryption key

                var Key = RecryptionKey.FromJSON(CurrentEncryptionKey.Payload.JSONReader());
                _ValidatedCurrentEncryptionKey = Key.EncryptionKey.KeyPair;
                }
            return _ValidatedCurrentEncryptionKey;
            }

        /// <summary>
        /// Add member to the recryption group.
        /// </summary>
        /// <param name="Recrypt">Member's recryption profile.</param>
        /// <returns>The new member</returns>
        public MemberEntry AddMember (RecryptProfile Recrypt) {
            Members = Members ?? new List<MemberEntry>();


            var GroupPrivate = GetGroupPrivate();

            var MemberEntry = new MemberEntry() {
                UDF = Recrypt.PersonalUDF,
                RecryptUDF = Recrypt.Identifier,
                Status = "Active",
                Entries = new List<UserDecryptionEntry>(),
                Name= Recrypt.ShortID
                };

            foreach (var EncryptKey in Recrypt.EncryptKeys) {
                MemberEntry.Entries.Add(MakeUserDecryptionEntry(GroupPrivate, EncryptKey));
                }

            Members.Add(MemberEntry);
            return MemberEntry;
            }


        KeyPair GetGroupPrivate () {
            if (RecryptionKeyPair != null) {
                return RecryptionKeyPair.KeyPair;
                }

            return KeyPair.FindLocal(ValidatedCurrentEncryptionKey.UDF);
            }

        /// <summary>
        /// Remove a member from the group.
        /// </summary>
        /// <param name="UserIdentifier"></param>
        public void RemoveMember (string UserIdentifier) {
            var Member = Members.SingleOrDefault(M => M.Name == UserIdentifier);
            if (Member != null) {
                Members.Remove(Member);
                }
            }


        /// <summary>
        /// Create a decryption entry for the specified member.
        /// </summary>
        /// <param name="GroupPrivate">The group private key</param>
        /// <param name="EncryptKey">The member's encryption key</param>
        /// <returns>The user decryption data</returns>
        public UserDecryptionEntry MakeUserDecryptionEntry (KeyPair GroupPrivate, PublicKey EncryptKey) {



            //var RecryptionProvider = new CryptoProviderExchangeDH(GroupPrivate);

            var GroupPrivateRecrypt = GroupPrivate as KeyPairAdvanced;
            GroupPrivateRecrypt.GenerateRecryptionPair(out var Recryption, out var Completion);
            var RecryptionKey = Key.FactoryPrivate(Recryption);
            var CompletionKey = Key.FactoryPrivate(Completion);

            var RecryptionBlob = new JoseWebEncryption(
                    CompletionKey, EncryptionKey: EncryptKey.KeyPair);

            return new UserDecryptionEntry() {
                EncryptionKeyUDF = GroupPrivate.UDF,
                MemberKeyUDF = EncryptKey.PublicParameters.Kid,
                DecryptionKey = RecryptionBlob,
                RecryptionKey = RecryptionKey
                };
            }


        //public PublicKey EncryptionKey { get => GetEncryptionKey(); }

        PublicKey GetEncryptionKey () {

            var Keydata = RecryptionKey.FromJSON(CurrentEncryptionKey.Payload.JSONReader());
            var Result = Keydata.EncryptionKey;

            return Result;
            }
        }

    public partial class GetKeyResponse {

        public RecryptionKey RecryptionKey => RecryptionKey.FromJSON(SignedKey.Payload.JSONReader());
        }


    public partial class RecryptionKey {

        public string RecrytionGroup { get; set; }

        public KeyPair NamedKeyPair () {
            RecrytionGroup.SplitAccountID(out var Domain, out var Account);
            var KeyPair = EncryptionKey.KeyPair;
            KeyPair.Name = KeyPair.UDF.ToLower() + "@" + Domain;

            return KeyPair;
            }

        List<KeyPair> EncryptionKeys => new List<KeyPair>() { NamedKeyPair() };

        CryptoParameters CryptoParameters => new CryptoParameters() { EncryptionKeys = EncryptionKeys };

        /// <summary>
        /// Get encryption key from signed data.
        /// </summary>
        /// <param name="SignedRecryptionKey">The signed recryption key.</param>
        /// <returns>The recryption key.</returns>
        public static PublicKey GetEncryptionKey (JoseWebSignature SignedRecryptionKey) {

            var Keydata = FromJSON(SignedRecryptionKey.Payload.JSONReader());
            return Keydata.EncryptionKey;
            }




        /// <summary>
        /// Encrypt content. The input is read from a file. The output is written to a file.
        /// </summary>
        /// <param name="Input">Filename of the file to read the plaintext from.</param>
        /// <param name="Output">Filename of the file to write the ciphertext to.</param>
        public void Encrypt (string Input, string Output) {
            Input.OpenReadToEnd(out var Data);
            Encrypt(Data, Output);
            }

        /// <summary>
        /// Encrypt content. The input is presented as a byte array. The output is written to a file.
        /// </summary>
        /// <param name="Input">The input data</param>
        /// <param name="Output">Filename of the file to write the ciphertext to.</param>
        public void Encrypt(byte[] Input, string Output) => 
                    FileContainerWriter.File(Output, CryptoParameters, Input);

        /// <summary>
        /// Encrypt content. The input and outputs are byte arrays.
        /// </summary>
        /// <param name="Input">The input data</param>
        /// <param name="Output">The output data</param>
        public void Encrypt(byte[] Input, byte[] Output) => Output = 
                    FileContainerWriter.Data(Input, CryptoParameters: CryptoParameters);


        /// <summary>
        /// Encrypt content. The input is read from a file. The output is written to a file.
        /// </summary>
        /// <param name="Input">The directory to read files from</param>
        /// <param name="Output">The output. This is a single file if SingleFile is true, 
        /// otherwise is a directory.</param>
        public void EncryptDirectory(string InputDirectory, string Output, bool SingleFile) => throw new NYI();


        }
    }
