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
<rsp>NAIP-F6BH-ZR5A-KGZZ-E5AW-ECY5-BSIQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NASC-TACK-QXD3-QXDF-5KDB-P6XR-CTPE-PUPS-ZESX-SG5T-AI53-66BN-3N2Y-G
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>ED2N-DYS6-RDEE-7ZE6-NEEB-4JKF-SHHQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EDRC-VSKS-XFJS-3W7E-SEPR-VV54-QDU5-SWOE-CAWN-K36Z-4CVC-TSHL-7S3G-2
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
<rsp>EAWB-DPFF-35Z2-BSYA-UVIN-2OJ5-UO7F-7U
MCVI-RFX3-VZOI-QKCH-ZK5K-SEU7-3ES2-RGYA-RB4I-A2RM-Q5AX-KRV5-SVMC-MO2O

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
<rsp>LICV-3VXL-OVCG-FTUC-CDEW-URNJ-5I
MDWO-G3QQ-JB7M-6WXA-325Q-JMR5-3TYN-BPXW-QGTY-QH6Y-6PZP-232A-DRYE
SAQH-653F-HQ65-ZOKM-JU3O-4J7X-2HJF-U
SAQ2-J2LM-UGIE-ILRV-ZPV4-XBUF-LX5M-U
SARM-UW3U-A3RK-XIY7-JKQK-RZIS-5IRT-U
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
    "Key": "LICV-3VXL-OVCG-FTUC-CDEW-URNJ-5I",
    "Identifier": "MDWO-G3QQ-JB7M-6WXA-325Q-JMR5-3TYN-BPXW-QGTY-QH6Y-6PZP-232A-DRYE",
    "Shares": ["SAQH-653F-HQ65-ZOKM-JU3O-4J7X-2HJF-U",
      "SAQ2-J2LM-UGIE-ILRV-ZPV4-XBUF-LX5M-U",
      "SARM-UW3U-A3RK-XIY7-JKQK-RZIS-5IRT-U"],
    "Success": true}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQH-653F-HQ65-ZOKM-JU3O-4J7X-2HJF-U ^
    SARM-UW3U-A3RK-XIY7-JKQK-RZIS-5IRT-U
<rsp>LICV-3VXL-OVCG-FTUC-CDEW-URNJ-5I
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
<rsp>LZDE-M2N6-NW5S-662O-M6QT-IZKF-WY
MCWF-7TT5-33FE-LQJB-6SIX-77RZ-5GI2-MFPU-J4XZ-ANGX-4VI6-4UCR-XCEC
SAYN-Y2FR-FGUN-ZJ23-EWWY-HXBZ-VGYJ-W
SAYW-Z32W-PUPA-EAYF-LATR-S6JK-WHUJ-S
SAZA-7WRW-MQO5-3TRO-CK5S-Q6AH-PXW6-G
SAZ4-KKKQ-32UH-ACGV-KVU3-BWGQ-BXAK-Y
SA2I-ZXFF-5S63-RMX3-EAZL-FG4E-MFQI-4
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share LICV-3VXL-OVCG-FTUC-CDEW-URNJ-5I
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

