using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;


using Goedel.Discovery;
using Goedel.Utilities;
using Goedel.Test;

namespace Goedel.DNS.Test{
    [MT.TestClass]
    public partial class ServiceDiscovery {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();
            var Instance = new ServiceDiscovery();

            Instance.TestDNS();

            }



        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) => InitializeClass();

        public static void InitializeClass() {


            }
        }


    }
