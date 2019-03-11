
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
NDC5-I222-S6AH-PIBF-YWOU-QZTI-FDGA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NB6U-3JSI-NQ2R-CKBC-YCBS-7XQM-ISV7-3GID-VJMG-X7K6-SSR2-JBO6-K6XV-I
````

Secrets are generated in the same way using the command `key secret` :


````
>key secret
ECFY-ODKK-OLSE-7HBB-CC2Z-YLOL-XU3A
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDOT-2Z6O-AAYF-TE5Q-334M-OEFK-BWFE-6VPE-XRDY-U3PN-MSH7-WZQJ-RSLQ-O
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
EBRQ-UE3Z-OPWO-ZLEN-67FF-HVGU-L6V5-L2
MAX5-PQI4-ADJG-CDKE-23ZQ-622L-VQUA-WESY-X6PK-DIBR-XP3G-UDKO-52FT-BDUK
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
ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA
MB5C-QW6E-JTAF-TQHQ-2URX-WJ6Z-TGVI-DHZM-SVIW-QKQB-DSWO-S3VR-2KTA
SAQK-V2IL-LS6Z-ZZSZ-6JIE-MS2B-6SQB-M
SAQV-OXGR-XFFF-BR57-6ICF-723U-4YWY-4
SARA-HUEY-CXLQ-JKJF-6G4H-TC5H-265Q-M
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
    "Key": "ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA",
    "Identifier": "MB5C-QW6E-JTAF-TQHQ-2URX-WJ6Z-TGVI-DHZM-SVIW-QKQB-DSWO-S3VR-2KTA",
    "Shares": ["SAQK-V2IL-LS6Z-ZZSZ-6JIE-MS2B-6SQB-M",
      "SAQV-OXGR-XFFF-BR57-6ICF-723U-4YWY-4",
      "SARA-HUEY-CXLQ-JKJF-6G4H-TC5H-265Q-M"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQK-V2IL-LS6Z-ZZSZ-6JIE-MS2B-6SQB-M SARA-HUEY-CXLQ-JKJF-6G4H-TC5H-265Q-M
ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EBGY-YRFR-APG6-OQ5D-DBZA-2P3F-ZAOA
MDFZ-X3GK-HVOX-N52R-ZEQZ-G3OB-WC6L-AR4M-J7PC-ENOF-246Q-ZCP5-M2PA
SAYJ-MWFB-OBLX-6RVO-6S5P-OCFF-X4D7-U
SAYZ-KGFM-KJOG-O2FI-T5AO-CZIB-V4UG-K
SAZE-TTDF-K4JI-MTJQ-UKVD-CIST-GYUV-2
SAZ3-I46M-PZ45-X5CG-733O-MQE2-KQFR-K
SA2N-KDXB-ZCJG-QXPL-WQTQ-BP6X-BDGV-U
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA
ED7H-KRIA-GDUQ-J47S-TQWK-WDYD-CKPA
MB5C-QW6E-JTAF-TQHQ-2URX-WJ6Z-TGVI-DHZM-SVIW-QKQB-DSWO-S3VR-2KTA
SAQI-XXSZ-LWM7-2UH2-R4ZL-JIRZ-3ZS7-W
SAQR-SR3N-XMBR-DHIB-FPET-ZGLE-XG4V-Q
SARK-NMEC-DBWC-L2IH-ZBP4-JEEP-SUGO-Q
````

