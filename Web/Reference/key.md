
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
NBFH-DXHR-M37G-SYJ6-WMM6-2422-MABQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBFH-DXHR-M37G-SYJ6-WMM6-2422-MABQ"}}
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
EAQX-MQXL-N4BV-7JXT-MTVH-BU7D-6Y3A
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAQX-MQXL-N4BV-7JXT-MTVH-BU7D-6Y3A"}}
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
EAGU-FEL7-UZR4-EHZC-YZD5-UBRU-P534-W2
MA6G-GHBR-RVPX-BZZY-XG2U-VVBD-YOGN-DRVF-SK4D-U7DT-XWHJ-T53G-ROWK-WSFG
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAGU-FEL7-UZR4-EHZC-YZD5-UBRU-P534-W2",
    "Identifier": "MA6G-GHBR-RVPX-BZZY-XG2U-VVBD-YOGN-DRVF-SK4D-U7DT-XWHJ-T53G-ROWK-WSFG"}}
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
EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q
MDI4-BCEK-HIKC-LOAC-TWLP-27D3-XKCZ-CXOQ-4FRV-GBB3-GWGH-5NRF-NGTQ
SAQI-K3MQ-LLTF-7UOL-HZHV-Z245-BAWI-C
SAQ2-NOV6-P6RZ-CFK6-3O27-SA6C-APLI-W
SARM-QB7M-URQM-EWHS-PEOJ-KG7G-76AJ-K
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q",
    "Identifier": "MDI4-BCEK-HIKC-LOAC-TWLP-27D3-XKCZ-CXOQ-4FRV-GBB3-GWGH-5NRF-NGTQ",
    "Shares": ["SAQI-K3MQ-LLTF-7UOL-HZHV-Z245-BAWI-C",
      "SAQ2-NOV6-P6RZ-CFK6-3O27-SA6C-APLI-W",
      "SARM-QB7M-URQM-EWHS-PEOJ-KG7G-76AJ-K"]}}
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
>key recover SAQI-K3MQ-LLTF-7UOL-HZHV-Z245-BAWI-C SARM-QB7M-URQM-EWHS-PEOJ-KG7G-76AJ-K
EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQI-K3MQ-LLTF-7UOL-HZHV-Z245-BAWI-C SARM-QB7M-URQM-EWHS-PEOJ-KG7G-76AJ-K /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q"}}
````


