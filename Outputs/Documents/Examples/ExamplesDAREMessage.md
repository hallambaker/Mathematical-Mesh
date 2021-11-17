
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"YQjCBr4zA0a0MlVqTPtN7Z3qKXx7jHFQuukf3qfUwRk"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"kBwlbXvu-7Tyr7t3N42BAy2UvGJIFjwqr-9Ud0N-o7c"}}
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

  5F 44 9F 56  88 03 7E 50  EA 75 AB 9D  C4 29 B9 1B
  0A 45 C7 6F  1C D1 C7 50  7C 10 66 36  3C 26 F5 20
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"Luvrwof5BpBi4rtIiu3YUrwJC1gTQqpQoq20qH-Howo"}}
~~~~

The key agreement value is calculated:

~~~~

  FB 9F FC 7C  1F 48 B1 BB  6F 5E 66 6A  88 40 DF 8D
  EB 0E E8 B2  8C 8E 8F 5F  F6 84 B4 3D  F2 11 6C 70
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  85 FE FF F9  BE 99 45 66  A5 FA 78 52  40 2D 7A 73
  58 C4 3E 4A  CA 91 1E 67  7E 1F 84 54  2A 2A F4 8D
~~~~

The wrapped base seed is:

~~~~

  A4 F4 DC 48  BB 8A D1 B1  2F 19 E1 BB  85 2C E5 70
  92 52 D4 D6  B2 1D F7 B5  0D C9 4E E1  46 33 70 9B
  05 96 B3 7B  57 26 D9 BE
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  DF F2 24 E0  08 7A 46 A5  6A 38 2F 26  DB CE 33 B5
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  34 06 F0 1D  B5 6C D5 68  E8 64 73 EB  E6 7D 0F 3D
  FA 67 77 41  60 FC 69 71  7E 8A 45 EF  D0 D9 81 C6
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  01 FF 29 91  D7 46 4D 20  F9 5C 00 1F  C1 44 C9 F5
~~~~

The output sequence is the encrypted bytes:

~~~~

  41 61 6C 21  1F 87 E3 8E  4A C2 BB 0C  E0 69 1B 7D
  BF 93 C9 32  8D 82 17 6F  11 53 D2 29  81 D1 20 09
  AF 99 AB E3  7E 9D 49 0C  70 2F EF E0  B8 08 65 23
  5A FB DE 96  57 4C 70 0E  2A D9 E0 0E  69 FE A4 B2
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQD-GHPI-MMGD-KEW5-6PQ3-Y3TG-GLRW",
      "Salt":"3_Ik4Ah6RqVqOC8m284ztQ",
      "recipients":[{
          "kid":"MBMR-WQKI-2GTU-EBEY-XOTA-53NO-XPEK",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"cq2meqL_0kX8g0wcwLpvWm3PK-qLMNnnYxz9-wA4E
  wY"}},
          "wmk":"oiNPjgGoWYFZydloxEIyohZtKEePc9dQLDmaHZpCOIs1woIo
  NaXRYQ"}
        ]},
    "QWFsIR-H445KwrsM4Gkbfb-TyTKNghdvEVPSKYHRIAmvmavjfp1JDHAv7-C4
  CGUjWvvelldMcA4q2eAOaf6ksg"
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
          "kid":"MDR2-KVPA-RQAV-FQX3-HQWI-M7DE-5ZAW",
          "signature":"MjZ0QU0HmjqlfG5TKc_xr2AUvrcTcJstgLWg2Koh9U
  p6qBwBA6h2QF9jW8c811cqqk7R45u1l1SRHY73b1IgBA"}
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
      "kid":"EBQJ-RQLJ-LWAC-BA6R-N3VP-EVK2-QM2O",
      "Salt":"fRRrFAdq-T-uJToAJDsjoQ",
      "recipients":[{
          "kid":"MBMR-WQKI-2GTU-EBEY-XOTA-53NO-XPEK",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"wPmJDpwxPM2ihw5fMD_yHhMIJ2FtRnq2tdPUXcdYq
  RQ"}},
          "wmk":"avVp6EgTTKWmy3Tu308GBkZXWBpqUosotRDqz_sjGp_9HOc5
  evgV_Q"}
        ]},
    "W3ez41FqmpkdOoBS72xDM5KXPtF_hOn0kAVEZ_poLy2_xxrmaOi_fKI0iTzn
  5cODyw-fzpCaQeVrBs-Fh68Vzw",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDR2-KVPA-RQAV-FQX3-HQWI-M7DE-5ZAW",
          "signature":"juT8WLI6CKfNrc8I0LWMp0Rt2L4oOZbfT03C7VH3ZP
  B3VXyd2gSW1H_QhxrcydyDZSA9mdZir4OVWXOq7-U_DA",
          "witness":"KEMVrmQeXPXOTyryc1VNwR5YVa1LmITolZh1Bt0Dvj0"}
        ],
      "PayloadDigest":"flND3U00L9CViwhgEXIqLlgMO6hLF-Ou8skpyCtlkk
  IgcxMXvlO4PKTrroIZyCQ9ZC3QmPLn52BbdMWxXlzG3g"}
    ]}
~~~~


