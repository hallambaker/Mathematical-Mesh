
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MCPZ-HDVM-PCDX-BRN4-XODS-XA5Z-42H5",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQL-ITZG-2R6Q-TMF3-YDDA-3N4T-VM5U",
            "Salt":"bJ6_c_OfrpkkZZCU-1LtYA",
            "recipients":[{
                "kid":"MCH3-3HJS-A6QP-RRJ5-HORB-3YTB-J4WU",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"wNwbGaju-1ja9t61bMotJABp0H3VWQdML0p
  dcAz6-k1In8KJo-vFr6EEQup8esye4HlX3B0SNUcA"}},
                "wmk":"tYp8TUPingIoHyHsWvfRnpZNlXFesw9jUenfLC0LLj
  ShzQJlgWfU7g"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMDktMjBUMTg6MTY6MTdaIn0"},
          "xw-RW7CvLuJl9zhDJxcbMw2UeTPuVU637VrHpgo3pcAMaOq-pVknNr
  xDMRFE3MnpSseqwKCepc2_489f3GZLl0unDhPnfrXrFaX4Mu54eEZlLCJ-_6ujksg
  lfMvvs8_elodspsKfaYbsApw1Qwazfy840AXWJkIFmzt2u43DtpPMhQpDrF46SD6D
  1fcZ48gcgZzA66C-ompAfrpF_7gTyjiizK5pGnjfMHObPqNlD3M2xEGDxGD6sQBet
  kEJZhD9L95Nxbw8bNzm4e0a8Bk--NWyzPL89OICTJrcMUpdb9Hw3NVMWpG0GvneZ-
  ItdMU44V8SJCaiRznm-Uk0P1d4kqJzGbg4tfaqrVYi4dOLq0sdXQJRe5elNTnceYR
  bzMF4wqsFjkh7LpaKUsiYNp4dmy4w7N4t9f5hXXw6o6zPk3y5fpCmK6zghcyw3hJJ
  u-nkANieu0I-xWNei7Pkn6fQKHJaf2l6igdcDC-PPxozKpi44FIMx9tjawkdlvQHA
  rAefxTiy8uCZWyYhhWZyKk2o8O9LN5jI2bAfHMUAJPp5-SMM0dT-UqTJHnD5PWWaA
  bPba2EHeQBWq39vLsmQr52GJC_ogtPWO--CEfhZYdDHCgRD96DFdJee9UUspehU2b
  6NLhptnz-Z84-lsQL659JPx-AtiYOs8vgzTgtOZRQMNpmeQ4UIwsWVTGhfdEOfAb6
  WT1kZKS7jDTRiQfz7JLAgw"
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
          "KeyId":"MCPZ-HDVM-PCDX-BRN4-XODS-XA5Z-42H5",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"DdA69XYL5v6HgeNEPLql1dpKqdEwoAlKJEF1AbRqR
  Fnf1GUqiEm7Bg8jdCFhE6weFkArPQspXzGA"}}}}
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
              "Result":"8ki73pVcpL3IcSt5ocXVHxVeWS-tb6ZPgTU2ZVH_c
  ltOQeDD2HBesbZWIbsWBhuGyFaNt8H0npqA"}}}}
      ]}}
~~~~

