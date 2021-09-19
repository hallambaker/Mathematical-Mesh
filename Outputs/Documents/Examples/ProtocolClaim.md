
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NBEQ-D5I4-2BMQ-PEAT-APGA-7RTU-P632",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQO-M24T-BAUQ-OGX4-ZEOK-5PEY-NZC2",
    "ServiceAuthenticate":"ADJK-LLMV-5JVJ-GBNU-64D6-S3SL-XHAA",
    "DeviceAuthenticate":"AAPM-PI5H-ROAI-DDAR-7CDR-ZVJX-GL6S"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MD3I-ASHA-DD5X-LZCN-56YJ-T5CS-IHI6",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQkVRLUQ1STQtMk
  JNUS1QRUFULUFQR0EtN1JUVS1QNjMyIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTlUMTc6NTI6NDhaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CRV
  EtRDVJNC0yQk1RLVBFQVQtQVBHQS03UlRVLVA2MzIiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tTTI0VC1CQVVRLU9HW
  DQtWkVPSy01UEVZLU5aQzIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RKSy1MTE1WLTVKVkotR0JOVS02NEQ2LVMzU0wtWEhBQSIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFBUE0tUEk1SC1ST0FJLUREQVItN0NEUi1aVkpYLUdMNlMi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCII-KQPJ-WB3H-OYUC-RHF6-5E6W-OHGU",
            "signature":"AMOwg6oAsKO64dr_Kpzb1VJ6QkXjj18_cNZvtDB2
  EOnnDRKgRbzkU0zEx5e6x7kOqNkkFcnGYQMAveNoWTPVOQ3_0D_jPhmIplR6GvHwq
  NwyWikvJkWtlqhoWp9Nyi3lF6EFPab6f3NoOgdno4oS2BAA"}
          ],
        "PayloadDigest":"e_MxJmGQd_4Ydveam7zGLQ5geGfk5eus9zD1015K
  enHedjSSRnBscECdb6l-bV1wv-NWhlLBpQk5GzUMxH1-AQ"}
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
      "Id":"EBQO-M24T-BAUQ-OGX4-ZEOK-5PEY-NZC2",
      "Authenticator":"ECYG-X6C3-A6KO-GKL6-YZCH-VMPO-OH3G-MBDV-CIO5
-YHGX-372Q-F5YA-K4DS-W",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQO-KKLE-U6YT-SPE7-EYGK-TUPL-BTPZ",
          "Salt":"kuCn4Ie3g1fkcKDQdNOnaw",
          "recipients":[{
              "kid":"EBQO-M24T-BAUQ-OGX4-ZEOK-5PEY-NZC2",
              "wmk":"35EYWE_IrUhWWb8R4fWOP0PSge-o-xXU2pIlUaxpDdMU
  2B39Nhf4iA"}
            ]},
        "nYXVlA3z-cohryBj10PltaBcBvVL0REJT5-XQj1t_L95abWt4HiqtcYg
  nay7r8XWw3SZ61E4GgA7mcVXx3CSKOMPTJocRQDEmyxfJFl6Fy3gH9dMvumlx-vKF
  XgnGHTMWPhVScfsF0vyYkLS0eWy6B0sPVo7lcNA72wOm0GK9FTPWDmG6F1RopcENw
  1YqaXw5qYSry8Te6K1yzTAzWgOJuJKsYFU9bp_gjZZL4abn9lO5eGUVMEKTgaC-bO
  wtx4B5cG55KF9_LT8opmdyXDtQxrfWk0wDuhaCdTUPPjF5mDl5i54K3H9IZ8Y-kzM
  x9eJNvVfBlUSxV1pNlek4rzkXsXiUJ13-9eZ7IwvGQAXVoWqVpZkBtwA2ypZsEUFf
  V01zdN_e2NliHRkooCJJmmFKgO8_Mc-NInpZJ4328nyyqSba19A-xsaFxcut4QNKe
  yL7V9rLJgz95GEk_z8duDV1WfX9lulD4GJJVfnJqY855DMjkVPYNBxaWWS483Kzfo
  9c7dLdvh6M1fsc15kPxSunkiGQl5S4AgwE88-Msu-sNbv8ywGqzLHn4TRW3eLRii8
  0q9yq1m9g2omOFIvPdwI8ivFhZy3Yb6SXzXRklwJOpys8Wf7TMIalssSY6cIVIWm-
  zfJqjJmvZge8Y4yt4-3aHRXRyaImm1a1YhxXRtLsRL6VPObsLWxg68U1OraprX3dF
  XVe7x5A8xRbyw3VTZJgaqbacNEpPmqqn5kFe_X4zwBtxPJZc7weJZAufJMm6JJQJ9
  7XnFoFTDyKKwrbijYAW4oEZCy0NH-ZBfg7c9-V-6UUVcxnrUTnvdNRMeXsXC5eWBi
  1pdTQvMBnj1cz6GZkWR27CO0DwlxYJz5vgkr4Czo3BJVJf63gfDrdy43Hz-Yp1u5E
  iP3ypMTjb85ahVS3crziWojzZxSkTripVKSFejeLo3RuyXkq7pFGo1luD9SshVf8X
  knjBx_1TgcYBJ1IBAKiZ0sbwiiHgqm7YHByIqDkaoHhcgYyWF6JoTBjirkUdISUbP
  vsW02PFGDUQ5f5c6H2P3H4vN-MTh2p_3VRvc_y4wDj1vkJLoc0eQTa6XwCtdzB8Ex
  y1dP0btRvv5daiulkNnuUDPScIQgZLQYwInB4dIq0OhhAxJ2qXu9j6Qe-iiM7z2aS
  Rrq6LYmpHPy-QqdYWyGNx4OUrN28tegrHg3UopCTJp8wmpyH4bsen4p-YdiQ4Ja-n
  _UzV0umkLz-ZUVCEMga6NWWtdcpLYTrdqjR6SMq0cib0Ob6a6sqq9MGwBxve9JJkS
  nZoSFN0vsaGyrspTVXPAx6VmeqHEwJG1OZIP5EBSAUIBeX9Y1R6Np2fBhQbdDB-WS
  deeRmgHHHlbpmsFD_qA4rlEQr4LPVLw55Mut4Np-GyKOVmv4sUFGAMR8nJEhVizei
  r9SMhtR96eiAX07yVow64prhjVMdWpwM7phL1644Jhw9WAhp1PvbX6sz51pwAOFJj
  cNaLZUPF9flHzci6L5Mi-ti8Xi2kvYhHK66jHoAQmLh7ysiI41IX9J0FR2HgOuZiF
  JlaqkWE9PBTGD5tVgCtq1KEwsz3anVJPRWU4OM93muz3R_UevBt_wtDBDUMpHbcix
  e3WsfuzT-Xj8wg7Jm4cE52dtJcx03NOh3xm5BR6nh_pNvP6cmQzEhoK14UtS62-zd
  ymKm8jXw1zqXOLIeBjjOsrEMsGVA_iuOrey2FuB7Jam2C5HU9DNqtGLWKGd-_bn_f
  vVxfdDs3QJat2eKtkflYAfZ2MzP0BsTUdLggNMJebhPdm-I8d3oQvCvbAIPVrYHee
  kM9s-oEhlwSafnDXYLvUFKjgHyS-cmdfx8BDZHBXXCrV-YLk4qPt3VTABW_6yz8k_
  PlAKGtRNDHXRV8DiIVaUcdgJatWm8Rzg3F0n7CmefYTh_u10PdoAWb5M9o95B3Xor
  dffHiJ_j5nz6oMbxxK4reEbD9XZ-FeN7ROg8SluxelwiIHSviHuljMBXNOmsIULCR
  avPwAO-mlJO2e5iXb9kSC90aJYZlFdvvMFIVzkUU4eJiFOSLeUifY3q9mBNxQLR75
  gC4yIzQakmZv-9oOL_KCpjV3aIwNYH7S3yH0mh4pCJp_DGqJt2sNjYdUDV-cp-31A
  ALrgloWbgdH-BoYrKaEfoM5p6HZi_Gba7Yz1AXUS8NvO02o7QIGuS2TYUUrCEzQwJ
  y94y51QtXqQzsn_QeNtrgGcpLozulbswdcG3pjt8hwzs6P-KQB1gUukY--Q6UrhZU
  aFUKS7IEdxdg4Xl4VMKGDxWyibRlzHcDuoE9ZDf1bPRsAMSKEHku3fDb610ZMEB1v
  nfAIIiyADv4ho8EuG5Ybv7hscMYFTaiICpTz4cZ6pRh1f5Up_-mZwkoXm6q1wcXlH
  xHY-3COimUv6cjNbs0YUWf_QYKM9rGiIPTohuYsD555S8BkWu0ZXFOrajQV2C7-vg
  WYwE7CT0ovkEFOgqbNFdn-kAIoJvDMKQRd18vVC2Ej0gkgCHa3EewsP0C4BVCrmt9
  6qb6nD9R6Nv50sacZuWf1uW7Slik6neew0hrFw9X8F_FRgtA4pBLoQYpsuzMkADmM
  J1nG45RT__Jx_Zfk99e1O56qSJThwcpuahCOsskMmcH_dnMj12blVkbvWGQBX9XrS
  jo4umR7eKhoFxlog9IWxx6XmL6RrbT0GWXa6Gq7zhyFFD2DHqZEQm-29zpJAziwyO
  L6qZhP6ul48RKYc2mkdc8ePinVFzpV7zNflSqJzg6Qlr9-xXf8I-hgdkl3aai0FfD
  ygnCWG7A7oW6gv5hv6mKtoPy3q6KSnR7JZsT-ixOUzfPi9e0YKfjbRH-X6x9-iPd4
  lJXGWd3Nstzf6_QBQuwsoSO-ceQufqM3noKDEzErkPWFzWaJRqlsCb83Y1sOUWGK5
  5QirNrIVdyqaetFrJSpFupACGhy3lAP-HYwUlgTvP5ehUJ2JJSHJc8jt411EeUxj-
  foM-9r5ULFa3OLdz_GRhxjMECrma6TsvXKQsdrNl6pvSHsPIA"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

