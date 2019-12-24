
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
<rsp>NCTC-KKU3-QZST-UGXF-YWUV-ELBV-ISFQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NCTC-KKU3-QZST-UGXF-YWUV-ELBV-ISFQ"}}
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
<rsp>EASP-CVRM-NB32-QSOH-XCOI-HKGS-TBAQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EASP-CVRM-NB32-QSOH-XCOI-HKGS-TBAQ"}}
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
<rsp>EASB-ULSK-CAQO-AMWN-QHY6-I6TA-5MJ4-WB
MBUQ-PSGE-3DLW-EQ7A-KGIF-WXKJ-2NF6-JCVS-V4MX-VOJL-5JSR-YI3R-BARG-H67I
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EASB-ULSK-CAQO-AMWN-QHY6-I6TA-5MJ4-WB",
    "Identifier": "MBUQ-PSGE-3DLW-EQ7A-KGIF-WXKJ-2NF6-JCVS-V4MX-VOJL-5JSR-YI3R-BARG-H67I"}}
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
<rsp>EADB-RGN6-M725-LCQP-WID5-BN77-BYOA
MDG2-CU4H-GS73-FZ43-B3QY-UCEN-K4DQ-OVTN-NW3X-F4TO-SCE3-MQ2V-TCTQ
SAQB-FPUH-YAKT-ZYA6-WIKF-E6XF-CSS6-A
SAQR-6ZDV-YHBI-H2VT-KR3J-2JIS-FI62-I
SARC-YCTD-YNX4-V5KH-63MO-PTZ7-H7KW-Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EADB-RGN6-M725-LCQP-WID5-BN77-BYOA",
    "Identifier": "MDG2-CU4H-GS73-FZ43-B3QY-UCEN-K4DQ-OVTN-NW3X-F4TO-SCE3-MQ2V-TCTQ",
    "Shares": ["SAQB-FPUH-YAKT-ZYA6-WIKF-E6XF-CSS6-A",
      "SAQR-6ZDV-YHBI-H2VT-KR3J-2JIS-FI62-I",
      "SARC-YCTD-YNX4-V5KH-63MO-PTZ7-H7KW-Q"]}}
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
<cmd>Alice> key recover SAQB-FPUH-YAKT-ZYA6-WIKF-E6XF-CSS6-A SARC-YCTD-YNX4-V5KH-63MO-PTZ7-H7KW-Q
<rsp>EADB-RGN6-M725-LCQP-WID5-BN77-BYOA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQB-FPUH-YAKT-ZYA6-WIKF-E6XF-CSS6-A SARC-YCTD-YNX4-V5KH-63MO-PTZ7-H7KW-Q /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EADB-RGN6-M725-LCQP-WID5-BN77-BYOA"}}
</div>
~~~~



