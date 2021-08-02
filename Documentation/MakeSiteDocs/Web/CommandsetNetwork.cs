using Goedel.Mesh.Shell;

#pragma warning disable IDE0022
#pragma warning disable IDE0060
#pragma warning disable IDE1006
using System.IO;
namespace ExampleGenerator {
    public partial class CreateExamples : global::Goedel.Registry.Script {



        //
        // WebNetwork
        //
        public static void WebNetwork(CreateExamples Examples) { /* XFile  */
            using var _Output = new StreamWriter("Guide/network.md");
            Examples._Output = _Output;
            Examples._WebNetwork(Examples);
            }
        public void _WebNetwork(CreateExamples Examples) {

            MakeTitle("network");
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The `network` command set is used to manage a network configuration catalog which contains\n{0}", _Indent);
            _Output.Write("a entries describing how to access particular networks.\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("## Adding networks\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The {1} command adds a network entry to a catalog:\n{0}", _Indent, ToCommand("network add"));
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(ShellNetwork.NetworkAdd);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("## Finding networks\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("The {1}  command retreives a network entry by label:\n{0}", _Indent, ToCommand("network get"));
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(ShellNetwork.NetworkGet);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("## Deleting networks\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("Network entries may be deleted using the  {1} command:\n{0}", _Indent, ToCommand("network delete"));
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(ShellNetwork.NetworkDelete);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("## Listing networks\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("A complete list of networks is obtained using the  {1} command:\n{0}", _Indent, ToCommand("network list"));
            _Output.Write("\n{0}", _Indent);
            ConsoleExample(ShellNetwork.NetworkList);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("## Adding devices\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("Devices are given authorization to access the networks catalog using the \n{0}", _Indent);
            _Output.Write(" {1} command:\n{0}", _Indent, ToCommand("device auth"));
            _Output.Write("\n{0}", _Indent);
            _Output.Write(" %  ConsoleExample (ShellNetwork.NetworkAuth);\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            }


        //
        // NetworkReference
        //
        public static void NetworkReference(CreateExamples Examples) { /* XFile  */
            using var _Output = new StreamWriter("Reference/network.md");
            Examples._Output = _Output;
            Examples._NetworkReference(Examples);
            }
        public void _NetworkReference(CreateExamples Examples) {

            var CommandSet = CommandLineInterpreter.DescribeCommandSet_Network;
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            Describe(CommandSet);
            _Output.Write("\n{0}", _Indent);
            _Output.Write("\n{0}", _Indent);
            Describe(CommandSet, _NetworkAdd._DescribeCommand);
            ConsoleReference(ShellNetwork.NetworkAdd);
            _Output.Write("\n{0}", _Indent);
            Describe(CommandSet, _NetworkDelete._DescribeCommand);
            ConsoleReference(ShellNetwork.NetworkDelete);
            _Output.Write("\n{0}", _Indent);
            Describe(CommandSet, _NetworkGet._DescribeCommand);
            ConsoleReference(ShellNetwork.NetworkGet);
            _Output.Write("\n{0}", _Indent);
            Describe(CommandSet, _NetworkDump._DescribeCommand);
            ConsoleReference(ShellNetwork.NetworkList);
            _Output.Write("\n{0}", _Indent);
            }
        }
    }
