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

        public static KeyPairEdwards Factory(
                CryptoAlgorithmID cryptoAlgorithmID, BigInteger scalar) => throw new NYI();


        public abstract ThresholdSignatureEdwards SignHashThreshold(byte[] data,
                CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                byte[] context = null);


        public static KeyShareEdwards[] Split(int n, int t) =>
                Split(n, t);

        public KeyShareEdwards[] Split(
                    int n, int t, out BigInteger[] polynomial) {

            var Shared = new Shared(0, 0);

            var keyshares = new KeyShareEdwards[n];

            Shared.Split(keyshares, t, out polynomial);
            return keyshares;
            }


        }

    public abstract class ThresholdCoordinatorEdwards {
        public abstract BigInteger Prime { get; }

        public BigInteger K;
        public CurveEdwards R = null;
        public BigInteger S = 0;
        public abstract CurveEdwards SB { get; }
        public abstract CurveEdwards PublicKey { get; }

        public abstract void AddShareR(byte[] r);

        public abstract BigInteger MakeK(
                    byte[] data,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true);


        /// <summary>
        /// Add a signature contribution to the accumulator.
        /// </summary>
        /// <param name="s"></param>
        public void AddShareS(BigInteger s) => S = (S+s).Mod(Prime);


        public BigInteger Verify() {
            PublicKey.Verify(K, S, R).AssertTrue();
            return S;
            }

        }


    public class ThresholdCoordinatorEdwards25519 : ThresholdCoordinatorEdwards {
        public override BigInteger Prime => DomainParameters.Curve25519.Q;
        public override CurveEdwards SB => throw new NYI();

        public CurveEdwards25519 A;
        public override CurveEdwards PublicKey => A;

        public ThresholdCoordinatorEdwards25519(CurveEdwards25519 a) {
            A = a;
            }


        public override BigInteger MakeK(
            byte[] data,
            CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
            byte[] context = null,
            bool prehash = true) => throw new NYI();

        public override void AddShareR(byte[] r) {

            var shareR = CurveEdwards25519.Decode(r);
            R = R == null ? shareR : R.Add(shareR);
            }

        }

    public class ThresholdCoordinatorEdwards448 : ThresholdCoordinatorEdwards {
        public override BigInteger Prime => DomainParameters.Curve448.Q;
        public override CurveEdwards SB => throw new NYI();

        public CurveEdwards448 A;
        public override CurveEdwards PublicKey => A;

        public ThresholdCoordinatorEdwards448(CurveEdwards448 a) {
            A = a;
            }

        public override BigInteger MakeK(
            byte[] data,
            CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
            byte[] context = null,
            bool prehash = true) => throw new NYI();

        public override void AddShareR(byte[] r) {

            var shareR = CurveEdwards448.Decode(r);
            R = R == null ? shareR : R.Add(shareR);
            }

        }

    public abstract class ThresholdSignatureEdwards {

        public CurveEdwards PublicR;
        public BigInteger PrivateR;

        public BigInteger K;


        protected ThresholdSignatureEdwards(BigInteger prime) {
            PrivateR = BigNumber.Random(prime);
            }

        public BigInteger Complete(
                    CurveEdwards aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true) =>
            Complete(aggregateR, A, data, 1, algorithmID, context, prehash);

        public abstract BigInteger Complete(
                    CurveEdwards aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    BigInteger lagrange,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true);

        }

    public class ThresholdSignatureEdwards25519 : ThresholdSignatureEdwards {
        CurveEdwards25519Private Key;

        public ThresholdSignatureEdwards25519(CurveEdwards25519Private key) : 
                base (DomainParameters.Curve25519.Q) {
            Key = key;
            PublicR = CurveEdwards25519.Base.Multiply(PrivateR);
            }

        public override BigInteger Complete(
                    CurveEdwards aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    BigInteger lagrange,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true) {

            var domain = CurveEdwards25519.Dom2(algorithmID, context);
            var Rs = aggregateR.Encode();
            var k = A.GetK(domain, Rs, data);

            var key = lagrange == 1 ? new CurveEdwards25519Private(PrivateR) :
                new CurveEdwards25519Private((PrivateR * lagrange).Mod(DomainParameters.Curve25519.Q));

            return key.Sign(k, PrivateR);
            }


        }

    public class ThresholdSignatureEdwards448: ThresholdSignatureEdwards {
        CurveEdwards448Private Key;

        public ThresholdSignatureEdwards448(CurveEdwards448Private key) :
                base(DomainParameters.Curve25519.Q) {
            Key = key;
            PublicR = CurveEdwards25519.Base.Multiply(PrivateR);
            }

        public override BigInteger Complete(
                    CurveEdwards aggregateR,
                    CurveEdwards A,
                    byte[] data,
                    BigInteger lagrange,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null,
                    bool prehash = true) {

            var domain = CurveEdwards448.Dom4(algorithmID, context);
            var Rs = aggregateR.Encode();
            var k = A.GetK(domain, Rs, data);

            var key = lagrange == 1 ? new CurveEdwards448Private(PrivateR) :
                new CurveEdwards448Private((PrivateR * lagrange).Mod(DomainParameters.Curve448.Q));

            return key.Sign(k, PrivateR);
            }
        }


    }
