
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
NDV4-W4Q3-LSQX-O5YM-3XZG-EQKX-5G7Q

````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NCIN-4SF3-HKW3-M43Z-5ZGO-NCSK-SVJR-X2UX-KMXI-2BJ4-XOBY-DGKQ-ZLRU-U

````

Secrets are generated in the same way using the command `key secret` :


````
>key secret
EAYK-XISS-BG4R-ON3G-JJKF-T35Z-RI4Q

````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EBNZ-C6DL-CA54-MTHP-TR44-WBRI-XWYL-VPCJ-AREV-GZJK-ZNGJ-JHHO-Q5VW-M

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
ECDJ-M5XQ-F6KZ-EOHJ-FVEH-AXB2-XK5B-ND
MCTO-HA7X-5WG5-SGOR-BI26-VX5G-TGEW-MBWZ-HUF2-ZHZR-UJHN-66FM-SMVM-Y3P6

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
ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA
MCNY-TSXH-KNNZ-LQFR-F7EO-PWNA-5EJI-F3WI-Z6VD-ANP4-5O6D-7VBP-G4AA
SAQN-W4Z2-QJHC-B7A3-NSUR-JETS-K64N-6
SAQR-KLIB-UAE3-A2F5-ZTCN-FNOG-K4S3-C
SARE-5ZWI-XXCT-7VLA-FTQJ-BWI2-K2JL-M

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
    "Key": "ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA",
    "Identifier": "MCNY-TSXH-KNNZ-LQFR-F7EO-PWNA-5EJI-F3WI-Z6VD-ANP4-5O6D-7VBP-G4AA",
    "Shares": ["SAQN-W4Z2-QJHC-B7A3-NSUR-JETS-K64N-6",
      "SAQR-KLIB-UAE3-A2F5-ZTCN-FNOG-K4S3-C",
      "SARE-5ZWI-XXCT-7VLA-FTQJ-BWI2-K2JL-M"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQN-W4Z2-QJHC-B7A3-NSUR-JETS-K64N-6 SARE-5ZWI-XXCT-7VLA-FTQJ-BWI2-K2JL-M
ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA

````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EDFW-KXNO-OJEY-64G4-ZZAX-NNYY-DSYA
MATR-GO6B-6QAU-7IJJ-LLHZ-A7ZB-7UXZ-POSA-6LFE-IWEP-6CIM-ANKX-C7OA
SAYK-MZEJ-GTHK-T4OA-5QGN-WWL4-CVLH-G
SAY3-IZYM-VIDG-UCJ6-M4IX-CAU2-2A7R-K
SAZP-K3HI-BYMY-TVPJ-JXOA-E4QT-JDLJ-M
SAZW-S5Q3-MEEA-SV6B-UBWI-7J7F-P4OM-G
SA2B-BAVG-ULI6-RDWH-L3BR-RJAR-OMI4-6

````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA
ECQ3-S43E-SKIY-66IM-RVLG-6HSY-JPNA
MCNY-TSXH-KNNZ-LQFR-F7EO-PWNA-5EJI-F3WI-Z6VD-ANP4-5O6D-7VBP-G4AA
SAQB-EZWK-R7FK-NACD-ZIXY-SPJU-KG27-U
SAQY-GFBB-XMBL-W4IO-Q7I3-YC2K-JMQE-2
SARP-HQLY-4Y5N-AYOZ-IVZ6-5WLA-ISFK-A

````

