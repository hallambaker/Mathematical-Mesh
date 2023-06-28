
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
            "kid":"EBQM-SDBL-2FII-4ZEO-XDZK-3ZMX-IGPU",
            "Salt":"o5MMIhLjNAF69Olax4CPaw",
            "recipients":[{
                "kid":"MBJA-SIGD-FUNB-PAR7-EBPB-WAPG-HHDF",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"V_Q7ZRiaZHf_aFJiMZRIqxclvTbV-K8nJy0
  C8Hv8eC8bTSZ4mxj9yoCq9rGWS3iZJpnwVGhRW7AA"}},
                "wmk":"gbw5UOsFlyZgKYLkp_F-N9S-UQwYxi7tARS4UpDgSa
  tznboopHoz4g"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjMtMDYtMjhUMTc6MDA6NDRaIn0"},
          "Vq_0YOMoVHrh_12ZfRAh6IEucnE940F8yrBwaDJ3pgbIb_Lg-ZuBr3
  taOfL1Y3EqG6uAo3SNOpyLwLpAuQlKoyj3ARlD6dKqOLweJ08p-ntNePRseexnltL
  H-ZzmD435w8xUq0a0u-8exOhiTM8Ews1_ger8Ca-J7PILCoXBMqaFKnY0gYNqoDps
  3L-DobgCXKahFUvS_m2QMjrZYgb0MJsytbhD6KIQbsUvbKvv-m7O84oV0ZWkuR2kN
  0dvN3PRjfEkMtXdCqticFaji-h9W58qH4EttDtuKgwimIRI990kBulZXerH1M_PZ4
  ey1VaBS7vR4c6AE5IkorL0ZWm-SZKBX6oiXTU4jPmfuerThRPZIGSbbrIaCVMtxdU
  RufhOrrXq8oSTwSbT-htVlW_5tkiOyhX_xkSDDiouTuOJ9U4gld47Ovs04KOSDCfH
  EXc-DlGK7GO_D9HAxPsHcIA8ICRheJyGhieyrOmImca3Mb9ukKX-Tt9JzrKOnap1J
  4pVwANgVrhinmji8l5O1DHtoECxtSz-UDObszOTZWQlmXgdXwRpFEaIBrdMDuxTVK
  d_vyypUv1Grty9nwV8IWYp9rKdDYK4lVfmTzR0fPhgHVYgBKDlrUuz8ncszmoSu9B
  xQ6GcuUlQSxWmykgnfwGvdB2NXmH-PXfmvtfGW08BkTzVD3ShoJY10VcKnnPhXgI2
  QxZ9oQtggCVzNnWk10Caqw"
          ],
        "Id":"MAOA-XEIS-6KM2-334Y-7M3P-S4U3-LCQP",
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
              "Public":"6mY-euLujNnyO12hdczFv4vckjk1FGrQwXZeye329
  U2FtV7i3PLLbxIwOvkfEJOtp7zUtXdc5DMA"}},
          "KeyId":"MAOA-XEIS-6KM2-334Y-7M3P-S4U3-LCQP"}}
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
              "Result":"ODcTzgThPhguBD0DIbx6IwIuHRml4ZD7XI6x4NeXt
  WHlbKJvFJC6empaS2fTxmxCoFMCH9vDLOmA"}}}}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~

