
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"7y6FC76LkHz64KyG9cTFr8XnFaqv1Dw2Kbem9-JuFNw",
    "crv":"Ed25519"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"EfISSistQefP583hd5n4chZPmgQPJukKZCMB-leIoAQ",
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

  79 86 A9 42  FB B0 A4 1E  01 44 E1 27  ED AB 11 62
  1C E1 A6 58  AD 5A 14 66  65 9E 85 AC  45 96 61 01
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "Private":"CjU4N0Z18lvEXxPsQEY8nrFbePEXAuSW8Z737TulbvM",
    "crv":"Ed25519"}}
~~~~

The key agreement value is calculated:

~~~~

  0C F8 05 7F  EB CC C4 10  8B A0 E8 51  5D 25 30 98
  C8 6D 85 BA  FC FD 3F 78  45 96 32 F9  49 06 B8 B5
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the base seed:

~~~~

  3A 10 D7 25  7E CE C2 EF  0C 77 0A 68  07 42 BF B3
  B3 DE 9D 35  B2 52 2B E0  F2 41 C2 12  2C 3F CB DE
~~~~

The wrapped base seed is:

~~~~

  E6 2D 9A 02  05 F1 42 F9  1E CA CC 5A  27 16 9D 7C
  CD 50 4F 11  BD 16 12 FC  01 80 AD DD  8A FB 6B 63
  5D 77 6B C1  2D 68 03 96
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  30 32 CA FE  98 EA B6 2E  A7 5A CB F7  A4 BA 9D 3A
~~~~

The base seed and salt value are used to generate the payload encryption
key:

~~~~

  1E 9F 2A 38  42 4A 95 FB  C0 78 9F C5  1D EC 4F 83
  ED 14 4A CA  8F DD 40 88  E1 B2 83 64  34 C4 21 F3
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  1C E0 FA 61  47 DC A2 AB  83 D1 C2 E3  D8 11 4D 76
~~~~

The output sequence is the encrypted bytes:

~~~~

  71 4B FA E5  38 F9 6A 98  C6 D2 51 9A  6E 0A 66 2B
  7A AE 72 EC  21 40 E1 63  00 96 A0 7B  AE D7 BB 92
  1E C9 02 15  D9 4D 03 98  E2 82 EA 72  48 2C 05 0C
  50 89 54 30  62 41 52 69  0F 31 40 33  C0 D1 27 EC
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQD-RA45-JFR7-HPBG-ZR4S-B6C4-ZKCT",
      "Salt":"MDLK_pjqti6nWsv3pLqdOg",
      "recipients":[{
          "kid":"MDTM-GPIA-P4O6-EKFJ-EYN6-ZDER-CYHK",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"2iPyFZwqMVylpCyChssZoIkgU49QLcQtQ9YlGTfGk
  n0"}},
          "wmk":"WfZ8OGr6KfFLqvIFq6VFdz-DevyzyF4ALVKkCSFeXKqeY1wX
  LX7j0A"}
        ]},
    "cUv65Tj5apjG0lGabgpmK3qucuwhQOFjAJage67Xu5IeyQIV2U0DmOKC6nJI
  LAUMUIlUMGJBUmkPMUAzwNEn7A"
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
          "kid":"MAQ5-ISDT-UZY5-HV46-LBFJ-KFDJ-URWR",
          "signature":"NPNbQ7DULJQ-8UNbMRVN_D95IgwWWH1DD8VwzSfZV8
  XKRBSQgx2au9HBbrVRn3X7GTddadMMcW9Z4WhyQ01xBQ"}
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
      "kid":"EBQM-VTDI-4DHA-WB3Z-BLJ3-QFFK-4VQG",
      "Salt":"yMBFjh5n4MB5lRgM-K3K5Q",
      "recipients":[{
          "kid":"MDTM-GPIA-P4O6-EKFJ-EYN6-ZDER-CYHK",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"Z7mEaNQ1amnS8boJ1oQT-MZFzr4iM2QKiXpdlCOj4
  hU"}},
          "wmk":"JFZvqBYH_iRXajUkS08O5GeiiwiZHExs19vvnLofhgbsGtms
  xsjPRQ"}
        ],
      "dig":"S512"},
    "bM7tcayYm0frxxDREBtMcy9LkSwOeepDFsKYcct8cIX02sTyUSWkQyhh_ZVD
  pb1IuprAPXzUBk1hH2p__frpIA",
    {
      "signatures":[{
          "alg":"ED25519",
          "kid":"MAQ5-ISDT-UZY5-HV46-LBFJ-KFDJ-URWR",
          "signature":"-9r2OqhBKxz2kYGY6kWL6kd19zsOWHCuopFL6JMJLt
  jnKq5R_1EN1jXoT0Jp8l8FET_6ApvRirvxRLp9AJquAg"}
        ],
      "WitnessValue":"mpFq4Dvf4dpyvXPY0jSqGD83BiYRBYcHoBTipaT7bK0",
      "PayloadDigest":"ziyURzEQdbY-Weme0S6RbyhwWDHD5tEWOJF4_ZGwf4
  9s3sWTAt6nz55bFw7E9T2YQ1Vm_nqefL8yxAazpzsdVQ"}
    ]}
~~~~


