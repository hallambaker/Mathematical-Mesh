
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
<rsp>NDQQ-2XUX-D2CW-NPTO-QOFE-KRLU-3Q4Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NDQQ-2XUX-D2CW-NPTO-QOFE-KRLU-3Q4Q"}}
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
<rsp>EADB-RNYX-E24C-XLPK-EID3-BQMU-YQOQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EADB-RNYX-E24C-XLPK-EID3-BQMU-YQOQ"}}
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
<rsp>EB36-N7RQ-RPQY-VLPV-NOC5-CELK-E5RR-JA
MCSN-I5MW-YA6T-MM23-CELK-GD7B-65F6-6SEM-K2LZ-4OUE-5LN7-3LMB-6JKG-63RF
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EB36-N7RQ-RPQY-VLPV-NOC5-CELK-E5RR-JA",
    "Identifier": "MCSN-I5MW-YA6T-MM23-CELK-GD7B-65F6-6SEM-K2LZ-4OUE-5LN7-3LMB-6JKG-63RF"}}
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
<rsp>UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4
MBPF-MOKL-H5YX-G63R-OTXN-O3M4-KM45-WP3D-33XH-FXXX-ZQG6-LCLO-R5V3
SAQC-PXRK-KY7O-37FU-DURM-D2N2-S7LX-I
SAQ2-VHKM-H64C-HJXA-TTZD-7W2F-B5PZ-I
SARC-2XDO-FEYV-SUIN-DTA3-3TGP-Q3TY-C
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4",
    "Identifier": "MBPF-MOKL-H5YX-G63R-OTXN-O3M4-KM45-WP3D-33XH-FXXX-ZQG6-LCLO-R5V3",
    "Shares": ["SAQC-PXRK-KY7O-37FU-DURM-D2N2-S7LX-I",
      "SAQ2-VHKM-H64C-HJXA-TTZD-7W2F-B5PZ-I",
      "SARC-2XDO-FEYV-SUIN-DTA3-3TGP-Q3TY-C"]}}
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
<cmd>Alice> key recover SAQC-PXRK-KY7O-37FU-DURM-D2N2-S7LX-I SARC-2XDO-FEYV-SUIN-DTA3-3TGP-Q3TY-C
<rsp>UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQC-PXRK-KY7O-37FU-DURM-D2N2-S7LX-I SARC-2XDO-FEYV-SUIN-DTA3-3TGP-Q3TY-C /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4"}}
</div>
~~~~



