
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"6o3XJvRF5WrG4-DY3hBG_qPb3j5JiAvWPfts3VhdQeg"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"3JhYW8Q2YHJ2_cPjLYOLbzprvecQi4xsfuat0eOKLxw"}}
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

  60 14 70 EB  98 22 EB 47  61 24 46 E2  C8 F0 86 31
  95 DD 37 38  C7 08 08 8C  1F 16 05 EE  B7 CC F3 8B
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"c3B3RFkR8tSm71a0nzZmHbWHgPPtrjGdu6ZB21NjBQ4"}}
~~~~

The key agreement value is calculated:

~~~~

  D5 CB 99 BE  FC F0 BA DF  FA C5 9A 29  6E AE 8F DB
  76 4E B0 95  76 F1 03 36  E7 1E 78 DA  FC 8D EF 72
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  3C 79 76 F7  22 61 62 CB  2B C8 98 31  16 75 71 39
  CC E3 9E 6A  25 6C F9 21  A9 6C 58 F2  DB 97 23 27
~~~~

The wrapped base seed is:

~~~~

  41 9C 2D 1D  05 33 5D 2E  AA 96 2A 46  BE 34 21 CF
  FD 06 8C 73  45 57 6E EC  01 43 FF 9C  F7 F9 BF 14
  C1 25 BB 71  51 B1 25 F9
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  6D 64 72 61  7D 48 99 D4  04 F2 36 7F  DA 78 E1 8D
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  84 7F 2C EB  72 4A CB B2  0F 66 21 81  30 76 43 06
  4F 63 80 B4  F2 68 68 EB  CA 7B 96 B7  FC 04 DF DC
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  A2 87 C4 F3  FA 8A 89 5B  4F CA 40 6E  BD E2 E5 76
~~~~

The output sequence is the encrypted bytes:

~~~~

  5A 34 06 42  1C 6A 5C 4B  BF D7 44 43  4B F8 A2 B7
  3E 56 65 27  AD AC 98 B1  07 59 2F F8  43 D5 A0 53
  13 A1 BB D3  90 76 FB F5  1C 30 58 FB  0B 06 67 54
  7A 66 FB 1D  43 50 3E C5  21 15 BA 79  AB 96 C1 1F
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQG-J7ZP-4NPO-BS3J-YFE4-3YPM-TICI",
      "Salt":"bWRyYX1ImdQE8jZ_2njhjQ",
      "recipients":[{
          "kid":"MCZG-SJCC-WPAU-MNRF-6TCG-KUUQ-ICAQ",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"5DmkW-Ieh_XdDKRYKi-_4gPeH3QwdNZ4BYajMsxdk
  e0"}},
          "wmk":"8-F2jDSBxmuCE2iYqP-BVcZiZUKcE8CrL3Vxis_487W-xjUx
  3b8F-A"}
        ]},
    "WjQGQhxqXEu_10RDS_iitz5WZSetrJixB1kv-EPVoFMTobvTkHb79RwwWPsL
  BmdUemb7HUNQPsUhFbp5q5bBHw"
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
          "kid":"MCQU-ONOR-SMME-AJM3-4RNU-2EDR-KWX4",
          "signature":"NthXHWAJ3b4r9ulhG5VRzcH3d-_RJ7PlT7F9wzD-dr
  XFLFVTUfrvuXteEuBaE4-9c-DLWGc_pIc9eGLjXBB9Dw"}
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
      "kid":"EBQE-FQSV-HURW-44LI-W7E3-4HMX-AR37",
      "Salt":"zel4BwvOFCzTs6BrNL0yzQ",
      "recipients":[{
          "kid":"MCZG-SJCC-WPAU-MNRF-6TCG-KUUQ-ICAQ",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"bYxb8Q4_gnY3CKnppk-82V33DHseB_caD8vu7s8wT
  40"}},
          "wmk":"hiLLca5zdVe8BFkT8n5dPxNOlDa5l4bhCXnjFRvSil9J19g7
  tnwMIQ"}
        ]},
    "KlaXVXwrVm1t5xny6xD8U1qAvOo6Iaw1uPV_7-XvmplQCU5sGT9kyZ6Xay3H
  AKP3gJ8CsxriOvxZjMwnwn4OZg",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCQU-ONOR-SMME-AJM3-4RNU-2EDR-KWX4",
          "signature":"9pXy6nHEzFjYSohDG9lR1h2ml4bvHGz6jGbMzCm_dn
  8ANcNZR_E6K7JM-sTexlooTgmdMKflGylCvqNJFiyNAA",
          "witness":"eqhzn-rVajjxuYGTjpOVNjJOOkeGiYa5E9iUnSr3wSg"}
        ],
      "PayloadDigest":"HNflV2DRiLjMWSWfJ5VZW7oeXA5YxmDuq0MN9F5rCG
  Kwh58BoxTE7CNyH85Cv4EH6-fKxtlmJayUmS4oxTv0Pw"}
    ]}
~~~~


