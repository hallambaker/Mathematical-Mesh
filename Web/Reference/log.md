# log

~~~~
<div="helptext">
<over>
log    DARE log commands
    append   Append the specified string to the sequence.
    create   Create a new DARE Sequence
    list   Compile a catalog for the specified sequence.
<over>
</div>
~~~~

**Under development**: This command set is currently under development and many
features are documented but not yet implemented. Use with care!

The `log` command set contains commands that create, read and write text data to DARE 
log sequences..





# log append

~~~~
<div="helptext">
<over>
append   Append the specified string to the sequence.
       Sequence to append to
       Text to append
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

The `log append` command appends a text entry to the specified DARE sequence.


# log create

~~~~
<div="helptext">
<over>
create   Create a new DARE Sequence
       New sequence
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
<over>
</div>
~~~~




# log list

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


The `log list` command returns a list of items in the specified sequence..




