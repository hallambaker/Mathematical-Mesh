
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
NCDX-KQQP-IBID-6OXT-JP2M-NUVI-RS7Q
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NCDX-KQQP-IBID-6OXT-JP2M-NUVI-RS7Q"}}
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
EDFZ-FPB7-AKZZ-TMWV-LIUT-PCQV-T7JQ
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDFZ-FPB7-AKZZ-TMWV-LIUT-PCQV-T7JQ"}}
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
EDDN-LZZQ-GXUU-GXCW-3EYU-2A47-H2TC-DJ
MDE7-EO26-OP66-VA6J-OQ2Q-3MNA-KQ6W-YEL4-AVQT-E7FP-TWQC-VL6P-FQPF-5HLC
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDDN-LZZQ-GXUU-GXCW-3EYU-2A47-H2TC-DJ",
    "Identifier": "MDE7-EO26-OP66-VA6J-OQ2Q-3MNA-KQ6W-YEL4-AVQT-E7FP-TWQC-VL6P-FQPF-5HLC"}}
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
EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA
MBK5-ITOH-Q7Z7-7JYT-O5QN-WOG2-JXJG-EWYP-OMBR-FYZP-7ZDP-SBTE-E6QA
SAQA-JM22-QDJJ-AXQA-57QW-LQRB-JF2C-K
SAQR-76BS-ZNRD-JNOH-YBMD-JP77-WKWV-2
SARD-WPIL-CXY5-SDMO-SDHQ-HPO6-DPTJ-K
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA",
    "Identifier": "MBK5-ITOH-Q7Z7-7JYT-O5QN-WOG2-JXJG-EWYP-OMBR-FYZP-7ZDP-SBTE-E6QA",
    "Shares": ["SAQA-JM22-QDJJ-AXQA-57QW-LQRB-JF2C-K",
      "SAQR-76BS-ZNRD-JNOH-YBMD-JP77-WKWV-2",
      "SARD-WPIL-CXY5-SDMO-SDHQ-HPO6-DPTJ-K"]}}
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
Alice> key recover SAQA-JM22-QDJJ-AXQA-57QW-LQRB-JF2C-K SARD-WPIL-CXY5-SDMO-SDHQ-HPO6-DPTJ-K
EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA
````

Specifying the /json option returns a result of type ResultKey:

````
Alice> key recover SAQA-JM22-QDJJ-AXQA-57QW-LQRB-JF2C-K SARD-WPIL-CXY5-SDMO-SDHQ-HPO6-DPTJ-K /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA"}}
````


