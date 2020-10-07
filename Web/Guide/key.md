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
<rsp>NBSW-6AVA-SHGU-KHOQ-YEEB-RBFE-JFBA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NANY-UJDS-IB4T-EX3M-CIZ4-WHIH-BDOP-EO5X-KI5G-FQYQ-FMIA-GFNO-YY53-S
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EBD7-YCVZ-NHXT-5LF7-KQXU-MK4I-LRQA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EDBI-2ZSJ-Z27I-M6DD-3OPS-C4IA-VLIH-ASAN-B5IH-NXVX-6L3A-IXY5-2NLH-2
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
<rsp>EACI-XSFI-YHE7-QNBC-YLUT-O6FS-BZSJ-TK
MBGP-XDQZ-WKIH-OJV6-6PER-HP4Q-3YKX-ZYEY-LI2O-NFBJ-Q37C-VEZR-HQBR-RYGZ
</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:

**Missing Example***

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


~~~~
<div="terminal">
<cmd>Alice> key share
<rsp>TSJD-3POT-AWSB-YOAX-MES7-FNHM-4M
MD75-RC34-OYKD-ECLM-75EZ-BGFL-O4WA-WMWH-MEDP-7JC4-QTL6-WIOC-TXCJ
SAQN-754U-LQ66-ICAW-WELA-PPC2-LEV2-6
SAQS-GXHK-7KUM-E3AR-FIKK-4UWB-7VVE-Q
SARG-NQSB-TEJ2-BUAL-UMJV-J2JJ-UGUR-I
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
    "Key": "TSJD-3POT-AWSB-YOAX-MES7-FNHM-4M",
    "Identifier": "MD75-RC34-OYKD-ECLM-75EZ-BGFL-O4WA-WMWH-MEDP-7JC4-QTL6-WIOC-TXCJ",
    "Shares": ["SAQN-754U-LQ66-ICAW-WELA-PPC2-LEV2-6",
      "SAQS-GXHK-7KUM-E3AR-FIKK-4UWB-7VVE-Q",
      "SARG-NQSB-TEJ2-BUAL-UMJV-J2JJ-UGUR-I"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQN-754U-LQ66-ICAW-WELA-PPC2-LEV2-6 SARG-NQSB-TEJ2-BUAL-UMJV-J2JJ-UGUR-I
<rsp>TSJD-3POT-AWSB-YOAX-MES7-FNHM-4M
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
<rsp>VLCN-AA2P-QDIG-NTSD-ERVU-UTWT-54
MDRV-Z6NK-FZUM-3TLB-7AYP-BPCR-N5FC-YK3R-O42N-RGLG-O36B-PWXC-EIH6
SAYH-MSPJ-ZR4B-NKYH-VQXU-T46F-7AAT-I
SAYR-L2KV-G6RJ-7KVT-5GCR-ZHA7-W7CX-K
SAZI-TIYS-ITHR-XT3L-QZCJ-YZCX-RYQO-K
SAZ5-C5ZA-6P6Y-WGJO-QJW4-STDN-PMJV-C
SA2O-2ZMB-IUW6-3B74-3YAK-GVDB-P2OL-S
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share TSJD-3POT-AWSB-YOAX-MES7-FNHM-4M
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

