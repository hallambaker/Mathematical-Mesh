
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
<rsp>NAC4-FVVP-OG4R-RGQS-XCTC-3ECI-LWTA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NAC4-FVVP-OG4R-RGQS-XCTC-3ECI-LWTA"}}
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
<rsp>ECZS-MCZV-Q4PT-2V7C-B4EO-BZXY-CMOA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECZS-MCZV-Q4PT-2V7C-B4EO-BZXY-CMOA"}}
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
<rsp>EAMA-F3Z3-KOXN-6T2S-LXJN-M3RP-YHBA-YH
MAG7-QZVX-DYJZ-7BNZ-CAS6-NU6O-7NC7-LW7D-MJZJ-LHHT-WJR7-YOIW-4IEY-ZG7W
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EAMA-F3Z3-KOXN-6T2S-LXJN-M3RP-YHBA-YH",
    "Identifier": "MAG7-QZVX-DYJZ-7BNZ-CAS6-NU6O-7NC7-LW7D-MJZJ-LHHT-WJR7-YOIW-4IEY-ZG7W"}}
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
<rsp>INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
MARI-JIJ7-MN3S-JHRE-GVQC-Z3H4-727N-W3QY-UHBJ-4KZT-4O3G-OPXC-GCZR
SAQJ-BYIM-G42W-ZED7-DTNL-KY3Q-YGJC-I
SAQ5-4UM3-TYJC-FBQV-VVLB-TCVK-PNYP-W
SARC-XQRL-ATXN-Q65M-HXIX-3MPE-GVHZ-6
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU",
    "Identifier": "MARI-JIJ7-MN3S-JHRE-GVQC-Z3H4-727N-W3QY-UHBJ-4KZT-4O3G-OPXC-GCZR",
    "Shares": ["SAQJ-BYIM-G42W-ZED7-DTNL-KY3Q-YGJC-I",
      "SAQ5-4UM3-TYJC-FBQV-VVLB-TCVK-PNYP-W",
      "SARC-XQRL-ATXN-Q65M-HXIX-3MPE-GVHZ-6"]}}
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
<cmd>Alice> key recover SAQJ-BYIM-G42W-ZED7-DTNL-KY3Q-YGJC-I SARC-XQRL-ATXN-Q65M-HXIX-3MPE-GVHZ-6
<rsp>INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQJ-BYIM-G42W-ZED7-DTNL-KY3Q-YGJC-I SARC-XQRL-ATXN-Q65M-HXIX-3MPE-GVHZ-6 /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU"}}
</div>
~~~~



