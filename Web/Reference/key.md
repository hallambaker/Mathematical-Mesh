
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
NBEP-HN3Y-ILQF-MERM-FPAN-TKGO-7QPA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBEP-HN3Y-ILQF-MERM-FPAN-TKGO-7QPA"}}
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
EAVX-SDDW-B7RN-ON5F-SFWH-ZZIH-2BIQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAVX-SDDW-B7RN-ON5F-SFWH-ZZIH-2BIQ"}}
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
EBEV-CV4J-W4M7-2LM6-Q2WX-TJWR-CYU6-VQ
MB6V-WEPD-DK24-IFW5-DTVU-YLPJ-OQMZ-S4IZ-AAPV-R2HX-DZLG-V36X-EGCZ-LI2C
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBEV-CV4J-W4M7-2LM6-Q2WX-TJWR-CYU6-VQ",
    "Identifier": "MB6V-WEPD-DK24-IFW5-DTVU-YLPJ-OQMZ-S4IZ-AAPV-R2HX-DZLG-V36X-EGCZ-LI2C"}}
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
ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA
MBDT-JP6X-RKBG-MQIP-YWJI-43SU-AWYX-TQ47-NR3Q-YUPC-LFIA-7YSC-V2GA
SAQK-RRFI-LPCJ-RYZN-JVK6-BL6H-SK2C-2
SAQ4-FS3R-QPDN-NUQ5-M4N2-3LDV-VSCV-M
SARN-ZUR2-VPER-JQIN-QDQX-VKJD-YZLH-6
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA",
    "Identifier": "MBDT-JP6X-RKBG-MQIP-YWJI-43SU-AWYX-TQ47-NR3Q-YUPC-LFIA-7YSC-V2GA",
    "Shares": ["SAQK-RRFI-LPCJ-RYZN-JVK6-BL6H-SK2C-2",
      "SAQ4-FS3R-QPDN-NUQ5-M4N2-3LDV-VSCV-M",
      "SARN-ZUR2-VPER-JQIN-QDQX-VKJD-YZLH-6"]}}
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
>key recover SAQK-RRFI-LPCJ-RYZN-JVK6-BL6H-SK2C-2 SARN-ZUR2-VPER-JQIN-QDQX-VKJD-YZLH-6
ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQK-RRFI-LPCJ-RYZN-JVK6-BL6H-SK2C-2 SARN-ZUR2-VPER-JQIN-QDQX-VKJD-YZLH-6 /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA"}}
````


