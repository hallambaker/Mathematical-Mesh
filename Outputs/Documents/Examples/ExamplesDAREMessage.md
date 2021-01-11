
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"ieL_CVf6C3UgRhR-gqIF20zxV_AUe_LJv8z90n-IDrQ"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"byS5VQR4oWh6zwExd_nk3i4YiKjfAZ1p5Szrur79yAg"}}
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

  71 AD DB 15  B6 88 FC 9A  B6 00 1D 85  42 1A DC 3B
  0D 33 37 DD  3D 2E 20 FB  C3 3A 14 AD  C1 1E A4 17
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"jZgPOMJJauQLxFugXRaokWxtE2JCwEdyq7OdWRIJV2U"}}
~~~~

The key agreement value is calculated:

~~~~

  EE 6C 42 A4  C6 32 AC 9F  4B 32 EA 54  6F DE 8B 4E
  08 CD 2B 18  2D 00 43 2B  76 D5 98 7A  24 16 AA 65
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  33 93 CC 19  54 8F DB 7E  65 C2 B0 F0  E1 C7 DC 39
  8A B5 37 0E  E3 8C D9 60  E5 50 0F 98  66 36 B1 1F
~~~~

The wrapped base seed is:

~~~~

  37 2A 4E 6B  A5 BC 94 1C  E3 85 C3 F2  DC B7 2A AF
  DF CE 66 A8  52 0F A3 35  58 C8 FC 64  08 E1 C9 A5
  97 26 2C 51  14 F4 9C F7
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  0B 7F 12 EC  10 23 10 84  C6 5F C6 C7  E2 A0 63 FD
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  58 96 D9 92  A0 77 6A 88  53 17 51 6F  B3 44 38 DC
  51 83 DF AF  3D 5E F3 F1  BE 98 46 87  99 7C 5D F4
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  84 59 F0 91  C2 C1 F2 BB  69 86 EC 05  82 A2 7E D9
~~~~

The output sequence is the encrypted bytes:

~~~~

  06 44 B5 A7  29 75 9E 26  2E D6 AF 92  AB 1C 9A C3
  20 32 A2 AD  76 AA FE B0  0C 23 B1 61  46 67 7E 6E
  EC 4F CC D5  9C F3 4C B8  7C 37 47 D8  A8 BE E6 68
  91 D1 DA 3D  2A BB BC DA  BF 2D 3E FB  A4 D0 53 5F
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQD-I4UX-U4U6-MFYE-XIWT-LIEU-ZZV6",
      "Salt":"C38S7BAjEITGX8bH4qBj_Q",
      "recipients":[{
          "kid":"MBNX-4HDR-4DHY-3JXP-DBVJ-TB3N-QIZY",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"wlYaooghhFWiEjKQcWHWgTytQGkdSNnOH3c8o0FrS
  cE"}},
          "wmk":"WfMf2tk1fgt6OGMMnmN5brl9pLhkO0z16h9ARQ2k8xbQyKp_
  6y6HYw"}
        ]},
    "BkS1pyl1niYu1q-SqxyawyAyoq12qv6wDCOxYUZnfm7sT8zVnPNMuHw3R9io
  vuZokdHaPSq7vNq_LT77pNBTXw"
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
          "kid":"MAN2-5OBV-CM46-NKXE-GHKU-REKV-A633",
          "signature":"xdS0WYFbHWUIoMVUAA-pZKU0jjRO1LfyN_ksjPAjT3
  VB2xvHsvW9a7MPUvuWGD1_Qb1JX97Jtlk3rBLnmgkNAA"}
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
      "kid":"EBQF-Z7RJ-RTUE-AMTV-M33B-LMOM-SFP5",
      "Salt":"GcAz-7wQ0xs44VvGnEneBA",
      "recipients":[{
          "kid":"MBNX-4HDR-4DHY-3JXP-DBVJ-TB3N-QIZY",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"hBwrG4AWFDz3fpcQx_6ThwHg1o9emQ6gNsViNV30I
  QI"}},
          "wmk":"GKuO7DD5yFpx-9qJx0WuF-JCpCRlLJ5piBvHhix6YU2iHL1H
  6Fg9sg"}
        ]},
    "_-Mp-b99seotljKDcEfA5nAYUGqNyycuCqClQ7BDIh_B4WxY2YdWmGDWajhy
  JJCbHlU8vbcmxwdNM--5Pt2Hbw",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAN2-5OBV-CM46-NKXE-GHKU-REKV-A633",
          "signature":"APvWWc81laN2z73XHS7bUCuXV1yAB0-hkBgjKAbU4C
  lVCIDxkDM4g0-uVpsZsguqZo_wNA3SbsY5zDfru8o2Bg",
          "witness":"F1o3mQ62YVCr3InxGfNR60FU1RIjdcW-9S3Km9isUoY"}
        ],
      "PayloadDigest":"oj7jdlLe-JRDDedZA9zbLlIomn0hrpfREErFQzIIAL
  JYwHBaipcxxUE6DDvwluZ_e2S_MggVdFU3Hvs8NSE1cQ"}
    ]}
~~~~


