
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
Alice> key nonce
NDWN-5BEK-ENOK-AHBF-TC73-AJ55-52CA
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NDWN-5BEK-ENOK-AHBF-TC73-AJ55-52CA"}}
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
Alice> key secret
ECJK-W3X3-3XAE-YK3H-Y4WO-OXHB-6P3Q
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECJK-W3X3-3XAE-YK3H-Y4WO-OXHB-6P3Q"}}
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
Alice> key earl
EBTR-ITUQ-M3HN-TRWL-VPJ5-G4ND-27HN-UT
MCCY-32DL-SQNL-46SP-J64G-2LV5-MOTF-R7FI-67EO-6FNO-ZBOX-B26K-6G7M-4Q2E
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBTR-ITUQ-M3HN-TRWL-VPJ5-G4ND-27HN-UT",
    "Identifier": "MCCY-32DL-SQNL-46SP-J64G-2LV5-MOTF-R7FI-67EO-6FNO-ZBOX-B26K-6G7M-4Q2E"}}
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
Alice> key share
EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A
MDS2-IZBW-P5YC-HQKZ-3GHJ-ZEI3-6CKV-2M2A-O45X-7XLG-RIJP-637L-JSPQ
SAQF-LAQZ-7DMQ-VZ5L-EXQN-XTRC-ZVMR-Y
SAQZ-PPVK-2SWN-XAFC-TAZJ-6WNK-65IX-4
SARN-T6Z3-WCAK-YGM2-BKCG-FZJT-EFE6-A
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A",
    "Identifier": "MDS2-IZBW-P5YC-HQKZ-3GHJ-ZEI3-6CKV-2M2A-O45X-7XLG-RIJP-637L-JSPQ",
    "Shares": ["SAQF-LAQZ-7DMQ-VZ5L-EXQN-XTRC-ZVMR-Y",
      "SAQZ-PPVK-2SWN-XAFC-TAZJ-6WNK-65IX-4",
      "SARN-T6Z3-WCAK-YGM2-BKCG-FZJT-EFE6-A"]}}
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
Alice> key recover SAQF-LAQZ-7DMQ-VZ5L-EXQN-XTRC-ZVMR-Y SARN-T6Z3-WCAK-YGM2-BKCG-FZJT-EFE6-A
EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key recover SAQF-LAQZ-7DMQ-VZ5L-EXQN-XTRC-ZVMR-Y SARN-T6Z3-WCAK-YGM2-BKCG-FZJT-EFE6-A /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A"}}
````


