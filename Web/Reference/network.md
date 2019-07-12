

# network

````
network    Manage network profile settings
    add   Add calendar entry from file
    delete   Delete calendar entry
    dump   List network entries
    get   Lookup calendar entry
````


# network add

````
add   Add calendar entry from file
       <Unspecified>
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network add NetworkEntry1.json NetID1
{Username}@{Service} = [{Password}]````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> network add NetworkEntry1.json NetID1 /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Service": "NetID1"}}}
````

# network delete

````
delete   Delete calendar entry
       Network entry identifier
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network delete NetID2
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
Alice> network delete NetID2 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# network get

````
get   Lookup calendar entry
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network get NetID2
Empty
````

Specifying the /json option returns a result of type ResultEntry:

````
Alice> network get NetID2 /json
{
  "ResultEntry": {
    "Success": false}}
````

# network dump

````
dump   List network entries
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
Alice> network list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
Alice> network list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

