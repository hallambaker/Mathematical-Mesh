

# calendar

~~~~
<div="helptext">
<over>
calendar    Manage calendar catalogs connected to an account
    add   Add calendar entry
    delete   Delete calendar entry
    get   Lookup calendar entry
    import   Add calendar entry from file
    list   List calendar entries
<over>
</div>
~~~~

The `calendar` command set is used to manage a calendar configuration catalog which contains
a entries describing how to access particular calendars.

It should be noted that by its very nature, a calendar tool is most likely 
to be useful within a calendar application. The
commands provided in the 'meshman' tool are intended to support debuging and 
maintenance of such applications and afford a means of interacting through scripts.

# calendar add

~~~~
<div="helptext">
<over>
add   Add calendar entry
       The entry title.
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

The 'calendar add' command is used to add appointment and task entries to the catalog.

The catalog entry is specified as a file. The file type is automatically inferred from
the extension or may be overridden with the '/format' option.

The '/id' option may be used to specify a unique identifier for the entry.


~~~~
<div="terminal">
<cmd>Alice> meshman calendar add CalendarEntry1.json CalID1
<rsp>{
  "Title": "CalendarEntry1.json",
  "Key": "NDY7-GKFS-CQ24-OTV7-H3NV-7DXO-N5SD"}
</div>
~~~~



# calendar delete

~~~~
<div="helptext">
<over>
delete   Delete calendar entry
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

The 'calendar delete' command deletes an appointment or task entry by means of 
its unique catalog identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman calendar delete CalID1
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~



# calendar get

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

The 'calendar get' command retrieves an appointment or task entry by means of its 
unique catalog identifier.


~~~~
<div="terminal">
<cmd>Alice> meshman calendar get CalID1
<rsp>
</div>
~~~~



# calendar import

~~~~
<div="helptext">
<over>
import   Add calendar entry from file
       File containing the calendar entry to add
    /id   Unique entry identifier
    /format   Specifies the file format.
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

The 'calendar import' command is used to add appointment and task entries to the catalog
from a file

The catalog entry is specified as a file. The file type is automatically inferred from
the extension or may be overridden with the '/format' option.

The '/id' option may be used to specify a unique identifier for the entry.


~~~~
<div="terminal">
<cmd>Alice> meshman calendar add CalendarEntry1.json CalID1
<rsp>{
  "Title": "CalendarEntry1.json",
  "Key": "NDY7-GKFS-CQ24-OTV7-H3NV-7DXO-N5SD"}
</div>
~~~~




# calendar list

~~~~
<div="helptext">
<over>
list   List calendar entries
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

The 'calendar list' command lists all data in the calendar catalog.


~~~~
<div="terminal">
<cmd>Alice> meshman calendar list
<rsp>CatalogedTask

CatalogedTask

CatalogedTask

</div>
~~~~




