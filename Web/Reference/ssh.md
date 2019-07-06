

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
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
    /alg   List of algorithm specifiers
    /id   Key identifier
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# ssh private

````
private   Extract the private key for this device
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /password   Password to encrypt private key
    /file   Output file
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# ssh public

````
public   Extract the public key for this device
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /format   File format
    /file   Output file
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# ssh host

````
host   Add one or more hosts to the known_hosts file
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# ssh host

````
host   Add one or more hosts to the known_hosts file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# ssh client

````
client   Add one or more keys to the authorized_keys file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# ssh host

````
host   List the known SSH sites (aka known hosts)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````

# ssh client

````
client   List the authorized device keys (aka authorized_keys)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /application   The application format
````

````
>profile list
ERROR - The command  is not known.
````

Specifying the /json option returns a result of type Result:

````
>profile list /json
{
  "Result": {
    "Success": false,
    "Reason": "The command  is not known."}}
````


