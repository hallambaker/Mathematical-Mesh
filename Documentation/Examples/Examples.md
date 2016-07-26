
#Protocol Overview

[Account request does not specify the portal in the request body,
only the HTTP package includes this information. This is probably a bug.]


##Creating a new portal account

A user interacts with a Mesh service through a Mesh portal provider 
with which she establishes a portal account. 

For user convenience, a portal account identifier has the familiar 
<<username>@<<domain> format established in [~RFC822].

For example Alice selects example.com as her 
portal provider and chooses the account name alice.
Her portal account identifier is alice.

A user MAY establish accounts with multiple portal providers
and/or change their portal provider at any time they choose.

###Checking Account Identifier for uniqueness

The first step in creating a new account is to check to see if the
chosen account identifier is available. This allows a client to 
validate user input and if necessary warn the user that they need 
to choose a new account identifier when the data is first entered.

The ValidateRequest message contains the requested account identifier
and an optional language parameter to allow the service to provide
informative error messages in a language the user understands. The
Language field contains a list of ISO language identifier codes 
in order of preference, most preferred first.


~~~~
POST /.well-known/mmm/HTTP/1.1
Host: example.com
Content-Length: 88

{
  "ValidateRequest": {
    "Account": "alice@example.com",
    "Language": ["en-uk"]}}
~~~~


The ValidateResponse message returns the result of the validation
request in the Valid field. Note that even if the value true is returned,
a subsequent account creation request MAY still fail.


~~~~
HTTP/1.1 200 OK
Date: Tue 26 Jul 2016 04:53:46
Content-Length: 190

{
  "ValidateResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Valid": true,
    "Minimum": 1,
    "InvalidCharacters": ".,:;{}()[]<>?|\\@#"}}
~~~~




[Note that for the sake of concise presentation, the HTTP binding
information is omitted from future examples.]


##Creating a new user profile

The first step in creating a new personal profile is to create a
Master Profile object. This contains the long term Master Signing
Key that will remain constant for the life of the profile, at least 
one Online Signature Key to be used for administering the personal
profile and (optionally), one or more master escrow keys.

For convenience, the descriptions of the Master Signing Key, 
Online Signing Keys and Escrow Keys typically include PKIX 
certificates signed by the Master Signing Key. This allows 
PKIX based applications to make use of PKIX certificate chains
to express the same trust relationships described in the Mesh.

~~~~
{
  "MasterProfile": {
    "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
    "MasterSignatureKey": {
      "UDF": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
      "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQRIcqzxpqI5QxAIN0zViKYjANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQTJQQy1HQVFLMi1CVlRGRi1YNDVYVi1ETkVGQi1RS0dVRzAe
...
viCe3FIZMarHUqmfP8PceptdOZ3_Ol1-CEze-yS7DzUW6b24uKP5Y8gZ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
          "n": "
trCr9ckkggcHQDoz5mZqO7zAXH0_dSqaXDZBgw1r6MxezX24hmc_rHKsENt03bX7
kUUzQDegGSB73j3MR-IxF7LzqJfOlmNVzxKQvnJVVZT5_81uNLhbRk1tkU7oD2MG
O2iX_n-9LjDZb1m9THs4ij-dalWG1MOlHXzrwuRpXL4z_BEca7qiHxjr6m5kfN_K
lO1e6Wb3meFPT4LrzQM2az9YPXON-Ex8ktKrpvibCz-pi65mpbRDc4U3QJr5ruih
5IyrBOX1EksGBr4nLbAaOqITNYmKCxoid-f10fu69gZ1bJVGr7ZqfIkyazn9pgFF
0h_DGBFthBV7kIWNcTXE_w",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MAGDA-2QL3P-QGFLU-EZDP5-X5A6F-DRTKJ",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAM1cBE3H34cGxNsHLXzHsoMwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUEyUEMtR0FRSzItQlZURkYtWDQ1WFYtRE5FRkItUUtHVUcw
...
OT6hMIn_w5Dik4gLg2IOReZisyKAxaTx5SDGrTePJJ8MLTE1H4S0bjtD4A",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MAGDA-2QL3P-QGFLU-EZDP5-X5A6F-DRTKJ",
            "n": "
v14EsYMG4suy4piHvJ6SO7AJwNXMhxLCe12jvqDG_IBwdX48_B5zqnTd1gNkxp-0
4gBrQzlHH73rI9s9tyDRNjvqkxnq3u_awpYZ9ZQ5lJNbxkqxXNCP6AB9MENls28G
FK6iHebTg58wBjnBryw9ZPacYZAQDsueIlmGLFjlnMR7T13SkDjfb04PTmG-t081
EJh6l5B9sg2BRpCqAo5MoMuOvTlcYAwWvFATJ97raN7ICC45KghmQss0RlHK5Wy_
kwtn4lnlISPrLvo9xCh5cGNsbHKFeOUaRRdlxh_vy6yt14TylbHCvJ8aa6ZZtpMN
chgCjTxQRnGn11IrDWlQEw",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MCSWW-AOHGW-USCET-P6OHS-GTTI7-QHQNO",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAIEAUogNACSI-qUfDVsSzOIwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUEyUEMtR0FRSzItQlZURkYtWDQ1WFYtRE5FRkItUUtHVUcw
...
l_gkzHMsW0V2O5NyPe41czTD41Ikn2G5ByFsOEmLTtFslSQmSF_WS7dBlQ",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCSWW-AOHGW-USCET-P6OHS-GTTI7-QHQNO",
            "n": "
w6d8rr2DSLZosSCpJX8Zmz4MOW5ir2b73EnPbmRqsS8d5WzrZLteBvGqzDSOkSCP
FjKLMr-pnJr3HeV6syVLu_vwhcnKfe1y2ek-xlapOyYx6Z3LzTZy1SjU0Em2AgCr
yfvM4hCApqiR-GLzahgY0CpXHSaE1jNIFSJHBYFNgf0jf4HhAP2K-HfUIyqrLBIw
I9v1F0GGI5fgZ9Y6O0Y4BUT9PN5_8HkOgPynMCMwdJBJXDWq7w_UvsaHqpuTJJWi
jsa83L5F_W2giQnP3d7aLYHDM-bu-4Uh2t12IyG8VjXCxMLKsUZLWHMO3jtbBGeV
qrJLm5LoCtMCMif-zmvDSw",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUEyUEMtR0FRSzItQlZURkYt
WDQ1WFYtRE5FRkItUUtHVUcifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUEyUEMt
R0FRSzItQlZURkYtWDQ1WFYtRE5FRkItUUtHVUciLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ",
      "signature": "
QqkV0pQXy3HNLmvnfRYC-uJoF8m0-nyOd-FAWLGzxMvMhaZ6jz1iC_dZaLYog51y
LRLNFrFwmSfiWu2DwigKooLelTRLHjgsJ408WPF7g3DGXz7DufpV7Dm1X0hk7q5u
N-Xmd7ErRPEE0LhmPWOyIK9xk85-0UpKbHne2EPPkbXJDY4pag6K9riInlDKpqi6
HieAF3vX49U9CMbNGSf6UXwJ0RP3sgdRVWdtQ7428Xz9iynIJl_glbMpp6dqnFZg
D_F8u3Q6UAWs7soVG1vlg0eMFdZ5KVjbSVH58dYcCnBfKHqAOM10CUDO6PtoxTmQ
6k0MgOrRUTMzOn8sQRkHGQ"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MBSVG-I2QUQ-FG7QP-WCBWP-KR6KX-6F7OE",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MBSVG-I2QUQ-FG7QP-WCBWP-KR6KX-6F7OE",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBSVG-I2QUQ-FG7QP-WCBWP-KR6KX-6F7OE",
          "n": "
5zTW4XHAZ33RHCtFYk2-G2fcGlq0WIf9Z65W4uRqkNcHb3RNxE2pnM1mNPEg7XV6
H5WNxrJuUbtyk1JBnJFcdDDAEZcniCHDhXI0lf8UCE3hy7pyuQAii8KfWCW5UKE9
vclec_m2ulw7OXpewB3LiO4iuuts3NjQd5Sn8JT8MZNziWIpbbRJzLaKj2iSNaup
sdCyzRwRn_nR9yuEdfTtfSGe70P7F31jU4uSzH4Z-vVMM6fNpAXseyeIszTET61T
hb0Vz92JVJzWWiB5GZe34vNv5oLbQEYQFiyHf3X7en5NzA2VNo4xD_uIYnhd2W9T
Y1Ytl4C0XcBwgiLy-RQKJQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MC3FN-KFK6X-5CGWI-ZTETK-HRTSQ-RGMU4",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC3FN-KFK6X-5CGWI-ZTETK-HRTSQ-RGMU4",
          "n": "
3qQ145r-eZhr0KvElzOjq5BOJ7G_0f_oNxvXMjvgXuiBMG3efk_fZ5qirvx_dToK
vjh2qH0ZwjRmYFCLrCfQTQDMuhW8Gd2jFwPhMrPEUxVKax4BEFyWu77hYs1KcWst
q4Os2Kj-9Mao5V73L1pKgOa19IGeyDOMW-6L9i3XUusdz64nkYWGSfMKUA15JsKj
F1WgZdNDTmVEaJKO9g2sUU8N2TqJtl8ETWDzm2w-CZGauwRccUKeDQVzPhnYujkf
63MBz5Y-VkgudE72Wi7WIZ8LiMv0alB6ovGPze_uX5a0lSZDGQ0824qMVGubWgGW
aGAXKySISvK0--5sEPQz4w",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MA7S6-EC6WL-E6TL4-OSAP5-QGPAF-ALAQU",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MA7S6-EC6WL-E6TL4-OSAP5-QGPAF-ALAQU",
          "n": "
jqCVvFolgxLyWh5zuUEgVu196u-wvdPvo40ziaUWynlervnfVRWESfHoCku_MMCQ
IMHPlgp4HcYG-Ey4N7YXPxaEAGFmv1_sLs1VGpd607m3ct9Imc7jHF5N_Fu1JAKo
XQzAuCEPPFI65DHSdKH524DWag6L2-JxFITDxe6O77KjriyetesGhOnDPsDBGDGX
2ZblPDwTMVulKzIZvd8H1c4JpWn3-xOgIjUj05ODU9_EdRY02O9y62vT0co8adwk
kYHBgPDi4Xmrrt9F4hW6Q90pLI6ss0MM-Hg44OCvGPo5GfBwBlDtDvVed0LtISAT
nBwT0TAad7Pare3VNdiMCw",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBSVG-I2QUQ-FG7QP-WCBWP-KR6KX-6F7OE",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJTVkct
STJRVVEtRkc3UVAtV0NCV1AtS1I2S1gtNkY3T0UiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
lfW-ejofZGGPKk8oaPmcNLv-n7vS7XVFrXxYpsRAoK-Wpl7fWMDjyBATsJiifVm6
8KYV34NIDOa7f0k1DoQ7GYcS-QRoVVTGzUrypIFUcLgda0vHdAVsuks95cF4ec1h
vT4nYNEqcJ_V0fZ-MvveH-fn_hbvxrAwG79i4o1k7BMXkhsbu_p8AUX68JwBuWYN
L7IDMR4Ta5XLr34CsKin2deaolbKjiCu6lYGCkCgdMWtQzWRcfQfPpm-5uK3E6kb
UPKUgwu22ELgjyiUFgbrr2yNGrRLdS9HqIg8z_YfPoMxFyVKxPzW0o7sX8LBfKqs
TS2IuhicckqDsB5KuPZEhw"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
    "SignedMasterProfile": {
      "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUEyUEMtR0FRSzItQlZURkYt
WDQ1WFYtRE5FRkItUUtHVUcifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUEyUEMt
R0FRSzItQlZURkYtWDQ1WFYtRE5FRkItUUtHVUciLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ",
        "signature": "
QqkV0pQXy3HNLmvnfRYC-uJoF8m0-nyOd-FAWLGzxMvMhaZ6jz1iC_dZaLYog51y
LRLNFrFwmSfiWu2DwigKooLelTRLHjgsJ408WPF7g3DGXz7DufpV7Dm1X0hk7q5u
N-Xmd7ErRPEE0LhmPWOyIK9xk85-0UpKbHne2EPPkbXJDY4pag6K9riInlDKpqi6
HieAF3vX49U9CMbNGSf6UXwJ0RP3sgdRVWdtQ7428Xz9iynIJl_glbMpp6dqnFZg
D_F8u3Q6UAWs7soVG1vlg0eMFdZ5KVjbSVH58dYcCnBfKHqAOM10CUDO6PtoxTmQ
6k0MgOrRUTMzOn8sQRkHGQ"}},
    "Devices": [{
        "Identifier": "MBSVG-I2QUQ-FG7QP-WCBWP-KR6KX-6F7OE",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJTVkct
STJRVVEtRkc3UVAtV0NCV1AtS1I2S1gtNkY3T0UiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
lfW-ejofZGGPKk8oaPmcNLv-n7vS7XVFrXxYpsRAoK-Wpl7fWMDjyBATsJiifVm6
8KYV34NIDOa7f0k1DoQ7GYcS-QRoVVTGzUrypIFUcLgda0vHdAVsuks95cF4ec1h
vT4nYNEqcJ_V0fZ-MvveH-fn_hbvxrAwG79i4o1k7BMXkhsbu_p8AUX68JwBuWYN
L7IDMR4Ta5XLr34CsKin2deaolbKjiCu6lYGCkCgdMWtQzWRcfQfPpm-5uK3E6kb
UPKUgwu22ELgjyiUFgbrr2yNGrRLdS9HqIg8z_YfPoMxFyVKxPzW0o7sX8LBfKqs
TS2IuhicckqDsB5KuPZEhw"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTJQ
Qy1HQVFLMi1CVlRGRi1YNDVYVi1ETkVGQi1RS0dVRyIsCiAgICAiU2lnbmVkTWFz
...
Y2NrcURzQjVLdVBaRWh3In19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
      "signature": "
IYJeK0Orl3OvnAe6AmzV_t4yDuOgy6BszC34VaHMmwVSD0sX15JQ5Z3tC5UaHDak
Sl7e7Xg5L06MH3tN_o4g8-1woAh_jVTJe4tKMojsqPjFAjV9Zy2NTluiIFW7pyGs
WZtm_MN0qtWLg3XU-WghEikYnerSrZK76exkmjT-O--U11x6xXYmR3nurJTu4f05
R0bHzwS4Ux3FPRKWM1Ftr5ooqDBF5tYUoxBLUopbxjcSjrHBFX7N4k_2R2EFptVC
Ix-nSa0Cr5ot_4_K2Jj-lqWa2zzSl__-kRgJq2JhzrpK8qnVGfynKH3sc7LRYzal
EnmZMZZjvQIZ2Yf69BCgnQ"}}}
~~~~

###Publishing a new user profile

Once the signed personal profile is created, the client can finaly
make the request for the service to create the account. The request object 
contains the requested account identifier and profile:


~~~~
{
  "CreateRequest": {
    "Account": "alice",
    "Profile": {
      "SignedPersonalProfile": {
        "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTJQ
Qy1HQVFLMi1CVlRGRi1YNDVYVi1ETkVGQi1RS0dVRyIsCiAgICAiU2lnbmVkTWFz
...
Y2NrcURzQjVLdVBaRWh3In19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
IYJeK0Orl3OvnAe6AmzV_t4yDuOgy6BszC34VaHMmwVSD0sX15JQ5Z3tC5UaHDak
Sl7e7Xg5L06MH3tN_o4g8-1woAh_jVTJe4tKMojsqPjFAjV9Zy2NTluiIFW7pyGs
WZtm_MN0qtWLg3XU-WghEikYnerSrZK76exkmjT-O--U11x6xXYmR3nurJTu4f05
R0bHzwS4Ux3FPRKWM1Ftr5ooqDBF5tYUoxBLUopbxjcSjrHBFX7N4k_2R2EFptVC
Ix-nSa0Cr5ot_4_K2Jj-lqWa2zzSl__-kRgJq2JhzrpK8qnVGfynKH3sc7LRYzal
EnmZMZZjvQIZ2Yf69BCgnQ"}}}}}
~~~~


The service reports the success (or failure) of the account creation
request:


~~~~
{
  "CreateResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~



##Connecting a device profile to a user profile

Connecting a device to a profile requires the client on the new
device to interact with a client on a device that has administration capabilities,
i.e. it has access to an Online Signing Key. Since clients cannot 
interact directly with other clients, a service is required to 
mediate the connection. This service is provided by a Mesh portal
provider.

All service transactions are initiated by the clients. First the 
connecting device posts ConnectStart, after which it may poll for the
outcome of the connection request using ConnectStatus.

Periodically, the Administration Device polls for a list of pending
connection requests using ConnectPending. After posting a request,
the administration device posts the result using ConnectComplete:

~~~~
Connecting                  Mesh                 Administration
  Device                   Service                   Device

	|                         |                         |
	|      ConnectStart       |                         |
	| ----------------------> |                         |
	|                         |      ConnectPending     |
	|                         | <---------------------- |
	|                         |                         |
	|                         |      ConnectComplete    |
	|                         | <---------------------- |
	|      ConnectStatus      |                         |
	| ----------------------> |                         |
~~~~



The first step in the process is for the client to generate a
device profile. Ideally the device profile is bound to the device
in a read-only fashion such that applications running on the 
device can make use of the deencryption and authentication keys
but these private keys cannot be extracted from the device:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
          "n": "
rsxkoPFvksiOXxGqeqAGXs6qyg8Vg8LjRMPqYsxW6srKZWMGNzj-vIwO_vbSknZf
hGvguKsJp4wxtjGuM3yls5L90dvkyZfPj5cQM-Kz7YYpr-SGLgVldFLGMTe3uyGm
5LOntCC8EFc_nw9WrQHIOnplTgYyJ0bxjmdWH4SHPbflpoRUrzQ0ZZR365GbHOsi
XxrRj9zhQYwp5Vqte8GYQjP4_esvaBbNLMKILlAKNttPMqyncFOTwg72TCI29M70
kbx9DcXNtF9YD_q_CTa7Nz3vopordeb_JjLeSDRaMiF-DBCd1AjW_rrOO4ZaHkrc
OsEVC9noeb0avWOLHGFr-w",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MDLEG-Y56OX-HPGWA-LPK3Q-AHQ2C-OOLNQ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDLEG-Y56OX-HPGWA-LPK3Q-AHQ2C-OOLNQ",
          "n": "
rtqoWUYgBGG6epzeThcYebGmTCmwf92BS7qITxYxxNUDsJI5-UtJEMmVDU5907Cx
NaSEMOp2Z7bysFkuwt6HVDOcp3D5UkVp_wtsml_w9qVf3EMPlaYx2ciIVP-hlhzk
xI45406TnkGxPgv_5gHUG5bmriqHuKlRkWG0uwzGfvi-rauOjnBD8jmn1utvhDbb
jwxM-o0YZn5yVDUq2JKGRK3KXFHAUoxKMWB63YF_bAdz_ow0fB0sGL6c3-r3bnxc
RYu8C_wwjiDDaWiLLzTET-KCgwWFVq3YpfBIbR17oon06uCWY9kiZdXRMXx81OY8
W0gGAQLjL4ANgtyexDT-AQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MCYUU-YL54V-YV6T5-ENZHM-XMRFS-BO2XB",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCYUU-YL54V-YV6T5-ENZHM-XMRFS-BO2XB",
          "n": "
u38hLETcV9TzO99awgg3z_URdMLQJ0O5YyiCbziVbZpKlLVmTE9CCSXP4HldEC0S
jx4gWYtLGKEYVXyKmLsnxWQBqfG082cusWE6WhdNdg5_lwQz9_B8A4DPx48EO7ww
hMbljMqnDLQj1u5EzUXd7du5Ys5qUmRiZlGAeNUUS16n2UsHTuiifxvc2tKCPYE3
DauJTwMseIi_NgjE69sdJj4BiV3_wTSeGSldgO4mRv1xQZVCQgJeVpYHajXbSLUB
13P-XBiXPzGQn26IZu1Cbd2sR-HClRyw4tuX0w1fz3YKYBziick8WTsdOzDr1ujp
apyA9GdJs43mOArjLDF8pQ",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFQWEMtNVhGNTYtT1FSMkIt
R1pWNlYtQVNFWVktRkxCQjcifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFQWEMt
NVhGNTYtT1FSMkItR1pWNlYtQVNFWVktRkxCQjciLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
Z5egihreo2LnRRvcl8HP5sENo1hwKWlEiqPXbZ68HdWEN_YQdVZgmunmnyGQ3UjK
YN1eMzjSlOAGV3VitwjC2DqV1rREHOojRAX33gosC83LaWjbdvSkuI8LmYczXUOi
_ldi4Hj40o0O3k0WfS-lajkPtwoAxk0R864N6-isLwpCwvNo76uPd4XPGxAf7lh5
UNIMpyGzSpOFPpkx5d02vegS9KYr3XI5yKwzoATgnHVTDpWQjHz0Rx-HA2J3o3h9
aGSo0kp18-xdozYJVXMUW_qaisBpCxJvhjHw_WMUR-tbwl4lUeG41a779mpx0nYb
KyVrWT2nCwQWHsZ_9ocBpQ"}}}
~~~~

###Profile Authentication

One of the main architecutral principles of the Mesh is 
bilateral authentication. Every device that is connected to a 
Mesh profile MUST authenticate the profile it is connecting
to and every Mesh profile administrator MUST authenticate devices
that are connected.

Having created the necessary profile, the device MUST verify 
that it is connecting to the correct Mesh profile. The best 
mechanism for achieving this purpose depends on the capabilities 
of the device being connected. The administration device 
obviously requires some means of communicating with the 
user to serve its function. But the device being connected may
have a limited display capability or no user interaction 
capability at all.

####Interactive Devices


If the device has user input and display capabilities, it can
verify that it is connecting to the correct display by first
requesting the user enter the portal account of the profile 
they wish to connect to, retreiving the profile associated 
with the device and displaying the profile fingerprint. 


The client requests the profile for the requested account name:


~~~~
{
  "GetRequest": {
    "Account": "alice",
    "Multiple": false}}
~~~~


The response contains the requested profile information.


~~~~
{
  "GetResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Entries": [{
        "SignedPersonalProfile": {
          "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTJQ
Qy1HQVFLMi1CVlRGRi1YNDVYVi1ETkVGQi1RS0dVRyIsCiAgICAiU2lnbmVkTWFz
...
Y2NrcURzQjVLdVBaRWh3In19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
            "signature": "
IYJeK0Orl3OvnAe6AmzV_t4yDuOgy6BszC34VaHMmwVSD0sX15JQ5Z3tC5UaHDak
Sl7e7Xg5L06MH3tN_o4g8-1woAh_jVTJe4tKMojsqPjFAjV9Zy2NTluiIFW7pyGs
WZtm_MN0qtWLg3XU-WghEikYnerSrZK76exkmjT-O--U11x6xXYmR3nurJTu4f05
R0bHzwS4Ux3FPRKWM1Ftr5ooqDBF5tYUoxBLUopbxjcSjrHBFX7N4k_2R2EFptVC
Ix-nSa0Cr5ot_4_K2Jj-lqWa2zzSl__-kRgJq2JhzrpK8qnVGfynKH3sc7LRYzal
EnmZMZZjvQIZ2Yf69BCgnQ"}}}]}}
~~~~


Having received the profile data, the user can then 
verify that the device is attempting to 
connect to the correct profile by verifying that the 
fingerprint shown by the device attempting to connect is
correct.

####Constrained Interaction Devices

Connection of an Internet of Things 'IoT' device that does 
not have the ability to accept user input requires a mechanism
by which the user can identify the device they wish to connect 
to their profile and a mechanism to authenticate the profile 
to the device.

If the connecting device has a wired communication capability
such as a USB port, this MAY be used to effect the device 
connection using a standardized interaction profile. But 
an increasing number of constrained IoT devices are only 
capable of wireless communication.

Configuration of such devices for the purpose of the Mesh requires
that we also consider configuration of the wireless networking
capabilities at the same time. The precise mechanism by which 
this is achieved is therefore outside the scope of this particular 
document. However prototypes have been built and are being considered
that make use of some or all of the following communication techniques:

* Wired serial connection (RS232, RS485).

* DHCP signalling.

* Machine readable device identifiers (barcodes, QRCodes).

* Default device profile installed during manufacture.

* Optical communication path using camera on administrative device
and status light on connecting device to communicate the device 
identifier, challenge nonce and confirm profile fingerprint.

* Speech output on audio capable connecting device.


###Connection request

After the user verifies the device fingerprint as correct, the 
client posts a device connection request to the portal:


~~~~
{
  "ConnectStartRequest": {
    "SignedRequest": {
      "Identifier": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFQWEMtNVhGNTYtT1FSMkIt
R1pWNlYtQVNFWVktRkxCQjcifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFQWEMt
...
cFEifX19fQ",
        "signature": "
Aryu2WwLugn_cWlVfG7pe1CeFO3no7Dxt_dIF7HVmCfMaS33mpM6zbIvtU4YNqh8
44d_VUet5aByLgEmD9puLM5BVdOP13DxwQ-DTylVcarYOdBgcNQSKrkpzqf_GQns
u2yFa1OfQELay6Cjc-mxSUtPfSo0tpywp60xsr0KqMrKeR6VnOTffSq4bJY-kGdb
DynlDHG36tHos4ym5N7jBokhz8rrHUjw9QvLh5SDeYRoXaIvas0XXEOv8DnwyvVZ
Bb-tumlO_Gt_pMUKy0B_5DQHYGnr1-W_aiNxkZagSHvURLHnWruau_tp6M7lIUcV
9NBxcwlcTKVGmlyGBCEfdw"}},
    "AccountID": "alice"}}
~~~~


The portal verifies that the request is accepable and returns 
the transaction result:


~~~~
{
  "ConnectStartResponse": {}}
~~~~


###Administrator Polls Pending Connections

The client can poll the portal for the status of pending requests
at any time (modulo any service throttling restrictions at the 
service side). But the request status will only change when
an update is posted by an administration device.

Since the user is typically connecting a device to their profile,
the next step in connecting the device is to start the administration
client. When started, the client polls for pending connection 
requests using ConnectPendingRequest.


~~~~
{
  "ConnectPendingRequest": {
    "AccountID": "alice"}}
~~~~


The service responds with a list of pending requests:


~~~~
{
  "ConnectPendingResponse": {
    "Pending": [{
        "Identifier": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFQWEMtNVhGNTYtT1FSMkIt
R1pWNlYtQVNFWVktRkxCQjcifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFQWEMt
...
cFEifX19fQ",
          "signature": "
Aryu2WwLugn_cWlVfG7pe1CeFO3no7Dxt_dIF7HVmCfMaS33mpM6zbIvtU4YNqh8
44d_VUet5aByLgEmD9puLM5BVdOP13DxwQ-DTylVcarYOdBgcNQSKrkpzqf_GQns
u2yFa1OfQELay6Cjc-mxSUtPfSo0tpywp60xsr0KqMrKeR6VnOTffSq4bJY-kGdb
DynlDHG36tHos4ym5N7jBokhz8rrHUjw9QvLh5SDeYRoXaIvas0XXEOv8DnwyvVZ
Bb-tumlO_Gt_pMUKy0B_5DQHYGnr1-W_aiNxkZagSHvURLHnWruau_tp6M7lIUcV
9NBxcwlcTKVGmlyGBCEfdw"}}]}}
~~~~


###Administrator updates and publishes the personal profile.

The device profile is added to the Personal profile which is
then signed by the online signing key. The administration
client publishes the updated profile to the Mesh through the
portal:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedPersonalProfile": {
        "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTJQ
Qy1HQVFLMi1CVlRGRi1YNDVYVi1ETkVGQi1RS0dVRyIsCiAgICAiU2lnbmVkTWFz
...
fQ",
          "signature": "
ki2mxEAPOGxkhcBbSHkVT_vOhfMKbA8F0dOiU665i47bjj8SP8C8l2TPTu86FIQP
7Zx6qNpPZE5llx9X2TEyAbcpVZPgkg9iA0mCahRnc-drtNsLITYjtXqaTuIqMb5T
-4aGg-FV6CQ2W48sTJsuet9vbxus3cW-2jeTqPYxQwWgOtc204bvDuPTJ4m60L4K
4pXTLxhufaWum2EQrWfo2afnf-bHM4CSO1dWQS26KEx4JnGTGAEin3mEA7ORSJiu
vrrDifHkCOsl-q55f25_-x7y8ka1aBFa-YdkUqWKz4MIUjyNM_iW1h6KT8bACkdM
NECB1GNgDxd13LV6sbHDeQ"}}}}}
~~~~


As usual, the service returns the response code:


~~~~
{
  "PublishResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~


###Administrator posts completion request.

Having accepted the device and connected it to the profile, the
administration client creates and signs a connection completion
result which is posted to the portal using ConnectCompleteRequest:


~~~~
{
  "ConnectCompleteRequest": {
    "Result": {
      "Identifier": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFQWEMtNVhGNTYtT1FSMkItR1pWNlYtQVNFWVktRkxC
...
dGVkIn19",
        "signature": "
og4XtVlzgI_okHj7Cwz3RDQspqCXSmURHn9cNY_nskspxwWg5D7ny_b0XwUpi6Ht
ZLfEPMlM_1MfKMUC-O5fJ4N0Om2SNwGY10IVy5k8wM_fbqpqz_HEV0Qr-mqJnHIo
cNf-18jCz0un3pLvugtf_x8yljExlm_Fky2ucm5FBus9aC5szy34eVA_uB49sAmP
pUI6b5oELXDIWsDe7EEII96yKwXAs8hXemibtG7RpwUITz6RzALMUmC0Q3oTcguG
4gm_lhBhk8nqXg90rYQoTw00DY3PvVkGZ8TWdn-V_YNjkWQs5SlZaUWmEWYcOh6O
yPaEW_d-KuYmohPOffCa4w"}},
    "AccountID": "alice"}}
~~~~


Again, the service returns the response code:


~~~~
{
  "ConnectCompleteResponse": {}}
~~~~


###Connecting device polls for status update.

As stated previously, the connecting device polls the portal 
periodically to determine the status of the pending request
using ConnectStatusRequest:


~~~~
{
  "ConnectStatusRequest": {
    "AccountID": "alice",
    "DeviceID": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MAPXC-5XF56-OQR2B-GZV6V-ASEYY-FLBB7",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFQWEMtNVhGNTYtT1FSMkItR1pWNlYtQVNFWVktRkxC
...
dGVkIn19",
        "signature": "
og4XtVlzgI_okHj7Cwz3RDQspqCXSmURHn9cNY_nskspxwWg5D7ny_b0XwUpi6Ht
ZLfEPMlM_1MfKMUC-O5fJ4N0Om2SNwGY10IVy5k8wM_fbqpqz_HEV0Qr-mqJnHIo
cNf-18jCz0un3pLvugtf_x8yljExlm_Fky2ucm5FBus9aC5szy34eVA_uB49sAmP
pUI6b5oELXDIWsDe7EEII96yKwXAs8hXemibtG7RpwUITz6RzALMUmC0Q3oTcguG
4gm_lhBhk8nqXg90rYQoTw00DY3PvVkGZ8TWdn-V_YNjkWQs5SlZaUWmEWYcOh6O
yPaEW_d-KuYmohPOffCa4w"}}}}
~~~~


[Should probably unpack further.]

##Adding an application profile to a user profile

Application profiles are published separately from the 
personal profile to which they are linked. This allows a 
device to be given administration capability for a particular
application without granting administration capability for 
the profile itself and the ability to connect additional 
profiles and devices.

Another advantage of this separation is that an application 
profile might be managed by a separate party. In an enterprise,
the application profile for a user's corporate email account 
could be managed by the corporate IT department.

A user MAY have multiple application profiles for the same
application. If a user has three email accounts, they would 
have three email application profiles, one for each account.

In this example, the user has requested a PaswordProfile to be
created. When populated, this records the usernames and passwords
for the various Web sites that the user has created accounts at 
and has requested the Web browser store in the Mesh.

Unlike a traditional password management service, the data stored
the Password Profile is encrypted end to end and can only be 
decrypted by the devices that hold a decryption key.

~~~~
{
  "PasswordProfile": {
    "Identifier": "MAJMS-TTR45-4BNIN-IFG7X-AXU44-UAVAL-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
o-Avsu8FCivNW6DhflKplQ",
      "ciphertext": "
fO3kEPY3fQSQIB0J2zYxwc_KsUm-whpH01SLFpCeoEQe-_8A3jxIPGLVxHOvkDdF",
      "recipients": [{
          "Header": {
            "kid": "MA7S6-EC6WL-E6TL4-OSAP5-QGPAF-ALAQU"},
          "encrypted_key": "
TZu3IC5nX2MFkpm1lsCvKJDzcBAkkfk9gkfqMOc8Cp9Y9QtVGmUURiJ0--THyvdp
Wbp8zVF9rKoEOyJ5LkyfPiP0TDdCq3xiKtGWQ7IO4Saf7KOiEZMEhk2zQ-hO74JO
fGZ-prgjYlXVqdPB_ynIOXQGbF1Yaellntt3MrBENVO5h998Jdy8qNRnU8N85oKG
ZPEtm03Vt_h-2GxiJlKhgVZP21C1MlTcRk4LYCmMSSo62AJmA8G3uIFiTx37FgI5
dGARGFR52O4Dg8X4vT9vjirC-kLjoGTncIMYIiZwA11IZWKOMUTT0HADHCbuoJIK
tLInSbUL6rV2bQJ1PMlkOQ"},
        {
          "Header": {
            "kid": "MCYUU-YL54V-YV6T5-ENZHM-XMRFS-BO2XB"},
          "encrypted_key": "
cGN_guz2VxoZKZ2hfBO5YDFSGGpRxBZdZHTWQM0jXGRKCERo3n7abXxE3FizB4sD
ItlLbP-unxFazsFc7OcLpGjJDhIZGCDYiymnHeiHUgra0exiaJR-zpSEGAC28BmV
2RUmdU0RqORsQ5q5u08I4g9uSkYaHFlz2nnG1b-JnY6MaFBoGIhcKav41BbkqQVu
byk9qzyHPyAWaKW-3lB-zxXNNRc0GhTBH-U4SgAugAvF7rggW5od-csnsbGrZxq-
R-IHCI2lQ4W3w6A9bAhkGoR1FZ7hvC5x2Trq2uxw6lFFsFDGCOo5EqbCGEA1fRha
rq_tnZqoxOlC4FzqvGwgTQ"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MAJMS-TTR45-4BNIN-IFG7X-AXU44-UAVAL-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQUpN
Uy1UVFI0NS00Qk5JTi1JRkc3WC1BWFU0NC1VQVZBTC1BIiwKICAgICJFbmNyeXB0
...
NUVxYkNHRUExZlJoYQpycV90blpxb3hPbEM0Rnpxdkd3Z1RRIn1dfX19",
          "signature": "
p-rLR29Cw0kFjHSZ6MVchJc7Q-qLJ3wN_C9TGgzUMJlWPZisRXbxrFVzNc8JQ_OO
HXvtrQVVlv8VXFiWrlb3-nSVvbUydJevFoqU-xlr-yNTqvN1HeIB6iIL7nStCbTy
aSGdB5aRtqcmkt7-eJlYJt5200ocWux_lH5Lv-tDAaBnGhvGft_onepI6YEOamNt
CDB_eZQBEKimgV6qQziiCwEmkZNZgH0uYEMI3_OsgCoFTwkXaJ9rGxgqZsrjoz5L
uLFTJip8QL3akxkCYji5xwAjOnDWX_wRsEOL0tne0N_SR_phNRrexo8FjzKbatCU
gLVl7F127hrfp4zWAJFlKg"}}}}}
~~~~


The service returns a status response.


~~~~
{
  "PublishResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~


Note that the degree of verification to be performed by the service
when an application profile is published is an open question.

Having created the application profile, the administration client
adds it to the personal profile and publishes it:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedPersonalProfile": {
        "Identifier": "MA2PC-GAQK2-BVTFF-X45XV-DNEFB-QKGUG",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJTVkctSTJRVVEtRkc3UVAt
V0NCV1AtS1I2S1gtNkY3T0UifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTJQ
Qy1HQVFLMi1CVlRGRi1YNDVYVi1ETkVGQi1RS0dVRyIsCiAgICAiU2lnbmVkTWFz
...
fQ",
          "signature": "
ki2mxEAPOGxkhcBbSHkVT_vOhfMKbA8F0dOiU665i47bjj8SP8C8l2TPTu86FIQP
7Zx6qNpPZE5llx9X2TEyAbcpVZPgkg9iA0mCahRnc-drtNsLITYjtXqaTuIqMb5T
-4aGg-FV6CQ2W48sTJsuet9vbxus3cW-2jeTqPYxQwWgOtc204bvDuPTJ4m60L4K
4pXTLxhufaWum2EQrWfo2afnf-bHM4CSO1dWQS26KEx4JnGTGAEin3mEA7ORSJiu
vrrDifHkCOsl-q55f25_-x7y8ka1aBFa-YdkUqWKz4MIUjyNM_iW1h6KT8bACkdM
NECB1GNgDxd13LV6sbHDeQ"}}}}}
~~~~


Note that if the publication was to happen in the reverse order,
with the personal profile being published before the application
profile, the personal profile might be rejected by the portal for 
inconsistency as it links to a non existent application profile.
Though the value of such a check is debatable. It might well
be preferable to not make such checks as it permits an application
profile to have a degree of anonymity.


~~~~
{
  "PublishResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~


##Creating a recovery profile

The Mesh invites users to put all their data eggs in one cryptographic
basket. If the private keys in their master profile are lost, they
could lose all their digital assets.

The debate over the desirability of key escrow is a complex one.
Not least because voluntary key escrow by the user to protect
the user's digital assets is frequently conflated with mechanisms
to support 'Lawful Access' through government managed backdoors.


Accidents happen and so do disasters. For most users and most applications,
data loss is a much more important concern than data disclosure. The option 
of using a robust key recovery mechanism is therefore essential for use of 
strong cryptography is to become ubiquitous.

There are of course circumstances in which some users may prefer to risk
losing some of their data rather than risk disclosure. Since any key recovery
infrastructure necessarily introduces the risk of coercion, the
choice of whether to use key recovery or not is left to the user to 
decide.

The Mesh permits users to escrow their private keys in the Mesh itself
in an OfflineEscrowEntry. Such entries are encrypted using the
strongest degree of encryption available under a symmetric key. 
The symmetric key is then in turn split using Shamir secret
sharing using an n of m threshold scheme.

The OfflineEscrowEntry identifier is a UDF fingerprint of the symmetric
key used to encrypt the data. This guarantees that a party that has the
decryption key has the ability to locate the corresponding Escrow
entry.

The OfflineEscrowEntry is published using the usual Publish
transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "OfflineEscrowEntry": {
        "Identifier": "MBSX6-UBU7W-75KZV-JIXBW-U2TKZ-PSMPL",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
WE-pX5tpCKFvxnpiV_kWmQ",
          "ciphertext": "
vAVGtXs43kwqgUT7Y320VYKOwXixzDHBJT2soTJesltXUjjtv6oRgjERr5cOWhs1
gs_G43DeKbSr-9CxcxpCO_LOb5lQ5N7QgcbcaLbG38d9MPgA1CFdfYUi16vrS7AS
...
8uUbGImrAdHGgW9tH_a69kdovlzU283_58gWiHzg_OuFnT-DY-i3ZgA8Jl46AQi2"}}}}}
~~~~


The response indicates success or failure:


~~~~
{
  "PublishResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~



##Recovering a profile

To recover a profile, the user MUST supply the necessary number of 
secret shares. These are then used to calculate the UDF fingerprint
to use as the locator in a Get transaction:



~~~~
{
  "GetRequest": {
    "Identifier": "MBSX6-UBU7W-75KZV-JIXBW-U2TKZ-PSMPL",
    "Multiple": false}}
~~~~


If the transaction succeeds, GetResponse is returned with the 
requested data.


~~~~
{
  "GetResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Entries": [{
        "OfflineEscrowEntry": {
          "Identifier": "MBSX6-UBU7W-75KZV-JIXBW-U2TKZ-PSMPL",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
WE-pX5tpCKFvxnpiV_kWmQ",
            "ciphertext": "
vAVGtXs43kwqgUT7Y320VYKOwXixzDHBJT2soTJesltXUjjtv6oRgjERr5cOWhs1
gs_G43DeKbSr-9CxcxpCO_LOb5lQ5N7QgcbcaLbG38d9MPgA1CFdfYUi16vrS7AS
...
8uUbGImrAdHGgW9tH_a69kdovlzU283_58gWiHzg_OuFnT-DY-i3ZgA8Jl46AQi2"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


