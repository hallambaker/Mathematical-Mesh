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
<rsp>NBAV-LLAC-XS4U-RGGE-GCBX-2A4W-BAFA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NAIR-TWCH-TOCO-WG5L-G2WJ-Y2OY-T4WE-24XX-Y7TJ-3XX5-BFL2-P2J6-H25H-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ED4P-M4GZ-KASC-ANRZ-7API-LVX6-LBFA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EC4X-YT3I-3RC4-IOEO-VZUE-IFDZ-EMZA-PJMC-E6VS-W3QY-4ZEQ-MX3M-T57N-6
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
<rsp>EBIT-X2HF-JOD7-CGDL-IYO2-TMXT-7PS5-MF
MDLU-OIR4-DHR6-YEHI-LMIC-YVHL-BVO4-M75V-MDQ4-ORIT-TNGT-IA3N-BTJC-FIL7
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
<rsp>DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y
MDO7-KVIF-IIU3-IE6L-5UEN-576Z-WNK4-Z4LV-L4AG-I2UG-NOOW-RUCH-4QVI
SAQF-PXGN-MGQK-5422-O4V5-4KW4-7EAA-W
SAQZ-G73G-V4ZV-M6SZ-FJOV-T4HZ-5BED-Q
SARM-6IP7-7TC7-4AKX-3WHN-LNYW-26IG-K
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
    "Key": "DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y",
    "Identifier": "MDO7-KVIF-IIU3-IE6L-5UEN-576Z-WNK4-Z4LV-L4AG-I2UG-NOOW-RUCH-4QVI",
    "Shares": ["SAQF-PXGN-MGQK-5422-O4V5-4KW4-7EAA-W",
      "SAQZ-G73G-V4ZV-M6SZ-FJOV-T4HZ-5BED-Q",
      "SARM-6IP7-7TC7-4AKX-3WHN-LNYW-26IG-K"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQF-PXGN-MGQK-5422-O4V5-4KW4-7EAA-W SARM-6IP7-7TC7-4AKX-3WHN-LNYW-26IG-K
<rsp>DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y
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
<rsp>URIQ-GGHE-ESYQ-RF4Q-ZRKQ-4YMF-4M
MAAA-EJON-Q3IF-JCEY-M52H-UYQE-VRHV-IPYB-SK4L-VZLJ-QQDV-4YPU-FZFS
SAYI-B2KS-YKUS-VNEH-4TP7-HI66-CCTM-I
SAYQ-BQM6-IC6C-5DS3-XU7H-QYUA-XQZB-Q
SAZC-HWPF-SMOT-APUE-ECWF-VEHW-MQUB-E
SAZ6-UMRI-XHGC-7RIB-B4UZ-ULZ7-BCEL-E
SA2F-HSTH-WTES-2IOS-RC3D-OPK2-VFJZ-E
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share DQ5D-IFAO-A5WF-XQ72-MJSM-ACNX-3Y
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

