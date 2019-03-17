
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
NDLI-GE2N-FRCL-ONLN-ZTYC-YW2V-TKHA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NCSO-5Z7I-6WVM-XVVM-JMU5-756B-LWJ2-FMQK-NDMD-6KNB-HKOJ-HO47-LJQV-S
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EDK5-BX5C-3X3N-YIFR-VTV7-ENRY-Y4CQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
ED7X-ZFLK-BPVU-FBC7-LKVR-TVAC-3RNF-SZI7-76ZE-35GE-TIOC-U3MX-L6UV-I
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
ECUM-RPER-UDTL-PD7K-IHN7-XOK6-ICJ4-PB
MBNY-WHDJ-QLI6-TBQN-6DP5-BEYS-CRUC-QAOA-EFTK-FT63-GB2H-G4WQ-U7KM-YLZD
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
EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q
MDSC-MVC2-RS3Y-KXWA-4G5Z-4N7W-YBCO-YW2S-4XOU-3ZKX-EYG2-S5ZP-O7FA
SAQJ-MFYZ-TZF7-LUSR-PT5P-D472-LFBX-C
SAQW-6P5A-4EKC-HGOT-HLUL-DPNF-O5QC-2
SARE-Q2BI-EPOF-CYKU-7DLH-DB2Q-SV6O-S
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
    "Key": "EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q",
    "Identifier": "MDSC-MVC2-RS3Y-KXWA-4G5Z-4N7W-YBCO-YW2S-4XOU-3ZKX-EYG2-S5ZP-O7FA",
    "Shares": ["SAQJ-MFYZ-TZF7-LUSR-PT5P-D472-LFBX-C",
      "SAQW-6P5A-4EKC-HGOT-HLUL-DPNF-O5QC-2",
      "SARE-Q2BI-EPOF-CYKU-7DLH-DB2Q-SV6O-S"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQJ-MFYZ-TZF7-LUSR-PT5P-D472-LFBX-C SARE-Q2BI-EPOF-CYKU-7DLH-DB2Q-SV6O-S
EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EA54-6YXN-GRIT-AM3G-EXQQ-SMO6-EHAQ
MB2J-NDNO-H5YE-THW7-LU4K-ST5A-DW44-26W5-SAGB-BJLS-NAZS-E7JA-QZMQ
SAYP-6Y7X-2SHK-SCP6-SJ4F-V44E-JCOG-C
SAY6-NTUI-7XCN-GKAI-7OKV-JK76-SHUG-O
SAZP-EDYW-NDLM-7CSS-UF6M-4MVA-XIDA-M
SAZS-CJNA-CXCJ-4MG3-QQXM-PB3K-YD2Q-W
SA2H-IERG-ASHD-6G5D-UOVU-BKS4-U225-Y
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q
EC6O-5ES3-QPEA-VT57-BUZC-UTZ3-E22Q
MDSC-MVC2-RS3Y-KXWA-4G5Z-4N7W-YBCO-YW2S-4XOU-3ZKX-EYG2-S5ZP-O7FA
SAQD-JI75-AK3B-W76U-CH4S-2IGT-QLBM-G
SAQ2-YWLH-VHUG-55GY-MTSS-QF2X-ZJPQ-I
SARC-IDWS-KENM-E2O4-W7IS-GDO4-CH5R-E
````

