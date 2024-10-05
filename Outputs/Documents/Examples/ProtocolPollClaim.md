
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQF-CQHK-FZHO-KK55-J42P-G62V-M32S",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "EnvelopedMessage":[{
        "EnvelopeId":"MD4I-HRXJ-JRHX-FGT5-2CC6-LFE4-FEVI",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUxSLUJOVFgtR1
  ZFTS1NQUdZLUJVWjMtT0tPUi1TWEZTIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDVUMDA6NDk6MTNaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2024-10-05T00:49:13Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MBN3-5FRI-PP6T-TUDK-EQVQ-6YG2-QQKP",
            "signature":"jEC0FWNvb6z_b9f8RKyS39efgch6dtogC4NgwD3F
  _stRSQhhqkjyMX-DHRIq_G-aft6fe2k1NQuAUkSsvcsa_cgWS3s9aBnWK-V9QPIAp
  -nZww-d7PdxRdDqPMo6fiQTQtAwPYc9YLVqPR92Mv4kNDIA"}
          ],
        "PayloadDigest":"MkcNFOTkKS2jGGhNMZM06Sc428NVzpkxZWhBfVGd
  5RfX3wFWQjTg7dfliz4Wo5QD3leiHwpcx2Dc8GFQYwyx3g",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFGLUNRSEstRlpITy1LSzU1LUo0MlAtRzYyVi1NMzJTIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFESU8tVzdSWi01SUZELVdUSU8tMkpTWC1JTVlGLVhO
  RFIiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRFQ1LUdYNEEtWVk3Sy1IT
  0NMLTc2R1otU1BQUi00TkFMIiwKICAgICJNZXNzYWdlSWQiOiAiTkFMUi1CTlRYLU
  dWRU0tTUFHWS1CVVozLU9LT1ItU1hGUyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


