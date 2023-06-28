
The service sends out the following request:

~~~~
{
  "RequestConfirmation":{
    "Text":"start",
    "MessageId":"NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H",
    "Sender":"console@example.com",
    "Recipient":"alice@example.com"}}
~~~~

Alice accepts the request and returns the following response:

~~~~
{
  "ResponseConfirmation":{
    "Request":[{
        "EnvelopeId":"MBRF-HV6Z-UAXU-IUP5-4B6A-XIRE-UHGZ",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJORFRVLUlJUFItTD
  VTSy1MNkNaLUpKR0YtWEE2TC01NjVIIiwKICAiTWVzc2FnZVR5cGUiOiAiUmVxdWV
  zdENvbmZpcm1hdGlvbiIsCiAgImN0eSI6ICJhcHBsaWNhdGlvbi9tbW0vb2JqZWN0
  IiwKICAiQ3JlYXRlZCI6ICIyMDIzLTA2LTI4VDE3OjAwOjM0WiJ9",
        "SequenceInfo":{
          "Index":7,
          "TreePosition":6224},
        "Received":"2023-06-28T17:00:34Z",
        "signatures":[{
            "alg":"S512",
            "kid":"MC3L-5Y6X-X2WA-6OAI-S56F-HNEV-R32R",
            "signature":"351CsK0q7VJWGm-1YuvzzxWRCTVOCqedM6F9CQ9j
  kCflfv1lJz43P6xg-xB1OQRdc6e92zgfv3-ApGteIPtv5vylpKo6EgzXGmpMZC3zA
  hymQesHMqsfGW-QyVk7460UhBq3sdLg1QCX01_Q_TgHUzIA"}
          ],
        "PayloadDigest":"hrg74rSm8V5zkdPOkn16W30g9lP4zANIh1OhtHp_
  XDwTGLtrDyDbp2_6Y3HMVylrGXB29fxxf0kppinWTsOHjg"},
      "",
      {}
      ],
    "Accept":true,
    "MessageId":"MB7S-ZUPK-XJ6Q-N42Y-4UTW-7CQI-33HL",
    "Sender":"alice@example.com",
    "Recipient":"console@example.com"}}
~~~~

