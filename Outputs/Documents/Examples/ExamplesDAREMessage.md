
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"eeBzVt0pqTfjR86SpldtcX1QFgXM_mBiiDU4Oaol7Do"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"gdZNTLY77lyNxTwTcyQU4Y7fM01l3L-RGeNzLYXVJWg"}}
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

  FB 80 55 EA  E1 73 8A 58  BD 41 01 64  2D 63 FA 63
  86 44 C5 C5  DC 65 1D 28  33 B5 97 AE  C1 A2 50 74
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"eD7pE_1kacfka_A8y7PqKiWXNU5w5U29XOrc4_tCSNg"}}
~~~~

The key agreement value is calculated:

~~~~

  BC 16 30 D6  22 5E 57 54  DC 8A 8B 3A  19 F7 4B 62
  E6 F1 77 0A  12 16 BD 66  30 BB 2D 06  AF EA AA 18
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  A1 FA 62 DC  58 01 13 B0  9E E8 2C A0  16 C6 4A C4
  C6 07 9E 2A  72 05 73 B2  A2 6C D0 06  6A C9 6A E4
~~~~

The wrapped base seed is:

~~~~

  1D 77 B1 DB  19 88 F5 96  6A 1A 3A B7  41 F4 8C 6A
  72 7E B1 16  C9 9B E9 65  40 69 F5 38  0C 9E C8 CB
  50 30 97 D3  8E 90 4C 1C
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  51 5D 21 88  2E ED D5 9E  E2 DD 49 72  80 DF B0 F2
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  0F 89 3A 14  24 FA FE 67  8F D5 5D 18  CD AC 93 9C
  1D EF 30 F1  9E EA D1 34  3A 60 22 01  B2 9C 80 9B
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  AC 64 5B E5  0F AF B2 2D  52 F4 F6 4A  DD 2D 6F 73
~~~~

The output sequence is the encrypted bytes:

~~~~

  9C A3 F9 0E  AB 16 67 3D  42 9B C8 1D  5C 18 08 7D
  CB D4 8C 1F  3D 07 57 E0  2B 56 26 14  59 F8 3B FD
  76 AE A1 5A  31 8A 28 52  2A DB 14 CD  F3 0C 2F 8B
  DD E9 C7 F6  1C F2 10 BA  D8 9E 71 75  C7 F2 7F DE
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQM-HQC2-L3DM-UPSY-Y2VJ-B3EU-4YMZ",
      "Salt":"UV0hiC7t1Z7i3UlygN-w8g",
      "recipients":[{
          "kid":"MA56-GZFJ-N6CJ-DZTT-4SG6-TEAH-DYVS",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"AE56FrJyU0Zcrd8rkLuJX4lM6_QIGU5FufE_Si5v9
  tU"}},
          "wmk":"XrXng5Yy-q88XjSefXOUdsn9uiXSSUF9EmzgIu2p3C-iG4d0
  gamXFw"}
        ]},
    "nKP5DqsWZz1Cm8gdXBgIfcvUjB89B1fgK1YmFFn4O_12rqFaMYooUirbFM3z
  DC-L3enH9hzyELrYnnF1x_J_3g"
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
          "kid":"MDNV-C3IE-XERP-KFK2-WSPE-46WU-SCVP",
          "signature":"HGg7oOqGk9JQHM5SEZLhvtJ6tyb43-qli2yaxpd5lj
  gxZhDZAtopkoHrLWvMV-p9XIA6bLY2B_Pb4hHSEBuNBA"}
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
      "kid":"EBQK-PV7W-GZL7-VOPV-MV3S-Q7KZ-DJAL",
      "Salt":"3Vi-To_UnAuSj3Uc6xrOfA",
      "recipients":[{
          "kid":"MA56-GZFJ-N6CJ-DZTT-4SG6-TEAH-DYVS",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"B0jSmhTtwz31DWnM1m7dmtBOB69U8zqBDhO2h9J-C
  Wc"}},
          "wmk":"Z1CtPB-YF-XdoXJie_eZa_nja1tEg3VOQFgr7cPVO1ZddoZd
  4U0djQ"}
        ]},
    "Ns-5nnV64a3ICuAErs4vlHfo5BwTa4FFl-Ggi8J9QI12DRlnCaFdeZZLds46
  BnVZUpX9DTaGvzbejArs9t3o6Q",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDNV-C3IE-XERP-KFK2-WSPE-46WU-SCVP",
          "signature":"7Q9QFd8buaxfGbZEwbqwgWN8C8w0b6GyD8lP0ghueU
  GTI2Diot-1BOQluJG0CtoijkaYEkje0UCkGspWZ73ZAw",
          "witness":"aa4g_VrkNrW0FXSLf1PoIdQgbFNw7z01rRYCJJJsncA"}
        ],
      "PayloadDigest":"gN-se1Af19E3SGT96hcSU4XHK2QbgmC3hHOZyRzb4i
  VBSOCvdUW7G8l18nL91zLl7f7x7JE16lL_P_Mprxoadg"}
    ]}
~~~~


