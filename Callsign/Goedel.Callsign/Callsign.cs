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

namespace Goedel.Callsign {


    public partial class Callsign {
        #region // Properties

        public static List<Page> Pages = new();

        static SortedList<int, CharacterSpan> VariantList { get; set; }


        #endregion
        #region // Constructors





        public Callsign(string presentation = null) {
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


        public void SetPresentation(string presentation) {
            presentation.AssertNotNull(NYI.Throw);


            if (Id == null) {

                Id = Canonicalize(presentation);

                }
            else {
                Id.AssertEqual(Canonicalize(presentation), NYI.Throw);

                }


            Presentation = presentation;




            }


        public static void AddPage(Page page) => Pages.Add(page);


        public static void MakeIndex() {
            var variantList = new SortedList<int, CharacterSpan>();

            foreach (var page in Pages) {
                foreach (var characterSpan in page.CharacterSpans) {
                    variantList.Add(characterSpan.First, characterSpan);
                    }
                }

            VariantList = variantList;
            }


        public static string Canonicalize(string presentation) {
            var builder = new StringBuilder();

            foreach (var c in presentation) {
                IsAllowed(c, out var characterSpan).AssertTrue(NYI.Throw);

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

        public static bool IsAllowed(char c, out CharacterSpan characterSpan) {
            foreach (var span in VariantList) {
                (span.Value.First > c).AssertFalse(NYI.Throw);

                var last = span.Value.Last > 0 ? span.Value.Last : span.Value.First;

                if (span.Value.First <= c & last >= c) {
                    characterSpan = span.Value;
                    return true;
                    }
                }
            throw new NYI();
            }

        #endregion


        }



    }
