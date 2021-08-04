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

namespace ExampleGenerator {
    public class ShellAccount : ExampleSet {
        public List<ExampleResult> ConnectRequest;
        public List<ExampleResult> ConnectRequestMallet;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectSync;
        public List<ExampleResult> ConnectPending2;
        public List<ExampleResult> ConnectReject;
        public List<ExampleResult> ConnectGetPin;
        public List<ExampleResult> ConnectPin;
        public List<ExampleResult> ConnectSyncPIN;
        public List<ExampleResult> ConnectPending3;

        public List<ExampleResult> ConnectEarlPrep;

        public List<ExampleResult> ConnectList;
        public List<ExampleResult> ConnectDelete;

        public List<ExampleResult> DeviceEarl1;
        public List<ExampleResult> DeviceEarl2;
        public List<ExampleResult> DeviceEarl3;
        public List<ExampleResult> DeviceEarl4;

        public List<ExampleResult> DeviceCreate;
        public string DeviceCreateUDF;
        public string DeviceCreateHTTP;


        public ShellAccount(CreateExamples createExamples) :
                base(createExamples) {

            }
        }
    }
