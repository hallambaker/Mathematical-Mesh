using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Command {

    /// <summary>
    /// Delegate calling a dispatch routine.
    /// </summary>
    /// <param name="Dispatch">The command description.</param>
    /// <param name="args">The set of arguments.</param>
    /// <param name="index">The first unparsed argument.</param>
    public delegate void HandleDelegate(DispatchShell Dispatch, string[] args, int index);


    /// <summary>
    /// Base class for command line interpreters
    /// </summary>
    public abstract class CommandLineInterpreterBase {

        /// <summary>The default flag indicator for display to terminal, this is a forward slash / for Windows
        /// and a double dash -- for UNIX.</summary>
        public static char FlagIndicator = '/';

        /// <summary>
        /// Provide the summary of a command set
        /// </summary>
        /// <param name="DefaultCommand">The description of the default command.</param>
        /// <param name="Description">The command description</param>
        /// <param name="Entries">The command entries</param>
        /// <param name="Output">The output stream (defaults to Console)</param>
        public static void Brief(
                    string Description,
                    DescribeCommandEntry DefaultCommand,
                    SortedDictionary<string, DescribeCommand> Entries,
                    TextWriter Output = null) {
            Output = Output ?? Console.Out;

            Output.WriteLine(Description);
            Output.WriteLine("");

            if (DefaultCommand != null) {
                DefaultCommand.Describe(FlagIndicator, Output);

                }
            foreach (var Entry in Entries) {
                if (!Entry.Value.IsDefault) {  // BUG: Is not doing the right thing here.
                    Entry.Value.Describe(FlagIndicator, Output);
                    }
                }
            }

        /// <summary>
        /// Process command options.
        /// </summary>
        /// <param name="Args">The command line arguments.</param>
        /// <param name="Index">The first unparsed argument.</param>
        /// <param name="Options">The option values to set.</param>
        public static void ProcessOptions(string[] Args, int Index, Dispatch Options) {
            var Describe = Options.DescribeCommand;
            using (var CommandLex = new CommandLex()) {

                var Parameter = 0;

                // Set all data slots to their default value
                foreach (var Description in Describe.Entries) {
                    if (Description.Default != null) {
                        Options._Data[Description.Index].Default(Description.Default);
                        }
                    }

                for (var i = Index; i < Args.Length; i++) {
                    var Arg = Args[i];
                    var Token = CommandLex.GetToken(Arg);

                    switch (Token) {
                        case CommandLex.Token.Empty: {
                            break;
                            }
                        case CommandLex.Token.Flag: {
                            var Entry = Match(Describe.Entries, CommandLex.Flag) as DescribeEntryValue;
                            Assert.NotNull(Entry, UnknownOption.Throw);
                            var Data = Options._Data[Entry.Index];
                            if ((i + 1 < Args.Length) && !IsFlagged(Args[i + 1])) {
                                i++;
                                Arg = Args[i];

                                SetValue(Data, Args[i]);
                                }
                            Data.SetFlag(CommandLex.Not);

                            if (Data as _Flag != null) {
                                (Data as _Flag).Value = !CommandLex.Not;
                                Data.ByDefault = false;
                                }
                            break;
                            }
                        case CommandLex.Token.FlagValue: {
                            var Entry = Match(Describe.Entries, CommandLex.Flag) as DescribeEntryValue; ;
                            Assert.NotNull(Entry, UnknownOption.Throw);

                            SetValue(Options._Data[Entry.Index], CommandLex.Value);

                            break;
                            }
                        case CommandLex.Token.Value: {
                            var Search = true;
                            for (var j = Parameter; Search & j < Describe.Entries.Count; j++) {
                                if (Describe.Entries[j] is DescribeEntryParameter) {
                                    DescribeEntryParameter Entry = Describe.Entries[j] as DescribeEntryParameter;
                                    SetValue(Options._Data[Entry.Index], CommandLex.Value);
                                    Parameter = j + 1;
                                    Search = false;
                                    }
                                }
                            break;
                            }
                        }
                    }
                foreach (var Entry in Options._Data) {
                    Entry.Complete(Options._Data);
                    }
                }
            }

        static void SetValue(Type Data, string Value) {
            Data.Parameter(Value);
            Data.ByDefault = false; // Has been set explicitly
            }

        static DescribeEntry Match(List<DescribeEntry> Entries, string Flag) {
            foreach (var Entry in Entries) {
                if (Entry.Key.ToLower() == Flag.ToLower()) {
                    return Entry;
                    }
                }
            return null;
            }

        /// <summary>
        /// Describe the values in an command.
        /// </summary>
        /// <param name="Dispatch">The command to describe.</param>
        public static void DescribeValues(Dispatch Dispatch) => _ = Dispatch.Keep(); // NYI: This may not be required.


        /// <summary>
        /// Return true iff the text value is flagged.
        /// </summary>
        /// <param name="Text">Text to test.</param>
        /// <returns>Result of the test.</returns>
        public static bool IsFlagged(string Text) {
            if (Text == null) {
                return false;
                }
            if (Text.Length <= 0) {
                return false;
                }
            return Text[0] == '-' | Text[0] == '/';
            }

        /// <summary>
        /// The main dispatch point
        /// </summary>
        /// <param name="Entries">Dictionary describing the shell commands and dispatchers.</param>
        /// <param name="DefaultCommand">The default command entry</param>
        /// <param name="Dispatch">The command description.</param>
        /// <param name="Args">The set of arguments.</param>
        /// <param name="Index">The first unparsed argument.</param>
        public void Dispatcher(SortedDictionary<string, DescribeCommand> Entries,
                DescribeCommandEntry DefaultCommand,
                DispatchShell Dispatch, string[] Args, int Index) {
            // NYI: This should really be set up to take a Command set description
            // as the input.

            if (Args.Length == 0) {
                Assert.NotNull(DefaultCommand, UnknownCommand.Throw);
                DefaultCommand.HandleDelegate(Dispatch, Args, Index);
                return;
                }

            Assert.True(Index < Args.Length, UnknownCommand.Throw);

            var Arg = Args[Index];
            Assert.True(Arg.Length > 0, UnknownCommand.Throw); // Should never happen.
            var Flagged = IsFlagged(Arg);
            var Command = Flagged ? Arg.Substring(1).ToLower() : Arg.ToLower();

            if (DefaultCommand != null & !Flagged) {
                DefaultCommand.HandleDelegate(Dispatch, Args, Index);
                return;
                }

            // NYI: no, it could be a default command and an option.
            Assert.True(Entries.TryGetValue(Command, out var DescribeCommand), UnknownCommand.Throw);
            if (DescribeCommand is DescribeCommandEntry) {
                var DescribeCommandEntry = DescribeCommand as DescribeCommandEntry;
                DescribeCommandEntry.HandleDelegate(Dispatch, Args, Index + 1);
                }
            else if (DescribeCommand is DescribeCommandSet) {
                var DescribeCommandSet = DescribeCommand as DescribeCommandSet;
                Dispatcher(DescribeCommandSet.Entries, DefaultCommand, Dispatch, Args, Index + 1);
                }


            }
        }


    /// <summary>
    /// Describe a command or parameter entry 
    /// </summary>
    public abstract class DescribeEntry {
        /// <summary>The identifier name.</summary>
        public string Identifier { get; set; }
        /// <summary>Brief description</summary>
        public string Brief { get; set; }
        /// <summary>The default value (if specified)</summary>
        public string Default { get; set; }
        /// <summary>The command line key.</summary>
        public string Key { get; set; }
        /// <summary>The position in the options array.</summary>
        public int Index { get; set; } // Index into array of Type
        }

    /// <summary>
    /// Describe a command set.
    /// </summary>
    public abstract class DescribeCommand : DescribeEntry {

        /// <summary>If true, this is the default command.</summary>
        public bool IsDefault = false;

        /// <summary>
        /// Describe the command set.
        /// </summary>
        /// <param name="FlagIndicator">The flag indicator to use when printing the description.</param>
        /// <param name="Output">The output stream (defaults to Console)</param>
        /// <param name="PrefixCommands">If true, prefix command tags with the flag.</param>
        public abstract void Describe(
                    char FlagIndicator,
                    TextWriter Output = null,
                    bool PrefixCommands = true);
        }

    /// <summary>
    /// Describe a command entry
    /// </summary>
    public class DescribeCommandEntry : DescribeCommand {

        /// <summary>Delegate to dispatch if command is selected.</summary>
        public HandleDelegate HandleDelegate { get; set; }

        /// <summary>If true perform lezy evaluation of parameters.</summary>
        public bool Lazy { get; set; } = false;

        /// <summary>The command entries.</summary>
        public List<DescribeEntry> Entries { get; set; }

        /// <summary>
        /// Get the default for the value.
        /// </summary>
        /// <param name="Tag">The tag text</param>
        /// <returns>The default value if it exists, null otherwise.</returns>
        public string GetDefault(string Tag) {
            foreach (var Entry in Entries) {
                if (Entry.Key == Tag) {
                    return Entry.Default;
                    }
                }
            return null;
            }

        /// <summary>
        /// Set the default value for the tag
        /// </summary>
        /// <param name="Tag">The tag text</param>
        /// <param name="Default">The value to set as the default.</param>
        public void SetDefault(string Tag, string Default) {
            foreach (var Entry in Entries) {
                if (Entry.Key == Tag) {
                    Entry.Default = Default;
                    }
                }

            }

        /// <summary>
        /// Describe the command to the console.
        /// </summary>
        /// <param name="FlagIndicator">The flag indicator to use in display.</param>
        /// <param name="Output">The output stream (defaults to Console)</param>
        /// <param name="PrefixCommands">If true, add prefix to command descriptions</param>
        public override void Describe(
                    char FlagIndicator,
                    TextWriter Output = null,
                    bool PrefixCommands = true) {
            Output = Output ?? Console.Out;
            var prefixCommand = PrefixCommands ? FlagIndicator.ToString() : "";

            Output.WriteLine("{0}{1}   {2}", prefixCommand, Identifier, Brief);
            foreach (var Entry in Entries) {
                switch (Entry) {
                    case DescribeCommandEntry SubCommand: {
                        Output.WriteLine("    {0}{1}  {2}", prefixCommand, Entry.Key, SubCommand.Brief);
                        break;
                        }
                    }
                }
            foreach (var Entry in Entries) {
                switch (Entry) {
                    case DescribeEntryParameter Parameter: {
                        Output.WriteLine("    {0}   {1}", Entry.Key, Parameter.Brief);
                        break;
                        }
                    }
                }
            foreach (var Entry in Entries) {
                switch (Entry) {
                    case DescribeEntryOption Option: {
                        Output.WriteLine("    {0}{1}   {2}", FlagIndicator, Entry.Key, Option.Brief);
                        break;
                        }
                    }
                }
            }


        }

    /// <summary>
    /// Describe a command set.
    /// </summary>
    public class DescribeCommandSet : DescribeCommand {

        /// <summary>Dictionary of command entries.</summary>
        public SortedDictionary<string, DescribeCommand> Entries;

        /// <summary>
        /// Describe the command set to the console.
        /// </summary>
        /// <param name="FlagIndicator">The flag indicator to use in display.</param>
        /// <param name="Output">The output stream (defaults to Console)</param>
        /// <param name="PrefixCommands">If true, add prefix to command descriptions</param>
        public override void Describe(
                    char FlagIndicator,
                    TextWriter Output = null,
                    bool PrefixCommands = true) {
            Output = Output ?? Console.Out;
            var prefixCommand = PrefixCommands ? FlagIndicator.ToString() : "";

            Output.WriteLine("{0}    {1}", Identifier, Brief);
            foreach (var Entry in Entries) {
                switch (Entry.Value) {
                    case DescribeCommandSet describeCommandSet: {
                        Output.WriteLine("    {0}{1}", Entry.Key, describeCommandSet.Brief);
                        break;
                        }
                    }

                }
            foreach (var Entry in Entries) {
                switch (Entry.Value) {
                    case DescribeCommandEntry describeCommandEntry: {
                        Output.WriteLine("    {0}{1}   {2}", prefixCommand, Entry.Key, describeCommandEntry.Brief);
                        break;
                        }
                    }

                }
            }
        }

    /// <summary>
    /// Describe an entry value.
    /// </summary>
    public class DescribeEntryValue : DescribeEntry {

        }

    /// <summary>
    /// Describe an option value.
    /// </summary>
    public class DescribeEntryOption : DescribeEntryValue {
        }

    /// <summary>
    /// Describe a parameter value.
    /// </summary>
    public class DescribeEntryParameter : DescribeEntryValue {
        }

    /// <summary>
    /// Describe a parameter value.
    /// </summary>
    public class DescribeEntryEnumerate : DescribeEntryValue {
        /// <summary>The command entries.</summary>
        public List<DescribeCase> Entries { get; set; }
        }

    /// <summary>
    /// Describe an entry value.
    /// </summary>
    public class DescribeCase : DescribeEntry {
        ///<summary>The index value</summary>
        public int Value;
        }

    /// <summary>
    /// Describe a shell.
    /// </summary>
    public abstract class DispatchShell : Dispatch {

        /// <summary>
        /// Method called before acommand is dispatched.
        /// </summary>
        /// <param name="dispatch">The options for the command dispatched.</param>
        public virtual void _PreProcess(Dispatch dispatch) { }
        }


    }
