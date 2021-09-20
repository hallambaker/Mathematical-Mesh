
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"VMCg_d9MbEFJ-EcgN4WkC9OS7z1cAOuCqNZip9jdJtA"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"B4Ub8jcfDNa6Wo92JIWk366luKXgO1BPZfQ6mjuMKec"}}
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

  D4 B1 D9 2A  DC 81 82 BD  E4 10 B3 01  54 75 5B 10
  A2 52 A1 08  A0 6E 90 07  4C FB F8 7C  20 C4 27 BC
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"Gyjai6Lur6EhNnZqunhNmU-1_AOS4f1XiSHf8KURIM4"}}
~~~~

The key agreement value is calculated:

~~~~

  1B C8 49 12  83 4B A1 A1  7C 00 1C 02  62 96 22 94
  5E 28 CA B2  6F 4D 69 9B  E1 2C 42 04  23 CA 90 80
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  D1 85 D8 C1  BA B2 91 E2  E5 EF 8B 6E  43 61 29 02
  09 0F 8A F1  53 E3 04 73  A9 6A 5D 3D  05 AE E2 2A
~~~~

The wrapped base seed is:

~~~~

  15 09 35 4E  22 12 F1 F9  ED 94 72 F1  5B D9 2C 0B
  05 C7 F4 57  00 A3 0E 72  76 EA 50 71  A4 13 8C B3
  23 91 83 B6  68 5E 8D 98
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  93 E4 18 E3  2E FB 56 5D  89 80 3E 88  E4 A2 40 25
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  D9 71 72 5B  6B 82 CD AB  90 3F DB A7  AF AE F9 B1
  31 F2 3D BA  40 D1 94 FB  CE 96 64 14  8B 21 D6 15
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  40 68 6F 1D  68 49 A4 73  FF 7B 9C EA  14 04 BC 51
~~~~

The output sequence is the encrypted bytes:

~~~~

  7A F4 E3 6A  D1 C2 BB DD  71 1E 0C D7  F5 DF DF 25
  9A 3F EF FD  DA 09 4D BE  5A 37 5C E3  C8 36 42 35
  62 16 ED 79  C9 78 69 EF  9D 4D 64 3A  9F 33 67 58
  5F 57 6A A1  1D 06 84 2E  4C 0B D9 8E  F7 BA EF 8F
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQO-3OJW-CFPE-Y2ZW-WGPX-MFCH-FLIE",
      "Salt":"k-QY4y77Vl2JgD6I5KJAJQ",
      "recipients":[{
          "kid":"MBX4-C7IN-RYSD-LLTR-SESE-PRSR-3ODH",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"Af8ipH86YPN0ZxnOL9xAQF1sNuyaYDPkwYa55pfqR
  NQ"}},
          "wmk":"f8kVvKs8c84FeoULiH45Me0dVsKG6P4Z6zqNzMzIpWCmdOyC
  -w6toQ"}
        ]},
    "evTjatHCu91xHgzX9d_fJZo_7_3aCU2-Wjdc48g2QjViFu15yXhp751NZDqf
  M2dYX1dqoR0GhC5MC9mO97rvjw"
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
          "kid":"MAZZ-ERQX-HEOR-LHHV-SQ2L-XLXN-ZV75",
          "signature":"8td-DICoL2Zo8lQaKWR3Pt9DhnZarWFlXPJBDIk1rV
  juHGPu7Qx4pLktb0qSXv3sY69x17FIDr07T2eMUvGeBQ"}
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
      "kid":"EBQC-SSVB-23LT-M7VW-HMIF-CZO2-HJMC",
      "Salt":"i9m6Kt6sVITflERPuITPcQ",
      "recipients":[{
          "kid":"MBX4-C7IN-RYSD-LLTR-SESE-PRSR-3ODH",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"O1SrM1qtglXwIlIbWyrshl9SLgKPgz1Yu2NgQmDLb
  p4"}},
          "wmk":"0Bq8nmPDbgns0rI8RS_1AmdCGYV4gB4e4UQ1GS9eOuO3dAuo
  JsTyJQ"}
        ]},
    "kSui04nb8kjGYGzRLjwJqRGvc7v-8tudkv3c59kPWpfelI2J5Nu5m76iY2tD
  F65QydsAzKRm7Oov6Wi94XfQkA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAZZ-ERQX-HEOR-LHHV-SQ2L-XLXN-ZV75",
          "signature":"3CeneP-0xynucTYkbOkL9QwSmd2dpLxEaUGGtjwcHn
  YnMkRo_k4uiddUXgBbdN0os9nesjBzn1dGazdTIHgrCw",
          "witness":"dsxH972GUSC9UJfNuUZfMVW_4__SHorzZAQVLbRkONE"}
        ],
      "PayloadDigest":"tl-PBQ-VgYpmiS1adKAxq_MWivBhL0LV9mvXuJdqy7
  abcsLZGMAoZXjqOJaMfmGUTmB44trA-xOctU_aqijJ5Q"}
    ]}
~~~~


