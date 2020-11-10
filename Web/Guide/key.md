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
<rsp>NDQQ-2XUX-D2CW-NPTO-QOFE-KRLU-3Q4Q
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NCZZ-AXCD-SWWR-VI5K-BMMR-QQAG-7CMZ-NKLM-MXSU-4NH2-PBGU-A3QF-F76X-W
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EADB-RNYX-E24C-XLPK-EID3-BQMU-YQOQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EC2O-DO4B-ZTHT-Q26M-5JSP-XTQD-V2CB-V42V-CEZI-4NJ2-3OBP-HAO2-I4BR-Y
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
<rsp>EB36-N7RQ-RPQY-VLPV-NOC5-CELK-E5RR-JA
MCSN-I5MW-YA6T-MM23-CELK-GD7B-65F6-6SEM-K2LZ-4OUE-5LN7-3LMB-6JKG-63RF

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
<rsp>UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4
MBPF-MOKL-H5YX-G63R-OTXN-O3M4-KM45-WP3D-33XH-FXXX-ZQG6-LCLO-R5V3
SAQC-PXRK-KY7O-37FU-DURM-D2N2-S7LX-I
SAQ2-VHKM-H64C-HJXA-TTZD-7W2F-B5PZ-I
SARC-2XDO-FEYV-SUIN-DTA3-3TGP-Q3TY-C
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
    "Key": "UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4",
    "Identifier": "MBPF-MOKL-H5YX-G63R-OTXN-O3M4-KM45-WP3D-33XH-FXXX-ZQG6-LCLO-R5V3",
    "Shares": ["SAQC-PXRK-KY7O-37FU-DURM-D2N2-S7LX-I",
      "SAQ2-VHKM-H64C-HJXA-TTZD-7W2F-B5PZ-I",
      "SARC-2XDO-FEYV-SUIN-DTA3-3TGP-Q3TY-C"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQC-PXRK-KY7O-37FU-DURM-D2N2-S7LX-I ^
    SARC-2XDO-FEYV-SUIN-DTA3-3TGP-Q3TY-C
<rsp>UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4
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
<rsp>CZYC-2VU6-K7C3-EU7O-XJQV-DGD3-SY
MBKE-TOJE-2CRX-ONMN-2NDP-CV5E-WIGD-4FQP-ADPC-E73J-5UHV-QM7A-HTWO
SAYP-SUIE-XYQ2-4Z3A-6LIJ-BFEO-LTXC-O
SAYY-OACE-5Y5Y-HKFI-7QBM-ENZD-WRU3-4
SAZL-67PN-43V5-PCMK-N6CU-6SIR-T3XM-C
SAZ2-FSP7-VAZK-UCQF-JVMD-PSSY-DR6P-2
SA2D-BZD2-GIH7-WKQZ-SV5X-XOXX-FUKH-E
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share UUPQ-Q3GF-XBJI-PHKT-IP4D-AICP-Q4
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

