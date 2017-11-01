
<h2>Initial Key Exchange Example

Alice requests access to a service using her account identifier alice@example.com.
She has already registered her Mesh personal profile with the service where it is bound
to her account identifier as the corresponding credential.

The Key exchange request is:


~~~~
POST /.well-known/jwcexchange/HTTP/1.1
Host: example.com
Content-Length: 1070

{
  "ExchangeRequest": {
    "ClientCredential": {
      "PublicKeyDH": {
        "kid": "MCYH4-7QXL6-U3OJU-FR3RZ-X5Z7G-MDYSR",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
JZVsCJJfE8Nka_OMVcixjiDV45TlsrpvZkuGEfbjjdcSojjMLBC_aP5WXtt-RVZ1
-B1ABJxv2clmK8gXks8tZZ49xob5CVmJUk_-Un_ck5BuI4YQ6Sa9Xd0FZMRTcS4v
SFO9rIlHwRHukdAa83TO_u9uWsWmnIj_KTxyFBQ5jZT_XRqiVZAsGYPhdsSvLV3F
Dt5Ukznft2LEB3dD4apkpheeaiz0Oj3tPi8j0dNm0c0XKdit8mDoq7WAKRhpAygz
YzxbCJcRYF4J_F8HpNKUamF-9233VWRxRlrs-YYZDX-UkuMn1DhVcV3vZpm3FNal
3_hW5-itTo5ZGyFQ22cr5wA"}},
    "ClientNonce": {
      "PublicKeyDH": {
        "kid": "MAQD3-EJYNT-DK2PU-M7HSK-3EZ5Q-MV3S5",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
9kg1-4_PhgQN6A3VZNOigHzTuRuWp9nXxu3EaucJxdmmB-U_db-_HrGv7JycEFwn
dxU0vlxJBu-8ltzFLgvMEMlC0bRuTxgMwz50E0l7tKo6ImiIT16ES3ITwtNtG743
6Z19fYjbtwD1i3HeHMfagxWEV8mu4w4eTyZKyDHp9uxoW5FxnuWbJYudEqMiJE0l
0epAKaMW_v5-dK0MCIMTV8peQbEJQLimLrFxdsfj8TGG_iTRejeM42Fq4NuYXtBQ
cIIYBzFkmNNhEdJRVcq-COVcajWergMsklbrAxD2lullUoYseRK3C3-AfT75seKT
6ONEmzrZ5VtmEOZopLXt3AA"}}}}
~~~~


The Keyu Exchange response is


~~~~
HTTP/1.1 200 OK
Date: Wed 25 Oct 2017 08:29:48
Content-Length: 1359

{
  "ExchangeResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Ticket": "
T3BhcXVlIHZhbHVlIG91dHNpZGUgc2NvcGUgb2Ygc3BlY2lmaWNhdGlvbg",
    "Witness": "
tKWAnl6bVFQj_qOun-BBUiedIUbrLkN4B9QyHno4KGU",
    "ServerCredential": {
      "PublicKeyDH": {
        "kid": "MDEQE-X23VF-TIR7J-DF5S2-56CWQ-TLTM6",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
KANgoKLN2Tj-bKp3qldHdMT8YHeJpD93_iy7tDnMpkANbzgNTRLESWBZOwfOHzqR
gJWuXKLn25l5J2yaAsm5Gkqgq7iioiCSLxtuOQwoNJS-MRETXX41maRGo_zbYJJW
zPr0YonR6GZgMRQJionO-IAfz0XV7DUaroXHjl7PpHPfbJtD_eFTjBYZrelhLsAg
uEqoD_oM8Y_8tcSrtjynqA_JHGGsgPhdIfFsHtQtH0E16dR6Ob4WtUYr17obJJXr
0w2bVRe8pHoeF9UK7AN5dIsPGyFQ6dm_UsWNxn8BSE5pqAoQYYh6QTcs5SD11rBG
8r3tLVdeyWQ_wdwq1yhpWQ"}},
    "ServerNonce": {
      "PublicKeyDH": {
        "kid": "MDKP2-WP5DN-MRO6Q-35RD6-XQ5NL-ZYJQU",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
BiEUN2V2Ol6xP9Ar2Jdk0imug6gKJB9HVM8kaYAcuYk6ozUjwIGNhkA7ePaPTKE6
81KL7a6QKGQL8UUnBSdOhti0JEAakLr2ErlJK_2P50QVZf8w4QPbv-hKFTAl1lft
hB4v0pOJWjBw-AYSewudS9dAihZIZQ68XyJIQWfSW0u2vAfhHi6MsNDfmJ2K2auP
1O8E0PIrMQxDJk9Zt7IGKhICion3LT0OnpSJNlsH7Aunro0xOeY3B4M6EE2yERGJ
rbGHLu07rfhnTSqVkMPOJRDRmBZpyKThfiauEeSO_jvN1aurQvBJFfQB18qoXnLS
1ToCVgKj8lg-13P5X_yVag"}},
    "Encryption": ["A256CBC-HS512"],
    "Authentication": ["HS512"]}}
~~~~


Note that the example has the witness value but does not authenticate the signed 
result at present. Perhaps it would be better to create the witness value from the 
ticket data which eliminates the need for authenticating the response??


<h2>Rekey Example

(TBS)

