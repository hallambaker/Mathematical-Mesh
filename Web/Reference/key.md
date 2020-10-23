
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
<rsp>NDY4-C7YY-2R2M-ZJ3H-NLQR-5W3Q-HRMQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NDY4-C7YY-2R2M-ZJ3H-NLQR-5W3Q-HRMQ"}}
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
<rsp>ED73-NPH3-ASAS-J2N6-J75U-AABD-3LLA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ED73-NPH3-ASAS-J2N6-J75U-AABD-3LLA"}}
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
<rsp>EDVJ-TVRX-BN2P-KH4Q-O6HW-4AVY-JUWN-ZE
MALQ-Q6LA-6AUO-WW7X-OHMV-DA5H-T4WJ-B44F-EVNE-P6QP-N6HV-2VZT-VGPW-TE3K
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDVJ-TVRX-BN2P-KH4Q-O6HW-4AVY-JUWN-ZE",
    "Identifier": "MALQ-Q6LA-6AUO-WW7X-OHMV-DA5H-T4WJ-B44F-EVNE-P6QP-N6HV-2VZT-VGPW-TE3K"}}
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
<rsp>3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
MAOH-UF4B-F5XC-526K-STLZ-4Q7M-XBE2-BSML-FO7M-4OPI-7RN2-RN22-2IW7
SAQH-GZHH-YNV3-RKXV-O6XG-2I47-3MAK-S
SAQQ-RIZ4-J3EK-GYLA-PKJD-GDSN-Z5ZQ-6
SARJ-3YMQ-3ISY-4F6L-PV27-R6H3-YPS2-Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM",
    "Identifier": "MAOH-UF4B-F5XC-526K-STLZ-4Q7M-XBE2-BSML-FO7M-4OPI-7RN2-RN22-2IW7",
    "Shares": ["SAQH-GZHH-YNV3-RKXV-O6XG-2I47-3MAK-S",
      "SAQQ-RIZ4-J3EK-GYLA-PKJD-GDSN-Z5ZQ-6",
      "SARJ-3YMQ-3ISY-4F6L-PV27-R6H3-YPS2-Q"]}}
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
<cmd>Alice> key recover SAQH-GZHH-YNV3-RKXV-O6XG-2I47-3MAK-S SARJ-3YMQ-3ISY-4F6L-PV27-R6H3-YPS2-Q
<rsp>3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQH-GZHH-YNV3-RKXV-O6XG-2I47-3MAK-S SARJ-3YMQ-3ISY-4F6L-PV27-R6H3-YPS2-Q /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM"}}
</div>
~~~~



