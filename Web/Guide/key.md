
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
NA7S-6JYZ-2YEX-B5R3-GQEL-JM5A-VPPQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
Alice> key nonce /bits=256
NCPW-VACL-IX3R-EMSP-C7TO-7IF6-LCVF-S7AQ-4TG7-NRZP-PNUV-F6G5-PCIN-W
````

Secrets are generated in the same way using the command `key secret`:


````
Alice> key secret
EBOB-OH23-N7L4-4DZK-5N4X-KAUQ-4WKQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
Alice> key secret /bits=256
EBIL-7TYN-OAKF-JLQS-LMNA-G3EP-7H67-XJ6U-LPVU-RZHS-UFBK-XXPY-KMBE-Y
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
EDYW-QQL3-FASO-RZ4R-ZE2D-L3FC-T5PK-FR
MAA7-WZKN-TDYK-3OYX-LXHT-7LF2-7GD2-5WGL-4JV6-XQMN-Y4OR-LIMP-OYL3-P24E
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
ECP4-ID66-OU4Y-DQ56-MLXK-SCB6-GA5A
MCQL-ZVUT-J4ZT-EFPN-ASKA-ASNB-VCFC-5TCN-IUGT-JYVX-S7RX-VSG2-J6KQ
SAQJ-WF3H-G75I-VEYH-PVIZ-DTQZ-7AAK-Q
SAQZ-M2V6-SF75-XJCL-HRAD-J4ZL-WHIR-M
SARJ-DPQV-5MCS-ZNMO-7MXN-QGB5-NOQY-I
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
    "Key": "ECP4-ID66-OU4Y-DQ56-MLXK-SCB6-GA5A",
    "Identifier": "MCQL-ZVUT-J4ZT-EFPN-ASKA-ASNB-VCFC-5TCN-IUGT-JYVX-S7RX-VSG2-J6KQ",
    "Shares": ["SAQJ-WF3H-G75I-VEYH-PVIZ-DTQZ-7AAK-Q",
      "SAQZ-M2V6-SF75-XJCL-HRAD-J4ZL-WHIR-M",
      "SARJ-DPQV-5MCS-ZNMO-7MXN-QGB5-NOQY-I"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
Alice> key recover SAQJ-WF3H-G75I-VEYH-PVIZ-DTQZ-7AAK-Q SARJ-DPQV-5MCS-ZNMO-7MXN-QGB5-NOQY-I
ECP4-ID66-OU4Y-DQ56-MLXK-SCB6-GA5A
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
Alice> key share /quorum=3 /shares=5
EBWL-ULYK-EDOV-WHW6-QEWQ-NNHN-5ZDA
MDHZ-VV6D-ANTK-TEGZ-SIAB-E3DR-Q3VT-YAF4-YDCH-XNFI-3AEH-5DWI-JMTQ
SAYC-V6DU-B2LQ-Y2IX-45BE-3COH-QB2V-4
SAYW-OLZB-KCAP-YOHV-WQ4Q-XEJF-4K5A-S
SAZC-CXRW-Z7PK-ZSVY-IVSW-OHGQ-CS6B-I
SAZV-TBNU-RSYB-4HS7-TLDW-ALGG-CZ53-E
SA2A-7JM2-Q32V-AM7L-WRPP-NQIH-474L-A
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
Alice> key share ECP4-ID66-OU4Y-DQ56-MLXK-SCB6-GA5A
ECP4-ID66-OU4Y-DQ56-MLXK-SCB6-GA5A
MCQL-ZVUT-J4ZT-EFPN-ASKA-ASNB-VCFC-5TCN-IUGT-JYVX-S7RX-VSG2-J6KQ
SAQC-HHEF-YM3K-7DNT-AIV7-F4UU-A6A3-M
SAQ2-O5H3-U74C-LGNC-IX2P-OPA7-2DJW-K
SARC-WTLR-RS4Z-XJMR-RG67-XBNL-TISO-C
````

