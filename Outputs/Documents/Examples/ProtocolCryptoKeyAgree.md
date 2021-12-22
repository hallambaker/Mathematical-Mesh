
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MA77-JIYT-4UAX-CALM-J4UC-K5KZ-EOLU",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQF-OQH2-2OJW-NA5D-YDWE-XCXS-EA7W",
            "Salt":"r2DqFzvxNJS5UvGU1bce8w",
            "recipients":[{
                "kid":"MDHS-QYWA-GWID-LZ74-5MEE-EAKV-PDI3",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"ilzDv00i26gNcmncWywW1RarSU2kC4rvzKp
  rbSMBnJYrzifRhVSz5NuA7lW1EidCn-8Ita2sVuAA"}},
                "wmk":"1FREv_FkyIJ-Wr_AUW1au2l2ZJBwteP1clHq9ikZUX
  yp_ZKcNAERbQ"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTItMjJUMDE6MTM6MTdaIn0"},
          "bww1T5nSZLx9178mNKSgHuaUlzoJXqzbNFwLn99inrlr4GX6Momacx
  9KbKp_fQqlZLFPpEEG4sBvYLvx1QE-Rkf_1o-NZeh48vpbPQDer2TiOd5qvmBmbbj
  _Ei9T-3v6mRfLp4LkCFbkNDVDRkMT8dArjJgKkmg4XJAtbcAil1tEUNiGB-AO-7C2
  WIGhntTpxDshl2thGXaAn0TjDDbSuNTOdIvXvDzQ1T9t1PhWhLoJvDRebq8TUmwNs
  QedEUhq5nZPbOPWtnivSKGayHtFaAGSEiPxGG4EaGu0-xzDbk2USe5gZUQEQ3Rzjl
  52uVNDWuMx5yaJLZZiMcne5IhuQiQ8AytVEtWbehtIhKDDh7Erv5UKkV8GhPqOsYa
  nxD8LM4flrEVACGUUcO9tvcQVVXbV9Q3WJ3Vtq3kSsGWdZfOjjs4S40q-58fBcXKf
  1Fxxi3q_0RqxrbPMD-V3IrS0wtUeMJDt5_4vXeaWCFBcJYjBvfRXvj5BHSkDwSAnO
  HsHycVKrpsOOFILNVaiUyi_0TecLA_2Z0eqP3OXMkzC_qsdk2ZeTOaxk6wpnXMU39
  bqJd53CPnf_p3pqS5BcmPiyd7Fl1-xEYnkbQmri8Z26Adk2p9tGUaslO8d29ezyLJ
  WQHPH6W4xqqcvqpfzjP4c-adtIc-EOLmy57vcZIdPeB0wVwgnKyYUQZ_6o7yKyrVG
  G8lbnBnjmiWsLUFWnax_Xg"
          ]}}}}
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
          "KeyId":"MA77-JIYT-4UAX-CALM-J4UC-K5KZ-EOLU",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"y6zAPkPNuQxjExphMvM6Iz-jDRfJzYx5hO2kZSJie
  rtvxqYj8ZuU4ObaCcz29JAV3lgtmlo1_88A"}}}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"wsMHQSANPnUG-CVjm3FQWloNy26fGkDTfX-K1ihZt
  1QOUrYO-tQT3FCGAoHFTmEKTNaSz61PIh-A"}}}}
      ]}}
~~~~

