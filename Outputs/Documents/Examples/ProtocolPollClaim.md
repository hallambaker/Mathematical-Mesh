
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQJ-VQU2-NBCP-XCDF-PFWE-J5H4-BR26",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "EnvelopedMessage":[{
        "EnvelopeId":"MDNB-MBUA-NUS2-B7D3-6FIZ-OAPG-D4L5",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjRQLVhRRFItSl
  ZPNC1NRDZSLTQ3QlotRzZFRC1KNTQzIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMTRUMTM6MTA6NThaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2024-10-14T13:10:58Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MDNT-WT3G-346G-4I5T-YV7F-LTQX-PSNT",
            "signature":"z03VvboD_IvshEuYEuRalFRGERvq1vHOJIWJzPNU
  gwLURsGLxxtfjE_1JtNWYe8kndOhVJo9_46A_Vx2DiAZ4ngzzYXoSpqAFgz7Ejqd5
  s1B7K1ehk5ToIK0oYOGoQ--npioQHEccyfUrQalwe76zx4A"}
          ],
        "PayloadDigest":"aobSWyLEGCMF0JbRdOst2LQPvpXI3ZVd45r3sjaV
  uO0FwMNtiiCGmjArENV3rVarWEAwLGBVYhVnpqw-S43pXw",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFKLVZRVTItTkJDUC1YQ0RGLVBGV0UtSjVINC1CUjI2IiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFBRjMtMjRCRy1VNzVZLTNHVDMtSzZORy1LWFdFLVFD
  V0EiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDdBLTRLU1ctMzdRWi1KR
  1Q3LVNLR1YtS1pIMi0zNkMzIiwKICAgICJNZXNzYWdlSWQiOiAiTkI0UC1YUURSLU
  pWTzQtTUQ2Ui00N0JaLUc2RUQtSjU0MyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


