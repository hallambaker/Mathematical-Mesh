

# message

````
message    Contact and confirmation message options
    accept   Accept a pending request
    block   Reject a pending request and block requests from that source
    confirm   Post a confirmation request to a user
    contact   Post a conection request to a user
    pending   List pending requests
    reject   Reject a pending request
    status   Request status of pending requests
````


# message contact

````
contact   Post a conection request to a user
       The recipient to send the conection request to
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message contact alice@example.com
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>message contact alice@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# message confirm

````
confirm   Post a confirmation request to a user
       The recipient to send the confirmation request to
       The recipient to send the confirmation request to
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message confirm alice@example.com "Purchase equipment for $6,000?"
OK
````

Specifying the /json option returns a result of type Result:

````
>message confirm alice@example.com "Purchase equipment for $6,000?" /json
{
  "Result": {
    "Success": true}}
````


# message pending

````
pending   List pending requests
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message pending
OK
````

Specifying the /json option returns a result of type ResultPending:

````
>message pending /json
{
  "ResultPending": {
    "Success": true,
    "Messages": []}}
````


# message status

````
status   Request status of pending requests
    /requestid   Specifies the request to provide the status of
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message status tbs
OK
````

Specifying the /json option returns a result of type Result:

````
>message status tbs /json
{
  "Result": {
    "Success": true}}
````

# message accept

````
accept   Accept a pending request
    /requestid   Specifies the request to accept
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message accept tbs
OK
````

Specifying the /json option returns a result of type Result:

````
>message accept tbs /json
{
  "Result": {
    "Success": true}}
````

# message reject

````
reject   Reject a pending request
    /requestid   Specifies the request to reject
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message reject tbs
OK
````

Specifying the /json option returns a result of type Result:

````
>message reject tbs /json
{
  "Result": {
    "Success": true}}
````

# message block

````
block   Reject a pending request and block requests from that source
    /requestid   Specifies the request to reject and block
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message block mallet@example.com
OK
````

Specifying the /json option returns a result of type Result:

````
>message block mallet@example.com /json
{
  "Result": {
    "Success": true}}
````

