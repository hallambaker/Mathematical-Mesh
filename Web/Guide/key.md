
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
>key nonce
NAQJ-65QK-DJG4-UVMU-FC3B-63FK-V2UA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NALF-C36R-7EK3-3T3G-WOBQ-2G3N-WB7I-FDFO-ZJUC-SE6M-IHKO-LY6P-VIXC-6
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
ED42-W24U-HIY4-IENG-I225-ENYA-H7VQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EAZ4-PWDN-FDIV-QN4H-HM3J-M5NP-WQGD-3S5H-NXKE-27OK-XD2I-25EX-RONX-Q
````

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using the `key earl` command to generate
a new secret/digest pair which are then used to process the content data:


````
>key earl
ED5J-KOG5-MFFA-Q6WP-SOE7-4DPM-NSQI-F2
MADM-FRBG-JSE3-KLNX-C3KK-TGNC-RDGO-3LUO-Z7YY-OOW6-HGA5-AQX3-XXEW-L4NR
````

Alternatively, the `dare earl` command may be used to perform both operations:


````
>dare earl TestFile1.txt
ERROR - The feature has not been implemented
````

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


````
>key share
EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA
MAIC-TKNE-ARN4-TV6W-LUKJ-3DGD-QLSU-KTSI-OVYC-MJ55-EQC6-RKAX-TCGQ
SAQK-T7ZZ-HFIS-2SO4-5GOB-I3MT-ALFK-O
SAQS-IROE-ZWVU-WYN6-MSJY-5V3Z-ZZSE-6
SARJ-5DCQ-MICW-S6M7-36FQ-SQLA-TH7C-U
````

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


````
>key share /json
{
  "ResultKey": {
    "Success": true,
    "Key": "EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA",
    "Identifier": "MAIC-TKNE-ARN4-TV6W-LUKJ-3DGD-QLSU-KTSI-OVYC-MJ55-EQC6-RKAX-TCGQ",
    "Shares": ["SAQK-T7ZZ-HFIS-2SO4-5GOB-I3MT-ALFK-O",
      "SAQS-IROE-ZWVU-WYN6-MSJY-5V3Z-ZZSE-6",
      "SARJ-5DCQ-MICW-S6M7-36FQ-SQLA-TH7C-U"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQK-T7ZZ-HFIS-2SO4-5GOB-I3MT-ALFK-O SARJ-5DCQ-MICW-S6M7-36FQ-SQLA-TH7C-U
EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EAJL-M6ND-XV73-C2NK-VIMD-7U5O-AEZA
MAIO-JB4Q-O2SK-DVUH-FVY6-PGSL-H6SZ-TP4Q-VBIH-5F75-GYPM-EOWL-JFZA
SAYH-IBUZ-N5HQ-H2TB-DDRN-56H4-HOQI-C
SAYT-M547-WKR7-W7ZV-HASV-AEVE-UBB5-6
SAZF-UCMM-NW6G-M37G-BBYW-XDGM-3PVX-6
SAZ5-5PC7-UCME-JPDT-RHDT-CZ3U-52LW-C
SA2M-JEAZ-JM3Z-MZG5-XQTK-DIU4-3BDV-E
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA
EAX3-RLNE-64HT-D63O-USNA-HLBX-GDGA
MAIC-TKNE-ARN4-TV6W-LUKJ-3DGD-QLSU-KTSI-OVYC-MJ55-EQC6-RKAX-TCGQ
SAQF-Z7L7-ACUG-3AXO-ZPCA-SW72-7W62-W
SAQY-UQSQ-LRM4-XU7C-FDRX-RNCJ-YRFI-U
SARL-PBZB-XAFS-UJGV-QYBO-QDEY-RLLW-S
````

