
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
ND6K-4V5M-WMTG-FVAL-72XE-ZPUK-F23A
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NAP2-44AE-Z6MQ-Z3IN-BWO3-LWRY-FTN2-3GW2-ZCTS-IT46-LWEA-DX5J-N3TC-K
````

Secrets are generated in the same way using the command `key secret` :


````
>key secret
EDGJ-IBRS-MVP2-ZMDS-MPLP-4A4B-3HAA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EDLB-4WCR-GGLJ-KZFU-3PUO-BTZ4-7BOP-KFXT-CPEF-WC6G-MY36-WXCX-D5DO-K
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
ED5O-JDQF-EVYM-6E7A-PJM7-VK2B-LFKT-56
MCZF-2HFB-TGTZ-U4H6-U4OL-6D2E-BO2G-T4MR-EZFU-GUFL-RK2H-BFWG-BBCF-7K6U
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
ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ
MCOM-OP2I-R2WY-DMO2-QT7F-3E3H-PAMX-ORCH-2COT-VHYM-AW7E-BDSE-NOPA
SAQN-2OD4-7X2C-P7NK-OEMF-CPCZ-4UPB-U
SAQQ-6CTJ-HVF6-MUFC-ZN2S-57NW-XF2I-4
SARE-BXCV-PSR2-JI43-EXJA-ZPYT-RXFT-K
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
    "Key": "ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ",
    "Identifier": "MCOM-OP2I-R2WY-DMO2-QT7F-3E3H-PAMX-ORCH-2COT-VHYM-AW7E-BDSE-NOPA",
    "Shares": ["SAQN-2OD4-7X2C-P7NK-OEMF-CPCZ-4UPB-U",
      "SAQQ-6CTJ-HVF6-MUFC-ZN2S-57NW-XF2I-4",
      "SARE-BXCV-PSR2-JI43-EXJA-ZPYT-RXFT-K"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQN-2OD4-7X2C-P7NK-OEMF-CPCZ-4UPB-U SARE-BXCV-PSR2-JI43-EXJA-ZPYT-RXFT-K
ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EALR-VJWR-57EW-E6A7-V7XW-UZXN-3TVA
MBVB-65YZ-HYKQ-V7HO-6X47-A3LA-C5GR-WYJV-X4FU-56T4-XJP6-C3SO-RHPA
SAYA-6D32-NMZK-6UUS-PQIH-Z2CI-REPQ-O
SAYW-B7HJ-KTC6-PE24-L5CS-KLTU-3B3V-K
SAZA-ZYXT-R2UX-EJGV-ZFG6-QPHL-3PS2-C
SAZR-FQMZ-DDOU-6BX6-XIVM-ME5N-SNVB-4
SA2H-FGGZ-6NQX-4OOX-GHN3-5MVZ-74CM-Y
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ
ECVW-NEF6-TRU2-VMQW-XNZX-V7IQ-Y5ZQ
MCOM-OP2I-R2WY-DMO2-QT7F-3E3H-PAMX-ORCH-2COT-VHYM-AW7E-BDSE-NOPA
SAQM-U2JE-R3ZO-UGL4-TSV2-S3GP-5LV5-C
SAQ6-S25Y-L5EW-VCCH-EKN5-6XVC-YUIC-6
SARA-Q3SM-F6P6-V5YR-VCGB-KUDV-T42F-U
````

