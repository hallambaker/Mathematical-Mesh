//using Goedel.Utilities;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Goedel.Test {
//    public static class CorruptData {




//        public static char Corrupt(this char data) {
//            var c = ((int) data) ^0x01;
//            return (char)c;

//            }

//        public static string Corrupted( this string data) => data switch {
//                    null => "A",
//                    "" => "A",
//                    _ => data[0].Corrupt() + data.Substring (1)
//                    };


//        public static string CorruptedPIN(this string data) =>
//                $"{data[0]}{data[1]}{data[2].Corrupt()}" + data.Substring(3);

//        }
//    }
