
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
NDVV-H3OU-CNTV-RZ5H-DJSD-WCNE-JX5A
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NDVV-H3OU-CNTV-RZ5H-DJSD-WCNE-JX5A"}}
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
EBRS-7MKG-URPT-SJZR-SPGQ-7GR4-LPRA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBRS-7MKG-URPT-SJZR-SPGQ-7GR4-LPRA"}}
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
EA3B-MS25-2CW3-3E5F-KHDF-H6BO-VCQR-V4
MANC-TBPU-MWAT-RZ3H-WHBW-FDX2-H2PZ-UU4K-ZQLZ-YE24-SSYH-YQLM-Z7O6-TLAC
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EA3B-MS25-2CW3-3E5F-KHDF-H6BO-VCQR-V4",
    "Identifier": "MANC-TBPU-MWAT-RZ3H-WHBW-FDX2-H2PZ-UU4K-ZQLZ-YE24-SSYH-YQLM-Z7O6-TLAC"}}
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
EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A
MBYF-UEMN-W5IP-CNTW-6LV5-EWN3-S7SO-56BQ-W6P5-2JFW-BQZF-PY2J-BQDA
SAQH-AHY6-QXGX-4HFQ-WZJY-QMX2-MX6F-C
SAQ4-6O5O-YNJ4-HNQV-GEZG-MQU7-5EKK-I
SARC-4WB7-ADNA-ST3Z-VQIU-IUSF-NQWM-I
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A",
    "Identifier": "MBYF-UEMN-W5IP-CNTW-6LV5-EWN3-S7SO-56BQ-W6P5-2JFW-BQZF-PY2J-BQDA",
    "Shares": ["SAQH-AHY6-QXGX-4HFQ-WZJY-QMX2-MX6F-C",
      "SAQ4-6O5O-YNJ4-HNQV-GEZG-MQU7-5EKK-I",
      "SARC-4WB7-ADNA-ST3Z-VQIU-IUSF-NQWM-I"]}}
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
>key recover SAQH-AHY6-QXGX-4HFQ-WZJY-QMX2-MX6F-C SARC-4WB7-ADNA-ST3Z-VQIU-IUSF-NQWM-I
EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQH-AHY6-QXGX-4HFQ-WZJY-QMX2-MX6F-C SARC-4WB7-ADNA-ST3Z-VQIU-IUSF-NQWM-I /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A"}}
````


