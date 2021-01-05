
# key

~~~~
<div="helptext">
<over>
key    Key operations.
    earl   Return a randomized secret value and locator as UDFs
    nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    recover   Recover a secret value from the shares provided
    secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    share   Split a secret value according to the specified shares and quorum
<over>
</div>
~~~~

The Key command set contains commands that operate on cryptographic keys and
nonces.


# key nonce

~~~~
<div="helptext">
<over>
nonce   Return a randomized nonce value formatted as a UDF Nonce Type
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
<over>
</div>
~~~~


The `key nonce` command returns a randomized nonce value formatted as a UDF nonce type.

Nonce values should be used when it is important that a value be unpredictable but 
does not need to be kept secret. For example, the challenge in a challenge/response
protocol.


~~~~
<div="terminal">
<cmd>Alice> key nonce
<rsp>NBNG-K554-5YYI-NLJ3-6I7U-JEKD-SHZQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NBNG-K554-5YYI-NLJ3-6I7U-JEKD-SHZQ"}}
</div>
~~~~


# key secret

~~~~
<div="helptext">
<over>
secret   Return a randomized secret value formatted as a UDF Encryption Key Type.
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /bits   Secret size in bits
<over>
</div>
~~~~

The `key secret` command returns a randomized secret value formatted as a UDF Encryption 
key type.


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ECUV-DNB4-RGYZ-MNLS-2WAS-OAS4-4F7Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECUV-DNB4-RGYZ-MNLS-2WAS-OAS4-4F7Q"}}
</div>
~~~~



# key earl

~~~~
<div="helptext">
<over>
earl   Return a randomized secret value and locator as UDFs
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
<over>
</div>
~~~~

The `key earl` command returns a randomized secret value and a fingerprint of the secret 
value, formatted as a UDF Encryption key type and Content Digest Type


~~~~
<div="terminal">
<cmd>Alice> key earl
<rsp>ECW2-UPXH-QX27-762O-BCF5-JHCF-AEX4-2B
MAXS-MYXJ-4OSB-WNT7-UTUK-PSVE-3GBB-5J5N-MK4Z-CZKC-F7Z4-XKOH-NUBM-6WZL
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECW2-UPXH-QX27-762O-BCF5-JHCF-AEX4-2B",
    "Identifier": "MAXS-MYXJ-4OSB-WNT7-UTUK-PSVE-3GBB-5J5N-MK4Z-CZKC-F7Z4-XKOH-NUBM-6WZL"}}
</div>
~~~~


# key share

~~~~
<div="helptext">
<over>
share   Split a secret value according to the specified shares and quorum
       The parameter to share
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /key   Encrypt data for specified recipient
    /bits   Secret size in bits
    /quorum   The number of shares required to recover the secret
    /shares   The number of shares to create
<over>
</div>
~~~~

The `key share` command returns a randomized secret value and a set of shares for the secret
formatted as a UDF Encryption key type and Share types


~~~~
<div="terminal">
<cmd>Alice> key share
<rsp>X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4
MABY-3I7S-MLWT-W62Y-R3OC-QXFT-Q5AC-P3N4-DYPN-UMKH-PLIQ-LFTK-TL6W
SAQN-WBKW-VQOS-2LTZ-NGIG-TOQG-M4QD-O
SAQ7-NN37-NJYO-E4VY-TAPX-RX2V-ZBZC-O
SARB-E2NI-FDCJ-PNXX-Y2XI-QBFF-FHB6-I
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4",
    "Identifier": "MABY-3I7S-MLWT-W62Y-R3OC-QXFT-Q5AC-P3N4-DYPN-UMKH-PLIQ-LFTK-TL6W",
    "Shares": ["SAQN-WBKW-VQOS-2LTZ-NGIG-TOQG-M4QD-O",
      "SAQ7-NN37-NJYO-E4VY-TAPX-RX2V-ZBZC-O",
      "SARB-E2NI-FDCJ-PNXX-Y2XI-QBFF-FHB6-I"]}}
</div>
~~~~



# key recover

~~~~
<div="helptext">
<over>
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
<over>
</div>
~~~~

The `key recover` command combines the specified set of share to recover the original secret 
value as a UDF Encryption key type.


~~~~
<div="terminal">
<cmd>Alice> key recover SAQN-WBKW-VQOS-2LTZ-NGIG-TOQG-M4QD-O SARB-E2NI-FDCJ-PNXX-Y2XI-QBFF-FHB6-I
<rsp>X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQN-WBKW-VQOS-2LTZ-NGIG-TOQG-M4QD-O SARB-E2NI-FDCJ-PNXX-Y2XI-QBFF-FHB6-I /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4"}}
</div>
~~~~



