using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Command;
using ExampleGenerator;


namespace ExampleGenerator {
    public partial class MakeSiteDocs {

        public override void DefaultCommand (DefaultCommand Options) {

            var CreateExamples = new CreateExamples();

            Directory.CreateDirectory("Mesh");
            Directory.CreateDirectory("Apps");
            Directory.CreateDirectory("Platform");

            ExampleGenerator.UserGuide(CreateExamples);

            ExampleGenerator.UserGuideApps(CreateExamples);

            ExampleGenerator.UserGuideSSH(CreateExamples);
            ExampleGenerator.UserGuideRecrypt(CreateExamples);
            ExampleGenerator.UserGuideCredential(CreateExamples);
            ExampleGenerator.UserGuideConfirm(CreateExamples);
            ExampleGenerator.UserGuideMail(CreateExamples);

            ExampleGenerator.UserGuideMesh(CreateExamples);

            ExampleGenerator.UserGuideServer(CreateExamples);
            ExampleGenerator.UserGuideQuickStart(CreateExamples);
            ExampleGenerator.UserGuideDisaster(CreateExamples);
            ExampleGenerator.UserGuideConnecting(CreateExamples);


            ExampleGenerator.UserGuidePlatform(CreateExamples);
            ExampleGenerator.UserGuideLinux(CreateExamples);
            ExampleGenerator.UserGuideDocker(CreateExamples);
            ExampleGenerator.UserGuideWindows(CreateExamples);
            ExampleGenerator.UserGuideOSX(CreateExamples);
            }



        }


    }
