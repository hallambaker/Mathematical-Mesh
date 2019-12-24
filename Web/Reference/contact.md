

# contact

~~~~
<div="helptext">
<over>
contact    Manage contact catalogs connected to an account
    add   Add contact entry from file
    delete   Delete contact entry
    get   Lookup contact entry
    list   List contact entries
    self   Add contact entry for self
<over>
</div>
~~~~


# contact add

~~~~
<div="helptext">
<over>
add   Add contact entry from file
    /email   <Unspecified>
    /file   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> contact add email carol@example.com
<rsp>{
  "Self": false,
  "Key": "NCG6-H4KN-TR6Z-QKFK-KRQO-2L3N-PAKK",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> contact add email carol@example.com /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Self": false,
      "Key": "NCG6-H4KN-TR6Z-QKFK-KRQO-2L3N-PAKK",
      "EnvelopedContact": [{},
        "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}}}
</div>
~~~~


# contact delete

~~~~
<div="helptext">
<over>
delete   Delete contact entry
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
<cmd>Alice> contact delete carol@example.com
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> contact delete carol@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
</div>
~~~~


# contact get

~~~~
<div="helptext">
<over>
get   Lookup contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /encrypt   Encrypt the contact under the specified key
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> contact get carol@example.com
<rsp>Empty
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> contact get carol@example.com /json
<rsp>{
  "ResultEntry": {
    "Success": false}}
</div>
~~~~


# contact list

~~~~
<div="helptext">
<over>
list   List contact entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> contact list
<rsp>{
  "Self": true,
  "Key": "NB54-QGQH-2PL5-DCAV-SXY6-ER2T-B556",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}{
  "Self": false,
  "Key": "NCG6-H4KN-TR6Z-QKFK-KRQO-2L3N-PAKK",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> contact list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "Self": true,
        "Key": "NB54-QGQH-2PL5-DCAV-SXY6-ER2T-B556",
        "EnvelopedContact": [{},
          "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]},
      {
        "Self": false,
        "Key": "NCG6-H4KN-TR6Z-QKFK-KRQO-2L3N-PAKK",
        "EnvelopedContact": [{},
          "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}]}}
</div>
~~~~


