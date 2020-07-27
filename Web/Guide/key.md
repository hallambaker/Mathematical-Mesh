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
<rsp>NBCE-RT2L-XDDT-LW2I-4CKE-46XU-LC7Q
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NAV5-BQSI-FXKU-ULXW-65X3-2YEY-B6CW-4YSH-25LF-MCRX-XIXH-X27D-QKXG-C
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EBXH-Q2QX-UQZV-JY3B-4KBS-DJH3-IZ6Q
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ECVV-GJWN-O6FS-MTA7-NF3V-55XO-A5FC-XKX6-AG7U-3BZQ-YSTL-FB2T-V5H7-E
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
<rsp>ECZT-ZW7N-2SIH-YCHX-DIJR-33H2-TKJ4-JA
MCAO-HLRT-WAWB-HQKY-RU7S-HNHC-INQT-Z2Y3-WAV4-33FG-MW2U-YU35-VPFR-AGTZ
</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
<div="terminal">
<cmd>Alice> dare earl TestFile1.txt example.net
<rsp>ERROR - Unspecified error
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
<rsp>EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ
MC7J-KNZH-SD7Z-GJMU-IZAB-KLBI-USUB-GQEX-B4AA-MTTL-KMJN-LQXM-PFDE
SAQC-UDCJ-FGXA-XSML-WBOV-T2TB-U24G-C
SAQX-LVE5-3BLW-2VIS-UQ73-FPQL-F4X6-I
SARM-DHHS-Q4AM-5YEZ-TARA-XENU-W6TW-O
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
    "Key": "EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ",
    "Identifier": "MC7J-KNZH-SD7Z-GJMU-IZAB-KLBI-USUB-GQEX-B4AA-MTTL-KMJN-LQXM-PFDE",
    "Shares": ["SAQC-UDCJ-FGXA-XSML-WBOV-T2TB-U24G-C",
      "SAQX-LVE5-3BLW-2VIS-UQ73-FPQL-F4X6-I",
      "SARM-DHHS-Q4AM-5YEZ-TARA-XENU-W6TW-O"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQC-UDCJ-FGXA-XSML-WBOV-T2TB-U24G-C SARM-DHHS-Q4AM-5YEZ-TARA-XENU-W6TW-O
<rsp>EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ
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
<rsp>EBGG-ZJ6E-5ELT-AFKK-4MQL-4ZDO-WRKQ
MCVQ-6NNM-3P6H-CHVX-VTTJ-ROY4-OUDQ-4QJ4-M46L-AOPR-JXJN-UN2P-DAP4
SAYN-QSZJ-F5GN-43UU-RX6L-OA3L-VVEE-2
SAYW-IA3N-AO7B-VQAJ-RQY2-G3UN-T522-2
SAZO-7FLT-II6M-YJDU-IWA6-L76K-IU6N-W
SAZX-WAJ3-5LEP-FG6U-XHWX-5NZB-T2OX-C
SA2A-MRWG-7VRI-4JRK-5F2G-3FET-VOL2-E
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share EDPE-H5D3-ASVD-4BF4-PMAR-NOA6-IEIQ
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

