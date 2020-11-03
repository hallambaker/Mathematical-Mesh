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
<rsp>NCEQ-2QSZ-RMHP-EJHN-74RH-4NUO-X2TQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>ND3H-6FGN-4GHV-O347-AD7E-NZHL-2DXA-OZJB-KDTY-CX7I-5KJ2-YZWG-6OYR-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ECIN-AKQO-6B4F-OC3X-ILJE-DLJH-IQUA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ECGD-2EHA-BU6M-BPXP-4DKR-SQR4-HPNR-6IKI-EQMS-G6F6-O6BU-BZR5-RKQV-O
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
<rsp>EDJ5-BDKR-CZWX-AGIO-F4IT-I5S7-ZIA5-ZN
MBMF-WVSO-55JG-MAKS-SP44-MD4X-PRXA-FG64-2W5F-YRP4-3S4I-ZDFG-DBOJ-RJDV

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
<rsp>NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ
MAFU-GZGM-SYNI-WX6R-SSQP-JBWK-TXGI-HFUZ-NLXK-OJ6P-KXUD-XHXV-D7P7
SAQD-VOMQ-BKN7-ZB46-7S5J-ULEQ-KLGA-G
SAQQ-QLD7-QGME-ZC33-FPXG-LHE5-YDTZ-E
SARN-LH3O-7CKJ-ZD2X-LMRD-CDFL-F4BV-I
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
    "Key": "NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ",
    "Identifier": "MAFU-GZGM-SYNI-WX6R-SSQP-JBWK-TXGI-HFUZ-NLXK-OJ6P-KXUD-XHXV-D7P7",
    "Shares": ["SAQD-VOMQ-BKN7-ZB46-7S5J-ULEQ-KLGA-G",
      "SAQQ-QLD7-QGME-ZC33-FPXG-LHE5-YDTZ-E",
      "SARN-LH3O-7CKJ-ZD2X-LMRD-CDFL-F4BV-I"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQD-VOMQ-BKN7-ZB46-7S5J-ULEQ-KLGA-G ^
    SARN-LH3O-7CKJ-ZD2X-LMRD-CDFL-F4BV-I
<rsp>NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ
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
<rsp>SW76-MOMJ-XXYI-DT33-GI3U-7IH6-XY
MC5H-BHYK-NBDK-GBSC-GF5Y-XF6N-VNUS-OMP3-WFMB-74H5-EGUZ-EZZU-HMNY
SAYO-3JGW-LQFK-L7RZ-WXRS-27Y6-ZQER-S
SAY5-7NDA-XT5I-VKYD-XEAC-E36G-AYSH-O
SAZG-X3UF-LRMW-X5W7-3DJB-CCKF-J5IN-Q
SAZZ-EU2E-HITU-TYOO-CVMP-SS44-U6HG-6
SA2F-FYU5-KZSC-I26O-N2KN-WNWM-B3OQ-S
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share NVDK-BE47-VSB4-FTMG-Z26I-FZFQ-OQ
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

