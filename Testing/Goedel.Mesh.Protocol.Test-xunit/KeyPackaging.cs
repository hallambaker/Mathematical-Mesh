using Goedel.Cryptography;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.IO;
using System;
using System.Collections.Generic;
using Goedel.Cryptography.Algorithms;
using System.Reflection;
using System.Diagnostics;
using Goedel.Test;
using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {
    public partial class TestService {

        delegate void TestCryptoAlgorithmIdDelegate(CryptoAlgorithmId cryptoAlgorithmId);
        static void TestAll(TestCryptoAlgorithmIdDelegate testCryptoAlgorithmIdDelegate) {

            testCryptoAlgorithmIdDelegate(CryptoAlgorithmId.X448);
            testCryptoAlgorithmIdDelegate(CryptoAlgorithmId.X25519);
            testCryptoAlgorithmIdDelegate(CryptoAlgorithmId.Ed25519);
            testCryptoAlgorithmIdDelegate(CryptoAlgorithmId.Ed448);
            }

        [Fact]
        public void KeyShareTestDirectAll() {
            //TestAll(KeyShareTestDirect);
            TestAll(KeyShareTestCapability);
            }

        static IKeyAdvancedPrivate Accumulate(params IKeyAdvancedPrivate[] keys) {
            var keyAccumulator = keys[0];
            for (var i = 1; i < keys.Length; i++) {
                keyAccumulator = keyAccumulator.Combine(keys[i]);
                }

            return keyAccumulator;
            }


        [Theory]
        [InlineData(CryptoAlgorithmId.X448)]
        [InlineData(CryptoAlgorithmId.X25519)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        public void KeyShareTestDirect(CryptoAlgorithmId cryptoAlgorithmId) {
            var shares = 2;

            var keyBase = KeyPair.Factory(cryptoAlgorithmId, keySecurity: KeySecurity.Exportable) as KeyPairAdvanced;

            var kbp = keyBase.IKeyAdvancedPrivate.Private.Mod(CurveX25519.Q);

            var keys = keyBase.IKeyAdvancedPrivate.MakeThresholdKeySet(shares);

            var keyAccumulator = Accumulate(keys);

            // Check we recovered the right value
            CheckEqual(keyBase.IKeyAdvancedPrivate, keyAccumulator);
            }


        [Theory]
        [InlineData(CryptoAlgorithmId.X448)]
        [InlineData(CryptoAlgorithmId.X25519)]
        [InlineData(CryptoAlgorithmId.Ed25519)]
        [InlineData(CryptoAlgorithmId.Ed448)]
        public void KeyShareTestCapability(CryptoAlgorithmId cryptoAlgorithmId) {

            var keyBase = KeyPair.Factory(cryptoAlgorithmId, keySecurity: KeySecurity.Exportable) as KeyPairAdvanced;
            Console.WriteLine($"Base Private = {keyBase.IKeyAdvancedPrivate.Private}");

            var capabilityGenerate = new CapabilityKeyGenerate() {
                KeyData = new KeyData(keyBase, true)
                };
            var keyRecover1 = capabilityGenerate.KeyData.GetKeyPairAdvanced(KeySecurity.Exportable);
            CheckEqual(keyBase, keyRecover1);




            var capabilityService = new CapabilityDecryptServiced() {
                };
            var capabilityMember = new CapabilityDecryptPartial() {
                };

            capabilityGenerate.CreateShares(capabilityService, capabilityMember);

            var key1 = capabilityService.KeyData.GetKeyPairAdvanced();
            var key2 = capabilityMember.KeyData.GetKeyPairAdvanced();

            var keyAccumulator = Accumulate(key1.IKeyAdvancedPrivate, key2.IKeyAdvancedPrivate);
            CheckEqual(keyBase.IKeyAdvancedPrivate, keyAccumulator);


            var keyRecombine = key1.Combine(key2);
            CheckEqual(keyBase, keyRecombine);
            // check we can reassemble the shares exactly.
            }

        /// <summary>
        /// Check round tripping of all KeyPairAdvanced types
        /// to and from JOSE <see cref="KeyData"/> format using the  <see cref="CryptoKey"/>
        /// and <see cref="IKeyAdvancedPrivate"/> entry points.
        /// </summary>
        /// <param name="repeat">Number of times to repeat the test.</param>
        [Theory]
        [InlineData(100)]
        public void PrivateKeyRoundTripFull(int repeat) {
            for (var i = 0; i < repeat; i++) {
                PrivateKeyRoundTrip(CryptoAlgorithmId.X448, i);
                PrivateKeyRoundTrip(CryptoAlgorithmId.X25519, i);
                PrivateKeyRoundTrip(CryptoAlgorithmId.Ed25519, i);
                PrivateKeyRoundTrip(CryptoAlgorithmId.Ed448, i);
                }
            }


        /// <summary>
        /// Check round tripping of KeyPairAdvanced of type <paramref name="cryptoAlgorithmId"/>
        /// to and from JOSE <see cref="KeyData"/> format using the  <see cref="CryptoKey"/>
        /// and <see cref="IKeyAdvancedPrivate"/> entry points.
        /// </summary>
        /// <param name="cryptoAlgorithmId">Algorithm to test</param>
        [Theory]
        [InlineData(CryptoAlgorithmId.X448,0)]
        [InlineData(CryptoAlgorithmId.X25519, 0)]
        [InlineData(CryptoAlgorithmId.Ed25519, 0)]
        [InlineData(CryptoAlgorithmId.Ed448, 0)]
        public void PrivateKeyRoundTrip(CryptoAlgorithmId cryptoAlgorithmId, int round) {
            var keyBase = GetKeyPairAdvanced(cryptoAlgorithmId, round);

            //var key = UDF.DeriveKey();


            //var keyBase = KeyPair.Factory(cryptoAlgorithmId, keySecurity: KeySecurity.Exportable);

            // Using the <see cref="KeyPair"/> representation.
            var KeyData1 = new KeyData(keyBase, true);
            var keyRecover1 = KeyData1.GetKeyPairAdvanced(KeySecurity.Exportable);
            CheckEqual(keyBase, keyRecover1);

            // Using the <see cref="IKeyAdvancedPrivate"/> representation.
            var KeyData2 = new KeyData((keyBase as KeyPairAdvanced).IKeyAdvancedPrivate);
            var keyRecover2 = KeyData2.GetKeyPairAdvanced(KeySecurity.Exportable);
            CheckEqual(keyBase, keyRecover2);
            }

        static KeyPairAdvanced GetKeyPairAdvanced(CryptoAlgorithmId cryptoAlgorithmId,
                        int round=0, int count=0) {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();

            var seed = method.Name;
            var testKey = UDF.TestKey (cryptoAlgorithmId, $"{seed}-{round}-{count}");

            return UDF.DeriveKey(testKey, null, KeySecurity.Exportable) as KeyPairAdvanced;
            }


        static void CheckEqual(KeyPair key1, KeyPairAdvanced key2) {
            var key1a = key1 as KeyPairAdvanced;

            CheckEqual(key1a.IKeyAdvancedPrivate, key2.IKeyAdvancedPrivate);
            key1a.KeyIdentifier.TestEqual(key2.KeyIdentifier);
            }
        static void CheckEqual(IKeyAdvancedPrivate key1, IKeyAdvancedPrivate key2) {
            key1.GetType().TestEqual(key2.GetType());

            var key1e = key1 as IKeyPrivateECDH;
            var domain = GetDomainParameters(key1e.CurveJose);

            key1.Private.Mod(domain.Q).TestEqual(key2.Private.Mod(domain.Q));
            }


        static DomainParameters GetDomainParameters(string curve) => curve switch {
                CurveEdwards25519.CurveJose => DomainParameters.Curve25519,
            CurveEdwards448.CurveJose => DomainParameters.Curve448,
            CurveX25519.CurveJose => DomainParameters.Curve25519,
            CurveX448.CurveJose => DomainParameters.Curve448,

                _ => throw new NYI()
                };


        [Fact]
        public void PublicKeyRoundTrip() {

            }


        [Fact]
        public void ResultKeyRoundTrip() {

            }


        }
    }
