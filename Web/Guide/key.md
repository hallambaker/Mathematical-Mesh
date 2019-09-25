
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
NCDX-KQQP-IBID-6OXT-JP2M-NUVI-RS7Q
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
Alice> key nonce /bits=256
NDAG-THE2-WUXV-GIPH-ZYH6-FBVH-AX4I-QH73-RHAT-QL7Z-4RKS-LVD6-POOB-K
````

Secrets are generated in the same way using the command `key secret`:


````
Alice> key secret
EDFZ-FPB7-AKZZ-TMWV-LIUT-PCQV-T7JQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
Alice> key secret /bits=256
EB42-X7BQ-LXX7-WSY5-YIPI-DC6P-TJN3-YLP4-ZTZU-YA4C-J5TL-FDCO-JPZ5-S
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
EDDN-LZZQ-GXUU-GXCW-3EYU-2A47-H2TC-DJ
MDE7-EO26-OP66-VA6J-OQ2Q-3MNA-KQ6W-YEL4-AVQT-E7FP-TWQC-VL6P-FQPF-5HLC
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
EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA
MBK5-ITOH-Q7Z7-7JYT-O5QN-WOG2-JXJG-EWYP-OMBR-FYZP-7ZDP-SBTE-E6QA
SAQA-JM22-QDJJ-AXQA-57QW-LQRB-JF2C-K
SAQR-76BS-ZNRD-JNOH-YBMD-JP77-WKWV-2
SARD-WPIL-CXY5-SDMO-SDHQ-HPO6-DPTJ-K
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
    "Key": "EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA",
    "Identifier": "MBK5-ITOH-Q7Z7-7JYT-O5QN-WOG2-JXJG-EWYP-OMBR-FYZP-7ZDP-SBTE-E6QA",
    "Shares": ["SAQA-JM22-QDJJ-AXQA-57QW-LQRB-JF2C-K",
      "SAQR-76BS-ZNRD-JNOH-YBMD-JP77-WKWV-2",
      "SARD-WPIL-CXY5-SDMO-SDHQ-HPO6-DPTJ-K"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
Alice> key recover SAQA-JM22-QDJJ-AXQA-57QW-LQRB-JF2C-K SARD-WPIL-CXY5-SDMO-SDHQ-HPO6-DPTJ-K
EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
Alice> key share /quorum=3 /shares=5
EBEE-FB6Y-7N7Z-HKJ3-TVAQ-EEKJ-435A
MCCC-DPRG-ZCBC-7EAG-DBN4-O7XV-DBNC-FVGV-FFZT-GV22-UFZL-BCTZ-7PRA
SAYN-GTVH-ZEZK-BG5B-JYCM-KKEF-LDCB-O
SAYW-BNYR-G6LJ-6QET-VCMC-JAJJ-WZRG-G
SAZP-A66E-EQTX-XAUA-JNLV-6C76-MLBE-I
SAZY-FHGA-R3ST-KYLH-GZBH-JSID-LXRV-I
SA2B-OGQG-O7H4-ZXKI-NFMW-LOBY-U7C4-M
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
Alice> key share EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA
EDUW-5ARW-ILWA-MOQ7-NKLM-IQXA-HMQA
MBK5-ITOH-Q7Z7-7JYT-O5QN-WOG2-JXJG-EWYP-OMBR-FYZP-7ZDP-SBTE-E6QA
SAQM-YKKP-JVLV-ART3-CN4M-7HGA-H3IT-Q
SAQ2-5ZA4-MRV3-JBV4-A6DQ-Q5J5-TVTV-A
SARJ-DHXJ-POAB-RRX4-7OKU-CTN2-7P6W-Q
````

