using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ExampleGenerator {
    class Program {
        static void Main(string[] args) {
            var Program = new Program();
            Program.Go();
            }


        void Go() {
            using (var Writer = new StreamWriter ("Generated\\Version.cs")) {
                var Version = new Version(Writer);
                Version.MakeVersion(1);
                }

            }

        }
    }
