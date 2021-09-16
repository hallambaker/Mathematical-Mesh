
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"RF5tXkM66BfoVNBUElH2sgJVGbmYR29kXoxwGdu86js"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"1gPU8EuKJswoxgY0bpGbsDax1o4ZH1RfqtWXr9CqWYA"}}
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

  44 23 9F 8F  5D C3 C4 29  A3 4D 8A D2  94 E7 C1 71
  3C 55 AD 34  7B DA 14 5D  88 5C C1 69  A8 C5 F1 15
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"koa0RkmEa7kUFKl8iyuGMhGW_K0qlpFxROTMC0dpmKw"}}
~~~~

The key agreement value is calculated:

~~~~

  A5 64 54 1F  E3 48 31 C6  AC 39 B0 01  3C 47 FE 9A
  96 A8 99 20  34 38 41 F8  09 A8 7D 83  14 B8 91 33
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  09 23 7F 14  1E C9 AA 7A  AB 3A D9 F7  01 75 63 A8
  90 67 27 E7  4D 1E C4 73  B6 8F 34 08  9F 00 0C E9
~~~~

The wrapped base seed is:

~~~~

  09 14 01 D6  04 44 AD 30  D6 31 7F B1  54 9C BD B2
  AB 9A AE 56  E3 3F FB BF  62 DA 1F 6D  E5 ED 37 85
  79 48 4D CE  D9 05 12 79
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  96 54 E7 47  E9 6C AE 35  EE 41 71 7E  6E D0 17 E6
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  FB 0A AA 1C  51 38 7D 58  5C FC 5F FF  03 D6 B5 AE
  86 71 B4 BF  04 60 E6 28  55 DC 4A 5B  DB 05 D3 3F
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  FB DB 38 0F  13 1F BD 35  07 B7 A0 ED  77 9F 2B 00
~~~~

The output sequence is the encrypted bytes:

~~~~

  AB 7B 98 ED  B9 81 8D 57  F0 57 73 54  84 E7 63 C0
  A0 AA 90 8B  FC 17 99 97  08 6D A6 B6  B9 50 E8 EC
  76 4A E7 B3  62 F0 68 FB  99 25 A2 BE  67 89 4C AD
  F2 7E 68 D2  52 29 86 D1  4F F8 2A CF  E2 13 98 35
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQL-TJ3V-RHZN-G5XP-SZSL-53QU-5GGF",
      "Salt":"llTnR-lsrjXuQXF-btAX5g",
      "recipients":[{
          "kid":"MATO-SSLL-BMNJ-UVJZ-EM52-TME2-PP2S",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"NuPmCcRNzCVpLmhj4kJDh8VYvSYhjlW1AFkVnpE3A
  Wg"}},
          "wmk":"BQPVztm9M-dZAN8Zn4wr8I88np8LgT5y2eZeYOc9QCrBan_T
  1o-xqA"}
        ]},
    "q3uY7bmBjVfwV3NUhOdjwKCqkIv8F5mXCG2mtrlQ6Ox2SuezYvBo-5klor5n
  iUyt8n5o0lIphtFP-CrP4hOYNQ"
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
          "kid":"MBUU-JLA2-IFYV-JJBZ-KTC4-LDBD-K2VC",
          "signature":"HXtaEk7Ff4WeCm2q0n7Y4K2OEOxrw3VFiheCwQXwSq
  0wouv2Kp63KUl5HErn4zWBtREsY4gxI-cp8RVYs9qXCQ"}
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
      "kid":"EBQP-S2MM-FM2W-M734-3W2I-2XUG-F5EH",
      "Salt":"cup9_LEDl1JySQ4uftnMkw",
      "recipients":[{
          "kid":"MATO-SSLL-BMNJ-UVJZ-EM52-TME2-PP2S",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"KfAjajohtZidbOLKPNlp-v3fySocYJPkCWEnD-2Xu
  Ko"}},
          "wmk":"k7nWU-82hYCtb6201XZAt357Vx6ec_12XcBqgoW5GjFPn4aG
  oEq91A"}
        ]},
    "3NObis6ykQKcZodC7Jk6AZlVtrNHn1W72boV4QPSyRRmtpUmRjhDIj3pdDsg
  QXmP3Z82o7sgbA91OyNg5WXXOQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBUU-JLA2-IFYV-JJBZ-KTC4-LDBD-K2VC",
          "signature":"CkS9wi8_r9DURNteNz2R_XbStXSl7tTK0cyoq_9qH7
  kliSA5XWk0y3S7oecrtnzwt5HBsWWjLrZ88vROAeFNAw",
          "witness":"hP2GUwccOpCuxb7etx7kPm4Xv7_7lQl7GiFMg9qXa3E"}
        ],
      "PayloadDigest":"beH8VLJyzEuczbAo6HbVOEA64zR1_HWd1_YeB2KEx4
  5pAlEoqzVZcpwvXibB4bR6Q3Sr_kWZxHIMI1o7RQiwqg"}
    ]}
~~~~


