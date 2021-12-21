

# ssh

~~~~
<div="helptext">
<over>
ssh    Manage SSH profiles connected to a personal profile
    addAdd a public key to the host or client configuration
    mergeMerge the catalog with the specified local file
    create   Generate a new SSH public keypair for the current machine and add to the personal profile
    delete   Delete mail account information
    get   Lookup mail entry
    import   Import account information
    list   List mail account information
    private   Extract the private key for this device
    public   Extract the public key for this device
<over>
</div>
~~~~


# ssh client

~~~~
<div="helptext">
<over>
client   Add key to the authorized_keys file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
    /id   Key identifier
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh add client
<rsp>ERROR - An unknown error occurred
</div>
~~~~



# ssh host

~~~~
<div="helptext">
<over>
host   Add host to the known_hosts catalog
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
    /id   Key identifier
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh add host
<rsp>ERROR - TBS
</div>
~~~~



# ssh create

~~~~
<div="helptext">
<over>
create   Generate a new SSH public keypair for the current machine and add to the personal profile
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
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
    /id   Key identifier
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh create /web
<rsp>UDF: MDDO-QOQ3-U6RO-HNBP-DCQX-S74X-MY27
</div>
~~~~




# ssh delete

~~~~
<div="helptext">
<over>
delete   Delete mail account information
       Mail account identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~



~~~~
<div="terminal">
<cmd>Alice> meshman ssh delete
<rsp>ERROR - TBS
</div>
~~~~



# ssh import

~~~~
<div="helptext">
<over>
import   Import account information
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh import
<rsp>ERROR - TBS
</div>
~~~~



# ssh get

~~~~
<div="helptext">
<over>
get   Lookup mail entry
       The mail account address
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh get
<rsp>ERROR - TBS
</div>
~~~~




# ssh list

~~~~
<div="helptext">
<over>
list   List mail account information
    /known   List known host entries
    /auth   List authorized client entries
    /application   The application format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh import
<rsp>ERROR - TBS
</div>
~~~~




# ssh client

~~~~
<div="helptext">
<over>
client   Merge the SSH authorized keys catalog with the specified file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
    /id   Specify the SSH instance
    /read   Read the specified file and update the catalog.
    /write   Read the catalog and write unknown hosts to it.
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice2> meshman ssh merge client
<rsp>ERROR - TBS
</div>
~~~~




# ssh hosts

~~~~
<div="helptext">
<over>
hosts   Merge the SSH known hosts catalog with the specified file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
    /id   Specify the SSH instance
    /read   Read the specified file and update the catalog.
    /write   Read the catalog and write unknown hosts to it.
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice2> meshman ssh merge hosts
<rsp>ERROR - TBS
</div>
~~~~




# ssh private

~~~~
<div="helptext">
<over>
private   Extract the private key for this device
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
    /id   Key identifier
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh private /file=alice1_ssh_prv.pem
<rsp></div>
~~~~



# ssh public

~~~~
<div="helptext">
<over>
public   Extract the public key for this device
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
    /password   Password to encrypt private key
    /private   <Unspecified>
    /id   Key identifier
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> meshman ssh public /file=alice1_ssh_pub.pem
<rsp></div>
~~~~
























