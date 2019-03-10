
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




# profile nonce

````
nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````


The `nonce` command returns a randomized nonce value formatted as a UDF nonce type.

Nonce values should be used when it is important that a value be unpredictable but 
does not need to be kept secret. For example, the challenge in a challenge/response
protocol.



# profile secret

````
secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````

The `secret` command returns a randomized secret value formatted as a UDF Encryption 
key type.


# profile earl

````
earl   Return a randomized secret value and locator as UDFs
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
````

The `earl` command returns a randomized secret value and a fingerprint of the secret 
value, formatted as a UDF Encryption key type and Content Digest Type

# profile share

````
share   Split a secret value according to the specified shares and quorum
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
    /quorum   The number of shares required to recover the secret
    /shares   The number of shares to create
````

The `share` command returns a randomized secret value and a set of shares for the secret
formatted as a UDF Encryption key type and Share types

# profile recover

````
recover   Recover a secret value from the shares provided
       Share value #1
       Share value #2
       Share value #3
       Share value #4
       Share value #5
       Share value #6
       Share value #7
       Share value #8
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
````

The `recover` command combines the specified set of share to recover the original secret 
value as a UDF Encryption key type.

