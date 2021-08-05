
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"y2kAJdaAR1hyqHOYlIsH4-pOqV7qJU1iFZ2ZNZ68j8M"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"MIBPnv_pLhRDy_O5rHpwnjl2w6Nv40HxpWYlKYaSyNs"}}
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

  8A 93 8B C4  4F F6 DF 7B  0B 50 8D 31  8D 5C D6 34
  27 D7 20 40  6D 64 5C 9C  43 A7 0D 6F  5E F8 09 FE
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"KzUcTyJ7hTclapw6F7bHdIt6N2Erisr3nKCFQxZiLc8"}}
~~~~

The key agreement value is calculated:

~~~~

  B3 02 1B 84  32 D5 AD 64  5F B0 BA 0B  C8 3C 39 BE
  06 BA 5E 67  74 E8 B6 50  44 30 0F 55  30 17 98 1D
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  73 C2 0A 48  E9 1E F4 2A  BA 4A 75 2F  EE 6C 93 35
  D1 33 2D 88  B6 BD 34 CC  FB 08 66 C2  A4 8F D0 11
~~~~

The wrapped base seed is:

~~~~

  4C F0 90 70  05 54 AC 25  79 DA 5E 5B  AE 81 1F 94
  94 45 10 04  B4 C2 18 D0  CE 33 F8 5B  9B 6E 82 BA
  5C B6 A0 35  8D 42 71 71
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  D1 52 EA 5A  04 77 10 CF  41 67 53 24  1C DB 84 55
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  4D B6 D3 3F  98 36 7C 49  A1 FB 2A C4  C6 9C D1 AD
  D1 50 05 57  81 52 A2 AB  CD D4 17 24  E8 FD E6 9A
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  9C 92 F0 C4  33 6F 85 6C  A7 F4 DD F2  11 71 9F 6A
~~~~

The output sequence is the encrypted bytes:

~~~~

  00 B3 A2 FC  BD EE D2 39  78 29 EE 72  79 49 97 0C
  91 C1 08 54  D9 5D F7 CA  B3 45 99 34  CC 11 31 F4
  75 3D 7D B9  BD 25 DC 5C  FC B1 78 40  49 A6 D5 EF
  99 87 7E 39  02 EA 66 EC  D5 7C 9C 59  C3 F9 C9 8F
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQO-I7V7-SMIU-R5H6-T3E5-3QXK-T42M",
      "Salt":"0VLqWgR3EM9BZ1MkHNuEVQ",
      "recipients":[{
          "kid":"MC26-ABWY-V347-CYLP-BL4I-OJK2-USAM",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"xy9IcR8Bw-_dhFAo40Yq6Gs50aHb3n1rWn_WqdsL5
  e0"}},
          "wmk":"cJ0sCeJuErbVczFrYR6DFJ7MhzkZ3kLObz_-Nod4WhtNfwis
  VwsLlw"}
        ]},
    "ALOi_L3u0jl4Ke5yeUmXDJHBCFTZXffKs0WZNMwRMfR1PX25vSXcXPyxeEBJ
  ptXvmYd-OQLqZuzVfJxZw_nJjw"
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
          "kid":"MCM2-KJVW-53WM-34MC-KA5N-WOUA-OTPO",
          "signature":"3bncPZjGBT3ZamGcqxTr2xy_gcPqSU4MJNh0N1Byjy
  eTBc56ZCSdPaMEcneM-I3gC1tYENjuZeaeHvFQqYZRDA"}
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
      "kid":"EBQD-RLIW-MDD2-EFQ3-BW7J-D274-HMIU",
      "Salt":"edg0MqvIVpbY_daVzcr2BA",
      "recipients":[{
          "kid":"MC26-ABWY-V347-CYLP-BL4I-OJK2-USAM",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"Zx_VpToogto-rqHfTM8cJrcFsxYx0vgXvQzQ2C98E
  XU"}},
          "wmk":"4wKXjIKw7An50V2F13YOXkcP65cm07K-Aq2OTmu5w1qFBmtz
  lHMaiw"}
        ]},
    "-7ltHUIS5CKK53ng5TXuI5f5iQ9jMSQ7ik6cW_1cn6xZGawxLCc7rH_fNSv4
  uvXEoaNsSs29YA2JRwDa1ikk0w",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCM2-KJVW-53WM-34MC-KA5N-WOUA-OTPO",
          "signature":"6EC_nMKMvbjTivoX8mpXKF0jXliQ0JgRNi-OlMeAIC
  OnnJIOLdwE3xEk3W2xbsPc35n-_Up1u64jLH0by2-mAw",
          "witness":"FEc2sqXKFgfSVUL1dQuuJ2Is1WsxcJtNJSFL-T1njTI"}
        ],
      "PayloadDigest":"b5VAe6YrqODvnyd3dwF-T2rqqVTYap2FzN-umyteo5
  NwNFf2_1h2ObZoLm3jj15NY9SHzHvcyXEeGPyey9aUVA"}
    ]}
~~~~


