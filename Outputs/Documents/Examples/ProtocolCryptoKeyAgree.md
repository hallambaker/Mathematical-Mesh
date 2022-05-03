
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MCF2-77X7-Q5FS-DJG7-4HCE-ZHNT-QSTM",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQJ-MGPJ-WMWN-2PUC-XVVX-U52L-XYHV",
            "Salt":"rlxBAWHqc7iLa-h124zQew",
            "recipients":[{
                "kid":"MC6X-PZL2-5AFN-73LG-KV2Y-U3UY-V7LD",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"lpsGfGaN6rUWGwVtPwNsPWwzRQXy0wctybv
  MoJmpBbNaArMfdzBWrxKVKH6i3Ggb1XNsSfLrng4A"}},
                "wmk":"w7g5-2NYYCeYMjKKzbP8iO1xInCDslR_XIDd96WrfV
  Qn0bZ8SJeHsg"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjItMDUtMDNUMTY6NDc6NDlaIn0"},
          "8LlL5oXxaDJPQIeuIjwannzM_mIdbCgwYwQQV9LhuTzksPg4RpsJpa
  F0W16MSrxH1KZTYsYm3WoNedRk_crEKSkA-GpzDqTu9V7WPiUs-LQMLhQ3cLZmp66
  oao5hsjywqEFi-IQQY6PwmK6iBbqP55RbqAxVt1ivT2gkszRim7ZJvXyqFXiFDgWZ
  m8OgYaBvXRMQ5xLMa5nsLD_iEi3wWKta-xfW0gcPuZdba1z1n6MLUWur7KrHUolBa
  7VtrAqzZwKdAM_Am6Bp3RRqFei2LS2hkjnlZKMq2wBZTbSekm1HCDiSVo3hOywVN0
  znYocpd54RyKQgPhR68-kluyzaxPMuuyuomNqQNmnwQbi8lt6CSBt4S3IryOFtroQ
  Kh2vETzTHH18A9T0Gu5PfYYwslSvaNoc4gwvATlIFKoElS5ca8t-pD6zNVqmF4tz1
  ln41Uqb9Q48UZkNIqlAOhhXSVfxlEOawrO0Dm6yrfsGvUsriiLpxhtOLljKJDAyi6
  rRKKMkuO_u0wrOGmFMl2Ewu434nKag7FcCoZ8yQvh1tee29us0HJWHZZjjOXBP7GV
  cbOq4sLcQjSKddhufEWH91SAMzsFybf2bclVjm0J-Z8uhXmyh3Q3eTz0DrTCUTUo9
  l22UtrGRqDX1_aapmELfadg0_7M9UmqpkQY4SNWEssuGEIQm2CjA_00gkHJWH98jn
  VCR-n0WIEsL5qU6OXMxs8A"
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
          "KeyId":"MCF2-77X7-Q5FS-DJG7-4HCE-ZHNT-QSTM",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"6g--3_5bty8vg41b8tK08-nFeUNObahnomLL1LN43
  yLrNcYXCsJmYTjiMYFGBU5kZXl-vYLFOf-A"}}}}
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
              "Result":"briigu6GI6-NODNwIQC47od8lyTFDvQ3kW1F-ghZ8
  _I1gR7WUbeNaMh_1Rik89qVajPB6PwFIVaA"}}}}
      ]}}
~~~~

