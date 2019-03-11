
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
NDV4-W4Q3-LSQX-O5YM-3XZG-EQKX-5G7Q
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NDV4-W4Q3-LSQX-O5YM-3XZG-EQKX-5G7Q"}}
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
EAYK-XISS-BG4R-ON3G-JJKF-T35Z-RI4Q
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAYK-XISS-BG4R-ON3G-JJKF-T35Z-RI4Q"}}
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
ECDJ-M5XQ-F6KZ-EOHJ-FVEH-AXB2-XK5B-ND
MCTO-HA7X-5WG5-SGOR-BI26-VX5G-TGEW-MBWZ-HUF2-ZHZR-UJHN-66FM-SMVM-Y3P6
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECDJ-M5XQ-F6KZ-EOHJ-FVEH-AXB2-XK5B-ND",
    "Identifier": "MCTO-HA7X-5WG5-SGOR-BI26-VX5G-TGEW-MBWZ-HUF2-ZHZR-UJHN-66FM-SMVM-Y3P6"}}
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
ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA
MCNY-TSXH-KNNZ-LQFR-F7EO-PWNA-5EJI-F3WI-Z6VD-ANP4-5O6D-7VBP-G4AA
SAQN-W4Z2-QJHC-B7A3-NSUR-JETS-K64N-6
SAQR-KLIB-UAE3-A2F5-ZTCN-FNOG-K4S3-C
SARE-5ZWI-XXCT-7VLA-FTQJ-BWI2-K2JL-M
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA",
    "Identifier": "MCNY-TSXH-KNNZ-LQFR-F7EO-PWNA-5EJI-F3WI-Z6VD-ANP4-5O6D-7VBP-G4AA",
    "Shares": ["SAQN-W4Z2-QJHC-B7A3-NSUR-JETS-K64N-6",
      "SAQR-KLIB-UAE3-A2F5-ZTCN-FNOG-K4S3-C",
      "SARE-5ZWI-XXCT-7VLA-FTQJ-BWI2-K2JL-M"]}}
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
>key recover SAQN-W4Z2-QJHC-B7A3-NSUR-JETS-K64N-6 SARE-5ZWI-XXCT-7VLA-FTQJ-BWI2-K2JL-M
ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQN-W4Z2-QJHC-B7A3-NSUR-JETS-K64N-6 SARE-5ZWI-XXCT-7VLA-FTQJ-BWI2-K2JL-M /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA"}}
````


