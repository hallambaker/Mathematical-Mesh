

# connect

````
connect    Device connection commands.
    accept   Accept a pending connection
    pending   Get list of pending connection requests
    pin   Accept a pending connection
    reject   Reject a pending connection
    request   Connect to an existing profile registered at a portal
````







# connect request

````
request   Connect to an existing profile registered at a portal
       New portal account
    /pin   One time use authenticator
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
````

````
>connect request
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>connect request /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# connect pending

````
pending   Get list of pending connection requests
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>connect pending
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>connect pending /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# connect accept

````
accept   Accept a pending connection
       Fingerprint of connection to accept
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>connect accept id
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>connect accept id /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# connect reject

````
reject   Reject a pending connection
       Fingerprint of connection to reject
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>connect reject id
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>connect reject id /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# connect pin

````
pin   Accept a pending connection
    /length   Length of PIN to generate (default is 8 characters)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>connect pin
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>connect pin /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

