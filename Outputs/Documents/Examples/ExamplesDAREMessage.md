
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"hduWGdNgIzwgLfB0s4zbbfg0sFFmF3dMJMpOnhDQawo"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"uNquVJCwSdRh5r_H8rC8TP8MHNtVIcQ6WcCcYS54OeE"}}
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

  F7 30 FE 06  64 42 F8 06  AB A8 E1 90  7A EC 56 1C
  FC 84 AB 72  C7 3F 8B 96  6B 05 03 6A  35 FE C1 91
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"c0s2p1PB6hRy2ypIeu3v60HkBUPB71p4z-ZVuSVfK9c"}}
~~~~

The key agreement value is calculated:

~~~~

  5A 10 3E A2  ED 3F 4C E4  08 F3 5C AD  7B AE 73 15
  9E B3 92 27  10 F8 0B B9  59 1C EB 31  AD 86 2E F3
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  7B 20 1B 5B  00 A9 AB 92  D1 D3 66 FD  04 09 18 04
  C1 91 83 6D  22 AD 12 E0  C5 08 B6 14  0E 4A D4 36
~~~~

The wrapped base seed is:

~~~~

  07 25 7B 51  EB 38 B1 5E  1B EF AA 3F  C6 B4 DE CA
  6F 0E A2 38  9E CA BD 2A  E4 A5 D9 BB  98 AC F1 E1
  2D 7B 77 97  55 02 F4 B1
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  B7 32 BA 29  D6 13 E1 1B  BD 62 06 3F  04 87 55 93
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  5C BC 9A 4D  79 EE 47 7A  3B B9 82 C6  51 29 59 48
  0F D5 BF 5F  23 96 D1 8C  0F 45 D4 39  A7 10 F8 A6
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  DA 40 08 B3  B6 87 73 AC  00 B0 8C 6E  C6 21 88 1F
~~~~

The output sequence is the encrypted bytes:

~~~~

  FB 04 55 9F  F3 47 15 AA  F9 47 C6 88  DE 71 C9 E5
  79 B0 2B 13  49 9A 29 DB  75 41 A5 74  39 5E 78 8B
  5A F5 66 A3  C5 67 1B 25  C7 8E 8F A8  03 5B 5E B8
  B7 FC 76 1F  19 11 8B 8F  86 DE C1 14  04 45 9C 7B
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQN-7SBL-YF46-KJZ7-M222-SHDC-BIHD",
      "Salt":"tzK6KdYT4Ru9YgY_BIdVkw",
      "recipients":[{
          "kid":"MADB-RMVX-3SOZ-5DEP-IUUZ-UET7-W6NL",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"h0agLIp9lg__pchrmtuOvhxoZNx6ZYKYCGNZrshk3
  Gw"}},
          "wmk":"QIyoyghcSzgBHsfPggnYYQwgIMtzSiZPFncSHkN4Afo5um3l
  3NcOLQ"}
        ]},
    "-wRVn_NHFar5R8aI3nHJ5XmwKxNJminbdUGldDleeIta9WajxWcbJceOj6gD
  W164t_x2HxkRi4-G3sEUBEWcew"
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
          "kid":"MBLT-KRZT-7WCU-NBB6-AF25-C4J2-4YLQ",
          "signature":"4zf9jiPkyx9_Gz0P8ppEGHlVbgfWyr1sYgIZPzSQWJ
  WDBn44XtMOsUVnqafgH52EIuUCdHamDt7fSeK6OvFXDA"}
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
      "kid":"EBQK-GIDM-L3HW-FQPR-BMX3-YNL6-WKL7",
      "Salt":"jP9l5fP87EmTufP_9qlW-w",
      "recipients":[{
          "kid":"MADB-RMVX-3SOZ-5DEP-IUUZ-UET7-W6NL",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"inroQCFaUl86pn605KFFwmcvx8xsObBd4xXK1Csxv
  l8"}},
          "wmk":"thrD8MLtrzEQs2o6yJ49pkl5P6hReGt5z3_PB1_NovgJMxuN
  AT0e_A"}
        ]},
    "9Q-cFTihRUiNKYkWCgK0zmJ2wbKtwqpnFuaTAdwJknsstVwUrkwe_2SrYQYz
  _t2X_hs0u8Bm5bHC0eImWnbrxw",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBLT-KRZT-7WCU-NBB6-AF25-C4J2-4YLQ",
          "signature":"KAZGuAfFph-FB_INGbgwTZdGOFp6MIkaRPS1t-V8Yd
  Z9cTAs8gKXpgB1KAXy2rAv9k81U7FdoDzSRj7V-7LNDg",
          "witness":"fV5xo4zFEGGcTo1kogG9eoRGOKFXMv6qQ2fYcj50ufo"}
        ],
      "PayloadDigest":"CgI6yULYsksi0RELhZLLxJt-p9Zk_KfSG26mmzSr1N
  ILMqzkBkiC7m1UuVG3nfCZgysrphCjVg1b2AF-fQcgRQ"}
    ]}
~~~~


