
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
        "EnvelopeId":"MBO3-YYGV-RKLJ-4JFD-OQD5-BEJS-4GYO",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJNQk8zLVlZR1YtUk
  tMSi00SkZELU9RRDUtQkVKUy00R1lPIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZml
  sZVNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAg
  IkNyZWF0ZWQiOiAiMjAyMS0xMi0yMVQxMzoyODowMVoifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJQcm9maWxlU2lnbmF0dX
  JlIjogewogICAgICAiVWRmIjogIk1CTzMtWVlHVi1SS0xKLTRKRkQtT1FENS1CRUp
  TLTRHWU8iLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVi
  bGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgI
  CAgIlB1YmxpYyI6ICIzbVB4d25Zdnl4bkdvUV9rNnZpdUdLd0VWZ2xMb2FOSWpCR1
  hZdlNTeVhvSTF0dXA5bU45CiAgSk1tX19LWVlIWWUzamUzTHJZOG54SkNBIn19fSw
  KICAgICJTZXJ2aWNlQXV0aGVudGljYXRpb24iOiB7CiAgICAgICJVZGYiOiAiTUJW
  QS1QWElDLURJNFAtUFQyNS1YWUZELVpIWDctNkZMTiIsCiAgICAgICJQdWJsaWNQY
  XJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgIC
  AgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiMUcxc1ZJa20xNFp
  kNVhmUXpVdVJ0SkpDTGtqTm5IaHJCYTdBanRLeHNjMlpYckktcnYtLQogIE4yb3k4
  VmozTzc2Q2NheW1KdUlyWDVVQSJ9fX0sCiAgICAiU2VydmljZUVuY3J5cHRpb24iO
  iB7CiAgICAgICJVZGYiOiAiTUNHVS1STUFRLUlaTk8tTVhCMy1QSEMzLUJUSEstUj
  dUTyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWN
  LZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJYNDQ4IiwKICAgICAgICAgICJQ
  dWJsaWMiOiAieElZWnlHS1V5OVhHUnVpUFR3SkJvRVQwU1dvRkpMRThaa3NISTVZV
  GoyUEU5bUJXYkVfegogIDJoSTd4eHdxQlc0UWE3UXJyTHgtQnFpQSJ9fX0sCiAgIC
  AiU2VydmljZVNpZ25hdHVyZSI6IHsKICAgICAgIlVkZiI6ICJNRFA2LUo3R0YtWll
  TSy1JQ05OLVBZMjMtR0ZHMy1CQ0gzIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMi
  OiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogI
  kVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiNHRWUzIwMHIyNHBoUk5icTRtOF
  pWSThPVl9kU2pYenBnd0tZaC1LeXluUW5DRWRsT29IUgogIEFHVlgxWWdNa3d2SE1
  0cWRkSXVXOExRQSJ9fX19fQ",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MBO3-YYGV-RKLJ-4JFD-OQD5-BEJS-4GYO",
            "signature":"BmzyEDidCwU7nlAFfwtNlmpJbgPvweXRLS8jCyQj
  hEN0OipcIujgWVkaYlKM83RcQKrVXcMpcPoA_Mo27OHrE6LTivTp6AGIjkuzvt6s8
  7rz13iVlR31xsxKswXU8HlKq7dPPScGYsEM0-DQREdqswYA"}
          ],
        "PayloadDigest":"TejLPOqqTu1gDeQeOd1i_4bj93UIVit07pb5F3l5
  QIYpTJLAY92hKNMEr6ODeaOgHuo9YbXjbwsT_R58zMKHjQ"}
      ]}}
~~~~




