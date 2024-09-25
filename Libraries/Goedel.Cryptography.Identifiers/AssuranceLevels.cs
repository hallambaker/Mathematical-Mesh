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


namespace Goedel.Cryptography;


/// <summary>
/// Assurance levels for cryptographic algorithms
/// </summary>
public enum AssuranceLevel {
    ///<summary>No assurance whatsoever</summary> 
    None        = 0,

    ///<summary>64 bits quantum security</summary> 
    PQ64        = 0x01,
    ///<summary>64 bits quantum security</summary> 
    PQ80        = 0x02,
    ///<summary>64 bits quantum security</summary> 
    PQ96        = 0x03,
    ///<summary>64 bits quantum security</summary> 
    PQ128       = 0x04,
    ///<summary>64 bits quantum security</summary> 

    ///<summary>80 bits classical security strength</summary> 
    CC80        = 0x010,
    ///<summary>112 bits classical security strength</summary> 
    CC112       = 0x020,
    ///<summary>128 bits classical security strength</summary> 
    CC128       = 0x030,
    ///<summary>192 bits classical security strength</summary>    
    CC192       = 0x040,
    ///<summary>224 bits classical security strength</summary>  
    CC224       = 0x050,
    ///<summary>256 bits classical security strength</summary>  
    CC256       = 0x060,

    ///<summary>128 bits classical security strength, 64 bits quantum security</summary> 
    PQC1        = CC128 | PQ64,
    ///<summary>128 bits classical security strength, 80 bits quantum security</summary> 
    PQC2        = CC128 | PQ80,
    ///<summary>192 bits classical security strength, 96 bits quantum security</summary> 
    PQC3        = CC192 | PQ96,
    ///<summary>192 bits classical security strength, 128 bits quantum security</summary> 
    PQC4        = CC192 | PQ128,
    ///<summary>256 bits classical security strength, 128 bits quantum security</summary> 
    PQC5        = CC256 | PQ128,

    ///<summary>Mask to return the conventional assurance level</summary> 
    ConventionalMask = 0xf0,

    ///<summary>Mask to return the quantum assurance level</summary> 
    QuantumMask = 0x0f,
    ///<summary></summary> 
    Unkown      = -1



    }


