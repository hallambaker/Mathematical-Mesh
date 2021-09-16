
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"PBO-CJms9M1rwBwXNDe6PN2PILUq94iVPoV23K9PwGc"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"eF_pxE5Xs-An_cWJqZUfovJHdLUX7nH0aGwGM_6s-gE"}}
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

  98 2B 77 E8  FC 29 35 A6  EE 42 31 14  C6 08 2E D9
  B9 33 D2 36  D9 4B 4D C1  85 BD A8 82  98 E4 EE 46
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"S2C02O145-5Q_P_GAQLBKXfDTI1jACcWqWTjFOQ90pE"}}
~~~~

The key agreement value is calculated:

~~~~

  1F 14 CD 78  98 6E 06 F5  D4 CF 68 05  56 0C 1E 10
  E3 43 CE 2B  92 25 6B D0  38 80 C4 79  19 F8 8D 1C
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  0F 8D 34 27  26 E4 EA 9C  55 1A F9 A2  04 2C BD BA
  43 7F A9 E8  56 90 9B 69  9C 93 4E A8  92 94 89 EF
~~~~

The wrapped base seed is:

~~~~

  86 A9 81 34  D0 C4 81 11  91 20 57 C7  AB E5 FA 4F
  19 A8 08 D7  5E 07 37 C4  FE FE E3 7A  6C 49 A5 4B
  96 51 0E BB  3F 35 A8 1B
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  72 3A 85 15  92 1C 31 81  82 0A 10 09  63 23 B9 08
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  5B 2C 64 16  5D 0B CE 6B  7C D4 06 A6  00 8A 38 E7
  9E 33 87 C3  83 14 2F 4E  11 C4 E8 71  77 96 F7 14
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  2C CA 61 E1  32 5A A8 04  56 FE 72 13  4B C5 CE 9A
~~~~

The output sequence is the encrypted bytes:

~~~~

  51 3A 8F 18  E4 6E 07 FF  5B C3 A2 DF  D3 E3 CC 7C
  39 CC 79 C4  0E 9A AF 32  17 FC 25 28  37 0E EF 22
  AE 18 A9 42  5C 40 D5 AF  19 18 0B 82  F6 C7 2A 7A
  63 91 6F 7D  88 AD A7 35  55 14 07 0A  CE 0F C5 1E
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQJ-B527-AFLA-O3FN-PXO6-DVYS-FX3O",
      "Salt":"cjqFFZIcMYGCChAJYyO5CA",
      "recipients":[{
          "kid":"MDNP-E33Z-R2YO-HUM3-AEQH-YTER-2O5F",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"FzOwzdpLQIg0YmJdFtRodBsIJkTGC_f1XUnlJYUc7
  ig"}},
          "wmk":"AwfdWCgqAT-FT7GFxWCH3rmGXHUgYfGBvERTOjn9XvEP034u
  A-5LVA"}
        ]},
    "UTqPGORuB_9bw6Lf0-PMfDnMecQOmq8yF_wlKDcO7yKuGKlCXEDVrxkYC4L2
  xyp6Y5FvfYitpzVVFAcKzg_FHg"
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
          "kid":"MCCK-354N-NVZZ-P4FY-YRE3-YM2K-ILF4",
          "signature":"-gT3MXamb4MU_eIeQgzN0uC7Hp495HaPpfFAp5tK3y
  cu7uQMVLqD3wQsXKZ3mEN_hIBcMXeeWrWmOd21oPYZBg"}
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
      "kid":"EBQE-S62S-RBZ7-GKT6-T64K-YYWB-HVEU",
      "Salt":"au-dM8A-N7hh0Y3H8DlUdg",
      "recipients":[{
          "kid":"MDNP-E33Z-R2YO-HUM3-AEQH-YTER-2O5F",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"GJGGo6xat-XBZAmdRi3KsHeNfJQbxdfN1VnUscHRA
  k4"}},
          "wmk":"oWr60jpehWp_JvzGU38zI3hWk7lF3AIJim93ZSg21FTTGAj2
  -xSqTw"}
        ]},
    "7hYjMLGmdqSX5NQqcr3uYb1KgANb6XxxHybNdXF73u-RdL0tsHUvT-RYiVFV
  AnA56TEvIqxMhxhtlGTweAsMiA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCCK-354N-NVZZ-P4FY-YRE3-YM2K-ILF4",
          "signature":"6O11Ou7ZPlA1b4q7XrglUxsSgfjtrikKCLnX_5x6w0
  eyjiAF4lFL6w9wQRLW4WYW5RdVKjW60y_XMbl8T7QyDQ",
          "witness":"xmwbkaFCf5EwPzExM_SBFwwIyCcKfodZh46qvgPW0Lo"}
        ],
      "PayloadDigest":"p8fckNR_hbEAakIg0DkB6XOYukYjzSqkGRFjRvuPzn
  FVKYKRiliNicfqdF57Hkgg0tdSmkzGUbyoJc5WctH1kw"}
    ]}
~~~~


