

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
>password add ftp.example.com alice1 password
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>password add ftp.example.com alice1 password /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
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
>password delete www.example.com
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>password delete www.example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
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
OK
````

Specifying the /json option returns a result of type ResultList:

````
>profile list /json
{
  "ResultList": {
    "Success": true,
    "CatalogEntryDevices": [],
    "Profiles": []}}
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
>password list
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>password list /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````


