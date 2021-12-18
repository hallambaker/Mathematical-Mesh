
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
<cmd>Alice> meshman key nonce
<rsp>NC7Q-WQA7-HBRG-ND3N-BMPF-V5HW-HAZQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NC7Q-WQA7-HBRG-ND3N-BMPF-V5HW-HAZQ"}}
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
<cmd>Alice> meshman key secret
<rsp>ED7E-NMBL-IK4D-FL7T-2Q2S-J6YW-D7HA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> meshman key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ED7E-NMBL-IK4D-FL7T-2Q2S-J6YW-D7HA"}}
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
<cmd>Alice> meshman key earl
<rsp>EA66-QPMP-VQBA-6ZMZ-W4HT-PY35-S2X3-AG
MAMK-7RM3-FWRH-MZKQ-4H4M-QHXH-PXE4-HSZT-XBXU-GJG7-AFRS-DQIC-AZAB-CLQ7
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> meshman key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EA66-QPMP-VQBA-6ZMZ-W4HT-PY35-S2X3-AG",
    "Identifier": "MAMK-7RM3-FWRH-MZKQ-4H4M-QHXH-PXE4-HSZT-XBXU-GJG7-AFRS-DQIC-AZAB-CLQ7"}}
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
<cmd>Alice> meshman key share
<rsp>K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
MAAW-T3UJ-4XQL-RTFJ-BXXH-STPN-LZ5D-LLK3-5MWF-WYAM-6JQC-V4KS-HTEU
SAQD-VDTI-E3YM-XF7X-3FUV-D6CO-BO3O-I
SAQR-2YQ6-F4JS-3ZFD-QVEG-JIHM-QC3W-W
SARA-ANOU-G42Z-AMKP-GETX-OSMK-6W37-E
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> meshman key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU",
    "Identifier": "MAAW-T3UJ-4XQL-RTFJ-BXXH-STPN-LZ5D-LLK3-5MWF-WYAM-6JQC-V4KS-HTEU",
    "Shares": ["SAQD-VDTI-E3YM-XF7X-3FUV-D6CO-BO3O-I",
      "SAQR-2YQ6-F4JS-3ZFD-QVEG-JIHM-QC3W-W",
      "SARA-ANOU-G42Z-AMKP-GETX-OSMK-6W37-E"]}}
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
<cmd>Alice> meshman key recover SAQD-VDTI-E3YM-XF7X-3FUV-D6CO-BO3O-I SARA-ANOU-G42Z-AMKP-GETX-OSMK-6W37-E
<rsp>K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQD-VDTI-E3YM-XF7X-3FUV-D6CO-BO3O-I SARA-ANOU-G42Z-AMKP-GETX-OSMK-6W37-E /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU"}}
</div>
~~~~



