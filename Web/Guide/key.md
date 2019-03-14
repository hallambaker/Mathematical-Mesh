
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
NBPL-L6HU-QYQL-HSCX-TRA5-7TBB-FKFA
````

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


````
>key nonce /bits=256
NAIZ-KW7C-BRVO-PXQH-Z6LX-FGPY-6BNS-BEPB-WW7D-2VQ2-PRSW-FB4F-T3P3-M
````

Secrets are generated in the same way using the command `key secret`:


````
>key secret
EAUM-CBZB-EGDC-TOPG-VKOA-B5IJ-TSMQ
````

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


````
>key secret /bits=256
ECTZ-CZ5K-ASRY-BCQT-KE2N-FUQR-J7VN-NK4D-ZJXU-WVQL-W4KY-CVMC-EWFN-C
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
ECGD-AX3D-K5NI-KNFS-P2H5-2ANC-QTGS-KI
MBBF-ZOTN-3MFJ-PQEM-GCGI-TZIC-D3TX-PYNO-ZFUM-6SW7-WXUF-ID4I-LDLR-JR43
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
ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ
MAZS-NIMY-XVCM-YEI7-AQO4-YIJ4-3XZB-5XMD-IX6O-LBIL-TG2A-RIFE-SM2A
SAQA-QUAF-22YQ-VIG7-DOPF-BAG3-GWPU-K
SAQW-7LNQ-4IHX-E6VQ-T3VK-CHY4-4WU2-Q
SARN-OC23-5VW5-UVEC-EI3P-DPK6-SW2A-W
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
    "Key": "ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ",
    "Identifier": "MAZS-NIMY-XVCM-YEI7-AQO4-YIJ4-3XZB-5XMD-IX6O-LBIL-TG2A-RIFE-SM2A",
    "Shares": ["SAQA-QUAF-22YQ-VIG7-DOPF-BAG3-GWPU-K",
      "SAQW-7LNQ-4IHX-E6VQ-T3VK-CHY4-4WU2-Q",
      "SARN-OC23-5VW5-UVEC-EI3P-DPK6-SW2A-W"]}}
````

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


````
>key recover SAQA-QUAF-22YQ-VIG7-DOPF-BAG3-GWPU-K SARN-OC23-5VW5-UVEC-EI3P-DPK6-SW2A-W
ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ
````

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


````
>key share /quorum=3 /shares=5
EBHF-JACW-QSC6-VDIH-OKRG-Z2L2-FQGQ
MCNB-Z3H3-ZRQE-GPXK-4GLJ-TNHX-FMDZ-KRGS-MHRV-6BAF-KDAU-HTTN-CXNA
SAYJ-VNCL-PIVH-V6TM-TKFM-VGT4-2RFJ-C
SAY6-HA7K-WWBR-76HD-ZPUO-LHBI-JMT7-W
SAZC-RQ26-BCHH-JZPS-TOGP-G4PL-33CB-Q
SAZW-U4VF-ONGH-TQMZ-BF3P-IG6H-R4PU-4
SA2K-REOA-6W6S-5C6X-CWTO-PGN3-LQ4W-U
````

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


````
>key share ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ
ECQP-EWWL-KKRM-ODMY-KH76-FGMF-SUKQ
MAZS-NIMY-XVCM-YEI7-AQO4-YIJ4-3XZB-5XMD-IX6O-LBIL-TG2A-RIFE-SM2A
SAQB-CKGR-VU7M-ZSBV-OCNH-FT6Q-Y757-Q
SAQY-CX2I-R4VP-NSK5-JDRO-LPII-BJRQ-4
SARP-DFN7-OELS-BSUF-EEVV-RKR7-JTFC-I
````

