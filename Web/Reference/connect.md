

# device

````
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
    create   Create new device profile
    delete   Remove device from device catalog
    earl   Connect a new device by means of an EARL
    list   List devices in the device catalog
    pending   Get list of pending connection requests
    pin   Accept a pending connection
    reject   Reject a pending connection
    request   Connect to an existing profile registered at a portal
````

# device request

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
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /ssh   Authorize use of SSH
    /password   Authorize access to password catalog
    /message   Authorize access to send and receive messages.
    /contacts   Authorize access to contacts catalog
    /calendar   Authorize access to calendar catalog
    /network   Authorize access to network catalog
    /confirm   Authorize response to confirmation requests
````

````
>device request alice@example.com
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device request alice@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device pending

````
pending   Get list of pending connection requests
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>device pending
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device pending /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device accept

````
accept   Accept a pending connection
       Fingerprint of connection to accept
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>device accept id
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device accept id /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device reject

````
reject   Reject a pending connection
       Fingerprint of connection to reject
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>device reject id
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device reject id /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device pin

````
pin   Accept a pending connection
    /length   Length of PIN to generate (default is 8 characters)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>device pin
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device pin /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device pin

````
pin   Accept a pending connection
    /length   Length of PIN to generate (default is 8 characters)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>device pin
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device pin /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device earl

````
earl   Connect a new device by means of an EARL
       The EARL locator
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
````

````
>device 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>device  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# device list

````
list   List devices in the device catalog
       Recryption group name in user@example.com format
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>device 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>device  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# device delete

````
delete   Remove device from device catalog
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>device 
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>device  /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

