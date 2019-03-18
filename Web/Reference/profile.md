

# profile

````
profile    Manage personal and device profiles and accounts.
    create   Create new personal profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    get   Describe the specified profile
    hello   Connect to the service(s) a profile is connected to and report status.
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    recover   Recover escrowed profile
    register   Register existing profile at a new portal
    sync   Synchronize local copies of Mesh profiles with the server
````

# profile create

````
create   Create new personal profile
       New account
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /alg   List of algorithm specifiers
````

````
>profile create  alice@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile create  alice@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# profile create

````
create   Create new device profile
       Device identifier
       Device description
    /alg   List of algorithm specifiers
    /default   Make the new device profile the default
    /ocr   Make the new device profile the default
````
**Missing Example***

# profile hello

````
hello   Connect to the service(s) a profile is connected to and report status.
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
````

````
>profile hello alice@example.com
OK
````

Specifying the /json option returns a result of type ResultHello:

````
>profile hello alice@example.com /json
{
  "ResultHello": {
    "Success": true,
    "Response": {
      "Version": {
        "Major": 0,
        "Minor": 8,
        "Encodings": [{
            "ID": ["application/json"]}]}}}}
````

# profile register

````
register   Register existing profile at a new portal
       New account
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
````

````
>profile register alice@example.net
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile register alice@example.net /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# profile sync

````
sync   Synchronize local copies of Mesh profiles with the server
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>profile sync
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>profile sync /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````


# profile list

````
list   List all profiles on the local machine
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

# profile get

````
get   Describe the specified profile
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>profile get /mesh=alice@example.com
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>profile get /mesh=alice@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# profile escrow

````
escrow   Create a set of key escrow shares
       <Unspecified>
    /alg   List of algorithm specifiers
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /quorum   <Unspecified>
    /shares   <Unspecified>
````

````
>profile escrow
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>profile escrow /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# profile recover

````
recover   Recover escrowed profile
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /file   <Unspecified>
    /verify   <Unspecified>
````
**Missing Example***

# profile export

````
export   Export the specified profile data to the specified file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>profile export profile.dare
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile export profile.dare /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# profile import

````
import   Import the specified profile data to the specified file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>profile import profile.dare
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>profile import profile.dare /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

