# Cryptographic Algorithms derrived from NIST ACVTS code

The routines in this library are taken from the NIST ACVTS project in accordance
with the Mesh project approach to importing cryptographic primitives:

* Use implementations supported in .NET core if possible

* Otherwise, use Public Domain reference implementations, if existing in C#

* Otherwise implement directly.

This library is designed to be used to supplement the .NET Core versions 8.0 and 9.0. If it proves necessary to implement additional algorithms to support other .NET releases such as the micro framework, these will be provided in a supplemental library.

## Algorithms

The following algorithms are required to implement a Mesh Key Management Client:

### Symmetric

| Algorithm		| Mode		| Source	| Future			|
|---------------|-----------|-----------|-------------------|
| AES			| CBC		| dotNet	|					|
|				| OCB		| local		|					|
| SHA-2			| All		| dotNet	| 					|
| SHA-3			| All		| local		| Move to dotNet	|
| HMAC			|			| local		| Move to dotNet	|
| HKDF			|			| local		| Move to dotNet	|
| Keywrap		|			| local		| Move to dotNet	|

### Asymmetric

| Algorithm		| Mode		| Source	| Future			| 
|---------------|-----------|-----------|-------------------|
| X25519		|			| local		| NIST + Threshold	| 
| X448			|			| local		| NIST + Threshold	| 
| Ed25519		|			| local		| NIST + Threshold	| 
| Ed25519		|			| local		| NIST + Threshold	| 
| P256			| Use		| dotNet	|					| 
|				| Threhold	| NIST'		|					|
| P384			| Use		| dotNet	|					| 
|				| Threhold	| NIST'		|					|
| P512			| Use		| dotNet	|					| 
|				| Threhold	| NIST'		|					|
| ML-KEM		|			| NIST		|					| 
| ML-DSA		|			| NIST		|					| 
| RSA			| Use		| dotNet	|					| 
|				| KeyGen	| NIST'		|					|

Although the NIST curves are implemented in dotNet Core, threshold operations on the curves are not. Thus it is necessary to import the NIST curve implementations so that point addition can be implemented.

The implementation of RSA poses a similar concern. While dotNet provides multiple implementations of RSA, it does not provide access to the internals of the deterministinc key generation required to implement UDF deterministic generation from seed.


## License

NIST-developed software is provided by NIST as a public service. You may use, copy, and distribute copies of the software in any medium, provided that you keep intact this entire notice. You may improve, modify, and create derivative works of the software or any portion of the software, and you may copy and distribute such modifications or works. Modified works should carry a notice stating that you changed the software and should note the date and nature of any such change. Please explicitly acknowledge the National Institute of Standards and Technology as the source of the software.

NIST-developed software is expressly provided "AS IS." NIST MAKES NO WARRANTY OF ANY KIND, EXPRESS, IMPLIED, IN FACT, OR ARISING BY OPERATION OF LAW, INCLUDING, WITHOUT LIMITATION, THE IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NON-INFRINGEMENT, AND DATA ACCURACY. NIST NEITHER REPRESENTS NOR WARRANTS THAT THE OPERATION OF THE SOFTWARE WILL BE UNINTERRUPTED OR ERROR-FREE, OR THAT ANY DEFECTS WILL BE CORRECTED. NIST DOES NOT WARRANT OR MAKE ANY REPRESENTATIONS REGARDING THE USE OF THE SOFTWARE OR THE RESULTS THEREOF, INCLUDING BUT NOT LIMITED TO THE CORRECTNESS, ACCURACY, RELIABILITY, OR USEFULNESS OF THE SOFTWARE.

You are solely responsible for determining the appropriateness of using and distributing the software and you assume all risks associated with its use, including but not limited to the risks and costs of program errors, compliance with applicable laws, damage to or loss of data, programs or equipment, and the unavailability or interruption of operation. This software is not intended to be used in any situation where a failure could cause risk of injury or damage to property. The software developed by NIST employees is not subject to copyright protection within the United States.