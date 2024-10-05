
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "Text":"start",
    "MessageId":"NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "Request":[{
        "EnvelopeId":"MB2P-CF2L-7MG6-LDVH-2VXR-H2B7-G6UZ",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQlVYLURPUE0tSk
  pLRy1OS01WLUsyNEctTVgyNC00UU5XIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDI0LTEwLTA1VDAwOjQ5OjA3WiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6211},
        "Received":"2024-10-05T00:49:07Z",
        "signatures":[{
            "alg":"ED448",
            "kid":"MCUU-PIM6-GR2N-I2LZ-73EP-VUG3-EHDI",
            "signature":"eEJ3Sr3wDovIzX1tXYJ9ql6bhtQ1MQZfasMn0rMk
  zrbU5kJlkZV8dGI0Xqmgaj7cJJl6a0ZvB0wAdSNXVHaHpfJK4o3sWGuYDcSABBrUf
  PSbZDui_o5nYS5K4P7mViaSv-QqN7mtbOIqsB-fh-qO1AkA"}
          ],
        "PayloadDigest":"3xSDdAkzmpAej8BOI4hZToVbI81T44BiyQCSlRgq
  gvvllaj2q0-oWiOOXGPPTMXZXzfmvJOzTTxIPhA7c-SR4g",
        "dig":"S512"},
      "ewogICJSZXF1ZXN0Q29uZmlybWF0aW9uIjogewogICAgIlRleHQiOiAic3
  RhcnQiLAogICAgIk1lc3NhZ2VJZCI6ICJOQlVYLURPUE0tSkpLRy1OS01WLUsyNEc
  tTVgyNC00UU5XIiwKICAgICJTZW5kZXIiOiAiY29uc29sZUBleGFtcGxlLmNvbSIs
  CiAgICAiUmVjaXBpZW50IjogImFsaWNlQGV4YW1wbGUuY29tIn19",
      {}
      ],
    "Accept":true,
    "MessageId":"MDNA-3FWM-EU32-YVSQ-FETM-AFPL-QNW5",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com"}}
~~~~

