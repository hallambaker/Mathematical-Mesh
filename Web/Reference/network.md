

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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>network 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>network  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
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
>network 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>network  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
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
>network 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>network  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
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
>network 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>network  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

