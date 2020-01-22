using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace ExampleGenerator {






    public partial class CreateExamples {


        public byte[] Enhance(
                    byte[] MasterSecret,
                    byte[] Plaintext,
                    byte[] Salt = null) {

            Salt ??= Goedel.Cryptography.Platform.GetRandomBits(128);
            var CryptoStack = new CryptoStack(encryptID: CryptoAlgorithmID.AES256CBC) {
                Salt = Salt ?? Goedel.Cryptography.Platform.GetRandomBits(128),
                MasterSecret = MasterSecret
                };
            return CryptoStack.EncodeEDS(Plaintext, null);
            }



        //public static string NameAccount = "alice";
        //public static string NameService = "example.com";


        //public static string Device1Name = "AliceDesktop";
        //public static string Device1Description = "A desktop computer built by Acme Computer Co.";

        //public static string Device2Name = "AliceRing";
        //public static string Device2Description = "A wearable ring computer";

        //public static string Device3Name = "AliceLaptop";
        //public static string Device3Description = "A laptop computer";



        //public string Device1(string Command) => Device1(Command, out var _);
        //public string Device1(string Command, out string Tag) {
        //    Tag = Label(Command);
        //    throw new NYI();

        //    }


        //public string Device2(string Command, out string Tag) {
        //    Tag = Label(Command);
        //    throw new NYI();
        //    //return Shell2.Dispatch(Command);
        //    }

        ////public Shell Shell3 = new Shell() {
        ////    MeshMachine = new MeshMachineCached(),
        ////    DefaultDescription = Device3Description
        ////    };
        //public string Device3(string Command, out string Tag) {
        //    Tag = Label(Command);
        //    throw new NYI();
        //    //return Shell3.Dispatch(Command);
        //    }

        ////static int Count = 0;
        //string Label(string Command) => throw new NYI();
        //    //var Tag = Count++.ToString();
        //    //Portal.Label(Tag);
        //    //Portal.Traces.Current.Command = Command;
        //    //return Tag;


        //public string LabelValidate;
        //public string LabelCreatePersonal;
        //public string CommandValidate;

        ///// <summary>
        ///// Create a new profile for alice@example.com
        ///// </summary>
        //void CreateProfile() {
        //    Device1("keygen");


        //    // check that the name is available
        //    Device1("verify test@prismproof.org", out LabelValidate);

        //    // create the profile
        //    Device1("personal create test@prismproof.org \\id=" + Device1Name, out LabelCreatePersonal);
        //    }


        //public string LabelConnectRequest;
        //public string LabelConnectPending;
        //public string LabelConnectAccept;
        //public string LabelConnectComplete;
        ///// <summary>
        ///// Add a second device
        ///// </summary>
        //void ConnectDevice() {

        //    // Connect the second device
        //    Device2("connect start test@prismproof.org", out LabelConnectRequest);
        //    //var Authenticator = (Shell2.LastResult as ResultConnectStart).Authenticator;

        //    Device1("connect pending", out LabelConnectPending);
        //    //Device1("connect accept " + Authenticator, out LabelConnectAccept);
        //    Device2("connect Complete", out LabelConnectComplete);
        //    }


        //public string LabelApplicationWeb1;
        //public string LabelApplicationWeb2;
        //public string LabelApplicationWeb3;
        //public string LabelApplicationWeb4;
        //public string LabelApplicationWeb5;


        //public string LabelApplicationProfile;


        ////SSHProfile SSHProfile;

        ///// <summary>
        ///// Create a SSH credential profile.
        ///// </summary>
        //void AddApplicationSSH() {
        //    Device1("keygen"); // Generate a password for the later pieces 

        //    Device1("ssh create");

        //    Device1("ssh public ");
        //    Device1("ssh private");

        //    Device1("ssh known");
        //    Device1("ssh add ssh1.example.com rsa AAAA1234");
        //    Device1("ssh known");

        //    }

        ///// <summary>
        ///// Create a SSH credential profile.
        ///// </summary>
        //void AddApplicationMail() => throw new NYI();



        //public string LabelEscrow = "Publish escrow";
        //public string LabelRecover = "Recover";



        }
    }
