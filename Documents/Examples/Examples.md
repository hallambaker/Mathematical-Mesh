
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
Content-Length: 90

{
  "ValidateRequest": {
    "Account": "test@prismproof.org",
    "Language": ["en-uk"]}}
~~~~


The ValidateResponse message returns the result of the validation
request in the Valid field. Note that even if the value true is returned,
a subsequent account creation request MAY still fail.


~~~~
HTTP/1.1 200 OK
Date: Fri 10 Nov 2017 08:25:12
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
    "Identifier": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
    "MasterSignatureKey": {
      "UDF": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
      "X509Certificate": "
MIIFXDCCBESgAwIBAgIQHxTK-cxo09CNPPaVXDZa1zANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQlo2Vy1WTUhEMy1TNTNEWC01M09RWS1ZNFIzVy03NVZDWjAe
...
YiOaVVYnu2-RDKp6VAyzH_7U0pi9kH4j3wYzD4EsqcI"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
          "n": "
z4Zdo_S9zrbB6_93c1UoPqtPfbYFAhx07rxIyJhHjJW50982gBAw9KiWJlCWj_il
q7OzyQfjvnskDmv4fnyOwn-O1qO4Y39BtzlK2TlQQXkWPqE7PClOg39DdNdzXXDZ
e9GnrQ7j_m1NGeu69aKs5ryfb2lUcseOZo0YX9dCzNekGsb80p_a4FkUND4ls0xo
t7yF-kXHM2_2zLyzMzigviPQwrm8yPe4086mGdqsgcfQGwUeaE7JRAA5RsigK9NQ
S_Yr449MMJJGUUrQIe3tpcWxpyRceSz9b0UNbETiSlsTB_jD2v3LTMq0BCBjkssX
gJpux5zLYA25_uHHREdK4Q"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MDK5J-JAP7J-BWPEP-W7D6P-P6Z4Q-M6KGP",
        "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRALlRcbEMn59NtZs1HHQOiQ0wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJaNlctVk1IRDMtUzUzRFgtNTNPUVktWTRSM1ctNzVWQ1ow
...
20mRRwo5CmEWRoEZhPtOi6ZvfoOsUmZvQ2ma3si_HHqO"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDK5J-JAP7J-BWPEP-W7D6P-P6Z4Q-M6KGP",
            "n": "
sWszXODbH7pHd-oVxzGF3mL3AsvAeAZ94HarfAhIJRKOrjOx-_EQC2FC7zcJhXX1
dAwhQnuMdbdHw18vp_BIh70Y2-sBtVqpLcWJJ9_0EM8LzE8-XDk5uxcN40gU2ih3
a_u-JDW0iIF1rSXPQ923onBAOkBXz8BkmY_rskhDnyNoPM0mlCJ1EUh1Ljb92EkY
VILgxEFi2X3vdvlDHKNSt9OG976Tk1Kj65mcaxGty16p7ZuRYYQAxBTGEJBNG1_g
2k_OruBunoOgNkpXrOdGQ1JB_4PXFAcHcIlNuTzHY2-Q1ggoSOCoSeNsiQQN2594
4cIJ5mx99doQLxVKCuRFiQ"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MABWP-OI6SL-MORUJ-2G2QE-RAD24-Y5TAA",
        "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAPXttNDGD1mZN90ov4zGKsIwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJaNlctVk1IRDMtUzUzRFgtNTNPUVktWTRSM1ctNzVWQ1ow
...
NEc9VHgw5SajaCsBL-2Y9k_e9mYJNkvI-D7CwWkqSctt"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MABWP-OI6SL-MORUJ-2G2QE-RAD24-Y5TAA",
            "n": "
xIR_-jJuOkq1-p2pM0G6dzGLgmMM-5Kg0JJAIlr_hfJiomlcPPT3riCPeTWdB9UJ
vmHObQf59QdVJ6MnHrOgGyNoj_YM-UNljpDBPQT_U5_aj9qNscaEbB4Tn_s0WxvQ
GT2c1v80wDGOmbOJan4xtboaDct-VVuHkKVjpR2sXyitq5A83y8jErP8tBw2LbJs
qPW11ohlKHS46C6mbO58yezERza0H8OqgBdx-MStuH_7FimHkH-LdJxreSqCmkAJ
ycJPFoWFW_F9Xg8aJCy0H7toazFhOXplurnrF5sEyoXRYFl698n6Z-cSLOyRfmAj
I7Iy6RBoy5etdDKHgkyL1Q"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJaNlct
Vk1IRDMtUzUzRFgtNTNPUVktWTRSM1ctNzVWQ1oiLAogICAgIk1hc3RlclNpZ25h
...
QiJ9fX1dfX0"
,
      "signatures": [{
          "header": {
            "kid": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmEzM2ZrbnZFSFJVM0c5a3VO
TGVYdy1NUEtzdkFBaXMybzNqSWdxOXRGNFZsd1ZHVWU3dmFkT1hScTJ6dnE1N0EK
T2VERlVRdkhpZjJaQzFmS2hFSlExQSJ9"
,
          "signature": "
Ir9wICiMmmUL8G4DMcvfguY2i1H_9W7UnyHSATMzLKIbtA3omjPYZ-SvHnj7EWgj
uBjiqs6DLcM31nY6FfhDFrRVec6eUZ4bRpgb7ghzF9OydgsdZ_LPlZzutfsebrb-
4k2MBz-QBvxU4WxpFI7ie650dc9wMHl62-cY3pTd3gphAY3KS_ecQZtjTrYZbQ6X
7MkC3GpQXp_rWx66ylxX8ge5z6zfx6SZJCMTM2a0vx5AwsPeIAkh-toyU7WD1Fvx
cbEvZf9AuZ18SC3-u8EqJ1hQIxHE_pH3qLZHgl-NMfOwsll111jy5Y-g3IpCgKek
cgGcKFGvffSQ60TygpJ92g"
}]}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "JoseWebSignature": {
    "unprotected": {
      "dig": "S512"},
    "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJVSTYt
R0pMNFUtUzZXS0ctUTRWWFYtV1BSVU8tNVc2N0MiLAogICAgIk5hbWVzIjogWyJE
...
NjRtazFRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
    "signatures": [{
        "header": {
          "kid": "MBUI6-GJL4U-S6WKG-Q4VXV-WPRUO-5W67C"},
        "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClpRUFpzOHhzaTZzVzYzM0FY
OEo5ZHZYQUpYeXRCTjlGMURCYllRdXozb3dSQmU4YlJfVXFFVHRNTGRqVmpsRG4K
aExfMGtBUzN2bDhfVnc3cEJOQ2hqdyJ9"
,
        "signature": "
FGR6a3xxW2b-CuGKsS9dkCox9RiDXy9w4lBv9RodBID2xTOwo8Bh3-5C0RGo6SBt
Q5lKClkSLStp5RukvK4gIRUjlCc71uubNn0QfQfYlHLhjKc2s_tHAHcZ6VZ3hjhr
1by5bSJgcDXO6xGvmAuveY6sk3T36V6i1fjrtlQsYSqDsSySZzpMEUFbKvB9aWFs
JxYMnk0KFzsqBQ8M4dEXb-R38ER-thLiSK27ZPVWLBihDrIqAjcFUROPwRki-Pme
FHiaxqU-qKAAod0w7iJn_2bfO064CGZpoEGFhCaOBDzySsNtr_70A38ulkJcXUGw
WybT1FCmflTZ_dMMLGvF_A"
}]}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBUI6-GJL4U-S6WKG-Q4VXV-WPRUO-5W67C",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJVSTYt
R0pMNFUtUzZXS0ctUTRWWFYtV1BSVU8tNVc2N0MiLAogICAgIk5hbWVzIjogWyJE
...
NjRtazFRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MBUI6-GJL4U-S6WKG-Q4VXV-WPRUO-5W67C"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClpRUFpzOHhzaTZzVzYzM0FY
OEo5ZHZYQUpYeXRCTjlGMURCYllRdXozb3dSQmU4YlJfVXFFVHRNTGRqVmpsRG4K
aExfMGtBUzN2bDhfVnc3cEJOQ2hqdyJ9"
,
          "signature": "
FGR6a3xxW2b-CuGKsS9dkCox9RiDXy9w4lBv9RodBID2xTOwo8Bh3-5C0RGo6SBt
Q5lKClkSLStp5RukvK4gIRUjlCc71uubNn0QfQfYlHLhjKc2s_tHAHcZ6VZ3hjhr
1by5bSJgcDXO6xGvmAuveY6sk3T36V6i1fjrtlQsYSqDsSySZzpMEUFbKvB9aWFs
JxYMnk0KFzsqBQ8M4dEXb-R38ER-thLiSK27ZPVWLBihDrIqAjcFUROPwRki-Pme
FHiaxqU-qKAAod0w7iJn_2bfO064CGZpoEGFhCaOBDzySsNtr_70A38ulkJcXUGw
WybT1FCmflTZ_dMMLGvF_A"
}]}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
    "SignedMasterProfile": {
      "Identifier": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJaNlct
Vk1IRDMtUzUzRFgtNTNPUVktWTRSM1ctNzVWQ1oiLAogICAgIk1hc3RlclNpZ25h
...
QiJ9fX1dfX0"
,
        "signatures": [{
            "header": {
              "kid": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmEzM2ZrbnZFSFJVM0c5a3VO
TGVYdy1NUEtzdkFBaXMybzNqSWdxOXRGNFZsd1ZHVWU3dmFkT1hScTJ6dnE1N0EK
T2VERlVRdkhpZjJaQzFmS2hFSlExQSJ9"
,
            "signature": "
Ir9wICiMmmUL8G4DMcvfguY2i1H_9W7UnyHSATMzLKIbtA3omjPYZ-SvHnj7EWgj
uBjiqs6DLcM31nY6FfhDFrRVec6eUZ4bRpgb7ghzF9OydgsdZ_LPlZzutfsebrb-
4k2MBz-QBvxU4WxpFI7ie650dc9wMHl62-cY3pTd3gphAY3KS_ecQZtjTrYZbQ6X
7MkC3GpQXp_rWx66ylxX8ge5z6zfx6SZJCMTM2a0vx5AwsPeIAkh-toyU7WD1Fvx
cbEvZf9AuZ18SC3-u8EqJ1hQIxHE_pH3qLZHgl-NMfOwsll111jy5Y-g3IpCgKek
cgGcKFGvffSQ60TygpJ92g"
}]}},
    "Devices": [{
        "Identifier": "MBUI6-GJL4U-S6WKG-Q4VXV-WPRUO-5W67C",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJVSTYt
R0pMNFUtUzZXS0ctUTRWWFYtV1BSVU8tNVc2N0MiLAogICAgIk5hbWVzIjogWyJE
...
NjRtazFRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
          "signatures": [{
              "header": {
                "kid": "MBUI6-GJL4U-S6WKG-Q4VXV-WPRUO-5W67C"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClpRUFpzOHhzaTZzVzYzM0FY
OEo5ZHZYQUpYeXRCTjlGMURCYllRdXozb3dSQmU4YlJfVXFFVHRNTGRqVmpsRG4K
aExfMGtBUzN2bDhfVnc3cEJOQ2hqdyJ9"
,
              "signature": "
FGR6a3xxW2b-CuGKsS9dkCox9RiDXy9w4lBv9RodBID2xTOwo8Bh3-5C0RGo6SBt
Q5lKClkSLStp5RukvK4gIRUjlCc71uubNn0QfQfYlHLhjKc2s_tHAHcZ6VZ3hjhr
1by5bSJgcDXO6xGvmAuveY6sk3T36V6i1fjrtlQsYSqDsSySZzpMEUFbKvB9aWFs
JxYMnk0KFzsqBQ8M4dEXb-R38ER-thLiSK27ZPVWLBihDrIqAjcFUROPwRki-Pme
FHiaxqU-qKAAod0w7iJn_2bfO064CGZpoEGFhCaOBDzySsNtr_70A38ulkJcXUGw
WybT1FCmflTZ_dMMLGvF_A"
}]}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlo2
Vy1WTUhEMy1TNTNEWC01M09RWS1ZNFIzVy03NVZDWiIsCiAgICAiU2lnbmVkTWFz
...
aW9ucyI6IFtdfX0"
,
      "signatures": [{
          "header": {
            "kid": "MABWP-OI6SL-MORUJ-2G2QE-RAD24-Y5TAA"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjFYa09EdjlqelhyR0xPR2s3
cFdfTWRyUUJKTWZUZ3pHVTN1SkNHYlVjcjJJLTR5eEdkMFF3NkZxc0s4Y0piUlcK
bFQ0QmZSckkwRGs3UmM0SjRzVGl3QSJ9"
,
          "signature": "
Rtx_anCI61VMbTNDgpzKZ4FvViQG6D5lDmum1eQNjNiGlNO9jkzs8lKING4CJWem
bcQaXkpmhMnQ-EjzzJWX0By945XGcqa1pKzVWw0K0g6t99LuWRTrL3cfFohBA9N-
xx3-aM8PI9PCxVKqpZbQL0Tm_g068CE9E4IhKzICt_L1NaWBg3dmSYFT1EkQHb1y
BtIWMx4QG3YgYn0ouQkfjyoCeicqt1G_NcjkgbflhVsQbVygK05u4GwentdIUjtX
Xr_37E1GtRyFOHPJaa32YzAXy1-cNdvx4J327TiXo40Li7lbXCm-gsoBPyEBGDnB
iWjimzJBm6B9Raq9S7ZdDA"
}]}}}
~~~~

###Publishing a new user profile

Once the signed personal profile is created, the client can finaly
make the request for the service to create the account. The request object 
contains the requested account identifier and profile:


~~~~
{
  "CreateRequest": {
    "Account": "test@prismproof.org",
    "Profile": {
      "SignedPersonalProfile": {
        "Identifier": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlo2
Vy1WTUhEMy1TNTNEWC01M09RWS1ZNFIzVy03NVZDWiIsCiAgICAiU2lnbmVkTWFz
...
aW9ucyI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MABWP-OI6SL-MORUJ-2G2QE-RAD24-Y5TAA"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjFYa09EdjlqelhyR0xPR2s3
cFdfTWRyUUJKTWZUZ3pHVTN1SkNHYlVjcjJJLTR5eEdkMFF3NkZxc0s4Y0piUlcK
bFQ0QmZSckkwRGs3UmM0SjRzVGl3QSJ9"
,
              "signature": "
Rtx_anCI61VMbTNDgpzKZ4FvViQG6D5lDmum1eQNjNiGlNO9jkzs8lKING4CJWem
bcQaXkpmhMnQ-EjzzJWX0By945XGcqa1pKzVWw0K0g6t99LuWRTrL3cfFohBA9N-
xx3-aM8PI9PCxVKqpZbQL0Tm_g068CE9E4IhKzICt_L1NaWBg3dmSYFT1EkQHb1y
BtIWMx4QG3YgYn0ouQkfjyoCeicqt1G_NcjkgbflhVsQbVygK05u4GwentdIUjtX
Xr_37E1GtRyFOHPJaa32YzAXy1-cNdvx4J327TiXo40Li7lbXCm-gsoBPyEBGDnB
iWjimzJBm6B9Raq9S7ZdDA"
}]}}}}}
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
    "Identifier": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
    "Names": ["Default"],
    "Description": "Unknown",
    "DeviceSignatureKey": {
      "UDF": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
          "n": "
x-o-9RMSsmMrgfHURNW6iGirvk6J9GfalyOlF6zVrMV1FKGreesN3VwY3sVs-8JO
BKRwl4NjFxG3_DgVDV-Ai6allZqy9cXCyetlVGJ9YWzOEwQLkvKcZh0fszEjpM4M
7YwW12L3dgeZ07uxrpqha2gp9BMrRimcfRJWIyu6Gg2eiO1Lc42OyKyPYjSyUK-H
uuu5UpV1LVlw_FXcCNA7vZeyIt-syT6W5adAyQKPt1kc-y3oLqNQR60aCssbVrYc
KrEioNoKsFwWR_ewPs3ywz6n9iKA2PdfT9kUVAW4zhl_P8zYq3ch6tPRH4H9arWH
n9a-cfr-U-OszX0rc3TIbQ"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCXIS-ONAGY-QRR5Z-IWALF-6THOE-BSP52",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCXIS-ONAGY-QRR5Z-IWALF-6THOE-BSP52",
          "n": "
yOJf7g7Z_CifP5rsiUVJpivvQsYLaaIF8Un8s-8AyZDLFueAVnPlR5mcWrOg9hYB
JByOBeOpev80bDGg5UCG4wbfHD8Y8__C21d8I4bckIOl-muJLMqK5nSyTvJDbjPI
MDDjwLIdp6PEqWKmu2kyxzC1DJFA2cAN1LRJtrI2wObbGVNjvhJ2CQQYIzD7CosZ
WnKRh9EdBds95Vx7XIG1x0PeXEcMVADJ7nmbYM4PzDqNNRg26CVst0eN33NQjZVQ
cN6AD0t5e9in3COsd0x63Nl11xZB1_6kzzA9o2S6Cbbdy9psvuIW8wvVMwuuV_Y3
9BnKOFuPSImbgtzYSvbncQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MBGBZ-QIPCC-ZCSJL-JKB3A-MNG7Z-DUW42",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBGBZ-QIPCC-ZCSJL-JKB3A-MNG7Z-DUW42",
          "n": "
v27jaTaPlDhJHJeKdtp9r1lWKPAIFcbMsoq-YLAPg1zrDWqcTan9rnGJjWkyLZVI
Ne_U70rDen0e07Obg2g5SpHuC-zexFUHlMeXRkFCY0PqXBM1zLYtnLP4Jrpo9L_G
BCXdhJ6mRBCQhL8CftH2eL9wZ5KH0ux_XvGgtDuBzR-JuVYVeYSrIVG_OFbqnTNx
HKiRW8WqMCeAL1WFdcytI_oXFLuF1-4Pxwwygg1uWH8olcvXL3cn3rvaE11f1_lR
fwrXozQSpeHJ2qsVnQYzGu5KWoOM9e5mA0FLPke0tCJ0lu0jip4_PAemGwVR0E_W
6bBMcXxhTkOHaeAXEYHbaQ"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJTVEUt
UEFHVkgtM1JVVUctWk9aREMtVFpSUlctRVVZSVAiLAogICAgIk5hbWVzIjogWyJE
...
ICAgICAgICAgImUiOiAiCkFRQUIifX19fX0"
,
      "signatures": [{
          "header": {
            "kid": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCkdsVGo5TzA0Uk9iMktKemFl
R3NfeERCTElRNGRBLXdISi1YZW8tMkdoZ2pDZVRFajJZOVQ3Qm95VjBSMjZyYmQK
QU9mbnhjRHRkYkFnUUluRlJFWHY4QSJ9"
,
          "signature": "
edsCJwDh-V4aoxsTtq0jGJsZFijL2cCACkQSIeI-g7YYoi91NP4LOB5QHeeljDSb
TmYwP_21v_1H48buGkd3kZt7q-05wW7oHStiQos5uWxJypvX57mi23iRmhlSKwIN
FJgma5euIW9lmaIRJX665_fqm9h8Qakb7KGiR7CCPKWASiVOZovEiCHoLkcC0z5I
l7ByoKAJWl9rT_jXIRNiCPSj8CI8cfoetEkD3fWJKq6yMvWmXkBIVyksPY1airnE
HtuIA8vq6g5qSmLed0lGZKPiIBfbghjsLvFqhI721XJhNOil_kEDnSDraDSJugVX
NFVOtrOxXZlrEPQPM42ong"
}]}}}
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
    "Account": "test@prismproof.org",
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
          "Identifier": "MBZ6W-VMHD3-S53DX-53OQY-Y4R3W-75VCZ",
          "SignedData": {
            "unprotected": {
              "dig": "S512"},
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlo2
Vy1WTUhEMy1TNTNEWC01M09RWS1ZNFIzVy03NVZDWiIsCiAgICAiU2lnbmVkTWFz
...
aW9ucyI6IFtdfX0"
,
            "signatures": [{
                "header": {
                  "kid": "MABWP-OI6SL-MORUJ-2G2QE-RAD24-Y5TAA"},
                "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjFYa09EdjlqelhyR0xPR2s3
cFdfTWRyUUJKTWZUZ3pHVTN1SkNHYlVjcjJJLTR5eEdkMFF3NkZxc0s4Y0piUlcK
bFQ0QmZSckkwRGs3UmM0SjRzVGl3QSJ9"
,
                "signature": "
Rtx_anCI61VMbTNDgpzKZ4FvViQG6D5lDmum1eQNjNiGlNO9jkzs8lKING4CJWem
bcQaXkpmhMnQ-EjzzJWX0By945XGcqa1pKzVWw0K0g6t99LuWRTrL3cfFohBA9N-
xx3-aM8PI9PCxVKqpZbQL0Tm_g068CE9E4IhKzICt_L1NaWBg3dmSYFT1EkQHb1y
BtIWMx4QG3YgYn0ouQkfjyoCeicqt1G_NcjkgbflhVsQbVygK05u4GwentdIUjtX
Xr_37E1GtRyFOHPJaa32YzAXy1-cNdvx4J327TiXo40Li7lbXCm-gsoBPyEBGDnB
iWjimzJBm6B9Raq9S7ZdDA"
}]}}}]}}
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
      "Identifier": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUJa
NlctVk1IRDMtUzUzRFgtNTNPUVktWTRSM1ctNzVWQ1oiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
        "signatures": [{
            "header": {
              "kid": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmI2MTVFa3hrcGJ4amRjV3FU
VnhFYU84eGRqR0hDYTJWMTV2alRKSDZBb05YVEl4VFdyY3NvcExHYVdqUUp6MWwK
b1FDaWFkRG1wcjBqelY5OVNDOUpFUSJ9"
,
            "signature": "
cEExnK2TD6MKGDSZsEqfidREEkahaWGCrVUbTcHk73Z2fpqiQldvz5DBuWni8BqJ
h3xsdXjoT7sZ7bl4BUILulczLmDXDoHsiW_4DqaCxfWi6i8qhvuyJFzrGojdhl_p
pIgucjqwfj-DhnBQp0-pYju-B7mjwIu4TQn7iM03VdO6apRbCHrEq9EwhN7ES8Yd
NTiRjATFyv-0S4zgnrk4lZX3YZRRiT19iBjJ6ZHdiWeJbXlIBTLKi4YQiazgV3Y-
EFyDnXVovGvlwcZF5P-3ejD12qOZ8rEVnCbMc98i2Svo2pozvReKlAlxN-XfWygv
Afu8bvVvVC-7LpYFUpGyTg"
}]}},
    "AccountID": "test@prismproof.org"}}
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
    "AccountID": "test@prismproof.org"}}
~~~~


The service responds with a list of pending requests:


~~~~
{
  "ConnectPendingResponse": {
    "Pending": [{
        "Identifier": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUJa
NlctVk1IRDMtUzUzRFgtNTNPUVktWTRSM1ctNzVWQ1oiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmI2MTVFa3hrcGJ4amRjV3FU
VnhFYU84eGRqR0hDYTJWMTV2alRKSDZBb05YVEl4VFdyY3NvcExHYVdqUUp6MWwK
b1FDaWFkRG1wcjBqelY5OVNDOUpFUSJ9"
,
              "signature": "
cEExnK2TD6MKGDSZsEqfidREEkahaWGCrVUbTcHk73Z2fpqiQldvz5DBuWni8BqJ
h3xsdXjoT7sZ7bl4BUILulczLmDXDoHsiW_4DqaCxfWi6i8qhvuyJFzrGojdhl_p
pIgucjqwfj-DhnBQp0-pYju-B7mjwIu4TQn7iM03VdO6apRbCHrEq9EwhN7ES8Yd
NTiRjATFyv-0S4zgnrk4lZX3YZRRiT19iBjJ6ZHdiWeJbXlIBTLKi4YQiazgV3Y-
EFyDnXVovGvlwcZF5P-3ejD12qOZ8rEVnCbMc98i2Svo2pozvReKlAlxN-XfWygv
Afu8bvVvVC-7LpYFUpGyTg"
}]}}]}}
~~~~


###Administrator updates and publishes the personal profile.

The device profile is added to the Personal profile which is
then signed by the online signing key. The administration
client publishes the updated profile to the Mesh through the
portal:


~~~~
{
  "ConnectPendingRequest": {
    "AccountID": "test@prismproof.org"}}
~~~~


As usual, the service returns the response code:


~~~~
{
  "ConnectPendingResponse": {
    "Pending": [{
        "Identifier": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUJa
NlctVk1IRDMtUzUzRFgtNTNPUVktWTRSM1ctNzVWQ1oiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmI2MTVFa3hrcGJ4amRjV3FU
VnhFYU84eGRqR0hDYTJWMTV2alRKSDZBb05YVEl4VFdyY3NvcExHYVdqUUp6MWwK
b1FDaWFkRG1wcjBqelY5OVNDOUpFUSJ9"
,
              "signature": "
cEExnK2TD6MKGDSZsEqfidREEkahaWGCrVUbTcHk73Z2fpqiQldvz5DBuWni8BqJ
h3xsdXjoT7sZ7bl4BUILulczLmDXDoHsiW_4DqaCxfWi6i8qhvuyJFzrGojdhl_p
pIgucjqwfj-DhnBQp0-pYju-B7mjwIu4TQn7iM03VdO6apRbCHrEq9EwhN7ES8Yd
NTiRjATFyv-0S4zgnrk4lZX3YZRRiT19iBjJ6ZHdiWeJbXlIBTLKi4YQiazgV3Y-
EFyDnXVovGvlwcZF5P-3ejD12qOZ8rEVnCbMc98i2Svo2pozvReKlAlxN-XfWygv
Afu8bvVvVC-7LpYFUpGyTg"
}]}}]}}
~~~~


###Administrator posts completion request.

Having accepted the device and connected it to the profile, the
administration client creates and signs a connection completion
result which is posted to the portal using ConnectCompleteRequest:


~~~~
{
  "ConnectCompleteRequest": {
    "Result": {
      "Identifier": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJTVEUtUEFHVkgtM1JVVUctWk9aREMtVFpSUlctRVVZ
...
aHAKNkZNV1RJc2REQnZ4ak0xNXpHMnhfQSJ9XX19fX19"
,
        "signatures": [{
            "header": {
              "kid": "MABWP-OI6SL-MORUJ-2G2QE-RAD24-Y5TAA"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmtteHRzbGUzcVNKMHJuMVlS
cW02RzlLVlBqRzBKbjRoQl8yLS0wbDdDcExSRE5pR0ZmZ0ZnQmtyamIxMDBIbEoK
Z0RNOFo3dE5oZm5SOVhqbW44YWNEQSJ9"
,
            "signature": "
nCnjQ9rFUpY_bcfEC2pcUjNd6qG5zt3yQz0RoRFiLU77IFQb7QHg281FJKIkiUyI
ScLnVXyIKzn0nRX3k-koXb4YLRC6pzyd32KtKT794lOcSCXkS3QgEA1L54vv0rdU
WGGUrjhC9wTB9YQ5f9T3tdueOawM80YnsUS0JdaJzsIxGJedPmlDwvHp-wrdRSfc
w3DGKD4kxg3fxPDhg7gRSOa_BDCGxnbzeC6UBAiWNdibGRtc8xbdom7w4ioAJ4qL
zwD0YdsmY-2Q32aJcnZxGZY-N5zw6MskmwHGJMYTT9IC7phCDN0tqsiyTGJnF-zX
GGcdSFnjLX_WtFgIGAHZYg"
}]}},
    "AccountID": "test@prismproof.org"}}
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
    "AccountID": "test@prismproof.org",
    "DeviceID": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MBSTE-PAGVH-3RUUG-ZOZDC-TZRRW-EUYIP",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJTVEUtUEFHVkgtM1JVVUctWk9aREMtVFpSUlctRVVZ
...
aHAKNkZNV1RJc2REQnZ4ak0xNXpHMnhfQSJ9XX19fX19"
,
        "signatures": [{
            "header": {
              "kid": "MABWP-OI6SL-MORUJ-2G2QE-RAD24-Y5TAA"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmtteHRzbGUzcVNKMHJuMVlS
cW02RzlLVlBqRzBKbjRoQl8yLS0wbDdDcExSRE5pR0ZmZ0ZnQmtyamIxMDBIbEoK
Z0RNOFo3dE5oZm5SOVhqbW44YWNEQSJ9"
,
            "signature": "
nCnjQ9rFUpY_bcfEC2pcUjNd6qG5zt3yQz0RoRFiLU77IFQb7QHg281FJKIkiUyI
ScLnVXyIKzn0nRX3k-koXb4YLRC6pzyd32KtKT794lOcSCXkS3QgEA1L54vv0rdU
WGGUrjhC9wTB9YQ5f9T3tdueOawM80YnsUS0JdaJzsIxGJedPmlDwvHp-wrdRSfc
w3DGKD4kxg3fxPDhg7gRSOa_BDCGxnbzeC6UBAiWNdibGRtc8xbdom7w4ioAJ4qL
zwD0YdsmY-2Q32aJcnZxGZY-N5zw6MskmwHGJMYTT9IC7phCDN0tqsiyTGJnF-zX
GGcdSFnjLX_WtFgIGAHZYg"
}]}}}}
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
{Example.PasswordProfile1}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:

% Point = Example.Traces.Get (Example.LabelApplicationWeb1);
{Point.Messages[0].String()}

The service returns a status response.

{Point.Messages[1].String()}

Note that the degree of verification to be performed by the service
when an application profile is published is an open question.

Having created the application profile, the administration client
adds it to the personal profile and publishes it:

{Point.Messages[0].String()}

Note that if the publication was to happen in the reverse order,
with the personal profile being published before the application
profile, the personal profile might be rejected by the portal for 
inconsistency as it links to a non existent application profile.
Though the value of such a check is debatable. It might well
be preferable to not make such checks as it permits an application
profile to have a degree of anonymity.

{Point.Messages[1].String()}

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

{Point.Messages[0].String()}

The response indicates success or failure:

{Point.Messages[1].String()}


##Recovering a profile

To recover a profile, the user MUST supply the necessary number of 
secret shares. These are then used to calculate the UDF fingerprint
to use as the locator in a Get transaction:


{Point.Messages[0].String()}

If the transaction succeeds, GetResponse is returned with the 
requested data.

{Point.Messages[1].String()}

The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


