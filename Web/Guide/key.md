
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
NBN6-5NSK-RYHT-6P6W-WCMK-B55X-3MZA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NBRC-NHFF-Y6ZH-CXGJ-57GN-UFLY-76MY-HMLI-5RTW-U4L4-QDGO-RPEL-MQC2-4
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EAOX-BMFS-JQ6S-S72U-FHVS-C6KK-RFRA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDM2-2NNY-V47N-TUYI-A4JG-VOFU-5E7B-3PL3-HBDD-LSRU-YNC6-QBIK-YIRP-O
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
EDKZ-42TC-MG7R-RXWD-KIIM-EN22-5QZT-IK
MDJW-3WA2-RRXN-4FSD-HFMK-MPGW-PST7-2JZA-4352-6Y4Y-DZXW-J5YT-GZU3-AJ4N
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
EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA
MCZW-AMSV-6ERA-F27E-WE5M-VHDW-K3L4-AHAS-V6BV-RJQ6-IB2P-IREZ-BOVQ
SAQG-COEC-KBOQ-XXQO-45SF-GSBK-K64B-6
SAQ3-M2U6-YX5B-MWP5-I4M6-KVLE-P4DL-E
SARA-XHF3-HOLS-BVPL-U3HX-OYU6-UZKR-E
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
    "Key": "EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA",
    "Identifier": "MCZW-AMSV-6ERA-F27E-WE5M-VHDW-K3L4-AHAS-V6BV-RJQ6-IB2P-IREZ-BOVQ",
    "Shares": ["SAQG-COEC-KBOQ-XXQO-45SF-GSBK-K64B-6",
      "SAQ3-M2U6-YX5B-MWP5-I4M6-KVLE-P4DL-E",
      "SARA-XHF3-HOLS-BVPL-U3HX-OYU6-UZKR-E"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQG-COEC-KBOQ-XXQO-45SF-GSBK-K64B-6 SARA-XHF3-HOLS-BVPL-U3HX-OYU6-UZKR-E
EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EA5A-RMTC-MUIF-OMDC-WNPK-PZ7T-USVA
MDLV-RDRO-TSTI-FMLB-6ZB4-4E5S-IVXF-4247-6H5T-EG5O-U5QY-D3O7-WJ6Q
SAYJ-A462-3MK3-RYXW-F2S4-S2SF-E2XT-S
SAYY-GSTQ-WUJ3-S24E-KYKA-PPZ7-77HO-S
SAZB-FDDT-6BPR-D4G2-3D7B-TJWY-P4B3-U
SAZT-4OPE-RT34-E4XZ-W5R7-6IIO-URG5-6
SA2A-MUWC-RLO4-V4PA-6FC3-QLPC-N6WS-K
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA
EAGA-MZO2-YAAW-EIEH-V3AT-V4BQ-NGGA
MCZW-AMSV-6ERA-F27E-WE5M-VHDW-K3L4-AHAS-V6BV-RJQ6-IB2P-IREZ-BOVQ
SAQP-Z4TK-WGUB-2DEN-VEXK-X5QI-AL4R-K
SAQ6-3XTP-RCID-RNX2-ZKXJ-NMI7-2WEG-W
SARN-5STU-L54F-IYLH-5QXI-C3BX-VAL4-C
````

