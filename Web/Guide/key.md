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
<rsp>NBJR-CKSN-H4LD-4FAW-P423-P3W3-6LPQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>ND7Z-EHM2-FTTV-7CQM-KNPZ-3TM3-NBH7-B255-MWEJ-ENLV-JRCJ-RIPZ-6O6R-4
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ECXT-YW2D-A3MH-J6VJ-TKFX-HMYP-PVFQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EAOW-ERAB-7SOK-RFEJ-EBRD-WOTJ-7QMP-OTUO-425P-66ZJ-5EAP-2M6U-2LZX-S
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
<rsp>EBWH-RCRW-FUOE-37TH-EDRM-2PBE-B463-FJ
MC4V-MY6J-T2K2-3LJI-4332-OPA7-CV3Y-QXBI-ICF5-FFUB-IJR5-S7NC-7OTZ-SQHV
</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
<div="terminal">
<cmd>Alice> dare earl TestFile1.txt
<rsp>ERROR - The feature has not been implemented
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
<cmd>Alice> key share
<rsp>EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A
MCTS-2NQA-AD5B-WFZE-NWH3-I5OI-TN6G-3MAK-TUHM-RMDK-NXO2-EZNT-XSMA
SAQI-6LMK-TSHH-W7FZ-YRR6-TQY6-XSQQ-E
SAQ3-PQLE-3GA5-TQWV-X7DH-FQ6N-AG4I-M
SARO-AVJ7-CZ2T-QCHR-XMUP-XRD3-I3IA-U
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
    "Key": "EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A",
    "Identifier": "MCTS-2NQA-AD5B-WFZE-NWH3-I5OI-TN6G-3MAK-TUHM-RMDK-NXO2-EZNT-XSMA",
    "Shares": ["SAQI-6LMK-TSHH-W7FZ-YRR6-TQY6-XSQQ-E",
      "SAQ3-PQLE-3GA5-TQWV-X7DH-FQ6N-AG4I-M",
      "SARO-AVJ7-CZ2T-QCHR-XMUP-XRD3-I3IA-U"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQI-6LMK-TSHH-W7FZ-YRR6-TQY6-XSQQ-E SARO-AVJ7-CZ2T-QCHR-XMUP-XRD3-I3IA-U
<rsp>EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A
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
<rsp>EA7P-YHDZ-CPFY-TXYZ-PCZI-5NVV-56KQ
MAX7-HP56-LC4V-O774-Q4Q4-COAU-AZKK-LDSJ-SU35-5GMD-EXRW-XXXF-H3UA
SAYH-O5WB-YFTL-FEOY-SAJA-PH52-WCO2-4
SAYU-AHJ3-EOF5-YPJI-AGW5-VMRP-7OW6-O
SAZJ-R34I-T6BU-RC6N-NZGC-XRQW-S4QH-G
SAZY-D3NK-GVGP-O7OI-2XWP-VW3O-QL2R-6
SA2P-WF47-4TUO-SEY2-HCIE-P4RX-X4WB-4
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share EBTJ-TMC7-TMOT-NHOJ-AFQM-E4DX-RF7A
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

