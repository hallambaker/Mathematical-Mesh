
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"_GJlr_xKPCwsqH_EmXN1u9i060rZXo0TYk9KJ1SXedc"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"sOgIs5LQVtcvQgJ8gYi9fXKaUd4Gn1sggft453CYUcI"}}
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

  01 62 79 57  C4 1E 07 7E  9B CA E7 CA  EF 04 DC 43
  92 EC 0E 24  EE 8A D2 05  C9 CB AD F4  F9 A5 E9 1D
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"kz4929TIsUQknUSGT1I0rwzlDB3cQ2UPWVBNP20551Y"}}
~~~~

The key agreement value is calculated:

~~~~

  8C FE 4F B2  A8 81 98 B4  78 FF 8F 7F  47 3F 15 26
  1A B2 DF 21  8B 3D BD 8F  5A 69 6A E3  39 97 F1 8A
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  6B 0E D6 15  13 6D 4C 3E  E9 13 DC 97  2E CB 27 B7
  91 BE DB 8A  FA 8B FF A7  37 28 43 65  0B AA 00 6F
~~~~

The wrapped base seed is:

~~~~

  7C 05 94 D0  6F A0 7E 11  53 2A B8 3D  15 BD 74 20
  46 36 BA 9C  63 63 0F 4A  CC 4C B1 3E  7B 9A BD 34
  14 C5 BB E3  56 0B AE 7D
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  45 79 E5 54  A1 72 52 9E  25 88 95 16  B8 AE A5 4F
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  9F 31 D6 55  8A 1F C7 BF  25 6B 92 44  2B 6B F8 81
  D8 44 42 11  F8 90 40 38  DB C8 9B 74  EB 18 C7 91
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  F4 1C 86 83  47 21 B8 D9  01 37 24 37  2F 17 AF 1D
~~~~

The output sequence is the encrypted bytes:

~~~~

  33 72 28 83  B1 C7 F0 39  BF FE 01 AE  4A 05 B5 E4
  E2 01 54 82  7F 18 A1 F0  C3 68 05 94  F1 CA 80 1E
  EF F4 F0 1F  D2 6E 65 81  5B D6 46 0F  AF 56 75 D5
  78 62 41 72  47 22 9E A4  07 7F E2 35  9A 52 30 8A
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQA-6KX3-CB46-AH7O-UQES-UPL5-7RHR",
      "Salt":"RXnlVKFyUp4liJUWuK6lTw",
      "recipients":[{
          "kid":"MCT7-AJMI-3MUH-YSXR-KIJL-OQVQ-MLZC",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"VYhKCuSYYhnnmKacZG6qZbUKYBWiI91lfEEfEKPz2
  uU"}},
          "wmk":"WD7HtaApkcpLZRERF2zKsFRfwKpVkGm2f1gI3ioyuzcNCSYS
  Wf7h0Q"}
        ]},
    "M3Iog7HH8Dm__gGuSgW15OIBVIJ_GKHww2gFlPHKgB7v9PAf0m5lgVvWRg-v
  VnXVeGJBckcinqQHf-I1mlIwig"
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
          "kid":"MAE3-AQPZ-IHZN-TY73-E5FY-3XX5-3NLI",
          "signature":"CUcjr2KkVpNbUZPvUcPrRFlfr5X98WvZ-_Y_hssNCi
  0AwAIgJzi39n5e8lw9Gkxm1UKFw6raX-Ca06QipdUICw"}
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
      "kid":"EBQH-URYZ-RFYS-RNPS-OZ4S-BFYF-W5DR",
      "Salt":"CQXeiAWvcYgTYRbet92ACg",
      "recipients":[{
          "kid":"MCT7-AJMI-3MUH-YSXR-KIJL-OQVQ-MLZC",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"fIoF-3DbRdvcyRlBVoPinsnZfdWJnmVg96f6mIXUa
  Xc"}},
          "wmk":"QIpMOQTN5gcLBr6km7x_mm396UR_Jzo0WbkOR_DfRv1FUtYi
  CUgWiw"}
        ]},
    "eZFD7csNEALoIcRNLqqmb3_vdwuOYSi9-gZY674Tkx_oVGLOHi8jh-iWEl3C
  _aXZIHqyh6zx4cKR1CpfPR4CxQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAE3-AQPZ-IHZN-TY73-E5FY-3XX5-3NLI",
          "signature":"_UTbRO8hGCcXqkCkqzJrw87ZbzZ4vWZtrgoOKg1FNH
  GcGwIXp80V0qRTOkZ4J8-zdVvfuMG4yArWtx5aR0j1Cw",
          "witness":"1d-O-16NfjeX5_rwQymgzj_-qHupHVTn71NhowJwsI8"}
        ],
      "PayloadDigest":"KK8P_JrGk2mxiF-ileUk221tXC8NpZEufBr-RHQ4nd
  t0Fx7-blPIjrd1Hro5vM2tpMcv6MODtU5dWNhqBV95Iw"}
    ]}
~~~~


