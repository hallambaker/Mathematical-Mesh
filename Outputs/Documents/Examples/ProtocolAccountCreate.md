
Alice requests creation of the account alice@example.com. The request payload is:


~~~~
{
  "BindRequest":{
    "AccountAddress":"alice@example.com",
    "EnvelopedProfileAccount":[{
        "EnvelopeId":"MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQ0Y0LTZWVVQtTk
  9QSy00VUlYLU41VkMtNk1ZRi1STVZUIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVVzZXIiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIkNy
  ZWF0ZWQiOiAiMjAyMS0xMi0xOVQwMjoxNTo0NVoifQ"},
      "ewogICJQcm9maWxlVXNlciI6IHsKICAgICJQcm9maWxlU2lnbmF0dXJlIj
  ogewogICAgICAiVWRmIjogIk1DRjQtNlZVVC1OT1BLLTRVSVgtTjVWQy02TVlGLVJ
  NVlQiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGlj
  S2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICAgI
  lB1YmxpYyI6ICJyUHhRMEFua1NhaVhpVzJYZ3VERlhlbV9UbnRvbXQxZlN1QzZUaE
  9QRkdQNURUVGgyelRxCiAgUERCMlJmY3ZfNVlhUy1sUzlZU01HMGFBIn19fSwKICA
  gICJBY2NvdW50QWRkcmVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiU2Vy
  dmljZVVkZiI6ICJNQ0FPLVhUSUItWVJONS1PWlk3LVBRWTItVjY3Ny1VVEJHIiwKI
  CAgICJFc2Nyb3dFbmNyeXB0aW9uIjogewogICAgICAiVWRmIjogIk1BT0QtR1FERS
  02UUFPLTUyTUItTjNJWC1NM1BOLVFIQ0YiLAogICAgICAiUHVibGljUGFyYW1ldGV
  ycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYi
  OiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImtZTVM4OElBbHplRjNLeFotb
  lZLTDZJMHZQcnhfUTRlSVJEVHktWVFyMDRwQ2tQT3NvZ0kKICBHUUk2U3ZqM1RMS1
  83XzBrek9lMFN3cUEifX19LAogICAgIkFjY291bnRFbmNyeXB0aW9uIjogewogICA
  gICAiVWRmIjogIk1CM1ktNjVOVy1KTE5OLUlGSUMtU1lUTy01V1kzLVNDUjMiLAog
  ICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibGljS2V5RUNES
  CI6IHsKICAgICAgICAgICJjcnYiOiAiWDQ0OCIsCiAgICAgICAgICAiUHVibGljIj
  ogIjJ6RGcwZ21LbDlNc01VeWdJMUlBNnBvQUoySDI0TFdfQVI2S01SMkVna0xMcmt
  vMFFCa3AKICA4VThpN1c2akItcm1UN1ptelk0SzNRSUEifX19LAogICAgIkFkbWlu
  aXN0cmF0b3JTaWduYXR1cmUiOiB7CiAgICAgICJVZGYiOiAiTUFZTC03QkI1LURIS
  UwtVFhMNy1BWlczLUhSWkMtSlNZMiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIj
  ogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJ
  FZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm8wZDlSRXNRS1dXM3o5R0FlT3lw
  eFpQU2ptZVQ3N29nSkFzT2VEaGNwblpiaThZYjBJU3YKICBHWWEzVmxoZTI4Z2xHa
  VJ0MzhKb1h4cUEifX19LAogICAgIkFjY291bnRBdXRoZW50aWNhdGlvbiI6IHsKIC
  AgICAgIlVkZiI6ICJNQkNCLVNNTDUtVU02NS00TUdKLUtLU1ktWkdTVC03T1BaIiw
  KICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVD
  REgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIlB1YmxpY
  yI6ICI3Ui1NTVpKWWdPRTlZQU5hX0h6SGN3QkR4Sk1XdHRJZHBjbmM5aXljT3RScz
  d5VWtnSEZ0CiAgaDNIZTFxeDBwQUpBQ25hTGlXMWdoN1FBIn19fSwKICAgICJBY2N
  vdW50U2lnbmF0dXJlIjogewogICAgICAiVWRmIjogIk1CU1ItR0tHNy1VRTNGLVMz
  TkwtQUFETC1WR1FWLUNHVVYiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKI
  CAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0ND
  giLAogICAgICAgICAgIlB1YmxpYyI6ICJnUjQwLVpqbzhXWDQ1ZUpXZmloQTVodG4
  xUW1kbTBoTkN5bE82M0d2bUlPSzlDYXQ4UHVkCiAgR0l0Rmxfd2J5WjVqV0lVeGZ1
  a3BHdUtBIn19fX19",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT",
            "signature":"Yh8EcT-UwJ8HgNtyCmu9ZgHVu41ruVjgFIr5lxYM
  dK_mK8xlW9F0I6hXBt_ID4Md4P94El37LwwAz7hg_RxMP-uZc8ZUwdujzkFHZqX5v
  Og_CII1G6mSL8vtXv-cFJDvmpNThgnYJf17bVnlyuqCFDYA"}
          ],
        "PayloadDigest":"KpHTuJ52WMQkFglLSZGZzeSjXPMytoePwTEp8CJD
  8DJrly3G6LVVNo6NHZXpcwQ_35KfPOpqgKqSKJn_7GG19g"}
      ]}}
~~~~


The response payload currently reports the success or failure of the bind operation:


~~~~
{
  "BindResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "EnvelopedAccountHostAssignment":[{
        "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJBY2NvdW50SG
  9zdEFzc2lnbm1lbnQiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCI
  sCiAgIkNyZWF0ZWQiOiAiMjAyMS0xMi0xOVQwMjoxNTo0NVoifQ"},
      "ewogICJBY2NvdW50SG9zdEFzc2lnbm1lbnQiOiB7CiAgICAiQWNjb3VudE
  FkZGVzcyI6ICJhbGljZUBleGFtcGxlLmNvbSIsCiAgICAiQWNjZXNzRW5jcnlwdCI
  6IHsKICAgICAgIlVkZiI6ICJNQU9GLVYyM08tSDNBWC1EN1NULVJDQVUtUlVBNy01
  NkRIIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY
  0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIlg0NDgiLAogICAgICAgICAgIl
  B1YmxpYyI6ICJQdjJ6c2Izb1JnaGk4OWFXZXVUekl3Z1h1YUJxTkxXX0N1X3VBR1N
  BQVVUTFRQaU8xb2RxCiAgb1RpS2tqdENRcTIzY0RNdlRVUWpxQzRBIn19fX19"
      ]}}
~~~~


It is likely that a future revisions of the specification will specify the host(s) to 
which future account service operations are to be directed. This would allow the
account management operations to be separated from the account maintenance operations
without requiring the traditional tiered architecture in which every interaction with 
a service is first routed to a host that cannot perform the required action so that
it can be directed to the host that can.


