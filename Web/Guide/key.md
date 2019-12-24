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
<rsp>NCTC-KKU3-QZST-UGXF-YWUV-ELBV-ISFQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NBKY-VVB6-VBSY-7ESD-NODP-B4RY-75UY-XZE7-C7ZG-KSQT-HBRA-ZBTK-AHVL-U
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EASP-CVRM-NB32-QSOH-XCOI-HKGS-TBAQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EAJT-VQUZ-6MBY-YLM6-HTFS-HDLE-7WAB-3BKX-LMAG-VRWM-6RAP-ZDSL-DTSK-U
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
<rsp>EASB-ULSK-CAQO-AMWN-QHY6-I6TA-5MJ4-WB
MBUQ-PSGE-3DLW-EQ7A-KGIF-WXKJ-2NF6-JCVS-V4MX-VOJL-5JSR-YI3R-BARG-H67I
</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
<div="terminal">
<cmd>Alice> dare earl TestFile1.txt
<rsp>ERROR - The feature has not been implemented
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
<cmd>Alice> key share
<rsp>EADB-RGN6-M725-LCQP-WID5-BN77-BYOA
MDG2-CU4H-GS73-FZ43-B3QY-UCEN-K4DQ-OVTN-NW3X-F4TO-SCE3-MQ2V-TCTQ
SAQB-FPUH-YAKT-ZYA6-WIKF-E6XF-CSS6-A
SAQR-6ZDV-YHBI-H2VT-KR3J-2JIS-FI62-I
SARC-YCTD-YNX4-V5KH-63MO-PTZ7-H7KW-Q
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
    "Key": "EADB-RGN6-M725-LCQP-WID5-BN77-BYOA",
    "Identifier": "MDG2-CU4H-GS73-FZ43-B3QY-UCEN-K4DQ-OVTN-NW3X-F4TO-SCE3-MQ2V-TCTQ",
    "Shares": ["SAQB-FPUH-YAKT-ZYA6-WIKF-E6XF-CSS6-A",
      "SAQR-6ZDV-YHBI-H2VT-KR3J-2JIS-FI62-I",
      "SARC-YCTD-YNX4-V5KH-63MO-PTZ7-H7KW-Q"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQB-FPUH-YAKT-ZYA6-WIKF-E6XF-CSS6-A SARC-YCTD-YNX4-V5KH-63MO-PTZ7-H7KW-Q
<rsp>EADB-RGN6-M725-LCQP-WID5-BN77-BYOA
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
<rsp>EBO6-UT2V-JRUD-2GR7-S75K-G2ZP-SD2A
MBOD-Z6ZL-CHSS-6GU6-2XD2-TC7L-ARWA-IOYZ-GZS4-ZSZM-L62E-M5SA-Z2UQ
SAYM-D6NP-JULH-KLRS-4SWB-CI63-N444-C
SAY7-6PHF-ODL6-SNAH-KQ2M-3U4C-GX72-M
SAZB-LM7R-YCIM-ITUX-RYZD-BMS7-QPRH-A
SAZQ-KXWU-HRAQ-M7PD-SKSD-TQDT-LDRI-K
SA2M-4PMM-4PUK-7QPL-MGFO-R7N5-WT76-K
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share EADB-RGN6-M725-LCQP-WID5-BN77-BYOA
<rsp>EADB-RGN6-M725-LCQP-WID5-BN77-BYOA
MDG2-CU4H-GS73-FZ43-B3QY-UCEN-K4DQ-OVTN-NW3X-F4TO-SCE3-MQ2V-TCTQ
SAQD-VO5O-PXP3-RV4C-AQFL-QYF4-IEG5-6
SAQW-6XWD-HVLX-XWLZ-7BRW-R4GA-QMG2-E
SARK-IAOX-7THT-5W3R-5S6B-TAGE-YUGW-K
</div>
~~~~

