
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

The `key earl` only creates the cryptographic material required to create an EARL.
The 'dare earl' command generates the cryptographic material and applies it to the contents
of a file.


~~~~
<div="terminal">
<cmd>Alice> meshman key earl
<rsp>ECUY-N7LY-5T42-WLFE-KDMP-3KRO-3IBE-JH
MDP7-PCT2-F5U3-UW2T-XMWX-3WU2-676G-VNWP-3BQK-S4SU-R5RP-UIR3-Y6WU-PIGU
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
<rsp>NCSB-5UHJ-MFPO-SIIR-7EQS-6CRR-FIBQ
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
<cmd>Alice> meshman key recover SAQB-KSRY-T3BX-NAE6-ERB4-7HYX-DUQQ-4 SARP-ZGVJ-3HFC-HH2D-IQHZ-E5OX-UEPG-4
<rsp>UGRA-AAKA-D7YU-XFC5-5YZ3-NWZC-SE
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
<rsp>EAMQ-OYRD-6W45-FN44-KKDQ-DH4W-KX4Q
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
<rsp>UGRA-AAKA-D7YU-XFC5-5YZ3-NWZC-SE
MA3W-X3QR-REOY-N4KI-ZHDT-OPRQ-YPZW-NCPB-O2OM-HEES-HWCS-G7ZG-NXWI
SAQB-KSRY-T3BX-NAE6-ERB4-7HYX-DUQQ-4
SAQY-R4TR-HRDM-2D7Q-WQU3-CCTX-L4P3-4
SARP-ZGVJ-3HFC-HH2D-IQHZ-E5OX-UEPG-4
</div>
~~~~







