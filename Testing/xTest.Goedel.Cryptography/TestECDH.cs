using System.Numerics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;

namespace Test.Goedel.Cryptography {
    public partial class TestGoedelCryptography {

        [TestMethod]
        public void TestDHEd25519Misc() {

            var KeyA = new CurveEdwards25519Private();
            var KeyAPublic = KeyA.Public;
            var KeyAPrivate = KeyA.Private;
            var Curve1 = KeyAPublic.Public.Multiply(CurveEdwards25519.Q);
            UT.Assert.IsTrue(Curve1.Y0 == 1);

            var Base = CurveEdwards25519.Base.Copy();
            var Neutral = CurveEdwards25519.Neutral.Copy();
            var KeyACurve = KeyAPublic.Public.Copy();

            var Pub2 = Base.Multiply(KeyAPrivate);
            UT.Assert.IsTrue(Base.Y == CurveEdwards25519.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards25519.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub2 = Base.Multiply(KeyAPrivate);
            UT.Assert.IsTrue(Base.Y == CurveEdwards25519.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards25519.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);

            var Pub3 = Base.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(CurveEdwards25519.Base);
            UT.Assert.IsTrue(Base.Y == CurveEdwards25519.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards25519.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y0 == KeyAPublic.Public.Y0);
            UT.Assert.IsTrue(Pub2.Y0 == Pub3.Y0);

            var KeyB = new CurveEdwards25519Private();
            var KeyBPublic = KeyB.Public;
            var KeyBPrivate = KeyB.Private;

            Pub2 = KeyBPublic.Public.Multiply(KeyAPrivate);
            UT.Assert.IsTrue(Base.Y == CurveEdwards25519.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards25519.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub3 = KeyBPublic.Public.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(KeyBPublic.Public);
            UT.Assert.IsTrue(Base.Y == CurveEdwards25519.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards25519.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);
            UT.Assert.IsTrue(Pub2.Y0 == Pub3.Y0);

            var AgreeAB = KeyA.Agreement(KeyB.Public);
            var AgreeBA = KeyB.Agreement(KeyA.Public);

            UT.Assert.IsTrue(AgreeAB.Y0 == AgreeBA.Y0);

            }

        [TestMethod]
        public void TestDHEd25519Decode() {

            var SecretKey = ("9d61b19deffd5a60ba844af492ec2cc4" +
            "4449c5697b326919703bac031cae7f60").FromBase16String();
            var PublicKey = ("d75a980182b10ab7d54bfed3c964073a" +
                        "0ee172f3daa62325af021a68f707511a").FromBase16String();
            var Message = "".FromBase16String();
            var Signature = ("e5564300c360ac729086e2cc806e828a" +
                               "84877f1eb8e5d974d873e06522490155" +
                               "5fb8821590a33bacc61e39701cf9b46b" +
                               "d25bf5f0595bbe24655141438e7a100b").FromBase16String();


            var Private = new CurveEdwards25519Private(SecretKey);
            var Public = Private.Public;

            var PublicBytes = Public.Encoding.Base16();

            UT.Assert.IsTrue(PublicBytes == PublicKey.Base16());
            }



        /// <summary></summary>

        [TestMethod]
        public void TestDHEd25519Agree() {

            var KeyA = new CurveEdwards25519Private();
            var KeyB = new CurveEdwards25519Private();

            var AgreeAB = KeyA.Agreement(KeyB.Public);
            var AgreeBA = KeyB.Agreement(KeyA.Public);

            UT.Assert.IsTrue(AgreeAB.Y0 == AgreeBA.Y0);
            }


        [TestMethod]
        public void TestDHEd25519AgreeToPublic() {

            var KeyA = new CurveEdwards25519Private();
            var KeyAPublic = KeyA.Public;

            var Result = KeyAPublic.Agreement();

            var AgreeAB = KeyA.Agreement(Result.Public);

            UT.Assert.IsTrue(AgreeAB.Y0 == Result.Agreement.Y0);
            }


        [TestMethod]
        public void TestDHEd25519AgreeRecryption() {

            var KeyA = new CurveEdwards25519Private();
            var KeyAPublic = KeyA.Public;


            var RecryptKeys = KeyA.GenerateRecryptionSet(2);

            var Result = KeyAPublic.Agreement();

            CurveEdwards25519[] Carry = new CurveEdwards25519[2];
            Carry[0] = RecryptKeys[0].Agreement(Result.Public);
            Carry[1] = RecryptKeys[1].Agreement(Result.Public);

            var AgreeAB = KeyAPublic.Agreement(Carry);

            UT.Assert.IsTrue(AgreeAB.Y0 == Result.Agreement.Y0);
            }



        [TestMethod]
        public void TestDHEd448Misc() {

            var KeyA = new CurveEdwards448Private();
            var KeyAPublic = KeyA.Public;
            var KeyAPrivate = KeyA.Private;
            var Curve1 = KeyAPublic.Public.Multiply(CurveEdwards448.Q);
            UT.Assert.IsTrue(Curve1.Y0 == 1);

            var Base = CurveEdwards448.Base.Copy();
            var Neutral = CurveEdwards448.Neutral.Copy();
            var KeyACurve = KeyAPublic.Public.Copy();

            var Pub2 = Base.Multiply(KeyAPrivate);
            UT.Assert.IsTrue(Base.Y == CurveEdwards448.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards448.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub2 = Base.Multiply(KeyAPrivate);
            UT.Assert.IsTrue(Base.Y == CurveEdwards448.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards448.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);

            var Pub3 = Base.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(CurveEdwards448.Base);
            UT.Assert.IsTrue(Base.Y == CurveEdwards448.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards448.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y0 == KeyAPublic.Public.Y0);
            UT.Assert.IsTrue(Pub2.Y0 == Pub3.Y0);

            var KeyB = new CurveEdwards448Private();
            var KeyBPublic = KeyB.Public;
            var KeyBPrivate = KeyB.Private;

            Pub2 = KeyBPublic.Public.Multiply(KeyAPrivate);
            UT.Assert.IsTrue(Base.Y == CurveEdwards448.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards448.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);

            Pub3 = KeyBPublic.Public.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(KeyBPublic.Public);
            UT.Assert.IsTrue(Base.Y == CurveEdwards448.Base.Y);
            UT.Assert.IsTrue(Neutral.Y == CurveEdwards448.Neutral.Y);
            UT.Assert.IsTrue(KeyACurve.Y == KeyAPublic.Public.Y);
            UT.Assert.IsTrue(Pub2.Y0 == Pub3.Y0);

            var AgreeAB = KeyA.Agreement(KeyB.Public);
            var AgreeBA = KeyB.Agreement(KeyA.Public);

            UT.Assert.IsTrue(AgreeAB.Y0 == AgreeBA.Y0);

            }


        }
    }
