
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"nwl9iSSW2OyJf2Pf5kNt7EqNKCpE6uxdmY_46a8SGUA",
    "crv":"Ed25519"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"TDuiCw36Z9tFE65-5wImmDqIZv8AsY6TBTkNQuxVxbU",
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

  D4 B9 0B 18  8F 3B 1A 86  E9 6D B6 17  78 5B 03 41
  10 B5 63 0D  A7 4E F1 A4  25 76 B2 7C  48 EA D3 F1
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"BbKvZPQspjv5bSySWxU86cnf5VCuJsN-vF6XQSnn2pc",
    "crv":"Ed25519"}}
~~~~

The key agreement value is calculated:

~~~~

  C7 08 8B 11  B8 1C 6B F5  04 72 7E 54  91 35 24 01
  E3 0D 00 4D  C3 4F 8A A1  E0 8F 87 BE  F9 F8 F8 1E
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  34 75 34 87  C8 B9 FC B5  76 8F 20 F4  0F 10 BF BE
  E3 EB 48 CD  5F A5 4B 0C  5E DC 62 FD  77 24 D7 42
~~~~

The wrapped base seed is:

~~~~

  42 39 2E E6  5D 20 8A 51  C5 B5 4E 1D  6E 62 F5 BA
  AD C1 00 26  33 E6 4B 64  2B E3 9A F4  46 5D 2F 40
  70 E0 AA F5  E1 3F 93 16
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  C7 F9 65 E4  91 29 70 39  B9 04 BF 2A  7B 1F 38 B4
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  5E 9A 43 79  3E 0F 89 65  C4 C0 F4 80  9B 46 14 05
  BB 2D 6D 91  73 75 B7 77  70 5E 1C 78  63 2E 74 48
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  D1 B3 40 5D  DA 4C 1F 91  9B B3 83 99  24 B2 83 FD
~~~~

The output sequence is the encrypted bytes:

~~~~

  C0 03 21 7D  46 D4 0E C5  49 6E 42 DB  DD D2 D3 06
  CD DC F7 F2  DF 00 08 8C  5D 54 F2 C5  68 68 CC FB
  72 16 F1 B3  1D 21 2A 8D  77 5B D1 E9  BA B0 A6 9F
  2E 72 1A 20  DE 5F 47 EB  16 3F 75 FD  D8 E5 28 39
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQF-CP73-F3CX-HX54-PIFU-4C4J-IYVL",
      "Salt":"x_ll5JEpcDm5BL8qex84tA",
      "recipients":[{
          "kid":"MC3P-SEXC-G5NY-LUUQ-CDZU-JZTN-HMPX",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"7XeOpwiT_2seIbUB5B4pvWuW__ZSiaU6dOlrGil9V
  oo"}},
          "wmk":"VLz73UJQNX5uxxVaCWe5Df3ecbbnTcVsXOIcEam0zMQvcnpW
  f2Fkhw"}
        ]},
    "wAMhfUbUDsVJbkLb3dLTBs3c9_LfAAiMXVTyxWhozPtyFvGzHSEqjXdb0em6
  sKafLnIaIN5fR-sWP3X92OUoOQ"
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
          "kid":"MBXV-TFAE-W2F4-MD2J-RTSC-BI5S-RZOF",
          "signature":"oTA-FtWVxbm3aPEMy7vQN-QamBXArpZn-yIpiEKlck
  J5wi-EqCzVqPxhutqiX7iBvBaunTiE-zSXjLXqM_O_AQ"}
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
      "kid":"EBQI-SSBW-XXYI-KCQ6-UXOY-XPQO-4ECY",
      "Salt":"8eHpXI3SRWuTwiTt0FrdMA",
      "recipients":[{
          "kid":"MC3P-SEXC-G5NY-LUUQ-CDZU-JZTN-HMPX",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"6-olHQrajRUZK7atlKCzdvPzJ3_fAzLB0JuBRtIcb
  6E"}},
          "wmk":"K7_uKzUucBDsGOuZNAn5MwefO0BVBbInkojiMr4ruE1Z8Yiy
  u3abeA"}
        ],
      "dig":"S512"},
    "uAazLEvBwoZiSlLn_gDf9ZDM74g-yoTnONmmng732bkL07S8XeNqqqFRy7d6
  4EI6vNkK96fW0n_x9iqAFSMDFg",
    {
      "signatures":[{
          "alg":"ED25519",
          "kid":"MBXV-TFAE-W2F4-MD2J-RTSC-BI5S-RZOF",
          "signature":"60Y8PwAR7nRx7HM79gv-4K3woMEF2h-51-3fkZDaGM
  bbqxjsaKPUob4PCPdU-lKZD6HA9Iy1xLGxEX8ZW7cWAg"}
        ],
      "WitnessValue":"dRRwO0Kts0gPBENC6ZEQVncJekLBPPQwmetMJLoL4yA",
      "PayloadDigest":"UrXB6S1YgWIkIcl6kJq9IqsSBgyjnruxiWYEca8NQ7
  Evnd1wZ77UG7AhLaTaR2GCwWfcEU9Kfnnms-cV7e51CA"}
    ]}
~~~~


