#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Collections.Generic;

using Goedel.Mesh.Test;

namespace ExampleGenerator;

public class ShellCalendar : ExampleSet {


    public List<ExampleResult> CalendarAdd;
    public List<ExampleResult> CalendarGet;
    public List<ExampleResult> CalendarList;
    public List<ExampleResult> CalendarDelete;
    public List<ExampleResult> CalendarAuth;
    public List<ExampleResult> CalendarList1;
    public List<ExampleResult> CalendarList2;

    public const string CalendarFile1 = "CalendarEntry1.json";
    public const string CalendarFile2 = "CalendarEntry2.json";
    public const string CalendarID1 = "CalID1";
    public const string CalendarID2 = "CalID2";

    public ShellCalendar(CreateExamples createExamples) :
    base(createExamples) {
        CalendarAdd = Alice1.Example($"calendar add {CalendarFile1} {CalendarID1}",
            $"calendar add {CalendarFile2} {CalendarID2}");
        CalendarGet = Alice1.Example($"~calendar get {CalendarID1}");
        CalendarList = Alice1.Example($"~calendar list");

        CalendarDelete = Alice1.Example($"~calendar delete {CalendarID1}",
            $"~calendar list");

        }

    }
