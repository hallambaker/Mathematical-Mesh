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
<rsp>NAAQ-NBJG-S3FU-TVNJ-GVG2-EMDC-TD6Q
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NDHK-2S2K-ICFG-DLCJ-JQCZ-7CBD-HVZO-BEYX-MT53-VHL7-6A7Y-HKNI-O5QD-2
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>ECWW-P2NQ-FRYI-U4TX-7Z6T-5ZPU-I4OQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EAAT-LTR3-C46S-AU2U-OXD6-22D3-UCVM-QGFB-TUS3-E7U3-OJRS-UQ3T-BZBF-Q
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
<rsp>EBLM-AZCG-S7YB-F4AI-U73E-JDK2-R4UB-UA
MD2O-IDCP-LKYT-PMTD-WHAF-I2YU-3LXV-63EA-RZ2C-S6N6-ZBRC-MWGY-YVE7-2OFA

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
<rsp>CJGO-SRYL-7TCI-K5ZY-KJDZ-OW7K-ZI
MBVW-TFZ4-6E6Y-LEWX-J5NQ-DAMN-GUOU-MAMI-YIP6-I4DK-NXAZ-3G5X-ZCXH
SAQJ-P5NO-7QIX-UVJ4-6ZMH-JZZJ-AQY2-I
SAQR-3HTU-WELP-PZPU-OV4J-PBV2-VR4E-W
SARK-GRZ2-MYOH-K5VL-6SML-UJSM-KS7S-K
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
    "Key": "CJGO-SRYL-7TCI-K5ZY-KJDZ-OW7K-ZI",
    "Identifier": "MBVW-TFZ4-6E6Y-LEWX-J5NQ-DAMN-GUOU-MAMI-YIP6-I4DK-NXAZ-3G5X-ZCXH",
    "Shares": ["SAQJ-P5NO-7QIX-UVJ4-6ZMH-JZZJ-AQY2-I",
      "SAQR-3HTU-WELP-PZPU-OV4J-PBV2-VR4E-W",
      "SARK-GRZ2-MYOH-K5VL-6SML-UJSM-KS7S-K"],
    "Success": true}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQJ-P5NO-7QIX-UVJ4-6ZMH-JZZJ-AQY2-I ^
    SARK-GRZ2-MYOH-K5VL-6SML-UJSM-KS7S-K
<rsp>CJGO-SRYL-7TCI-K5ZY-KJDZ-OW7K-ZI
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
<rsp>DJ2S-5HMH-4AJL-TX5U-HL3Z-24EC-XE
MDIT-VPAG-IO5Z-PI7D-OMZ7-JHOX-TFUC-HJFR-7AWW-DYT2-53RD-6ZRV-3YH2
SAYL-EYCO-MWG6-ZIYR-7WAE-ELOF-VFEL-G
SAYS-376Z-L5RP-VMLT-OOBI-TJSU-VFUF-C
SAZI-2U6P-RMDQ-UPO6-IG5R-CYKK-ODQ7-S
SAZ5-AXBQ-5B5B-WSCS-NAU5-SXVG-762X-Q
SA2P-OGH5-O66C-3UGP-43HO-DHTK-KXRM-4
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share CJGO-SRYL-7TCI-K5ZY-KJDZ-OW7K-ZI
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

