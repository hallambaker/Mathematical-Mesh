using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Cryptography.Algorithms;
using System.Numerics;

namespace Goedel.Cryptography {


    public class KeyShareEdwards : KeyShare {

        }


    public abstract class KeyPairEdwards : KeyPairECDH {

        public abstract ThresholdSignatureEdwards SignHashThreshold(byte[] data,
                CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                byte[] context = null);


        public static KeyShareEdwards[] Split(int n, int t) =>
                Split(n, t);

        public KeyShareEdwards[] Split(
                    int n, int t, out BigInteger[] polynomial) {

            var privateKey = (IKeyAdvancedPrivate as CurveEdwardsPrivate);

            var Shared = new Shared(privateKey.Private, 
                    privateKey.PublicPoint.DomainParameters.Q);

            var keyshares = new KeyShareEdwards[n];

            for (int i = 0; i < n; i++) {
                keyshares[i] = new KeyShareEdwards() {
                    Index = i+1
                    };
                }


            Shared.Split(keyshares, t, out polynomial);
            return keyshares;
            }


        }

    public abstract class ThresholdCoordinatorEdwards {
        public abstract BigInteger Prime { get; }

        public BigInteger K;
        public CurveEdwards R = null;
        public BigInteger S = 0;
        public abstract CurveEdwards PublicKey { get; }

        public abstract void AddShareR(byte[] r);


        /// <summary>
        /// Complete the first round of the signature of the message <paramref name="data"/> 
        /// with optional inputs <paramref name="context"/> and <paramref name="algorithmID"/>.
        /// and return the value of the additive point R in encoded form.
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The signature algorithm identifier. This is contstrained by
        /// but not determined by the key.</param>
        /// <param name="context">The signature context value (if used).</param>
        /// <returns>The encoded value of the additive point R in encoded form.</returns>
        public byte[] CompleteR(
                    byte[] data,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null) {
            K = PublicKey.GetK(algorithmID, R.Encode(), data, context);

            Console.WriteLine($"Prime {Prime}");
            Console.WriteLine($"Public Key {PublicKey.DomainParameters.Q}");

            Console.WriteLine($"Sign 0");
            Console.WriteLine($"   K=  {K}");
            Console.WriteLine($"   R");
            Console.WriteLine(R.Encode().ToStringBase16FormatHex());
            return R.Encode();
            }

        /// <summary>
        /// Add a signature contribution to the accumulator.
        /// </summary>
        /// <param name="s"></param>
        public void AddShareS(BigInteger s) => S = (S+s).Mod(Prime);

        /// <summary>
        /// Complete the second round of the signature and return the scalar value S
        /// such that S.B == R + k.A
        /// </summary>
        /// <returns>The signature scalar value S.</returns>
        public BigInteger CompleteS(bool validate = true) {
            Console.WriteLine($"Verify");
            Console.WriteLine($"   K=  {K}");
            Console.WriteLine($"   S=  {S}");
            Console.WriteLine($"   R");
            Console.WriteLine(R.Encode().ToStringBase16FormatHex());

            if (validate) {
                PublicKey.Verify(K, S, R).AssertTrue();
                }
            return S;
            }

        }


    public class ThresholdCoordinatorEdwards25519 : ThresholdCoordinatorEdwards {
        public override BigInteger Prime => DomainParameters.Curve25519.Q;

        public CurveEdwards25519 A;
        public override CurveEdwards PublicKey => A;

        public ThresholdCoordinatorEdwards25519(CurveEdwards25519 a) {
            A = a;
            }

        public override void AddShareR(byte[] r) {

            var shareR = CurveEdwards25519.Decode(r);
            R = R == null ? shareR : R.Add(shareR);
            }

        }

    public class ThresholdCoordinatorEdwards448 : ThresholdCoordinatorEdwards {
        public override BigInteger Prime => DomainParameters.Curve448.Q;

        public CurveEdwards448 A;
        public override CurveEdwards PublicKey => A;

        public ThresholdCoordinatorEdwards448(CurveEdwards448 a) {
            A = a;
            }

        public override void AddShareR(byte[] r) {

            var shareR = CurveEdwards448.Decode(r);
            R = R == null ? shareR : R.Add(shareR);
            }

        }

    public abstract class ThresholdSignatureEdwards {

        public CurveEdwards PublicR;
        public BigInteger PrivateR;

        protected BigInteger privateKey;

        public BigInteger K;


        protected ThresholdSignatureEdwards(BigInteger prime) {
            PrivateR = BigNumber.Random(prime);
            }

        public BigInteger Complete(
                    byte[] aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true) =>
            GetS(aggregateR, A, data, 1, algorithmID, context, prehash);

        public abstract BigInteger GetS(
                    byte[] aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    BigInteger lagrange,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true);

        }

    public class ThresholdSignatureEdwards25519 : ThresholdSignatureEdwards {

        public ThresholdSignatureEdwards25519(CurveEdwards25519Private key) : 
                base (DomainParameters.Curve25519.Q) {
            privateKey = key.Private;
            PublicR = CurveEdwards25519.Base.Multiply(PrivateR);
            }

        public override BigInteger GetS(
                    byte[] aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    BigInteger lagrange,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true) {

            var domain = CurveEdwards25519.Dom2(algorithmID, context);
            var k = A.GetK(domain, aggregateR, data);

            var scalar = lagrange == 1 ? privateKey : (privateKey * lagrange).Mod(DomainParameters.Curve25519.Q);


            var sk = (k * scalar).Mod(DomainParameters.Curve25519.Q);
            var s = (PrivateR + sk).Mod(DomainParameters.Curve25519.Q);
            PrivateR = 0; // prevent reuse of the private additive scalar.

            Console.WriteLine($"Sign 0");
            Console.WriteLine($"   s=  {s}");
            Console.WriteLine($"   K=  {k}");
            Console.WriteLine($"   S=  {s}");
            Console.WriteLine($"   R");
            Console.WriteLine(aggregateR.ToStringBase16FormatHex());

            return s;
            }


        }

    public class ThresholdSignatureEdwards448: ThresholdSignatureEdwards {
        CurveEdwards448Private Key;

        public ThresholdSignatureEdwards448(CurveEdwards448Private key) :
                base(DomainParameters.Curve448.Q) {
            Key = key;
            PublicR = CurveEdwards448.Base.Multiply(PrivateR);
            }

        public override BigInteger GetS(
                    byte[] aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    BigInteger lagrange,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true) {

            var domain = CurveEdwards448.Dom4(algorithmID, context);
            var k = A.GetK(domain, aggregateR, data);

            var key = lagrange == 1 ? new CurveEdwards448Private(PrivateR) :
                new CurveEdwards448Private((PrivateR * lagrange).Mod(DomainParameters.Curve448.Q));

            return key.Sign(k, PrivateR);
            }
        }


    }
