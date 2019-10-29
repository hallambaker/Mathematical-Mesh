

# contact

````
contact    Manage contact catalogs connected to an account
    add   Add contact entry from file
    delete   Delete contact entry
    get   Lookup contact entry
    list   List contact entries
    self   Add contact entry for self
````


# contact add

````
add   Add contact entry from file
    /email   <Unspecified>
    /file   <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> contact add email carol@example.com
{
  "Self": false,
  "Key": "NAB3-WBKU-NAVH-K5BW-AKDW-YET2-2LNF",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> contact add email carol@example.com /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Self": false,
      "Key": "NAB3-WBKU-NAVH-K5BW-AKDW-YET2-2LNF",
      "EnvelopedContact": [{},
        "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}}}
````

# contact delete

````
delete   Delete contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> contact delete carol@example.com
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> contact delete carol@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# contact get

````
get   Lookup contact entry
       Contact entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /encrypt   Encrypt the contact under the specified key
````

````
Alice> contact get carol@example.com
Empty
````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> contact get carol@example.com /json
{
  "ResultEntry": {
    "Success": false}}
````

# contact list

````
list   List contact entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> contact list
{
  "Self": true,
  "Key": "NDTX-ZU63-2WJJ-CFJ2-CZLK-V33F-HJE7",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}{
  "Self": false,
  "Key": "NAB3-WBKU-NAVH-K5BW-AKDW-YET2-2LNF",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}````

Specifying the /json option returns a result of type ResultDump:

````
Alice> contact list /json
{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": [{
        "Self": true,
        "Key": "NDTX-ZU63-2WJJ-CFJ2-CZLK-V33F-HJE7",
        "EnvelopedContact": [{},
          "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]},
      {
        "Self": false,
        "Key": "NAB3-WBKU-NAVH-K5BW-AKDW-YET2-2LNF",
        "EnvelopedContact": [{},
          "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}]}}
````

