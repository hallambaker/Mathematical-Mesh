
# Using the Key Command Set

The Key command set contains commands that operate on cryptographic secrets and
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
NDTB-6CPK-QU33-TMTA-EE23-NUWL-JKAQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NBU3-EP3E-RPZJ-QOTL-JWDR-5X32-AAKO-3GFX-2ACH-GXWA-BSIX-MIJE-KRKD-4
````

Secrets are generated in the same way using the command `key secret` :


````
>key secret
EASL-RTEE-QFUF-SFDQ-IUOB-HOS3-5BEQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDTF-OY2T-D7FG-CIPX-XPZR-2FIH-U4C2-ADH3-SSGE-PCTD-622I-AUTK-H6NB-U
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
ECXR-S6AG-SVR5-BHKV-X4S5-5LNK-J6UQ-7N
MAS6-LOUP-LMEV-A7OE-F2J4-LOTT-K5SE-PF5Q-FME7-ALLB-YPTB-LO5I-RB66-B2VW
````

Alternatively, the `dare earl` command may be used to perform both operations:

**Missing Example***

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


````
>key share
ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA
MCYH-DIY6-7OZZ-36RK-NHEI-FH43-YORF-PYXX-KN75-SEIE-BFPZ-AMDO-ZEIQ
SAQI-LSPX-QRSK-3TZA-KJIS-DCQI-HMIA-C
SAQY-H4GX-53CO-ECCJ-5GE3-BU5B-VZYL-A
SARI-EF5Y-LESR-MQLT-QDBE-AHJ3-EHIV-6
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
    "Key": "ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA",
    "Identifier": "MCYH-DIY6-7OZZ-36RK-NHEI-FH43-YORF-PYXX-KN75-SEIE-BFPZ-AMDO-ZEIQ",
    "Shares": ["SAQI-LSPX-QRSK-3TZA-KJIS-DCQI-HMIA-C",
      "SAQY-H4GX-53CO-ECCJ-5GE3-BU5B-VZYL-A",
      "SARI-EF5Y-LESR-MQLT-QDBE-AHJ3-EHIV-6"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQI-LSPX-QRSK-3TZA-KJIS-DCQI-HMIA-C SARI-EF5Y-LESR-MQLT-QDBE-AHJ3-EHIV-6
ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EA4U-E4VV-EPF5-QEMP-ZVTS-3B4Z-NU2Q
MASL-WYQL-G3S3-THED-2F57-AAIS-IPCA-SNRE-P4YI-4M5U-5HHU-74R2-4CSQ
SAYB-M47F-VRDX-TQ2E-6FDA-VIDF-4NWU-U
SAYX-TFGV-DBR3-NWUF-AHIN-BRCJ-T2CF-W
SAZG-FJKA-7F4I-GHOR-YFW3-TGJS-ZKZD-K
SAZ5-DJJJ-J6C5-5DJL-GAOM-KHZB-M73Q-W
SA2M-NFEO-DKF4-SKER-JXO7-GVQV-OZJK-U
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA
ECD2-GFY2-AR4Z-L5V3-DCJE-A3WH-V5JA
MCYH-DIY6-7OZZ-36RK-NHEI-FH43-YORF-PYXX-KN75-SEIE-BFPZ-AMDO-ZEIQ
SAQH-CJOO-GDKR-CGTO-K7E6-GAQP-R7WG-2
SAQV-VKEF-I6S2-RHXF-6R5T-HQ5Q-LAUY-Q
SARE-IKZ4-LZ3E-AI25-SEWI-JBKR-EBTK-G
````

