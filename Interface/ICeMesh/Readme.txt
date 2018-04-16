1. Open Visual Studio Command Prompt for VS2015/2017
2. From command line enter: 'cl /LD MESH.cpp REGISTRY.CPP GUIDs.cpp UUID.lib Ole32.lib Advapi32.lib MESH.def'
3. Register the component to COM by executing 'regsvr32 MESH.dll' from command line or execute REGISTER.BAT