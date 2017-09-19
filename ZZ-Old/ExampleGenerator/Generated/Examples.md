
#Protocol Overview

[NB - serious bug! the status code is not included in the response!]

[NB - another serious bug! need to pickle the data in each message!]

[Account request does not specify the portal in the request body,
only the HTTP package includes this information.]


##Creating a new portal account

A user interacts with a Mesh service through a Mesh portal provider 
with which she establishes a portal account. 

For user convenience, a portal account identifier has the familiar 
<username>@<domain> format established in [~RFC822].

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
Date: Wed 02 Mar 2016 04:25:44
Content-Length: 110

{
  "ValidateResponse": {
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
    "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
    "MasterSignatureKey": {
      "UDF": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAMGOj5Ek6yKqC7h9Qj0DgXMwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUFYWTItVkFQVlEtQ1pTQ0QtVFJDRzMtS1RCUTItUzJLUlIw
...
S5SqPAkCB48rp6B8U20zMQhKZNHJ_8tVQvOvlsoN1a8JmEw9ST_C2OQyYg",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
          "n": "
qfbEEVIX_L-Y7ZIM8mhvm8_zeM-wRizDIuPf8GXVgG3pkQ8wjAOtDcuUj4_gwaAF
s7M1wTDYZftAfEod9YW0VND5SuS_uRIkZrBwhSixYCIsbCCSBmUmw33_CxQImhaL
w7FyATBh_Dt3txIFEQ0n_SNYask1xgPMcNoaT1ho7mYs8JaW88qWFonuoLBlMRbF
T1mdH5nrQTrphWrIB8y9xLAliB_8hMxAywLS3MSaaWN3u8S2BqKoaJVD-M-NZMDx
4gY-2R2bLNTMhjqowlBO1gfg97CoQxjdiYqHRgAIcdDUus8ip6u7XlHJmGghEabk
u5SM1EERQJj9IdMm5q41aQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MBEYS-NG5KH-2MGD4-V2NDU-R2JYH-LLLBT",
        "X509Certificate": "
MIIDJTCCAg2gAwIBAgIP5Nt7ymvv-rd5fz0O9MMFMA0GCSqGSIb3DQEBDQUAMC4x
LDAqBgNVBAMWI01BWFkyLVZBUFZRLUNaU0NELVRSQ0czLUtUQlEyLVMyS1JSMB4X
...
MTWqhTPlz0uX977QANojrNA0DMfSf2h3oieKXnzbFhaJShyeEg6JIjE",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBEYS-NG5KH-2MGD4-V2NDU-R2JYH-LLLBT",
            "n": "
ujVEfG7oPZXbSi17NW4UkG4KiZTa9uwLbOPSUdsX1cp1z1GaTlz9f2vYaZ246pwI
2sdrawbUiKtPv0VAleVrbWGATCTqJmEif9inn6nKO0XWF7hr6v3jaxwlunD-HhFn
Vlra2dT_XfLGLlmkcc3bmJuv0Zke9vEqZjCLcefCAEhuhHSq0Cu4A5WSYbWnxnlB
3GLI9jxv4pPlJ8JAhmCwp8aLDNNWNs--PVNfVT9ZiFtJ2rUnlvj_lQrXjc2A6y0s
df6j8RbC5s8CErKQufTHpzB0nMWgGZE0mdhBh2YxvpZBUzLE7LHFk51jT13IBke1
kuO9MuK6vwBlLdrigMxtaw",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MA3MU-QXJOW-KE57W-M724F-KKJOK-WPU7Q",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRALUhMqh9S5QSvv7Nw0_hHvIwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUFYWTItVkFQVlEtQ1pTQ0QtVFJDRzMtS1RCUTItUzJLUlIw
...
LEQpFCWwXbBMFUpkrFLT2Jqivzh7aIFTqcBeX3cYKapA2TX03Lqmj-MX0A",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MA3MU-QXJOW-KE57W-M724F-KKJOK-WPU7Q",
            "n": "
1uHQdpIBLHoKdcbYBkvuO-QiKtiE6SMWQYkNWzRFifUjuImOJiVgvre0rsxrld2-
FmT8tMHGw2hzJR6-6aNA7ahfQEEXKwzY1MSFZ5iGMV8f1gbop8z2YsLC6OdSPi5y
DYYNv350L3x7oX6GEiKtnBM_G1OtMu4U1OtGxRdyH3jPThOo8S6hTxnwkiP9G3P_
ix9m7dy8An6DiKahayhSqbO_76CXJ2hAUhpXJhY69QwkYUOn7CdFotp3pgHmY_bB
AJn1-YMW5CbuIbGdGs7SqqJsmOEKWNcwushzjBHmU1Zwj9Dt0DQMNwZGOf0TBdop
gUv3-27aYdvqQl9hXWGpjQ",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFYWTItVkFQVlEtQ1pTQ0Qt
VFJDRzMtS1RCUTItUzJLUlIifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFYWTIt
VkFQVlEtQ1pTQ0QtVFJDRzMtS1RCUTItUzJLUlIiLAogICAgIk1hc3RlclNpZ25h
...
CkFRQUIifX19XX19",
      "signature": "
jpkLN7Zg0ltrQ1iNlhuGI8Q4PQaaDMrGKLu39u26XGqEN6cbZfMcEc0-8_mzZiYp
oTqHwxaeudse3SajavIhlW7cweMHWBjlGkH_wRHsncyjhTdWGfBtGghs0yj_FwnT
sqMntWtPT87Usknu57Fv05zH1SC6WgfqkmJsq4SsSENii7sV3lvc2_4L5yTIOi1G
EnRhVzoiwIk_FwrHMVM3XrC0zwyK2x0kZRJ_ObJWBOpF3KNS0r2ucLM-VSD7Qpv7
3z_CR4HoxDECRjPHgnvqlW3travPRidPKYTzcUOrYqiXxkQ4qUox31gNmhw4Gh39
aV4_PBV5SctAbD61j00DWQ"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MDP25-ZHH5R-BCUCT-ZFNOX-ALK6U-FGEBD",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MDP25-ZHH5R-BCUCT-ZFNOX-ALK6U-FGEBD",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDP25-ZHH5R-BCUCT-ZFNOX-ALK6U-FGEBD",
          "n": "
qeE6cw4y-KxzwABY6XDBhmwzjVKGUoZamPNXtPZsb5oswgVmUk5Gpi43r4WG8-64
QC-SZVr2N7SQ0d5nrU0RAyBbBza1bLrWA7JfdaX5S-lOy4Sj_ru1KaUbj8Xz-M5N
OtHbQqaBafm-_m-04-ybRznzlPw1fGq0gwDnORW03ERttDcVQ0ZhADyncmrDnPjq
UIX4eFQcf-gtdswjqYlS6hXPCt-bDRIGfibnbmzON0CgE7B_RqHf5z80WiX1jcEk
ngXU9S1m_4nIgIfJm62RyD-J5UbfJLZnyhNevevLI-v3-PUI6d60UHu6RVoJrrwe
cdmdGLSh5TzvNJXE8QECWQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCJ3K-3RIE2-5SVXH-EGKU4-GXNG3-2LJIT",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCJ3K-3RIE2-5SVXH-EGKU4-GXNG3-2LJIT",
          "n": "
r3BmRRlBa67_9rrWTHYAmdl31wvlQwls32-iQTV-aPnZKd0CH87vckM22SkCxkTM
8YJpEtFc92QsjM7qG3EIIDslrYm-yhYTNfI2jLmgqJoDp202sUfxDy5LSFxvO445
1mr1KrNYk7k8hXJDo2rwz2g0QtrF__--HR3u9oZhT_mlJBJBIZtCJByyb8UZB0wa
WesmagCM2FwcGQgsOD1HLsiPdmmrlJGpCrfeRuNFWJeQo4PVrh2zWSSFkn78EATZ
fsn5Mx5A-nVxgNa5GopnLBgqhhlutlpMtfMB_ic81A833JJaY4ZfPl8q6Y9aWPT1
6Snh4xXHH0S7aLd3ZUIKew",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MDAN6-ZU5BV-VWJHV-4UYBX-PPB7R-IMVQM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDAN6-ZU5BV-VWJHV-4UYBX-PPB7R-IMVQM",
          "n": "
o5pCLjiSxGv299huTeg8BYN7BzN6Tk-p5wObHried_CHWXU0eWOmVB6CKygQIIPZ
Sxa7EaG-zus2EuiiKUskVkl3Vmr7ycU0zu5SWSlqZJU-lBFtKRdnUNuxOLY83SAD
da1EATosB3v56onwc8Hxcz74qBXlFmSblyWA8ujGLW2hMDmkcCrzrUD1HYetqqd5
G0SjCzZPH9B7zdduSyuN_eHuqXzyQ1hkjqV2Gk3E1iDzdCpieHsRUx_Z6Q-GVvkr
dY2t6EwHWj9XEUK_snqxnIqDhTBlPphWFZTXUN9dwfZinqVXjJkbT1ngzaFEd9o_
QhzE4Ns5uZY119R994VHvQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MDP25-ZHH5R-BCUCT-ZFNOX-ALK6U-FGEBD",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURQMjUt
WkhINVItQkNVQ1QtWkZOT1gtQUxLNlUtRkdFQkQiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
iHSs6drEDJNhbeHzly4nHB9G345e4DaY2SXueVE2k4dBqB1La8b7llbeW0uT5605
cbi3wKzelrW7p1iazd0TYyukwtt6gicUMFqAPctIQHmgxwW21SVjfWfIKaC21RL9
kXr4pRWiEAXiWke5x-p7unjW48iO-mKpROb8G36r3d1RTGJJ9Q53MlIW0pFgIY8H
jOxpMlUHY8WiqDmBOElum49gv8xrFBoXJxYEBNSOY0aiyJXUdXzEYAKTqbwP0ARe
znNblL6kRi6RX4U2hDEsv6-GmSuHSFsO3ST4UgZ1Th-Ni5F0SFa7MPRPzpW1PWBn
vtYwXRMEQiBluh8Z8UwyGw"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
    "SignedMasterProfile": {
      "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFYWTItVkFQVlEtQ1pTQ0Qt
VFJDRzMtS1RCUTItUzJLUlIifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFYWTIt
VkFQVlEtQ1pTQ0QtVFJDRzMtS1RCUTItUzJLUlIiLAogICAgIk1hc3RlclNpZ25h
...
CkFRQUIifX19XX19",
        "signature": "
jpkLN7Zg0ltrQ1iNlhuGI8Q4PQaaDMrGKLu39u26XGqEN6cbZfMcEc0-8_mzZiYp
oTqHwxaeudse3SajavIhlW7cweMHWBjlGkH_wRHsncyjhTdWGfBtGghs0yj_FwnT
sqMntWtPT87Usknu57Fv05zH1SC6WgfqkmJsq4SsSENii7sV3lvc2_4L5yTIOi1G
EnRhVzoiwIk_FwrHMVM3XrC0zwyK2x0kZRJ_ObJWBOpF3KNS0r2ucLM-VSD7Qpv7
3z_CR4HoxDECRjPHgnvqlW3travPRidPKYTzcUOrYqiXxkQ4qUox31gNmhw4Gh39
aV4_PBV5SctAbD61j00DWQ"}},
    "Devices": [{
        "Identifier": "MDP25-ZHH5R-BCUCT-ZFNOX-ALK6U-FGEBD",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURQMjUt
WkhINVItQkNVQ1QtWkZOT1gtQUxLNlUtRkdFQkQiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
iHSs6drEDJNhbeHzly4nHB9G345e4DaY2SXueVE2k4dBqB1La8b7llbeW0uT5605
cbi3wKzelrW7p1iazd0TYyukwtt6gicUMFqAPctIQHmgxwW21SVjfWfIKaC21RL9
kXr4pRWiEAXiWke5x-p7unjW48iO-mKpROb8G36r3d1RTGJJ9Q53MlIW0pFgIY8H
jOxpMlUHY8WiqDmBOElum49gv8xrFBoXJxYEBNSOY0aiyJXUdXzEYAKTqbwP0ARe
znNblL6kRi6RX4U2hDEsv6-GmSuHSFsO3ST4UgZ1Th-Ni5F0SFa7MPRPzpW1PWBn
vtYwXRMEQiBluh8Z8UwyGw"}},
      {
        "Identifier": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQyQlctUlVTUUEtNldZM0ot
WURHWTMtUVA2SVgtTkg0NTcifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQyQlct
UlVTUUEtNldZM0otWURHWTMtUVA2SVgtTkg0NTciLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
          "signature": "
e5k7KmGR-TzH2NBXn_IykvIytwldKpZYKXUS1GrKFuu1I5iam7UiwmSnqgK06vpi
0wpBpkvB0kb9HgqdG0fhEucwB2caDr7vfqGPpc9d5AI11Gp6Nm0e4rF60Ondx9k_
PoQTsZitQwZWYrmap-J_dyUAGmSubxvry5DvPNlTeX5fa0UrZzsj75f1R3YJEK8D
7HmD_f1VDuFrTnWQbyEKjMd-cONKz5s0RFDDwe4YIzlC5LXk8A6ogmL9U-Vc0mdg
xoiClV-ytGwXeTTK7LBIA4mLI1EDhBlSZHcPBJOd8uo6GDkwHaS-J7ymysYHey5E
9NF2ifYDedIakS3DZlxZMw"}}],
    "Applications": [{
        "Identifier": "MBX64-FKJZJ-VOJ4Z-XHTA3-CBEWW-GVSMC-A",
        "Type": "PasswordProfile",
        "SignID": ["MDP25-ZHH5R-BCUCT-ZFNOX-ALK6U-FGEBD",
          "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457"],
        "DecryptID": ["MDP25-ZHH5R-BCUCT-ZFNOX-ALK6U-FGEBD",
          "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457"]}]}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVhZ
Mi1WQVBWUS1DWlNDRC1UUkNHMy1LVEJRMi1TMktSUiIsCiAgICAiU2lnbmVkTWFz
...
aUJsdWg4WjhVd3lHdyJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
      "signature": "
BiDHqGcftzngSmuCc1VqDoMOi3ejBz9CWWey1L8TRIm7DvjhQYj93NfAe08AJY-5
8ymcRGK1ux5loGZQeb-rGN4M-uhyWt7AvI3cyUJBW72_kVmyqTrIQ4e7t7_MwRr7
S_r-TmuXDS2CXurw36poYBdb9JGDlv59fY11N6FwlKjkYdW_Pd0MBMVyEXT9JMaB
En4q8B6YTkcQJ9TwUMlkHd8ZBumgwQZC4FN9v9mUopuI6c9GM20xJJnGmJarGOQ4
1nhchS9qvNc2IzRECucr85BtMO9RXA84if2pUsycj4mxDMUBNN_E0T26st2jPkEj
SUDkywrM9tgHa0iOiwbLKw"}}}
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
        "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVhZ
Mi1WQVBWUS1DWlNDRC1UUkNHMy1LVEJRMi1TMktSUiIsCiAgICAiU2lnbmVkTWFz
...
aUJsdWg4WjhVd3lHdyJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
BiDHqGcftzngSmuCc1VqDoMOi3ejBz9CWWey1L8TRIm7DvjhQYj93NfAe08AJY-5
8ymcRGK1ux5loGZQeb-rGN4M-uhyWt7AvI3cyUJBW72_kVmyqTrIQ4e7t7_MwRr7
S_r-TmuXDS2CXurw36poYBdb9JGDlv59fY11N6FwlKjkYdW_Pd0MBMVyEXT9JMaB
En4q8B6YTkcQJ9TwUMlkHd8ZBumgwQZC4FN9v9mUopuI6c9GM20xJJnGmJarGOQ4
1nhchS9qvNc2IzRECucr85BtMO9RXA84if2pUsycj4mxDMUBNN_E0T26st2jPkEj
SUDkywrM9tgHa0iOiwbLKw"}}}}}
~~~~


The service reports the success (or failure) of the account creation
request:


~~~~
{
  "CreateResponse": {}}
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
    "Identifier": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
          "n": "
l65DHel2-iwO860n_t7HreDAgjCzctLrq3JXV_rsVHhxjhmK4C1V87s5ykKTyPGF
3O_cy7wjV5DOlCAaCrg2ROOg7ddtqcgswHruJBJUPlDYqkmKofuIjWGlSu18WQbz
boCPHfkLLXy8TryqtqBuMSubHULpGUeWX1TPTz5xce-OUMSmpmzQ4nwoZsZunD-7
c4CZ9DOP68AinK2hUzWEpD7thOdcXjr5dLY3TgDGHxEiUoDydpknekTEQS43gAHa
VDHlOqPZM_11Hr7TRBvZ679fTgd8iJ07eN_n4j2f6GABi4y4C65p8HC2KU5nOA65
YPbeVDjrP5YzDNVrSOxZow",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MA57V-6AIMD-TPTYO-OFWGZ-4WT3D-GO3BA",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MA57V-6AIMD-TPTYO-OFWGZ-4WT3D-GO3BA",
          "n": "
4H3193trVFroP1719R9NWzLDCQKysWUtKRe1O3uwnEGNJmL92_1Nz8UauxTwVRFw
3wYATevoEp86U2N6hQMRADPAcA3JGuJsFuD5HUsrQLJFFUfiYXdPnVrqE45r14SD
Mk3BbyJmtLtBjGiX7Z3TTFbYTM6ksio9QLNaAk3yiseT7da8twlAqvZ3Za5E1q7l
7CVn1yeATwidvxIaaAreUvWUCKo-ZUoyxLDQDT5rBJ945D4fjieOTCdAPXLp1euk
8n9--gKaP8sTMivhxLSP800sc6ttl70I9llXSIE9W6qN2FGwFc3t1hmgNm81oeVq
aphze2wj5zOmFMFin081KQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MD5OJ-U6IN7-OV6LH-KDIJF-B53RG-FMUZW",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD5OJ-U6IN7-OV6LH-KDIJF-B53RG-FMUZW",
          "n": "
td41tm6KYElWFUBOmDzunfr1uBwkT8s3ssPwow2oUst4kSV6XU3keZvUXUO3uoqO
rZTpI-GA6os8lDrdohnnBxHkK0fBblGQytyIpqvYdzrN-M8kD5JrsC6Ew2zlSA7X
m5GhqttNTdpdgegYu0RHFEpYPaB78GvniEZSKuGyAdFKNnx2vpCADlL-_3CHS4A1
WOrZMvfTxWaEswHsOcEPNy5tcFAOlm-cwE1j8RwvYyBJHCZTSY_MqK9_CR4bnXt9
BsJOqWkjdQ0K721M10QN3eJFIDI-F_CPQGmi3gFHM8LOxl51dKTRmrAshQ99Eu80
qevNpGBcVtwfKvd_ijk3gQ",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQyQlctUlVTUUEtNldZM0ot
WURHWTMtUVA2SVgtTkg0NTcifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQyQlct
UlVTUUEtNldZM0otWURHWTMtUVA2SVgtTkg0NTciLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
e5k7KmGR-TzH2NBXn_IykvIytwldKpZYKXUS1GrKFuu1I5iam7UiwmSnqgK06vpi
0wpBpkvB0kb9HgqdG0fhEucwB2caDr7vfqGPpc9d5AI11Gp6Nm0e4rF60Ondx9k_
PoQTsZitQwZWYrmap-J_dyUAGmSubxvry5DvPNlTeX5fa0UrZzsj75f1R3YJEK8D
7HmD_f1VDuFrTnWQbyEKjMd-cONKz5s0RFDDwe4YIzlC5LXk8A6ogmL9U-Vc0mdg
xoiClV-ytGwXeTTK7LBIA4mLI1EDhBlSZHcPBJOd8uo6GDkwHaS-J7ymysYHey5E
9NF2ifYDedIakS3DZlxZMw"}}}
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
    "Entries": [{
        "SignedPersonalProfile": {
          "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVhZ
Mi1WQVBWUS1DWlNDRC1UUkNHMy1LVEJRMi1TMktSUiIsCiAgICAiU2lnbmVkTWFz
...
aUJsdWg4WjhVd3lHdyJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
            "signature": "
BiDHqGcftzngSmuCc1VqDoMOi3ejBz9CWWey1L8TRIm7DvjhQYj93NfAe08AJY-5
8ymcRGK1ux5loGZQeb-rGN4M-uhyWt7AvI3cyUJBW72_kVmyqTrIQ4e7t7_MwRr7
S_r-TmuXDS2CXurw36poYBdb9JGDlv59fY11N6FwlKjkYdW_Pd0MBMVyEXT9JMaB
En4q8B6YTkcQJ9TwUMlkHd8ZBumgwQZC4FN9v9mUopuI6c9GM20xJJnGmJarGOQ4
1nhchS9qvNc2IzRECucr85BtMO9RXA84if2pUsycj4mxDMUBNN_E0T26st2jPkEj
SUDkywrM9tgHa0iOiwbLKw"}}}]}}
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
      "Identifier": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQyQlctUlVTUUEtNldZM0ot
WURHWTMtUVA2SVgtTkg0NTcifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUQyQlct
...
TXcifX19fQ",
        "signature": "
emVPl32GiyChpyvHhBqdg5bIDNixas5Dy0icVk-7U9fVeDrzqqHi_yf4v2xj2YB6
lvCC7AkyxM-YlSH8SEOuADN173P6o0iMbchpc9XdCTwPWhxyiu9wK5qGJV4mkcju
WlzpsiQk0w1eg8_BqxywVqb0o3nWBvbFhOfApPCe0zyCzMK-olcA8HcSoIECNJZy
JjQfp25uXTRI5JkdEjPwRlWEaAwSwRxWytbOOz51mUIvBu39qX5JgrG70rJLFOoD
SfYdVV0mjLWHAPNtUeJflvaH3_V1M4M-ripyStwdYj57GODcyOwVNyiD9lsIg_El
Q4J9vykoM13RTNihCNw8IQ"}},
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
        "Identifier": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQyQlctUlVTUUEtNldZM0ot
WURHWTMtUVA2SVgtTkg0NTcifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUQyQlct
...
TXcifX19fQ",
          "signature": "
emVPl32GiyChpyvHhBqdg5bIDNixas5Dy0icVk-7U9fVeDrzqqHi_yf4v2xj2YB6
lvCC7AkyxM-YlSH8SEOuADN173P6o0iMbchpc9XdCTwPWhxyiu9wK5qGJV4mkcju
WlzpsiQk0w1eg8_BqxywVqb0o3nWBvbFhOfApPCe0zyCzMK-olcA8HcSoIECNJZy
JjQfp25uXTRI5JkdEjPwRlWEaAwSwRxWytbOOz51mUIvBu39qX5JgrG70rJLFOoD
SfYdVV0mjLWHAPNtUeJflvaH3_V1M4M-ripyStwdYj57GODcyOwVNyiD9lsIg_El
Q4J9vykoM13RTNihCNw8IQ"}}]}}
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
        "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVhZ
Mi1WQVBWUS1DWlNDRC1UUkNHMy1LVEJRMi1TMktSUiIsCiAgICAiU2lnbmVkTWFz
...
ZllEZWRJYWtTM0RabHhaTXcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
          "signature": "
C1EluYveoZ1cVlpawiqk6WqAyCAbbR2xiKUzG5dL5wVtw8EkSA2oSnaTZi_N66I8
FIcL1Ih5W9ylT2hX8s-sw5g0NbTSyY8UTh-THTwe8mFN_2gMEZG8foRwuLX0kQvh
02ZTmo8wfwvmMTnnLQOsQdfRqvSi0eD5-bfYRYnftBespawRhsmkL62ZiLmQqS9P
QUUjV1To00ZO_S9igLOvDE9a32cVIvnRcTFR3pZ2pwb-YIcC_x8rm5UYVW7UvmAK
MuB-G4b-EpoXZPmHLpOwLlLK-hCqHtuJkhIrjiWZGTcgWcw0BJzdr-3Hb5OmE-ib
z9BRIErg0ce5SfnYg7jCwA"}}}}}
~~~~


As usual, the service returns the response code:


~~~~
{
  "PublishResponse": {}}
~~~~


###Administrator posts completion request.

Having accepted the device and connected it to the profile, the
administration client creates and signs a connection completion
result which is posted to the portal using ConnectCompleteRequest:


~~~~
{
  "ConnectCompleteRequest": {
    "Result": {
      "Identifier": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUQyQlctUlVTUUEtNldZM0otWURHWTMtUVA2SVgtTkg0
...
dGVkIn19",
        "signature": "
LFqbasce5dlZn69E9e9ewVyekHu1JmCKXZFhWjvElSQ6aTayyZXA4a68C6oV4tPb
Tqxni53EDmWRKDeY9tZvV2NQ-_IPpqkNh7Vap_z5zBzhfkExB-fjuZYJnYobA8dq
ICc0IYjXLRfpiqjm4N_3UWyGMHPZCAd-mfQK2pO524CDpIME8YrLBqcG7hDh7yi4
NubcyYm_22-RCwZwj1nzOkqaEm527o71-FuBJ8l2_2bC2QsMr7ASUcJi35uxoI-1
syv_0B3ZzX0JKQVDf2VSOla-oP6ctBpgWz_rfYr2rtm6V3dI2UfWr3d-hjMpUFWl
Tlm6WJJKW0lAJerecOL2NA"}},
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
    "DeviceID": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MD2BW-RUSQA-6WY3J-YDGY3-QP6IX-NH457",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUQyQlctUlVTUUEtNldZM0otWURHWTMtUVA2SVgtTkg0
...
dGVkIn19",
        "signature": "
LFqbasce5dlZn69E9e9ewVyekHu1JmCKXZFhWjvElSQ6aTayyZXA4a68C6oV4tPb
Tqxni53EDmWRKDeY9tZvV2NQ-_IPpqkNh7Vap_z5zBzhfkExB-fjuZYJnYobA8dq
ICc0IYjXLRfpiqjm4N_3UWyGMHPZCAd-mfQK2pO524CDpIME8YrLBqcG7hDh7yi4
NubcyYm_22-RCwZwj1nzOkqaEm527o71-FuBJ8l2_2bC2QsMr7ASUcJi35uxoI-1
syv_0B3ZzX0JKQVDf2VSOla-oP6ctBpgWz_rfYr2rtm6V3dI2UfWr3d-hjMpUFWl
Tlm6WJJKW0lAJerecOL2NA"}}}}
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

{
  "PasswordProfile": {
    "Identifier": "MBX64-FKJZJ-VOJ4Z-XHTA3-CBEWW-GVSMC-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
BXHggWAjAavliSMdvSpALw",
      "ciphertext": "
c84QYlnz_FCBoGDyfxDZeLAjXOzomozHWjSMRSEG9pH0XOiuT_dRjlKvIQOFmzpw",
      "recipients": [{
          "Header": {
            "kid": "MDAN6-ZU5BV-VWJHV-4UYBX-PPB7R-IMVQM"},
          "encrypted_key": "
B3pZ-STwYg4O4RpfbsC6b-66zWUygwzO1GbKuMltCXiFjeQWuCDr8le0HbAKpEKI
irxXmFz0Iha94tAe2KFGhWnT-L1nX6dBQdRRdNVvNhs6tLTpfqJwwkByfZ_1vELV
ceYFHl8A9lFOXl55y4sCcHDdABT6MHl41HuaEJH6Fnrh-55_c7OaG5mf4Psls0E_
6vH0x-C_k8AITALuevJp7bWP93o8x9I3MSdJ44mvaeYcTBUt7yuEJNR9Q5AowZJm
dB-EVNUPvy--pT-K6uw-m3BEFw1R5Qnmnb7lOEb008pqlczn-FXs0bt8QEpDCnnj
H89eTHoEGKGJ6cESBDKCdA"},
        {
          "Header": {
            "kid": "MD5OJ-U6IN7-OV6LH-KDIJF-B53RG-FMUZW"},
          "encrypted_key": "
UOlmQrFkdW7CaWMU3vidf7RZ3BLiUSz-W53krsL71bj5jllX7CqqOMM6vi-WRO_y
Ektv9WJUVQrOlrqOl_4fhtPh2Dji07mXCWdcMoUVUmL6Xk6ENBibNGTTPLklAicB
Ka0vAye_mI6Y-px8r55bUVlu4cK5Ci6Rbk5pWbd1fJFLUw3Jh2NdKp0p6E1OSX6A
uvPgZWhLJNlXhidgMeUPtkT1Y7fqA4pSy7lQ5s4Jc71KzGQgP6waAWLoRbuyXZjZ
9LJIjlW3NmVPfECvNb_C9Dpv2I4x9dkT3Nq2DXiHW65mEv6366ChpTAe-0g554lI
JZndoFc7JL2f1sYHJqx8CA"}]}}}

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MBX64-FKJZJ-VOJ4Z-XHTA3-CBEWW-GVSMC-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlg2
NC1GS0paSi1WT0o0Wi1YSFRBMy1DQkVXVy1HVlNNQy1BIiwKICAgICJFbmNyeXB0
...
aHBUQWUtMGc1NTRsSQpKWm5kb0ZjN0pMMmYxc1lISnF4OENBIn1dfX19",
          "signature": "
frOoFBI8Ir0FxJLqbrAgSICeK_chBBaR-elKyo73U122LMdTfvHuPYMIYO9vzyxk
p5uYN7z35PCQPQcyccNjXPsuUidtAo5FRK4movF9iZdwnARnDwrWwKhQ7YShwZYT
jlVFpLPZtHkTKScHtPV3FZ_cM7Nnmp0hkCwA-oOE0pHKB8vYWCQTlfV-lnqe1snX
nwykm5hauq7DPQrAJksk8qyuv7hKeVkSq3ceByQ1zTMWDGlcbkm8Zt8sNL3K97-1
NgnolRuvygaKxbonHfrdjMEz-wgCQU6qElW5_0RW3xKGZJqprrlsCFQY6dsyJayc
Cqn6DQRJBiLOy7i6Wc2lxg"}}}}}
~~~~


The service returns a status response.


~~~~
{
  "PublishResponse": {}}
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
        "Identifier": "MAXY2-VAPVQ-CZSCD-TRCG3-KTBQ2-S2KRR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQMjUtWkhINVItQkNVQ1Qt
WkZOT1gtQUxLNlUtRkdFQkQifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVhZ
Mi1WQVBWUS1DWlNDRC1UUkNHMy1LVEJRMi1TMktSUiIsCiAgICAiU2lnbmVkTWFz
...
ZllEZWRJYWtTM0RabHhaTXcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
          "signature": "
C1EluYveoZ1cVlpawiqk6WqAyCAbbR2xiKUzG5dL5wVtw8EkSA2oSnaTZi_N66I8
FIcL1Ih5W9ylT2hX8s-sw5g0NbTSyY8UTh-THTwe8mFN_2gMEZG8foRwuLX0kQvh
02ZTmo8wfwvmMTnnLQOsQdfRqvSi0eD5-bfYRYnftBespawRhsmkL62ZiLmQqS9P
QUUjV1To00ZO_S9igLOvDE9a32cVIvnRcTFR3pZ2pwb-YIcC_x8rm5UYVW7UvmAK
MuB-G4b-EpoXZPmHLpOwLlLK-hCqHtuJkhIrjiWZGTcgWcw0BJzdr-3Hb5OmE-ib
z9BRIErg0ce5SfnYg7jCwA"}}}}}
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
  "PublishResponse": {}}
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
        "Identifier": "MCHDU-NB5LX-GJO3D-WZ3W7-S2PII-W2QTM",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
XAkc1IxPB2y-PWYKdlw3YA",
          "ciphertext": "
ghIVeH_bLoD38VlTzH0wbxYFMzgMywT9avgSHdicSF81tmwcJl7B-k35ExS2H8EO
RWjgOhiznUMpL8lfdzyYhzC0A_amZIAuDQquxGdJeieD7_CJTCEJWkj1EfSg_UkJ
...
RJ7OF0FPUndjGU41B2W46Una7glu58m2sM2On7vDNCEbcK3ipVFPQIrL2DjZ1ohL"}}}}}
~~~~


The response indicates success or failure:


~~~~
{
  "PublishResponse": {}}
~~~~



##Recovering a profile

To recover a profile, the user MUST supply the necessary number of 
secret shares. These are then used to calculate the UDF fingerprint
to use as the locator in a Get transaction:



~~~~
{
  "GetRequest": {
    "Identifier": "MCHDU-NB5LX-GJO3D-WZ3W7-S2PII-W2QTM",
    "Multiple": false}}
~~~~


If the transaction succeeds, GetResponse is returned with the 
requested data.


~~~~
{
  "GetResponse": {
    "Entries": [{
        "OfflineEscrowEntry": {
          "Identifier": "MCHDU-NB5LX-GJO3D-WZ3W7-S2PII-W2QTM",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
XAkc1IxPB2y-PWYKdlw3YA",
            "ciphertext": "
ghIVeH_bLoD38VlTzH0wbxYFMzgMywT9avgSHdicSF81tmwcJl7B-k35ExS2H8EO
RWjgOhiznUMpL8lfdzyYhzC0A_amZIAuDQquxGdJeieD7_CJTCEJWkj1EfSg_UkJ
...
RJ7OF0FPUndjGU41B2W46Una7glu58m2sM2On7vDNCEbcK3ipVFPQIrL2DjZ1ohL"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


