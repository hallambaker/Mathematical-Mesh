

# contact

````
contact    Manage contact catalogs connected to an account
    add   Add contact entry from file
    delete   Delete contact entry
    get   Lookup contact entry
    list   List contact entries
````


# contact add

````
add   Add contact entry from file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>contact add carol-contact.json
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>contact add carol-contact.json /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
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
>contact delete carol@example.com
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>contact delete carol@example.com /json
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
>contact get carol@example.com
Empty
````

Specifying the /json option returns a result of type ResultEntry:

````
>contact get carol@example.com /json
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
>contact list
````

Specifying the /json option returns a result of type ResultDump:

````
>contact list /json
{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": []}}
````

