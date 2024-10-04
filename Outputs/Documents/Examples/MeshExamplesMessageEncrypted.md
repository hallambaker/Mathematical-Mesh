
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQJ-IMKL-5AMQ-TELS-RET6-G3YY-37OF",
    "Salt":"TjsNh27nD1KFULQ-stjsbA",
    "annotations":["iAEAiCCwsoXU7hiLj8R5q-VRiQFWgguI6VW2yZSRO6SW3o
  EuuQ",
      "iAEBiCBwSs1uh_mOVm6w98JC2AGCPrp0CTatBP9b6GF4uAT4Ng",
      "iAECiDA5QxNl32AkfBez3nhetlGUKIW10dfI9OuTezjb03TZtFD8IZb2by
  I7MVdiId7IWwc"
      ],
    "recipients":[{
        "kid":"MBSN-WL7P-L35O-O4DY-EMAO-LGUS-B6QW",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"dXuxNNVGe81qWvJVJ7CXDPAYGHX-pWHTL5UW_iwbhNo"}},
        "wmk":"1eDDPI2zMzXpmgZGeSGJOTyOShl7PGW1LUpXlErPULNBp0ugux
  Ldtw"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "ausPd9Ur1OCYEbDv9-STxhI-IFuIQ2BKE3SHF6zrZrcmViyGsmSJsvaTtgJUYl
  HUXAttAfzKlbfAj7IRHftPGQ"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

