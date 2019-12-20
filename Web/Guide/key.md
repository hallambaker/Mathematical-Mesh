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
<rsp>NDLN-IN7W-QXML-TV4Z-YKES-N27M-PEXQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NDY2-YTXB-YS6H-HVWC-Y2KI-67PW-VXG3-S4UE-CIDM-IE7T-3UVC-CWVJ-UYWC-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ECUX-XPSS-MXDD-P2XC-YCLC-F4ZM-57MQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ED6N-GRV4-X3T2-4TPA-OUAL-W5CT-LOEQ-PIVT-PGAI-KJT4-WKHG-ARLT-BTAT-S
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
<rsp>EBI2-R7IW-F5H6-JNNT-J5TA-AD3K-7T5K-LD
MBVM-OUFP-QBLY-ZRCM-DZXB-CKKM-IFQO-YXDC-3LD6-IXUY-VIY4-MNCR-46ZF-WYPG
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
<rsp>EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q
MCPR-KQBK-I23Y-ZZ3J-ITHZ-E5U2-FVBY-FUPM-BMQD-JM3K-YF6G-SOBF-UKYQ
SAQI-XFWD-ONIK-OLFU-C4FW-ENV7-WUTH-2
SAQ4-BX5L-Z7OV-TZV5-PPMJ-OO4C-SCD7-2
SARP-MKEU-FRVA-ZIGG-4CS4-YQCF-NPUX-2
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
    "Key": "EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q",
    "Identifier": "MCPR-KQBK-I23Y-ZZ3J-ITHZ-E5U2-FVBY-FUPM-BMQD-JM3K-YF6G-SOBF-UKYQ",
    "Shares": ["SAQI-XFWD-ONIK-OLFU-C4FW-ENV7-WUTH-2",
      "SAQ4-BX5L-Z7OV-TZV5-PPMJ-OO4C-SCD7-2",
      "SARP-MKEU-FRVA-ZIGG-4CS4-YQCF-NPUX-2"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQI-XFWD-ONIK-OLFU-C4FW-ENV7-WUTH-2 SARP-MKEU-FRVA-ZIGG-4CS4-YQCF-NPUX-2
<rsp>EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q
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
<rsp>ECVB-AC4O-2OQD-Q5JB-Y6AX-HG2E-UNSQ
MB53-2D6E-KT5Z-VHTK-WQF4-KIAX-IZ3G-UNJS-LAYQ-S27G-KION-ZSKU-IUJA
SAYL-6MDI-SZSB-W4AR-ICZ6-A4QL-VS4H-G
SAYS-FI4Z-YBJQ-NRCH-HWLP-2INM-JN6S-W
SAZN-I2M7-BSQG-ENIX-DBYN-PAT5-EDY7-G
SAZ5-JATY-PNGC-3QUA-2FAW-7FD6-FULG-K
SA2C-F3RG-BRLG-S3EE-NAEM-KV5P-N7VI-C
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q
<rsp>EBLE-3WYW-YP2H-FKVS-HYWT-D7GZ-YT6Q
MCPR-KQBK-I23Y-ZZ3J-ITHZ-E5U2-FVBY-FUPM-BMQD-JM3K-YF6G-SOBF-UKYQ
SAQG-5EP4-2O7L-JIYY-CIJJ-V24W-VFGO-S
SAQY-NVQ6-SC4X-JU4F-OHTQ-RJJQ-PDKN-K
SARJ-6GSA-JW2D-KA7S-2G5X-MXWK-JBOM-C
</div>
~~~~

