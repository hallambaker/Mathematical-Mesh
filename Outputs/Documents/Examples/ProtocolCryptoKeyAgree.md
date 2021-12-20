
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MDOU-YNCK-RN72-PKKQ-LHKZ-HMO2-JPHC",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQI-5LBE-5UCS-7YYY-YPBN-65HA-EY3V",
            "Salt":"jTTtksIhWHcokUDfTObUOw",
            "recipients":[{
                "kid":"MBEC-N2VX-7PII-YBQF-2KPJ-24T3-LQBS",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"hnfGDXXG6qSvlnLOnPjYisZCtD7ITKBbzX5
  KpgTQCxUUMuKFa66ZkLD1arTQAla9p834HL6qyhmA"}},
                "wmk":"Uj3K4IS3Duq5abRE-uSYUgqO2ADLafljWQOyq48JG5
  TXb2i9OHRLLw"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTItMjBUMTQ6MDA6MjlaIn0"},
          "gjWCERYM9q-od2F7CbQ5lqiiTfmWVERcaMiFH83j1a-bAXeEHbXrLl
  ecJS19STXxRRt6aytBtoYj5aheODbAwceCLjdAkpg5IgJ9EvPboI6sV78yq4vanxC
  f2o9q26sAtdoBznxy8Cb2Q8FeZLzqW_tVWjPpKEkAeKzZZn3OAVxDMUgkmYDqRZb8
  TyF3dnwZ8bIkWxIGjUB4iD3y7IcpE_3p2sBxoWUgjKVG3GQOQ0VUk5BgfJPxEN7wI
  4FEh6J3Nf6Fz0PMlMFNyrvR3Re79oP4_gvh8xBfUAn2olYYuGHpSUKT_OoCgO-UKD
  G0LToYUtQO0b7ukXKJsGE0La4_GVQQsrVFSInFKSM381fcQxQifBMmxJ8Tq1nfr-Y
  PekyHmPxcdeX15ikO4AfVC7dL_zBglvx9Z5n7TlJq-0153LOOX5w6hLhYGDKjM6mo
  h7l8Lw0xc8YiOlDX_aYDuM0ncEstTGurZFFKiQJ5MjEFD_NZPByG2OHX3jD1oFsuL
  lrS5zFrYal4YbRHxjdz8zLfd1XWrbov2QJGeejeZFBY0NGbNgDw9XpjK2NFwykFtH
  XRqbBdSJCtISFGAe43rNjTkd6SQwAiWoqfjCkbcgPWIQRBBtC4Z4l_BHH4G6SrV9v
  7qxjtEVd2_ajF8r9YApVVXokQRTU_RlT4YudCFJY-1BImZItdkxZAA7Ycmx1eO5Bt
  geQEj7v9Y4sAZIhBumVEYQ"
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
          "KeyId":"MDOU-YNCK-RN72-PKKQ-LHKZ-HMO2-JPHC",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"bW46eWG-GpBid7xRKUAmZZ-varGwbdLk1VEy7QVOM
  lOqe33k0EnfrmNX8U8Oa_OjkCNiIxHQicwA"}}}}
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
              "Result":"JHFfqQwWeDIOx92JGjWUfac7E9LE4Cj6Hsn0Cvokj
  LtK1qTwLwla9HWFUsmeyP-XzoRNQdwuAroA"}}}}
      ]}}
~~~~

