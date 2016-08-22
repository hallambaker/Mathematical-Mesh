
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
Date: Mon 22 Aug 2016 08:59:26
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
    "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
    "MasterSignatureKey": {
      "UDF": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAIOKLp_GPWl4suYMSF9jIYIwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUROT0ktTUgyRkotTVJVSDYtUE1LSEktR1JTWDctUUlGM1kw
...
pWXsvmpRKYcXRCCI5fpSxW9W-PSd5JKO0ehJwqtSeW_Vol54w2_ux_pj4w",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
          "n": "
n5LhyfCOUBgP8fVhvHrZphDfw8kO6NMuFaxnHG7WGvaLUZ3OX7SawH8aCukVPQ5R
XlkBeAyO5mJf1N-IjT9144gDOG19jTmdMCe6M_y3jYoHkI8jOZGKU7oOVfTSqmSo
RehMEA8DxmAOF0pfljJr7Pai-lt6UbBTGTtCz7jZGwWgCUUAwAUgloiU3YCdXV4m
jSkB-cvZc-kXuCtgIE0AeGbVkFLkouPPOaFVf3JqsVwE9gRmtoBdlkshfsctv2qU
NwHqvgSWUMcaSXQHpjAsk0G9mFE_TnBTd5CjkYUQraTO1bIVc8v_5le0S6IOIC9D
66Z1SvSx39DYC3Gzo-GZUQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MA6RL-PBUTG-ZMZUV-MMXPS-5DJW5-TPSPK",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQKOkT5L30A7TvTerYvBnhYzANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNRE5PSS1NSDJGSi1NUlVINi1QTUtISS1HUlNYNy1RSUYzWTAe
...
xmB_f3Ja4IF14UxXmMr7Kl_ryjHST4fW-6C5Iz6Q1MeUga0ciuNtSByT",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MA6RL-PBUTG-ZMZUV-MMXPS-5DJW5-TPSPK",
            "n": "
0o6QJAJjokCbpgX-_hqw_im_lN7JqhEx5IvfUs73fA736zIISBITvxIv137cAKK2
ionMbd45aldSq-yUwdsQQPhGgRKDacfzPmOhE7Tx471N4mWCyNdM1pz3vhlHFzsH
MCjwMBc9dltpBDnYN9N44W2c338yxB0w2E-MaX_KV5m6YeuoVIB7mpWJJ3K_Ph0A
1ehFrz2k5kUrl-d0pyboLjucOFsvLdkrRKFq3STzSE9ubF9VE-iQERzQQOVgatsO
srm61OFyQYKpZqpSzRYrUy99_1tbjYUXNEJhm6pdhj_DzejSduSZ1lbOQPITo5RM
m-1dzt-z5dbRRWZDhT3hLw",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MDO5B-ZDE4R-YZ4QX-WOQO2-IISQX-3ECZK",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQVYRxaxRGgua1lJ-MlJid4DANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNRE5PSS1NSDJGSi1NUlVINi1QTUtISS1HUlNYNy1RSUYzWTAe
...
AgP5cLhq7jYR0nNLHGULwVwdzkcR6QWu0nzy-SNNP_-wVUC1fudsY0D6",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDO5B-ZDE4R-YZ4QX-WOQO2-IISQX-3ECZK",
            "n": "
rYpt3pZ6W1XJQGHxbpGTmUCYU3ve1wrCwOU2yh-msdldy8XJ2Fo60ivsVIRhPajv
achQVP722kD55QpddY4eqx7AX5o5utvF0Ip5eXKWjCoVq3hLSxuWLIG0npMBLwiK
4KD1EhRDdxg8EaItY0VVzKaR4-xheqeV4HiXNdXDQkI3mtfBf-Or8g4atUGa45zj
TVy0cDB5-mJSME5e_Z9R5grUcoe3pBA67veZEZEcAANPU5qYIEhwzJTcgXg_FDnl
tvS_lB4i72i7sh095Vo2mPOs9ggSVgljsuFbDvy_x5Z5lwV_fkYeKSobEruI-mwJ
ZgJmbT131gm82yTdLr0JZw",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUROT0ktTUgyRkotTVJVSDYt
UE1LSEktR1JTWDctUUlGM1kifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUROT0kt
TUgyRkotTVJVSDYtUE1LSEktR1JTWDctUUlGM1kiLAogICAgIk1hc3RlclNpZ25h
...
QVFBQiJ9fX1dfX0",
      "signature": "
QmTV7LBCMe7SmFWM5Os_lQf-jJeRJ8m2wfQ3K_14n8tRq6jSlQ_-MnTdjnbHVJbA
ZqsGBNUR-NDoLlOviP0R68BFlevp2HdkIzARLdxvBzA3LF_mAJcDptFfCaQ_pSPG
XgiUZkRHUGCf_PQ39ALgHeE7ZkK09B6E1mA7o9Z3K1sNIeKWIMSvuL_K81ctQRfq
OPrKBpeevbaHrPuxZPCaXS7j4Cews0JCM2WqUezUsot6HUk8iHsgBwD5RkCqmt0D
G59nRNhr2m1NY5_VgyOkteOQWAaP01FNhwrT1JOQL1ypaJ8IOJG5vk-5LlBLlYM2
koqUSOCUBHz25UQ8cXL0ZQ"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MAUVJ-K76BV-QKJ5Z-2I7L3-3MPAI-52PZE",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MAUVJ-K76BV-QKJ5Z-2I7L3-3MPAI-52PZE",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAUVJ-K76BV-QKJ5Z-2I7L3-3MPAI-52PZE",
          "n": "
scaogqOH-wtvW0_89U2YyKdlA45OjrLLp5Y4i7S9CgrWCsC1T2wJQBDBQ7wdPJNa
Xt2_iiJElEUthxgWo0jOWZ_RtJncu1tQooNYQxg1_Cd3Mnk-w3T9RRyZUuwPrdFx
TmgyEFzjOD8StxGhNjN_K_4NjMJklooX1uWTNgCu_eoA8iHRyr0B5sv5yKoWLxKx
CfA9eGIAWC5BdUW15nLPxNEnavFtDTIuXHDfSRT9KK0IkAfRkQsEGpclhPMEeaYe
nYswgZTyjo8tzH1XlOOxmVwe330fY-ndtil98ePzdNcOoZ5-xxByqU1Llv9sCSzY
xxw2HbDx3H7ZDAEfetFyVw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MD27Z-OU5DO-ANWLK-2S6QP-2B53L-WQB6G",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD27Z-OU5DO-ANWLK-2S6QP-2B53L-WQB6G",
          "n": "
6eXs9umwthLfra5qWq-KhSLBBGof9aNJJJvaapMKB2vVBemc6GNRTVzXYx3QEKvl
Xe4Zoarooh-tQ87l1DIVW2xcM24xPqCA_YmJbR3AMmdbOk9nZJKuNNL_hhNh_ldV
CsgQdNo0p4GyQxSKBPjf3IR4fQXumyDJc5gvpVb7KqiDZ5Cq6FVsrq9dlKqYD_0B
_X3PphG7ZDl8yoi2H4tuybAZzA_E2Z2XNbeO8UruF2mVo7KpaDRPxIKF24iBcMVi
nsjwf5U08qn-M-Zsbrl21TxzjpWdDjLVFpEzdSDGh9RuyPX5z0BLYjDPPjtjufhf
MQFbvQwWKZXpxZX1yhBOGQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MAEJX-AM5C7-V25FK-MFEUM-WD2Y4-OAV6L",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAEJX-AM5C7-V25FK-MFEUM-WD2Y4-OAV6L",
          "n": "
6D-lNuPq0ezamR1OM-b_m09Qx4ryi-f3EdDoX5WT22nOsFpejKMPlxev6oVK4_uT
TUlJTeWG3iMXyAX_HdTNmSGX6wfb1vPc5xOxBAm2m9SsFcE5tLRCaOcqBY3uGiSx
3qJVfxxZaNDXAK2TTC84J225AbBaCnZv9FeqkrRiXnmEWlBRUvGuLn5Pr_aRk6m5
NZgLu5tEEkjBu5ItDcA3msdYHlhkIS3F_2HUipNmU5K-EVWqVLCjuasd-N57DlnE
baVR0hp0PNkdDkqVFDPoj_kO8sTMBB8lGAjAgmkWdPSuSMY3lbzYLJa9ambQ8D1q
uQ5jFxgETWvdKeD_WvOnTQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAUVJ-K76BV-QKJ5Z-2I7L3-3MPAI-52PZE",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFVVkot
Szc2QlYtUUtKNVotMkk3TDMtM01QQUktNTJQWkUiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
PvXN7ft4ZTQqJfmSquOP90M40O6GipeOpC_dVzJ4p3enNd5fOkS57LLMV3z6ltax
tKttV4--3Ml2rVTmXB3tc7sxNQ2rcEYoUhL48SJCcCQGGUusvwPHQwNeLEVR4Lg_
wlywFQuCsrapcCH9kqdbWcQ2fHdRaX95VwDhIpLLf4Hjq9zI2NM0pQIWg247Ife5
d0bDKnzhJN6Y_tGL6yKlGrTY_o-d7bScbGbBp_VatMggrTGzBvUwaVY3WgW4zPK0
ChyYst_AldtpANhDlhWJj8yOJE82ozFlcPgKkcUnJwveuH4tREHot8X8joCSFRbc
ggR-vaNhl_9Xudg8W5DGHQ"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
    "SignedMasterProfile": {
      "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUROT0ktTUgyRkotTVJVSDYt
UE1LSEktR1JTWDctUUlGM1kifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUROT0kt
TUgyRkotTVJVSDYtUE1LSEktR1JTWDctUUlGM1kiLAogICAgIk1hc3RlclNpZ25h
...
QVFBQiJ9fX1dfX0",
        "signature": "
QmTV7LBCMe7SmFWM5Os_lQf-jJeRJ8m2wfQ3K_14n8tRq6jSlQ_-MnTdjnbHVJbA
ZqsGBNUR-NDoLlOviP0R68BFlevp2HdkIzARLdxvBzA3LF_mAJcDptFfCaQ_pSPG
XgiUZkRHUGCf_PQ39ALgHeE7ZkK09B6E1mA7o9Z3K1sNIeKWIMSvuL_K81ctQRfq
OPrKBpeevbaHrPuxZPCaXS7j4Cews0JCM2WqUezUsot6HUk8iHsgBwD5RkCqmt0D
G59nRNhr2m1NY5_VgyOkteOQWAaP01FNhwrT1JOQL1ypaJ8IOJG5vk-5LlBLlYM2
koqUSOCUBHz25UQ8cXL0ZQ"}},
    "Devices": [{
        "Identifier": "MAUVJ-K76BV-QKJ5Z-2I7L3-3MPAI-52PZE",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFVVkot
Szc2QlYtUUtKNVotMkk3TDMtM01QQUktNTJQWkUiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
PvXN7ft4ZTQqJfmSquOP90M40O6GipeOpC_dVzJ4p3enNd5fOkS57LLMV3z6ltax
tKttV4--3Ml2rVTmXB3tc7sxNQ2rcEYoUhL48SJCcCQGGUusvwPHQwNeLEVR4Lg_
wlywFQuCsrapcCH9kqdbWcQ2fHdRaX95VwDhIpLLf4Hjq9zI2NM0pQIWg247Ife5
d0bDKnzhJN6Y_tGL6yKlGrTY_o-d7bScbGbBp_VatMggrTGzBvUwaVY3WgW4zPK0
ChyYst_AldtpANhDlhWJj8yOJE82ozFlcPgKkcUnJwveuH4tREHot8X8joCSFRbc
ggR-vaNhl_9Xudg8W5DGHQ"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRE5P
SS1NSDJGSi1NUlVINi1QTUtISS1HUlNYNy1RSUYzWSIsCiAgICAiU2lnbmVkTWFz
...
OVh1ZGc4VzVER0hRIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
      "signature": "
LH-25N5f9to22VUAiUsnMHg6lbjlCKU5pDgaKg6Cj5OJ2t9TMoJtJtAwOVyUz2lm
AUtdx1kY4TA56vFHVsfYmcax_dgaKO0yUiV5Yg3JDL_JppomB2zYUX6yRMudBUIS
8j_VvRp_w06R1VVWs4tRG-8G9qdqoIqGNNAVZrfD-oWAJcMIFxLAmjVNtxOyByRo
A07kAhvyRd_z7fIiW9tjvCTjPgnfuxV5AdalLeb_6xBK1blOgLvA8XPjCysDAF1m
X19yy7_iTYMAY-h33sF49HoKePR4YjaJ9YcVtAFxs4sJAsiJUe6UdbNambsVtzuj
tuZ9C3HKTJoXOI5909azog"}}}
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
        "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRE5P
SS1NSDJGSi1NUlVINi1QTUtISS1HUlNYNy1RSUYzWSIsCiAgICAiU2lnbmVkTWFz
...
OVh1ZGc4VzVER0hRIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
LH-25N5f9to22VUAiUsnMHg6lbjlCKU5pDgaKg6Cj5OJ2t9TMoJtJtAwOVyUz2lm
AUtdx1kY4TA56vFHVsfYmcax_dgaKO0yUiV5Yg3JDL_JppomB2zYUX6yRMudBUIS
8j_VvRp_w06R1VVWs4tRG-8G9qdqoIqGNNAVZrfD-oWAJcMIFxLAmjVNtxOyByRo
A07kAhvyRd_z7fIiW9tjvCTjPgnfuxV5AdalLeb_6xBK1blOgLvA8XPjCysDAF1m
X19yy7_iTYMAY-h33sF49HoKePR4YjaJ9YcVtAFxs4sJAsiJUe6UdbNambsVtzuj
tuZ9C3HKTJoXOI5909azog"}}}}}
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
    "Identifier": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
          "n": "
rFR3WULGziMckbJSqDyNagCzgDmfsBsmLJiTd6J5BCldz4qiLY2AUSd99SCTsBaA
-hzz8JrUJDW1_J31w8BZIdk3oI6zLMwNDAIOMA2GJSW9ytYBg0IOVDKIymul_aCD
26fR4K3EeJVN6U_H0npfdqC1eTUQLzJHgHh_9Q_X0_F2n6jdAip5zKQ09UVrq9dy
vfGBUFAXE2OGKKUkOjvbjbZnpt__gLlepjsaZ4oWMS-rigokhmKz0zpI7yOY2i0O
2ij6OIRbvZpiy2pIIFgBPCp9jsJ0ziZDOJYqe_PQ-6KyszY62-4ElFTch1x8PWtv
fw_-nZWUicMnDsMX6hX7eQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCA6F-BZAJQ-JLS2G-H3VNC-FN5ID-Q5QCB",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCA6F-BZAJQ-JLS2G-H3VNC-FN5ID-Q5QCB",
          "n": "
wDupLQOC8KoLXawZtSV1QlbIxWWcZgsIDLgaJZ3DlGh4zFWuHlufJkKswpZTUclN
Xbd5WJHEGEdydfvABloT-S4NCovOU8S4-JGnUcl1NFifXfea_hZcnDIii0CExY2Z
-NIT3KbopUK94ZRbXee6P2tY6w8DiL2XHntFHQdULWcJvwAK3w72tiXYf6oY-cv9
DTDtb8CfuYVfe8NcTYDMgtkUE31OFa-v8rxKr54fKNBfVZe3EDL0-lFQtlU_vuWO
pbIBaQSVMVd71C5vIV7Tl1n-Fas9xHA7K7SZsTC1A-VG936SSvT4uxYkH0oYGrKl
9Vx4MqjUbLBlP-aDAJ1v1Q",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MADBY-64XY2-CCN7I-2NDQ2-NYHZ4-M6CQ6",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MADBY-64XY2-CCN7I-2NDQ2-NYHZ4-M6CQ6",
          "n": "
nuj1fhaFwHscpnslgHIA_suW6DAM_yx9P4B1LFJDrpq253mgjn80tGdM8_wfaR7r
E_tS_JtVOQASczojlqU0e88Q0UlKVpWpg0zZCLFz51omt-P-TheyDoQWZnfBiz7y
ckzC3nyscyj5olVc9NcQm2XsbetHurEeoe4XsrIyhSHq4MEQtkOZCpHfzd8ixnVW
G59RuCZqi7pk4MKtq219BgejFXA36QNDIhIV8aAcqo4Nal5xndjVetr0YEjgaCPD
PCdEI9AsTcTA54Oi32OXEh3PVj-uR0XTcP50BfU9FvG4VO7QsYALbfBJG6UTaXN4
UjYi-Eb0kZQ0hSS5lpk0ww",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJCSjctUUY2SkgtVUk3VEgt
WEVDUzctWUIzTUYtN0lIUE0ifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJCSjct
UUY2SkgtVUk3VEgtWEVDUzctWUIzTUYtN0lIUE0iLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
JTk70txLKtPXVAf6XhVCsBkyFIj4LGbsiLw6DDiT26390_D4YQ-ZbdhLzDTfQNXa
VE-f8X46RAVkNtfiDMyttuh8csmF-Ak5yGx7Ds0dwRDyZ9gSm_MTFa2xOhA7hGDg
7rxZ9qhmkNqoVIl-t5tvH1J4JyRJr7VsODkSag32qookedct3yuq1qVriU5R7gSX
qiStCRLbxNxQCd0WC2rkKfY_3DeXLdIWrn_G_J-JPyoZGad0bYqlV4Py_V_VDxiO
NQhCTnwuuL00JxonZSos8p4loACVeWn1VX0SAGhDsU7FsoqyClxjHce4LSvT_0aD
YstoN1NKpHJcSH9Ww3VdWg"}}}
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
          "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRE5P
SS1NSDJGSi1NUlVINi1QTUtISS1HUlNYNy1RSUYzWSIsCiAgICAiU2lnbmVkTWFz
...
OVh1ZGc4VzVER0hRIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
            "signature": "
LH-25N5f9to22VUAiUsnMHg6lbjlCKU5pDgaKg6Cj5OJ2t9TMoJtJtAwOVyUz2lm
AUtdx1kY4TA56vFHVsfYmcax_dgaKO0yUiV5Yg3JDL_JppomB2zYUX6yRMudBUIS
8j_VvRp_w06R1VVWs4tRG-8G9qdqoIqGNNAVZrfD-oWAJcMIFxLAmjVNtxOyByRo
A07kAhvyRd_z7fIiW9tjvCTjPgnfuxV5AdalLeb_6xBK1blOgLvA8XPjCysDAF1m
X19yy7_iTYMAY-h33sF49HoKePR4YjaJ9YcVtAFxs4sJAsiJUe6UdbNambsVtzuj
tuZ9C3HKTJoXOI5909azog"}}}]}}
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
      "Identifier": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJCSjctUUY2SkgtVUk3VEgt
WEVDUzctWUIzTUYtN0lIUE0ifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUJCSjct
...
V2cifX19fQ",
        "signature": "
VYuAUMefJNq4IxYmcL_7ZyIIYHTrLoZk8NhxRtPS46WX5lxdGWqLYe-wFlWfBJ4j
yQ9mPoi2uL1fOM0B_gOsz4zvMaiuM_vOI5aZAY1vGxf4gf4_fXpp9Xz4RFwRWO_4
UTLQvnUEhucIUo64p5gGwctj9HVhDX8eCO_dtjv54adYtTCSNXOOPRo0PBc31yT4
Rho20j5_fmFEuKu0XyuJEWBbrRbdrM_eSBKL1Ppq1TnWfJDKVKJG9I18j6uke_aY
YorkpvX3ejypslmGZeI5QK-6GxoWKWAlGEeKqiDGNbxvt0ltwb7r84u29jsOAdUE
8YLgekU7zgpSI2_xKu8pBA"}},
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
        "Identifier": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJCSjctUUY2SkgtVUk3VEgt
WEVDUzctWUIzTUYtN0lIUE0ifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUJCSjct
...
V2cifX19fQ",
          "signature": "
VYuAUMefJNq4IxYmcL_7ZyIIYHTrLoZk8NhxRtPS46WX5lxdGWqLYe-wFlWfBJ4j
yQ9mPoi2uL1fOM0B_gOsz4zvMaiuM_vOI5aZAY1vGxf4gf4_fXpp9Xz4RFwRWO_4
UTLQvnUEhucIUo64p5gGwctj9HVhDX8eCO_dtjv54adYtTCSNXOOPRo0PBc31yT4
Rho20j5_fmFEuKu0XyuJEWBbrRbdrM_eSBKL1Ppq1TnWfJDKVKJG9I18j6uke_aY
YorkpvX3ejypslmGZeI5QK-6GxoWKWAlGEeKqiDGNbxvt0ltwb7r84u29jsOAdUE
8YLgekU7zgpSI2_xKu8pBA"}}]}}
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
        "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRE5P
SS1NSDJGSi1NUlVINi1QTUtISS1HUlNYNy1RSUYzWSIsCiAgICAiU2lnbmVkTWFz
...
TktwSEpjU0g5V3czVmRXZyJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
CHOCJVcfgO5mVXTiIy6Rj3Xb2cwL4oyJvj2D5UELV6JcjjD-_5ME3BYVJ-Pf26nV
7GNJV0X_ms1-52ORe-FG4716brzkuaUrkEEfOHTiAeQZzgNj3d2UXvDSNr-aG1co
PIFDoqcPN4zHHgxRb7ymNiDr5sM5dAdegjWlbqwBENDTChmFIFvol-ciLPm2EuFG
yoplvLIIInIUoUMHeJhzsIqQ9uRWlG40h45XOp9Y-hXXl2btXOaFBlP82syhvQ6l
QAhwqpNbibMOI_c-2YaK5Q8gmbTmAb154D2luZtEY7p7WCI7wr9DItva5nLwe3M3
g3B-Cn5XMdOrtAuY8WV6ag"}}}}}
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
      "Identifier": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJCSjctUUY2SkgtVUk3VEgtWEVDUzctWUIzTUYtN0lI
...
dGVkIn19",
        "signature": "
HmEWT31B0NLY91JODzMVpaVHqnh24nXAD8ECZBE6P8Fda9VRBtxE3lZ4mJsjQqSl
lImrrF60bervm5ZvMbSKsuJfJ85DYIOFO_BZbaFXHZ8-LGuxW-yfqwM6qXJJ37MH
2SXuzDabc8GLfpHAUUuAn-xZ5Eih9v9Waq4M0vsN8Odg_cHpolu87IOMOknpV0Le
1yYX_FtmVN_kv73CWuNLkWmwtGovxDQOCerwz8M6EEik5twqrTel6AFO36N5vHDU
ips4SMWl03_pVg8s59SplOWy_A_jCXFBgTV7w7IJFF01yGb9LVLln_KZrS8TQO5a
duxH-PjPygngH5mmcJx_Tg"}},
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
    "DeviceID": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MBBJ7-QF6JH-UI7TH-XECS7-YB3MF-7IHPM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJCSjctUUY2SkgtVUk3VEgtWEVDUzctWUIzTUYtN0lI
...
dGVkIn19",
        "signature": "
HmEWT31B0NLY91JODzMVpaVHqnh24nXAD8ECZBE6P8Fda9VRBtxE3lZ4mJsjQqSl
lImrrF60bervm5ZvMbSKsuJfJ85DYIOFO_BZbaFXHZ8-LGuxW-yfqwM6qXJJ37MH
2SXuzDabc8GLfpHAUUuAn-xZ5Eih9v9Waq4M0vsN8Odg_cHpolu87IOMOknpV0Le
1yYX_FtmVN_kv73CWuNLkWmwtGovxDQOCerwz8M6EEik5twqrTel6AFO36N5vHDU
ips4SMWl03_pVg8s59SplOWy_A_jCXFBgTV7w7IJFF01yGb9LVLln_KZrS8TQO5a
duxH-PjPygngH5mmcJx_Tg"}}}}
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
    "Identifier": "MCKZY-MQMR4-BZSIO-5X4YA-6GJY2-PHVVM-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
oyj9h7NKB1IFwPNoLTy14w",
      "ciphertext": "
OyfLtmtdRrNqRasFcZYaj6sG3AQenMejbdlBEC2AsyU1I0Z7U-NY_qiy-_rIXKWl",
      "recipients": [{
          "Header": {
            "kid": "MAEJX-AM5C7-V25FK-MFEUM-WD2Y4-OAV6L"},
          "encrypted_key": "
TAiJhSBLbTMI4Gf-05-mypLi6eEN7KCJ1ANzBrRwec9sevL-eWY6pt6l_abb14Pf
kt9IsF1h3heNKwlxI9eZpBPqvUOe_u2EqeRBySxaywTYV9kYHSZcDh5BQAxosYa6
ah8kHxEXiY0dEU15TZ0TUes3hUfYuYwgffsmL3XXLwYj_m2T8sMuHvt2hPtwsWm7
QQgn4YQ8xSMO3kIIPl_Elp8HkISM9sbpWSLjAQT8ILpeEhsSwbFLIrYAVbChwi2x
VKl0jlkn0bt8amoM-n5HOE7xUEE1cygG-NEidSxNXhpMnCarNZP70TX_6-Ke98Uz
YS2fAxhbWGzgtek5hTnUbg"},
        {
          "Header": {
            "kid": "MADBY-64XY2-CCN7I-2NDQ2-NYHZ4-M6CQ6"},
          "encrypted_key": "
jNrEhCbIOhSfztHV2hthTKTVRpIh8Qug0tKs3Chb2BDbnKNjfpKwk_Pyr5C1fl9M
zv2WbkokiLqVfYr8fVty2qFi2loTHUm-JIAP-LY78H-INbRbOdCF0272cGmSZwK6
UoHtZ-SzQRF-DRwsKGbl18XD1W0shBzFUMakpa4irx3tw98U__07HpkZJ-fqYsEv
oHI5QLg0aC3qpsvAhElAPQzdbLK2bJbbANOlKJYxYiiE8EpIW4clfHBlUkzu89es
yX4Ao7lzo0ZhrBmDFIHns_4Q7kJRO0mDBSt3F4vJbOo2bpKFgQvIpI6ZSnrr16t6
tw71Oi0G1LglW9zNdYrKpw"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MCKZY-MQMR4-BZSIO-5X4YA-6GJY2-PHVVM-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQ0ta
WS1NUU1SNC1CWlNJTy01WDRZQS02R0pZMi1QSFZWTS1BIiwKICAgICJFbmNyeXB0
...
SXBJNlpTbnJyMTZ0Ngp0dzcxT2kwRzFMZ2xXOXpOZFlyS3B3In1dfX19",
          "signature": "
l0eHL9dHtG52_5J80HqX2wjtOcc403xQriuTs0ESfYCQtYeMwe2yUevIaq_g0_uq
APnQOgqpOZSFXR-XA0kDWI-Z6jV40LlIJ-tHH6k_aEwSvukouSdzqhBIEy3WNyDI
H7RQDqjQOJHYRGCFxLm_1zrKYHqhfRAYKJvyaQtvfNzqM8wWvPhnKRWRstBfnUkM
1N9vx_BkeCuBTo3XZ5GyWl0TVz0Dcfoo07a_EkXpOHpVL9uXt_eVNsnwvPsquqli
uebYj0yBCw9YTRwXVxwyW1LhsKxawiruEm5XkDAhUVrS7nJL_ybgMdZYdetQv2dz
jcY-ent7x2vrbfpVJNFFeg"}}}}}
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
        "Identifier": "MDNOI-MH2FJ-MRUH6-PMKHI-GRSX7-QIF3Y",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFVVkotSzc2QlYtUUtKNVot
Mkk3TDMtM01QQUktNTJQWkUifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRE5P
SS1NSDJGSi1NUlVINi1QTUtISS1HUlNYNy1RSUYzWSIsCiAgICAiU2lnbmVkTWFz
...
TktwSEpjU0g5V3czVmRXZyJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
CHOCJVcfgO5mVXTiIy6Rj3Xb2cwL4oyJvj2D5UELV6JcjjD-_5ME3BYVJ-Pf26nV
7GNJV0X_ms1-52ORe-FG4716brzkuaUrkEEfOHTiAeQZzgNj3d2UXvDSNr-aG1co
PIFDoqcPN4zHHgxRb7ymNiDr5sM5dAdegjWlbqwBENDTChmFIFvol-ciLPm2EuFG
yoplvLIIInIUoUMHeJhzsIqQ9uRWlG40h45XOp9Y-hXXl2btXOaFBlP82syhvQ6l
QAhwqpNbibMOI_c-2YaK5Q8gmbTmAb154D2luZtEY7p7WCI7wr9DItva5nLwe3M3
g3B-Cn5XMdOrtAuY8WV6ag"}}}}}
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
        "Identifier": "MCXQR-PKCKG-NSUFB-DSSGA-T3R5O-P54ZX",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
2LgiL3a765LXaU_tCq4gaw",
          "ciphertext": "
YJZgI5_mnvfhwAESKWgO_gXEEYegCKZ0Q2EvmlW33pAzqeO9tGDtQOWhvZPG03TN
PcbXaoEFhxH8GfyA96fDclpfJiJca2KEjz4R8ISpzfYVSFTzePWb6Cf2mOlfHEcA
...
N3r7OvNmTUtOTNYL9sA4Lao-qlHUGW2KVldBruIomPKeuy7ENunnmnkpO9SdItq8"}}}}}
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
    "Identifier": "MCXQR-PKCKG-NSUFB-DSSGA-T3R5O-P54ZX",
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
          "Identifier": "MCXQR-PKCKG-NSUFB-DSSGA-T3R5O-P54ZX",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
2LgiL3a765LXaU_tCq4gaw",
            "ciphertext": "
YJZgI5_mnvfhwAESKWgO_gXEEYegCKZ0Q2EvmlW33pAzqeO9tGDtQOWhvZPG03TN
PcbXaoEFhxH8GfyA96fDclpfJiJca2KEjz4R8ISpzfYVSFTzePWb6Cf2mOlfHEcA
...
N3r7OvNmTUtOTNYL9sA4Lao-qlHUGW2KVldBruIomPKeuy7ENunnmnkpO9SdItq8"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


