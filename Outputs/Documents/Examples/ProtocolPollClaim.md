
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQK-LU3P-VJLT-ZPG7-B667-L53L-MBEN",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"wMSgIvLpoj69Rw_P_YJ7yXYvo18eCvgU3Hd8DgJ_
  07Jv0nqIkC4sZMGFGW6Ntl_3PVwk7bAj51GVrPwqzZ12sg",
        "EnvelopeId":"MBQG-HNR6-TNS7-5N2M-BN4R-ECNA-6ETO",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MBUX-YI5W-NTAH-UJN2-4FFC-4PAY-NI73",
            "signature":"fxh1PHK56aMoB9Qkbx3Kcv4UrPQkfGRCd9LwW4Un
  3EcR_EqxpWaxZjcXFqdX6d4j9lEStBR2QxKAE_GCYpaXVOLOAVTbb4pwaV9fLDo8r
  FtlKfnFFoBZMslOfqcKsJrAnc4AQsT2H5nu6xZ0dq927jYA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ1dLLTdPTjQtVk
  IyUy0zSk9YLTZRWUktRUU1Vi1RSUhNIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTAtMjVUMTU6NDk6MDhaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-10-25T15:49:08Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DV0
  stN09ONC1WQjJTLTNKT1gtNlFZSS1FRTVWLVFJSE0iLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUstTFUzUC1WSkxULVpQR
  zctQjY2Ny1MNTNMLU1CRU4iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RRWC1TQlJBLTZBQ1gtWkdHQi1JVTNMLTJUWlMtVElLWiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFETkItU05FMi1HRUw1LUdRUVMtSkJVQi1UWTMyLUpHQ0Mi
  fX0",
      {}
      ]}}
~~~~


