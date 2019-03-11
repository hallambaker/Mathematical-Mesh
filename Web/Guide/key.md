
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
NBFH-DXHR-M37G-SYJ6-WMM6-2422-MABQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NAIE-P575-EXBP-MC2Z-FUT2-HPWX-IM2G-CBAU-PC5W-DMBB-XIOW-5YNX-4XKO-M
````

Secrets are generated in the same way using the command `key secret` :


````
>key secret
EAQX-MQXL-N4BV-7JXT-MTVH-BU7D-6Y3A
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDE2-PZM2-PCB7-IHKM-K5HJ-DX44-U67U-W4C4-XKCV-N2AM-IKPM-GKKW-H6JB-G
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
EAGU-FEL7-UZR4-EHZC-YZD5-UBRU-P534-W2
MA6G-GHBR-RVPX-BZZY-XG2U-VVBD-YOGN-DRVF-SK4D-U7DT-XWHJ-T53G-ROWK-WSFG
````

Alternatively, the `dare earl` command may be used to perform both operations:

**Missing Example***

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


````
>key share
EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q
MDI4-BCEK-HIKC-LOAC-TWLP-27D3-XKCZ-CXOQ-4FRV-GBB3-GWGH-5NRF-NGTQ
SAQI-K3MQ-LLTF-7UOL-HZHV-Z245-BAWI-C
SAQ2-NOV6-P6RZ-CFK6-3O27-SA6C-APLI-W
SARM-QB7M-URQM-EWHS-PEOJ-KG7G-76AJ-K
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
    "Key": "EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q",
    "Identifier": "MDI4-BCEK-HIKC-LOAC-TWLP-27D3-XKCZ-CXOQ-4FRV-GBB3-GWGH-5NRF-NGTQ",
    "Shares": ["SAQI-K3MQ-LLTF-7UOL-HZHV-Z245-BAWI-C",
      "SAQ2-NOV6-P6RZ-CFK6-3O27-SA6C-APLI-W",
      "SARM-QB7M-URQM-EWHS-PEOJ-KG7G-76AJ-K"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQI-K3MQ-LLTF-7UOL-HZHV-Z245-BAWI-C SARM-QB7M-URQM-EWHS-PEOJ-KG7G-76AJ-K
EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EA3D-NPJE-T3MT-YZLY-KQOV-G4HY-PUGQ
MCYH-AGSR-YZCU-XMWP-2YHN-XW3Q-PL7L-FLV7-6WJY-SEMQ-KRBH-WMG3-QSPQ
SAYA-O4Y2-L4WB-RSGJ-WU2O-7JPI-QIPK-6
SAY2-3NZL-SENX-AH57-6NT4-5VNZ-TBZQ-6
SAZC-SAXQ-XJWN-6QKI-GLWL-VYXE-HN44-O
SAZX-SVTJ-3MQG-MLLC-OPB3-HTLI-NMZT-2
SA2J-5MMW-6M3A-JZAO-WXWL-TFKG-E6PT-4
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q
EBSC-AYRW-FEXI-4N5A-5DAN-G6AM-QJ3Q
MDI4-BCEK-HIKC-LOAC-TWLP-27D3-XKCZ-CXOQ-4FRV-GBB3-GWGH-5NRF-NGTQ
SAQN-2I2S-CBRK-EG5L-WKVZ-R3NQ-NCLK-U
SAQV-MJSB-5KOB-LKI7-YRXH-CB7I-YSVK-U
SARM-6KJR-YTKY-SNUT-2YYU-SIRB-EC7N-2
````

