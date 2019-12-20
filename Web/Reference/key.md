
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
<rsp>NDLN-IN7W-QXML-TV4Z-YKES-N27M-PEXQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NDLN-IN7W-QXML-TV4Z-YKES-N27M-PEXQ"}}
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
<rsp>ECUX-XPSS-MXDD-P2XC-YCLC-F4ZM-57MQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECUX-XPSS-MXDD-P2XC-YCLC-F4ZM-57MQ"}}
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
<rsp>EBI2-R7IW-F5H6-JNNT-J5TA-AD3K-7T5K-LD
MBVM-OUFP-QBLY-ZRCM-DZXB-CKKM-IFQO-YXDC-3LD6-IXUY-VIY4-MNCR-46ZF-WYPG
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBI2-R7IW-F5H6-JNNT-J5TA-AD3K-7T5K-LD",
    "Identifier": "MBVM-OUFP-QBLY-ZRCM-DZXB-CKKM-IFQO-YXDC-3LD6-IXUY-VIY4-MNCR-46ZF-WYPG"}}
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
<rsp>EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q
MCPR-KQBK-I23Y-ZZ3J-ITHZ-E5U2-FVBY-FUPM-BMQD-JM3K-YF6G-SOBF-UKYQ
SAQI-XFWD-ONIK-OLFU-C4FW-ENV7-WUTH-2
SAQ4-BX5L-Z7OV-TZV5-PPMJ-OO4C-SCD7-2
SARP-MKEU-FRVA-ZIGG-4CS4-YQCF-NPUX-2
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q",
    "Identifier": "MCPR-KQBK-I23Y-ZZ3J-ITHZ-E5U2-FVBY-FUPM-BMQD-JM3K-YF6G-SOBF-UKYQ",
    "Shares": ["SAQI-XFWD-ONIK-OLFU-C4FW-ENV7-WUTH-2",
      "SAQ4-BX5L-Z7OV-TZV5-PPMJ-OO4C-SCD7-2",
      "SARP-MKEU-FRVA-ZIGG-4CS4-YQCF-NPUX-2"]}}
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
<cmd>Alice> key recover SAQI-XFWD-ONIK-OLFU-C4FW-ENV7-WUTH-2 SARP-MKEU-FRVA-ZIGG-4CS4-YQCF-NPUX-2
<rsp>EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQI-XFWD-ONIK-OLFU-C4FW-ENV7-WUTH-2 SARP-MKEU-FRVA-ZIGG-4CS4-YQCF-NPUX-2 /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q"}}
</div>
~~~~



