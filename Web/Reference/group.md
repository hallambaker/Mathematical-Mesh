

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


# profile create

````
create   Create recryption group
       Recryption group name in user@example.com format
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
````
# profile add

````
add   Add user to recryption group
       Recryption group name in user@example.com format
       User to add
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
# profile delete

````
delete   Remove user from recryption group
       Recryption group name in user@example.com format
       User to delete
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

