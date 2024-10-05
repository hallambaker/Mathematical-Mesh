
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
            "kid":"EBQH-6NGV-JQTA-2JO3-RTXM-Y7O4-G5P7",
            "Salt":"IiPCtyzHkwa-VjqDtxyftw",
            "recipients":[{
                "kid":"MBTT-4LVV-UIQM-RXLJ-HOQS-QOAO-P6WO",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"S192cXCylrJiHbmr3vItlEo1JRc7lkhvTrV
  9sVLGkTyLBwMFZsLNn7_BTSLgU4NUtmLDoiB4QOGA"}},
                "wmk":"vRvl-NncuVwqv7gzddPoTawerJSWYKYQqmxTTj_e0l
  Z2ONlfAkt6hQ"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjQtMTAtMDVUMDA6NDk6MTFaIn0"},
          "y7tHASuLBDPxq6d8zXyWscAm6EEEVMVqTzQ3D4FM-aQh0BOi7EnbQS
  e6B_7MYVLQoZtd3JOGCQu1gjrwpBz8WzzaopW4J0AsgLuCiOxQiSUbpqvXyzwaqbX
  onusNcp2Ih0fCgjKXFDakkw7j_78ZzmIHPyCunVSXoYKVIEblEQc7VFDO41OVbaJ2
  gyGpW9DyBa7JoQGOkdl9m_5zZtLRVDuwXPNldMilWlLJjMH3WZSDT17LZeLCbuUua
  IRDfEAVqclkqlcKmwZZJaSqWk65h9wbCOHbbvY6doPlosdV3uZJQBXGXoltq1t00p
  CikhhxVVVYSTSYGsGvULKZoWat9oxCiET1Ow9nRAZEImg8MeRDqpBfUCUT9YOiqhm
  qmKm7ctA3yD29JK2AfDwmJ_fk1QlaHmXT2-5LPyY0b_UFIKJ38tFXVo5Bg78Eebww
  XQkWlk7jEfM2P8F4t7XJtw7kiiRN1X9KK2r-5Fdm8NuhcFgaam14okq6V3KzbhU9k
  6F80r6dC1fCd6Y5rWNUkwjxKUE2-zWB36IixesVoZBBEJNb5MAf9DJUiepp-Uh1am
  _MgMg_2J-AN_UNGhoLIR0OBV1_asvEWD120so4PwwCXU56-HKWX9uo55_fp_UJZZi
  RZ2BVr2uJ0jwCkrdoeFbwajK0TO38shWlm_3XVlwg_Js8QiIM9oMyuprHDBtb1mTX
  PfE6qIFHEhluf9bnLDwGeQ"
          ],
        "Id":"MCJO-U3KM-KEAD-ITSC-YHU5-2P4A-OGLX",
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
              "Public":"T3sVdRmQMcbOLPYkdJrW8GGeVnwapqgLekg8MAyH_
  NblG2ZgpFXFNZxZgR4MmQRUTOnaQEkn6BCA"}},
          "KeyId":"MCJO-U3KM-KEAD-ITSC-YHU5-2P4A-OGLX"}}
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
              "Result":"QET9hAMzhiHVDksErpZmPx-O7Jhn99DA4jntTLQ61
  BLITfmXERz0ft_fw1XRrcj33J8HJNjOkdyA"}}}}
      ],
    "Status":201,
    "StatusDescription":"Operation completed successfully"}}
~~~~

