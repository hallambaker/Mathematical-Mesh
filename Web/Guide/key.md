
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
NC3T-2Q7Y-3Z3L-GS2E-UDPJ-NKQQ-UUJQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NDQ4-AEDT-FSTF-J3KR-6PIW-VOZG-YB2S-22KQ-LHVH-46YV-C66S-BVSW-USWM-K
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EBJH-D4MW-HZWJ-7IG2-TXNT-JTPV-HKKA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
ECAM-ITM5-UCY2-FRR6-QBPD-3CDC-ULAK-B3G4-WIE7-GD3G-6N5Y-QVEI-S6PZ-I
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
ECUS-AJBQ-LD6O-6NQQ-Z3AY-FMJG-W2JO-UB
MDQY-GOFN-FPJR-SH7M-TPNW-DESW-E2EN-DW7C-37EI-UGMQ-WXTK-57NN-PLX6-J63V
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
EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA
MAOR-7JWV-MLVH-46ZZ-FUJ6-NJPF-RXPZ-G7Q2-YRNW-NXSC-E7IY-25F2-H2EQ
SAQJ-LZKP-CQ2F-66B5-5NVB-MKKJ-Q4R3-M
SAQ6-S3NR-K5SS-EAZ4-SSMP-P7KI-CLVS-U
SARD-Z5QT-TKK6-JDR3-HXD5-TUKG-T2ZG-W
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
    "Key": "EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA",
    "Identifier": "MAOR-7JWV-MLVH-46ZZ-FUJ6-NJPF-RXPZ-G7Q2-YRNW-NXSC-E7IY-25F2-H2EQ",
    "Shares": ["SAQJ-LZKP-CQ2F-66B5-5NVB-MKKJ-Q4R3-M",
      "SAQ6-S3NR-K5SS-EAZ4-SSMP-P7KI-CLVS-U",
      "SARD-Z5QT-TKK6-JDR3-HXD5-TUKG-T2ZG-W"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQJ-LZKP-CQ2F-66B5-5NVB-MKKJ-Q4R3-M SARD-Z5QT-TKK6-JDR3-HXD5-TUKG-T2ZG-W
EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EDQ7-TYSR-YDFV-PPAH-7DKC-B6CJ-22YA
MCGZ-RJLO-AYAY-IBDY-QWTB-6CF2-N6DZ-FPFH-3NLI-2OTF-DYZU-STLP-EQMQ
SAYB-UBHR-WTB6-DVS7-2UOZ-M3G7-57MQ-G
SAYZ-YMSX-2KSB-ULIT-PXMR-U45R-Z27Y-S
SAZG-RAQU-VNQX-IW6X-AIVW-ANLN-42E5-Y
SAZX-55BI-H357-AYVK-MIKG-PMQU-G44C-6
SA2N-7CES-RVZY-4QMN-TWKD-B2NE-YDFI-E
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA
EBBF-Z3GR-AOOO-2P2C-HM2F-KSX3-LRBA
MAOR-7JWV-MLVH-46ZZ-FUJ6-NJPF-RXPZ-G7Q2-YRNW-NXSC-E7IY-25F2-H2EQ
SAQH-I3EG-SWCJ-QMVA-YAQV-S4WX-T6I5-G
SAQ2-M7BA-LICZ-G6AC-HYDX-5EDE-IPDW-I
SARN-RC52-D2DI-5PLD-XPW2-HLPQ-476P-K
````

