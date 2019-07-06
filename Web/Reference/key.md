
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
NDYC-SF76-OZQP-PWZK-BXXB-GJYL-WYEA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NDYC-SF76-OZQP-PWZK-BXXB-GJYL-WYEA"}}
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
EDHZ-V3LE-VB2G-O65X-ION6-LNKW-GYDA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDHZ-V3LE-VB2G-O65X-ION6-LNKW-GYDA"}}
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
EANE-4R6G-6FCC-YPX7-ML5L-N6IM-UNT5-37
MD57-QV2G-ODKI-5CZO-SJDH-STXX-RUU7-AYHR-I2WO-YKNM-LIXA-7CDE-NCCC-W4WL
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EANE-4R6G-6FCC-YPX7-ML5L-N6IM-UNT5-37",
    "Identifier": "MD57-QV2G-ODKI-5CZO-SJDH-STXX-RUU7-AYHR-I2WO-YKNM-LIXA-7CDE-NCCC-W4WL"}}
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
EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q
MBMQ-3DNW-RVIM-IKFM-2YFL-4LBQ-SWWU-YWME-4PC7-EKJF-P4AE-7CAG-F5SQ
SAQG-H6VC-3SET-WVAT-FQDH-O3NO-RXNI-M
SAQV-ZL54-N5DQ-JD37-LILB-E7WC-G7CI-2
SARF-KZGW-AICM-3SXL-RAS2-3D6V-4GXJ-I
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q",
    "Identifier": "MBMQ-3DNW-RVIM-IKFM-2YFL-4LBQ-SWWU-YWME-4PC7-EKJF-P4AE-7CAG-F5SQ",
    "Shares": ["SAQG-H6VC-3SET-WVAT-FQDH-O3NO-RXNI-M",
      "SAQV-ZL54-N5DQ-JD37-LILB-E7WC-G7CI-2",
      "SARF-KZGW-AICM-3SXL-RAS2-3D6V-4GXJ-I"]}}
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
>key recover SAQG-H6VC-3SET-WVAT-FQDH-O3NO-RXNI-M SARF-KZGW-AICM-3SXL-RAS2-3D6V-4GXJ-I
EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQG-H6VC-3SET-WVAT-FQDH-O3NO-RXNI-M SARF-KZGW-AICM-3SXL-RAS2-3D6V-4GXJ-I /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q"}}
````


