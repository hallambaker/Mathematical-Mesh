
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"IMtB2FjBkPHsDvlZ3KoobYvlmS9xshYv075LNteNi8I"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"fhsvOGjjbHuuQ6_KXo-blebnCPWHzJIt8AuGzk86vUo"}}
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

  97 83 6B E6  4D 8B CB 05  52 ED 69 BD  2F 35 66 A0
  6C E5 F6 FB  20 52 91 20  1B AD 41 61  76 A1 D8 B3
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"ZOf5pv5Ifkr2frxCKa4KE96DqQYefLXR4EoG0xXUZoU"}}
~~~~

The key agreement value is calculated:

~~~~

  52 68 B6 44  C9 B2 70 FF  17 C3 F3 AC  9A 09 21 55
  10 BC D1 7D  E3 B5 D6 5E  F4 ED A9 D8  B2 A9 40 86
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  7F 25 A8 2B  3B 71 17 70  DF 51 40 F6  40 EB B2 1E
  DC 2B 01 F2  20 00 2C 65  66 62 56 31  34 B8 48 D3
~~~~

The wrapped base seed is:

~~~~

  2D 27 84 CA  89 F8 DE F6  EB 98 1F A9  DE FF E2 BC
  D7 D4 37 E7  EA 05 35 F0  53 C7 22 73  9B 02 B1 B7
  4E 9C E9 2D  DF 2E 39 81
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  DB 7E E2 91  4B E6 B3 19  1F 7C 58 57  8B 88 A4 C0
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  05 64 6B A8  2E 45 AC 96  CF 39 7D 26  61 75 FD DA
  19 55 7B E0  7C 7B D9 B8  F9 10 86 CE  3C A1 EB DE
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  02 29 E4 8E  CB 35 23 05  EA A9 F9 EB  44 E1 B6 C5
~~~~

The output sequence is the encrypted bytes:

~~~~

  50 26 0D EC  11 2E 19 64  24 31 71 64  0E B8 F8 FC
  63 7A C4 40  8C 47 5C F2  60 47 84 72  3B 7C C0 7D
  2C C5 CB E3  7F B5 CC 46  8A A0 74 51  BD 78 DE 70
  59 B5 E4 19  C0 D5 6E 82  96 3B 72 38  0C 26 43 A1
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQO-G7GG-RIIM-5BEH-KDUR-OEER-HHQ6",
      "Salt":"237ikUvmsxkffFhXi4ikwA",
      "recipients":[{
          "kid":"MAAK-DSAH-2TZ2-WZYL-VXJH-ECLN-NFXO",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"6u-7Ud_Q6CSWHLu_UJQAaURVLHDJBSKERP_F8fMYt
  7w"}},
          "wmk":"SXs4YQ5rIVrs8SpQai_ydpadOo0RvJZ_C4I1vDl7q6Si-sD2
  _NlnwQ"}
        ]},
    "UCYN7BEuGWQkMXFkDrj4_GN6xECMR1zyYEeEcjt8wH0sxcvjf7XMRoqgdFG9
  eN5wWbXkGcDVboKWO3I4DCZDoQ"
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
          "kid":"MDIR-FYB4-WZTX-TXY2-OZ4R-IGOG-S2AY",
          "signature":"LW5p7YJGSA8xU9yq463xdvCyqNMJ4apEdbYa5um-Sc
  6llpukZOFYjnJG18Xg--9LktJBhet6WyDu3aqVmX41CA"}
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
      "kid":"EBQP-GSDU-C2L3-VZZC-7GJH-GVQR-ALYW",
      "Salt":"LTip5v0FimyXThIwnVM7lQ",
      "recipients":[{
          "kid":"MAAK-DSAH-2TZ2-WZYL-VXJH-ECLN-NFXO",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"-Ka6O7Xqu6shr4-e5oey5gWAXKfzxEaM9hCD_6pat
  wE"}},
          "wmk":"wiZbvZzJsCeTrje79QHmoyleD35q3qqrti7cfQhfviJSKd1w
  tcLcNQ"}
        ]},
    "UTeEfTETvMam4r1dFyRs1FneKAJE9pQ8YHVLw_uMt3IX9V2UQo9o5vNQTbvK
  YqBpSX1Vj5CyLs7UPRhYDv8hBA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MDIR-FYB4-WZTX-TXY2-OZ4R-IGOG-S2AY",
          "signature":"E-OYp4N_Y1ldOfdx1srwCUfHZPNzKyrleTyy5XGJxx
  K3udsS0_U_HPe8YaT_mBwdDMo0LyivVae37GURGuIyBw",
          "witness":"t48doVQCex86gtkAxf8rGkBJovZasZC21G1hCN5gG8w"}
        ],
      "PayloadDigest":"66oSygUDUiet5i2h5GKh2_B3omwiecHy1N3Ba6wIeI
  svSMGOCBztBB2B1HgCAYgv-zvEw8CssrM4MBBFdw5zjA"}
    ]}
~~~~


