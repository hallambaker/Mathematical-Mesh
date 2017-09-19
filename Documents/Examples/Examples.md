
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
Date: Mon 18 Sep 2017 05:07:25
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
    "Identifier": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
    "MasterSignatureKey": {
      "UDF": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
      "X509Certificate": "
MIIFXDCCBESgAwIBAgIQcL7ySTJG8wNHO591_XBcPzANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQzJUNy1KTkNJNS1ZTUFXNC0zWEhZTS1TQkdKTi1VTUY0QzAe
...
V3vWAmk5gx_bslvn62cX7-nXYHgNPhVzgsGZzyQ7xoQ"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
          "n": "
0stVVlOfh0EjLAxxjUA3QqBf_YPgr_KpuwoeD0RFjhSGwVV-Sg1iXfW3vnzh9G45
VH0zf73WzlioIyzAKn_SX8K4VwqP0ruvRxh7tUjx6s9-eqTF_QLoGVy_yiGohjAh
TomN4RHKNzU6aXhAgQijFVDNhr72iSMxcQbR6-w2fowMhRWvuozgkWjEf87kaaU3
_D_4J3STB0Q_q8YmvHQzkcK9J44b0N3ElEGrpa_yztR2sDgZKF33wLoJIQqxnfKT
y2e5_zSkiitZVbdrrOBacf83tDayUnIqzi8tOObVl4PGmgAcDmsFXh5EyUlDDntW
7UoUvnXhO2vid80VNaKQBQ"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MAL7U-IDBDI-R6BYF-SLY3J-MCTRX-HHTTG",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQEG_YIz9AHtxBPygAWwXd1TANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQzJUNy1KTkNJNS1ZTUFXNC0zWEhZTS1TQkdKTi1VTUY0QzAe
...
pNfaAH5VutN_byCXIJcOO7RaG4_5Q1DJ9fg509R4YOA"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MAL7U-IDBDI-R6BYF-SLY3J-MCTRX-HHTTG",
            "n": "
3pbzrDX60CicvkVauO18cilQgX49H_cABCw0kVTgR0m0bz7GX_cRXOEXRWrll6OA
ZJ3O_S5iWXT7ftschA_hHualfNtMCb1p3RmjpWKVNd24-Nk_V_miIej0xONCbWnc
LZW1uFLvHK4sj6LdlyVwri9NLzQF2rREXVtnQztl6HOpLEBbGGbYiXg1wyyfvCtt
aB1_YtMU5dvSupEGym1OLv5vj24Y7lY1CKQHWycSrwCoEVMsZvypqKftuwXZzY8f
4WTX3G1qZiU9Ay5OdUnTxoRhWUIWkC3wmRO5rNWhJvJv-3zU4ObKKAobz4qPBqbH
ddhkdoWZGBE9AGVXtuShXQ"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MA7XV-ZOTDR-TXEDM-O2QP7-F7JTG-FGFFE",
        "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAI04UIvLHhp0RDWWNNAjKW0wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUMyVDctSk5DSTUtWU1BVzQtM1hIWU0tU0JHSk4tVU1GNEMw
...
-ACINNDOx-GsXY0-b8HsRzfdTHjW-r982VbEv06ZUz_E"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MA7XV-ZOTDR-TXEDM-O2QP7-F7JTG-FGFFE",
            "n": "
z0GLRVQtom0B8eH-mYziccDixsLQeK8VUPENOb5jAF0QnOVITe1I-oq3wfotxxa6
_ehMLGUMPjSotKhEyjW7iFrkH9VCIPGMppqqU3sEWWzLvAAjdbOzAqTKWpjvXTfy
SDZO6f5pAcOQNVqoIE3lfrBfcB8wH_cciuhaxUp92E06FKyX5W76M7S2csGIaDPL
rDzJQFBNwuVLEOQ1CU3TlwNz99JL-jgBKCyt3cZBNM1yozJQDCiZMp6ffuR_bdcc
W8Y3sCzFIjd4Y4CskqjiYdij1lHcA_ppmAUKAbHwH5K3WVpVoXJGEg17GBAWtT1F
HyAvPtEnXvExYUEtcugaoQ"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUMyVDct
Sk5DSTUtWU1BVzQtM1hIWU0tU0JHSk4tVU1GNEMiLAogICAgIk1hc3RlclNpZ25h
...
In19fV19fQ"
,
      "signatures": [{
          "header": {
            "kid": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmZVbDB3d3dHamZsSFNzdGVz
MjcwNG4tOVJMNURUTHdrSmYxdzJuQTh2SnFYNUFZSGpYMXNCcDlObTJhUl9zbHEK
QVZGbk5SRDl1dzRmbFJGQVF1NjlBdyJ9"
,
          "signature": "
Ij6qkuwdSEbllNnCh-Lbca9BwEBxOparME-tu0IDgJz9TwvAVLPSTyPnLA8oPxpU
YcSnHwWbj_1A3OMdYAfOZk6do4uNirrCc7l4meUvH8psl3t5avZtRzRu6LXkIuI9
myZzef2C3UvfIzdW3E26tzRHUKo3ytyHiurH_hbHkTAReLQA18DSsTv3qMtTcKgF
BovmL9BLLZlTT7qWt1mibEMJc4iG4RjkFnBResR6tB1Qq_cLYYLP1wB8H3LjBw5q
2KEXk-KZrXo1jBYnCed0qJX8axpI7fzLpCZIjMZJ_fz4gNXuNUaYpfqkiHFID41_
yruKcfxntvzVPQ3e8aVb0A"
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
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFVNjMt
WUJFSFQtRDJYUlYtUjJDRFQtRjMySFgtTEVXRFQiLAogICAgIk5hbWVzIjogWyJE
...
ZW9ESjNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
    "signatures": [{
        "header": {
          "kid": "MAU63-YBEHT-D2XRV-R2CDT-F32HX-LEWDT"},
        "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm81TjhEQnpYbXAydlRZUGYy
cFdQN2dkdm9iZmpNNktsTEpFTjhyN3BsUGRPZjVQeHhVT3BvbEE2eWxTbnNXc0gK
dWVHSFJTNUdZLXFFWHhPcUhZSWZqUSJ9"
,
        "signature": "
MngvWlH1-_wpaiQ9vy9oYymY7HWY6lnyMqw9VvjAHyCOGK0la7WJTL74l4J5R1Ac
C3Hz2FH77gWraXksvEQICcUmfQA7L8RQ54yZ7Ns3VDutIjA6Mx6v-1LERCCUF3wJ
px85F7dgsS5NindawFAStOTnEq8zYHTi91tsKM0dGvELpXVuJqBA7DxK1qzLP21I
BhhCiiiB3zLMfMieBOZYlUshw8_bJi2cTpcpk4qf8ysAihZiCbVzRs6GKwxCY1qO
lCUkAqBwhALnNymGuhBNChwxGB0dJTtxtl_IghMqiJTdP2d1iQnBwQvu904kLTIQ
-nWESV29mAB_JaecLWSwBw"
}]}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAU63-YBEHT-D2XRV-R2CDT-F32HX-LEWDT",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFVNjMt
WUJFSFQtRDJYUlYtUjJDRFQtRjMySFgtTEVXRFQiLAogICAgIk5hbWVzIjogWyJE
...
ZW9ESjNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MAU63-YBEHT-D2XRV-R2CDT-F32HX-LEWDT"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm81TjhEQnpYbXAydlRZUGYy
cFdQN2dkdm9iZmpNNktsTEpFTjhyN3BsUGRPZjVQeHhVT3BvbEE2eWxTbnNXc0gK
dWVHSFJTNUdZLXFFWHhPcUhZSWZqUSJ9"
,
          "signature": "
MngvWlH1-_wpaiQ9vy9oYymY7HWY6lnyMqw9VvjAHyCOGK0la7WJTL74l4J5R1Ac
C3Hz2FH77gWraXksvEQICcUmfQA7L8RQ54yZ7Ns3VDutIjA6Mx6v-1LERCCUF3wJ
px85F7dgsS5NindawFAStOTnEq8zYHTi91tsKM0dGvELpXVuJqBA7DxK1qzLP21I
BhhCiiiB3zLMfMieBOZYlUshw8_bJi2cTpcpk4qf8ysAihZiCbVzRs6GKwxCY1qO
lCUkAqBwhALnNymGuhBNChwxGB0dJTtxtl_IghMqiJTdP2d1iQnBwQvu904kLTIQ
-nWESV29mAB_JaecLWSwBw"
}]}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
    "SignedMasterProfile": {
      "Identifier": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUMyVDct
Sk5DSTUtWU1BVzQtM1hIWU0tU0JHSk4tVU1GNEMiLAogICAgIk1hc3RlclNpZ25h
...
In19fV19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmZVbDB3d3dHamZsSFNzdGVz
MjcwNG4tOVJMNURUTHdrSmYxdzJuQTh2SnFYNUFZSGpYMXNCcDlObTJhUl9zbHEK
QVZGbk5SRDl1dzRmbFJGQVF1NjlBdyJ9"
,
            "signature": "
Ij6qkuwdSEbllNnCh-Lbca9BwEBxOparME-tu0IDgJz9TwvAVLPSTyPnLA8oPxpU
YcSnHwWbj_1A3OMdYAfOZk6do4uNirrCc7l4meUvH8psl3t5avZtRzRu6LXkIuI9
myZzef2C3UvfIzdW3E26tzRHUKo3ytyHiurH_hbHkTAReLQA18DSsTv3qMtTcKgF
BovmL9BLLZlTT7qWt1mibEMJc4iG4RjkFnBResR6tB1Qq_cLYYLP1wB8H3LjBw5q
2KEXk-KZrXo1jBYnCed0qJX8axpI7fzLpCZIjMZJ_fz4gNXuNUaYpfqkiHFID41_
yruKcfxntvzVPQ3e8aVb0A"
}]}},
    "Devices": [{
        "Identifier": "MAU63-YBEHT-D2XRV-R2CDT-F32HX-LEWDT",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFVNjMt
WUJFSFQtRDJYUlYtUjJDRFQtRjMySFgtTEVXRFQiLAogICAgIk5hbWVzIjogWyJE
...
ZW9ESjNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
          "signatures": [{
              "header": {
                "kid": "MAU63-YBEHT-D2XRV-R2CDT-F32HX-LEWDT"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm81TjhEQnpYbXAydlRZUGYy
cFdQN2dkdm9iZmpNNktsTEpFTjhyN3BsUGRPZjVQeHhVT3BvbEE2eWxTbnNXc0gK
dWVHSFJTNUdZLXFFWHhPcUhZSWZqUSJ9"
,
              "signature": "
MngvWlH1-_wpaiQ9vy9oYymY7HWY6lnyMqw9VvjAHyCOGK0la7WJTL74l4J5R1Ac
C3Hz2FH77gWraXksvEQICcUmfQA7L8RQ54yZ7Ns3VDutIjA6Mx6v-1LERCCUF3wJ
px85F7dgsS5NindawFAStOTnEq8zYHTi91tsKM0dGvELpXVuJqBA7DxK1qzLP21I
BhhCiiiB3zLMfMieBOZYlUshw8_bJi2cTpcpk4qf8ysAihZiCbVzRs6GKwxCY1qO
lCUkAqBwhALnNymGuhBNChwxGB0dJTtxtl_IghMqiJTdP2d1iQnBwQvu904kLTIQ
-nWESV29mAB_JaecLWSwBw"
}]}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQzJU
Ny1KTkNJNS1ZTUFXNC0zWEhZTS1TQkdKTi1VTUY0QyIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
      "signatures": [{
          "header": {
            "kid": "MA7XV-ZOTDR-TXEDM-O2QP7-F7JTG-FGFFE"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnhHUlFPY21qdGtWbHhMdTFh
RTJjS1JKN2k4MWN0NmQ4MTZGSTZxRHVOS3RGbm9MYjRybDhoM2NvSS1neGI5aEMK
V3ExY3B6cU81SHJDMHRNdDlvRk1CQSJ9"
,
          "signature": "
D4lfCt5MEKb-1xB4KFC62ZWZaiHnOLgiQOxGhUkuhx-hGnP6XUkyMBjM2Xn2ggeW
HTo7aa-SoeA8pEvCsX1udicW7uRqJPxUf4_fC4LxVhJko9pWkPs2BnuBcTlYjzKL
QuAx8Uby34lk_f2260R6gx9smxEAFuq-hE3KpPWOfa0_wDZnJ2T_LljDoDdThpef
fXuWfX9ehO7jGEObOWOImLb9anLrciLNIkxDgjs_urcAdsmciMBODIn5OtaUbxiU
zzRaOlofB3PFCWEg8bnJ4g9CsMbmUC0TfKAwtyvto5aD0z_t5JmKCyjrpeg6PlkV
NjmUpXfqwSE_E8Zmwv5PsQ"
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
        "Identifier": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQzJU
Ny1KTkNJNS1ZTUFXNC0zWEhZTS1TQkdKTi1VTUY0QyIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
          "signatures": [{
              "header": {
                "kid": "MA7XV-ZOTDR-TXEDM-O2QP7-F7JTG-FGFFE"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnhHUlFPY21qdGtWbHhMdTFh
RTJjS1JKN2k4MWN0NmQ4MTZGSTZxRHVOS3RGbm9MYjRybDhoM2NvSS1neGI5aEMK
V3ExY3B6cU81SHJDMHRNdDlvRk1CQSJ9"
,
              "signature": "
D4lfCt5MEKb-1xB4KFC62ZWZaiHnOLgiQOxGhUkuhx-hGnP6XUkyMBjM2Xn2ggeW
HTo7aa-SoeA8pEvCsX1udicW7uRqJPxUf4_fC4LxVhJko9pWkPs2BnuBcTlYjzKL
QuAx8Uby34lk_f2260R6gx9smxEAFuq-hE3KpPWOfa0_wDZnJ2T_LljDoDdThpef
fXuWfX9ehO7jGEObOWOImLb9anLrciLNIkxDgjs_urcAdsmciMBODIn5OtaUbxiU
zzRaOlofB3PFCWEg8bnJ4g9CsMbmUC0TfKAwtyvto5aD0z_t5JmKCyjrpeg6PlkV
NjmUpXfqwSE_E8Zmwv5PsQ"
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
    "Identifier": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
    "Names": ["Default"],
    "Description": "Unknown",
    "DeviceSignatureKey": {
      "UDF": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
          "n": "
zqnfQp2q3wV31KUAMuvMkLTZ29SfqKuIIeGKWhrTMDoMKoj_NKqBaSmXh5ggsl2_
9IkhaddFKwzJkYokxII5PQfPio9E8Kwp1roVOVhSRjVvQgIFTu43HNOL5EtO6ofN
iHbjtE8VhW4f827q_ViU3zfoRdyMRV_RYb8OV5bIFzWeKMjm8tYO_QbMZL5VYjJ_
w5exDxq_-3l8tXA84RggCDWWVg-zXkmfOYVyV0T5zW9vUe4SFQQHBWtBy2nVh1-i
zNDPdJwgixh7Ey8vB3Wd_QcxFmoLZeDrGOIqZ4bVwC3wQdwb26GV3jJH30sQ46pw
w5nSX-oCnKLFtBORIPOE2Q"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MAMIP-V4HJY-EV2VR-2TL6C-22VZU-QAZT4",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAMIP-V4HJY-EV2VR-2TL6C-22VZU-QAZT4",
          "n": "
2HzzkEgoaqLyEf7MsykSt8l9rVUEgjNc9QJSw6-_kzKrOmmJaHS0KUWUKGR6G-Ps
QvG6TBAnGYzwihwCz8OoTqvwIXQGeI_4Wg_jwSj5qMWXgb2bIskbnQxJBxNMmLU_
i7-EnuqYwwvy2DBKMz4p4-dJaiISPKZUXnrJQq6jotdMniAuVMWFMMif2Y3-DNGn
I7yBo3_KPmzqRID1EQJxWU0YffPo2bS8lcJTeiIQeViRtPpN7rEyvSVmoWirG_XY
LijjQnpZUdC_UZNTkdFkpZkJU-_IcWbegmEoxTbXgOdeGNy1SgEjNTUqUoiWKHk5
o__IzuqAkdXlrxRYsJu4iQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MBZL4-6R2G4-3VA6V-XNMJS-B5ZAU-XZ4KZ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBZL4-6R2G4-3VA6V-XNMJS-B5ZAU-XZ4KZ",
          "n": "
3PwWFh0nziWOWohD1dWQSjQHzS6MicVxnjOiyR0W5-_Xxz53R1phuEiU52o9epSx
vFVmYsf7_9qjKyESE19WUR6b-XeOhjnukV0V-7wRFvO5EAyr52WB49Kr3W5rQvGZ
ETGVVlL0ZtLo9FkDrqca0bcNK1yL8sg4wKBOxKe3Lt-f2W-WLGT0QkPHIfuafeci
WGVQSvFmtTTiK1L-Yfx9aqc8hxXFfOqVKnTHNIx9rYyQvw9XVQ6dSun-ljf8e1wP
Im7yriOyztMr0w6MHMASEDkdyqVRddUjyc_EJTdIHhHuoGkhjWfSnsMrfgDgyNe1
FDNY1xMja2Kol7ZSyWLuCQ"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURWSUst
RzRQUUItU1RHTVYtMllQNEYtUlNHNDQtUlVSQ1EiLAogICAgIk5hbWVzIjogWyJE
...
ICAgICAgICAgImUiOiAiCkFRQUIifX19fX0"
,
      "signatures": [{
          "header": {
            "kid": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmRzLXpSNzV0TWtYTld4UG1X
RURBMU5jM3hUcGJhWWNDLWxCWFRUNXhNZDR0d2tMc1hsbXdlZ0N0bzVVTWFvem0K
U25KMFF1d2M2azBLSGh1ak9QNzJoZyJ9"
,
          "signature": "
K5kWHWdOOK-cCWg-QbEiKPpNG5hexBHFrJNFh14g_LoFsUZQ8Jsa8hc0wQqD7S8E
qA3i8EEjYj0V-jxeEHNQPObpocy98Sgx3iV55nIH3eX9ccvdWE7pcYIwJ2kx5WNa
n7RmmviaFB-I_7vZ-WG7Mdr9LF6nlSSLrGUG1rh8cY558QCpxt1Fvx1qXTG9Upf6
fTsHG0WyAEnWtTGqd8VqWysD7O24QFlPWOSHS3OwuHZ-aRyt0Wfl3GgtIt2kLXWg
Vn8jZpbZzDgbjKhK4AsyLWopVOT_Tbs7wNGMwCwdKjyb56rKXCBJ50MePeoRFH3J
xxsjlZrC8wMTbIRNOI7krg"
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
          "Identifier": "MC2T7-JNCI5-YMAW4-3XHYM-SBGJN-UMF4C",
          "SignedData": {
            "unprotected": {
              "dig": "S512"},
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQzJU
Ny1KTkNJNS1ZTUFXNC0zWEhZTS1TQkdKTi1VTUY0QyIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
            "signatures": [{
                "header": {
                  "kid": "MA7XV-ZOTDR-TXEDM-O2QP7-F7JTG-FGFFE"},
                "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnhHUlFPY21qdGtWbHhMdTFh
RTJjS1JKN2k4MWN0NmQ4MTZGSTZxRHVOS3RGbm9MYjRybDhoM2NvSS1neGI5aEMK
V3ExY3B6cU81SHJDMHRNdDlvRk1CQSJ9"
,
                "signature": "
D4lfCt5MEKb-1xB4KFC62ZWZaiHnOLgiQOxGhUkuhx-hGnP6XUkyMBjM2Xn2ggeW
HTo7aa-SoeA8pEvCsX1udicW7uRqJPxUf4_fC4LxVhJko9pWkPs2BnuBcTlYjzKL
QuAx8Uby34lk_f2260R6gx9smxEAFuq-hE3KpPWOfa0_wDZnJ2T_LljDoDdThpef
fXuWfX9ehO7jGEObOWOImLb9anLrciLNIkxDgjs_urcAdsmciMBODIn5OtaUbxiU
zzRaOlofB3PFCWEg8bnJ4g9CsMbmUC0TfKAwtyvto5aD0z_t5JmKCyjrpeg6PlkV
NjmUpXfqwSE_E8Zmwv5PsQ"
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
      "Identifier": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUMy
VDctSk5DSTUtWU1BVzQtM1hIWU0tU0JHSk4tVU1GNEMiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
        "signatures": [{
            "header": {
              "kid": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmZ1T0h4N3BWM19lU2Q4UXh5
bUgyQWFoWDR0a3VFM0ZjSHNzeE1LdVFDTDd3THFYeXgtZi1TZmloa1dRS3RVckYK
VGRtcWZUTHRrMFAxS2tQZmZDbElnQSJ9"
,
            "signature": "
vsMjgztTeC9TK11ZSa8at7hlQbD51g0ImBypkGqwEvWOO6J7NSaR7kPtgukzIS75
Bii8coRZjSFBlieMWUj6pWp5Ge70wx7S8BBvqFol5YRqmqxnek9gPmxRWrPnPX8_
nBytoATRY-sztfA1teN4fkKAp5yJxV9tLqYDuZlmw6jPZ_OpRKWQ16IOpHPdut_q
8IAdAuaerVXpk4DN5sqSRUMdNdW27DXwk3Y8crdj2UNpbQIhpBCgZMA7Fn6elmDN
rPHpDgRjQf-qAqpIIU_AGmylUk4M8I1eeuvf_-U0jxDG0FDM_WBJ58RUL0yFP-oM
NH6SyZFFszHl--u1SHO3kA"
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
        "Identifier": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUMy
VDctSk5DSTUtWU1BVzQtM1hIWU0tU0JHSk4tVU1GNEMiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmZ1T0h4N3BWM19lU2Q4UXh5
bUgyQWFoWDR0a3VFM0ZjSHNzeE1LdVFDTDd3THFYeXgtZi1TZmloa1dRS3RVckYK
VGRtcWZUTHRrMFAxS2tQZmZDbElnQSJ9"
,
              "signature": "
vsMjgztTeC9TK11ZSa8at7hlQbD51g0ImBypkGqwEvWOO6J7NSaR7kPtgukzIS75
Bii8coRZjSFBlieMWUj6pWp5Ge70wx7S8BBvqFol5YRqmqxnek9gPmxRWrPnPX8_
nBytoATRY-sztfA1teN4fkKAp5yJxV9tLqYDuZlmw6jPZ_OpRKWQ16IOpHPdut_q
8IAdAuaerVXpk4DN5sqSRUMdNdW27DXwk3Y8crdj2UNpbQIhpBCgZMA7Fn6elmDN
rPHpDgRjQf-qAqpIIU_AGmylUk4M8I1eeuvf_-U0jxDG0FDM_WBJ58RUL0yFP-oM
NH6SyZFFszHl--u1SHO3kA"
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
        "Identifier": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUMy
VDctSk5DSTUtWU1BVzQtM1hIWU0tU0JHSk4tVU1GNEMiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmZ1T0h4N3BWM19lU2Q4UXh5
bUgyQWFoWDR0a3VFM0ZjSHNzeE1LdVFDTDd3THFYeXgtZi1TZmloa1dRS3RVckYK
VGRtcWZUTHRrMFAxS2tQZmZDbElnQSJ9"
,
              "signature": "
vsMjgztTeC9TK11ZSa8at7hlQbD51g0ImBypkGqwEvWOO6J7NSaR7kPtgukzIS75
Bii8coRZjSFBlieMWUj6pWp5Ge70wx7S8BBvqFol5YRqmqxnek9gPmxRWrPnPX8_
nBytoATRY-sztfA1teN4fkKAp5yJxV9tLqYDuZlmw6jPZ_OpRKWQ16IOpHPdut_q
8IAdAuaerVXpk4DN5sqSRUMdNdW27DXwk3Y8crdj2UNpbQIhpBCgZMA7Fn6elmDN
rPHpDgRjQf-qAqpIIU_AGmylUk4M8I1eeuvf_-U0jxDG0FDM_WBJ58RUL0yFP-oM
NH6SyZFFszHl--u1SHO3kA"
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
      "Identifier": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTURWSUstRzRQUUItU1RHTVYtMllQNEYtUlNHNDQtUlVS
...
Cm9HYzJwWlhfbHFibHZxemhhSzBMNFEifV19fX19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MA7XV-ZOTDR-TXEDM-O2QP7-F7JTG-FGFFE"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClRtQzNKakpZLS1oQjdRT0Fp
bFg0WGtlQ3ZoVG02MEkwM3F0OVlKdkEwVUVRb0Y3X2M0ems2UnZoSWZGVm02NDIK
bmM5b1k2Y3FIV0ZLdnBwZlJobm9qZyJ9"
,
            "signature": "
DMNIqoQOKRFCaJTjHcR72StoWTqsaL3Kx1tL3P0QjPsI1sfo6DQPTQu6RP5ZNksm
UF60KHGheopm-RvlxZjZ5qfMwWdCmmiCzAj-yrQoLcTEkq523mzDqZNc03IME6jn
MDE2_oGkoa5FyXeQAtPEsbB8n4Ib2FE7nkcehGufiP5RiKi0dxDJaMJaEiSfkIvf
XjUfypzW6nk_ALwi898icIXBxNatlUwgiikrchdu3PcG1c-dKndQqsd2Z74_vjKq
hUeyTiZT33CMEMt74Gi8dX4C78W2QxApUdGsv6EzWZmL9Jjr_p2neerfZfuTik8C
Xp1aigh1A0uyY30RbEwSQw"
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
    "DeviceID": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MDVIK-G4PQB-STGMV-2YP4F-RSG44-RURCQ",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTURWSUstRzRQUUItU1RHTVYtMllQNEYtUlNHNDQtUlVS
...
Cm9HYzJwWlhfbHFibHZxemhhSzBMNFEifV19fX19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MA7XV-ZOTDR-TXEDM-O2QP7-F7JTG-FGFFE"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClRtQzNKakpZLS1oQjdRT0Fp
bFg0WGtlQ3ZoVG02MEkwM3F0OVlKdkEwVUVRb0Y3X2M0ems2UnZoSWZGVm02NDIK
bmM5b1k2Y3FIV0ZLdnBwZlJobm9qZyJ9"
,
            "signature": "
DMNIqoQOKRFCaJTjHcR72StoWTqsaL3Kx1tL3P0QjPsI1sfo6DQPTQu6RP5ZNksm
UF60KHGheopm-RvlxZjZ5qfMwWdCmmiCzAj-yrQoLcTEkq523mzDqZNc03IME6jn
MDE2_oGkoa5FyXeQAtPEsbB8n4Ib2FE7nkcehGufiP5RiKi0dxDJaMJaEiSfkIvf
XjUfypzW6nk_ALwi898icIXBxNatlUwgiikrchdu3PcG1c-dKndQqsd2Z74_vjKq
hUeyTiZT33CMEMt74Gi8dX4C78W2QxApUdGsv6EzWZmL9Jjr_p2neerfZfuTik8C
Xp1aigh1A0uyY30RbEwSQw"
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


