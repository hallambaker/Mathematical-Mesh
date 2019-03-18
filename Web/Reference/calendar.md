

# calendar

````
calendar    Manage calendar catalogs connected to an account
    add   Add calendar entry from file
    delete   Delete calendar entry
    dump   List calendar entries
    get   Lookup calendar entry
````


# calendar add

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
>calendar add CalendarEntry1.json CalID1
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>calendar add CalendarEntry1.json CalID1 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# calendar delete

````
delete   Delete calendar entry
       Contact entry identifier
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>calendar delete CalID1
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>calendar delete CalID1 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# calendar get

````
get   Lookup calendar entry
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>calendar get CalID1
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>calendar get CalID1 /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# calendar dump

````
dump   List calendar entries
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>calendar list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>calendar list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````


