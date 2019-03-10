

````
profile
    /accept   Accept a pending connection
    /connect   Connect to an existing profile registered at a portal
    /device   Create new device profile
    /dump   Describe the specified profile
    /escrow   Create a set of key escrow shares
    /export   Export the specified profile data to the specified file
    /hello   Connect to the service(s) a profile is connected to and report status.
    /import   Import the specified profile data to the specified file
    /list   List all profiles on the local machine
    /master   Create new personal profile
    /pending   Get list of pending connection requests
    /pin   Accept a pending connection
    /recover   Recover escrowed profile
    /register   Register existing profile at a new portal
    /reject   Reject a pending connection
    /sync   Synchronize local copies of Mesh profiles with the server
````


````
/hello
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
````

````
/device
    /alg   List of algorithm specifiers
       Device identifier
       Device description
    /default   Make the new device profile the default
````


````
/master
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
/register
       New account
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
````


````
/sync
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


````
/escrow
    /alg   List of algorithm specifiers
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
       <Unspecified>
    /quorum   <Unspecified>
    /shares   <Unspecified>
````


````
/recover
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
       <Unspecified>
    /file   <Unspecified>
    /verify   <Unspecified>
````


````
/export
       <Unspecified>
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


````
/import
       <Unspecified>
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


````
/list
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


````
/dump
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


````
/pending
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


````
/connect
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


````
/accept
       Fingerprint of connection to accept
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````


````
/reject
       Fingerprint of connection to reject
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
/pin
    /length   Length of PIN to generate (default is 8 characters)
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

