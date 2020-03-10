
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"YVDc2lAAlRRTOp49t8-cS5ncpC9nD8QwE6KCbs_Iv8I"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"P7ZGsbYzQAT47Ht6QgYlMnun7rbYhyuWZFnmmbvRMGI"}}
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
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M"
    ]}
~~~~

## Plaintext Message with EDS

If a plaintext message contains EDS sequences, these are also in plaintext:

~~~~
{
  "DareEnvelope":[{
      "Annotations":["iAEBiC1TdWJqZWN0OiBNZXNzYWdlIG1ldGFkYXRhIHNob3
  VsZCBiZSBlbmNyeXB0ZWSIAA",
        "iAECiAoyMDE4LTAyLTAxiAA"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~

  B8 80 46 8D  20 9A 6E 06  1D 66 51 EE  C2 65 BA 4D
  A3 A6 E4 C5  11 24 91 EE  51 AF 67 69  85 F3 B4 F3
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"HcVhD-tsgNYYMWGglhSRs6GPRhCAfKnfqul4xOnWjM4"}}
~~~~

The key agreement value is calculated:

~~~~

  CD D1 1C 5F  39 F5 FE 75  EE BC 4D C6  EE 41 82 0D
  CF 32 6E 19  06 18 B2 5D  F2 2A 2C AE  0B B6 E2 29
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  EE 0B 3D 1D  95 B4 8C BE  60 13 46 E9  B0 2B F8 23
  42 6E 7D 4A  20 4B 3C 96  DC 2C 03 FF  F5 04 E2 18
~~~~

The wrapped master key is:

~~~~

  77 07 5F C4  C3 02 83 FE  4A 3B 08 A2  31 46 32 1C
  6C AA 2C 1C  70 70 2B E7  72 08 73 55  BA 10 28 29
  21 38 4D 00  CA 3A 4F 7E
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  0A 01 BA 13  4A 1F C2 4C  78 19 F0 50  60 49 32 E6
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  E7 02 E0 B6  C1 22 86 F4  0F EB FF 8F  10 82 1F ED
  F3 DB 59 B9  00 62 25 BA  79 82 8E C5  B3 21 76 6C
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  51 D3 87 C4  0E 3E 88 65  83 34 64 0D  5E E7 D6 6A
~~~~

The output sequence is the encrypted bytes:

~~~~

  C9 79 19 E0  B7 57 4D F9  38 FB 33 D9  1F 6B B4 01
  B6 21 B5 16  A9 8B 1E 8B  92 29 5F 48  B6 95 1B 3D
  DB E1 60 24  C9 44 3E AC  0B FA 25 1E  6C E2 79 97
  DA 31 18 64  62 79 98 26  7E DA FB 16  8D 40 15 81
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "Salt":"CgG6E0ofwkx4GfBQYEky5g",
      "recipients":[{
          "kid":"MAUC-ZTKR-N3D5-TZCI-K6IR-5Q5C-VKU2",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"zN9NE_98jmR3D0HB8sbbzOs5B_Yc0basc4Z9CxDHCTc"}},
          "wmk":"dwdfxMMCg_5KOwiiMUYyHGyqLBxwcCvncghzVboQKCkhOE0Ayj
  pPfg"}
        ]},
    "yXkZ4LdXTfk4-zPZH2u0AbYhtRapix6LkilfSLaVGz3b4WAkyUQ-rAv6JR5s4n
  mX2jEYZGJ5mCZ-2vsWjUAVgQ"
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
      "dig":"SHA2"},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M",
    {
      "signatures":[{
          "alg":"SHA2",
          "kid":"MD6B-BZ25-DIK6-76IL-S5U2-33BS-L4KQ",
          "signature":"sv-z5iBfBfQ2DD635M5ysM7wZ1kdiusp_3ek0L1C0tpc
  VOvdwIwefIY-y8gy7Wack-BjisrQr6R_t-kOlGWXDg"}
        ],
      "PayloadDigest":"raim8SV5adPbWWn8FMM4mrRAQCO9A2jZ0NZAnFXWlG0x
  F6sWGJbnKSdtIJMmMU_hjarlIPEoY3vy9UdVlH5KAg"}
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
      "dig":"SHA2",
      "Salt":"b1DTSOar_Gy2hEMEzH4VyA",
      "recipients":[{
          "kid":"MAUC-ZTKR-N3D5-TZCI-K6IR-5Q5C-VKU2",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"NWKOzIPkWK6WRIekz0LXdGpjOu1wcqqDR0WT2fyyq2w"}},
          "wmk":"ElI1Fj1xxowDiLbu0AAdb9slBZjQv9htXCsv3Dd6d1la8hhWky
  bOmA"}
        ]},
    "Uypt-b72evPGc1cVSxqaspKjFTNYWIgxowQ-gn8lF8_mjoN5Thf0esf4I9cYpv
  5dNFDyhOym_iK5NyWFXTEBig",
    {
      "signatures":[{
          "alg":"SHA2",
          "kid":"MD6B-BZ25-DIK6-76IL-S5U2-33BS-L4KQ",
          "signature":"4fEo2MdeXbp6cr97TTZXUvTpJQTu1WTAOrDFRmAzb4Ye
  faSrrRMvX4q1BB7q52YwqeybbW6aigpz9psRBhWbAQ",
          "witness":"iVib2Afu55V6CN1b3kl4HkN_4pic-wqt_tUp430tIJo"}
        ],
      "PayloadDigest":"kVieR-HvMSgpFQc4snccMW6iAfQVzkQFhlWbuB0bWA-x
  au2JR5e1PSCbm1vN05px2eZziNqaUw-dDxo9G1ekMA"}
    ]}
~~~~


