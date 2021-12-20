
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
<rsp>EBB4-Q5GA-MBAW-XYHP-ZEA4-HY2S-LB3J-JX
MCPO-5GTH-KCYZ-FZVS-T7GP-C7MG-TJQH-MLHB-A22Z-KBPS-77SZ-L3SW-XL4H-IRRY
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
<rsp>NAU5-F3CD-FBRB-2FQE-3XPL-NVKI-2BLQ
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
value as a UDF Encryption key type. It is not necessary to enter the shares in a particular order.


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQL-PIHW-KFCV-MVKU-3UO6-ZEY4-2DXB-O SARM-6FX7-H5SF-ZBOS-RZVC-LY7W-AEMW-6
<rsp>VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
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
<rsp>EDS5-MX7W-FO2S-LMAP-QMZK-ZEG2-LEWA
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
<rsp>VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
MBSG-RAUT-4OLX-TWJH-A337-RPHT-KRDE-KZWC-Q3M5-3Z25-QESB-24NW-URKR
SAQL-PIHW-KFCV-MVKU-3UO6-ZEY4-2DXB-O
SAQ4-GW72-ZBKN-S3MT-WXCA-SO4J-NEB4-G
SARM-6FX7-H5SF-ZBOS-RZVC-LY7W-AEMW-6
</div>
~~~~







