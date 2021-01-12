
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"qhi-uWjCmXSY1hPuGpPqoDx658cJ5B3JXleY87taqkI"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"hsSHOh7IRCAS6jjczpGs7Ju-mo40cYgJthJG3N-b5-8"}}
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

  D9 25 E5 FC  F7 AF D9 F9  DF 2D A6 88  0F 03 CC 7E
  8E 96 E5 08  EB D7 0F 58  08 FE 1C 39  FF DC E0 2D
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"xv1oPOh1g1NlklAJd4MhTkqnBpHW3H17-RKxzjNELQE"}}
~~~~

The key agreement value is calculated:

~~~~

  94 39 DC D2  D1 38 13 FC  C7 48 4B F8  64 4F C3 C7
  66 13 E7 16  AF 32 86 0D  68 A0 C9 0A  AB AE F1 5E
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  3D B1 C5 E6  55 FC 54 84  58 F7 2F AD  58 19 5B 23
  49 46 15 44  76 00 8B 70  F4 AE FA 97  4C A0 7D A5
~~~~

The wrapped base seed is:

~~~~

  C2 4F 0C 34  24 A5 F2 5B  6E 71 15 EE  0E DE D9 3A
  AF BE 9D 7C  A0 81 8F BC  FD 0B C7 69  FE 06 52 2A
  CF 1C 4C 88  67 DC EC CE
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  43 59 EE F4  E3 02 E9 46  6A 5D 7B CE  0D A6 DF CA
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  05 59 E3 1B  DF 07 85 AF  DC F4 F8 90  21 B8 D6 A0
  B2 E2 DD A1  23 F0 A2 7E  71 47 1D 0C  34 ED C6 61
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  81 CD 0E C3  C5 B1 61 71  24 9D 53 32  5A CA 3D F0
~~~~

The output sequence is the encrypted bytes:

~~~~

  35 5C 26 13  C7 91 B1 14  88 0F 09 51  83 92 E9 82
  2D A9 9C B9  64 07 43 14  0F 48 CC B1  E7 62 B4 3A
  3D B8 7F A1  50 20 F1 CE  4C 11 61 97  5A 50 84 8E
  65 AD 16 55  5C 6F E7 EF  A9 B9 EE 99  22 A5 0F B0
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-WZ4G-EPFE-INRJ-CM7U-L7NX-PQPS",
      "Salt":"Q1nu9OMC6UZqXXvODabfyg",
      "recipients":[{
          "kid":"MB3X-PGK5-PDA2-IREB-QCSL-3VEB-FFHR",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"bH8eV02x1QxvPfBgngCG_kJG0hVa_jYfNUR9dbr2D
  2U"}},
          "wmk":"EAeNqfiXqQ4s48MuDnZUko8BMVfoD9sNekDqv5KkptfFNyPy
  9UhQBw"}
        ]},
    "NVwmE8eRsRSIDwlRg5Lpgi2pnLlkB0MUD0jMseditDo9uH-hUCDxzkwRYZda
  UISOZa0WVVxv5--pue6ZIqUPsA"
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
          "kid":"MBDF-NR7S-QI4C-T76I-BKJS-JHBS-JKYF",
          "signature":"Tek1T3ysxgXSxQCw8qeRrrN9fsLj5RVxUsg7cn1oS0
  Rlhmxe5W69zAfy9CR2kZzUmiQxdK51cemBOr0mu7K-Ag"}
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
      "kid":"EBQA-4VKJ-2C5J-64CB-ILSW-3TL6-DBXM",
      "Salt":"iF9eBi4IuiuFZ9GSE8raVA",
      "recipients":[{
          "kid":"MB3X-PGK5-PDA2-IREB-QCSL-3VEB-FFHR",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"TSg9K3za8xjFnr46o2jnSKMX0ThTTfZD9zev7xi2U
  UU"}},
          "wmk":"301HSTwutZdLtDhw8MC61wiQhvAgfqVauRWhSEZhAkslEzNR
  imQtZA"}
        ]},
    "7HF0ea1CnExo3psgSKMW0_on36AzWOvGeXb1klfJLtXxeIDgSv-3sEONa7xL
  vG_NdZfPwUjcgL5gX7YnhgJ4eQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBDF-NR7S-QI4C-T76I-BKJS-JHBS-JKYF",
          "signature":"84FEbVlLtaBejGSZxgn3nLuNR98OAv541vCT1zgCeI
  9unsAbKOX5HtA_jaLrPN0C1KxzSKC2t31LFzMv-qoRDQ",
          "witness":"svu3EZSw9cxYfiA8HrYkDdaQ8JpSm_DaMrAgDxxTOXM"}
        ],
      "PayloadDigest":"ojPbEd-HKWUV7byaITYpHu7cMFfi0FjiDlURo2A0dP
  PdTqzBw37ZAYTx7512tOtuX0ye_dTgi-NdDBZGmaCOUw"}
    ]}
~~~~


