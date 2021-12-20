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
<rsp>NAAX-5THA-IQI4-H7YJ-CPVQ-GSKM-MEOQ
</div>
~~~~

The Base32 presentation of a nonce value will always begin with the letter N.

By default, a 128 bit nonce is generated but nonces of any length may be
generated using the `/bits` option:


~~~~
<div="terminal">
<cmd>Alice> meshman key nonce /bits=256
<rsp>NBHD-GIM7-BPW3-U4GK-AASE-AQZ2-X4T3-LFED-LYYY-ZUTP-RLI3-YRXT-UTEC-S
</div>
~~~~

Secrets are generated in the same way using the command `key secret`:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret
<rsp>EALE-Y32T-5UEM-DWK2-RR7N-ACWL-2WCA
</div>
~~~~

The Base32 presentation of a secret value will always begin with the letter E.
Again, any output length can be requested up to the platform limit:


~~~~
<div="terminal">
<cmd>Alice> meshman key secret /bits=256
<rsp>EAY5-2OVU-7PZJ-2564-FX4B-FZ2F-X67S-IOGD-4JTV-RAYF-JEE3-O44F-K5AR-I
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
<rsp>EC4Q-7GAG-H76D-KINT-RWUG-VY2D-INNE-B3
MD6U-G3XB-5U5L-HRZH-ASFU-Q7JI-62CF-BEEY-Q3FT-ILMM-JKW6-KLKG-T4ZX-DI6M

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
<rsp>CKY3-MCKZ-NHBD-CJU3-GCPX-5FCE-VY
MCYP-ZJOS-UEMA-6UW2-ECNY-ICHL-QBFA-ABDD-TNIP-LVT4-R37M-7ARN-Q5NL
SAQJ-Z77K-VFL4-VPXC-UEDV-HCMK-6F6J-G
SAQS-OTQ7-JFLC-XO4U-DNZX-M44X-J22E-K
SARL-DHCT-5FKI-ZOCF-SXPZ-SXND-VPWC-U
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
    "Key": "CKY3-MCKZ-NHBD-CJU3-GCPX-5FCE-VY",
    "Identifier": "MCYP-ZJOS-UEMA-6UW2-ECNY-ICHL-QBFA-ABDD-TNIP-LVT4-R37M-7ARN-Q5NL",
    "Shares": ["SAQJ-Z77K-VFL4-VPXC-UEDV-HCMK-6F6J-G",
      "SAQS-OTQ7-JFLC-XO4U-DNZX-M44X-J22E-K",
      "SARL-DHCT-5FKI-ZOCF-SXPZ-SXND-VPWC-U"]}}
</div>
~~~~

The original secret may be recovered from a sufficient number of shares to
meet the quorum using the `key recover`:


~~~~
<div="terminal">
<cmd>Alice> meshman key recover SAQJ-Z77K-VFL4-VPXC-UEDV-HCMK-6F6J-G ^
    SARL-DHCT-5FKI-ZOCF-SXPZ-SXND-VPWC-U
<rsp>CKY3-MCKZ-NHBD-CJU3-GCPX-5FCE-VY
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
<rsp>LOF4-WWUI-TIAW-MDJ7-VK7P-COLZ-JE
MCNP-WKQK-EIS2-47YG-JW6E-5CIY-ZUU4-C46A-DJBQ-7BP6-PIES-WF2J-AK7T
SAYF-3RN4-SU4O-6I32-SXXK-YBPE-FVV3-O
SAY5-XCJ4-CNNR-RXPP-XY7S-UC3B-LQD7-Y
SAZN-JVSJ-2TXR-OMGF-QYYS-JT3I-YVG6-K
SAZU-TLHF-3H2O-UG73-5XCJ-YUP2-NE6X-E
SA2D-UDIQ-EJWJ-DH4S-6T4Z-BEYW-I7LN-M
</div>
~~~~

It is also possible to share a specified secret. This allows a secret to be 
shared multiple times creating independent key sets. If we re-share the secret
created earlier to create three shares with a quorum of two, the shares will
be different:


~~~~
<div="terminal">
<cmd>Alice> meshman key share CKY3-MCKZ-NHBD-CJU3-GCPX-5FCE-VY
<rsp>ERROR - Attempted to divide by zero.
</div>
~~~~

