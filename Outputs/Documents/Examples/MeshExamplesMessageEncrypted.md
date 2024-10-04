
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQL-GUH6-4WWR-SGL4-QZKC-IS4K-27MT",
    "Salt":"OGz462wyFIq4RIpk5whMfA",
    "annotations":["iAEAiCAx2EA0Vr3QedQNr57PLjN_pqbF8ZUQQL_9PXSjPj
  cV1Q",
      "iAEBiCCSRmAxL6NQmUrKzRGHJ5bZPkRkoYrRn-ZUWDGANKQ1-w",
      "iAECiDBOo_mgUUHmvID9PxfoCLbBBTdL4pn5-6IU2LJVQrV0tTBt_-AufI
  YsXoZL414Oo7g"
      ],
    "recipients":[{
        "kid":"MDTM-GPIA-P4O6-EKFJ-EYN6-ZDER-CYHK",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"RBcglt2oMEGq3Z9ZDJGRCsgEf5ERp29qbcHJfIrQlLQ"}},
        "wmk":"5i2aAgXxQvkeysxaJxadfM1QTxG9FhL8AYCt3Yr7a2Ndd2vBLW
  gDlg"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "dC7uZcLkFjPf8VjJpjbzuw6DppTUNVg0I0iaUe33iQeVfVt1DLnSlvKfclAfLw
  p8FVanCtGbyH4HbtMWFpuzZw"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

