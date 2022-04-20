
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"ni85QjaM8wU5vRoKmwnxD0F9c4SK303Mk0Gad5WlJ8hgB
  iYWw9oNzmi32sw8XAmer6UM0SoTc24A"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MDSK-EUHS-QXGD-LKOF-AVC7-V2RH-LV6Z",
    "EscrowEncryption":{
      "Udf":"MBZP-WZAZ-B6KQ-MYYP-H7KD-VVBA-7T6U",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"tR85RCqWv8-X5Bk0NU4EVljQFJ585FNE3ZwyWzXSVtJHi
  x0FZ7jZQ7xg9uurw8KOKl5M0UW7LLOA"}}},
    "AdministratorSignature":{
      "Udf":"MBDV-XXNH-2RUB-RBMZ-5NG7-L3CD-3THV",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"HUwN4RVhGczFlOm2bDcevvVYyd6gjdq33QqV8Uq39dGas
  RzQn9_PVgCBRI_8MjiverTKdaaEI32A"}}},
    "CommonEncryption":{
      "Udf":"MDPR-FJVW-GK5Z-2LJA-LMYV-XSCH-HE2C",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"55jUkmqn3gwG0b2HzDVu3Hlf5sO6GgVlj_vaYFwAEksDc
  My3wyvUwt9ojkeUKT6304Dwfrh-Uw8A"}}},
    "CommonAuthentication":{
      "Udf":"MBVI-EWLO-EI7J-OVAK-GGZH-6YHW-ZJSU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"fTU3TeB1-7K8SZpo4tQxZPpJAb-_d3NIdJhlkxWaiZogJ
  REK9adPf9Kns5mqr11UTToIMhzfdJaA"}}},
    "CommonSignature":{
      "Udf":"MAMP-BX4G-AKK2-YHPA-IXJV-Z2KV-UXBW",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"Y6-D2DbbKlaVXvG5ZQweLd5_kP1ECACR40bDmpg-Y4Ks9
  2FNe-uysWUrM_LmQKOIPjjr5L8NOBEA"}}}}}
~~~~

