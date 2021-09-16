
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"nUwTVFq4D_O4Yn6fiYxBY6a-ph1-f0WYlCsyr-u9elA"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"q58OixOIErtFcrf1IxVCfgqTfnRc5_4lvdsn0jFz9qA"}}
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

  5A E7 6B 0F  38 A3 28 84  BD 45 89 70  B1 78 33 40
  9C FD 0B 44  76 77 8D D5  3D 44 CD 97  9F 75 EC E6
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"vOO4sV1HefMdOUjdoP3v59fZilnCterB54iriqc0K04"}}
~~~~

The key agreement value is calculated:

~~~~

  D3 46 37 12  1C C9 EC 9C  87 A4 0E 1A  03 11 3A 77
  30 A3 8A 7A  8D 79 E6 2A  42 D5 CB C7  16 C6 EB 9E
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  FA EF DA 34  62 3D 3E A0  93 A9 7C 0B  35 F6 B3 AB
  23 FA 92 CE  36 B9 F8 82  AD 28 93 A8  E3 3E FB 42
~~~~

The wrapped base seed is:

~~~~

  DD 7B 5C 60  EA FF 28 93  29 07 50 BB  52 36 74 39
  00 0B 21 B5  4C 18 7D 76  F2 24 3C F5  36 25 75 A8
  43 9C C3 59  4D 0C 28 21
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  B0 60 2B 83  2B E1 CA 28  31 06 5C E5  0C 38 9F DB
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  73 7B 72 D6  A4 89 67 9D  F7 E7 77 7D  23 A1 41 41
  7A DF 8C A9  36 9E 0D 4C  DA 5F 30 01  D3 46 B0 11
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  55 94 FA 4E  6D AD 21 C8  F7 D1 42 70  92 F8 4F 02
~~~~

The output sequence is the encrypted bytes:

~~~~

  CA 38 0A 94  97 17 27 EC  34 31 12 88  19 03 29 75
  FE 6B 05 89  70 F9 CD 35  7D C4 51 AB  E4 8B 86 F1
  01 1E 86 B4  5B 34 BB 38  BD F9 ED 39  EC 39 A6 6E
  EB E6 64 91  04 4E 77 CA  F8 95 45 CF  07 E7 E7 08
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQM-BNKD-D2F2-M3EW-W4TF-XLIZ-RVP3",
      "Salt":"sGArgyvhyigxBlzlDDif2w",
      "recipients":[{
          "kid":"MBX7-7SMG-JGVM-FXQP-6HPY-7OND-NXTR",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"mf2EWC4_R1oPJLsLuqTSqOvGM05VYXqXDH06eaAwb
  l4"}},
          "wmk":"O3US7xbHjSnDzNZCw8vrTwDcadPCH3JmqS5B-2d1sQkDHRS2
  hNmoHg"}
        ]},
    "yjgKlJcXJ-w0MRKIGQMpdf5rBYlw-c01fcRRq-SLhvEBHoa0WzS7OL357Tns
  OaZu6-ZkkQROd8r4lUXPB-fnCA"
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
          "kid":"MADC-FI7V-3IZV-IEPO-EG2I-NBNQ-2MQ3",
          "signature":"SWIWx4mdvhWClxktaWo2h9foUaaFYnZGYYHE0x6TxB
  gvmGXD-gq2Ai5r8qKlRNJrdfp_U4KevEPvXguqF24PCQ"}
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
      "kid":"EBQK-FJIF-6D6U-CWH6-2EZX-HHUW-AQQM",
      "Salt":"Z8UP1HTtTVhscaWgGNWB1w",
      "recipients":[{
          "kid":"MBX7-7SMG-JGVM-FXQP-6HPY-7OND-NXTR",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"Rp8_KWKCKqgeP9yAPkhWraYm71xgGGHkac3x-70zy
  NM"}},
          "wmk":"uGkbeQAfI0Ifb8h8HFsiP59hbZVgzV4Rc_R_37vapu7d-WEv
  NNIq8w"}
        ]},
    "BS2_4TR4h8B5dCrY8jiG1wArSoV9o6lNNlDSd1vwMgYUPU-568lFApAr4Z50
  VYuVbjqPxBv98pUpzOWSsbWVgQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MADC-FI7V-3IZV-IEPO-EG2I-NBNQ-2MQ3",
          "signature":"vxyEYmaL2dxRsZW2Q8lKBmQT97Uz2gRh5_QaxN0XT7
  o3cvUCg977wQhBqXEiPtIk0QEPN6BkIUy4kCMuk7aFCw",
          "witness":"5A3Au7cm3n0H8opn9cfbN5J019f3L2mA7VJH8Lxmo70"}
        ],
      "PayloadDigest":"UyvtbR3QsLudpE22MCHo2azV-NlDuwc_lxEoaX3gr-
  oYefhzOmxLiCTYJusKT8Wt75lMfPU0gbjI_AKSKiOmPA"}
    ]}
~~~~


