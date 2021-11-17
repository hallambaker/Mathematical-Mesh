
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQJ-F3HF-WSRR-53YK-37I3-NPWS-DI2R",
    "Salt":"_AB2_21ftAif0mb3OG7tdw",
    "annotations":["iAEAiCBSOa4a2ojOZX7LhcgavZnjpSFTUetC3Kl-ssKbXc
  4iLA",
      "iAEBiCDVHd1gP9MfZgj2LVPtQUUUjuN1uO4edfmDTRJRUXfiSA",
      "iAECiDBv1aBAveLy_zrcBh0xuq32WyIZX5uWElimVslhf9_WL9eR5PgTvw
  wOvpKvalFFlQc"
      ],
    "recipients":[{
        "kid":"MBMR-WQKI-2GTU-EBEY-XOTA-53NO-XPEK",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"YPWFbBbIqUKQgpMcWa5efsznELBpKk9QbfFcJAPHjEE"}},
        "wmk":"pPTcSLuK0bEvGeG7hSzlcJJS1NayHfe1DclO4UYzcJsFlrN7Vy
  bZvg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "-H0hjMjWs8VC2MErvsW7iCVmxHLrkSoWuyF6vDHQlnhaN1ucJPev-QMgG_LELi
  m7qUrUQ4jD8TphAJLhxkNjIg"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

