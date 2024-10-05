
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
<rsp>EC6F-U7PX-STXQ-2Z66-RQUM-PP6A-ABJX-CS
MAOP-YG26-CLUN-6YRX-XSSE-ZR4V-RDHT-PGN5-NTA2-4L6B-EN2C-UPL5-VCKK-B4MC
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
<rsp>NBV4-B2X6-YGYH-6N3N-XUDI-NWXJ-CJKA
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
<cmd>Alice> meshman key recover SAQA-SSRW-7KKI-VNWK-BI46-YXDO-YVZQ-S SARP-GOCE-NSID-OJG4-NID5-JOEY-7OGB-A
<rsp>CRJT-AQMW-WR74-BWSS-7AXF-TKTG-T4
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
<rsp>EA3V-OAE3-RUJS-IXDH-U2JD-RBVP-YGZA
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
<rsp>CRJT-AQMW-WR74-BWSS-7AXF-TKTG-T4
MCYY-FO3A-72EU-CTAT-B2GE-3WSU-B7CZ-QPS2-SLTP-SRMK-JKRW-T2UZ-RLYK
SAQA-SSRW-7KKI-VNWK-BI46-YXDO-YVZQ-S
SAQ7-4QJ5-WOJG-B3OT-HIQO-BCUD-4B72-M
SARP-GOCE-NSID-OJG4-NID5-JOEY-7OGB-A
</div>
~~~~







