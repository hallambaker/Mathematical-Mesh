
# Using the  Command Set

The `dare` command set contains commands that encode, decode and verify 
DARE messages.

## Encoding a file as a DARE message.

The `dare encode` command is used to encode files as DARE Messages:


````
>dare encode TestFile1.txt
ERROR - The feature has not been implemented
````

In this case, the file `TestFile1.txt` contains the text `"This is a test"`.

By default, a content digest is calculated over the contents. This may be 
suppressed using the `/nohash` flag.

The data contents may be encrypted and authenticated under a specified symmetric key:


````
>dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare /key=EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
ERROR - The feature has not been implemented
````

Specifying a directory instead of a file causes all the files in the directory to be 
encoded:


````
>dare encode TestDir1 /encrypt=EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
ERROR - The feature has not been implemented
````

Files may also be signed using the user's Mesh signature key and/or encrypted for one
or more recipients. In this example, Alice creates a message intended for Bob.
Alice signs the message with her private signature key and encrypts it under Bob's
public encryption key.


````
>dare encode TestFile1.txt /out=TestFile1.txt.mesh.dare/encrypt=bob@example.com /sign=alice@example.com
ERROR - The feature has not been implemented
````


## Verifying a DARE message.

The `dare verify` command is used to verify the signature and 
digest values on a DARE Message without decoding the message body:


````
>dare verify TestFile1.txt.dare
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.dare'.
````

The command to verify a signed message is identical:


````
>dare verify TestFile1.txt.mesh.dare
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.mesh.dare'.
````

Messages that are encrypted and authenticated under a specified symmetric key 
may be verified at the plaintext level if the key is known or the ciphertext 
level otherwise.


````
>dare verify TestFile1.txt.symmetric.dare /encrypt=EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
ERROR - The option  is not known.
````



````
>dare verify TestFile1.txt.symmetric.dare
ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\TestFile1.txt.symmetric.dare'.
````

## Decoding a DARE message to a file.

The `dare decode` command is used to decode and verify DARE Messages:


````
>dare decode TestFile1.txt.dare
ERROR - The feature has not been implemented
````

To decode a message encrypted under a symmetric key, we must specify the key:


````
>dare decode TestFile1.txt.symmetric.dare /encrypt=EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
ERROR - The option  is not known.
````

If the message is encrypted under our private encryption key, the tool will locate
the necessary decryption key(s) automatically:


````
>dare decode TestFile1.txt.mesh.dare
ERROR - The feature has not been implemented
````


## Creating an EARL.

The `dare earl` command is used to create an EARL:


````
>dare earl TestFile1.txt
ERROR - The feature has not been implemented
````

A new secret is generated with the specified number of bits, this is then used
to generate the key identifier and encrypt the input file to a file with the
name of the key identifier.

The `/log` option causes the filename, encryption key and other details of
the transaction to be written to a DARE Container Log.


````
>dare container create EarlLog.dlog /encrypt=alice@example.com
ERROR - The command  is not known.
>dare earl TestFile1.txt /log=EarlLog.dlog
ERROR - The feature has not been implemented
````

The `/new` option causes the file to be encoded if and only if it has not 
been processed already.


````
>dare earl TestFile1.txt /new=EarlLog.dlog
ERROR - The feature has not been implemented
````

