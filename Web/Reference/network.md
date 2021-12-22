

# network

~~~~
<div="helptext">
<over>
network    Manage network profile settings
    add   Add network entry 
    delete   Delete calendar entry
    get   Lookup calendar entry
    import   Add network entry from file
    list   List network entries
<over>
</div>
~~~~


# network add

~~~~
<div="helptext">
<over>
add   Add network entry 
       WiFi SSID parameter
       Password value
    /id   Unique entry identifier
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

The 'network add' command is used to add a network entry to the catalog.

Note that the options supported are limited. The  `network import`
command should be used to add complex network entries.


~~~~
<div="terminal">
<cmd>Alice> meshman network add mywifi wifipassword /id=NetID1
<rsp>{Username}@{Service} = [{Password}]
</div>
~~~~



# network delete

~~~~
<div="helptext">
<over>
delete   Delete calendar entry
       Network entry identifier
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

The 'network delete' command deletes a network entry entry by means of 
its unique catalog identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman network delete NetID2
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~



# network get

~~~~
<div="helptext">
<over>
get   Lookup calendar entry
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

The 'network get' command retrieves a network entry by means of its 
unique catalog identifier.



~~~~
<div="terminal">
<cmd>Alice> meshman network get NetID2
<rsp>
</div>
~~~~



# network import

~~~~
<div="helptext">
<over>
import   Add network entry from file
       File containing the network entry to add
    /id   Unique entry identifier
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

The 'network import' command is used to add a network entry to the catalog
from a file


~~~~
<div="terminal">
<cmd>Alice> meshman network import NetworkEntry2.json /id=NetID2
<rsp>ERROR
</div>
~~~~



# network list

~~~~
<div="helptext">
<over>
list   List network entries
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

The 'network list' command lists all data in the network catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman network list
<rsp>CatalogedNetwork

CatalogedNetwork

</div>
~~~~



