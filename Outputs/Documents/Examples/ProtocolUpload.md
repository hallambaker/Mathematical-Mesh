
The request payload specifies the data to be appended to the stores.


~~~~
{
  "TransactRequest":{
    "Updates":[{
        "Envelopes":[[{
              "enc":"A256CBC",
              "dig":"S512",
              "kid":"EBQG-ABNM-VGL3-YZPB-MCTH-RCCN-MVRF",
              "Salt":"zQqPRQivGSXVQpq_vC-glA",
              "recipients":[{
                  "kid":"MDEC-T7A4-FMKQ-ARG4-A7XL-C5YG-6Z7P",
                  "epk":{
                    "PublicKeyECDH":{
                      "crv":"X448",
                      "Public":"YjBwUWu6QUiLDH6yKpmzF0NqewYU2ceNy
  XlighsJvD4u9HlucHVHP8_z1wH3vSAAGDhEXi1GOkQA"}},
                  "wmk":"zcLc8KMJYu8BItSMrHEM1ny8wvLb6VcLFBLW1gGK
  teX2yunNOas-kw"}
                ],
              "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQVFULUZL
  N1gtR0w1QS1DUUNOLTVWNUQtWFlWVC1VMjY3IiwKICAiRXZlbnQiOiAiTmV3In0",
              "SequenceInfo":{
                "Index":1,
                "TreePosition":0},
              "PayloadDigest":"6ZmcFu-7qSH168GqmF7ivXphhJ7pqpAEj1
  ire6a5gXGyNYqeZbTC7uu0v1Kfw31IyEAPu5HUSHciuJdAS2cw-A",
              "TreeDigest":"zQRyNXghPaZ6zCnb34oSAt986UQkvhtIAlzlQ
  wf4NWVafUSGIMNKbce9tIg18ETBO-jZoFh4F_13Cm0_arXQFA"},
            "mKlLNGh_cJ7xht4pkpMZuRlkBe1NsM5AlY8FRptEQxTySgXE_IA4
  y9VfLcDcTOu6KmDSk9x1Vz2vX53C8eIhb1dZs5VNjjyQr6Nt8LNh4SI32f3NsF78v
  dyGBP-jImCOo3mWkivzQqJC9ZGKgzPTlDCMP_20oh6vwO8n2UcusTseMVfOjWmlIH
  zhMKynHC00"
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




