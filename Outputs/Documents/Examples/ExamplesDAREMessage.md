
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"VPMxK6KqZjSIVxGxpY3LhmLYyLRisqxmvL7s0UxND-A",
    "crv":"Ed25519"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"H4vYLegql3J8i2rDmU0t9rFGRpg5P2IeBdykCE_YMWo",
    "crv":"Ed25519"}}
~~~~

The body of the test message is the UTF8 representation of the following string:

~~~~
"This is a test long enough to require multiple blocks"
~~~~

The EDS sequences, are the UTF8 representation of the following strings:

~~~~
"Subject: Message metadata should be encrypted"
"2018-02-01"
~~~~

## Plaintext Message

A plaintext message without associated EDS sequences is an empty header
followed by the message body:

~~~~
{
  "DareEnvelope":[{},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBs
  ZSBibG9ja3M"
    ]}
~~~~

## Plaintext Message with EDS

If a plaintext message contains EDS sequences, these are also in plaintext:

~~~~
{
  "DareEnvelope":[{
      "annotations":["iAEAiC1TdWJqZWN0OiBNZXNzYWdlIG1ldGFkYXRhIHNo
  b3VsZCBiZSBlbmNyeXB0ZWQ",
        "iAEBiAoyMDE4LTAyLTAx"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBs
  ZSBibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a base seed:

~~~~

  21 68 62 34  87 66 26 74  A7 0B 24 DD  12 51 5B 5B
  AC 0A A9 AF  48 67 46 E2  6B CF 83 B4  D1 57 44 F5
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"WDAYDXD5Put4Ll0xAhkK3kv6-3CyTJgVDcYgXuldi4E",
    "crv":"Ed25519"}}
~~~~

The key agreement value is calculated:

~~~~

  CC 81 13 A7  8D 18 A7 2C  98 1C 36 AD  5C 8F BF CF
  C2 A4 32 09  B4 FB 79 D6  80 9E 6A FC  79 81 5A 93
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  88 F6 C4 90  53 44 FC 11  96 55 63 F4  99 B5 63 3B
  56 02 19 F6  47 F6 8B 8E  F3 75 18 7B  0C F1 5B 8B
~~~~

The wrapped base seed is:

~~~~

  35 F6 23 8E  03 56 CA 90  84 F4 6E F5  2B E8 B3 23
  48 3F E5 A0  25 80 3E B8  A7 F6 30 19  A0 B9 F0 60
  5C B0 F3 10  B3 8C 0E 4B
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  3E CC 00 84  29 59 55 47  7E 93 13 A1  97 81 3B 0D
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  AB 90 F5 53  ED 24 EF 2D  23 99 85 F5  6D 0B F5 9C
  9E 5A A1 1C  81 4A 6E 50  56 6C 6D 48  F2 29 87 A8
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  21 8A A9 BE  9B 56 C2 BE  B0 D9 5F B5  04 70 15 9D
~~~~

The output sequence is the encrypted bytes:

~~~~

  B6 09 1D C6  9F E9 FC 35  6B 29 FB AE  4B 47 50 EE
  03 0E D8 A7  B5 14 70 A8  9E D1 1B 45  F0 F6 C7 00
  CA 97 2A 9B  84 BA 06 63  7A 28 A9 F6  C0 DE 2F 77
  63 B6 30 12  E3 FD B4 2B  D3 5D 3D D2  81 19 70 C2
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQO-PYPP-HTQI-JGSK-EK2J-PPXW-TNDZ",
      "Salt":"PswAhClZVUd-kxOhl4E7DQ",
      "recipients":[{
          "kid":"MC76-W4OU-INGZ-PG5U-TEOO-WOAV-3VGU",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"gP7OFu6N_Pvt8cmGFfTm05F6EsgyBHN4Y5HhSNDgN
  0s"}},
          "wmk":"hJz_kZ51-5yrtI5MpDQnHvQ5VRJ4QGIue2KGPkII9esK4x5S
  Sp9ZVA"}
        ]},
    "tgkdxp_p_DVrKfuuS0dQ7gMO2Ke1FHContEbRfD2xwDKlyqbhLoGY3ooqfbA
  3i93Y7YwEuP9tCvTXT3SgRlwwg"
    ]}
~~~~

## Signed Message

Signed messages specify the digest algorithm to be used in the header and
the signature value in the trailer. Note that the digest algorithm is not optional
since it serves as notice that a decoder should digest the payload value 
to enable signature verification.

~~~~
{
  "DareEnvelope":[{
      "dig":"S512"},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBs
  ZSBibG9ja3M",
    {
      "signatures":[{
          "alg":"ED25519",
          "kid":"MAWV-ICLF-JOLB-LW3P-XTRD-4CRE-HS3J",
          "signature":"aPPvx7jYFC44XO9BYLT1tQORUCqSP7p5O3UsqA03kt
  GopWUZkek9JXyQtsqQ6JvFwUUCA1eFaDMPro7CzRMrCw"}
        ],
      "PayloadDigest":"raim8SV5adPbWWn8FMM4mrRAQCO9A2jZ0NZAnFXWlG
  0xF6sWGJbnKSdtIJMmMU_hjarlIPEoY3vy9UdVlH5KAg"}
    ]}
~~~~

## Signed and Encrypted Message

A signed and encrypted message is encrypted and then signed.
The signer proves knowledge of the payload plaintext by providing the
plaintext witness value.

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQA-RXBZ-FYC4-L4JY-WVPP-7YBR-7S26",
      "Salt":"M22azgOppsK_6tqAS2ZCLg",
      "recipients":[{
          "kid":"MC76-W4OU-INGZ-PG5U-TEOO-WOAV-3VGU",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"bErqrChtgcdLelLZoCL-jSnKqAp3WdPmaOzsel0Xj
  -8"}},
          "wmk":"-b2dpCMahNH9GNq8Z2HFfpaJzfrb5vAbLjgbOL6EtMWoQEgE
  eXZrrA"}
        ],
      "dig":"S512"},
    "PHCJD-4Zm3OV8MFUG5paDWPodZRn1BFMd6XWQ0Jj9EO3elqdXRHFDDqhOSJW
  LJCZHN7JWSJHbOnpl-3XnkmZ7Q",
    {
      "signatures":[{
          "alg":"ED25519",
          "kid":"MAWV-ICLF-JOLB-LW3P-XTRD-4CRE-HS3J",
          "signature":"gDLIwa4fuv5yD6S35T8HCP5l-qG-dHXHmP0u_7VaMW
  1dOnXE5hZCd3I8ixj9yhqL0Auj6ZvMYt4RwdSVWzsRDA"}
        ],
      "WitnessValue":"18h5LhE_irwzwzUbq7dXnlNj-5TxnGhrurx14K7eYrs",
      "PayloadDigest":"g1dgc5pDNqqJXF-uYxlNxHmvht8JE-74ZEmEVUPgSI
  1XOG6Rer6wVIMtqRh1jaXHByaWok2FrjZz2UIVVs6ivg"}
    ]}
~~~~


