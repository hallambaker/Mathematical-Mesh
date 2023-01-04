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

using Goedel.Registry;

namespace Goedel.Command;

/// <summary>
/// Information level to be returned in a result.
/// </summary>
public enum Verbosity {
    ///<summary>Minimal information, no additional text.</summary> 
    Terse,
    ///<summary>Standard descriptive result.</summary> 
    Standard,
    ///<summary>Verbose report with maximum information.</summary> 
    Full,
    ///<summary>Return output in JSON</summary> 
    Json,
    ///<summary>No output</summary> 
    None
    }




/// <summary>Track start and end time of parse.</summary>
public abstract class Dispatch{
    /// <summary>Record start time.</summary>
    public System.DateTime Started = System.DateTime.Now;

    /// <summary>Calculate elapsed time.</summary>
    public TimeSpan Elapsed => System.DateTime.Now - Started;

    /// <summary>Command type data</summary>
    public virtual Type[] _Data { get; set; }

    /// <summary>Command description</summary>
    public virtual DescribeCommandEntry DescribeCommand { get; set; }

    }

/// <summary>
/// Describe a shell.
/// </summary>
public abstract class DispatchShell : Dispatch {
#pragma warning disable IDE1006 // Naming Styles
    /// <summary>
    /// Method called before acommand is dispatched.
    /// </summary>
    /// <param name="dispatch">The options for the command dispatched.</param>
    public virtual void _PreProcess(Dispatch dispatch) { }


    ///<summary>Report flag, if <see langword="true"/> results of operations
    ///are reported to the console. Otherwise, no output is returned.</summary>
    public bool Report { get; set; }

    ///<summary>Verbose flag, if <see langword="true"/> verbose results of operations
    ///are reported to the console. Takes priority over <see cref="Report"/></summary>
    public Verbosity Verbosity { get; set; }

    ///<summary>Stream to write the output to.</summary> 
    public TextWriter Output { get; set; } = System.Console.Out;


    ///<summary>If false, catch exceptions and interpret as an error.</summary> 
    public bool NoCatch { get; init; }



    }