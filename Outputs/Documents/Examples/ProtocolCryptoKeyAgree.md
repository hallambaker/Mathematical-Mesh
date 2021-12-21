
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MCAL-TOGV-SG7G-N3I2-I6EB-HJ5A-D3FR",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQK-ZCUZ-QSWR-JK32-S5RH-SLNP-JUZK",
            "Salt":"oquV-MHNCkykTuQooyqZ9Q",
            "recipients":[{
                "kid":"MCGU-RMAQ-IZNO-MXB3-PHC3-BTHK-R7TO",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"ARCBtmJa4XtTQPimEfJ0XOTIxyAWAVlhj-5
  BCWsHCuMFK4Kt27uhegnzMSRVtgnelXywRDubsMiA"}},
                "wmk":"Z7_EwB6o4rVfb2j1SQkhd18wv_-XGjy5S4mf3p8kjq
  WEGJNMXnRwoA"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTItMjFUMTM6Mjg6MjlaIn0"},
          "x16D1QecGdwL6eZl0OTQtdqZkRhlr2s7h9PUhG58wxAk8PZtnaNHuv
  RVKzNZbU5b8-jctI8rAhtIZrdgRUoMOxod6CtFg3s01UYkBP3dB3RZ65B3X2BN9lR
  Jl8RrIEfGBK-pxbX2cP5FovTHwcZ8IPTmRHC3esii6GnR0COlbbqDQPLeyoe993vF
  rzq0Cseo5PnciC9eN4EdVFwldnMMh1J4GP_bi1vyLpcfcC_a1KasjcmkKA5ZDrsto
  LbmZlmUfP0qwak-nguCc-lkMC5DZx9gmS-4nsXg6zhhAutFQKPXo7Z-rs7_aMMBN7
  nJdj2z2ruXdRXI4M6yJ9eW_1CjQlWaK_TfQaEcBGKcYsOlPhMOizcgv2zW25coXvM
  Jy1lA6d9TZJiYAnCweXZraNBX31HBxcpn2-w5DGJ2QhNUzK1Lh0NCJSFAcIZFUdXI
  -5WAVPZn9wmqioid4W0ezKMe44rYUCrPkx9VdPLKYqqdOh6BPBo8kGpsKdFu_6wQ1
  _9wf5lAip0Tho_U_IhURijZEMzRW4kTt-E_kXG6uPJm6DvfvTMTZ1lM6ExTdATpyh
  cUQYPQ8hkgLdy8qQ5qz0hYEpvokw0L9L3MZv25rsfvJAr1pROU3NcMdXrkAx6fTFg
  vdLlFW5UxW7C-j9PEu0perfBq1Z_J2ZgYAUL5Ab-ljdFFixHgWqi-IwfxQDmsDp2E
  suIJH-rF-GYT-W5TicauaA"
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
          "KeyId":"MCAL-TOGV-SG7G-N3I2-I6EB-HJ5A-D3FR",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"xbLGJhTuy5T4iacPn9G3Y46SwQ5Trq-znLnU31gF9
  cYWEcQmjArlaPRLSbQseMTi2iQFloJXejUA"}}}}
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
              "Result":"phnY_54hMycemnNul4rK4mxbrIeXUoZcbEXzB7oY8
  kXHP9CFJLBnbGc7xnnbYxX1jWBowPShD2MA"}}}}
      ]}}
~~~~

