
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NBMT-D5D7-NNPI-MSFS-JUZE-ROWT-CPGT",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQL-ZUO7-WENT-VXQ6-CDUT-OZLB-KWJO",
    "ServiceAuthenticate":"ADHP-6I3N-XW4J-YMY4-YICW-HUP2-QNFD",
    "DeviceAuthenticate":"ACBX-A72P-WTXQ-JDOF-HLL5-Z7M2-ATPK"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MD4D-CQJQ-ROZ5-2GYN-GPFL-EE2E-PAMU",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQk1ULUQ1RDctTk
  5QSS1NU0ZTLUpVWkUtUk9XVC1DUEdUIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMTlUMDI6MTY6MTBaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CTV
  QtRDVENy1OTlBJLU1TRlMtSlVaRS1ST1dULUNQR1QiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUwtWlVPNy1XRU5ULVZYU
  TYtQ0RVVC1PWkxCLUtXSk8iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RIUC02STNOLVhXNEotWU1ZNC1ZSUNXLUhVUDItUU5GRCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFDQlgtQTcyUC1XVFhRLUpET0YtSExMNS1aN00yLUFUUEsi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBSR-GKG7-UE3F-S3NL-AADL-VGQV-CGUV",
            "signature":"AD_38nOxoSgWOgj6t1BQCYC6eu_FcAVFnA4jmKqT
  wH8LOkLKA2_xcNc1ucQvqzSw4g7_KOKWlCmACsLYDa4E8pKMHk0QCnOnzqe4Dp0wb
  zyZ6VHubp-iuoHCUnOVLOfap07chfzUsHrd4Xc654RDDgUA"}
          ],
        "PayloadDigest":"KL4lvGXiJosyeFLvDTxd_P3Ijx9TH9m-NeXhOt63
  RTJyyMhFXNvt2KQE4OmMPRJz9sNGbTJ52lqHztl2TO_yZQ"}
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
      "Id":"EBQL-ZUO7-WENT-VXQ6-CDUT-OZLB-KWJO",
      "Authenticator":"EBQP-HX7J-AAY5-XVK4-R76M-4RVJ-4I2Q-22SJ-ND5M
-HTNR-3QLS-C6ZG-OMKX-K",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQF-PBJG-BDJS-D6N5-CRNH-HO4I-R456",
          "Salt":"YLdv--jzYkaOg0kSUyrvIA",
          "recipients":[{
              "kid":"EBQL-ZUO7-WENT-VXQ6-CDUT-OZLB-KWJO",
              "wmk":"q7YFIDHRxjRtq95WRVvBs5JzFheHKiKiig_AYmhKdPI8
  EIhThmszDQ"}
            ]},
        "31mx5SVXdLDth3fsLm-0KHkzjBY7u_Ela-joTcysRWQlWAwfbknSUJc2
  GfgwhlyO8W11TdYW-BcJnqDAws_DkIwOC8bBQAVjLNyUf68Fnci3KzKmxhV5-j_qi
  HmK6Xr7dB7G7fx4ElLc2KOY0AFA4CX7xuHQI5pJfYST5OkgrMMzQ58TH8k7HL302Y
  F2EPvNoudtdC1PJhZGzJWtgQ6c_f7JJaXAB4_EVDFBPusfw8Qe1aVJYI5IgjOPS7X
  7DNVYbqTT5nzRRUblcYIU8xXqlnWe1iYH8egBF9jJIN3nXZBySwnN2n-nzmFN_K0G
  2VSnOY4nVtaqkC5GzS4ugPRhiYfWOpU0ClTdhf6LGtuCE5RSYLtH30U-mwSmoKYbl
  znF1Llzv6zbX8nuwTlzTUKGgntSMjOHqVhzaVR8NmLsoXAhErxRmZdgeVc_DQ4eHh
  CZ0jvsxV3WH_l7HM8vOsTfBhxNhlclEB0slUS32_DF-AEnz4D8v43cdDJSoQecibi
  QdxMjtg8c6jk2WlLMIjfTA21IQsmhxA2WDLc_efyjeiqCYPULaK5vFeQx1g40clDD
  xbUNl6QiPeLk9kVwSZWgpnkUuX2RgyJIhwufTYNiMYQE6WRtlY5r12lmE2jhHBRhh
  ULn-oEzS4n29a3q4KK316eiwFZpF5QJLJh_gHVwYkviifmf_OGnbcPrS4Erao_aCT
  EZCVytqXMUR2cgGEnF_TasiQxOU3OLMlDBKqHUb9dowaoQb0ZBq9eI9YlFtPdoa-t
  TR0vHK0aodebYX59w0ORSHlZZNIh9_dANT87NTmkXLUjVdexoxvhdI2K9mBUiKp9s
  Dl22G9UOYhH9VTEB-ZPfXPrSjdlwfZufiWxJTiBscQcBSrSbHpkr9mXp_uroCG6C3
  6w7MraiX_n_BOkVnCFSmJ-6W1bW1c_S-0kRJupzPew7tgMjZ6xyh7A6mHwnbPidxj
  PrwnNlqcgNNIAZdT66fRbWsRdbKi3F2xCO9WJvvkrObckpeO5o2AXnmCfE8n7DWV7
  xtKI04N13FagkBjzhxKTn4ekDBHeFQkCsQK-QdAH5-3Ffajmk6_fkZZL5zgybLXnK
  667zAPEcL8bPk_rebsPhjWRUSf3Cv1uKsrWkYPdEkxVmpyHNNNI5Em4wENn1rBDt1
  a9eRGARpOsUtBZGz6xvw2RN6MfVCQuhMVNLlAU_AJnswbJF5JCAb4Jw4H0KDF6psq
  G9B0YtusN64RJ2KYdiHxgoXCGM_rbIEuRVg-VuCRdhp32A6HkLGqX0mHD73LQmzCk
  2EoGCSUhWaHvLwo3N3YJgSE_OipvcWnI2gChRsFiyzJ6a9Baz-4dYqhPFyHSrN96I
  EfbzWRlpF3xruFVg0g-f5SSpt7zNIKWvbgT8d2qCYu6q-92DefRqbhTmnKvCt9E79
  -VF5zUulzknKVHWi5yq5Vdsm0TQWVcsLULRFt9s6HxN86xLehS5iDKVm_J9Vakx4j
  fUIoMrX9s1IO9pRnF5xOcpDNcYTCaaEYFtTexFmQhbbWVSaMx9dzVoAheB7YJex93
  Z5TJG3l7nKxWfRcyqHaiCVeLMdjf22z6JGUzO7K311cBptAiHnjfhAFJ2hvb-N8oD
  jqIXo1JkkeVRSGa0Cas8YCSs4z6PZ3FY64nhD4O5KPX0Tjj_nMn9Vp0ApIgxHL1Zh
  vScbklwjxSEP-FnZ3mW0BIFvgaTktgKldqJlW9_app907uMVH-i2BOo2CT0yf5YFk
  hPUOIj2YY-Ni3gmqeA1PIKqyt4pH61iWhhomnUYVu5uYw-_S-rvO5fRN0zwI5nV8h
  XQqL3aRxO7SzqWVfRad25gxtJmYFgbI3m8kr8O50XJk_6FKRdhQOjS4bPm1Lbz4q7
  21cqsiqi0aErck2np1Ec8MqC0InDcuisuK6ZlneKxNmI8BSVvF20uZRlVYJNSKkAQ
  GIhvj4czf7cJZ22nHEJ5rgJtAPHGaNCFL73Co3OZhgufy4oMH-m8JtbKZWEY0hS4R
  ThJVVufr0Rg2evj4eo4e5klvKePJuEu86Lwq-bzShkE96lmOR6vZGPpFxMheQclnY
  wVTqcixVMTZS4_5wHU5fGSvZLXyGG--QMpRpqT111ehU9-zd-HpMBqIK7gKnw7L_T
  aSQDNl1vLNQMyD4lFa6001YoByBfN7_bvX4i3bRVSMWUNFeU_CRH3HZ04sbz7BSbo
  tzXlpDCK3gqWDfVaoNnr9SdkRYJJda9SazXZuaxcB-XWDWugrNqFCMn0bJ-MrtLgV
  oQwITQNp6jmbW43i57PRtgR2z1FatJfT0kKgkO2ygpoprl5hEUSY002OHIA6qv1h7
  pC9h14ornkL672PQZ2qvR2NDug8m5gW0HSks0Yu6tOI8pJl1ao92OFxNUv17b-ZpY
  Qc7_jVfO707EKnCwiTQwRc327roqz-jSoHeq8soA4c6ggyigiBBqeOMZU2YdGLKP8
  WQNaRmD2lZTykLsRMl6TtPzGARyNWCQIRDPBXEVcb43dAIpmQwVROpTGdsAQGnVrh
  x2SzB0jusYwYqmJnjqWfvFNm9ZfixxqxXwRWYSWgmHehVkBJIAUzuz32teHC-4I0L
  W7WrMH9_urkyh-ZKapqVVu2QzqsCJLAAIHKqXwZuooROFMPLjtBLhQpj9HeZdr_gc
  SuKcxXbnucs-y9B7Bfi4b4hqUR9KLKIkfAfc3zsdY_BfWcf1GpgQ4LbdY0kVCAuiP
  RDe8diAgZ0ohnoyj3yOGu1X91KOHqpDN1__CKuXVPI1Zp476gleMuKxILBSeohztN
  WfyrLPTbqQDdVKVeX0SS4sccXkJCdlAuZ-VwYVqWAWIz9pCLQ6LZXIoyH3FzAd_Mp
  9oiXUmuhFuBh0RWPE6vxDqRb_TiL8h76qiADxhSUsaY2PI9Mj8aLLSbt9o4PioCGF
  FYN3pcFsOV_noMdtCkpcq9YeKafGZ2I47PT-1D3pMJBQFv5qlcvwInTZep2AyA2NN
  ZoM6i1m__CyRfRJ4PZeW7PejYBw6NJkeD6f4uUkCnznmGumug"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

