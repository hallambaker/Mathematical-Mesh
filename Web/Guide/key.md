<title>key
# Using the key Command Set

The `key` command set contains commands that operate on cryptographic secrets and
nonces.

## Generating Secrets and Nonces

Secrets and nonces both consist of a randomly generated sequence of bits. The
only distinction made between a secret and a nonce is the uses that may be 
made of them. For example, a secret value must not be passed in clear text in 
any circumstances. The visual distinction between these uses afforded by UDF 
presentation aids application debugging and audit.

The `key nonce` command is used to generate a new random nonce value:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce
<rsp>NDTQ-VPYW-U45B-NHPM-YBJL-T2TE-SZCA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NDOF-COZS-NC24-CCKD-ICKW-KFI3-DNSO-SCA5-B3GX-QEBN-VJYQ-O2CD-K37W-M
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EBC6-7CCH-HKRW-IMZJ-DN7R-YUFC-CPWA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>ECUN-SLSP-TQMV-EUGA-L5F5-2FAK-AKOJ-7V2D-IH32-JTJD-NOUH-L5XN-WK6D-W
</div>
~~~~

## Generating EARL values

An Encrypted Authenticated Resource locator is a form of URI that specifies 
a means of locating and decrypting content stored on a remote Web service.

The EARL itself specifies a domain name and a secret. The content is stored
on the Web Service under a label that is the Content Digest of the secret.

EARLs may be generated using the `key earl` command to generate
a new secret/digest pair which are then used to process the content data:


~~~~
<div="terminal">
<cmd>Alice> meshman key earl
<rsp>EAPH-3VAH-3RKP-FCMI-M3AQ-TX7M-EKDQ-U7
MBRD-PPK4-FT72-52N7-WJD6-DEHE-Q3PD-SV4O-EJDM-KZZF-B2VI-G22T-4XLN-MHBP

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
<div="terminal">
<cmd>Alice> meshman dare earl TestFile1.txt example.com
<rsp>ERROR - An unknown error occurred
</div>
~~~~

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


~~~~
<div="terminal">
<cmd>Alice> meshman key share
<rsp>IKT5-XING-IF3Y-UC52-GWRI-RDWI-NY
MCXR-ZXTT-ZLRL-ORRS-PDKN-JGIL-LOSG-SKQ7-EQQR-5N3P-SNNT-Q5TG-EJE6
SAQK-C5U3-LREW-DZCF-7FK2-NNOU-ENSI-O
SAQQ-ARK3-C3WI-EUIB-43YR-PSI7-XAAG-2
SARF-6FA2-2GH2-FPN5-2SGI-RXDL-JSOI-M
</div>
~~~~

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


~~~~
<div="terminal">
<cmd>Alice> meshman key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "IKT5-XING-IF3Y-UC52-GWRI-RDWI-NY",
    "Identifier": "MCXR-ZXTT-ZLRL-ORRS-PDKN-JGIL-LOSG-SKQ7-EQQR-5N3P-SNNT-Q5TG-EJE6",
    "Shares": ["SAQK-C5U3-LREW-DZCF-7FK2-NNOU-ENSI-O",
      "SAQQ-ARK3-C3WI-EUIB-43YR-PSI7-XAAG-2",
      "SARF-6FA2-2GH2-FPN5-2SGI-RXDL-JSOI-M"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQK-C5U3-LREW-DZCF-7FK2-NNOU-ENSI-O ^
    SARF-6FA2-2GH2-FPN5-2SGI-RXDL-JSOI-M
<rsp>IKT5-XING-IF3Y-UC52-GWRI-RDWI-NY
</div>
~~~~

As with secret generation, larger or smaller secrets may be created but due
to a limitation in the implementation of the key sharing algorithm, the secret 
must be of length 512 bits or less and the number of bits is rounded up to
the nearest multiple of 32 bits.

For example, we can create a 192 bit secret and share it five ways with a quorum
of three:


~~~~
<div="terminal">
<cmd>Alice> meshman key share /quorum=3 /shares=5
<rsp>QLSW-Z3QA-ZXAO-YAQT-FX3G-FHL5-JA
MBNL-I5BE-43FI-VHR7-QORR-GJCU-IXMM-IDNG-23TU-M54V-IAWA-5EX4-I5LP
SAYI-2ZCF-3IOC-Q27W-CIKY-YHBN-TL3D-G
SAY4-BUJN-GIR6-VEQ4-GJ5C-LV6M-SUBD-A
SAZB-2LBC-6YMB-IM26-MNAP-WKJ7-ROQQ-Y
SAZ2-E5JH-EX4K-KT54-URVA-YEEG-P3JS-2
SA2F-BLBZ-YHCZ-3ZZW-6X2V-RDNB-N2MC-2
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share IKT5-XING-IF3Y-UC52-GWRI-RDWI-NY
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

