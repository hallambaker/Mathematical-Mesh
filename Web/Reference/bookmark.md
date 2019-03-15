

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
add   Add bookmark
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>bookmark  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# network delete

````
delete   Delete bookmark entry
       Contact entry identifier
    /path   <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>bookmark  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# network get

````
get   Lookup bookmark entry
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>bookmark  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# network list

````
list   List bookmark entries
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>bookmark 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>bookmark  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

