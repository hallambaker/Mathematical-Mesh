

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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network add NetworkEntry1.json NetID1
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>network add NetworkEntry1.json NetID1 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# network delete

````
delete   Delete calendar entry
       Network entry identifier
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network delete NetID2
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>network delete NetID2 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# network get

````
get   Lookup calendar entry
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network get NetID2
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>network get NetID2 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# network dump

````
dump   List network entries
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>network list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

