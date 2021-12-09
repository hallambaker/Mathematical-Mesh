
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MDMG-5KJT-SFQQ-EE3U-GZAK-CEGV-5GR2",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"qdbzMAn7YpbLjLEGhza7F4gWg71_VaQxGldfKfZAG9EIM
  oqz_4-NYdVD5FLbeUX0o8PP5MrSTlaA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MB7B-JS7Y-IUYW-TKPL-Y5NL-JRPB-LTSV",
    "EscrowEncryption":{
      "Udf":"MD2P-BXLX-J44E-GOHO-7WP3-BA5X-2D7D",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"VB76-rhiS4lYeCYh_B8_l1FcBu8d_p7zYRJfC9mfjCga2
  nKS6YBdukbSns6ax-O24fnQ5WkEJdaA"}}},
    "AccountEncryption":{
      "Udf":"MDJ6-6I36-OCND-X224-DSD3-LMDU-37Z4",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"34Lldzb9rPQeqG5VzbHJSkR8_6g_HlY5Se-sC9j7P5BK2
  Nq0NpQNPrqvJT7B30mP7BwqB9wAov6A"}}},
    "AdministratorSignature":{
      "Udf":"MBQK-3U5I-SGKF-T3GH-MTCD-L335-IDQI",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"-tMSK_ugti3I_PsvYGLQQpMS8_GF2LecPvMWY7Q_SV8vB
  F_dHqvnTSXXMVPHomQnbG53D5QbEVCA"}}},
    "AccountAuthentication":{
      "Udf":"MCER-5W4E-3R3A-XZZT-S6KN-AOVF-GJ5N",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"z1Q06Xz9wBARdUjFYTuwIjQYMQ2XVzcFG1ZLF3O4LdCTn
  YVuCbZGAmzbGXJxFHA5Xf6jtRI4P6oA"}}},
    "AccountSignature":{
      "Udf":"MBYT-6KBR-3GF7-E3CS-HTYV-63RU-LUSG",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"xr1DZNn-n2n04Rc7Bwe82lxy0VMJoBCn-WVXKUlnTtZIV
  HE6f3Q_brrBxkxQG_VVpEJ5_nE4xyOA"}}}}}
~~~~

