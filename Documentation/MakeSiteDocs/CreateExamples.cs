using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace ExampleGenerator {






    public partial class CreateExamples {


        public byte[] Enhance(
                    byte[] MasterSecret,
                    byte[] Plaintext,
                    byte[] Salt = null) {

            Salt ??= Goedel.Cryptography.Platform.GetRandomBits(128);
            var CryptoStack = new CryptoStack(encryptID: CryptoAlgorithmId.AES256CBC) {
                Salt = Salt ?? Goedel.Cryptography.Platform.GetRandomBits(128),
                MasterSecret = MasterSecret
                };
            return CryptoStack.EncodeEDS(Plaintext, null);
            }



        }
    }
