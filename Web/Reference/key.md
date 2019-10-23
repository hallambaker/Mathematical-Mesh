
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
NBC5-QH5Z-I4NE-GUWY-AOWW-AXXF-ATCQ
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBC5-QH5Z-I4NE-GUWY-AOWW-AXXF-ATCQ"}}
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
EDCA-JKMV-ZACY-BP5H-FIKE-BM2C-24SA
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDCA-JKMV-ZACY-BP5H-FIKE-BM2C-24SA"}}
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
EAGC-FIKB-DV2S-HJMK-6AB7-BSIC-BURY-SR
MBQQ-7A3R-Q2KF-KOEK-CZN5-SXMF-C6YE-N66E-4ICB-U4VC-2GJG-3XNS-GKXK-R5RM
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAGC-FIKB-DV2S-HJMK-6AB7-BSIC-BURY-SR",
    "Identifier": "MBQQ-7A3R-Q2KF-KOEK-CZN5-SXMF-C6YE-N66E-4ICB-U4VC-2GJG-3XNS-GKXK-R5RM"}}
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
EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ
MDLW-W6ZD-F23V-RQM4-AGOE-TXQE-5GTE-U5DP-QC6G-DESN-3Z63-ZUUD-3S6Q
SAQF-3YGW-V2N2-6CAJ-ISFG-2L5L-WN5D-6
SAQQ-EYUJ-2XAW-3ADY-53RK-GCX2-3HYO-2
SARK-NZB4-7TTS-X6HI-TE5N-RZSK-ABT4-4
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ",
    "Identifier": "MDLW-W6ZD-F23V-RQM4-AGOE-TXQE-5GTE-U5DP-QC6G-DESN-3Z63-ZUUD-3S6Q",
    "Shares": ["SAQF-3YGW-V2N2-6CAJ-ISFG-2L5L-WN5D-6",
      "SAQQ-EYUJ-2XAW-3ADY-53RK-GCX2-3HYO-2",
      "SARK-NZB4-7TTS-X6HI-TE5N-RZSK-ABT4-4"]}}
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
Alice> key recover SAQF-3YGW-V2N2-6CAJ-ISFG-2L5L-WN5D-6 SARK-NZB4-7TTS-X6HI-TE5N-RZSK-ABT4-4
EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key recover SAQF-3YGW-V2N2-6CAJ-ISFG-2L5L-WN5D-6 SARK-NZB4-7TTS-X6HI-TE5N-RZSK-ABT4-4 /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ"}}
````


