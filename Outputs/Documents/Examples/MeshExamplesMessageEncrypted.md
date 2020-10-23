
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-3UFY-333S-CC5C-Z7KR-LUVT-YXE7",
    "Salt":"SHC5DUIGtcw7YOsqoqynvQ",
    "Annotations":["iAEBiCBc7FQyn25LQX5T2jaNFoa8o__Fmz1kkf8tCyuHcL53
  jA",
      "iAECiCCrilC-ld8dAAkMOr0sSHF4ZVVTn3f7wpZ3sy0ec_ERCQ",
      "iAEDiDAVPSYgWQbxxelvYOywGzDTnbAd9-WSZP2_q5zCWJ_MlhwItHVpkqp7
  u0WvGHiLxrM"
      ],
    "recipients":[{
        "kid":"MDN4-UHD2-ZAI2-64DP-5JAM-Z3O4-VYJ4",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"4-0WqFhszd7HVky9OczAH3xfM7Uvb5pVobU98um-d0Y"}},
        "wmk":"6MmdHrCn2ND_gZBXTII-HJeVpiXlKmVXibP_UhkA0P_ixFMs3TaO
  AA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS1t
  YWlsIn0"},
  "L6_Mdg1OxFyz0r8EwVzG07wXuow8BI4baejaVqbcj6ScvWfyDLoBsVW-55HlhaZh
  7niMLZzZ8tLukdw_9F0gmg"
  ]
~~~~

