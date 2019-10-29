
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
ND2P-DLUX-XDDF-PJT7-EXCF-53MH-XVQA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
Alice> key nonce /bits=256
NDAS-ITXL-6ML4-6E4K-HTTG-IUUW-P4UA-WTX3-NDFJ-JY5J-KN2A-S6AW-PMJL-O
````

Secrets are generated in the same way using the command `key secret`:


````
Alice> key secret
EB3H-ZVVR-OK27-PKF5-R7CD-CIHT-YGBQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
Alice> key secret /bits=256
EAOS-QRCX-HV6R-2PQN-FYV5-CSUO-MWIR-ZXMU-KULA-ZCW5-WWT7-OACV-NBUW-W
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
ECJR-7UEO-WOPB-2RVE-GN2T-CNOU-PHTL-OR
MB5O-NJ2N-ISQD-KUAZ-KH5B-6LZR-QIWL-SQXD-BBOD-PUNQ-P7EQ-WIHP-5G2E-ATKF
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
EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA
MB3Z-TBR3-C5ZH-FUGN-DZJ5-IPQF-7UJH-WJD7-R4A6-DBY5-MM6Q-FONE-Q7WQ
SAQI-USPH-MIWN-NXQV-M3QE-XCOO-DGCI-M
SAQQ-UYYG-2HUM-3TEQ-VW3T-4DR6-TTBH-C
SARI-U7BG-IGSM-JOYL-6SHD-BEVP-EAAI-6
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
    "Key": "EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA",
    "Identifier": "MB3Z-TBR3-C5ZH-FUGN-DZJ5-IPQF-7UJH-WJD7-R4A6-DBY5-MM6Q-FONE-Q7WQ",
    "Shares": ["SAQI-USPH-MIWN-NXQV-M3QE-XCOO-DGCI-M",
      "SAQQ-UYYG-2HUM-3TEQ-VW3T-4DR6-TTBH-C",
      "SARI-U7BG-IGSM-JOYL-6SHD-BEVP-EAAI-6"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
Alice> key recover SAQI-USPH-MIWN-NXQV-M3QE-XCOO-DGCI-M SARI-U7BG-IGSM-JOYL-6SHD-BEVP-EAAI-6
EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
Alice> key share /quorum=3 /shares=5
EA4U-2GN2-NK2Q-5SR7-ZQBT-USOO-DUGA
MAMV-SSQB-5CGK-36DI-JS6O-O5VB-W2VY-WNUS-WGIB-ZR5F-HFU2-3KTY-ZK5Q
SAYH-HUAR-SJA5-VPG4-CHUZ-6EAI-5AHQ-Y
SAYY-UXKY-3BXG-L334-3C7L-RIFQ-GX3C-I
SAZH-Z5HP-RTYF-NJVM-SRFU-73B7-W7JF-I
SAZU-XFWV-V7D2-ZYTL-ISHW-J4VX-NWRZ-Y
SA2P-MQYL-ID2G-RIVY-5GFP-PNAX-K5VC-6
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
Alice> key share EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA
EAFD-BR7S-ODP6-7GRA-BFMQ-KXMW-IZUA
MB3Z-TBR3-C5ZH-FUGN-DZJ5-IPQF-7UJH-WJD7-R4A6-DBY5-MM6Q-FONE-Q7WQ
SAQO-P67K-44FY-7YAW-4U6P-QJCC-RVCL-O
SAQ4-LRYN-3OTD-7UET-VJYJ-OQZH-QRBN-G
SARK-HERQ-2BAO-7QIQ-N6SD-MYQM-PNAO-6
````

