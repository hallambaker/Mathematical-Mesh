
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"XJcwcdZ4EPzVJ5HklrhRO3ri2t5SrkggMZKc-ERPnMs",
    "crv":"Ed25519"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"ICRU6fZ6iYnZKuU-5Leg-rEnnt2Fpx6eazWF82aXT0E",
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

  CD 61 12 9F  A5 83 CF C6  D2 46 BC 28  E2 52 29 56
  5F 69 07 42  37 FB 84 A4  1A FF 64 2B  BC B9 CA ED
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"5wQJSpm30D34AQEKAiL1X2_qjSxC4NX1zNiujiiipAU",
    "crv":"Ed25519"}}
~~~~

The key agreement value is calculated:

~~~~

  AB 4E 44 BA  C4 50 72 E1  0B 99 4C 4A  D9 BE A5 AC
  B3 C4 B7 16  2D 04 93 52  65 2D 96 41  C4 D4 1B 38
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  B1 C0 C8 0C  E0 C5 CB 98  EB C2 29 91  D8 31 35 00
  91 A9 FE CC  08 4A 13 FA  AE DD 8D 8D  80 78 5E 1A
~~~~

The wrapped base seed is:

~~~~

  4D C5 D7 D6  BC 91 78 0A  05 8E E4 77  FC E9 FC 27
  9A 83 85 C6  8A C6 83 01  98 B7 BA B6  E5 8A E2 35
  5D B0 CD C8  12 2F 83 19
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  F8 A1 00 CE  73 F9 35 7A  D2 2F 44 7F  4C 6E ED F0
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  8C DC 8A 6E  2F 2C 63 4D  E7 10 A3 0B  64 15 E1 02
  29 D8 F2 92  E0 01 5E E8  3D 44 04 BB  20 9B EC 0D
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  80 AB 50 61  3D 61 B8 24  CF B1 D0 53  D2 FC E5 D9
~~~~

The output sequence is the encrypted bytes:

~~~~

  CC 74 28 09  C0 DE A6 6E  71 48 1D D9  97 99 EB 4F
  F0 1B A1 96  68 43 E8 7E  5E 3D 3C CF  2B 1B A4 38
  1D DC 2F AA  22 65 9C 26  0F 64 DA AA  A7 A6 7E 59
  53 3A F7 3A  1E 49 ED C6  A5 09 AF BC  31 C7 29 76
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQH-VIOW-AFQV-PYWL-LQGL-W2A4-XFX3",
      "Salt":"-KEAznP5NXrSL0R_TG7t8A",
      "recipients":[{
          "kid":"MABF-ASRG-OGVF-SCZE-NVR4-CY5C-NEP6",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"D9JsCEgzHQ16MKpQj7Gh0L-PG8XXyEqgRri3LrbGX
  DA"}},
          "wmk":"ARG2KdAqe3gh8HYWzkNcSgzuo72F8fypnKV_priKgAcVHsUt
  5BBmoA"}
        ]},
    "zHQoCcDepm5xSB3Zl5nrT_AboZZoQ-h-Xj08zysbpDgd3C-qImWcJg9k2qqn
  pn5ZUzr3Oh5J7calCa-8Mccpdg"
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
          "alg":"ED25519",
          "kid":"MAYO-77YW-UQNB-UV4A-AQ7H-KBOE-MDOM",
          "signature":"WioyYTxpnYc1f5XENhwi8a_bcIziA8GYxtX4Qjc9hh
  WnTnAq2R9F48rHo4W65X5UOWgl1gO0QfBu94tBRrU9Cw"}
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
      "kid":"EBQE-6EIB-RUKJ-D6ZF-XGJI-5AEA-WZL6",
      "Salt":"bbzY9kIZVZPYL5h06SJbcA",
      "recipients":[{
          "kid":"MABF-ASRG-OGVF-SCZE-NVR4-CY5C-NEP6",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"iOEoYN_4NmKTE_t2W4zlzv0boprbXDDz2RuJCpnB1
  qk"}},
          "wmk":"Jz4DvuVYASsZ-7zTgLG8Ae9hBVBN2P5DlSpVd1JaFnVfiegZ
  _LNHXw"}
        ],
      "dig":"S512"},
    "ZylmvB1MQ6fP3gI8lF_QgiGnZNKvkWnZ4YmW1h7OzLOpWs6RX44mThZN_jqE
  6La0T3Op7th-j36JMB-W-UONGQ",
    {
      "signatures":[{
          "alg":"ED25519",
          "kid":"MAYO-77YW-UQNB-UV4A-AQ7H-KBOE-MDOM",
          "signature":"IjAbv7URkXE20Izm_fnObyom1jBjjaIAn2QFBtJ2LE
  4D49RDHY0saW8-A_cvW0g_DhRaDGmvrMvpZju-RAkLDQ"}
        ],
      "WitnessValue":"5WoZt6sdXM2Aw2E9TKoci2jDEPXivVrw339oQpBhzeY",
      "PayloadDigest":"lHLEn2gHT3q_x-uV7YaNYHoCLVhILjzffmpHynW4pP
  aohJVzPlT4PuY90RVA2cWK61uj6qUTHkYpxSuRjgRpQw"}
    ]}
~~~~


