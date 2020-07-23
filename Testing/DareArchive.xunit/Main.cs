
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;


namespace MeshStore.xunit {
    public partial class Phase2Tests {
        string ServiceName = "example.com";
        TestCLI DefaultDevice => defaultDevice ?? GetTestCLI().CacheValue(out defaultDevice);
        TestCLI defaultDevice;

        public static Phase2Tests Test() => new Phase2Tests();


        ///<summary>The test environment, base for all </summary>
        public TestEnvironmentCommon TestEnvironment => testEnvironment ??
            new TestEnvironmentCommon().CacheValue(out testEnvironment);
        TestEnvironmentCommon testEnvironment;

        public Phase2Tests(string serviceName = null) =>
                    ServiceName = serviceName ?? ServiceName;

        public TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName);
            return new TestCLI(testShell);
            }

        public Result Dispatch(string command, bool fail = false) =>
                DefaultDevice.Dispatch(command, fail);



        ///<summary>Corrupt the archive at frame <paramref name="frame"/>
        ///with error <paramref name="error"/>.</summary>
        ///<param name="filename">The container to validate</param>
        ///<param name="frame">The position in the file at which to introduce the error.</param>
        ///<param name="error">The type of error to induce.</param>
        void CorruptArchive(string filename, int frame, string error) => throw new NYI();

        /// <summary>
        /// Validate the container <paramref name="filename"/> against the security
        /// policy 
        /// </summary>
        /// <param name="filename">The container to validate</param>
        /// <param name="policy">The security policy</param>
        void ValidateContainer(string filename, string policy) => throw new NYI();

        }
    }
