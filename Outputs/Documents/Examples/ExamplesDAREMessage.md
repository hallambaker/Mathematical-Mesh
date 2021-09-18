
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"D8IhTMCIy0M2cbB0yByZVmSJeEbED7HZ-6AxgvTNSHI"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"aVNqrEAz7i12rCRp1j05nYoewZ914aj7WjEL7wY75Nc"}}
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

  F6 EA 48 C4  C1 86 F9 CC  EC 54 E8 8F  3C 8C 66 DA
  E5 5F 9F AB  5D EA E5 4D  B6 5D 5F 7C  BF 7B 0E 33
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"aGdg3cQ9gSv1D2U6ejipW0Gv_3wQrnx0VTl-5TK3xVA"}}
~~~~

The key agreement value is calculated:

~~~~

  79 8D B7 F4  B1 8D D9 22  48 D9 22 1A  4E B5 3F B2
  F3 A1 BB 90  7E 75 90 E6  0A 6C 1C DD  DA 2D C1 19
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  7A 33 CA C0  2C E5 CD 90  BD 50 39 A6  BB 30 44 4C
  42 5A 6E 85  7C 7A 4B 32  F4 A4 3F A6  88 87 4E AE
~~~~

The wrapped base seed is:

~~~~

  7D C3 70 6A  F5 64 D9 13  D0 F8 2A 06  FB 2A 6F 1A
  DF D3 85 2A  BB 0D 66 2F  52 33 8C 40  44 7F 0D 10
  4C E8 D2 C5  71 A3 50 B0
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  E8 C7 36 AE  BE B1 05 88  6D 12 D3 59  A9 FE CE 2E
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  83 8B BF 10  99 CC 0F C8  EA 92 D3 B8  58 EC C1 69
  E1 54 58 97  58 54 A8 BF  DB 3B 47 73  C7 8A 12 32
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  5B D1 BD C1  EA C9 26 35  81 54 E3 5A  7B 60 CB 32
~~~~

The output sequence is the encrypted bytes:

~~~~

  81 C2 93 1D  41 7C EF F1  31 40 A9 BC  C1 64 52 EF
  0D 70 D9 A8  DA A5 EF 9F  2B 9A 35 48  9F 45 53 65
  1F 94 D3 08  F9 E2 F3 30  B6 26 25 08  92 8B 73 11
  9B D5 53 CB  F0 D3 BE D3  5A BB 8D 78  AA 06 2A 26
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQH-P7WQ-FIBO-VBSF-DBXE-6WQI-HDBL",
      "Salt":"6Mc2rr6xBYhtEtNZqf7OLg",
      "recipients":[{
          "kid":"MDLP-4BEQ-R6KK-JJ3O-O57J-5G42-FEEI",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"0vAQZiRXgtJtDJgivbWWiu1dnUSD23Ji99V5dxvF4
  3M"}},
          "wmk":"aZ0pcfhlfwlcqDh4HYV2r535jq75mSWFP9C0jl5MWGdyFpi4
  zA8pTQ"}
        ]},
    "gcKTHUF87_ExQKm8wWRS7w1w2ajape-fK5o1SJ9FU2UflNMI-eLzMLYmJQiS
  i3MRm9VTy_DTvtNau414qgYqJg"
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
          "kid":"MCJ4-KD6E-CLBD-T7UT-IBLN-JGTT-M2PH",
          "signature":"zolQU72O30E4b1J8wMmGMHbKAUIDD3aLONaOB5e19K
  iP729ncCeiL5B_dZjaV3BehRGuCORpQpv8SlQEPTfCCA"}
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
      "kid":"EBQE-L6GN-ZONU-XTIP-5QZ7-6P5U-PEZI",
      "Salt":"nFDcVIqG0P3VGkYcGODO2Q",
      "recipients":[{
          "kid":"MDLP-4BEQ-R6KK-JJ3O-O57J-5G42-FEEI",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"mVKIv6dzpItzRBPUWxBL_rrRAJbJvzoalx3zjWfC0
  QU"}},
          "wmk":"7tjkDTXrd-1jweXIGRg0e0xgpyCBz21Zhmp8Pco0MMDHcm29
  5l-PUQ"}
        ]},
    "JvGxqgUBfSUv4lgg6KNCWGpiyzLnoVxwA1xauE3GBjBSZXYN8XGwF21VPdAR
  Z9R_qIEVkgqtGa69NYhww9Y9ew",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCJ4-KD6E-CLBD-T7UT-IBLN-JGTT-M2PH",
          "signature":"UDX6IdySw6bKWlyY6EDTil9pH2zHJyhqq4OTlStpbU
  DhqKRDDn8FSkLuEpQDi8o6Drj0KDbHil7ivde7V337CQ",
          "witness":"VWn-yy43WKDES_7G1BFS47nq98-mOMJYQmi8SrWya7Q"}
        ],
      "PayloadDigest":"ubCV9En7wu851CFOxHLwt4M534d1Stn_tLDH_h_9fx
  jVVDURWpxmw4L946YDlIAR71S6ywmRgy3bRHjtO8CeFw"}
    ]}
~~~~


