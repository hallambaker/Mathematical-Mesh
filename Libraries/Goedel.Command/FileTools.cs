using System;
using System.IO;

using Goedel.Registry;

namespace Goedel.Command {


    /// <summary>
    /// Utility class for managing files.
    /// </summary>
    public class FileTools {


        /// <summary>
        /// Get the time at which the specified file was created
        /// Return DateTime.MinValue if the file does not exist
        /// </summary>
        /// <param name="FileName">The file to test</param>
        /// <returns>The time the file was created.</returns>
        public static DateTime GetFileDateTime(string FileName) {
            if (!File.Exists(FileName)) {
                return DateTime.MinValue;
                }
            return File.GetLastWriteTimeUtc(FileName);
            }

        /// <summary>
        /// Write short form description of the current program to the console.
        /// </summary>
        public static void About() {
            var CompilationDate = Script.AssemblyBuildTime;

            string Build = Script.LocalizeTime(CompilationDate, false);

            Console.WriteLine(Script.AssemblyTitle);
            Console.WriteLine("  {0}", Script.AssemblyDescription);
            Console.WriteLine("  CopyRight : {0} {1}", Script.AssemblyCopyright, Script.AssemblyCompany);
            Console.WriteLine("  Version   : {0}", Script.AssemblyVersion);
            Console.WriteLine("  Compiled  : {0}", Build);
            }

        /// <summary>
        /// Cehck to see if a Destination file is more recent than a source file.
        /// </summary>
        /// <param name="Source">The source file.</param>
        /// <param name="Destination">The destination file.</param>
        /// <returns>True if the source was created before the destination.</returns>
        public static bool UpToDate(string Source, string Destination) {

            DateTime OutputDateTime = FileTools.GetFileDateTime(Destination);
            if (OutputDateTime == DateTime.MinValue) {
                return false;
                }
            DateTime ToolDateTime = Script.AssemblyBuildTime;
            if (OutputDateTime < ToolDateTime) {
                return false;
                }
            DateTime SourceDateTime = FileTools.GetFileDateTime(Source);
            return (OutputDateTime > SourceDateTime);
            }

        /// <summary>
        /// Determine output file name using command line entry and default data.
        /// </summary>
        /// <param name="Extension">The default extension.</param>
        /// <param name="Default">The base file name.</param>
        /// <returns>The defaulted output file.</returns>
        public static string DefaultFile(string Extension, string Default) => Path.GetFileNameWithoutExtension(Default) + "." + Extension;

        /// <summary>
        /// Determine output file name using command line entry and default data.
        /// </summary>
        /// <param name="Specified">The specified file name. This will be returned as is
        /// unless it is null in which case the default filename will be used.</param>
        /// <param name="Extension">The default extension.</param>
        /// <param name="Default">The base file name.</param>
        /// <returns>The defaulted output file.</returns>
        public static string DefaultFile(string Specified, string Default, string Extension) {
            if (Specified != null) {
                return Specified;
                }
            return DefaultFile(Extension, Default);
            }


        //
        //  Search for a file.
        //
        //  If FileName exists, use that, otherwise try FileName.Extension
        //

        /// <summary>
        /// Search for a file using specified extension if required.
        /// </summary>
        /// <param name="FileName">The base file name.</param>
        /// <param name="Extension">Default extension.</param>
        /// <returns>The defaulted file.</returns>
        public static string DefaultExtension(string FileName, string Extension) {
            if (File.Exists(FileName)) {
                return FileName;
                }

            return FileName + "." + Extension;
            }

        /// <summary>
        /// Calculate output file name.
        /// </summary>
        /// <param name="SourcePath">The source file path</param>
        /// <param name="DestinationPath">The destination file path.</param>
        /// <param name="Extension">The default extension.</param>
        /// <returns>The defaulted file name.</returns>
        public static string DefaultOutput(string SourcePath, string DestinationPath,
                        string Extension) {
            if (DestinationPath != null) {
                return DestinationPath;
                }
            return Path.GetFileNameWithoutExtension(SourcePath) + "." + Extension;
            }
        }
    }
