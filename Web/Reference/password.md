

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
<rsp>alice1@ftp.example.com = [password]
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> password add ftp.example.com alice1 password /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "CatalogedCredential": {
        "Service": "ftp.example.com",
        "Username": "alice1",
        "Password": "password"}}}}
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
<cmd>Alice> password get ftp.example.com
<rsp>alice1@ftp.example.com = [newpassword]
</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> password get ftp.example.com /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "CatalogedCredential": {
        "Service": "ftp.example.com",
        "Username": "alice1",
        "Password": "newpassword"}}}}
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
<cmd>Alice> password delete www.example.com
<rsp></div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> password delete www.example.com /json
<rsp>{
  "Result": {
    "Success": true}}
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
<rsp>CatalogedCredential

CatalogedCredential

</div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> password list /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "CatalogedCredential": {
          "Service": "ftp.example.com",
          "Username": "alice1",
          "Password": "password"}},
      {
        "CatalogedCredential": {
          "Service": "www.example.com",
          "Username": "alice@example.com",
          "Password": "newpassword"}}]}}
</div>
~~~~



