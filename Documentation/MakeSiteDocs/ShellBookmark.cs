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

using System.Collections.Generic;

using Goedel.Mesh.Test;

namespace ExampleGenerator {
    public class ShellBookmark : ExampleSet {
        public List<ExampleResult> BookmarkAdd;
        public List<ExampleResult> BookmarkGet;
        public List<ExampleResult> BookmarkList;
        public List<ExampleResult> BookmarkDelete;
        public List<ExampleResult> BookmarkAuth;

        public List<ExampleResult> BookmarkList2;

        public const string BookmarkPath1 = "Folder1/1";
        public const string BookmarkURI1 = "http://example.com/";
        public const string BookmarkTitle1 = "Example Dot Com";

        public const string BookmarkPath2 = "Folder1/2";
        public const string BookmarkURI2 = "http://example.net/Bananas";
        public const string BookmarkTitle2 = "Banana Site";

        public const string BookmarkPath3 = "Folder1/1a";
        public const string BookmarkURI3 = "http://example.com/Fred";
        public const string BookmarkTitle3 = "The Fred Space";

        public ShellBookmark(CreateExamples createExamples) :
                base(createExamples) {
            BookmarkAdd = Alice1.Example($"bookmark add {BookmarkPath1} {BookmarkURI1} \"{BookmarkTitle1}\"",
                $"bookmark add {BookmarkPath2} {BookmarkURI2} \"{BookmarkTitle2}\"",
                $"bookmark add {BookmarkPath3} {BookmarkURI3} \"{BookmarkTitle3}\"");
            BookmarkGet = Alice1.Example($"bookmark get {BookmarkPath2}");
            BookmarkList = Alice1.Example($"bookmark list");
            BookmarkDelete = Alice1.Example($"bookmark delete BookmarkPath2");

            }

        }
    }
