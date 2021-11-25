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

public class ShellGroup : ExampleSet {



    public List<ExampleResult> GroupCreate;
    public List<ExampleResult> GroupDecryptAlice;
    public List<ExampleResult> GroupAdd;
    public List<ExampleResult> GroupDecryptBob2;
    public List<ExampleResult> GroupList1;
    public List<ExampleResult> GroupDelete;
    public List<ExampleResult> GroupDecryptBob3;
    public List<ExampleResult> GroupList2;
    public List<ExampleResult> GroupEncrypt;



    public ShellGroup(CreateExamples createExamples) :
        base(createExamples) {

        //GroupCreate = testCLIAlice1.Example($"group create {GroupService}");
        //GroupEncrypt = testCLIBob1.Example(
        //            $"dare encode{TestFile1} {TestFile1Group} /encrypt={GroupService}",
        //            $"dare decode  {TestFile1Group}");
        //GroupDecryptAlice = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
        //GroupAdd = testCLIAlice1.Example($"group add {GroupService} {BobService}");
        //GroupDecryptBob2 = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
        //GroupList1 = testCLIAlice1.Example($"group list {GroupService}");
        //GroupDelete = testCLIAlice1.Example($"group delete {GroupService} {BobService}");
        //GroupDecryptBob3 = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
        //GroupList2 = testCLIAlice1.Example($"group list {GroupService}");

        }


    }
