
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"RtkJ4eR1kT7A1dg1uppeDof-GOIljFSyziYlYn09Lko"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"ve15U4yWLMW4sC5Ix1RQ9muFFRt39sCiT5LlXV-NgME"}}
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

  1E 94 E3 88  87 FD 44 AB  84 CB 61 C0  10 DB C8 2C
  EB 6E 9D 5B  6F 36 55 9C  23 94 8D AD  0D 61 61 4E
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"qwa0YDPu60kJU7nPHL-St-qaG5d1YruokWnU2ud9gvU"}}
~~~~

The key agreement value is calculated:

~~~~

  52 5A 7E E8  E2 3C 58 D8  E1 24 6D 74  37 87 56 9D
  16 71 D3 87  DE 72 2B 13  B3 57 0E 47  57 E4 42 F5
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  6E 8A 16 14  F2 E1 CC 41  0E 01 DB A5  2A 5C A9 7A
  F8 85 52 4F  1A CC 97 E4  C7 30 11 13  16 8C F9 98
~~~~

The wrapped base seed is:

~~~~

  2F 72 2D 14  79 C0 4B FD  A5 4E EA 5B  8F 5B 16 04
  75 97 36 8F  BE 78 7C 09  32 D5 1E 4B  BF 4D 8A 85
  A6 3C 9B 41  C8 9F CB 23
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  E2 E8 FC 9E  1E 1B D7 1F  2C F4 DD C9  6D 82 6F BC
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  9D AB 91 7C  CE 1B 7D DD  C2 B0 B6 D3  9F 8B EA 8A
  33 D3 27 1A  58 19 68 0A  1A EC 12 61  4F 4E D9 CE
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  4F 7A DA 12  36 D7 72 BC  B2 FB DE DE  31 42 D3 3B
~~~~

The output sequence is the encrypted bytes:

~~~~

  5D 17 37 02  C0 2C F7 E0  AE 51 FF B8  48 FA 07 16
  1F 0E 94 0D  BD 52 04 1A  BE 4B B7 C9  B9 09 94 BA
  5B 9B 3B DD  4A 87 22 DA  62 49 49 7F  F1 5F FB F3
  7C 31 F1 C7  95 C8 96 8F  43 10 3A 4B  3D 31 79 9E
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQK-KA47-IKWM-K3BT-6M4Y-7C44-CMQX",
      "Salt":"4uj8nh4b1x8s9N3JbYJvvA",
      "recipients":[{
          "kid":"MDDG-ZV35-AOTM-32HM-PW5S-FKW3-F63R",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"sD1V-Xmp16GXoTkTfUzZXy1xO0DgpLMgTmGGU3tkv
  64"}},
          "wmk":"brLFfEq2hrDXqK9rS7g-B6g9tCzUyYDMKCbr3t2AgOMzyd0i
  yME2fw"}
        ]},
    "XRc3AsAs9-CuUf-4SPoHFh8OlA29UgQavku3ybkJlLpbmzvdSoci2mJJSX_x
  X_vzfDHxx5XIlo9DEDpLPTF5ng"
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
          "kid":"MA7C-5WTL-4JBN-X2QG-3VEV-QMFP-A5DL",
          "signature":"GwiJNYk0G5aVt0ovzj1UAGYBtK3KvNEgOfELUh4fun
  KHyxW1zRlqP1q3hsXm820IjNyVCJoqzAgUh7m0RyEWBA"}
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
      "kid":"EBQP-SP4U-W3WX-DJZT-CDNC-U56A-MNJV",
      "Salt":"3f5QEPU6QAGA6IfroNeilA",
      "recipients":[{
          "kid":"MDDG-ZV35-AOTM-32HM-PW5S-FKW3-F63R",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"gl-LZSjvtJCoY-VSiZRYgaLd3RHY0xqIrBlN0r-Kg
  mE"}},
          "wmk":"Xt_foDlZqxxYWs15rgW1lOFB58NNi4yv11Q5LOglpPJ6vFL0
  dPyFlA"}
        ]},
    "b4QnZKrjJ5AUzvuE-B78pvjHGA4_uogjBZz4Psq3lHKDSZSZxKoBr8TzZxuF
  EzLZiCGlFQOi74kiG_ryikSMVQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MA7C-5WTL-4JBN-X2QG-3VEV-QMFP-A5DL",
          "signature":"kQ4bToosSLTUe5u_PcuUaiafmRqCUjwiMCfNni6Vzq
  a17cStNAInK3NaPEYZTY41YyzmrRbxpmt4L_rFMPTUDA",
          "witness":"VSGzqrIdfGx11hP7WO6zdihUshAqhVAoNbJeg61Kxnc"}
        ],
      "PayloadDigest":"3fnVcg6ZEm6Cl7Ogm-jFe3c4dBJDwUkfIklvph3Q-e
  3doxQZ8qJj9UZYeHa9xruVjm4hyQzPkUa8EB-xAo7_uQ"}
    ]}
~~~~


