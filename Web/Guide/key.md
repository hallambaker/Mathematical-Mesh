
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
NBTT-NB6C-DPXI-DDPX-X5T6-DBKA-J2GA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NBIM-TW5J-VED2-6K4K-O4U2-5KHC-LQV7-7WZI-AZNI-HQ2H-5SON-GWDO-2A5D-2
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EC2U-OMMU-OISE-BUYM-T3FX-CBPJ-A4KA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EAKV-RZ2A-FFFE-6ZXC-436W-4PRG-TFOU-Z6C6-KTLH-RAL5-ABKG-HTMR-VDDP-U
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
EDNK-UHTM-7YXL-WKPF-R37Z-3EB6-PGFC-Z5
MDMO-SGRK-NIFK-GC2Z-O2JL-T2YG-MMEG-JQSZ-BBHL-KSGA-ZQVQ-SDG2-7GE3-WWQY
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
EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ
MAI4-TOFA-PW2P-3LCR-UTBH-GPIG-6YIL-YBEI-GMF6-G4I6-PH5U-5TUN-XVUA
SAQL-FS4Y-TEJY-KCES-EAJ5-FWBX-FQ75-K
SAQ2-RI5B-EKGK-EPKX-RUEP-CZNC-DVXM-K
SARJ-465J-VQC3-64Q4-7H7A-74YN-B2O3-K
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
    "Key": "EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ",
    "Identifier": "MAI4-TOFA-PW2P-3LCR-UTBH-GPIG-6YIL-YBEI-GMF6-G4I6-PH5U-5TUN-XVUA",
    "Shares": ["SAQL-FS4Y-TEJY-KCES-EAJ5-FWBX-FQ75-K",
      "SAQ2-RI5B-EKGK-EPKX-RUEP-CZNC-DVXM-K",
      "SARJ-465J-VQC3-64Q4-7H7A-74YN-B2O3-K"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQL-FS4Y-TEJY-KCES-EAJ5-FWBX-FQ75-K SARJ-465J-VQC3-64Q4-7H7A-74YN-B2O3-K
EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EAKZ-OXBC-YHDB-ELCK-TOVI-YS5G-TGLQ
MAYD-LJTG-EGXP-TGLV-QE37-IMSP-JRNV-CT5E-IK6Y-6GNS-QN5Z-2B3C-ZRQA
SAYM-TP2J-GOG7-DBRO-VRLU-YX3A-WEIJ-Q
SAY5-AFPA-Y7ST-HYUP-DQDZ-AWPW-UPSV-G
SAZC-RGZC-37DY-2J2N-TGWH-M7AN-P4L4-Q
SAZ5-GTYP-PM2P-2VDK-EVC7-5RNF-IKUF-2
SA2N-AMNG-TIWY-I2PE-X3KC-SNV5-52LK-Y
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ
EC6P-HEAP-TJT5-HTFT-D22E-VTB3-CDSQ
MAI4-TOFA-PW2P-3LCR-UTBH-GPIG-6YIL-YBEI-GMF6-G4I6-PH5U-5TUN-XVUA
SAQG-6WCE-P5MG-4JPJ-UM2G-BJU7-L5JG-A
SAQS-DPHY-54LH-I6AG-SNFA-2ATS-QOJ5-W
SARN-IINN-L3KH-VSRD-QNP3-SXSF-U7KY-S
````

