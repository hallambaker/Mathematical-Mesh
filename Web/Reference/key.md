
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
NBH7-KOKI-2ROG-5HTJ-5OUG-F7LK-U2NA

````

Specifying the /json option returns a result of type ResultKey:

````
>key nonce /json
{
  "ResultKey": {
    "Success": true,
    "Key": "NBH7-KOKI-2ROG-5HTJ-5OUG-F7LK-U2NA"}}
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
EDD5-2ILE-MYZT-GXC3-EG72-JGBJ-O3MQ

````

Specifying the /json option returns a result of type ResultKey:

````
>key secret /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDD5-2ILE-MYZT-GXC3-EG72-JGBJ-O3MQ"}}
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
EDKC-JTJB-LPQH-6452-XJNX-3OLM-TQPW-3I
MDXW-KXQD-GI6R-QNVG-M2PT-KUEX-PR24-AJBG-IW3E-7LEL-YSQN-DS4W-3JOJ-GZA3

````

Specifying the /json option returns a result of type ResultKey:

````
>key earl /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EDKC-JTJB-LPQH-6452-XJNX-3OLM-TQPW-3I",
    "Identifier": "MDXW-KXQD-GI6R-QNVG-M2PT-KUEX-PR24-AJBG-IW3E-7LEL-YSQN-DS4W-3JOJ-GZA3"}}
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
EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ
MBAK-P45Y-5TTY-YQCW-SB52-6VIY-LLUJ-FV6A-OJV3-PNTJ-A4SJ-Q4N4-JTVQ
SAQJ-NALW-VKTC-HEGY-UJ2J-Q2TY-7N63-M
SAQ5-MTL3-4TSZ-5ROM-3GEI-WAYQ-4FUR-6
SARB-MGMB-D4SR-T6WB-CCOH-3G5I-Y5KF-K

````

Specifying the /json option returns a result of type ResultKey:

````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ",
    "Identifier": "MBAK-P45Y-5TTY-YQCW-SB52-6VIY-LLUJ-FV6A-OJV3-PNTJ-A4SJ-Q4N4-JTVQ",
    "Shares": ["SAQJ-NALW-VKTC-HEGY-UJ2J-Q2TY-7N63-M",
      "SAQ5-MTL3-4TSZ-5ROM-3GEI-WAYQ-4FUR-6",
      "SARB-MGMB-D4SR-T6WB-CCOH-3G5I-Y5KF-K"]}}
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
>key recover SAQJ-NALW-VKTC-HEGY-UJ2J-Q2TY-7N63-M SARB-MGMB-D4SR-T6WB-CCOH-3G5I-Y5KF-K
EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ

````

Specifying the /json option returns a result of type ResultKey:

````
>key recover SAQJ-NALW-VKTC-HEGY-UJ2J-Q2TY-7N63-M SARB-MGMB-D4SR-T6WB-CCOH-3G5I-Y5KF-K /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EBLL-K4LQ-M2UF-XZDL-MCS5-DYIV-SJGQ"}}
````


