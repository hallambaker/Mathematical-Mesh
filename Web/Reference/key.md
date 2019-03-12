
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
ND7B-PRGA-MN6H-XYNF-USYJ-JJ6C-OFBA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ND7B-PRGA-MN6H-XYNF-USYJ-JJ6C-OFBA"}}
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
EDY2-2SH6-YIBM-V3MC-APLM-JCEE-ZXTA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDY2-2SH6-YIBM-V3MC-APLM-JCEE-ZXTA"}}
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
ECUM-5AI2-4W4R-EBEH-M5KZ-7IKK-K5P2-P2
MDGK-SWMJ-YU5J-GDUH-VHBJ-5SER-3QJ7-HIPN-C6R5-QKTQ-QLAD-PWU5-UKDC-OUAS
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECUM-5AI2-4W4R-EBEH-M5KZ-7IKK-K5P2-P2",
    "Identifier": "MDGK-SWMJ-YU5J-GDUH-VHBJ-5SER-3QJ7-HIPN-C6R5-QKTQ-QLAD-PWU5-UKDC-OUAS"}}
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
EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA
MBDX-WI4D-WU5K-6GKZ-JW6C-X5WU-RYJT-TOTR-WUXJ-HZNX-C6MX-H25P-JR4Q
SAQJ-263E-6R5S-JT2J-IG4T-DRFJ-5MEW-U
SAQT-EGNS-JSJA-Q3DS-7KWP-DEQ5-EMB3-2
SARM-NN77-USUO-YCM4-WOQL-CX4Q-LL7E-G
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA",
    "Identifier": "MBDX-WI4D-WU5K-6GKZ-JW6C-X5WU-RYJT-TOTR-WUXJ-HZNX-C6MX-H25P-JR4Q",
    "Shares": ["SAQJ-263E-6R5S-JT2J-IG4T-DRFJ-5MEW-U",
      "SAQT-EGNS-JSJA-Q3DS-7KWP-DEQ5-EMB3-2",
      "SARM-NN77-USUO-YCM4-WOQL-CX4Q-LL7E-G"]}}
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
>key recover SAQJ-263E-6R5S-JT2J-IG4T-DRFJ-5MEW-U SARM-NN77-USUO-YCM4-WOQL-CX4Q-LL7E-G
EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQJ-263E-6R5S-JT2J-IG4T-DRFJ-5MEW-U SARM-NN77-USUO-YCM4-WOQL-CX4Q-LL7E-G /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA"}}
````


