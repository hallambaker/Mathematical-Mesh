

# ssh

~~~~
<div="helptext">
<over>
ssh    Manage SSH profiles connected to a personal profile
    client   Import SSH client information
    create   Generate a new SSH public keypair for the current machine and add to the personal profile
    delete   Delete SSH profile information
    get   Get SSH account data
    host   Import account information
    known   Get SSH data for known host
    list   List SSH account information
<over>
</div>
~~~~


# ssh client

~~~~
<div="helptext">
<over>
client   Import SSH client information
       File containing the contact entry to add
    /id   Unique entry identifier
    /merge   Merge input file with Mesh profile
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~

The ssh client command adds a client entry to the application catalog from a file.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh client ssh_config.json /id=work
<rsp>[CatalogedApplicationSsh]

</div>
~~~~





# ssh create

~~~~
<div="helptext">
<over>
create   Generate a new SSH public keypair for the current machine and add to the personal profile
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
    /auth   (De)Authorize the specified function on the device
    /root   Device as super administration device
    /admin   Device as administration device
    /message   Authorize rights for Mesh messaging
    /web   Authorize rights for Mesh messaging and Web.
    /device   Device restrictive access
    /threshold   Authorize threshold rights for Mesh messaging and Web.
    /ssh   Authorize rights for specified SSH account
    /email   Authorize rights for specified smtp email account
    /member   Authorize member rights for specified Mesh group
    /group   Authorize group administrator rights for specified Mesh group
    /null   Do not authorize any device rights at all (cannot be used with any rights grant))
    /id   Key identifier
<over>
</div>
~~~~

The ssh create command creates a new SSH client entry.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh create /web /threshold /id=ssh
<rsp>UDF: MC7I-NMDE-PGIQ-4W3W-TC5I-QYWC-DQWK
</div>
~~~~




# ssh delete

~~~~
<div="helptext">
<over>
delete   Delete SSH profile information
       Unique entry identifier
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

The ssh delete command deletes a client or host.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh delete work
<rsp>[CatalogedApplicationSsh]

</div>
~~~~




# ssh get

~~~~
<div="helptext">
<over>
get   Get SSH account data
       The mail account address
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~


The ssh get command describes a client or host entry.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh get work /file=alice1_ssh_pub2.pem /format=pem
<rsp></div>
~~~~




# ssh host

~~~~
<div="helptext">
<over>
host   Import account information
       File containing the contact entry to add
    /id   Unique entry identifier
    /merge   Merge input file with Mesh profile
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~


The ssh host command adds a host entry to the credential catalog from a file.


~~~~
<div="terminal">
<cmd>Alice> meshman ssh host ssh_host1.json
<rsp>ssh:alice42@ssh1.example.com = []

</div>
~~~~




# ssh known

~~~~
<div="helptext">
<over>
known   Get SSH data for known host
       The mail account address
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /sync   If true, attempt to synchronize the account to the service before operation
    /auto   If true, automatically approve pending requests with prior authorization.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
<over>
</div>
~~~~

The SSH known command returns the SSH authention data for all hosts in the credentials 
catalog or for a specific host.



~~~~
<div="terminal">
<cmd>Alice> meshman ssh known ssh1.example.com
<rsp>ssh:alice42@ssh1.example.com = []

</div>
~~~~




# ssh list

~~~~
<div="helptext">
<over>
list   List SSH account information
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
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

The SSH get command lists the client and/or host entries.

If the /client option is specified, only client entries are shown. If the /host option is
specified, only host entries are shown. In all other cases, both types of entry are shown.


~~~~
<div="terminal">
<cmd>Alice2> meshman ssh list
<rsp>UDF: MC7I-NMDE-PGIQ-4W3W-TC5I-QYWC-DQWK
</div>
~~~~




