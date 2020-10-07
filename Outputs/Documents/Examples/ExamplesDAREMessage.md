
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"XDjfMhROJgoU405XHXCSz1bBgQWjW684s6k_XF9Ua-o"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"GgPgDJeBzYUl_db4ySfoKmzhos3MGyYcXswgXcirf14"}}
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
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M"
    ]}
~~~~

## Plaintext Message with EDS

If a plaintext message contains EDS sequences, these are also in plaintext:

~~~~
{
  "DareEnvelope":[{
      "Annotations":["iAEBiC1TdWJqZWN0OiBNZXNzYWdlIG1ldGFkYXRhIHNob3
  VsZCBiZSBlbmNyeXB0ZWQ",
        "iAECiAoyMDE4LTAyLTAx"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~

  12 2A 02 0E  00 B3 CA 3F  EF D1 6E 61  24 7C 9F 25
  E8 C7 61 D2  7A 82 13 9C  00 F8 F6 20  4B 6E 59 B9
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"Jb4jviREIX_tfmVGnVvvolDMq0dTJ-EwQSLNBjn3pek"}}
~~~~

The key agreement value is calculated:

~~~~

  AA 1D 94 73  FF 97 73 24  ED 0B CD ED  06 EF 5B 6E
  AF EF BD 17  30 52 1E D0  88 4E 88 71  A1 1D 39 50
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  87 25 99 F2  58 5B 55 8C  B2 56 9D DF  17 A9 0A B4
  A5 EE 8F 48  5A 6B 43 C8  E4 BE B6 36  97 0D 3D F8
~~~~

The wrapped master key is:

~~~~

  CD E4 95 EF  35 37 D7 80  EF 35 82 4A  FE 90 5D 7D
  CC 77 CD 61  29 5A 66 9D  C9 EC 52 24  43 34 FA 4B
  36 09 EC 36  05 BC 1C 57
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  8B 2D 09 10  C1 23 EE 57  CE 97 3A 0D  D1 AB 17 FB
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  C6 F2 F4 F9  A2 9C 3F 0A  AF D6 4C 0E  19 59 65 51
  AA 5A 14 4F  85 A5 54 B6  27 00 5E A1  27 B3 F3 42
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  9C D7 AF 06  06 3B D9 F3  F7 70 34 C4  07 3F 99 CB
~~~~

The output sequence is the encrypted bytes:

~~~~

  79 FD 7E 89  39 28 AB 01  42 E2 14 57  67 C9 3D 33
  0A 73 61 62  ED C2 0A C3  05 DB 0F 75  0F F1 B7 B8
  0A 8B E0 6F  B0 3B 38 9D  77 05 AE 4B  80 5D EC 69
  B4 82 DD 60  0D 82 A6 41  75 A2 CA C0  D6 F6 AE F7
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQJ-5M4C-T6MX-XHHF-GRWB-T3PT-A57F",
      "Salt":"iy0JEMEj7lfOlzoN0asX-w",
      "recipients":[{
          "kid":"MDRV-TDBP-FXUP-GBGD-3BNT-ATMX-HBHE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"kL4d24pnY4yRFKdU7G4dgUnOzfBiRU7T0sTw7ZlWQ48"}},
          "wmk":"zeSV7zU314DvNYJK_pBdfcx3zWEpWmadyexSJEM0-ks2Cew2Bb
  wcVw"}
        ]},
    "ef1-iTkoqwFC4hRXZ8k9MwpzYWLtwgrDBdsPdQ_xt7gKi-BvsDs4nXcFrkuAXe
  xptILdYA2CpkF1osrA1vau9w"
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
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAV4-PVGJ-HX7B-5SDW-SHRR-JJKT-XUHD",
          "signature":"E4XDbOzbza5HjVoY7bLS8joM64FOu5qvo1CDMLsCZKe_
  u0t5CwhZebBfNnpfiVTxg-TmVsIm3bJ5rehCClpPAg"}
        ],
      "PayloadDigest":"raim8SV5adPbWWn8FMM4mrRAQCO9A2jZ0NZAnFXWlG0x
  F6sWGJbnKSdtIJMmMU_hjarlIPEoY3vy9UdVlH5KAg"}
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
      "kid":"EBQE-WCGW-TQGA-ZITO-YVSS-P5XC-KSWK",
      "Salt":"U9mM8zZjbt3CrLCgBpoLEg",
      "recipients":[{
          "kid":"MDRV-TDBP-FXUP-GBGD-3BNT-ATMX-HBHE",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"WheHiXnrlbBDkSGejZrmbjqxNT9sgvuPZCgrqKAaH1U"}},
          "wmk":"9ogWc4tdzcPmm0TA0pF5UnrqwlrxJgkqdXx3V0eoClo9ikcyP8
  ttOw"}
        ]},
    "rYG5hj9Gwom-M84jgd_kTnRN0TYCx-Gw4XknavPso9EUevzIPBvhlHv_CI2T2O
  N_5WOtAYSnNOt6jf6xPfSgWA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAV4-PVGJ-HX7B-5SDW-SHRR-JJKT-XUHD",
          "signature":"Z-fefI2Q3cz1QqosC_xAvSTkiOsw7VPAiiKrZo5cAt2H
  r9eH4SNEnJdqSK9ksBZgig3f_YbA03tSq8ovmnJ4Cg",
          "witness":"aKO0H0xZLcCFCqw2dlPgKdqytOcxHUL8kukUAHKaAvw"}
        ],
      "PayloadDigest":"M005gEUpVkEE6Ql6-xTAsPl7PvN-P13HpZzm0I0-mG-l
  GAuAmZbPj8hQwYEhYKz7FB0OkbIMkl6ky1uwBoVO6g"}
    ]}
~~~~


