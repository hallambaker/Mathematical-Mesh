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
<rsp>NDFI-5WRA-L5R6-EALN-NPFG-EU66-QTHQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NAPF-BCOR-3WAW-RCF4-URJP-FBSG-MN2R-GRM2-UCXI-CL7V-IPEW-CUWD-645X-G
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>ECOW-HR6W-TWLF-WCXW-OF7K-H55J-CH2Q
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>ECYR-JDYB-2ATZ-SKTO-DZPM-OVJ2-ZUUC-4KOG-Z5OX-367O-PAUS-3OYC-WJED-O
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
<rsp>EBYF-T3I3-HMDO-4EVH-OJKN-CUJA-S6BG-DZ
MD2T-MLE3-3XLQ-I6UJ-ETRP-GT24-OG77-XIGO-GJDI-WDLL-WJRU-DRL5-4GPL-AUW3

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
Missing example 1
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
<rsp>WT77-HFZI-42AW-IV6J-PXUZ-NNSC-TM
MAUQ-VI4X-E57W-WRA6-A773-JWKG-EQ6G-J25H-WEJW-3AIZ-B2B3-DDJS-MZYI
SAQH-JUCJ-A57X-JRPW-QDLL-K2C5-UI5A-O
SAQT-JIE6-O7LA-GCUI-VHR6-ZZZE-RYYX-G
SARP-I4HT-5AWJ-CTY2-2LYS-IZPL-PIUR-E
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
    "Key": "WT77-HFZI-42AW-IV6J-PXUZ-NNSC-TM",
    "Identifier": "MAUQ-VI4X-E57W-WRA6-A773-JWKG-EQ6G-J25H-WEJW-3AIZ-B2B3-DDJS-MZYI",
    "Shares": ["SAQH-JUCJ-A57X-JRPW-QDLL-K2C5-UI5A-O",
      "SAQT-JIE6-O7LA-GCUI-VHR6-ZZZE-RYYX-G",
      "SARP-I4HT-5AWJ-CTY2-2LYS-IZPL-PIUR-E"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQH-JUCJ-A57X-JRPW-QDLL-K2C5-UI5A-O ^
    SARP-I4HT-5AWJ-CTY2-2LYS-IZPL-PIUR-E
<rsp>WT77-HFZI-42AW-IV6J-PXUZ-NNSC-TM
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
<rsp>GYRD-OP3B-GKWH-KE6Z-62I7-JZDT-TA
MDAZ-QACX-XAWG-Q22D-6QHR-GZQR-5H6E-IFXS-UYRM-54Y5-OZ4Y-NQD2-AREE
SAYM-UNX3-Q3QA-XI4Q-5CNW-ABQK-AEQB-W
SAYV-FQ5L-XJ5Q-B2ST-HTXG-FF4C-GS4G-S
SAZM-7SCH-3IZB-FAF4-CDJP-4RS5-P46O-Q
SAZU-CRGP-4YCU-AZWL-MRET-GEU3-4CWT-E
SA2K-OOKD-3X2I-VHEB-G5IQ-B7B5-LEE2-2
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share WT77-HFZI-42AW-IV6J-PXUZ-NNSC-TM
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

