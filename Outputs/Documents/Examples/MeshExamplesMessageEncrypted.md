
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQD-EETE-UQKO-Q3X5-C2HO-CV2V-VVLQ",
    "Salt":"9Xin72G_L-8niqzXPvBRxw",
    "annotations":["iAEAiCBvtcwdxKvB5SmO2ki-vienJnc5w5tMey-RteTRIp
  ih_A",
      "iAEBiCDgQ9a2R784gmgZ1wgg4l1hNCX57Vf9o30gUzIbt4pJnw",
      "iAECiDCmSsz0FPVhar_JIuFe_Gcme888eIkD8a1SfA7OTRTbSFCa-m1HyI
  KD8yjcOymZEK4"
      ],
    "recipients":[{
        "kid":"MBPQ-HJXB-LUTS-HZEC-NPCR-Q5FG-HQ37",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"mgRuWI34u7mg20jwse0aVWMUuF99YqAANA7m2EwHocI"}},
        "wmk":"pkAqkQlCllpIHL9Z88uYvRe52Qu-87QA3MGAA77vu060Hh4LoY
  KIRw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "YkH-osPK2Kmb-CPlj3MNSiifnycI35RgRDIrveVW5HHmvDpjZCMfBSisYliZgu
  5nOkDLfOfVl5CJoZTGpEyg1w"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

