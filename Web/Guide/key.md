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
<rsp>NCBK-6PZI-NG2X-PLYR-XPRV-HDVG-IYVA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NDCE-JXO6-STXG-2XYV-E22C-2P2G-BGHD-7DL4-L3OY-PJXK-RMKA-PXHQ-JW5A-6
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>ECS3-TLWD-FDZZ-KTUT-KJE4-KNZL-FYGA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>ED5X-ICH2-IX5K-ACFH-CV4Y-FMLE-VS4T-C2YM-TWRJ-XBQ3-V6QK-HIBY-TCJN-4
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
<rsp>EA5D-IE6G-4ZKG-3AGD-JV7Z-Q4IC-2KCA-J2
MDCW-UTHJ-DZRM-Q4UX-WY5I-NIZP-XLTQ-DW6O-PKPL-MRZP-XJ3U-W2SR-G7RR-WWVL

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
<rsp>5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U
MDMD-ID7I-G2YZ-R3QL-ULBC-OJSC-JQYD-GXWL-E4HT-G2NB-G5IM-L6NK-2XHT
SAQL-VGHG-CUSW-RMWH-GWGY-QQOH-LW4C-Y
SAQY-SAZ2-DCCL-SH2E-3KDQ-ZUXX-EBHX-G
SARF-O3MO-DPSA-TC6C-P6AJ-CZBG-4LTL-U
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
    "Key": "5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U",
    "Identifier": "MDMD-ID7I-G2YZ-R3QL-ULBC-OJSC-JQYD-GXWL-E4HT-G2NB-G5IM-L6NK-2XHT",
    "Shares": ["SAQL-VGHG-CUSW-RMWH-GWGY-QQOH-LW4C-Y",
      "SAQY-SAZ2-DCCL-SH2E-3KDQ-ZUXX-EBHX-G",
      "SARF-O3MO-DPSA-TC6C-P6AJ-CZBG-4LTL-U"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQL-VGHG-CUSW-RMWH-GWGY-QQOH-LW4C-Y ^
    SARF-O3MO-DPSA-TC6C-P6AJ-CZBG-4LTL-U
<rsp>5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U
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
<rsp>3Q2N-UTEH-6YXB-K73S-G5J4-IDDG-WA
MACV-XQUO-RLBJ-7HUD-ZTFD-C7BO-I3LU-QYKZ-KYIH-HUM2-P5VL-JZCY-MX6K
SAYM-UQOF-5SVE-BOQ2-FK2C-RFAL-INWN-2
SAYT-KCYY-BZQK-PW3B-D4KF-NGQJ-RPB5-W
SAZB-ZEGQ-WGVS-XEPK-LSJM-CZN6-4VV5-2
SAZY-BUXP-22E4-XXNV-4MXW-R5ZL-KBSO-G
SA2G-DULV-PT6I-RPWD-WLVE-2TSO-ZSXL-U
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share 5QXJ-EEOG-DBDE-TEEU-AOYJ-PGZA-4U
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

