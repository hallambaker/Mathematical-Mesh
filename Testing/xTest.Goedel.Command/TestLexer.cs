using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Registry;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Goedel.Command {
    public class CommandTestValue {
        public string Test { get; set; }
        public CommandLex.Token Token { get; set; }
        public string Value { get; set; }
        public string Flag { get; set; }
        }

    public class DispatchTestValue {
        public string Test { get; set; }
        public Dispatch Expect { get; set; }
        }

    public class SplitTestValue {
        public string Command { get; set; }
        public List<string> Arguments { get; set; }

        public SplitTestValue (string Command, List<string> Arguments) {
            this.Command = Command;
            this.Arguments = Arguments;
            }
        }

    [TestClass]
    public class TestLexer {

        public DispatchTestValue[] TestSetDispatch = new DispatchTestValue[] {
            //new DispatchTestValue {Test="about" },
            new DispatchTestValue {Test="help" },

            new DispatchTestValue {Test="/one test", Expect =new One () {
                _P1 ="test", _P2="" } },
            new DispatchTestValue {Test="one test", Expect =new One () {
                _P1 ="test", _P2="" } },
            new DispatchTestValue {Test="-one test", Expect =new One () {
                _P1 ="test", _P2="" } },
            new DispatchTestValue {Test="-one test /o1", Expect =new One () {
                _P1 ="test", _P2="", _O1="true" } },


            new DispatchTestValue {Test="/two test", Expect =new Two () {
                _P1 ="test", _P2="42", _O1="true" } },
            new DispatchTestValue {Test="/two test /o1:false", Expect =new Two () {
                _P1 ="test", _P2="42", _O1="false" } },
            new DispatchTestValue {Test="/two test /o1=false", Expect =new Two () {
                _P1 ="test", _P2="42", _O1="false" } },
            new DispatchTestValue {Test="/two test /noo1", Expect =new Two () {
                _P1 ="test", _P2="42", _O1="false" } },


            new DispatchTestValue {Test="sub four", Expect =new Four () { } },
            new DispatchTestValue {Test="sub five", Expect =new Five () { } },
            new DispatchTestValue {Test="sub sub2 six", Expect =new Five () { } },
            new DispatchTestValue {Test="sub sub2 seven", Expect =new Five () { } },

            new DispatchTestValue {Test="help one" },
            new DispatchTestValue {Test="help two" },
            new DispatchTestValue {Test="help sub" },
            new DispatchTestValue {Test="help sub four" },




            //new DispatchTestValue {Test="about" }
            };


        public SplitTestValue[] SplitTestValues = new SplitTestValue[] {


            new SplitTestValue ("MyApp alpha beta", 
                new List<string>(){ "MyApp", "alpha", "beta"}),
            new SplitTestValue (@"MyApp ""alpha with spaces"" ""beta with spaces""",
                new List<string>(){ "MyApp", "alpha with spaces", "beta with spaces"}),
            new SplitTestValue (@"MyApp 'alpha with spaces' beta",
                new List<string>(){ "MyApp", "'alpha", "with", "spaces'", "beta"}),
            new SplitTestValue (@"MyApp \\\alpha \\\\""beta",
                new List<string>(){ "MyApp", @"\\\alpha", @"\\beta"}),
            new SplitTestValue ("MyApp \\\\\\\\\\\"alpha \\\"beta",
                new List<string>(){ "MyApp", @"\\""alpha", @"""beta"}),


            new SplitTestValue ("one", new List<string>(){ "one"}),
            new SplitTestValue ("one two", new List<string>(){ "one", "two"}),
            new SplitTestValue ("one two three", new List<string>(){ "one", "two", "three"}),
            new SplitTestValue ("one\"two", new List<string>(){ "onetwo"}),
            new SplitTestValue ("one\"\"two", new List<string>(){ "onetwo"}),
            new SplitTestValue ("one\\two", new List<string>(){ "one\\two"}),
            new SplitTestValue ("one\\\\two", new List<string>(){ "one\\\\two"}),
            new SplitTestValue ("one\"two", new List<string>(){ "onetwo"}),
            new SplitTestValue ("one\\\"two", new List<string>(){ "one\"two"}),

            new SplitTestValue (@"one\\""two", new List<string>(){ @"one\two"}),
            new SplitTestValue (@"one\\\""two", new List<string>(){ @"one\""two"}),
            new SplitTestValue (@"one\\\\""two", new List<string>(){ @"one\\two"}),





            new SplitTestValue ("", new List<string>())

            };


        // NYI: Need to add in check to the parser and script libraries
        // NYI: Need to move to Goedel.Command so that we can back out changes
        // NYI: Test the Lazy and filename default schemes.
        // NYI: Library to expand out files to a set.



        [TestMethod]
        public void TestDispatch () {

            var CLI = new CommandLineInterpreter();
            var Shell = new Shell() { };
            foreach (var Test in TestSetDispatch) {
                Shell.Expect = Test.Expect;
                Console.WriteLine(Test.Test);
                CLI.MainMethod(Shell, Test.Test.Split());
                }
            }


        CommandTestValue[] TestSet = new CommandTestValue[] {
            new CommandTestValue () {
                Test = "Parameter",
                Token = CommandLex.Token.Value, Value = "Parameter", Flag = ""},
            new CommandTestValue () {
                Test = "/Flag=Parameter",
                Token = CommandLex.Token.FlagValue, Value = "Parameter", Flag = "Flag"},
            new CommandTestValue () {
                Test = "-Flag=Parameter",
                Token = CommandLex.Token.FlagValue, Value = "Parameter", Flag = "Flag"},
            new CommandTestValue () {
                Test = "/Flag:Parameter",
                Token = CommandLex.Token.FlagValue, Value = "Parameter", Flag = "Flag"},
            new CommandTestValue () {
                Test = "-Flag:Parameter",
                Token = CommandLex.Token.FlagValue, Value = "Parameter", Flag = "Flag"},
            new CommandTestValue () {
                Test = "/Flag",
                Token = CommandLex.Token.Flag, Value = "", Flag = "Flag"},
            new CommandTestValue () {
                Test = "-Flag",
                Token = CommandLex.Token.Flag, Value = "", Flag = "Flag"}
            };

        [TestMethod]
        public void TestCommandLex () {
            var Lex = new CommandLex();
            foreach (var Test in TestSet) {
                TestCommandLex(Lex, Test);
                }
            }

        [TestMethod]
        public void TestCommandSplitLex () {
            var Lex = new CommandSplitLex();
            foreach (var Test in SplitTestValues) {
                TestCommandSplit(Lex, Test);
                }
            }

        public void TestCommandLex (CommandLex Lex, CommandTestValue Test) {
            var T1 = Lex.GetToken(Test.Test);
            UT.Assert.IsTrue(T1 == Test.Token);
            UT.Assert.IsTrue(Lex.Value == Test.Value);
            UT.Assert.IsTrue(Lex.Flag == Test.Flag);
            }


        public void TestCommandSplit (CommandSplitLex Lex, SplitTestValue Test) {
            Console.WriteLine("[{0}]", Test.Command);
            var T1 = Lex.GetToken(Test.Command);
            foreach (var Argument in Lex.Value) {
                Console.WriteLine("    [{0}]", Argument);
                }

            //UT.Assert.IsTrue(T1 == CommandSplitLex.Token.Value);
            UT.Assert.IsTrue(Lex.Value.Count == Test.Arguments.Count);
            for (var i = 0; i< Lex.Value.Count; i++) {
                UT.Assert.IsTrue(Lex.Value[i] == Test.Arguments[i]);
                }
            }




        }

    public partial class Shell {
        public Object Expect;

        public override void One (One Options) {
            UT.Assert.IsTrue(Expect.GetType() == typeof(One));
            var Value = Expect as One;
            UT.Assert.IsTrue(Value.P1.Value == Options.P1.Value);
            UT.Assert.IsTrue(Value.P2.Value == Options.P2.Value);
            UT.Assert.IsTrue(Value.O1.Value == Options.O1.Value);
            }
        public override void Two (Two Options) {
            UT.Assert.IsTrue(Expect.GetType() == typeof(Two));
            var Value = Expect as Two;
            UT.Assert.IsTrue(Value.P1.Value == Options.P1.Value);
            UT.Assert.IsTrue(Value.P2.Value == Options.P2.Value);
            UT.Assert.IsTrue(Value.O1.Value == Options.O1.Value);
            }
        public override void Three (Three Options) {
            UT.Assert.IsTrue(Expect.GetType() == typeof(Three));
            }
        public override void Four (Four Options) {
            UT.Assert.IsTrue(Expect.GetType() == typeof(Four));
            }
        public override void Five (Five Options) {
            UT.Assert.IsTrue(Expect.GetType() == typeof(Five));
            }
        public override void Six (Six Options) {
            UT.Assert.IsTrue(Expect.GetType() == typeof(Six));
            }
        public override void Seven (Seven Options) {
            UT.Assert.IsTrue(Expect.GetType() == typeof(Seven));
            }
        }


    public class TestParser : Goedel.Registry.Parser{
        public Four NewOptions;
        }

    public class TestScript : Goedel.Registry.Script {

        public TestScript (TextWriter Out) {
            }

        public void Test (TestParser TestParser) {
            }
        }

    }
