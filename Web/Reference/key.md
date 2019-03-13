
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
NC54-REPP-6VJG-NA2A-WP3W-KFHK-SCQQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NC54-REPP-6VJG-NA2A-WP3W-KFHK-SCQQ"}}
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
ECH6-HZZO-JFWQ-AI3B-QNT2-QC7S-U2JQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECH6-HZZO-JFWQ-AI3B-QNT2-QC7S-U2JQ"}}
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
EDLD-QEEU-LBM7-TJRY-UNCS-RHKT-SVFC-NW
MCEU-JH72-TL55-FQUZ-O4NZ-NZPC-66SQ-5N6C-4KBU-SB4M-H62O-R2F6-QFEV-B4YC
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDLD-QEEU-LBM7-TJRY-UNCS-RHKT-SVFC-NW",
    "Identifier": "MCEU-JH72-TL55-FQUZ-O4NZ-NZPC-66SQ-5N6C-4KBU-SB4M-H62O-R2F6-QFEV-B4YC"}}
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
EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ
MDKF-ECPI-S2AQ-N3ER-YENX-AD7O-KR7L-46PX-H5SC-TGCF-APSH-7W6W-FDJA
SAQD-XUZF-XMKG-CBR6-L7CI-H5FI-UTPP-6
SAQ2-VQNA-2TWV-FAGO-IZQQ-CB6O-ZMP5-E
SARB-TMA3-53DE-H626-FT6X-4GXU-6FQH-E
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ",
    "Identifier": "MDKF-ECPI-S2AQ-N3ER-YENX-AD7O-KR7L-46PX-H5SC-TGCF-APSH-7W6W-FDJA",
    "Shares": ["SAQD-XUZF-XMKG-CBR6-L7CI-H5FI-UTPP-6",
      "SAQ2-VQNA-2TWV-FAGO-IZQQ-CB6O-ZMP5-E",
      "SARB-TMA3-53DE-H626-FT6X-4GXU-6FQH-E"]}}
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
>key recover SAQD-XUZF-XMKG-CBR6-L7CI-H5FI-UTPP-6 SARB-TMA3-53DE-H626-FT6X-4GXU-6FQH-E
EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQD-XUZF-XMKG-CBR6-L7CI-H5FI-UTPP-6 SARB-TMA3-53DE-H626-FT6X-4GXU-6FQH-E /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ"}}
````


