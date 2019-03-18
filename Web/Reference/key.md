
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
NAQJ-65QK-DJG4-UVMU-FC3B-63FK-V2UA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NAQJ-65QK-DJG4-UVMU-FC3B-63FK-V2UA"}}
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
ED42-W24U-HIY4-IENG-I225-ENYA-H7VQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ED42-W24U-HIY4-IENG-I225-ENYA-H7VQ"}}
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
ED5J-KOG5-MFFA-Q6WP-SOE7-4DPM-NSQI-F2
MADM-FRBG-JSE3-KLNX-C3KK-TGNC-RDGO-3LUO-Z7YY-OOW6-HGA5-AQX3-XXEW-L4NR
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ED5J-KOG5-MFFA-Q6WP-SOE7-4DPM-NSQI-F2",
    "Identifier": "MADM-FRBG-JSE3-KLNX-C3KK-TGNC-RDGO-3LUO-Z7YY-OOW6-HGA5-AQX3-XXEW-L4NR"}}
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
EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA
MAIC-TKNE-ARN4-TV6W-LUKJ-3DGD-QLSU-KTSI-OVYC-MJ55-EQC6-RKAX-TCGQ
SAQK-T7ZZ-HFIS-2SO4-5GOB-I3MT-ALFK-O
SAQS-IROE-ZWVU-WYN6-MSJY-5V3Z-ZZSE-6
SARJ-5DCQ-MICW-S6M7-36FQ-SQLA-TH7C-U
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA",
    "Identifier": "MAIC-TKNE-ARN4-TV6W-LUKJ-3DGD-QLSU-KTSI-OVYC-MJ55-EQC6-RKAX-TCGQ",
    "Shares": ["SAQK-T7ZZ-HFIS-2SO4-5GOB-I3MT-ALFK-O",
      "SAQS-IROE-ZWVU-WYN6-MSJY-5V3Z-ZZSE-6",
      "SARJ-5DCQ-MICW-S6M7-36FQ-SQLA-TH7C-U"]}}
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
>key recover SAQK-T7ZZ-HFIS-2SO4-5GOB-I3MT-ALFK-O SARJ-5DCQ-MICW-S6M7-36FQ-SQLA-TH7C-U
EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQK-T7ZZ-HFIS-2SO4-5GOB-I3MT-ALFK-O SARJ-5DCQ-MICW-S6M7-36FQ-SQLA-TH7C-U /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA"}}
````


