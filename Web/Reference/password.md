

# password

~~~~
<div="helptext">
<over>
password    Manage password catalogs connected to an account
    add   Add password entry
    delete   Delete password entry
    get   Lookup password entry
    list   List password entries
<over>
</div>
~~~~


# password add

~~~~
<div="helptext">
<over>
add   Add password entry
       <Unspecified>
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
<cmd>Alice> password add ftp.example.com alice1 password
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> password add ftp.example.com alice1 password /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Cannot access a closed file."}}
</div>
~~~~


# password get

~~~~
<div="helptext">
<over>
get   Lookup password entry
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
<cmd>Alice> password delete www.example.com
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> password delete www.example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The entry could not be found in the store."}}
</div>
~~~~


# password delete

~~~~
<div="helptext">
<over>
delete   Delete password entry
       Domain name of Web site
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
<cmd>Alice> mesh list
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> mesh list /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The command System.Object[] is not known."}}
</div>
~~~~


# password list

~~~~
<div="helptext">
<over>
list   List password entries
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
<cmd>Alice> password list
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> password list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": []}}
</div>
~~~~



