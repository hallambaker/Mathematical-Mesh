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
<rsp>NAU5-F3CD-FBRB-2FQE-3XPL-NVKI-2BLQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NBHN-3P7H-VTDJ-6XV4-MLZT-Z3IW-NDQV-KVHV-4W7K-W5DZ-6Y4K-5MJD-HPLM-2
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EDS5-MX7W-FO2S-LMAP-QMZK-ZEG2-LEWA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EDZT-4OJO-EFDZ-OCQS-MPOY-B4GE-VWLW-I4TQ-2IIE-G4NE-MZ7K-RX75-42LC-4
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
<rsp>EBB4-Q5GA-MBAW-XYHP-ZEA4-HY2S-LB3J-JX
MCPO-5GTH-KCYZ-FZVS-T7GP-C7MG-TJQH-MLHB-A22Z-KBPS-77SZ-L3SW-XL4H-IRRY

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
<rsp>VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
MBSG-RAUT-4OLX-TWJH-A337-RPHT-KRDE-KZWC-Q3M5-3Z25-QESB-24NW-URKR
SAQL-PIHW-KFCV-MVKU-3UO6-ZEY4-2DXB-O
SAQ4-GW72-ZBKN-S3MT-WXCA-SO4J-NEB4-G
SARM-6FX7-H5SF-ZBOS-RZVC-LY7W-AEMW-6
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
    "Success": true,
    "Key": "VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM",
    "Identifier": "MBSG-RAUT-4OLX-TWJH-A337-RPHT-KRDE-KZWC-Q3M5-3Z25-QESB-24NW-URKR",
    "Shares": ["SAQL-PIHW-KFCV-MVKU-3UO6-ZEY4-2DXB-O",
      "SAQ4-GW72-ZBKN-S3MT-WXCA-SO4J-NEB4-G",
      "SARM-6FX7-H5SF-ZBOS-RZVC-LY7W-AEMW-6"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQL-PIHW-KFCV-MVKU-3UO6-ZEY4-2DXB-O ^
    SARM-6FX7-H5SF-ZBOS-RZVC-LY7W-AEMW-6
<rsp>VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
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
<rsp>OZ4E-TKUS-TTZD-4FBD-YLHL-IHJS-2Y
MDOT-XGTZ-L54A-7CC5-A5MP-IU4D-VUDN-JRQ5-LRRA-GIW5-6DA7-54XZ-DUFU
SAYC-6C22-TW42-ACVV-XB5W-4Y2X-JBJE-O
SAY6-E6ZA-TEFI-FZSJ-3D45-6FEL-H6JB-4
SAZJ-BR43-TSCU-LBH2-OWPR-JYSQ-ALY7-K
SAZT-T4GL-VAU6-PZWH-RZVQ-7TFF-SJY7-6
SA2N-35VQ-XP4G-UC5R-ENO4-7U4L-5YJG-6
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share VPS7-DWRV-2M6R-MBDX-Z7VL-AOGY-NM
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

