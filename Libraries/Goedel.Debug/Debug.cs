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
using System;
using System.Diagnostics;

using Goedel.IO;

namespace Goedel.Debug;

/// <summary>
/// Class containing static helper methods. This should inherit from the Trace class
/// but that is sealed.
/// </summary>
public class Debug {


    /// <summary>
    /// Perform standard initialization
    /// </summary>
    public static void Initialization(bool TestMode = false) {
        Trace.Listeners.Add(new GoedelTraceListener());

        var TraceFileStream = "LastTrace.txt".OpenFileWriteShare();
        var TraceWriter = TraceFileStream.OpenTextWriter();
        Trace.Listeners.Add(new TextWriterTraceListener(TraceWriter));
        }

    /// <summary>
    /// Convenience method to do formatted write to the trace output
    /// </summary>
    /// <param name="Format">A composite format string </param>
    /// <param name="Arg">An array of objects to write using format</param>
    public static void WriteLine(string Format, params object[] Arg) {
        var Text = String.Format(Format, Arg);
        Trace.WriteLine(Text);
        }


    /// <summary>
    /// Convenience method to do formatted write to the trace output
    /// </summary>
    /// <param name="Format">A composite format string </param>
    /// <param name="Arg">An array of objects to write using format</param>
    public static void Write(string Format, params object[] Arg) {
        var Text = String.Format(Format, Arg);
        Trace.Write(Text);
        }

    }

/// <summary>
/// 
/// </summary>
public class GoedelTraceListener : TraceListener {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public override void Write(string message) => Console.Write(message);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    public override void WriteLine(string message) => Console.WriteLine(message);
    }
