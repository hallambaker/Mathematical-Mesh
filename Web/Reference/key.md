
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
NBPL-L6HU-QYQL-HSCX-TRA5-7TBB-FKFA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBPL-L6HU-QYQL-HSCX-TRA5-7TBB-FKFA"}}
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
EAUM-CBZB-EGDC-TOPG-VKOA-B5IJ-TSMQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAUM-CBZB-EGDC-TOPG-VKOA-B5IJ-TSMQ"}}
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
ECGD-AX3D-K5NI-KNFS-P2H5-2ANC-QTGS-KI
MBBF-ZOTN-3MFJ-PQEM-GCGI-TZIC-D3TX-PYNO-ZFUM-6SW7-WXUF-ID4I-LDLR-JR43
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECGD-AX3D-K5NI-KNFS-P2H5-2ANC-QTGS-KI",
    "Identifier": "MBBF-ZOTN-3MFJ-PQEM-GCGI-TZIC-D3TX-PYNO-ZFUM-6SW7-WXUF-ID4I-LDLR-JR43"}}
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
ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ
MAZS-NIMY-XVCM-YEI7-AQO4-YIJ4-3XZB-5XMD-IX6O-LBIL-TG2A-RIFE-SM2A
SAQA-QUAF-22YQ-VIG7-DOPF-BAG3-GWPU-K
SAQW-7LNQ-4IHX-E6VQ-T3VK-CHY4-4WU2-Q
SARN-OC23-5VW5-UVEC-EI3P-DPK6-SW2A-W
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ",
    "Identifier": "MAZS-NIMY-XVCM-YEI7-AQO4-YIJ4-3XZB-5XMD-IX6O-LBIL-TG2A-RIFE-SM2A",
    "Shares": ["SAQA-QUAF-22YQ-VIG7-DOPF-BAG3-GWPU-K",
      "SAQW-7LNQ-4IHX-E6VQ-T3VK-CHY4-4WU2-Q",
      "SARN-OC23-5VW5-UVEC-EI3P-DPK6-SW2A-W"]}}
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
>key recover SAQA-QUAF-22YQ-VIG7-DOPF-BAG3-GWPU-K SARN-OC23-5VW5-UVEC-EI3P-DPK6-SW2A-W
ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQA-QUAF-22YQ-VIG7-DOPF-BAG3-GWPU-K SARN-OC23-5VW5-UVEC-EI3P-DPK6-SW2A-W /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ"}}
````


