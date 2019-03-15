

# group

````
group    Group management commands
    add   Add user to recryption group
    create   Create recryption group
    delete   Remove user from recryption group
    list   List members of a recryption group
````


# group create

````
create   Create recryption group
       Recryption group name in user@example.com format
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
````

````
>group 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>group  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# group add

````
add   Add user to recryption group
       Recryption group name in user@example.com format
       User to add
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>group 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>group  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# group delete

````
delete   Remove user from recryption group
       Recryption group name in user@example.com format
       User to delete
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>group 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>group  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# group list

````
list   List members of a recryption group
       Recryption group name in user@example.com format
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>group 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>group  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

