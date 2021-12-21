
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQC-JJZB-NVUT-HJBY-F4Q3-WQHI-4PMQ",
    "Salt":"og1PptDeRSgIBtn0FmLyAA",
    "annotations":["iAEAiCAeE23r_3ZivBuejoYKpp-un1tCMEtv86k3UBHZwv
  yHDA",
      "iAEBiCAUgxilH9kBGDvykShlkTc63zu9uA9bzRqKFGs1YKTW-A",
      "iAECiDDGGGI3ueNqecudwlxWx8Iqom6xxknVYQEJhIgv5YDaL99CTleStO
  phjEu6Uoe-8pg"
      ],
    "recipients":[{
        "kid":"MADB-RMVX-3SOZ-5DEP-IUUZ-UET7-W6NL",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"adGiJs2JoB9ib-o6LT_jeXy4PlstkUqfcqGBhRsypDU"}},
        "wmk":"ByV7Ues4sV4b76o_xrTeym8Oojieyr0q5KXZu5is8eEte3eXVQ
  L0sQ"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "Wai6lHPCuu72338J3HxcML97YWkOzyi994AxQAApf41_Q0kRwCPmqKU9x-noTO
  WlDO-00L75C96aPXf5XRDE5g"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

