
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "PublicationId":"EBQB-RDUZ-TWGC-H3AD-ZGID-HBMY-FKSF",
    "ServiceAuthenticate":"AASJ-74AG-LAJH-GMML-ELNU-DR6M-QZYC",
    "DeviceAuthenticate":"AD36-TC2T-63VK-SZSE-QTST-OHNJ-2FFG",
    "MessageId":"NASM-UF4U-723N-YRWS-HWZB-5BBB-VN5A",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MBG5-XM34-5DUE-WBZD-G27D-YB5B-F2DP",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQVNNLVVGNFUtNz
  IzTi1ZUldTLUhXWkItNUJCQi1WTjVBIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMDRUMDE6MDQ6NDJaIn0",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFCLVJEVVotVFdHQy1IM0FELVpHSUQtSEJNWS1GS1NGIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFBU0otNzRBRy1MQUpILUdNTUwtRUxOVS1EUjZNLVFa
  WUMiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDM2LVRDMlQtNjNWSy1TW
  lNFLVFUU1QtT0hOSi0yRkZHIiwKICAgICJNZXNzYWdlSWQiOiAiTkFTTS1VRjRVLT
  cyM04tWVJXUy1IV1pCLTVCQkItVk41QSIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MBJB-QS7J-ACZ2-FVMP-ELSA-EWGT-X4YW",
            "signature":"EdxiI4m_F6waudyOU7Aij0cIoIP8PxXRM2CDR8ft
  WII1AMqtdA8f0y5YU-wrlGry8lIh4ROBR2oApgX9q4bM_6x4L3zyO_JwbYTSqDVcN
  GCUJEeanlrI5apH0-FzWmLS1kbEFtDKGmrpRs13zTj2PS8A"}
          ],
        "PayloadDigest":"XpZP9bhsbvCMEK0B8gNwzoaLw3D6Xke6LBXPBxkD
  NodwXAF3JA_bsp41t81EAWdpHvSMn9GlmH_ISP7O-Cmc0g"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "CatalogedPublication":{
      "Id":"EBQB-RDUZ-TWGC-H3AD-ZGID-HBMY-FKSF",
      "Authenticator":"ECCH-756Z-DV32-CRZ3-GWVV-4K7H-I3WG-VTHV-M3D6
-WT42-4WVS-WCTD-JX3M-U",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQK-XNEC-AO56-MAJ4-MVQ7-64ZY-4DTP",
          "Salt":"1RaVyHnuQ0NvhToLi2SHMA",
          "recipients":[{
              "kid":"EBQB-RDUZ-TWGC-H3AD-ZGID-HBMY-FKSF",
              "wmk":"j14fjw20YKq6JHWnZQTsthreWTud3FKDCLxjxJBAoK2p
  l4M4Qg3K_g"}
            ]},
        "5pkQqkoclKgS5t2Exq0fKZ7FjeKhWxFhPmc1ioFbUN0JNsDE8XfO_LqV
  7WF7KsYEeN-uyF4ghn9G2CqUOSynuo0GlvCbUwYiJF_4c31yF0Lp6AqFK4TQFkb5W
  ZGX7CrUeBW1iB66JMRJYC2szTr80gv02Ge35w7w02hv5usRBCUkppIn_CnyxI9paq
  p3WeIQscBA3lnwZ1pPoyHo1itjmyIUVi2WO3Vcze0GEh-bbWWEMaPpXA66uU9Tn2p
  FOf9N-MHbesLK-eQRdaUhnLreJpi4EbU_QPBlBf-SG_14s7TF5FPDI9D5W2xq048h
  OGFQcfBTOK6weTYgIHu5-70QJDDZ0OSVIdW32PcoXoD942jvmZsHcImLULET4mkH1
  1_IuemMNOCl2BYoWJa0u7p7Ls0RhU6l3IA7hBEp3t8d7JnvySIxR12lXdsVSaK44e
  pORC-b76AEwfT6vqZ3Z_XBp0D5iUMEK77oXVop0sJzXEkI6z_MYlH9yoitOGU_5tJ
  EEcSN4bqQtYMk3d_WgHJm2X3yiVzimxq8RJ2k6M1cDdXBjPJKzzqSM9dle3l1H3Ew
  SwW42aH4Kn8q9tSO7HMVbq3CpEt_xOJqYeBWYcDAwgNZStvBJzZw6fZEzZFJqR_S2
  WvJuw6LNYA7W1PCif1x80REvPEjA155da_TRPjMNm8ibWNl2Dj3cu0mUwAdpCgoFg
  T7J4q-Xtntcds-mpaCS5UCTAQXoXy__AEQaKPDJhwhF7PYk2UgimqY3vMgk94SO6J
  0Idwk8tYmA0y5Qy4J1EEgxEJV5m8iR0IZ2FTAbm5QZyj9k0gzQuBEfXjxr3FKTKGx
  nzTeCH4VmzSKUT5J2KPzBqlBkNnbo36VH8vH66a1bo4oSNFstvvTA6qc7pjMqLJEc
  sKc1CxQ-TD_goMbXnMtv7OS_gYNf9kxIkKNZRxGCRy87PScD4fd1uTUfYqldE6WrO
  5CNavS41tNgVvhwL22MMzcOLk8kSQYOeMiV0-6FVH_nktCZf4dN2xM4peWUfHVseG
  7_awE-mHL_XVmoxAAWKlg6bcIhua4MX_K_ozbco0CQ_6t6bFwciNtZX7Z5lVKwYWq
  X1-XWJECjmm1H19YrwluswQW1qwFdip2ZS-1R7GQg3vjxucRVi0KQs1IxcU54A0DN
  XxhdzRvm2u1JvVyCXNBnHOhuXOcFFThF4w25WZbGlonqPNdvKqoAJ1fDAsq2t-slV
  GZZKUXr-ga30yxTlAEPuE2nRnP4_dD2m9U8b9mXIQR5pTXy2SXqgccEGGW4jgPmJT
  SaaUdKNNvKbpk1wTn0amUB_-y4TtNJ6S2eJmQyLrARCeLRuG2Av8h98tchkmyod2S
  bWQ7e_J-XtsaN182QIAkseIeKhrQ7B-BuRIDeM9j_wmLIL2al3NIOxKas4KqWhXjN
  94crAslFTHVXXrlwEQAC2BmU_5359RsItU53I2MTmLxjja587DaLrXY7Or-P67UmU
  LNV9HRYNSQWMc_tzTZEFjhFzP-SxQvULVgbnox_Ht1EWkjZSnwR4SFy48Ajohfs7G
  T2SlWZevP7wKXjSPneR3Fay-ZQTCXaJZRbOh4ivmx_mN2oPwklXILwOc-ADz06hii
  g7zVpsAbe5MQUJFHRnM8cmU-2IGEKvBi2GzFtjPOlZiXP98hwtubCQ-knreN0WOgW
  g_gaRWnpNTE4CR2K1Bj8XgW4eh4_65FGavZSu0AtOGIO5h4wD-FC_APLpU-8fZLlK
  SR6SDecI0Ry8B4sA5rGdrh69HbLxVj6DlI5RJMPqddMRqKVCmNL7jZ4teVCwJrjij
  aREJTKXcT12Oiq_mq7moYKZK2hlikk3-ZvttLditVfMPUecUAhaoxq9CDNhfU2eQo
  yrZZkGfJwDeIAMK47cOuXfYX2wvgyXWJwUUY1B6dBtKLH_KRRWdIGywfBFQJOaB0c
  UHrcs-6LyWvpeTRttylStfLW0MO6fvvw4thN_IFflMRPqpSJTkZoqBoVc2FgYelzV
  _HYmkqnok4A4JiVdJttbjOa9dfiPdukXRVFmMIZnM6feSfUiNC6krzbOPTfClO-HV
  9I8xz5k5dhLIMCNUGPFdlwyePhtNUVVUTeu7KAdMopFhdEBoYz35iBww3emjSPODL
  z62HPG5n8qxUqYPmGJJCVI1tHuqcDxqQrDfU8TWUN-KdbEstjgefFACzdYAM3jKYS
  Ukd7vqtPE2-rXy74NNSCvbzxhizhJx_L2WBnGWtXYKGXXDAVQx-xSwf_Rvzu-i5yv
  O5r1zB2j5tHAXyxIxhV3syTqJ7bGJRN1sNirHkpxELzM43_4ueqglFEq4dtNK9K7v
  QUKxWwHctf9Bnpo4cV-3R2PHTeahhMOFQBByzNacJsR0gauh1C41Gnw8ifUeYRaJS
  nlLlZo_LfgCdfO2LOw11tFK0uwMKyymYAyckLv3VzYGsHPc3Q8mIxyYpYQRaIqgwk
  nsQHOtUcamtkac0erVCFKRBL3M-WRvoIoGM6vBwcTp57XdPhW_fUmNlMdFCRE6TjK
  agABi6dlhZ8PEzMfHdqELdgMxXvnBEZb9fRlEKPeNEnoYDpgmB-s0MXWkmo9XcWdj
  Te86krUVWhkVRp0KvEEg1o_G8NMmq0Iors6W8DrTGAvXEJLW2WuIjQ3NBLSZ4yMh3
  iyYeAfypV-fxWPQgOPdqJHjX9IPKy_YkVemYgRNb0J-9oB5yVKRgRTT5eS0f1qb_1
  dVs9q6oIOgsnhohsx6r7INrYJ25wM4aHOj5t7p5DG0YFaVwQARV_s_qi9ABWTs3sb
  VzcKzVZL0lHr5SUbw1Dy6urpE-nfM-4rY8kzMIVXp0BkRIFm2pzgiwaxQ2us6V83S
  EY21_wTvsx6gue1REhTOF3HTGxhAtgo23dG-W8RLdrs5O8UHyiwWvUHqKEVKwztyn
  8fMxDQNr-2XGwzzT4nhWr7bXoKbjwGjm5Cw_5yEZy1LianDFaL3abs18mmuyt3Uec
  qdl-ZulMvSdl8M1_gmZra--1C4e"
        ]},
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

