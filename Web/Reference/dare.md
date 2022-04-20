# dare

~~~~
<div="helptext">
<over>
dare    DARE Message encryption and decryption commands
    append   Append the specified file as an entry to the specified sequence.
    archive   Create a new DARE archive and add the specified files
    copy   Copy sequence contents to create a new sequence removing deleted elements
    create   Create a new DARE Sequence
    decode   Decode a DARE Message.
    delete   Delete file from archive index.
    dir   Compile a catalog for the specified sequence.
    earl   Create an Encrypted Authenticated Resource Locator (EARL)
    encode   Encode data as DARE Message.
    extract   Extract the specified record from the sequence
    index   Compile an index for the specified sequence and append to the end.
    list   Compile a catalog for the specified sequence.
    log   Append the specified string to the sequence.
    verify   Verify a DARE Message.
<over>
</div>
~~~~

**Under development**: This command set is currently under development and many
features are documented but not yet implemented. Use with care!

The `dare` command set contains commands that encode, decode and verify 
DARE envelopes and sequences.



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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /id   Identifier of the file in the sequence
    /index   Append index to the archive
<over>
</div>
~~~~

The `dare append` command appends the specified file to the sequence.


~~~~
<div="terminal">
<cmd>Alice> meshman dare append Sequence.dcon TestFile1.txt
<rsp></div>
~~~~




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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /type   The sequence type, plain/tree/digest/chain/tree
    /out   New sequence
    /index   Append index to the archive
<over>
</div>
~~~~

The `dare archive` command creates an archive sequence with the specified cryptographic
enhancements. If a file or directory is specified, they are added to the archive and
an index appended to the end.


~~~~
<div="terminal">
<cmd>Alice> meshman dare archive SequenceArchive.dcon TestDir1
<rsp>ERROR - Path cannot be null. (Parameter 'path')
</div>
~~~~




# dare create

~~~~
<div="helptext">
<over>
create   Create a new DARE Sequence
       New sequence
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /type   The sequence type, plain/tree/digest/chain/tree
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~


The `dare create` command creates an empty DARE sequence with the specified
security policy.


~~~~
<div="terminal">
<cmd>Alice> meshman dare create Sequence.dcon
<rsp></div>
~~~~




# dare copy

~~~~
<div="helptext">
<over>
copy   Copy sequence contents to create a new sequence removing deleted elements
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /decrypt   Decrypt contents
    /index   Append an index record to the end
    /purge   Purge unused data etc.
<over>
</div>
~~~~

The `dare copy` command copies a sequence applying the specified filtering 
and indexing criteria.


~~~~
<div="terminal">
<cmd>Alice> meshman dare copy Sequence2.dcon
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\WorkingDirectory\Sequence2.dcon'.
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
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
<cmd>Alice> meshman dare decode TestFile1.txt.symmetric.dare /encrypt=FONQ-44SZ-FPSK-PIRE-J646-OCG4-ZY
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~




# dare delete

~~~~
<div="helptext">
<over>
delete   Delete file from archive index.
       Sequence to append to
    /file   Name of file to delete
    /key   <Unspecified>
<over>
</div>
~~~~

The `dare delete` command marks the specified file entry as deleted in the
sequence but does not erase the data from the file.


~~~~
<div="terminal">
<cmd>Alice> meshman dare delete Sequence.dcon  TestFile2.txt
<rsp>ERROR - Value cannot be null. (Parameter 'key')
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
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
each completed transaction are written to a DARE Sequence Log. If `/log` is specified, the 
file is always processed. If `/new` is specified, files are only
processed if there is no existing entry in the specified log.

The log file must be initialized before use (eg. using the `dare log` 
command). Log entries are written with the cryptographic enhancements specified in
the sequence using the active key collection.

The active key collection may be overriden using the `/mesh` option.


~~~~
<div="terminal">
<cmd>Alice> meshman dare earl TestFile1.txt example.com
<rsp>ERROR - An unknown error occurred
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
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
<cmd>Alice> meshman dare encode TestFile1.txt /out=TestFile1.txt.symmetric.dare/key=FONQ-44SZ-FPSK-PIRE-J646-OCG4-ZY
<rsp>ERROR - The option System.Object[] is not known.
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `dare extract` command extracts the specified sequence entries and writes them
to files.


~~~~
<div="terminal">
<cmd>Alice> meshman dare extract Sequence.dcon /file=TestDir1\TestFile4.txt
<rsp>ERROR - The file was not found.
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `dare index` command appends an index record to the end of the sequence.


~~~~
<div="terminal">
<cmd>Alice> meshman dare index Sequence.dcon
<rsp></div>
~~~~






# dare list

~~~~
<div="helptext">
<over>
list   Compile a catalog for the specified sequence.
       Sequence to be cataloged
       List output
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
<over>
</div>
~~~~

The `dare list` command returns a list of items in the specified sequence..


~~~~
<div="terminal">
<cmd>Alice> meshman dare list Sequence.dcon
<rsp>ERROR - Path cannot be null. (Parameter 'path')
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
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The `dare log` command appends a text entry to the specified DARE sequence.


~~~~
<div="terminal">
<cmd>Alice> meshman dare create Sequence.dcon
<rsp></div>
~~~~





# dare verify

~~~~
<div="helptext">
<over>
verify   Verify a DARE Message.
       Encrypted File
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Specifies the value of the master key
<over>
</div>
~~~~

The `dare verify` command verifies the specified input file using keys found in the
currently active key collection and reports success or failure.

The active key collection may be overriden using the `/mesh` option.



~~~~
<div="terminal">
<cmd>Alice> meshman dare verify TestFile1.txt.symmetric.dare /encrypt=FONQ-44SZ-FPSK-PIRE-J646-OCG4-ZY
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~





