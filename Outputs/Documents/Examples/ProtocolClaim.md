>>>> Unfinished ProtocolClaim




A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NC3H-ICAW-FCYY-6YVV-DGHC-ONKY-WBBS",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQP-LJ5U-LV2Z-2A3U-MUCB-5LEI-NVFP",
    "ServiceAuthenticate":"ACUB-IIU2-I3QD-BKIS-7MN6-YHZR-E67H",
    "DeviceAuthenticate":"ABBJ-5ATD-SE4Y-FUNF-63WG-YSHT-67C5"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MDFR-JFNN-B7YT-MFYF-FTVW-6M4H-ZRHF",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQzNILUlDQVctRk
  NZWS02WVZWLURHSEMtT05LWS1XQkJTIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTdUMTM6MDg6NTJaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DM0
  gtSUNBVy1GQ1lZLTZZVlYtREdIQy1PTktZLVdCQlMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUVAtTEo1VS1MVjJaLTJBM
  1UtTVVDQi01TEVJLU5WRlAiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  NVQi1JSVUyLUkzUUQtQktJUy03TU42LVlIWlItRTY3SCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCQkotNUFURC1TRTRZLUZVTkYtNjNXRy1ZU0hULTY3QzUi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAWM-77KH-5JB5-ZKBD-BKZX-BM37-SFMF",
            "signature":"UOqQ5vh4UnGG4sO52wSMTa70IRubasfnVZxl61_s
  EjIhgSD0Xy0X4P-uV7_k8pKW5sX4b6PbzokAjOP7aNCuDSCOEBbp7NtNcamb_WywH
  5mb42fcPCeP1CkL3WGLze68m7wRZndjuUd1qeRJy_9nfQAA"}
          ],
        "PayloadDigest":"-7CrSm3HJm7c3S2vwhI3kYcnBqvq1h7MU38xj7pH
  1rtWmkP4qcvxqsXy7BRhMo0ww6bw08WNU83vDu3oWXK6Ww"}
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
      "Id":"EBQP-LJ5U-LV2Z-2A3U-MUCB-5LEI-NVFP",
      "Authenticator":"EDM7-RIF2-CJNO-QQIJ-LGHZ-HFO4-HB2X-ZRB3-XVUH
-5K2D-52JH-B454-P5T2-2",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQF-YGPQ-B5PT-L6HZ-5GID-5X5H-KZKC",
          "Salt":"gVoapLEXPLgeA7yAvi3p9w",
          "recipients":[{
              "kid":"EBQP-LJ5U-LV2Z-2A3U-MUCB-5LEI-NVFP",
              "wmk":"xCdeF6gwY5h0ZpaIxBwX6C7tOD66HiK9c_IjolqbjLWM
  pd6rzcaRZg"}
            ]},
        "5aku6MruwJc9r0fkl4Osd1BzQIJEuzwPLtBiCnDSiHtEIX11jkVR4VDg
  jIZ8YzQWEug1WrZUPNsoibboyTelwpMueOJ0lFu0ngzH-SLrj4ar5Aksa6u9xU0qG
  IXcSFF8VRTGiqbYvaWKOybMpKNJMmhLAOzg4Lx3jBg3MV2mBkSvFJvpwFX92ls-YD
  C4EWbgCPAJNSU18T-xjWKhPzIM7KJbOc2PTETbE3Xk2pTABxXIWQu-1xGBiaND3sk
  B2LxH_Oj_gdgydUl7GgfchTIqdxgiB_ljb5rIknDR7-XMFiHZwfmwC1dvQfn2r3qp
  Wv3d4f9O73zuamYgH4W0sJupbcP0oaijPrsooAaf65n6xepBANTjUnX-eus-vr3ca
  PXyEb6_fAbzMZxtNnjPz_KKbJXLmgj_v2dNoZukzOXXwljbC7twai7gkFgA6qhrZ6
  _-ifP9LITmHWAZ_aFND5y7PBbmpwPMgpviPJRRPmaGNIGtcy7BKxGkn8vCZBnhEki
  GxZ3YVWxj-TG9oGC9I3kRm9jwpckDkx9JGMBXBVWXXX_sEMZiPeSA_Aptzuc59vqD
  oUsYrBb133Hw5Yo5hwv9spGBupwCGftNfMS10RTqYr_Gq2Ow8fCiHxXR-x4rj9RSf
  accsEMchwMaIaCMtAYhpO_tN7reLl1XfDVI_Hz99sz4yMO5uvHno4V6qjONKdT6fo
  -fs-9IYeG8UGaj6iTm67xOqOPrq0fZm4KuHY49SPFmrnfrm_RMpB4IJvTSaMEWLjD
  BJCEiAL_zxp0P2WoayQMneuFAUsG2XQh3uxJ6E-J7v_piUjLq9-dbj36QnaHCzB7J
  iAKRJnF30gSMw0k1Co8UGTsERFNPV1-BBYOc58HR6Zl9XJ1gvB6MOotDMHtg8A8VK
  htj2X30Kl3InpW7wb5zo564y9WNrW9fUuGpBkuwmO-QHPp8xW_8BQ_5bVn3T6hXBr
  kwzYbZ81cW7vycAOwzmionYaelBSn4zs0_I10-tZsAfCAB6ML_51iq_-UHBEnfXvX
  KyL3agKo1b5bRa5EO6QaP8zNQSwIzyTCca7qE-8Ch7QoLqtG5aSsRYqqNk0VZtxfl
  IA3sXREPjEvh0XbXUYu0KNGmMm1EGIrxtmDKoOjUKZRU6ZaaZMSFfcI0gkrmJldrY
  XeD1BZIUaLiirfVRjJU6W1M5StxTjuhsGM9X8RcakU6j3uM5ScbJ2fkagH08HbpUA
  AcwF13fZ-uzab3Lj1WtBqeZsy4nsVH6KX9FITbdvBTKcZqVaBIcKv4rDtOrf-RNpn
  EL0MhYL2ZOXlboioVaDpHDYyQRQR8USe38p6-oxxHZhU1hwu3yTGAW_wwptZLge34
  J4A5UWI9X5rkHWqPeflywvGQuGyUBx7dJc-ujKh_B1OZ1EssRXRY6tZC4AnwqtNHm
  Ln2fqACvXIsH_IiER7phQ0lI8raLgrBfinb1NlB9frfAgy4ZPFdoGWeFsXHe27abO
  GFFHlBxSTDxhwDKPeA22bcjZsin_BlZ6SkEW6OYPKglbtt41AsxQ4-QB_YSddnaLJ
  UWdRrD6eNMMmppjN4mj-dg3j7SLmHWHyCR62p7LqZhnXCU63tSqqQeJmujfY_zmpB
  fj9wh7jU9CQZgk7BH8ZeUEKcJdWjc1cGDHw8Ho6LZ89IqVbMA8iuaktnd0o8fJ9aY
  RZ5uRTLn6DV0U1JHbua_FyUmyiC1RmbI8tFzNVWGQY1jI2coefz3ETg9BkPBqEG8c
  eAFDc8skHs-QtPQzyxq_LerfPMxom6NEuEVHOLgZy7ibq8a-LxI6n8NgGIqRRJynP
  KKjaBwd78nmkywutJlPfkNkVLywEjwcd7NK3EdbI_vt4UgXqsAmb4Yy41NAL3yyrm
  -aFYqQbaOXlP3pVc8zwsff9Wdu8m3CxVFALwPAjJCXsOy4PT0MZ2VJ_cLrPfTmeCU
  typmO6-J5eRsruUcHgwpmcETz0kdixx_kZLhgVZfS4wsnwddp4_cMqv-6HsT49V9Q
  P-ulSvzkPVRrTeVLKUX4HgQIKVuaUIkmIqe9z4iY31CmasD9uOgRi7SJyRf8NZprn
  pKGAITGb9Wazuwe5yj7uSEQ1e2UvIunvZOjHUiOhMbwY9n62WprevuUhcmXhtk3_K
  xwAVXRPWHxyjrhf1UhTfeGiMTZvhW0YaqT1TsEm0tuF9SoqiUsPv72iJ_JStprrn9
  D1dkHIDdRjtzzRgK6oLirbiCxMY02-aDAA4-aaAExkWoMw59H-7eo6pwdblCPHcJ5
  -rmDvTKHr1jiAjSYS4F7FAKMmILYMMEgqTHHPk0A7v9Rbw6Qs1KkyVgi3zIZw_JHy
  Ke6bIS7cIBvCgpHl-MXRL5JngGleyb5P6lO3eIo2zMwBaRIHmMMSxct6an0o1I444
  JtbF8LYiJai6a-CmCzcoCdPlkhrK_xIm_JX15Cm9sWi_soHSg5ZS62NjHlvKkInyT
  oWI5WaZpRpzH19yaHzb4qLpTF-XHno-KwbFwHuxMLw3QCLxJlcMOdwbVFNWJB4HU3
  G5RmbL93pn5fX2HQF2u7hgHxeojC10lAhsW9QqqZMvBnWrcLhODZ0Zdf-WL09nAHS
  y23JeEmtUUuoLFK7pvvyKwBX0mUHsE9KuIbWw1xLqrD4S5GtSBPz6imeIs4pESb2Z
  ZKsHzU8oTHBA9qrEnOIwhAzYejcFBw7pQnrPb-ErwzjzPS094b6Xr5i2YX3oJXhMd
  EIb4WEMClP9f4AKIG0nrRyxJUERayq7C9ZVo1_73N-CEWNBJISXH_3P9IMIFjG1qI
  M-Igw2in0u4h0onDoUm_WNWBoR2BSnfC1w4Tw0EogxTKk17bZ1fBBA7cQPggBIhU0
  oXaWzpVGBoIrSKvwZc3mEBAksSUeZoTbGRpQDNxoK4hwN7ZU8g45BV1BIePo9-SsZ
  8W5WjihriWPUboC99EQyikEb9xAYUDe11NCCyx76HboWQscANnB-DtGaJBUIdUD6U
  IDgl-XpSASJlON4wvnVF0DMkpmjb2XEFAP89qbRz032wiaDQA"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

