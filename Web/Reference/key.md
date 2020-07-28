
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
<rsp>NC6S-4P32-DN6X-X5XT-7FGG-R6ZJ-FPFA
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key nonce /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "NC6S-4P32-DN6X-X5XT-7FGG-R6ZJ-FPFA"}}
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
<rsp>ECBV-NNU4-LJVA-PZM3-J66J-EMQR-PRBQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key secret /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "ECBV-NNU4-LJVA-PZM3-J66J-EMQR-PRBQ"}}
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
<rsp>EBEW-QNOT-6ACF-6KW3-4DRD-HTZW-G3ZD-JS
MCYP-CCPS-7JOG-NCPS-OQNC-6YXS-IJFK-VQ4S-F7KY-BPHI-FHEX-MDAU-SGD3-FUEH
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key earl /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EBEW-QNOT-6ACF-6KW3-4DRD-HTZW-G3ZD-JS",
    "Identifier": "MCYP-CCPS-7JOG-NCPS-OQNC-6YXS-IJFK-VQ4S-F7KY-BPHI-FHEX-MDAU-SGD3-FUEH"}}
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
<rsp>EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ
MDNS-WI5Q-NX3W-TG3O-RPX6-QVJ4-MMVT-D6PL-ZZZV-SPWG-N4C7-OM2F-VZZH
SAQO-6O6Z-A6YD-PMHO-TPUZ-ZLPQ-VSA7-K
SAQ7-IDPP-QX4A-PBA3-JBPZ-K2OW-6HJ4-2
SARP-RYAG-AQ75-OV2H-6TKY-4JN5-G4S2-K
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ",
    "Identifier": "MDNS-WI5Q-NX3W-TG3O-RPX6-QVJ4-MMVT-D6PL-ZZZV-SPWG-N4C7-OM2F-VZZH",
    "Shares": ["SAQO-6O6Z-A6YD-PMHO-TPUZ-ZLPQ-VSA7-K",
      "SAQ7-IDPP-QX4A-PBA3-JBPZ-K2OW-6HJ4-2",
      "SARP-RYAG-AQ75-OV2H-6TKY-4JN5-G4S2-K"]}}
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
<cmd>Alice> key recover SAQO-6O6Z-A6YD-PMHO-TPUZ-ZLPQ-VSA7-K SARP-RYAG-AQ75-OV2H-6TKY-4JN5-G4S2-K
<rsp>EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ
</div>
~~~~

Specifying the /json option returns a result of type ResultKey:

~~~~
<div="terminal">
<cmd>Alice> key recover SAQO-6O6Z-A6YD-PMHO-TPUZ-ZLPQ-VSA7-K SARP-RYAG-AQ75-OV2H-6TKY-4JN5-G4S2-K /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "EDVG-TQUJ-NBT5-3QPP-OOR7-ECTH-GAOQ"}}
</div>
~~~~



