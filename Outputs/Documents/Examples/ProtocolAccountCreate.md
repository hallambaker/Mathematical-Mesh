
The request payload:


~~~~
{
  "HelloRequest":{}}
~~~~


The response payload:


~~~~
{
  "MeshHelloResponse":{
    "Status":201,
    "Version":{
      "Major":3,
      "Minor":0,
      "Encodings":[{
          "ID":["application/json"
            ]}
        ]},
    "EnvelopedProfileService":[{
        "EnvelopeId":"MA36-TUJL-QRZJ-3M3L-SRBQ-BRYQ-W2YM",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQTM2LVRVSkwtUV
  JaSi0zTTNMLVNSQlEtQlJZUS1XMllNIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0wMS0xM1QxNjozODoxN1oifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1BMzYtVFVKTC1RUlpKLTNNM0wtU1JCUS1CUll
  RLVcyWU0iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJHWnNNaWlOclNMc3ZpbjU5SUZvTWhqcHJYYTRxNUFTTVZZUk
  FNVGdlUUZTM05lUWxDU1hkCiAgZmZzbzJNaHM5RDc2ZDJFX1lSWWFtZllBIn19fSw
  KICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNRE5PLVFF
  VzMtTzVHTy1JNUlaLVNXTEstUENaMy1WQ1QzIiwKICAgICAgIlB1YmxpY1BhcmFtZ
  XRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3
  J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICIwY2szb0lGWjZ0eEUzajJ
  HRUxXZzhaQ1BxaFRHaWtRUWZqeFUxUHhGbVZBczRmLVd6MW05CiAgMkg2alFxWmJq
  ZmVKLUVickpETzJOTVFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MA36-TUJL-QRZJ-3M3L-SRBQ-BRYQ-W2YM",
            "signature":"MeeZPEkxMpnwnFIcqeau_cw3m82x8n-fT5Gbp0ka
  U53PTSHIlXrnbJozvpM9kIFK5dr_xFvAcQsAoH0KS9NciI2CHvMYuZgmOX7Yj8GRu
  bBFpWQABlssgVp5WDTJBBKNHny9ahysun5far-CSdh6MBEA"}
          ],
        "PayloadDigest":"7rouYSGk4aJyF1lFml3TtsjIe_4VLmbAzgm1STiM
  5-8z0gBV-R1n8-qXNUolXqQWo05cc8hBXuZdfz6KfZdmwA"}
      ],
    "EnvelopedProfileHost":[{
        "EnvelopeId":"MAFN-RXIO-YV7S-ZIU2-WXLO-S3ZO-DUU6",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQUZOLVJYSU8tWV
  Y3Uy1aSVUyLVdYTE8tUzNaTy1EVVU2IiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZUhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0wMS0xM1QxNjozODoxN1oifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1BRk4tUlhJTy1ZVjdTLVpJVTItV1hMTy1TM1pPLUR
  VVTYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJjRWhGR2FLd3BlY1FIN0lGemhlWE1TOUVrT3p2dTY5SWNxeWNjcm
  Q3RkRMdG9tdkU2S044CiAgVXJhUDczblJ4TDhMOGEwdjdFOFlBQTRBIn19fSwKICA
  gICJLZXlBdXRoZW50aWNhdGlvbiI6IHsKICAgICAgIlVkZiI6ICJNQ0ROLVMzVU8t
  NjVYNy1MN1k3LVMzREUtN09MNy1PRk5JIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlc
  nMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2Ij
  ogIlg0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJEY2FVNlNPbVFfR21IQ2hldjZ
  JNnNxOFQyOVRuTWctcV84a0NibGFMeVc3bGNFdEJ6NWFTCiAgZ2p2RDFNVm04MElz
  V0JmRk5MTER2NFFBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAFN-RXIO-YV7S-ZIU2-WXLO-S3ZO-DUU6",
            "signature":"BuUFO7hpykuHiwuM0i1P4aCMIHBHmubtKdskHfbR
  NrHGV0Va3Lcljyp5XaXp1KDhrygv8l9XcJiAL2Vy2xTHghzfu29XLc4p59RxhlxP6
  nlWP0Lw0pUER9v9v9BEss1ULDJYw7yc-mEf0h5sygAnTx8A"}
          ],
        "PayloadDigest":"bOkDrRdW4SGwdJ0_YaJoeS1JhczC7o-ftjVWr3sC
  yLo7-dHhyB-cKe3Fksrg31v_p2R4q6IhUwYOwFrgFEF1nA"}
      ]}}
~~~~


