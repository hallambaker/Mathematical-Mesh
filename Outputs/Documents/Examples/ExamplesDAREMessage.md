
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"cAm8Krviq1tUBg2Z24ZDbWps3AOjRRTSReZwBKW2DPA"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"-yK9ViDaJvdcOTXIt151IYrnl-0Dl8zKAEzQyy30wJU"}}
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

  69 3E 1D BE  4E E2 9E 68  CA B6 2F 10  44 41 59 B3
  6F 23 85 B6  27 8A E7 B4  27 83 01 43  3D 20 37 8F
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"OMsKcwiygXLqDeZWp9LI5cbRcrXfKCElDJggOETDo84"}}
~~~~

The key agreement value is calculated:

~~~~

  67 51 F1 D3  38 11 A1 4D  71 DA A3 33  10 59 4F 60
  60 AE 51 08  61 C5 D5 0F  5D B5 83 00  D8 8A 98 DF
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  47 6E 28 F6  3C 9C 43 7F  C5 08 A7 8F  93 2B 75 66
  3B 71 CD 62  B8 A6 EC DB  AA AC 01 CB  B9 A7 62 D6
~~~~

The wrapped master key is:

~~~~

  90 AC 2B 54  E6 A2 3A 75  AB 4B 97 36  DD 06 37 0B
  10 2F BC 83  1A 07 98 B0  7B F2 5A 4A  90 28 E7 B7
  C0 16 57 E2  79 F7 BD 99
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  AA 8E 0E EB  00 49 64 0C  73 B1 AE 85  4D F3 FD FB
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  0C DB 2A EB  6F 6F 07 E8  CE EE 9B 0C  4B AC E8 6B
  52 C3 99 B3  15 B1 20 9C  CE F5 D3 A5  DE C3 41 B5
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  2D BF 75 66  97 94 2D 7F  9C 5A 5C E2  8E E7 5C BF
~~~~

The output sequence is the encrypted bytes:

~~~~

  62 1F 74 B7  FE E4 65 5B  73 6E E0 9B  0F 2B 2F 67
  50 49 C1 67  76 2E 0A 8D  EC 47 43 A3  80 C0 7F 21
  FF F8 54 5F  CD B0 46 7A  23 D4 F7 CB  CE C0 15 00
  67 D7 CE 9B  06 5F ED 93  4F 38 9A 89  F1 95 D3 8E
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQD-IGDT-4K6K-Q5KV-KI5M-W444-EWEF",
      "Salt":"qo4O6wBJZAxzsa6FTfP9-w",
      "recipients":[{
          "kid":"MACG-BP6N-3XDH-2FFJ-C4VH-7ZCE-Q7LE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"YYs94LbzgffGtIgjgvvhlBv1K_XWyvwhg0cQr-554
  tk"}},
          "wmk":"kKwrVOaiOnWrS5c23QY3CxAvvIMaB5iwe_JaSpAo57fAFlfi
  efe9mQ"}
        ]},
    "Yh90t_7kZVtzbuCbDysvZ1BJwWd2LgqN7EdDo4DAfyH_-FRfzbBGeiPU98vO
  wBUAZ9fOmwZf7ZNPOJqJ8ZXTjg"
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
          "kid":"MC23-CN4T-46YO-SXWD-P3XR-BP4Q-6R2E",
          "signature":"sQcR8z1gYcGvb9seJv95FBrGRj1PwU-d5K4UvI9wks
  itiSPxG0lKJbpdyEAtOpv_R8ynXfYLYYHC4hJqDhBHCw"}
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
      "kid":"EBQL-7C4A-L27F-GZZC-CAQL-JJJI-GLPM",
      "Salt":"ppXoXnOKAfKmi-qor6ah7Q",
      "recipients":[{
          "kid":"MACG-BP6N-3XDH-2FFJ-C4VH-7ZCE-Q7LE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"8raSaF_M40O8wIw43Bo-i4-MEo4-ZAKI7FsgLrb9T
  3E"}},
          "wmk":"LrIGLn1onjz0i-x3ft-3xCt00NUdoYxpJ9ettnn5mo7tEvSH
  ZdlVaQ"}
        ]},
    "GE7ZrUzu7jZO1hT5ih3M4shn4-YyIKFvZeXJBlHii1PuY9_BKElvgJFs757w
  ktlbXSGAfZESFm8cYFOhLxTiaQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MC23-CN4T-46YO-SXWD-P3XR-BP4Q-6R2E",
          "signature":"yEp5HaPinpvfBpeLlnDR4hknY4GcjC7gJ8LN0wD8uE
  L-JROrCRGu7Q3gPJtLsAgDwnedz83Q7HCM8ndgwpqLCA",
          "witness":"HwLK2mG1fMd9o-ItELyKbOZRE5DLn9DndB3Zd_Do2C0"}
        ],
      "PayloadDigest":"X4StoPlsAJDjjswTAbaqMyqYWmJ47QUGHGJqbXelLf
  knc1mxuWmIdBubsl4GA15D4O122wZnyvo-evtXpyvZDA"}
    ]}
~~~~


