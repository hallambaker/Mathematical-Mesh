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
<rsp>NC7Q-WQA7-HBRG-ND3N-BMPF-V5HW-HAZQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NBQW-Z5AM-JX5V-XBHA-F32A-GNHI-4RYY-XAM4-SYOE-ZVGG-WMBI-6UU4-H437-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>ED7E-NMBL-IK4D-FL7T-2Q2S-J6YW-D7HA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>ED2W-52FX-4SIS-KW4Y-P5KT-UWHP-2WIR-UT6W-DZPB-VCMT-J5F4-AUFT-A52V-E
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
<rsp>EA66-QPMP-VQBA-6ZMZ-W4HT-PY35-S2X3-AG
MAMK-7RM3-FWRH-MZKQ-4H4M-QHXH-PXE4-HSZT-XBXU-GJG7-AFRS-DQIC-AZAB-CLQ7

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
Missing example 7
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
<rsp>K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
MAAW-T3UJ-4XQL-RTFJ-BXXH-STPN-LZ5D-LLK3-5MWF-WYAM-6JQC-V4KS-HTEU
SAQD-VDTI-E3YM-XF7X-3FUV-D6CO-BO3O-I
SAQR-2YQ6-F4JS-3ZFD-QVEG-JIHM-QC3W-W
SARA-ANOU-G42Z-AMKP-GETX-OSMK-6W37-E
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
    "Key": "K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU",
    "Identifier": "MAAW-T3UJ-4XQL-RTFJ-BXXH-STPN-LZ5D-LLK3-5MWF-WYAM-6JQC-V4KS-HTEU",
    "Shares": ["SAQD-VDTI-E3YM-XF7X-3FUV-D6CO-BO3O-I",
      "SAQR-2YQ6-F4JS-3ZFD-QVEG-JIHM-QC3W-W",
      "SARA-ANOU-G42Z-AMKP-GETX-OSMK-6W37-E"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQD-VDTI-E3YM-XF7X-3FUV-D6CO-BO3O-I ^
    SARA-ANOU-G42Z-AMKP-GETX-OSMK-6W37-E
<rsp>K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
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
<rsp>VQ6V-H3H4-KOIP-VGX4-5TRR-4R3I-CU
MD7Q-CF6S-YBBS-BEVN-TXXG-DJMW-N7VV-M5YL-B6EH-C37R-TDUE-LZDE-KAQL
SAYD-GCOY-YSFX-HA6I-CQD2-2V3J-JAXT-K
SAYQ-P6XV-RMV4-AUMK-BWME-FALO-2YN5-K
SAZC-WEFK-IDOT-T6SA-Q6XK-YYJO-6EW7-K
SAZZ-YSXW-4WP6-A7PL-QJFO-V5VJ-TFSZ-K
SA2F-XKO3-PFZ3-HXEK-7VWP-4QO6-Z3BI-E
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share K65L-EHWO-NFFU-YLMK-H5H2-7FVW-LU
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

