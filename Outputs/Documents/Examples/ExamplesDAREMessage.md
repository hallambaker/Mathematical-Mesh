
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"aoLNZ370GWJVyXZLF08HC3278ZF-FrlUvHLkU3O9WMQ"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"GuNgjCDBAl-xlR1nU5KydjuZ_HR8U4iwLTD3inAPzQk"}}
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

  BA AB 85 E1  48 00 00 0B  C7 AF 68 2E  2E E1 9A B9
  2F FF DB ED  9A 3E FB E8  1F 51 E3 A2  3B DA 47 99
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
$$$$ Empty $$$$
~~~~

The key agreement value is calculated:

~~~~
$$$ Missing data $$$
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~
$$$ Missing data $$$
~~~~

The wrapped base seed is:

~~~~
$$$ Missing data $$$
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  FB E7 6C 22  55 DE 74 5B  4E 1D 08 37  0C 19 E8 DD
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  58 0B 83 36  3C D5 9F 42  18 EA F1 A9  FC 7D 21 29
  9E 2C 85 BC  C7 DC B4 45  88 4A C9 7B  8B 91 D7 AE
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  FE 03 58 DB  83 5D 4E AB  90 6C FB FC  FF 6A 66 A7
~~~~

The output sequence is the encrypted bytes:

~~~~

  A7 DF 10 A3  E3 BB A3 69  B1 77 6D 6C  24 D7 D4 85
  19 EA 4F 67  06 10 A4 54  24 75 8B 85  83 6F 7F 14
  69 9D 96 A5  C0 FC 3A E4  38 E4 92 8B  AC 86 78 69
  E5 3D DD 50  35 F2 D4 05  F8 32 A3 A3  10 4D A4 B6
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQL-65RH-22F5-IGUI-V2HZ-M5VW-ETVO",
      "Salt":"--dsIlXedFtOHQg3DBno3Q",
      "recipients":[{
          "kid":"MAW5-HWG2-5AKV-SRYJ-RMA6-LCIQ-UUCY",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"0y9_DzVpKL8erMQAEKG_hR3FDxWFSM8d4G8F9jkcM
  ks"}},
          "wmk":"igZEjN-uEb25ucoTcmg6kXSXmKlFpJIrTK7Fxfl0RQQ_Lkd2
  cewukQ"}
        ]},
    "p98Qo-O7o2mxd21sJNfUhRnqT2cGEKRUJHWLhYNvfxRpnZalwPw65Djkkous
  hnhp5T3dUDXy1AX4MqOjEE2ktg"
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
          "kid":"MCGY-6FG6-TZS4-BYBK-DN44-UMAX-U2I4",
          "signature":"_NZWz-tRVc_a4ecpxf0Zjbb_N937N_CsXhyGEgY3F1
  _ZmC6W_bkfzqA8K0H2JDG1b7Zqxh6yfrCqJvS25kmiAw"}
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
      "kid":"EBQI-HHPN-YXS5-SINL-QYUZ-7JFS-MAYB",
      "Salt":"4PCRBHm5Yi2xPyi6Gs7AsQ",
      "recipients":[{
          "kid":"MAW5-HWG2-5AKV-SRYJ-RMA6-LCIQ-UUCY",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"MZaUP_4XKeIgURnrsrDldqFKz5rz2B2Y1cK-a_NX2
  Wk"}},
          "wmk":"0BgDRJhqq6jxDmusfS2J4JKH2aZpZIqJT4GRSi7vTymgb4H9
  oDY62Q"}
        ]},
    "0mYpHC0e4qSB3WGelhjpS7O_Ip_h1ULUnyOma1j1Ai8H7FZ30ibF-A6Dv3EM
  cP2AixDiGMc8GmdwGaYOUmrbdg",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCGY-6FG6-TZS4-BYBK-DN44-UMAX-U2I4",
          "signature":"zPSZD0SpWF7n6JXZx5BcVm-6In9h6wFR2UmRv4c23R
  Fxc0haS7XkLUKY3-RHUDvdPACYOe_QPK5qOo348Uc_Aw",
          "witness":"UfO86rpk0hVd8QmHVgxFaJKj-q9s0HIoc71Vho4iu-4"}
        ],
      "PayloadDigest":"xCJnc5RJRkC527jiMM4HXcwuRQUMCy6w5mkzKpGWGz
  OYjWrIIWy-ZX4HBsSP9Lm0WpArt8e7f1TzKfYRQ19U_Q"}
    ]}
~~~~


