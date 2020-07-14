﻿using System;

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
using System.Globalization;


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


        /// <summary>The assembly version</summary>
        public static string AssemblyVersion => Assembly.GetEntryAssembly().GetName().Version.ToString();

        /// <summary>The assembly title.</summary>
        public static string AssemblyTitle => 
            Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyTitleAttribute>().Title;

        /// <summary>The Assembly Description</summary>
        public static string AssemblyDescription =>
            Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyDescriptionAttribute>().Description;

        /// <summary>The Assembly Product</summary>
        public static string AssemblyProduct =>
            Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product;

        /// <summary>The Assembly Copyright</summary>
        public static string AssemblyCopyright =>
            Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;

        /// <summary>The Assembly Company</summary>
        public static string AssemblyCompany =>
            Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company;



        // Get the date at which the running assembly was linked

        // Method due to Jeff Atwood and Dustin Aleksiuk
        // http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html

        // This approach may well be dependent on the MSFT linker format not
        // changing but seems to be the best currently available. Hopefully
        // MSFT will do the right thing and provide a proper call for this before
        // they change the linker format.

        /// <summary>
        /// The assembly build time.
        /// </summary>
        public static DateTime AssemblyBuildTime => GetBuildDate(Assembly.GetEntryAssembly());
        private static DateTime GetBuildDate(Assembly assembly) {
            const string BuildVersionMetadataPrefix = "+build";

            var attribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (attribute?.InformationalVersion != null) {
                var value = attribute.InformationalVersion;
                var index = value.IndexOf(BuildVersionMetadataPrefix);
                if (index > 0) {
                    value = value.Substring(index + BuildVersionMetadataPrefix.Length);
                    if (DateTime.TryParseExact(value, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result)) {
                        return result;
                        }
                    }
                }

            return default;
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
