

# profile

````
profile    
    accept   Accept a pending connection
    connect   Connect to an existing profile registered at a portal
    device   Create new device profile
    dump   Describe the specified profile
    escrow   Create a set of key escrow shares
    export   Export the specified profile data to the specified file
    hello   Connect to the service(s) a profile is connected to and report status.
    import   Import the specified profile data to the specified file
    list   List all profiles on the local machine
    master   Create new personal profile
    pending   Get list of pending connection requests
    pin   Accept a pending connection
    recover   Recover escrowed profile
    register   Register existing profile at a new portal
    reject   Reject a pending connection
    sync   Synchronize local copies of Mesh profiles with the server
````


# profile contact

````
contact   Post a conection request to a user
       The recipient to send the conection request to
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile confirm

````
confirm   Post a confirmation request to a user
       The recipient to send the confirmation request to
       The recipient to send the confirmation request to
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile pending

````
pending   List pending requests
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile status

````
status   Request status of pending requests
    /requestid   Specifies the request to provide the status of
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile accept

````
accept   Accept a pending request
    /requestid   Specifies the request to accept
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile reject

````
reject   Reject a pending request
    /requestid   Specifies the request to reject
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile block

````
block   Reject a pending request and block requests from that source
    /requestid   Specifies the request to reject and block
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


