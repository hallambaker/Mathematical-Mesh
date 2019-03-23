
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
NCPE-S63N-WBCY-KPZ4-2XH4-O3FZ-B6VQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NCPE-S63N-WBCY-KPZ4-2XH4-O3FZ-B6VQ"}}
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
EB2G-YKSM-G36Z-HIQZ-VCYL-5QOZ-V4KA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EB2G-YKSM-G36Z-HIQZ-VCYL-5QOZ-V4KA"}}
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
EBDE-Q3IW-5YW4-K6LV-DUWJ-YZUY-KFZG-OV
MC2T-H75H-WRK4-XMAG-DSRO-X7QQ-SXKY-WXN2-KVM7-2RFJ-SV3S-Q5DH-Y5O7-7COT
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBDE-Q3IW-5YW4-K6LV-DUWJ-YZUY-KFZG-OV",
    "Identifier": "MC2T-H75H-WRK4-XMAG-DSRO-X7QQ-SXKY-WXN2-KVM7-2RFJ-SV3S-Q5DH-Y5O7-7COT"}}
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
ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q
MA73-R3AD-MDMW-32FB-MM2W-QGFT-S252-XNB3-7GTL-4ZCD-JMYA-WIFB-5SHA
SAQC-ODBR-CQFZ-D47W-7SPZ-IQUD-S43N-U
SAQ3-NXE4-TARW-OA6T-4DFQ-EJWX-RWAG-Y
SARE-NLII-DQ5T-YE5Q-YT3H-ACZL-QPE4-W
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q",
    "Identifier": "MA73-R3AD-MDMW-32FB-MM2W-QGFT-S252-XNB3-7GTL-4ZCD-JMYA-WIFB-5SHA",
    "Shares": ["SAQC-ODBR-CQFZ-D47W-7SPZ-IQUD-S43N-U",
      "SAQ3-NXE4-TARW-OA6T-4DFQ-EJWX-RWAG-Y",
      "SARE-NLII-DQ5T-YE5Q-YT3H-ACZL-QPE4-W"]}}
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
>key recover SAQC-ODBR-CQFZ-D47W-7SPZ-IQUD-S43N-U SARE-NLII-DQ5T-YE5Q-YT3H-ACZL-QPE4-W
ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQC-ODBR-CQFZ-D47W-7SPZ-IQUD-S43N-U SARE-NLII-DQ5T-YE5Q-YT3H-ACZL-QPE4-W /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q"}}
````


