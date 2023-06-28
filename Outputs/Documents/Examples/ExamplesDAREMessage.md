
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"paX59ChSdnCUnAwmBYVFFqV5Cbr8g1A6iJ1axyQGFqk",
    "crv":"Ed25519"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"hkYsLO2D7_4vuqZB3MFMV6blEozFJ5KL6CqBtu61Ops",
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

  6D C8 50 14  FD 8E EE B1  36 8F 2F E2  57 5B AE F7
  00 2B F0 85  77 EC 84 55  9D A1 47 6B  BC E8 8F 13
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"IZZYwHMfhG0N038tWvORYOV_wTNw-MG6ueob3yXn6fk",
    "crv":"Ed25519"}}
~~~~

The key agreement value is calculated:

~~~~

  95 7D 09 D6  AE CD 94 0D  7A 2C E1 5E  2D B5 28 F2
  28 41 2E F4  42 EB 85 D6  27 C8 24 84  75 16 31 B2
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  A7 4D 37 B1  99 00 A8 54  8F 26 18 21  69 0E 51 68
  48 82 1E 72  D8 3D AF 0B  83 34 1B 77  72 8F F3 AA
~~~~

The wrapped base seed is:

~~~~

  30 5D 96 95  BC 08 80 65  A5 41 61 9E  BD CC B9 38
  6C 8B 9E 7B  B5 08 14 2A  1E 80 25 AB  5E B6 B2 5D
  E6 6F FC 2E  F0 19 35 FA
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  7B 10 9B 97  CD 00 0C B9  C1 72 60 61  59 08 15 CE
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  0F 68 C8 90  DE 76 76 03  F0 51 89 82  A3 6E 46 36
  C5 47 C5 A0  40 B4 21 9E  25 03 AC 41  80 4D 83 2B
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  B7 9E 72 C4  C3 5A 7D 06  39 CD D4 26  ED 47 62 00
~~~~

The output sequence is the encrypted bytes:

~~~~

  DD EC C1 C4  B0 49 8D 7A  F9 A4 49 88  6E D3 7F AA
  9F 7D 77 DF  AF 0C 72 8C  E1 91 2B AA  C2 E6 D9 87
  8F 33 1F C8  D3 6C D3 10  76 B8 F7 62  6C 48 09 33
  7F C4 82 F6  9E E1 B6 D9  0A 34 5E 42  9D 91 A0 05
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-FRUM-PRWG-CYFY-BLAO-DUEH-HVPB",
      "Salt":"exCbl80ADLnBcmBhWQgVzg",
      "recipients":[{
          "kid":"MDFQ-C642-7ZJ6-WVCA-QHPW-236B-UNCE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"MMi1LMWpMUvyl0Zu5dxiIwRkgiR1qBtYq3dqEGvxf
  AA"}},
          "wmk":"UuEt2Y5LpeBxjRuiylqTDNU13yPADoofL_dEeopO_64ZV5jK
  oSu2SA"}
        ]},
    "3ezBxLBJjXr5pEmIbtN_qp99d9-vDHKM4ZErqsLm2YePMx_I02zTEHa492Js
  SAkzf8SC9p7httkKNF5CnZGgBQ"
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
          "kid":"MDXM-CKCM-UJTS-LZO3-XAC5-KTVY-DAXA",
          "signature":"JZtkvJf0ryob6LC00khVpYlcb56teH-0aoiFjiPWUN
  pmm9XbsouoMGFTird0Rx-9fU5Z-bLDXwWN42f5T5yxCw"}
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
      "kid":"EBQN-4CD5-7ZEE-Y3LB-JC2V-DGXI-A7GO",
      "Salt":"z5_5_GsTUvCBBeNgVRDfug",
      "recipients":[{
          "kid":"MDFQ-C642-7ZJ6-WVCA-QHPW-236B-UNCE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"d-11VbHUe1BBek4pncrK2pn_q9-orDU_zsd6HKyvD
  v8"}},
          "wmk":"eZO6Ff2jQFrK3PyuUtR8IabKxgZmZRYETS7-ER4c75nFWVes
  Ydg2eg"}
        ]},
    "OyhzXMfA1AWzP6TGGU9jeeP0RjzC9aPMTyfJtHneuchxCqgCQoyBTnRSJj5f
  58YOfck29dCzK0Owel04c9SnCQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDXM-CKCM-UJTS-LZO3-XAC5-KTVY-DAXA",
          "signature":"KeT5fbFM17cdZTvFmf8evf3pR1hrXXxJhqFKQgJ-WP
  xV2WxECFlCNZfolYKouUR32SEPGdZtRPRf_KHG0eSGDg",
          "witness":"mStCDGih4PHjpfHHofbbtwp84bJulWoa6v6lrp_MjHw"}
        ],
      "PayloadDigest":"PWv7mK6OAoB7OO_Azhj88_ReFX5kbPWxQ3iwH50RPB
  H_grVaFi_-78JIs07tV_p6ciJOGHgLV3Z28wuvwV3sxA"}
    ]}
~~~~


