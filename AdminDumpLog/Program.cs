using System;
using Goedel.Persistence;


namespace DumpLog {

    /// <summary>
    /// Main entry point
    /// </summary>
    class Program {
        static string Store = "mesh.jlog";
        static string Portal = "portal.jlog";
        static void Main(string[] args) {
            var Program = new Program();
            Dump(Store);
            Dump(Portal);
            }

        
        /// <summary>
        /// Dump out records in a specified log
        /// </summary>
        /// <param name="File">Filename of log file to dump.</param>
        public static void Dump(string File) {

            var Store = new LogPersistenceStore(File);

            foreach (var Record in Store) {
                Console.Write("Got Record Key {0} ID {1}", Record.PrimaryKey, Record.TransactionID);
                foreach (var Key in Record.Keys) {
                    Dump(Key);
                    }
                }

            }

        /// <summary>
        /// Write out a particular index term
        /// </summary>
        /// <param name="IndexTerm">The index term to write out.</param>
        public static void Dump (IndexTerm IndexTerm) {
            Console.WriteLine("    [{0}]/[{1}]", IndexTerm.Type, IndexTerm.Term);

            }


        }
    }
