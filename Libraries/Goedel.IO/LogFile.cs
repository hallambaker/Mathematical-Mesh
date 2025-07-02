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

using System.Diagnostics;

namespace Goedel.IO;

public static class LogFile {

    public static bool Stack { get; } = false;

    public static TextWriter Log { get; } = "log.txt".OpenTextWriter();


    public static void Write(string text) {

        Log.WriteLine(text);
        Log.Flush();
        }

    public static void WriteLine(string text, bool trace=false) {

        if (trace | Stack) {
            WriteStack();
            }

        Write(text);
        }

    public static void WriteStack(string text) => WriteLine(text, true);

    public static void WriteStack() {
        var stackTrace = new StackTrace();

        Write($"Stacktrace");

        for (var i = 0; i < stackTrace.FrameCount; i++) {
            var frame = stackTrace.GetFrame(i);
            var method = frame.GetMethod();

            Write($"Stack {method.Name}");
            }

        }



    }
