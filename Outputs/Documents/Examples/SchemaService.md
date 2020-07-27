
The service profile

~~~~
{
  "ProfileService":{
    "KeyOfflineSignature":{
      "UDF":"MAXZ-IPG7-VHAO-WQUT-CBTL-HLS2-SKOW",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"bcjZiD3BgPq8NHA8TQslJQo0s8MxGZ4UdOQ_3pfAXhfRGKt
  8wiXee9z36xWBqTeJFHawOnMcOriA"}}},
    "KeyEncryption":{
      "UDF":"MD3H-3OKF-KL34-M6CF-JEGU-A2EM-CTYU",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"pIr9Py5kZnvAOii6tDGQz75dUB53iBB13FJAvsH2MtyISdP
  XVwMckSqNLiyO0iQ2Zjq9BDWVjf8A"}}}}}
~~~~

The host also has a profile

~~~~
{
  "ProfileHost":{
    "KeyOfflineSignature":{
      "UDF":"MB3Z-K5HL-EKAB-6M5J-3PKY-BIYB-JYK5",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"gjioWzUbYj6LLCb44dkaL8I5p91ipNHhrNMQtVQIlP6ix72
  fUZqXDZANgJK3i9u8DcHMxiWHljQA"}}},
    "KeyAuthentication":{
      "UDF":"MCX7-6PCD-WPHH-VF4L-VQ5X-ISIH-TVM3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"OlebIP4cz-8EVWNeDPULOkj2es7vu7AP_NLJ51k1H0XoStQ
  kEikPC_o3qBVblUHvRM0nPEBlctgA"}}}}}
~~~~

And there should be a connection of the host to the service but this isn't implemented yet:

~~~~
$$$$ Empty $$$$
~~~~


