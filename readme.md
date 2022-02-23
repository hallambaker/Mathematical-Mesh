# MeshMan To Do List

## Uncaught errors

### No command present

````
PS C:\Users\hallam> meshman
Unhandled exception. Goedel.Command.UnknownCommand: The command System.Object[] is not known.
   at Goedel.Utilities.Assert.AssertNotNull[T](T test, ThrowDelegate throwDelegate, Object[] args)
   at Goedel.Command.CommandLineInterpreterBase.Dispatcher(SortedDictionary`2 Entries, DescribeCommandEntry DefaultCommand, DispatchShell Dispatch, String[] Args, Int32 Index)
   at Goedel.Mesh.Shell.Shell.Dispatch(String[] args, TextWriter console)
   at meshman.Program.Main(String[] args)
````