
# key

````
key    Key operations.
    earl   Return a randomized secret value and locator as UDFs
    nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    recover   Recover a secret value from the shares provided
    secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    share   Split a secret value according to the specified shares and quorum
````

The Key command set contains commands that operate on cryptographic keys and
nonces.


# key nonce

````
nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````


The `key nonce` command returns a randomized nonce value formatted as a UDF nonce type.

Nonce values should be used when it is important that a value be unpredictable but 
does not need to be kept secret. For example, the challenge in a challenge/response
protocol.


````
>key nonce
NB53-JR66-6S3H-BUAQ-VILK-BZEJ-5NZQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NB53-JR66-6S3H-BUAQ-VILK-BZEJ-5NZQ"}}
````

# key secret

````
secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
````

The `key secret` command returns a randomized secret value formatted as a UDF Encryption 
key type.


````
>key secret
EANA-5VUF-D5DS-WE7H-SDJZ-RVYK-A7VQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EANA-5VUF-D5DS-WE7H-SDJZ-RVYK-A7VQ"}}
````


# key earl

````
earl   Return a randomized secret value and locator as UDFs
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
````

The `key earl` command returns a randomized secret value and a fingerprint of the secret 
value, formatted as a UDF Encryption key type and Content Digest Type


````
>key earl
ECLU-XHSG-53QK-ULTJ-TR2G-7GRU-4PKF-WU
MAXU-G4VT-U553-3EWV-53EI-RAR6-EVB2-U5E2-XVDV-3FVW-O6UB-IFNG-YASE-74YZ
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECLU-XHSG-53QK-ULTJ-TR2G-7GRU-4PKF-WU",
    "Identifier": "MAXU-G4VT-U553-3EWV-53EI-RAR6-EVB2-U5E2-XVDV-3FVW-O6UB-IFNG-YASE-74YZ"}}
````

# key share

````
share   Split a secret value according to the specified shares and quorum
       The parameter to share
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
    /quorum   The number of shares required to recover the secret
    /shares   The number of shares to create
````

The `key share` command returns a randomized secret value and a set of shares for the secret
formatted as a UDF Encryption key type and Share types


````
>key share
ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA
MCGO-YNKF-WODB-LEQN-YK6L-UHIO-45K4-VIAI-2HJL-TQE6-F6VZ-Q5C7-Q65Q
SAQN-22T7-IK4J-OL22-HNOA-KM4Q-36DF-Y
SAQT-G6IL-ITYH-XLAM-F3CI-GLZU-Q5SW-K
SARI-TB4X-I4UG-AKF6-EIWQ-CKWY-F5CK-C
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA",
    "Identifier": "MCGO-YNKF-WODB-LEQN-YK6L-UHIO-45K4-VIAI-2HJL-TQE6-F6VZ-Q5C7-Q65Q",
    "Shares": ["SAQN-22T7-IK4J-OL22-HNOA-KM4Q-36DF-Y",
      "SAQT-G6IL-ITYH-XLAM-F3CI-GLZU-Q5SW-K",
      "SARI-TB4X-I4UG-AKF6-EIWQ-CKWY-F5CK-C"]}}
````


# key recover

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
````

The `key recover` command combines the specified set of share to recover the original secret 
value as a UDF Encryption key type.


````
>key recover SAQN-22T7-IK4J-OL22-HNOA-KM4Q-36DF-Y SARI-TB4X-I4UG-AKF6-EIWQ-CKWY-F5CK-C
ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQN-22T7-IK4J-OL22-HNOA-KM4Q-36DF-Y SARI-TB4X-I4UG-AKF6-EIWQ-CKWY-F5CK-C /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA"}}
````


