
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
ND2P-DLUX-XDDF-PJT7-EXCF-53MH-XVQA
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ND2P-DLUX-XDDF-PJT7-EXCF-53MH-XVQA"}}
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
EB3H-ZVVR-OK27-PKF5-R7CD-CIHT-YGBQ
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EB3H-ZVVR-OK27-PKF5-R7CD-CIHT-YGBQ"}}
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
ECJR-7UEO-WOPB-2RVE-GN2T-CNOU-PHTL-OR
MB5O-NJ2N-ISQD-KUAZ-KH5B-6LZR-QIWL-SQXD-BBOD-PUNQ-P7EQ-WIHP-5G2E-ATKF
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECJR-7UEO-WOPB-2RVE-GN2T-CNOU-PHTL-OR",
    "Identifier": "MB5O-NJ2N-ISQD-KUAZ-KH5B-6LZR-QIWL-SQXD-BBOD-PUNQ-P7EQ-WIHP-5G2E-ATKF"}}
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
EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA
MB3Z-TBR3-C5ZH-FUGN-DZJ5-IPQF-7UJH-WJD7-R4A6-DBY5-MM6Q-FONE-Q7WQ
SAQI-USPH-MIWN-NXQV-M3QE-XCOO-DGCI-M
SAQQ-UYYG-2HUM-3TEQ-VW3T-4DR6-TTBH-C
SARI-U7BG-IGSM-JOYL-6SHD-BEVP-EAAI-6
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA",
    "Identifier": "MB3Z-TBR3-C5ZH-FUGN-DZJ5-IPQF-7UJH-WJD7-R4A6-DBY5-MM6Q-FONE-Q7WQ",
    "Shares": ["SAQI-USPH-MIWN-NXQV-M3QE-XCOO-DGCI-M",
      "SAQQ-UYYG-2HUM-3TEQ-VW3T-4DR6-TTBH-C",
      "SARI-U7BG-IGSM-JOYL-6SHD-BEVP-EAAI-6"]}}
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
Alice> key recover SAQI-USPH-MIWN-NXQV-M3QE-XCOO-DGCI-M SARI-U7BG-IGSM-JOYL-6SHD-BEVP-EAAI-6
EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key recover SAQI-USPH-MIWN-NXQV-M3QE-XCOO-DGCI-M SARI-U7BG-IGSM-JOYL-6SHD-BEVP-EAAI-6 /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA"}}
````


