
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
            "kid":"EBQH-2PZ5-HTKM-HC3Y-N6YT-VQ3A-ZZCR",
            "Salt":"H00N80phHkIfP95CI5ZlZw",
            "recipients":[{
                "kid":"MDET-26NB-5GRV-JOWD-HJ6D-6WUN-JLWE",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"MDbm9mOsQDWbtNQahw0CnoIFuZpoVsj8gtZ
  8F-yN11ioJnoxCz9S_v_mIDFOWiZAqy0a5I3YTjOA"}},
                "wmk":"p2KrCgM3HliVXkJLugonLHpT8ZPxxBWm1jZxOOWkBp
  8uxIAXFySoeA"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjQtMTAtMTRUMTM6MTA6NTVaIn0"},
          "wsXytUHUeYC6ko5uTPalgTsmTG1car6vZIbVPUcbgS81xAawr1wwAr
  ytRIJE2Ji3FbY4pQA8RRdzBAuxAbSTZIIvsCic3nYQ8wuxyX3JWkUPtuHj-5G4R3W
  o2TVHS2BQUywYgnCHOcfTaPLr2O1arDQ3fo401dYeJtFSPiOexmwjsghD_KXILmBA
  tUTZnp6UPI0yQd90Qmxs6QonkHgYwY8pmCoLJxebyf80C0teU4u5O8I1t0Nxlw1oH
  8Z6zgB-0K8u8lmf0h0IwxZRLnGjMAivV8D1n9SIYMZEnYzpItXu5zxf8z_RV15GO5
  d9qy3SRtPOlGSZXI3Xn_CRk9dt6jUbpGl-NCbqXAweA71x1dgTMXcDozHbL0UQhHH
  ZZlq8crxgfGAGr1PBHFc8Wg4yDxU_JLzwz3V2r7RnnMXfJsgE2-F-SZVYTtpZQ5LW
  DiuEMF5UR6wxz7cdd4hY-z2CjoydhrWmBBOCGgn7wwzd6XkvMg02trFAYM63psNr1
  YWh8qvI1rtx1h8DVKErp-2w2x64Hc1Tf7gW7eExGoFHG8nIWfEpJ28arPLoD0Z2tE
  5xAZ6UmlY3zYjU_rTmf62qhjNVdag5qu_YPilWHlD4oHvGh67e04QUOnzLR-UoScy
  BSdF1u6_HxenHJ46NV4mbzmZV2KvQw9Y7aMDLeR3gufmRR2Tr9nuKhQnO3zWSE68p
  VXIRxz5rVmo_fYtg3PrcdQ"
          ],
        "Id":"MBNJ-RWYE-WXIY-ETHX-RIVA-RKHM-Q7QC",
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
              "Public":"ZoSHmhH63m5wJqoaS3V0-B3KN2WL29IsJWdRDyIaT
  -glv5ZhlHZq0gN0_qWhpYt8yZYm0St0P9aA"}},
          "KeyId":"MBNJ-RWYE-WXIY-ETHX-RIVA-RKHM-Q7QC"}}
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
              "Result":"9iLvBSWGWu_iAvqdLxB8D-0yNFhNDe8it5FMZ4J7Q
  w6y25Z_oP4GTB9mxMucGukzeF0V0HiQeU4A"}}}}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~

