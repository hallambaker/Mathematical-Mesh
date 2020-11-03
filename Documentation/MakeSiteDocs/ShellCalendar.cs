using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {
    public class ShellCalendar : ExampleSet {
        public List<ExampleResult> CalendarList2;

        public List<ExampleResult> CalendarAdd;
        public List<ExampleResult> CalendarGet;
        public List<ExampleResult> CalendarList;
        public List<ExampleResult> CalendarDelete;
        public List<ExampleResult> CalendarAuth;


        public const string CalendarFile1 = "CalendarEntry1.json";
        public const string CalendarFile2 = "CalendarEntry2.json";
        public const string CalendarID1 = "CalID1";
        public const string CalendarID2 = "CalID2";

        public ShellCalendar(CreateExamples createExamples) :
        base(createExamples) {
            CalendarAdd = testCLIAlice1.Example($"calendar add {CalendarFile1} {CalendarID1}",
                $"calendar add {CalendarFile2} {CalendarID2}");
            CalendarGet = testCLIAlice1.Example($"calendar get {CalendarID1}");
            CalendarList = testCLIAlice1.Example($"calendar list");

            CalendarDelete = testCLIAlice1.Example($"calendar delete {CalendarID1}",
                $"calendar list");

            }

        }
    }
