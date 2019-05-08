
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
NB53-JR66-6S3H-BUAQ-VILK-BZEJ-5NZQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NARE-B5KK-ISA6-2DC2-C2FP-5LZT-Q57Z-ECF2-727W-UIEA-GZU7-JIKJ-P6GI-O
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EANA-5VUF-D5DS-WE7H-SDJZ-RVYK-A7VQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDCM-ICCY-GVAL-JKPC-HHVV-O72I-NUMJ-CCAA-IMFI-ZTSJ-5V42-XVEX-2KAS-A
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
ECLU-XHSG-53QK-ULTJ-TR2G-7GRU-4PKF-WU
MAXU-G4VT-U553-3EWV-53EI-RAR6-EVB2-U5E2-XVDV-3FVW-O6UB-IFNG-YASE-74YZ
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
ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA
MCGO-YNKF-WODB-LEQN-YK6L-UHIO-45K4-VIAI-2HJL-TQE6-F6VZ-Q5C7-Q65Q
SAQN-22T7-IK4J-OL22-HNOA-KM4Q-36DF-Y
SAQT-G6IL-ITYH-XLAM-F3CI-GLZU-Q5SW-K
SARI-TB4X-I4UG-AKF6-EIWQ-CKWY-F5CK-C
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
    "Key": "ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA",
    "Identifier": "MCGO-YNKF-WODB-LEQN-YK6L-UHIO-45K4-VIAI-2HJL-TQE6-F6VZ-Q5C7-Q65Q",
    "Shares": ["SAQN-22T7-IK4J-OL22-HNOA-KM4Q-36DF-Y",
      "SAQT-G6IL-ITYH-XLAM-F3CI-GLZU-Q5SW-K",
      "SARI-TB4X-I4UG-AKF6-EIWQ-CKWY-F5CK-C"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQN-22T7-IK4J-OL22-HNOA-KM4Q-36DF-Y SARI-TB4X-I4UG-AKF6-EIWQ-CKWY-F5CK-C
ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EAJE-JPFV-3WLP-OXJ5-WFAU-RVXW-4M7Q
MDXJ-2IO4-MQCC-YYX7-3XAV-7PT3-Y2S6-DCXU-I6QT-YX7G-5XLV-Y3XW-VKYA
SAYK-7OS5-TZEH-GQYW-KRKH-4GSH-7TAV-W
SAY6-L2BO-RFPE-GNLE-BKZD-MSTA-3TWR-C
SAZL-JTRP-O4PQ-NTSG-MDFG-TWJB-S5TG-C
SAZR-Y3DA-M6FL-4DN5-K2OR-RRUK-FQWU-W
SA2B-ZQWB-LKQW-R46I-5QVE-GEU2-TNBA-E
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA
ECDV-X42A-QCZL-FKCH-6ODT-P3JX-U4QA
MCGO-YNKF-WODB-LEQN-YK6L-UHIO-45K4-VIAI-2HJL-TQE6-F6VZ-Q5C7-Q65Q
SAQJ-AQ6I-WJZ4-OUVW-MTZY-2TSL-WWB7-O
SAQZ-SK46-ERTN-X4WE-QHZZ-GZFK-GNQM-4
SARK-EE3T-SZM7-BEWS-T3ZZ-S6YI-WE62-K
````

