
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"YX39DIWEBqxIJOBjR1yPNubhuB4oKmyz_f_PZk2Wft4"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"i-OxFUS-3GO0ftVIy3TYOAPWBjOnz3ZUNqLEdIx7stA"}}
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

  E6 71 C9 D3  99 29 57 00  01 C5 DF 54  5C 81 1F C6
  75 BF 99 11  EC F9 92 BA  4B FF 5E B2  0A F4 E8 8A
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"v1EY8ZhRS0pkHVz94JNyFA_RPhfcsdxFjYoHWe2LN84"}}
~~~~

The key agreement value is calculated:

~~~~

  29 53 00 38  88 B1 25 C0  4C D6 DC 4F  D0 C3 BD EB
  B0 B9 97 E7  CD 95 A0 8E  AF A6 FE FD  18 A0 65 58
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  6A EA FC 8C  42 63 BD 42  A5 CC 41 6C  3A 5F 45 EA
  5C C8 E1 8F  CA 41 3B 5B  B1 14 33 1D  08 08 38 2D
~~~~

The wrapped base seed is:

~~~~

  37 72 90 D2  37 02 CE D6  CE 31 23 B0  72 FC BF 51
  D1 8D B0 B2  FE 3C CB 5D  F7 F6 4C B9  6A 93 E0 6C
  C4 21 78 F7  DD A1 E5 29
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  B0 5D 23 F4  DC C8 92 EE  CE 02 F7 33  96 5F 23 37
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  09 A5 BE 8B  F7 48 35 A6  F0 E3 07 3C  9D 47 B6 1B
  1B AD 48 BB  99 E3 2F 92  CC FF C6 3F  EC 3B 37 6C
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  69 85 92 7A  4F F3 A1 C7  7A 04 20 90  9F 43 0E E8
~~~~

The output sequence is the encrypted bytes:

~~~~

  92 58 64 D4  AF 6A 3D C1  59 2F ED 2B  02 EE FA 53
  9A 21 F1 57  F9 29 B6 5C  9D 71 1F 69  87 3A FD F8
  26 28 54 99  12 83 07 AE  73 72 45 73  8D 0F 66 9F
  1B F8 B6 A8  F7 F9 10 14  4B C7 23 95  96 9C E7 A2
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQK-WRSP-WK6E-AVC5-2ZQI-PZ5K-2K6I",
      "Salt":"sF0j9NzIku7OAvczll8jNw",
      "recipients":[{
          "kid":"MBUX-V4NE-VRJS-6NT7-6QKR-DE2W-QQBG",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"LE55Fn_dDQFZvzlJvYToyy-GmKcHD4zELw8U6WWZK
  qk"}},
          "wmk":"Q6XR1OPMdCNSaJ2Vd-BsdWNkAl5SMm3Hho6uoPmWPfVoWzeg
  WF9boQ"}
        ]},
    "klhk1K9qPcFZL-0rAu76U5oh8Vf5KbZcnXEfaYc6_fgmKFSZEoMHrnNyRXON
  D2afG_i2qPf5EBRLxyOVlpznog"
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
          "kid":"MAR2-RQDD-TLR2-UQP5-YCU5-26Y3-YWCZ",
          "signature":"araqhHqBT0RZa5qlXgtBS0udR3jdtSvlUiqNdsUlzd
  mjmbqvt83WKGmcS07JvLufqfF9delLCK5LT4yuAlO8Cg"}
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
      "kid":"EBQN-KLCB-QE3Z-S4IC-Y46H-MN7G-FVSC",
      "Salt":"9_yqbGfRxVimraQfhaIFZQ",
      "recipients":[{
          "kid":"MBUX-V4NE-VRJS-6NT7-6QKR-DE2W-QQBG",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"OT13Sphcbw3rDkKJdjtf73V2Ji0WlelQnULdE88Aj
  20"}},
          "wmk":"o9WQhJKLmnMG39XgxOMAruKNauSiKudfNvZnlFUUsj5YqTC_
  eMpHXg"}
        ]},
    "gYktKBTQrq_lcFbGcJp7qT-BciaMw5WZ4-oRnLiLcu-87pDrOETXNl8yWG_p
  g1zyDeyGkvcYPgHIGzZ3O4zGSg",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAR2-RQDD-TLR2-UQP5-YCU5-26Y3-YWCZ",
          "signature":"iI0aJ271ojzRuTln6nr6Q_HGQO15mehYlMZSmXznmZ
  iFkwB9tY-J-5ASmNhntFeUBeFJkocfGw225HHG9pdsBw",
          "witness":"G9x6MI7_vEAK9bLN97ZgzzZeXGO1A8bGY53CmwSkVwE"}
        ],
      "PayloadDigest":"2Nw9Ydgm-aEoc5i4TwqT8lAuruwEtpfnj3KeLZsqoI
  j5SpsR613RjlIhDhsd2p2Tb2QS8eXD73csYNnlmA8G1A"}
    ]}
~~~~


