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

            ContactAddSelf = Alice1.Example($"contact self email {AliceService1}");
            ContactAdd = Alice1.Example($"contact add email {CarolService}");
            ContactGet = Alice1.Example($"contact get {CarolService}");
            ContactList = Alice1.Example($"contact list");
            ContactDelete = Alice1.Example($"contact delete {CarolService}");

            }
        }
    }