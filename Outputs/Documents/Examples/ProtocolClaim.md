
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "PublicationId":"EBQC-OKCE-7PPE-SQ4J-IY6Q-XGHA-OD4J",
    "ServiceAuthenticate":"ADIR-QW2Y-YEDT-AXAC-LOWW-MHK2-VROC",
    "DeviceAuthenticate":"AD4N-2ENX-A42Q-PNOT-GVBS-DDYD-7SQD",
    "MessageId":"NA2A-OY2I-OZGM-Q2FP-RI2C-BI2V-I2CE",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MD54-PJZM-F6UL-E5GY-X2EZ-ZPLV-NH4H",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQTJBLU9ZMkktT1
  pHTS1RMkZQLVJJMkMtQkkyVi1JMkNFIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjMtMDYtMjhUMTc6MDA6NTBaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFDLU9LQ0UtN1BQRS1TUTRKLUlZNlEtWEdIQS1PRDRKIiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFESVItUVcyWS1ZRURULUFYQUMtTE9XVy1NSEsyLVZS
  T0MiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDROLTJFTlgtQTQyUS1QT
  k9ULUdWQlMtRERZRC03U1FEIiwKICAgICJNZXNzYWdlSWQiOiAiTkEyQS1PWTJJLU
  9aR00tUTJGUC1SSTJDLUJJMlYtSTJDRSIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDE2-MKMI-773P-GJ3F-YYAI-UVCK-OMKS",
            "signature":"AVvfeF9kk8VekNI1EIi0qISa7yRvOWccRXxqf2YJ
  zEotsx4ARBhGJ5GGI3KCWyy1Ejq1ZLxW2xMAcypvT6OxKRhscsvdphabQRSJdztgc
  9SYCxbU5q8N4jQ-CwMlYLQssQVi6AiKU0pOh9DzPeUiKREA"}
          ],
        "PayloadDigest":"A-z5xIvCyoCCIcWvFZGshgLRFxI6SHPXgRdYidy0
  CHfIQSh0gShhJQPm0IWemu7IdFr10Q65Qj231ngp78TK7w"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "CatalogedPublication":{
      "Id":"EBQC-OKCE-7PPE-SQ4J-IY6Q-XGHA-OD4J",
      "Authenticator":"EA5K-OOBH-7FV3-N47W-JOWD-YBEE-676U-6CRX-NW5X
-HL36-H53W-AS26-CQ3L-2",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQC-MPUZ-GTPF-CZVW-LZCR-KJRL-VVJ6",
          "Salt":"UGfYaamJakLw9-AxTE0aGA",
          "recipients":[{
              "kid":"EBQC-OKCE-7PPE-SQ4J-IY6Q-XGHA-OD4J",
              "wmk":"07bXydiQxFJzzC7ZdXvIL_xNPYWA__UKTTscClnl0JBm
  Vlw5QHNCvg"}
            ]},
        "1q7hYMf_-_m5j0skBvC8oKHay2R7vUFaLOU56SXST7mD8rYBUkKFDf84
  Andi5cOshdy7w69yEkPETyECcTVwQynLm1LWmUE6KXbvqULb3BGPrGBqiOHAbUCzk
  98iwd4E-ZrtPKkUykDc_rjp9z4Vp9HA--yaMXDqAOHuMXzcUmZP-7UL1vwgL70CwS
  POVjvbJODUhshAO51AMwFbCOvajfrc5Xzt8XqFB3LAvFtEh9DLdZ7pmLkscMyv3Hu
  gEvIUqSlbqF3-wNE-a0aHj_WFZFqMe6DrjGHNYYY5HCLikXwivS94q4RU2E6r7FHA
  gUUdrU6cioH41BbBpc461GjhwtJIDO_tNWRqKuKbiubSaAa8tkjUJCjBncNK3t1X8
  mtosHY7ea2O9qgPRPis1tvGadPmEF3DYDEU4O7O8Do7Jk6zK6CNPDdBlZWleuy9gQ
  QAbucEnY-OeP4Gd12Fcx4FerAqcrpxtUc-YdKfhEdVmNbq3-twa61x6XCJswArR1K
  rvrnWg89xg-MbVwpWHM0tOSMsChE0I9YQ-V8Hjd-8mYC_SSWMnWhfaO4S2TCchphK
  0EswzSyt_yR-0WQNAWk5Gnx4UdY-O_xz5btm9QyFVjlMU3m5JKTm4G7OsCUZdy-IA
  QG5bv7ZXgiGnUvKZp3Dg413qdOrbwNWvVBW27TDF4lhfzoSWfAsVM6y_1EAK95doC
  0GWEjTB0ShACb7H0AgwkUNuxH_Xr1annGO6z3cUdJ2Pv6h94wpFWX7tcL3u0j6Cts
  N9GMzKU4098YGE6G9XgEgsqHpbTfcS17iEMtwmWrpxGXkp0Unau7E7SQlbkXrwak2
  DSFqUjh1N4BnB4DNmZ1KX1RS4wQPfdPjpReAalWn8obGTOSZ0As1JkRKIOYfLMlTt
  BhOUEyp3152fn7MN0KvFrCd9CyrtufAxLThnymkbJAwaMwSeIK0GPfo7EbeRiHAo0
  ECbnsX1KpjLE6oOuWkgWqE19-s190NlkAQfXLBjQWW7bfaHxLves80_GE3k6mN1Ku
  vBALWlDe27TxehT5x_0Q0epFYfXtSsCbi8ZP5_czEJDqg5ECv4fXOCJEEn0cV37K1
  yOXBRUotwfw5Yi5xSLWqChE7wjdmcmB75ABBBuCrw4zkccckTAmCumaAsGSZQI8bW
  8dt7-JvQ7uExI6TdVNMfeAITyK8ZotrOHpr7j9DgGqX_QvcLarjWuurG1-_IL4Pc4
  0FaY0bx1MSqAhJmK8tNMQMO2lu4mts-1o6txpVEhY7NSdw-8PNGev-Bkgy4OjzS8g
  ymkfDPYrLnrKF15QYpS0FwGnkH1lLSgvFx5PHreOKvR86L0soFSuRCpREnE29dLr5
  F1Pvg5fXSJ1Ikw89pTox3v6Gp4H3IvCGV5RWoaqNERY6CFHV-TnQbTIlaJItsLdFh
  exW_jutigHHiMZosXTw14QcUkZqTFJx5klcZfQ6EsKede30HcttBKWcGy9ljGU_JO
  HJiBXR6aRwyCBLOAwES9FF14nvHrH5L-i57I_KabWxwvNWMsDNHcKTmN2T1-IrdVt
  9STbk-_PI5Z1mZnAWnff0HgKikH6dXg6omsQgD8ej4G87nGAJs9amn5T9pe8wslt2
  8cEtl_9AV9Xbp6UolDtRtYae0VArGneS-nCcVYVxtaOOswdyTMTWcrXKh1bMIYeOf
  zLfCIm_FdTjHIcydu4lbHZUiRm6GLs9OT_irPxkhera0r7JWjnHAu8J1EbBlhgyig
  GvqgbBmjdhJMr4elQWGxGlEaG9QfDKs4xKas6OSOGLu8WqQQ_hKIoF8rluiYLz2q1
  SVDlNAD4sEwQveUvB2UM8-jIgAf2WyWfgz7ztR3lzDqTw8gIvr4GE8Mw0jDznolAW
  NrA-LymxP1_V4ptXpNOphNr_442U03LiUeyY5w8q-IY6VJYpWIwtHGvxSeGrJt-b0
  P2amInoEpPChRofmt07cSIYW1jDljdoZ0KPZi_YJKsB7l9xiEXQQPvPZ-gI2yHF_8
  v3oNP8X3r7wp1E8AEOhYzOE0Znsvc68Qz8depNdjSkMQtQCQqnjIfcBxG3t3K48YH
  BCUZHkiE5WNzh5iq8oHHXrKx4RPf3KxQ0ahSpxE9mLz-y3-n_NnSIA634nBRnfgxN
  tfCaKqdEj4zFYv6vTlRBBzJSYw9sIpp8eusT6048UBflxyWCR-C3LOKw5Wski31p7
  Q4qvO0_cFv26pwaNnAIlU8UR-UzdPpaiwc-pj3R_9fQqK3PLqiYN-N9xjIvhUd4Lz
  WE-WVzPWEZd3BxmV98rKv-Zm3Mu4ehOZ2nH0WyrweCm7jBTdcPKWRrhQ4toh2wY7j
  ijEkDzUgfVAD1-XhTDoe9Rav3L_TLI4T-6c12LhgbB0BLuVALH8xh23CnU16fj8IJ
  RWKcc1gtTxfEqbfimtX_nvok0bWyfgr_n4kGXtCeS6Vg1csS8zT6F1bgecnHi-pxh
  swQ-KG3oSEeKCB8L3_M4nybYphwLw8GMFX6zXArm2PeUZpzc9Izec5z9pvwiRzsM0
  FKP2Yg13qxC85t9UCFWPSupvRZjHIfSK7o9gOrh6Tb-MJSgsjjHWuwipKaAf2oy2k
  KREgyyPyv0HY2O8po2kPZAVDLRU6Kgh7aymaIurR3EhHrgz_wZfcXei5GbTkLV5So
  -2PEhfJ75ayqbJK977xKtIrKy0tugcud7uFvhn2dEwQi4OEDGFThGHKhdOI-eyu4X
  xUWQyPKOlEQ8IMc9S_V3OA5z0IiwtNjwU8eIgsjVrwupLdWnSlO5UClDOrkSC9clN
  vFzYXsRo4XDT3gxrb9AsObNUc-Pk0jXz2avuTr-5rqoJV1zfTmQPNiLG4wwC4gkBW
  _3R9KqArQ_YW47cHdX8Cyd2lzubSxsZzUbn1nK1GBIE7HmE8eDM1Gd93VRrRwM0k7
  WfUCp8A-TGV1GE-3yuaWDQUmdYWSpnVQaVsdcQjDiuSSfU93n-NEP_jRrpxVYjE_n
  PKoLmpHOjVMTY-nTYivvGt0Ssqr1siwxGZiyFlni6eiuBlkhw"
        ]},
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

