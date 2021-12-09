
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NCH4-GRXN-MMDE-UDY6-FQDX-ALKC-M5WH",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQG-PIN7-QL6B-TJOP-UPV2-O4OA-RM2U",
    "ServiceAuthenticate":"AD3M-XMRP-GSML-B7IY-TPUU-7PN7-MMXP",
    "DeviceAuthenticate":"ADKR-PMWS-5ZCL-NQL2-7LB6-KR5A-5HJV"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MAYY-4JOM-JJNV-KCJK-3XR4-HG2Y-EJ5X",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQ0g0LUdSWE4tTU
  1ERS1VRFk2LUZRRFgtQUxLQy1NNVdIIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMTItMDlUMTY6NDY6MjJaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5DSD
  QtR1JYTi1NTURFLVVEWTYtRlFEWC1BTEtDLU01V0giLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctUElONy1RTDZCLVRKT
  1AtVVBWMi1PNE9BLVJNMlUiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  QzTS1YTVJQLUdTTUwtQjdJWS1UUFVVLTdQTjctTU1YUCIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFES1ItUE1XUy01WkNMLU5RTDItN0xCNi1LUjVBLTVISlYi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBYT-6KBR-3GF7-E3CS-HTYV-63RU-LUSG",
            "signature":"lFbww93VPOD07Cvq5fcDyatFecuc66s6_kEwVGo3
  P8cQUV2y6Uxab6uDJlAomYp-qOd2m1_0B1WARzwNeJiyfaCeAlslHDSTGAYQ_I7F9
  A5Eliy2lr3xMGjvAD1ahZqqCcXKGF2TK6s9vNANp_PLtg0A"}
          ],
        "PayloadDigest":"DvkJj7SyTc7CgsWiXT2Tt1A-xkn9c0a397Ebswe1
  RYUXnlwr9NgwsLFIajMAi3MCVqlbSAovw37tZgSp-FpWpw"}
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
      "Id":"EBQG-PIN7-QL6B-TJOP-UPV2-O4OA-RM2U",
      "Authenticator":"EA52-27DM-2JH2-NOX4-LZPI-Y24P-MREY-WZNY-XR7Y
-OMVQ-XPRK-4FY2-G6RR-I",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQB-JSDX-Q5QU-ZR5B-NIHD-F6WY-CYUI",
          "Salt":"9rKZXiWsgdTLSsF5OXyAdw",
          "recipients":[{
              "kid":"EBQG-PIN7-QL6B-TJOP-UPV2-O4OA-RM2U",
              "wmk":"6kvn7CUzEa3VFigTijbFL4v9252eKfEvcBQPbSzEI_KH
  lntzfg2uzg"}
            ]},
        "1ThT07k35CcLqcs4mHndGrHFOQTIGmMcLl2BFeGct3-NvEGDASaXA9gW
  Y0HG__36rp21m_UVhTR6_vzj3gOAxvOESlKT5vnXKQ8129mXQ_Y4rQ5I6eDFvDgqP
  aEWlS0sjKoGnY2UqesmqQmm3PZqbhtp78iCV8z6zTLU2ihn5W7-uDC7LgpF-H9xNJ
  t6cLmu66mInOqmgauBkk2PpddgLbge6vTUWs0UsZPc1M0WxUxGfv7081SvO7IfGwG
  fd41W_GYAPGYz0SiMU7e9MllTwL0NxlcVIt_oOiMNFA-FcRhQSrMla-pfCASV26XU
  kAK5hwmyZvU5xz3PdbYxjmJbuOby16NbtRQcHg0nu0Sf3X9Ktl7DjEk573aBLdBm2
  O649p_YqvPv0vhYnF9pW6Grno6liVMwrUsrPgzo3w15yI6AB0CU2Pa0iBQHBA5W3z
  l_RbkMcgewEzbHOJ9nNRML5yPcO0M6iPR1z9GcktbRqiXpBl6gu69JcM9l3VhIYKV
  ZUkUFVO3dfDvF0T26VM1Lastdq6OIARAMklzkWupl9UZ7Zs8O626lAFkJsGlsDh9i
  dTnqmpO4qMRNOWdbnYL1xqNIghDBtMV0PZrh1J_G9fu6VQfEQ5Wvx3YE02SalW0jg
  geEgPEJIOuRHA4DTDHCBDiHGs-GOSrf5emZAJl2Ce_jaTBtSt8lUzntQ7VBPkFKsp
  S4ODnW4_iEOkjcVmcUghwYGXHUqPnvQbsaabF6oAEkRefrIy3LfgFsefmTFOoam52
  HCgoBwinyqfpNycoX8VCClbrboW66Bb1djsIZbo-tjoFyqx7PVQaiYbwT2w1_yAxo
  rtYXbUYyZW3CKONm-9jb-oWkgm_t2YaQOrsHGufMej2bf6m6-10N3Bjxa8QDAOqXr
  P9h010zT5UvwT40B6YV5ddRBDZkxR8I6UpTb0KTpLRcR5Y-13atazYR0h_uc2XbbP
  W2qKWND4YcdVjlCJhLuB_TuUht_dhQUUgzGTPhaE5mdyLTAvfXRC-4zmjKmm14HdH
  7dGUlN4V17EU8IgvEKfFbEHcTPZ1Lg8yRTAY1taGHbYM3cMRVJqKENI6zCA19IAnP
  AR_PuAhV2dt0QL07Yxrc4ul4ZulyUbN-kCf_-wAlLlQV9Vg_IUvbiVglSPgT5-eUA
  GAsBQKHRqMErIter9vgJZ34FEEa13CNpd4AjpljTIpGrZPrNXlxkFAOFaVBOHY5br
  DRLPKJg8Ml5Kv6_pHvDWWRAUbhRHDC64gtCXtqwD6pQxwKPSzSdhmlfGivIHyHogm
  seg5wao08sIXRfhLhk0vmJ_ze_o-6QHyl6_wWUvhAFQ5T9yMEkV0JUTBCRiNw1vVu
  zWiy6-IlJITQo1-F48-mGb3cYS9-GKH1bKknMZ6oXiChxhkabR6LFhpvk4oHEJ__y
  59fK2JDKGFTzd3TnbMsmiRKh_dEaDwEGP5EzPTtf0xHNJA55j2FjjeQEH_ePVM5no
  5R3jOAHOKrq1SyB0YM0wnQrgXP-xctORiE4t9W2Vt-yi127Cr0x0icJx9p_UYnDgv
  CcTZlJxhkLzw6MdlxSFyYr0M_4hiRGxbupxB5eBBwIZ34dhW5ByLNyRWj8rCHwNTF
  cpspirebY1X4N6hYcEtoc_1RCenzO4sFk5j54DqZmtIXXracY5jyxtCE28wLqXmCk
  t80L7Mtia5C1xBUwvmgSykl3qgm1LSs9fLrF4umNM1m6anEo_tFne3yMHf8ToGEJA
  -AUFzFRCsjVAZeJQsV9ES4HlGSyEK6xjuCzp-3gvRKAlnYyd0NGubYGfx5Rz9c5wo
  BYN27wRJuL_TENsQ4CUU2FtHGQNw5Kd7lArl0QW1zUcl0oe6hsU7WNNHnW5u6P28G
  C8xObl9hkS6Bng5hPBm7GogiOp_X_LQzfxovEWStWURnw8z-i7C9vs1nR7fMi-8r_
  mBd2YCWU0cGLsyQ2sM8ERw944z-lqf8wpHjcRAll89RkwbQHEyqylwJS44JSfff6m
  kRxsiNPIEorIYl4CrpfQEp9rABpPbFGJvy4nZkseGRR82E_dibbU8aSPXQN57lqdH
  U3EhzOLXU-XjSvM-MIXaRDiJzs9yzhx-KZGbJ22YQibFiQW4dE0K7abNaL5BW6wBf
  wcuHpqKz21d9NPh5I0nmJ24C9dIsjNJbr5-S73wSRhH45uDACzwBxMeVkNmhH-TAk
  kg2MmW-fUcv301oBMTbAyDIG8bG-xer5ZQpMHsJrfYHh4RJ2IeLCOP6obDJo4BGcr
  BWV92Sb0TF50S2zyr2eRMBA3A5kZLubfyhC-rp2Vl7nu2ynJNPqjwsAu5DFs4siCo
  sUJb8LQtXyVeJ9MOzLVxRhxIsUmngVT7cvehasxYn1wyPYwKp9RwHxAcxIPbqxyDX
  g-9qguhe14tWtGtuo5s3yA05bW6Wsq7gQt-e4qDaJ3q0MCUNHI4cRG2ZE1WHsFvtx
  4Kx1w0o775vpsYRBo6gDepyrEETxUYXUqYwC8Y3HrAhDBsCd5532KzUZLqn-7R0qy
  9LCl4GvwQBAu4R-RVgIDsLIN2J5bnOa6eXRrEWyEmZq37LHraHsAM_N5AJUF8nGml
  Eg0lX6zCW1G8Qgvavdt6iPu7YgH_-u0vVgIoQ-Xh-W8v-_QA58_PUcX0GCGTKz9S-
  ZN196KnV0VNCSSrXVVwSIAVxg_iOMdlxYrpe_SR-blXK0vTz9oqUl1PHsUYv70Rah
  cEMNYJyttr15xm-VcMZoBtGbJmLkCO5xGE0RFb89uFqsPl6PnakyyiabOx3KFvPZZ
  v-NufyEwomnXs6hoQ5X5SjxT_mp80vnxpciXtUIYv1Vtvc8gj6pTBt1UFl-6cj8F-
  3RPkZ_A-8TbpIDrIvNyBMyiunvP92UwFA31DEq7WPRKCql9vUCgcvLugN3TKMugH3
  yCE5-skYyOeunuODGrADjbQ7HA-QD0kOuYj_jWhh-iE_cChNxMCwayThszb2lVv09
  qTym-_kOc5mZyfxyAAUMlTywwptOUYiLYECxM8IZpKFxRDzdQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

