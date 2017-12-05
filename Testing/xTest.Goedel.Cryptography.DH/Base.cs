using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GU=Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;

namespace Goedel.Cryptography.Test {
    [TestClass]
    public partial class TestCryptography {

        static DHKeyPair AliceKeyPair;
        static DHKeyPair BobKeyPair;
        static DHKeyPair GroupKeyPair;

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

            AliceKeyPair = new DHKeyPair(AlicePrivate);
            BobKeyPair = new DHKeyPair(BobPrivate);
            GroupKeyPair = new DHKeyPair(GroupPrivate);

            AlicePublic = AlicePrivate.DiffeHellmanPublic;
            BobPublic = BobPrivate.DiffeHellmanPublic;
            GroupKeyPublic = GroupPrivate.DiffeHellmanPublic;
            }


        }
    }
