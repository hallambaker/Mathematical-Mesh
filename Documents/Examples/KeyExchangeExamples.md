
<h2>Initial Key Exchange Example

Alice requests access to a service using her account identifier alice@example.com.
She has already registered her Mesh personal profile with the service where it is bound
to her account identifier as the corresponding credential.

The Key exchange request is:


~~~~
POST /.well-known/jwcexchange/HTTP/1.1
Host: example.com
Content-Length: 1068

{
  "ExchangeRequest": {
    "ClientCredential": {
      "PublicKeyDH": {
        "kid": "MBPYH-H2LPG-VWBJF-MA7GC-NZG4X-M3G2A",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
DOYRlkYn6wlvbT-H_9i8jZAtCqqhwEZR92Q267qnRRycoZSGYH7FJzIvocEx1v-u
F_05IpYxmSjpkEVDU0nFw7LswqmBDnwcQaV-JWPTdWCbFChW0OiTvwTG1SIgEg62
0OvneArUyMCEujimB9Y9hAWOkFD6AXFUk15MBaMrJRyzCHnrQDnbC2SRBHInuyeP
RiRcIJqfMO2nQeMwT5yTH1STb1_kLzu_hpHJ3EWwfxsqqjjScSq5TrshFtJ5__kL
XAgepGXuwmLBB6sXEm0sxdwBf3lWa-kyYmTfcpzR3C-AXDp4irZ0t2_c8Bzg8fX9
nudLU-QNEzb5AWBr2dWOBw"}},
    "ClientNonce": {
      "PublicKeyDH": {
        "kid": "MAGDI-IMZJX-3QNLR-62K7E-BBSGW-GKCM6",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
Rv7ABgNIQtyis5TFe3y7vZ5evFg0BKhgtyuJ-vr1aCuMyyFyGyMIaQfKxlsZawkt
zuiqej2RYV1LQb6rljnP3z7H-WdqK9l3onuJuR1S_bvBkosjD1KtUxGY_Dm1MkvQ
BHUBnTOt3KTIpcOORZmsyiQmtvHqXYUdoiSD6Fv-R3zRZ2XrSClBGoZEra7-7aAs
s9xwGy_bNI9iEPEWL59XuSdmSwkJmeMyCGFj_tLq4CwYdoyBFpvHB78RxJBXxmRY
MWdpWW8D-171YzB_Yp8vBnJQ9akVVyfXoHCRa8nIfq43snyJdOGZGGe-KbNVmoha
ZvkF4B-4PuiDyuFoQMHcAg"}}}}
~~~~


The Keyu Exchange response is


~~~~
HTTP/1.1 200 OK
Date: Fri 10 Nov 2017 08:25:12
Content-Length: 1359

{
  "ExchangeResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Ticket": "
T3BhcXVlIHZhbHVlIG91dHNpZGUgc2NvcGUgb2Ygc3BlY2lmaWNhdGlvbg",
    "Witness": "
uTDCL_X_WOfx0TtwfiF5bNZYBTAco7fcRkxyXpDV9kA",
    "ServerCredential": {
      "PublicKeyDH": {
        "kid": "MC7JQ-NDPOL-QZ6D6-RQMST-AFKOB-YDDYE",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
YjM0m-TunuiRX6TK4pNJf8j5Y9XlrHG9WU-VprX9tgsVP6baQzVp9Hmhqr5ASnNg
PWvd2S19Q2vtih35V2cVnwvLHnpEJH5X95DRHqMp-S_RkQLrJU57a_OhKGSjvBtI
halMHKBTXbIgZ-QZrvodp9z3LLYm3OfXlesnSNKcdPWwZFXCYDrhDRZWsxQt_SVP
QvwFHwXEHZYcA649yIB7JFSZw_gbza8M1W5U_lCw5VW-hLAUb4SogNUmynnpopnV
xlgFUwevq7wNO7mt55UaQDsfFz9Da1UeuwEy89uduHjshFvCC_Fhb8QTJuQbAIvJ
5Xa70y3BCoMzJS9RtglKUA"}},
    "ServerNonce": {
      "PublicKeyDH": {
        "kid": "MCETO-ASH24-Z73CX-U33NC-WETKU-57SWJ",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
J4NP-n0RRPMQ2GyOiUKjYuTYiFAEKj_vaQCydDsvqKRtvAv-NTIWSfrE40i-60dI
J2wKV4uwMlhebM8N3byGBoe22NDKAuOHYoBv9X1gVtQWfN8bTTOu87QKfch6IhlW
KVs9cpabmYTms_lzK0KY88EH-hOMaTnxsb6kPt3W8l84RnvJdpQSHIOQuXF4DNjL
7bv1FnqYmWhGXnTGy7plknOq2nNYpP7YoPXMqK5n3rj7yLPQFZC6zKviS2ri6CaV
3E5rfyUHO3boAO_QlnzBm3pxRFpQyeV6qogfkU8hY7g08EtC3TgFi5wDYL7E0CCM
yUUVNXSh9X2a6cjsfP8dRA"}},
    "Encryption": ["A256CBC-HS512"],
    "Authentication": ["HS512"]}}
~~~~


Note that the example has the witness value but does not authenticate the signed 
result at present. Perhaps it would be better to create the witness value from the 
ticket data which eliminates the need for authenticating the response??


<h2>Rekey Example

(TBS)

