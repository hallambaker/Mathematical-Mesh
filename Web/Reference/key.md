
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
<rsp>NBJR-CKSN-H4LD-4FAW-P423-P3W3-6LPQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NBJR-CKSN-H4LD-4FAW-P423-P3W3-6LPQ"}}
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
<rsp>ECXT-YW2D-A3MH-J6VJ-TKFX-HMYP-PVFQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECXT-YW2D-A3MH-J6VJ-TKFX-HMYP-PVFQ"}}
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
<rsp>EBWH-RCRW-FUOE-37TH-EDRM-2PBE-B463-FJ
MC4V-MY6J-T2K2-3LJI-4332-OPA7-CV3Y-QXBI-ICF5-FFUB-IJR5-S7NC-7OTZ-SQHV
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBWH-RCRW-FUOE-37TH-EDRM-2PBE-B463-FJ",
    "Identifier": "MC4V-MY6J-T2K2-3LJI-4332-OPA7-CV3Y-QXBI-ICF5-FFUB-IJR5-S7NC-7OTZ-SQHV"}}
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
<rsp>EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A
MCTS-2NQA-AD5B-WFZE-NWH3-I5OI-TN6G-3MAK-TUHM-RMDK-NXO2-EZNT-XSMA
SAQI-6LMK-TSHH-W7FZ-YRR6-TQY6-XSQQ-E
SAQ3-PQLE-3GA5-TQWV-X7DH-FQ6N-AG4I-M
SARO-AVJ7-CZ2T-QCHR-XMUP-XRD3-I3IA-U
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A",
    "Identifier": "MCTS-2NQA-AD5B-WFZE-NWH3-I5OI-TN6G-3MAK-TUHM-RMDK-NXO2-EZNT-XSMA",
    "Shares": ["SAQI-6LMK-TSHH-W7FZ-YRR6-TQY6-XSQQ-E",
      "SAQ3-PQLE-3GA5-TQWV-X7DH-FQ6N-AG4I-M",
      "SARO-AVJ7-CZ2T-QCHR-XMUP-XRD3-I3IA-U"]}}
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
<cmd>Alice> key recover SAQI-6LMK-TSHH-W7FZ-YRR6-TQY6-XSQQ-E SARO-AVJ7-CZ2T-QCHR-XMUP-XRD3-I3IA-U
<rsp>EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQI-6LMK-TSHH-W7FZ-YRR6-TQY6-XSQQ-E SARO-AVJ7-CZ2T-QCHR-XMUP-XRD3-I3IA-U /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A"}}
</div>
~~~~



