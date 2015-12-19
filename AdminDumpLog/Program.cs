using System;
using Goedel.Persistence;
using Goedel.Mesh;

namespace DumpLog {

    /// <summary>
    /// Main entry point
    /// </summary>
    class Program {
        static string Store = "MeshPersistenceStore.jlog";
        static string Portal = "PortalPersistenceStore.jlog";
        static void Main(string[] args) {
            var Program = new Program();
            Console.WriteLine("Persistence Store");
            Console.WriteLine("-----------------");
            Console.WriteLine();
            Dump(Store);
            Console.WriteLine("Portal Store");
            Console.WriteLine("-----------------");
            Dump(Portal);
            Console.WriteLine();
            }


        /// <summary>
        /// Dump out records in a specified log
        /// </summary>
        /// <param name="File">Filename of log file to dump.</param>
        public static void Dump(string File) {

            var Store = new LogPersistenceStore(File);

            foreach (var Record in Store) {
                Console.WriteLine("Record Key {0} ID {1}", Record.PrimaryKey, Record.TransactionID);
                if (Record.Keys != null) {
                    foreach (var Key in Record.Keys) {
                        Dump(Key);
                        }
                    }
                if (Record as DataItem != null) {
                    Dump(Record as DataItem);
                    }
                }

            }

        /// <summary>
        /// Write out a particular index term
        /// </summary>
        /// <param name="IndexTerm">The index term to write out.</param>
        public static void Dump(IndexTerm IndexTerm) {
            Console.WriteLine("    [{0}]/[{1}]", IndexTerm.Type, IndexTerm.Term);

            }


        public static void Dump(DataItem Item) {
            if (Item == null) return;
            Console.WriteLine("    {0}", Item.Action);


            var Profile = Entry.FromTagged(Item.Text);
            Dump(Profile as SignedProfile);
            }

        public static void Dump(SignedProfile Item) {
            if (Item == null) return;

            // elide signature for now.
            Dump(Item as SignedPersonalProfile);
            Dump(Item as SignedApplicationProfile);
            }

        public static void Dump(SignedPersonalProfile Item) {
            if (Item == null) return;

            Dump (Item.Signed);
            }

        public static void Dump(PersonalProfile Item) {
            if (Item == null) return;

            Console.WriteLine(Item.ToString ());
            }


        public static void Dump(SignedApplicationProfile Item) {
            if (Item == null) return;

            Dump(Item.Signed);
            }

        public static void Dump(ApplicationProfile Item) {
            if (Item == null) return;

            Console.WriteLine(Item.ToString());
            }

        }
    }
