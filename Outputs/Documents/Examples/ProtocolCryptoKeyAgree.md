
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MB2A-CXKT-EXGZ-473B-X27A-QZCK-UZFP",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQL-UGQL-D2MA-V3H4-JKUV-NYEE-A7JL",
            "Salt":"cDwzGKgiCRZa5SkWHxq4_w",
            "recipients":[{
                "kid":"MC3A-K4P7-Z4BY-X75Z-I7DO-QNZI-S4TN",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"GW7zdtvzIY53J8WJWxlbxsc990meMm8aGeA
  m13LjP1HuGyFSWic9qnGgf_Cm3AhBFYleH_MwYsYA"}},
                "wmk":"wKDyiXL_uSJQb25FKYw3DUq5FAsHv1BhjUcJxUx2Xt
  mPlBwAafB29A"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTItMTlUMTk6MjE6MTZaIn0"},
          "9A8nxZKirBOGAAeCWtlAMoVGGRJEs6LJaOzq8SLaf2gVuqfq4fkokx
  _zuQi0KS1dFErYpFJwKgDs8dbzrissItEMViYImHBCH-4Gco4voE1dnMHSPt2mL8i
  ByBk30mGPlI5V7yEKed-oXNY61pYZl4yvrSAnw27mnU_f05grkx4_I1lIDSz0xL-J
  4tGpn_lswaSEg3tVCCjAtDedtwTwH5d4sc0pAll3O-zgYuW89XqW95943I7v9KOom
  tg7POQbc3qbyXQzsFp072pC8lnsOMH7frKZableOwgpqV2LO9O4hy5bofT83bnjfT
  rY7nSje3bfzgJSG1Avmgih8odepdk4_UnVTXys-ZYuIMZRDmGRpbcZUxfC17aGAHA
  Wr6oWg3Eb-hfPi5gbhyHMrOVT_IsVFWWeK2KFWwQkJZaEkgQ_A4pYFCUteZieXGXf
  inQ7-Huf6K97rgYQEl8H0SW7mYmTwqAUsNijuIXRsbcFvLz0oipxpY4wiX7GGZIHE
  uXOTZBEan5MRzva0tCX2hRwEKACpFXymOWYZnEQn84FFzw9RWm4AA5bJja47LYgEO
  RWI_zwZw6Pz13bj1B6rWKpH6EUqgsV5EZyWhfpMEkF_yNwoF0-Vw0bVoYppLoLtgf
  Q5jIFNrvi61Vd8APmeSSkIaqKEEXJ3wHn2ekYMk4vUqeyjGU3dJNaYYpIPqdcJzDM
  dBk4Hh1nOxVflzk8x24YlA"
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
          "KeyId":"MB2A-CXKT-EXGZ-473B-X27A-QZCK-UZFP",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"l6W88nZJ24wOFeqQPhnaBuDPfS-Io0FaWunL_hxyI
  ZYN9oKQFfi0F_oWsVZ7oFPk6L3eNDIacmcA"}}}}
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
              "Result":"emPbcGISO8QZIb451rN-Roqz4xhSzXwkFz0tn-P9C
  ssHM1013HmwG9feQUbDlI_yeZqDAxShit8A"}}}}
      ]}}
~~~~

