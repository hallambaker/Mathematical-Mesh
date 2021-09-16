
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"LWdFZZ6tqtrU5f4fHnHNKCFPG9W0yu6GRsIYrXLJ5tU"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"xxlrMI_ks2qsQiVKvYXSDu33DxPTfeHWEn7gX6yJXoY"}}
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

  96 AA C8 0A  12 F1 07 F0  AA 80 78 C6  4C 3F 50 2E
  3A 17 0E D6  5C 04 B6 FD  6E 3E 8D 95  07 56 AD 87
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"81Kn78uFbUJUB2zlHilkaJeV17PutJCLPcdx3fXPkfE"}}
~~~~

The key agreement value is calculated:

~~~~

  AD 1E CC 1A  38 FB 66 D3  46 06 0F 31  74 AD 10 CA
  8F 20 4B 2C  B5 0E C3 9C  34 6D C9 48  28 54 3A 46
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  74 6E 1C A6  CD 8F C2 C6  B7 D3 8A 5E  FF 0D 10 F8
  60 C6 F4 4A  78 05 21 AA  BF E2 3C 7E  2E EF 66 6A
~~~~

The wrapped base seed is:

~~~~

  18 B8 BF 27  1F 20 72 8D  73 F2 16 46  08 6B 0D 79
  DB F2 8A EE  A8 00 C4 E3  5D C1 58 9B  9F DC D1 A7
  0C 32 E8 6F  6D 6A 49 71
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  86 5E CD FB  BB FF 08 45  CE 7E 3F 2E  14 4F 63 3C
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  63 54 11 F4  47 72 03 5F  E3 8E A6 C5  53 39 AE 7E
  26 2F 4C 2F  1A 48 70 90  FA A5 EC 71  E1 A9 DC 20
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  7A EF 7F DE  5B FF F7 01  EC DA C5 69  49 55 55 38
~~~~

The output sequence is the encrypted bytes:

~~~~

  09 D4 00 45  93 F9 2B E9  87 CF AB 78  9A 0D 27 E9
  1A AE 86 C0  3C 72 B9 C3  09 13 C7 92  B7 E6 43 76
  EA B3 22 43  7C E7 A0 7D  B7 87 F4 F0  A4 BD F6 A7
  F9 49 EF 2D  CB 0D E8 BC  D0 21 8F CE  33 B6 2D 1D
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQJ-4UIV-PTPK-7H7J-DLT4-72BZ-GJYN",
      "Salt":"hl7N-7v_CEXOfj8uFE9jPA",
      "recipients":[{
          "kid":"MBSA-K4SH-7RGV-KO7A-KC2D-C6NF-R4XK",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"K8_xV00fzCLhFZ_PHkcHk3XX3cwQz1JXMGnKBuftX
  qI"}},
          "wmk":"GajSVdB5-5Z99hNfgeIhbxC47MdAtO_UzIixgqTBGtQESe2i
  d3PSIw"}
        ]},
    "CdQARZP5K-mHz6t4mg0n6RquhsA8crnDCRPHkrfmQ3bqsyJDfOegfbeH9PCk
  vfan-UnvLcsN6LzQIY_OM7YtHQ"
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
          "kid":"MBHI-JJYK-VRQD-OBGR-PMP5-XSYP-BBNB",
          "signature":"2qSBHPPPSAFiFnpxhPYwkAXjOXHviDjyg0G1N4vU8N
  u7pHQwwn2Xklb0JA41oyHswCjfM6Tke8eSlnT3xIDtBQ"}
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
      "kid":"EBQI-TX2B-6MGV-LKWD-XTXI-5HDD-I7WL",
      "Salt":"H_fDVzuvM28Ug3AChXdb1w",
      "recipients":[{
          "kid":"MBSA-K4SH-7RGV-KO7A-KC2D-C6NF-R4XK",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"HgeAj9mqqhi020CEsER_eW1bFEF77PaNr0gZNnSKy
  dE"}},
          "wmk":"oTfvevH-GBHgdjETyfwx7qhpGoeEYOFHsgD28VjV8mc7MutQ
  XARAQg"}
        ]},
    "q3NIwCnD-QY7SmApJ86mRFo0_Yalf_SfeeZIdEDj8-6D5qbu3a3HtfCVGo0k
  btifXsHjb4Y6Nk_3n0jcM3widQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBHI-JJYK-VRQD-OBGR-PMP5-XSYP-BBNB",
          "signature":"m--KaUJUWREYStOJhju7kUkQU5cWGYDvop5pTXYKpV
  nzX1UwkKgiSGuy-xxP7wXApAKZVY0l0UEb_h6YhDt_Dg",
          "witness":"w2zXjvpZbCKOJ4qjre7Dn-W0zgx4onjMu5EdehfBlCY"}
        ],
      "PayloadDigest":"er4fzAou8NV-1_OVfM6R_4eLlDLvGahnUN_3-lQV_M
  Ftw6AHQBOLWrqCOlQuNgtArTdglyNumB8kWBliFV9O0Q"}
    ]}
~~~~


