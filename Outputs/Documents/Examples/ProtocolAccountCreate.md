
The request payload:


~~~~
{
  "Hello": {}}
~~~~

The response payload:


~~~~
{
  "MeshHelloResponse": {
    "Status": 201,
    "Version": {
      "Major": 3,
      "Minor": 0,
      "Encodings": [{
          "ID": ["application/json"]}]},
    "EnvelopedProfileService": [{
        "EnvelopeID": "MAAU-NKGA-OXBB-Q7RY-F3N2-EWGC-IF2O",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQUFVLU5LR0EtT1hCQi1
  RN1JZLUYzTjItRVdHQy1JRjJPIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiA
  gIkNyZWF0ZWQiOiAiMjAyMC0xMC0yOFQxNTo1ODoxMFoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9
  maWxlU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1BQVUtTktHQS1PWEJCL
  VE3UlktRjNOMi1FV0dDLUlGMk8iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiO
  iAiRWQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJOS3hvOTRVMzRWQVhBNEY
  3NjdGZlRBaU1heVAzaDRjZXlsRHY1aXF0cjRVQjBFcGdEY3NvCiAgZ3NaNDZJd
  3dZaDdfSUpBdVhULTREWC1BIn19fSwKICAgICJTZXJ2aWNlRW5jcnlwdGlvbiI
  6IHsKICAgICAgIlVkZiI6ICJNRElQLUtGTEYtRlZNQi1OTEQyLVBNNkktWlQ2Q
  i1DUUZWIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB
  1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgI
  CAgICAgIlB1YmxpYyI6ICJQeGlwWHo5OWlhSXpib25IMWh2N1piN3VQS3owcG5
  3OE5nNWNIZFZBbXdXVEROQ18zUHhzCiAgVmwxaFdKZk5MOURYNzdpZUxhcTlXZ
  3dBIn19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MAAU-NKGA-OXBB-Q7RY-F3N2-EWGC-IF2O",
            "signature": "qiL21QJm7yVlX5iAS-3ImGd_wDXZuYNvl0YFjTw_FHPiCxK9D
  OdPHED0QaUh7XJhZMn84FIL7x4A3bbyAhi6UfpQ8RzVuz-24JD1uwwOLSlFPTH
  V_lzh1o0o2GeZ8AS6LGRqMzd5wrzAoXsFEEENwwIA"}],
        "PayloadDigest": "0cxxaZsvUx27O5QtWR6gR6w1g_F4-ZQSHujfAGdS8lryB
  zrHlF6-a5cT9NxP2KPuqqxpFcu5LXOu6ajUhNDbxg"}],
    "EnvelopedProfileHost": [{
        "EnvelopeID": "MB4H-K75L-4MAC-I4QD-COEJ-KMFU-PEQK",
        "dig": "S512",
        "ContentMetaData": "ewogICJVbmlxdWVJRCI6ICJNQjRILUs3NUwtNE1BQy1
  JNFFELUNPRUotS01GVS1QRVFLIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  Uhvc3QiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkN
  yZWF0ZWQiOiAiMjAyMC0xMC0yOFQxNTo1ODoxMFoifQ"},
      "ewogICJQcm9maWxlSG9zdCI6IHsKICAgICJQcm9maWx
  lU2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CNEgtSzc1TC00TUFDLUk0U
  UQtQ09FSi1LTUZVLVBFUUsiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHs
  KICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiR
  WQ0NDgiLAogICAgICAgICAgIlB1YmxpYyI6ICJqQm5tbUF6dXNZNFZlc0Zxd2J
  4OTJtaDl6RmJWQ2xKeHZGVnpfS2hxSkFRbXFsSEVaWVFFCiAgNWl3VmFqRGVyd
  DNWSnkzWGZMR2k0NlNBIn19fSwKICAgICJLZXlBdXRoZW50aWNhdGlvbiI6IHs
  KICAgICAgIlVkZiI6ICJNQ0g1LVhRN1ItRUtFTC01SFVXLUZNUTctN0tYUC1PT
  01GIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1Ymx
  pY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICJTOEg0a0o5OE9vMktmN3haZUE0VXZ4Z19ud3hZVGRRZUc
  4Q1NSMUVPRW1tcFRIR3FFZDNMCiAgNlRRZjI0WVJhTG5nWnI5RHd5a1FRbXVBI
  n19fX19",
      {
        "signatures": [{
            "alg": "S512",
            "kid": "MB4H-K75L-4MAC-I4QD-COEJ-KMFU-PEQK",
            "signature": "tnpp86uHdIQzogmi-Tx0pTFUdNNuL7PA4imLOHxsBAOlGnUkU
  YCmXNXxL7eCH96rqYogYQ1MuACAjmstnCOxJgafg7shHtkDQoz23kkFri9wJbv
  87IL4y-bTr6g5C5B-mQg06a94jZtpqDTC9V38KyUA"}],
        "PayloadDigest": "1XOueB_8OtgTrA4R5iIstf5tmjKOUJ8l6RlQxZ96RWXq4
  4hjnuJrjUfQDWnCH6QloulhN6uLWg3ic4SSUFAlkQ"}]}}
~~~~

