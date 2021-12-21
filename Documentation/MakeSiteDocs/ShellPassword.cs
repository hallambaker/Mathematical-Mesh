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

public class ShellPassword : ExampleSet {
    public List<ExampleResult> PasswordAdd;
    public List<ExampleResult> PasswordGet;
    public List<ExampleResult> PasswordUpdate;
    public List<ExampleResult> PasswordList;
    public List<ExampleResult> PasswordDelete;
    public List<ExampleResult> PasswordAuth;

    public List<ExampleResult> PasswordList1;
    public List<ExampleResult> PasswordList2;
    public List<ExampleResult> PasswordSequence => CreateExamples.Concat(PasswordAdd, PasswordList, PasswordUpdate, PasswordGet);


    public const string PasswordAccount1 = "alice1";
    public const string PasswordValue1 = "password";
    public const string PasswordValue1a = "newpassword";
    public const string PasswordSite = "ftp.example.com";
    public const string PasswordAccount2 = "alice@example.com";
    public const string PasswordValue2 = "newpassword";
    public const string PasswordSite2 = "www.example.com";


    public ShellPassword(CreateExamples createExamples) :
                base(createExamples) {
        PasswordAdd = Alice1.Example(
            $"password add {PasswordSite} {PasswordAccount1} {PasswordValue1}",
            $"password add {PasswordSite2} {PasswordAccount2} {PasswordValue2}");
        PasswordList = Alice1.Example($"password list");
        PasswordUpdate = Alice1.Example($"password add {PasswordSite} {PasswordAccount1} {PasswordValue1a}");
        PasswordGet = Alice1.Example($"password get {PasswordSite}");
        PasswordDelete = Alice1.Example($"password delete {PasswordSite2}");

        }
    }
