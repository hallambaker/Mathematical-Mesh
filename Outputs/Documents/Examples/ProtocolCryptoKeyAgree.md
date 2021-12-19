
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MBDS-2J55-7GGZ-VRCV-ASVU-OTKA-6ZHL",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQJ-6VAH-7DQF-WSDR-V7KM-WUPG-GVGY",
            "Salt":"6juOvNhETIKXD3slSmRAMA",
            "recipients":[{
                "kid":"MAOF-V23O-H3AX-D7ST-RCAU-RUA7-56DH",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"faEf3nfxjf7ecS7IzNL20Pee1Hj2Ma8K5hY
  I2YRTxgqCg1TBpYrA6Y3sy5oeHmJrf9Aw2GIDL4MA"}},
                "wmk":"S1c_gsccCii4d5LFeuDqMVu-VPKQALM2egrd5rAumu
  6xNN3NsWdj4Q"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTItMTlUMDI6MTY6MDJaIn0"},
          "tfwg-LVuz1e6XdA5_h_Un2SH3EZYIhbKb_PNqES9aCg40Rlw1cGmjq
  6Mg1R3X7Zor9vNrAAvSQqlbk2aauc65ArBVikxEuGbe6TzDj9dxTFfDuOwqGSi1zq
  7qtzN3IVxr1iAE6jHnPJ5LVVLKfV3zvgPe-DEGPrqS9cnGDdp5cjRe-iS3PxuOfNd
  NN6JyuIBHrvwj6TNImGrVeNINQ1QYIWpOfBFZQ17enzyzP_jd-fNwLyfpg4F-WI-h
  2hd37F4vHj0PIU7w8beOoXsf9B72MJpA6wbVQDKVFb4uLK84Jke9f7QAn3iYCe5d1
  fxE1X1mU7JxbOy1oxiw9h9gABtk4VTXDiUT2X75WqbDd2g0DVBjey3lXEvaLmjwHZ
  Lrq8BYlfNQiWR77nFmeJrmDzGCAEgsQZRW_Lax5lpPwCjZnqLV34OAX9uJ-cVxhYO
  uaez7bw443T4OtRMdYZ39rRrZWPuJoaztO0LktMQ3t746YGFC9I1AfVHyAEBwgRwq
  wmOrVjZCOGC_xaKHvNA_Vwt8Uh8rVa5sn4J1PlIY9zGSVj1VG_89LUfI9i_1SX1ZL
  AppdSvH7DEzRc__VYMwoGwibvgWIPyIF3jfVL2WSFDHso1Z1xAWBVotgjT1ZpPYQS
  QftTQPWQ8NHwY0D6gHtS2nTgQ6000QLHL9pnvzQXNaHiG92DI6XfsxlV7xauZtrN3
  mqmzTUb7qOEo7SUYKElmmg"
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
          "KeyId":"MBDS-2J55-7GGZ-VRCV-ASVU-OTKA-6ZHL",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"PKaPiwz1Hd76CtzFjaPaqmcWzYNSKXq7safFQgFfh
  dqEoc-2bVQrhir5a5pwxD3CYln_TpWaBT0A"}}}}
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
              "Result":"tYkrR8TXQl40LMKNP71NPHrSoZ3zGb8qYBisp26QG
  ihXbAP_a9s1TfJ1VTiOkqc75fcRvKazyQgA"}}}}
      ]}}
~~~~

