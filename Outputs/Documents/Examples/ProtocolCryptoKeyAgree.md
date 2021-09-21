
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MDXM-ETUI-4MNW-XJEE-OU5J-L725-ODYN",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQA-BDFH-7BTM-QQXV-Q462-UK3J-3BWI",
            "Salt":"2_EdSy8aYGsXfPEMw44FKg",
            "recipients":[{
                "kid":"MBBD-R4KA-SRWR-CYAK-DGPV-65NT-3EHB",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"ANQKdaF82i8xWXjRTROLb7JqlDXxLpvh0EP
  Gdm5BBn98BzcQi-mRulFhg4rak0HRDfN1fUg7Jv6A"}},
                "wmk":"jfZrYtb7GwH-oAvqyCkIQJBUmEl6jD_twe0B_vaZY2
  YqaYuywdaMhQ"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMDktMjFUMDA6NTY6MDRaIn0"},
          "dfiwRwAtDvaIWfs-vQ0NKXOf_aapeA1hqWsPohqlMyZVTmTGRdz14R
  RABkYs-AQlKGBVofgaHcVfwZAq5dCIx1mIHUSgqkKTcOrsRz8SVZAmFcDluZdzQBb
  Oskzkeock_aD70TA4UWS7mg6OXRf-AUwoFl1Y3ARJQTyI1bWkLLsVQsJjo_ZziIqE
  DCeS8haBSZVdrN6mD0dQojWd3heeAx3wvxx2CxMVjjszCUaqDMGU1YBrNv4EIjcHC
  qpGysdivCm8wSaSM5MYDBDKN9dEwYPOqsK6gac7ihziLk6x1oBvnEkp59iWr1ZXm9
  3d90Eqip4ljtawQKXgWvp2GhX6W8gb_5mHFnOewUDEzg1E-jx7ABTxJlVx4ojVo7L
  OZVRwxoaGL-sFNTiEvpIhhneQJpSJwDu_2_JDe_xyKxpPxd6wtHnp22Gmqnpend4o
  EuBTRQ6ZzFOtkODtedhQP6TZUWM7j-wpn2SAZvwYmgDJgqN-ykB4i89GnSSSsVT7f
  haXEDZPlSlDhBDDgxs7VTtVSSoE56oT6T317ayoCofx9AktyIeCJg6mlo_ffFc27u
  ToLzshQUc-Qpeq7iihBC1BFCcXG-IeGchuWNgg4wvLwLyUrnzRUPD0bJeOaLflVg-
  14L00hae549rwrFhjSEq3fJwVzZ_oaMqZyeaKsMPYXwMKO9cBxb56hmzgAkZ8lfLr
  KqC1azWPYVxO1k1_0ejjxA"
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
          "KeyId":"MDXM-ETUI-4MNW-XJEE-OU5J-L725-ODYN",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"X5yGTtai6qyrHt03hFe0NuRXkw4tuozLBMYkA1_2V
  0hnVmxxo8mqbYX_8GIXmuoS5WTRY8b4qNqA"}}}}
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
              "Result":"MAcNMzSJWp1XHY-jAYD0z3RjHcTDHsOKNLe2Rcpsh
  kq8-dKLMn7nG_qRVA2pmCZqYv3ehPrxiu6A"}}}}
      ]}}
~~~~

