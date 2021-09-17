
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"JsuZf-ljce-oxTzyA4k56rPC4HbXYhjN5AiJqygAvWs"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"OstXx_W-BQak0vgydcTmQkjbV9ie5L3ytKHpYmYGvqM"}}
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

  3A 6C 63 C4  A0 F7 06 D1  45 C0 E0 1F  31 FD 64 05
  64 80 E1 C7  3C 1B A6 57  21 AD 8F 0C  B9 CC 41 B0
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"qWZdC3OILEqSsz_z57vSJH1qzHHKB8A0RZmPRpQ6mSw"}}
~~~~

The key agreement value is calculated:

~~~~

  22 3D F6 F6  5F 14 9E 14  44 62 29 E2  18 A7 8D 3D
  44 36 5C C9  70 9D 29 09  21 DF A7 DA  5B 9E D4 17
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  EA 53 05 B7  9A E0 87 7E  46 72 67 EF  86 80 7D 3A
  88 1D 24 6E  5D BC 21 07  77 F5 4E 9B  A0 9A B4 CD
~~~~

The wrapped base seed is:

~~~~

  9E DB B5 02  40 76 D1 13  86 F9 49 E2  88 6E 44 15
  BA FE 58 EF  19 6D 16 80  C5 C3 16 E3  F7 F3 55 DB
  B9 9E 3B 6A  02 2E 9A 2D
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  5C E3 99 DB  1B 5A 4A 27  21 8D 2F D8  1E 20 8A D8
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  62 D8 7D B5  84 54 8A 1E  B9 13 74 58  93 05 38 CE
  AA 9A 2E 57  0B DD 3C 03  85 99 34 85  5A 79 72 AF
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  44 29 66 CE  15 09 52 03  83 9F 63 F8  F5 50 8D D6
~~~~

The output sequence is the encrypted bytes:

~~~~

  EA FA 0A D3  6E 54 C4 AB  AF 13 CE 38  F4 19 02 73
  F2 EF AF F3  88 7A BB 75  19 D9 B2 7F  71 AD 2A 5B
  3D DA 11 86  F8 F7 0E 0E  E2 57 68 5D  D0 D5 BB EE
  BD 1C 5D 5F  4B FC 69 99  DC 8B BF 6F  B7 ED 6F 92
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQF-GYVS-7KJ4-E3G3-AFTR-EGW7-WZPZ",
      "Salt":"XOOZ2xtaSichjS_YHiCK2A",
      "recipients":[{
          "kid":"MB7M-TOJK-4SNN-2WOV-O5DW-WN4D-DKZE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"-QYgS6Bdc94TqH5efk5nEqmvstVnt_Jv9-ZL7pFia
  2Y"}},
          "wmk":"deTzLTpNl3VrHs6--rg4Gz9PZRGakvIuQ8j7Kh4Ka2IQ9nU9
  IgD70g"}
        ]},
    "6voK025UxKuvE8449BkCc_Lvr_OIert1Gdmyf3GtKls92hGG-PcODuJXaF3Q
  1bvuvRxdX0v8aZnci79vt-1vkg"
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
          "kid":"MAUR-NSBK-HQC2-KWXZ-AOQ6-G7OM-IO7U",
          "signature":"P_Dol9Cr1A7DBTHbSAw0pUid-SdochBzVCEkS6SWl0
  -VBxT183BPzVr3fkXu6emdavdEcfw0UzKDx7Sijx3UDw"}
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
      "kid":"EBQG-G5W2-YA5Q-OTEX-HHTN-ZFL3-JZOR",
      "Salt":"RLulnPGfad3P324UTvnexg",
      "recipients":[{
          "kid":"MB7M-TOJK-4SNN-2WOV-O5DW-WN4D-DKZE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"SHg0TUUM2cMbTxv4sWO5hX29ODMCQD9jEvrhhrGCq
  GM"}},
          "wmk":"x0A1qOXWP1V1zKrvnnscnM_4UtTVxTwAp4wzE5MdmYVjuGcm
  i6VjqQ"}
        ]},
    "uPftNF-3xjwjUW0lqqGT59lD6R0s2j2rYafONmgyQ45Jt39cVYkUKTTJIvVw
  tUD4SAFgjbeSuEkZ6SbUovOrig",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAUR-NSBK-HQC2-KWXZ-AOQ6-G7OM-IO7U",
          "signature":"_7mAdaqXazoVA4sACRx2wU8-vTRQ8HhYuddswzJsQD
  Q55FP65rfjfVOJDm2NFE8xK1tm5pBsTd75571rcyliAA",
          "witness":"2mYA3M_1xQD1bqiNFDj2Rem2PadUedgooeOuckHfuYw"}
        ],
      "PayloadDigest":"w4z35VKCgDsxiDk3iv6BeolZ2pEVHnqTrkKTqEFkcR
  xvYUuIV_502dAv7Vk7lpBZH6e8sW4c_6dEzjrM0eMYww"}
    ]}
~~~~


