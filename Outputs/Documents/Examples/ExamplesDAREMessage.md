
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"2Lri1UfTwQeJguUgnl5JE3OQqNS-pb5eo8CtWABH9vE",
    "crv":"Ed25519"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"dG4pXBUI4sd9qEpm0ww2ztEXZqBq0HL2vovGJban4Yk",
    "crv":"Ed25519"}}
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

  92 FC 14 D7  B2 42 7C 1E  98 55 4A A4  F9 6C 32 5F
  EB 91 22 51  6A E3 E4 07  09 24 71 43  F5 5F E5 CC
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"sYBNWdswbRawLW55xtZqEU2IySEdAPqUfdGT-Wz3liM",
    "crv":"Ed25519"}}
~~~~

The key agreement value is calculated:

~~~~

  FA 58 F8 67  2D C3 94 F2  CA C6 63 EF  9A 6D 9D E9
  16 48 C3 F5  F6 EE 2F 42  00 29 2C 2B  4F 8A 70 BE
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  8E F5 84 AB  88 CF F0 FF  A0 48 8E 3A  D1 38 47 DA
  8D 07 36 CB  B1 A7 CF 6D  4F 92 E6 71  69 92 36 AC
~~~~

The wrapped base seed is:

~~~~

  D5 E0 C3 3C  8D B3 33 35  E9 9A 06 46  79 21 89 39
  3C 8E 4A 19  7B 3C 65 B5  2D 4A 57 94  4A CF 50 B3
  41 A7 4B A0  BB 12 DD B7
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  9E 35 08 ED  BA D6 4C 9C  B7 63 FF 28  71 B5 ED 4A
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  98 82 DB 8B  7A CE D5 0B  1A C1 A5 E2  C1 D5 A3 68
  0A A6 AC 1A  02 BE 98 F0  97 DA 5C 61  14 AD EA 88
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  5E BB 1B FB  44 C3 EE 91  55 47 B9 74  E1 70 93 E5
~~~~

The output sequence is the encrypted bytes:

~~~~

  2A 4E BD 59  67 E8 14 90  A4 6B 5B 43  D7 BA A8 4E
  87 56 C5 B4  E4 E7 97 2B  30 FB CF A3  D3 D5 D9 59
  72 A5 78 FC  A1 8C 8C 85  9D B3 0A 15  2A A1 D5 79
  45 77 8E B5  2B B7 12 12  D2 3A E2 DD  7B 40 66 6A
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQL-5LOP-QFZQ-UAT2-LND5-IJ6J-HTAK",
      "Salt":"njUI7brWTJy3Y_8ocbXtSg",
      "recipients":[{
          "kid":"MBSN-WL7P-L35O-O4DY-EMAO-LGUS-B6QW",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"mCUHfKUboCWmNy5vi81nquAqcdH6_YjRFIFbMLr6Z
  80"}},
          "wmk":"t1HzvdxWvm0_CQlpBCzr3SL9jTPDmZ0_LaDu0DhhEKQCXdCY
  F1IyKg"}
        ]},
    "Kk69WWfoFJCka1tD17qoTodWxbTk55crMPvPo9PV2VlypXj8oYyMhZ2zChUq
  odV5RXeOtSu3EhLSOuLde0Bmag"
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
          "alg":"ED25519",
          "kid":"MCXB-T4GU-QXXJ-EVDH-UNPN-O56O-TJ26",
          "signature":"U1peoqyfrqY5YDkbA6O_dkuPvq6-Br4XD13-LQNuNl
  sa95bsHf4CtAS1oYMXojg3R0sYfvWTlVfYUku9LrIZDw"}
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
      "kid":"EBQC-ERK3-5WTI-LQ5D-WMBA-4DMY-YNC2",
      "Salt":"Zd8HADz9aQWwfvwySANqww",
      "recipients":[{
          "kid":"MBSN-WL7P-L35O-O4DY-EMAO-LGUS-B6QW",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"8x5TLgcj6pdAezqsBq7KFZWfRxx-uV0HLzL7QDvwn
  3s"}},
          "wmk":"O5Moi6cTSdmliUfOam4hdIuy8Ax0kJqkeqR8_UcY8X1ahYB9
  j2y1dg"}
        ],
      "dig":"S512"},
    "nhIWMFllaN6Q_micqcCYaC5D_NX1k-cUABHzd_mjalNJ6UGGeaCE8i6Dyqvl
  z3EMLFfuQnH0fFipcXgFezK0Qw",
    {
      "signatures":[{
          "alg":"ED25519",
          "kid":"MCXB-T4GU-QXXJ-EVDH-UNPN-O56O-TJ26",
          "signature":"Qr9F7Od1ni4fWZCuCxy9darVMOZer53F386qQmiy-c
  W8fx2nHxWcYHXBQl8PcSWvNjJt6BEDuojs_6t3M7umDw"}
        ],
      "WitnessValue":"V6zN9sbhDtQOtXaCp2meJG1W0qOBuuOhFuuKMAwoVRU",
      "PayloadDigest":"7QX58jG3VEfom8jEi2Pp9cpCY9-ScDz6RLWsZoh3ll
  GQYN7Kabd89qiLO9qctk6wDpygzMYhXngRXvnQFwH-iw"}
    ]}
~~~~


