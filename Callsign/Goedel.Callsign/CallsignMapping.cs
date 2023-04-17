//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Utilities;

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Goedel.Callsign;


/// <summary>
/// Maintains a collection of callsign mapping pages that map a callsign to a value. 
/// </summary>
public partial class CallsignMapping {
    #region // Properties


    ///<summary>List of callsign code pages.</summary> 
    public List<Page> Pages { get; } = new();

    ///<summary>Dictionary mapping page name to page.</summary> 
    public Dictionary<string, Page> PageDictionary = new();

    ///<summary>The default callsign mapping.</summary> 
    public static CallsignMapping Default => defaultMapping ?? 
            new CallsignMapping(true).CacheValue (out defaultMapping);
    static CallsignMapping defaultMapping = null;


    ///<summary>List of variant characters specified in the code page.</summary> 
    SortedList<int, CharacterSpan> VariantList { get; set; }


    #endregion
    #region // Constructors

    /// <summary>
    /// Constructor returning a callsign mapping instance. 
    /// </summary>
    public CallsignMapping(bool loadDefaults = false) {

        if (loadDefaults) {
            var pages = Page.LoadResources();
            foreach (var page in pages) {
                Pages.Add(page);
                }
            MakeIndex();
            }
        }

    #endregion
    #region // Implement Inteface $$$
    #endregion
    #region // Override Methods
    #endregion
    #region // Methods

    /// <summary>
    /// Strip the leading @ off a callsign if present.
    /// </summary>
    /// <param name="callsign">The callsign to strip</param>
    /// <returns>The stripped callsign.</returns>
    public static string Strip(string callsign) =>
        callsign[0] == '@' ? callsign.Substring(1) : callsign;


    /// <summary>
    /// Validate the callsign binding <paramref name="callsignBinding"/> for consistency of the
    /// presentation value according to the mapping rules specified.
    /// </summary>
    /// <param name="callsignBinding">The callsign binding to verify.</param>
    /// <returns>True if the mapping is valid, otherwise false.</returns>
    public bool Validate(CallsignBinding callsignBinding) {
        "Implement callsign binding validation logic".TaskValidate();

        return true;
        }

    /// <summary>
    /// Add the code page <paramref name="page"/>
    /// </summary>
    /// <param name="page">The code page to add.</param>
    public void AddPage(Page page) => Pages.Add(page);


    /// <summary>
    /// Create an index over the code page.
    /// </summary>
    public void MakeIndex() {
        var variantList = new SortedList<int, CharacterSpan>();

        foreach (var page in Pages) {
            PageDictionary.Add(page.Id, page);
            foreach (var characterSpan in page.CharacterSpans) {
                variantList.Add(characterSpan.First ?? 0, characterSpan);
                }
            }
        foreach (var page in Pages) {
            page.Expand(PageDictionary);
            }
        VariantList = variantList;
        }

    /// <summary>
    /// Strip the callsign presentation <paramref name="presentation"/> and
    /// return the canonicalized form.
    /// </summary>
    /// <param name="presentation">The presentation of the callsign.</param>
    /// <returns>The stripped, canonical form of <paramref name="presentation"/>.</returns>
    public string CanonicalizeStripped(string presentation) =>
        Canonicalize(Strip(presentation));

    /// <summary>
    /// Return the canonical form of the page <paramref name="presentation"/> according
    /// to the code page settings.
    /// </summary>
    /// <param name="presentation">The presentation to canonicalize</param>
    /// <returns>The canonical form of <paramref name="presentation"/>.</returns>
    /// <exception cref="InvalidCharacter">A character is invalid</exception>
    public string Canonicalize(string presentation) {
        var builder = new StringBuilder();

        foreach (var c in presentation) {
            IsAllowed(c, out var characterSpan).AssertTrue(InvalidCharacter.Throw, c);

            switch (characterSpan) {

                case MapChar mapChar: {
                    builder.Append((char) (c + mapChar.Target - mapChar.First));

                    break;
                    }
                case MapString mapString: {
                    builder.Append(mapString.Target);
                    break;
                    }
                default: {
                    builder.Append(c);
                    break;
                    }
                }
            }

        //Screen.WriteLine($"{presentation} -> {builder.ToString()}");

        return builder.ToString();
        }

    /// <summary>
    /// Check to see if <paramref name="presentation"/> is valid within 
    /// the character page <paramref name="pageName"/> returning true is
    /// so and false otherwise.
    /// </summary>
    /// <param name="presentation">The presentation to check</param>
    /// <param name="pageName">Name of the page to check.</param>
    /// <returns>True if <paramref name="presentation"/> is valid within
    /// <paramref name="pageName"/>, otherwise false.</returns>
    public bool CheckPage(string presentation, string pageName) {
        var hasNonDigit = false;

        if (!PageDictionary.TryGetValue(pageName, out var page)) {
            return false;
            }

        foreach (var c in presentation) {
            if (!CheckPage(c, page)) {
                return false;
                }
            hasNonDigit |= !Char.IsDigit(c);
            }

        return hasNonDigit;
        }

    /// <summary>
    /// Check to see if <paramref name="c"/>is valid within 
    /// the character page <paramref name="page"/> returning true is
    /// so and false otherwise.
    /// </summary>
    /// <param name="c">The character to check</param>
    /// <param name="page">The page to check.</param>
    /// <returns>True if <paramref name="c"/> is valid within
    /// <paramref name="page"/>, otherwise false.</returns>
    public static bool CheckPage(char c, Page page) {

        if (page.IsAllowed(c)) {
            return true;
            }
        foreach (var subPage in page.SubPages) {
            if (subPage.Value.IsAllowed(c)) {
                return true;
                }
            }

        return false;
        }


    /// <summary>
    /// Returns true if the character <paramref name="c"/> is permitted
    /// in the character span <paramref name="characterSpan"/>. Otherwise,
    /// an exception is thrown.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="characterSpan"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public bool IsAllowed(char c, out CharacterSpan characterSpan) {
        characterSpan = null;
        foreach (var span in VariantList) {
            if (span.Value.First > c) {
                return false;
                }

            var last = span.Value.Last > 0 ? span.Value.Last : span.Value.First;

            if (span.Value.First <= c & last >= c) {
                characterSpan = span.Value;
                return true;
                }
            }
        return false;
        }

    #endregion


    }



