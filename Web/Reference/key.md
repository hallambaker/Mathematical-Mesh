
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
NDLI-GE2N-FRCL-ONLN-ZTYC-YW2V-TKHA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NDLI-GE2N-FRCL-ONLN-ZTYC-YW2V-TKHA"}}
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
EDK5-BX5C-3X3N-YIFR-VTV7-ENRY-Y4CQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDK5-BX5C-3X3N-YIFR-VTV7-ENRY-Y4CQ"}}
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
ECUM-RPER-UDTL-PD7K-IHN7-XOK6-ICJ4-PB
MBNY-WHDJ-QLI6-TBQN-6DP5-BEYS-CRUC-QAOA-EFTK-FT63-GB2H-G4WQ-U7KM-YLZD
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECUM-RPER-UDTL-PD7K-IHN7-XOK6-ICJ4-PB",
    "Identifier": "MBNY-WHDJ-QLI6-TBQN-6DP5-BEYS-CRUC-QAOA-EFTK-FT63-GB2H-G4WQ-U7KM-YLZD"}}
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
EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q
MDSC-MVC2-RS3Y-KXWA-4G5Z-4N7W-YBCO-YW2S-4XOU-3ZKX-EYG2-S5ZP-O7FA
SAQJ-MFYZ-TZF7-LUSR-PT5P-D472-LFBX-C
SAQW-6P5A-4EKC-HGOT-HLUL-DPNF-O5QC-2
SARE-Q2BI-EPOF-CYKU-7DLH-DB2Q-SV6O-S
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q",
    "Identifier": "MDSC-MVC2-RS3Y-KXWA-4G5Z-4N7W-YBCO-YW2S-4XOU-3ZKX-EYG2-S5ZP-O7FA",
    "Shares": ["SAQJ-MFYZ-TZF7-LUSR-PT5P-D472-LFBX-C",
      "SAQW-6P5A-4EKC-HGOT-HLUL-DPNF-O5QC-2",
      "SARE-Q2BI-EPOF-CYKU-7DLH-DB2Q-SV6O-S"]}}
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
>key recover SAQJ-MFYZ-TZF7-LUSR-PT5P-D472-LFBX-C SARE-Q2BI-EPOF-CYKU-7DLH-DB2Q-SV6O-S
EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQJ-MFYZ-TZF7-LUSR-PT5P-D472-LFBX-C SARE-Q2BI-EPOF-CYKU-7DLH-DB2Q-SV6O-S /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q"}}
````


