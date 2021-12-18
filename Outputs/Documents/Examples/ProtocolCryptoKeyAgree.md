
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MC23-IO7X-XTEA-ZSFN-VPVV-O73X-CNCH",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQH-SBUL-OFEN-77SY-WGXR-E3LY-5W4R",
            "Salt":"CpIr9XmfOVyI81Cw8Rg6fg",
            "recipients":[{
                "kid":"MD3L-EYHD-5R33-LRSC-E63I-THV7-F2DP",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"FhPqcGXXMrY4Qkkb6eeHn5UGeMMff2Oeh0e
  XYKgXyleuy0mefFQn5RozHBrLXA3Zc6XcCDxzqDwA"}},
                "wmk":"mhnAdZjiCIgpaM1ENRQEFfOnEjQXV3LAyODdmABS6I
  39aarkCQWqsg"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTItMThUMDE6NTc6MjJaIn0"},
          "jeQakwjY3DZH0TH0sFWpG0DM3bfoRM3VGRpeQknfxJ16Qagn9XEqVa
  qiRYoaoMXJgBItQp3H9NqCKZmad4EvDHN4r0wBv23f_heaKvCaYg9Kvgw1GnLMiKx
  yOxJHqDKKuMRCSaApwHJO6r9pGGHVUjoMNfHhrbV1Zci4RVbzoXUsNHlwRqaVYB-4
  AWnud-uVyrVxdhR58OM3M-IZ1aoTRkyxDnE63rb_MSgq5CawQMwX9JNNezptP_VAC
  NbNvqZce8BcWZBRIBpyB95Pc7eTIoh-7rskm3axUm2WvE3zNXPtLZgT-R57oofFxR
  FCVC0KSFzxhhAnjZe6aSlE1KzmJkJm-7XYqbC0cUMuxxh5-c_Codp7I6U403F1XvU
  gHZV5hZ1GdV9wv-383YjSjIH1li1LU8WG-gMnkoe9kAoumIFvtcXr6_CP3llb8Cy1
  MBentJF7vyC8_MxNmvVcyq-MOwk5LRhKm6WUbYbwC1jAjHdWiMM-RHlqA-FtZJUb5
  wZvzOOSIh1SUAzLYOcJoTRZ9I9ddRsE1hIAzjoH5dE5-g4H3Oudut1d5cvNFw6Dr8
  Ycrjjmld2ShuCu7VaxUqDjXmCV9cM5VojhZh_-Afvmny6WOBeQX6otpHBzXfVVIV6
  pTWmcKJb9UjxnKonUPB4mYNCETbS6bCSAVykVoT3xvipKtVjFTYmGpD-MHp2OGNzF
  GSp3uExaaXAq9aRLMXkFvA"
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
          "KeyId":"MC23-IO7X-XTEA-ZSFN-VPVV-O73X-CNCH",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"CQF8UAfkwk4MRwhIWZSGGjj6PjZ6upEP9K_xz1y_F
  Zn9TpYaXogbakICRm_rUlCNIJxlH7OPK-eA"}}}}
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
              "Result":"_ci_258nv-sQpC_azbR4saDP5cDRZIWh3as7nFOFn
  -q9fllY3wG6itd5ppbuiaA4MLQMxnp0ljiA"}}}}
      ]}}
~~~~

