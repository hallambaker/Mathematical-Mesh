using System;

using Goedel.Test;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Xunit;
using Goedel.Cryptography.PQC;
using System.Runtime.Intrinsics.X86;

namespace Goedel.XUnit;

/// <summary>
/// Test library for PQC algorithms.
/// </summary>
public class TestPQC : Disposable {


    /// <summary>
    /// Static constructor, put initializations here.
    /// </summary>
    static TestPQC() {
        }


    /// <summary>
    /// Create method, return an instance.
    /// </summary>
    /// <returns>The instance</returns>
    public static TestPQC Test() => new();

    [Theory]
    //[InlineData(512)]
    //[InlineData(768)]
    [InlineData(1024)]
    public void Kyber(int bits, int repeat=1) {
        for (var i = 0; i < repeat; i++) {
            var random = TestRandom.GetRandom($"-{bits}-{i}");

            var seedKey = random.GetBytes(Cryptography.PQC.Kyber.SymBytes, "Keygen");
            var seedSession = random.GetBytes(Cryptography.PQC.Kyber.SymBytes, "Session");

            var kyber = new Kyber(bits);
            var (publicKey, privateKey) = kyber.KeyPair(seedKey);

            var encryptor = new KyberPublic(publicKey);
            var (ciphertext, sharedSecret) = encryptor.Encrypt(seedSession);

            var decryptor = new KyberPrivate(privateKey);
            var plaintext = decryptor.Decrypt(ciphertext);

            plaintext.TestEqual(sharedSecret);

            //Console.WriteLine($"{i}");
            }
        }


    [Theory]
    [InlineData(DilithiumMode.Mode5)]
    public void Dilithium(DilithiumMode mode, int repeat = 1) {
        for (var i = 0; i < repeat; i++) {
            var random = TestRandom.GetRandom($"-{mode}-{i}");

            var matseed = random.GetBytes(Cryptography.PQC.MLDSA.SeedBytes, "Keygen");
            var sm = random.GetBytes(128, "Message");

            var (pk, sk) = Cryptography.PQC.MLDSA.GenerateKeypair(mode, matseed);


            var privateKey = new DilithiumPrivate(sk);
            var signature = privateKey.Sign(sm);

            var publicKey = new DilithiumPublic(pk);
            var verify = publicKey.Verify(signature, sm);

            verify.TestTrue();

            sm[0] ^= 0x01;

            var fail = publicKey.Verify(signature, sm);
            fail.TestFalse();

            //Console.WriteLine($"{i}");
            }
        }

    }



