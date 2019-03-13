
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
NDVV-H3OU-CNTV-RZ5H-DJSD-WCNE-JX5A
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NAY3-TSRS-ZYNH-PWJ7-LKEL-GB54-JMZZ-FR75-T3OD-7LYJ-DWEP-OKPS-XC4L-O
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EBRS-7MKG-URPT-SJZR-SPGQ-7GR4-LPRA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EBUP-RAM7-FLT5-LLDK-DGKI-GLU6-C5QS-32UO-MSPH-DONE-Q6XW-K6C3-U2Y5-E
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
EA3B-MS25-2CW3-3E5F-KHDF-H6BO-VCQR-V4
MANC-TBPU-MWAT-RZ3H-WHBW-FDX2-H2PZ-UU4K-ZQLZ-YE24-SSYH-YQLM-Z7O6-TLAC
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
EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A
MBYF-UEMN-W5IP-CNTW-6LV5-EWN3-S7SO-56BQ-W6P5-2JFW-BQZF-PY2J-BQDA
SAQH-AHY6-QXGX-4HFQ-WZJY-QMX2-MX6F-C
SAQ4-6O5O-YNJ4-HNQV-GEZG-MQU7-5EKK-I
SARC-4WB7-ADNA-ST3Z-VQIU-IUSF-NQWM-I
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
    "Key": "EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A",
    "Identifier": "MBYF-UEMN-W5IP-CNTW-6LV5-EWN3-S7SO-56BQ-W6P5-2JFW-BQZF-PY2J-BQDA",
    "Shares": ["SAQH-AHY6-QXGX-4HFQ-WZJY-QMX2-MX6F-C",
      "SAQ4-6O5O-YNJ4-HNQV-GEZG-MQU7-5EKK-I",
      "SARC-4WB7-ADNA-ST3Z-VQIU-IUSF-NQWM-I"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQH-AHY6-QXGX-4HFQ-WZJY-QMX2-MX6F-C SARC-4WB7-ADNA-ST3Z-VQIU-IUSF-NQWM-I
EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EAMA-AC3F-J4YK-VCKH-F43I-SUOO-QVTQ
MCQK-BGNZ-2LKE-3XXP-K77X-66RC-U7OJ-RCL5-62RE-OOCO-BGEJ-2LPK-BV5Q
SAYD-YFIO-6PAX-Z45V-Z4YQ-I6OW-JIBH-U
SAY5-V63P-4AQM-7IU6-AF7K-7YUH-THC2-A
SAZP-JMZO-FJWS-RN2B-3YMD-RQ3F-XXHK-M
SAZY-SPCJ-2KTI-QMNB-MT6Z-6HDQ-WYOY-Y
SA2J-RFWC-3DGO-4EN4-SYXO-F3NI-QKZI-K
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A
EAIQ-FDSI-I44I-GTB3-OSVC-GVHC-4P7A
MBYF-UEMN-W5IP-CNTW-6LV5-EWN3-S7SO-56BQ-W6P5-2JFW-BQZF-PY2J-BQDA
SAQO-LT2P-XQ47-MEE6-YBA2-G7C2-SSSA-A
SAQ3-VHAR-GAWL-HHPR-IUHJ-ZVLA-IZR4-6
SARI-62GS-UQPX-CK2D-ZHNZ-MLTF-7ARZ-4
````

