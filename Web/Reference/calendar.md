

# calendar

~~~~
<div="helptext">
<over>
calendar    Manage calendar catalogs connected to an account
    add   Add calendar entry
    delete   Delete calendar entry
    dump   List calendar entries
    get   Lookup calendar entry
    import   Add calendar entry from file
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
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> calendar add CalendarEntry1.json CalID1
<rsp>{
  "Title": "CalendarEntry1.json",
  "Key": "NAHT-EV4E-VDN7-UOFB-QKG2-JIIQ-SPAC"}</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> calendar add CalendarEntry1.json CalID1 /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Title": "CalendarEntry1.json",
      "Key": "NAHT-EV4E-VDN7-UOFB-QKG2-JIIQ-SPAC"}}}
</div>
~~~~


# calendar delete

~~~~
<div="helptext">
<over>
delete   Delete calendar entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> calendar delete CalID1
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> calendar delete CalID1 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
</div>
~~~~


# calendar get

~~~~
<div="helptext">
<over>
get   Lookup calendar entry
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
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


# calendar dump

~~~~
<div="helptext">
<over>
dump   List calendar entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> calendar list
<rsp>ERROR - The command  is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> calendar list /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
</div>
~~~~



