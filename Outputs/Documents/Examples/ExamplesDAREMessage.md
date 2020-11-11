
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"Lt9hUjkQ1RDvoAhA9EUooE-X7KigDOQOvXNC1lxMSto"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"B-K6VxuFjt9pIX28Ve1ebVsKL2v8TNxFTYbVx3Vyf0s"}}
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
      "Annotations":["iAEBiC1TdWJqZWN0OiBNZXNzYWdlIG1ldGFkYXRhIHNo
  b3VsZCBiZSBlbmNyeXB0ZWQ",
        "iAECiAoyMDE4LTAyLTAx"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBs
  ZSBibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~

  06 73 48 23  93 56 56 EB  B7 DF E9 02  19 DD C6 DD
  AA 33 5B 3B  F0 99 BD 3F  E4 45 CE 54  AA 38 7E 6D
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"jWW8AbAd7aYyegeGa5xtrXV_gGg8b0Oe_hNm25mqejg"}}
~~~~

The key agreement value is calculated:

~~~~

  A9 04 72 22  88 34 CF 36  D0 8F 5C DC  76 9B 3A 39
  CD 49 E0 17  4F B7 D1 13  9F 1E A8 43  52 2D 86 FA
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  30 F7 69 3A  73 9C 19 96  6F 49 0E 37  F0 0C 45 73
  89 C4 36 DA  D6 3A 12 76  3A B1 CC FC  4C B8 C5 C5
~~~~

The wrapped master key is:

~~~~

  50 90 F3 D9  1F C7 C7 E5  26 62 F6 A7  63 0F AC 08
  8A 49 7E 4B  00 EE CC 47  60 4B 71 E5  2C 84 9C 20
  F3 16 A7 C0  38 D6 3C 6F
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  EE 96 EA CB  F0 86 FD 5B  DC 07 B1 44  28 AE 92 59
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  47 EE DF 79  B6 AA F8 CA  9F 4C 6D FB  A0 ED 9A 08
  7A CE 46 CA  92 D6 EF A0  DC 44 3C 97  62 9F 4A 9B
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  23 88 65 36  96 33 D5 AE  89 BE 46 4C  D9 99 F6 3A
~~~~

The output sequence is the encrypted bytes:

~~~~

  AE 13 DB 62  7B C3 1C B2  C0 C1 DB D4  53 DF 91 E9
  BE F3 7F 8C  4F 07 18 9D  6E 61 E6 AA  6B 53 F6 FD
  BC 9C B9 0D  5C 63 00 0F  84 28 EB A2  A3 DF 02 F1
  C2 4A 6A 05  F9 D7 1F 97  07 68 89 C2  C2 98 BB B3
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQJ-V4EO-ZZFX-7J4D-V6RN-ZXLM-QZ3C",
      "Salt":"7pbqy_CG_VvcB7FEKK6SWQ",
      "recipients":[{
          "kid":"MAAB-5QQZ-WH4Z-YE3R-KYUY-7DCU-JW3D",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"wsb1faA-wf1z2uAWc86nizyiM_yvD7dmaiCC7w9jO
  sM"}},
          "wmk":"UJDz2R_Hx-UmYvanYw-sCIpJfksA7sxHYEtx5SyEnCDzFqfA
  ONY8bw"}
        ]},
    "rhPbYnvDHLLAwdvUU9-R6b7zf4xPBxidbmHmqmtT9v28nLkNXGMAD4Qo66Kj
  3wLxwkpqBfnXH5cHaInCwpi7sw"
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
          "kid":"MDPI-OV6U-L3IQ-CV53-HMX3-6A6G-RKDV",
          "signature":"lAZHGxo73wrrucgq6hAU1yylKxe8yuswPe6gyItWHz
  cbcEDV-mafeGUlfZ4zBVeJXVElX5Xa_gBYopQ-DGfsBw"}
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
      "kid":"EBQJ-MCQH-IXJJ-H26T-GZHH-NGGN-F2HX",
      "Salt":"uPRKBPiX1WiynCJDR9dwpA",
      "recipients":[{
          "kid":"MAAB-5QQZ-WH4Z-YE3R-KYUY-7DCU-JW3D",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"mRiFiR-Wq-DutTS-ZP6or6Ow186X5WMZ_FSUl4Q5s
  qM"}},
          "wmk":"yK5Ptx1j9DjP3VwcoqzOmluAsdaAbf7mPWRG4YrdJc47lC_w
  xdLImg"}
        ]},
    "4ZqTUCU7Z67PUj5JdUjgjcwh6UHSoY6dewWTYcLgst6fCotY-byWWhy8HUkc
  xReyjKRdBFMTj44yZieN9FLguQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDPI-OV6U-L3IQ-CV53-HMX3-6A6G-RKDV",
          "signature":"B7L_GW7suv9PIs3-mfz2pI0ejq-1lMoE8Bw7hgi1LX
  TPUMErBVWsCfUiFpeJ3a2ES9duuwIfW5Coh37xx9w_AQ",
          "witness":"KM1NLSbuLNraAeoBEGEJ1oANB5lrHnc-YeRgcxS6iEY"}
        ],
      "PayloadDigest":"V5sVHLN7fZI4yKkBW6_TzgWJwft_IbZPRYzGS-Rv33
  zkRcsSBe-I1bpKuCMnNuN4Wr5NKHizhun4OlwAVc70ng"}
    ]}
~~~~


