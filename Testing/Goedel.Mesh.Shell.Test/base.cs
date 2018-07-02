using System;
using Goedel.Mesh.Shell;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goedel.Mesh.Shell.Test {
    [MT.TestClass]
    public class MeshShellTests {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();

            var Instance = new MeshShellTests();
            Instance.TestMethod1();
            //Instance.TestInstanceB();
            }

        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) => InitializeClass();
        public static void InitializeClass() {

            }

        [MT.TestMethod]
        public void TestMethod1() {
            }


        }
    }
