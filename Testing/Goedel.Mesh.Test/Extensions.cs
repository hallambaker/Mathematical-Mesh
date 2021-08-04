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

using Goedel.Mesh.Shell;

namespace Goedel.Mesh.Test {
    public static class Extensions {

        public static ResultPending GetResultPending(
                    this List<ExampleResult> Results,
                    int index = 0) => GetResult(Results, index) as ResultPending;
        public static ResultSent GetResultSent(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultSent;
        public static ResultReceived GetResultReceived(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultReceived;
        public static ResultEscrow GetResultEscrow(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultEscrow;
        public static ResultCreateAccount GetResultCreateAccount(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultCreateAccount;
        public static ResultHello GetResultHello(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultHello;
        public static ResultPIN GetResultPIN(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultPIN;
        public static ResultPublishDevice GetResultPublishDevice(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultPublishDevice;
        public static ResultConnect GetResultConnect(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultConnect;
        public static ResultFileDare GetResultFileDare(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultFileDare;

        public static ResultEntry GetResultEntry(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultEntry;
        //public static ResultComplete GetResultComplete(
        //    this List<ExampleResult> Results,
        //    int index = 0) => GetResult(Results, index) as ResultComplete;
        public static ResultDump GetResultDump(
            this List<ExampleResult> Results,
            int index = 0) => GetResult(Results, index) as ResultDump;
        public static Result GetResult(
            this List<ExampleResult> Results,
            int index = 0) {

            if (Results == null || index >= Results.Count) {
                return null;
                }

            return Results[index].Result;


            }


        }
    }
