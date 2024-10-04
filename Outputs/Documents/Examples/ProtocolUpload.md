
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "kid":"EBQG-2N4U-5L6V-XYNQ-B6Q6-OHJH-MN53",
              "Salt":"TJ_u2tG0TE0UFb4XsFgE9Q",
              "recipients":[{
                  "kid":"MD5O-USW6-UBL3-HFWZ-DQ4O-HOEV-AYQX",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"sj0LYye68_V5CSy29z9BHWhpTtQU0cQZ2
  atKVzfDzcVX1A5o-Filw9-vA4EoVfgJ9cGNGX-XJwWA"}},
                  "wmk":"v5VCUqocEf2XIrAYBA9rlLUTK6m9U4x_gu-YrgI_
  DSTkMGleImawgw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlM1LVNR
  RjYtSDNEUy1QRldDLVYyQ0otUE5CTC1RNklCIiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0},
              "PayloadDigest":"G0WhBI3OMhtxG6AFRXV4-rjg0Pleqn2oJu
  eYWQ33H1sxv_2NRoH2d5dASMJLnJIlw0Oe-hlIr_2yNQqDm_dMbQ",
              "ApexDigest":"NUam8Njb7vaKRS_aHN2qp4vAAC3wQ5bjdyUcZ
  tXXrJA4rg0KWAARHjLogrGujs1SVvx5oVkNGapaGGQ9HRNsNw",
              "dig":"S512"},
            "kXubaFuLulJ3R0UAIMuKeIM2DWH04ybTDl65gsJcl-Zi4jXNQyiD
  cK7Mu2vqlyFuZYOVuduMvzRoDQMRywtR32X83702AB3kbCF13v1ZQGB6W2glkZlQK
  syRwVj4rE2fkHoOAgZQCcSj_2_ax8DMRW3sqUvKTUMQW6CkgEzk0II2B7qlE1xjxR
  Ia4CaIanPJ"
            ]
          ],
        "Store":"Bookmark"}
      ]}}
~~~~


The response reports successful completion:


~~~~
{
  "TransactResponse":{
    "Bitmask":"AAEAAA",
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~




