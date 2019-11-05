using System;

/* Unmerged change from project 'Goedel.Registry'
Before:
using System.IO;
using System.Collections.Generic;
After:
using System.Collections.Generic;
using System.IO;
*/
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace Goedel.Registry {

    /// <summary>
    /// Script output class
    /// </summary>
    public partial class Script {
        /// <summary>The script output writer</summary>
		public TextWriter _Output { get; set; } = null;
        /// <summary>The current indent string, this is prefixed to each line.</summary>
        public string _Indent { get; set; } = "";
        /// <summary>The output filename.</summary>
        public string _Filename { get; set; } = null;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Script() {
            }

        /// <summary>
        /// Constructor with specified output.
        /// </summary>
        /// <param name="Output">The output stream</param>
		public Script(TextWriter Output) => _Output = Output;

        /// <summary>
        /// Set the output.
        /// </summary>
        /// <param name="Output">The output stream</param>
        public void SetTextWriter(TextWriter Output) {
            Close();
            _Output = Output;
            }

        /// <summary>
        /// Constructor with specified output file
        /// </summary>
        /// <param name="FileName">The output file </param>
        public void SetTextWriter(string FileName) {
            SetTextWriter(new StreamWriter(FileName));
            _Filename = FileName;
            }

        /// <summary>
        /// Close the current output file.
        /// </summary>
        public void Close() {
            if (_Output != null) {
                _Output.Close();
                }
            _Filename = null;
            }

        /// <summary>If true, the entry assembly is unknown.</summary>
        public static bool _TestEntryAssembly = true;
        /// <summary>The entry assembly</summary>
        public static Assembly _EntryAssembly = null;

        /// <summary>
        /// Get the current entry assembly.
        /// </summary>
        public static Assembly EntryAssembly {
            get {
                if (_TestEntryAssembly) {
                    _EntryAssembly = Assembly.GetEntryAssembly();
                    _TestEntryAssembly = false;
                    }
                return _EntryAssembly;
                }
            }

        /// <summary>The operating system version.</summary>
        static System.OperatingSystem OperatingSystem = System.Environment.OSVersion;

        /// <summary>The operating system platform name.</summary>
        public static string Platform => OperatingSystem.Platform.ToString();


        /// <summary>The operating system version.</summary>
        public static string PlatformVersion => OperatingSystem.Version.ToString();


        /// <summary>The assembly title.</summary>
        public static string AssemblyTitle => GetAssemblyTitle(EntryAssembly);


        /// <summary>Get assembly title.</summary>
        /// <param name="Assembly">The assembly being queried.</param>
        /// <returns>The assembly title.</returns>
        public static string GetAssemblyTitle(Assembly Assembly) {
            object[] attributes = Assembly.
                    GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0) {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "") {
                    return titleAttribute.Title;
                    }
                }
            // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.CodeBase);
            }

        /// <summary>The assembly version</summary>
        public static string AssemblyVersion => EntryAssembly != null ? GetAssemblyVersion(EntryAssembly) :
                        "Unknown";


        /// <summary>Get assembly version</summary>
        /// <param name="Assembly">The assembly being queried.</param>
        /// <returns>The assembly version</returns>
        public static string GetAssemblyVersion(Assembly Assembly) => Assembly.GetName().Version.ToString();

        /// <summary>The Assembly Description</summary>
        public static string AssemblyDescription => EntryAssembly != null ? GetAssemblyDescription(EntryAssembly) :
                        "Unknown";


        /// <summary>Get Assembly Description</summary>
        /// <param name="Assembly">The assembly being queried.</param>
        /// <returns>The Assembly Description</returns>
        public static string GetAssemblyDescription(Assembly Assembly) {

            // Get all Description attributes on this assembly
            object[] attributes = Assembly.
                    GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            // If there aren't any Description attributes, return an empty string
            if (attributes.Length == 0) {
                return "";
                }
            // If there is a Description attribute, return its value
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;

            }

        /// <summary>The Assembly Product</summary>
        public static string AssemblyProduct => EntryAssembly != null ? GetAssemblyProduct(EntryAssembly) :
                        "Unknown";


        /// <summary>Get Assembly Product</summary>
        /// <param name="Assembly">The assembly being queried.</param>
        /// <returns>The Assembly Product</returns>
        public static string GetAssemblyProduct(Assembly Assembly) {
            // Get all Product attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().
                GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            // If there aren't any Product attributes, return an empty string
            if (attributes.Length == 0) {
                return "";
                }
            // If there is a Product attribute, return its value
            return ((AssemblyProductAttribute)attributes[0]).Product;
            }

        /// <summary>The Assembly Copyright</summary>
        public static string AssemblyCopyright => EntryAssembly != null ? GetAssemblyCopyright(EntryAssembly) :
                        "Unknown";


        /// <summary>Get Assembly Copyright</summary>
        /// <param name="Assembly">The assembly being queried.</param>
        /// <returns>The Assembly Copyright</returns>
        public static string GetAssemblyCopyright(Assembly Assembly) {
            // Get all Copyright attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().
                GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            // If there aren't any Copyright attributes, return an empty string
            if (attributes.Length == 0) {
                return "";
                }
            // If there is a Copyright attribute, return its value
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }

        /// <summary>The Assembly Company</summary>
        public static string AssemblyCompany => EntryAssembly != null ? GetAssemblyCompany(EntryAssembly) :
                        "Unknown";


        /// <summary>Get Assembly Company</summary>
        /// <param name="Assembly">The assembly being queried.</param>
        /// <returns>The Assembly Company</returns>
        public static string GetAssemblyCompany(Assembly Assembly) {

            // Get all Company attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().
                GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            // If there aren't any Company attributes, return an empty string
            if (attributes.Length == 0) {
                return "";
                }
            // If there is a Company attribute, return its value
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }


        // Get the date at which the running assembly was linked

        // Method due to Jeff Atwood and Dustin Aleksiuk
        // http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html

        // This approach may well be dependent on the MSFT linker format not
        // changing but seems to be the best currently available. Hopefully
        // MSFT will do the right thing and provide a proper call for this before
        // they change the linker format.

        /// <summary>
        /// Return the assembly build time.
        /// </summary>
        /// <param name="Assembly">The assembly being queried.</param>
        /// <returns>The assembly build time</returns>
        public static DateTime AssemblyBuildTime(Assembly Assembly) {

            string FilePath = Assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try {
                s = new System.IO.FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
                }
            finally {
                if (s != null) {
                    s.Close();
                    }
                }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int SecondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime DateTime = new DateTime(1970, 1, 1, 0, 0, 0);
            DateTime = DateTime.AddSeconds(SecondsSince1970);

            return DateTime.SpecifyKind(DateTime, DateTimeKind.Utc); ;
            }

        /// <summary>
        /// Convert a time to a localized string.
        /// </summary>
        /// <param name="Time">Time to convert.</param>
        /// <param name="UTC">If true, use UTC, otherwise use the platform time.</param>
        /// <returns>The localized time.</returns>
        public static string LocalizeTime(DateTime Time, bool UTC) {
            DateTime ZoneTime = Time;
            string Format = "u";

            if (!UTC) {
                TimeZoneInfo TimeZoneInfo = TimeZoneInfo.Local;
                //bool DaylightSavings = TimeZoneInfo.IsDaylightSavingTime(Time);

                ZoneTime = TimeZoneInfo.ConvertTimeFromUtc(Time, TimeZoneInfo);
                Format = "yyyy-MM-dd HH:mm:ss zzz";
                }

            return ZoneTime.ToString(Format);
            }

        /// <summary>
        /// Build an indented summary comment string at the current position
        /// for the currently selected language.
        /// </summary>
        /// <param name="Spaces">Number of spaces to indent text</param>
        /// <param name="Text">Text to add</param>
        /// <returns>The comment string.</returns>
        public string CommentSummary(int Spaces, string Text) {
            var Indent = _Indent + new string(' ', Spaces);
            var Builder = new StringBuilder();

            Builder.Append(Indent);
            Builder.Append("/// <summary>\n");

            var Split = Text.Split('\n');

            foreach (var Part in Split) {
                Builder.Append(Indent);
                Builder.Append("///");
                Builder.Append(Part);
                Builder.Append("\n");
                }

            Builder.Append(Indent);
            Builder.Append("/// </summary>\n");

            return Builder.ToString();
            }

        /// <summary>
        /// Build an indented summary comment string at the current position
        /// for the currently selected language.
        /// </summary>
        /// <param name="Spaces">Number of spaces to indent text</param>
        /// <param name="Text">Text to add</param>
        /// <returns>The comment string.</returns>
        public string CommentSummary(int Spaces, List<string> Text) {
            var Indent = _Indent + new string(' ', Spaces);
            var Builder = new StringBuilder();

            Builder.Append(Indent);
            Builder.Append("/// <summary>\n");


            foreach (var Part in Text) {
                Builder.Append(Indent);
                Builder.Append("///");
                Builder.Append(Part);
                Builder.Append("\n");
                }

            Builder.Append(Indent);
            Builder.Append("/// </summary>\n");

            return Builder.ToString();
            }

        }
    }
