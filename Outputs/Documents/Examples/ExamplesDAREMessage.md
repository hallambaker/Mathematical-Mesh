
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"j1ht2_IwXJt9luQkmAXOrgp4kQstc6b0SRt8Bow6etQ"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"x9C64nrGICIHvvAYI3e-h5ZfRf_ExhImfhSSj5XCx8Q"}}
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

  00 DA 2D E8  49 7F D6 1F  B1 62 66 A9  A3 CE 50 31
  95 BE 92 DB  41 8F F5 2F  29 C9 84 F6  63 DA 5E 8B
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"6vQOw_mYhLNSBCpx0jEx55TaisVjSR85TJA5n1ASZrU"}}
~~~~

The key agreement value is calculated:

~~~~

  28 46 CB 29  98 DA 0E E9  F8 76 22 21  F5 D1 71 33
  5B 5C 77 DB  0C CC BF CC  1C 9E FE FE  13 C5 63 EF
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  A4 1A 7C 41  75 07 CA 12  F1 F9 B2 50  08 69 AB E3
  EF 2E 0A 25  01 46 B1 C6  E9 56 BF 76  A4 20 DC BB
~~~~

The wrapped master key is:

~~~~

  EB E6 9A 2E  1F 39 88 FE  39 83 DB C9  3B C0 AE 5D
  0F 2F 04 63  D4 2C 5E 9B  23 6D DB 1C  D0 83 64 7B
  67 D5 79 8C  3B 30 32 11
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  F2 82 F7 D0  EF B9 32 51  B7 CB B1 00  34 A7 C9 0D
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  65 66 1E FE  58 1C 3F 95  B2 78 D0 FC  07 5A 03 87
  01 A8 5F B5  CD A4 4D 00  74 23 A2 43  2F 6D 8B 9A
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  B0 FE D4 4A  25 27 81 26  88 CC 80 60  A2 90 4B 05
~~~~

The output sequence is the encrypted bytes:

~~~~

  BC 1C 3B 02  3C B8 9F 6C  48 77 FC CD  D1 1D C0 F6
  F6 9E 64 44  77 4C 9C 09  25 F4 8D 34  15 11 0B 66
  BB DA 91 38  DC 35 69 68  BB 93 85 B2  D2 C2 5C E0
  CD 84 60 B9  4B E9 78 CD  8D 57 F1 B8  07 8C 63 60
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-O7XU-LUZR-WQ7M-E7WN-6TV2-IAUQ",
      "Salt":"8oL30O-5MlG3y7EANKfJDQ",
      "recipients":[{
          "kid":"MDN4-UHD2-ZAI2-64DP-5JAM-Z3O4-VYJ4",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"IqxgA6h1cCIQzFhdmegOm8bl6rGXWKeKzAXIKdg7BQw"}},
          "wmk":"6-aaLh85iP45g9vJO8CuXQ8vBGPULF6bI23bHNCDZHtn1XmMOz
  AyEQ"}
        ]},
    "vBw7Ajy4n2xId_zN0R3A9vaeZER3TJwJJfSNNBURC2a72pE43DVpaLuThbLSwl
  zgzYRguUvpeM2NV_G4B4xjYA"
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
          "kid":"MBOF-BSR7-OTN6-PWLV-LOYX-FLNT-AELH",
          "signature":"g8Qz-qN-Nrwuad3_idXV7EGBaOSH-M1NivUUaL-kU_Yx
  ZFg6VgeYzmZ13ng67xLS0pVjHSxaKvq9AZosFJFRBA"}
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
      "kid":"EBQA-HFLG-7D2P-Q66Y-PXDN-SSXT-MHCG",
      "Salt":"LunUHY16rzdpVQSiA_EmhQ",
      "recipients":[{
          "kid":"MDN4-UHD2-ZAI2-64DP-5JAM-Z3O4-VYJ4",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"G0Mu_CYedN4FTLmJziHDhgWVGRYMD-PNpsTcESZKzS8"}},
          "wmk":"RXUeLV8jbBy2L2ik8GkSQriDXsEukoq64uudYS8UfO_WQXWjYA
  nX9Q"}
        ]},
    "9z7cGvs7jlE6IfgQEJcaybmUStUm9wjAl4Zc4VwVQ-zf4eCdf4NUZXTPxXU7S3
  VRVw8IEDxFsoO2DxRZKwLgYg",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBOF-BSR7-OTN6-PWLV-LOYX-FLNT-AELH",
          "signature":"w3ogUyFiEUl9T0JdF7EI8MqlXVwDuTkkt_f22K-BM0A9
  Cls_u1Bq8U-jhZE0_6ouCpIPNTdyKyjOKqNwsvdwAw",
          "witness":"qhQIbXKoTVVYI5hTfeUdNwPnP9Q__NpOYrwijZUKfZU"}
        ],
      "PayloadDigest":"EaqMKfgD8atRTZyd9xv_5bV-Rv77khPJNZyR79_QaqEN
  6kNHbedtCJfW7AldaRnSKQ3-vn0qQDFQMbItw4L2uQ"}
    ]}
~~~~


