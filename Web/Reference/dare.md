# dare

~~~~
<div="helptext">
<over>
dare    DARE Message encryption and decryption commands
    append   Append the specified file as an entry to the specified sequence.
    archive   Create a new DARE archive and add the specified files
    decode   Decode a DARE Message.
    delete   <Unspecified>
    dir   Compile a catalog for the specified sequence.
    earl   Create an Encrypted Authenticated Resource Locator (EARL)
    encode   Encode data as DARE Message.
    extract   Extract the specified record from the sequence
    index   Compile an index for the specified sequence and append to the end.
    list   Compile a catalog for the specified sequence.
    log   Append the specified string to the sequence.
    purge   Copy sequence contents to create a new sequence removing deleted elements
    sequence   Create a new DARE Sequence
    verify   Verify a DARE Message.
<over>
</div>
~~~~

The `dare` command set contains commands that encode, decode and verify 
DARE envelopes and sequences.


# dare archive

~~~~
<div="helptext">
<over>
archive   Create a new DARE archive and add the specified files
       Directory containing files to create archive from
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /type   The sequence type, plain/tree/digest/chain/tree
    /out   New sequence
    /index   Append index to the archive
<over>
</div>
~~~~

The `dare archive` command creates an archive with the specified cryptographic
enhancements.


~~~~
<div="terminal">
<cmd>Alice> meshman container archive ContainerArchive.dcon TestDir1
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman container archive ContainerArchive.dcon TestDir1 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~


# dare log

~~~~
<div="helptext">
<over>
log   Append the specified string to the sequence.
       Sequence to append to
       Text to append
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `dare log` command creates a sequence with the specified cryptographic
enhancements.


~~~~
<div="terminal">
<cmd>Alice> meshman container create Container.dcon
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman container create Container.dcon /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~




# dare extract

~~~~
<div="helptext">
<over>
extract   Extract the specified record from the sequence
       Sequence to read
       Extracted file
    /record   Index number of file to extract
    /file   Name of file to extract
    /key   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `dare extract` command extracts the specified container entries and writes them
to files.


~~~~
<div="terminal">
<cmd>Alice> meshman container extract Container.dcon TestOut
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman container extract Container.dcon TestOut /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~


# dare append

~~~~
<div="helptext">
<over>
append   Append the specified file as an entry to the specified sequence.
       Sequence to append to
       File to append
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   <Unspecified>
    /index   Append index to the archive
<over>
</div>
~~~~

The `dare append` command appends the specified file to the container.


~~~~
<div="terminal">
<cmd>Alice> meshman container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman container append Container.dcon TestFile1.txtcontainer append Container.dcon TestFile2.txtcontainer append Container.dcon TestFile3.txt /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~



# dare delete

~~~~
<div="helptext">
<over>
delete   <Unspecified>
       Sequence to append to
    /file   Name of file to delete
    /key   <Unspecified>
<over>
</div>
~~~~

The `dare delete` command marks the specified file entry as deleted in the
container but does not erase the data from the file.


~~~~
<div="terminal">
<cmd>Alice> meshman container delete Container.dcon  TestFile2.txt
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman container delete Container.dcon  TestFile2.txt /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~


# dare index

~~~~
<div="helptext">
<over>
index   Compile an index for the specified sequence and append to the end.
       Sequence to be indexed
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `dare index` command appends an index record to the end of the container.


~~~~
<div="terminal">
<cmd>Alice> meshman container index Container.dcon
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman container index Container.dcon /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~


# dare purge

~~~~
<div="helptext">
<over>
purge   Copy sequence contents to create a new sequence removing deleted elements
       Sequence to read
       Copy
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /type   The sequence type, plain/tree/digest/chain/tree
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /decrypt   Decrypt contents
    /index   Append an index record to the end
    /purge   Purge unused data etc.
<over>
</div>
~~~~

The `dare purge` command copies a container applying the specified filtering 
and indexing criteria.


~~~~
<div="terminal">
<cmd>Alice> meshman container copy Container2.dcon
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman container copy Container2.dcon /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~




# dare encode

~~~~
<div="helptext">
<over>
encode   Encode data as DARE Message.
       File or directory to encrypt
       Filename for encrypted output.
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /sub   Process subdirectories recursively.
    /key   Specifies the value of the master key
<over>
</div>
~~~~

The `dare encode` command encrypts a file and writes the output to a DARE Message.

If the input file specified is a file, the tool processes that file. If the
input file is a directory, the tool processes all the files in the directory. If the
`/sub` option is specified, subdirectories are processed recursively.

By default, a digest value is calculated over the message body (i.e. the ciphertext
if it is encrypted). This may be suppressed using the `/nohash` option.

The tool attempts to determine the IANA media type of the file from the file 
extension. This may be overriden using the /cty `option`.

Encryption and Signature enhancements may be specified with the `/sign` and 
`/encrypt` options. 

* Key parameters that have the form of a UDF secret (Exxx-xxxx-...) are interpreted
as symmetric encryption keys and used to encrypt the contents directly.

* Key parameters that have the form of an Internet user account (\<user\>@\<domain\> are 
resolved according to the currently active key collection.

The active key collection may be overriden using the `/mesh` option.

Algorithms for public key operations are inferred from the keys provided. The 
`\alg` option may be used to override the inferred or default algorithms.

The `/out` option may be used to specify the output file name. Otherwise the output
file name is the input file name with the additional extension `.dare`.




~~~~
<div="terminal">
<cmd>Alice> meshman dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare /key=K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare /key=K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The option System.Object[] is not known."}}
</div>
~~~~



# dare decode

~~~~
<div="helptext">
<over>
decode   Decode a DARE Message.
       Encrypted File
       Decrypted File
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Specifies the value of the master key
<over>
</div>
~~~~

The `dare decode` command decodes the specified input file using keys found in the
currently active key collection.

The active key collection may be overriden using the `/mesh` option.

The `/out` option may be used to specify the output file name. Otherwise the output
file name is the input file name stripped of the extension `.dare` if present or
with the extension `.undare` otherwise.


~~~~
<div="terminal">
<cmd>Alice> meshman dare decode TestFile1.txt.symmetric.dare /encrypt=K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman dare decode TestFile1.txt.symmetric.dare /encrypt=K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The option System.Object[] is not known."}}
</div>
~~~~


# dare verify

~~~~
<div="helptext">
<over>
verify   Verify a DARE Message.
       Encrypted File
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Specifies the value of the master key
<over>
</div>
~~~~

The `dare decode` command verifies the specified input file using keys found in the
currently active key collection and reports success or failure.

The active key collection may be overriden using the `/mesh` option.



~~~~
<div="terminal">
<cmd>Alice> meshman dare verify TestFile1.txt.symmetric.dare /encrypt=K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman dare verify TestFile1.txt.symmetric.dare /encrypt=K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The option System.Object[] is not known."}}
</div>
~~~~


# dare earl

~~~~
<div="helptext">
<over>
earl   Create an Encrypted Authenticated Resource Locator (EARL)
       File to encode
       Domain of the EARL service.
    /dir   Directory to write encrypted output.
    /new   Only convert file if not listed in DARE Sequence Log.
    /alg   List of algorithm specifiers
    /log   Write transaction report to DARE Sequence Log.
    /admin   Identifier of administrator authorized to read the log.
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `dare earl` command is used to encode an input file and return
(or log) the corresponding identifier information in a format that enables use
as an Encrypted Authenticated Resource Locator.

If the input file specified is a file, the tool processes that file. If the
input file is a directory, the tool processes all the files in the directory. If the
`/sub` option is specified, subdirectories are processed recursively.

If the `/log` or `/new` option is specified, the filename, encryption key and other details of
each completed transaction are written to a DARE Container Log. If `/log` is specified, the 
file is always processed. If `/new` is specified, files are only
processed if there is no existing entry in the specified log.

The log file must be initialized before use (eg. using the `container create` 
command). Log entries are written with the cryptographic enhancements specified in
the container using the active key collection.

The active key collection may be overriden using the `/mesh` option.


