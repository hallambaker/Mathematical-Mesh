using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using GU=Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Test;

namespace Goedel.Cryptography.DH.Test {
    [TestClass]
    public partial class TestCryptography {

        static KeyPairDH AliceKeyPair;
        static KeyPairDH BobKeyPair;
        static KeyPairDH GroupKeyPair;

        static DiffeHellmanPrivate AlicePrivate;
        static DiffeHellmanPrivate BobPrivate;
        static DiffeHellmanPrivate GroupPrivate;

        static DiffeHellmanPublic AlicePublic;
        static DiffeHellmanPublic BobPublic;
        static DiffeHellmanPublic GroupKeyPublic;


        const CryptoAlgorithmID CryptoAlgorithmID = Goedel.Cryptography.CryptoAlgorithmID.DH;

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();

            var Instance = new TestCryptography();

            Instance.TestDH_Encrypt();

            }

        [AssemblyInitialize]
        public static void Initialize(TestContext Context) => InitializeClass();

        public static void InitializeClass() {
            CryptographyWindows.Initialize();

            AlicePrivate = new DiffeHellmanPrivate();
            BobPrivate = new DiffeHellmanPrivate();
            GroupPrivate = new DiffeHellmanPrivate();

            AliceKeyPair = new KeyPairDH(AlicePrivate);
            BobKeyPair = new KeyPairDH(BobPrivate);
            GroupKeyPair = new KeyPairDH(GroupPrivate);

            AlicePublic = AlicePrivate.DiffeHellmanPublic;
            BobPublic = BobPrivate.DiffeHellmanPublic;
            GroupKeyPublic = GroupPrivate.DiffeHellmanPublic;
            }


        }
    }
