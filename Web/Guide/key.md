<title>key
# Using the key Command Set

The `key` command set contains commands that operate on cryptographic secrets and
nonces.

## Generating Secrets and Nonces

Secrets and nonces both consist of a randomly generated sequence of bits. The
only distinction made between a secret and a nonce is the uses that may be 
made of them. For example, a secret value must not be passed in clear text in 
any circumstances. The visual distinction between these uses afforded by UDF 
presentation aids application debugging and audit.

The `key nonce` command is used to generate a new random nonce value:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce
<rsp>NCAC-2JTC-TIAV-RGQQ-WRZY-N5NX-TDLA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NCOV-TES2-A3F6-4LJL-PCXX-YN64-4SVO-KV67-GBQV-WYWX-DADG-UTGU-OVJ5-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>ECLW-O5SD-BFSE-3UQW-H4YM-35DI-KSRQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>ECUI-RZJA-IOQ4-M6SU-WJVT-PWAB-HNXS-HBBJ-2MWG-FHG7-DXN5-D7C5-YIOX-M
</div>
~~~~

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using the `key earl` command to generate
a new secret/digest pair which are then used to process the content data:


~~~~
<div="terminal">
<cmd>Alice> meshman key earl
<rsp>ECLL-FJIS-NHPL-MFEN-RWW5-7XWQ-3R5R-PY
MB76-DWBP-554T-B7TW-JIO2-E64D-T7ZP-VR3F-X643-W5ZY-MM7X-HEFJ-YH7Q-QKCZ

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
<div="terminal">
<cmd>Alice> meshman dare earl TestFile1.txt example.com
<rsp>ERROR - An unknown error occurred
</div>
~~~~

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


~~~~
<div="terminal">
<cmd>Alice> meshman key share
<rsp>5FN4-CSWQ-IX64-YEV4-MV6U-4KQK-C4
MBIV-FGKW-DOFM-FTNR-4CQN-V73T-7BE5-ZG2C-KT6Y-QDQQ-ZS6C-4TD3-OVBG
SAQJ-O3PQ-F3SL-ECRE-PJTS-X3YB-L5ZK-E
SAQU-LAA7-CL4R-4FT4-4II7-EYFU-STNS-2
SARP-HESN-64GY-UIWV-JG6L-RUTH-ZJB6-W
</div>
~~~~

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


~~~~
<div="terminal">
<cmd>Alice> meshman key share /json
<rsp>{
  "ResultKey": {
    "Key": "5FN4-CSWQ-IX64-YEV4-MV6U-4KQK-C4",
    "Identifier": "MBIV-FGKW-DOFM-FTNR-4CQN-V73T-7BE5-ZG2C-KT6Y-QDQQ-ZS6C-4TD3-OVBG",
    "Shares": ["SAQJ-O3PQ-F3SL-ECRE-PJTS-X3YB-L5ZK-E",
      "SAQU-LAA7-CL4R-4FT4-4II7-EYFU-STNS-2",
      "SARP-HESN-64GY-UIWV-JG6L-RUTH-ZJB6-W"],
    "Success": true}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQJ-O3PQ-F3SL-ECRE-PJTS-X3YB-L5ZK-E ^
    SARP-HESN-64GY-UIWV-JG6L-RUTH-ZJB6-W
<rsp>5FN4-CSWQ-IX64-YEV4-MV6U-4KQK-C4
</div>
~~~~

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


~~~~
<div="terminal">
<cmd>Alice> meshman key share /quorum=3 /shares=5
<rsp>PY6G-Y3PH-CUKB-OZ4B-JNHY-ZLFO-H4
MDRF-EPVP-ZZF5-BQXO-EVJ5-BNCA-ZFM3-EERN-UVGK-XV3X-KJP6-2TIK-ZZZV
SAYJ-CT25-4CLO-QKR5-IDQY-MUB2-O7OU-M
SAY3-ATKT-RME5-CHXR-O7U2-ZIF6-CR5C-K
SAZN-WNSN-NU74-74RU-BSM3-4QIX-QKCN-Y
SAZR-ECSL-Q44O-JJAE-73Y3-WMKG-YH6T-Q
SA2F-JSKN-3D2Q-6NDE-J3Y2-G4KL-2LRZ-6
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share 5FN4-CSWQ-IX64-YEV4-MV6U-4KQK-C4
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

