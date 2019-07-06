

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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
````

````
>group create groupies@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>group create groupies@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# group add

````
add   Add user to recryption group
       Recryption group name in user@example.com format
       User to add
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>group add groupies@example.com bob@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>group add groupies@example.com bob@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# group delete

````
delete   Remove user from recryption group
       Recryption group name in user@example.com format
       User to delete
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>group delete groupies@example.com bob@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>group delete groupies@example.com bob@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# group list

````
list   List members of a recryption group
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>group list groupies@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>group list groupies@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

