The request payload:


~~~~
{
  "Transact": {
    "Accounts": ["bob@example.com"],
    "Outbound": [[{
          "EnvelopeID": "MCSP-G7O6-MCSW-5CUG-QL4J-IJCP-6GIT",
          "enc": "A256CBC",
          "kid": "EBQD-VIOV-AKFE-OVWB-Y4F7-TSQY-OFCU",
          "Salt": "F6K_DtcU8ewWkfu4tQY-qA",
          "recipients": [{
              "kid": "MD6N-MTZP-LGQF-437L-FNAI-TJD6-MDKE",
              "epk": {
                "PublicKeyECDH": {
                  "crv": "X448",
                  "Public": "QnwJpe1ZXmJPJq5KpcBXjT2IQx2iNSUCwq3v-2Rv7ot7kChvn-Ao
  3a_au4Z-R2xBedMuIku91hQA"}},
              "wmk": "8ApzcJcDL0YMnhW24fwCLtuo83sHKSNhybjt_GEyRTdlmYJZfTybAA"}],
          "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJOQ0xCLUlCRkMtNUhFQi1
  TWkdPLUZTNkstSDZZSC00S0JYIiwKICAiTWVzc2FnZVR5cGUiOiAiR3JvdXBJb
  nZpdGF0aW9uIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAo
  gICJDcmVhdGVkIjogIjIwMjAtMTAtMjhUMTU6NTg6MThaIn0"},
        "F8sTWQs1cu6xO2hNsIr4n9XkgLDKF9zEi4NlJo6vcQ_
  Dl1cRWLtK2YFNjt1-cgR9BJNJrJ4AfG-mESqIcVWSnS5UwaTXCn1dUrhBkfXSx
  1-mLwvF5fOge04UmAQtd-BW3Z5XnGr1PGhteHUYNlwwFr03o7IUe76dFBpN9V2
  SGYzFrRc3ipueo3O-qT4TSPnm_Yu3JlluPO8Gm4PmDCaHDNfHOZn1ZRMQkjYAC
  J8ibgKCgPoydPqAYVRE1AACWiMz1uA9uG4YazMDqGn6m9bCa5X-OLw0qxntN92
  T8qpXYialJAnm6Tt10JGWQ01fueB_7kJFUpfrFBS1AbGiLSCkpVqkwkwsoBB3M
  1czAAf1Cr3c-tnRZ2fVi7Delkt_MiEH8pJdmxVK_TSqknKNK-aLJ7jRDsJo8IO
  PSOe5CMmNoCB6-gDZqZMqWiHth48_zuaQatZwALE6eHjQ_qKq0hxBW2kVbtKit
  zOVzPlO3wjzYyCqf9qERZlTyvx-Emu3OK4KiRnlhFBJdexHeSOEvinVV7GpkqI
  Ok1ospFI-xe7Jzo4KAqPVWXGcYlfs82QCntALIDYM7KduDReJAYVgw-zTyBTSM
  NTTQ6r6iO6o3QtmruIl9I6NCQTZ-SJoatUOXJTzozehlzUGmNR4VvFvEo4i6ug
  AN71ZHlxzEVtEtRLbtw41KkHFp1V7Q2mULM6j333Y9_lymLn10s1b3c-PlnV8a
  6qzNlcjt48oJQmkzODVzqJVSt22yUn_fzg7K-8zAtA2aDaB2YUs7uFU7EX1Zmo
  SgsBSLlvwJJqR4B96UKTdSPgNlKv5JiC68K13Lksg_F7Dq9LEMuP6bztOc0p_k
  t3IxnpEeMAGBLwtKCusxxYWSeOynnQdWw1VeOLdTr7t5JVlk6b5wKEGU0Ena5B
  _bFdz2qete6NwwsUWU5gH_VjYwmdXkNQufu0dKrFqtBQbF6LZUwnZItieRyHNY
  Hnvz5hsjtcgixib9XOCMyfTWJkpZru8SRZ0nWkyO7HKkkgGOiq-rpqddmxAReH
  psq9mVdcdNwpMc2umqZTSAoEgPFJYSTyCr68frmiFQcOoM7mfAcC_I9jGPqqqt
  YzGSGoNropaIUx0JiF1oY0A54F9__9VDChPiTa7tmluhXWuTQrL72zDbUeoFl4
  CgRKF4Hn8MfZ6Y5iOnDq08ZAJj_oC4zoLYyig9DoIv2ftVx65fNWTatrSMMv-W
  Vq1akVDMZIqAQ6nQe-j1SWqt3_000sT7TX6eocwxL1T3OdNSFrjBstDIVe19Iy
  vEtAiK5RDa8CpBxoWdaAKgIG8qkrYLQBbi4yAVU1C02yonvKqvJLj9Dvmv5A_k
  GOgzaqbf-8YAFvUKjhcci1XpQj1nc-u8AsZB4tEdmP07EjVONWhv7pripHw9o2
  ROjTX8n5kIGyjfm6nQgwd4Z_biK9DZrdmOyLFN680pFnUfyGMXRh7WmJr9rqvg
  ipDU6ZaLo2a6xnERbZ9VkoAKJJih9eMwrojgBmKjIEeRKuBQNezSu8j545SJak
  IELZyO3UubyK4AbZuHAIdROtr4J63p8JxgD_saq9anRLu7hsd08H_thNjAeJ6k
  GgTtYUC_ZTcAULhkVtQyOYMdYXJdlXBuBdNI65I-UI3GUvIUN8r00Qf3J11kyk
  lrCcD9y8VA2Kk3E62rzx-jsObtAQRPitM4ExVmqDygIVS2O4LJbS8cnstPbYj2
  Z6EAzJ-7pOX1HHfD-JW1iwcYSJThasA5rwYboWiaZkUKnH43cwc743aZwC0C7q
  wrGZzAnBlmC-uhwGOBpxR8al7e7NuYyqf-YBElWy2ZA2iL_AQUWC-qSbi-lwPq
  83BzWfsMWaRFcjscn8ECaEiO2iTLTZC6Qvo49XuhyjybWdCtyjNokReGnF0eru
  0Hap5bj8_LFSTqXMqpe1NLjUX2qodgnSyDLqlUePAzQww0C_nRqyCv8OysyfgH
  ZOcKNpeA1rjzRZUWUA544vFIa-ONAd1MtWRWb_odtMJ6A0b11nVRN7qSXpp69d
  rNXTQEdVOmnUxblKC-G3O4D7GVaSEZERG8iJtLmQeaPV2qdC6fcmpyd5vp-GX-
  EObvC7A0lFh0pZ5ocGn6KZaAGSYPQKN2gdcaMeFBCpvkGy_873jP91ITLoaVPl
  VCoOjWGolNNeEVcgGMwbsxd1rEciNYKSZKdjQennJLryAY7tvMEJZDpEBCRtLL
  RDeqjfmI2EUR2k2xt8bki5bCLfsBR4YSF5inbT4Uo-A2gf9WyovHrrHsKhJz6_
  ty2ffwvGGo0TWZpRAog4xz7j3iC78u7TsrvMxS46ZOgEN-GDydeJ08Xl-kldKf
  OPTl1uW_lW_7PkxBQcgvDhbiJ_Ql60VxTz9v0h9q2JIfGbGCwuu2VabQdOsWMd
  BxU7Nzvt6UKqSAx9Qg-3fdxoWgfAjxiq5KsGuxp9NR3ecUUX68msMaUhhAP4RZ
  HCwIJE4VpV8btGMbiYJPfxhWGtVVCWUynpr0QU0cO5HeqSy_noOgVtt_8XSyMr
  V5IOX-PBiDVZlWogomYkiu7w7-G6izmzHkWnjkVy8HHOKkxlObzKO4ILiBo6c7
  Vv1Ym9jbSzvkeLkgtweAMl6nQGPfXg5cuXARBDp1L2vXZuKH7q6U1kdGViz4o5
  A814XstszsthFnJ1xyl4pkp7uBcr-l4r1G4_1T1TxvI2mcX5RF-TyHad4IXxnh
  YkpKTMWSYZAwdm8SR7FGJFDd3dBxdd5RPSGAYHdG6FsHtN_SyBcOrPqMNAx_Lf
  I7dBU1xHO0yLaZQ9BQmy0TPsUUCHa4NDlYAqsdCasLs32bO65lR_sdZwZRm_fN
  DxdcZ9cweyOpDI2IMx2nrscSpa9_UmR45dBchTXQnkx_bMXBLyhS0fcrJKN32V
  Px_l3dcuUhoKwd5UREEO62DT0tB9j2eohsr6QKOOPrzLzsV6Vd15mSTbbeEEk-
  kNwv8WGeUa9rhwEArDoiqlX2EnbD8q5Gl7JIW8WTMgEJMZWViacauphsPSM-JY
  1y8YM6UddbnEtxPfO_l9WsNtAxpGi9ipnxPkGfAPJKHRqvVSeQDqz-rS1ITvuM
  CvRUSvvqqwdhtJuy0JdYnuc8cq4ICohWL52INYNkyHkzqk5C0dYQ59IDsbCOUN
  IBdktF2OGewCQ0pGqnaiWZhhpv-gMJk6CpSjxJG5S5kpevt3OXTl5HGB2PpmFk
  GW21WlXYFr6FDTA8mo4dE1Le3uPa0njUS8OdcSuVvBZhuXcp9TXpSVdRR8oHHl
  EDsxtjQIGpdK4yN8FkP7O3QjH8-r0slxldR7JjDH_v3JkfI4-Qe3KfvNgSs9Wb
  z_pr-xyyqAfaoMRJc_1OEe19JhL9dRLMiyWFbodj5rdJ7TSrCV81Onuhnz_iLJ
  JwUEjegSgMF4R_G9t0CXuXVjX39RgohTaRLq5Bx0iQOAJm5khkCEBP0m7XsLDi
  CevfR1EEUij-8YrDGUbBmNAikdcM0cnQYySX44WjMEvK5PA_ejEwdtjDIAppRZ
  a22mu6OCwGZqZRfmex5XVaUvOkVo9WFZ7uqcTmy9WmMqCJ_hunwtmm5yNQPBBR
  sXXlNze6WfRcS7YyN5OW-tsBNHyHeD_XHXCv_WWrwGa59RKfbEGs6svG8qqrrB
  ApoE4uVHDIR1WUlYfjy0Fhnwy13gSKjgIUy92yZh9Lk5401AYCkmV0HqdHXFkP
  NxUN48LSSNf15M8PiDQP3NfMjs8uylfaeB0ntLVEFOYlklK5Rhh3STpUngMZUX
  U91I6JzLQV7WaKJ57d8VV5U6XlRnUKaTrOc9IYI-8qQhksVMbbSOjN3liNqvgb
  mt3eBbuGmxtM9cUm-4G4h_ELCasKUXwJxmKrXNMmjpTNEVdd3Pr3JGVuVljOlJ
  K94r0zLttG2QqMoIbvqIpTNxVYM8IAPva82Uc9bCKg1_iu8QldO6n1MIz8j5hN
  beNrlCmmnR_mfcZmASmloY7F_h_9nsqlJxtHMZ-PtCix33z2ao8XrSHqRScHSs
  AmcKqRXuA3bvcYNrnIThY_P-Jj0qtYNUtPym11xBOzEZBnG1cXbuAUNgFT2bjb
  KxO7qDlnyEnkhzu86dLbxOveuQqXTjD2LLsCB4_HpJqDUTW5JA_F6gy2kpDIJ7
  XnNyI4Vp_DXasdlAZFWl5lTID69hYT0on_nzGV1d0i2ehPVCei8Nao1VGgslYQ
  vQ7cA4j4f05-hZSlLqNwpp80Ko6AlE-Z0Nd8WgtN9LylcWkU-c72OstBDPsgAf
  rbwx6nhJnwns7szErTrjRX0aZvm0Uq9EojwtKbpfJFc7R2QZyHw"]]}}
~~~~

The response payload:


~~~~
{
  "TransactResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~
