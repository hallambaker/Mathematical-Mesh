
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"eqwqCHHcSiTj-mNmC-Bmt-AF-ffz9_di_XjRinSzH4Q"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"2kFxM14g8Tolc-zPWT65C2rqNaKxKvSbohZRt_vFM20"}}
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

  AD 49 FD 1C  7B ED 15 A6  7E 31 BE FC  1B 82 05 97
  25 F2 20 B8  A7 14 28 48  8A 7D E6 D1  EF 58 27 EF
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"PuJnqrlvv2nhkbWCXxNd2Licp3vKNGj_ZK2yDCZj-_0"}}
~~~~

The key agreement value is calculated:

~~~~

  85 CE 53 AB  01 79 56 94  21 7A 74 57  AD 60 73 54
  93 91 12 D5  7B B0 EA 02  73 18 70 48  43 C9 F4 3F
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  57 07 F5 26  F9 D9 5E 00  52 0A 16 07  3A 0D 12 E2
  7D C9 4B BC  30 BB CF F6  2C A3 73 2A  97 C0 53 55
~~~~

The wrapped base seed is:

~~~~

  93 61 C7 47  41 CF FC 1E  D2 58 F6 7D  CB 5F B4 24
  3B B0 1A B2  B5 EB B9 C2  96 DC DE 41  F3 63 97 79
  C2 40 5F 62  F5 97 F9 8C
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  D5 F3 3A 1D  3B D4 72 09  75 CA 1F F7  CB E4 28 A0
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  12 78 EC B2  6D 9F 53 5B  24 04 CE 76  90 E4 08 25
  83 85 33 B4  8F B1 94 F8  1E FF 54 06  6E 88 09 DA
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  E5 25 D6 91  99 46 22 9F  B2 B4 03 FC  D9 78 D3 27
~~~~

The output sequence is the encrypted bytes:

~~~~

  34 30 A2 BC  B5 0F 50 FD  9F B5 01 4B  6A 5B B6 26
  E4 4F 75 A7  EF 16 8D 5A  D6 05 DA 1F  6F 0B CC 11
  F1 F9 66 B9  45 1D 39 85  9C 4C 69 4F  7F E9 6F 9E
  87 4F F6 3E  B2 F3 2B 51  3D 6D 5D 35  E6 0F 7C CB
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQI-FXMZ-AF7F-LUOA-YMM4-O2NQ-IPVA",
      "Salt":"1fM6HTvUcgl1yh_3y-QooA",
      "recipients":[{
          "kid":"MDWB-P6K6-BLJP-OPMK-KOFT-XUM7-GIJN",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"BSDrgH9xyCqL8JG6UAyYK6vZD5gf12swZxZGhtNC0
  4o"}},
          "wmk":"SkozuWOnHXysmkrw58oD1xeA_KbGrGAZrlav5IwUqY6Ldi0T
  c8Xilw"}
        ]},
    "NDCivLUPUP2ftQFLalu2JuRPdafvFo1a1gXaH28LzBHx-Wa5RR05hZxMaU9_
  6W-eh0_2PrLzK1E9bV015g98yw"
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
          "kid":"MCOY-MHYT-EIGE-7FX5-CRFW-43MX-V4V7",
          "signature":"0uSXb84meW1zxuUnNVgSKXoZJ7iibMiQ8CQQY0AQdQ
  -gI5fMIS8K9vDg7xxBpzFA0UmTXibEn3Y8USE5aYwhDg"}
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
      "kid":"EBQN-L67Q-AIB7-GQJA-SQ7C-N2VJ-SVQL",
      "Salt":"634SvtuW_xs_01i5hWSc1Q",
      "recipients":[{
          "kid":"MDWB-P6K6-BLJP-OPMK-KOFT-XUM7-GIJN",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"7w_peMglKw7IO5QiyDrTmxKww0dwrl_pXSYI1NwgX
  B0"}},
          "wmk":"_x6dtjHHFpVJptPajWSnLyBDyVifjPL3C2aBmDy9DPGYzO7h
  kOskUg"}
        ]},
    "RqVd5mP_4zWDkIRc23W76F-GEy3dC4IjAeqt6JcX3n6Mowg_WNlG2czo6QKa
  K6m0UFTi97WwlrYMjOSp7tgGNg",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCOY-MHYT-EIGE-7FX5-CRFW-43MX-V4V7",
          "signature":"obqjaxdW_Q7xgSaoR579zmwZvNLIst7t9yXiJSPNjb
  0ASFMAP3zXMD3ujkj-aWrltoE0aXSpql7XGabh9KW-Bw",
          "witness":"U41oAmF7Kpw1ndL3RAYhMEkayT61xQxaLzb0SbLm7XY"}
        ],
      "PayloadDigest":"-5SYLvx2qcipxSET8IshNfOww1BmY6y-5dEXI1b1Kd
  jh3oPvzthU7wlUS2YdJEovh7ooj61YNnwaZWfaOl9ylQ"}
    ]}
~~~~


