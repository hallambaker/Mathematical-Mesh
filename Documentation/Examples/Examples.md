
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
Date: Fri 13 May 2016 08:50:14
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
    "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
    "MasterSignatureKey": {
      "UDF": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
      "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQIjJwW67kIHAP8W1KaA-OxDANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQkVDMi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSTAe
...
qMIn2RP0h3k592mo5DSXiq5oMxCDNA27wOda969UiW6UY1TjD8ZqLIi1",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
          "n": "
tl7iIYmZyhGf46VzB_2V11v2a4cJqfqP0mRkyaQsMVzhO9q0YfOavKr5vzCM8Nc2
2tozOG1zmMkmRIS1M_rojIhEX8ED_1Ou8eitsBdiMgXTcss6isJiQPkXHqId30JH
LZGlvbQfS_ab5z-YNUm1O7uxbNX06ylsswTGYyVglJ3e-DJDsOHfc1xxafrFMWim
6hSTHmBu4z2rAnrkLSz2age8eHOOIB4TG5XzVvJxj4VJwXaJOXuPpwiPkejauT3A
tF7xF1r1d8ShHb2t8eRsiHuRD4Sv6QqPeWyHyIvyYdC3BGMf-9iZxzKK_UIR4216
9nx_iR1FtnU-Ow4t_KFosQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MC66F-7VEXJ-B55EW-S52GW-JATGJ-54Y7B",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQQ8Th-EUuBPFJau3aylR1SjANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQkVDMi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSTAe
...
j8p-wyCS_5H-kCGOBcLgrzCzs2Tz_2YL37ffqZBrt2eFkqPSINBoZ4co",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MC66F-7VEXJ-B55EW-S52GW-JATGJ-54Y7B",
            "n": "
lCOkqtMYaoPbwsDr2EjLzzFWviRi7UU2m25BbzX-rWFo6mxB6IV1IkZhRWf3pQEc
me4QnzxIguYxoYqWohgeqziP-a4npHZEokCyQ_J__uVa-yfv6Nyp97ox_95ZwfAT
mGHGiShJSavZg2vv1YWWsZsNY7LWE7AqpzQer27BjzCxSTRW_TtNyzLBZQipu4pd
yizns4I6bxrSb-YDRU5Y54rEnRNhYacMfYXHzjASAzHfwXLyRqeU3_zM3B6Mqnpx
6CMRn9oEE_9tnj5Wl0Re83pDIZ1FqJ_o_HqeQ5MPKY7bOognFZvRAz3G8aQlxM53
6yRRzIRWgKHLRLkzQzVosw",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MA576-SVB25-275EF-5C5SN-RAPZX-YH7N7",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQNKoYE8JdTM_RPMTIJZs4CzANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQkVDMi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSTAe
...
fEn_GPEt9oa5E73DT2spSzm9eNJchnAYGUsa6mm2AQHLUB--5vtfXgI2",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MA576-SVB25-275EF-5C5SN-RAPZX-YH7N7",
            "n": "
nTe6E4RtA0cVBHAXWwIa_y1S0Ijs8bN4AEqVjwspTwhRnHnLe7QV1sSbWDUGzEqd
0fU-pj-2mzTd_ITHLWCvVizBFYbiAJkEvv3w6yUOihEqz66r3XCtHrVO3I7EzTS3
kmL2EGHPWDIpJ8oWWAJtTmaygipfRSzpAPutTF0yIN_eyqZOPavXAMop4wK7n1Xm
w8ow1OsxIFyvvE4-G-cgHY8Ys2DUM_L-r_CjvHiUTGg8spwuJJ605Msrx9T60Ar5
3Ya4og37FVL9OBP5G3A2GOyl_Df5M27rGscQQ3RCpKSdAUkXHCYx9yhLy5dBTj7T
Ku13BEaSoZ3H7FhdCKpGtQ",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJFQzItN1VSVFotQkpIUEIt
SFFCNUMtRlNQTzctWDdGR0kifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJFQzIt
N1VSVFotQkpIUEItSFFCNUMtRlNQTzctWDdGR0kiLAogICAgIk1hc3RlclNpZ25h
...
QUIifX19XX19",
      "signature": "
kEM5u7EmcojybRRTvjS9MST2MuPwHRAA4dr-RqVm0Bvtuq-LF8L9paVvNPpl9k_8
3YUP_TTJ06_gKVYpyDVIyvbe_ghwgYVnr9VKTo07M3M8hAkPmUIllM0KIByqelXa
d1jJlyJfrn7utcklBPInIJ8VxHKGF-owFAESh7J_JWm3UQ4pTQYvJpwFVcMnYM-E
5MMtmNmLEfzqQGC0_NKr28ekc0iEodAzX-3gFFbXzhkuhgDJAq4Gl_z2-9dMfrux
thkR_UlofdA6JnbHkquIQB3nT4IkycIv7Jr_SekhpYaf16m5JldIrp0kUqRYPpO2
OdvkE492Bix3-67g22ku_w"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MC47U-GCK57-DQOIW-ODOCH-HNIJT-35NKH",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MC47U-GCK57-DQOIW-ODOCH-HNIJT-35NKH",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC47U-GCK57-DQOIW-ODOCH-HNIJT-35NKH",
          "n": "
062GNJ3Ok86eAKJbSvJRvNS4L-uoUwyVvqps13fhuWRnVvJ5Fy0iGgMsCphgbmRE
w04xrEIreDpQhLdmVNySCBGA1ApTTQYO4X4EFy-cXzNOy1TDSqPoydBoO6YdS5SM
lE2IGHUBZv6JAjWaLF3uirFH50UH0i8zrsC8oZA2v74YZfO17StDBWNqdcE6Ny8N
MshcfJ08IK6JC2hCJgmoH4gU62lZU_AHO6jfB4NluT9O80TAE33gD-DMTGgwmikI
2B9nyH3Ac8djfDCgIKntowGOyr6qtEACBuSy1t82V8K7iw1z-K-AOcr-OXSK2Esv
wuAHK-QhbyqSrTNmOypcCQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MBQ7J-MJOJO-7ATDT-QSQ2J-KUFHV-U4PUQ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBQ7J-MJOJO-7ATDT-QSQ2J-KUFHV-U4PUQ",
          "n": "
uHcCxIBMj7N8gikA1q3CsTpV_CroR3ep2ftIsHlNT_6X3XPJA46dDWeChR6nE_2X
B4quxgzHaBL4YUlkN16Ko1sR6LSepD06Mk01DBWgXzpP_dHR5lq-fhMR8Q9sJnSp
_0blkGWMteIPYUxfG_Xhtkya2DJGk0ueKVue6oUBeo-nM2w6W0LAJkiqeIlBUozO
o3ZEYAG8CKl6FJFTL96trvXV2uElMGKumKMj1sIwNnV8FfVI1NzlxC3eEpN1ZoqS
WynBU2NOQm5jJen7XxWrZSI6RagnqbmuFAza-MVvGInLtDT8Vim_PuuNUpwnJYjX
QZWeSb8Bzw1i_wEsI41GJw",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MBFGX-VA7SP-W5EWS-JDBFA-JWAOC-WJJRS",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBFGX-VA7SP-W5EWS-JDBFA-JWAOC-WJJRS",
          "n": "
yyvxy3glAU5lj1givRZQX4i30v4Lb_dh3KHQudKoZ0jviGWib1t4dyfykv1QIq4L
9VmiulB1Ui3r9xTB3PYYhNQ2fWr7AXr0I7zJFzhzxC4coFH8lGPF9Q2scvae8JZJ
bNjwPtaGBqjNqu9Q0lm_EUciAhZqdMJDKEQf9dcaR8whY8VBVa5b-AtltfmxMXVE
VEfJmmsgUMmvGkcJw1f5VEIXcGaUdTxDihIZHItHGeqBFfXBd-5zMsBYPkYUPa8G
8rlNm_YdD4m1cG2sNfyQRKyhlt_qOJZb7XobZA6O_-s2t265Im8su1va6J5JFvwB
10ur_2RLa2-YpdriyXlmZQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MC47U-GCK57-DQOIW-ODOCH-HNIJT-35NKH",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUM0N1Ut
R0NLNTctRFFPSVctT0RPQ0gtSE5JSlQtMzVOS0giLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
JdlwrvaA9J0OEGawonRKeXeiDa82qcT8ao-HSdsiOu0D3A27opup8ZxBVKX0M2Sa
AazxdNiCQiSCpvV3zd9v-oyma95z2k9YR0FHOCaDKkbqOudjGZf1xUpBZvVqblJ3
JXjCyvDtgU7PN-Mn_ePqEKa-spI8bzoS08JqM6KuxQIvcWwiL9Uj8vgONegjKtJB
ygc1CnHTv4fsgiytFkdYsogHWmj9DjoCIwsrCzTFrMyf_JIRxFcHt4_7MmSMpjMv
rlOO5j9ksvrojRYgojczxO-sNFX4q5cFf5RlLEOmpFdreKutWVWge6wTTsZq9oX9
ERjK3lFalvuhMqj_vaJ-EA"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
    "SignedMasterProfile": {
      "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJFQzItN1VSVFotQkpIUEIt
SFFCNUMtRlNQTzctWDdGR0kifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJFQzIt
N1VSVFotQkpIUEItSFFCNUMtRlNQTzctWDdGR0kiLAogICAgIk1hc3RlclNpZ25h
...
QUIifX19XX19",
        "signature": "
kEM5u7EmcojybRRTvjS9MST2MuPwHRAA4dr-RqVm0Bvtuq-LF8L9paVvNPpl9k_8
3YUP_TTJ06_gKVYpyDVIyvbe_ghwgYVnr9VKTo07M3M8hAkPmUIllM0KIByqelXa
d1jJlyJfrn7utcklBPInIJ8VxHKGF-owFAESh7J_JWm3UQ4pTQYvJpwFVcMnYM-E
5MMtmNmLEfzqQGC0_NKr28ekc0iEodAzX-3gFFbXzhkuhgDJAq4Gl_z2-9dMfrux
thkR_UlofdA6JnbHkquIQB3nT4IkycIv7Jr_SekhpYaf16m5JldIrp0kUqRYPpO2
OdvkE492Bix3-67g22ku_w"}},
    "Devices": [{
        "Identifier": "MC47U-GCK57-DQOIW-ODOCH-HNIJT-35NKH",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUM0N1Ut
R0NLNTctRFFPSVctT0RPQ0gtSE5JSlQtMzVOS0giLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
JdlwrvaA9J0OEGawonRKeXeiDa82qcT8ao-HSdsiOu0D3A27opup8ZxBVKX0M2Sa
AazxdNiCQiSCpvV3zd9v-oyma95z2k9YR0FHOCaDKkbqOudjGZf1xUpBZvVqblJ3
JXjCyvDtgU7PN-Mn_ePqEKa-spI8bzoS08JqM6KuxQIvcWwiL9Uj8vgONegjKtJB
ygc1CnHTv4fsgiytFkdYsogHWmj9DjoCIwsrCzTFrMyf_JIRxFcHt4_7MmSMpjMv
rlOO5j9ksvrojRYgojczxO-sNFX4q5cFf5RlLEOmpFdreKutWVWge6wTTsZq9oX9
ERjK3lFalvuhMqj_vaJ-EA"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkVD
Mi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSSIsCiAgICAiU2lnbmVkTWFz
...
cWpfdmFKLUVBIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
      "signature": "
U3z4H2OUEYR5JQCuf7_lNr67dY1CNQN-p3wYNvDTG_sf_kAJpVe8ezhZQbi6MRrO
P-JqzNLrcY0jePiJOqHXupyQInK55UzaXjmh-TyUJYLp-TrF-0CE86uTFRQhw6XL
QOo2uFHVFHtPuQsLRWnuRzu0ydQqa9gdfUMQZo7w71b99OJHmWQIjh7EdfxBnQwO
BS94_o0HacfcSb8YBhr6-YtoGJ8xPkNhyAdKBeTOWx4vC-LXEnQpd_ejhME0T1VP
-WL5ct8UihlyAcZbmxgcLmWCj6iWLaTfJaqDxUgSjBYJiPnRF6qgcAb_rkEwot5a
pnFLCsdG4R536-ruQcGKrg"}}}
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
        "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkVD
Mi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSSIsCiAgICAiU2lnbmVkTWFz
...
cWpfdmFKLUVBIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
U3z4H2OUEYR5JQCuf7_lNr67dY1CNQN-p3wYNvDTG_sf_kAJpVe8ezhZQbi6MRrO
P-JqzNLrcY0jePiJOqHXupyQInK55UzaXjmh-TyUJYLp-TrF-0CE86uTFRQhw6XL
QOo2uFHVFHtPuQsLRWnuRzu0ydQqa9gdfUMQZo7w71b99OJHmWQIjh7EdfxBnQwO
BS94_o0HacfcSb8YBhr6-YtoGJ8xPkNhyAdKBeTOWx4vC-LXEnQpd_ejhME0T1VP
-WL5ct8UihlyAcZbmxgcLmWCj6iWLaTfJaqDxUgSjBYJiPnRF6qgcAb_rkEwot5a
pnFLCsdG4R536-ruQcGKrg"}}}}}
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
    "Identifier": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
          "n": "
yYJ5ajYmF2CD_bzThxvQ8DmaebR9wnxqc8pxiXwRLM4lgAMpcOnUyL5Hg-OUtRmp
c5wjO9SWH0NelBGYdGNLC4Y1rA1QTu13lV0Go4r-YjX7C0CJjhY5_xo37XXD1zD7
eZhCl37wWQyhVnWF8BRNnMYEwo9rxHkQz-Y2fK9j3xcr3ehNtxao8gHroQHWpN-4
6Jadt7HkMYKBnqXj2U4gBFKWw-I_d-S5SjyX3ufw8I7V_Hd2MLuto-DxQIArMnHj
at9Vy5uC65WmadFhOhM9E3lsoh50gFzoeqwE9IcR5EsL3ehei5KZZb1OKN92UCJp
KBC4cq9B8w8tHvAEsTDV3Q",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MBWOZ-ZPDVY-RYCN6-SUXIE-RQ75F-WH6KS",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBWOZ-ZPDVY-RYCN6-SUXIE-RQ75F-WH6KS",
          "n": "
0y_oVXWWYD4CWD24ID2CQJqbDgjwFRXJ_Co3iFN_5D8F7OJBNy-OulM0XuE2lX_O
T6gSJ6o3Fl8QAyTkluqo44sA9_GLgEEEfchI_aYX6gDT3IZoozPA-Tx8Jj78wxZU
uPGbqqKg0Y2u8Thocguo_tcadb2wXs4AiLBIWTS9u7hBEt3FZyGrgxybjbkbUQ4R
P4SGF0VXtu70oMLvWQkLDwzAMMCMKq3Zi7wrI8MULIA4e9jRr4oy95ZdMmTKKEu6
Mg5dTNH1VTqBpleHwJQ28zAIuqRuaxxMBU-y2zySnOwIb_-EPDOP3qr4NislbVqN
2VbTIkC3vd512IDvO9Bk4Q",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MBMPP-WPS5J-WJEQV-I6WSC-FV6L3-Z7ZNI",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBMPP-WPS5J-WJEQV-I6WSC-FV6L3-Z7ZNI",
          "n": "
yoDKNkQdYwucuUHn5R8CJwMXYOufzIQcCSLTzbQ526LwUC4f_49_zacQ9AuofuhL
kztZYk12Eo823MaLvrhvBte3Ksvp4ARS1iFRTiWEYoGw_HlVVUTajUB2niLIEfxT
l8AuPoyF4ZxMCJA8m-r0YuvEOFQpPST4ADaq2k7RV_lykhOUvOfBD3mSZ3EqAgNn
ZBtihzySAfkvZOR0uMoBka-bXh34Qu03O-5QIBCQEx3LSPrl6uPFr3oUVpnXExyc
2fAKtJiU_4aD9MQEjrCX8wOVKIbmljaB-ikqGsLCXai8bVJzJHVCYqnXrMG1PHtR
evEuFI-ri5RTa8jFU4Jglw",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFGUE0tNU41NU8tQ1RLTDQt
RENFWTYtSzU3TEktNEVLSEQifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFGUE0t
NU41NU8tQ1RLTDQtRENFWTYtSzU3TEktNEVLSEQiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
J4Re2tlx-HZKUq-cho_g34FuL6rWRtLm8rTX9LKlgBNJLNoKc4829JYoUuLeiOGb
yfLOL63NbboqKOF8RJ2CP_ppbdhRUSTY04jEj5yk2oSBE7kEl5KhWSxRH_d1_GUj
G9TDfY9tc2_SADpUg6p--e8z3mn2MmzGlsG7X3Lueos-bgJKRE_jaWOKYORJOitX
SBsn1PD9Pvr42ujtF_6205fVAZVZjDmsNx8kF46ppO96M2CFYQFN0ayp2sCi5qrG
zqC7yvRr_ouY6ScrCUF850CFU1VUsbKOEyLxbC2Gs_KCwQOvaKvj7KYR9RsPvWN_
Y9H5S-sG_23OxYg7REN7Jg"}}}
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
          "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkVD
Mi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSSIsCiAgICAiU2lnbmVkTWFz
...
cWpfdmFKLUVBIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
            "signature": "
U3z4H2OUEYR5JQCuf7_lNr67dY1CNQN-p3wYNvDTG_sf_kAJpVe8ezhZQbi6MRrO
P-JqzNLrcY0jePiJOqHXupyQInK55UzaXjmh-TyUJYLp-TrF-0CE86uTFRQhw6XL
QOo2uFHVFHtPuQsLRWnuRzu0ydQqa9gdfUMQZo7w71b99OJHmWQIjh7EdfxBnQwO
BS94_o0HacfcSb8YBhr6-YtoGJ8xPkNhyAdKBeTOWx4vC-LXEnQpd_ejhME0T1VP
-WL5ct8UihlyAcZbmxgcLmWCj6iWLaTfJaqDxUgSjBYJiPnRF6qgcAb_rkEwot5a
pnFLCsdG4R536-ruQcGKrg"}}}]}}
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
      "Identifier": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFGUE0tNU41NU8tQ1RLTDQt
RENFWTYtSzU3TEktNEVLSEQifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFGUE0t
...
SmcifX19fQ",
        "signature": "
twnFuxHeDz7WdDtyMUX9tS4kvBepy3SKl_AHhQMq_Uny0-qqkGdPcH7bkbwDSi4B
9w6fGRAM1duiqYIOHoDLl-hckDVVVkCZw3DMXVqKcS7Ez5Xqp2RrwdiUr5y73uCZ
GSyceB8nWHZkm65t7AqEvP-DVvP9K__-YEGOwwT8o0SMTQIGiMyQxYaahg3W07di
junKRo0DhyweDkCXcJZUdLKAbC-nu7VZcSmF310J2kF_CUeUQyeC1nQg8sz-wzSO
WEN4zoparns-ynnMOYKcoNZnkk8vk_GxLyi_gaOxZ-9NAIMsSJ3tf-PGtLNwlGnr
6-T-ME1pbhl9BeLTlMvLsg"}},
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
        "Identifier": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFGUE0tNU41NU8tQ1RLTDQt
RENFWTYtSzU3TEktNEVLSEQifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFGUE0t
...
SmcifX19fQ",
          "signature": "
twnFuxHeDz7WdDtyMUX9tS4kvBepy3SKl_AHhQMq_Uny0-qqkGdPcH7bkbwDSi4B
9w6fGRAM1duiqYIOHoDLl-hckDVVVkCZw3DMXVqKcS7Ez5Xqp2RrwdiUr5y73uCZ
GSyceB8nWHZkm65t7AqEvP-DVvP9K__-YEGOwwT8o0SMTQIGiMyQxYaahg3W07di
junKRo0DhyweDkCXcJZUdLKAbC-nu7VZcSmF310J2kF_CUeUQyeC1nQg8sz-wzSO
WEN4zoparns-ynnMOYKcoNZnkk8vk_GxLyi_gaOxZ-9NAIMsSJ3tf-PGtLNwlGnr
6-T-ME1pbhl9BeLTlMvLsg"}}]}}
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
        "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkVD
Mi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSSIsCiAgICAiU2lnbmVkTWFz
...
MjNPeFlnN1JFTjdKZyJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
RA36dxICganh5cIOuGH58Ie3o4_rwRc2xyV-QTiWKPeMRNrgSce7W5UPEz1iQlhh
z0lVDEX0v9-3kUzIOgiv2TDwoWN_36MjC55l2nhzUoiF7Rp0SOFX2P7OIcrplq7f
tLv276-IujTd2amPl-LwbqZbLGFgVf-LXSypgG764iyDAnjGiqDW4Qdnt50Opw0-
zJB-NRoOjqo1ezadBWr5DjDPAIBJVpy4q1efpa7fxYMtWPye1LueK5wgDRqQJ0Rg
IbE63IISjj74Hknsd_CJrizHQPItQEorWdvk-LiyWMvDi82IA1BxdC5piGPFpN23
gti0-Va_P5LvJephE8_ImQ"}}}}}
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
      "Identifier": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFGUE0tNU41NU8tQ1RLTDQtRENFWTYtSzU3TEktNEVL
...
dGVkIn19",
        "signature": "
L-NuPVGshZcDR6NgWw6F2DgvELu33oV4sKAF-xJX1Q1KIK_hgeI1U9TUQJIZEkzh
U7BALMXY07FPBybODMmgEW6cKqv0eLnWrz8A5SZWrOeYvSbH1uP5ck8SVayxTmje
cZCLNFi7p32GQa-1on1mPMvrX2qGtHYSHQLz_ZUjBYidUL8hGa1ffE_vQBA_-M7R
FrQfiH4nl7d24Z29-VjpA_6IjkvPseS0RJvP9dimTK8x2_J5twQAqihz8LeI81jC
JQbK_YG67OxkXF-DB_4QYpMQtgc6cqINvkwIKd9iAKQ9lCXGX5ZtDmybywtVTtxY
QJVNl9YPiuznyT9QRibJGg"}},
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
    "DeviceID": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MAFPM-5N55O-CTKL4-DCEY6-K57LI-4EKHD",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFGUE0tNU41NU8tQ1RLTDQtRENFWTYtSzU3TEktNEVL
...
dGVkIn19",
        "signature": "
L-NuPVGshZcDR6NgWw6F2DgvELu33oV4sKAF-xJX1Q1KIK_hgeI1U9TUQJIZEkzh
U7BALMXY07FPBybODMmgEW6cKqv0eLnWrz8A5SZWrOeYvSbH1uP5ck8SVayxTmje
cZCLNFi7p32GQa-1on1mPMvrX2qGtHYSHQLz_ZUjBYidUL8hGa1ffE_vQBA_-M7R
FrQfiH4nl7d24Z29-VjpA_6IjkvPseS0RJvP9dimTK8x2_J5twQAqihz8LeI81jC
JQbK_YG67OxkXF-DB_4QYpMQtgc6cqINvkwIKd9iAKQ9lCXGX5ZtDmybywtVTtxY
QJVNl9YPiuznyT9QRibJGg"}}}}
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
    "Identifier": "MASFC-YI5YK-G5DFB-YYT3F-TCERG-MJRQO-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
JU1SkO3_R0XYfLBrbmJOUw",
      "ciphertext": "
7NGhvy0D9aehP5FVfyKPfMP9ukYmOgNxVaJdhPo265S9UnT9o3WRSMKlggAquKs6",
      "recipients": [{
          "Header": {
            "kid": "MBFGX-VA7SP-W5EWS-JDBFA-JWAOC-WJJRS"},
          "encrypted_key": "
hv_13wroEwZAoVfhZ4qUKQzBdno0enqPLwm12QEoGOPoSuVLaOuly2nDAK-Yupuq
sf8MZ26fsQ56Y5zJenPR38-Jkvl2Fvq5LGZ3TQRZG1gUfqomKgDoKWW1ervaiMa1
UQEVE0H4BLDiupUKkWUMunXrtrV2i6RDJfeiA0rGh8j5QZunBc5wNyS-nmn-m6vY
f8buJMuxPpGzris-KSQF1pyJQZrSj74SIId9pDia7rUabgUYHsh_t13B5oiBTY3J
5vNA0-APdn78p4KNGYmvipsUiwno7qNg85R_eXg4SBZRXHFL4hPc-KLlgv1hvKTj
yjfWBYIkiS1x7MaQyaniYw"},
        {
          "Header": {
            "kid": "MBMPP-WPS5J-WJEQV-I6WSC-FV6L3-Z7ZNI"},
          "encrypted_key": "
SpCIiHHGIVe9w5nrIIV0LZYKBt54aWpFoLJ6rYxWwVy-8lJcv3JDgojEoC9_uB2I
A97B5YL4WbARRXAWXR1h-ztJOwD9YRYEOqIJYcHO64dinWN60KOwuw1fOyCYi-ic
lZk5s-7WH1ouS5fAC2UmIIn7P3EsQXV1w3kyZg7Ss_BVm4-FZsnGBSl5V-y50M6g
YQM7mBSG776wu64QhmmSmNm34KV5l2rSHnVaPgyKaM1AJEaactluLCz91uTryjo9
Vr94HFQVDNsh2I3B7roB57dK-tttBg11ZYwwJNjwtlmx8EcGLPROSAYamGqYG3Ub
jg8uZic7Adzyp0FM1qHvUQ"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MASFC-YI5YK-G5DFB-YYT3F-TCERG-MJRQO-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVNG
Qy1ZSTVZSy1HNURGQi1ZWVQzRi1UQ0VSRy1NSlJRTy1BIiwKICAgICJFbmNyeXB0
...
T1NBWWFtR3FZRzNVYgpqZzh1WmljN0FkenlwMEZNMXFIdlVRIn1dfX19",
          "signature": "
nJ1LObwl2bbRyzsu4zHEud3hVY8hNsWTyPAUefVxkrpANZ6Y0YY-jRPNfX1WNUed
O1sePtrC2eK8TgXRxeQuiGCYBIvSt9psHTLFtismZdEG_674h2hsYZ59an6qd1gs
dG0Rh_Ep1fQR4IFvYCRaZEoo7vCK6DON5kKiSLLVkL0IeTCifBPAfMZxEyBbxCFN
pC_-eWb_s7JgsIweCtfcrBnnLaa0dVWu3F0Fx9qXbZobx1IbJAV0wggxjD6BQFE0
ExwO9b50s4FAN0mqjFuP2D5j5B9Im-D1H2wDFJ3fR-In77z9f5LI_sgdEBUteOSF
8Y9Djp0NvA0mA1UMjdRxMQ"}}}}}
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
        "Identifier": "MBEC2-7URTZ-BJHPB-HQB5C-FSPO7-X7FGI",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM0N1UtR0NLNTctRFFPSVct
T0RPQ0gtSE5JSlQtMzVOS0gifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkVD
Mi03VVJUWi1CSkhQQi1IUUI1Qy1GU1BPNy1YN0ZHSSIsCiAgICAiU2lnbmVkTWFz
...
MjNPeFlnN1JFTjdKZyJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
RA36dxICganh5cIOuGH58Ie3o4_rwRc2xyV-QTiWKPeMRNrgSce7W5UPEz1iQlhh
z0lVDEX0v9-3kUzIOgiv2TDwoWN_36MjC55l2nhzUoiF7Rp0SOFX2P7OIcrplq7f
tLv276-IujTd2amPl-LwbqZbLGFgVf-LXSypgG764iyDAnjGiqDW4Qdnt50Opw0-
zJB-NRoOjqo1ezadBWr5DjDPAIBJVpy4q1efpa7fxYMtWPye1LueK5wgDRqQJ0Rg
IbE63IISjj74Hknsd_CJrizHQPItQEorWdvk-LiyWMvDi82IA1BxdC5piGPFpN23
gti0-Va_P5LvJephE8_ImQ"}}}}}
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
        "Identifier": "MBFWI-XMM7G-ULVGU-WZ2FN-P26EL-VJ4OZ",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
lqAEGIM1LBmtiErPtwPcsQ",
          "ciphertext": "
BJEOz7c4gYoF6wIDdUQ0U5VlM9_lRbTRIeM7wpj1lB6ltz_dAVWpS3ObBg_BL5IT
GCWi3XWPfxXytMIxPJrHhvszPOPyyI-Nc82LkhgPNh3QjeErg134-mrvP1RGRI__
...
re8_gELPkvwuub8vsWcZthgsf-TqyryLD9yD9pCGQ1QZhQoUgPvHMpHjg04a-Rko"}}}}}
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
    "Identifier": "MBFWI-XMM7G-ULVGU-WZ2FN-P26EL-VJ4OZ",
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
          "Identifier": "MBFWI-XMM7G-ULVGU-WZ2FN-P26EL-VJ4OZ",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
lqAEGIM1LBmtiErPtwPcsQ",
            "ciphertext": "
BJEOz7c4gYoF6wIDdUQ0U5VlM9_lRbTRIeM7wpj1lB6ltz_dAVWpS3ObBg_BL5IT
GCWi3XWPfxXytMIxPJrHhvszPOPyyI-Nc82LkhgPNh3QjeErg134-mrvP1RGRI__
...
re8_gELPkvwuub8vsWcZthgsf-TqyryLD9yD9pCGQ1QZhQoUgPvHMpHjg04a-Rko"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


