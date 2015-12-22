//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  
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
