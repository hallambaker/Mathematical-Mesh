
For example, Alice creates a personal account:


~~~~
<div="terminal">
<cmd>Alice> account create alice@example.com
<rsp>Account=alice@example.com
UDF=MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3
</div>
~~~~

The account profile created is:

~~~~
{
  "ProfileUser":{
    "ProfileSignature":{
      "Udf":"MA62-NMPL-3OBH-KM2M-LPOO-RUZC-HUH3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"PKUc6dAzRjjzcGduwfzcfDYfOz2UaRnt4dOnwojJxFnQi
  7ZZbCOF3l9ig518ujdAxMA0VeoslgcA"}}},
    "AccountAddress":"alice@example.com",
    "ServiceUdf":"MA7O-ZY5H-FL7B-7UUG-QCU6-U6TL-HEWC",
    "AccountEncryption":{
      "Udf":"MAMD-XHP5-FHFG-OUWO-3PSS-CPEN-PG7L",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"k6Q3Qlxtxm8fIFp6WQHlomxHw01B7hojqMbzYiPoWBsll
  w48GK4AT1AAPSzgmj_UHWCh9EuvX-SA"}}},
    "AdministratorSignature":{
      "Udf":"MCDU-FFUU-ZXWI-KAXT-MJDY-CPOL-HP2L",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"3omZ2oEdaY5mGD-9q87EpRsiln7u_f30BM-cHuUg-4LmX
  U22hQRHFbi-5oU5LCnX8vVCL83UqEYA"}}},
    "AccountAuthentication":{
      "Udf":"MB72-CHTQ-277Z-BX3C-ZU7D-W7VU-KJTV",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"H2ISDW8QKBK0gcTkJPjKmnSzYBbOCjQvqV7Jif0IqEZK0
  rBawwabcX8II2PcQFW4rQmL8laYDzAA"}}},
    "AccountSignature":{
      "Udf":"MCII-KQPJ-WB3H-OYUC-RHF6-5E6W-OHGU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"XZs5s5lYZuE52LLs9jSm9530pjEBe3DUEGX2uYtqfzFyj
  Fw7QJLXnuaQfHh4s2gdhIM9GwtOhouA"}}}}}
~~~~

