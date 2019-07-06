
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
NCJH-PVEY-VATR-4XMJ-QX4F-PDC5-OMYA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NAXZ-CKHU-XG7R-CODE-U5WP-MWGB-XCSE-NWUQ-AS6C-CCCK-QMJ3-BV7U-5JFO-S
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EDLC-OQAL-YXLU-RE3Q-WXEI-QD5W-FONA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EAEO-S5MM-GTMA-MILF-2RCL-QNS7-TA7O-T6BY-ZYVQ-ZAHR-BLQW-5DD3-QSY4-M
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
EAVA-MTJV-LBPT-WSNS-YANJ-5NGP-2N4D-AD
MDDQ-I3R3-EL6R-VRNM-PBVD-KOJZ-K5KF-NIFJ-2HGM-VCXP-OY5V-4B5F-MBHO-R66U
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
EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
MBBS-P6KK-N6TD-2SWK-X3MV-ELXY-D47A-G6WM-J442-CTLF-73WC-4UTP-EP6A
SAQF-JHAP-SSCL-3SJC-TUOS-X7JE-AORS-G
SAQX-D7JR-FZ3C-7GJR-3WRV-RT3E-MBJC-C
SARI-6XSS-ZBT2-C2KB-DYUY-LINE-XUAR-6
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
    "Key": "EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ",
    "Identifier": "MBBS-P6KK-N6TD-2SWK-X3MV-ELXY-D47A-G6WM-J442-CTLF-73WC-4UTP-EP6A",
    "Shares": ["SAQF-JHAP-SSCL-3SJC-TUOS-X7JE-AORS-G",
      "SAQX-D7JR-FZ3C-7GJR-3WRV-RT3E-MBJC-C",
      "SARI-6XSS-ZBT2-C2KB-DYUY-LINE-XUAR-6"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQF-JHAP-SSCL-3SJC-TUOS-X7JE-AORS-G SARI-6XSS-ZBT2-C2KB-DYUY-LINE-XUAR-6
EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EDU6-4LUK-SSCI-BORD-5WAJ-QUVS-DC5Q
MBPP-XAKX-IL5H-2ZKV-A575-ARQH-CPAE-37RM-6B63-WVRW-4IRH-RTPO-SPAA
SAYO-BHN6-UMBC-ZL3D-JJVK-NY46-XTJR-K
SAYS-NHRG-BZBI-Z2MK-BQBV-G4PM-574M-M
SAZL-X33E-ZRK2-KLZO-NC3Y-MQZ5-JOFD-I
SAZ2-BEL2-3U5X-LACQ-MCDT-6V4P-Z6DP-S
SA2N-JBDI-IDZ7-3XHP-6NZH-5LXE-PPXU-Q
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
EA3T-V3P2-SNF7-SE24-S37S-VY5G-6QSQ
MBBS-P6KK-N6TD-2SWK-X3MV-ELXY-D47A-G6WM-J442-CTLF-73WC-4UTP-EP6A
SAQF-5EIX-JRXN-FLH5-ATAS-6GPF-5DXH-6
SAQY-LZ2A-TZFF-SYHG-VTVV-6CHI-FLUN-S
SARK-2PLJ-6AS6-AFGQ-KUKY-557K-NTRT-G
````

