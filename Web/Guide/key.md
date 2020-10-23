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
<cmd>Alice> key nonce
<rsp>NDY4-C7YY-2R2M-ZJ3H-NLQR-5W3Q-HRMQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NAXM-ZV55-YCD6-DE2I-U352-F5GA-MV4T-H2QA-ZWO3-Z4BQ-F6KR-Q2VA-CZG5-M
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ED73-NPH3-ASAS-J2N6-J75U-AABD-3LLA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ECHF-ABLQ-2ZP3-VNLD-KCEW-BG5X-66GR-5C5C-MZYB-RUXH-LGTL-52KQ-WQ7U-W
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
<cmd>Alice> key earl
<rsp>EDVJ-TVRX-BN2P-KH4Q-O6HW-4AVY-JUWN-ZE
MALQ-Q6LA-6AUO-WW7X-OHMV-DA5H-T4WJ-B44F-EVNE-P6QP-N6HV-2VZT-VGPW-TE3K
</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:

**Missing Example***

## Sharing and recovering secrets

Secret sharing splits a secret into a set of shares such that the original
secret can be recovered from a chosen number of shares called the quorum.

The `key share` command creates a secret and splits it into the specified
number of shares with the specified quorum for recovery. By default, a 128
bit secret is created and three shares are created with a quorum of two:


~~~~
<div="terminal">
<cmd>Alice> key share
<rsp>3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
MAOH-UF4B-F5XC-526K-STLZ-4Q7M-XBE2-BSML-FO7M-4OPI-7RN2-RN22-2IW7
SAQH-GZHH-YNV3-RKXV-O6XG-2I47-3MAK-S
SAQQ-RIZ4-J3EK-GYLA-PKJD-GDSN-Z5ZQ-6
SARJ-3YMQ-3ISY-4F6L-PV27-R6H3-YPS2-Q
</div>
~~~~

The first UDF output is the secret key, followed by the key identifier 
two shares. The different outputs are easily distinguished by their first 
letter. As with every meshman command, the `/json` option may be used to 
obtain the result as a JSON structure:


~~~~
<div="terminal">
<cmd>Alice> key share /json
<rsp>{
  "ResultKey": {
    "Success": true,
    "Key": "3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM",
    "Identifier": "MAOH-UF4B-F5XC-526K-STLZ-4Q7M-XBE2-BSML-FO7M-4OPI-7RN2-RN22-2IW7",
    "Shares": ["SAQH-GZHH-YNV3-RKXV-O6XG-2I47-3MAK-S",
      "SAQQ-RIZ4-J3EK-GYLA-PKJD-GDSN-Z5ZQ-6",
      "SARJ-3YMQ-3ISY-4F6L-PV27-R6H3-YPS2-Q"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQH-GZHH-YNV3-RKXV-O6XG-2I47-3MAK-S SARJ-3YMQ-3ISY-4F6L-PV27-R6H3-YPS2-Q
<rsp>3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
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
<cmd>Alice> key share /quorum=3 /shares=5
<rsp>WWDY-H7RH-PCN7-7VHX-JYC7-AMLD-6U
MBTA-NYWE-XVIQ-ZDFU-FGEF-SEKU-SJ27-IPHB-ZGYO-HRAL-VYXZ-CIPQ-QKJ5
SAYO-HDYE-Z7JY-NGMS-DJT6-VVUF-RP25-E
SAYU-3WVO-HL26-5D6X-LVWN-AS3D-YRFF-I
SAZP-I2UA-H6HL-A7WP-TYC7-4ZEK-3JQ6-C
SAZ5-OPT2-3WO4-YZT2-3QZX-KIP2-ZY6B-G
SA2P-MVU6-CURU-ERWZ-C72T-JA5T-T7MR-2
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share 3YTJ-GOAO-ZX2I-U5GK-U44P-DZUO-IM
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

