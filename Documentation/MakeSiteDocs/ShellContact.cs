using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellContact : ExampleSet {


        public List<ExampleResult> ContactAuth;
        public List<ExampleResult> ContactList2;


        public List<ExampleResult> ContactAdd;
        public List<ExampleResult> ContactAddSelf;
        public List<ExampleResult> ContactGet;
        public List<ExampleResult> ContactList;

        public List<ExampleResult> ContactDelete;



        public ShellContact(CreateExamples createExamples) :
                base(createExamples) {

            ContactAddSelf = testCLIAlice1.Example($"contact self email {AliceService1}");
            ContactAdd = testCLIAlice1.Example($"contact add email {CarolService}");
            ContactGet = testCLIAlice1.Example($"contact get {CarolService}");
            ContactList = testCLIAlice1.Example($"contact list");
            ContactDelete = testCLIAlice1.Example($"contact delete {CarolService}");

            }
        }
    }