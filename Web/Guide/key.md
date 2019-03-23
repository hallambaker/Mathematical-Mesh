
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
NCPE-S63N-WBCY-KPZ4-2XH4-O3FZ-B6VQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NCCO-O6IF-U2H3-V27R-AI5U-4KSE-UYS6-XX5X-7AN5-BPVF-MZZB-BA3C-TZCE-E
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EB2G-YKSM-G36Z-HIQZ-VCYL-5QOZ-V4KA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
ECZM-WSQA-U4I7-UKO6-WTHU-JVBE-3UVV-KQ5H-YK3X-LTFH-HHP6-CKLF-SKSG-M
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
EBDE-Q3IW-5YW4-K6LV-DUWJ-YZUY-KFZG-OV
MC2T-H75H-WRK4-XMAG-DSRO-X7QQ-SXKY-WXN2-KVM7-2RFJ-SV3S-Q5DH-Y5O7-7COT
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
ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q
MA73-R3AD-MDMW-32FB-MM2W-QGFT-S252-XNB3-7GTL-4ZCD-JMYA-WIFB-5SHA
SAQC-ODBR-CQFZ-D47W-7SPZ-IQUD-S43N-U
SAQ3-NXE4-TARW-OA6T-4DFQ-EJWX-RWAG-Y
SARE-NLII-DQ5T-YE5Q-YT3H-ACZL-QPE4-W
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
    "Key": "ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q",
    "Identifier": "MA73-R3AD-MDMW-32FB-MM2W-QGFT-S252-XNB3-7GTL-4ZCD-JMYA-WIFB-5SHA",
    "Shares": ["SAQC-ODBR-CQFZ-D47W-7SPZ-IQUD-S43N-U",
      "SAQ3-NXE4-TARW-OA6T-4DFQ-EJWX-RWAG-Y",
      "SARE-NLII-DQ5T-YE5Q-YT3H-ACZL-QPE4-W"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQC-ODBR-CQFZ-D47W-7SPZ-IQUD-S43N-U SARE-NLII-DQ5T-YE5Q-YT3H-ACZL-QPE4-W
ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EAGB-Y7CT-UNZZ-NDF2-6SWC-RHUX-AUPQ
MC6D-YFBK-NLFJ-VFHW-ZKDB-CQOB-4NOB-6VCA-4JIS-X6O7-BL7S-LIKK-2CCQ
SAYB-3DVZ-HHNH-FBNZ-EB47-UCRB-HWXM-O
SAY7-RJ73-OR23-TLHH-EMOJ-2TN5-J7IM-E
SAZJ-22CD-AN2U-SDAW-YLOJ-L43S-ZVVK-U
SAZQ-XT4P-43MS-BI2H-7646-H62B-WZ6L-E
SA2E-HXPC-D2QU-A4T2-3G2I-OZJK-BMDQ-2
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q
ECLT-XRMP-6O6O-IGQY-OQTF-4L5A-5V5Q
MA73-R3AD-MDMW-32FB-MM2W-QGFT-S252-XNB3-7GTL-4ZCD-JMYA-WIFB-5SHA
SAQO-JXWO-Q4KJ-4G6J-ZIKA-DWKO-2RJ7-K
SAQT-FAOX-PY2X-6U3Z-POZ5-2VDO-A65D-Y
SARI-AJHA-OVLG-BCZJ-FVJ3-RT4N-HMQL-M
````

