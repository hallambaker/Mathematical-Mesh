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
<rsp>NBV4-B2X6-YGYH-6N3N-XUDI-NWXJ-CJKA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NCW6-ASSM-IW7M-TDBR-GQ4O-7ZLR-UU7W-4MGN-IN5R-ZE3O-YAOI-WJ5G-Z6D7-M
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EA3V-OAE3-RUJS-IXDH-U2JD-RBVP-YGZA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EAHU-JBXY-JTNJ-JJGK-4V2D-UR2L-FU6K-2MX2-QYYP-6TZE-6IZR-SJTH-ZHT7-K
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
<rsp>EC6F-U7PX-STXQ-2Z66-RQUM-PP6A-ABJX-CS
MAOP-YG26-CLUN-6YRX-XSSE-ZR4V-RDHT-PGN5-NTA2-4L6B-EN2C-UPL5-VCKK-B4MC

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
<rsp>CRJT-AQMW-WR74-BWSS-7AXF-TKTG-T4
MCYY-FO3A-72EU-CTAT-B2GE-3WSU-B7CZ-QPS2-SLTP-SRMK-JKRW-T2UZ-RLYK
SAQA-SSRW-7KKI-VNWK-BI46-YXDO-YVZQ-S
SAQ7-4QJ5-WOJG-B3OT-HIQO-BCUD-4B72-M
SARP-GOCE-NSID-OJG4-NID5-JOEY-7OGB-A
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
    "Key": "CRJT-AQMW-WR74-BWSS-7AXF-TKTG-T4",
    "Identifier": "MCYY-FO3A-72EU-CTAT-B2GE-3WSU-B7CZ-QPS2-SLTP-SRMK-JKRW-T2UZ-RLYK",
    "Shares": ["SAQA-SSRW-7KKI-VNWK-BI46-YXDO-YVZQ-S",
      "SAQ7-4QJ5-WOJG-B3OT-HIQO-BCUD-4B72-M",
      "SARP-GOCE-NSID-OJG4-NID5-JOEY-7OGB-A"],
    "Success": true}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQA-SSRW-7KKI-VNWK-BI46-YXDO-YVZQ-S ^
    SARP-GOCE-NSID-OJG4-NID5-JOEY-7OGB-A
<rsp>CRJT-AQMW-WR74-BWSS-7AXF-TKTG-T4
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
<rsp>4FAL-FYMZ-FCF3-CFQY-MFS5-NYPQ-RE
MAQF-6YFK-GU2E-JYHD-CWFI-DKO7-OY66-SDQJ-VOVM-NOWY-HLEB-W4BM-5AEW
SAYO-LAW6-LX7H-TY35-HYLX-APVP-RIMX-G
SAY4-F3K5-3ZXI-54IA-5SS6-2IPV-7ST3-2
SAZH-TABR-MLUW-PNB4-EHB5-QD5K-HGNW-O
SAZQ-SO2Y-5NXQ-ILJO-3VYT-CB6M-ID2H-C
SA2H-EHWU-O77W-IW6Z-D6W7-QCS4-CKZQ-4
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share CRJT-AQMW-WR74-BWSS-7AXF-TKTG-T4
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

