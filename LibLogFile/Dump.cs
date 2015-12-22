//Sample license text.
using System;
using Goedel.Persistence;

namespace Goedel.Persistence {
    /// <summary>
    /// Dumps out a log persistence store at the DataItem level.
    /// LogEntries such as headers, etc. are not included.
    /// </summary>

    class Dump {
        
        public static void Write (string File) {

            var Store = new LogPersistenceStore(File);

            foreach (var Record in Store) {
                Console.Write("Got Record Key {0} ID {1}", Record.PrimaryKey, Record.TransactionID);
                foreach (var Key in Record.Keys) {
                    Write(Key);
                    }
                }

            }

        public static void Write (IndexTerm IndexTerm) {
            Console.WriteLine("    [{0}]/[{1}]", IndexTerm.Type, IndexTerm.Term);

            }


        }
    }
