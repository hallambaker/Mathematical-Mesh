
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQH-AGVC-B622-U52I-WWQX-42ZZ-XTMT",
    "Salt":"8kQboNZviQDlGxUy97CWpA",
    "annotations":["iAEAiCAWtZhFPJYBgtEKi6wZDp4_D9l1XkSBcy4U7bmqTc
  L-uQ",
      "iAEBiCC45Wa_AynUFozyA2BWDNlDdUVK_dWQUn8X7rA2dlROmg",
      "iAECiDCD2Cr4A94KEaKwXdgWUw7L-WJSb8tpFa_L3UFCDS5Sy8oIGa-3I7
  jUj-lUuxaRrIw"
      ],
    "recipients":[{
        "kid":"MBWZ-WJJH-XO63-6ZXQ-CPE2-D5CQ-HW53",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"a5aLk7NjYnePkrMcT7Nf08cMHXRs3uxdlvv9Hqt99qU"}},
        "wmk":"r9esyj7Jl3fTlJUfaY3v9VLiRimhyUALqVJ8OIqnl-Nl5It25q
  Fx9A"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "BX9spCCwQP4roFYYACNLovuGVL5d7qt5uBtjRg_UH7FM5_nbc3COmsCFlKiwIA
  2R_2awaZ7WYM_Cw_q2Og2R5g"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

