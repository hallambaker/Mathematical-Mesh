
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
NDWN-5BEK-ENOK-AHBF-TC73-AJ55-52CA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
Alice> key nonce /bits=256
NAAK-OKKU-GPRS-SXLT-NOEW-XKPE-34A4-XLWQ-YGKU-WC63-3HZP-NDCI-5DUS-C
````

Secrets are generated in the same way using the command `key secret`:


````
Alice> key secret
ECJK-W3X3-3XAE-YK3H-Y4WO-OXHB-6P3Q
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
Alice> key secret /bits=256
EBWZ-4TLZ-RGFJ-WHWZ-POA7-JC4C-AVUN-G3HZ-LPGA-VOI3-CNZO-RY4J-OVBO-4
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
EBTR-ITUQ-M3HN-TRWL-VPJ5-G4ND-27HN-UT
MCCY-32DL-SQNL-46SP-J64G-2LV5-MOTF-R7FI-67EO-6FNO-ZBOX-B26K-6G7M-4Q2E
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
EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A
MDS2-IZBW-P5YC-HQKZ-3GHJ-ZEI3-6CKV-2M2A-O45X-7XLG-RIJP-637L-JSPQ
SAQF-LAQZ-7DMQ-VZ5L-EXQN-XTRC-ZVMR-Y
SAQZ-PPVK-2SWN-XAFC-TAZJ-6WNK-65IX-4
SARN-T6Z3-WCAK-YGM2-BKCG-FZJT-EFE6-A
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
    "Key": "EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A",
    "Identifier": "MDS2-IZBW-P5YC-HQKZ-3GHJ-ZEI3-6CKV-2M2A-O45X-7XLG-RIJP-637L-JSPQ",
    "Shares": ["SAQF-LAQZ-7DMQ-VZ5L-EXQN-XTRC-ZVMR-Y",
      "SAQZ-PPVK-2SWN-XAFC-TAZJ-6WNK-65IX-4",
      "SARN-T6Z3-WCAK-YGM2-BKCG-FZJT-EFE6-A"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
Alice> key recover SAQF-LAQZ-7DMQ-VZ5L-EXQN-XTRC-ZVMR-Y SARN-T6Z3-WCAK-YGM2-BKCG-FZJT-EFE6-A
EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
Alice> key share /quorum=3 /shares=5
EAMC-3QLP-IYSC-IZBH-EL6V-AOEM-SMBQ
MCYK-D2BL-533D-C74Z-NZQ4-5MXE-IWGA-W3U6-K3DE-NW3T-2QDZ-KP5X-TTQA
SAYC-SBHN-DYKF-25B6-43J6-NDI2-A63U-W
SAYW-AKB7-EAGU-KCXJ-YS7B-VOMX-74X5-O
SAZL-3F5X-OUYN-V2DE-YDQZ-TVNS-OL6K-O
SAZU-CU2W-DV7R-6DFP-3M7G-HYLJ-MMOY-Q
SA2O-WWY3-DD4B-C56L-CPKH-RXF4-Z6JO-A
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
Alice> key share EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A
EAJU-LCI5-AU5E-5M5T-R4ME-FGVD-MC5A
MDS2-IZBW-P5YC-HQKZ-3GHJ-ZEI3-6CKV-2M2A-O45X-7XLG-RIJP-637L-JSPQ
SAQE-IZLK-FOTX-45H4-C6OC-JY2I-5LT6-4
SAQX-LBKL-HJE4-FG2E-POUT-DA7X-GJXS-E
SARK-NJJM-JDWA-NQMM-363D-4JFF-PH3F-M
````

