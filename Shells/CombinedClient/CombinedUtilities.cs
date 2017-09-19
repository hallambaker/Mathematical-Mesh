using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Goedel.Mesh.Platform;



namespace Goedel.Combined.Shell.Client {
    public partial class CombinedShell {

        bool VerboseOutput = false;
        bool ReportOutput = true;
        bool ActiveListener = false;

        private void SetReporting (IReporting Reporting) {
            SetReporting(Reporting.Report, Reporting.Verbose);
            }

        private void SetReporting (Flag Report, Flag Verbose) {
            ReportOutput = Report.Value;
            VerboseOutput = Verbose.Value;

            if (VerboseOutput & !ActiveListener) {
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                ActiveListener = true;
                }
            }

        public void Verbose (string Text, params object[] Data) {
            if (VerboseOutput & ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void ReportWrite (string Text) {
            if (ReportOutput) {
                Console.Write(Text);
                }
            }

        public void Report (string Text, List<string> Items) {
            if (!ReportOutput) {
                return;
                }
            Console.Write(Text);
            foreach (var Item in Items) {
                Console.Write(" ");
                Console.Write(Item);
                }
            Console.WriteLine();
            }

        public void Report (string Text, params object[] Data) {
            if (ReportOutput) {
                Console.WriteLine(Text, Data);
                }
            }

        public void Report (string Text) {
            if (ReportOutput) {
                Console.WriteLine(Text);
                }
            }


        public RegistrationDevice GetDevice (IDeviceProfileInfo Options) {

            // Feature: Should allow user to specify if device profile should be the default.

            if (!Options.DeviceUDF.ByDefault) {
                // Fingerprint specified so must use existing.
                return MeshSession.GetDevice(Options.DeviceUDF.Value);
                }
            if (Options.DeviceID.ByDefault | Options.DeviceNew.Value) {
                // Either no Device ID specified or the new flag specified so create new.
                var DeviceID = Options.DeviceID.Value ?? "Default";     // Feature: Pull from platform
                var DeviceDescription = Options.DeviceDescription.Value ?? "Unknown";  // Feature: Pull from platform
                return MeshSession.CreateDevice(DeviceID, DeviceDescription, true);
                }
            // DeviceID specified without new so look for existing profile.
            return MeshSession.GetDevice(DeviceID: Options.DeviceID.Value);
            }


        public SessionPersonal GetPersonal (IMeshProfile Options) {
            return GetPersonal(Options.MeshID.Value);
            }

        public SessionPersonal GetPersonal (string Address) {
            var RegistrationPersonal = MeshSession.GetPersonal(Address);
            RegistrationPersonal.MeshCatalog = MeshSession;

            Assert.NotNull(RegistrationPersonal, ProfileNotFound.Throw,
                new ExceptionData() { String = Address ?? "<default>" });

            return RegistrationPersonal;
            }


        }
    }
