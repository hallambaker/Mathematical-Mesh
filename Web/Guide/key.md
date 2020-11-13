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
<rsp>NBHX-JIOO-4VQY-FDZN-ZOC3-T2LA-AYFQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NAMG-GJBP-2BBI-KCQQ-U5QL-SXGG-CYQX-MGI2-AANZ-EMWL-F4R7-NRQS-O47P-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EA4C-YEQM-NSEV-CN5R-EJMO-JXP3-BXVQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ECLM-52A5-SRTX-ZCSR-TXYX-TXBW-BJIA-EJ52-GO5B-SIVE-6W4K-WOVC-22HM-6
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
<rsp>ECZG-3DOX-4EOU-23QR-CMNB-RCMA-WCXK-J2
MCVQ-HAWD-4C4P-RTGH-RRDO-VBPW-HMXX-2QKF-W36W-PQHQ-W2F7-OLH4-3DUA-UE4I

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
<rsp>DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY
MDM5-BM6U-AHDA-ADIC-WI4S-BTEI-CBH4-NYTZ-RMKM-G43I-Z5NY-6MC2-SBS7
SAQK-PNZ5-2ZGO-LU2I-KVZL-IFTV-G3I4-U
SAQT-NNBW-RVR3-NVQA-Z3TL-HBFS-TYBC-W
SARM-LMJP-IR5I-PWFZ-JBNL-F4XQ-AUZL-6
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
    "Key": "DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY",
    "Identifier": "MDM5-BM6U-AHDA-ADIC-WI4S-BTEI-CBH4-NYTZ-RMKM-G43I-Z5NY-6MC2-SBS7",
    "Shares": ["SAQK-PNZ5-2ZGO-LU2I-KVZL-IFTV-G3I4-U",
      "SAQT-NNBW-RVR3-NVQA-Z3TL-HBFS-TYBC-W",
      "SARM-LMJP-IR5I-PWFZ-JBNL-F4XQ-AUZL-6"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQK-PNZ5-2ZGO-LU2I-KVZL-IFTV-G3I4-U ^
    SARM-LMJP-IR5I-PWFZ-JBNL-F4XQ-AUZL-6
<rsp>DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY
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
<rsp>GWBT-A7X2-WWMH-5USC-OHQ7-GBD3-PE
MABH-VY5G-HGHH-LRSC-B37S-K5S6-YOQT-OLIX-JAQD-NQX4-2Y65-O7GU-EFYB
SAYP-UAJS-W33L-VERV-XQJK-HVKW-Z2SN-S
SAYX-2YMV-FOFB-UBQY-XROX-JTLH-ZFMA-C
SAZL-7JCX-3S2N-H5BH-2MRO-JSRF-6SKV-O
SAZ4-BSL2-ZJ3O-QXDD-ABRP-HS4R-KBOK-Q
SA2I-BUH5-6TIF-OPWK-IQO2-DUNJ-3SW7-I
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share DC5E-KHZW-CTII-7W76-WSUD-PT5B-GY
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

