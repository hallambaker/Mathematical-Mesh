
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
NBN6-5NSK-RYHT-6P6W-WCMK-B55X-3MZA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBN6-5NSK-RYHT-6P6W-WCMK-B55X-3MZA"}}
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
EAOX-BMFS-JQ6S-S72U-FHVS-C6KK-RFRA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAOX-BMFS-JQ6S-S72U-FHVS-C6KK-RFRA"}}
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
EDKZ-42TC-MG7R-RXWD-KIIM-EN22-5QZT-IK
MDJW-3WA2-RRXN-4FSD-HFMK-MPGW-PST7-2JZA-4352-6Y4Y-DZXW-J5YT-GZU3-AJ4N
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDKZ-42TC-MG7R-RXWD-KIIM-EN22-5QZT-IK",
    "Identifier": "MDJW-3WA2-RRXN-4FSD-HFMK-MPGW-PST7-2JZA-4352-6Y4Y-DZXW-J5YT-GZU3-AJ4N"}}
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
EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA
MCZW-AMSV-6ERA-F27E-WE5M-VHDW-K3L4-AHAS-V6BV-RJQ6-IB2P-IREZ-BOVQ
SAQG-COEC-KBOQ-XXQO-45SF-GSBK-K64B-6
SAQ3-M2U6-YX5B-MWP5-I4M6-KVLE-P4DL-E
SARA-XHF3-HOLS-BVPL-U3HX-OYU6-UZKR-E
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA",
    "Identifier": "MCZW-AMSV-6ERA-F27E-WE5M-VHDW-K3L4-AHAS-V6BV-RJQ6-IB2P-IREZ-BOVQ",
    "Shares": ["SAQG-COEC-KBOQ-XXQO-45SF-GSBK-K64B-6",
      "SAQ3-M2U6-YX5B-MWP5-I4M6-KVLE-P4DL-E",
      "SARA-XHF3-HOLS-BVPL-U3HX-OYU6-UZKR-E"]}}
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
>key recover SAQG-COEC-KBOQ-XXQO-45SF-GSBK-K64B-6 SARA-XHF3-HOLS-BVPL-U3HX-OYU6-UZKR-E
EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQG-COEC-KBOQ-XXQO-45SF-GSBK-K64B-6 SARA-XHF3-HOLS-BVPL-U3HX-OYU6-UZKR-E /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA"}}
````


