using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Protocol.Debug;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;

namespace ExampleGenerator {

    public static class Extension {
        public static (BigInteger X, BigInteger Y) GetXY(this Curve curve) {
            switch (curve) {

                case CurveMontgomery curveMontgomery: {
                    return (curveMontgomery.U,
                        curveMontgomery.V);
                    }
                case CurveEdwards curveEdwards: {
                    return (curveEdwards.X,
                        curveEdwards.Y);
                    }

                default:
                    break;
                }

            throw new NYI();
            }


        }

    public partial class ThresholdSignature {

        public Unanimous UnanimousEd25519;
        public Unanimous UnanimousEd448;
        public Quorate QuorateEd25519;
        public Quorate QuorateEd448;

        public ThresholdSignature() {

            //TestLagrange();

            UnanimousEd448 = new Unanimous(CryptoAlgorithmId.Ed448);
            QuorateEd448 = new Quorate(CryptoAlgorithmId.Ed448);

            UnanimousEd25519 = new Unanimous(CryptoAlgorithmId.Ed25519);
            QuorateEd25519 = new Quorate(CryptoAlgorithmId.Ed25519);


            }


        public void TestLagrange() {

            var KeyShares = new KeyShare[] {
                //new KeyShareSymmetric (1, 1494, 16),
                new KeyShareSymmetric (2, 1942, 16),
                //new KeyShareSymmetric (3, 2578, 16),
                new KeyShareSymmetric (4, 3402, 16),
                new KeyShareSymmetric (5, 4414, 16),

                };

            var prime = BigInteger.Pow(2, 32) + 15;
            var result = Shared.CombineNT(KeyShares, DomainParameters.Curve25519.Q, 3);
            (result == 1234).TestTrue();
            }

        }

    public partial class SigExample {

        public BigInteger Modulus => PublicSignatureKey.DomainParameters.Q;

        public virtual string TestData => "This is a test";
        public byte[] TestDataBytes => TestData.ToUTF8();

        public byte[] RRa;
        public byte[] RRb;
        public BigInteger Ra;
        public BigInteger Rb;
        public byte[] R;
        public BigInteger K;

        public BigInteger La = 1;
        public BigInteger Lc = 1;

        public BigInteger SSa;
        public BigInteger SSb;

        public BigInteger S;
        public CurveEdwards SB;
        public BigInteger SBX => SB.X0;
        public BigInteger SBY => SB.Y0;
        public CryptoAlgorithmId CryptoAlgorithmID;


        public CurveEdwards PublicSignatureKey;

        public ThresholdCoordinatorEdwards ThresholdCoordinate;

        public SigExample(CryptoAlgorithmId cryptoAlgorithmID) => CryptoAlgorithmID = cryptoAlgorithmID;

        public ThresholdSignatureEdwards Threshold1;
        public ThresholdSignatureEdwards Threshold2;

        public KeyPairEdwards Edwards1;
        public KeyPairEdwards Edwards2;
        public KeyPairEdwards EdwardsAggregate;
        public CurveKey KeyAggregate;

        public void Complete1() {

            var hash = CryptoAlgorithmID.Bulk().GetDigest(TestDataBytes);
            Threshold1 = Edwards1.SignHashThreshold(hash);
            Threshold2 = Edwards2.SignHashThreshold(hash);

            Ra = Threshold1.PrivateR;
            RRa = Threshold1.PublicR.Encode();

            Rb = Threshold2.PrivateR;
            RRb = Threshold2.PublicR.Encode();

            ThresholdCoordinate = PublicSignatureKey.Coordinator();

            // Coordinator actions
            ThresholdCoordinate.AddShareR(RRa);
            ThresholdCoordinate.AddShareR(RRb);

            R = ThresholdCoordinate.CompleteR (TestDataBytes) ;
            K = ThresholdCoordinate.K;

            SSa = Threshold1.GetS(R, PublicSignatureKey, TestDataBytes, La);
            SSb = Threshold2.GetS(R, PublicSignatureKey, TestDataBytes, Lc);

            ThresholdCoordinate.AddShareS(SSa);
            ThresholdCoordinate.AddShareS(SSb);

            S = ThresholdCoordinate.CompleteS(false);
            SB = CurveEdwards25519.Base.Multiply(S);

            //Verify();
            }


        public void Verify() {
            // check that R = RRa + RRb

            var publicRa = CurveEdwards25519.Decode(RRa);
            var publicRb = CurveEdwards25519.Decode(RRb);

            var publicR = CurveEdwards25519.Decode(R);

            var publicRab = publicRa.Add(publicRb);
            var publicRba = publicRb.Add(publicRa);

            (publicRab == publicRba).TestTrue();
            (publicRab == publicR).TestTrue();

            // Check that S = Sa + Sb Mod Q 
            var SSab = (SSa + SSb).Mod(DomainParameters.Curve25519.Q);
            (S == SSab).TestTrue();

            var privateKey1 = (Edwards1.IKeyAdvancedPrivate as CurveEdwardsPrivate).Private;
            var privateKey2 = (Edwards2.IKeyAdvancedPrivate as CurveEdwardsPrivate).Private;
            var privateKey = (EdwardsAggregate.IKeyAdvancedPrivate as CurveEdwardsPrivate).Private;

            // multiply by the lagrange coefficients.
            privateKey1 = (privateKey1 * La).Mod(Modulus);
            privateKey2 = (privateKey2 * Lc).Mod(Modulus);




            // check the (adjusted) private key shares equal the master key.
            var privateKey12 = (privateKey1+ privateKey2).Mod(Modulus);
            (privateKey.Mod(Modulus) == privateKey12).TestTrue();

            // Check that public key A + B = Aggregate;
            var publicKey1 = (Edwards1.IKeyAdvancedPublic as CurveEdwardsPublic).PublicKey as CurveEdwards25519;
            var publicKey2 = (Edwards2.IKeyAdvancedPublic as CurveEdwardsPublic).PublicKey as CurveEdwards25519;


            if (La == 1) {
                // If doing unanimous Check the public components add up.
                var publicKey12 = publicKey1.Add(publicKey2);
                (PublicSignatureKey == publicKey12).TestTrue();


                // Check the value of the first threshold contribution is correct
                var SBa = CurveEdwards25519.Base.Multiply(SSa);
                var kA1 = publicKey1.Multiply(K);
                var RkA1 = publicRa.Add(kA1);
                (SBa == RkA1).TestTrue();
                }

            // Verify that S.B = R + S.A;
            PublicSignatureKey.Verify(K, S, publicR).TestTrue();

            }


        }

    public partial class Unanimous : SigExample {

        public CurveKey KeyAlice;
        public CurveKey KeyBob;




        public Unanimous(CryptoAlgorithmId cryptoAlgorithmID) : base(cryptoAlgorithmID) {

            KeyAlice = new CurveKey(cryptoAlgorithmID, true, "TSIG1", "Alice's Key");
            KeyBob = new CurveKey(cryptoAlgorithmID, true, "TSIG2", "Bob's Key");

            Edwards1 = KeyAlice.KeyPair as KeyPairEdwards;
            Edwards2 = KeyBob.KeyPair as KeyPairEdwards;

            EdwardsAggregate = Edwards1.Combine(Edwards2, KeySecurity.Exportable) as KeyPairEdwards;
            KeyAggregate = new CurveKey(EdwardsAggregate, false) {
                Name = "Aggregate Key = Alice + Bob"
                };

            PublicSignatureKey = (EdwardsAggregate.IKeyAdvancedPublic as CurveEdwardsPublic).PublicKey;


            Complete1();

            }
        }

    public partial class Quorate : SigExample {
        public override string TestData => "This is another test";


        public BigInteger A0;
        public BigInteger A1;

        public BigInteger Xa;
        public BigInteger Ya;

        public BigInteger Xb;
        public BigInteger Yb;
        public BigInteger Xc;
        public BigInteger Yc;



        public BigInteger Sa;
        public BigInteger Sc;

        // Map the Carol parameters to the 'b' set calculated above
        public byte[] RRc => RRb;
        public BigInteger Rc => Rb;
        public BigInteger SSc => SSb;



        public Quorate(CryptoAlgorithmId cryptoAlgorithmID): base (cryptoAlgorithmID) {

            KeyAggregate = new CurveKey(cryptoAlgorithmID, true, "TSIGQ", "Aggregate Key");
            
            EdwardsAggregate = KeyAggregate.KeyPair as KeyPairEdwards;
            
            PublicSignatureKey = (EdwardsAggregate.IKeyAdvancedPublic as CurveEdwardsPublic).PublicKey;
            
            // extract the private key for later use
            var privateKey = (EdwardsAggregate.IKeyAdvancedPrivate as CurveEdwardsPrivate).Private;


            var keyShares = EdwardsAggregate.Split(3, 2, out var polynomial);

            (keyShares[0].Prime == Modulus).TestTrue();


            A0 = polynomial[0];
            A1 = polynomial[1];

            //(A0 % Modulus == A0).AssertTrue();


            Xa = keyShares[0].Index;
            Ya = keyShares[0].Value;

            Xb = keyShares[1].Index;
            Yb = keyShares[1].Value;

            Xc = keyShares[2].Index;
            Yc = keyShares[2].Value;

            (Xa == 1).TestTrue();
            (Xb == 2).TestTrue();
            (Xc == 3).TestTrue();


            // check the calculation of Fa
            var checkfa = (A0 + (Xa * A1)).Mod(Modulus);
            (checkfa == Ya).TestTrue();

            var checkfb = (A0 + (Xb * A1)).Mod(Modulus);
            (checkfb == Yb).TestTrue();

            var checkfc = (A0 + (Xc * A1)).Mod(Modulus);
            (checkfc == Yc).TestTrue();


            // create the recovery shares for the first and third shares
            var recoveryShares = new KeyShareEdwards[] { keyShares[0], keyShares[2] };
            var testa0 = Shared.CombineNT(recoveryShares, Modulus, 2);

            //Console.WriteLine($" A0 =     {A0}");
            //Console.WriteLine($" TestA0 = {testa0}");

            var t3 = (A0 - testa0) % Modulus;
            //Console.WriteLine($" TestA0 = {t3}");


            La = recoveryShares[0].Lagrange(recoveryShares, 0);
            Lc = recoveryShares[1].Lagrange(recoveryShares, 1);

            


            // check calculation of the lagrange point La - x = 1
            var l1num = (-3) %Modulus;
            var l1den = (1 - 3) %Modulus;
            var l1deninv = ModInverse(l1den, Modulus);
            var l1test = (l1num * l1deninv).Mod(Modulus);

            var litestinv = (l1den * l1deninv).Mod(Modulus);
            //Console.WriteLine($" litestinv = {litestinv}");

            (l1test == La).TestTrue();

            // check calculation of the lagrange point Lc - x = 3
            var l2num = (-1)% Modulus;
            var l2den = (3 - 1)%Modulus;
            var l2deninv = ModInverse(l2den, Modulus);
            var l2test = (l2num * l2deninv).Mod(Modulus);

            (l2test == Lc).TestTrue();



            // calculate the recovery scalar values
            Sa = (La * Ya).Mod(Modulus);
            Sc = (Lc * Yc).Mod(Modulus);

            // check the (adjusted) private key shares equal the master key.
            var Sac = (Sa + Sc).Mod(Modulus);
            (A0.Mod(Modulus) == Sac).TestTrue();


            Edwards1 = KeyPairECDH.KeyPairFactory(cryptoAlgorithmID, Ya) as KeyPairEdwards;
            Edwards2 = KeyPairECDH.KeyPairFactory(cryptoAlgorithmID, Yc) as KeyPairEdwards;

            Complete1();


            }


        static BigInteger ModInverse(BigInteger k, BigInteger m) {
            var m2 = m - 2;
            if (k < 0) {
                k += m;
                }

            return BigInteger.ModPow(k, m2, m);
            }

        }


    public partial class Threshold {
        public KeyGen KeyGenX25519;
        public KeyGen KeyGenX448;
        public KeyGen KeyGenEd25519;
        public KeyGen KeyGenEd448;

        public Decrypt DecryptX25519;
        public Decrypt DecryptX448;


        public Threshold() {
            KeyGenX25519 = new KeyGen(CryptoAlgorithmId.X25519);
            KeyGenX448 = new KeyGen(CryptoAlgorithmId.X448);
            KeyGenEd25519 = new KeyGen(CryptoAlgorithmId.Ed25519);
            KeyGenEd448 = new KeyGen(CryptoAlgorithmId.Ed448);

            DecryptX25519 = new Decrypt(CryptoAlgorithmId.X25519);
            DecryptX448 = new Decrypt(CryptoAlgorithmId.X448);
            }
        }





    public partial class CurveResult {
        public Curve CurvePoint;
        public IKeyAdvancedPublic Key;

        public byte[] Public;

        public bool IsCurveX => CurvePoint is CurveMontgomery;
        public string XTag => IsCurveX ? "U" : "X";
        public string YTag => IsCurveX ? "V" : "Y";

        public BigInteger X = -1;
        public BigInteger Y = -1;


        public BigInteger X2;
        public BigInteger Z2;
        public BigInteger X3;
        public BigInteger Z3;

        public CurveResult(Curve point = null) {
            CurvePoint = point;
            Key = CurvePoint.KeyAdvancedPublic;
            Public = Key.Encoding;

            (X, Y) = point.GetXY();
            }
        public CurveResult(IKeyAdvancedPrivate key, KeyPairAdvanced Point) {
            var scalar = key.Private;

            CurveMontgomery curve;
            switch (Point.IKeyAdvancedPublic) {
                case CurveX25519Public point: {
                    curve = point.Public;
                    break;
                    }
                case CurveX448Public point: {
                    curve = point.Public;
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }

            CurvePoint = curve;

            curve.ScalarAccumulate(curve.U, scalar, out X2, out Z2, out X3, out Z3);
            (X, Y) = curve.ScalarMultiplySigned(scalar);

            Public = curve.Encode(false);
            }
        }

    public partial class CurveKey {

        static readonly byte[] Dummy = { 0 };

        public string Name = "TBS";
        public CryptoAlgorithmId CryptoAlgorithmID;
        public KeyPairAdvanced KeyPair;

        public bool IsCurveX => (KeyPair is KeyPairX25519) | (KeyPair is KeyPairX448);

        public string Curve => CryptoAlgorithmID.ToJoseID();
        public string UDF = "TBS";
        public BigInteger Scalar = -1;

        public BigInteger Modulus => throw new NYI();

        public byte[] Public = Dummy;
        public byte[] Private = Dummy;

        public bool Extended = false;

        public BigInteger X = -1;
        public BigInteger Y = -1;
        public string XTag => IsCurveX ? "U": "X";
        public string YTag => IsCurveX ? "V" : "Y";

        // Intermediate Montgomery Ladder parameters
        public string X2 = "TBS";
        public string Z2 = "TBS";
        public string X3 = "TBS";
        public string Z3 = "TBS";

        public CurveKey() {
            }

        public CurveKey(
                CryptoAlgorithmId cryptoAlgorithmID, 
                bool extended, 
                string prefix = null, 
                string name=null) {
            CryptoAlgorithmID = cryptoAlgorithmID;

            if (name != null) {
                Name = cryptoAlgorithmID.ToJoseID() + name;
                UDF = Goedel.Cryptography.UDF.TestKey(cryptoAlgorithmID, prefix + Name);
                }

            KeyPair = Goedel.Cryptography.UDF.DeriveKey(UDF, KeySecurity.Exportable, KeyUses.Any) as KeyPairAdvanced;
            SetParameters(KeyPair, extended);

            }
        public CurveKey(KeyPair keyPair, bool extended) {
            KeyPair = keyPair as KeyPairAdvanced;
            SetParameters(KeyPair, extended);
            }

        void SetParameters(KeyPair keyPair, bool extended) {
            switch (keyPair) {
                case KeyPairX25519 keyPairX25519: {
                    SetParameters(keyPairX25519, extended);
                    break;
                    }
                case KeyPairX448 keyPairX448: {
                    SetParameters(keyPairX448, extended);
                    break;
                    }
                case KeyPairEd25519 keyPairEd25519: {
                    SetParameters(keyPairEd25519);
                    break;
                    }
                case KeyPairEd448 keyPairEd448: {
                    SetParameters(keyPairEd448);
                    break;
                    }

                default:
                    break;
                }
            Private ??= Dummy;
            Public ??= Dummy;
            }
        void SetParameters(KeyPairX25519 keyPair, bool extended) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveX25519Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveX25519Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding ;
            Public = publicKey.Public.Encode (extended);

            X = publicKey.Public.U;
            Y = publicKey.Public.V;
            }
        void SetParameters(KeyPairX448 keyPair, bool extended) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveX448Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveX448Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding;
            Public = publicKey.Public.Encode(extended);

            X = publicKey.Public.U;
            Y = publicKey.Public.V;
            }
        void SetParameters(KeyPairEd25519 keyPair) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveEdwards25519Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveEdwards25519Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding;
            Public = publicKey.Encoding;

            X = publicKey.Public.X;
            Y = publicKey.Public.Y;
            }
        void SetParameters(KeyPairEd448 keyPair) {
            //var publicKey = keyPair.IKeyAdvancedPublic as CurveEdwards448Public;
            var privateKey = keyPair.IKeyAdvancedPrivate as CurveEdwards448Private;
            var publicKey = privateKey.Public;

            Scalar = privateKey.Private;
            Private = privateKey.Encoding;
            Public = publicKey.Encoding;

            X = publicKey.Public.X;
            Y = publicKey.Public.Y;
            }

        }



    public partial class Decrypt {
        public CryptoAlgorithmId CryptoAlgorithmID;

        public CurveKey KeyE;

        public CurveResult KeyEA;
        public CurveResult KeyE1;
        public CurveResult KeyE2;
        public CurveResult KeyE12;

        // Splitting
        public CurveKey KeyA;
        public CurveKey Key1;
        public CurveKey Key2;


        delegate KeyPair MakeKeyPairDelegate(IKeyAdvancedPrivate keybase,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any);

        public Decrypt(CryptoAlgorithmId cryptoAlgorithmID) {
            CryptoAlgorithmID = cryptoAlgorithmID;

            // Create the key split first!
            Key1 = new CurveKey(CryptoAlgorithmID, true, "THD", "Key1");
            var key1 = Key1.KeyPair.IKeyAdvancedPrivate;

            KeyA = new CurveKey(CryptoAlgorithmID, false, "THD", "KeyA");
            KeyE = new CurveKey(CryptoAlgorithmID, false, "THD", "KeyE");

            MakeKeyPairDelegate makeKeyPair = KeyA.KeyPair.KeyPair;

            var keyA = KeyA.KeyPair.IKeyAdvancedPrivate;
            var keyE = KeyE.KeyPair.IKeyAdvancedPrivate;

            var keyEA = keyE.Agreement(KeyA.KeyPair) as ResultECDH;
            KeyEA = new CurveResult(keyEA.Agreement);


            var keys = new List<KeyPair>() { Key1.KeyPair };

            var key2 = keyA.Combine(key1, KeySecurity.Exportable);
            Key2 = new CurveKey(makeKeyPair(key2, KeySecurity.Exportable), true);

            KeyE1 = new CurveResult(key1, KeyE.KeyPair);
            KeyE2 = new CurveResult(key2, KeyE.KeyPair);

            var keyE12 = KeyE1.CurvePoint.Add (KeyE2.CurvePoint);
            KeyE12 = new CurveResult(keyE12);
            }

        }

    public partial class KeyGen {


        public CurveKey Key1;
        public CurveKey Key2;
        public CurveKey KeyA;

        public KeyGen(CryptoAlgorithmId cryptoAlgorithmID) {
            
            Key1 = new CurveKey(cryptoAlgorithmID, true, "TKG", "Key1");
            Key2 = new CurveKey(cryptoAlgorithmID, true, "TKG", "Key2");

            var keypair = Key1.KeyPair.Combine(Key2.KeyPair, KeySecurity.Exportable);
            KeyA = new CurveKey(keypair, false);

            
            }
        }




    public partial class CreateExamples {
        #region //stuff
        //KeyExchangeClient KeyExchangeClient;
        //KeyExchangePortalTraced KeyExchangePortalTraced;

        public TraceDictionary KeyExchangeTraces;
        public Key ClientDHIdentity;
        public string TraceDH = "DiffieHellman";

        //AdvancedRecovery
        public byte[] AdvancedRecoveryMaster;
        public int AdvancedRecoveryThreshold = 3;
        public int AdvancedRecoveryCount = 5;
        public BigInteger[] AdvancedRecoveryPolynomial;
        public KeyShareSymmetric[] AdvancedRecoveryShares;
        public BigInteger[] AdvancedRecoveryShareValues;
        public byte[][] AdvancedRecoverySharesHex;
        public string[] AdvancedRecoveryBase32;

        //AdvancedCogen
        public ProfileDevice AdvancedCogenDeviceProfile;
        public byte[] AdvancedCogenPrivateKeySeed;
        public PrivateKeyECDH AdvancedCogenPrivateKeyValue;
        public PublicKeyECDH AdvancedCogenCompositeKey;
        public DareEnvelope AdvancedCogenPrivateKeySeedEncrypted;


        //AdvancedRecryption
        public string AdvancedRecryptionGroupID = "recrypt@example.com";
        //public ProfileMesh AdvancedRecryptionGroup;
        public string AdvancedRecryptionMessagePlaintext;
        public DareEnvelope AdvancedRecryptionMessageEncrypted;
        public Assertion AdvancedRecryptionBobProfile;
        public Key AdvancedRecryptionBobDecryptionKey;
        public Key AdvancedRecryptionBobRecryptionKey;
        public Key AdvancedRecryptionBobRecryptionEntry;
        public Object AdvancedRecryptionRecryptionAddMemberRequest;
        public Object AdvancedRecryptionRecryptionRecryptionRequest;
        public Object AdvancedRecryptionRecryptionRecryptionResponse;
        public Object AdvancedRecryptionDecryptionValue;
        public Object AdvancedRecryptionKeyAgreementValue;

        //AdvancedQuantum
        public byte[] AdvancedQuantumMasterSecret;
        public string[] AdvancedQuantumShares;
        public byte[][] AdvancedQuantumPrivate;
        public byte[] AdvancedQuantumPublic;
        public string AdvancedQuantumPublicUDF;
        #endregion      
        public CryptoCombine CryptoCombine;
        public CryptoGroup CryptoGroup;
        public Threshold Threshold;
        public ThresholdSignature ThresholdSignature;

        public void PlatformCrypto() {
            // To do - write the code to create examples for the 'advanced' section
            // These will need to include examples of the internals of shamir secret sharing, 
            // co-generation, recryption, etc.
            //CryptoCombine = new CryptoCombine();
            //CryptoGroup = new CryptoGroup();
            Threshold = new Threshold();
            ThresholdSignature = new ThresholdSignature();
            }
        }


    public partial class KeyPairPartialTest : KeyPairPartial {

        public string IdGroup;
        public string IdMember;
        public KeyPair PrivateKey;
        public KeyPairAdvanced KeyPairService;
        public KeyAgreementResult PartialService;
        public byte[] PartialServiceEncoded => (PartialService as CurveEdwards25519Result).AgreementEd25519.Encode();
        public KeyAgreementResult PartialDevice;
        public byte[] PartialDeviceEncoded => (PartialDevice as CurveEdwards25519Result).AgreementEd25519.Encode();
        public byte[] Result;

        public KeyPairPartialTest(KeyPairAdvanced keyPairGroup,
                KeyPairAdvanced keyPairPart, KeyPairAdvanced keyPairService) : base(keyPairGroup, keyPairPart) => KeyPairService = keyPairService;

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral = null,
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                    KeyAgreementResult partial = null,
                    byte[] salt = null) {

            PartialService = KeyPairService.Agreement(ephemeral);
            PartialDevice = KeyPartial.Agreement(ephemeral);

            var keyPartial = KeyPartial as KeyPairEd25519;


            Result = keyPartial.Agreement(
                ephemeral as KeyPairEd25519, PartialService as CurveEdwards25519Result).AgreementEd25519.Encode();
            return KeyPartial.Decrypt(encryptedKey, ephemeral, algorithmID, PartialService, salt); ;
            }

        }
    public class CryptoGroup {

        public readonly string PlaintextText = "This is a test";
        public byte[] Plaintext => PlaintextText.ToUTF8();

        public string KeyUDFGroup;
        public string KeyUDFDevice;

        public KeyPairEd25519 KeyPairGroup;
        public KeyPairEd25519 KeyPairDevice;
        public KeyPairEd25519 KeyPairService;


        public byte[] KeyPairGroupPrivate => (KeyPairGroup.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;
        public byte[] KeyPairDevicePrivate => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;

        public BigInteger KeyPairDevicePrivateInt => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;

        public BigInteger KeyPairGroupPrivateInt => (KeyPairGroup.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;

        public BigInteger KeyPairServicePrivateInt => (KeyPairService.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;


        public DareEnvelope Envelope;
        public KeyPairPartialTest KeyPairDeviceWrapped;

        public string GroupName = "GroupW@example.com";
        public string UserName = "Bob@example.com";

        public CryptoGroup() {

            KeyUDFGroup = UDF.DerivedKey(UdfAlgorithmIdentifier.Ed25519, data: GroupName.ToUTF8());
            KeyUDFDevice = UDF.DerivedKey(UdfAlgorithmIdentifier.Ed25519, data: UserName.ToUTF8());



            KeyPairGroup = UDF.DeriveKey(KeyUDFGroup, keySecurity: KeySecurity.Exportable) as KeyPairEd25519;
            KeyPairGroup.Locator = KeyUDFGroup;


            //var RecipientsGroup = new List<KeyPair> { KeyPairGroup };
            var CryptoParametersGroup = new CryptoParameters(recipient: KeyPairGroup);


            KeyPairDevice = UDF.DeriveKey(KeyUDFDevice, keySecurity: KeySecurity.Exportable) as KeyPairEd25519;

            KeyPairService = KeyPairGroup.GenerateRecryptionKey(KeyPairDevice) as KeyPairEd25519;


            Envelope = new DareEnvelope(CryptoParametersGroup, Plaintext);



            KeyPairDeviceWrapped = new KeyPairPartialTest(KeyPairGroup, KeyPairDevice, KeyPairService) {
                IdGroup = GroupName,
                IdMember = UserName
                };

            var keyCollectionDevice = new KeyCollectionCore();
            keyCollectionDevice.Add(KeyPairDeviceWrapped);



            CheckDecode(Envelope, Plaintext, keyCollectionDevice);

            }


        static void CheckDecode(
                    DareEnvelope envelope,
                    byte[] plaintext,
                    keyCollection keyCollection
                    ) {

            var cryptoStack = envelope.Header.GetCryptoStack(keyCollection);
            byte[] decrypt;


            using var input = new MemoryStream(envelope.Body);
            using var output = new MemoryStream();
            var decoder = cryptoStack.GetDecoder(input, out var plaintextStream);
            plaintextStream.CopyTo(output);
            decrypt = output.ToArray();
            decrypt.IsEqualTo(plaintext).TestTrue();

            }

        }
    public class CryptoCombine {

        public string SeedAliceDevice;
        public string SeedAliceOverlay;

        public KeyPairEd25519 KeyPairDevice;
        public KeyPairEd25519 KeyPairOverlay;

        public byte[] KeyPairDevicePrivate => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;
        public byte[] KeyPairOverlayPrivate => (KeyPairOverlay.IKeyAdvancedPrivate as CurveEdwards25519Private).Encoding;

        public KeyPairEd25519 CombinedPrivate;
        public KeyPairEd25519 CombinedPublic;

        public BigInteger SecretScalarDevice => (KeyPairDevice.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;
        public BigInteger SecretScalarOverlay => (KeyPairOverlay.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;
        public BigInteger SecretScalarComposite => (CombinedPrivate.IKeyAdvancedPrivate as CurveEdwards25519Private).Private;

        public CryptoCombine() {


            var seed = "AliceDevice1".ToUTF8();
            var random1 = KeyDeriveHKDF.Random(seed, 128, "Signature".ToUTF8());
            var random2 = KeyDeriveHKDF.Random(seed, 128, "OverlaySignature".ToUTF8());

            SeedAliceDevice = UDF.DerivedKey(UdfAlgorithmIdentifier.Ed25519, data: random1);
            SeedAliceOverlay = UDF.DerivedKey(UdfAlgorithmIdentifier.Ed25519, data: random2);

            KeyPairDevice = UDF.DeriveKey(SeedAliceDevice, KeySecurity.Exportable) as KeyPairEd25519;
            KeyPairOverlay = UDF.DeriveKey(SeedAliceOverlay, KeySecurity.Exportable) as KeyPairEd25519;

            CombinedPrivate = KeyPairDevice.Combine(KeyPairDevice) as KeyPairEd25519;
            CombinedPublic = KeyPairDevice.CombinePublic(KeyPairDevice) as KeyPairEd25519;
            }






        }
    }
