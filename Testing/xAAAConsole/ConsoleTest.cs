using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using Goedel.Utilities;
using System.IO;
using Goedel.Test;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.Windows;
using Goedel.Cryptography.Container;
using Goedel.Command;

using Test.Goedel.Cryptography.Container;

/// <summary>
/// 
/// </summary>
namespace PHB_Framework_Library1 {

    public static class Entry {
        static void Main () {
            Goedel.IO.Debug.Initialize();
            CryptographyFramework.Initialize();
            //Goedel.FSR.Lexer.Trace = true;
            var Start = new StartContainer();
            }
        }

    /// <summary>
    /// 
    /// </summary>
    public class StartContainer {

        int Max2 (int x) {
            x = x / 2;
            return x == 0 ? 1 : 2 * Max2(x);
            }

        int MaxTree (int x) {
            var x2 = x == 0? 0 : Max2(x);
            return (x2 == x) ? x2/2 : MaxTree(x-x2);
            }

        int Chain (int x) {
            var x2 = x == 0 ? 0 : Max2(x);
            return (x2 == x) ? x2 / 2 : x2+MaxTree(x - x2);
            }


        int MaxTree2 (int x) {
            int x0 = x;
            int l = 0;
            int x2 = Max2(x);


            if (x2 + (x2/2) >= x) {
                return x2 / 2;
                }

            while (x2 > 0) {
                if (x > x2) {
                    x = x - x2;
                    l = x2;
                    }

                x2 = x2 / 2;
                }

            return x0 - 2*l;
            }

        bool IsOdd (int x) {
            return (x & 1) == 1;
            }

        int MagTree3 (int x) {
            int x2 = x+1;
            int d = 1;

            while (x2 > 0) {
                if ((x2 & 1) == 1) {
                    return x2 == 1 ? (d/2) -1 : x - d ;
                    }
                d = d * 2;
                x2 = x2 / 2;
                }
            return 0;
            }


        int MagTree4 (int x) {
            int x2 = x;
            int d = 1;

            while (x2 > 0) {
                if ((x2 & 1) == 1) {
                    return x2 == 1 ? (d / 2) : x - d ;
                    }
                d = d * 2;
                x2 = x2 / 2;
                }
            return 0;
            }

        ///<summary></summary>
        public StartContainer () {
            //MaxTree2(42);


            //for (int i = 2; i < 100; i+=1) {
            //    Console.WriteLine("{0} -> {1}   / {2}={3}", i, MagTree4(i), MagTree4(i+1)-1, MagTree3(i));
            //    }



            var TestSimple = new TestSimple();

            var TContainer = MakeContainer("Test1List", ContainerType.List);
            TestSimple.TestContainer(TContainer, 100, 300);

            TContainer = MakeContainer("Test1Digest", ContainerType.Digest);
            TestSimple.TestContainer(TContainer, 100, 300);

            TContainer = MakeContainer("Test1Tree", ContainerType.Chain);
            TestSimple.TestContainer(TContainer, 100, 300);
            }



        public Container MakeContainer (string FileName, ContainerType ContainerType = ContainerType.Chain,
            bool Debug = true) {


            var FileStream = FileName.FileStream(FileStatus.Overwrite);
            var JBCDStream = Debug ? new JBCDStreamDebug(FileStream) :new JBCDStream(FileStream);
            return Container.NewContainer(JBCDStream, ContainerType);

            }
        }

    /// <summary>
    /// 
    /// </summary>
    public class Start3 { 

        ///<summary></summary>
        public Start3 () {
            CommandSplitLex.Trace = true;

            //var UnitTest1 = new TestLexer();
            //UnitTest1.TestCommandSplitLex();
            }
        }

    /// <summary>
    /// 
    /// </summary>
    public class Start2 {

        ///<summary></summary>
        public Start2() {

            var Key = Platform.GetRandomBits(256);
            var Plaintext = "This is a bigly test".ToUTF8();
            var EncryptID = CryptoAlgorithmID.AES256CBC;
            var CryptoProvider = CryptoCatalog.Default.GetSignature(CryptoAlgorithmID.RSASign);
            CryptoProvider.Generate(KeySecurity.Ephemeral);


            var EncryptedData = new JoseWebEncryption(Plaintext, Key, EncryptID: EncryptID);

            var Decrypt = EncryptedData.Decrypt(Key);

            }
        }

    /// <summary>
    /// 
    /// </summary>
    public class Start {


        ///<summary></summary>
        public Start() {

            var In ="hello".ToUTF8();
            var SHA3 = new SHA3();
            var Shake = SHA3.Shake256(In, 256);
            var ShakeText = Shake.ToBase16String();

            var c1 = new CurveEdwards448(new BigInteger(1), false);


            //var match = "1234075ae4a1e77316cf2d8000974581a343b9ebbca7e3d1db83394c30f221626f594e4f0de63902349a5ea5781213215813919f92a4d86d127466e3d07e8be3";

            var Curve448BaseY = (
    "298819210078481492676017930443930673437544040154080242095928241" +
    "372331506189835876003536878655418784733982303233503462500531545062" +
    "832660").DecimalToBigInteger();
            var b2 = new CurveEdwards448(Curve448BaseY, false);


            b2.Double();


            var Curve448TestY = CurveEdwards448.Decode (("6c82a562cb808d10d632be89c8513ebf" +
                   "6c929f34ddfa8c9f63c9960ef6e348a3" +
                   "528c8a3fcc2f044e39a3fc5b94492f8f" +
                   "032e7549a20098f95b").FromBase16String());




            var Base = CurveEdwards448.Base.Copy();
            var Neutral = CurveEdwards448.Neutral.Copy();


            var Base2 = CurveEdwards448.Base.Copy();
            Base2.Accumulate(Base);
            Assert.True(b2.Y0 == Base2.Y0);

            var Curve1 = Base.Multiply(CurveEdwards448.Q);
            var Curve2 = Base.Multiply(CurveEdwards448.Q - 1);



            var KeyA = new CurveEdwards448Private();

            var KeyAPublic = KeyA.Public;
            var KeyAPrivate = KeyA.Private;


            var KeyACurve = KeyAPublic.Public.Copy();






            var Pub2 = Base.Multiply(KeyAPrivate);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub2 = Base.Multiply(KeyAPrivate);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);

            var Pub3 = Base.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(CurveEdwards448.Base);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y0 == KeyAPublic.Public.Y0);
            Assert.True(Pub2.Y0 == Pub3.Y0);


            var KeyB = new CurveEdwards448Private();
            var KeyBPublic = KeyB.Public;
            var KeyBPrivate = KeyB.Private;

            Pub2 = KeyBPublic.Public.Multiply(KeyAPrivate);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub3 = KeyBPublic.Public.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(KeyBPublic.Public);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);
            Assert.True(Pub2.Y0 == Pub3.Y0);

            var AgreeAB = KeyA.Agreement(KeyB.Public);
            var AgreeBA = KeyB.Agreement(KeyA.Public);

            Assert.True(AgreeAB.Y0 == AgreeBA.Y0);



            var Recrypt1 = Platform.GetRandomBigInteger(KeyAPrivate);
            var Recrypt2 = KeyAPrivate - Recrypt1;

            var Pub4a = KeyBPublic.Public.Multiply(Recrypt1);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);

            var Pub4b = KeyBPublic.Public.Multiply(Recrypt2);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub4a.Accumulate(Pub4b);
            Assert.True(Pub2.Y0 == Pub4a.Y0);



            var RecryptKeys = KeyA.GenerateRecryptionSet(2);
            var Test = (KeyA.Private - RecryptKeys[0].Private - RecryptKeys[1].Private);
            var Test2 = Test.Mod(CurveEdwards448.Q);

            var Pub5a = KeyBPublic.Public.Multiply(RecryptKeys[0].Private);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);

            var Pub5b = KeyBPublic.Public.Multiply(RecryptKeys[1].Private);
            Assert.True(Base.Y == CurveEdwards448.Base.Y);
            Assert.True(Neutral.Y == CurveEdwards448.Neutral.Y);
            Assert.True(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub5a.Accumulate(Pub5b);
            Assert.True(Pub2.Y0 == Pub5a.Y0);


            //          181709681073901722637330951972001133588410340171829515070372549795146003961539585716195755291692375963310293709091662304773755859649779
            //{         181709681073901722637330951972001133588410340171829515070372549795146003961539585716195755291692375963310293709091662304773755859649779}

            ////var RecryptKeys = KeyA.GenerateRecryptionSet(2);


            ////var Test = (KeyA.Private - RecryptKeys[0].Private - RecryptKeys[1].Private);

            ////var Tot1 = CurveEdwards448.Base.Multiply(KeyA.Private);
            ////var Tot2 = CurveEdwards448.Base.Multiply(RecryptKeys[0].Private);
            ////var Tot3 = CurveEdwards448.Base.Multiply(RecryptKeys[0].Private);
            ////var Tot4 = Tot2.Add(Tot3);

            ////var Result = KeyAPublic.Agreement();

            ////CurveEdwards25519[] Carry = new CurveEdwards448[2];
            ////Carry[0] = RecryptKeys[0].Agreement(Result.Public);
            ////Carry[1] = RecryptKeys[1].Agreement(Result.Public);

            ////var AgreeAB = KeyAPublic.Agreement(Carry);


            ////var ResultValue = Result.Agreement.Encode();
            ////var AgreeEncode = AgreeAB.Encode();


            }


        public void Delete (string Key) {
            try {
                var CSP = new CspParameters() {
                    KeyContainerName = Key
                    };
                var RSA = new RSACryptoServiceProvider(CSP) {
                    PersistKeyInCsp = false
                    };
                }
            catch {

                }
            }


        }

    }