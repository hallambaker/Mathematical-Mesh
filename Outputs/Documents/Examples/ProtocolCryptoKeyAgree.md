
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MDEG-PW6C-LVGR-OEJ7-3TSJ-CUC7-FNXB",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQM-KXW4-KXTO-4MLJ-VXTW-F7GD-VQOC",
            "Salt":"PYvfAmOV1ZIz8Y2LlN9bSg",
            "recipients":[{
                "kid":"MDY5-ED2F-6ZNA-THJR-SBQY-6ADT-EKS6",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"HrEWEeKSOwy175RRWg1elwue301kEnuC4YX
  3vHJWw1XsYl1aBjvPVUTEbRqkFWjh_JgJoClVEAQA"}},
                "wmk":"3o-9cpXQtd0RpNq-jzlWZdb2T1_MtHiCyOyiAez0Yr
  l494lcR-gleQ"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMDktMTlUMTc6NTI6NDFaIn0"},
          "3X9Dy5Sy1yiGsDLC0iYkze5DUQV7qEeQUpPA-qM0zlz3N7QVK3W3aV
  QNXasLJu8dCMnmb_eyO8EYSLwEV2sVFyOozjS7A3VSZd-iLIQ4p6oqow1x3VeSqn9
  ppjK5PyJP2tLM2TE8R6TczZ3XbKiX1a5poc-SJF0BySIXIj-gPrLRFxyGuJ-K7Q5_
  xDUm3kblwBo9P_so6r_XmCXwhXB_gS2xxwGU3I9lCjbGIWBJER7dW_yO3o2fiwXRf
  zQdi88Tr4pcYbqzOSQTRTRZ_AkGkcLNUXTxxphW_oMejmC1bLEO6_BoRRDAFfzg41
  oDwlswYtIl8uMiS-cPePdIHPeTU5P3HNFiYkELyXJUh3IQihJ9gXUSr6Qbe0yqFjf
  lIwsQd3w1G2iADauqScEIzMtFJrp6bi98IbrcWlBtUXtVKCaHyKXHnZ60JpYcSW6n
  lkUvBtrcOqAwmTj1e85Vdi4lxjOmwp8plRShRg2d6oKo6stsKJTtZ5o97LWqLcq33
  J5974Me94KU55P4FqgYPwLis2EieXSYiikv6899l9Etr3nVW_8C5gkd4JRl9yH46z
  GK6jgZPfTDrK0gNLFIbo0cbzZOWXu3c_YnyQwLb37w8TzMHC4vPQSdd3b6ERY4LXo
  rZx-cdRE_CM-FZeNzmlg7onsJLp87EhhMaqC_KvSAHNKOSr8Fcrq6frruIlNndKcM
  yzBDN9HwVA_jQIibtIrZiw"
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
          "KeyId":"MDEG-PW6C-LVGR-OEJ7-3TSJ-CUC7-FNXB",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"vMmXfUCSss48TgsdPABHs1wTeA2N5Q6VLbYrUZzEC
  3M5QUlmKQ7MPeaEnpNAs7Y6k3aAkSSSP9gA"}}}}
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
              "Result":"86GtftqkqDFxfhbdP0GGsIE_F_YvZK5n-mtqtc5_n
  5FC1JnkUGXxaD5xex9sGWT-eHX1nkyTKkqA"}}}}
      ]}}
~~~~

