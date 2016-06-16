
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
Date: Thu 16 Jun 2016 06:02:16
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
    "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
    "MasterSignatureKey": {
      "UDF": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAO816esQiw6oD52tOCJSNaAwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJJNlUtNzNUN0YtU0tXRTMtSUE0UEstTkpUQUctNlFWWjUw
...
LbC55mfa2PhV8x-DGb_tXnBah8hDKRoXNz_w-zNn145mXxI07UPHKut1jQ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
          "n": "
4cJLij7qzG9jGNtOOSOlJHZZd-14Plhp5zhr6pb1ar1IxmSBWZfI3LhzE-ynrbUr
mKogi6iQRovtlTfzTOJK4F2cdGsq16xH5d2uyzfMMKTxqVN1j1i34chW-bJ4j0tI
AHN-l6JDcy5vl2QodFhqkqH6_w2uqxMsbxHIVubXmzRxvXAvWQ9du7VUdCb98wrA
QhpZtD8dfj1eOz6gZnuoEMPYIommZ_dTdZzscR1i-Pmo5iYwfbaR3Z-IHL51yBtk
6iLvjOUk2JF-iPQ_SoQxCX5vQNA3nO4HzkyusfvKrFyba7vSLXN-Oiv3gmwLc287
KMVslTtF4kp5trEI011IeQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MBMDF-YI7D3-SYRT6-DS5VP-WBIJJ-HHMPU",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAPaSTefxZ1iITZQOmGCwP0IwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJJNlUtNzNUN0YtU0tXRTMtSUE0UEstTkpUQUctNlFWWjUw
...
LWmMxg72yU-oMAR54THq2US7NttwJyS2rd3_Ge1E9TirB1Tb5H1XbTozBw",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBMDF-YI7D3-SYRT6-DS5VP-WBIJJ-HHMPU",
            "n": "
m69ze0g2tj498IOjnyZJXIYj4kjVsmX4IRaQMyENlNN7iBazZRKVuYFQzfLYcFGi
f7uOM4ApwnUxQZ1-F994PRricq-PQfArQHi_uD65Hc5wn9trrAevh2hx99aBdEd6
XBNHqrarpZ-qk04-bBon7bQ7QR-Y04VGYC3zZmwLu_n5tJlREXwbEHiPcuSlfb-D
EK7b4wxlg3r4jKU1m-D8W2fNElu15yUGAQbSGYpkGmVkPTKWhMaxYyceruQO87VE
SlIAWAvxfRepCz6ZHXjHK22RI71mfAqKwlpwDvzXLlyIEYMjJNV9JFv58w2YEZCM
AqhxmWBXHKlLQoD80UhJyw",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MDHMU-WNYUF-HSKHD-FOUFA-35CSW-EDM2W",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAKKUEEf6KyKHIS65Mhq9SCswDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJJNlUtNzNUN0YtU0tXRTMtSUE0UEstTkpUQUctNlFWWjUw
...
3ve0sMAJ3sUfPYA2VqJ5GRhgFFWLUmCxI3ClaGjBcQCwjZlDGkGE8PYpSw",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDHMU-WNYUF-HSKHD-FOUFA-35CSW-EDM2W",
            "n": "
j8TiAB7oPf2A8Q5DzAV5V8AA8TYZ7F5jfA4Qb6M6bpB4RB0cOFCPVTjIAv5kDJHD
dAnY50qEksStJQAVQprrSnQTgoqm3PKjfed5R5zfGvmCZ0MGkiDTkrlhqxHWa_Dh
WZnfVvxU1X-x2YD0qZKF_QnAJ4T0BlQOch-wJDURhjygXps_LhyxdlcE1hyCkcdt
ecCBOCC8l-dZhF57oXN8vaRN9Zc6WU64M1IYhEH9WawxCGzCom1o2QcIXlHIXwea
GN_IWY9Gmtdcr8-wF2THcuFjLEGJnAHCFnlCp7KNGLuvFklJPphZkIuw5GAcbeCz
8UniUfbbYRMh371RE2LoZQ",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJJNlUtNzNUN0YtU0tXRTMt
SUE0UEstTkpUQUctNlFWWjUifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJJNlUt
NzNUN0YtU0tXRTMtSUE0UEstTkpUQUctNlFWWjUiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
      "signature": "
kGKg0rqwhKfPTudQnnaaYrvCAnFLi8ZeBA4-gFearJwKLqNO5B4i-gsI5DEn8k9a
s1tNF8jHXHYWtir81QYNkCw-uAnVDWAhkgt6t4g-VV8KTxpm6BIyCxeg8zMXFOpT
mA8QSs5U1xjKKOLsP3c-11WMhHZD9xav9xam2IDdMy3w8DUsT9bifG3JxZ-pM9KU
lAVIRzCKffcZKKN2TnZSSLjnuPblQD7imRkE6O2kFgVFZRECmlwLdJXV0RAo90l9
Xz4qu1y0jRJDO1orFvlHKOyd3NqITZZhFq8PBQ26b8ThiNXt4SPLi5-_Lho27JL_
MBcA4KNlefob5ht6JTSwVQ"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MAQSY-D5MPY-UJP63-DRNEO-E25E7-IYAIY",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MAQSY-D5MPY-UJP63-DRNEO-E25E7-IYAIY",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAQSY-D5MPY-UJP63-DRNEO-E25E7-IYAIY",
          "n": "
jTWfiDHbVsx00JOaGqaTbRR8sih58oOP4nqFHt-j5fgzhmYxNlzxhMUFPnT-4ED_
ADuG2OOm-bihIS_TIqq3hD5Zg7egy3tfhHbPdQEVG2-ME-tpSx5eZvKhCdPdIVyH
ucfhXuaxt0AryjM4w1cTTD0L6cTuPk1pkFHNXrV9OM8dmt4rsK5RDE8IozF7WBpS
JxvSq-i5vQoMHQ3yJs6nTleTxoTCx5dZpU8Ckz3hgUfIz9KM638jTztSSR2KIMcV
pKDqQgEMI1v3lwCKWfOjWse8Y-CBWgYVmeOO2ffs0C4yAHFvztXToxKhhE0YUnwb
-vB9aNCZEx-bEJCLbDRpLQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MC7DJ-NKXJC-JJEHT-C6RXP-7CM6O-YWHSP",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC7DJ-NKXJC-JJEHT-C6RXP-7CM6O-YWHSP",
          "n": "
xdEtlYY60Cqzpa47dlVBknfI7hFJosQVWMyHzczFLAdcD7ahNH53vQBhEXNtEHfd
pQVjGVZWg95YdzuK2Bvz9bRnAISIH0JE5nYmFhAoqW_Atdi5q768BJMMvrqL4I_v
O6zINi0AafCZdxZid5LLv4l-rLJ7CtHia_JpuoloiIJIpMYNgUq7oBFkUJvX2sHL
PSWoj9V80JT5n_-gcsFr_DQDUMmQrsKPXgBxhmCye6l98hL6eCGb7Meaa1fO5F53
bv8frXqjCtJ66V0dYk_LBiT3CUHVj4dBpo4PA5k7tEhm7Nd2Rj1b3dhe1iCXr_Gw
eXB8TPEno295g0kvkWwzmw",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MCGLH-HTO5K-ODXPR-N23PJ-3WAKI-VGF62",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCGLH-HTO5K-ODXPR-N23PJ-3WAKI-VGF62",
          "n": "
1yFBvPdeVpToOnF0xKMlfVLi8cDE-Eb_dZHST61yZisq5CrsujPYz4JuDNo82bbU
0t7qp1WCpzU2er5ZEAtwxLgC4vmCrQrvye2NOyYig_ExYgMiYLQpGJzUJGLBH6kC
uV-flgbA5sN9XP8GLM20zy5mpsTrRS1pvV4HbI0Dexu9TcCHAQIhmlPl8ZKFPAms
iDf8fJIgRy6ohGjW4PnRRjaAxzBcQcAxhTuz0VwandJFrg6S-00YvCcXQpxWLSLx
iMUasMRag-5E9bSTLV4-hhDep1N8UVOlxA0UcgJ6flEPsey45s5ynnHB2YoB78wH
OKBGwCDpRWu3RbjudV262Q",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAQSY-D5MPY-UJP63-DRNEO-E25E7-IYAIY",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFRU1kt
RDVNUFktVUpQNjMtRFJORU8tRTI1RTctSVlBSVkiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
O6RDBQR5j-jTVpFz8_1ZQsVYDu8yjdrFrbMFT56-m4ITyTQwuE8TEaFO_4L-RyS-
3cXN7d89TUJi3f1B3M-Vlh1oVrhFnicsCZFic377ry6Jc5J-KEqbFXRfu02MlWhh
SuHF1_LZw8LLU1SFVr6oYxZQEgNj762lpQi8NRKRQ7j0RNy7YIm3z1ercGGPH338
YfvZKiH60XPVpbdzV6IRko0OjkQ_oivMGPG5csGbg8KysiRZeq1UBuL1wninN97F
SietwsCfWmHSc349bNo72t-9oS_b8oP81iTTm-Nm7lL5JnnjEMAdc0gnGCQRreI8
spAKj29LWLB26ikQE4btwQ"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
    "SignedMasterProfile": {
      "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJJNlUtNzNUN0YtU0tXRTMt
SUE0UEstTkpUQUctNlFWWjUifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJJNlUt
NzNUN0YtU0tXRTMtSUE0UEstTkpUQUctNlFWWjUiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
        "signature": "
kGKg0rqwhKfPTudQnnaaYrvCAnFLi8ZeBA4-gFearJwKLqNO5B4i-gsI5DEn8k9a
s1tNF8jHXHYWtir81QYNkCw-uAnVDWAhkgt6t4g-VV8KTxpm6BIyCxeg8zMXFOpT
mA8QSs5U1xjKKOLsP3c-11WMhHZD9xav9xam2IDdMy3w8DUsT9bifG3JxZ-pM9KU
lAVIRzCKffcZKKN2TnZSSLjnuPblQD7imRkE6O2kFgVFZRECmlwLdJXV0RAo90l9
Xz4qu1y0jRJDO1orFvlHKOyd3NqITZZhFq8PBQ26b8ThiNXt4SPLi5-_Lho27JL_
MBcA4KNlefob5ht6JTSwVQ"}},
    "Devices": [{
        "Identifier": "MAQSY-D5MPY-UJP63-DRNEO-E25E7-IYAIY",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFRU1kt
RDVNUFktVUpQNjMtRFJORU8tRTI1RTctSVlBSVkiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
O6RDBQR5j-jTVpFz8_1ZQsVYDu8yjdrFrbMFT56-m4ITyTQwuE8TEaFO_4L-RyS-
3cXN7d89TUJi3f1B3M-Vlh1oVrhFnicsCZFic377ry6Jc5J-KEqbFXRfu02MlWhh
SuHF1_LZw8LLU1SFVr6oYxZQEgNj762lpQi8NRKRQ7j0RNy7YIm3z1ercGGPH338
YfvZKiH60XPVpbdzV6IRko0OjkQ_oivMGPG5csGbg8KysiRZeq1UBuL1wninN97F
SietwsCfWmHSc349bNo72t-9oS_b8oP81iTTm-Nm7lL5JnnjEMAdc0gnGCQRreI8
spAKj29LWLB26ikQE4btwQ"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkk2
VS03M1Q3Ri1TS1dFMy1JQTRQSy1OSlRBRy02UVZaNSIsCiAgICAiU2lnbmVkTWFz
...
MjlMV0xCMjZpa1FFNGJ0d1EifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
      "signature": "
KOzgtJMUI0htJ6PmPCLEwMQBzVWfWl9bT_X2yzJRNaimosmaynai-gb7Fnlk7Ji4
Nl41n1n2oh-o-D_jYpW885arMOuS5M09FKsZ3xx8kXRSwFLpeEXHHJmhLtPh8I92
MCoA_WtCIjzkx6x_NyFAi0P-BpIAACBONUCgcMnJRZRoXJFnNUii5xvIxx8O7fRk
hWjHwtQxaM-3j4VvJWHnL7KsetXV7KSfFCxL6U8OI_1RToKRZQQguwsLrl4vZo4Q
0DiH60OO3pNOYyWvLuA9wY-73AYqcrw6brg5nhJs5klTtEuVzRACXK6Zs9wvdMaA
MlqKesgBtbpL4YCY_88SBQ"}}}
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
        "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkk2
VS03M1Q3Ri1TS1dFMy1JQTRQSy1OSlRBRy02UVZaNSIsCiAgICAiU2lnbmVkTWFz
...
MjlMV0xCMjZpa1FFNGJ0d1EifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
          "signature": "
KOzgtJMUI0htJ6PmPCLEwMQBzVWfWl9bT_X2yzJRNaimosmaynai-gb7Fnlk7Ji4
Nl41n1n2oh-o-D_jYpW885arMOuS5M09FKsZ3xx8kXRSwFLpeEXHHJmhLtPh8I92
MCoA_WtCIjzkx6x_NyFAi0P-BpIAACBONUCgcMnJRZRoXJFnNUii5xvIxx8O7fRk
hWjHwtQxaM-3j4VvJWHnL7KsetXV7KSfFCxL6U8OI_1RToKRZQQguwsLrl4vZo4Q
0DiH60OO3pNOYyWvLuA9wY-73AYqcrw6brg5nhJs5klTtEuVzRACXK6Zs9wvdMaA
MlqKesgBtbpL4YCY_88SBQ"}}}}}
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
    "Identifier": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
          "n": "
r5HwwVUhUWQsrZt_sdYXZIqEAr_CJpIUExrJqnmgoNLzM-7e743rBLuQULAPLMT1
TKZ2eEjKOga1VaKC7F8o_rNQr47kgaX4Nn7lO7cK4ESa4GFlLT8Luuhobf4EteYV
m-uKoo9RGyprpaf68-BMwWkunE4AVXOzJOCSvCAQ8DXlG9rZGqFsXVJjtMWn5qSi
bciyHwNnnrcCmeShwyFd6_aCdVrTdBL0ngXS3bLBjqlAxMvyTxtOCZeRI98lBARw
arH7Adi3ELOkCfrVJ0e95AQ_9bdSMUAptuzKo6L6JQIRHHsG8vahGzbA2yRGMHKU
csL_i004lpOShiV8-yi8lQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MBACU-OQNN7-ZQL6O-H64B7-EZC4H-MMRTC",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBACU-OQNN7-ZQL6O-H64B7-EZC4H-MMRTC",
          "n": "
xJaFjkNHAIg0jSO9xNCi1TGA89ROdtUDyWF_PnPApxIIFCBfXm9eCqS-ZemHF6wu
eoaJCDccMD7QLxGUTDRrxilJMAAgITyIJymGQW3OYGshlQOmPiHx9A-5ym6ps2Z4
Da4Sjm8YfXIfTdphD9dHV-R2qr9w_X-tXfhhTspt3FZhPMfJV97Q87NvmT80zsD4
MDmmVDx017kIWmfdA4eiJW-R3fpxbTBcpk7V5ip5qJp7iuclwcyakJxs1ya2VOnl
KIMc9Gx3r_McjsawsFS8gCr8NBOtZ-k4ezdKsl4XFyOd-d0Btpkm3r9OkdfOBSrI
nk0GpJTouol6x7YIxzv82w",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MACNG-WRES3-ZH3SR-NPJRK-RCHGV-AL6VH",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MACNG-WRES3-ZH3SR-NPJRK-RCHGV-AL6VH",
          "n": "
rI5aYqMEzakAIrcY9rqpPksi2tsLhxV0bOGejprSh2f37iJ6QrPG8JkrEb3tTRY2
HsVbGHuXvG2ec0S5KB9suoRvcrp2nFqGXvCoD68s3sBkkO2p3jTTF4d2sGU5ekdZ
B-bJmx6-HFA46QoHPVc3DuMHU8wfmu-T0vw3j3lVoKmIhD2c7ygf_JbryT3hJafk
LV0oTJpJGXQk6Rq48ff7XN-S8d4oklqhI3ToIkH6LL8sivDHQZxPUWZTORqx0Oob
_QnEnB14MEL7oNFroYTybOlLeaPvlvreCRNYCuduQxV5nXGeOGRPQx29NtIUAu-0
BQlodHWxUjmf-W9Podepiw",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQMjMtSFRKQTItNVdNR1Yt
WlZFT0ItWUNZUEUtNFBFVVAifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNQMjMt
SFRKQTItNVdNR1YtWlZFT0ItWUNZUEUtNFBFVVAiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
LEBe2Y1Z6ak0BQqJwff5fmHEXTnMD-xqy4FoOtdZZofKuGSqNXe32Q7y9QDZCl9R
rvly-D5rjSCEtjINeUrWw8JJlOrEWgqyYekiAyN8Anbu-o01oGiMxWe-vm8JGGZT
gcy5mzX1oAdztkxELBdMG2MiSJnJMmdFkRlmNZqbpliHog9hj9vpmwLeVdM1KHwf
iDMaXMGQ91j1gXXAMirnH8MFTUQPWkQGcTviLS3QzawHFgHX0GMXU4cEM4eOC3ZQ
uCOgh0Lko2xuOHl9M_JSYpD3j-27WG7QrFOJmdWFRO0VWCU_i5dAnsFXtozYRUDM
OdOEDCOm3IHTpNMtmZU09Q"}}}
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
          "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkk2
VS03M1Q3Ri1TS1dFMy1JQTRQSy1OSlRBRy02UVZaNSIsCiAgICAiU2lnbmVkTWFz
...
MjlMV0xCMjZpa1FFNGJ0d1EifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
            "signature": "
KOzgtJMUI0htJ6PmPCLEwMQBzVWfWl9bT_X2yzJRNaimosmaynai-gb7Fnlk7Ji4
Nl41n1n2oh-o-D_jYpW885arMOuS5M09FKsZ3xx8kXRSwFLpeEXHHJmhLtPh8I92
MCoA_WtCIjzkx6x_NyFAi0P-BpIAACBONUCgcMnJRZRoXJFnNUii5xvIxx8O7fRk
hWjHwtQxaM-3j4VvJWHnL7KsetXV7KSfFCxL6U8OI_1RToKRZQQguwsLrl4vZo4Q
0DiH60OO3pNOYyWvLuA9wY-73AYqcrw6brg5nhJs5klTtEuVzRACXK6Zs9wvdMaA
MlqKesgBtbpL4YCY_88SBQ"}}}]}}
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
      "Identifier": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQMjMtSFRKQTItNVdNR1Yt
WlZFT0ItWUNZUEUtNFBFVVAifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUNQMjMt
...
OVEifX19fQ",
        "signature": "
WUXz0cZ9Hs2gfRZHWrphzNop5EhoAzh4L1g4gV_6zFArKRi_0yXTwBNPZ_86szCq
6EGzOErmmAPmPExTye2dPWuoz2R2zoBgpX0g2S_D0UQCLVfodXAELlbeQGxyWncx
XOUbpSi1kVAgm6jEdvRN26IkB2f7Edpyd8WTekMYSRlpB1lnVqMXjP3rQyn-JWhc
HYN-9Xk9lj5DI6xm-Klp9-u377NiGR4vIL1aTtg4O40I3744CyqJNu5V--wY-FI0
ZwXW-kya7Twf4Za41bux2gfc9EyUomhwglCoAIhBiO41EVDWIZeF8lOQKyL14JX3
LuIhu18Os4o4LONNNO9RtA"}},
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
        "Identifier": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQMjMtSFRKQTItNVdNR1Yt
WlZFT0ItWUNZUEUtNFBFVVAifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUNQMjMt
...
OVEifX19fQ",
          "signature": "
WUXz0cZ9Hs2gfRZHWrphzNop5EhoAzh4L1g4gV_6zFArKRi_0yXTwBNPZ_86szCq
6EGzOErmmAPmPExTye2dPWuoz2R2zoBgpX0g2S_D0UQCLVfodXAELlbeQGxyWncx
XOUbpSi1kVAgm6jEdvRN26IkB2f7Edpyd8WTekMYSRlpB1lnVqMXjP3rQyn-JWhc
HYN-9Xk9lj5DI6xm-Klp9-u377NiGR4vIL1aTtg4O40I3744CyqJNu5V--wY-FI0
ZwXW-kya7Twf4Za41bux2gfc9EyUomhwglCoAIhBiO41EVDWIZeF8lOQKyL14JX3
LuIhu18Os4o4LONNNO9RtA"}}]}}
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
        "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkk2
VS03M1Q3Ri1TS1dFMy1JQTRQSy1OSlRBRy02UVZaNSIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
AQDz4ee21xoH2eEILYiVVyJFg_4pW72OFDTKTW0cOIxz4lG0z8Spdeks3FVUFYDw
B3MlBywQ0YP12i7-r7fIHzd-GtLc3_X3Y15j_0Sp91aM-aFeLS55VvyHkrChdnyw
v_Uogdkd7rJTYh3rNbRhftcFFB7cZvYGSK9h7TNlQrFhZKDwcR-Z-kTF_Gv6vSRl
wQCIjc5G-YrsFUa3mM3D_2qO4FBSaDQLaAW0lTmIaVo5aM9ps5YiDvIf-xz53ZGK
r-AFY2wWweVW-KaOd-K-90RV_QxH2Adq3bX0663hRyojlEeITnL1nZq3_DMl-F37
Gl93gkEjS0GEucTWIl7fcA"}}}}}
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
      "Identifier": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNQMjMtSFRKQTItNVdNR1YtWlZFT0ItWUNZUEUtNFBF
...
dGVkIn19",
        "signature": "
aT9x9Dqot0Lhis1TcG603veyUmOTnzFx0DkX0GEnBsDe1JvGzidQ-MbKyMJRO2li
lzGS-N9sT6xnoP-4Qkt8rc8ogj-e6DV8hG_79SpJ4YNMvjAvzTTjN_ZJ9CtkcypH
mGRRE4gK2eziOaHHbimhkkqdr0U54eCFSmpoMbJY8eBVhVXvdoSGlJEKqgtYuIlW
lh6kuC5bsoxG5_l7vtLoGIx6j9hU6W0swUXmnxZ5j2W5DlNtUDi810lBYxrvg2SZ
ehzdpJNlMT8gRvb020Vf7WRGKlHJ9GO0Gys1JBNq3w0u3UDGCbYZ7uJoJmf0y7-k
mLQ-WbXFOVr1VE1UT3PefQ"}},
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
    "DeviceID": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MCP23-HTJA2-5WMGV-ZVEOB-YCYPE-4PEUP",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNQMjMtSFRKQTItNVdNR1YtWlZFT0ItWUNZUEUtNFBF
...
dGVkIn19",
        "signature": "
aT9x9Dqot0Lhis1TcG603veyUmOTnzFx0DkX0GEnBsDe1JvGzidQ-MbKyMJRO2li
lzGS-N9sT6xnoP-4Qkt8rc8ogj-e6DV8hG_79SpJ4YNMvjAvzTTjN_ZJ9CtkcypH
mGRRE4gK2eziOaHHbimhkkqdr0U54eCFSmpoMbJY8eBVhVXvdoSGlJEKqgtYuIlW
lh6kuC5bsoxG5_l7vtLoGIx6j9hU6W0swUXmnxZ5j2W5DlNtUDi810lBYxrvg2SZ
ehzdpJNlMT8gRvb020Vf7WRGKlHJ9GO0Gys1JBNq3w0u3UDGCbYZ7uJoJmf0y7-k
mLQ-WbXFOVr1VE1UT3PefQ"}}}}
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
    "Identifier": "MBTGL-L4CXT-CFNDW-RQUJR-AMGHA-64OJ4-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
OmS5XE05QZcXvcAxoO9yig",
      "ciphertext": "
Cmypz74JJGVNS0mkgWuydaQzM6hnqVjIm_yhVE_CVRGmJSjh07CMdlr_9fUp8YDY",
      "recipients": [{
          "Header": {
            "kid": "MCGLH-HTO5K-ODXPR-N23PJ-3WAKI-VGF62"},
          "encrypted_key": "
sElIMvjqHFuufdO3jelfxmAnh7vslLnrR2x8Hm9MB0p7bxsn1r_CLuY3DQMyaaex
U8dmtyHTtRo-kOhzBIbuY3XV4Y0HxQtp1p3Izwogm86NcsksWZSQ6-hRAI2vW9Nw
NT05fzGYqF5EesppWNGhj41aYHjoyzI2DOVF9EaO1suF446eagoA_fg9PDX8CSN-
AGnwbCgenWTeL6N0AD52yMq_L09_CvONXaIabsNOAYAy2CTaTisS3nYgtpnXEyAQ
3oM9fjRv1wAeKPHbcuF2FadCFAoVbnTKTmF_BrGd5sZ7irXUQBsn07SJ9IQnlVF0
1l-KxjrKQcIRU3EeKf4VUw"},
        {
          "Header": {
            "kid": "MACNG-WRES3-ZH3SR-NPJRK-RCHGV-AL6VH"},
          "encrypted_key": "
OanUlFSC6SwX5DZ9_8SOfkWEPPLPlun-N8WtgVWcIYyWNacqn_wffBaqiwtZyfDc
FlVXpSIfVrMb94N_tsWCMssOd0JMFHDtLJdALoOlp2p1aGbI6dOsrHXO5vgTjtC4
TNR-Oq3aeK-G18gogPi7Yax_TRatzDF-OQyPZcWokG3gzIrrhhUSg6MZaCPnzhSV
6rGJG3dB_rSUKQ31AyMjjaId52VPScuDFHZFYJM1805HMYCsvqTSnX4flnCVuD_i
Y3tRa5qydAuZlnMZPETpH-mtK-uqd1_wmzddeV-PHiywWyDordgEQHgd_IVcMruN
uUgOTJJnFU1zWEXiEzKb-Q"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MBTGL-L4CXT-CFNDW-RQUJR-AMGHA-64OJ4-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlRH
TC1MNENYVC1DRk5EVy1SUVVKUi1BTUdIQS02NE9KNC1BIiwKICAgICJFbmNyeXB0
...
RVFIZ2RfSVZjTXJ1Tgp1VWdPVEpKbkZVMXpXRVhpRXpLYi1RIn1dfX19",
          "signature": "
HewRousnUlfsqFRG_Ih_bHXuNmJMT7O76Mbg0D9xBvzbAhWIi4yilhHDf7HBIYuj
oSj8dvhghm0KMIihqkEidscwzWyTdftXuAoPKiO7OttxW23h_8fLtzuZMdCLyp8k
bqMeg7X2FzoTN2Oc_B13DYYKJpI18dBRba4g6oW6Yq71pPErdb4iw4p7D8fTUhy4
ojBRqiY8AWN0zofZgQshqrSYYAglPK2np0v_k7Li5OZJcJQ7a9uVSQ_XEm0xy55H
iSCH8cPq9M5XYoKlsFSzukyb8CDFMLBenYRA9xbHAMHSUD_IS6YYH39tTfxfLpwI
LWrBJn4gwcLnYHC5CVScuw"}}}}}
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
        "Identifier": "MBI6U-73T7F-SKWE3-IA4PK-NJTAG-6QVZ5",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFRU1ktRDVNUFktVUpQNjMt
RFJORU8tRTI1RTctSVlBSVkifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkk2
VS03M1Q3Ri1TS1dFMy1JQTRQSy1OSlRBRy02UVZaNSIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
AQDz4ee21xoH2eEILYiVVyJFg_4pW72OFDTKTW0cOIxz4lG0z8Spdeks3FVUFYDw
B3MlBywQ0YP12i7-r7fIHzd-GtLc3_X3Y15j_0Sp91aM-aFeLS55VvyHkrChdnyw
v_Uogdkd7rJTYh3rNbRhftcFFB7cZvYGSK9h7TNlQrFhZKDwcR-Z-kTF_Gv6vSRl
wQCIjc5G-YrsFUa3mM3D_2qO4FBSaDQLaAW0lTmIaVo5aM9ps5YiDvIf-xz53ZGK
r-AFY2wWweVW-KaOd-K-90RV_QxH2Adq3bX0663hRyojlEeITnL1nZq3_DMl-F37
Gl93gkEjS0GEucTWIl7fcA"}}}}}
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
        "Identifier": "MBVGJ-PLWY7-NPWH2-5OL57-BJOJY-HHD3H",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
Gjk7g6OF3-qxApa2IPJ27A",
          "ciphertext": "
xZGPgOnxXzZQTr37pruwi-87m4TeUSQW12G8Fv7BshVRrHwsjTfyUzkJqbLS58xp
deF0LxJVx64yTZpp2iAmbAhtTiJo7-p2eNpph4KZy3cjJxVcsEIAniBN4ZYrYZkU
...
dWfKXTG6tnQs-X6AIpBLgoXssQo-C07PdUCWNeNMsTXJgxjZN8U3ITiIaPK3eVdG"}}}}}
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
    "Identifier": "MBVGJ-PLWY7-NPWH2-5OL57-BJOJY-HHD3H",
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
          "Identifier": "MBVGJ-PLWY7-NPWH2-5OL57-BJOJY-HHD3H",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
Gjk7g6OF3-qxApa2IPJ27A",
            "ciphertext": "
xZGPgOnxXzZQTr37pruwi-87m4TeUSQW12G8Fv7BshVRrHwsjTfyUzkJqbLS58xp
deF0LxJVx64yTZpp2iAmbAhtTiJo7-p2eNpph4KZy3cjJxVcsEIAniBN4ZYrYZkU
...
dWfKXTG6tnQs-X6AIpBLgoXssQo-C07PdUCWNeNMsTXJgxjZN8U3ITiIaPK3eVdG"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


