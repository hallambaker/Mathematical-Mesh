

# connect

````
connect    
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
**Missing Example***

# connect pending

````
pending   Get list of pending connection requests
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
**Missing Example***

# connect accept

````
accept   Accept a pending connection
       Fingerprint of connection to accept
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
**Missing Example***

# connect reject

````
reject   Reject a pending connection
       Fingerprint of connection to reject
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
**Missing Example***

# connect pin

````
pin   Accept a pending connection
    /length   Length of PIN to generate (default is 8 characters)
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
**Missing Example***

