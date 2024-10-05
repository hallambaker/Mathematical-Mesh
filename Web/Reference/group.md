

# group

~~~~
<div="helptext">
<over>
group    Group management commands
    add   Add user to recryption group
    create   Create recryption group
    delete   Remove user from recryption group
    get   Find member in recryption group
    list   List members of a recryption group
<over>
</div>
~~~~

# group add

~~~~
<div="helptext">
<over>
add   Add user to recryption group
       Recryption group name in user@example.com format
       User to add
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


The `group add` command adds a user to a group.

The first required parameter specifies the name of the group, the second required parameter 
specifies the name of the user to be added.



~~~~
<div="terminal">
<cmd>Alice> meshman group add groupw@example.com bob@example.com
<rsp>bob@example.com [MBSX-VMLY-JDTV-GYNX-G6F4-2J5P-4JKS]

</div>
~~~~



# group create

~~~~
<div="helptext">
<over>
create   Create recryption group
       Recryption group name in user@example.com format
       Recryption group name in user@example.com format
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
    /cover   File containing a default cover to be added to encrypted files
<over>
</div>
~~~~

The `group create` command creates a group.

The parameters for group creation are the same as for account creation. This allows a group
to be used to share a calendar or password catalog etc.



~~~~
<div="terminal">
<cmd>Alice> meshman group create groupw@example.com /web
<rsp>Account=groupw@example.com
UDF=MBQI-GRBW-QGJ4-WPKJ-J224-X7IY-HA7S
</div>
~~~~




# group delete

~~~~
<div="helptext">
<over>
delete   Remove user from recryption group
       Recryption group name in user@example.com format
       User to delete
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

The `group reject` command deletes a user from a group account.

The first required parameter specifies the name of the group, the second required parameter 
specifies the name of the user to be removed.

To delete the group account itself, the 'account delete' command is required.


~~~~
<div="terminal">
<cmd>Alice> meshman group delete groupw@example.com bob@example.com
<rsp>bob@example.com [MBSX-VMLY-JDTV-GYNX-G6F4-2J5P-4JKS]

</div>
~~~~



# group get

~~~~
<div="helptext">
<over>
get   Find member in recryption group
       Recryption group name in user@example.com format
       User to find
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

The `group get` command returns details of the sepcified group member.

The first required parameter specifies the name of the group, the second required parameter 
specifies the name of the user whose information is requested.


~~~~
<div="terminal">
<cmd>Alice> meshman group get groupw@example.com bob@example.com
<rsp>bob@example.com [MBSX-VMLY-JDTV-GYNX-G6F4-2J5P-4JKS]

</div>
~~~~



# group list

~~~~
<div="helptext">
<over>
list   List members of a recryption group
       Recryption group name in user@example.com format
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

The `group reject` command lists the names of the users in the specified group.

The first parameter specifies the name of the group.


~~~~
<div="terminal">
<cmd>Alice> meshman group list groupw@example.com
<rsp></div>
~~~~



