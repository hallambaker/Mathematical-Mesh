
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;


namespace MeshStore.xunit {
    public partial class Phase2Tests {

        // Fails because the library doesn't support writing index to end of archive
        [Fact]
        public void TestContainerArchive() {
            var inputDir = @"..\CommonData";
            var output = @"CommonData.darch";
            var outputDir = @"CommonData";


            outputDir.DirectoryDelete();
            Dispatch($"container archive {inputDir} /out {output}");
            Dispatch($"container extract {output} {outputDir}");

            }

        /// <summary>
        /// Test encryption /decryption to self / other / group
        /// </summary>
        [Fact]
        public void TestContainerArchiveEncrypt() => throw new TestNotImplemented();

        /// <summary>
        /// Test success of signature verification.
        /// </summary>
        [Fact]
        public void TestContainerArchiveSign() => throw new TestNotImplemented();

        /// <summary>
        /// Test failure of signature verification.
        /// </summary>
        [Fact]
        public void TestContainerArchiveVerify() {
            ValidateContainer(null, null);
            CorruptArchive(null, 0, null);
            throw new TestNotImplemented();
            }


        [Fact]
        public void TestContainerArchiveExtractAll() => throw new TestNotImplemented();

        [Fact]
        public void TestContainerArchiveExtractFirst() => throw new TestNotImplemented();

        [Fact]
        public void TestContainerArchiveExtractLast() => throw new TestNotImplemented();

        [Fact]
        public void TestContainerArchiveExtractRandom() => throw new TestNotImplemented();

        [Fact]
        public void TestContainerArchiveAppend() => throw new TestNotImplemented();

        [Fact]
        public void TestContainerArchiveDelete() => throw new TestNotImplemented();

        [Fact]
        public void TestContainerArchiveList() => throw new TestNotImplemented();



        }
    }
