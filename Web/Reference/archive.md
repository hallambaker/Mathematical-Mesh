# archive

~~~~
<div="helptext">
<over>
archive    DARE archive commands
    append   Append the specified file as an entry to the specified sequence.
    copy   Copy sequence contents to create a new sequence removing deleted elements
    create   Create a new DARE archive and add the specified files
    delete   Delete file from archive index.
    dir   Compile a catalog for the specified sequence.
    extract   Extract the specified record from the sequence
    index   Compile an index for the specified sequence and append to the end.
<over>
</div>
~~~~

**Under development**: This command set is currently under development and many
features are documented but not yet implemented. Use with care!

The `dare` command set contains commands that encode, decode and verify 
DARE envelopes and sequences.



# archive append

~~~~
<div="helptext">
<over>
append   Append the specified file as an entry to the specified sequence.
       Sequence to append to
       File to append
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /self   Encrypt a copy of the data for self
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /cover   File containing a cover to be added to encrypted files
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
<cmd>Alice> meshman archive append Sequence.dcon TestFile1.txt
<rsp>ERROR - The process cannot access the file 'C:\Users\hallam\Test\Deterministic\Examples-InternetDrafts\Working\Sequence.dcon' because it is being used by another process.
</div>
~~~~




# archive create

~~~~
<div="helptext">
<over>
create   Create a new DARE archive and add the specified files
       Filename for encrypted output.
       Directory containing files to create archive from
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /self   Encrypt a copy of the data for self
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /cover   File containing a cover to be added to encrypted files
    /alg   List of algorithm specifiers
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /type   The sequence type, plain/tree/digest/chain/tree
    /index   Append index to the archive
<over>
</div>
~~~~

The `dare archive` command creates an archive sequence with the specified cryptographic
enhancements. If a file or directory is specified, they are added to the archive and
an index appended to the end.


~~~~
<div="terminal">
<cmd>Alice> meshman archive create SequenceArchive.dcon TestDir1
<rsp></div>
~~~~




# archive copy

~~~~
<div="helptext">
<over>
copy   Copy sequence contents to create a new sequence removing deleted elements
       Sequence to read
       Copy
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /self   Encrypt a copy of the data for self
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /cover   File containing a cover to be added to encrypted files
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
<cmd>Alice> meshman archive copy Sequence2.dcon
<rsp>ERROR - Could not find file 'C:\Users\hallam\Test\Deterministic\Examples-InternetDrafts\Working\Sequence2.dcon'.
</div>
~~~~




# archive delete

~~~~
<div="helptext">
<over>
delete   Delete file from archive index.
       Sequence to append to
       Name of file to delete
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /key   <Unspecified>
    /erase   If true, erase file from container preventing recovery.
<over>
</div>
~~~~

The `dare delete` command marks the specified file entry as deleted in the
sequence but does not erase the data from the file.


~~~~
<div="terminal">
<cmd>Alice> meshman archive delete Sequence.dcon  TestFile2.txt
<rsp>ERROR - The process cannot access the file 'C:\Users\hallam\Test\Deterministic\Examples-InternetDrafts\Working\Sequence.dcon' because it is being used by another process.
</div>
~~~~





# archive dir

~~~~
<div="helptext">
<over>
dir   Compile a catalog for the specified sequence.
       Sequence to be cataloged
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

The `dare delete` command marks the specified file entry as deleted in the
sequence but does not erase the data from the file.


~~~~
<div="terminal">
<cmd>Alice> meshman archive delete Sequence.dcon  TestFile2.txt
<rsp>ERROR - The process cannot access the file 'C:\Users\hallam\Test\Deterministic\Examples-InternetDrafts\Working\Sequence.dcon' because it is being used by another process.
</div>
~~~~



# archive extract

~~~~
<div="helptext">
<over>
extract   Extract the specified record from the sequence
       Sequence to read
       Extracted file
    /record   Index number of file to extract
    /out   Name of file to extract
    /key   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /recover   If true, return deleted files.
<over>
</div>
~~~~

The `dare extract` command extracts the specified sequence entries and writes them
to files.


~~~~
<div="terminal">
<cmd>Alice> meshman archive extract Sequence.dcon /file=TestDir1\TestFile4.txt
<rsp>ERROR - The option System.Object[] is not known.
</div>
~~~~




# archive index

~~~~
<div="helptext">
<over>
index   Compile an index for the specified sequence and append to the end.
       Sequence to be indexed
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /self   Encrypt a copy of the data for self
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /cover   File containing a cover to be added to encrypted files
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
<cmd>Alice> meshman archive index Sequence.dcon
<rsp>ERROR - The process cannot access the file 'C:\Users\hallam\Test\Deterministic\Examples-InternetDrafts\Working\Sequence.dcon' because it is being used by another process.
</div>
~~~~








