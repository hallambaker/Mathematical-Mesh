
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "Text":"start",
    "MessageId":"NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "Request":[{
        "EnvelopeId":"MDCG-C2DB-DTMH-MPP7-NGOG-AC5J-M6BO",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFBDLUJXVTQtVU
  xBVS1EVVNaLVBEUDUtN1FPSC1INTNMIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA0VDEzOjEzOjA5WiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6211},
        "Received":"2024-10-04T13:13:09Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MBPJ-WHZE-K6ER-A5BQ-QYGE-3S57-AEIQ",
            "signature":"ons7x_lwfccbP7aYSK12VXYIO8R680SX3ysbeH_7
  E_FDd2IXEpRZ0qdWg94mum7IfqOnyov-vIaAtzS1FffkqHxX6y4B6f2XzbZxpquFh
  Ph94SAZ0nKul5CcrwZeN8Z_mJPGaB88lv5fprqTA1l8CQ8A"}
          ],
        "PayloadDigest":"Qgw2qH88uSnz3QDvnqkhSfpeYbM6bRpD0gjVzIVM
  6K0NVrx_q0V53xCu7ig-0RANLqOv_cNdUmUY1fMNmKoPtA",
        "dig":"S512"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIlRleHQiOiAic3
  RhcnQiLAogICAgIk1lc3NhZ2VJZCI6ICJORFBDLUJXVTQtVUxBVS1EVVNaLVBEUDU
  tN1FPSC1INTNMIiwKICAgICJTZW5kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIs
  CiAgICAiUmVjaXBpZW50IjogImFsaWNlQGV4YW1wbGUuY29tIn19",
      {}
      ],
    "Accept":true,
    "MessageId":"MBJK-3QH6-T4TQ-WFOK-UUZW-5HOI-ZBK3",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com"}}
~~~~

