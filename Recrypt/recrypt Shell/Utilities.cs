using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Recrypt;
using Goedel.Debug;


namespace Goedel.Recrypt.Shell {

    public partial class Shell {

        bool VerboseOutput = true;
        bool ReportOutput = true;

        private void SetReporting(Flag Report, Flag Verbose) {
            ReportOutput = Report.Value;
            VerboseOutput = Verbose.Value;
            }

        public void Verbose(string Text, params object[] Data) {
            if (VerboseOutput & ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void ReportWrite(string Text) {
            if (ReportOutput) {
                Console.Write(Text);
                }
            }

        public void Report(string Text, List<string> Items) {
            if (!ReportOutput) return;
            Console.Write(Text);
            foreach (var Item in Items) {
                Console.Write(" ");
                Console.Write(Item);
                }
            Console.WriteLine();
            }

        public void Report(string Text, params object[] Data) {
            if (ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void Report(string Text) {
            if (ReportOutput) {
                Console.WriteLine(Text);
                }
            }


        }
    }
