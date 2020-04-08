using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;

using System.Numerics;

using Xunit;
using Goedel.Cryptography.Jose;

#pragma warning disable IDE0059


namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {



        [Theory]
        [InlineData(10, CryptoAlgorithmId.X25519)]
        [InlineData(10, CryptoAlgorithmId.X448)]
        [InlineData(10, CryptoAlgorithmId.Ed25519)]
        [InlineData(10, CryptoAlgorithmId.Ed448)]
        public void EncodingTest(int iterations, CryptoAlgorithmId cryptoAlgorithmId) {
            for (var i = 0; i < iterations; i++) {
                EncodingTestInner(cryptoAlgorithmId);
                }
            }

        [Theory]
        [InlineData(10)]
        public void EncodingTests(int iterations) {
            for (var i = 0; i < iterations; i++) {
                EncodingTestInnerX448();
                }
            }

        public bool EncodingTestInner(CryptoAlgorithmId cryptoAlgorithmId) {

            var keypair = KeyPair.Factory(cryptoAlgorithmId, KeySecurity.Ephemeral);


            var encoding = Key.FactoryPublic(keypair);

            var decoding = encoding.KeyPair;

            keypair.UDF.Equals(decoding.UDF);

            return true;
            }


        public bool EncodingTestInnerX448() {

            var keypair = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Ephemeral) as KeyPairX448;


            var encoding = Key.FactoryPublic(keypair);

            var decoding = encoding.KeyPair as KeyPairX448;

            keypair.UDF.Equals(decoding.UDF);

            keypair.PublicKey.Public.AssertEqual(decoding.PublicKey.Public);
            keypair.PublicKey.Public.U.AssertEqual(decoding.PublicKey.Public.U);
            keypair.PublicKey.Public.V.AssertEqual(decoding.PublicKey.Public.V);
            keypair.PublicKey.Public.Odd.AssertEqual(decoding.PublicKey.Public.Odd);

            return true;
            }



        [Fact]
        public void CheckV() {
            var v25519 = "14781619447589544791020593568409986887264606134616475288964881837755586237401".DecimalToBigInteger();
            var v448 = ("355293926785568175264127502063783334808976399387714271831880898" +
                        "435169088786967410002932673765864550910142774147268105838985595290" +
                        "606362").DecimalToBigInteger();

            // check Curve 25519 base point has the correct V
            (CurveX25519.Base.GetV(true) == v25519).AssertTrue();

            // check Curve 448 base point has the correct V
            (CurveX448.Base.GetV(false) == v448).AssertTrue();
            }


        [Fact]
        public void X25519TV1() {
            var inputScalar = "a546e36bf0527c9d3b16154b82465edd62144c0ac1fc5a18506a2244ba449ac4".FromBase16();
            var inputScalarInteger = ("31029842492115040904895560451863089656" +
                "472772604678260265531221036453811406496").DecimalToBigInteger();

            var inputCoordinateU = "e6db6867583030db3594c1a424b15f7c726624ec26b3353b10a903a6d0ab1c4c".FromBase16();
            var inputCoordinateUInteger = ("34426434033919594451155107781188821651" +
                "316167215306631574996226621102155684838").DecimalToBigInteger();

            var outputCoordinateU = "c3da55379de9c6908e94ea4df28d084f32eccf03491c71f754b4075577a28552".FromBase16();

            var decodedScalar = CurveX25519.DecodeScalar(inputScalar);
            var inputPoint = new CurveX25519(inputCoordinateU);
            var outputPoint = new CurveX25519(outputCoordinateU);

            (decodedScalar == inputScalarInteger).AssertTrue();
            (inputCoordinateUInteger == inputPoint.U).AssertTrue();

            var output = inputPoint.ScalarMultiply(decodedScalar);

            (output == outputPoint.U).AssertTrue();
            }

        [Fact]
        public void X25519TV2() {
            var inputScalar = "4b66e9d4d1b4673c5ad22691957d6af5c11b6421e0ea01d42ca4169e7918ba0d".FromBase16();
            var inputScalarInteger = ("35156891815674817266734212754503633747" +
                "128614016119564763269015315466259359304").DecimalToBigInteger();

            var inputCoordinateU = "e5210f12786811d3f4b7959d0538ae2c31dbe7106fc03c3efc4cd549c715a493".FromBase16();
            var inputCoordinateUInteger = ("88838573511839298940907593866106493194" +
                "17338800022198945255395922347792736741").DecimalToBigInteger();

            var outputCoordinateU = "95cbde9476e8907d7aade45cb4b873f88b595a68799fa152e6f8f7647aac7957".FromBase16();



            var decodedScalar = CurveX25519.DecodeScalar(inputScalar);
            var inputPoint = new CurveX25519(inputCoordinateU);
            var outputPoint = new CurveX25519(outputCoordinateU);

            (decodedScalar == inputScalarInteger).AssertTrue();
            (inputCoordinateUInteger == inputPoint.U).AssertTrue();

            var output = inputPoint.ScalarMultiply(decodedScalar);

            (output == outputPoint.U).AssertTrue();

            }


        [Fact]
        public void X25519TV3() {
            var k = "0900000000000000000000000000000000000000000000000000000000000000".FromBase16();
            var u = "0900000000000000000000000000000000000000000000000000000000000000".FromBase16();

            var iter1e0 = "422c8e7a6227d7bca1350b3e2bb7279f7897b87bb6854b783c60e80311ae3079".FromBase16();
            var iter1e3 = "684cf59ba83309552800ef566f2f4d3c1c3887c49360e3875f2eb94d99532c51".FromBase16();
            var iter1e6 = "7c3911e0ab2586fd864497297e575e6f3bc601c0883c30df5f4dd2d24f665424".FromBase16();


            for (var i = 1; i <= 1000; i++) {
                Test22519(ref k, ref u);
                if (i == 1) {
                    Utilities.Assert.AssertEqual(k, iter1e0);
                    }
                if (i == 1000) {
                    Utilities.Assert.AssertEqual(k, iter1e3);
                    }
                }
            }

        void Test22519(ref byte[] kb, ref byte[] ub) {
            var k = CurveX25519.DecodeScalar(kb);
            var u = new CurveX25519(ub);

            ub = kb;
            kb = CurveX25519.EncodePoint(u.ScalarMultiply(k));


            }



        [Fact]
        public void X448TV1() {
            var inputScalar = ("3d262fddf9ec8e88495266fea19a34d28882acef045104d0d1aae121" +
                "700a779c984c24f8cdd78fbff44943eba368f54b29259a4f1c600ad3").FromBase16();
            var inputScalarInteger = ("599189175373896402783756016145213256157230856" +
                "085026129926891459468622403380588640249457727" +
                "683869421921443004045221642549886377526240828").DecimalToBigInteger();

            var inputCoordinateU = ("06fce640fa3487bfda5f6cf2d5263f8aad88334cbd07437f020f08f9" +
                "814dc031ddbdc38c19c6da2583fa5429db94ada18aa7a7fb4ef8a086").FromBase16();
            var inputCoordinateUInteger = ("382239910814107330116229961234899377031416365" +
                "240571325148346555922438025162094455820962429" +
                "142971339584360034337310079791515452463053830").DecimalToBigInteger();

            var outputCoordinateU = ("ce3e4ff95a60dc6697da1db1d85e6afbdf79b50a2412d7546d5f239f" +
                "e14fbaadeb445fc66a01b0779d98223961111e21766282f73dd96b6f").FromBase16();

            var decodedScalar = CurveX448.DecodeScalar(inputScalar);
            var inputPoint = new CurveX448(inputCoordinateU);
            var outputPoint = new CurveX448(outputCoordinateU);

            (decodedScalar == inputScalarInteger).AssertTrue();
            (inputCoordinateUInteger == inputPoint.U).AssertTrue();

            var output = inputPoint.ScalarMultiply(decodedScalar);

            (output == outputPoint.U).AssertTrue();
            }

        [Fact]
        public void X448TV2() {
            var inputScalar = ("203d494428b8399352665ddca42f9de8fef600908e0d461cb021f8c5" +
                "38345dd77c3e4806e25f46d3315c44e0a5b4371282dd2c8d5be3095f").FromBase16();
            var inputScalarInteger = ("633254335906970592779259481534862372382525155" +
                "252028961056404001332122152890562527156973881" +
                "968934311400345568203929409663925541994577184").DecimalToBigInteger();

            var inputCoordinateU = ("0fbcc2f993cd56d3305b0b7d9e55d4c1a8fb5dbb52f8e9a1e9b6201b" +
                "165d015894e56c4d3570bee52fe205e28a78b91cdfbde71ce8d157db").FromBase16();
            var inputCoordinateUInteger = ("622761797758325444462922068431234180649590390" +
                "024811299761625153767228042600197997696167956" +
                "134770744996690267634159427999832340166786063").DecimalToBigInteger();


            var outputCoordinateU = ("884a02576239ff7a2f2f63b2db6a9ff37047ac13568e1e30fe63c4a7" +
                "ad1b3ee3a5700df34321d62077e63633c575c1c954514e99da7c179d").FromBase16();

            var decodedScalar = CurveX448.DecodeScalar(inputScalar);
            var inputPoint = new CurveX448(inputCoordinateU);
            var outputPoint = new CurveX448(outputCoordinateU);

            (decodedScalar == inputScalarInteger).AssertTrue();
            (inputCoordinateUInteger == inputPoint.U).AssertTrue();

            var output = inputPoint.ScalarMultiply(decodedScalar);

            (output == outputPoint.U).AssertTrue();

            }

        [Fact]
        public void X448TV3() {
            var k = ("05000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000000000000").FromBase16();
            var u = ("05000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000000000000").FromBase16();

            var iter1e0 = ("3f482c8a9f19b01e6c46ee9711d9dc14fd4bf67af30765c2ae2b846a" +
                "4d23a8cd0db897086239492caf350b51f833868b9bc2b3bca9cf4113").FromBase16();
            var iter1e3 = ("aa3b4749d55b9daf1e5b00288826c467274ce3ebbdd5c17b975e09d4" +
                "af6c67cf10d087202db88286e2b79fceea3ec353ef54faa26e219f38").FromBase16();
            var iter1e6 = ("077f453681caca3693198420bbe515cae0002472519b3e67661a7e89" +
                "cab94695c8f4bcd66e61b9b9c946da8d524de3d69bd9d9d66b997e37").FromBase16();


            for (var i = 1; i <= 1000; i++) {
                Test448(ref k, ref u);
                if (i == 1) {
                    Utilities.Assert.AssertEqual(k, iter1e0);
                    }
                if (i == 1000) {
                    Utilities.Assert.AssertEqual(k, iter1e3);
                    }
                }
            }



        void Test448(ref byte[] kb, ref byte[] ub) {
            var k = CurveX448.DecodeScalar(kb);
            var u = new CurveX448(ub);
            var uu = u.U;

            ub = kb;

            var u2 = u.ScalarMultiply(k);
            kb = CurveX448.EncodePoint(u2);
            }


        [Fact]
        public void X25519AgreeX() {
            var a = "77076d0a7318a57d3c16c17251b26645df4c2f87ebc0992ab177fba51db92c2a".FromBase16();
            var publica = "8520f0098930a754748b7ddcb43ef75a0dbf3a0d26381af4eba4a98eaa9b4e6a".FromBase16();
            var b = "5dab087e624a8a4b79e17f8b83800ee66f3bb1292618b6fd1c2f8b27ff88e0eb".FromBase16();
            var publicb = "de9edb7d7b7dc1b4d35b61c2ece435373f8343c85b78674dadfc7e146f882b4f".FromBase16();

            var k = "4a5d9d5ba4ce2de1728e3bf480350f25e07e21c947d19e3376f09b3c1e161742".FromBase16();

            // test using cuve functions directly

            var scalarA = CurveX25519.DecodeScalar(a);
            var scalarB = CurveX25519.DecodeScalar(b);

            var pointA = new CurveX25519(publica);
            var pointB = new CurveX25519(publicb);

            var checkA = CurveX25519.Base.Multiply(scalarA);
            var checkB = CurveX25519.Base.Multiply(scalarB);

            (checkA == pointA).AssertTrue();
            (checkB == pointB).AssertTrue();

            var agreeAB = pointA.Multiply(scalarB);
            var agreeBA = pointB.Multiply(scalarA);


            (agreeAB == agreeBA).AssertTrue(String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeAB.Encode(), String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeBA.Encode(), String: "Unexpected agreement value");

            // test using key pairs


            }

        [Fact]
        public void X448AgreeX() {

            var a = ("9a8f4925d1519f5775cf46b04b5800d4ee9ee8bae8bc5565d498c28d" +
                "d9c9baf574a9419744897391006382a6f127ab1d9ac2d8c0a598726b").FromBase16();
            var publica = ("9b08f7cc31b7e3e67d22d5aea121074a273bd2b83de09c63faa73d2c" +
                "22c5d9bbc836647241d953d40c5b12da88120d53177f80e532c41fa0").FromBase16();
            var b = ("1c306a7ac2a0e2e0990b294470cba339e6453772b075811d8fad0d1d" +
                "6927c120bb5ee8972b0d3e21374c9c921b09d1b0366f10b65173992d").FromBase16();
            var publicb = ("3eb7a829b0cd20f5bcfc0b599b6feccf6da4627107bdb0d4f345b430" +
                "27d8b972fc3e34fb4232a13ca706dcb57aec3dae07bdc1c67bf33609").FromBase16();
            var k = ("07fff4181ac6cc95ec1c16a94a0f74d12da232ce40a77552281d282b" +
                "b60c0b56fd2464c335543936521c24403085d59a449a5037514a879d").FromBase16();

            // test using cuve functions directly

            var scalarA = CurveX448.DecodeScalar(a);
            var scalarB = CurveX448.DecodeScalar(b);

            var pointA = new CurveX448(publica);
            var pointB = new CurveX448(publicb);

            var checkA = CurveX448.Base.Multiply(scalarA);
            var checkB = CurveX448.Base.Multiply(scalarB);

            (checkA == pointA).AssertTrue();
            (checkB == pointB).AssertTrue();

            var agreeAB = pointA.Multiply(scalarB);
            var agreeBA = pointB.Multiply(scalarA);


            (agreeAB == agreeBA).AssertTrue(String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeAB.Encode(), String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeBA.Encode(), String: "Unexpected agreement value");

            }


        [Fact]
        public void KeyPairX25519AgreeX() {
            var a = "77076d0a7318a57d3c16c17251b26645df4c2f87ebc0992ab177fba51db92c2a".FromBase16();
            var publica = "8520f0098930a754748b7ddcb43ef75a0dbf3a0d26381af4eba4a98eaa9b4e6a".FromBase16();
            var b = "5dab087e624a8a4b79e17f8b83800ee66f3bb1292618b6fd1c2f8b27ff88e0eb".FromBase16();
            var publicb = "de9edb7d7b7dc1b4d35b61c2ece435373f8343c85b78674dadfc7e146f882b4f".FromBase16();

            var k = "4a5d9d5ba4ce2de1728e3bf480350f25e07e21c947d19e3376f09b3c1e161742".FromBase16();

            // test using cuve functions directly

            var scalarA = new CurveX25519Private(a);
            var scalarB = new CurveX25519Private(b);

            var pointA = new CurveX25519Public(publica);
            var pointB = new CurveX25519Public(publicb);



            var agreeAB = scalarB.Agreement(pointA);
            var agreeBA = scalarA.Agreement(pointB);


            (agreeAB == agreeBA).AssertTrue(String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeAB.Encode(), String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeBA.Encode(), String: "Unexpected agreement value");
            }


        [Fact]
        public void KeyPairX448AgreeX() {
            var a = ("9a8f4925d1519f5775cf46b04b5800d4ee9ee8bae8bc5565d498c28d" +
                "d9c9baf574a9419744897391006382a6f127ab1d9ac2d8c0a598726b").FromBase16();
            var publica = ("9b08f7cc31b7e3e67d22d5aea121074a273bd2b83de09c63faa73d2c" +
                "22c5d9bbc836647241d953d40c5b12da88120d53177f80e532c41fa0").FromBase16();
            var b = ("1c306a7ac2a0e2e0990b294470cba339e6453772b075811d8fad0d1d" +
                "6927c120bb5ee8972b0d3e21374c9c921b09d1b0366f10b65173992d").FromBase16();
            var publicb = ("3eb7a829b0cd20f5bcfc0b599b6feccf6da4627107bdb0d4f345b430" +
                "27d8b972fc3e34fb4232a13ca706dcb57aec3dae07bdc1c67bf33609").FromBase16();
            var k = ("07fff4181ac6cc95ec1c16a94a0f74d12da232ce40a77552281d282b" +
                "b60c0b56fd2464c335543936521c24403085d59a449a5037514a879d").FromBase16();

            // test using cuve functions directly

            var scalarA = new CurveX448Private(a);
            var scalarB = new CurveX448Private(b);

            var pointA = new CurveX448Public(publica);
            var pointB = new CurveX448Public(publicb);



            var agreeAB = scalarB.Agreement(pointA);
            var agreeBA = scalarA.Agreement(pointB);


            (agreeAB == agreeBA).AssertTrue(String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeAB.Encode(), String: "Unexpected agreement value");
            Utilities.Assert.AssertEqual(k, agreeBA.Encode(), String: "Unexpected agreement value");
            }


        [Theory]
        [InlineData(1000, 500)]
        [InlineData(1000, 50)]
        public void X448SignedMultiply(int totalIn, int partIn) {

            BigInteger total = totalIn;
            BigInteger part = partIn;


            var q = CurveX448.Base;
            var q1 = q.Multiply(part+1);

            var point = CurveX448.Base;
            CheckCurve(point);

            point.ScalarAccumulate(point.U, part, out var xq, out var zq, out var xq1, out var zq1);
            point.ScalarAccumulate(point.U, part+1, out var xq2, out var zq2, out _, out var _);

            var u0 = point.Recover(xq, zq);
            
            var u1 = point.Recover(xq1, zq1);
            var u2 = point.Recover(xq2, zq2);
            (u1 == u2).AssertTrue();
            (q1.U == u2).AssertTrue();

            var v0 = point.GetV(u0, true);
            var s = new CurveX448(u0, v0);
            var s1 = s.Add(point);

            (s1.U == u1).AssertTrue();

            var v1a = point.GetV(u1, true);
            var v1b = point.GetV(u1, false);


            var v1 = point.GetV(u1, !s1.V.IsEven);
            (s1.V == v1).AssertTrue();


            var p1 = point.Multiply(part);
            CheckCurve(p1);


            var p2 = point.Multiply(total - part);
            CheckCurve(p2);

            var p3 = p1.Add(p2);
            CheckCurve(p3);

            var p3test = point.Multiply(total);
            CheckCurve(p3test);

            (p3.U == p3test.U).AssertTrue();
            (p3.V == p3test.V).AssertTrue();
            }

        [Theory]
        [InlineData(1000, 500)]
        [InlineData(1000, 50)]
        public void X448SignedMultiplyFast(int totalIn, int partIn) {
            BigInteger total = totalIn;
            BigInteger part = partIn;

            var q = CurveX448.Base;
            var q1 = q.Multiply(part + 1);

            var point = CurveX448.Base;
            CheckCurve(point);

            point.ScalarAccumulate(point.U, part, out var xq, out var zq, out var xq1, out var zq1);
            point.ScalarAccumulate(point.U, part + 1, out var xq2, out var zq2, out _, out var _);

            var u0 = point.Recover(xq, zq);

            var u1 = point.Recover(xq1, zq1);
            var u2 = point.Recover(xq2, zq2);
            (u1 == u2).AssertTrue();
            (q1.U == u2).AssertTrue();

            var v0 = point.GetV(u0, true);
            var s = new CurveX448(u0, v0);
            var s1 = s.Add(point);

            (s1.U == u1).AssertTrue();

            var v1a = point.GetV(u1, true);
            var v1b = point.GetV(u1, false);


            var v1 = point.GetV(u1, !s1.V.IsEven);
            (s1.V == v1).AssertTrue();


            var p1 = point.MultiplySigned(part);
            CheckCurve(p1);


            var p2 = point.MultiplySigned(total - part);
            CheckCurve(p2);

            var p3 = p1.Add(p2);
            CheckCurve(p3);

            var p3test = point.MultiplySigned(total);
            CheckCurve(p3test);

            (p3.U == p3test.U).AssertTrue();
            (p3.V == p3test.V).AssertTrue();
            }


        void CheckCurve(CurveMontgomery curve) {
            bool? odd = ((curve.V) & 1) == 1;
            var vtest = curve.GetV(odd);

            (curve.V == vtest).AssertTrue();
            }

        /// <summary></summary>

        [Theory]
        [InlineData(1)]
        [InlineData(1000)]
        public void X25519Agree(int count) {
            for (var i = 0; i < count; i++) {
                var KeyA = new CurveX25519Private();
                var KeyB = new CurveX25519Private();

                var AgreeAB = KeyA.Agreement(KeyB.Public);
                var AgreeBA = KeyB.Agreement(KeyA.Public);

                (AgreeAB == AgreeBA).AssertTrue();
                }
            }


        [Theory]
        [InlineData(1)]
        [InlineData(1000)]
        public void X448Agree(int count) {
            for (var i = 0; i < count; i++) {

                var KeyA = new CurveX448Private();
                var KeyB = new CurveX448Private();

                var AgreeAB = KeyA.Agreement(KeyB.Public);
                var AgreeBA = KeyB.Agreement(KeyA.Public);

                (AgreeAB == AgreeBA).AssertTrue();
                }
            }





        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void X25519AgreeRecryption(int count) {
            for (int i = 0; i < count; i++) {
                TryX25519AgreeRecryption().AssertTrue();
                }
            }


        public bool TryX25519AgreeRecryption() {

            var KeyA = new CurveX25519Private();
            var KeyAPublic = KeyA.Public;

            var RecryptKeys = KeyA.MakeRecryptionKeySet(2);

            var Result = KeyAPublic.Agreement();

            CurveX25519[] Carry = new CurveX25519[2];
            Carry[0] = (RecryptKeys[0] as CurveX25519Private).Agreement(Result.Public);
            Carry[1] = (RecryptKeys[1] as CurveX25519Private).Agreement(Result.Public);

            var AgreeAB = KeyAPublic.Agreement(Carry);

            return (AgreeAB == Result.AgreementX25519);
            }



        }
    }
