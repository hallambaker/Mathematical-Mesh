using Goedel.Mesh.Test;

using System.Collections.Generic;

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
            BookmarkAdd = testCLIAlice1.Example($"bookmark add {BookmarkPath1} {BookmarkURI1} \"{BookmarkTitle1}\"",
                $"bookmark add {BookmarkPath2} {BookmarkURI2} \"{BookmarkTitle2}\"",
                $"bookmark add {BookmarkPath3} {BookmarkURI3} \"{BookmarkTitle3}\"");
            BookmarkGet = testCLIAlice1.Example($"bookmark get {BookmarkPath2}");
            BookmarkList = testCLIAlice1.Example($"bookmark list");
            BookmarkDelete = testCLIAlice1.Example($"bookmark delete BookmarkPath2");

            }

        }
    }
