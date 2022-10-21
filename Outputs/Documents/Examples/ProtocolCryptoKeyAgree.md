
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQP-6DRQ-2TLC-BCIO-IEN4-XYON-7TOK",
            "Salt":"cLEpWYfA_14wpQzGEwwMZA",
            "recipients":[{
                "kid":"MA6Q-4KLG-YT7L-YV2N-DS4T-HP2G-Z3H6",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"xJQBqymZRqaMGdbcqipO728xaVACSIm7-o4
  GQx7uFL2CR8ogbRsh1XLOPU9gwaSP0nO9X6yzx0QA"}},
                "wmk":"RxqG7EcQH1eQXzCvug-DnqTxz4V6-7P0HeHZx6PMxN
  jzarvLHmT5Ng"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjItMTAtMThUMTI6NDQ6MzRaIn0"},
          "m8W7c9a-Bw8Dcrh5P15KNYNw5SgeIaeYYYnih1aBwhc3mfZsWGcvdp
  I_BPCxHWJ_-3wsDc00htKUDDFUnQb9jppJuG5VBehH80iJX1vPqoQ2tK7xuIYvJEH
  u0sVlAxAjmTqSewnGFa8h9ndO7uR_MkuoUCRo0_WplxE2x7LqwwqJR0auZfdxrj9c
  -0yTmjmD7UoVVQfqw8Fmie64gNDqsknZcxGBeZvaqOCMw9boyojzq0P62nFUhRVl4
  OSyzXiUQd69vuz1Z4eOXqZXCZTcHDxBCd9uh-lDJqh68MwHb8ONuWNjysIvWylC7r
  fFICGzkO99QRGfErXtlwPG6Ir5aSK13Wlen7h9wRlE_kkh_hVlvBUw63WOQs9XQ1Z
  k_8_IuRQ3zn82d8_8nLGU8_OTVF1FrTdIy1zlKjkbUm6mm7WKu-zIvt4vS-lX7NE0
  olGotZU7IcXOCdlMy8DvRpcGcKXnj6yLqgQnW7eAW6AsnXi_vpLkXMaHi3eVhliWk
  dkGF3n60yQNHlDrFTUSP1S-fSGPHB4ot3muzVOKT5lx3ZjIMzm4ibS4WVtbuKlxxt
  jtlRj09nqw1uC6EBo03G2Bt8FxXUk7eD7rOLOoufUDLHMFHHdAhLe4Ea541bP6p_L
  JvDvUbTPg5Iq960uPCqJO3uSv8X5Urwi05H07D4zMQ9nnrJZWX0XTjyEURvsJtDt8
  l2EPY332_0X211mQWynugw"
          ],
        "Id":"MBVT-4N6Y-ARXQ-F3ZO-NEOS-EYNS-AG5N",
        "Active":true}}}}
~~~~

The private key (in this case a key share) is encrypted under the service key.

To make use of the access entry, a request is made that specifies the key share
to be operated on and the public key parameters to perform the agreement with.

The request payload:


~~~~
{
  "OperateRequest":{
    "AccountAddress":"groupw@example.com",
    "Operations":[{
        "CryptographicOperationKeyAgreement":{
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"z5zGNSPu0Rb5k9cYKwjBrJTZwBBnZACAKEeZqeH2u
  YXB4kggHSUjEmhIDeztsvsJ8F2b2HsMSMeA"}},
          "KeyId":"MBVT-4N6Y-ARXQ-F3ZO-NEOS-EYNS-AG5N"}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"YqgJtmNNDS0becbHYSKYxcLvwpIXkPitWyHyPERQM
  9aV_8zoWAjE7Evqv6isn_hfAoKswajzTJoA"}}}}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~

