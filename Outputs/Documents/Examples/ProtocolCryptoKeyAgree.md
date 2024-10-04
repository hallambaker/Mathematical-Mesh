
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQC-T7YG-I2YP-55WG-2NZ7-ASVV-OXOP",
            "Salt":"1Rc-q4YmDDaM29_zsrr_4w",
            "recipients":[{
                "kid":"MB4Z-2RLE-QYAO-RHKL-R3L4-OW7W-YFUW",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"nDqI6YMI6_8hNA8u1LjJMTdDlZ3re1pIjaq
  CdqDafqeJZ0hgdzP9pmKxf7uTiJUut98XMAHg5AqA"}},
                "wmk":"seXybccN84Tf2l1dDGjn9I8b3b9tFCRHkJFsOIBNMT
  HshULz9hCMrA"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjQtMTAtMDRUMTM6MTM6MTNaIn0"},
          "UmSbTfXcMMfRhhtzLdjdmhYGVJw92rzUXZCRf1fGEXynhKnYJYI8nq
  yYSssxTxxBVqFC3DXYSEJGShEuvh39iJMF93se27IJZy80549PI2feD1xoqiSi_Kz
  WNl8_MWeuIMSwuSjumAOHkriPGqcIyveqDCdXpi53cbcKarELysxU4WXZvdboYNdc
  fNR5dqH9khyz3yvhF2qdzK2364NomoAKWcMvHwjyZv1OTmxBSy1FJ0h7tUX830VDx
  cPKEAR2OzF8JEtchKe4RcrLrBhy7pMP41XNlqZEdTdK9eepe4D-tE1-N6Z_000hx6
  U7ynZ6BYPK39ZjcdLedmaAyusCwzJ8KRMTE4rWWDJ93orf8hYZPprCyHv6ROSlht5
  q2Gkj1L6-ShB_QYwpIG2QcjAfwMk-ExtXKkKC-1qxkNk4_kw_Roq0CGmNwdg3NMfo
  TlnpJTii04C_Vps6mHcrx5MJAB9UL8DGwc1IQpoh1Yk0-r6WJNgPqxgt6tKDg58D2
  UFO3UtBkQ10Y-fQR8urYiqsekgjIWo4-ofpZvLm_trfqMm2gHG_FTqz1LFAIR_29l
  FYq0ZD4fMxHQoaJtVET7KWPumxwq7UWyAq3BUfqjJ-QvruQQ7dbN4V-tm9WTYKlMD
  h9xldTIuzOL2A5hhTQEa92HNg7P4kfJ8sbBINDXdNIAy2wARfMw0YPfbZuPBMno8v
  YE-je59rTUtnoS3Dl1RsDw"
          ],
        "Id":"MBUJ-WCVX-67TB-XHGP-PV7Q-65ZN-SKIA",
        "Active":true}}}}
~~~~

The private key (in this case a key share) is encrypted under the service key.

To make use of the access entry, a request is made that specifies the key share
to be operated on and the public key parameters to perform the agreement with.

The request payload:


~~~~
{
  "OperateRequest":{
    "AccountAddress":"groupw@example.com",
    "Operations":[{
        "CryptographicOperationKeyAgreement":{
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"RoO2dRxx4xkiqD3iXjt7ajQkvoFgN0R9p8Ku_Rtbe
  ZrWj93m7SMr8bZoPnc-GrnScnZrFJRRqMmA"}},
          "KeyId":"MBUJ-WCVX-67TB-XHGP-PV7Q-65ZN-SKIA"}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"_tCRwqpLTU9o_cDnzW4KKbe43VzSARFBgGBlLKXZP
  _r-C-em0zGOtF46x9diMAWWhr6Kj8Qdrs8A"}}}}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~

