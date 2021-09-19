
The device in the example above periodically polls the service to which the device 
description is published to find if a claim has been registered.

The PollClaimRequest contains the account to which the document is published
and the publication ID:


~~~~
{
  "PollClaimRequest":{
    "PublicationId":"EBQO-M24T-BAUQ-OGX4-ZEOK-5PEY-NZC2",
    "TargetAccountAddress":"maker@example.com"}}
~~~~


The response returns the latest claim made as signed message:


~~~~
{
  "PollClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedMessage":[{
        "PayloadDigest":"e_MxJmGQd_4Ydveam7zGLQ5geGfk5eus9zD1015K
  enHedjSSRnBscECdb6l-bV1wv-NWhlLBpQk5GzUMxH1-AQ",
        "EnvelopeId":"MAVZ-OFCO-C3O2-A3QK-X3HX-EM5S-TZEJ",
        "dig":"S512",
        "signatures":[{
            "alg":"S512",
            "kid":"MCII-KQPJ-WB3H-OYUC-RHF6-5E6W-OHGU",
            "signature":"AMOwg6oAsKO64dr_Kpzb1VJ6QkXjj18_cNZvtDB2
  EOnnDRKgRbzkU0zEx5e6x7kOqNkkFcnGYQMAveNoWTPVOQ3_0D_jPhmIplR6GvHwq
  NwyWikvJkWtlqhoWp9Nyi3lF6EFPab6f3NoOgdno4oS2BAA"}
          ],
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkVRLUQ1STQtMk
  JNUS1QRUFULUFQR0EtN1JUVS1QNjMyIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTlUMTc6NTI6NDhaIn0",
        "SequenceInfo":{
          "Index":1,
          "TreePosition":0},
        "Received":"2021-09-19T17:52:48Z"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CRV
  EtRDVJNC0yQk1RLVBFQVQtQVBHQS03UlRVLVA2MzIiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tTTI0VC1CQVVRLU9HW
  DQtWkVPSy01UEVZLU5aQzIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RKSy1MTE1WLTVKVkotR0JOVS02NEQ2LVMzU0wtWEhBQSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFBUE0tUEk1SC1ST0FJLUREQVItN0NEUi1aVkpYLUdMNlMi
  fX0",
      {}
      ]}}
~~~~


