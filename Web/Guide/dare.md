<title>dare
# Using the dare Command Set

The `dare` command set contains commands that encode, decode and verify 
DARE messages.

## Encoding a file as a DARE message.

The `dare encode` command is used to encode files as DARE Messages:

**Missing Example***

In this case, the file `TestFile1.txt` contains the text `"This is a test"`.

By default, a content digest is calculated over the contents. This may be 
suppressed using the `/nohash` flag.

The data contents may be encrypted and authenticated under a specified symmetric key:

**Missing Example***

Specifying a directory instead of a file causes all the files in the directory to be 
encoded:

**Missing Example***

Files may also be signed using the user's Mesh signature key and/or encrypted for one
or more recipients. In this example, Alice creates a message intended for Bob.
Alice signs the message with her private signature key and encrypts it under Bob's
public encryption key.

**Missing Example***


## Verifying a DARE message.

The `dare verify` command is used to verify the signature and 
digest values on a DARE Message without decoding the message body:

**Missing Example***

The command to verify a signed message is identical:

**Missing Example***

Messages that are encrypted and authenticated under a specified symmetric key 
may be verified at the plaintext level if the key is known or the ciphertext 
level otherwise.

**Missing Example***


**Missing Example***

## Decoding a DARE message to a file.

The `dare decode` command is used to decode and verify DARE Messages:

**Missing Example***

To decode a message encrypted under a symmetric key, we must specify the key:

**Missing Example***

If the message is encrypted under our private encryption key, the tool will locate
the necessary decryption key(s) automatically:

**Missing Example***


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

