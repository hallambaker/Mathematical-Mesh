using System;
using Goedel.Persistence;


namespace DumpLog {
    class Program {
        static string Store = "mesh.jlog";
        static string Portal = "portal.jlog";
        static void Main(string[] args) {
            var Program = new Program();
            Dump(Store);
            Dump(Portal);
            }


        public static void Dump(string File) {

            var Store = new LogPersistenceStore(File);

            foreach (var Record in Store) {
                Console.Write("Got Record Key {0} ID {1}", Record.PrimaryKey, Record.TransactionID);
                foreach (var Key in Record.Keys) {
                    Dump(Key);
                    }
                }

            }

        public static void Dump (IndexTerm IndexTerm) {
            Console.WriteLine("    [{0}]/[{1}]", IndexTerm.Type, IndexTerm.Term);

            }


        }
    }
