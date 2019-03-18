
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
NC4I-HGUZ-WLDW-5WHL-Z4GZ-APB4-NQXA
````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NC4I-HGUZ-WLDW-5WHL-Z4GZ-APB4-NQXA"}}
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
EDVT-MLRP-6SPD-UTLL-UI5D-LWKU-VVLA
````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDVT-MLRP-6SPD-UTLL-UI5D-LWKU-VVLA"}}
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
EDXJ-EW5B-AGTF-D7RV-6SGZ-3767-NV3T-NE
MB2Y-JPLQ-SFKE-ARX7-TY2B-KOHO-RDI7-L7XH-P2IZ-W5VS-QSZK-NLXX-3NEL-C5KQ
````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDXJ-EW5B-AGTF-D7RV-6SGZ-3767-NV3T-NE",
    "Identifier": "MB2Y-JPLQ-SFKE-ARX7-TY2B-KOHO-RDI7-L7XH-P2IZ-W5VS-QSZK-NLXX-3NEL-C5KQ"}}
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
ECCQ-OJV7-JSNI-G7JH-J3EF-R33F-LWWA
MADR-S2BO-7NPA-HWS3-WVHF-BPFN-P46L-VQMF-SDAJ-QGSW-UE5U-M5L6-WSGA
SAQH-BNO4-RVIK-ESB4-5TAH-JR6A-PC4Y-M
SAQV-YZES-LNKK-UDH4-WIZC-CNUR-RQKW-A
SARE-QE2I-FFML-DUN4-O6R4-3JLC-T5YT-U
````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECCQ-OJV7-JSNI-G7JH-J3EF-R33F-LWWA",
    "Identifier": "MADR-S2BO-7NPA-HWS3-WVHF-BPFN-P46L-VQMF-SDAJ-QGSW-UE5U-M5L6-WSGA",
    "Shares": ["SAQH-BNO4-RVIK-ESB4-5TAH-JR6A-PC4Y-M",
      "SAQV-YZES-LNKK-UDH4-WIZC-CNUR-RQKW-A",
      "SARE-QE2I-FFML-DUN4-O6R4-3JLC-T5YT-U"]}}
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
>key recover SAQH-BNO4-RVIK-ESB4-5TAH-JR6A-PC4Y-M SARE-QE2I-FFML-DUN4-O6R4-3JLC-T5YT-U
ECCQ-OJV7-JSNI-G7JH-J3EF-R33F-LWWA
````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQH-BNO4-RVIK-ESB4-5TAH-JR6A-PC4Y-M SARE-QE2I-FFML-DUN4-O6R4-3JLC-T5YT-U /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECCQ-OJV7-JSNI-G7JH-J3EF-R33F-LWWA"}}
````


