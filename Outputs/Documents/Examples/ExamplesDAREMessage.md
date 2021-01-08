
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"0VAp9YnJ-uMiaJ13p8N88N1KJamEl49u5xdR-MQ6i8s"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"MgzaWMerguTw6ozHTwUiEANqk2BHR9jSIRdUucLIUL4"}}
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

  10 95 8A 3B  9D 19 FC D0  02 3A 54 0D  C6 22 BD A7
  9A 58 01 16  15 61 4E 39  F4 0E 09 98  E5 BC CA AB
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

  9E F6 C0 0D  7F FF 5A B4  B8 73 C3 CB  86 71 DA 4F
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  12 07 6F 44  02 71 70 8F  72 62 06 2C  AD CD 89 FF
  9C 31 28 B6  3F 27 8E 92  3D 71 EF AB  17 4B 61 9E
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  D9 43 F6 8A  2A D3 F2 C5  16 22 07 C4  26 B2 A6 03
~~~~

The output sequence is the encrypted bytes:

~~~~

  48 69 98 1E  BE B7 32 B3  0D 0D 34 67  3A 50 1B 11
  03 F5 48 94  51 3F CE 19  01 33 EC DF  6E D9 2E 78
  FE 2A 9D CC  35 B3 DF 6C  DA EA 93 1E  5D 71 F4 01
  69 B0 00 13  62 25 94 ED  0E 72 0C 34  D3 4E D3 B4
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQB-K4DV-OP2P-N63D-LF2Z-QM2X-MDFF",
      "Salt":"nvbADX__WrS4c8PLhnHaTw",
      "recipients":[{
          "kid":"MDMU-YGBP-X5YF-K3HV-I56L-UFBN-YCTX",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"S_nKNFxvBaC3Q7fbYv-uHv2axPg60MMAsHQDbvMSa
  -U"}},
          "wmk":"LmAcxcCUWXJ8QD-2jzo5GybY7wMv5ETg9_idlDtBXo7EnXGF
  4nT1Xg"}
        ]},
    "SGmYHr63MrMNDTRnOlAbEQP1SJRRP84ZATPs327ZLnj-Kp3MNbPfbNrqkx5d
  cfQBabAAE2IllO0Ocgw0007TtA"
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
          "kid":"MD6Z-ZFMW-DUJU-SKYX-C6HS-CXXL-72ZJ",
          "signature":"WRZeL_5iGf6omZkJR5GTVYogpBre_7797MHkHCLUHq
  htnVnUWKbuwEL-hVKVu7rWBi_S3UPSDX3n5bJm-iYKBw"}
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
      "kid":"EBQA-L6ZB-VSH6-ZXQN-MKRR-C2IQ-OSIL",
      "Salt":"HWStqybUvyVyRWT8MRjJrA",
      "recipients":[{
          "kid":"MDMU-YGBP-X5YF-K3HV-I56L-UFBN-YCTX",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"duq1gd6oZzKaq2BuB2WKJ157K5epN1gXyzlMvS5sl
  dI"}},
          "wmk":"4MbTsqxYIN114Sj0TMynknIGd2AvvG3qVnaxdmKs5yD-FJC5
  _p3qQQ"}
        ]},
    "Tymeetm_psf4JLuatMQ6cP1PHiXuu_TLymEq8XVmfc3E7NiVg2X42p89aEgm
  _WIX87OUHaDCTX8Fk0PUJmXDpQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MD6Z-ZFMW-DUJU-SKYX-C6HS-CXXL-72ZJ",
          "signature":"eS2krFsxUXxrP4zOo1XXaGFGdMy2ZDl37PVgeCcI2g
  dH-a9lw8pdqABR70PmlYGEE57vAstpXB8VIEz722GDCg",
          "witness":"V0ffrbYiZYV7koLdOsfMZHTNK-YfbniivzYRQm4t14M"}
        ],
      "PayloadDigest":"WWM0o2No_0Lj4zDhO75uvsX7hLN3_Unf-aY4jLzZ2T
  NNj3RRFu3sxAinsNpBQMQtsmro_560bslZihqb6IPytQ"}
    ]}
~~~~


