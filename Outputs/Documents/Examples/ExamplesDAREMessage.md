
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"_DLeB9Phh637q9vDPRast9JaKmIg9eF-lTg1UV9-sB4"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"tWS6EyvT3r1xTk3zzv-6Ek4v5FntEq_uB4cC9gn4_MY"}}
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
  VsZCBiZSBlbmNyeXB0ZWSIAA",
        "iAECiAoyMDE4LTAyLTAxiAA"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~

  3C 29 54 5F  9C 24 17 3A  2C F0 BC F7  22 F2 35 9A
  2A 50 50 B3  4C 31 B1 44  5B BD D6 75  54 1D 90 45
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"6QxTJ30xfSKkR7s2cJwlz0lk6rE0wsapdEmk6uVxhnM"}}
~~~~

The key agreement value is calculated:

~~~~

  FA 99 C3 96  91 FF 86 46  CC EB CF BD  25 B8 35 6F
  B5 DE FC 02  47 2E D0 BD  CF 44 C0 1C  93 C3 E4 6B
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  5D 5D F6 85  FF FB 2C 5D  CD 79 F8 CD  A1 9B 80 57
  CA 27 65 04  9F 33 AB D5  92 AB 77 31  6D E7 A0 16
~~~~

The wrapped master key is:

~~~~

  CF 0E A3 92  4C 02 4C 41  EE A8 4F 9E  F5 84 BC 11
  5B 53 5E 98  14 BC D0 44  18 41 58 B0  14 3B D8 CF
  5E 4B 6D AB  89 1F 06 86
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  58 23 17 AB  4A 4E 6C CC  8A 32 8D 62  C6 D9 52 7C
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  A3 57 FF DC  00 A9 2E 1A  80 8E 15 58  05 5E 40 1C
  CF B8 1A 0C  A8 90 45 9E  97 4E 94 27  7F A0 34 64
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  6B 70 DC 64  5F 41 51 C7  89 67 70 BF  E3 03 A2 DA
~~~~

The output sequence is the encrypted bytes:

~~~~

  57 CB 1F 8B  E9 0F 00 7F  E2 26 35 6B  B6 06 59 A3
  2E 2D F3 DB  76 91 1B 20  D3 CD 02 66  65 80 0A D2
  21 7A 9F 7C  D3 D8 20 22  FA D4 11 86  23 B6 81 0D
  FE 21 9F A7  1B 82 B8 3C  AB 58 6C F7  AC E2 02 A0
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQO-WNI4-BRD4-TY3E-UDGO-5X75-6675",
      "Salt":"WCMXq0pObMyKMo1ixtlSfA",
      "recipients":[{
          "kid":"MAZQ-4ASQ-M4GB-2AH6-JYBJ-G7ME-3GP3",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"BsEDw9N8SWsy8RnTUobi9LxdoF5ctlv2pmRF6QQ2ijA"}},
          "wmk":"zw6jkkwCTEHuqE-e9YS8EVtTXpgUvNBEGEFYsBQ72M9eS22riR
  8Ghg"}
        ]},
    "V8sfi-kPAH_iJjVrtgZZoy4t89t2kRsg080CZmWACtIhep9809ggIvrUEYYjto
  EN_iGfpxuCuDyrWGz3rOICoA"
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
      "dig":"SHA2"},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBsZS
  BibG9ja3M",
    {
      "signatures":[{
          "alg":"SHA2",
          "kid":"MCZH-3KUN-DZH5-GSPY-6KV5-A43N-DFF3",
          "signature":"_hLBDZT8oZozrwweypbtmSl_rtqmuZNjnF4343VZxEqz
  94A72B-_qluqYqXzNO0PyoO6xUyrHZ3QjhzBa4TjAg"}
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
      "dig":"SHA2",
      "kid":"EBQJ-ABSI-QR3P-XSEY-RJQT-45MV-FDN2",
      "Salt":"cfY_McNrYQDbxeIG3bS2TA",
      "recipients":[{
          "kid":"MAZQ-4ASQ-M4GB-2AH6-JYBJ-G7ME-3GP3",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"7uJciy6zYF43EXDcqPz6btXMdpopnPeE1gZYzZINKS0"}},
          "wmk":"wkgWkMQ9EllWy-ji8erztJCgUuKGm2vDueSdM_cR6IGndwvHod
  Y6JQ"}
        ]},
    "iE2cIZWiR8U1mH7j8cyK-PcdSyZM0LdkE_nbMXm9cOJqQwSI78gNs1qzZd0L1T
  Aah3XG5uDTDjw-e2XbVGOy2Q",
    {
      "signatures":[{
          "alg":"SHA2",
          "kid":"MCZH-3KUN-DZH5-GSPY-6KV5-A43N-DFF3",
          "signature":"iUjTTlN5ofNjyoMfmeXY4L6y8QCvyE8y1zHoJRuVD3po
  -dP2BL_VOfc-qDLg6PM8O4b8NKMHfCmRba1WfnWkCw",
          "witness":"kl3qVDZaaDWYnOjhDwvE7JHs-Q_tG1xJrYfq0vc4Ag8"}
        ],
      "PayloadDigest":"ohlZ-KKC10cqZ7rQwmEhANTDRDV2vsPQu2DKnfXFChgN
  f5jLfiNdIwi4IkBLcllGGANITDKyyg6fmPSMCnTrqw"}
    ]}
~~~~


