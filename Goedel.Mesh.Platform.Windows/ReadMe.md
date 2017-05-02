=Platform class

All platform dependent code for a given machine type (Windows, macOS, Linux) is 
maintained in a separate namespace with a .Platform extension. This allows versions
of the build to be created for different platforms by linking to the platform dll
for that machine.

This is the Platform module for Windows. It contains code for:

* Interfacing to the Registry
* Accessing Keys in the Windows key store
* Integrating to Windows applications
	* Windows Live Mail
	* Outlook for Windows

Note that even though many applications run on multiple platforms, different platforms
often if not usually require different integration modules.

The .Platform namespace is dependent on the parent namespace. One major consequence
of that is that the platform independent code can't be referenced from the platform 
independent code. While this is obvious it is very inconvenient.

As a result, quite a few of the classes in the .Platform namespace override classes
in the platform independent library to add in methods and properties that are
platform specific.

To make this robust, the class with platform dependencies is declared abstract and the 
extended class with platform specific extensions has a Platform suffix.

When it comes time to identify classes etc that might usefully be used in other 
applications, this will be factored out into Goedel.Platform.<PlatformName>


Agh... Windows 10 Mail has a different design entirely. The config files are stored here:

//HKEY_USERS\S-1-5-21-4237498542-1133628048-3486816621-1001\SOFTWARE\Microsoft\ActiveSync\Partners\{60D03F1B-38BA-4FC2-8CA3-89408FC4ED48}
