
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
NBEP-HN3Y-ILQF-MERM-FPAN-TKGO-7QPA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NBEN-WBOT-F5LT-LVZY-GKXV-XMBT-LDG5-ATIP-HGUI-LU2A-QRV7-IG67-ZX4M-6
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EAVX-SDDW-B7RN-ON5F-SFWH-ZZIH-2BIQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
ED5Q-5ABU-JSH2-CPRS-4G6V-MFA3-ET4Y-EEEV-S64X-LJD4-DQUO-BSF5-NNMQ-G
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
EBEV-CV4J-W4M7-2LM6-Q2WX-TJWR-CYU6-VQ
MB6V-WEPD-DK24-IFW5-DTVU-YLPJ-OQMZ-S4IZ-AAPV-R2HX-DZLG-V36X-EGCZ-LI2C
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
ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA
MBDT-JP6X-RKBG-MQIP-YWJI-43SU-AWYX-TQ47-NR3Q-YUPC-LFIA-7YSC-V2GA
SAQK-RRFI-LPCJ-RYZN-JVK6-BL6H-SK2C-2
SAQ4-FS3R-QPDN-NUQ5-M4N2-3LDV-VSCV-M
SARN-ZUR2-VPER-JQIN-QDQX-VKJD-YZLH-6
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
    "Key": "ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA",
    "Identifier": "MBDT-JP6X-RKBG-MQIP-YWJI-43SU-AWYX-TQ47-NR3Q-YUPC-LFIA-7YSC-V2GA",
    "Shares": ["SAQK-RRFI-LPCJ-RYZN-JVK6-BL6H-SK2C-2",
      "SAQ4-FS3R-QPDN-NUQ5-M4N2-3LDV-VSCV-M",
      "SARN-ZUR2-VPER-JQIN-QDQX-VKJD-YZLH-6"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQK-RRFI-LPCJ-RYZN-JVK6-BL6H-SK2C-2 SARN-ZUR2-VPER-JQIN-QDQX-VKJD-YZLH-6
ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EDKN-JFJM-XGM6-CR23-URUK-DVCD-NQJA
MCRR-UC2P-PXG7-PSNE-2JXC-ZBP7-E7MN-GPYY-V26N-HYZO-I43H-HJ7T-MIQA
SAYI-C5V4-6IWC-VXJZ-AJPK-6EFI-3C27-Y
SAYQ-F2TG-RVM7-5ZCS-RKHG-I7KW-K3CC-O
SAZF-SL4R-7ZBR-L5UT-6QZY-RZ64-XWLM-M
SAZY-IRR7-ITTX-AE75-H5HB-YUB4-BUW2-M
SA2I-ILTO-MFDQ-2PEO-NPPB-5NTU-IWEM-O
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA
ECHL-3XZT-YJNP-IPJT-SAJ3-GGLY-4MCA
MBDT-JP6X-RKBG-MQIP-YWJI-43SU-AWYX-TQ47-NR3Q-YUPC-LFIA-7YSC-V2GA
SAQP-A6Q6-QZ2P-RFLW-E46G-W4DA-63Y5-Q
SAQV-ENS5-3ETZ-MNVP-DLUM-GLNI-OUAH-S
SARL-H4U5-FPND-HV7I-B2KR-V2XP-6MHU-2
````

