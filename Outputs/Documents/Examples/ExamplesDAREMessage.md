
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"9P8DMDTrvUwyEGWN72e_1idB21Z8e16JTFTHDn85QPI"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"fLdt6Ns0omvYQQI47SBq6FkE-SbTN-4Au2OdGh8er-s"}}
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

  47 A4 D2 A5  43 C0 69 99  24 AF B0 05  12 82 A7 7F
  2B 9A DC 0C  76 8E 91 29  A4 47 82 EE  5F 99 74 A7
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"VsHsxkHRM4Zfehcl3c_VQfFyjLHWa7VzXgsGD1yofSw"}}
~~~~

The key agreement value is calculated:

~~~~

  E3 A3 B7 DD  CA 2F C6 83  05 7A 18 12  0C A7 CD EB
  84 4C 3C 81  2C 90 19 90  D6 96 AC 60  3C 71 69 19
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  27 E6 61 11  DD C4 EF 8F  1A 28 55 6F  AB AD 0F 3D
  92 A8 1C A1  2B 48 7C 0D  7E 06 64 AB  3C 7C F0 B9
~~~~

The wrapped base seed is:

~~~~

  7E F0 2F DE  7F B5 CF 7F  B5 0E 0A 7B  A3 2D C2 C1
  4D 63 FD 1A  D1 AF E0 6A  66 CB 82 09  C1 94 44 A7
  6E 86 0B 8C  14 C8 0F 6E
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  97 0F 58 4E  D5 FD EF 12  47 BE FB A0  85 14 CE 11
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  51 E4 6D 26  CA 77 19 3E  A2 5B C7 3D  54 B1 E8 D3
  26 0F C4 C1  61 F7 2D F2  AD 0A B9 CF  F5 A3 7E 65
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  27 7B B1 45  A6 3C C9 8A  7C E2 FB 2F  53 F8 05 9D
~~~~

The output sequence is the encrypted bytes:

~~~~

  CF A2 5C D5  00 B6 84 AD  38 74 A0 46  FB 51 2D 47
  34 01 83 7A  9B 65 37 50  C9 B3 B0 73  ED BD 2A 2E
  83 38 10 B6  AF 76 B6 9F  F6 90 7D 49  EA FF 70 DD
  46 F0 2A F9  5D D3 57 DE  CF 2B 02 A1  09 1D 47 70
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQH-PK5I-4ZLA-TM2X-6UL2-D77K-VCZF",
      "Salt":"lw9YTtX97xJHvvughRTOEQ",
      "recipients":[{
          "kid":"MDTY-SXEH-PUGX-DYCP-VLXL-YWKR-ACZ5",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"TeltL4pA5REj5Dt5RWsB_pieZbT6BYIHrQfkD-GTc
  tY"}},
          "wmk":"o7Zq_xXtlyBVWHNnKs2kjTSkFuKfG8bBJUtcT3rJP7Yk_aew
  5DIVsg"}
        ]},
    "z6Jc1QC2hK04dKBG-1EtRzQBg3qbZTdQybOwc-29Ki6DOBC2r3a2n_aQfUnq
  _3DdRvAq-V3TV97PKwKhCR1HcA"
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
          "kid":"MCKM-HVXJ-276S-R7ID-N62U-EICL-JWMC",
          "signature":"eB9Qly0qoF2oxyXtXoV3CC0pHmmXlJSknWf8gdmHX6
  P4K94cStAYK610-XkBxjvOueqRd1YZh1Orn4XR72wDAA"}
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
      "kid":"EBQH-HRZJ-BZLY-6GSU-UEWK-NJZ4-PHQQ",
      "Salt":"KivOhJ848ZDZxIWUdo9JoA",
      "recipients":[{
          "kid":"MDTY-SXEH-PUGX-DYCP-VLXL-YWKR-ACZ5",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"psQsoQh-MkmdVcsei9ciTkjJj9B0dUhbCIxm523uH
  44"}},
          "wmk":"lVJFMK6LzkQEnjKHF_KGUe77c_f7QwjgW9ZTRQkaBmFnhVrF
  l0VYmw"}
        ]},
    "74tAuvgiK1uwMFh7itMlgJ2NyCEoUX3pVnEnfp8oYaALXyzRrlw_3ukZ4s4z
  Mckqpen8PnwCEUoCPAEVPfPtMQ",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MCKM-HVXJ-276S-R7ID-N62U-EICL-JWMC",
          "signature":"iyuIJ6HsF44iBKG7ytdUP0Zo0r6VY9jPN7Wi3AOZ9i
  3OZXP5qe5MSACUY7FDhX240_gtHlIntbn67Hq8gX7iCg",
          "witness":"AQlWT0I3RSYYRCAbisL_NGziWmAole9VvWAdWjoFdi4"}
        ],
      "PayloadDigest":"ZZCmsiYq8fjk3DC95aPT5zcYvKAix1ROq1Lpz-2_zT
  tvDcvlb2R_3udHcAhIpfyzpEYOV4A1GZuGtQF9JUTcHg"}
    ]}
~~~~


