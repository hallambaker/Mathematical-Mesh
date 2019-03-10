

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
/create
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /type   The container type, plain/tree/digest/chain/tree
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
       New container
````
````
/archive
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /type   The container type, plain/tree/digest/chain/tree
       Directory containing files to create archive from
    /out   New container
````
````
/append
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
       Container to append to
       File to append
    /key   <Unspecified>
````
````
/delete
       Container to append to
       File to append
    /key   <Unspecified>
````
````
/index
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
       Container to append to
````
````
/extract
       Container to read
       Extracted file
    /record   Index number of file to extract
    /file   Name of file to extract
    /key   <Unspecified>
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````
````
/copy
       Container to read
       Copy
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /alg   List of algorithm specifiers
    /type   The container type, plain/tree/digest/chain/tree
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /decrypt   Decrypt contents
    /index   Append an index record to the end
    /purge   Purge unused data etc.
````
````
/verify
    /portal   Account identifier (e.g. alice@example.com)
    /udf   Profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
       Container to read
````

