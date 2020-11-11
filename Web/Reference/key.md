
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
<rsp>ND5Z-6243-JO2A-K5BG-UR7W-M26B-MBAA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ND5Z-6243-JO2A-K5BG-UR7W-M26B-MBAA"}}
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
<rsp>EB7E-ZSSO-3AHK-VORB-JO7F-YO63-PIQQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EB7E-ZSSO-3AHK-VORB-JO7F-YO63-PIQQ"}}
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
<rsp>EAX4-T46B-3MHJ-QTOC-UVOM-2K2Q-5IH4-G3
MDS6-ORVS-BXAP-TETA-JVYN-HHCA-WU4D-AO3N-57YR-5ABF-IS6S-XVPW-LUIV-K47Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EAX4-T46B-3MHJ-QTOC-UVOM-2K2Q-5IH4-G3",
    "Identifier": "MDS6-ORVS-BXAP-TETA-JVYN-HHCA-WU4D-AO3N-57YR-5ABF-IS6S-XVPW-LUIV-K47Q"}}
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
<rsp>CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY
MDE6-YM65-YURX-F2LG-ZHCH-VHAR-SN6P-3YHD-EINK-CIJZ-J3TI-EEZX-MEBN
SAQN-BCC4-3CUI-OIZL-F2QB-PA7H-3PLF-4
SAQY-4TB3-F4ED-F6OU-CNDU-DKJP-FLJR-W
SARE-YEAZ-QVT5-5UD4-67XG-XTTW-PHH5-Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY",
    "Identifier": "MDE6-YM65-YURX-F2LG-ZHCH-VHAR-SN6P-3YHD-EINK-CIJZ-J3TI-EEZX-MEBN",
    "Shares": ["SAQN-BCC4-3CUI-OIZL-F2QB-PA7H-3PLF-4",
      "SAQY-4TB3-F4ED-F6OU-CNDU-DKJP-FLJR-W",
      "SARE-YEAZ-QVT5-5UD4-67XG-XTTW-PHH5-Q"]}}
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
<cmd>Alice> key recover SAQN-BCC4-3CUI-OIZL-F2QB-PA7H-3PLF-4 SARE-YEAZ-QVT5-5UD4-67XG-XTTW-PHH5-Q
<rsp>CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQN-BCC4-3CUI-OIZL-F2QB-PA7H-3PLF-4 SARE-YEAZ-QVT5-5UD4-67XG-XTTW-PHH5-Q /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY"}}
</div>
~~~~



