
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MAPK-LBYY-2G6S-7Y2F-7KWO-KZQC-2IEW",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQA-LO4N-N2FL-U23L-SKWO-POAW-VDLW",
            "Salt":"FXW3PsFesjcC6fDC3dHHMg",
            "recipients":[{
                "kid":"MAJY-65KP-C67E-LFXP-Q3XI-ZHZF-GNHV",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"CcZftsANqPybF3CXKG4neCPC5mLKeBaFIwv
  tkGBThR8QlqtAp0Gr-XevcrOlbqxhKP2kfxQQyxuA"}},
                "wmk":"VAR6_ezf8hgETm61CJ4CUOw66l_f8YKwG65_GYE96W
  5b_VeZNoOiHQ"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjItMDQtMjBUMTY6MTc6NDlaIn0"},
          "5HYVc-1SfcKj29O6UyNv_CptjRl-gy3hjp42VUdTi032r7Yamt4xmE
  hByPQgpVetmoFayOWc9V8GILPMbrQ8LO8OwHD35Fio_OfX1PLe8or5AuBylbF9y9f
  3S25QD9WupYJJN0L2m8hbia3LLbU-BcVSrmI0OjB7tkeEgp6vmboTGv9QQxSSrMTQ
  5v8Le6dtJhuUqwyj7JJA76oBWk8ZzibJ6hQLT1v5owABTPMxq1fGNRv2RgDtz4tpy
  deUBq5Gp9B0WKSKBCfOGFzNcunXbA5AbXWkORK4s07fZ42EsWiwkrncFRQqKTvomX
  37CHtJo4kJkoyhbQWAwcLHaeo5DQrWBHJq6p2evWH4Z0gW_ZB9f3UiuW3jEOj-wvG
  mYI5Mfo0Y5YEqy8iuOmo2KI3qDTAfWE_PID-4V2IWKhGibz7mqOy8pFMBUZXySwmY
  w-M8Wti61wlST10kPaivW-0hS86MWGYlfzrVP3GqWkqNfHBuI-1iHwe3nNz2npsI0
  Z3QnYr5VB-Q-ifkQZrYiTkPLKNAf_rR0-2le4lVBMasJJpk3cISt2V27RqxglrzX4
  nSh0abD-7jBuAr-h7dH4abak2zkcQWqqe1bVjSfQ8OS6on4auWb4ZmJHY_cBCz3Br
  wTer6j-0r1UWTtQg0V4SuEDLaR0VCqrQhiLgEdLENBzESJqa1x0vQHQeciteoBDa_
  CdQCdzPUYycikRI778ElNg"
          ]}}}}
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
          "KeyId":"MAPK-LBYY-2G6S-7Y2F-7KWO-KZQC-2IEW",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"7BkA7YrtcC7GrNRvyX0es1xOgNeUmSPFgLPsK8Xy-
  y8kaCqguTYD4BzWGBZi5a6KafeQQV6DwKcA"}}}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"RK_nkdnG2HF8Xm79VfrFpufigvIldNPo16ZIFf4-E
  GJaqRaHIBNVbDs-bTfS30FuJkadIzvfzQwA"}}}}
      ]}}
~~~~

