
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
<rsp>NDVO-BPJC-JIAY-CUKX-4T5E-PLX2-UUPQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NDVO-BPJC-JIAY-CUKX-4T5E-PLX2-UUPQ"}}
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
<rsp>EDYA-LHGG-J663-TNTV-3HAU-SUQG-PPGQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDYA-LHGG-J663-TNTV-3HAU-SUQG-PPGQ"}}
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
<rsp>EBYV-GJQU-7XYF-VG3C-OMW2-QXF6-Z37F-HN
MCO5-D3TD-KQMA-5S4V-45ZI-Q4EW-6YUU-TIF7-4RNK-YT7G-Y7DY-AUV2-6SDQ-BUAO
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBYV-GJQU-7XYF-VG3C-OMW2-QXF6-Z37F-HN",
    "Identifier": "MCO5-D3TD-KQMA-5S4V-45ZI-Q4EW-6YUU-TIF7-4RNK-YT7G-Y7DY-AUV2-6SDQ-BUAO"}}
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
<rsp>ECBR-HIGH-QJX6-WX7O-KYAP-UBQI-NZEA
MCZU-U662-PSPP-QQ3R-IZTI-TJR7-VORM-VPLI-FZ3I-VSYJ-QVJN-DNZE-GROQ
SAQG-NSYI-ZJ23-AKOL-J64S-TBR4-VRWU-Q
SAQU-VATQ-ZVUP-A2BW-WEOF-EETT-KBWE-Q
SARC-4OOY-2BOD-BJVC-CJ7X-VHVJ-6RVU-Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECBR-HIGH-QJX6-WX7O-KYAP-UBQI-NZEA",
    "Identifier": "MCZU-U662-PSPP-QQ3R-IZTI-TJR7-VORM-VPLI-FZ3I-VSYJ-QVJN-DNZE-GROQ",
    "Shares": ["SAQG-NSYI-ZJ23-AKOL-J64S-TBR4-VRWU-Q",
      "SAQU-VATQ-ZVUP-A2BW-WEOF-EETT-KBWE-Q",
      "SARC-4OOY-2BOD-BJVC-CJ7X-VHVJ-6RVU-Q"]}}
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
<cmd>Alice> key recover SAQG-NSYI-ZJ23-AKOL-J64S-TBR4-VRWU-Q SARC-4OOY-2BOD-BJVC-CJ7X-VHVJ-6RVU-Q
<rsp>ERROR - Not enough shares to recover key
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQG-NSYI-ZJ23-AKOL-J64S-TBR4-VRWU-Q SARC-4OOY-2BOD-BJVC-CJ7X-VHVJ-6RVU-Q /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Not enough shares to recover key"}}
</div>
~~~~



