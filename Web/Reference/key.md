
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
NCJH-PVEY-VATR-4XMJ-QX4F-PDC5-OMYA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NCJH-PVEY-VATR-4XMJ-QX4F-PDC5-OMYA"}}
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
EDLC-OQAL-YXLU-RE3Q-WXEI-QD5W-FONA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDLC-OQAL-YXLU-RE3Q-WXEI-QD5W-FONA"}}
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
EAVA-MTJV-LBPT-WSNS-YANJ-5NGP-2N4D-AD
MDDQ-I3R3-EL6R-VRNM-PBVD-KOJZ-K5KF-NIFJ-2HGM-VCXP-OY5V-4B5F-MBHO-R66U
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAVA-MTJV-LBPT-WSNS-YANJ-5NGP-2N4D-AD",
    "Identifier": "MDDQ-I3R3-EL6R-VRNM-PBVD-KOJZ-K5KF-NIFJ-2HGM-VCXP-OY5V-4B5F-MBHO-R66U"}}
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
EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
MBBS-P6KK-N6TD-2SWK-X3MV-ELXY-D47A-G6WM-J442-CTLF-73WC-4UTP-EP6A
SAQF-JHAP-SSCL-3SJC-TUOS-X7JE-AORS-G
SAQX-D7JR-FZ3C-7GJR-3WRV-RT3E-MBJC-C
SARI-6XSS-ZBT2-C2KB-DYUY-LINE-XUAR-6
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ",
    "Identifier": "MBBS-P6KK-N6TD-2SWK-X3MV-ELXY-D47A-G6WM-J442-CTLF-73WC-4UTP-EP6A",
    "Shares": ["SAQF-JHAP-SSCL-3SJC-TUOS-X7JE-AORS-G",
      "SAQX-D7JR-FZ3C-7GJR-3WRV-RT3E-MBJC-C",
      "SARI-6XSS-ZBT2-C2KB-DYUY-LINE-XUAR-6"]}}
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
>key recover SAQF-JHAP-SSCL-3SJC-TUOS-X7JE-AORS-G SARI-6XSS-ZBT2-C2KB-DYUY-LINE-XUAR-6
EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQF-JHAP-SSCL-3SJC-TUOS-X7JE-AORS-G SARI-6XSS-ZBT2-C2KB-DYUY-LINE-XUAR-6 /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ"}}
````


