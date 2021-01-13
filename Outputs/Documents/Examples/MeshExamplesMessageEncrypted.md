
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQH-3NAT-FW7Z-IRDK-QC3M-SC2B-UI77",
    "Salt":"-7YjIinh89vumJlW5P2GMg",
    "annotations":["iAEAiCC8xyPT3IaxCUiUUDdUKfJ4FojwKinCRX9DIQ5UXd
  14vQ",
      "iAEBiCCwXnWWrKxt6ijdvmVm8QkKBWwWu3zcjOsQ2HiYNI5qFg",
      "iAECiDCPK9HdJbLx0DRO4mWcUc36Q5vPpfjK0kchlTnJOAaAJ6BBM1RJw_
  hzAaekH0FeD64"
      ],
    "recipients":[{
        "kid":"MCZG-SJCC-WPAU-MNRF-6TCG-KUUQ-ICAQ",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"9vIwyosnE76w1gtCYqY0nKu5MrIf3jPeiPFE_6T3-ks"}},
        "wmk":"QZwtHQUzXS6qlipGvjQhz_0GjHNFV27sAUP_nPf5vxTBJbtxUb
  El-Q"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "DvWZ9em6q2rIrWAAUcaS-W7DN1dbEVeyO9L5iqC-1okIbwm2V4pP8prKH1Acy7
  IJrWKK8d8Smxm5ep9XiIrjuw"
  ]
~~~~

