
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
NDYC-SF76-OZQP-PWZK-BXXB-GJYL-WYEA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NBLM-DWVZ-OZUU-5BVI-4EHV-72ZX-SBL5-L4HE-2P6M-B2KS-2XEH-PSBR-SL56-Y
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EDHZ-V3LE-VB2G-O65X-ION6-LNKW-GYDA
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EA3Y-2KFX-Q4IZ-ORC7-BIQP-Q5WQ-HKQ4-ERZF-HTMU-CJYP-GMYG-CBW2-DITZ-M
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
EANE-4R6G-6FCC-YPX7-ML5L-N6IM-UNT5-37
MD57-QV2G-ODKI-5CZO-SJDH-STXX-RUU7-AYHR-I2WO-YKNM-LIXA-7CDE-NCCC-W4WL
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
EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q
MBMQ-3DNW-RVIM-IKFM-2YFL-4LBQ-SWWU-YWME-4PC7-EKJF-P4AE-7CAG-F5SQ
SAQG-H6VC-3SET-WVAT-FQDH-O3NO-RXNI-M
SAQV-ZL54-N5DQ-JD37-LILB-E7WC-G7CI-2
SARF-KZGW-AICM-3SXL-RAS2-3D6V-4GXJ-I
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
    "Key": "EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q",
    "Identifier": "MBMQ-3DNW-RVIM-IKFM-2YFL-4LBQ-SWWU-YWME-4PC7-EKJF-P4AE-7CAG-F5SQ",
    "Shares": ["SAQG-H6VC-3SET-WVAT-FQDH-O3NO-RXNI-M",
      "SAQV-ZL54-N5DQ-JD37-LILB-E7WC-G7CI-2",
      "SARF-KZGW-AICM-3SXL-RAS2-3D6V-4GXJ-I"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQG-H6VC-3SET-WVAT-FQDH-O3NO-RXNI-M SARF-KZGW-AICM-3SXL-RAS2-3D6V-4GXJ-I
EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
ED5G-YVUM-FBTW-IHTS-X3J4-YQN5-S4EA
MBOJ-52GD-HVRT-RCU6-LHEQ-7BES-SQT3-KFIQ-FC6W-NCPU-IKOZ-5URE-JDUA
SAYE-HCZT-LQHC-MQE6-KQCG-3Z7V-WDIO-6
SAYS-A3MW-GWNR-BIH7-4ROY-7PW4-ZPCJ-I
SAZJ-CE37-DDHS-NBKD-EPFD-SUHX-BZY7-O
SAZZ-K7HO-AWVG-P3LI-CJFG-VHSE-PDMO-K
SA2C-3KPC-7QWN-JWLO-V7PC-HJWF-BL4V-4
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q
EBVU-LCKJ-ZNZB-RJX5-63OF-ZGXD-6B7Q
MBMQ-3DNW-RVIM-IKFM-2YFL-4LBQ-SWWU-YWME-4PC7-EKJF-P4AE-7CAG-F5SQ
SAQA-O5LY-FEU6-NACQ-CFXV-WP43-OYWZ-6
SAQ2-HJLH-BCEF-VZ7Z-ETT5-UIU4-BBVP-E
SARD-7VKV-47TM-6T5C-HBQF-SBM4-TKUB-E
````

