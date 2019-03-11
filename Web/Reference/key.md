
# key

````
key    
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
NDC5-I222-S6AH-PIBF-YWOU-QZTI-FDGA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NDC5-I222-S6AH-PIBF-YWOU-QZTI-FDGA"}}
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
ECFY-ODKK-OLSE-7HBB-CC2Z-YLOL-XU3A
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECFY-ODKK-OLSE-7HBB-CC2Z-YLOL-XU3A"}}
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
EBRQ-UE3Z-OPWO-ZLEN-67FF-HVGU-L6V5-L2
MAX5-PQI4-ADJG-CDKE-23ZQ-622L-VQUA-WESY-X6PK-DIBR-XP3G-UDKO-52FT-BDUK
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBRQ-UE3Z-OPWO-ZLEN-67FF-HVGU-L6V5-L2",
    "Identifier": "MAX5-PQI4-ADJG-CDKE-23ZQ-622L-VQUA-WESY-X6PK-DIBR-XP3G-UDKO-52FT-BDUK"}}
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
ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA
MB5C-QW6E-JTAF-TQHQ-2URX-WJ6Z-TGVI-DHZM-SVIW-QKQB-DSWO-S3VR-2KTA
SAQK-V2IL-LS6Z-ZZSZ-6JIE-MS2B-6SQB-M
SAQV-OXGR-XFFF-BR57-6ICF-723U-4YWY-4
SARA-HUEY-CXLQ-JKJF-6G4H-TC5H-265Q-M
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA",
    "Identifier": "MB5C-QW6E-JTAF-TQHQ-2URX-WJ6Z-TGVI-DHZM-SVIW-QKQB-DSWO-S3VR-2KTA",
    "Shares": ["SAQK-V2IL-LS6Z-ZZSZ-6JIE-MS2B-6SQB-M",
      "SAQV-OXGR-XFFF-BR57-6ICF-723U-4YWY-4",
      "SARA-HUEY-CXLQ-JKJF-6G4H-TC5H-265Q-M"]}}
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
>key recover SAQK-V2IL-LS6Z-ZZSZ-6JIE-MS2B-6SQB-M SARA-HUEY-CXLQ-JKJF-6G4H-TC5H-265Q-M
ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQK-V2IL-LS6Z-ZZSZ-6JIE-MS2B-6SQB-M SARA-HUEY-CXLQ-JKJF-6G4H-TC5H-265Q-M /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA"}}
````


