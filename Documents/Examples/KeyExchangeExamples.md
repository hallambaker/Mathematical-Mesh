
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
        "kid": "MD7G3-C6CVW-3MYGU-RDYB6-KRY2G-HICUW",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
UD7EVJT3HpjWllq9FMvHLQlMKEswExC8sCzlsni1bWvhnlEpcDE6dPgMYTOuyNkA
sD-RriPxQiPHcJfZkfK54GGTcJphlIgGiieXOiYLCRla-nvQix3_p8-KNk5wM550
o-SclM0LI1zDi2nV3lgO9vhEFoPAlTm216gkO08yxJqyV_HZL6Wv87h0Ga90nTuZ
3v0dmCUUSz4QH4ZfQd_DLJlkYv8CULO-nO7sTvSmSloYUaKBv5T3bjq-awNGGotY
c-lLgJv3nhMOxeLoIFsAClZm1-hpQe6Z19Tr9vL4jm6yNw8dC2xJ5ShoBV4XC9Qs
sm-3tFUkkyfzkGlavslbnwA"}},
    "ClientNonce": {
      "PublicKeyDH": {
        "kid": "MCED2-DY6HD-LMU26-NZDNF-PMSFA-JHIUV",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
ttYQUqze31h83KXoMolNnK-AkJPLabht0nEC9RTy52xvVJeKYN8yxZTTNteiFvhq
6ke2PfXaadNeYEL3ISnCTeT9wmD6ZQwnZAwIb4416zS42oATMZVs0L_pKisudUHD
DK2FIviQnt1OTUKlfJemEvaMVNIc064mANasXFPU-yL4yv2DrkGMfCSGnH1Pt1bw
mHF2LndhqbLmbPafZfL8edXWrbPQT3482EY2EDW81MalqNpbA5yJKx9sUUuRnHj8
R6F7Au7fTqC3DxFVywehy5pBtpodyZfzmbSaUO0dlpP1Tfe8xILRaMeG3nlt0WQw
xEM3pn--MMcEx7mtdZfDpAA"}}}}
~~~~


The Keyu Exchange response is


~~~~
HTTP/1.1 200 OK
Date: Sun 08 Oct 2017 10:11:41
Content-Length: 1360

{
  "ExchangeResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Ticket": "
T3BhcXVlIHZhbHVlIG91dHNpZGUgc2NvcGUgb2Ygc3BlY2lmaWNhdGlvbg",
    "Witness": "
lqWXkx3zj1Ex3nBp6GTKJO0GUD9qfRsUI3759S7V5y4",
    "ServerCredential": {
      "PublicKeyDH": {
        "kid": "MCDJ2-ERISF-HEU5V-2CYDI-3AXUR-BNJX6",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
uSDWcnHImlmwDKTOZDhQaxd5_idjtqSOn4Nr_ZY-MWeC1qcAC9o7p1cNDiax9mVK
2R8twZx7_KT_u2jiVyyFcGA5qJ8-NPxi0VvrG3bQ_jdgpCfFVuoinTj3tIO8cQTX
L8ujxG7o8Zy9iR3fG27Sg2VhHIePbm87-xWBaW03ZcsAdS2ewrYLx7Lp1G3LHNXh
aWntO-97yMgd_j9vMz8AaocC9b-Xog-O6lInc1zIow5p5qHTIzUiLN8RnV6-hyh8
R_vu4aAWBhmD27uxuXXb9YUzgL7cE4ZgjVrK_W2Ti3hzF25ZDnIy9f8okJM7HhDz
kmIc46zUjh9RdSH-gmbJdQ"}},
    "ServerNonce": {
      "PublicKeyDH": {
        "kid": "MDBE6-M6VZZ-KNZFX-V3OQC-IBWEH-YIWFS",
        "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
        "Public": "
JKe6QgcTxCvVAHST4f7vK1u8Yr1DXxXSs-56T6Cc9LzauZ4n0bTzrC9bbPFQrtBO
7GVmHNItzbN8gls-ACKr09ZQTztYF2z0mIpZ6PRLLWCJqrIB1UR84wOk8G9e3gvf
hIiqTbVT4VMUX_nY2rrljx7-XO2sWI9iZYoY7HeWAdYzJGzAQUJlg2bPvba-rvV2
Hs-bcLVwl3-NcSfivKiT69ecQz4AWCdhP5y_DrnR20FRvtBJDJIjeqhzTbYwrEjk
3RkPxtDURq0SeLXkCsYUGeNUtSNKq6-K8MPveHDZhRYUssDSguDz0_gBeNhbJc3H
_exF7zeujFUdWKVU0uWbtQA"}},
    "Encryption": ["A256CBC-HS512"],
    "Authentication": ["HS512"]}}
~~~~


Note that the example has the witness value but does not authenticate the signed 
result at present. Perhaps it would be better to create the witness value from the 
ticket data which eliminates the need for authenticating the response??


<h2>Rekey Example

(TBS)

