
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQP-KM4Q-N32E-JM5V-DF4Y-EPZ3-PPDA",
    "Salt":"1D0GBsw_YuKSA8t7ScnsLw",
    "Annotations":["iAEBiCBMuc8j9gaxmEgKqHwmxOLwRXtvc_NIl9TnCl1THa1y
  dA",
      "iAECiCCmaGajbkqu-MnAxtca7ktmFcDgWSF64ezieKCc8P947g",
      "iAEDiDBOZKsqsyk-KYrcT3ll-Odxcj6kbtVSnx3sLC2EEnPFdjZNv6Pf1-eQ
  S1ST1W4mcDk"
      ],
    "recipients":[{
        "kid":"MAZQ-4ASQ-M4GB-2AH6-JYBJ-G7ME-3GP3",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"m-3HyC2NCd5ik788zg8YxHHPQvtKM0kx3R-bOEJHInw"}},
        "wmk":"7r4CXNsg8hgwU9vNv3XmbIn9dzgdDsMN83WPuwv7xqVygBKyvZrX
  Xg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS1t
  YWlsIn0"},
  "TRmSam6XnPWRgos9zu3Gs_PPn40zwqVAUx4JcXIEMeSopahOxCRPsAw4YFDNJtNs
  iPOmY81DRW9rgRV-uSRSFg"
  ]
~~~~

