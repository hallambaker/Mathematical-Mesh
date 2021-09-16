>>>> Unfinished ProtocolClaim




A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NBYR-XXNR-HDUV-KIZF-V4TT-YGJI-AJRK",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQO-LKVP-2NAA-YX3N-OWC4-2QKF-GPCK",
    "ServiceAuthenticate":"ADGH-7WD7-VVGX-QYZY-PJAB-SB45-7DXJ",
    "DeviceAuthenticate":"AD6Y-MH5F-PVZO-DZCD-SE5D-IX55-ID5P"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MACN-A7UF-JX44-F7VP-3K3L-OSGY-CUGU",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQllSLVhYTlItSE
  RVVi1LSVpGLVY0VFQtWUdKSS1BSlJLIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTg6MzI6NTlaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CWV
  ItWFhOUi1IRFVWLUtJWkYtVjRUVC1ZR0pJLUFKUksiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUU8tTEtWUC0yTkFBLVlYM
  04tT1dDNC0yUUtGLUdQQ0siLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RHSC03V0Q3LVZWR1gtUVlaWS1QSkFCLVNCNDUtN0RYSiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFENlktTUg1Ri1QVlpPLURaQ0QtU0U1RC1JWDU1LUlENVAi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAJ2-4LS7-7CU4-7QAD-RG2G-NURX-PGL2",
            "signature":"ko9O3mvQ13-zhiYRUsdaM-mYsrVOVQcGillwAaaq
  _EcG4WQQJ7Q3qo0IowoOWsEu4vCqTIalo38AorzKLYB7PPKJnoB1Cl2Y_3zS_NrCq
  YecxujnOG_wHPMnjv0AG7j3CPUCP_k7U5MNhL7J8EkZCAUA"}
          ],
        "PayloadDigest":"06N-CogBU-PWMvmr2JbTVO0RyXxR3l8n73O7ADm0
  m8S0LJNLzQ6dP0AdWwzTecc63ydaVWSvlakfTac8oc7B4Q"}
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
      "Id":"EBQO-LKVP-2NAA-YX3N-OWC4-2QKF-GPCK",
      "Authenticator":"ED3L-L6VL-GSHF-GQGX-KFHO-EEJE-ZQY2-FCQ6-QGG3
-K3YX-NLUU-GMFT-SLKY-K",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQF-T573-OPL2-H3W4-FQFG-6665-ACGY",
          "Salt":"AK5yBAcEgN-_Au1zLH-b8A",
          "recipients":[{
              "kid":"EBQO-LKVP-2NAA-YX3N-OWC4-2QKF-GPCK",
              "wmk":"jDkypl_2zD1gWrCkjJMt9nMNwlXuJD_CwI31jA_jSGHz
  347NoEqyVw"}
            ]},
        "UNFa-r1OUGFwp4bArU0oY-R_Ba0hXiDRz443j_QYBT56bzU_KGL3Ggvo
  VNhFeT01SHYxlGaGiJepgHkIKVyvKQbiGxRN8RJPeTYEw04mWaJ-N498-F4GjHsfO
  poxsciM1FBUb9tOh00fT_Vav5c7kY9JJLKhu9ydQmP2SDCx6ZV1R8v7qhuM5Kk6hm
  ycGiNDAJZ61THX7aI7FaS-FOB92z1DQSNKWib_7sLYG7byFor36E_GD9eC5QLiU3V
  rUMEIaWyakIkMlpmJnE-JKb1C9qdq855mJ1aOYE-uVWQe78kJsMB4DuDySC64QBcC
  cJcvIiq12-2jnaKGD_y88hOPGQgDAbgyGVi02Pna3ZJxKRNx_NqLhxA88rk28qnXr
  JTd9l8TxC9gWutmuXPWxCUmJpxvPv0MDSc8uEctBiRDiXJnGHuEFWFByiXAhpQ19G
  MXp2O277-7J8avAEuCoWur9F4wVf4nmhd87P7F9--vZG3gSgWgNRFFCWyHO-FnM0P
  q-BcYM_Cm70sWcCyzzDnQ6qeu-35xmZs89DAUE8nHYOguwd3a_oL9XXRbaMd5vXlW
  N0tAQG8SwZr3o00CAqQ16eGLXqnKO4AbiZsNmtoKYYvdA5Y9YkGlVpEftxwZ0k1w_
  Jb4_TogTQbzXIvOcExvv9kNQCFH1YN5ZyNQNgR-I0cL0r6iRcqdv6VjQU_wiUV8YK
  _jIgs2vQ2dLCarMn785gS7ZT3YyFu8Kloz1MYbWfDBYvJJACHYCzdYEj64V11N0bo
  fknfJSpHUTu7GMUHM_LsyApr4KgVFcwPZ9ldDSM6rC2POg8AVwlCZ-wOLiBi4YMN3
  dwaX1LTvq3KhnOfwNWG55Z1NJCr_YGgtD17-ReOgwqSGGsDZI5cj6kjiA1u77100j
  WwZ37dx5HLE_Sc1N8MhWTG2I1BVhzw4Z-PpUWQ04o0dGlWS4lOlNC80xf55YA2EDJ
  OwY-0enBUBPnpeSc8az60Eq0KymTaOmgpjMN38VwdUUlBIIH06km9FaXF8D7-SbG4
  6KXJBYY8Wc79orjyl_ENR7EMSCsV1spbiMZmVRQWm7QmSi1TXIrTG6Q62Lx8yDb81
  g_oRDLLeAM_7PONecf98N9ujD2QEL-iaCD1KxG3ENE2Ni9ayBLa-3T-asYj1ZARTN
  5Pc0WxbRFKlpyiBnVpIl4hEV75EVXkDH-Susxb9FNNzq0TEhmbsKRYofVj14hA1gk
  HSgmonL_CwP3-ERORXIv1eNbujW1cS1CzIucML3lsMADkEYEYVK5bALVejILBpd2L
  aEWzxXgSe9GwWfVcHVEEkc1Z6gnYAytGX3WcZ7xVwJlU_LCmkBMcmUdWi-NrIt45m
  69d0vyX-TLCb7DDUlD2o6BgbaufwUY03rIAGz38D8nKnq9zCYQrHKss7gs9jiPcsi
  X8JTK3O5gCwIgl0sWDSYY3ib6i8yPk14QuzGAdyEYJnlOBE8-kl777p5U23qWSn0J
  QrY42ExyZ-6elj3JgUvELeDpbcwuSeNiqMpGrI3MZiKwvD1Xc3sjjBgkngZrwiqKV
  KPCftdMlrRM4AEyIuo1useK52g1d4LPRoqkj88SiWN2kM2tcpIM0af0kgdFH4TB0U
  BFTToneh2EE4xW10GciI6hZMN38UyAKMqvhjNelyvoN3-xu29t4UBACPBkjmxFMi7
  Q4-uLGj0vvCyDcDBxzcci3GFO1p3sa-TcJS5pXLsIj215uj3E8_vvVYVk7OTj7hyi
  ORqd9b16fvrYCyYMpcpw09ffWwpPmJnDIgtBPPoK-4xCWyZ_5MAm-3mUmb0kpRMpE
  zdY-VEGEhjsNw_eFS-SoJPHom_UcWbfLt_WLu8LsVoSVaAkpLI69-6Ts3ndnDj9Zk
  ft1yaCpoggiLD-3GRpfPkqWtZYz75gtHi1OxuIX5FpyYSVQrRfjpdkynWIFLaPoGH
  6loF75XqY8qB4cCPsrx8PNr1eJtK6y_8lMEj0cjAc3R-FV3_AuSzFmEMDOjxs3kL1
  F4QqcnXW9H5nBpFXF-NMqoc0_P9D80aZsloqsBdVAk-P1WMPbXXoG_kI43E9wDILG
  xdFOcXWyye7lZLgqJmCdoEP0seCUfx7u3t0LoreuuLLDNFpjMKyKzfhH1UKPs8gAH
  CyEwG--XNONsir1kv-0WYCpDPeypM-p9X4E1deFGMtxSmTpDMF3aMXdoCEHJQPXBg
  pKPxB8f6S1BYrhS2tkOOQNqmZtOKyNQVcl7cOiG8zfFpsh88ngC--Qr0H5VAgtsKn
  925rZZ14diynVvxJSupYk2yCZn2vv8Zd1ObN1HLQrltnbT32IT1BawxLxXl5ru84b
  qvHUNx9AVwoA2heddy_kT3c2i1lDoERsOt-U5QqBdH0um4n4awG9wWynaGjR6-tPo
  2-jbS40Uel3nKrwvPp97BANDig5YSmkqTXDWMkQl3frtwQvkiYbOoMOl_2PWZBP-d
  2RbDOiC1b-k8qpBrabdzeQtO5NlCY7g-ksflYZ1lCBtopZQ0GX2PNEQWFIlPxb4zK
  jlEfJSQT2hzeOZjt0g_jQtc3PFwjmKqs2o_NVTA-umTtMxXhnvF8E9g-PhSPD7dIo
  Qa8FJAXyU8wavRF0JEWc3m0pBJO7QUvEFdnNFZ7cHQf6iAZPTfVWghlB4VcXXcQaQ
  lZ1STlcK29_SJBV68hsoXH1xvw7eLu_-yRTIvrO0QIF5WhU679718GDYyWPTssPqq
  hj1vnvSYIzCmGZFhUK7g2jqqX85hMAvgbKq1zrEwsuzUwRZOqyu8jO-u6Bb9mjFky
  TV6pSgx67mGj5wi29_AURWzkMx6wKYNjO1j7OcPxIyAj92LuaQ2i6tJWwm7DC8OJM
  lmllGlqUNufUPb3IXvy0dIc-0t_-Be07ygAjZRgIuwFui3hFLVh_WBP9R-ZlkdGN8
  5HI4p9grOc66kTgMgxvTONha74niGec-_4LlXEM465rS4V6ML3NEEiQzy5DanlHP9
  oLzaTzl0zV9iBS23CgOACA4oN_7BIQvSDI_7z3gL5riHXogtw"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

