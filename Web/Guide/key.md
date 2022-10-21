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
<rsp>NCSB-5UHJ-MFPO-SIIR-7EQS-6CRR-FIBQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NBDY-CHZN-UEJY-2YQP-6MBO-RLOH-4Q2C-XZYK-TJC6-2CIF-Z364-GCYP-RHOG-Y
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EAMQ-OYRD-6W45-FN44-KKDQ-DH4W-KX4Q
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EDHO-EL7F-VCU2-CIDH-7XNY-M6TJ-CSJM-NHGM-6C2P-SMU4-4KTV-CKDL-27MB-E
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
<rsp>ECUY-N7LY-5T42-WLFE-KDMP-3KRO-3IBE-JH
MDP7-PCT2-F5U3-UW2T-XMWX-3WU2-676G-VNWP-3BQK-S4SU-R5RP-UIR3-Y6WU-PIGU

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
<rsp>UGRA-AAKA-D7YU-XFC5-5YZ3-NWZC-SE
MA3W-X3QR-REOY-N4KI-ZHDT-OPRQ-YPZW-NCPB-O2OM-HEES-HWCS-G7ZG-NXWI
SAQB-KSRY-T3BX-NAE6-ERB4-7HYX-DUQQ-4
SAQY-R4TR-HRDM-2D7Q-WQU3-CCTX-L4P3-4
SARP-ZGVJ-3HFC-HH2D-IQHZ-E5OX-UEPG-4
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
    "Key": "UGRA-AAKA-D7YU-XFC5-5YZ3-NWZC-SE",
    "Identifier": "MA3W-X3QR-REOY-N4KI-ZHDT-OPRQ-YPZW-NCPB-O2OM-HEES-HWCS-G7ZG-NXWI",
    "Shares": ["SAQB-KSRY-T3BX-NAE6-ERB4-7HYX-DUQQ-4",
      "SAQY-R4TR-HRDM-2D7Q-WQU3-CCTX-L4P3-4",
      "SARP-ZGVJ-3HFC-HH2D-IQHZ-E5OX-UEPG-4"],
    "Success": true}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQB-KSRY-T3BX-NAE6-ERB4-7HYX-DUQQ-4 ^
    SARP-ZGVJ-3HFC-HH2D-IQHZ-E5OX-UEPG-4
<rsp>UGRA-AAKA-D7YU-XFC5-5YZ3-NWZC-SE
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
<rsp>ZWQT-BBCB-6GHD-FR2I-OWDK-6WUU-O4
MAG4-BWDG-VIG5-2U2X-43E7-ERGO-BSDU-KIDI-K2R6-P53X-6WUE-DQ5Y-U67L
SAYP-NY3F-MQVZ-3UGQ-7457-FZEM-2CCA-O
SAYR-TXJ4-3O5E-K3B7-W6ET-ROSA-IQAM-K
SAZD-NDVW-5LW6-QYD6-6AYE-OB6J-WUFR-O
SAZU-Z56T-SHDI-NLMO-VEYR-3TJJ-EORM-U
SA2F-2GES-2BCC-AU3O-4KF3-2CS6-R7D5-4
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share UGRA-AAKA-D7YU-XFC5-5YZ3-NWZC-SE
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

