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
<rsp>NAC4-FVVP-OG4R-RGQS-XCTC-3ECI-LWTA
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> key nonce /bits=256
<rsp>NAMM-5PMM-NBI5-TA33-T7HK-YMU7-LLBT-B6CR-ICKL-WRYQ-MN33-KZB2-KS3Q-6
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> key secret
<rsp>ECZS-MCZV-Q4PT-2V7C-B4EO-BZXY-CMOA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> key secret /bits=256
<rsp>ED4M-PLLJ-XNIY-PDRQ-QY32-6TF7-VZMN-KDV6-VJSC-DD4M-EBRG-B7BH-O6XW-C
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
<rsp>EAMA-F3Z3-KOXN-6T2S-LXJN-M3RP-YHBA-YH
MAG7-QZVX-DYJZ-7BNZ-CAS6-NU6O-7NC7-LW7D-MJZJ-LHHT-WJR7-YOIW-4IEY-ZG7W

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
<rsp>INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
MARI-JIJ7-MN3S-JHRE-GVQC-Z3H4-727N-W3QY-UHBJ-4KZT-4O3G-OPXC-GCZR
SAQJ-BYIM-G42W-ZED7-DTNL-KY3Q-YGJC-I
SAQ5-4UM3-TYJC-FBQV-VVLB-TCVK-PNYP-W
SARC-XQRL-ATXN-Q65M-HXIX-3MPE-GVHZ-6
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
    "Key": "INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU",
    "Identifier": "MARI-JIJ7-MN3S-JHRE-GVQC-Z3H4-727N-W3QY-UHBJ-4KZT-4O3G-OPXC-GCZR",
    "Shares": ["SAQJ-BYIM-G42W-ZED7-DTNL-KY3Q-YGJC-I",
      "SAQ5-4UM3-TYJC-FBQV-VVLB-TCVK-PNYP-W",
      "SARC-XQRL-ATXN-Q65M-HXIX-3MPE-GVHZ-6"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> key recover SAQJ-BYIM-G42W-ZED7-DTNL-KY3Q-YGJC-I ^
    SARC-XQRL-ATXN-Q65M-HXIX-3MPE-GVHZ-6
<rsp>INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
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
<rsp>KEDS-KBYY-CI5T-UTDB-PE7J-ZGRL-4M
MCRD-5IS2-7TN7-FIPS-AUQO-BTIM-FX4L-67J3-C5KJ-IIDX-HCMA-K6IH-WTM7
SAYM-VGSC-BELD-TFJS-X7YP-WWLH-VELD-W
SAYU-C4C3-FXH4-MPVQ-C5I2-DH3P-ZRBP-Y
SAZL-LCLQ-OVCL-QN5S-KKBW-YEFV-AOZI-Y
SAZS-NZMB-352Q-7ABZ-OGDF-VLJX-J5SI-K
SA2J-LBEP-NRQM-YGCF-ORNG-25HW-V5MU-2
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> key share INYH-ZUCY-W2NO-RDC7-KE6D-OB5T-JU
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

