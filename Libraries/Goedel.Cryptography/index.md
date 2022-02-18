=Using the Goedel.Cryptography support library

Goedel.Cryptography is a portable library that contains classes and
methods that support the use of public key cryptography.

Since the portable libraries do not currently provide any
cryptographic support and cannot in any case provide access 
to the platform libraries, these functions are implemented
in a separate, non-portable library that must be loaded
and initialized if any of the non-portable features are to be used.

==Initializing the framework library

The support library for use with .NET framework and Mono projects is
Goedel.Cryptography.Framework. To initialize the library, a call
must be made to the Cryptography.Initialize method as follows:

~~~~
using Goedel.Cryptography.Framework;

namespace Test {
    public void Initialize () {
        Cryptography.Initialize();
		}
	}
~~~~




==Cryptography Examples

===Creating Random numbers

The Platform class contains convenience methods that generate random Numbers



