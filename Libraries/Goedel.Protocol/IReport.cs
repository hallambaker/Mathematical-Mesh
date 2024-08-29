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
//using Microsoft.Extensions.Logging;


namespace Goedel.Protocol;

/// <summary>
/// Reporting instance, report on the result.
/// </summary>
public interface IReport {
    /// <summary>
    /// The reporting mode, may be turned into flags.
    /// </summary>

    void Report(StringBuilder output, LogLevelSeverity reportMode);

    }

/// <summary>
/// Enumerated Log severity levels. This mirrors the .NET enumerated type
/// Microsoft.Extensions.Logging.LogLevel. Duplicated so as to avoid the 
/// need to import extension packages into every project.
/// </summary>
public enum LogLevelSeverity {

    ///<summary>Detailed description of transaction including full request and response.</summary> 
    Trace = 0,

    ///<summary>Brief description on transaction exit.</summary> 
    Debug = 1,

    ///<summary>Brief description on transaction exit.</summary> 
    Information = 2,

    ///<summary>Brief description on transaction start and exit.</summary> 
    Warning = 3,

    ///<summary>Record of changes written to service state.</summary> 
    Error = 4,

    ///<summary>Record of changes written to service state.</summary> 
    Critical = 5,


    ///<summary>No report</summary> 
    None = 6
    }