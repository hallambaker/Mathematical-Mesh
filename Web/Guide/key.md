
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
NC54-REPP-6VJG-NA2A-WP3W-KFHK-SCQQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NBR4-MWFH-3PH4-6UJH-ZKJ6-AUSE-FZJS-PP2L-V2AC-VDBQ-DUPB-5VAA-HOEK-I
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
ECH6-HZZO-JFWQ-AI3B-QNT2-QC7S-U2JQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDWD-4E7J-4J4A-STXZ-7N3H-3P76-3V6L-MVFV-TQ2M-OTFA-ISDO-XSB7-LX6N-K
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
EDLD-QEEU-LBM7-TJRY-UNCS-RHKT-SVFC-NW
MCEU-JH72-TL55-FQUZ-O4NZ-NZPC-66SQ-5N6C-4KBU-SB4M-H62O-R2F6-QFEV-B4YC
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
EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ
MDKF-ECPI-S2AQ-N3ER-YENX-AD7O-KR7L-46PX-H5SC-TGCF-APSH-7W6W-FDJA
SAQD-XUZF-XMKG-CBR6-L7CI-H5FI-UTPP-6
SAQ2-VQNA-2TWV-FAGO-IZQQ-CB6O-ZMP5-E
SARB-TMA3-53DE-H626-FT6X-4GXU-6FQH-E
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
    "Key": "EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ",
    "Identifier": "MDKF-ECPI-S2AQ-N3ER-YENX-AD7O-KR7L-46PX-H5SC-TGCF-APSH-7W6W-FDJA",
    "Shares": ["SAQD-XUZF-XMKG-CBR6-L7CI-H5FI-UTPP-6",
      "SAQ2-VQNA-2TWV-FAGO-IZQQ-CB6O-ZMP5-E",
      "SARB-TMA3-53DE-H626-FT6X-4GXU-6FQH-E"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQD-XUZF-XMKG-CBR6-L7CI-H5FI-UTPP-6 SARB-TMA3-53DE-H626-FT6X-4GXU-6FQH-E
EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EDLU-DKP2-FWAF-MTZG-Q4YW-UI4V-2INA
MDNY-HWF5-VDE7-DBV7-R3LB-CAKD-WHN3-YLOS-B24J-SRUL-CMUL-HPKF-EQIA
SAYL-U4SP-ZICO-UZ2J-VMMF-UHU6-RSFW-Q
SAYY-WCM2-KIYJ-IHHJ-UYDN-S4KK-XNNB-W
SAZE-SB4J-SKYH-25ZP-C5JK-6YRI-EI7D-G
SAZ7-I3A5-ROCK-M5QZ-7355-X4JW-YE36-G
SA2I-2N2W-HSWQ-6GNK-LUBF-6HTW-TBDM-K
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ
EDGO-JKVB-HNXY-XLTZ-FADO-DAT6-TZPQ
MDKF-ECPI-S2AQ-N3ER-YENX-AD7O-KR7L-46PX-H5SC-TGCF-APSH-7W6W-FDJA
SAQE-NV4T-L7DO-XDHN-N4WM-NBPP-5V2W-6
SAQ4-BST4-DZJG-PDRM-MUYY-MKS5-LRGL-E
SARD-VPLE-3TO6-HD3L-LM3E-LTWK-ZMR4-E
````

