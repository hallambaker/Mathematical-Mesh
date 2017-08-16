
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
Date: Wed 16 Aug 2017 06:54:29
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
    "Identifier": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
    "MasterSignatureKey": {
      "UDF": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
      "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAJgW2Bbo4WgGTos7iEz0p_QwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUQ0R1ktQ1BNT0YtQzdQTzMtSFBCREotNFpISFgtM01HVlMw
...
l13JWzooXYmyci3dnmCveygbGHh3vKkuCf7uAeBmm18h"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
          "n": "
wVODdCKcVXCDPk7FVSauY9dI5cqvek8i1vyK__tlrGl3c_tBt8aCLDP5fhV3pAyn
o-pUkMIWpFgXAzoA-TGbUuvUqPzRRSweNYFRO6XL2SPxnY66E1Z0P5BFE9WEDe5y
Lq1dqO9ZkOE-ZcRYYNU1waETM8pLZraWpWIY8Alz3dGaYtRF7fd8Q843UlZ4Sx_D
ew3YVEoaU48MNtKls6tMyK9AUaYgxcClinIBAQAZaRx1ofOKEm0uObHmou1qPdzr
56tBytXTgXegzdBDYbPSlExA8gnfpMRPgNHrhJLgid5GaoMaGO5Qfxtpm512qoOW
VJR-S8O7xqs6Yqy35SmXtQ"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MCK7O-YP3PL-FH66Z-SWLR4-HC6HD-QI2AI",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQPRb5NFFp_BEuwn41lTF7ezANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNRDRHWS1DUE1PRi1DN1BPMy1IUEJESi00WkhIWC0zTUdWUzAe
...
RKS4Kj8qX03_V7SbjM8efB_5pBNiBy9N7H37ISdHfjs"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCK7O-YP3PL-FH66Z-SWLR4-HC6HD-QI2AI",
            "n": "
oxQ1wX23ZthRJ5ce7MBS0CIzGaKsHPsWuTS2LXHWYoqtr2uXdPsres0hw6cKdg3t
OVogFMOB549QVCJA20K3xqjGlx8ooEF2GHlPwwZRx1HRmN9NTNdDxWwwZP-sInJw
gr_5hfLovQpDs-sb1KtP-vWr-2LHAEnRbQfkOGycI5CigPh1E8dVkAU0hlUEO3PD
Y31SsOMZtVjB9Vz2xshd8zh32H1YVgBnlLJRbddHWMyAZXCcsse4jVTYXEIcYcyy
QAaXN-Xlj_sYPiSFh5jW-fpECYRKyPWeuiQeHwkhHcAd7Gbv_nK0Wg4Ad-mao2bp
GkKdDtMAOak66mcipSBggQ"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MDOBX-E24X2-NIXRQ-WSKBN-LXH46-VRGNF",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQCp4zgHmim9gKMLoy4F6aADANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNRDRHWS1DUE1PRi1DN1BPMy1IUEJESi00WkhIWC0zTUdWUzAe
...
sO4NrIBHPZzzW3zbSyGb7FSOEcv0qoLRufba1NNJi3Y"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDOBX-E24X2-NIXRQ-WSKBN-LXH46-VRGNF",
            "n": "
_c4x7cfUJgBrha9vUdRUAVTeO0eAwRZnPW0E9HABWBdUavHPrhoby-qawnMmJUaH
3TTMf4pI6ngksxIxNyCVDyjYbNwIygjJ-fHb99zRh4pQNovxi-EHg0faOvihBxdU
JeDR_Ipuz_bfwUd47x3R7r3ETy0xRijMUR2kuKpsOuyUaWa99X6fOllT_TgCKFkd
5cJa0FVyKd-ElL6Hepe_u5S0XBxg3Fg93fGToprsaF8dEInyE715dJp0rtFkFlxU
fqzqA7GMu2uC5IQ38cMBDY--GtKhm8tFGkAhxvLP5iYzP7wfIfHnltS-ve54XaYj
mxp91TjIP-Wjpe5tJW6ayQ"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQ0R1kt
Q1BNT0YtQzdQTzMtSFBCREotNFpISFgtM01HVlMiLAogICAgIk1hc3RlclNpZ25h
...
In19fV19fQ"
,
      "signatures": [{
          "header": {
            "kid": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnFkbHFiUHd3b1hCb3dGNDdu
ZHhmY2RRVWQ3amwzUUw3VzJHYVlTR2hfcnpZeWx5amE0NVZicExwck8zR21PZWkK
c2xNbGRRUFljTHFCa1l3SFNrcHl6USJ9"
,
          "signature": "
lOnhJvmpyxZI8TaOP2Avxrootd_WLAiiwxqAKIVQSge3MBM-Kn81LG41DKmHt85l
qQ7VbplWY0MNMOxBZxqjXa_IJeHCmq6ilmiZNHjJjaJQqTH0zAb_zh6Qih91WYBf
IlsShXHy5xmjmUqNalJyYTTfBcaRm4Fyztl9K8VHt6iMIoSJmSh4ZuxddbBte-f4
j_6S2cJ7hRXYptnX9eogmS2A-8Jan1cQJ-cxJabPZTzxtZ9S0fqEnsK6OGvGQx1t
aXHUB6kiKHBuXf2Ua3tfs8d0OLgSp47wmCTPLM__NvYB4nU6Yf0n7smgaCz-lakN
V20dKO23960_2GqDgkuy8g"
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
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUM2UkMt
SlBDREUtQ1hNNjItWFVaTlktSFRLSFktNFZXV1kiLAogICAgIk5hbWVzIjogWyJE
...
ZENxQTZRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
    "signatures": [{
        "header": {
          "kid": "MC6RC-JPCDE-CXM62-XUZNY-HTKHY-4VWWY"},
        "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmlpSHhreHo2THhON1BySDdZ
RUVXMTZPSFJuVHpYeHpJQjdlT3ByeVNkeHd6TGdXa2pQZ0RPamlXY2dxWThJdXUK
ekhoMjd3eGZvcFNjTlhpOEFRVWxkdyJ9"
,
        "signature": "
gRWCGIKt7R32KcN89TkPthVICDvHaYOZMNAkdeT5SMkYHHXnHgfjVnpkPRh2uRoT
rUj9rP1zWPxX_QLC7iQ7PFbmjwyPu2C0hbF8PdrmD9C14jeOpkNuMgfRaJnzFwUZ
vwpuPBgiedGkgWhk2h4s8mDK8EccDJaZN3Q8l1xNfNn-IsDccyiGv0nrKPsBsgRy
X69iE47kSHnnAB3ez5fPsNNzvUW2Kon-LPDDkunaBREu5UP-Zds63xawcZMyqgBu
bwQKaFEbn9CnKzu7YoORnDx5Sh65tmahdgxD6xDFkx47RrMfiA6G8VaqLN25OcAj
Uz9zCAlF1Z58Oh6_CyCLWA"
}]}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MC6RC-JPCDE-CXM62-XUZNY-HTKHY-4VWWY",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUM2UkMt
SlBDREUtQ1hNNjItWFVaTlktSFRLSFktNFZXV1kiLAogICAgIk5hbWVzIjogWyJE
...
ZENxQTZRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MC6RC-JPCDE-CXM62-XUZNY-HTKHY-4VWWY"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmlpSHhreHo2THhON1BySDdZ
RUVXMTZPSFJuVHpYeHpJQjdlT3ByeVNkeHd6TGdXa2pQZ0RPamlXY2dxWThJdXUK
ekhoMjd3eGZvcFNjTlhpOEFRVWxkdyJ9"
,
          "signature": "
gRWCGIKt7R32KcN89TkPthVICDvHaYOZMNAkdeT5SMkYHHXnHgfjVnpkPRh2uRoT
rUj9rP1zWPxX_QLC7iQ7PFbmjwyPu2C0hbF8PdrmD9C14jeOpkNuMgfRaJnzFwUZ
vwpuPBgiedGkgWhk2h4s8mDK8EccDJaZN3Q8l1xNfNn-IsDccyiGv0nrKPsBsgRy
X69iE47kSHnnAB3ez5fPsNNzvUW2Kon-LPDDkunaBREu5UP-Zds63xawcZMyqgBu
bwQKaFEbn9CnKzu7YoORnDx5Sh65tmahdgxD6xDFkx47RrMfiA6G8VaqLN25OcAj
Uz9zCAlF1Z58Oh6_CyCLWA"
}]}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
    "SignedMasterProfile": {
      "Identifier": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQ0R1kt
Q1BNT0YtQzdQTzMtSFBCREotNFpISFgtM01HVlMiLAogICAgIk1hc3RlclNpZ25h
...
In19fV19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnFkbHFiUHd3b1hCb3dGNDdu
ZHhmY2RRVWQ3amwzUUw3VzJHYVlTR2hfcnpZeWx5amE0NVZicExwck8zR21PZWkK
c2xNbGRRUFljTHFCa1l3SFNrcHl6USJ9"
,
            "signature": "
lOnhJvmpyxZI8TaOP2Avxrootd_WLAiiwxqAKIVQSge3MBM-Kn81LG41DKmHt85l
qQ7VbplWY0MNMOxBZxqjXa_IJeHCmq6ilmiZNHjJjaJQqTH0zAb_zh6Qih91WYBf
IlsShXHy5xmjmUqNalJyYTTfBcaRm4Fyztl9K8VHt6iMIoSJmSh4ZuxddbBte-f4
j_6S2cJ7hRXYptnX9eogmS2A-8Jan1cQJ-cxJabPZTzxtZ9S0fqEnsK6OGvGQx1t
aXHUB6kiKHBuXf2Ua3tfs8d0OLgSp47wmCTPLM__NvYB4nU6Yf0n7smgaCz-lakN
V20dKO23960_2GqDgkuy8g"
}]}},
    "Devices": [{
        "Identifier": "MC6RC-JPCDE-CXM62-XUZNY-HTKHY-4VWWY",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUM2UkMt
SlBDREUtQ1hNNjItWFVaTlktSFRLSFktNFZXV1kiLAogICAgIk5hbWVzIjogWyJE
...
ZENxQTZRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
          "signatures": [{
              "header": {
                "kid": "MC6RC-JPCDE-CXM62-XUZNY-HTKHY-4VWWY"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmlpSHhreHo2THhON1BySDdZ
RUVXMTZPSFJuVHpYeHpJQjdlT3ByeVNkeHd6TGdXa2pQZ0RPamlXY2dxWThJdXUK
ekhoMjd3eGZvcFNjTlhpOEFRVWxkdyJ9"
,
              "signature": "
gRWCGIKt7R32KcN89TkPthVICDvHaYOZMNAkdeT5SMkYHHXnHgfjVnpkPRh2uRoT
rUj9rP1zWPxX_QLC7iQ7PFbmjwyPu2C0hbF8PdrmD9C14jeOpkNuMgfRaJnzFwUZ
vwpuPBgiedGkgWhk2h4s8mDK8EccDJaZN3Q8l1xNfNn-IsDccyiGv0nrKPsBsgRy
X69iE47kSHnnAB3ez5fPsNNzvUW2Kon-LPDDkunaBREu5UP-Zds63xawcZMyqgBu
bwQKaFEbn9CnKzu7YoORnDx5Sh65tmahdgxD6xDFkx47RrMfiA6G8VaqLN25OcAj
Uz9zCAlF1Z58Oh6_CyCLWA"
}]}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDRH
WS1DUE1PRi1DN1BPMy1IUEJESi00WkhIWC0zTUdWUyIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
      "signatures": [{
          "header": {
            "kid": "MDOBX-E24X2-NIXRQ-WSKBN-LXH46-VRGNF"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjV4d0hwSmNCVWtCMnNsemRV
NDBMd0ltWEhnQ2U3dEpIZnZRSEFLQmw4RFRLVllaWEFNTm13Vk5PcXEtcFBZR3cK
VlZFWFhwMlRpN0Z6V3owcjhfQkZaUSJ9"
,
          "signature": "
5UKWKh6VDINGksTtEuHjJahinzZAqprVAzXdYY00RT16uKb2pSSgW4-ay3yXVVKM
ZMxFJsFNuYnfyR2OvbS88R0TPEok5iK_Z9Qtf4py2rzQPMqkuleE5rq407ChvIH6
GJnemjfevsmS0JYlDViHBDKkK8uFvs3EjKoWUTkB_GkgSUEG1p3_IO3qi2wGbqRk
xyZEvwVwU51i6Xz1PGimFhmVLF2mhOSmWfThJxelugGy3F-uWxsoPiVKZ5u_sXy5
n1nMPPsp_KgeooZMLjr7wYu9Mmza0vsjxjTh6dpCOlPv2G5htokUniQeX1UUTr1R
WeBTSSP5W7ph2gmpCkfzVg"
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
        "Identifier": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDRH
WS1DUE1PRi1DN1BPMy1IUEJESi00WkhIWC0zTUdWUyIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
          "signatures": [{
              "header": {
                "kid": "MDOBX-E24X2-NIXRQ-WSKBN-LXH46-VRGNF"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjV4d0hwSmNCVWtCMnNsemRV
NDBMd0ltWEhnQ2U3dEpIZnZRSEFLQmw4RFRLVllaWEFNTm13Vk5PcXEtcFBZR3cK
VlZFWFhwMlRpN0Z6V3owcjhfQkZaUSJ9"
,
              "signature": "
5UKWKh6VDINGksTtEuHjJahinzZAqprVAzXdYY00RT16uKb2pSSgW4-ay3yXVVKM
ZMxFJsFNuYnfyR2OvbS88R0TPEok5iK_Z9Qtf4py2rzQPMqkuleE5rq407ChvIH6
GJnemjfevsmS0JYlDViHBDKkK8uFvs3EjKoWUTkB_GkgSUEG1p3_IO3qi2wGbqRk
xyZEvwVwU51i6Xz1PGimFhmVLF2mhOSmWfThJxelugGy3F-uWxsoPiVKZ5u_sXy5
n1nMPPsp_KgeooZMLjr7wYu9Mmza0vsjxjTh6dpCOlPv2G5htokUniQeX1UUTr1R
WeBTSSP5W7ph2gmpCkfzVg"
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
    "Identifier": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
    "Names": ["Default"],
    "Description": "Unknown",
    "DeviceSignatureKey": {
      "UDF": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
          "n": "
wVERGhJluQlEtnf879OmJwwZp9Dcx52xfdaTJaa_Xvizn8IOFx85WpDn5ps8vfKC
PABWAb0vWwV8u4xKVnTywVYfCpEOkCGI8uKHjtAB6dmo5P9VnZtKQwDpodvOHucj
QEFk8-2K90tV0KKdyv6duZ_1ZCEf2IqYucJMICk-95AhOxm9G1c-P3jS8EEb0dQH
h-5_HmRuL0ZA09kB1NbnGZJFs1s59BvaN1K7mrz_r-n7P95taxWOvyMSrWLZ1ijb
rjkxf5F6-C21YBG5waVUTNxkL-Q2POMVfXVwCFKvPt8tsPAwUrUDGn8QCf_cwrok
zYFWG1A6yGjZR6Ro-I_vTQ"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MB2DA-BFHWZ-UM73S-LVBFX-MWPY5-LZPCM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MB2DA-BFHWZ-UM73S-LVBFX-MWPY5-LZPCM",
          "n": "
pPFJe29biA-dfQl1T5S0eitc_WW1oz8F1TIzgzi4pMyw86QALLy_m5OwgsrbmMZi
RuWGTk6XIcAyWlC5HNnJaVD6ouizeUFZsJhmLUQtsgV_QIPoyp4CGq6kF43mfOGN
cBKYMu5vbHBPYTJtQziWDEoqA64OC8GEHZrwtZqjd3y7xmcAyPdt9x5NUqH3o7qk
yiuZU7Hn2TdU930Rgt9iJ9RcQoJHXe60Yb5iwg9CM0u6x8wyIO6uhKXF9QlRGji6
3PiJmNM52kf42Addv2s7iBG3BSuWv02qOVEekUVe0fDbk8B1qBma3AwBiz0Hslog
Rt5-YNV94-KHVhvb3Ym9aQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MA7W7-U6IY2-BVOXG-FDCBK-RNKIQ-U4RTK",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MA7W7-U6IY2-BVOXG-FDCBK-RNKIQ-U4RTK",
          "n": "
4Vx_uzXG0DxkSqE5nNZ85byom3Pp54YYw-LGkPymhAv9XpXm27tl7s206Ftp7b_P
pVwXwsLKOWRRvldkKt_oC30dJ7D73r_jR_VTb3zWZJtbjd5eFF7fOMxBU8W00EHs
6BY8xWMQQ3OS_LHBlJ8VNnDaJEkhcctLfzayoNpWDX1-6F6NPMQOfui9YvK2PYdQ
U2EYoELWnpszZEm0ikQHmxfc2p5mUQNpJ8Ro4gJip8CRYSN-GNj44y5HtHG_WMoq
O70WMtbYDbBhfYzdIX1DilUGym14rFo4FoJ5PFDrC_ArhfIcePHWB7oEpp3WWFwZ
xJuhgY2goCG0YC2lQAUymQ"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFaQzUt
VE1JNDMtWU1IVEotUFhNRFYtTlBFSlItSkxDSUgiLAogICAgIk5hbWVzIjogWyJE
...
ICAgICAgICAgImUiOiAiCkFRQUIifX19fX0"
,
      "signatures": [{
          "header": {
            "kid": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCkMyQ2FsMUhsek1XTDh6UnZu
SllaQUtnVXJzZjhZeTMyTGJwdU5qXzFPY1NwazBtcDNpZU5MaVZPYlFVaG0zaVcK
STZXejhscWdpSUhRYm0zU1lOWFQxQSJ9"
,
          "signature": "
n1uJ8z-7awDo5cU-P9PuHrcMUrrhsRJ0QbvrK5qh02zdjb1HuiotRIwCtbaH7P64
Dda4JFlg_b6dzcXWIzldV7n3Naq7c7JEjXHeA6yooFJ2uDPRztZQPGwuYTpH0eKV
8povvJW5uZhTRnuK4ThyvGIVvY5Ngmb4IMtFw_7TLFvi5iCEKlhxNJgA2H2SHlVB
heSagRttgUaqHpKZdzvpoQsoS0napj9A3jk-C0517pMv_swDRqYDD3Vmz6_Reu4L
2CKsD9X0kMd2QE9FuZPCOi-6SUGVGtG1GplTDfQzyP25jJRAUg0s-IB2f3FP8pf1
HI1G5e0EDigD1z4FfM_Q8g"
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
          "Identifier": "MD4GY-CPMOF-C7PO3-HPBDJ-4ZHHX-3MGVS",
          "SignedData": {
            "unprotected": {
              "dig": "S512"},
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDRH
WS1DUE1PRi1DN1BPMy1IUEJESi00WkhIWC0zTUdWUyIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
            "signatures": [{
                "header": {
                  "kid": "MDOBX-E24X2-NIXRQ-WSKBN-LXH46-VRGNF"},
                "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjV4d0hwSmNCVWtCMnNsemRV
NDBMd0ltWEhnQ2U3dEpIZnZRSEFLQmw4RFRLVllaWEFNTm13Vk5PcXEtcFBZR3cK
VlZFWFhwMlRpN0Z6V3owcjhfQkZaUSJ9"
,
                "signature": "
5UKWKh6VDINGksTtEuHjJahinzZAqprVAzXdYY00RT16uKb2pSSgW4-ay3yXVVKM
ZMxFJsFNuYnfyR2OvbS88R0TPEok5iK_Z9Qtf4py2rzQPMqkuleE5rq407ChvIH6
GJnemjfevsmS0JYlDViHBDKkK8uFvs3EjKoWUTkB_GkgSUEG1p3_IO3qi2wGbqRk
xyZEvwVwU51i6Xz1PGimFhmVLF2mhOSmWfThJxelugGy3F-uWxsoPiVKZ5u_sXy5
n1nMPPsp_KgeooZMLjr7wYu9Mmza0vsjxjTh6dpCOlPv2G5htokUniQeX1UUTr1R
WeBTSSP5W7ph2gmpCkfzVg"
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
      "Identifier": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUQ0
R1ktQ1BNT0YtQzdQTzMtSFBCREotNFpISFgtM01HVlMiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
        "signatures": [{
            "header": {
              "kid": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCndqaTIxTy1EN3lLUUpmUmFH
bWIyNE8xcGN0d1VoNnFwa3R1REJha0VFSkF4SHJaMER5NmhVdEV3NldWX2dnQXEK
Rk5UY0N1bjlQZ3VkZzdpdGduSERWQSJ9"
,
            "signature": "
WRcvytyfpyE_gLfKiAx8nvQI8GeRNbnXqu5tUZNIWvYivvKoPM6AuVHEWXqMAl4d
oUdmmXrGaWF6TIMKBv9pGNJpcR2rgalIWtqrt-UzTeepcZkNvT9f_n53lSH3xT2K
MtrlmZyjk6h0zkZ6COsx7ZGlczuHoCfgS5wVAHJnfq_C0vIUXrfaJyPhzhZIDrwJ
GTEZJLdbu0rCxh8Q0lpg-gbJjMMdgiJEAki6qkx_5LoQDhrvOrSOa3BSVjiN3DAG
KjhuGhlGn1GrME628V_W_IqXjnz9vdE9N3Fdr2p3pthQW29sI3Q-7U4YvxOIi3Qo
ttOm5g-FFMWC60dxXr0Pqw"
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
        "Identifier": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUQ0
R1ktQ1BNT0YtQzdQTzMtSFBCREotNFpISFgtM01HVlMiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCndqaTIxTy1EN3lLUUpmUmFH
bWIyNE8xcGN0d1VoNnFwa3R1REJha0VFSkF4SHJaMER5NmhVdEV3NldWX2dnQXEK
Rk5UY0N1bjlQZ3VkZzdpdGduSERWQSJ9"
,
              "signature": "
WRcvytyfpyE_gLfKiAx8nvQI8GeRNbnXqu5tUZNIWvYivvKoPM6AuVHEWXqMAl4d
oUdmmXrGaWF6TIMKBv9pGNJpcR2rgalIWtqrt-UzTeepcZkNvT9f_n53lSH3xT2K
MtrlmZyjk6h0zkZ6COsx7ZGlczuHoCfgS5wVAHJnfq_C0vIUXrfaJyPhzhZIDrwJ
GTEZJLdbu0rCxh8Q0lpg-gbJjMMdgiJEAki6qkx_5LoQDhrvOrSOa3BSVjiN3DAG
KjhuGhlGn1GrME628V_W_IqXjnz9vdE9N3Fdr2p3pthQW29sI3Q-7U4YvxOIi3Qo
ttOm5g-FFMWC60dxXr0Pqw"
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
        "Identifier": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUQ0
R1ktQ1BNT0YtQzdQTzMtSFBCREotNFpISFgtM01HVlMiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCndqaTIxTy1EN3lLUUpmUmFH
bWIyNE8xcGN0d1VoNnFwa3R1REJha0VFSkF4SHJaMER5NmhVdEV3NldWX2dnQXEK
Rk5UY0N1bjlQZ3VkZzdpdGduSERWQSJ9"
,
              "signature": "
WRcvytyfpyE_gLfKiAx8nvQI8GeRNbnXqu5tUZNIWvYivvKoPM6AuVHEWXqMAl4d
oUdmmXrGaWF6TIMKBv9pGNJpcR2rgalIWtqrt-UzTeepcZkNvT9f_n53lSH3xT2K
MtrlmZyjk6h0zkZ6COsx7ZGlczuHoCfgS5wVAHJnfq_C0vIUXrfaJyPhzhZIDrwJ
GTEZJLdbu0rCxh8Q0lpg-gbJjMMdgiJEAki6qkx_5LoQDhrvOrSOa3BSVjiN3DAG
KjhuGhlGn1GrME628V_W_IqXjnz9vdE9N3Fdr2p3pthQW29sI3Q-7U4YvxOIi3Qo
ttOm5g-FFMWC60dxXr0Pqw"
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
      "Identifier": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFaQzUtVE1JNDMtWU1IVEotUFhNRFYtTlBFSlItSkxD
...
CmdZNTdqbEgxemVqWVNvclZ6cllYaEEifV19fX19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MDOBX-E24X2-NIXRQ-WSKBN-LXH46-VRGNF"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCktEUDJ3TGZpVndiZWxxdThv
cUJaLVdHZWt3eVk4b0R3N2h3UWdaWVoxQlJDSk1RVndKZTB1Q3kyamJFSDJFYTYK
M2VvRXJ5NXRNSFJHeE5xU3UxbHB4dyJ9"
,
            "signature": "
CI83LYHd6lxb5SeC3z5WfeiNH8CsknswHZNgfqepDopbTwUW8F2j6pu9TIZ0FDHj
t8Ef8zJt6AygTV7hExtEvlW5o5tBml3S6-7KNCryvcd6qcAtVRoNo7cR1iWRyIrx
0bRD2e5WgK7T6qW-hkzM-aoE1t1upZng-oHK1AVhwcB2oqTpw6bIP7EgbNkPG2xj
4ZEWYXZOPJyOYLmH-TXcQ7rJsycNMiwwJwhSL4_ILwiJ9bPFaqtcv78yfZ7mgeSf
4OlUwQ2te7w_AnK9K0Fqc2bjaxnxCoNsVo_vWQX7ktzZyo_53hd7EukmnKtm0ABY
_n6d4A773IE2A6xmctbT2w"
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
    "DeviceID": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MAZC5-TMI43-YMHTJ-PXMDV-NPEJR-JLCIH",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFaQzUtVE1JNDMtWU1IVEotUFhNRFYtTlBFSlItSkxD
...
CmdZNTdqbEgxemVqWVNvclZ6cllYaEEifV19fX19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MDOBX-E24X2-NIXRQ-WSKBN-LXH46-VRGNF"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCktEUDJ3TGZpVndiZWxxdThv
cUJaLVdHZWt3eVk4b0R3N2h3UWdaWVoxQlJDSk1RVndKZTB1Q3kyamJFSDJFYTYK
M2VvRXJ5NXRNSFJHeE5xU3UxbHB4dyJ9"
,
            "signature": "
CI83LYHd6lxb5SeC3z5WfeiNH8CsknswHZNgfqepDopbTwUW8F2j6pu9TIZ0FDHj
t8Ef8zJt6AygTV7hExtEvlW5o5tBml3S6-7KNCryvcd6qcAtVRoNo7cR1iWRyIrx
0bRD2e5WgK7T6qW-hkzM-aoE1t1upZng-oHK1AVhwcB2oqTpw6bIP7EgbNkPG2xj
4ZEWYXZOPJyOYLmH-TXcQ7rJsycNMiwwJwhSL4_ILwiJ9bPFaqtcv78yfZ7mgeSf
4OlUwQ2te7w_AnK9K0Fqc2bjaxnxCoNsVo_vWQX7ktzZyo_53hd7EukmnKtm0ABY
_n6d4A773IE2A6xmctbT2w"
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
    "Identifier": "MBX6T-3G6YY-57VFN-FNENK-S5S7M-WUNYY-A"}}
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


