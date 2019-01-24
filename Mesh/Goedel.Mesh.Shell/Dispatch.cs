using System;
using System.IO;
using Goedel.Protocol;
using Goedel.Utilities;


namespace Goedel.Mesh.Shell {

    public partial class ShellDispatch {

        public bool     Verbose { get; set; }
        public bool     Report { get; set; }
        public bool     Json { get; set; }

        public string   AccountID { get; set; }
        public string   UDF { get; set; }

        public bool     DeviceNew  { get; set; }
        public string   DeviceUDF { get; set; }
        public string   DeviceID { get; set; }
        public string   DeviceDescription { get; set; }

        TextWriter Output;

        //SessionApplication SessionApplication = null;

        public ShellDispatch(TextWriter Output = null, string Catalog = null) => this.Output = Output ?? Console.Out;


        //CatalogClient CatalogClient 

        public void ReportResult(Result Result) {
            if (Json) {
                // Only report the results in JSON format and without
                // additional text.
                Output.Write(Result.GetJson(false));
                }
            else {
                Output.Write(Result.ToString());
                if (Verbose) {
                    Output.Write(Result.Verbose());
                    }
                }
            }

        }

    }