
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
<rsp>NBHX-JIOO-4VQY-FDZN-ZOC3-T2LA-AYFQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NBHX-JIOO-4VQY-FDZN-ZOC3-T2LA-AYFQ"}}
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
<rsp>EA4C-YEQM-NSEV-CN5R-EJMO-JXP3-BXVQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EA4C-YEQM-NSEV-CN5R-EJMO-JXP3-BXVQ"}}
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
<rsp>ECZG-3DOX-4EOU-23QR-CMNB-RCMA-WCXK-J2
MCVQ-HAWD-4C4P-RTGH-RRDO-VBPW-HMXX-2QKF-W36W-PQHQ-W2F7-OLH4-3DUA-UE4I
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECZG-3DOX-4EOU-23QR-CMNB-RCMA-WCXK-J2",
    "Identifier": "MCVQ-HAWD-4C4P-RTGH-RRDO-VBPW-HMXX-2QKF-W36W-PQHQ-W2F7-OLH4-3DUA-UE4I"}}
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
<rsp>DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY
MDM5-BM6U-AHDA-ADIC-WI4S-BTEI-CBH4-NYTZ-RMKM-G43I-Z5NY-6MC2-SBS7
SAQK-PNZ5-2ZGO-LU2I-KVZL-IFTV-G3I4-U
SAQT-NNBW-RVR3-NVQA-Z3TL-HBFS-TYBC-W
SARM-LMJP-IR5I-PWFZ-JBNL-F4XQ-AUZL-6
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY",
    "Identifier": "MDM5-BM6U-AHDA-ADIC-WI4S-BTEI-CBH4-NYTZ-RMKM-G43I-Z5NY-6MC2-SBS7",
    "Shares": ["SAQK-PNZ5-2ZGO-LU2I-KVZL-IFTV-G3I4-U",
      "SAQT-NNBW-RVR3-NVQA-Z3TL-HBFS-TYBC-W",
      "SARM-LMJP-IR5I-PWFZ-JBNL-F4XQ-AUZL-6"]}}
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
<cmd>Alice> key recover SAQK-PNZ5-2ZGO-LU2I-KVZL-IFTV-G3I4-U SARM-LMJP-IR5I-PWFZ-JBNL-F4XQ-AUZL-6
<rsp>DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQK-PNZ5-2ZGO-LU2I-KVZL-IFTV-G3I4-U SARM-LMJP-IR5I-PWFZ-JBNL-F4XQ-AUZL-6 /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY"}}
</div>
~~~~



