
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-PH7Q-NLQQ-6YXC-FVCU-WOWD-6KN2",
    "Salt":"0TkX46QoauYRoV70dzzA9Q",
    "Annotations":["iAEBiCDXGeA7BZHZD2Zkppaj-140TrB4uQ8nnPV6YOqSetPL
  zQ",
      "iAECiCCnt0bMS66m1QFxN55NmXroSLV_jr2eUMmfyd9GXUOS6w",
      "iAEDiDAwfJAIYouiWKP2AmoCH1_ZNIrRDh8vJcflI4kYyePIHEJgBqkE5YCj
  9R58UF7X37s"
      ],
    "recipients":[{
        "kid":"MDVZ-T4HO-L2WL-H6YA-UXJV-BOVD-Y7TJ",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"6cGZoaWhmxEzLFstYn1ZlALiB7hNJo_946CQoafZuf4"}},
        "wmk":"vV906eQTy9ZHyJazKHa9uJySm4pNzZ21JRTdrna89wO2inVXo8OA
  aQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS1t
  YWlsIn0"},
  "HAp7NtByFwW-ZdGg1qJzpKEPbpJB_aRhTkxqhFyAD4xrmZfpKj1C7KhN3art1TyU
  e4ZWrAucrSjtMJUiodgBRA"
  ]
~~~~

