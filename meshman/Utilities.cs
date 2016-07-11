using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Mesh;
using Goedel.Mesh.Platform;

namespace Goedel.Mesh.MeshMan {
    public class Utilities {


        // Convenience routines 

        public static string Default(string Value, string Default) {
            return Value == null ? Default : Value;
            }

        public static void Assert(bool Value, string Reason) {
            if (Value) return;
            Error(Reason);
            }

        public static void Assert(object Value, string Reason) {
            if (Value != null) return;
            Error(Reason);
            }

        public static void Assert(bool Value, string Text, params object[] Data) {
            if (Value) return;
            Error(Text, Data);
            }




        public static void Assert(object Value, string Text, params object[] Data) {
            if (Value != null) return;
            Error(Text, Data);
            }

        public static void Error(string Text, params object[] Data) {
            var Reason = System.String.Format(Text, Data);
            Error(Reason);
            }

        public static void Error(string Reason) {

            Console.WriteLine(Reason);
            throw new Exception(Reason);

            }

        public static void NYI(string Item) {
            Error("Not yet implemented", Item);
            }

        public static void NYI() {
            Error("Not yet implemented");
            }
        }



    }
