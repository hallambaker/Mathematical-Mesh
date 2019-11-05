using Goedel.Registry;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Tool.Version {
    class Program {
        static string PathDistribution = "prismproof\\Downloads";
        //static string PathSummary = "Sources\\" + PathDistribution;

        public Distribution Distribution = new Distribution();

        static void Main() {
            var _ = new Program();
            }

        public Program() {
            var Directories = Directory.GetDirectories(PathDistribution);
            foreach (var Directory in Directories) {
                //Console.WriteLine($"Directory {Directory}");
                ParseManifest(Directory);
                }

            //var Generate = new MakeRelease();
            MakeRelease.MakeIndex(Distribution);
            MakeRelease.MakeVersionID(Distribution);
            }




        public void ParseManifest(string Path) {
            var inputfile = Path + "\\Manifest.txt";
            var Parse = new Release() {
                };

            using (Stream infile = new FileStream(inputfile, FileMode.Open, FileAccess.Read)) {
                Lexer Schema = new Lexer(inputfile);
                Schema.Process(infile, Parse);
                }

            foreach (var Item in Parse.Top) {
                if (Item as Version != null) {
                    var Version = Item as Version;
                    Version.Parse();
                    if (Version.Stable) {
                        Distribution.Stable = Distribution.Stable ?? Version;
                        }
                    if (Version > Distribution.Latest) {
                        if (Distribution.Latest != null) {
                            Distribution.Versions.Add(Distribution.Latest);
                            }
                        Distribution.Latest = Version;
                        }
                    else {
                        Distribution.Versions.Add(Version);
                        }
                    }
                }
            }

        }

    public class Distribution {
        public Version Stable;

        public Version Latest;


        public SortedSet<Version> Versions = new SortedSet<Version>(new Version());

        }

    public partial class Version : IComparer<Version> {
        public int Major = 0;
        public int Minor = 8;
        public int Revision = 0;
        public List<Platform> Platforms = new List<Platform>();

        public bool Stable = false;

        public void Parse() {
            var Digits = Code.Split('.');

            Major = Convert.ToInt32(Digits[0]);
            Minor = Convert.ToInt32(Digits[1]);
            Revision = Convert.ToInt32(Digits[2]);

            foreach (var Entry in Entries) {
                if (Entry is Platform) {
                    var Platform = Entry as Platform;
                    Platforms.Add(Platform);
                    Platform.Parse();
                    }
                else if (Entry is Stable) {
                    Stable = true;
                    }
                }
            }

        public override string ToString() => $"{Major}.{Minor}.{Revision}";

        public int CompareTo(Version y) => Compare(this, y);

        public int Compare(Version x, Version y) => Version.CompareV(x, y);

        public static int CompareV(Version x, Version y) {
            if (y == null) {
                return 1;
                }
            if (x == null) {
                return 0;
                }
            if (x.Major != y.Major) {
                return x.Major > y.Major ? 1 : -1;
                }
            if (x.Minor != y.Minor) {
                return x.Minor > y.Minor ? 1 : -1;
                }
            if (x.Revision != y.Revision) {
                return x.Revision > y.Revision ? 1 : -1;
                }
            return 0;
            }


        public static bool operator <(Version left, Version right) => (CompareV(left, right) < 0);
        public static bool operator >(Version left, Version right) => (CompareV(left, right) > 0);
        }


    public partial class Platform {
        static Dictionary<string, string> MapPlatform = new Dictionary<string, string> {
                { "windows", "Windows" },
                { "osx", "macOS" },
                { "linux", "Linux" },
                { "any", "Universal" },
            };
        public string PlatformName;
        public List<File> Files = new List<File>();

        public void Parse() {
            MapPlatform.TryGetValue(Name, out PlatformName);
            foreach (var Entry in Entries) {
                var File = Entry as File;
                Files.Add(File);
                File.Parse();
                File.Platform = this;
                }
            }

        }




    public partial class File {
        public Platform Platform;


        static Dictionary<string, string> MapRID = new Dictionary<string, string> {
            { "win-x64", "Intel & AMD 64 bit (Windows 7 or later)"},
            { "win10-arm", "Windows ARM, 64 bit (Windows 10 only)"},
            { "osx-x64", "macOS (OSX) (Sierra (10.12) or later)"},
            { "linux-x64", "Any 64 bit Intel"},
            { "linux-arm", "Any 64 bit ARM"},
            { "any", "Universal (requires dotnet runtime)"}
            };

        public string Icon = "fa-file-archive-o";

        public string PlatformDescription = "unknown";


        public void Parse() => MapRID.TryGetValue(RID, out PlatformDescription);


        }

    }




