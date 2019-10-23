
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
NBC5-QH5Z-I4NE-GUWY-AOWW-AXXF-ATCQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
Alice> key nonce /bits=256
NARF-FZH3-GA3B-YSZL-D6ML-RU3Y-AJ55-YN3H-4SWY-QZQX-R637-JLZI-SWBW-U
````

Secrets are generated in the same way using the command `key secret`:


````
Alice> key secret
EDCA-JKMV-ZACY-BP5H-FIKE-BM2C-24SA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
Alice> key secret /bits=256
EBS7-3QMZ-6JF4-SWD3-RGBC-M6E6-5MCQ-Q5NK-FWOY-LAVV-O4G2-N3KZ-BNJM-U
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
EAGC-FIKB-DV2S-HJMK-6AB7-BSIC-BURY-SR
MBQQ-7A3R-Q2KF-KOEK-CZN5-SXMF-C6YE-N66E-4ICB-U4VC-2GJG-3XNS-GKXK-R5RM
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
EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ
MDLW-W6ZD-F23V-RQM4-AGOE-TXQE-5GTE-U5DP-QC6G-DESN-3Z63-ZUUD-3S6Q
SAQF-3YGW-V2N2-6CAJ-ISFG-2L5L-WN5D-6
SAQQ-EYUJ-2XAW-3ADY-53RK-GCX2-3HYO-2
SARK-NZB4-7TTS-X6HI-TE5N-RZSK-ABT4-4
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
    "Key": "EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ",
    "Identifier": "MDLW-W6ZD-F23V-RQM4-AGOE-TXQE-5GTE-U5DP-QC6G-DESN-3Z63-ZUUD-3S6Q",
    "Shares": ["SAQF-3YGW-V2N2-6CAJ-ISFG-2L5L-WN5D-6",
      "SAQQ-EYUJ-2XAW-3ADY-53RK-GCX2-3HYO-2",
      "SARK-NZB4-7TTS-X6HI-TE5N-RZSK-ABT4-4"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
Alice> key recover SAQF-3YGW-V2N2-6CAJ-ISFG-2L5L-WN5D-6 SARK-NZB4-7TTS-X6HI-TE5N-RZSK-ABT4-4
EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
Alice> key share /quorum=3 /shares=5
EA32-KPYZ-RD5D-6MIR-OCQB-5ESD-VW3A
MDMA-NGGM-OG3F-KTJE-F5KQ-SOII-T2C7-QDAG-KIJ7-L7TY-KTFV-2JWV-CUHA
SAYF-MNFL-6CLD-UEE2-SLGT-65SI-GWKK-E
SAYT-RTT3-GEEE-Z7DU-VOED-IYHW-JK5V-Y
SAZN-64VM-3LPT-GAV7-LOQX-5XU4-QMRB-O
SAZU-UIKA-5YNO-YI32-UMMR-53Z2-33EG-2
SA2H-RWRX-NK5X-QXVG-QHXR-JEWR-LWXM-I
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
Alice> key share EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ
EC4V-6I4H-OXYI-7GM2-GI3V-IXEN-AOIQ
MDLW-W6ZD-F23V-RQM4-AGOE-TXQE-5GTE-U5DP-QC6G-DESN-3Z63-ZUUD-3S6Q
SAQF-J6CY-7TMS-OITT-TIED-SL2A-PMX3-I
SAQ7-BEMO-OI6F-3NKN-THPD-WCRE-NFOA-U
SARI-YKWD-46PZ-ISBH-TG2D-ZZII-K6EC-2
````

