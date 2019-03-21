
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
NBZN-6OAF-5ASD-DGAE-6JFA-JK3Q-5CUA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBZN-6OAF-5ASD-DGAE-6JFA-JK3Q-5CUA"}}
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
ECBJ-PLU4-G6QV-ZPFE-3GWW-QB6P-ZQWQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECBJ-PLU4-G6QV-ZPFE-3GWW-QB6P-ZQWQ"}}
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
EAIF-F3UP-7U6T-VYSA-JEZ4-IXA2-UUGA-5W
MCJO-A7Z4-OO3X-P6XB-AJT2-VAUH-7TXC-ABJ7-ZVF2-DUNL-GUFL-BCVX-WGTE-2GSW
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAIF-F3UP-7U6T-VYSA-JEZ4-IXA2-UUGA-5W",
    "Identifier": "MCJO-A7Z4-OO3X-P6XB-AJT2-VAUH-7TXC-ABJ7-ZVF2-DUNL-GUFL-BCVX-WGTE-2GSW"}}
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
ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ
MAV5-OE43-PQRW-RCVS-O3ZB-CQHA-NHAY-OBHV-S4KZ-UAIW-ZWNI-HOMQ-5VWQ
SAQG-3PFO-KME2-BF44-P5WV-2AXW-PWJ4-6
SAQT-KL6D-5TNT-3YY7-XN6F-Z7QO-AJEV-K
SARP-ZIWZ-Q2WN-WLVC-66FV-Z6JF-Q37Q-4
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ",
    "Identifier": "MAV5-OE43-PQRW-RCVS-O3ZB-CQHA-NHAY-OBHV-S4KZ-UAIW-ZWNI-HOMQ-5VWQ",
    "Shares": ["SAQG-3PFO-KME2-BF44-P5WV-2AXW-PWJ4-6",
      "SAQT-KL6D-5TNT-3YY7-XN6F-Z7QO-AJEV-K",
      "SARP-ZIWZ-Q2WN-WLVC-66FV-Z6JF-Q37Q-4"]}}
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
>key recover SAQG-3PFO-KME2-BF44-P5WV-2AXW-PWJ4-6 SARP-ZIWZ-Q2WN-WLVC-66FV-Z6JF-Q37Q-4
ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQG-3PFO-KME2-BF44-P5WV-2AXW-PWJ4-6 SARP-ZIWZ-Q2WN-WLVC-66FV-Z6JF-Q37Q-4 /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ"}}
````


