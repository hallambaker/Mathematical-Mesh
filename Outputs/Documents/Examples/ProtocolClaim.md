>>>> Unfinished ProtocolClaim




A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NBIR-XMBK-4TOA-QDBO-XEY4-F2IE-PVJC",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQG-3JXE-WNLS-KULA-67M5-2UWD-DE4N",
    "ServiceAuthenticate":"AABQ-WBVM-62VF-7DLJ-JMSO-XZA7-VULN",
    "DeviceAuthenticate":"ADJ3-63MW-AKRA-EY23-PLYK-AUUW-AF6Z"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MDBD-KPML-2U5G-B5MY-7OQ7-RFIR-MSNQ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQklSLVhNQkstNF
  RPQS1RREJPLVhFWTQtRjJJRS1QVkpDIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDktMTZUMTg6MTI6NDdaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5CSV
  ItWE1CSy00VE9BLVFEQk8tWEVZNC1GMklFLVBWSkMiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUctM0pYRS1XTkxTLUtVT
  EEtNjdNNS0yVVdELURFNE4iLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  FCUS1XQlZNLTYyVkYtN0RMSi1KTVNPLVhaQTctVlVMTiIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFESjMtNjNNVy1BS1JBLUVZMjMtUExZSy1BVVVXLUFGNloi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCQP-OYN3-STXV-QUWF-P3MT-3FXI-ZATO",
            "signature":"YAYRdn4MXAQ6ORKBq0OgXlqtxVR-kgxk6xLugvn3
  PgRPWEVWMRNNAt2gS3dBfOxpejM3FiAgJ88ApQcTXVuoovadfxqFXPu4_rv51BMy-
  E2r6wUVZR26Qb6o2yVjGb5C8FjpAu1g4B7sg1YLLj0-zjcA"}
          ],
        "PayloadDigest":"O038PA1wfJPmQ28VHRX8cPCj6JBpVSpFc9olybvc
  2DtwJrBM3EJJBEziEMgDD6xHOxo-e5I2ZmMLRtnITnJ9IQ"}
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
      "Id":"EBQG-3JXE-WNLS-KULA-67M5-2UWD-DE4N",
      "Authenticator":"ECQ4-TUG6-7M5I-LX3Z-4U5J-U72O-SJYN-UX3P-G2UT
-IVGE-XV7U-55N5-FF65-6",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQE-AG7C-YK56-KLNR-RKTK-ZBEU-5VIP",
          "Salt":"15sv1ZFp31wrn_54cefEJw",
          "recipients":[{
              "kid":"EBQG-3JXE-WNLS-KULA-67M5-2UWD-DE4N",
              "wmk":"wUsbeJsCCYQXI_cGJON5wHFaR6KWGuRBvoux-e5g67i-
  YqfWgWcv3g"}
            ]},
        "RrqJArBBfD6AnzpeyQO9CdP3kXII-rL6F8QFfaKhGOMdQuFjCMKYwXEe
  nRYpUxFyip9060k9GyOJ8yCom3E8gfvNYMXf54BpBzIW0Xhp0CGPGlujdv4bFUZSH
  0MgeBfUkdpwDQIZy8f4SnVTU4eYYbXPCGhTNsFAnr6DDh35uTtWg9MtExwbOfod3D
  nUvG1Kwb_XmQzYgPi1kXQ4iNw5imXyDOuFwJbnAsEd7F87884RSJjds__df3llBXX
  -qw4nU5CfAmkxvEwYJ3-LqKNutkNsHd3pyaJS-SJkUUdJG_OwuzJKF5wZmNCpXP9A
  -RQGE4ph3VshpTfh4xjpIwIGHZCWLZiRUK8R_dweviW4OeYE-mwY2x_qdNkZxN29K
  dmP0LLZ3Gglni-LFs_wMCZQUZUSWcW8smAVm6uHHZSh7_7t3coER8kv0rixR6Yomt
  vy1aeUabVJqX58iM2xwdN3feSQUfxcp3mixASE1ji1ihRobYAE4bAi4YkbsyRqFLN
  xs5oBdpOtUh6G-kP0HPJVxEXMbndBHcPZCjKXWLJWJcVaCRemAR0XTiaVQ6zeiYOq
  2l-R9qfv0GZuIIH6J2qfLxhS6u_cRY5zilvYTGp2RsYXH7ZHjubu0_CGfw9nOUUOd
  iUHApx28T4hKxkNgmjRAJ9zpoRO74-p1VsznBiHhceckc1GSj_SrhJjGw0EJBH5IC
  6AwPziQSNwodp5UTDWmtOSnnylPtZQhDiTPGs_fDdhC7iEPEkQxJkRSVC7KO4LDWD
  ZUKQZLbZCfOAlT0fD049zEM4R_CEDmPn5sXn6kR-7QJazA3Jcv1nk1oZp-qsCrZsI
  VcdZ00APbVjXLN87XGolgh1N-37xsHjZ-yltcR9Wt89o284UiFI4KD58-hrFtn85w
  BaFZCzMPpbutDXL46NjVAvqwpCY2t8x4YaxG13NSmUQ7OgjnghwU-YI98BzLPvcxY
  5F7zUneHs_ndQSBiaZvuf509QhGc6i1DafDuGhHpn_1RerItD9BJOnoGDu1AO9Wgw
  foS8vpUFeVyBpyMKbrvJWOESCRcD5aL6-8ld4fykt8fpPcMJ6gMRLJiIaKlcAdAwD
  ASCn__TNQoiONI4-35HV4wYtN_rLFvbpS2zDYi21cIK1eNuURdcASeyrAfDZFT8Qd
  8BGSWFvBfMPu92UujYllhqwvHWZjcf2Nf4o_EKBdEO-uutqau91EsADOy3Z0ezKg3
  uzzNrUU0OM6oFVjMAk_wLiUyOfNQ1DtTi13ehzjT1jllyyKea8Xohv9zkQAxgmZ8t
  xQQEYRgGEjkA_oUBhK5SSl8_val3jHCyz7n530EFXpMdMpiXJMVRTLu5naafHGu1S
  vPb1zYcFN5AA6I9H68rQ7kKmBJFgyv0y0jEGYsDcDIKbTp_Rs36pkUc-Sve5KQRE1
  0mdudfE3k5qS7H1dJqUHiQtIdKc8-CtxwpNhYyR_lV1ShfjXCx7FNdfP1ptu2zV6F
  eKTIlejUjoMDH72j0XEn8eRSLQBafLOPwAQDI7CgG6YQoAKgQkTeY6AjxHIa1qp3z
  X1z7NKVSvIYwdnN7sy2t9jP2V_LRWF9ry6IbWuWsofq9-rcLTV96wmKnlK6raJl8I
  EcL0vJh1SU2qETaeAOkwjO833z9OaoZ-rI624LepojA8b0cp9anz6-qZ24KkodmnY
  wciVEA1FrqHgriELm_F-gwHVyYBoFl2P9tEKVtU5PmK2O2qwOPUZ8iIt6hkA30dDM
  0qgE97HAuBsfSAI0RZt_5ATVKVFI8Aidk_r0cXGNdi8R2EOE2nbEYmGX1Vp3Q_Un8
  _sVgQ0uz24QhyVvhMEtondGpsYro3qNdFKsMmW-JUEeu10-NdXulp70F6sJjeCvmT
  uMHWa6rKX43kZpyqqv8T7mL3CLLt1-rxFO_mbo9lQ41PQTjdKKt-oLC0KkmtzsJxo
  pKGRDMgA4PFSrmLJ4ihowokpWxLFCR0Ql9N4tXRptqTlG137HM00BQUYKW9gpoNCT
  3c6am-2k5ZFy275AULtTDtHuLud4uv-4LqQXlj6FsWu3wSxiTfvo3avN8-KyRcdbh
  gezDraWYVFeyz7bzgZoeoD4cxiCXpurwm5XqOoch-jNbSt8yk6X2U8ofg-IJZnesv
  rgY6ZuKPr9nZJLFKTNsH9CeHnP24G3qK5WUKi8h5MbIggbQpwAOaD_RLktuYi7Ju9
  Py_h2R0vOw0Nbb0JBVeYPnJ838yjbAz8FQ639ajk9Hw1QO7xautrFZAR-5AnAktt3
  eik3uXPtFhGBWkgm8ncsFWFe78qSVePxH8teVkx2Cy96T-0gAgWG2SKecAExf68NU
  R4-zr9I11b6gn7VzP2TeEVHkKjiXMf7_-Oy0cJHyaQkMVNGHM5qlfXWlk16EcRiFV
  vFy4rXDyLykQokpxm35-QQvVToNTbZmxR45s65h6x9j0LG8bD0ToKHPYC0PMKJfvt
  5zlIRkp_OKTTUSGIx3BGTPPVAJ7FkuvemQgYRwDPY9zJJAkrsyBipujx2naYyQBUp
  h4uvapLRRNbyjd3Fj4YrDjJZn4aNNG2m3a6LyJQISdj3FxDjeSva3DqKbdmZze9SN
  fa8J8WlQGW8d7voC5A4gXllOAHXGeUj7xxKSmbiUxHfYnUOSTBGge30WoyMLarN9l
  y4Tn6ybToUvvgLDzQKPLF1d5cguSrDwg0JgqJiFgcedQQsDVj8pgOBeQup9yzt9oE
  R1qyuma9vVu0tv9eb9xakV3AecSHx2fLlfsVd8jwe-gkHYu2_l9eBMjjfHlNcoyvv
  BFnX6aHS31_pD5i76rhzl9pS98y6HMg-O9APLqMfNJZl_FpmLEyhiske6lr3-6IbF
  fKOlxkztht9mZT9pNzYXQBl1Dz9n5B68s7CtbCjSVfd1si6WGFes4yPAqlsURIgPH
  tsrF8sNSZ9qddpfrW5LdX1fn7fptrDnS-0DfA9G90EcKvipMCdIVRpbaqvuaVtWfH
  LmGZwUfr_AZJ1XDDMaVHmUBuWTmzcWyQSTIfM5zeKsHOnSXcQ"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

