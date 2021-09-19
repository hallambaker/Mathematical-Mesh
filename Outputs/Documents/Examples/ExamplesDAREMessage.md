
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"4rPu23meICbPMLvmjAaZm6N-CZ3wqnjA5gCeNvs0Svc"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"znX4E3eT_qsOrNKtzVo5yQXjKLS_Xe302S6_zE8MU5E"}}
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

  40 0E B3 EC  04 73 1E A6  45 64 B0 6A  ED F9 AC B1
  9A B6 C7 72  E3 DF 77 10  5A 71 21 54  9B 52 3D 71
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"78dh0AIeOv4nem043ll2nlDp52k16N0PXpjErrGyWBw"}}
~~~~

The key agreement value is calculated:

~~~~

  B4 0C 18 C0  87 12 91 25  BA A0 03 5D  52 BE AB 99
  4E 7B 02 9F  A8 02 C1 6C  E0 60 BC C8  81 24 1E 0C
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  BA 5D 91 1B  E4 F6 8E 5B  B5 70 3A FA  B7 09 82 07
  60 0E A5 34  B0 91 A5 4B  56 08 38 B7  8E 75 54 67
~~~~

The wrapped base seed is:

~~~~

  3F F4 42 D5  92 D8 0C C5  5B 6F 2A 86  26 67 C6 FF
  5A E2 53 EF  F2 62 DF DD  FF 90 F7 DF  56 6D 76 78
  95 9C 17 0E  38 9F 3B 71
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  D2 F1 FB 60  3D 06 1F F3  42 47 91 13  8B 77 E2 EE
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  69 11 25 F3  65 4A 4C 49  B2 6B CA 13  48 C3 45 BE
  B5 38 6E A7  0F 7E A8 E5  B3 8C F5 0F  33 3A A8 20
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  6A 00 1A 6B  26 18 8D 26  C8 2A 54 1F  DE 18 B0 59
~~~~

The output sequence is the encrypted bytes:

~~~~

  D2 5E 42 E8  5B 19 7E 49  D8 BC E8 63  47 AF E3 A1
  9E 8C F9 98  03 A2 35 1F  B2 87 79 CF  2D E6 1E 65
  38 5B 1F 76  A2 69 0F CA  88 8E A1 B3  EC 8D EF 28
  8C 16 6C 9D  58 AF 62 4E  86 2B 5E CC  99 4A 50 9C
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQO-ZHLV-PTHT-7EH5-LDGK-LCU3-HAPV",
      "Salt":"0vH7YD0GH_NCR5ETi3fi7g",
      "recipients":[{
          "kid":"MDW3-XKC7-T2YL-2WCJ-C5VK-46QT-CQP4",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"2MmwZTfeBCRImFB2kwFRgNoay9IjJHcOuX7jrl9pM
  yo"}},
          "wmk":"4PXvuukffEuZyUJXanJke7GREmPbAr9Y2Wz89DwN-CK7gHVx
  4II6xQ"}
        ]},
    "0l5C6FsZfknYvOhjR6_joZ6M-ZgDojUfsod5zy3mHmU4Wx92omkPyoiOobPs
  je8ojBZsnVivYk6GK17MmUpQnA"
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
          "kid":"MD4C-AWRW-JSSJ-CP2D-JSNY-HUPI-SOH3",
          "signature":"Y76p0SE2zmoyKRjgL4T-iq7U2gMWQR1WJUHkFfO98U
  W-YaDdmw7dAeEE0AxUPBGu0XHowSZ0p4HF76GYbqZjAg"}
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
      "kid":"EBQB-DDWU-V4YU-AUPL-H5JQ-W7K4-SDXD",
      "Salt":"VBS4crdNcEZobOlnIrC-zA",
      "recipients":[{
          "kid":"MDW3-XKC7-T2YL-2WCJ-C5VK-46QT-CQP4",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"IjE5rpUzw4QQq0lR-DyGVlWFLG0HpDTo6oG73MgUM
  mk"}},
          "wmk":"IfL6epBv1t-wSbLBU9sVW84AaNQ43_2VEkkatrq7jTBqx7ui
  psv2gw"}
        ]},
    "bx8sBdxb3DTgZw4K7Bwf6idZC-0sGlHWrytgYuT0ERoTqUMmgb-0LNbz6Vd1
  dp5-_-EkhpNZf2ERYXDXixXQ9g",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MD4C-AWRW-JSSJ-CP2D-JSNY-HUPI-SOH3",
          "signature":"4lcQgA8cVIWlfA8mvCzSmw1wQm9pGyXgi9C3V-oH_p
  dr_eNVT2sq_FVCQiGYtdpxT3MW17wSl1kXo9fNsVB7CQ",
          "witness":"W_Uz9WvEdi_xTZf2q1cDoUDeC3S7JnHi36pRUiezCAo"}
        ],
      "PayloadDigest":"O-Phb87EkcBt6sM6qSCAjOjGvU_zD6DlkqCWEGK3En
  zzd-HGvDO5sTyhke4sKtHjyDKkj2iDNqroOcluIUqE_A"}
    ]}
~~~~


