
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"ZTpkcKy-6Q_meq-jbtUJNjVCcC0G7udaagPGKtYywjY",
    "crv":"Ed25519"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"zNBnGilzHnOQ2CpoQGZBNM7Z5FmqvEqQaPl3_hNJIJ4",
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

  69 CC E0 59  36 2C A3 AC  B5 BB F3 6E  02 C6 2F 9C
  62 C8 F9 01  25 F9 BF 95  27 45 50 3E  34 EB 3C 4E
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"ya_wfOr6qUsC-SK007UBc4_N-rgJOA938gHYAtwmYK8",
    "crv":"Ed25519"}}
~~~~

The key agreement value is calculated:

~~~~

  E8 E9 98 18  3D 76 7A AC  40 F6 A9 17  59 9D A3 E5
  6F 3D 33 C8  5C 72 3B A5  0C 1C 0B E5  77 C0 BC 60
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  E6 05 E7 B0  CA FC 9F 71  6D D5 D2 51  EF EE AE 13
  7D 0E C3 41  3C 43 6E 1B  F4 C3 DB D1  F0 74 90 3C
~~~~

The wrapped base seed is:

~~~~

  58 D6 F9 CF  00 B3 ED 14  C9 54 1D 67  CE 5A 9D AC
  49 54 34 07  58 30 2C 3E  C3 26 4D C7  72 6C 97 7B
  39 A3 12 79  DF BD A1 D3
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  5A 14 91 3A  02 37 54 28  EF 3F C5 CD  19 75 40 A8
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  AA 25 C0 99  EE BA 06 60  82 A1 5E 1D  F3 BF 8E BA
  20 99 94 3A  92 6B 4D 97  6B B9 3B 25  7C 05 F0 CB
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  48 D3 64 35  CB 41 A6 6E  9D 5E 4D 11  85 C0 B3 7B
~~~~

The output sequence is the encrypted bytes:

~~~~

  20 88 B5 BD  F3 50 6F 35  1E 02 E0 50  96 8B 7E 0D
  FB 42 42 67  EB E9 C4 86  0E 79 80 A8  B5 34 4F 66
  31 8A 99 67  BD 4C 14 92  46 6D FD 68  FF 6E 1A DD
  3F D6 D1 41  DF 61 DD 0D  6F DB E9 84  9C 96 3E A6
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQF-ULB3-QRUJ-DJ65-VW6U-DCMS-7IUW",
      "Salt":"WhSROgI3VCjvP8XNGXVAqA",
      "recipients":[{
          "kid":"MDBD-G2N6-CEIS-LQJ5-NNTO-PAHD-OJKW",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"9eX_-YhN7TaNYxTLR-4m1D424Bb5Oee1yDiYauwvR
  uM"}},
          "wmk":"rVnqGDdpDtIr0vlNtOFR1XZsHgt-xCsmnct7CBTx8dfcd9CI
  N6-IpQ"}
        ]},
    "IIi1vfNQbzUeAuBQlot-DftCQmfr6cSGDnmAqLU0T2YxiplnvUwUkkZt_Wj_
  bhrdP9bRQd9h3Q1v2-mEnJY-pg"
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
          "kid":"MBNF-MADB-OAZ3-7JOJ-WCQA-LQEK-JZTT",
          "signature":"HjotuHPSvOCJ8-qmctwpwfr1oTBlKV_zS9SwC3Rewd
  tpfVDOYMbfcY65ppf08lc5a158zNzohwpecH09_RUnBg"}
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
      "kid":"EBQE-JDZA-O6SC-THAF-SY5Q-27HI-N7M6",
      "Salt":"Q0WHe4ToWVPt8B_yZMsTew",
      "recipients":[{
          "kid":"MDBD-G2N6-CEIS-LQJ5-NNTO-PAHD-OJKW",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"wi5FlXOMcCjzMtB-zo2TBjCUKeqMvAFs3JWsrxtbd
  fw"}},
          "wmk":"tScSFm_ixIAFV4uGXiwbflJOlEmI2vEocGXh7DWgOYFcl4Br
  _DTzkg"}
        ]},
    "urNDz3AmiSBuVbkXE-AltI8m9Xkt0q1Ar24hlcrNrCQ21xiykC_iz39p1jKz
  KWNJssLgR8NWyTSzzkZ00FXlvQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBNF-MADB-OAZ3-7JOJ-WCQA-LQEK-JZTT",
          "signature":"54QC4ridASGMyMlBj7b9iIruU0RuF3QBZYbHvsfRdj
  WrDkoKWRFK1LDKYJ1b0asv8G_zuR4IoLJbSS_ayVTBAg",
          "witness":"OPjhVd75ROFKAMzXWS70zyNqMN5PD30xb1kaSzZ_u5E"}
        ],
      "PayloadDigest":"RVr3LlUYe-19Q3HIQeUQAjqXYZ9b0V7ehdxBNm9tU6
  SxQEYWykL_eq-h4qu5xTbNUdfvtMS6mEcbIJpFG19rtg"}
    ]}
~~~~


