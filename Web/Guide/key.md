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
<rsp>NBNG-K554-5YYI-NLJ3-6I7U-JEKD-SHZQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>ND67-V4XX-VSPO-KPAF-NHWC-OX3S-J75R-2FDK-SADI-XAKB-MNTY-XVXF-CKWW-M
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ECUV-DNB4-RGYZ-MNLS-2WAS-OAS4-4F7Q
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>EAUN-MFY7-2M6W-LW3I-XTSY-RGYW-4H7X-7QCC-SOEY-UX7V-72Z5-46RV-LICC-M
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
<rsp>ECW2-UPXH-QX27-762O-BCF5-JHCF-AEX4-2B
MAXS-MYXJ-4OSB-WNT7-UTUK-PSVE-3GBB-5J5N-MK4Z-CZKC-F7Z4-XKOH-NUBM-6WZL

</div>
~~~~

Alternatively, the `dare earl` command may be used to perform both operations:


~~~~
Missing example 4
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
<rsp>X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4
MABY-3I7S-MLWT-W62Y-R3OC-QXFT-Q5AC-P3N4-DYPN-UMKH-PLIQ-LFTK-TL6W
SAQN-WBKW-VQOS-2LTZ-NGIG-TOQG-M4QD-O
SAQ7-NN37-NJYO-E4VY-TAPX-RX2V-ZBZC-O
SARB-E2NI-FDCJ-PNXX-Y2XI-QBFF-FHB6-I
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
    "Key": "X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4",
    "Identifier": "MABY-3I7S-MLWT-W62Y-R3OC-QXFT-Q5AC-P3N4-DYPN-UMKH-PLIQ-LFTK-TL6W",
    "Shares": ["SAQN-WBKW-VQOS-2LTZ-NGIG-TOQG-M4QD-O",
      "SAQ7-NN37-NJYO-E4VY-TAPX-RX2V-ZBZC-O",
      "SARB-E2NI-FDCJ-PNXX-Y2XI-QBFF-FHB6-I"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQN-WBKW-VQOS-2LTZ-NGIG-TOQG-M4QD-O ^
    SARB-E2NI-FDCJ-PNXX-Y2XI-QBFF-FHB6-I
<rsp>X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4
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
<rsp>MRE2-4KFP-YKCL-VIVA-X7S5-VGJI-PM
MBGK-DDCP-YUCD-IBQA-GR33-7IZB-WB7Q-O7GG-JB6A-GNEA-Z5K5-QAUH-OUWT
SAYB-ZBSQ-EZF6-QMUY-XS2Q-BQKG-FNED-K
SAY4-BSS2-5W4P-RSYI-N3B4-GONK-BXMT-2
SAZF-CFOO-P33P-ITQJ-XDGQ-OTYG-IDNS-2
SAZ4-22FK-3IC5-VO44-TLIM-2AK2-YRHG-W
SA2D-LQXP-73S2-YE6B-CTHR-IUFH-TAZJ-C
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share X5JS-33OJ-O7VD-UOYB-LKKL-OBOO-I4
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

