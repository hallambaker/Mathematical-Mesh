
<h2>Initial Key Exchange Example

Alice requests access to a service using her account identifier alice@example.com.
She has already registered her Mesh personal profile with the service where it is bound
to her account identifier as the corresponding credential.

The Key exchange request is:


~~~~
POST /.well-known/jwcexchange/HTTP/1.1
Host: example.com
Content-Length: 1069

{
  "ExchangeRequest": {
    "ClientCredential": {
      "PublicKeyDH": {
        "kid": "MA4GC-SHA3W-A23IB-HBM6G-D5QSN-B76ZT",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
gYNJ9v3DqU3s5qkkldisYvcTI0ZQq21L1A5zAI7wcmn77xTz_PPIQ0ltP2_AAk9b
Xs1wfMTdCmwa2KMULheGVPaEUL9DQB_eWsUlf9vyMgxA8WbcyzMqttwJzGMb1QXL
Z6xTcyO67qD1Ir743L6Amc_WDKFGVuo1HQr6Dmsss7uwOm98oSW_7ur_ijA_JkBK
0OnUiWxGC7NvAu12PZzWMCPq921WGfPFFKNSFX3AgA2k0Iha-FY5G3mnGGTNPhFU
xB7nRoYDcC--V-hEweDpFEDe0SUlCH8eDQhD1bWQoaRjF-al45WVE4OE1yQcHiNk
03FEHwmiGu1gsld7BiOAkwA"}},
    "ClientNonce": {
      "PublicKeyDH": {
        "kid": "MAY7J-GNYDL-XUWZ2-AJATA-7UVXQ-XQ25H",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
QALfOT-zidb1MccOV5Fx7A-r1CoH768c70MzVUdr9YeNFopNAIwcATca_1vgnsfV
RALLNEDDHyNv9MU3o6D8GgIE804phJGcvkRP4Dm1W-U_20Pv_UPUmh15o7K6xTxf
jdw7LaRdb-81q4MxaCI0X_98SwRZrT1mTm7X_gq97NwLzljR4Ee5rJk_Nwh4CNTN
2rYOCix6wE9F2zSwW0X3Dav7UmdiuUEimz_JddcoMxkdStHpb8Kdf7oBhOoeI9G4
_skBjXwuiWJ02flZJD_Ptehd3l7cxM8ll086cLu6WAk0JfNZlp6t9L_h78ekEhGW
RUXDxiUM9FzZ67WRRmHhFw"}}}}
~~~~


The Keyu Exchange response is


~~~~
HTTP/1.1 200 OK
Date: Sat 07 Oct 2017 11:01:54
Content-Length: 1360

{
  "ExchangeResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Ticket": "
T3BhcXVlIHZhbHVlIG91dHNpZGUgc2NvcGUgb2Ygc3BlY2lmaWNhdGlvbg",
    "Witness": "
QxD6TYh6kQql2xmqhtnJzHjB9k3QyxUIdFjdiwCcpCs",
    "ServerCredential": {
      "PublicKeyDH": {
        "kid": "MBRPP-26X4E-XY27F-CBMJ6-FST3T-LABBR",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
u6CPO696SgIxL-kMn99332IWHP5XTgvZErMaDqy81fmZvcGH19s5BOt7Meu5BLyV
EfxbT5M2TOWwec56k_Pei3Weg2kHvGgjQ0pdv02nbQjAm0y0gataOVIyMGHeR4uf
uu2jjKh0Jzk8EULNUuMYnJZRhu1DY6xv4jqkmEk1rLAWEmO4A5ISNgRhcsyjlehB
bQPnYG8YbNp8V5JRUh0U6Q4OahWg8YfK8qb6O5-bZ5e9-6uz3qOvojM_DHiWa0AS
JrAcTWcrjfg0UX94hLNtBzLgCkURhu4ca-iOtErJhdyBrMs5iivEGEZPr1p6Lg-t
Rw6lqehvvKiDsL1TpLvAiwA"}},
    "ServerNonce": {
      "PublicKeyDH": {
        "kid": "MB7WD-NNTRF-2VG6W-OQQGL-UB2VN-4QW5Q",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
oIHS7XCQcs21lpOS3zYZb1znTbKTm7WpEJ9faKF65L0Jt69ephr5mUGULJmmRhc6
urCkLB_haw6PPRVLK99tyQyrONZbsiq0TbUtqnxfYavDX7O1d8oxVrUHVdALpkhe
o1CEqafcaspKjUtICQngW4bU9AqwNZOrojVwJvU1jWiB9zgLsT92XFnIMFX8val1
eIiHb6VNN532t0yo2fx8E5M96KQZYJGDT2398VzzdDQCQ23tNkR1fGP3cJWEa9TC
2vPfJqcEKgLEdRsHE4b6Dp4FGd5Poo6QqyWlVkAJ3NfsMY3XOoQF1MiOZAxE9rPA
QVyAWzMJ3NqkbnFKg31afw"}},
    "Encryption": ["A256CBC-HS512"],
    "Authentication": ["HS512"]}}
~~~~


Note that the example has the witness value but does not authenticate the signed 
result at present. Perhaps it would be better to create the witness value from the 
ticket data which eliminates the need for authenticating the response??


<h2>Rekey Example

(TBS)

