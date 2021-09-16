
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NDZB-XZFX-2RVL-D262-ACTQ-MAQ6-OCGD",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQD-UFH5-2RXL-KFEY-UJ24-AF2Q-DCF7",
    "ServiceAuthenticate":"ACD2-WIVY-QXQS-LT2F-AAYN-NTE3-VGG3",
    "DeviceAuthenticate":"AAME-QNDM-MLGL-R4LS-KVF3-EQLX-4T3M"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MB7Q-UGRQ-SIPC-5CS6-ASNO-DPSL-3BUX",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFpCLVhaRlgtMl
  JWTC1EMjYyLUFDVFEtTUFRNi1PQ0dEIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTE6NDc6MDBaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5EWk
  ItWFpGWC0yUlZMLUQyNjItQUNUUS1NQVE2LU9DR0QiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUQtVUZINS0yUlhMLUtGR
  VktVUoyNC1BRjJRLURDRjciLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  NEMi1XSVZZLVFYUVMtTFQyRi1BQVlOLU5URTMtVkdHMyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFBTUUtUU5ETS1NTEdMLVI0TFMtS1ZGMy1FUUxYLTRUM00i
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCSR-FPUF-3O3S-SMH4-E2EQ-NQOD-HJLL",
            "signature":"C7rmB5eVvLpjzk4i-s3NSZIkeK6SOHRemnzxPkC2
  V2R6Sj9NG85zvOtJj5GabbxNt-lOrv_fEWiAIq_0xIN7bL6bqIJoRI9sVknaM1vxK
  oDmqrlH6CH841jZMj9QQKr0EJdNGkre-w9hckYJw-sfvBoA"}
          ],
        "PayloadDigest":"iyyHcVpAGs3HkHBOKxQf9deVtMIHXhuR7MIc-CPi
  ZBeAAmc4ce7jMLYm1hJREmk1-3dmQXVelT7xXBUE2q3bpw"}
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
      "Id":"EBQD-UFH5-2RXL-KFEY-UJ24-AF2Q-DCF7",
      "Authenticator":"EBE5-3UTU-MUVJ-PCCI-DVOU-WLZ4-AV6M-A6ET-J5VX
-B4OH-DRHO-5UZ4-CPFV-E",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQB-QZQR-YZKV-LQIJ-VANJ-GBOI-O3OQ",
          "Salt":"P5jtDbV5UsrB_PIon_2fXg",
          "recipients":[{
              "kid":"EBQD-UFH5-2RXL-KFEY-UJ24-AF2Q-DCF7",
              "wmk":"O5Nkj00qgac1643XxVJtDy22Oi_Idz0iR00BgN7LIGCF
  KhP8uBEHGA"}
            ]},
        "bl_EpHiUoq7Bf89xtLVD8ku9oVueJVjrEAnkicf8BBWfsHMXiSOq1NR1
  nFBJoM7iBWYgLkaIfncQgiM1TEX3wuwjKPs5C7DSF1TLFh0Q-VjTvk8ESJGW1rwtU
  zpUrpTNHd2kCzjFeQ4nVvZZWIOCg5dDHyHwdtfhsa6pcNFZw8IsYHuZiQgzEubHNb
  jur3aeGAO-2DfipQNJcTKb5IePGCoif7ryd2gdrvS2jz2XhC51I_qmG_sGWMPGMTg
  BELlZtNWfFnSN0TNXJBf9FQNNF2ry5_m25E-T4qpriY6Hja7D8hHCSGYT7lwEVm3K
  xL_iIH98fhCuJA6W9oMGrVTcfl9XI4TvgnVBRsdkRYNLxRMsVskYyeiLjJTRl6QhR
  eWqokEL8othVgsooQUAz8icV7IZe8n9-aF-Z97K2R3g6JlY6gKZ84D_G824mlNZ7w
  1SCyF_RTiY4MfCL4CtXdg07E_T6_wDhsuD1pzgvSqle8asNLl7LEENFFwEGQoTdF0
  A8pJTWggA70sQrMUoRSYG5vUvbJkpOceeSBkzafMMzI6GN2TBTvq4VXfxKrXPCQ4U
  eQGPqcZFE2vPUzH2gq4hJbCBR8BHsSfKp6sbXKrXNDhha5FmKgxCa867ENsmK_RnM
  nqaKNcVmdiAGQrbmfJbPl7wmfsAvCNMh3dpiUm6Y2tpP4PgxIjyfggFsUfKLr2Pb9
  ImYy8n1NdOLg_LpvhZMlHF57QkBb2oW17MOyeK6xIdSgEBErFvGHSIPGaiP--C05Y
  CIRUnHHDDzRt8bWF2r56QHRhU3DW7Fjc0dteYyRJbYJCoZ-ma1Bre8vlXxRgomuD2
  OEKSfWBssTgyOQ3pLlokoXVKnrsrNel0ELKN9OdFWOfnFEi2Jtrq4rMIaMMDFHFil
  pqLEt0Y6SxaoTWYUi6gyuE53QbXYQjtdi8jR-5zldvLUtIn3CMD6E9zJFRimmjA8V
  XF8gvfH69ygLpT-Uz5XFcVJzUNXqzxALeUothQ61RbsJHIwiv0riQo3QArmdrf5qR
  PwHFDQACUjvDl317exOL5Amam0prOPuwBKTCqbcRHni96tDdc5eS6yjzBC-UKTTjT
  448bxBh9ugaex8ZpLLlzzhQe8zSnbUNvNBqIo75u6CeXaHmvOzTGapFvpxKyiwUyB
  NIHxx-o7qJ2sjR-f107LkGpLDhNI6LKBp5Le4gpIT9Fb1LQIpn6-af6sM0ZApkRH_
  Gk10DTGgvexDlAH_FE8JQZ8NHF0Qyn8eS1o7WlvhdweUoyo69IG8ZIzyfhGCnxLRp
  fGPWILrByd1c9gUuSt3ZMusp5o9vDDKYB19fapzjbV_DY4BiK7I3q5GqC74f9D4A4
  afCVlUw-VKePjU7ibGbMFU6x1TglNsZCFOeyswcdSbBTfxi1tkL28fPPpYv6aBvU3
  kfuKGXkjrfJMopJ8LVxDOfL4ZQtGZgGbHOaQwznM6NuA2NSZEZUTxaoCiMVij8lq_
  4D3S9OKilMkaDymF6kxSnXoC3pT7swMF6-VEBqeC6e20sD7-L79Hd3kMEcxrQYV_W
  I_wyXhBiogMwgxvuz71-1yd7HnELRQNwuDNVwdP23dkO6bO1o6-2MAKOJyQM-zqPL
  qkGdWHtYI6qjZzoRyPrkOCRK-drK2_C_pzj282Y8AyvjcG9gYuIWxgSUzMk_mjyVn
  pvWaw6PE6poWOqpjpbdWlc3DaCm_bWSTt8ZM2P0aRkgBgcwPJlLa3rVHlo0yt5ljJ
  0TufpPNgsjMU_UauCrOtGVf6xUidCEEi85Nmb4WUMCkGA8G-1g4rfSKO91DRBfcU6
  exS-1ZZzqRqL0LA83TswLHHDDe2GlQJ6K9l7zXw-RMz5VN2gSfQAC_kC2fMjBsid5
  Qwsw3lwkuSWabI0OJbaZYGEc_extIp33xUE6oKZJTXMvjDW9fQ25zC2kkrlCDybh1
  E2RjFZDwlhOLxoaANRkQ2rhLuCWRU3BGTWrahIaAxtCIimlsR5NbzflkWdrOaIWP7
  cFypp2O8hF8jCNED7N6JD6J5_Bu07MNL8Q6jVLJ7SYLXr6Ge3VMjgzCyb7tC6bM35
  Vn712CCS4pzz4lxvSrfSSIsuGcZwGSruQg-t9Xv48GirknjizCJ0RY7oIy4ZJ5NfP
  4q17Md0yb9n9YkGZPSq1K65MgZuuebbA_8TtJLLnJ_fysjhC_uDKEHHHqdWLOadJg
  PAMH2a4F6Hze8AtOFnw5wHlsdY-f5tD--iBfHLMn-K3xbYA4N1hZragAcPOV3GlHG
  GYvvNtIrL4Fh6RielfIiV3EDb0XX9ZMMlkDk_O7tp6YeeOuQ_KjXHJtjEWdV11QCf
  l8JZq9dBUIQQsckr-qJpertiThPZAcXTo6WCUoVv-z9p4s51uxOApEHVMqUUqaeSb
  ABu3896cyhR5Mq_xZjiDP-obwWhW3iaoDJFmXHAcJz2V53p1QZBZjX0nb3G3VKkF6
  1WX2a9U6vvqeRMfJXGVW8g8vCyVwnn2rqca2WDdNDUJ4LIazew8gCMzXL-8SmBS1l
  mWQ3cbys1vNvrPUy1sDfNWkzP8O8yjusu0NwCgGVoVoQrvh4fFAcuhxq66G0Pq844
  7IhIkSd6z78dCGxhBqJC1gs7OgVEBERVaN9_wDzEmAdAHiZezTVeBWVWOaj36iJcu
  vImjW5RlMJLi7ZPZFtoiBG-3tg14GkbIVmOjb-JjvQrmLejk3ES1HABZAvxzNwMix
  ENiz39KuHcz9k1TcLxjNXLEgem-whdBKmq138yUNIVsn7L5I2u5P764X1O8Xh3Lsh
  1R-c--0h6g1WJTfvKTaqesguXSV9wvssVA0GnJJ-u1iRRFDrfkvnJ49FIQlfJkVQj
  PTmeTnwJqEFHOAgG8SbJrusRRdFsy3csR7gVr8GlXUNmDOR3MtbZunvyrkVt8TpAg
  2B4L4T_tCU_heoulpdT1GRqSYyj1yeXD6ct5tGl16uRS83fXnCEwgf7FqD6thSOou
  BYdZeL12svcWqM0SVXucukzMPVYlCuW-1UG7PeSBvZPi0WM-w"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

