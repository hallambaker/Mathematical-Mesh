
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQI-M2P3-F55D-WCEB-7VYU-LWC6-Q2BM",
    "Salt":"o9Re2obfj5Ph_SkaE_NFJA",
    "Annotations":["iAEBiCCup_XWe2Sc39QuAMS81a3RUruO8JkI71oTt1Md9y
  v1RA",
      "iAECiCC8plNhUWr9nbr2k5DIVRG29ZoUdS0ppyG8cjuuBR-PIw",
      "iAEDiDBsBoOnbfEdhDuAQLAzQ96Lwt5UVxE1jM12bVTmXCcosAOF9F3ch1
  CRJ_WciSrLO6I"
      ],
    "recipients":[{
        "kid":"MACG-BP6N-3XDH-2FFJ-C4VH-7ZCE-Q7LE",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"xla-MsXQifGqhIe7_v4tPBhK_clFQH_NHOuj6vgVoYU"}},
        "wmk":"zxffIN8ZMvtlZhiXJo0fgpvr0XQNP0R_79VeAUFl0FOBSSczCx
  JV9A"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "FNfliMVMoDIEeV3iIc8n9PDferocMOSOnolkol-VNeY0y4ULR6Iev8rgXQUmrT
  2g098dAT3TEgbRK8y0CKQJeg"
  ]
~~~~

