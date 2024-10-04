
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQP-UJFC-BOF7-NVKR-UWEY-YEW5-RD4T",
            "Salt":"QXoxAdVzh28BmQd317msmQ",
            "recipients":[{
                "kid":"MCZH-QYAR-OT5E-AY75-NZMX-O67H-HD52",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"BG6ErdutQpOIB6Glu9nNNcxr1LTCHlHgvoV
  yfnS7UuBhO1eJ9nzBDWgWN-75olphj8ny8TI5Js-A"}},
                "wmk":"DfVK0kGXwT8JE-zQ1CJUzYBXjln8Cegt5Yqdk6-svM
  blCfeg_Dlbcw"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjQtMTAtMDRUMDE6MDQ6MzhaIn0"},
          "WX_QftFAsMvxRbXAW-FHkWBNWS7FbopsemvZYwDDP0TgLtbHYsXKJR
  OEA85Fd4zuZk1eUYTZhmlQvQNyDHTTB0a2Ri50DkyjKHHUMkQT3j7YDt35X3Eyfjo
  ve-8DAK1ZiYMDhghsFYnlYaLSPMyAgnTx-Cdc1GVgR8f6GxhkkkGxhqhFioatYe1z
  G90WScIuJ_ifSkHk2bcQYfxuq9tgfBIsV3TJ46mBSVeHUBi3OdsL1i-g-c6LGUEIx
  4iltg2djYmGTEYuzvA15EvrLOMxEsrq0N7PEL7BfsfIDaBdewWAf3pZT7Zpe06Ry1
  UdLh-yW5_8M3wSGACLGRRAbjSfO_lWU3Urt2gUoDY45LONzwIY9OgAHmvWpK6sCA5
  vk9HDoCrH73e3zW3-hk1eJF1Vzatt9wuV8MErQDghtfc2Pnm4F3dTKMyGfchJvHLv
  3CJVihNP-pZbhc1zBa5dfntXdflOV8TL4DzZ7YdS_z4iK1qlFvq8hB8TnB8ZmM7rD
  889NwfLBGbW1LMoERYq9Gn3jKlMYk3V58UBfwMoMNZ2IOWEFO82Cf-y-3j_PSCMNY
  a6dRpkHRCXEYC_EPeRliXgioYUJqdtXInyYiSYe9nY5OM0VIZwhX6kchcTSZYOzxU
  yhnb__4YetRpLGIvEGRr9l2KB2FR-s7yZapA5hqWR_tP-7nG9RwewvfPpzc77araN
  YxGVKWpQEPAV3uskz8O-lw"
          ],
        "Id":"MAMD-TA2N-G5NY-SCCF-CIJ2-Y2W3-NTU7",
        "Active":true}}}}
~~~~

The private key (in this case a key share) is encrypted under the service key.

To make use of the access entry, a request is made that specifies the key share
to be operated on and the public key parameters to perform the agreement with.

The request payload:


~~~~
{
  "OperateRequest":{
    "AccountAddress":"groupw@example.com",
    "Operations":[{
        "CryptographicOperationKeyAgreement":{
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"HKPaeyipbrjIhaC-l1cpSjUx8TlGUHeoPXd6rV7kO
  hVhsYUhzwWJMIY44SufrDeBOfoGML7O8xoA"}},
          "KeyId":"MAMD-TA2N-G5NY-SCCF-CIJ2-Y2W3-NTU7"}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"zK6dKffmK2FeDha6jgsvMUz3Vuo4-Kf1mpsqenRaA
  lLwF4JqmKwqK_hBu0MZQD07ihtwZOj0BpoA"}}}}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~

