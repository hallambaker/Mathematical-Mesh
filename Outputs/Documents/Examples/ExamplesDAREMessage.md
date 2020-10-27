
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"V3TwVnystorrwiy02hL1Gs3cPeBfRe-ukyF0gkjq2h4"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"Y2ewEdEGRZ2VY8VyX1zstSrkkBCIJtgSlwQvKzceHtg"}}
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
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M"
    ]}
~~~~

## Plaintext Message with EDS

If a plaintext message contains EDS sequences, these are also in plaintext:

~~~~
{
  "DareEnvelope":[{
      "Annotations":["iAEBiC1TdWJqZWN0OiBNZXNzYWdlIG1ldGFkYXRhIHNob3
  VsZCBiZSBlbmNyeXB0ZWQ",
        "iAECiAoyMDE4LTAyLTAx"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~

  7F EC FA 28  9A 0A 55 8F  FB 6B 07 64  20 84 84 61
  91 74 C6 6E  2B EE C7 78  D5 A4 FE 1A  46 DE 05 80
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"JuWwUveqKmc0-Z3HNJ6i8JJF-B1LzwnG0i_dJfFKfqQ"}}
~~~~

The key agreement value is calculated:

~~~~

  AA 7F A3 DC  A1 C9 9F 2C  F6 D0 9D 4E  68 A9 CE E0
  5E A9 DD 8F  20 84 A3 53  7E 67 C6 22  38 94 7C E7
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  1F B5 66 FF  3B 05 AB 49  4C 55 40 25  69 7C BA 31
  32 DB DA 6C  EA 02 A7 43  60 5F 90 1F  BC 29 06 44
~~~~

The wrapped master key is:

~~~~

  EF 2E CD 93  92 B3 13 F3  A8 69 45 A5  D4 F9 0A 4D
  38 FE 77 61  5A CE 5B 43  D1 73 09 4D  9B 4B 80 D5
  30 8C EF 42  81 BC D8 9E
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  13 50 3A 14  91 C6 32 A2  FC 78 BA EA  78 5E AE 59
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  4E 4D 0D A5  9B 58 CF E2  EF 2E 98 3F  AE 47 47 FF
  DA 72 CF 0F  E2 3F B2 C4  41 38 0F B0  78 CC 9B BE
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  93 ED DA 51  EE 3C 66 E9  01 8B E3 5E  32 B1 A3 5A
~~~~

The output sequence is the encrypted bytes:

~~~~

  F0 C0 17 A8  5D 8C 35 6C  05 11 7E 5F  75 41 A4 74
  DE 02 A3 BB  7D 98 27 CA  5E DD 0C 87  6E B9 FB 1D
  D2 5C 9E B8  8C A3 7F 44  71 24 47 A6  40 D8 F8 22
  3C EC A4 95  15 DB 20 3C  04 74 46 D1  CE D6 24 67
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-LUTX-CMHL-5GTJ-46AY-A7AJ-KNZV",
      "Salt":"E1A6FJHGMqL8eLrqeF6uWQ",
      "recipients":[{
          "kid":"MBZZ-VZFR-KNGP-WODA-RXJF-YUZV-S3GS",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"YttbWV-_6I0cJfx2kYkxPXqiAi30BvE-d2r8-NJFss4"}},
          "wmk":"7y7Nk5KzE_OoaUWl1PkKTTj-d2FazltD0XMJTZtLgNUwjO9Cgb
  zYng"}
        ]},
    "8MAXqF2MNWwFEX5fdUGkdN4Co7t9mCfKXt0Mh265-x3SXJ64jKN_RHEkR6ZA2P
  giPOyklRXbIDwEdEbRztYkZw"
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
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MB2S-HQ7C-5HRP-DIY4-AMLX-QANT-XVB4",
          "signature":"oDel-I3koGsjXyP-m1P_vdDDQ-w1x6ewnwLKsL8mOBeK
  01BDoDATQHD37HYTG7rUiL_12tyZGRVSN3RMVYfmDA"}
        ],
      "PayloadDigest":"raim8SV5adPbWWn8FMM4mrRAQCO9A2jZ0NZAnFXWlG0x
  F6sWGJbnKSdtIJMmMU_hjarlIPEoY3vy9UdVlH5KAg"}
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
      "kid":"EBQA-5VKH-RI7J-VZS3-2PGK-F66L-6CMI",
      "Salt":"mG6MzeFRbJKHtGSCV6Zarw",
      "recipients":[{
          "kid":"MBZZ-VZFR-KNGP-WODA-RXJF-YUZV-S3GS",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"HDM6sNZREivjBc75SB2cWHTvJSIF-Z_bj_1zASz8nNc"}},
          "wmk":"ry3kUQPHa56bq2T6POIf4w4fNRCV-MPyUyzqwW-70ymoCQ-gQE
  aaYg"}
        ]},
    "aEvZDCZzLkG1V-AOYRtMNBokfWgRRh-L_tTvn8v7lfrS7LsZ2cEjM2mRQE283x
  mk-wE7XrnIggEjduR2jcWkcA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MB2S-HQ7C-5HRP-DIY4-AMLX-QANT-XVB4",
          "signature":"4uH3m1x_le6S04gdum0vEjJJNbX7pUL3XCcUVag_uJ_E
  iM6tRWfblNUg5EqmAvT_wHJeuQUSJiXGjF5AJAXLDQ",
          "witness":"suV0S7PJa20J65NmfApfP-aBH52amvvAx0WKcl6Jsss"}
        ],
      "PayloadDigest":"xtYd4xDAlzUpyBqtMfgFP83UnIqCasQW0qCdxC11C7jZ
  METoCKPjx9RJYibH6aSP4pCv0Dh65POWgmdBCuODYA"}
    ]}
~~~~


