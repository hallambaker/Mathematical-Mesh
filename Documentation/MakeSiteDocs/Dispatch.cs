using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Command;
using ExampleGenerator;
using Goedel.Mesh;


namespace ExampleGenerator {
    public partial class MakeSiteDocs {

        public override void DefaultCommand (DefaultCommand Options) {
            Goedel.IO.Debug.Initialize();
            //Mesh.Initialize(true);



            var CreateExamples = new CreateExamples();

            Directory.CreateDirectory("UserGuide\\Mesh");
            Directory.CreateDirectory("UserGuide\\Apps");
            Directory.CreateDirectory("UserGuide\\Platform");
            ExampleGenerator.UserGuideCreate(CreateExamples);
            ExampleGenerator.UserGuide(CreateExamples);
            ExampleGenerator.ExampleSession(CreateExamples);

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


            // This MUST be the last file created so that it can include the entries created 
            // in the others.
            ExampleGenerator.ToDo(CreateExamples);
            }



        }
    }
