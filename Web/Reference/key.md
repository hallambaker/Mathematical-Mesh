
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
<rsp>EBYF-T3I3-HMDO-4EVH-OJKN-CUJA-S6BG-DZ
MD2T-MLE3-3XLQ-I6UJ-ETRP-GT24-OG77-XIGO-GJDI-WDLL-WJRU-DRL5-4GPL-AUW3
</div>
~~~~





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
<rsp>NDFI-5WRA-L5R6-EALN-NPFG-EU66-QTHQ
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
<cmd>Alice> meshman key recover SAQH-JUCJ-A57X-JRPW-QDLL-K2C5-UI5A-O SARP-I4HT-5AWJ-CTY2-2LYS-IZPL-PIUR-E
<rsp>WT77-HFZI-42AW-IV6J-PXUZ-NNSC-TM
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
<rsp>ECOW-HR6W-TWLF-WCXW-OF7K-H55J-CH2Q
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
<rsp>WT77-HFZI-42AW-IV6J-PXUZ-NNSC-TM
MAUQ-VI4X-E57W-WRA6-A773-JWKG-EQ6G-J25H-WEJW-3AIZ-B2B3-DDJS-MZYI
SAQH-JUCJ-A57X-JRPW-QDLL-K2C5-UI5A-O
SAQT-JIE6-O7LA-GCUI-VHR6-ZZZE-RYYX-G
SARP-I4HT-5AWJ-CTY2-2LYS-IZPL-PIUR-E
</div>
~~~~







