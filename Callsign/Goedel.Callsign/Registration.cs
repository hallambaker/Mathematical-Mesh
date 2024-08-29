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

using Goedel.Protocol;

namespace Goedel.Callsign;

public partial class Page {

    ///<summary>Dictionary listing the valid sub pages.</summary> 
    public Dictionary<string, Page> SubPages = new Dictionary<string, Page>();

    ///<summary>Expand the dictionary with entries from <paramref name="pages"/>.</summary> 
    public void Expand(Dictionary<string, Page> pages) {
        if (Allow is null) {
            return;
            }
        foreach (var allow in Allow) {
            pages.TryGetValue(allow, out var page).AssertTrue(NYI.Throw);


            SubPages.Add(allow, page);
            Expand(pages, page);

            }


        }


    void Expand(Dictionary<string, Page> pages, Page page) {
        foreach (var allow in Allow) {
            if (!SubPages.TryGetValue(allow, out _)) {
                SubPages.Add(allow, page);
                Expand(pages, page);
                }
            }
        }

    /// <summary>
    /// Return true if the character <paramref name="c"/> is allowed in this page
    /// (or a sub-page), otherwise false.
    /// </summary>
    /// <param name="c">The character to check.</param>
    /// <returns>True if the character is allowed, otherwise false.</returns>
    public bool IsAllowed(char c) {
        foreach (var span in CharacterSpans) {
            if ((c == span.First) & (span.Last == null)) {
                return true;
                }
            if ((c >= span.First) & (c <= span.Last)) {
                return true;
                }
            }

        return false;
        }


    ///<summary>The resource identifier for the digits character page.</summary> 
    public const string FileCharacterPageDigits = "Resources.CharacterPageDigits.json";

    ///<summary>The resource identifier for the Latin character page.</summary> 
    public const string FileCharacterPageLatin = "Resources.CharacterPageLatin.json";

    ///<summary>The resource identifier for the reserved character page.</summary> 
    public const string FileCharacterPageReserved = "Resources.CharacterPageReserved.json";

    /// <summary>
    /// Load the resource with identifier <paramref name="file"/>
    /// </summary>
    /// <param name="file">The resource to load.</param>
    /// <returns>The page resulting from parsing the resource.</returns>
    public static Page LoadResource(string file) {
        var assembly = typeof(CallsignEntry).Assembly;
        var name = assembly.GetName().Name;
        var resourceName = $"{name}.{file}";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new JsonBcdReader(stream);

        var result = Page.FromJson(reader);

        return result;
        }

    /// <summary>
    /// Load the default pages and return the pages as a list.
    /// </summary>
    /// <returns></returns>
    public static List<Page> LoadResources() {
        var result = new List<Page> {
            LoadResource(FileCharacterPageDigits),
            LoadResource(FileCharacterPageLatin),
            LoadResource(FileCharacterPageReserved)
            };

        return result;
        }


    }


public partial class Registration {
    #region // Constructors


    /// <summary>
    /// Default constructor, returns an empty instance.
    /// </summary>
    public Registration() {
        }

    /// <summary>
    /// Return a registration instance for the callsign <paramref name="callsign"/> with optional
    /// prior registration <paramref name="registration"/> and 
    /// </summary>
    /// <param name="callsign">The callsign binding.</param>
    /// <param name="registration">The prior registration for the canonical callsign
    /// value.</param>
    /// <param name="registrationReason">The registration reason. This is ignored if 
    /// <paramref name="registration"/> is null.</param>
    public Registration(
            CallsignBinding callsign,
            Registration? registration = null,
            RegistrationReason registrationReason = RegistrationReason.Update) {
        Id = Udf.Nonce();
        Entry = callsign.Enveloped as Enveloped<CallsignBinding>;
        Submitted = System.DateTime.Now;

        if (registration is null) {
            Reason = CallsignConstants.RegistrationReasonInitialTag;
            }
        else {
            Reason = registrationReason.ToLabel();
            PriorId = registration.Id;
            }

        // not currently dealling with the registrar slot.
        }

    #endregion

    }
