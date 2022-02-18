<id>DB318ED1-90C4-4CA8-8371-2991C0BC7ADD
<version>4
<contenttype>developerConceptualDocument

Description of the architecture of the crypto libraries

#Key concepts

##Algorithm Identifiers

There are many different systems for categorizing Cryptographic algorithms and
any cryptographic platform typically ends up spending a lot of time converting
between them.

The most straightforward approach to implementing this is to introduce yet another
layer of identification that is internal to the cryptographic platform. The .NET
libraries naturally have two and it is planned to merge these into a third. So the
Goedel libraries are forced to introduce yet another.

##Key handle

A key handle is an identifier for a key bound to a cryptographic algorithm. This may be
either a symmetric or an asymmetric algorithm.

Using a key handle in place of a key itself allows an application to make use of a 
key without necessarily having access to the key value. This allows an application to
make use of keys that are stored on cryptographic hardware devices or protected
in other ways.

##Provider

A cryptographic provider is an implementation of a cryptographic algorithm that
is bound to a resolved key handle. The provider exposes the functions supported
by the key without exposing the key itself.

The cryptography libraries enforce a distinction between two modes of provider
use.

:Bulk Provider

::A bulk provider is created, processes a single data stream and is then disposed.
Bulk providers are the only type of provider that is permitted to operate directly
on data.

:Meta Provider

::A meta provider generates providers. Unlike the bulk provider, a meta provider 
may be called multiple times.

For example, if we are signing documents with RSA and SHA-2-512, we will first
create an RSA Signature provider and then request creation of a bulk provider
to perform the SHA-2-512 processing on each document.

Since asymmetric key operations are only used to generate keys for use with
a symmetric algorithm, asymmetric providers are always meta provider.

A bulk provider may operate as either a bulk provider or a meta provider but
not both. Once an operation of one type is performed, attempts to perform
the other operation will cause an exception to be thrown.


