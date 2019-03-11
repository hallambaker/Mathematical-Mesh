
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
NDTB-6CPK-QU33-TMTA-EE23-NUWL-JKAQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NDTB-6CPK-QU33-TMTA-EE23-NUWL-JKAQ"}}
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
EASL-RTEE-QFUF-SFDQ-IUOB-HOS3-5BEQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EASL-RTEE-QFUF-SFDQ-IUOB-HOS3-5BEQ"}}
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
ECXR-S6AG-SVR5-BHKV-X4S5-5LNK-J6UQ-7N
MAS6-LOUP-LMEV-A7OE-F2J4-LOTT-K5SE-PF5Q-FME7-ALLB-YPTB-LO5I-RB66-B2VW
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECXR-S6AG-SVR5-BHKV-X4S5-5LNK-J6UQ-7N",
    "Identifier": "MAS6-LOUP-LMEV-A7OE-F2J4-LOTT-K5SE-PF5Q-FME7-ALLB-YPTB-LO5I-RB66-B2VW"}}
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
ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA
MCYH-DIY6-7OZZ-36RK-NHEI-FH43-YORF-PYXX-KN75-SEIE-BFPZ-AMDO-ZEIQ
SAQI-LSPX-QRSK-3TZA-KJIS-DCQI-HMIA-C
SAQY-H4GX-53CO-ECCJ-5GE3-BU5B-VZYL-A
SARI-EF5Y-LESR-MQLT-QDBE-AHJ3-EHIV-6
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA",
    "Identifier": "MCYH-DIY6-7OZZ-36RK-NHEI-FH43-YORF-PYXX-KN75-SEIE-BFPZ-AMDO-ZEIQ",
    "Shares": ["SAQI-LSPX-QRSK-3TZA-KJIS-DCQI-HMIA-C",
      "SAQY-H4GX-53CO-ECCJ-5GE3-BU5B-VZYL-A",
      "SARI-EF5Y-LESR-MQLT-QDBE-AHJ3-EHIV-6"]}}
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
>key recover SAQI-LSPX-QRSK-3TZA-KJIS-DCQI-HMIA-C SARI-EF5Y-LESR-MQLT-QDBE-AHJ3-EHIV-6
ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQI-LSPX-QRSK-3TZA-KJIS-DCQI-HMIA-C SARI-EF5Y-LESR-MQLT-QDBE-AHJ3-EHIV-6 /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA"}}
````


