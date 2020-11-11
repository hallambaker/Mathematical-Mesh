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
<cmd>Alice> key nonce
<rsp>ND5Z-6243-JO2A-K5BG-UR7W-M26B-MBAA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NBEX-OXPJ-RPVC-Y4R7-A4M4-OLIW-JNS6-FMHI-DN5B-Y7HS-Z665-5SCY-KSJZ-2
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EB7E-ZSSO-3AHK-VORB-JO7F-YO63-PIQQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ECVO-D76K-BAGA-WI6A-M3L5-6R7K-DA2M-GBNK-ODOE-7IBO-FJIS-XOBC-YSDL-Q
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
<cmd>Alice> key earl
<rsp>EAX4-T46B-3MHJ-QTOC-UVOM-2K2Q-5IH4-G3
MDS6-ORVS-BXAP-TETA-JVYN-HHCA-WU4D-AO3N-57YR-5ABF-IS6S-XVPW-LUIV-K47Q

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
Missing example 4
~~~~

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


~~~~
<div="terminal">
<cmd>Alice> key share
<rsp>CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY
MDE6-YM65-YURX-F2LG-ZHCH-VHAR-SN6P-3YHD-EINK-CIJZ-J3TI-EEZX-MEBN
SAQN-BCC4-3CUI-OIZL-F2QB-PA7H-3PLF-4
SAQY-4TB3-F4ED-F6OU-CNDU-DKJP-FLJR-W
SARE-YEAZ-QVT5-5UD4-67XG-XTTW-PHH5-Q
</div>
~~~~

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY",
    "Identifier": "MDE6-YM65-YURX-F2LG-ZHCH-VHAR-SN6P-3YHD-EINK-CIJZ-J3TI-EEZX-MEBN",
    "Shares": ["SAQN-BCC4-3CUI-OIZL-F2QB-PA7H-3PLF-4",
      "SAQY-4TB3-F4ED-F6OU-CNDU-DKJP-FLJR-W",
      "SARE-YEAZ-QVT5-5UD4-67XG-XTTW-PHH5-Q"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQN-BCC4-3CUI-OIZL-F2QB-PA7H-3PLF-4 ^
    SARE-YEAZ-QVT5-5UD4-67XG-XTTW-PHH5-Q
<rsp>CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY
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
<cmd>Alice> key share /quorum=3 /shares=5
<rsp>GYNJ-IZ6Y-JYLE-36Q3-QJP5-D7CP-7U
MDKT-YLY7-QNVL-PVFH-6R4F-NOWQ-U43I-LJ6J-LXXX-2PBA-PCSR-NIUM-NFVJ
SAYN-6QXZ-XNXV-IORJ-IEHO-5D32-LQR7-A
SAYU-7DFP-ILFO-YU45-44US-VOEN-6557-U
SAZI-N55U-7XVR-MYVL-5RVD-NWYM-ZZMI-C
SAZY-LBAK-5TH5-EZ2T-KDJB-F5XW-4C4V-E
SA2E-WMNR-B54S-AYMU-CRQL-6DCM-F2PG-2
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share CLCH-5ASI-3NGI-ESPY-5VPK-BDGZ-NY
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

