
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"YtCQASJyUMFVaXLlL12VJ7ITa72m8tcLWV5-6uuH2dw"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"-5zIro5wEnRp0fvMBc5m7bofU0bfG74jJJQs38sMyAg"}}
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

  2C 9A CB D6  B8 1A 40 FB  55 7C DF CC  3C C9 4C A6
  25 F9 54 63  FA 22 23 A8  27 98 3B 63  B9 1F 4D 25
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"thChO2XKEVZTe_y6n8IE_gmw981qdH-0Rw-6SekfAoE"}}
~~~~

The key agreement value is calculated:

~~~~

  3D 1D 6C 63  99 2A 34 AE  1A EC 8C 35  8C C7 1B 00
  AA 87 54 DD  C1 08 62 C4  77 4B F8 C8  CC E4 FA DF
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  E0 25 27 C8  13 D3 EA A0  E8 02 2A 06  CD 27 96 F8
  17 86 C6 DC  6D 88 22 F3  DE 90 95 23  BC 8A 27 02
~~~~

The wrapped master key is:

~~~~

  C3 2E 24 A9  46 89 07 9A  FA 65 02 7F  3B 89 D6 A9
  9D BF 8D 22  67 8C 0D 31  CF C5 3B 21  29 77 14 D9
  E9 B6 9D 4A  2E 7F 93 7E
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  04 3C 82 B9  09 0F 27 DF  6C 98 7C E3  B5 55 23 B0
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  B7 0E 84 94  1B E1 ED 49  3A 4C 9E B4  70 EA 6A 4B
  D4 EA 9C CC  A0 40 37 D9  41 DB 2E ED  AF B7 CC E9
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  B2 AD A7 3B  09 B1 7B 7C  C6 0E A8 41  65 C5 00 63
~~~~

The output sequence is the encrypted bytes:

~~~~

  09 77 6B 8D  A0 8C C6 24  D7 3B 03 2E  89 08 92 E5
  7A 97 18 74  9D 5A 2F A0  B3 33 54 FE  D3 08 03 17
  B1 F9 31 C5  29 C5 3E 28  1C 00 11 B6  45 B4 64 CE
  DC 77 D0 E8  90 B3 D6 E1  3B A5 9D 67  A3 8D 63 25
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-3XOJ-KCWV-4RF6-4UXT-C53V-3KK4",
      "Salt":"BDyCuQkPJ99smHzjtVUjsA",
      "recipients":[{
          "kid":"MCOP-FVIJ-Y67Y-UY5G-4POC-T43X-VKME",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"oIHH5g6DbRg1kgqqazOguY69zwlbvZ0EQ046hsDNm
  nc"}},
          "wmk":"wy4kqUaJB5r6ZQJ_O4nWqZ2_jSJnjA0xz8U7ISl3FNnptp1K
  Ln-Tfg"}
        ]},
    "CXdrjaCMxiTXOwMuiQiS5XqXGHSdWi-gszNU_tMIAxex-THFKcU-KBwAEbZF
  tGTO3HfQ6JCz1uE7pZ1no41jJQ"
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
          "kid":"MBW5-O63O-LACU-BWAP-CVSA-ZF5W-YPTT",
          "signature":"Zsi48ranNjtDbkiwz6Q2hzwXIx84NWR0L4jjxlMUwn
  pQ2GnWrcHkyo_q2IwVLbGFaV-miVt_zlTwdc8C7cBiBA"}
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
      "kid":"EBQB-CDQA-UE6G-A7RG-VITY-P3XL-MGAK",
      "Salt":"_ivtm4DfSb2IvxV9XEu1-A",
      "recipients":[{
          "kid":"MCOP-FVIJ-Y67Y-UY5G-4POC-T43X-VKME",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"g2XfNQ3S5hJ9TdefJogIZ9tVUm5_u3tcancEnS29p
  es"}},
          "wmk":"XI6zoYq9h2KTNG1wCz1rb9ENzfLKRdcmaHe6LqAIInkmH_To
  wXpeLw"}
        ]},
    "vmoH00ViCEt0CAIb93ljb7VfEfgDWJa5AuKIt9v0lpyLzEvmzeqQLOehu4UA
  GyPnDVd4T6rYPjZMuUtfscJmyg",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBW5-O63O-LACU-BWAP-CVSA-ZF5W-YPTT",
          "signature":"8zVZ0cyooZ6IbYtT_i-pq9aDMDa-IfDNk4HyW-DnCx
  Vdrvh-Y_J7DzysPVJtFiO6or8I1O-vsYbjFVrhyzoDDA",
          "witness":"S1uuvSq3Q9J8Rwl6zf8_vLTkXzbZKUi-OnTbxkTLv08"}
        ],
      "PayloadDigest":"Yzckt0mv_2WLgK3inrqu9Nzck1jC08Q4W1OVvgwFiJ
  jAhOoMBuiZxWszzFASlr9SXMAQNrn78eSpJDeDW5cprQ"}
    ]}
~~~~


