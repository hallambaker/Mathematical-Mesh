
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"HawKMMGYCmQkL6hSqMJYIclx9fMm243u_63giLa22ns"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"UnysF4ZwBNhgtv5iW6fumnbrDJGN0svuK1vmTS5llMg"}}
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

  CF 80 F2 42  21 C2 3C 09  56 88 64 91  C1 D2 F7 5C
  96 7E FC 02  D5 3D A4 96  E4 60 77 3E  C2 2D 5F 89
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"Ul2pAC1E4IjIS3unz2czwRMPym762yAgD_djh3yu04s"}}
~~~~

The key agreement value is calculated:

~~~~

  73 72 62 C7  0D B6 03 4C  CF D4 68 5B  F2 54 70 E9
  E9 F6 42 FF  2B B3 8E 2C  20 16 B0 68  FD F9 07 A2
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  B4 11 43 06  A9 0D 31 CA  EC 5D 8F 08  4A A9 5B 33
  AC D1 09 67  04 9F D4 32  8A 7A 7E 1B  9B 54 B1 6F
~~~~

The wrapped base seed is:

~~~~

  72 DD C4 52  C3 AA 6A AC  E9 C4 93 ED  55 35 6B DE
  8F 27 02 DD  D5 90 15 D9  2A 9E 99 6D  DD CF B2 33
  52 31 B8 FB  B7 B9 1D A9
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  5B 3F E2 3F  FB 71 9D 97  4F C5 48 17  57 77 98 87
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  83 01 22 A6  9E 4A EC 8C  E3 E3 B7 83  10 CA 43 E9
  D0 0B E3 E1  99 D7 45 86  5E 51 5E 67  88 22 FC 06
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  8D 44 87 83  FF F8 6D AC  9F A3 71 69  26 68 6D 54
~~~~

The output sequence is the encrypted bytes:

~~~~

  D6 4F 50 8B  AE 8C 26 2F  73 DF 1B 85  FE 7F B1 48
  C9 87 45 06  37 80 00 D8  81 05 2E 44  46 1A 78 78
  01 4D 18 77  2B F9 AC 5D  FA 27 5B 2A  A4 B7 6C 56
  25 C7 17 44  61 DC BE 74  86 71 B3 5D  B4 F7 A8 4F
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQP-U5HP-UPPK-B442-HBQT-BQ5P-OTKE",
      "Salt":"Wz_iP_txnZdPxUgXV3eYhw",
      "recipients":[{
          "kid":"MCVI-JPOH-L33G-ZBOE-74VA-SRNR-EAVY",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"nNqy1Mmt9JfN3piE3KtTwH2pkxnSCsfEio2ub07HF
  h0"}},
          "wmk":"1bufE7Zpi5OVHR_qUFuqoWjUrmEhKW_Dc2Es6AQ_Y1IdEEH3
  HmnmwA"}
        ]},
    "1k9Qi66MJi9z3xuF_n-xSMmHRQY3gADYgQUuREYaeHgBTRh3K_msXfonWyqk
  t2xWJccXRGHcvnSGcbNdtPeoTw"
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
          "kid":"MCC2-A7MT-WD5H-EA2G-KCOV-TL4W-MDED",
          "signature":"l53GNGsr8NrEXqk_2WPH5igTqAXjOHAlQHoseqYpRG
  lwas2E21eFp2fQfE2N9KeSdvzFVmBertWQFWjSYoJlDw"}
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
      "kid":"EBQN-T2NB-WW4R-OKLT-O33C-6FS5-AVA5",
      "Salt":"meWtVYIbRsxBdcOaPqPn0Q",
      "recipients":[{
          "kid":"MCVI-JPOH-L33G-ZBOE-74VA-SRNR-EAVY",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"_85d2KWQGTyJRrv3aK6phHRuf-42vi5M77mpfxKRg
  78"}},
          "wmk":"POdfhyoHPr8sWDv9SpiGQxTaZpDQWNgG_ueZT1HWVFG3zZ0M
  I1kGnQ"}
        ]},
    "XD-S1ROPqNPt-E60QIOdgg3yaCyQg_12ceXAVVvEnVqFxxobP1I-dH3NLxg6
  DAEULT-ylZuiwLjCgfI3qOJD6g",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCC2-A7MT-WD5H-EA2G-KCOV-TL4W-MDED",
          "signature":"OFIpAMrZm7KF-QaBhcgvtYyE9nOfrgmHuY_dT9QNlW
  0KBSlcO0-bSQxV3I8qL0FhHICpDvDBDsQ2EnnZNO02CQ",
          "witness":"-E58onGujyFN7BN8nuHLwaHqnrgIgzocE1HTqPcPeOQ"}
        ],
      "PayloadDigest":"uabW5RuK-IBQU02j2q1eS9S7-Vnmz9-ru7u7bBLm21
  z_H9wG609cswC-is3G2OSEOjTk3bOTPQrHFJ-Sm_Se3A"}
    ]}
~~~~


