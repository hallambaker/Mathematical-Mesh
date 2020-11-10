
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"yrnMxMfmJ3U87gmJUOo5muG5oTejfnmWNHSsH1owRQw"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"5yTNPn1wEIRwmULR2PIwGuWr61YKzTVYeYloF4ISzbo"}}
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
      "Annotations":["iAEBiC1TdWJqZWN0OiBNZXNzYWdlIG1ldGFkYXRhIHNo
  b3VsZCBiZSBlbmNyeXB0ZWQ",
        "iAECiAoyMDE4LTAyLTAx"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBs
  ZSBibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~

  3E 53 F3 35  C2 76 C9 FD  19 F4 AB 42  1B D7 40 4F
  8F 18 30 47  94 F5 04 6D  74 6B A4 F4  2F D5 7D 47
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"Ulzd_tGYLGxmRtURUqnHLFLlTRSmJXDpqagnbTH5k-c"}}
~~~~

The key agreement value is calculated:

~~~~

  64 E7 53 3E  4B 76 5D 01  48 38 B2 1C  4D FE 4D E6
  A0 E3 80 36  56 F1 74 27  99 58 EA 14  D6 20 D3 32
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  25 EA DB 00  EE B0 88 65  69 92 CC 87  8B 4F 32 F6
  EC 56 E4 83  4E EF 8C 88  51 9E 4D 19  64 74 D2 F5
~~~~

The wrapped master key is:

~~~~

  BE 15 51 61  B5 C3 6B 69  AD 16 5B A5  04 8F 98 0C
  38 AC 1A A0  E3 EC 6D 61  E0 5E 37 07  59 52 0C 0D
  A9 B2 43 CB  F9 59 7C 22
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  FC 0F C3 87  9B DB 5F DE  91 A6 6D F3  A2 BF 39 5A
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  28 9B BB 67  59 95 7B 2D  9C 8A 8C 4B  7B BE 1E 51
  86 3D 07 54  81 54 2C F9  5A 0A 1B 2E  02 92 31 2C
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  FE 4C DB 01  F8 A0 B3 87  5F E1 DE 26  37 90 47 5C
~~~~

The output sequence is the encrypted bytes:

~~~~

  87 FA 1B 47  17 9E 5D 3E  88 D6 43 25  27 BD 5D AA
  D6 0E 9E EE  0B 13 DB B8  3F 56 6E 9D  70 8E 13 29
  EE 30 5B 4F  43 1B EE 1C  BB E6 D3 EA  FF C9 76 3E
  53 0D EC 65  A0 74 97 A6  A7 90 7C 55  71 59 03 60
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQO-7UQG-GCYI-4HAZ-XNUB-BB23-75PJ",
      "Salt":"_A_Dh5vbX96Rpm3zor85Wg",
      "recipients":[{
          "kid":"MBJX-GGAM-BXKQ-B2MM-KE4H-ALKP-BOQG",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"ggxui2EDuD2WAeYIM_sQw4Z_e7yIIWRLrhr59uU3X
  1w"}},
          "wmk":"vhVRYbXDa2mtFlulBI-YDDisGqDj7G1h4F43B1lSDA2pskPL
  -Vl8Ig"}
        ]},
    "h_obRxeeXT6I1kMlJ71dqtYOnu4LE9u4P1ZunXCOEynuMFtPQxvuHLvm0-r_
  yXY-Uw3sZaB0l6ankHxVcVkDYA"
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
          "kid":"MCJ3-I23J-QAZP-3774-744C-EY6E-QTQN",
          "signature":"HjtGgur3w1u210tQI2-_YegZmlzT4eNe0G4lZnkIgN
  udRvhMNn7C3Cx3R58vcPab2gJn0F-3fS4_D1z6hhORBA"}
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
      "kid":"EBQK-636J-WODP-4YSF-IT2M-DOL2-EMFF",
      "Salt":"4xfpUiRFYdntT2RmMM6X2w",
      "recipients":[{
          "kid":"MBJX-GGAM-BXKQ-B2MM-KE4H-ALKP-BOQG",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"C9FekzCAYw1l7NVRe0xQX_YR85OKAoDTaIvKc9Ru2
  KQ"}},
          "wmk":"4BtI7LnK_lVRs9TbIxaqYBJI2p01uNHwLBR90y4dxdV5bUi4
  _jVb0g"}
        ]},
    "sJoYSUxiTWg_sqcZOZ7mCKhWNoWduUM0LNcEw3jy3vzm20WmIK9kiHgrk1s2
  N6zByhdGp9gLg0LgRdzNk5-q3Q",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCJ3-I23J-QAZP-3774-744C-EY6E-QTQN",
          "signature":"G0R2QCbz2LxPDv-qR2_5rH7qaEFInyCEM9MwzgsieX
  YA-U8KY9YfCxgjSNAt2DfKq-Skkw-qWtnX3SZGFE7XBA",
          "witness":"gBpRN0oZwYC5NS2B0U0x_K6dwbtE-8M8ob_dq2Pto3k"}
        ],
      "PayloadDigest":"gdPPJ3vzDed1tX1fO7U-WOly8IyCZ8Nfgwyj3Ay5Z-
  XrbB3FzL0PBOjjROGVA_SVMqr4hNq2fQEpaA9C0ZOE3Q"}
    ]}
~~~~


