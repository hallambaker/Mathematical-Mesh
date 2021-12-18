
The following is an encrypted version of the message shown earlier. 
The payload and annotations have both increased in size as a result
of the block cipher padding. The header now
includes Recipients and Salt fields to enable the content to be decoded.

~~~~
[{
    "enc":"A256CBC",
    "kid":"EBQI-A5AY-C4N4-4QGM-3GNU-6IPS-PVFS",
    "Salt":"oRtDigGrhjceAsKUls6mOw",
    "annotations":["iAEAiCBwW_cBBBK6DVXxN2xzx42sqz7EH06YkM9KIjERdV
  Lwww",
      "iAEBiCB8aQLGz-C5r4M9Pq2Dru_jhatXbdOIdnqovoGXVKei3w",
      "iAECiDD2ComVIYm4t0lZxneEqAESS5YCCh2YZRnjfgAz8YlFcsOi-y68mG
  VVPOu7jBGxJ0g"
      ],
    "recipients":[{
        "kid":"MA56-GZFJ-N6CJ-DZTT-4SG6-TEAH-DYVS",
        "epk":{
          "PublicKeyECDH":{
            "crv":"Ed25519",
            "Public":"PKv5erLVWDnPllwdR-oQt9hyZgLWiksl6mD6D88d_EE"}},
        "wmk":"HXex2xmI9ZZqGjq3QfSManJ-sRbJm-llQGn1OAyeyMtQMJfTjp
  BMHA"}
      ],
    "ContentMetaData":"ewogICJjdHkiOiAiYXBwbGljYXRpb24vZXhhbXBsZS
  1tYWlsIn0"},
  "wVmuXVygfKgyuC3kOcBmEMse0wdj5WshLv1PxmoAzoG8EgxRaB91x8Zgc_nCV6
  E7nBdcuFZ6FAvnfY1w16JA8A"
  ]
~~~~

For efficiency of processing, the ContentMetaData is presented in plaintext.
This header could be encrypted as an EDS sequence and presented as a 
cloaked header.

