

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
**Missing Example***


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
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>message pending /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
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
**Missing Example***

# message accept

````
accept   Accept a pending request
    /requestid   Specifies the request to accept
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
**Missing Example***

# message reject

````
reject   Reject a pending request
    /requestid   Specifies the request to reject
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
**Missing Example***

# message block

````
block   Reject a pending request and block requests from that source
    /requestid   Specifies the request to reject and block
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
**Missing Example***

