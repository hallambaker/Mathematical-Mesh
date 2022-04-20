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
<rsp>NDQO-CRFB-7Q2T-7PBF-QSDA-4QDM-3OCQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NAL6-L7WE-G2ZX-54FN-EJIB-VOMS-FF6J-H5WG-YMHZ-7MJL-QTNV-TM36-ESSG-G
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>ECKK-AQRO-KTCX-5SF3-TYVI-U3FO-OCOA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EABV-WM7M-PECY-F43H-DOUY-7YPL-5EVS-GPAB-QBVV-YXXQ-JAJS-B2H4-YGMA-A
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
<rsp>ECMU-XV2S-GMPK-IKDB-ZYU5-532V-ARPA-4Q
MAMT-M3E3-AOIF-WJGE-ENOV-L6CG-FSIV-ZFIR-LH4M-AJRM-OQXQ-JYGB-ZDBI-MFZM

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
<rsp>FONQ-44SZ-FPSK-PIRE-J646-OCG4-ZY
MB5L-YKYL-FCDD-CB3S-4QU2-JZZN-W4DF-DMDQ-NNXJ-HII4-E2VX-GN6P-J3VC
SAQE-B6HK-FZT7-3XFY-YIAV-7HQZ-PYIE-I
SAQV-MVWF-5J3M-7VGJ-4HPG-7ASL-6NB3-U
SARG-XNFB-U2C2-DTG3-AG5X-6ZT6-NB3T-A
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
    "Key": "FONQ-44SZ-FPSK-PIRE-J646-OCG4-ZY",
    "Identifier": "MB5L-YKYL-FCDD-CB3S-4QU2-JZZN-W4DF-DMDQ-NNXJ-HII4-E2VX-GN6P-J3VC",
    "Shares": ["SAQE-B6HK-FZT7-3XFY-YIAV-7HQZ-PYIE-I",
      "SAQV-MVWF-5J3M-7VGJ-4HPG-7ASL-6NB3-U",
      "SARG-XNFB-U2C2-DTG3-AG5X-6ZT6-NB3T-A"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQE-B6HK-FZT7-3XFY-YIAV-7HQZ-PYIE-I ^
    SARG-XNFB-U2C2-DTG3-AG5X-6ZT6-NB3T-A
<rsp>FONQ-44SZ-FPSK-PIRE-J646-OCG4-ZY
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
<rsp>JLT4-IF7N-4V5H-4CWR-6KDH-AJYV-6I
MCAD-QFVM-2URA-M4FJ-7RMQ-PMLH-QQT3-HHTF-F5ZE-UYX3-6VLN-CTJS-TXFU
SAYG-OX27-TEAL-PGQY-OJPG-IT6M-UIBE-U
SAYZ-SFPG-JWIW-RTPT-FNXC-PZWQ-IWD2-O
SAZO-AC2Y-GWP7-SFQO-GYAT-2S33-CGTA-S
SAZT-YP5V-KEWG-Q4TJ-SIL2-I7ON-AZOT-2
SA2K-3MX5-UA3L-NYYF-H6YV-27OG-EOW2-S
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share FONQ-44SZ-FPSK-PIRE-J646-OCG4-ZY
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

