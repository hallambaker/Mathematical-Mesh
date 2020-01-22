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
<rsp>NDVO-BPJC-JIAY-CUKX-4T5E-PLX2-UUPQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NAP4-AQ7L-ZAF7-TDZF-AFNH-4TVS-BNY4-CG2A-DU6Y-3J4U-5LVI-6TLQ-I7EC-I
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>EDYA-LHGG-J663-TNTV-3HAU-SUQG-PPGQ
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EAQP-DKBC-B3MO-O4QM-3VV4-QWLW-WOTR-BUOX-MOH5-RLZ5-XSJ7-6NEX-WJ2X-6
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
<rsp>EBYV-GJQU-7XYF-VG3C-OMW2-QXF6-Z37F-HN
MCO5-D3TD-KQMA-5S4V-45ZI-Q4EW-6YUU-TIF7-4RNK-YT7G-Y7DY-AUV2-6SDQ-BUAO
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
<rsp>ECBR-HIGH-QJX6-WX7O-KYAP-UBQI-NZEA
MCZU-U662-PSPP-QQ3R-IZTI-TJR7-VORM-VPLI-FZ3I-VSYJ-QVJN-DNZE-GROQ
SAQG-NSYI-ZJ23-AKOL-J64S-TBR4-VRWU-Q
SAQU-VATQ-ZVUP-A2BW-WEOF-EETT-KBWE-Q
SARC-4OOY-2BOD-BJVC-CJ7X-VHVJ-6RVU-Q
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
    "Key": "ECBR-HIGH-QJX6-WX7O-KYAP-UBQI-NZEA",
    "Identifier": "MCZU-U662-PSPP-QQ3R-IZTI-TJR7-VORM-VPLI-FZ3I-VSYJ-QVJN-DNZE-GROQ",
    "Shares": ["SAQG-NSYI-ZJ23-AKOL-J64S-TBR4-VRWU-Q",
      "SAQU-VATQ-ZVUP-A2BW-WEOF-EETT-KBWE-Q",
      "SARC-4OOY-2BOD-BJVC-CJ7X-VHVJ-6RVU-Q"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQG-NSYI-ZJ23-AKOL-J64S-TBR4-VRWU-Q SARC-4OOY-2BOD-BJVC-CJ7X-VHVJ-6RVU-Q
<rsp>ERROR - Not enough shares to recover key
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
<rsp>EDLZ-UN3I-P3QU-EAKC-RJZH-EXD2-HUCQ
MCMP-J5EH-VANO-QW5S-WCCP-DN6M-OBPQ-IEYN-RRUX-RVQG-CBLE-7ERY-PZNQ
SAYI-HBLI-WGQC-C4XJ-LJYV-TTMF-FWIY-C
SAY3-OSFB-ODCV-6GFO-DOM3-PBEF-I2XZ-W
SAZH-FY7B-UXXJ-UM2P-QYBY-XF24-YWLS-A
SAZ3-MVZJ-KEN5-FQWN-TGXN-MBQL-VJEE-G
SA2I-DITY-OJGQ-RRZI-K2NZ-NUER-6TBN-C
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share ECBR-HIGH-QJX6-WX7O-KYAP-UBQI-NZEA
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

