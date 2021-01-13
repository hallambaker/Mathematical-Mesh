
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NAB5-YJPI-PTQM-LDCJ-73YB-YRMJ-EJTZ",
    "Sender":"maker@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQA-UU6A-52ZG-L2KJ-2NZY-GZOP-KQ6B",
    "ServiceAuthenticate":"ABDM-BH6K-2J3F-S5PU-G3OA-6UDM-S5CW",
    "DeviceAuthenticate":"ABOA-4PKL-7A5C-EW3R-7NNS-EOS4-XX5C"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MAT7-SJFB-SVYG-7UK6-ZAEP-PS27-E7LE",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUI1LVlKUEktUF
  RRTS1MRENKLTczWUItWVJNSi1FSlRaIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjEtMDEtMTNUMTY6Mzg6NDVaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BQj
  UtWUpQSS1QVFFNLUxEQ0otNzNZQi1ZUk1KLUVKVFoiLAogICAgIlNlbmRlciI6ICJ
  tYWtlckBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUEtVVU2QS01MlpHLUwyS
  0otMk5aWS1HWk9QLUtRNkIiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  JETS1CSDZLLTJKM0YtUzVQVS1HM09BLTZVRE0tUzVDVyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFCT0EtNFBLTC03QTVDLUVXM1ItN05OUy1FT1M0LVhYNUMi
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MCVM-VUHL-UTSB-SV5M-VRD5-P5XF-QAEV",
            "signature":"kN-cd4dUkTGT6gjm3MVnuRPCHWYtGmqi2IbhaBmb
  agc3D6hmJgNTbGApAuVofNkPqc_jBhSpU-WA5NoDvH-e8dn0lUsMLxLUyFvs8VSns
  PwFvdpMzymp4woMdNQV-7QofoqU7DBAMljBJrLSiG8mdR4A"}
          ],
        "PayloadDigest":"pmdjNV2iacjFv2I_5rPfwbCHRV2G2xAaVvW1hb84
  J1-oN4WiTf8GkSuEwM0hk__qH7qk19nroBGJYEszOe-CsQ"}
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
      "Id":"EBQA-UU6A-52ZG-L2KJ-2NZY-GZOP-KQ6B",
      "Authenticator":"EBGU-ETMA-3DE7-CAHG-BVVE-QARV-4LVT-LKKT-IXR4
-FTJQ-JLWD-4RWV-TFFH-E",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQL-HMNU-PPID-5DNC-OA36-4Q4R-O5RJ",
          "Salt":"YsZp_N4nuWOAv_NwsHZqqQ",
          "recipients":[{
              "kid":"EBQA-UU6A-52ZG-L2KJ-2NZY-GZOP-KQ6B",
              "wmk":"IZxxQwSP394qBo43PA2UuajT-fsFs-FDes1A9A0xxUw9
  q_o44vw9Ig"}
            ]},
        "c-BCcKJKlzHeVj23CuFDw7XNNl28Vp6G8u0nU7786yumJMW9qNddCtT1
  l2Ui6YxFqrczuEl56Mfr9dsRj66uOR4rznOhsa9YOCj_9qkQmFQaVqbEqDLAGIc5y
  WBD-VhUpPu1m0t4fpqIdB5eZOd8jnuvjAFIaGqgtH5C8Dh55fCuKbwS3t3F0G6UgE
  H8IDqg4Qh4jFA5UhmP7HfsQGHld0TroLmL_5raTmsLfLZ1ziULc-7Y7TLOMRL42a7
  xvzlSmDGV0QQyvnHCOe_gH6hOXjezuOeaI79FerzeZgeKHv3O9IO8D4apW4eg-65B
  zn0-enj5XKjXmbtQ4jMlAD_iauowS6dwARK2ULV3YsXUGTSn_fWZFj8jMWXeMC0P8
  5mZWzdBKHcY9V0cJvG-hqdsHt2yOeqUOeHlNZtKX1rjc5a1d_CopL9yi5JgZ-YJbK
  XjahTUEWb88YGLkKvdk1j-SoM8DIxJ1Q6w3FfrPZdi8FqSkGWfunIktPIr7i_yXsb
  syzXFe0ONHLdoSxV18-UMbMsUMphajm91MRFYK_JQK37My6RaOVQkh8TA1CeYmLM6
  Ur_i0eH2Q8-DEpvUhyr3Sv7OPZdB3LbrKCfqNS0m_kquJtC0BXcP5ye62vFf9iJGh
  icC04xRJngfg_0eWMK96wWFelUjMF_C238rs3TuL3dtK2m76rLfLtK76wrN8CwegJ
  OSfOkUVwzTwzjsJR77OPbeHJrCsAO0XCKN_uZE81cJC1ivagAvyiuUpx6jBW-agwL
  xGKGdsmYKA6kbpZLzAHIKD4x4fEI_EDF-bM-_0JNkTsiZ9XSkdOh8Vrid8_hU6BkP
  meeHWWdpTpH7kv-FUFrAle9MiXyR6ebqhtQWhnV9VXsV4EmC625owxyvt9nt5eRQa
  9rpc_wb5HkqGrhXxHCns61aWBZA5JmtHW3VsyEXOUAYFJjha_PKuitqzRIG2-yzxQ
  1NBmFlxK8Q57tLaJGQYbEPO5CgbutTZMmN8oJtm_82TZJJAsECX7gGVq-cUjeNkyO
  Zx3RF4PQwC76YJQF4TUdVTw5VoGE7YU61ZY7Kj-cpWoxnny3-U-NTti4jMOgYU8XD
  jk95bQhXelttxSqAt43NFs1zsQKJ348offS-5g52wPqs0wSroqruP77MyqyFx0Flq
  hPHdNKQmTujiKfDisqwym3QRDwJYctcSM4ifHzVIGkXICkj-DeST9c-f5wDKWrb2m
  sSJElw8xDJctv_0tSfKgPb7nwhxzy7Ettjg0601CETKLpyrBQg3uH62sfDPleA5Uw
  lpD2PF-GN3B10vJgM34tazM4U9CyNGhkoSxt_BxofedfgzLJTbWOzXGZPJLp6NRim
  hAr4_pjmaeqTwJQjVY-2q2jsz2aY_5X65r4XS-A0I-paUhebXrj3sEiVaSa67KGNJ
  rLoLLwr3EqfY90Pyus1ylh3kd13nEMeRMlPsxqwrjyuHiVKzVwfAEq-0eOHaT9VlV
  XyfnLoCj60L0tNhYng154gq4Bj-8nuR2SZVPoRxVxOnM3yEgMlgNe6HLsUVAwen1S
  NLh0EK8axBv9NfTEALVRxWAklOoDFz64SWgimIzgJJP4O2iFt6Or_7ksZ1li7AjhC
  t-GmjVYELwNP0UVEErHXAIZCt88TwV1OSSFVhsV0rfA1eqbjNFqz1sLJjrF-osUKI
  xGicbebO-yhj5TCXtzWKbbp4Fmfwrg0cdRS7m3qQlJB5_m2bR6P6qEYekuNxSxcCO
  DWEn-9WfL0-hNnI03m0FvEYFSMN6MpBWyiTPsnDepbbZfD3yJMUUzs3IIIaQwI3Wf
  OUEicFB_Mc16KRE1IndUSoQjtDUGNJ37UhBvEfzYmUzWHFKHnUVvvMFjVtD1kh_F8
  psgrYwg6pu1KS6cXttLzYNpu1i3_4uzsbksZLF-S5M-wx4xy9858YazjJ-bRUDg4a
  TQ_CHKtYV3m4trO6lgCAa4aVt32kzPBve9pt-YxxMT7gsGEszmRphZ1kq4miaMnr-
  8zjQn7CKq853v6K1HzCsJA8avjUDWb5mfqvI1u9hxrdZ866guMAtMgqnI_jU78VqE
  _a3r17C8KfH8mH8fylW5VMKqCslCRJOzCLgv8_5YdcUDcn1I7ytMdagFXN-gc5a0E
  RBSpr9sxcwdGX5p9b40COCi1oEza0sfUoNHYPM8WHyQHJFPjcLsOH60S1ydjtZKta
  nAFtBPs_PLnmOaPylqAGMn-rTV14yy68A9tdBgKqZMCZzDaHHYzYdNS25EaYFT-G7
  5KiiF0ARAGMIwAVM5WcEfMbFq-SZXsxKDxMxfXJO0mPiO9xBx2BXwRdAN5Qr1BZHi
  kIRvs5FT-PFPuE3MyYpWAbhlc6PPBmam0ma-LO4S8jkFPMjpFQ33JT0OIyttrz2I_
  qhQq27wAGy0ZeILdXbJCMFzr0Ms_kB6ZVYGnteSsrkO4Qu9rQsb3JnV0uKnqwHhOE
  pTx2Usu6__JdWv8JUizt5tPo13u8ynIOkCxnAPRXDhBHbHD8nTtNYkNB3cpczToQh
  NmLe8-BN7tqZ3anErBOMR6N39B0sANJyWrom_pWEt52ZYsaqEz75I-GFZFxfsT-M6
  NDywxXRrcJDXVmpSnGCxAb9IrFR07aQqn5fhOATok3onsTyz2ArsHzHsDFxLi2sNR
  fRCt1ZUpgE_ryyQu0ex4ItwnAtsJIw8pTnTBkzoDUAmA43VVeAC_pr9QPAy_4BOc8
  gvdL87fuYbyr_L_VRhTzp3XMMjfAbKjPXdIkNiRKvkbGr9PyOb1riUwd8uLffzvds
  w9QQiV7GuP3_AwwIOuOijk0ig62EWb7bGA1K-_Zyka5PCDjAMEwkVSbI-Av7-dSu-
  bu28TgGk8T0f3RNdQR7drp-zCCT7Kbz5CtAUR8SkB7USqUOVng7Ygo5d61Fufx-jz
  dvZhaTgcbcd69qtxKqXDb9uhGCyKBLP5sDjx-aHX-q7WzFs8UptsD9JWsUM1HJHB3
  klH8xloE9zNtmTpq9j7GCj4RvmWfsWHkEfDDGxqipiXFixpYoWMp2tu2WxGt1d8OA
  xUMkY"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

