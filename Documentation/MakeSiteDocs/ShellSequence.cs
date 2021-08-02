using System.Collections.Generic;

using Goedel.Mesh.Test;

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
            ContainerCreate = Alice1.Example($"container create {TestContainer}");
            ContainerCreateEncrypt = Alice1.Example($"container create {TestContainerEncrypt} /encrypt={GroupAccount}");
            ContainerArchive = Alice1.Example($"container archive {TestContainerArchive} {TestDir1}");
            ContainerArchiveEnhance = Alice1.Example($"container create {TestContainerArchiveEnhance} {TestDir1}",
                                                            $"/encrypt={GroupAccount} /sign={AliceAccount}");
            ContainerArchiveVerify = Alice1.Example($"container verify {TestContainerArchiveEnhance}");
            ContainerArchiveExtractAll = Alice1.Example($"container extract {TestContainer} {TestDir2}");
            ContainerArchiveExtractFile = Alice1.Example($"container extract {TestContainer} /file={TestFile4}");
            ContainerAppend = Alice1.Example($"container append {TestContainer} {TestFile1}" +
                                                            $"container append {TestContainer} {TestFile2}" +
                                                            $"container append {TestContainer} {TestFile3}");
            ContainerDelete = Alice1.Example($"container delete {TestContainer}  {TestFile2}");
            ContainerIndex = Alice1.Example($"container index {TestContainer}");
            ContainerArchiveCopy = Alice1.Example($"container copy {TestContainer2}");
            ContainerArchiveCopyDecrypt = Alice1.Example($"container copy {TestContainerArchiveEnhance} /decrypt");
            ContainerArchiveCopyPurge = Alice1.Example($"container copy {TestContainer2} /purge");

            }
        }
    }
