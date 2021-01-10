
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"ak8xjwDerzvZ0rI5CXOYLc1if0m7tv-QEIlc5xLZvNw"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"b5i2R-otUnPEYniM2yT92fYMcjWQv1yP5s_RG7_30Nc"}}
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

  AF 9B 03 58  11 FD C6 0C  AD 0E 89 08  AE 9B 5F 07
  9A 6B 54 E9  4E 82 CC 0D  0E CF D3 17  C0 09 39 DA
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"HPcfqnLBjXJCAYpfvS7nJ2gSB4cmA3viKGW3Rk9Yjww"}}
~~~~

The key agreement value is calculated:

~~~~

  62 06 82 A5  72 A3 05 71  FC EB 50 8F  05 95 2D 10
  81 A7 C7 06  85 3B EC 8D  86 1B 0C A1  1E A5 A5 0D
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  1A 3C FB C2  56 1A 5F CF  16 E9 8B 7A  2D F6 B9 CF
  D6 12 85 24  48 59 10 F1  7C 33 D6 4B  FE 04 9B 58
~~~~

The wrapped base seed is:

~~~~

  25 A6 E7 70  44 B5 CA B6  76 2B F0 B5  C5 39 A4 1B
  47 74 58 A3  AD 27 31 45  62 A4 8C 67  26 85 71 4B
  C1 56 1F 6A  ED 04 19 A6
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  BC BB 55 BE  73 48 0F BA  46 A3 50 46  A1 B2 1A 34
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  A8 03 D4 62  35 0B E1 AB  DA 9C 20 F4  BC 05 51 98
  AD E3 44 B0  16 3B 53 9E  DF AA B4 DA  F6 BA 4E C0
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  F7 F3 60 65  41 CE 5C 1D  8E F0 B1 08  B9 C4 F5 A6
~~~~

The output sequence is the encrypted bytes:

~~~~

  BC 03 1A CA  10 B0 6C 3F  F4 AE 74 37  6B 41 83 D8
  E6 2B 2A E0  94 11 0A 6D  87 1E 1D 0C  11 0C 9F 7C
  7D F1 58 3B  20 8C 76 CD  96 D0 9C 1F  3A 4E 72 05
  97 7B 4A 78  CC B7 E4 90  76 A6 53 7F  08 96 FE E5
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-EFAC-CUBX-MH7D-NW2W-NLLM-PDPY",
      "Salt":"vLtVvnNID7pGo1BGobIaNA",
      "recipients":[{
          "kid":"MDP3-2S7M-HGCP-O7OY-OHWG-JRDP-UUTI",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"_vmIsnNq1nzkEER9XNeLMmtuVgfspVdm8KrSFrJme
  NQ"}},
          "wmk":"g5CO0pU4q3Hs4tK1A1kSBRAsGPXkZAWoY8oXVzrJgy9ngUEC
  gYXKrg"}
        ]},
    "vAMayhCwbD_0rnQ3a0GD2OYrKuCUEQpthx4dDBEMn3x98Vg7IIx2zZbQnB86
  TnIFl3tKeMy35JB2plN_CJb-5Q"
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
          "kid":"MDHP-TBY6-Y6ZV-6ZY7-WNGX-FYBS-6BXD",
          "signature":"9oIte7jO2hasJLe8uTuB-JscDOFP5KUv2OAl6hkuOB
  BHW9en3qpaEQqw6BxSllASQI-M-rgnPJzhhzzJkiT_Ag"}
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
      "kid":"EBQI-IRIJ-JETV-BP2A-S6HZ-UVFK-BHGU",
      "Salt":"zWIHDOqWjwaazP_48VB6Nw",
      "recipients":[{
          "kid":"MDP3-2S7M-HGCP-O7OY-OHWG-JRDP-UUTI",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"gEABgcaEfoeDG04ybGvE3rF03gDZzrb0HIO8Xkfdy
  A4"}},
          "wmk":"WU-I3viMTkcd10v_9GhLi-1VxMtD6YtXEX_Ha_Mg9zUKOk9O
  U1J3iA"}
        ]},
    "C5R8aHBKo-g5x9Ura1inMFTEgavWV0G37WW21YsEbgZzE-MjLIKqY80H6Fup
  F29p0nS5ZqxWsQPB5xD7CAs_og",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDHP-TBY6-Y6ZV-6ZY7-WNGX-FYBS-6BXD",
          "signature":"2ob5hzmqNkcid8vMJ6k46SLrWFzJ7RISyEf21xDFyf
  fASpQWrh7dX1qrflhJJnX0P53ykl_FP8GCQyq12-NrDA",
          "witness":"B2E80chjeaZ9GEQKJ7SlDBzutita1HnOKHDKfIkdJKo"}
        ],
      "PayloadDigest":"jLWE9jmp_OFn9WnWotYXlHtl6iHCCLR5EnCY2csudJ
  1vRCxCBMnKhaCCzwOtWhOKYtfFnj6tGJ7tkcR_KnsvOw"}
    ]}
~~~~


