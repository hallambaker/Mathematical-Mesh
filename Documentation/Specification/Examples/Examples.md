
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
Date: Wed 23 Aug 2017 07:41:38
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
    "Identifier": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
    "MasterSignatureKey": {
      "UDF": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
      "X509Certificate": "
MIIFXDCCBESgAwIBAgIQCHzThmmiZClaSVb1Aa-bkDANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQU9IUS1JMlQ0NS1WREFVSi03WkxFVS00MkhTNC1XQklHVTAe
...
Mq8NklKdN29S7i6xvyDsE4wmoy9pFbgwHNabQ7npNQg"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
          "n": "
zlI_ExdhglgqlwZEWHADF_nc-ay-8Hz0wmYAfeUl-dpXJ2WJSoEgMcowwc3TJbv1
jtyMHy9ZoHIdzWqsMCqYNG6BOp6U7x6UuGMVlE4dNpsfiUW7L6mqpYm7FDI3nid5
Td662FLgl00hRgk7msuTqGrWfg_BAR7WYEG0_8SyF0MWTTUqE3H5oByvoR8orw3j
Ts3dOvTKAqA6DDhBNh5pa3nQcIbH2f_9qIiayOucR6Nk1DNN5xio0EAQDGspQ-84
0O71gQhm-cAlGswwQohGjVHvNPNYfk0OqjCcIAq2OWMdxC_Uau5On3hEAKwhVVAd
vhmt4XC5bDTGKfOxZUyciQ"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MDIP3-YUA4S-EN4BQ-S4GUR-55AWF-WN4QX",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQIhv11qperPumwGG90S_4VTANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQU9IUS1JMlQ0NS1WREFVSi03WkxFVS00MkhTNC1XQklHVTAe
...
nQ-M733j8sVkM3Ljs9x_u_V7wtFZH4sY-5is40hpuqs"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDIP3-YUA4S-EN4BQ-S4GUR-55AWF-WN4QX",
            "n": "
6hf6tuqCjarYfc2VJmjaOsaokAwulfZS3a7Fb0hog_A6bIVhD4acMw6NKFgUrIBH
DtwapJm8cNt04SKA30wyClYN9oDNDsfdmk-GapplT6lufyxgQWlpu-oQPejc_B19
XIpUD_nkxP7WrkDR9jebxJfM35Ngr7Shgafm-RO9eeYqBpX8DsV3dIs5OlvDt-nB
Qdb8gHzwdVehRZ5h6FclB7Vul1dWfMu2w6RlTfjSw6BoCNVIr8Lew3C7Ukg43mGp
WQbOFnsxoF-TwQJm_DwccFSUqMN_Qsd0Q3gtnjzQ2J32pipLz9PY40p-cVXrWP7l
Ghg_yvnrVzQy8Gc0WXQHwQ"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MCREM-CORYU-NK735-FWDQA-CF4X7-JF46W",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQcrepRwqFOjxUWExvPQR-FDANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQU9IUS1JMlQ0NS1WREFVSi03WkxFVS00MkhTNC1XQklHVTAe
...
G-UQYLFIefZ2b7WpCPgmy5jrloYm0VL7YMOud4viUqA"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCREM-CORYU-NK735-FWDQA-CF4X7-JF46W",
            "n": "
ycmcLU06GbmS-O_4W6BjcDrBiGO_IUhvDjAu0Yz-YxOdq_-UJ_hxZjYJI0DRt-2w
_IEbXHpy3LNunobLhcq_augxM5fNM0P9dZN722IQH_VzA-ZPeqBhN8gGapWqpWPS
k-RLes9HkBl21pugVEf1pwPHBtlHj37mCPsWGvCMAm6XvacVqs6m7f8Isskvu1jQ
6NSUdr7Fcb6I2D-7RhSFpolm4HwpwdPNvoA4-3JlbeHI3i4NhaNZf7YIEBMHTmFU
W0l4DH2wTz5waSPkgSKBrxM88fEgLu46VkYsbiNN6KBB0T7BO-7ufHb2TjagsRTU
sWz3tArHhPfOn5EjoI1VJQ"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFPSFEt
STJUNDUtVkRBVUotN1pMRVUtNDJIUzQtV0JJR1UiLAogICAgIk1hc3RlclNpZ25h
...
fX19XX19"
,
      "signatures": [{
          "header": {
            "kid": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClhmcVFXVHJ5TTRzWTQ3MU8y
Ylg3RDUyMk1ad2NWZ3JsbU4yQnN5RTJJTV9vRlR0VGp0ei1fU0pqZnpGTUxPa0sK
VnJJYU1wUkVsdGN1QzYzcUJmejZWQSJ9"
,
          "signature": "
uRPzohb3UPFWDD5Q0v4mMAsfBF90eR72JKcEFN00xVJeLsBdqMMOVpf_DKMCUS-V
lhF_a8cWWQsnMWa2jNBdapxewpl4Ri452-JdWaMvQURy1uAWNslRlo4SVF_0-Pwx
dpz4grIuPPpt3ifk6-4LU4lKY8fvx3I7GlXpy5nuOBV6iwwrkUUTXex6kN-IhDsn
sKIfDQLtKMNmUbTl2SfT7wEy1yeYqwSKuIlV_1FF_2zl-bZlMxribynq7eo0k_Hu
F06CPiIjo8QVJpTdN1-rPNSOTKXCd4CNkJHaYFkFCJptvDOxpjGqGeJ9f7YM7xpV
19ljIL-m1EmRpfqWeaJpJQ"
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
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNaN1Yt
S1JYSkotRENCS1MtU1pJUEgtNkpLUVktWU40RDMiLAogICAgIk5hbWVzIjogWyJE
...
WDduRDJRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
    "signatures": [{
        "header": {
          "kid": "MCZ7V-KRXJJ-DCBKS-SZIPH-6JKQY-YN4D3"},
        "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClVSYkdoQjJ6eXpsLU5oalpp
elhuSGgySG5ybHFmZF9uUThDWWVCUEFlRXBXakZ4LVFHR0IxZWZrbUN0RVBicmgK
aW41OGhXczROLXNPOEVCWEdLel9oZyJ9"
,
        "signature": "
xd-EikxyUPRHFeZ2XPgsWcuutBt6NgUFmR3_7qlVRgU4WXhPxpOeEIocNzYWPNpC
Sbp0vdlKxCGCO0PTkDz2kl34-cocs6GNPRpksGiNqyG3sAwFhqzH4CGnujGkXVkk
iLWOGIub7-Ef7zf2YDkZ8w-jYlt0eZFQRrC7qcpcS5bHSalbvBQMb5mkrBHJJlVN
emY-V4uLsYVNrXjfNWx3S3ia79PzZN2a-oWx-86QP7XnqE5-Lg4gtn7zxZlZBPnR
KYZzVYRBpJKUn9ml5_kbY7OLjH3D9MsB98gY_BoagByD-nLFgsQjuTXT3Jb-g85R
gCMEshXzAZ6x1U8OJEIVJQ"
}]}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCZ7V-KRXJJ-DCBKS-SZIPH-6JKQY-YN4D3",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNaN1Yt
S1JYSkotRENCS1MtU1pJUEgtNkpLUVktWU40RDMiLAogICAgIk5hbWVzIjogWyJE
...
WDduRDJRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MCZ7V-KRXJJ-DCBKS-SZIPH-6JKQY-YN4D3"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClVSYkdoQjJ6eXpsLU5oalpp
elhuSGgySG5ybHFmZF9uUThDWWVCUEFlRXBXakZ4LVFHR0IxZWZrbUN0RVBicmgK
aW41OGhXczROLXNPOEVCWEdLel9oZyJ9"
,
          "signature": "
xd-EikxyUPRHFeZ2XPgsWcuutBt6NgUFmR3_7qlVRgU4WXhPxpOeEIocNzYWPNpC
Sbp0vdlKxCGCO0PTkDz2kl34-cocs6GNPRpksGiNqyG3sAwFhqzH4CGnujGkXVkk
iLWOGIub7-Ef7zf2YDkZ8w-jYlt0eZFQRrC7qcpcS5bHSalbvBQMb5mkrBHJJlVN
emY-V4uLsYVNrXjfNWx3S3ia79PzZN2a-oWx-86QP7XnqE5-Lg4gtn7zxZlZBPnR
KYZzVYRBpJKUn9ml5_kbY7OLjH3D9MsB98gY_BoagByD-nLFgsQjuTXT3Jb-g85R
gCMEshXzAZ6x1U8OJEIVJQ"
}]}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
    "SignedMasterProfile": {
      "Identifier": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFPSFEt
STJUNDUtVkRBVUotN1pMRVUtNDJIUzQtV0JJR1UiLAogICAgIk1hc3RlclNpZ25h
...
fX19XX19"
,
        "signatures": [{
            "header": {
              "kid": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClhmcVFXVHJ5TTRzWTQ3MU8y
Ylg3RDUyMk1ad2NWZ3JsbU4yQnN5RTJJTV9vRlR0VGp0ei1fU0pqZnpGTUxPa0sK
VnJJYU1wUkVsdGN1QzYzcUJmejZWQSJ9"
,
            "signature": "
uRPzohb3UPFWDD5Q0v4mMAsfBF90eR72JKcEFN00xVJeLsBdqMMOVpf_DKMCUS-V
lhF_a8cWWQsnMWa2jNBdapxewpl4Ri452-JdWaMvQURy1uAWNslRlo4SVF_0-Pwx
dpz4grIuPPpt3ifk6-4LU4lKY8fvx3I7GlXpy5nuOBV6iwwrkUUTXex6kN-IhDsn
sKIfDQLtKMNmUbTl2SfT7wEy1yeYqwSKuIlV_1FF_2zl-bZlMxribynq7eo0k_Hu
F06CPiIjo8QVJpTdN1-rPNSOTKXCd4CNkJHaYFkFCJptvDOxpjGqGeJ9f7YM7xpV
19ljIL-m1EmRpfqWeaJpJQ"
}]}},
    "Devices": [{
        "Identifier": "MCZ7V-KRXJJ-DCBKS-SZIPH-6JKQY-YN4D3",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNaN1Yt
S1JYSkotRENCS1MtU1pJUEgtNkpLUVktWU40RDMiLAogICAgIk5hbWVzIjogWyJE
...
WDduRDJRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
          "signatures": [{
              "header": {
                "kid": "MCZ7V-KRXJJ-DCBKS-SZIPH-6JKQY-YN4D3"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClVSYkdoQjJ6eXpsLU5oalpp
elhuSGgySG5ybHFmZF9uUThDWWVCUEFlRXBXakZ4LVFHR0IxZWZrbUN0RVBicmgK
aW41OGhXczROLXNPOEVCWEdLel9oZyJ9"
,
              "signature": "
xd-EikxyUPRHFeZ2XPgsWcuutBt6NgUFmR3_7qlVRgU4WXhPxpOeEIocNzYWPNpC
Sbp0vdlKxCGCO0PTkDz2kl34-cocs6GNPRpksGiNqyG3sAwFhqzH4CGnujGkXVkk
iLWOGIub7-Ef7zf2YDkZ8w-jYlt0eZFQRrC7qcpcS5bHSalbvBQMb5mkrBHJJlVN
emY-V4uLsYVNrXjfNWx3S3ia79PzZN2a-oWx-86QP7XnqE5-Lg4gtn7zxZlZBPnR
KYZzVYRBpJKUn9ml5_kbY7OLjH3D9MsB98gY_BoagByD-nLFgsQjuTXT3Jb-g85R
gCMEshXzAZ6x1U8OJEIVJQ"
}]}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU9I
US1JMlQ0NS1WREFVSi03WkxFVS00MkhTNC1XQklHVSIsCiAgICAiU2lnbmVkTWFz
...
cyI6IFtdfX0"
,
      "signatures": [{
          "header": {
            "kid": "MCREM-CORYU-NK735-FWDQA-CF4X7-JF46W"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCk0zdlhKUV8wN2xwRm1TNF9M
bExDNE85R1lsTW5sa2planNqQ0V5QlpOQ1lYaGhTeUhzZjRHeENGUDg2TWxEeWMK
VDdtbHE4Qi1BRGxzQUJqNjlzWWtmZyJ9"
,
          "signature": "
Jb8UbEPjEpFVgtalPp59FUA6z2SgWd7zfYtzTdPz5uADCqyahdjuNJhmFQyJRUXz
b2PZaBMfDqU9M-0Xi66dHzNmA5vwSBYAIv8VV3MyJrCJkTSk_H5u5zbtKD67jF-s
_XwqgHAxp7jTQrjScT-a430foQkWugZwsxv_wE8e1J3sKR3fGd5Idyu61YUqo54h
Pf7PopOmgcU8Y_YBsnKknI9gENBGNXieqemtibDJ1GHgd-lcRzuD5d07BHlXvH7C
AbGgJ3dTN5wwnJmTwSizyrCWXq2cd5KmheW3ETvQQoAqHtKYv8GMdEI93Y0BfdkL
7G06IFwsRtya1ZiM7gzp2g"
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
        "Identifier": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU9I
US1JMlQ0NS1WREFVSi03WkxFVS00MkhTNC1XQklHVSIsCiAgICAiU2lnbmVkTWFz
...
cyI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MCREM-CORYU-NK735-FWDQA-CF4X7-JF46W"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCk0zdlhKUV8wN2xwRm1TNF9M
bExDNE85R1lsTW5sa2planNqQ0V5QlpOQ1lYaGhTeUhzZjRHeENGUDg2TWxEeWMK
VDdtbHE4Qi1BRGxzQUJqNjlzWWtmZyJ9"
,
              "signature": "
Jb8UbEPjEpFVgtalPp59FUA6z2SgWd7zfYtzTdPz5uADCqyahdjuNJhmFQyJRUXz
b2PZaBMfDqU9M-0Xi66dHzNmA5vwSBYAIv8VV3MyJrCJkTSk_H5u5zbtKD67jF-s
_XwqgHAxp7jTQrjScT-a430foQkWugZwsxv_wE8e1J3sKR3fGd5Idyu61YUqo54h
Pf7PopOmgcU8Y_YBsnKknI9gENBGNXieqemtibDJ1GHgd-lcRzuD5d07BHlXvH7C
AbGgJ3dTN5wwnJmTwSizyrCWXq2cd5KmheW3ETvQQoAqHtKYv8GMdEI93Y0BfdkL
7G06IFwsRtya1ZiM7gzp2g"
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
    "Identifier": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
    "Names": ["Default"],
    "Description": "Unknown",
    "DeviceSignatureKey": {
      "UDF": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
          "n": "
qkJw9vjDY5wAppArMebVltIepdAqnlV3Ytk-Bza5STpIvZxJm5lKMbwgnNm0Gmd4
YeklRhD04UCbtgnd5sKjBMXICocbS7BocYMY9XZzoNUNT7tHkf0HPTH0Mpf5SCzt
ecWrSIrxh90xZMdStxtn8HV5czNbovcBuAAfHCIOgfHaON8uC-PAGeR7Lkk62THu
ec3GitO4ycFh9Ksh23xwahNKMQcQbFzGguFIe_exgS_8i0V9AoKmRoHhfY6UfHhr
UsP5iJlUnQE2MHCO-ifWKkxzsUv_UOZFsI4NPOZx-J-WRVR8is5rMHzC8-uHSRFq
c_OaAlBe54OS6hxtta3tCQ"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MDQYY-G5SD2-IBHPR-47CN4-3SV47-7OA27",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDQYY-G5SD2-IBHPR-47CN4-3SV47-7OA27",
          "n": "
vk57VXDHSiupisxRZEe70PnrkEBYDGB0e_UvZGEbiV8_ljwydWA2BtTYkWwrAWcn
zXWvI0OMri3XgU7KUYzYGHlEmgznqA2lbPDtmLeln8WkOgOzsIYU6bvIjTl5k9hN
GRI_pcH6xHr-nlsd8AmNV8kqKKaJAtHhEjjh7QTfrSq0zla8S4pzYaP-GcPS_lmv
7OxVuBY1hmv9dZsXGJD-lCXvpf7bXf2Gb1dP7ONwCNBYZ7HFXoK0etOhfb1A7OoQ
QHOAbTSCh1HG-V5m93fr0kuOT344Sjnp0kzZCnZi6kpi41HmHr6-AEGJzDK6jRiF
lv7wpIIPWWfeYJQUpw8T1Q"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MC4T4-RJDER-VI3MM-Y6RRV-66Q2S-2FUEA",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC4T4-RJDER-VI3MM-Y6RRV-66Q2S-2FUEA",
          "n": "
w6PeMdS0k8RsC5BXg-1j47KPg_7NJdVmedu-GtgpZXsGcDHG7wGMscVG1GxuP4Fb
HuxkzKfCkt2tTlXW1c7CxVHX8VjO8Pm7-XdS4Pu5z8B1iR_71pWWlBYeOUoskjX0
afGHDV6GzSSGbsEUQmwd3-225cBzST3VhesVWo0GRfRTf-OjDLdf4eDmmWqBUvw4
YmP3mwkOzJ6Z5erzi1RWC90w3aqIKq2H_74ZjMfWhl1UURLLUtuTQXhumGrZ0Dvd
P4SPbHtgZod4PiCEpfB81RgluO_8D0xUx7GKjeyKBX1Nx3EJqu_Ql5u9SMAoZQqw
yvfkpzR2gi_G_LkqJC9D3Q"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNOTTYt
M1hZUDUtS0NPNkItS1A2QzYtQk9aWFYtTUpNQ1ciLAogICAgIk5hbWVzIjogWyJE
...
ICAgICAgICAgImUiOiAiCkFRQUIifX19fX0"
,
      "signatures": [{
          "header": {
            "kid": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmJtcjFEbTMxZmh1UjgtLXo4
QmMxMk5yNUVJTGpNajJmZHIwM1JWeXJXU0xKVEk2dzZPSzVyZ1N5ZG15UzlnV20K
VDdaYk55LXhlMkZORzdYX0ZaRkJDUSJ9"
,
          "signature": "
PbGkXgJwjJv3mJVIlOw_C87ZzQINCkKCbGY7yAsqPx4CKNOIrEJ8nwaiwlYNGA-E
YhENjm22X7PbUkAanKaepVDeqPvQwgdTQgniXtUfdezv6QqBzjJiwhY2KZ9b8k1r
_QC6gV-q9hVSosOGosCU8Y7I6lw_1SUC_0eCJWcNtOK480ghZUN5W6iIHMkCcVm7
WSYwYsvMr1MWa1D3DaJ2uDUgbIogf_JRANVes-e-SbTpVOuHb7ulFspBwkvqmJ4P
_YnGdDuW1N2GjoBWSZT7DSmrFqqwqTyGfQzkq9QsXlxdDnv1W5siv8rQT6puLIcf
XHN4fYR-7sITijGNCdWVJg"
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
          "Identifier": "MAOHQ-I2T45-VDAUJ-7ZLEU-42HS4-WBIGU",
          "SignedData": {
            "unprotected": {
              "dig": "S512"},
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU9I
US1JMlQ0NS1WREFVSi03WkxFVS00MkhTNC1XQklHVSIsCiAgICAiU2lnbmVkTWFz
...
cyI6IFtdfX0"
,
            "signatures": [{
                "header": {
                  "kid": "MCREM-CORYU-NK735-FWDQA-CF4X7-JF46W"},
                "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCk0zdlhKUV8wN2xwRm1TNF9M
bExDNE85R1lsTW5sa2planNqQ0V5QlpOQ1lYaGhTeUhzZjRHeENGUDg2TWxEeWMK
VDdtbHE4Qi1BRGxzQUJqNjlzWWtmZyJ9"
,
                "signature": "
Jb8UbEPjEpFVgtalPp59FUA6z2SgWd7zfYtzTdPz5uADCqyahdjuNJhmFQyJRUXz
b2PZaBMfDqU9M-0Xi66dHzNmA5vwSBYAIv8VV3MyJrCJkTSk_H5u5zbtKD67jF-s
_XwqgHAxp7jTQrjScT-a430foQkWugZwsxv_wE8e1J3sKR3fGd5Idyu61YUqo54h
Pf7PopOmgcU8Y_YBsnKknI9gENBGNXieqemtibDJ1GHgd-lcRzuD5d07BHlXvH7C
AbGgJ3dTN5wwnJmTwSizyrCWXq2cd5KmheW3ETvQQoAqHtKYv8GMdEI93Y0BfdkL
7G06IFwsRtya1ZiM7gzp2g"
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
      "Identifier": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUFP
SFEtSTJUNDUtVkRBVUotN1pMRVUtNDJIUzQtV0JJR1UiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
        "signatures": [{
            "header": {
              "kid": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCl9rc00wRzgwQzFmV0JhRnpT
cmRTWUlYWHA2dTBKWGY2YXJZcHRiQ283LXRzYkVJTFFYX3ZkUmw2UVdRcW1Vdm8K
M1J2bTdiUnVabkNTZl9mdHN1WWs1dyJ9"
,
            "signature": "
HG7l9ELwaGbn4_De-IB0CAmmH5hH0GOe3WeYWzVA_begYewsUC5bdHW3KpJjScwR
FuTDegBUEHvoxUmdWbXK0K07KdCFo-m2sm-1eJHiRjdcew61xOgmrKLm23A-RfeQ
VwC7vmNkHfBitoDWZxLKGG4k9M3F6UeMyco8fev1CLkeixae-H-BbxoDhZgDUhp6
kYuwO2ecEEV3wZycwHr8x3f5RcdmWo0wRs85LpyohriMi2uabkQSsOm7vUGuNkQd
cbzqUyl88330CqYOxPoeQYhH-qxJwK5pwRK0e4hH1EqA3VXVH2HxRE0oLV2B6Wvu
xKXc8FkJKxVReQe4Ckpwng"
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
        "Identifier": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUFP
SFEtSTJUNDUtVkRBVUotN1pMRVUtNDJIUzQtV0JJR1UiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCl9rc00wRzgwQzFmV0JhRnpT
cmRTWUlYWHA2dTBKWGY2YXJZcHRiQ283LXRzYkVJTFFYX3ZkUmw2UVdRcW1Vdm8K
M1J2bTdiUnVabkNTZl9mdHN1WWs1dyJ9"
,
              "signature": "
HG7l9ELwaGbn4_De-IB0CAmmH5hH0GOe3WeYWzVA_begYewsUC5bdHW3KpJjScwR
FuTDegBUEHvoxUmdWbXK0K07KdCFo-m2sm-1eJHiRjdcew61xOgmrKLm23A-RfeQ
VwC7vmNkHfBitoDWZxLKGG4k9M3F6UeMyco8fev1CLkeixae-H-BbxoDhZgDUhp6
kYuwO2ecEEV3wZycwHr8x3f5RcdmWo0wRs85LpyohriMi2uabkQSsOm7vUGuNkQd
cbzqUyl88330CqYOxPoeQYhH-qxJwK5pwRK0e4hH1EqA3VXVH2HxRE0oLV2B6Wvu
xKXc8FkJKxVReQe4Ckpwng"
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
        "Identifier": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUFP
SFEtSTJUNDUtVkRBVUotN1pMRVUtNDJIUzQtV0JJR1UiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCl9rc00wRzgwQzFmV0JhRnpT
cmRTWUlYWHA2dTBKWGY2YXJZcHRiQ283LXRzYkVJTFFYX3ZkUmw2UVdRcW1Vdm8K
M1J2bTdiUnVabkNTZl9mdHN1WWs1dyJ9"
,
              "signature": "
HG7l9ELwaGbn4_De-IB0CAmmH5hH0GOe3WeYWzVA_begYewsUC5bdHW3KpJjScwR
FuTDegBUEHvoxUmdWbXK0K07KdCFo-m2sm-1eJHiRjdcew61xOgmrKLm23A-RfeQ
VwC7vmNkHfBitoDWZxLKGG4k9M3F6UeMyco8fev1CLkeixae-H-BbxoDhZgDUhp6
kYuwO2ecEEV3wZycwHr8x3f5RcdmWo0wRs85LpyohriMi2uabkQSsOm7vUGuNkQd
cbzqUyl88330CqYOxPoeQYhH-qxJwK5pwRK0e4hH1EqA3VXVH2HxRE0oLV2B6Wvu
xKXc8FkJKxVReQe4Ckpwng"
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
      "Identifier": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNOTTYtM1hZUDUtS0NPNkItS1A2QzYtQk9aWFYtTUpN
...
alozRnJBUWZsM182cEo1WHcwM0F3In1dfX19fX0"
,
        "signatures": [{
            "header": {
              "kid": "MCREM-CORYU-NK735-FWDQA-CF4X7-JF46W"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjNvSVN2YldGdlZEQnpOMWlx
QVFRUzBidE1KbWpuUGlPOGlKUUxILVAzbFVQdzUtLUJhbERIM3NHVlBQRjRIbTEK
UFdGNThkREhqTWt5UWRWVnhmUmJaUSJ9"
,
            "signature": "
tcOAoIaJ6xRUtY1DWCqv5dXYmll3KcpF3B2ZwgWafhKFROZ-bKz9vDhsUfKaHdxh
cvC3H0dwS-M8ppW-h1Mmy6O0RgACr_arUf2JUM51UF0Koh_TaYkscO5VrEHj4rQg
-aHNOpa4t4svF5ErAP6X2wg2bToLls7D2y0lsQXPZMyoWNPha0zmp__OQhJouo4b
8VvDtj-Ui2RtIB6eQ0DEL6rgsTbcSCx-_dBOE0tdZILqqHo1OftKaC1UiEIoBFQG
msoylAYqdbtUrT1DINAeeNUtccZzhEjZPyqgvBI6eCAThPWEFj_E6YobZyJdLIcy
banSGg7uxlQfkfFKOO1VEQ"
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
    "DeviceID": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MCNM6-3XYP5-KCO6B-KP6C6-BOZXV-MJMCW",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNOTTYtM1hZUDUtS0NPNkItS1A2QzYtQk9aWFYtTUpN
...
alozRnJBUWZsM182cEo1WHcwM0F3In1dfX19fX0"
,
        "signatures": [{
            "header": {
              "kid": "MCREM-CORYU-NK735-FWDQA-CF4X7-JF46W"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjNvSVN2YldGdlZEQnpOMWlx
QVFRUzBidE1KbWpuUGlPOGlKUUxILVAzbFVQdzUtLUJhbERIM3NHVlBQRjRIbTEK
UFdGNThkREhqTWt5UWRWVnhmUmJaUSJ9"
,
            "signature": "
tcOAoIaJ6xRUtY1DWCqv5dXYmll3KcpF3B2ZwgWafhKFROZ-bKz9vDhsUfKaHdxh
cvC3H0dwS-M8ppW-h1Mmy6O0RgACr_arUf2JUM51UF0Koh_TaYkscO5VrEHj4rQg
-aHNOpa4t4svF5ErAP6X2wg2bToLls7D2y0lsQXPZMyoWNPha0zmp__OQhJouo4b
8VvDtj-Ui2RtIB6eQ0DEL6rgsTbcSCx-_dBOE0tdZILqqHo1OftKaC1UiEIoBFQG
msoylAYqdbtUrT1DINAeeNUtccZzhEjZPyqgvBI6eCAThPWEFj_E6YobZyJdLIcy
banSGg7uxlQfkfFKOO1VEQ"
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
{
  "PasswordProfile": {
    "Identifier": "MDUVE-HF4Y2-RBBMK-EKVDB-4VGPX-G32PQ-A"}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:

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


