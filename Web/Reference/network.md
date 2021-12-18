

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
       <Unspecified>
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
<cmd>Alice> meshman network add NetworkEntry1.json NetID1
<rsp>{Username}@{Service} = [{Password}]
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> meshman network add NetworkEntry1.json NetID1 /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "CatalogedNetwork": {
        "Service": "NetworkEntry1.json",
        "Password": "NetID1"}}}}
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

~~~~
<div="terminal">
<cmd>Alice> meshman network delete NetID2
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> meshman network delete NetID2 /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The entry could not be found in the store."}}
</div>
~~~~


# network get

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
<cmd>Alice> meshman network get NetID2
<rsp>
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> meshman network get NetID2 /json
<rsp>{
  "ResultEntry": {
    "Success": false}}
</div>
~~~~


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

~~~~
<div="terminal">
<cmd>Alice> meshman network list
<rsp>CatalogedNetwork

CatalogedNetwork

CatalogedNetwork

</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> meshman network list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "CatalogedNetwork": {
          "Service": "myWiFi",
          "Password": "securePassword"}},
      {
        "CatalogedNetwork": {
          "Service": "NetworkEntry1.json",
          "Password": "NetID1"}},
      {
        "CatalogedNetwork": {
          "Service": "NetworkEntry2.json",
          "Password": "NetID2"}}]}}
</div>
~~~~


