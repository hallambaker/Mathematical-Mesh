
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"QuDRQifkzIolNvLMl6BCxzDb3F_jH-TqQ7mUugWKk88"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"nxmXSFWqjU9m4nA13rTCL0XxoaLiLTWphS_hSwlAHSo"}}
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

  48 F5 D9 60  D7 41 C8 E8  94 FB 36 70  90 52 6D 7B
  6B 6F 17 C4  74 73 B7 A2  8F 3F EA 74  4B AC 1A 72
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"irzVbOTf41LzVHGZpOoZ75ymfXJMEGS4xYuCzwOkpSo"}}
~~~~

The key agreement value is calculated:

~~~~

  B4 19 C7 AA  0E CF 07 87  A5 76 5E 6C  AE EF 33 42
  08 D8 7E 14  4C FE A7 B7  22 CD 5F 9D  09 7D 65 4C
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  72 D0 EC 1A  18 97 43 91  6B 86 45 63  D1 89 DE 9E
  30 0D 15 77  F8 FE D7 B9  D1 04 92 94  6D 77 40 C9
~~~~

The wrapped base seed is:

~~~~

  67 9D 02 2D  F5 91 1E EC  2D A1 4D 4F  5F 69 B1 E0
  52 C3 A0 08  BE DE 7B 1D  3A E5 DF 6B  B9 0D 76 A5
  CF 45 F7 26  A9 13 5D 3D
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  16 36 49 85  54 6A 86 C7  76 2E 49 F5  07 71 5D EA
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  49 4A 25 16  5E 74 C5 1A  59 A8 59 B8  D3 C8 08 9E
  E8 E8 A2 9B  05 E6 FB 02  7C 8A 38 04  A7 98 88 2E
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  F1 16 C5 6B  0B D3 DB E1  E0 5B 6C AF  53 A3 E2 BD
~~~~

The output sequence is the encrypted bytes:

~~~~

  D6 5B 3E C1  96 30 74 4D  FE 46 5C E4  B9 17 38 F9
  A1 C2 8E FA  94 13 4F BF  71 4F 76 E3  CB BD 31 28
  9A F2 8E 43  DE F3 6F C6  38 5E 40 6B  73 EC 9B 63
  90 2D 61 60  E6 86 CE 27  7E 4F 3B D8  91 D6 18 ED
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQM-VCAO-5XPB-E75C-QVKJ-QPFC-74B6",
      "Salt":"FjZJhVRqhsd2Lkn1B3Fd6g",
      "recipients":[{
          "kid":"MCV2-Y4W4-4BHT-HXJO-7IC5-WYB7-E6J4",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"NWSrilzygV1_R-61sgRzVzk1y0X33HtHKD_HWevUn
  uY"}},
          "wmk":"Gzyq8Jy1lITvI9_tmqfHPRVOEzp9iVn-OP1c97RA2FIWGnVd
  q9Pi0Q"}
        ]},
    "1ls-wZYwdE3-RlzkuRc4-aHCjvqUE0-_cU9248u9MSia8o5D3vNvxjheQGtz
  7JtjkC1hYOaGzid-TzvYkdYY7Q"
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
          "kid":"MC7H-ZNHI-U5QX-SP5R-IBYV-QYIN-DXOT",
          "signature":"sSTI6xFGTdoZSHB10gZEeAZffhNW2p3RjvIo1gSW09
  3kZzzNz3oewhsqrPT6DB5JIPRE79cnPjkoIplq0IquAw"}
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
      "kid":"EBQC-S46W-7HAZ-ZBI4-F4SQ-DWU7-XQMW",
      "Salt":"LN3FrwIb7tVaoN7p9xvGBw",
      "recipients":[{
          "kid":"MCV2-Y4W4-4BHT-HXJO-7IC5-WYB7-E6J4",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"lGJpHKTvX8DsGOYEeeUrYqjVxlh_EHP_pN8DTF1TC
  k4"}},
          "wmk":"xNRRy9KlZWamYJVol6RrSEbTInUNqqfveCSJIKqXdwQP_hDU
  ISjwlw"}
        ]},
    "gyAJc_Mes1a3hWFv1u1ZGYAcmG7K_L2ItzNRfNqnkf2_qYUSy9cm56eiaEMx
  PL23KQhCZW80dQxFjaazSmfJag",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MC7H-ZNHI-U5QX-SP5R-IBYV-QYIN-DXOT",
          "signature":"9PPcQ6Xlhe6E6rjTPyo9C6Hh6HhnUfevZTgbAdI5aL
  E8nqTxQpQwPY0DA9R3vJIsI_0nMTgVULGkRsTQ__z4Ag",
          "witness":"KLZb1V5gxCWXnmeU4A0wjuxbWIVgKjZnawawmLQu680"}
        ],
      "PayloadDigest":"9bQM9b4hyjJbaJ7I1DBipLFxPjYhBLouZg5HgWhezS
  P0pU0qFV1Kv8qVlhSCmD8MYTs8dfLjHgOun3qSyvsO0g"}
    ]}
~~~~


