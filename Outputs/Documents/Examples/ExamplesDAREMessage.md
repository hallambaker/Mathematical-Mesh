
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"ofU7EM6vRmMwT6Ci75OYf2ReWmSrS0ml7PYJrP35rbU"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"TI97eALaOSebv9J_gtyhhcqzzQvPLeN0GYMnsrfKPq4"}}
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

  AB 27 F0 8C  AD 0A 01 23  33 51 5E 19  D1 EE F2 F1
  DC 58 26 D4  24 32 E2 38  31 3D 79 2B  02 01 6D 75
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"QFi2eOKTfHltSQ4NBynmWHZTUd0Xdl2-7X5dK1Yn8u0"}}
~~~~

The key agreement value is calculated:

~~~~

  7A D1 9C DB  47 6A E6 82  56 3E EE 9D  D0 14 98 50
  13 44 37 42  08 80 CA D9  45 5F 88 7E  9E 86 D3 BF
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  0E 4A 69 58  3D CA CF BA  66 0E 20 CC  66 2B 3D 0C
  96 64 58 E2  C9 91 0F B1  D0 C2 B7 77  8A 26 02 21
~~~~

The wrapped base seed is:

~~~~

  55 74 77 52  D9 2B A5 9D  C7 B0 1B 5D  66 8A 6D 3B
  1E 17 30 2C  10 F0 03 16  E2 7F DB 90  C0 7E DC 03
  DD E2 05 04  1D 2F 7F 9F
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  A0 6C 7E 27  24 C4 A7 5C  3E BD E5 E4  3B 1D DA 31
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  6A B3 71 00  53 04 00 8C  19 F7 0B 7B  68 7E 40 D7
  E4 51 93 BA  1B E1 70 A1  22 5C 9B D0  91 C6 98 FB
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  DD 7A 9C DB  B3 D0 8E 37  E9 F7 69 D1  2C 3F FC 06
~~~~

The output sequence is the encrypted bytes:

~~~~

  6C 6D 28 4F  96 26 2E 9A  03 7C 4B 84  90 F2 0E B1
  64 2A 54 AC  CB 91 E5 01  14 8A 95 E7  0D BF A2 D9
  96 29 44 1A  9B 4A FC E3  C0 94 FE 3D  4A 56 16 4E
  81 9A 08 19  9F 97 0F C0  EE 42 41 9D  5B ED 85 48
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQL-D7FL-HDQH-KXAT-YZO6-ZNZD-IXLH",
      "Salt":"oGx-JyTEp1w-veXkOx3aMQ",
      "recipients":[{
          "kid":"MBVR-DSPX-YXLT-5VIS-V53W-XULC-MQPL",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"-x3zr-mQEyufHBtQlHajgz3ECN88UO1SXWNCYIyv5
  LM"}},
          "wmk":"47LEucZy7k3d8jX3DhC_emsNcanC01Z4hVobu68e-7p7S6pF
  9y_i6g"}
        ]},
    "bG0oT5YmLpoDfEuEkPIOsWQqVKzLkeUBFIqV5w2_otmWKUQam0r848CU_j1K
  VhZOgZoIGZ-XD8DuQkGdW-2FSA"
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
          "kid":"MCNM-NSDH-2V7Q-HEYL-VAPD-4X26-JK2D",
          "signature":"2BRr8x_vTqD_luOzpOzTqff-yggcTTqQgRIyqdAeiL
  nQz4YnYxysMnTe1ojnereNqj-lRQjLaYu8iF8pK2W8Cg"}
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
      "kid":"EBQI-QHD6-IV3Q-LFRB-BMAB-NQ7I-JFYB",
      "Salt":"6NqOlTeWD1FJWaY_Le0Ldg",
      "recipients":[{
          "kid":"MBVR-DSPX-YXLT-5VIS-V53W-XULC-MQPL",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"O5kmqWRzuRDf3VYIdpf4HH_eh4YYzrGbtQsADFhdm
  iw"}},
          "wmk":"LqzvN81GFQW7CU2B3GFx2k_wNVkj80Up94uQJ8DgDWbjwJ30
  ECeI6Q"}
        ]},
    "7F_Ejfe5S_xsqB7y5Hrgj0WTusHAFGP6xahb5zfCRqPJV4F6YPgtyFiVlB_2
  ZIny2ZUFBsS07g9Zv3JWodbNeA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCNM-NSDH-2V7Q-HEYL-VAPD-4X26-JK2D",
          "signature":"AzMadMqmwzRnHKvgNj0M6R2cDjBpzYrFY3YzGAmOwD
  94vo8kh2xr4kKcScWilqIlQ25eRaTa8MGYpILqd57jBg",
          "witness":"IkKzN7v7HEU-RuOeE-xofwv5Y-tnBFopk8B2HDmtC7A"}
        ],
      "PayloadDigest":"6SVRLKalkQbYq3AX_zSexBSEuR7AjhE0vJx2kKcOxl
  ggcDW3bQ_vG3k4P7zaM38fF03EkW3FnQUow8Lwks3zqg"}
    ]}
~~~~


