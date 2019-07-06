
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
NC3T-2Q7Y-3Z3L-GS2E-UDPJ-NKQQ-UUJQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NC3T-2Q7Y-3Z3L-GS2E-UDPJ-NKQQ-UUJQ"}}
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
EBJH-D4MW-HZWJ-7IG2-TXNT-JTPV-HKKA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBJH-D4MW-HZWJ-7IG2-TXNT-JTPV-HKKA"}}
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
ECUS-AJBQ-LD6O-6NQQ-Z3AY-FMJG-W2JO-UB
MDQY-GOFN-FPJR-SH7M-TPNW-DESW-E2EN-DW7C-37EI-UGMQ-WXTK-57NN-PLX6-J63V
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECUS-AJBQ-LD6O-6NQQ-Z3AY-FMJG-W2JO-UB",
    "Identifier": "MDQY-GOFN-FPJR-SH7M-TPNW-DESW-E2EN-DW7C-37EI-UGMQ-WXTK-57NN-PLX6-J63V"}}
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
EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA
MAOR-7JWV-MLVH-46ZZ-FUJ6-NJPF-RXPZ-G7Q2-YRNW-NXSC-E7IY-25F2-H2EQ
SAQJ-LZKP-CQ2F-66B5-5NVB-MKKJ-Q4R3-M
SAQ6-S3NR-K5SS-EAZ4-SSMP-P7KI-CLVS-U
SARD-Z5QT-TKK6-JDR3-HXD5-TUKG-T2ZG-W
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA",
    "Identifier": "MAOR-7JWV-MLVH-46ZZ-FUJ6-NJPF-RXPZ-G7Q2-YRNW-NXSC-E7IY-25F2-H2EQ",
    "Shares": ["SAQJ-LZKP-CQ2F-66B5-5NVB-MKKJ-Q4R3-M",
      "SAQ6-S3NR-K5SS-EAZ4-SSMP-P7KI-CLVS-U",
      "SARD-Z5QT-TKK6-JDR3-HXD5-TUKG-T2ZG-W"]}}
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
>key recover SAQJ-LZKP-CQ2F-66B5-5NVB-MKKJ-Q4R3-M SARD-Z5QT-TKK6-JDR3-HXD5-TUKG-T2ZG-W
EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQJ-LZKP-CQ2F-66B5-5NVB-MKKJ-Q4R3-M SARD-Z5QT-TKK6-JDR3-HXD5-TUKG-T2ZG-W /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA"}}
````


