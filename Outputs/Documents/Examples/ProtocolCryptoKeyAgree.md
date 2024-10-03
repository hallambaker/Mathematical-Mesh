
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
            "kid":"EBQF-MXCU-GV2R-W7OH-WHUL-TP33-5JQO",
            "Salt":"3m6KcNZ2pLKfFkqdER915g",
            "recipients":[{
                "kid":"MBRT-7NEO-DREA-TE3U-IOVU-FA3M-BJJQ",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"hUWbG_5jfQQlvbjRNqCNbWqZ83TyDlXvOc5
  G9YCsifriM74giRsoW1JwkrbC5vgu7pKwUBY6oyqA"}},
                "wmk":"X4EtovCfgxUzUgFj3pI8rq9vFhGol9kCYHKNZ4iEZy
  X0fVmkl7MKUQ"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjQtMTAtMDNUMTQ6NTc6MTJaIn0"},
          "pA7f25zgQNDrL67rSonFtNAwBu7KnAIgvPvSfPaJvnW81vw-bmBNwi
  m5DR9y1irNRWweL2O2bHtUVqooxCUPmjALAM3l5WMmfW3CPeaqQ4jmIoZi-eqQ5qO
  yyzvLXcEYpF3OpGtaIPz2s6a1-HnS-UuPDjVlSa2FCahUruXBoXfTj9zpJjDR1XNb
  7H5ogD6qUJ9UHxg_ag_4If1YXrPfJCIrg-OieKPdXaw5mTKm2MNrORmvjZhhU4dPd
  _sU19igQdo019IMNeuKUDzwDt_LhlJUHJOYV_JVL6JcYU89tvSrmh7fK4L1lZJTif
  vk1LoE3U62ZJEarZe8C0Xzgie2sQaQCfYFw97T6Hqflo_VknQ0whdwZjsiDQCo41n
  NfF-t9ibwsYFDFrHIdK_zxC7Q4Cnl4hDRGOVftLx_pNbpT1imjWGi62goNHYzeI72
  soeD6ElHVznsZ_NHzqD5hE_jTJ47gxD_vLPQPnrTSQLo0ZdyAN66zGMcgxOT5qgpc
  EFJJIi1ct8H6MStAx_WcqSta8rLq-vyXA4GfPlcDj2O8o1-4Ldt67534PMi3Th9kM
  gFuAKb8ABnXL3DzFftkmIEhRnZ_9oKH7d6kw8Q6P7RbcdJTDiLIYsIU8_PSwP_LxB
  TNpv-3qRySXxCQmERtvDFIrHCMslUcF7SRflh7UDfge-pAwln-5D0a3rbUIZ7sGJA
  3yHbh13k061HbTOhBdVRcQ"
          ],
        "Id":"MDE7-R4RY-LPFS-EUSU-3EKP-XEHX-V5KT",
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
              "Public":"w2BmbzBeyvQDgSAT3e8aEkWuFerYNZx-ZiVRl_ICA
  5t6nzyVuU-dJy2JnOOzRDN44yJSVNisAT2A"}},
          "KeyId":"MDE7-R4RY-LPFS-EUSU-3EKP-XEHX-V5KT"}}
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
              "Result":"zhVNGGbLIyoQSlgAIntyPClrzF3wzFmAk4NFmTLjs
  LmL3PuvbB4yWmr0xIotV2OpgJ52-mCU8yWA"}}}}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~

