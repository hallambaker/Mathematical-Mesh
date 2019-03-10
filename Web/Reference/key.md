
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
/nonce
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````


The nonce command creates a randomized nonce value formatted as a UDF Nonce Type.

Nonce values should be used when it is important that a value be unpredictable but 
does not need to be kept secret. For example, the challenge in a challenge/response
protocol.



````
/secret
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````

The secret command creates a randomized secret value formatted as a UDF Encryption 
Key Type.


````
/earl
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
````



````
/share
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
    /quorum   The number of shares required to recover the secret
    /shares   The number of shares to create
````


````
/recover
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
       Share value #1
       Share value #2
       Share value #3
       Share value #4
       Share value #5
       Share value #6
       Share value #7
       Share value #8
````

