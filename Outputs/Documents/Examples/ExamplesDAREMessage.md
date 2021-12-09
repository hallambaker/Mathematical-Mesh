
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"C-3cHR6YUzvtwsJ3UiXwNPx9SL4Pd7d4jAp_-TNZjbA"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"VGSwyDlvmob7n1DlnnC_TCTNkfY30mAwYSd9ZnzU3P4"}}
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

  99 A3 E4 99  CD 6E 40 5B  C0 3D 25 42  B1 B0 98 84
  05 8E 3E AF  9A 73 DC B2  0F 3C 66 E2  35 9D 91 86
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"JFs9s_q-HXnq46UN9bHhPG9G5j080-VsqOlqGQnOylE"}}
~~~~

The key agreement value is calculated:

~~~~

  93 BF D0 A6  B9 4B B4 33  0C 7B 78 15  53 4F 98 65
  9F 48 15 98  D8 49 19 DA  FF 16 44 83  53 57 E2 9A
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  7E FB 8F 0F  6C C1 08 95  70 98 7C 11  AF D1 DD 42
  60 9E 72 43  63 F3 1D 0E  BF 70 1B BA  FD 14 3E BC
~~~~

The wrapped base seed is:

~~~~

  AF D7 AC CA  3E C9 97 77  D3 94 95 1F  69 8D EF F5
  52 E2 46 29  A1 C9 40 0B  A9 52 7C 38  8A A7 97 E3
  65 E4 8B 76  E6 A1 71 F4
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  67 DA 49 8B  CA BF 94 5C  0B 08 F7 35  FC 5B 58 B9
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  46 6D 37 CA  80 5E 8C 24  7E 03 C9 4F  F6 ED 3F 24
  5C 47 59 2A  E8 FD E9 8F  EC 88 F4 6C  40 AE D1 12
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  25 64 3F E9  E8 FA 15 F4  D2 74 8C 91  05 7E 48 87
~~~~

The output sequence is the encrypted bytes:

~~~~

  DE 7B 00 CF  67 33 7B 39  8A 74 45 47  20 78 AA 98
  51 77 0E 7B  9F A5 EC 03  AB F2 90 37  2A ED 97 3D
  49 49 0A 10  F8 39 E2 EB  FD C5 B1 57  CC EA E3 31
  61 E2 19 7C  AB BB EA 89  28 CD DE A9  1C 87 81 BF
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-5QND-PTLB-UV3U-RWZP-U7DW-BCJL",
      "Salt":"Z9pJi8q_lFwLCPc1_FtYuQ",
      "recipients":[{
          "kid":"MBWZ-WJJH-XO63-6ZXQ-CPE2-D5CQ-HW53",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"G7i3coByLB9jcVUSVkvs7slgGjKLY_cnHiOWxf64S
  go"}},
          "wmk":"Cz8RSYrWdwICJi7IQQpZTdRIQXrQpd--u3s2lNZt3BKMYR2A
  oTpfpA"}
        ]},
    "3nsAz2czezmKdEVHIHiqmFF3DnufpewDq_KQNyrtlz1JSQoQ-Dni6_3FsVfM
  6uMxYeIZfKu76okozd6pHIeBvw"
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
          "kid":"MCFV-JXDG-N5RY-ZHNM-VHYQ-DU7F-XERW",
          "signature":"pktqBYIF0Z-PctciD7mZ_69CLYTEzWQrLK1IK7_Uon
  PY2VIL96Sh-G5bOo1YgsTZoR5GhKht0fcWx_72-Jm9Bw"}
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
      "kid":"EBQD-MFU5-GM4C-SKAO-S2MU-FXEU-REV2",
      "Salt":"XNqO3SQaZXnkzL2vzpOC2A",
      "recipients":[{
          "kid":"MBWZ-WJJH-XO63-6ZXQ-CPE2-D5CQ-HW53",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"JuunKpaUAQBNLKG2DyJCL4VQz5WEfN0_S0289wKD_
  5k"}},
          "wmk":"DhCVt4GSB5zWtedSwYnLmxD-BxzRa8xt5Bk2N8tITyq-5npn
  SMRUig"}
        ]},
    "XmsgwQ5NybCZzenhNho1-CtnuYkKZB8lR2Nc2sVc1Tg0vp_skj3S9Cz07VHI
  cPv3fCkcjt2Rpr1pBwrJLSW24A",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCFV-JXDG-N5RY-ZHNM-VHYQ-DU7F-XERW",
          "signature":"CLdnEQhEkLEA3C6dMTIACyMlG9TBX15wlKzajCXf-f
  lZzxsf9WIJj5ySEBmQiFxjRmLmqFXn_KXOMDet3lblDg",
          "witness":"aNoAtOL_3LoFAoJAoC_BjPSwIdQsma5yTHPRiYFa87E"}
        ],
      "PayloadDigest":"VtzFXbn7sOjbLinh34AVGIfnS-n17OqXbtmgaCAJpY
  PYHMetYH0WyKTBAiqOIGFkH5lZhNyagyfpqaJS0jKfXg"}
    ]}
~~~~


