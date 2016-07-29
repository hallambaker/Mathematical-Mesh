//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using Goedel.Tool.RFCTool;
//using GM=Goedel.MarkLib;
//using GW=Goedel.WordLib;
//using Goedel.Registry;
//using MakeRFC;
//using OpenXML;

//namespace Goedel.Tool.RFCDoc {
//    class Import {
//        GM.TagCatalog TagCatalog;

//        public Import(string inputfile) {
//            var Parse = new Goedel.BootMark.MarkSchema();

//            using (Stream infile =
//                        new FileStream(inputfile, FileMode.Open, FileAccess.Read)) {
//                var Schema = new Lexer(inputfile);
//                Schema.Process(infile, Parse);
//                }

//            TagCatalog = new GM.TagCatalog(Parse);
//            }

//        public Import(GM.TagCatalog TagCatalog) {
//            this.TagCatalog = TagCatalog;
//            }


//        public void MDParse(string File, Goedel.Tool.RFCTool.Document Target) {
//            //var FileInfo = new FileInfo(File);

//            //// Here we put in the call to parse using the MarkDown  parser...
//            //var Source = new GM.Document(FileInfo, TagCatalog);


//            var Source = GM.BlockParserMarkDown.Parse(File, TagCatalog);

//            // Here we put in the call to reorganize the blocks from the
//            // markdown style parser to this parser
//            ConverterRFC.Convert(Source, Target);
//            }

//        public void WordParse(string File, Goedel.Tool.RFCTool.Document Target) {
//            //ReadWord.Create(File, Target);

//            //// Here we put in the call to parse using the Word parser...
//            //var Source = GW.WordDocument.Create(null, FileInfo, TagCatalog);

//            var Source = BlockParseWord.Parse(File, TagCatalog);


//            // Here we put in the call to reorganize the blocks from the
//            // markdown style parser to this parser
//            ConverterRFC.Convert(Source, Target);
//            }
//        }
//    }
