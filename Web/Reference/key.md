
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
<rsp>EASN-PHWS-DJAI-DWS7-4BVK-MWFF-J4MR-NW
MBRI-NYZW-2OIT-REUD-VMYC-2LUR-5BIB-VPSB-TX2A-OZ77-JPRT-K7CW-MKQF-PN2S
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
<rsp>NBZF-KCXZ-FVOO-VVIO-ALFR-5JVE-UO3A
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
<cmd>Alice> meshman key recover SAQD-5NHQ-BTGZ-DQEB-GOI4-A4VV-WMPN-A SARO-75B4-2ZVP-KWMH-24Q5-7QJ3-GSSA-A
<rsp>4YKU-TJ76-37Z7-3YOJ-WDFX-F4S4-NM
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
<rsp>EDUS-AMYO-VAKG-FONE-IK3T-JWP7-JW6Q
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
<rsp>4YKU-TJ76-37Z7-3YOJ-WDFX-F4S4-NM
MCCR-4JZO-JBIS-YKP3-7ZWS-DOFL-VTLY-EW2T-2WDJ-GZJY-VFYH-WEUS-M32U
SAQD-5NHQ-BTGZ-DQEB-GOI4-A4VV-WMPN-A
SAQZ-OVEW-OGOE-HDIE-QVM5-AGPY-OPQW-Q
SARO-75B4-2ZVP-KWMH-24Q5-7QJ3-GSSA-A
</div>
~~~~







