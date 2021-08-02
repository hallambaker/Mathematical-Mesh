using Goedel.Cryptography.Windows;
using Goedel.Test;

namespace Goedel.XUnit {
    public partial class TestPlatformWindows : TestPlatform {

        public TestPlatformWindows() => Initialization.Initialized.TestTrue();


        }
    }
