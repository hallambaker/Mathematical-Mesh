using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GU=Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Cryptography.Test {
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

        [AssemblyInitialize]
        public static void Initialize (TestContext Context) {
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
