
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
<rsp>NBCE-RT2L-XDDT-LW2I-4CKE-46XU-LC7Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NBCE-RT2L-XDDT-LW2I-4CKE-46XU-LC7Q"}}
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
<rsp>EBXH-Q2QX-UQZV-JY3B-4KBS-DJH3-IZ6Q
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBXH-Q2QX-UQZV-JY3B-4KBS-DJH3-IZ6Q"}}
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
<rsp>ECZT-ZW7N-2SIH-YCHX-DIJR-33H2-TKJ4-JA
MCAO-HLRT-WAWB-HQKY-RU7S-HNHC-INQT-Z2Y3-WAV4-33FG-MW2U-YU35-VPFR-AGTZ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECZT-ZW7N-2SIH-YCHX-DIJR-33H2-TKJ4-JA",
    "Identifier": "MCAO-HLRT-WAWB-HQKY-RU7S-HNHC-INQT-Z2Y3-WAV4-33FG-MW2U-YU35-VPFR-AGTZ"}}
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
<rsp>EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ
MC7J-KNZH-SD7Z-GJMU-IZAB-KLBI-USUB-GQEX-B4AA-MTTL-KMJN-LQXM-PFDE
SAQC-UDCJ-FGXA-XSML-WBOV-T2TB-U24G-C
SAQX-LVE5-3BLW-2VIS-UQ73-FPQL-F4X6-I
SARM-DHHS-Q4AM-5YEZ-TARA-XENU-W6TW-O
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ",
    "Identifier": "MC7J-KNZH-SD7Z-GJMU-IZAB-KLBI-USUB-GQEX-B4AA-MTTL-KMJN-LQXM-PFDE",
    "Shares": ["SAQC-UDCJ-FGXA-XSML-WBOV-T2TB-U24G-C",
      "SAQX-LVE5-3BLW-2VIS-UQ73-FPQL-F4X6-I",
      "SARM-DHHS-Q4AM-5YEZ-TARA-XENU-W6TW-O"]}}
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
<cmd>Alice> key recover SAQC-UDCJ-FGXA-XSML-WBOV-T2TB-U24G-C SARM-DHHS-Q4AM-5YEZ-TARA-XENU-W6TW-O
<rsp>EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQC-UDCJ-FGXA-XSML-WBOV-T2TB-U24G-C SARM-DHHS-Q4AM-5YEZ-TARA-XENU-W6TW-O /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ"}}
</div>
~~~~



