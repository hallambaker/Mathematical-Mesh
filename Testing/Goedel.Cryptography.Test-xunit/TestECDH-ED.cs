#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Numerics;

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {

        [Fact]
        public void TestDHEd25519Misc() {

            var KeyA = new CurveEdwards25519Private();
            var KeyAPublic = KeyA.Public;
            var KeyAPrivate = KeyA.Private;
            var Curve1 = KeyAPublic.Public.Multiply(CurveEdwards25519.Q);
            (Curve1.Y0 == 1).TestTrue();

            var Base = CurveEdwards25519.Base.Copy();
            var Neutral = CurveEdwards25519.Neutral.Copy();
            var KeyACurve = KeyAPublic.Public.Copy();

            var Pub2 = Base.Multiply(KeyAPrivate);
            (Base.Y == CurveEdwards25519.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards25519.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();

            Pub2 = Base.Multiply(KeyAPrivate);
            (Base.Y == CurveEdwards25519.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards25519.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();

            var Pub3 = Base.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(CurveEdwards25519.Base);
            (Base.Y == CurveEdwards25519.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards25519.Neutral.Y).TestTrue();
            (KeyACurve.Y0 == KeyAPublic.Public.Y0).TestTrue();
            (Pub2.Y0 == Pub3.Y0).TestTrue();

            var KeyB = new CurveEdwards25519Private();
            var KeyBPublic = KeyB.Public;
            var KeyBPrivate = KeyB.Private;

            Pub2 = KeyBPublic.Public.Multiply(KeyAPrivate);
            (Base.Y == CurveEdwards25519.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards25519.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();

            Pub3 = KeyBPublic.Public.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(KeyBPublic.Public);
            (Base.Y == CurveEdwards25519.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards25519.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();
            (Pub2.Y0 == Pub3.Y0).TestTrue();

            var AgreeAB = KeyA.Agreement(KeyB.Public);
            var AgreeBA = KeyB.Agreement(KeyA.Public);

            (AgreeAB.Y0 == AgreeBA.Y0).TestTrue();

            }

        [Fact]
        public void TestDHEd25519Decode() {

            var SecretKey = ("9d61b19deffd5a60ba844af492ec2cc4" +
            "4449c5697b326919703bac031cae7f60").FromBase16();
            var PublicKey = ("d75a980182b10ab7d54bfed3c964073a" +
                        "0ee172f3daa62325af021a68f707511a").FromBase16();
            //var Message = "".FromBase16String();
            //var Signature = ("e5564300c360ac729086e2cc806e828a" +
            //                   "84877f1eb8e5d974d873e06522490155" +
            //                   "5fb8821590a33bacc61e39701cf9b46b" +
            //                   "d25bf5f0595bbe24655141438e7a100b").FromBase16String();


            var Private = new CurveEdwards25519Private(SecretKey);
            var Public = Private.Public;

            var PublicBytes = Public.Encoding.ToStringBase16();

            (PublicBytes == PublicKey.ToStringBase16()).TestTrue();
            }

        [Fact]
        public void TestDHEd25519Agree() {

            var KeyA = new CurveEdwards25519Private();
            var KeyB = new CurveEdwards25519Private();

            var AgreeAB = KeyA.Agreement(KeyB.Public);
            var AgreeBA = KeyB.Agreement(KeyA.Public);

            (AgreeAB.Y0 == AgreeBA.Y0).TestTrue();
            }


        [Fact]
        public void TestDHEd25519AgreeToPublic() {

            var KeyA = new CurveEdwards25519Private();
            var KeyAPublic = KeyA.Public;

            var Result = KeyAPublic.Agreement();

            var AgreeAB = KeyA.Agreement(Result.Public);

            (AgreeAB.Y0 == Result.AgreementEd25519.Y0).TestTrue();
            }


        [Fact]
        public void TestDHEd25519AgreeRecryption() {

            var KeyA = new CurveEdwards25519Private();
            var KeyAPublic = KeyA.Public;


            var RecryptKeys = KeyA.MakeThresholdKeySet(2);

            var Result = KeyAPublic.Agreement();

            CurveEdwards25519[] Carry = new CurveEdwards25519[2];
            Carry[0] = (RecryptKeys[0] as CurveEdwards25519Private).Agreement(Result.Public);
            Carry[1] = (RecryptKeys[1] as CurveEdwards25519Private).Agreement(Result.Public);

            var AgreeAB = CurveEdwards25519Public.Agreement(Carry);

            (AgreeAB.Y0 == Result.AgreementEd25519.Y0).TestTrue();
            }



        [Fact]
        public void Ed448RecoverX() {
            BigInteger Curve448BaseY = (
                "298819210078481492676017930443930673437544040154080242095928241" +
                "372331506189835876003536878655418784733982303233503462500531545" +
                "062832660").DecimalToBigInteger();

            BigInteger Curve448BaseX = (
                "224580040295924300187604334099896036246789641632564134246125461" +
                "686950415467406032909029192869357953282578032075146446173674602" +
                "635247710").DecimalToBigInteger();

            var Result = new CurveEdwards448(Curve448BaseY, false);
            }



        [Fact]
        public void TestDHEd448Decode() {

            var SecretKey = ("6c82a562cb808d10d632be89c8513ebf" +
                        "6c929f34ddfa8c9f63c9960ef6e348a3" +
                        "528c8a3fcc2f044e39a3fc5b94492f8f" +
                        "032e7549a20098f95b").FromBase16();
            var PublicKey = ("5fd7449b59b461fd2ce787ec616ad46a" +
                        "1da1342485a70e1f8a0ea75d80e96778" +
                        "edf124769b46c7061bd6783df1e50f6c" +
                        "d1fa1abeafe8256180").FromBase16();
            //var Message = "".FromBase16String();
            //var Signature = ("e5564300c360ac729086e2cc806e828a" +
            //            "84877f1eb8e5d974d873e06522490155" +
            //            "5fb8821590a33bacc61e39701cf9b46b" +
            //            "d25bf5f0595bbe24655141438e7a100b" +
            //            "533a37f6bbe457251f023c0d88f976ae" +
            //            "2dfb504a843e34d2074fd823d41a591f" +
            //            "2b233f034f628281f2fd7a22ddd47d78" +
            //            "28c59bd0a21bfd3980ff0d2028d4b18a" +
            //            "9df63e006c5d1c2d345b925d8dc00b41" +
            //            "04852db99ac5c7cdda8530a113a0f4db" +
            //            "b61149f05a7363268c71d95808ff2e65" +
            //            "2600").FromBase16String();


            var Private = new CurveEdwards448Private(SecretKey);
            var Public = Private.Public;

            var PublicBytes = Public.Encoding.ToStringBase16();

            (PublicBytes == PublicKey.ToStringBase16()).TestTrue();
            }

        /// <summary></summary>




        [Fact]
        public void TestDHEd448Misc() {

            var KeyA = new CurveEdwards448Private();
            var KeyAPublic = KeyA.Public;
            var KeyAPrivate = KeyA.Private;
            var Curve1 = KeyAPublic.Public.Multiply(CurveEdwards448.Q);
            (Curve1.Y0 == 1).TestTrue();

            var Base = CurveEdwards448.Base.Copy();
            var Neutral = CurveEdwards448.Neutral.Copy();
            var KeyACurve = KeyAPublic.Public.Copy();

            var Pub2 = Base.Multiply(KeyAPrivate);
            (Base.Y == CurveEdwards448.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards448.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();

            Pub2 = Base.Multiply(KeyAPrivate);
            (Base.Y == CurveEdwards448.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards448.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();

            var Pub3 = Base.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(CurveEdwards448.Base);
            (Base.Y == CurveEdwards448.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards448.Neutral.Y).TestTrue();
            (KeyACurve.Y0 == KeyAPublic.Public.Y0).TestTrue();
            (Pub2.Y0 == Pub3.Y0).TestTrue();

            var KeyB = new CurveEdwards448Private();
            var KeyBPublic = KeyB.Public;
            var KeyBPrivate = KeyB.Private;

            Pub2 = KeyBPublic.Public.Multiply(KeyAPrivate);
            (Base.Y == CurveEdwards448.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards448.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();

            Pub3 = KeyBPublic.Public.Multiply(KeyAPrivate - 1);
            Pub3.Accumulate(KeyBPublic.Public);
            (Base.Y == CurveEdwards448.Base.Y).TestTrue();
            (Neutral.Y == CurveEdwards448.Neutral.Y).TestTrue();
            (KeyACurve.Y == KeyAPublic.Public.Y).TestTrue();
            (Pub2.Y0 == Pub3.Y0).TestTrue();

            var AgreeAB = KeyA.Agreement(KeyB.Public);
            var AgreeBA = KeyB.Agreement(KeyA.Public);

            (AgreeAB.Y0 == AgreeBA.Y0).TestTrue();

            }


        }
    }
