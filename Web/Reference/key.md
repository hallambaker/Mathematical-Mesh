
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
<rsp>NCEQ-2QSZ-RMHP-EJHN-74RH-4NUO-X2TQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NCEQ-2QSZ-RMHP-EJHN-74RH-4NUO-X2TQ"}}
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
<rsp>ECIN-AKQO-6B4F-OC3X-ILJE-DLJH-IQUA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECIN-AKQO-6B4F-OC3X-ILJE-DLJH-IQUA"}}
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
<rsp>EDJ5-BDKR-CZWX-AGIO-F4IT-I5S7-ZIA5-ZN
MBMF-WVSO-55JG-MAKS-SP44-MD4X-PRXA-FG64-2W5F-YRP4-3S4I-ZDFG-DBOJ-RJDV
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDJ5-BDKR-CZWX-AGIO-F4IT-I5S7-ZIA5-ZN",
    "Identifier": "MBMF-WVSO-55JG-MAKS-SP44-MD4X-PRXA-FG64-2W5F-YRP4-3S4I-ZDFG-DBOJ-RJDV"}}
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
<rsp>NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ
MAFU-GZGM-SYNI-WX6R-SSQP-JBWK-TXGI-HFUZ-NLXK-OJ6P-KXUD-XHXV-D7P7
SAQD-VOMQ-BKN7-ZB46-7S5J-ULEQ-KLGA-G
SAQQ-QLD7-QGME-ZC33-FPXG-LHE5-YDTZ-E
SARN-LH3O-7CKJ-ZD2X-LMRD-CDFL-F4BV-I
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ",
    "Identifier": "MAFU-GZGM-SYNI-WX6R-SSQP-JBWK-TXGI-HFUZ-NLXK-OJ6P-KXUD-XHXV-D7P7",
    "Shares": ["SAQD-VOMQ-BKN7-ZB46-7S5J-ULEQ-KLGA-G",
      "SAQQ-QLD7-QGME-ZC33-FPXG-LHE5-YDTZ-E",
      "SARN-LH3O-7CKJ-ZD2X-LMRD-CDFL-F4BV-I"]}}
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
<cmd>Alice> key recover SAQD-VOMQ-BKN7-ZB46-7S5J-ULEQ-KLGA-G SARN-LH3O-7CKJ-ZD2X-LMRD-CDFL-F4BV-I
<rsp>NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQD-VOMQ-BKN7-ZB46-7S5J-ULEQ-KLGA-G SARN-LH3O-7CKJ-ZD2X-LMRD-CDFL-F4BV-I /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ"}}
</div>
~~~~



