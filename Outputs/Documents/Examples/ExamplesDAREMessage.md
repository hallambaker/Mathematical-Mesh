
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"5Bw5PIsUSEttOl6-ktqPcIzhuXJ8LZbU_plqYMagLoI"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"-JJ4e-u1JgKv7Q9IgmDfHDPSCDYAy3A-wFtCS7N92qk"}}
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

  5F 63 58 1D  2E 06 40 7D  14 62 DB 47  1D 04 FD 91
  4D 26 43 23  B0 AA 7A C5  8D FF 70 04  60 B2 93 DD
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"34tQreV11Kyg1gsz5QKCxBrl0px1JOZu-4fuHLIDCss"}}
~~~~

The key agreement value is calculated:

~~~~

  AD 56 E8 5B  8D DC 2B 1B  A0 17 C0 37  0F 96 D3 F3
  E2 E6 0C 99  09 F9 D5 A7  99 F4 4D CA  51 1E 4C 0D
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  B7 FE 21 B2  A0 CB A9 BF  66 EF F5 F1  66 7C EE 5A
  97 47 D0 7C  18 47 05 B8  B4 D1 5A 1F  F2 14 62 33
~~~~

The wrapped base seed is:

~~~~

  8B B9 F1 9E  0A 0F 1C 40  80 FB 5E 20  74 FA DD 59
  89 83 44 8E  22 A0 F3 19  BB C5 C6 80  D5 AA 22 01
  E3 80 68 BA  E3 0F 07 13
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  5B 3E 09 4B  25 2E AE AE  35 A7 2D C4  D3 00 73 02
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  9E 15 76 62  33 3C 21 28  ED 50 EB 95  48 89 FE 8F
  D5 9C DC 5A  F3 A8 45 EC  C3 02 98 ED  77 94 40 81
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  3D 2C 9C 50  49 FD 58 DC  95 7D 52 11  8C 6C A5 DD
~~~~

The output sequence is the encrypted bytes:

~~~~

  BA 4D 44 9F  CD B6 BA 1F  D7 B0 E3 3B  15 04 6A 83
  62 C9 7F E1  15 B4 EA D3  3D 38 8B DB  D7 13 31 D3
  DA 2C 0D 9D  CA 1D C9 A4  DF 9C EA ED  E8 FD 51 5B
  B2 D2 65 C3  E2 EA B4 C9  D4 8F 51 CB  69 48 1C 73
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQM-DBRN-5MXY-WIMJ-YK5G-2AA4-5XGZ",
      "Salt":"Wz4JSyUurq41py3E0wBzAg",
      "recipients":[{
          "kid":"MBOE-T7MX-VJL5-QTW2-ZCHK-6ED5-MN3X",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"3DnTH-qyXYxZ4QNyLwacrIvCiVC575Lzp0df0w4_t
  Y0"}},
          "wmk":"8MK-N1Yai4nldYeTqDcDjlvH5sQq-6eF8X7cBw0L1yzj1IS_
  XXilyg"}
        ]},
    "uk1En822uh_XsOM7FQRqg2LJf-EVtOrTPTiL29cTMdPaLA2dyh3JpN-c6u3o
  _VFbstJlw-LqtMnUj1HLaUgccw"
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
          "kid":"MDF2-YGDJ-WCMG-RR4U-FIBB-GWXT-Q7QP",
          "signature":"w2TAnnWN03_UqfaMi812-stuMUncI9door0NxhJ7CS
  Az127Hi9nxqhyrfmYCUUt89cpK85uS5kb4cOKFx9NaBQ"}
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
      "kid":"EBQI-6A3X-7T7U-RE2N-YOZR-P36N-L5JX",
      "Salt":"ttyl8BHPgj84zRN4KfOgsQ",
      "recipients":[{
          "kid":"MBOE-T7MX-VJL5-QTW2-ZCHK-6ED5-MN3X",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"v_7lqY2PV7ZtaKMMe96EZu9wSijcI62ayWMNRBt_v
  Hs"}},
          "wmk":"s-_8w2UtuNquqOJQAUrSfGz4TKz4r9IdeALajNz3fSHZLP0X
  iGixwQ"}
        ]},
    "2dIwk9fDNAGuMen3zudGErMgu2dT0kHUt6j79xVfQFp3T7OIhXxM0XJm7QK3
  KryiuUxwHwetHgW1SytmyeAQbQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDF2-YGDJ-WCMG-RR4U-FIBB-GWXT-Q7QP",
          "signature":"JromdoqndCrcLl1Y7275YEtu29GU0K7oAl-NGudC3z
  C8QeLxJ_daX2aQ6ar_8yvXN-DgSFYubkqUIF0AsxPGCw",
          "witness":"jLLmO6I4ujDPQJExYs5NjV3CebPRs4KapVE4G1A7aX8"}
        ],
      "PayloadDigest":"qjM7VsAAfqwbDK3TGi955l7CVBfcSEtDo2Vbgkw-v4
  NknsyF5md1wz2RjVatKGOp2OJy_si7maMO3tQYREWAxQ"}
    ]}
~~~~


