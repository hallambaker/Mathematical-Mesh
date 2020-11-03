using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellPassword : ExampleSet {
        public List<ExampleResult> PasswordAdd;
        public List<ExampleResult> PasswordGet;
        public List<ExampleResult> PasswordUpdate;
        public List<ExampleResult> PasswordList;
        public List<ExampleResult> PasswordDelete;
        public List<ExampleResult> PasswordAuth;
        public List<ExampleResult> PasswordSequence => CreateExamples.Concat(PasswordAdd, PasswordList, PasswordUpdate, PasswordGet);


        public const string PasswordAccount1 = "alice1";
        public const string PasswordValue1 = "password";
        public const string PasswordValue1a = "newpassword";
        public const string PasswordSite = "ftp.example.com";
        public const string PasswordAccount2 = "alice@example.com";
        public const string PasswordValue2 = "newpassword";
        public const string PasswordSite2 = "www.example.com";


        public List<ExampleResult> PasswordList2;

        public ShellPassword(CreateExamples createExamples) :
                    base(createExamples) {
            PasswordAdd = testCLIAlice1.Example(
                $"password add {PasswordSite} {PasswordAccount1} {PasswordValue1}",
                $"password add {PasswordSite2} {PasswordAccount2} {PasswordValue2}");
            PasswordList = testCLIAlice1.Example($"password list");
            PasswordUpdate = testCLIAlice1.Example($"password add {PasswordSite} {PasswordAccount1} {PasswordValue1a}");
            PasswordGet = testCLIAlice1.Example($"password get {PasswordSite}");
            PasswordDelete = testCLIAlice1.Example($"password delete {PasswordSite2}");

            }
        }
    }
