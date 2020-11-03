using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellSequence : ExampleSet {

        public string TestContainer = "Container.dcon";
        public string TestContainerEncrypt = "ContainerEncrypt.dcon";
        public string TestContainerArchive = "ContainerArchive.dcon";
        public string TestContainerArchiveEnhance = "ContainerArchiveEncrypt.dcon";

        public string TestContainer2 = "Container2.dcon";
        public string TestContainerEncrypt2 = "ContainerEncrypt2.dcon";
        public string TestContainerArchive2 = "ContainerArchive2.dcon";
        public string TestContainerArchiveEnhance2 = "ContainerArchiveEncrypt2.dcon";

        public List<ExampleResult> ContainerCreate;
        public List<ExampleResult> ContainerCreateEncrypt;
        public List<ExampleResult> ContainerArchive;
        public List<ExampleResult> ContainerArchiveEnhance;
        public List<ExampleResult> ContainerArchiveVerify;
        public List<ExampleResult> ContainerArchiveExtractAll;
        public List<ExampleResult> ContainerArchiveExtractFile;

        public List<ExampleResult> ContainerAppend;
        public List<ExampleResult> ContainerDelete;
        public List<ExampleResult> ContainerIndex;
        public List<ExampleResult> ContainerArchiveCopy;
        public List<ExampleResult> ContainerArchiveCopyDecrypt;
        public List<ExampleResult> ContainerArchiveCopyPurge;

        public ShellSequence(CreateExamples createExamples) :
        base(createExamples) {
            ContainerCreate = testCLIAlice1.Example($"container create {TestContainer}");
            ContainerCreateEncrypt = testCLIAlice1.Example($"container create {TestContainerEncrypt} /encrypt={GroupService}");
            ContainerArchive = testCLIAlice1.Example($"container archive {TestContainerArchive} {TestDir1}");
            ContainerArchiveEnhance = testCLIAlice1.Example($"container create {TestContainerArchiveEnhance} {TestDir1}",
                                                            $"/encrypt={GroupService} /sign={AliceService1}");
            ContainerArchiveVerify = testCLIAlice1.Example($"container verify {TestContainerArchiveEnhance}");
            ContainerArchiveExtractAll = testCLIAlice1.Example($"container extract {TestContainer} {TestDir2}");
            ContainerArchiveExtractFile = testCLIAlice1.Example($"container extract {TestContainer} /file={TestFile4}");
            ContainerAppend = testCLIAlice1.Example($"container append {TestContainer} {TestFile1}" +
                                                            $"container append {TestContainer} {TestFile2}" +
                                                            $"container append {TestContainer} {TestFile3}");
            ContainerDelete = testCLIAlice1.Example($"container delete {TestContainer}  {TestFile2}");
            ContainerIndex = testCLIAlice1.Example($"container index {TestContainer}");
            ContainerArchiveCopy = testCLIAlice1.Example($"container copy {TestContainer2}");
            ContainerArchiveCopyDecrypt = testCLIAlice1.Example($"container copy {TestContainerArchiveEnhance} /decrypt");
            ContainerArchiveCopyPurge = testCLIAlice1.Example($"container copy {TestContainer2} /purge");

            }
        }
    }
