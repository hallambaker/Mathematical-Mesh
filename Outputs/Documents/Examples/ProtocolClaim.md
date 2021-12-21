
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NBI2-SEOW-QQIP-ROJK-DXZ5-FMRU-CB6Z",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQO-YJMT-UGHT-OVEQ-NJGE-KUMT-VBWH",
    "ServiceAuthenticate":"ADVC-IXQY-GVMF-DQR5-XCXX-QUI4-H7UP",
    "DeviceAuthenticate":"ACHO-TM4I-C2AA-EV2R-JREM-WJHY-432I"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MDNM-272X-SRO3-RI2G-CRWH-SXRT-T7ES",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkkyLVNFT1ctUV
  FJUC1ST0pLLURYWjUtRk1SVS1DQjZaIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMjFUMTM6Mjg6MzZaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CST
  ItU0VPVy1RUUlQLVJPSkstRFhaNS1GTVJVLUNCNloiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tWUpNVC1VR0hULU9WR
  VEtTkpHRS1LVU1ULVZCV0giLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RWQy1JWFFZLUdWTUYtRFFSNS1YQ1hYLVFVSTQtSDdVUCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDSE8tVE00SS1DMkFBLUVWMlItSlJFTS1XSkhZLTQzMkki
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MC6B-Q2VW-SC2M-4357-CUXC-2MY4-USPV",
            "signature":"Q3Jpz0MB0p8HQF88oQrfS4w7hvdnUEdWFsBaXohi
  mm0if8XPiDUFs_kZmIymCHWhjj591YOVva2AFfyMCh5GNkOHTILifJ11_pd4hdVn5
  1ENVTuMKuPXzMyXPDisQ4Qjp5mN_0HEEBs4WmehtEnvPhsA"}
          ],
        "PayloadDigest":"5XlnnypiWKWksAVpLj0qnHH4V59I_whujxS9gGew
  ut_qIjixK39qKvE15oEUvJ_i-oYCi0uwteI0VDlQ-ZGJAg"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "CatalogedPublication":{
      "Id":"EBQO-YJMT-UGHT-OVEQ-NJGE-KUMT-VBWH",
      "Authenticator":"EAD5-TAUM-AD6T-J7HI-HUF4-GMIQ-W7UD-TK66-JRKR
-CG4T-7KDX-JJPL-GZTG-A",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQI-V4MG-CFCW-5BSW-WFSN-JTCV-T4WE",
          "Salt":"Bztb4rMk5BU7qWTQLldpnA",
          "recipients":[{
              "kid":"EBQO-YJMT-UGHT-OVEQ-NJGE-KUMT-VBWH",
              "wmk":"Jp_keTiAJhYW3soT8veHLsR1yvhSRJa-POZq2h6R5NVY
  PxHpVibmig"}
            ]},
        "-GBpRHxkOY6iFbHsVpBHPQSLMAvqFdXDXKFdxBuQSX3U5eIxDauGTmBr
  fiZsWq62LurFMzLuYAlM8B7oszlpCUPYGS8sOrvkNG1G7Li7rnpAukXUrfWgUKrWb
  Apu_-X8h3l8K1GFihJkajFo7F7CfOVydczhrkOl_UPFYfXM5pmHGL_dU7DSb6wXaZ
  QxcVcvcQj7ZYa3pqibFjgeRo3bjJzJ0AHwjIHnIIsU6XCyTNgchVVI6KwHQd4E1em
  mOtf5lozXqeonYlnHstA4nwKg38_GWbnwNUQAl8sE2O9VWGij0G7SZs6GR4ra_MXU
  Amu2xLIvdTbpAJ_z3mLHzYnlEKRDM1LlYqzEJzGBvHA8JqAcXYrP-LjfTtEkV5SOF
  Ru0r9B1DQIpV6kHi_s8Dg2LQrhe0T8uPOzHETzxQQ2dVtka8symPM80Q9oZP3F8J8
  0mBAKIe0ahOAYCPgy1FKCFxvkq4g6W0qb7yulNycACaQNM65rH3xkaWybYT3n6ftq
  gL4yCavPlUIXIBBkgI_5VFMWqP3EPtBj_iJBgnmHfePcovKq6hpt5TauIik2HziOL
  zhIlnFlPUQg28EwuTPqy2OXrzioPazE2lVYVXWHhtLKrUn1oRW5uqJeyN0W_OFhpu
  pIilYzJSvq2d2B6gWSWqr76CXg-enSr0K1ctUWr-p4Sj5EjHFzynAswSKifrC4dMp
  LdEkogkL7Q6vYOtq51PU2iik2pH9xffY0u8tPLPL_eWlzUYevaAIqG7wnuqeDK_Wo
  PDXVyiSW4OaeARO80rQq33EuJF8gVPcOHVvVllUmhFuMaQiQ-QxwfhX7YQJO3YtJ7
  YGStyxDMzFXA8Pckn2xZ8ZmpXlkDn9uCxD_hZB5W1Nl9abrSgDks3VR4_X-x3TbEd
  5eyIJhH_LDUnP1IkaNonJpN9oiO35jAchcgDYgYCSHbUe3p-zbMASfuYY43dbkwau
  ETGb4wy4BVQ5DEmb8HebXpencMR5rBNBbeeNuqY7J-FcLNVoKxxK8uwzWpjHqzqDO
  XHVQfb2BtuAPvs-4g5nGat_0NGzWIp6Dq5Xy1TnUhB8qGRvasN6mAMjXcBCFPU4Pe
  E9Ko1ogrXYhGN5uWpMlWdR7-HqF70KACbhdOFNIx2E5PnQltWpq06THcRfG9s_IOk
  r9D-q7ZjOdS53PUMEtwx-onsqLZC1Z9gVYZyYXkZP5NZuAzT-fjr_168EOzB6pLby
  KujnfXG6MKSzVJIcmjOy5i1khDdbSPdqXlkx2sm3XsKcQeOyirreaUFhhQcHjtyg7
  r0gK_Z6YlFJ11KHQ54HaaVgxAHMZDe0GDDIIVSdv3lFkBxf-6C3ROpeD1YfTNiqfk
  aHLK-g_7j6FgPm-dbZJWLDuf_Sfr2G7GsurPc8TKW-KB5qyWlVs2TtkCY9lXW1WJl
  pK27P2Ve3Ha8aVcFU6mD4n8dO7w_b8JOBdiJ7eSdwD4AMNoYD-6q8W7JKsg-djZFg
  NW9BoDPXf43Q5NimmHs2d-hQbBovkBuBYyP5W45I4DPInGhuU0zprBEjJRt2cgRwm
  mt4v8vrY0a7-n7Yjjrg8nHqrXCyayNEt5uGxLvvkypiCWrBb8iaFBSqW6wq7hxS54
  -3-zHqM2QVU0LlNoSBKkEq27zmrFY2PRmsWLDsSVA651AJO0hZWgDRkLf-pEWBASi
  DHfM-fCNfIWlMwpxIKGjCk06ukhL1n8c3lWvq5Dgbfe2NRV3rUP04OUXGwLb5m1Hs
  RpD2o0ivM7Np4ze7adnD9Uz7K8LqlTMdeue-l0RpZCD1t8B41Q32TCYjeNjUKXCrK
  pBduDI1gPj9MSItMGLDjsUWLr-MKjO-vnGJTPSMJHh71Apwe3aE1cc9_3CPWB1gB_
  sObnqLb9uNHoZIz3DRbJDfvXbPPBVA0qq3TFE_IcoDPEkRNb6NLxZ36rnpUfSLn-W
  B9-kcSQfl8tWtFaew1B-305H2znI3AlCJdKIGutDQ5Y_LE_DSWhU71xbhieDQysgn
  b8NwOjGthxAhOA6X-si8smuEZFH7YL2wYAM5aMpyRCxfzBb0JH-YwgQRwCLESXHee
  yR8eFVCdHOHoDm9D1otBGM2eELuYEF7ehbHOTlfGULrq-m99NL-0lJD3MYd8EHGA1
  xuQXjFM5EXYFJdHYnN1upMehEaroXzN5E7dXT2fxllzVubuPB8aJPD487fQgFzDFf
  qkDmki_PbQgA6jCRC7iqkWwgQjamUt9AnJtdrsCUysVBz91AAof3Z1ESFD49cFqKH
  iNZC_3clVJ3Nee3s_ewbOI_InsETZ2hIDnFi4sO0ep9C3dCgyRQPx_CPVYLyARyBI
  7zkUd2-2Mdt1kaI7QzTzhILDOsAM6V8tCeZVCrXEjctXJ4Nsi1G0F4H01LtoQf5ZJ
  hRK-AJUly10q65Y5pqty9vsn9dS5EC081mDUepmzEZV0xbJEdjOJ0PWU-NFbR5GC5
  8pZE0dwGJQCHCUjxjM76HNnkxMzIdmShcGLmTeIo4-fBWdjMoSnYLQxQEYh6oW_M5
  RGPNQUPE13sN1drIoXQIgmpGuFZoA5vNbudTYJlod93GFkMWJYQmLmqGmoQrHRK5O
  aPVVfumwK5kTEdMDHhpKBY-U1qpXpaKE61c-3QJjo2khlKxNfPPUK10Dv9UEDw5lT
  IpGZDAoW7zaVpF9ff7_mT5SFNoSMbIa7Z-EPHvevesuaLdehi2zlrb0krUMCQNWYB
  CXYNQdJhHuyFnbowpo0qSNyj6c783TVAoQm-8MXrepjX0CTJfggmFhrNpZine2PAp
  fgHrjWSPYQxM_Bpu3Oo6XfRsWObRz3lp6D7kudBQ8h9J9wTDsoo8F2qM44G_dxt1C
  ambHI5gUmzr8Qseaei-09xw9K5AatuGNGJIuznWzKAO3P0qg-5yk8bXIaLIjye0uz
  5f-nu9DBUA9M9ez81-aRtQaveqGmQMCXJVrL9rTStEdmr7jI0SB0OnbPsDaLXXGxT
  ILFqwptaR2aKFzf7ncfIuApb8ND5wYNOVQiqm3ppMgudGUAdg"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

