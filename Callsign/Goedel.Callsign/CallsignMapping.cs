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

namespace Goedel.Callsign;


public record CallSign {

    public CallsignMapping CallsignMapping { get; init; }

    public string Id { get; set; }
    public string Presentation { get; set; }
    }

public partial class CallsignMapping {
    #region // Properties

    public string Id { get; set; }
    public string Presentation { get; set; }


    ///<summary>List of callsign code pages.</summary> 
    public static List<Page> Pages { get; } = new();

    ///<summary>List of variant characters specified in the code page.</summary> 
    static SortedList<int, CharacterSpan> VariantList { get; set; }


    #endregion
    #region // Constructors




    /// <summary>
    /// Constructor returning a callsign instance. If the parameter <paramref name="presentation"/>
    /// is not null, the presentation value of the callsign is set to the specified value.
    /// </summary>
    /// <param name="presentation">The presentation value to be set.</param>
    public CallsignMapping(string presentation = null) {
        if (presentation != null) {
            SetPresentation(presentation);
            }


        }

    #endregion
    #region // Implement Inteface $$$
    #endregion
    #region // Override Methods
    #endregion
    #region // Methods


    public bool Validate(CallsignBinding callsignBinding) {
        "Implement callsign binding validation logic".TaskValidate();

        return true;

        }


    /// <summary>
    /// Set the presentation value of the callsign. 
    /// </summary>
    /// <param name="presentation">The presentation value to be set.</param>
    /// <exception cref="InvalidPresentation">The presentation is invalid</exception>
    public void SetPresentation(string presentation) {
        presentation.AssertNotNull(InvalidPresentation.Throw, presentation, Id);

        if (Id == null) {
            Id = Canonicalize(presentation);
            }
        else {
            Id.AssertEqual(Canonicalize(presentation), InvalidPresentation.Throw);
            }

        Presentation = presentation;
        }

    /// <summary>
    /// Add the code page <paramref name="page"/>
    /// </summary>
    /// <param name="page">The code page to add.</param>
    public static void AddPage(Page page) => Pages.Add(page);


    /// <summary>
    /// Create an index over the code page.
    /// </summary>
    public static void MakeIndex() {
        var variantList = new SortedList<int, CharacterSpan>();

        foreach (var page in Pages) {
            foreach (var characterSpan in page.CharacterSpans) {
                variantList.Add(characterSpan.First??0, characterSpan);
                }
            }

        VariantList = variantList;
        }

    /// <summary>
    /// Return the canonical form of the page <paramref name="presentation"/> according
    /// to the code page settings.
    /// </summary>
    /// <param name="presentation">The presentation to canonicalize</param>
    /// <returns>The canonical form of <paramref name="presentation"/>.</returns>
    /// <exception cref="InvalidCharacter">A character is invalid</exception>
    public static string Canonicalize(string presentation) {
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
    /// Returns true if the character <paramref name="c"/> is permitted
    /// in the character span <paramref name="characterSpan"/>. Otherwise,
    /// an exception is thrown.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="characterSpan"></param>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public static bool IsAllowed(char c, out CharacterSpan characterSpan) {
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



