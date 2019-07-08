
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
NCLN-ATD2-ALYB-5HAG-L3CY-ZLRN-Z6EQ
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NCLN-ATD2-ALYB-5HAG-L3CY-ZLRN-Z6EQ"}}
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
EAX7-PX5K-EP7P-5WKB-CU6Q-OU5Q-YP6A
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAX7-PX5K-EP7P-5WKB-CU6Q-OU5Q-YP6A"}}
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
EBO5-LLT3-V4RL-JAB7-WTU7-ZCZF-7LFP-IO
MAIL-2MEL-UN3C-3T7K-D3U6-LTSE-QTIF-5OQ4-NNRY-ILHH-R77I-5ZXO-T3J7-SSP5
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBO5-LLT3-V4RL-JAB7-WTU7-ZCZF-7LFP-IO",
    "Identifier": "MAIL-2MEL-UN3C-3T7K-D3U6-LTSE-QTIF-5OQ4-NNRY-ILHH-R77I-5ZXO-T3J7-SSP5"}}
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
ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ
MCSQ-WURP-QXUO-3KWT-3ZBU-WUGA-ULQ5-KNX6-6EVQ-KQVY-ZCE4-35FO-4LUA
SAQM-PWF6-Y4JW-Y4X2-DVKB-FLPY-Z5QQ-G
SAQQ-24YZ-WCE5-UGFO-4LXI-UQDG-KST4-4
SARF-GDLU-TIAE-PPTD-VCEQ-DUWT-3HXM-Y
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ",
    "Identifier": "MCSQ-WURP-QXUO-3KWT-3ZBU-WUGA-ULQ5-KNX6-6EVQ-KQVY-ZCE4-35FO-4LUA",
    "Shares": ["SAQM-PWF6-Y4JW-Y4X2-DVKB-FLPY-Z5QQ-G",
      "SAQQ-24YZ-WCE5-UGFO-4LXI-UQDG-KST4-4",
      "SARF-GDLU-TIAE-PPTD-VCEQ-DUWT-3HXM-Y"]}}
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
Alice> key recover SAQM-PWF6-Y4JW-Y4X2-DVKB-FLPY-Z5QQ-G SARF-GDLU-TIAE-PPTD-VCEQ-DUWT-3HXM-Y
ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key recover SAQM-PWF6-Y4JW-Y4X2-DVKB-FLPY-Z5QQ-G SARF-GDLU-TIAE-PPTD-VCEQ-DUWT-3HXM-Y /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ"}}
````


