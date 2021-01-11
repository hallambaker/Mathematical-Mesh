
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQB-GXCN-NWBB-SJFW-A7VT-CLWO-YZUQ",
    "Salt":"xf680E5NE2vfH1L8PMpSXQ",
    "annotations":["iAEAiCBWL3WZ3_VEUdvxL4duNfxISAM3L38Op4br00Bt29
  yNBw",
      "iAEBiCB1zLUQ_M68RDK9ZkTkDer9B8ZMuRbhX_3PWFHVVy6tYg",
      "iAECiDAdIRcq0f9_uK6qh3xaAw4FcrmvHirVHlZZSqMD1y3z9xmQp6R0bG
  66QNzuRcnMMH4"
      ],
    "recipients":[{
        "kid":"MBNX-4HDR-4DHY-3JXP-DBVJ-TB3N-QIZY",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"GN1e3Xw5_ENZW737iELroNC0dQ5bOmE807dY7PRdUYc"}},
        "wmk":"NypOa6W8lBzjhcPy3Lcqr9_OZqhSD6M1WMj8ZAjhyaWXJixRFP
  Sc9w"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "fHrNkvQlrIwFmuOlXHdB9KmLto3KRElk5gFwi8AtNKPhvrYlIMEiyOoVTx6eHd
  jY2FuU5N_J0asVuGWQ_0zBvQ"
  ]
~~~~

