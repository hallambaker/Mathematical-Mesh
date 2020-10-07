

The account profile specifies the online and offline signature keys used to maintain the
profile and the encryption key to be used by the account.

~~~~
{
  "ProfileUser":{
    "OfflineSignature":{
      "UDF":"MAQJ-32QZ-HFDM-M2MZ-PR57-3FSO-4CH4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"-iC8hrqmyhDGim-0oopft45Kkcben6LV9ad5W9C0in7sH2B
  5m8Z6AK1WL0aRmJvk_T7RoJfChs-A"}}},
    "AccountAddresses":["alice@example.com"
      ],
    "AccountEncryption":{
      "UDF":"MATQ-SWCI-66AW-3WH7-T5IM-HQHR-2JGC",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"2nmt99fWQgPYwD4jRCbq_lsiLOcXtFumg0BN2694Bkw93YQ
  PIgOHh67_TgBXmhSk5YUB6wmu-jeA"}}},
    "EnvelopedProfileService":[{
        "EnvelopeID":"MDGZ-ESGM-MCSE-3BXY-B4ME-BOOX-FFYA",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJRCI6ICJNREdaLUVTR00tTUNT
  RS0zQlhZLUI0TUUtQk9PWC1GRllBIiwKICAiTWVzc2FnZVR5cGUiOiAiUHJvZmlsZ
  VNlcnZpY2UiLAogICJjdHkiOiAiYXBwbGljYXRpb24vbW1tL29iamVjdCIsCiAgIk
  NyZWF0ZWQiOiAiMjAyMC0wOS0yMlQxMzoxMjo1N1oifQ"},
      "ewogICJQcm9maWxlU2VydmljZSI6IHsKICAgICJPZmZsaW5lU2lnbmF0dXJl
  IjogewogICAgICAiVURGIjogIk1ER1otRVNHTS1NQ1NFLTNCWFktQjRNRS1CT09YL
  UZGWUEiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI6IHsKICAgICAgICAiUHVibG
  ljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAiRWQ0NDgiLAogICAgICAgICA
  gIlB1YmxpYyI6ICJNQ0kxWHNmZ0NMZi0teEpubDlQZnpNVmlPNzlRYmFSMW1KYnRK
  Nl8xQ0c0aFVGRF9OQUI0CiAgcWNvTVlFUVEyY0pCN3c5TkJ0Ym1tM0dBIn19fSwKI
  CAgICJLZXlFbmNyeXB0aW9uIjogewogICAgICAiVURGIjogIk1CSFItM0s1RS1VM0
  FYLUlUUEwtVENNUC1WVVBCLVRDWFkiLAogICAgICAiUHVibGljUGFyYW1ldGVycyI
  6IHsKICAgICAgICAiUHVibGljS2V5RUNESCI6IHsKICAgICAgICAgICJjcnYiOiAi
  WDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIjVVWkdzcmZ1THlTQUVSX1VEb0JUT
  3N1aUQ4VmJUTUtMbk9MZmk0UXVMcjk0Wlh1dGxWeXUKICBYX3QxdjM1Vjk1TDJiV2
  NJZjNtOW5OYUEifX19fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MDGZ-ESGM-MCSE-3BXY-B4ME-BOOX-FFYA",
            "signature":"0sBNsSpvT39eV3_WElcs_wTRVQyj8MTBE2B5SlqCHk
  BMq74M7Hj89OTB_OO1X_aFslBzeCyGrA4Ab6DipZuJ1H9gg0MdLpwjPKaHkQ9_Emp
  jBn7_TiuiLbUpLYDveTiUGQdsEkGwVYlr5vb4_R8GASMA"}
          ],
        "PayloadDigest":"_H4qy5lt1j851SEfkWMeouHF-OjiM08E9yHlNbt7r8
  xmV5aUzPTmYEuwKlftD9LYF4_Rlf9RGjleX4jik1a68w"}
      ],
    "KeyAuthentication":{
      "UDF":"MATA-BCSV-PNYH-6WOF-EROB-O75B-O3NJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"YNPwc91pzLQfps17Kbhtrs0-uCeXKoaMgz8pg5N_6QSWfTQ
  0RDIB-LAvwGs3_EmyjGX5IamKVw0A"}}}}}
~~~~

Each device connected to the account requires an activation record. This specifies the 
key contribtions added to the manufacturer device profile keys:

~~~~
{
  "ActivationDevice":{
    "ActivationKey":"ZAAQ-LB7J-HMRM-ZCHA-GPGU-Q74B-QISK-KJ4D-5D7W-XAXF-7RV7-B6KW-3V3H-Q6EV",
    "AccountUDF":"MBRF-SATS-3Q6Q-CAS7-5Y26-J7LX-XH6P"}}
~~~~

The resulting key set is specified in the device connection:

~~~~
$$$$ Empty $$$$
~~~~

All the above plus the ProfileDevice are combined to form the CatalogedDevice entry:

~~~~
$$$$ Empty $$$$
~~~~


