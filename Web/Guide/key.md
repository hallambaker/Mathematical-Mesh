
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
ND7B-PRGA-MN6H-XYNF-USYJ-JJ6C-OFBA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NDI3-YLFR-YEBX-S52H-C6DT-QJFC-BPLU-R7O3-CRQH-TUKZ-GGGS-7EGX-XWQR-G
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EDY2-2SH6-YIBM-V3MC-APLM-JCEE-ZXTA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EAYA-LYDR-5DYD-DLMK-UCYO-QALY-WAPM-LELB-3TYB-6A3U-3N24-JRFC-MSO2-I
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
ECUM-5AI2-4W4R-EBEH-M5KZ-7IKK-K5P2-P2
MDGK-SWMJ-YU5J-GDUH-VHBJ-5SER-3QJ7-HIPN-C6R5-QKTQ-QLAD-PWU5-UKDC-OUAS
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
EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA
MBDX-WI4D-WU5K-6GKZ-JW6C-X5WU-RYJT-TOTR-WUXJ-HZNX-C6MX-H25P-JR4Q
SAQJ-263E-6R5S-JT2J-IG4T-DRFJ-5MEW-U
SAQT-EGNS-JSJA-Q3DS-7KWP-DEQ5-EMB3-2
SARM-NN77-USUO-YCM4-WOQL-CX4Q-LL7E-G
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
    "Key": "EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA",
    "Identifier": "MBDX-WI4D-WU5K-6GKZ-JW6C-X5WU-RYJT-TOTR-WUXJ-HZNX-C6MX-H25P-JR4Q",
    "Shares": ["SAQJ-263E-6R5S-JT2J-IG4T-DRFJ-5MEW-U",
      "SAQT-EGNS-JSJA-Q3DS-7KWP-DEQ5-EMB3-2",
      "SARM-NN77-USUO-YCM4-WOQL-CX4Q-LL7E-G"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQJ-263E-6R5S-JT2J-IG4T-DRFJ-5MEW-U SARM-NN77-USUO-YCM4-WOQL-CX4Q-LL7E-G
EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
ECBE-SYW7-FZDP-BAF6-WVPZ-JU4X-A5TA
MCG2-NXW4-E4PF-INKF-LQYT-4BER-GBJV-APF6-ILXZ-7BYK-IRM7-AT7A-3QBQ
SAYP-OCCL-J4BF-ZEGT-XBBC-4OI3-MVDV-M
SAYV-VEBH-4ROA-V7T5-RTHG-CLCT-IKBD-S
SAZK-ZYHY-T45V-EOL6-HRM7-Q3T3-F24H-K
SAZ6-36V5-P6QD-EQOV-Y3SP-H74T-FHU5-O
SA2B-3XLW-QWFK-WF4E-FRXV-HX43-GQLC-Y
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA
EAEN-2F44-MRAT-EH4I-YVY7-ONVT-B3SA
MBDX-WI4D-WU5K-6GKZ-JW6C-X5WU-RYJT-TOTR-WUXJ-HZNX-C6MX-H25P-JR4Q
SAQL-EYRN-OQ2E-ZLPY-AABZ-AVQT-2T7I-S
SAQV-XZ2D-JQCF-QKOQ-O5A2-5NHQ-63W7-W
SARA-K3CZ-EPKG-HJNI-5Z74-2E6O-DDOW-2
````

