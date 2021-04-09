
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQP-2DLV-TUZQ-EMFK-XRGF-PN32-BJ3S",
    "Salt":"vWOrqwtZ3uKGcixDz4U2Qw",
    "annotations":["iAEAiCAMYDpX8xrbKM92QAsQmNZclyd_vMBxCJi5VEl_XB
  a15g",
      "iAEBiCC-XyRtP7V3xxe-UOMMx3M0BBAXrRBZ5_OmeTjMoCwxkQ",
      "iAECiDAukX8EaDETxxc80dAeGprWHKRHz1w5pKDuPjO7PaLhtHVKzqwZY0
  JePPq3oeIXJmk"
      ],
    "recipients":[{
        "kid":"MCBO-GJDS-ZSKH-YCWA-WAIQ-W2LI-Z5Z6",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"PYiRPSj_B-xSU-D5PfGBlpJxHWtxaWjv-UTi7D-4Jb8"}},
        "wmk":"4tyCupRacKAuP0I7MJg7N558T47tPbZN9jC_W82AQ1NXQ9Zz4k
  jziA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "Wxf8BN0UU8eInxTlPklQ6IugYt5aHOArseMpCRbqrlsPOx5GWB07RReYTkQGpZ
  NyHnqlm9gk_ck-icVfxAIO3w"
  ]
~~~~

