
#Test Examples

In the following examples, Alice's encryption private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"9w5mh_jfFJychdw7k29F1zwfV6KAk0GLz3Orv478uMQ"}}
~~~~

 Alice's signature private key parameters are:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"yjrUDVNNSbZIsuk_OwpJzGErfz-3B_483-pJzYTtmb4"}}
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
      "Annotations":["iAEBiC1TdWJqZWN0OiBNZXNzYWdlIG1ldGFkYXRhIHNo
  b3VsZCBiZSBlbmNyeXB0ZWQ",
        "iAECiAoyMDE4LTAyLTAx"
        ]},
    "VGhpcyBpcyBhIHRlc3QgbG9uZyBlbm91Z2ggdG8gcmVxdWlyZSBtdWx0aXBs
  ZSBibG9ja3M"
    ]}
~~~~

## Encrypted Message

The creator generates a master session key:

~~~~

  1B E9 6A 5B  E6 4B 4C B6  51 93 A4 15  4F B8 5E 0A
  2B B6 A2 2D  59 85 3F 9C  00 20 7E 9D  B7 05 0C 5B
~~~~

For each recipient of the message:

The creator generates an ephemeral key:

~~~~
{
  "PrivateKeyECDH":{
    "crv":"Ed25519",
    "Private":"umxRoIt_v-NK5bZKL7AjTOBLdx-mi4imnjBPJrd4C0E"}}
~~~~

The key agreement value is calculated:

~~~~

  FB A9 38 AE  FF 10 2D B4  58 EF 5D 7B  79 46 78 78
  F4 47 A7 6D  BB 2E D2 B4  47 E1 04 52  A0 22 1D 91
~~~~

The key agreement value is used as the input to a HKDF key
derivation function with the info parameter 
master to create the key used to wrap the master key:

~~~~

  75 9F B6 1E  C6 BC D5 7E  67 75 BD EC  B7 C9 C9 6E
  94 BA 37 6A  3B 8F 87 44  45 46 06 38  33 5A 85 45
~~~~

The wrapped master key is:

~~~~

  98 04 0D D2  70 60 32 BD  7D 33 F0 39  C4 9D 0D B6
  2E 02 C2 D9  77 7C 3D 43  47 82 7E EE  8F 31 00 39
  16 5B 7E 63  81 3A 98 41
~~~~

This information is used to calculate the Recipient information
shown in the example below.

To encrypt a message, we first generate a unique salt value:


~~~~

  AA CD 32 EC  AD 58 70 5D  D6 BE 2D AD  78 3C E6 A4
~~~~

The salt value and master key are used to generate the payload encryption
key:

~~~~

  05 C7 44 1A  50 B4 EC E8  55 9D 95 06  F8 7D 2C 0A
  1C 3E DD 60  E7 66 72 CE  DC 2A D0 94  B7 26 A4 DF
~~~~

Since AES is a block cipher, we also require an initializarion vector:

~~~~

  08 45 FD EB  39 3B 25 76  D7 38 5D 11  EC 2C A7 6F
~~~~

The output sequence is the encrypted bytes:

~~~~

  50 48 0F 34  06 82 87 E8  1C C9 E8 89  29 DA 99 A7
  1E 33 77 47  66 FF CF 96  C9 08 EF 3C  51 A8 4D ED
  19 00 8E 1B  D2 8E 11 98  CF 74 D0 20  6F 5C 7F DF
  EF 67 AD 8E  D5 DD D8 A7  B2 CA 5F FD  A9 D3 A7 76
~~~~

Since the message is not signed, there is no need for a trailer.
The completed message is:

~~~~
{
  "DareEnvelope":[{
      "enc":"A256CBC",
      "kid":"EBQH-NWLL-AAMB-5TA5-PRX6-ZB7Z-QYZK",
      "Salt":"qs0y7K1YcF3Wvi2teDzmpA",
      "recipients":[{
          "kid":"MAE2-3NJU-IUW7-N44W-W6F6-IBEK-D6JI",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"C4cfRZZ4up-3JyPCXruTzs-FHzf0kvI3YJZxFwHcg
  5Y"}},
          "wmk":"mAQN0nBgMr19M_A5xJ0Nti4Cwtl3fD1DR4J-7o8xADkWW35j
  gTqYQQ"}
        ]},
    "UEgPNAaCh-gcyeiJKdqZpx4zd0dm_8-WyQjvPFGoTe0ZAI4b0o4RmM900CBv
  XH_f72etjtXd2Keyyl_9qdOndg"
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
          "kid":"MAI6-IZLB-FL4W-3DTO-KNUR-GOSM-7YAJ",
          "signature":"dAomURrU_Dnnc9LWEU7Od9j2A6RwmXVfTpi-JuSyfe
  DZV8Ck1hdxcrzkXZTjs1MomfxpxdthoPPm6jCbP__wDw"}
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
      "kid":"EBQO-FINI-6ZUF-HLTN-NUFW-EEOH-FTI3",
      "Salt":"KLMIWzpWshuv2gjrtWyQDQ",
      "recipients":[{
          "kid":"MAE2-3NJU-IUW7-N44W-W6F6-IBEK-D6JI",
          "epk":{
            "PublicKeyECDH":{
              "crv":"Ed25519",
              "Public":"FxcBgrezvnAijHr1oS0B_6O8sgW9qEYuGAGCRHrQZ
  Ls"}},
          "wmk":"pAmdw0CXCxB6RawrUPCi0_sRb8qCvaCn_wcnPZpTPoUy6wKM
  KYt-MA"}
        ]},
    "ytUidym-WoNGIcoco9Bzidoy8oTR1xkCWR3991kYeDRDUs_MobnpB32d6c2V
  WlGigVGri19Q-nBP5duYQKYMcA",
    {
      "signatures":[{
          "alg":"S512",
          "kid":"MAI6-IZLB-FL4W-3DTO-KNUR-GOSM-7YAJ",
          "signature":"b9cIuTGeK3s0o2ugg42PZxETdBQ96UE1SeRkNRq1Sd
  97AcDCmj9o3aJ9RhIWMjPqfi3aCe24ZEJk4Evlay3LBg",
          "witness":"5h1y7fj_hPF_0eoKD_5Ci2iF_2YvTzRPwunTrVjTi4I"}
        ],
      "PayloadDigest":"I1cIRpzGvTk9D2QBinOqJJufmTWmqGOmnKagAAiyOB
  go02w2VijpEl4k5iSRQcqx37zxHY_h8dnVbOwagc-SnA"}
    ]}
~~~~


