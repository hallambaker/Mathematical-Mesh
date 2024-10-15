
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "PublicationId":"EBQJ-VQU2-NBCP-XCDF-PFWE-J5H4-BR26",
    "ServiceAuthenticate":"AAF3-24BG-U75Y-3GT3-K6NG-KXWE-QCWA",
    "DeviceAuthenticate":"AD7A-4KSW-37QZ-JGT7-SKGV-KZH2-36C3",
    "MessageId":"NB4P-XQDR-JVO4-MD6R-47BZ-G6ED-J543",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MCET-4P2O-3PEK-4PCH-7HGM-N5RL-M36D",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQjRQLVhRRFItSl
  ZPNC1NRDZSLTQ3QlotRzZFRC1KNTQzIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjQtMTAtMTRUMTM6MTA6NThaIn0",
        "dig":"S512"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiUHVibGljYXRpb25JZCI6IC
  JFQlFKLVZRVTItTkJDUC1YQ0RGLVBGV0UtSjVINC1CUjI2IiwKICAgICJTZXJ2aWN
  lQXV0aGVudGljYXRlIjogIkFBRjMtMjRCRy1VNzVZLTNHVDMtSzZORy1LWFdFLVFD
  V0EiLAogICAgIkRldmljZUF1dGhlbnRpY2F0ZSI6ICJBRDdBLTRLU1ctMzdRWi1KR
  1Q3LVNLR1YtS1pIMi0zNkMzIiwKICAgICJNZXNzYWdlSWQiOiAiTkI0UC1YUURSLU
  pWTzQtTUQ2Ui00N0JaLUc2RUQtSjU0MyIsCiAgICAiU2VuZGVyIjogImFsaWNlQGV
  4YW1wbGUuY29tIiwKICAgICJSZWNpcGllbnQiOiAibWFrZXJAZXhhbXBsZS5jb20i
  fX0",
      {
        "signatures":[{
            "alg":"ED448",
            "kid":"MDNT-WT3G-346G-4I5T-YV7F-LTQX-PSNT",
            "signature":"z03VvboD_IvshEuYEuRalFRGERvq1vHOJIWJzPNU
  gwLURsGLxxtfjE_1JtNWYe8kndOhVJo9_46A_Vx2DiAZ4ngzzYXoSpqAFgz7Ejqd5
  s1B7K1ehk5ToIK0oYOGoQ--npioQHEccyfUrQalwe76zx4A"}
          ],
        "PayloadDigest":"aobSWyLEGCMF0JbRdOst2LQPvpXI3ZVd45r3sjaV
  uO0FwMNtiiCGmjArENV3rVarWEAwLGBVYhVnpqw-S43pXw"}
      ]}}
~~~~


The publication is found and the claim is accepted, the publication  is returned
in the response.


~~~~
{
  "ClaimResponse":{
    "CatalogedPublication":{
      "Id":"EBQJ-VQU2-NBCP-XCDF-PFWE-J5H4-BR26",
      "Authenticator":"ECMR-LTTI-XRTX-EXOY-K7U4-WHBZ-B6RQ-EECF-S44N
-ZACS-OPFF-73UN-WOHB-U",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQL-OM6D-RFHG-GGS3-DROH-6PLS-MU3G",
          "Salt":"Y5tvWUmCqp4z2DDdAWa_tw",
          "recipients":[{
              "kid":"EBQJ-VQU2-NBCP-XCDF-PFWE-J5H4-BR26",
              "wmk":"YfJu1nJPXW1hRH7eDes_N9LMAXai-3hjO9uUKvFpC2MY
  vZQllFjIhw"}
            ]},
        "6HQDAIDsWjnl6nkYcLwyXpNcxXCgsEq1S9E9M2FiLYImPgefjo4baMQL
  fQWa_Al9yjHLNSziOPidvQ-tpk-PmhrtwzAC4-9FC7AHPyicqzTk3dtsRLigqi9mL
  VW02h1zrJnTR8sHkt_WO4_FrmkqLHeTsZlqXm9No78UINGHt_ntffBd2NPwfiejkV
  l6X5DA_CxwPZdFS3cOUORyJjgMCKcrbast50u2rGieT9nBCGAxqMffwK5T35eRGKS
  OLh-92hXRF0K6yM1RBkXCTpCFdz807NnJPXiY1kwPwjptPVwTNsTgAXMl-IqGuaM5
  Qglj4thR-OnQgDui_T51VAKBaICGjYbsGsq9XfJlrrQf9VJIVQ42C3REPaE1a07wI
  USLrjKxEgT9K13Y9BrP47rI43Z-75rC60C0nA5gzFQSlOtRt8LdcN_sX-JN_maY7M
  hZCVYdehKxUgAUqCt5MHuliQA4atczYIyDbUy2o31xj5vUtL0cX7MSIDu3F26P3w0
  jVwDeNW1HfCs33_kqQHzLATr6vTwsgFkwhrq_DGbkJhGAiZjGfG-9s4CEckUUByDr
  Qu-umCAsnIWHPeLywTFiOtE9t7oPD_C1oIzf0MG0Jxl4CCS23X59lIrQzba1a7tXs
  6oCJtSsPqLVdIHzOW0pK96725VLPnBHwo2DcjM4aWHLqr1dk5WGrSNBgeT_y6hH2y
  pE6xfeh57oTxCX8S0ThzKrm7nnVWVxBKE9YEyWJExEBqJEbiTeQqk0RwhLcgb1ECN
  DHuwIe9FWwfJOltyI1bja65EzBKiJrHLF1mjJEZIlTfLzzH-49Mf4zO9N6pdO_MmG
  VJJw_WvZZ-aBHoGLtP6SLLbAFPizSX_-io_eqIzmAnDLVZUJXNpHpUad87tX7gSJj
  J4J83E9vD1sA9BYzwRZiX6aRpaUxn-8Q2Af9Po4_mOjZPMtwwWrk883Wpz23WiIxf
  pVOPVazd95pqCdrQXLRQbTE-xa8ZI5uPz3vtNdiNy5I7gMYzANoU764CAWjVap8Fi
  dQBlALt2rEJ6fG87ulmYcmP-D3aeh9Cs-0r3mBlNWZnlf7y7yjfKRGmQRC6QyPToL
  kdg6bXAxpf7Mxao28VCcClTKsdr5IxknIZiarsi6lqOgYvYS2hbC2fnuSU6cRRAUH
  7EIVS--7nDLYtDAZAoS1ZEkAbc4R6Qq5LeDTbW3I9UwjhY5d0wKeQh_6MBzU4wUAV
  2kLDaOFId5PEYJMXdo2OwKTv6IGMEx7umcM0TReGp8-uqElp2Fp7VZGzzeCI4g0_C
  FsO3aY_uyHBYLZq9JiHgDG7decs0YxOzHmpiYaMqgCNkfJNTsbJ1sCUdTXabUM5Tp
  JB2UO6uetpl_oOoA-vKGcQMnzMIh2S-mm2NsVkZktDinBjnwb_X3EyPVBUybKj8RC
  K4RN5clEXb7l-ddQqIxNZlxUd5o3XyICYMGSPvq9DiXktnpnH9bQDhHrdB4_r_3u3
  XENxlytln3p5Cwk37pJyQTYGknmLtmyNFGWo_RVUZCivnT5OEgkUm1FkTdH9xZ_WF
  JwEs7Yxt9pRQQKFj2AtcB0DqeGtOvJc1eg1z51xe-Le8tkBlQzz4XS58HDrNnrlw9
  QSaoUCEP2sO_8M2SgCNBkeFQO0EAf0pdAClJUy52xyTqSJo_FsjJkE0h1wnSxxFd4
  SMRiGpbpGh1VxzrWgM_3txrjk8Sp7OQqzN3kquc2OS86PuZfDOBEsq_-gr2pLNGGH
  xxZ4EW82TUgynRBohITHmYwGfisUx0YWtWR2ZhlS-KyvFaNCE6hdN2BwOtdsfouOO
  xjjOZfwiOxFx0MMkN2WSoocXxS1HudynfI23J5FWfJRhWpsDXfcOznZ2kAB014Kj5
  MF42ZusxrHlRTnHQG3OmfcW6NnoyjOPXjiGk-CgHVI-P2xZi77xbr9okZlW7QmNvE
  ZZtgYZosLWc9QdLEnR17S8hScjgDC06ByRvVHKocSs-CdwtjfjXBAXitJRkNryzPr
  NOaYMLGhrMLeMA1X3eVfyB0zEyN6rEndnNwquqzevvV-J-p6hfuVVAkEK1ya7Suo_
  j_vDOXtuX2mBr0l0DkkdgYlJcrLX7Slb6G40vVDZPmd2aQbB3ZGExTEL9Zlczp7T5
  2fuK75lnbn9Osd50BnuSZ_LBGmpDNp2IxPqz7nel7wMEZW0zEyw_RAGqrzWLasi4t
  GovT0VNI4oc-h46I6e09eY83RoUwVNfgy9WSCR2Fb1fubqURgTkoOdptFAVy2Efel
  gRaWoaSnnz8xo8Pt2JAb1zRiWDgBrICe4QelPRlokNrAORCMBL2_GgWd_gv9h5Hrl
  gumJOmUiae8Iar7Gh08VzlYwk5JqA3xX6ooy2rnTKTJjKb9UdeApxooHvMnwxdnK9
  A9LT5vbKYIQEcyOm6A3pcesJIUy5CF9fHsOvh-tS4Hg86xRoq1O6UEInwAJ7P5l5s
  9Yh9Ge6EIq7JoffWFADCD0TN2MqrACBDdsbblE2TeC5nRJqKvGRv35j0PUVxCozb5
  tEpj__CbXzJs4PrtCeu96npz6JTXesUIYNuvQD-7MkHjuAI7A-P4KrER14mjfftwi
  G6TlF9CMAhCTmDcFg21g7xtk_Ku6CA_diXU7dcjHyXzy0nECoTPzyJYBkoy22RLpu
  K65JbMR8cpDjB5hyYkiuDtVGRGcGpWWdq0qJPaXwIl2rmEHnjzzOyKovXFJyzEhmY
  m5jYwHbRhtBAUl3zZ5A5xHKi05OyDeiOESC7gJaISHPi0cWxIRc7hZ0VZ0n2asMi2
  kW5ddh4MyLSD4qIwgCB5QC8CdTOoG2mM4PLgmJ1bLhi7Wkr7ndAPD4TA5FyPUD8L8
  LjolfOQWwJfSe6UknbDYcRnUHVRp689OwzIPMHV00fxkK7ZCbL-Kcg8ea9oaZ-s5v
  _mkv7KMCed3B7V38FokYxuw1dVZODgxthk2nahCZ-cxAkgqgPDIuTrITIeqeykJiF
  UZRAldM_781GmMr-p_8HS25QVht"
        ]},
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

