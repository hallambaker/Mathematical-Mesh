
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"-Uye7_hgOBKAkc3z1bVe-kQPZ8gLMCsds5I1B1kdyfg"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"3sqB9SW-AeblQgp1LpQAaeyNwTe9zIL8kCHREN0Z5aI"}}
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

  65 01 C1 19  7F C7 54 2A  EA 1B D1 03  67 D9 B8 BA
  88 C2 D7 E1  7D 68 CA EA  61 D5 52 88  74 11 BB AE
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"LHFGKaKzQQaJjXOOteGaT0HHM8nnVh7XKQYzgXJEyQ8"}}
~~~~

The key agreement value is calculated:

~~~~

  2A 96 D2 30  2F 76 BC 25  E2 79 BD 6F  02 FB E3 6C
  3A 9B F1 78  66 30 8A 7B  8A 0E BC DC  AA A9 06 D9
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  D4 EC FA 89  F8 44 43 11  63 08 3F 9F  30 06 82 04
  D7 0B B4 99  18 62 3C 2F  E0 A4 4A C1  3A 8E 5B 9F
~~~~

The wrapped master key is:

~~~~

  EB 17 34 1B  15 83 71 E3  F2 34 BC 8F  28 22 4E F2
  21 CE F9 EE  46 DE 85 56  3B FD 6B 70  6A C0 F3 AF
  C5 B3 D4 37  02 DF 95 0A
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  14 66 1C D3  61 43 AB 33  80 5B B3 AC  12 C2 BF 73
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  C9 6C C5 4D  E6 08 1B D7  11 18 33 6B  7E DC CC 5E
  0C 31 28 00  2E 61 1A 85  B7 00 EC 99  22 94 B2 5B
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  D2 D4 EE 1E  DB 2E 84 1A  B7 44 2A 76  50 16 AF 49
~~~~

The output sequence is the encrypted bytes:

~~~~

  C1 84 BD EF  6E E7 C9 04  CD AB 88 03  D2 78 E2 14
  B5 5A 4E D2  79 4D F5 62  6E 27 1F 6B  56 2F 7C CC
  C7 51 3E 77  85 97 7A E1  DA FA F6 69  6D 73 26 26
  96 F0 FA CA  F1 E5 37 B9  57 03 64 FA  F3 A0 1E 72
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQL-3XPM-4TXF-HEMW-IETV-OE7R-T6RL",
      "Salt":"FGYc02FDqzOAW7OsEsK_cw",
      "recipients":[{
          "kid":"MCUG-LA4F-7LOS-Z2JR-MNMJ-BEL5-654X",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"L8Ao9kViM5R5VXejYBi7q5W14Kag3SrlI-Rfrh6-t
  X4"}},
          "wmk":"6xc0GxWDcePyNLyPKCJO8iHO-e5G3oVWO_1rcGrA86_Fs9Q3
  At-VCg"}
        ]},
    "wYS9727nyQTNq4gD0njiFLVaTtJ5TfVibicfa1YvfMzHUT53hZd64dr69mlt
  cyYmlvD6yvHlN7lXA2T686Aecg"
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
          "kid":"MC27-POUO-6LAV-IQMY-EMXG-ZAI4-27P5",
          "signature":"WZfzGwAoVYItkIzACC8PI376fuFVxOaFKlzLuqqoCv
  2Ig9eRX1idcB1B4ijK0yTUvFBtB4y5eeNR-lp_8KpYBA"}
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
      "kid":"EBQF-GAG6-RXVB-E6FN-Q22L-DB5M-VP3I",
      "Salt":"ZgKze8-JB-2DT5MziGwbUA",
      "recipients":[{
          "kid":"MCUG-LA4F-7LOS-Z2JR-MNMJ-BEL5-654X",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"7EIpiRO3znZLzB4RcpJIFMUfU_cH1GQqm_dEArqgd
  Fs"}},
          "wmk":"CvI2fpurkp-8hcXmX1jAHFoNczYKKTw9LIJtenGcFanmyZKF
  fGZeZg"}
        ]},
    "BCGSlTBDwcmh_fOs1Sc95FiAuzJYu_wGU54kHOCdZt0VDxxqqGVy6EZ0oheX
  opmlOaYNZluArErSiDsuqvjeZA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MC27-POUO-6LAV-IQMY-EMXG-ZAI4-27P5",
          "signature":"zm_BKVAs7AmOAl3q9Di-mEAvx3xglbgaNTgXenmIbq
  hUgXFI5qH-mVxd0rUYWnSBeCgx-8MWjeEQSCxwefWzDg",
          "witness":"11qUMvtqF2Kv5CJzisi1M65MwEFuRQicYsiyNSk_PNk"}
        ],
      "PayloadDigest":"VjLfgk-YvUCIn_DRJ2HuHGD-5Y9AM7VtejkaoGFgs_
  7AodH6pZQy9kRcoXLGMCzQhgsqZi9hvCRmMX6awrAx2w"}
    ]}
~~~~


