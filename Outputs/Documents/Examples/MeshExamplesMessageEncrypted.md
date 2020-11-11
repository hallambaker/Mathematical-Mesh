
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQF-A7R2-P2KL-IRPB-NC4J-PLCR-HQE2",
    "Salt":"6eYDXKwoTPDE-4AhyQtLqw",
    "Annotations":["iAEBiCCo5iyFnYO6DQvswD3EsAJN42U-u2JwUT0dXJLBtR
  -RtA",
      "iAECiCC6Gdl6alWSF9YULAg299PX19id8r_GqhVkbCm4y5_xyg",
      "iAEDiDAMB0CpeRmNRJDp2BbbWK7afp9_AblJ4IOwAm7JW7cBjuXS3art4W
  ACgXjwtgVUxjs"
      ],
    "recipients":[{
        "kid":"MAAB-5QQZ-WH4Z-YE3R-KYUY-7DCU-JW3D",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"TxrqNA-y3CuK5l-2PgdGlmaC9NcMH-UKjMpDlWwxvk0"}},
        "wmk":"H3rPuSSBdJ_i7Ot_KAzT0wVEzvorrH3Z5cn_zAOdPTM4p-6ONS
  y0rQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "lxzd7TxWZlS0GWR0LQ-AIT4IhSGwolzkd94U_plAuwr23ODeTM6-p5e5mwFIAW
  9nzLoy-L_UzMw3Ev7KwyQW1A"
  ]
~~~~

