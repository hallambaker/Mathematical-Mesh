

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


# calendar add

~~~~
<div="helptext">
<over>
add   Add calendar entry
       <Unspecified>
    /id   <Unspecified>
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
<cmd>Alice> calendar add CalendarEntry1.json CalID1
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> calendar add CalendarEntry1.json CalID1 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Cannot access a closed file."}}
</div>
~~~~


# calendar delete

~~~~
<div="helptext">
<over>
delete   Delete calendar entry
       Contact entry identifier
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
<cmd>Alice> calendar delete CalID1
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> calendar delete CalID1 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The entry could not be found in the store."}}
</div>
~~~~


# calendar get

~~~~
<div="helptext">
<over>
get   Lookup calendar entry
       <Unspecified>
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
<cmd>Alice> calendar get CalID1
<rsp>Empty
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> calendar get CalID1 /json
<rsp>{
  "ResultEntry": {
    "Success": false}}
</div>
~~~~


# calendar list

~~~~
<div="helptext">
<over>
list   List calendar entries
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
<cmd>Alice> calendar list
<rsp>CatalogedTask

</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> calendar list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "CatalogedTask": {
          "Title": "SomeItem",
          "Key": "NAZH-Z36Z-HJRC-KS5C-RVWH-XVSB-Z5A7"}}]}}
</div>
~~~~



