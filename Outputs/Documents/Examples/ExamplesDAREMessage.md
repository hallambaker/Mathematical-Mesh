
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"ZEciFkOwo_gl5BeWV8NTEzQbsGWHlilNwstRomVWbqo"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"6ySU4AI8ilSq7xsz2etam6XkOUuXl1Hz7z1NpBWJL-A"}}
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

  54 52 B4 A5  2A 37 BA B8  3C CE 2D 4B  D3 8F D0 08
  8B CD E2 BF  B5 32 82 90  34 F6 19 D9  39 90 F5 9F
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"K56Lh3gjh9_WPO-6XF3CIUIxxqOTOnEe2T3_59Q-BRE"}}
~~~~

The key agreement value is calculated:

~~~~

  F0 26 0D 3D  B6 E4 21 67  16 C9 CB 01  30 72 78 F9
  2E D3 99 0A  FB 90 46 CF  F7 C7 4C 3C  1B A6 E4 5F
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  F1 2F 66 6D  D6 6A AF F8  02 74 8C 51  2C 2D 0C E6
  5C 6C 07 CB  B4 60 66 50  8E 9C 7C 64  EE FF EA A0
~~~~

The wrapped base seed is:

~~~~

  D5 BA D3 97  80 43 81 E3  06 AD 9F 8B  9A A4 18 4D
  CF 09 85 A5  76 B9 C9 64  B8 48 74 E4  81 22 E1 1C
  B2 B6 A2 EE  66 C1 CA 62
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  1B D0 87 6E  08 1F F2 31  8B 10 6B AF  E0 DA F0 5F
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  2E C2 E1 53  77 D6 E3 1C  8E 86 34 58  D3 62 60 24
  57 03 0E A3  E1 71 FD A0  51 D7 5F 48  87 F3 18 14
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  F2 8D 2B BF  CE 66 42 3E  08 3A 58 DE  F9 C2 38 11
~~~~

The output sequence is the encrypted bytes:

~~~~

  1D 33 12 F1  90 99 C9 5B  C0 CF C9 6D  AE FD 5B FE
  14 A9 36 E3  6D E2 55 88  09 53 5F EA  1B 1C 01 14
  36 FF E7 3A  2D 08 62 6D  B3 93 AE B9  BE 2D A2 B3
  85 A2 25 C6  5C 35 9E E4  40 90 B8 54  9B E0 1B F1
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQE-BCNP-BAJ3-5NCO-MOCA-ZYT6-J3NE",
      "Salt":"G9CHbggf8jGLEGuv4NrwXw",
      "recipients":[{
          "kid":"MDOR-K4XI-VOE2-WMZ5-245M-WRTP-LT46",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"dWWfnaxRuxzynP9kPAYbVb7qFFtCH-x9lLRdWx1Sa
  pU"}},
          "wmk":"iVcbYu9eL_x7yVJo9OoZZdydgW5r7D50xtxiA2yhUayXc-NJ
  2AmOXQ"}
        ]},
    "HTMS8ZCZyVvAz8ltrv1b_hSpNuNt4lWICVNf6hscARQ2_-c6LQhibbOTrrm-
  LaKzhaIlxlw1nuRAkLhUm-Ab8Q"
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
          "kid":"MDTD-6EFX-UWJ4-S5LO-E2WB-LDH7-J6GI",
          "signature":"u54bEQs8RtCinhjXSdxt-1ol_ipY-dfKc5ZoU7kLiT
  GueTHrWr3SeO0wo2cbV-FXCMvUbk49ZlsRUe-os8geBA"}
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
      "kid":"EBQC-EW5L-FV6E-WGF3-7G6J-NRRJ-2DBS",
      "Salt":"msLctDTqPUe_hwttcsoXgQ",
      "recipients":[{
          "kid":"MDOR-K4XI-VOE2-WMZ5-245M-WRTP-LT46",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"RctOUBJtOJxPe-54A6ZE-5TB7Rt5Of8NqEC1L_h3i
  CA"}},
          "wmk":"MbHl6zsexc8Zp9xI17m71ZW2mbKE7Eull5WnV5y75yfkCtMT
  YtZ41g"}
        ]},
    "wv9ObrsQqNE_itjse91jcYqdDOGCOxkCUKXFZGRwSnmpTqBG1Zm7eyl3V35l
  HF7rAF54WUAYT-8xtwtW-NEjAA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDTD-6EFX-UWJ4-S5LO-E2WB-LDH7-J6GI",
          "signature":"pNBAgMfd0pJfdcQVfmftw9uyadMOvmQQFT5Bburs2J
  ZmulSGahZmpW92NaWvWugpkSmc1AqEtTT9AryaeOMVAw",
          "witness":"fVP6RzszioTLw4avfBqFwGydFWOT59TDmG7bG4k4GCk"}
        ],
      "PayloadDigest":"LuXadvLCEngKjT4LqAuyK6ZJppbffuH5bSileE4i7t
  WZ-5uOi0JweX5Hb0vU0_ydcliwFW6_XEre9pi5zM1Q8g"}
    ]}
~~~~


