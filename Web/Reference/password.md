

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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password add ftp.example.com alice1 password
alice1@ftp.example.com = [password]
````

Specifying the /json option returns a result of type ResultEntry:

````
>password add ftp.example.com alice1 password /json
{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Service": "ftp.example.com",
      "Username": "alice1",
      "Password": "password"}}}
````

# password get

````
get   Lookup password entry
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password delete www.example.com
````

Specifying the /json option returns a result of type Result:

````
>password delete www.example.com /json
{
  "Result": {
    "Success": true}}
````

# password delete

````
delete   Delete password entry
       Domain name of Web site
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>mesh list
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>mesh list /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# password list

````
list   List password entries
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>password list
alice1@ftp.example.com = [password]
alice@example.com@www.example.com = [newpassword]
````

Specifying the /json option returns a result of type ResultDump:

````
>password list /json
{
  "ResultDump": {
    "Success": true,
    "CatalogEntries": [{
        "Service": "ftp.example.com",
        "Username": "alice1",
        "Password": "password"},
      {
        "Service": "www.example.com",
        "Username": "alice@example.com",
        "Password": "newpassword"}]}}
````


