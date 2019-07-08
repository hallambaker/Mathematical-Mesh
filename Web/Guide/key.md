
# Using the `key` Command Set

The `key` command set contains commands that operate on cryptographic secrets and
nonces.

## Generating Secrets and Nonces

Secrets and nonces both consist of a randomly generated sequence of bits. The
only distinction made between a secret and a nonce is the uses that may be 
made of them. For example, a secret value must not be passed in clear text in 
any circumstances. The visual distinction between these uses afforded by UDF 
presentation aids application debugging and audit.

The `key nonce` command is used to generate a new random nonce value:


````
Alice> key nonce
NCLN-ATD2-ALYB-5HAG-L3CY-ZLRN-Z6EQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
Alice> key nonce /bits=256
NC4X-DWAX-5YVQ-7HKW-R5VT-BSRR-RIDM-QBQI-4F5S-SMDT-IT6G-77GT-ZKF5-I
````

Secrets are generated in the same way using the command `key secret`:


````
Alice> key secret
EAX7-PX5K-EP7P-5WKB-CU6Q-OU5Q-YP6A
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
Alice> key secret /bits=256
EAA2-W43G-PJKF-6BXJ-RIUS-YCJJ-EJNB-UDA5-4LKU-LS3K-PROW-XELK-JAIH-I
````

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using the `key earl` command to generate
a new secret/digest pair which are then used to process the content data:


````
Alice> key earl
EBO5-LLT3-V4RL-JAB7-WTU7-ZCZF-7LFP-IO
MAIL-2MEL-UN3C-3T7K-D3U6-LTSE-QTIF-5OQ4-NNRY-ILHH-R77I-5ZXO-T3J7-SSP5
````

Alternatively, the `dare earl` command may be used to perform both operations:


````
Alice> dare earl TestFile1.txt
ERROR - The feature has not been implemented
````

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


````
Alice> key share
ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ
MCSQ-WURP-QXUO-3KWT-3ZBU-WUGA-ULQ5-KNX6-6EVQ-KQVY-ZCE4-35FO-4LUA
SAQM-PWF6-Y4JW-Y4X2-DVKB-FLPY-Z5QQ-G
SAQQ-24YZ-WCE5-UGFO-4LXI-UQDG-KST4-4
SARF-GDLU-TIAE-PPTD-VCEQ-DUWT-3HXM-Y
````

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


````
Alice> key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ",
    "Identifier": "MCSQ-WURP-QXUO-3KWT-3ZBU-WUGA-ULQ5-KNX6-6EVQ-KQVY-ZCE4-35FO-4LUA",
    "Shares": ["SAQM-PWF6-Y4JW-Y4X2-DVKB-FLPY-Z5QQ-G",
      "SAQQ-24YZ-WCE5-UGFO-4LXI-UQDG-KST4-4",
      "SARF-GDLU-TIAE-PPTD-VCEQ-DUWT-3HXM-Y"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
Alice> key recover SAQM-PWF6-Y4JW-Y4X2-DVKB-FLPY-Z5QQ-G SARF-GDLU-TIAE-PPTD-VCEQ-DUWT-3HXM-Y
ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
Alice> key share /quorum=3 /shares=5
EASX-B2FW-QPOK-TK2T-O4DG-JNMA-H22Q
MDYD-XION-GG7E-I6IY-PFLA-RUZN-J5DC-VLZX-FWXT-C4PD-POIY-TJNS-UULQ
SAYB-E6QF-ALW7-YQSO-35IW-KVI3-27DW-Q
SAY4-5GD4-7X6G-ESMG-4LLO-ZMZR-CX76-S
SAZF-TTCQ-U6XQ-5P2T-LYDZ-Y7XV-HLT5-E
SAZ3-IFMA-AADA-DI5U-KDRX-JODI-IZ7Y-S
SA2N-25AL-A4AT-V5VJ-XNVH-KX4K-HDDN-W
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
Alice> key share ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ
ECBD-4Y65-TT7M-2RKX-XGNR-XC2K-DICQ
MCSQ-WURP-QXUO-3KWT-3ZBU-WUGA-ULQ5-KNX6-6EVQ-KQVY-ZCE4-35FO-4LUA
SAQA-G5YK-WHBS-PJSQ-TPSH-CSSX-W34V-C
SAQY-JL5R-QXUV-A723-4AHU-O6JE-EPMN-A
SARA-L2CY-LIHX-SWDH-EQ5B-3J7Q-SC4B-Y
````

