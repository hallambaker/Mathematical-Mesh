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

namespace Goedel.Protocol;

/// <summary>
/// Reporting instance, report on the result.
/// </summary>
public interface IReport {
    /// <summary>
    /// The reporting mode, may be turned into flags.
    /// </summary>

    void Report(StringBuilder output, ReportMode reportMode);

    }

/// <summary>
/// Enumerated reporting modes. These may be replaced by flags at a later date
/// to permit greater control.
/// </summary>
public enum ReportMode {

    ///<summary>No report</summary> 
    None,

    ///<summary>Brief description on transaction exit.</summary> 
    Brief,

    ///<summary>Brief description on transaction start and exit.</summary> 
    Event,

    ///<summary>Detailed description of transaction including full request and response.</summary> 
    Full,

    ///<summary>Record of changes written to service state.</summary> 
    State
    }