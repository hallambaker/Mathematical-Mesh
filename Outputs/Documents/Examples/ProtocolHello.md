
The request payload only specifies that is is a request for the service description:


~~~~
{
  "HelloRequest":{}}
~~~~


The response payload describes the service and the host providing that service:


~~~~
{
  "MeshHelloResponse":{
    "Status":201,
    "Version":{
      "Major":3,
      "Minor":0,
      "Encodings":[{
          "ID":["application/json"
            ]}
        ]},
    "EnvelopedProfileService":[{
        "EnvelopeId":"MAWW-D3T6-T5C5-P7SQ-QDYF-JGD7-KHHU",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQVdXLUQzVDYtVD
  VDNS1QN1NRLVFEWUYtSkdENy1LSEhVIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMi0xOFQwMTo1NzowMVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1BV1ctRDNUNi1UNUM1LVA3U1EtUURZRi1KR0Q
  3LUtISFUiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJzNUQ3NThrVkRXZUUwcFY1eXAtU2loVlZFdDhXaFNERGdldT
  ZDb21HbWdXUEdERy1jLWYzCiAgMUdRejJvWUoxZ1RsTUlkTWw5T3BSdGNBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJO
  TC1SWDVULUJPR1EtVjQzSi1FTUFBLUFCQTYtS1pKNyIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAicnpSQmV3RExFRzZ
  3Y1UzdjNKZmJMUjN1UFY3LUNXWDRTU19UTXlvMzhYb0FNN2lnUkpPcgogIFM0eWc2
  RGl6WEs2M205QUlHbTNIQkxxQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUQzTC1FWUhELTVSMzMtTFJTQy1FNjNJLVRIVjctRj
  JEUCIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAiLUR2b25Ncm9jVzVNTDBzTVZXMFVucy14aVFBcWtTZEtJTGplMXp2e
  FdWQmpRNHN6OXlSZAogIG9QR01hZ3BkdnZMNVpueXRxamRwTmxnQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNQUNYLUc1WlItNU9
  JNi1YQkVDLUZRRDYtUTRMQy1UQVpYIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiYWlObVl3Y0tQdlVyR3hJa3Q2TG
  c5UEhCM05HWVhDbTlkSW8zR3djd3ZzaWJ4VjZvU09ZNgogIDN5SHVLRWFaVGpfSW8
  2em9XTTdaWUZVQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAWW-D3T6-T5C5-P7SQ-QDYF-JGD7-KHHU",
            "signature":"ZpX7SIWIUoC4_7AHqNAbaDMHnDyqowwEOinO17bC
  wck7JRlSzzBtacd3hIx9245pYe53tkwF4gaAZozhVPycmVTuT303zzcmnfYIK7Op2
  RtvZNQR5kk-bZmzqPiJwJ8KLvS3paSkOfZi-UFiAvtEID4A"}
          ],
        "PayloadDigest":"cDMerx8FyT6T-Z9mUqJR8Ih1ZN5zZCdT8rt3qNv1
  _NKAsLOfYlUdAvA7CJ3_WdRqC7QWRPcVLaO5NqiemWJR4g"}
      ]}}
~~~~




