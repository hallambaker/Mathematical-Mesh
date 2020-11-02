
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
$$$$ Empty $$$$
~~~~

 Alice's signature private key parameters are:

~~~~
$$$$ Empty $$$$
~~~~

The body of the test message is the UTF8 representation of the following string:

~~~~
"This is a test long enough to require multiple blocks"
~~~~

The EDS sequences, are the UTF8 representation of the following strings:

~~~~
"Subject: Message metadata should be encrypted"
"2018-02-01"
~~~~

## Plaintext Message

A plaintext message without associated EDS sequences is an empty header
followed by the message body:

~~~~
$$$$ Empty $$$$
~~~~

## Plaintext Message with EDS

If a plaintext message contains EDS sequences, these are also in plaintext:

~~~~
$$$$ Empty $$$$
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~
$$$ Missing data $$$
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
$$$$ Empty $$$$
~~~~

The key agreement value is calculated:

~~~~
$$$ Missing data $$$
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~
$$$ Missing data $$$
~~~~

The wrapped master key is:

~~~~
$$$ Missing data $$$
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~
$$$ Missing data $$$
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~
$$$ Missing data $$$
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~
$$$ Missing data $$$
~~~~

The output sequence is the encrypted bytes:

~~~~
$$$ Missing data $$$
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
$$$$ Empty $$$$
~~~~

## Signed Message

Signed messages specify the digest algorithm to be used in the header and
the signature value in the trailer. Note that the digest algorithm is not optional
since it serves as notice that a decoder should digest the payload value 
to enable signature verification.

~~~~
$$$$ Empty $$$$
~~~~

## Signed and Encrypted Message

A signed and encrypted message is encrypted and then signed.
The signer proves knowledge of the payload plaintext by providing the
plaintext witness value.

~~~~
$$$$ Empty $$$$
~~~~


