
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"KSing7HKR2HTk13MiKOTTKCm76vDLjf6tTyfh8ocpOM"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"g4_4t5VgOaCZnfCv8N7i_wG47yAevHlV28qAQTIIq2U"}}
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

  E7 ED C7 9B  8B 83 9B 7E  82 FF 4D CD  46 43 D2 5E
  7F 60 65 40  8C 67 E8 2C  A3 65 95 BC  C2 14 4D BC
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"z_Vizuuv_UChMsxpbjdMChqoUrHpB6WI_q7gDqmKuNg"}}
~~~~

The key agreement value is calculated:

~~~~

  CE CE F3 F7  3B 2E DB 9B  BB ED 85 EE  54 EA D4 5E
  F8 4D 05 FC  60 50 D7 5E  64 14 96 71  94 B5 FC 99
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  35 09 16 78  5B 64 F4 CF  8D 9A B8 E5  0A 74 EC 3F
  E2 C2 5C 75  AB 9C 78 CA  1B 72 E5 F8  05 CC 32 30
~~~~

The wrapped base seed is:

~~~~

  E2 DC 82 BA  94 5A 70 A0  2E 3F 42 3B  30 98 3B 37
  9E 7C 4F 8E  ED 3D B6 4D  F6 30 BF 5B  CD 80 43 53
  57 43 D6 73  E2 48 F3 88
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  82 5B 0A C8  DD 47 3E E4  3D B0 7C F5  51 9F 02 82
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  11 C1 B0 2B  23 7B B9 56  28 36 86 7E  6B FC 9F B8
  82 70 62 A0  FC 48 85 BE  00 B6 2D C7  2E 7F 6C 8F
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  C2 D7 86 12  A5 12 D6 DA  26 DF 2D B9  BA 93 4D BE
~~~~

The output sequence is the encrypted bytes:

~~~~

  8B FD 8C 50  F3 26 09 61  FB FE 72 82  06 DA B8 8C
  C9 05 68 96  4D 17 F3 E0  1E 7D B1 F6  BC 7B EE 11
  04 02 7D C9  54 A0 4B 2B  C3 59 ED A0  25 8D CA 61
  6E DE EB CB  99 AA C3 A5  D9 E6 24 0B  46 15 E3 D7
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQG-LO4H-B36O-VQYH-FAQL-4TTS-RRQ6",
      "Salt":"glsKyN1HPuQ9sHz1UZ8Cgg",
      "recipients":[{
          "kid":"MCBO-GJDS-ZSKH-YCWA-WAIQ-W2LI-Z5Z6",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"SI3EejeDfGSK66NyAbZ8A80O88wOYN9DtCSK5h-Bz
  oc"}},
          "wmk":"AsQaHQTsRgsX4grjEaQ7mv9IylhA5KpRGTAu2Dgi0n479PAH
  _u7vvw"}
        ]},
    "i_2MUPMmCWH7_nKCBtq4jMkFaJZNF_PgHn2x9rx77hEEAn3JVKBLK8NZ7aAl
  jcphbt7ry5mqw6XZ5iQLRhXj1w"
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
          "alg":"S512",
          "kid":"MBML-OX6M-CIF5-5ZUA-G77W-YDIW-JYWY",
          "signature":"VKphwNgVg1bVxeXefrgI4ecUMxooJQQpnv-WbbuDmZ
  3BcNiGzWYXtHyyrTcuLtDIXzejca8zCQ4iYFJEAXTLCQ"}
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
      "dig":"S512",
      "kid":"EBQM-MW4H-RTYX-UPXW-WZ2H-H5EA-S5DR",
      "Salt":"duNNYU6HurL5IZcZcgkcbw",
      "recipients":[{
          "kid":"MCBO-GJDS-ZSKH-YCWA-WAIQ-W2LI-Z5Z6",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"JWSApyvexjduYMiyU6j98IM9Y2OLd2Ur1PU_0xLuE
  -8"}},
          "wmk":"zf4kU0uqZERgTwudPYoOykNLHq7RTVwtNV1jFbZPmxxJvkb9
  F5NK4Q"}
        ]},
    "TFYCeL7IAJerJK17dSqR2QgAysrzmYWi5OY1QhPsiUfr0nlmlqg6DXMHKTcv
  xuorW9jXxctSDNM1VnNwuypbcw",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBML-OX6M-CIF5-5ZUA-G77W-YDIW-JYWY",
          "signature":"p9mQAypz788GEUmyZlDHbIEAFjbQ80rKRtpOhx4-3h
  tgYDBpEnXZL4VFgZL4BjTFowYlEkIsKd7tpoHFh-6WBA",
          "witness":"HZ537gu-LX_VFamEYzq2kkFLg704aGqlrilmAFP8PrU"}
        ],
      "PayloadDigest":"0S-Mtyrc6N1sbd7_Liv10nW-z9mxRxxazVGIJYg3_p
  zPW6A-XNjLs0xS-bWMwqBIHlV0BXEnKGAo5Z1iwSh6jw"}
    ]}
~~~~


