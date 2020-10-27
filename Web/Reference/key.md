
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
<rsp>NBAV-LLAC-XS4U-RGGE-GCBX-2A4W-BAFA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NBAV-LLAC-XS4U-RGGE-GCBX-2A4W-BAFA"}}
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
<rsp>ED4P-M4GZ-KASC-ANRZ-7API-LVX6-LBFA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ED4P-M4GZ-KASC-ANRZ-7API-LVX6-LBFA"}}
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
<rsp>EBIT-X2HF-JOD7-CGDL-IYO2-TMXT-7PS5-MF
MDLU-OIR4-DHR6-YEHI-LMIC-YVHL-BVO4-M75V-MDQ4-ORIT-TNGT-IA3N-BTJC-FIL7
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBIT-X2HF-JOD7-CGDL-IYO2-TMXT-7PS5-MF",
    "Identifier": "MDLU-OIR4-DHR6-YEHI-LMIC-YVHL-BVO4-M75V-MDQ4-ORIT-TNGT-IA3N-BTJC-FIL7"}}
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
<rsp>DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y
MDO7-KVIF-IIU3-IE6L-5UEN-576Z-WNK4-Z4LV-L4AG-I2UG-NOOW-RUCH-4QVI
SAQF-PXGN-MGQK-5422-O4V5-4KW4-7EAA-W
SAQZ-G73G-V4ZV-M6SZ-FJOV-T4HZ-5BED-Q
SARM-6IP7-7TC7-4AKX-3WHN-LNYW-26IG-K
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y",
    "Identifier": "MDO7-KVIF-IIU3-IE6L-5UEN-576Z-WNK4-Z4LV-L4AG-I2UG-NOOW-RUCH-4QVI",
    "Shares": ["SAQF-PXGN-MGQK-5422-O4V5-4KW4-7EAA-W",
      "SAQZ-G73G-V4ZV-M6SZ-FJOV-T4HZ-5BED-Q",
      "SARM-6IP7-7TC7-4AKX-3WHN-LNYW-26IG-K"]}}
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
<cmd>Alice> key recover SAQF-PXGN-MGQK-5422-O4V5-4KW4-7EAA-W SARM-6IP7-7TC7-4AKX-3WHN-LNYW-26IG-K
<rsp>DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQF-PXGN-MGQK-5422-O4V5-4KW4-7EAA-W SARM-6IP7-7TC7-4AKX-3WHN-LNYW-26IG-K /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y"}}
</div>
~~~~



