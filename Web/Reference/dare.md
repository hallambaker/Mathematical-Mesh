# dare

~~~~
<div="helptext">
<over>
dare    DARE Message encryption and decryption commands
    decode   Decode a DARE Message.
    earl   Create an Encrypted Authenticated Resource Locator (EARL)
    encode   Encode data as DARE Message.
    verify   Verify a DARE Message.
<over>
</div>
~~~~

The `dare` command set contains commands that encode, decode and verify 
DARE messages.

# dare encode

~~~~
<div="helptext">
<over>
encode   Encode data as DARE Message.
       File or directory to encrypt
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
    /out   Filename for encrypted output.
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
<cmd>Alice> dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare /key=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultFile:

~~~~
<div="terminal">
<cmd>Alice> dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare /key=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM /json
<rsp>{
  "ResultFile": {
    "Success": true,
    "Filename": "TestFile1.dare",
    "TotalBytes": 14}}
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
<cmd>Alice> dare decode TestFile1.txt.symmetric.dare /encrypt=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> dare decode TestFile1.txt.symmetric.dare /encrypt=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM /json
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
<cmd>Alice> dare verify TestFile1.txt.symmetric.dare /encrypt=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> dare verify TestFile1.txt.symmetric.dare /encrypt=3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM /json
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
    /new   Only convert file if not listed in DARE Container Log.
    /alg   List of algorithm specifiers
    /log   Write transaction report to DARE Container Log.
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

**Missing Example***

