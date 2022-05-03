
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"srLESz6Hpsy8Ry3Vi1FqcKpiMnLQjSGWoJi1ecZTDo0"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"_VPiqwO8EMWJQuFLRZbogEdAnVFXhdxfRBSUXgi4irE"}}
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

  57 01 7E BF  11 0F E9 83  17 FE E8 00  18 67 A9 A1
  64 23 6B 01  EF 26 A4 B5  22 F9 D3 4A  CA E3 6A D0
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"U3owU7ODJ4TvDaQ1tdoIy3uL_XR6nZlJpuAJ511n288"}}
~~~~

The key agreement value is calculated:

~~~~

  C7 FF 13 08  B9 F9 C7 ED  3E C0 92 08  D0 88 E7 1A
  3B 47 38 AC  2D 11 B3 58  31 95 EA 71  24 C6 97 D5
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  13 7F D1 2D  C0 EB 1F 00  F0 6D 4A F4  C2 B9 C8 CE
  AA C6 54 37  77 32 84 20  8F 99 EB B8  99 A5 5B 71
~~~~

The wrapped base seed is:

~~~~

  A6 40 2A 91  09 42 96 5A  48 1C BF 59  F3 CB 98 BD
  17 B9 D9 0B  BE F3 B4 00  DC C1 80 03  BE EF BB 4E
  B4 1E 1E 0B  A1 82 88 47
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  54 00 88 66  1A C2 38 F6  6C 7E 98 3C  F2 E5 B8 B7
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  20 FC AF 5C  69 D9 44 1C  99 4E BF E7  BB DD A5 D3
  19 18 67 94  32 B4 2E 4F  3B 71 E7 F1  A5 A1 2D 55
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  38 BB CB 63  54 34 49 F4  27 64 6F 62  C9 5C E5 6D
~~~~

The output sequence is the encrypted bytes:

~~~~

  63 F1 7C 59  D4 1C 10 09  74 3D 86 96  7A B2 38 A6
  E1 B3 C1 D3  46 B6 0F 3F  B7 89 53 C0  14 FB 5C 8A
  0E E4 D9 4C  BD 70 DB 3F  E3 64 C5 24  3F 6E 29 F5
  8C 89 EF 77  8E 4F C1 C2  48 3A A5 17  CC 20 D1 16
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQD-DISH-3KI4-FQ5B-M6OB-HRPA-TMZY",
      "Salt":"VACIZhrCOPZsfpg88uW4tw",
      "recipients":[{
          "kid":"MBPQ-HJXB-LUTS-HZEC-NPCR-Q5FG-HQ37",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"4Y1dgH6krEDA2VOuukqRmoudR0KglRTDod0gFkyY8
  YE"}},
          "wmk":"PHfeFcom0g8AecCd97PZtfz4HapdPV4j_eJDFDnq7rYadCbl
  sL0O8Q"}
        ]},
    "Y_F8WdQcEAl0PYaWerI4puGzwdNGtg8_t4lTwBT7XIoO5NlMvXDbP-NkxSQ_
  bin1jInvd45PwcJIOqUXzCDRFg"
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
          "kid":"MBVS-ODR3-5EAW-BJHA-22VB-RP5P-6D6X",
          "signature":"yN0SwnT2SLJjlY2ijhA5jhFF_ZlwF7WTS9ob6uuN4d
  u9jguD9w6JEPujNkzMSmey85zTyiIBh7xK1qLKsyjvAg"}
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
      "kid":"EBQP-BHRF-LFAS-EQDF-TBQ2-UQJC-Q24I",
      "Salt":"CQUfLtZJNuuK2FATqPSi-g",
      "recipients":[{
          "kid":"MBPQ-HJXB-LUTS-HZEC-NPCR-Q5FG-HQ37",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"sv5wUnLrIjvkyr9hGnE6KhwrTICnwSEnlkDDzeHlP
  -A"}},
          "wmk":"Y6J7QNJ8FyFZONSk6TLaJZmNFsX2wyl6ZoHz1kt8kCvo1jk8
  r4HSIg"}
        ]},
    "IHvL5XOlAOonxpq0vVRynF6NHO1Fg7BQz_J0EntQgDp0MQO5EhuYZW68rA27
  AMzu9kdcjuJ0mj-SP1mkROQUHw",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MBVS-ODR3-5EAW-BJHA-22VB-RP5P-6D6X",
          "signature":"VTuo8MGkusVTOtcd-tv05Erv7spIbJkKRWSDI2Lqze
  2U1pj7ODYdOU7J_zsN4M4rYadmGKbhy0_-nGbd1V81BQ",
          "witness":"VU_gilEQHmwnvHhH0rCWTab76jAGiWZWHJBcoZ7kV4M"}
        ],
      "PayloadDigest":"mq9Ym6Sas1OmTzAxnT9G1opWuoOOZSlNIXeg9QWuAc
  LIG_L-6opbaKCAI_vz8lYJgJBLt3ifOORa8QNJlBLgTg"}
    ]}
~~~~


