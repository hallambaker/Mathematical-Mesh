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

namespace Goedel.Cryptography.KeyFile;

/// <summary>
/// Read a PEM style private key file (unencrypted)
/// </summary>
public partial class KeyFileLex {
    int armor1 = 0;
    int armor2 = 0;
    int armor3 = 0;
    int armor4 = 0;
    readonly StringBuilder buildTag1 = new();
    readonly StringBuilder buildTag2 = new();
    readonly StringBuilder buildBase64 = new();

    //StringBuilder BuildHeader = new StringBuilder();

    /// <summary>List of headers</summary>
    public List<Header> Headers = new();
    Header currentHeader;

    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Reset(int c) {
        }

    /// <summary>
    /// Count the inital staring armor tag
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Count1(int c) => armor1++;

    /// <summary>
    /// Count the inital finishing armor tag;
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Count2(int c) => armor2++;

    /// <summary>
    /// Count the final staring armor tag;
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Count3(int c) => armor3++;

    /// <summary>
    /// Count the final finishing armor tag;
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Count4(int c) => armor4++;

    /// <summary>
    /// Record the initial item description
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Tag1(int c) {
        if (!c.IsWhite()) {
            buildTag1.Append(c.ToASCII());
            }
        }

    /// <summary>
    /// Record the encoded data
    /// </summary>
    /// <param name="c">Character that was read</param> 
    public virtual void Base64(int c) {
        if (c.IsBase64()) {
            buildBase64.Append(c.ToASCII());
            }
        }

    /// <summary>
    /// Record the final item description
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Tag2(int c) {
        if (!c.IsWhite()) {
            buildTag2.Append(c.ToASCII());
            }
        }

    readonly StringBuilder BuildTagBegin = new();

    /// <summary>
    /// Verify the initial BEGIN tag
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void Begin(int c) {
        if (!c.IsWhite()) {
            BuildTagBegin.Append(c.ToASCII());
            }
        }

    readonly StringBuilder buildTagEnd = new();
    /// <summary>
    /// Verify the final End tag
    /// </summary>
    /// <param name="c">Character that was read</param>
    public virtual void End(int c) {
        if (!c.IsWhite()) {
            buildTagEnd.Append(c.ToASCII());
            }
        }

    /// <summary>
    /// Add character to tag
    /// </summary>
    /// <param name="c">Character value to add</param>
    public virtual void AddTag(int c) {
        }

    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="c">Character value read</param>
    public virtual void Abort(int c) {
        }

    readonly StringBuilder buildHeaderValue = new();
    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="c">Character value read</param>
    public virtual void StartHeader(int c) {
        currentHeader = new Header() {
            Tag = buildBase64.ToString()
            };
        Headers.Add(currentHeader);
        buildBase64.Clear();
        }

    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="c">Character value read</param>
    public virtual void HeaderAdd(int c) => buildHeaderValue.Append(c.ToASCII());

    /// <summary>
    /// Do nothing
    /// </summary>
    /// <param name="c">Character value read</param>
    public virtual void CopyHeader(int c) {
        currentHeader.Value = buildHeaderValue.ToString();
        buildHeaderValue.Clear();
        }




    /// <summary>
    /// Process tagged data
    /// </summary>
    /// <returns>Summary of tagged data.</returns>
    public TaggedData GetTaggedData() {
        bool Strict = armor1 == armor2 & armor1 == armor3 &
            armor1 == armor4;
        string Tag = buildTag1.ToString();

        Strict &= Tag == buildTag2.ToString() & BuildTagBegin.ToString() == "BEGIN" &
            buildTagEnd.ToString() == "END";

        var Base64Data = buildBase64.ToString();
        var Data = BaseConvert.FromBase64(Base64Data);

        var Result = new TaggedData {
            Strict = Strict,
            Count = armor1,
            Tag = Tag,
            Data = Data,
            Headers = Headers
            };

        return Result;
        }

    }

/// <summary>Tagged data from file</summary>
public class TaggedData {
    /// <summary>If true the file is strictly compliant with the PEM spec,
    /// the number of dashes at the start and end of the header and footer
    /// armor match.</summary>
    public bool Strict;
    /// <summary>Number of dashes counted</summary>
    public int Count;
    /// <summary>The tag (excluding BEGIN or END)</summary>
    public string Tag;
    /// <summary>The tagged data converted from Base64.</summary>
    public byte[] Data;

    /// <summary>Listy of header values</summary>
    public List<Header> Headers;
    }

/// <summary>Header value</summary>
public class Header {

    /// <summary>The header tag</summary>
    public string Tag;

    /// <summary>The header value</summary>
    public string Value;


    }
