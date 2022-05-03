
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> meshman account create alice@example.com
<rsp>Account=alice@example.com
UDF=MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"SjBIjXHPFfPW5pVqo-KquT4qCRJOL82yNbDf9xFabi0vu
  nP3XGffV8-s8WJUe_H3WCX9bLIW5zuA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MD3P-ALTL-T6I4-U6ER-O4ZD-5AP5-J6SO",
    "EscrowEncryption":{
      "Udf":"MAND-BKQ3-XXGY-AYTS-L7VX-OOHW-HT7P",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"YBdCsK_SyB5pgAkJoxlKjmsXS9bZtyMS1RVJVETLXR1F7
  Wp30L85U84DX7LfsGPKS3YV8tH_FdqA"}}},
    "AdministratorSignature":{
      "Udf":"MAJ5-HQAF-XXGK-W6BW-EGH3-ELNH-EQ7I",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"WmDloJ7YAL7FeDYIpjXW5cF5pJ2xwYXD2s7_YBsJrys15
  KedP4C5y58uN0n3ufc0uOyx6vtRqocA"}}},
    "CommonEncryption":{
      "Udf":"MASL-5B72-3K3B-PKQR-MGHP-L5QP-MVOA",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"yx7_72c7tOCRGRmKQQa9ja2v9HZEnKtFHowFzFehHJrHK
  zRrwyaVf3WvudZE4xy680tRIoF7u4aA"}}},
    "CommonAuthentication":{
      "Udf":"MA76-DK4C-DZFG-CAVP-YCTU-X6O5-ZU5M",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"54SUa8ieu3HENQpsiugoJtfALqBUCx_JcPOYJagYGZsCA
  VE9ju754z8YW2Gzya-sV-hdaUlSXrMA"}}},
    "CommonSignature":{
      "Udf":"MDWZ-36RF-622V-XT6X-O6KB-3S5J-4JE3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"xruAnshybRzxDhw-Mk2t0bQ43bkEj13cJF6twKb3x-jWx
  uOfMoRL-xqqhx5p6ZGS-w8HtNIyJ14A"}}}}}
~~~~

