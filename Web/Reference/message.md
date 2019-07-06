

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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message contact alice@example.com
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>message contact alice@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# message confirm

````
confirm   Post a confirmation request to a user
       The recipient to send the confirmation request to
       The recipient to send the confirmation request to
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message confirm alice@example.com "Purchase equipment for $6,000?"
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>message confirm alice@example.com "Purchase equipment for $6,000?" /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````


# message pending

````
pending   List pending requests
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message pending
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>message pending /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````


# message status

````
status   Request status of pending requests
    /requestid   Specifies the request to provide the status of
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message status tbs
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>message status tbs /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# message accept

````
accept   Accept a pending request
    /requestid   Specifies the request to accept
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message accept tbs
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>message accept tbs /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# message reject

````
reject   Reject a pending request
    /requestid   Specifies the request to reject
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message reject tbs
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
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>message block mallet@example.com
````

Specifying the /json option returns a result of type Result:

````
>message block mallet@example.com /json
{
  "Result": {
    "Success": true}}
````

