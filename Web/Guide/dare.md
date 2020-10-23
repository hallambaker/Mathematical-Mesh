<title>dare
# Using the dare Command Set

The `dare` command set contains commands that encode, decode and verify 
DARE messages.

## Encoding a file as a DARE message.

The `dare encode` command is used to encode files as DARE Messages:


~~~~
<div="terminal">
<cmd>Alice> dare encode TestFile1.txt
<rsp></div>
~~~~

In this case, the file `TestFile1.txt` contains the text `"This is a test"`.

By default, a content digest is calculated over the contents. This may be 
suppressed using the `/nohash` flag.

The data contents may be encrypted and authenticated under a specified symmetric key:


~~~~
<div="terminal">
<cmd>Alice> dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare /key=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp></div>
~~~~

Specifying a directory instead of a file causes all the files in the directory to be 
encoded:


~~~~
<div="terminal">
<cmd>Alice> dare encode TestDir1 /encrypt=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp>ERROR - No decryption key is available
</div>
~~~~

Files may also be signed using the user's Mesh signature key and/or encrypted for one
or more recipients. In this example, Alice creates a message intended for Bob.
Alice signs the message with her private signature key and encrypts it under Bob's
public encryption key.


~~~~
<div="terminal">
<cmd>Alice> dare encode TestFile1.txt /out=TestFile1.txt.mesh.dare/encrypt=bob@example.com /sign=alice@example.com
<rsp></div>
~~~~


## Verifying a DARE message.

The `dare verify` command is used to verify the signature and 
digest values on a DARE Message without decoding the message body:


~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.dare'.
</div>
~~~~

The command to verify a signed message is identical:


~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.mesh.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.mesh.dare'.
</div>
~~~~

Messages that are encrypted and authenticated under a specified symmetric key 
may be verified at the plaintext level if the key is known or the ciphertext 
level otherwise.


~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.symmetric.dare /encrypt=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~



~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.symmetric.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.symmetric.dare'.
</div>
~~~~

## Decoding a DARE message to a file.

The `dare decode` command is used to decode and verify DARE Messages:


~~~~
<div="terminal">
<cmd>Alice> dare decode TestFile1.txt.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.dare'.
</div>
~~~~

To decode a message encrypted under a symmetric key, we must specify the key:


~~~~
<div="terminal">
<cmd>Alice> dare decode TestFile1.txt.symmetric.dare /encrypt=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

If the message is encrypted under our private encryption key, the tool will locate
the necessary decryption key(s) automatically:


~~~~
<div="terminal">
<cmd>Alice> dare decode TestFile1.txt.mesh.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.mesh.dare'.
</div>
~~~~


## Creating an EARL.

The `dare earl` command is used to create an EARL:

**Missing Example***

A new secret is generated with the specified number of bits, this is then used
to generate the key identifier and encrypt the input file to a file with the
name of the key identifier.

The `/log` option causes the filename, encryption key and other details of
the transaction to be written to a DARE Container Log.

**Missing Example***

The `/new` option causes the file to be encoded if and only if it has not 
been processed already.

**Missing Example***

