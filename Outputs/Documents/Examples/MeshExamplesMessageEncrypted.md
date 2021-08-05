
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQB-MC5P-GVBA-OIKJ-M4DN-LKSF-D23C",
    "Salt":"SiukGTw3XgbQQnAtsVc5eQ",
    "annotations":["iAEAiCCrEcD5_2UZXbzWdtq5nUxPtL_6wnAIZaxf1O4txy
  L8uA",
      "iAEBiCDQ0IWOvr1HActxmRYTFUrYPGD3tI6PRajjaIbOaMcRCQ",
      "iAECiDBfKgYNBS7SqLGfdmMnTv8lQpUTVsKyZ2e8XfRx9WQHGTVwDeaxLM
  A4KD28YSDH5yQ"
      ],
    "recipients":[{
        "kid":"MC26-ABWY-V347-CYLP-BL4I-OJK2-USAM",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"RGBacVLPZS881Ml2RMGAlUQ5iKX-C8X-7FDfrQTYL58"}},
        "wmk":"TPCQcAVUrCV52l5broEflJRFEAS0whjQzjP4W5tugrpctqA1jU
  JxcQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "zD9fqMmZr2VzlRWl6sLakYbrUH6ELfcVlw3pMb-uVcCl6DI7tQuQ8D0vNMd4D3
  vGfStUpdz_UPRB2BCKe5WxWA"
  ]
~~~~

