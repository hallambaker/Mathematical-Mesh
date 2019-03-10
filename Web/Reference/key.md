# Key

````
key
    /earl   Return a randomized secret value and locator as UDFs
    /nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    /recover   Recover a secret value from the shares provided
    /secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    /share   Split a secret value according to the specified shares and quorum
````


## key nonce

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

## key secret

````
/secret
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````

The secret command creates a randomized secret value formatted as a UDF Encryption 
Key Type.

## key earl

````
/earl
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
````

## key share

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

## key recover

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

