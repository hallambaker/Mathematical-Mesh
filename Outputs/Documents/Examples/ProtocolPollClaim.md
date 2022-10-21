
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQM-KNOL-3JSA-7ODT-IDYR-4MIF-T372",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "EnvelopedMessage":[{
        "EnvelopeId":"MBRA-UGUV-W5GN-5VFJ-MVZH-MMG3-VSIE",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORE1XLVM1NkItTz
  NEMy1OQUs2LVNLSEYtM0tIUi1VQ0Q3IiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjItMTAtMThUMTI6NDg6MThaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2022-10-18T12:48:18Z",
        "signatures":[{
            "alg":"S512",
            "kid":"MCDG-TS7T-UPDD-V667-OXSX-QJ5G-FQRZ",
            "signature":"AZPN7yQXHU7HGacLw1ggJW_huQ2Kx6JDuBhnraAA
  U7b-PFHBMqcLEExjp7uvP_wJRdOHx9vVZJuAvu9qpnOoH2uJpE7i-LHsonlgTSZH9
  _RqqOKXNzQvHhj81K3LecFAFige_yHZXP4aFpLDMVldLh8A"}
          ],
        "PayloadDigest":"UzMKbHTyfoSBf2pi03m-mgLhgFwb6e0qyYFYdV--
  MO5icQ_AxmcJCvoHT698416SI4qvEz749uiE1ZnNf8-AZQ"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFNLUtOT0wtM0pTQS03T0RULUlEWVItNE1JRi1UMzcyIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFEQjYtTEw2Uy1DRkdKLVdFR04tQVRRSC1CSVdQLUMy
  NzUiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDVJLVRXR1ItNUpMVy1QW
  U1ILTZQUUMtTFZNTy1NTUJWIiwKICAgICJNZXNzYWdlSWQiOiAiTkRNVy1TNTZCLU
  8zRDMtTkFLNi1TS0hGLTNLSFItVUNENyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


