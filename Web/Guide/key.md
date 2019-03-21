
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
NBZN-6OAF-5ASD-DGAE-6JFA-JK3Q-5CUA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NDMO-J2KS-XXTG-WBEM-GCRH-OICF-66WF-DV7W-WUQ2-OEC7-62S6-ZPKI-EO3K-6
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
ECBJ-PLU4-G6QV-ZPFE-3GWW-QB6P-ZQWQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
EAJI-MLHL-KLHV-3K6O-TDTS-OEDH-GE7A-2HCQ-QSAL-A6WX-RVRL-2DYF-ABX3-6
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
EAIF-F3UP-7U6T-VYSA-JEZ4-IXA2-UUGA-5W
MCJO-A7Z4-OO3X-P6XB-AJT2-VAUH-7TXC-ABJ7-ZVF2-DUNL-GUFL-BCVX-WGTE-2GSW
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
ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ
MAV5-OE43-PQRW-RCVS-O3ZB-CQHA-NHAY-OBHV-S4KZ-UAIW-ZWNI-HOMQ-5VWQ
SAQG-3PFO-KME2-BF44-P5WV-2AXW-PWJ4-6
SAQT-KL6D-5TNT-3YY7-XN6F-Z7QO-AJEV-K
SARP-ZIWZ-Q2WN-WLVC-66FV-Z6JF-Q37Q-4
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
    "Key": "ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ",
    "Identifier": "MAV5-OE43-PQRW-RCVS-O3ZB-CQHA-NHAY-OBHV-S4KZ-UAIW-ZWNI-HOMQ-5VWQ",
    "Shares": ["SAQG-3PFO-KME2-BF44-P5WV-2AXW-PWJ4-6",
      "SAQT-KL6D-5TNT-3YY7-XN6F-Z7QO-AJEV-K",
      "SARP-ZIWZ-Q2WN-WLVC-66FV-Z6JF-Q37Q-4"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQG-3PFO-KME2-BF44-P5WV-2AXW-PWJ4-6 SARP-ZIWZ-Q2WN-WLVC-66FV-Z6JF-Q37Q-4
ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EALO-CNZJ-5TOW-ZXB6-QDKO-LQMQ-ZTOA
MD5W-EGYK-Z2XV-OEFM-T2DG-GTFQ-XFVZ-ZMPF-DG3Q-T6OQ-6SOX-BK5Z-QY3Q
SAYM-V55P-VFMK-G4EA-OZBZ-64IA-4PUK-M
SAYW-2DLN-AZTJ-AMZI-UL7S-DMOH-CXI6-Y
SAZP-2ITP-IELK-HNGU-YSZV-XKAU-E2ER-I
SAZX-WNVW-LFUN-35ME-3NQE-2U7I-CYG3-Q
SA2O-OSSC-J5OT-55JY-44C7-NNKC-4RQD-4
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ
ECTE-TGFZ-HABU-YGKD-LZOQ-PXXY-3ZEQ
MAV5-OE43-PQRW-RCVS-O3ZB-CQHA-NHAY-OBHV-S4KZ-UAIW-ZWNI-HOMQ-5VWQ
SAQM-HIPC-MLQD-G7Z5-C2ZQ-VQDH-XM7O-G
SAQ6-B6RM-BSEG-HMTA-5ID3-Q6HQ-PWPX-2
SARP-4UTV-WYYJ-HZME-XVOG-MMLZ-IAAB-O
````

