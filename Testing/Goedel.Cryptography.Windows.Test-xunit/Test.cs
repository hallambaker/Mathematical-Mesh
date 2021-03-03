using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Cryptography.Windows;
using Goedel.Utilities;
using Goedel.Test;

namespace Goedel.XUnit {
    public partial class TestPlatformWindows : TestPlatform {

        public TestPlatformWindows() => Initialization.Initialized.TestTrue();


        }
    }
