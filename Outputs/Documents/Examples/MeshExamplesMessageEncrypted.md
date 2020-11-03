
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-JL2F-WWAH-TB5I-JHQV-33K4-UXTC",
    "Salt":"GdANLjz0STqBV_VrLXSt4w",
    "Annotations":["iAEBiCCMPw-7wD7zbiJ7ibyFTzOCC31vMiLs3IwdZqlBqT
  E6YQ",
      "iAECiCBX9ZNBei3mlep4NLm8BOqKMUCmOHgQWucOHuR_Q_ELIA",
      "iAEDiDC_ltEcAMJS_HV76Acq7PpNY9BSxt-Our-8THB_LlwT9LDuLiaTEv
  zpMIdG-XPxpqY"
      ],
    "recipients":[{
        "kid":"MCUG-LA4F-7LOS-Z2JR-MNMJ-BEL5-654X",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"wmbGWU9mVQtV7tiJQx795KsW0nxkBCphux1HMepjOG4"}},
        "wmk":"qOytoINlqv0ceaDUNShRUqjPE4AFvTaK2sithsrU1tVUpFoKal
  2Tiw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "rj2yWkGTe8l6p4AiDPEKSas8IzvLltbQIrWbqykbdHvTtpQKz0QTbDEOLVvnVS
  ScQnYIsT_W55pcJORZzOQC4Q"
  ]
~~~~

