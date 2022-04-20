
A device is preconfigured during manufacture and a Device Description published to the
EARL:



The client claiming the publication creates a claim message specifying the 
resource being claimed and the address of the Mesh account making the claim.

~~~~
{
  "MessageClaim":{
    "MessageId":"NAFD-ZIB6-VLZD-QO4O-6C5N-YII5-VLJJ",
    "Sender":"alice@example.com",
    "Recipient":"maker@example.com",
    "PublicationId":"EBQL-I4TF-ITF3-X4I3-QCHK-WK32-347R",
    "ServiceAuthenticate":"ADKJ-W4NY-ZRLB-PUSC-3OSI-UADE-SCJW",
    "DeviceAuthenticate":"ADSB-J6YC-B5R6-VJIA-GULG-LZIP-AEUO"}}
~~~~

The message is signed by the claimant to make a RequestClaim to the service:


~~~~
{
  "ClaimRequest":{
    "EnvelopedMessageClaim":[{
        "EnvelopeId":"MAPR-DUUH-WNG3-DQCP-6RRB-NCVC-2RM4",
        "dig":"S512",
        "ContentMetaData":"ewogICJVbmlxdWVJZCI6ICJOQUZELVpJQjYtVk
  xaRC1RTzRPLTZDNU4tWUlJNS1WTEpKIiwKICAiTWVzc2FnZVR5cGUiOiAiTWVzc2F
  nZUNsYWltIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJD
  cmVhdGVkIjogIjIwMjItMDQtMjBUMTY6MTc6NTdaIn0"},
      "ewogICJNZXNzYWdlQ2xhaW0iOiB7CiAgICAiTWVzc2FnZUlkIjogIk5BRk
  QtWklCNi1WTFpELVFPNE8tNkM1Ti1ZSUk1LVZMSkoiLAogICAgIlNlbmRlciI6ICJ
  hbGljZUBleGFtcGxlLmNvbSIsCiAgICAiUmVjaXBpZW50IjogIm1ha2VyQGV4YW1w
  bGUuY29tIiwKICAgICJQdWJsaWNhdGlvbklkIjogIkVCUUwtSTRURi1JVEYzLVg0S
  TMtUUNISy1XSzMyLTM0N1IiLAogICAgIlNlcnZpY2VBdXRoZW50aWNhdGUiOiAiQU
  RLSi1XNE5ZLVpSTEItUFVTQy0zT1NJLVVBREUtU0NKVyIsCiAgICAiRGV2aWNlQXV
  0aGVudGljYXRlIjogIkFEU0ItSjZZQy1CNVI2LVZKSUEtR1VMRy1MWklQLUFFVU8i
  fX0",
      {
        "signatures":[{
            "alg":"S512",
            "kid":"MAMP-BX4G-AKK2-YHPA-IXJV-Z2KV-UXBW",
            "signature":"Fk2oDmBaKXmkf7vnvLHDNH8M6LRYHC1lD6VaypH6
  rgc0_uftuhH12Uitq0fgWMFNbvAyTaSdchKAPizuQisjvI_K5G6VOr8HnTft65UIW
  sFZjsj6vQjVb8j3oa5gCJPFQzbyn9khoO6irBTXGbfIJgAA"}
          ],
        "PayloadDigest":"B8c5TfDXr1GK6CgI8aFEXBWT35NCMN70f3HHreRr
  C5o5dGw04VA8YmUrW4tnSpYdVOBap0tSSQwGV8HnYVkd2w"}
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
      "Id":"EBQL-I4TF-ITF3-X4I3-QCHK-WK32-347R",
      "Authenticator":"ECXL-6FG3-37XK-J6GM-VR2W-4KUI-5BW7-JQRO-CYMW
-PIHF-6FSA-FQ6T-YXKG-K",
      "EnvelopedData":[{
          "enc":"A256CBC",
          "kid":"EBQO-52CW-B4C4-7MLL-5LZT-PJ7Y-Z3O6",
          "Salt":"YwqtqOhssmpR3cH8fZkGYw",
          "recipients":[{
              "kid":"EBQL-I4TF-ITF3-X4I3-QCHK-WK32-347R",
              "wmk":"i0Wx4i67v2s9XeUvtlmgAojKsuBzi_-B4MbLLHhJbVmM
  2FfwzN1YEA"}
            ]},
        "zpvCTGxohUkssrMsznDdzinzW-ioixuVZfdG_XqtFac38vFixkhZbhJH
  xGJIxFGRBOwEzF-rNu9bPHDacsXru3SnkYIQL9jw1Nx2ipOOduys0MijUJ99sUhhm
  JhW8mqzUroU_uh7yum8twTBK71eZIMX3FZxFnse5QeeD1KOadqcDV0hXNi2QAmEvp
  CZNTKiRroE1jxFv9PiVbdvvWXC8eIVTYqHrn3T9edfLxil819vubbDWJXz_DxI6JL
  QCX9MJTnZ7_6_AWBFyi9D3lzKdYOWbsOu8zJGotEpi9YXDGnPOojqmCPdyzEdIsUZ
  JIld_KuOv6fYa4wZ3AlTilSgbmAQG4KMYiV2a8Od0o2Uoqvi8yujAEv5qxl1A1Zk5
  i-K1ZxFHiAw5te9M5eCyEx34AONGIExXegDu1EAg_A14FCKhyKyn6bpvJOjR2RHZh
  84CgwiHZvVEtxTL0nY7r8mghvH3cxTzfW8nF9cS8-MwhhYNSdIXCcGkRl1FhyM5P6
  GRh_RODqm1QmlgBuJjLdaaEHYlaxRBqaT6jI8c2SlvAZAFfn3JxIErLU8r_gTW3G6
  KPn_JUqcRFVlRrQJcV-8uuTn6y7Sdv6RsXnJDQNlE0rAsb6jilU1Z-_CUeX6cTyAl
  UPb-TXlZsjWplTIlSrX65jCYasfcVnrC9ibIiU6zQBxYLOvTdVi6dTiuQ_OHJ8FbB
  mxtHFJwfjxoNqiuemwZ1yC-jGtaaFgDcAjp1i4AHsZSVUHl2f9hbRPWCTB2WlaXy1
  gohp-x_Ft7mUD4JibMjDUPb1Sxjtk5ZAq6bXWnEz7cEDNR8JgujeU_0RukN3CEvWR
  SyQ-6LWX4svntzUcdffqFmD6MjXnNLxkUgG6bBxmc-caUDRGBEHl-UUxzWY30yVXs
  UcEQCg-9bscVIwYgQFzTKAP4zNXH7lUXGM3p7wf9yRs__GYncfVcDGWsemYHFDGp2
  3ApBI9LEUbhR_h-hIBjSEu61cFCzpC5dQsGLIUv8i-J-nWEt7_OWg3he2FgYn5_2-
  IQ4tF9qGnt2v5wfcfIL60B03hSaDIDnrvDFtXqmz8At6fgZOAFYy9IE9TSXLyhZSq
  88c0nq5293Z5kiz_XgneRLAPhWsHMd609AEarSKq9UJQzj4fF32iIj377XZCwOp87
  RFomBwhCXYwloTAeegJwTDfo3hdUdbWl1DPhj4zpO5Vpzsn3zu1qHjBDRCbzeuYg5
  XVoAKX4Oe6uo9H8UlbmEHNG0vEi47ko8HgZ_M41Xz2TGyrsJxKVkhJK7J8_-RQlrx
  BgXr0Lhkhc3fJY7IVPtJCMw5gUpxbfa5cUqRChYx-RLOusz2IUTgc9c0yXWwZiiAG
  pG_oeTBHnp6_U0FxPzIeP3QjhmQpGgDdd2HLnHcGWkEhhpvqbwaSr8USdYRo0t7CH
  C1Fvjjdn0oICdRQyTpT4n6XuDMcs6DLggrW4BnKFUfuYmv6dIg6Q1o3AM9p3W1-zl
  M3AkPguPkRvW-tnrmMy7liUXzCKdd3Vv2-9i7IaiTBQMZYcnrWuRMFdBA6WkJbgnj
  -Od2EgwZ-Dux4aPB1ra53r49wERYxTTrRSQhW9aSQxHM2YRjIK0NolmAn9zLOLtdK
  lepTqmKmXSMLuHosFxMdlHgDUb3rqL_CmIJ8naiprf8juxLWTw6w0OUlNZYTUWf1v
  TRr_VeeXLHU1lL5Ob-nQyQb66UZw2Lh-iP-VdsdJo7juL4-S_uO5g2bYGBklclF7i
  XMOpxxBiZw7wQ4VVz_B_4RV7twqeAbVPkfe8yCgCYCwogy-x-cf6wMbKdq5w9qFWm
  A9dwHFEt7e8eKAqh0PoQKJhSm2e94UL_wEgvdNrTb_fQuGHxKxpM27T8qBQVRzsrz
  -IGwi1MeUS9vM5N3DXnQYj4cO5j5aZSQR37sJfjrtkNC7vNguVDu5PRCcWWCr8J3z
  aJlMW5XaS4QXMEeZzzKYmOr6ZBJ6CAVVwBudsM7M5Y-mc1qAIe6pkUEngLOOP-OBm
  Rt1Oj0ZH0-HlpeRfaB0TBJe67M397xOi9d39uP5CjDUqvTbsQzf7_Kh8BDGxtXjSZ
  UZqGr4UU80x9UuNgmdkLppxz7EjIWQ6qsp9xE9sX9cMxE3uRNlB-xFgRdiEHbbAfj
  cyOr2UUbR4YMrXNDHs5szAMyAXuwJbzDGvlXmDuMyDW4sVstmcuVoRs-uM8Y157o4
  wsg_XbSL5u6H3Z6QXP7vPN6oyHc3lqMkFRU5sHR9zRpgCCSi2YmWU609HGUBPYj1H
  hSi-bkg5T7zA_pnsRWRNIDPSrEHDadXBxs7YDyMxkPQ2ML3j-7zGi8rz46eyV4sAb
  T8xOAiCfzLfjrJtGaXO04PYLXRdxD-bWeTPORtAUIXukkbCoCfMxfDd3JKDR-QvTO
  OUhOTnO-9yWnlJucrFpE5syujJz6awo95ZULiayBGPY0QxnnNOH3CER_cTb7DjSwF
  i_gcTE3q1dtyQAexMj7tj-h30qjEjt3j-72_2pw-gTY_akNJeyc6iTfcJsa4ldI0V
  A_m-ErjTpWA6AkiJ61hfLg4KZai3RiWPQWOHvNGQGX4TC3lCwNto_sJO7vjjKFfEl
  Eb2GuVgiuFcBCcOWBWE9LTBs5EAYNcwCPeG0dXv73GBuTupnJvZWHLhw4lRCV4ju4
  OqhsrkOR7fGnXsPDJrvlrlvYQsJUblfiBjGUN9UJy_Vgd5eAvNWLMonk2oyxpJCXw
  NOO5nNVtzplH3PE1ZzhR_YjbEg1gXUWkPRpETpKMXDfjVe1Y6Wh2x4boRtzRMls_V
  J-Y1yrHSuYex-xOkN0GcEou_0t_gGtHIkjEu1-kIu74osRiEV4cvBQEJH2V1r-B5Q
  VjUmdAVWsODhtp_yH87KYCksKqwYITOIqaUWHUThg-R0tD94urJ0wHFlxNFRcxZvC
  ZKr9EuxtmWQq9lVr9UGQzZqL09-ddnuNru6LFDPgjOT4bfCTy32mtIj7vhwZ47BWm
  4BrOKA0GNghJziGNFXwsZz1ZPjv3Cy_knTA23osoygx6i0khg"
        ]}}}
~~~~


The device waiting to be connected uses the PollClaim transaction to receive notification
of a claim having been posted.

