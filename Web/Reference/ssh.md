

# ssh

````
ssh    Manage SSH profiles connected to a personal profile
    create   Generate a new SSH public keypair for the current machine and add to the personal profile
    private   Extract the private key for this device
    public   Extract the public key for this device
````


# ssh create

````
create   Generate a new SSH public keypair for the current machine and add to the personal profile
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
    /alg   List of algorithm specifiers
    /id   Key identifier
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

# ssh private

````
private   Extract the private key for this device
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /password   Password to encrypt private key
    /file   Output file
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

# ssh public

````
public   Extract the public key for this device
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
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

# ssh host

````
host   Add one or more hosts to the known_hosts file
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
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

# ssh host

````
host   Add one or more hosts to the known_hosts file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
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

# ssh client

````
client   Add one or more keys to the authorized_keys file
       <Unspecified>
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
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

# ssh host

````
host   List the known SSH sites (aka known hosts)
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
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

# ssh client

````
client   List the authorized device keys (aka authorized_keys)
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
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


