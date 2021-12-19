

# network

~~~~
<div="helptext">
<over>
network    Manage network profile settings
    add   Add calendar entry from file
    delete   Delete calendar entry
    get   Lookup calendar entry
    import   Add calendar entry from file
    list   List network entries
<over>
</div>
~~~~


# network add

~~~~
<div="helptext">
<over>
add   Add calendar entry from file
       WiFi SSID parameter
       Password value
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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
<cmd>Alice> meshman network add NetworkEntry1.json NetID1
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
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'network delete' command deletes a contact entry entry by means of 
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
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'network get' command retrieves a contact entry by means of its 
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
import   Add calendar entry from file
       File containing the network entry to add
    /id   Unique entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

The 'network import' command is used to add appointment and task entries to the catalog
from a file


# network list

~~~~
<div="helptext">
<over>
list   List network entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /local   Local name for account (e.g. personal)
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

CatalogedNetwork

</div>
~~~~



