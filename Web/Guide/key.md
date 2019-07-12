
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
NBHJ-BVOE-BXTD-EPMW-QLI6-JSD6-2VHQ
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
Alice> key nonce /bits=256
NCCI-SBQM-GVKY-2DU4-XPNF-LG4G-UVH5-F6PK-K37A-NY2F-WNJ4-QEFT-KAAI-W
````

Secrets are generated in the same way using the command `key secret`:


````
Alice> key secret
EAQJ-2C3A-3YRU-GXVH-XXD5-BZR2-ET5A
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
Alice> key secret /bits=256
EB3H-E3GF-MQSJ-SGCK-OMJR-6LEK-AFLH-J5YZ-EZB7-IX3K-HA6B-DRAN-2KNY-E
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
EDXG-XCNG-KBXW-MA5P-I6UY-ABUH-FDZB-DN
MC3S-YICX-I57H-5AGR-6MEZ-BDP2-NSSI-2QBK-MFI4-EOA3-NCQI-Z4X4-IOQV-VV6P
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
EBFX-GMHU-BVBM-4GEJ-4T4I-K2BW-ZKOA
MDCU-NS3Z-PDAS-GGLE-A5AC-5GK3-LT3W-LFWW-S5KB-5TYF-CNDY-RTAT-ZSOA
SAQD-PALP-JFJA-GY4U-KWJK-UXH6-ZF3H-W
SAQS-HD5N-T2LM-H6IQ-EFAF-YNEV-LQRF-U
SARA-7HPL-6PNY-JDUL-5TXA-4DBL-53HD-S
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
    "Key": "EBFX-GMHU-BVBM-4GEJ-4T4I-K2BW-ZKOA",
    "Identifier": "MDCU-NS3Z-PDAS-GGLE-A5AC-5GK3-LT3W-LFWW-S5KB-5TYF-CNDY-RTAT-ZSOA",
    "Shares": ["SAQD-PALP-JFJA-GY4U-KWJK-UXH6-ZF3H-W",
      "SAQS-HD5N-T2LM-H6IQ-EFAF-YNEV-LQRF-U",
      "SARA-7HPL-6PNY-JDUL-5TXA-4DBL-53HD-S"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
Alice> key recover SAQD-PALP-JFJA-GY4U-KWJK-UXH6-ZF3H-W SARA-7HPL-6PNY-JDUL-5TXA-4DBL-53HD-S
EBFX-GMHU-BVBM-4GEJ-4T4I-K2BW-ZKOA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
Alice> key share /quorum=3 /shares=5
EDFI-QCIW-3WJO-XB5M-IXSO-OVUG-YO5A
MC52-C2BM-HWLE-ZWCN-XABF-ERCT-HCQR-5UC2-6N2J-XZXW-QVPK-VOCJ-5ASA
SAYK-NI2D-PESQ-RN7D-P4BG-NKMO-JZD4-E
SAY5-WWF4-6SWH-ZB22-UQGK-HNZC-G6ZB-S
SAZG-RKDV-RFZ6-4WPN-DNSJ-YEAS-IMBI-Y
SAZU-5ETN-G55V-4L42-4UFE-7NC6-OA4U-4
SA2I-2FVD-73BM-YCDE-AD63-5JAG-X5LF-6
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
Alice> key share EBFX-GMHU-BVBM-4GEJ-4T4I-K2BW-ZKOA
EBFX-GMHU-BVBM-4GEJ-4T4I-K2BW-ZKOA
MDCU-NS3Z-PDAS-GGLE-A5AC-5GK3-LT3W-LFWW-S5KB-5TYF-CNDY-RTAT-ZSOA
SAQN-FUIM-YWPJ-BEX7-DUV5-WSLC-HTP6-A
SAQV-ULXI-S4X5-4V7F-WBZL-4DK4-IL2P-C
SARO-DDGE-NDAS-YHGM-IO42-BUKW-JEFD-K
````

