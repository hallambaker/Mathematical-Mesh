

# password

````
password    Manage password catalogs connected to an account
    add   Add password entry
    delete   Delete password entry
    get   Lookup password entry
    list   List password entries
````


# password add

````
add   Add password entry
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>password  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# password get

````
get   Lookup password entry
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>password  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# password delete

````
delete   Delete password entry
       Domain name of Web site
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>profile list
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# password list

````
list   List password entries
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>password  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````


