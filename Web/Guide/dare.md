<title>dare
# Using the dare Command Set

**Under development**: This command set is currently under development and many
features are documented but not yet implemented. Use with care!

The `dare` command set contains commands that encode, decode and verify 
DARE envelopes and sequences.

## Encoding, decoding and verifying individual files in a DARE envelope.

The `dare encode`, `dare decode` and
`dare verify` commands are used to encode files as DARE Messages,
decode and verify them respectively. If the '/encrypt' option is specified,
the contents are encrypted under the corresponding encryption key:


~~~~
<div="terminal">
<cmd>Alice> meshman type plaintext.txt
<rsp>This is a test
<cmd>Alice> meshman dare encode plaintext.txt ciphertext.dare /encrypt ^
    alice@example.com 
<cmd>Alice> meshman dare verify ciphertext.dare
<rsp>File: ciphertext.dare
    Bytes: 16
    Encryption Algorithm: A256CBC
        Recipient: MCGS-T6PR-YQBN-KZI6-LUQO-XIVI-OSFJ
    Digest Algorithm: S512
    Payload Digest: A2AAD60FAE2F106FB3DFE0AF2A88D7B5C2CC48FB334B9B518
121BBFCB691142E8AFBAB9479E680D598C50BFAF000B0F9B48843992FBFBE6BE837A7
7507CF0E6F
</div>
~~~~

By default, a content digest is calculated over the contents. This may be 
suppressed using the `/nohash` flag.

The data contents may be encrypted and authenticated under a specified symmetric key:


~~~~
<div="terminal">
<cmd>Alice> meshman dare encode TestFile1.txt ^
    /out=TestFile1.txt.symmetric.dare ^
    /key=VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying a directory instead of a file causes all the files in the directory to be 
encoded:


~~~~
<div="terminal">
<cmd>Alice> meshman dare encode TestDir1 ^
    /encrypt=VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
<rsp>ERROR - No encryption key is available
</div>
~~~~

Files may also be signed using the user's Mesh signature key and/or encrypted for one
or more recipients. In this example, Alice creates a message intended for Bob.
Alice signs the message with her private signature key and encrypts it under Bob's
public encryption key.


~~~~
<div="terminal">
<cmd>Alice> meshman dare encode TestFile1.txt TestFile1.txt.mesh.dare ^
    /encrypt=bob@example.com /sign=alice@example.com
</div>
~~~~


### Verifying a DARE message.

The `dare verify` command is used to verify the signature and 
digest values on a DARE Message without decoding the message body:


~~~~
<div="terminal">
<cmd>Alice> meshman dare verify TestFile1.txt.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.dare'.
</div>
~~~~

The command to verify a signed message is identical:


~~~~
<div="terminal">
<cmd>Alice> meshman dare verify TestFile1.txt.mesh.dare
<rsp>File: TestFile1.txt.mesh.dare
    Bytes: 16
    Encryption Algorithm: A256CBC
        Recipient: MD6O-BFVH-45Z6-K3S5-FMDH-WXW4-BCA7
    Digest Algorithm: S512
    Payload Digest: 2D506E53ED640D06237CB12E18B199FDB0D10C200ED063D1D
C9C03EC8DB18FECEAC5CFACCFF1DA176873B147B6C1959A492972358F8390361E51BF
0C53EF29BF
        Signer: MCED-PMVZ-L4BE-WLJZ-2P4K-QINM-EHM2
</div>
~~~~

Messages that are encrypted and authenticated under a specified symmetric key 
may be verified at the plaintext level if the key is known or the ciphertext 
level otherwise.


~~~~
<div="terminal">
<cmd>Alice> meshman dare verify TestFile1.txt.symmetric.dare ^
    /encrypt=VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~



~~~~
<div="terminal">
<cmd>Alice> meshman dare verify TestFile1.txt.symmetric.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.symmetric.dare'.
</div>
~~~~

### Decoding a DARE message to a file.

The `dare decode` command is used to decode and verify DARE Messages:


~~~~
<div="terminal">
<cmd>Alice> meshman dare decode TestFile1.txt.dare
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Te
stFile1.txt.dare'.
</div>
~~~~

To decode a message encrypted under a symmetric key, we must specify the key:


~~~~
<div="terminal">
<cmd>Alice> meshman dare decode TestFile1.txt.symmetric.dare ^
    /encrypt=VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

If the message is encrypted under our private encryption key, the tool will locate
the necessary decryption key(s) automatically:


~~~~
<div="terminal">
<cmd>Alice> meshman dare decode TestFile1.txt.mesh.dare
<rsp>ERROR - No decryption key is available
</div>
~~~~


## Creating an EARL.

The `dare earl` command is used to create an EARL:


~~~~
<div="terminal">
<cmd>Alice> meshman dare earl TestFile1.txt example.com
<rsp>ERROR - An unknown error occurred
</div>
~~~~

A new secret is generated with the specified number of bits, this is then used
to generate the key identifier and encrypt the input file to a file with the
name of the key identifier.

The `/log` option causes the filename, encryption key and other details of
the transaction to be written to a DARE Sequence Log.


~~~~
<div="terminal">
<cmd>Alice> meshman dare earl create EarlLog.dlog /encrypt=alice@example.com
<rsp>ERROR - The option System.Object[] is not known.
<cmd>Alice> meshman dare earl TestFile1.txt /log=EarlLog.dlog
<rsp>ERROR - An unknown error occurred
</div>
~~~~

The `/new` option causes the file to be encoded if and only if it has not 
been processed already.


~~~~
<div="terminal">
<cmd>Alice> meshman dare earl TestFile1.txt /new=EarlLog.dlog
<rsp>ERROR - Flag value not recognizedEarlLog.dlog
</div>
~~~~


## Creating Sequences

Sequences are created with the `dare create`,
`dare archive` or `dare log` commands. 

`dare archive` creates a sequence that is specialized
for use as a DARE archive while `dare log` creates a 
sequence that is specialized for use as an event log. 
`dare sequence` creates an unspecialized sequence.


~~~~
<div="terminal">
<cmd>Alice> meshman dare create Sequence.dcon
</div>
~~~~

A sequence may have a security policy specified when it is created. If
no encryption or signature policy is specified on creation, the entries
appended to the sequence will not be encrypted or signed 

The cryptographic enhancements specified when a sequence is created have the 
same format and function as for DARE Messages but their scope is the sequence
as a whole.

For example, Alice creates an encrypted sequence readable by anyone who is a
member of the group groupw@example.com;


~~~~
<div="terminal">
<cmd>Alice> meshman dare create SequenceEncrypt.dcon ^
    /encrypt=groupw@example.com
</div>
~~~~

Since it is rarely desirable to sign every entry in a sequence, signatures
are typically added to a sequence when entries or indexes are added. 

### Archives

The `dare archive` creates a new archive, adds the
specified file(s) as entries and appends an index as the final record:


~~~~
<div="terminal">
<cmd>Alice> meshman dare archive SequenceArchive.dcon TestDir1
<rsp>ERROR - Path cannot be null. (Parameter 'path')
</div>
~~~~

An archive may be signed and encrypted:


~~~~
<div="terminal">
<cmd>Alice> meshman dare archive SequenceArchiveEncrypt.dcon TestDir1 ^
    /encrypt=groupw@example.com /sign=alice@example.com
<rsp>ERROR - Path cannot be null. (Parameter 'path')
</div>
~~~~

The signature on a signed archive is calculated over the final apex of the 
Merkel tree. Thus a single signature verification may be used to validate
any or all entries in the sequence.

## Reading Sequences

The `dare verify` command used to verify enveloped is also used to
verify the contents of a sequence: 


~~~~
<div="terminal">
<cmd>Alice> meshman dare verify SequenceArchiveEncrypt.dcon
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quenceArchiveEncrypt.dcon'.
</div>
~~~~

The verification performed depends on the type of authentication applied to the
sequence and whether the verifier can provide the necessary authentication or
decryption keys.

One or more sequence entries may be extracted to a file using the  
`dare extract` command. If the sequence is an archive, all
the files are extracted by default:


~~~~
<div="terminal">
<cmd>Alice> meshman dare extract Sequence.dcon TestOut
</div>
~~~~

Alternatively, the `/file` option may be used to extract a specific file:


~~~~
<div="terminal">
<cmd>Alice> meshman dare extract Sequence.dcon /file=TestDir1\TestFile4.txt
<rsp>ERROR - The file was not found.
</div>
~~~~


## Writing to Sequences 

The `dare append` command adds an entry to a sequence:


~~~~
<div="terminal">
<cmd>Alice> meshman dare append Sequence.dcon TestFile1.txt
<cmd>Alice> meshman dare append Sequence.dcon TestFile2.txt
<cmd>Alice> meshman dare append Sequence.dcon TestFile3.txt
</div>
~~~~

If no security enhancements are specified, the default enhancements specified 
in the index entry are applied.

The `dare delete` command adds an entry to a sequence
marking an entry as deleted:


~~~~
<div="terminal">
<cmd>Alice> meshman dare delete Sequence.dcon  TestFile2.txt
<rsp>ERROR - Value cannot be null. (Parameter 'key')
</div>
~~~~

Marking an entry for deletion does not cause the entry itself to be modified.
The entry is merely marked as having been deleted. To erase the entry contents,
it is necessary to either make a copy of the sequence using the `/purge`
option to reclaim the space used by deleted entries or to use the 
`/erase` or `overwrite` options.


The `dare index` command adds an index entry to the end of
sequence:


~~~~
<div="terminal">
<cmd>Alice> meshman dare index Sequence.dcon
</div>
~~~~

The index entry may be complete, providing an index of the entire file 
or incremental, only indexing the items added since the last index was created.
Indexing sequences allows the contents to be efficiently retrieved.


## Copying and Purging Sequences

The `dare copy` command makes a copy of a sequence with
the specified filtering rules. By default, no changes are made except to 
collect tree index fields dispersed throughout the sequence with an index 
at the end:


~~~~
<div="terminal">
<cmd>Alice> meshman dare copy Sequence2.dcon
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quence2.dcon'.
</div>
~~~~

The `dare copy`  command may be used to encrypt or decrypt the sequence contents during 
the copy:


~~~~
<div="terminal">
<cmd>Alice> meshman dare copy SequenceArchiveEncrypt.dcon /decrypt
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quenceArchiveEncrypt.dcon'.
</div>
~~~~

The `dare copy`  command may also be used to reclaim space used by deleted items
by specifying the '/purge' option:


~~~~
<div="terminal">
<cmd>Alice> meshman dare copy Sequence2.dcon /purge
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Se
quence2.dcon'.
</div>
~~~~

Note that it is not possible to purge a file in place writing the output to the input file
using this command.


