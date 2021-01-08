<title>dare
# Using the dare Command Set

The `dare` command set contains commands that encode, decode and verify 
DARE envelopes and sequences.

## Encoding a file as a DARE message.

The `dare encode` command is used to encode files as DARE Messages:


~~~~
<div="terminal">
<cmd>Alice> dare encode TestFile1.txt
</div>
~~~~

In this case, the file `TestFile1.txt` contains the text `"This is a test 1"`.

By default, a content digest is calculated over the contents. This may be 
suppressed using the `/nohash` flag.

The data contents may be encrypted and authenticated under a specified symmetric key:


~~~~
<div="terminal">
<cmd>Alice> dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare ^
    /key=INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying a directory instead of a file causes all the files in the directory to be 
encoded:


~~~~
<div="terminal">
<cmd>Alice> dare encode TestDir1 /encrypt=INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Files may also be signed using the user's Mesh signature key and/or encrypted for one
or more recipients. In this example, Alice creates a message intended for Bob.
Alice signs the message with her private signature key and encrypts it under Bob's
public encryption key.


~~~~
<div="terminal">
<cmd>Alice> dare encode TestFile1.txt ^
    TestFile1.txt.mesh.dare/encrypt=bob@example.com ^
    /sign=alice@example.com
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~


## Verifying a DARE message.

The `dare verify` command is used to verify the signature and 
digest values on a DARE Message without decoding the message body:


~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.dare'.
</div>
~~~~

The command to verify a signed message is identical:


~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.mesh.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.mesh.dare'.
</div>
~~~~

Messages that are encrypted and authenticated under a specified symmetric key 
may be verified at the plaintext level if the key is known or the ciphertext 
level otherwise.


~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.symmetric.dare ^
    /encrypt=INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~



~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.symmetric.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.symmetric.dare'.
</div>
~~~~

## Decoding a DARE message to a file.

The `dare decode` command is used to decode and verify DARE Messages:


~~~~
<div="terminal">
<cmd>Alice> dare decode TestFile1.txt.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.dare'.
</div>
~~~~

To decode a message encrypted under a symmetric key, we must specify the key:


~~~~
<div="terminal">
<cmd>Alice> dare decode TestFile1.txt.symmetric.dare ^
    /encrypt=INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

If the message is encrypted under our private encryption key, the tool will locate
the necessary decryption key(s) automatically:


~~~~
<div="terminal">
<cmd>Alice> dare decode TestFile1.txt.mesh.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.mesh.dare'.
</div>
~~~~


## Creating an EARL.

The `dare earl` command is used to create an EARL:


~~~~
Missing example 5
~~~~

A new secret is generated with the specified number of bits, this is then used
to generate the key identifier and encrypt the input file to a file with the
name of the key identifier.

The `/log` option causes the filename, encryption key and other details of
the transaction to be written to a DARE Container Log.


~~~~
Missing example 6
~~~~

The `/new` option causes the file to be encoded if and only if it has not 
been processed already.


~~~~
Missing example 7
~~~~


## Creating Sequences

Containers are created with either the `dare archive` or 
`dare log`. Both commands create a sequence with the 
specified cryptographic enhancements. The `container archive`
command additionally adds the specified file(s) to the container to create 
a container archive.


~~~~
<div="terminal">
<cmd>Alice> container create Container.dcon
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

*catalog* *spool* *archive* *log*


The cryptographic enhancements specified when a container is created have the 
same format and function as for DARE Messages but their scope is the container
as a whole.

For example, Alice creates an encrypted container readable by anyone who is a
member of the group groupw@example.com;


~~~~
<div="terminal">
<cmd>Alice> container create ContainerEncrypt.dcon ^
    /encrypt=groupw@example.com
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Since it is rarely desirable to sign every entry in a container, signatures
are typically added to a container when entries or indexes are added. 

The `container archive` creates a new container, adds the
specified file(s) as entries and appends an index as the final record:


~~~~
<div="terminal">
<cmd>Alice> container archive ContainerArchive.dcon TestDir1
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

An archive may be signed and encrypted:


~~~~
<div="terminal">
<cmd>Alice> container create ContainerArchiveEncrypt.dcon TestDir1
<rsp>ERROR - The command System.Object[] is not known.
<cmd>Alice> /encrypt=groupw@example.com /sign=alice@example.com
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

The signature on a signed archive is calculated over the final apex of the 
Merkel tree. Thus a single signature verification may be used to validate
any or all entries in the container.

## Reading Containers

The `dare verify` command verifies the contents of a container: 


~~~~
<div="terminal">
<cmd>Alice> container verify ContainerArchiveEncrypt.dcon
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

The verification performed depends on the type of authentication applied to the
container and whether the verifier can provide the necessary authentication or
decryption keys.


The `dare extract` 

One or more container entries may be extracted to a file using the  
`container extract` command. If the container is an archive, all
the files are extracted by default:


~~~~
<div="terminal">
<cmd>Alice> container extract Container.dcon TestOut
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Alternatively, the `/file` option may be used to extract a specific file:


~~~~
<div="terminal">
<cmd>Alice> container extract Container.dcon /file=TestDir1\TestFile4.txt
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~


## Writing to Archives 

The `dare append` command adds an entry to a container:


~~~~
<div="terminal">
<cmd>Alice> container append Container.dcon TestFile1.txtcontainer append ^
    Container.dcon TestFile2.txtcontainer append Container.dcon ^
    TestFile3.txt
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

If no security enhancements are specified, the default enhancements specified 
in the index entry are applied.

The `dare delete` 

The `container delete` command adds an entry to a container
marking an entry as deleted:


~~~~
<div="terminal">
<cmd>Alice> container delete Container.dcon  TestFile2.txt
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Marking an entry for deletion does not cause the entry itself to be modified.
The entry is merely marked as having been deleted. To erase the entry contents,
it is necessary to either make a copy of the container using the `/purge`
option to reclaim the space used by deleted entries or to use the 
`/erase` or `overwrite` options.


The `dare index` command adds an index entry to the end of
container:


~~~~
<div="terminal">
<cmd>Alice> container index Container.dcon
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

The index entry may be complete, providing an index of the entire file 
or incremental, only indexing the items added since the last index was created.
Indexing containers allows the contents to be efficiently retrieved.


## Writing to Logs


## Purging Sequences

The `dare purge` command makes a copy of a container with
the specified filtering rules. By default, no changes are made except to 
collect tree index fields dispersed throughout the container with an index 
at the end:


~~~~
<div="terminal">
<cmd>Alice> container copy Container2.dcon
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

The copy command may be used to encrypt or decrypt the container contents during 
the copy:


~~~~
<div="terminal">
<cmd>Alice> container copy ContainerArchiveEncrypt.dcon /decrypt
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

The copy command may also be used to reclaim space used by deleted items:


~~~~
<div="terminal">
<cmd>Alice> container copy Container2.dcon /purge
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~






