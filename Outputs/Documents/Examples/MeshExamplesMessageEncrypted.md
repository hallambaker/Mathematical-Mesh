
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-5YSY-6WCK-WIWQ-PJ2I-UZPY-XRQ4",
    "Salt":"80JdA2DqTOg_ESSyFCf0SQ",
    "annotations":["iAEAiCC68rJXTEGlQjBjah_Z2l_r0zR9ewG6oo3xnGXUnI
  _Epg",
      "iAEBiCA_N-6U8t5FpmZz8zonAZBwLXHmdhWtvvR9KrEvLLsr2A",
      "iAECiDBoSrcr2t-dmx4he-s2OLce1gcuSyG4uD9X8wdMjSgfJN-L-yy4Q1
  2odyS6VvZpw6o"
      ],
    "recipients":[{
        "kid":"MATO-SSLL-BMNJ-UVJZ-EM52-TME2-PP2S",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"0E4mziBeZSnfXiHDn065z6-WlT0TefCpiHaAf4I_5WE"}},
        "wmk":"CRQB1gRErTDWMX-xVJy9squarlbjP_u_YtofbeXtN4V5SE3O2Q
  USeQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "ULJOVgooKdNSjxfmXjzIjxO9FooXtVAt83wlh2UpqhAPRIcalH1zsuv029nja3
  5Ly8v710pjuyFs_FY7rY6RHw"
  ]
~~~~

