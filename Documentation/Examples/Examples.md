
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
Date: Fri 27 May 2016 06:11:39
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
    "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
    "MasterSignatureKey": {
      "UDF": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAIaXs3UNqTyMhpr4XpXzLPEwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJaRDMtSzZOTjYtUE5DS1gtVlU1MkgtQUhOQ00tN1gzMkYw
...
Qh1fhJYhjTgmNsIBwKtsnSG4LMIx-Tpem4DIdI7okK19QZ7jMS7tKNgJIg",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
          "n": "
0NrwR-EkaHk-plHGTNqXMTwTbB88DP5tFwLMJLSGm3JHWeiz59WrnLTLWki_J2lD
49oT9EF7W79ye00vXbjFyDV9pMzlaHQ95o6XcU690-4QsEcNunPP6jC8FsV-TRKx
N_c65VD22sJq5yKWQEGME_9wwtI17eewrMnFwgjJyU9A1QMl7hAxr6ORaPJuN3eW
uh8mwtL4kMNnYS6KiNPP2h0WnyvX-aBOGdZyumZFg0s80Wh4wfDlIeLUT48dv4me
Eu2mVR2atxBNw7S-R67J_lZQNemsbwc7y1zzjAM0kmtRPQw-ZVGcKw-y0EKshD7C
lWGmxZ4nR6GdfRmR1dKSdw",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MBEUK-6MVVF-WHPAN-QGO7O-745A5-IACYW",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQNJPuq1j87xY9BqO2NHTfEjANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQlpEMy1LNk5ONi1QTkNLWC1WVTUySC1BSE5DTS03WDMyRjAe
...
iFnqSACrhGr7BdeJLZVEXwlm_jdo7lCzRNlC0xHTm9M8wA140m145kcZ",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBEUK-6MVVF-WHPAN-QGO7O-745A5-IACYW",
            "n": "
zGE4Wd1sskznGR_FBttGk24LrnU0LGbGlL8g6pf9udL7FrwpU-_2gOKeThCSJRe2
3erxiIl8Zp72I96HJOmwGloJt-HY2oZhRM5PWbVjgjM5wog4MeuL8nS5xEiaLKaW
hu-WAS_9rCm5tn33uQXgSYPxOmje5YLMh4dmyjBmerRqEkNLmobCtqUJJEMr_RKT
OR5G-0QORIMSHZmtjMcW-9pfuOONqC6QttAoHV0AmAGaS70FfrY5s8093D8Xa3_C
s1DJbYy_-jL0xK3iz9bxQuIEHCn1lNMm2wJ7IGW4_YezvgH6bb7Wo44nKLMowN3r
ey8FPek9FirzRNs1UWuUyQ",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MBU7B-SX6B6-5444G-M2W76-PH3EA-UNXTT",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQTU13KxKF5nrKVrm2hEDbKjANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQlpEMy1LNk5ONi1QTkNLWC1WVTUySC1BSE5DTS03WDMyRjAe
...
qxWhekRhCYqW5h-i561IF84T5FCSUNWaeYCcby6O99Ma7cm_cmd5Vg0Y",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBU7B-SX6B6-5444G-M2W76-PH3EA-UNXTT",
            "n": "
7qhu4lh62ne-rWaq3J2UNA3Sf9KyVInpCtteDax87JxAGzcklcrv0deMOx0XAyHw
T-tfa6PdCioNkfPGwCPDdsOvrlui4LBH27vmJe6ejtA58JvIZ8SjGaUB6uHJf3Pj
rGOIbXtpHO_F7zYLT8sz5qhbZHxLVgoFkF7BQlB4pMcBQBBmfcBIJgZtgfriFXRm
l3CqBUyiWLnZKZ4s4Mm8hSb1L2fmnCxDIrVnags62BgyiNwVSjmFyycjFs2IiyKy
5lR_O9yDNUchMz8oI-fNl3DXkZfsDp-anshoQVED_Zxn0mL5sgGvq3e8-kImdLH6
kiwfeVbDN70bI1KGVaZ0wQ",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJaRDMtSzZOTjYtUE5DS1gt
VlU1MkgtQUhOQ00tN1gzMkYifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJaRDMt
SzZOTjYtUE5DS1gtVlU1MkgtQUhOQ00tN1gzMkYiLAogICAgIk1hc3RlclNpZ25h
...
QVFBQiJ9fX1dfX0",
      "signature": "
KUzTu53g8VTFHIWykCk-TwFEW526isYzogshXbvWjJgjGi0ypFGPtj9vXRRGowF1
2BkEFXo2zJ507sDbv5JB6efb4QlnEj2mCetFT2zaTV3xdTQOhetO08IEG66u4h5S
dfFwGtLZnlRSz5pEvdhrvKdvvhYTl4grjaIvQVGOQRzwXGpQDF84NUKNlzUvyVJT
yWEWpiS6_TCILDOGEXrMyrkT2zNxKYCH4BmY-5VL1-CSZT9EL9p_ijvv2MyHSp7P
yFyeHPlFEWVLT0Q-lBii3gcL66ScNnMWyncDH_-9il8NFxOwoHaQ5P0O3x3d23km
13TaKbZ-FCdC6AcK5NN55A"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MCPNS-U434L-3RPDP-TSJ55-INCDD-UW6GF",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MCPNS-U434L-3RPDP-TSJ55-INCDD-UW6GF",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCPNS-U434L-3RPDP-TSJ55-INCDD-UW6GF",
          "n": "
mx8AqbVLpiO1yLs8hFhf7lt-XAcSK0M6ONtz5hChN59d2jKFr0N2M_BOgmC0x9aK
Ak0uMz4wNEK4oSuacs0on7O_FJkjRnzOXFSKluVBgi9Bk1RbkdqejURp_8KvMFRq
QkM4kwqhqONNIrqY_-USIX8f8Db3lJcN8fpHlDxT-9yXK2YA1mEhkKgibb7OYB7e
oY_pesMlBmkpriPkZ0yYHFBI-0buceQmUQVoPj4UmGzqri-zSfgs6fTNGBYRIYhH
q_VSomqC2OE1t_mrNWbi-zgQ4znexMmqYQ7PSqFcdHHrGCaRR_M--kf97O7XaK8k
SPB2u_lGcXUIWqbDD__Z0w",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MC7MD-4CE36-R33SK-7OBZY-KZ3L7-U2RWW",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC7MD-4CE36-R33SK-7OBZY-KZ3L7-U2RWW",
          "n": "
xz74yBQPy8JTnWul1_lBKoYjPExd6dIx_-u_bzSB28wLjow63ci9qRCUpD3mgiJR
niO0AMIhQfNe4UfULoWdTkKiBAazGDNZc7grLt7GTHgMpC9-s2DpNZipGaSPwRfH
JFYS33RY6iVT_qg_JEwBo26hg5y7KODMT6LnojJs3MGrKQ5A0BN6ZVkzP3vDaAeB
Q0LmXYitrlnMB_JtzzucZAsP2_-j3pu1kO3j9x5iy30U-BUF_E6O2VGq_jabzFat
F8Uusn2y9dpvnIaXokFsKZLr3Yi0uD-MNP8OjE9fmARiT7k47MWqQGNkAqXWpxIw
oRmCYIb1w_JAqJcItmqTaQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MDBF6-U6PPM-4YVCJ-LUJQC-7OCXJ-2UNWZ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDBF6-U6PPM-4YVCJ-LUJQC-7OCXJ-2UNWZ",
          "n": "
nOWDvAc6S8ba-3oZJpEunddCjGpQAEPzT3x553rWiYA3bJIOZDtSbl4AtqJENQyi
Y6lbSYt7-7HuB3aoAY2_NVNirkry-HlHVjcDSVfmKtXzFmZnGZyHw9gN0VZEx_PO
Ss3CboJ24aebO8F2AKLC3AUP0YlXgHJ6Zf5CgvoCJEw_Mn4Pz_2ySTTHHk9PEbnF
Dy8MPLZRFtHmnfEwIFIQMsI3bpjMPlrzake7hq5WHeRbgAZ8UA7VHovSAIrPfsUH
w7Ui9MsLznqp299-QHbIuzGfLkXtfIuoLtilEGqyZ1z2d7dyCeJrOWvG2fleMZR3
PbMR6akVhUKro9XnPWplow",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCPNS-U434L-3RPDP-TSJ55-INCDD-UW6GF",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNQTlMt
VTQzNEwtM1JQRFAtVFNKNTUtSU5DREQtVVc2R0YiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
S25FevDrNoEKTmI4mbBc_xsXOYHvFzW9nI6aoDvnsDiVPGR0R0_FJxbbDzpClgqS
1Q1lGJK7hwyI1MPR4fUDIqQ6Wb8wWO4YX_4cGEinFmXrL_TpFJdLgtvWdOFwbqSu
se6rENaxECI4IhIH1Qp2Sxg-VheFrWEjNadHNlwqnUghn10S0zLCDpGjytlEolQf
HemG44JX5XEbPvPpgG1DJCD9wMN0ToV-a6xAOvlj5c3xGqp33cNhvIwIZlH7LRRe
tWhrZS0jOXGpv7NFWT8niztFOZhIOWBF8cJqQOleqP6Ul67l0J1Ajg9rmnxP9fDQ
3biW965CFRJUmvD4pm8zHQ"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
    "SignedMasterProfile": {
      "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJaRDMtSzZOTjYtUE5DS1gt
VlU1MkgtQUhOQ00tN1gzMkYifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJaRDMt
SzZOTjYtUE5DS1gtVlU1MkgtQUhOQ00tN1gzMkYiLAogICAgIk1hc3RlclNpZ25h
...
QVFBQiJ9fX1dfX0",
        "signature": "
KUzTu53g8VTFHIWykCk-TwFEW526isYzogshXbvWjJgjGi0ypFGPtj9vXRRGowF1
2BkEFXo2zJ507sDbv5JB6efb4QlnEj2mCetFT2zaTV3xdTQOhetO08IEG66u4h5S
dfFwGtLZnlRSz5pEvdhrvKdvvhYTl4grjaIvQVGOQRzwXGpQDF84NUKNlzUvyVJT
yWEWpiS6_TCILDOGEXrMyrkT2zNxKYCH4BmY-5VL1-CSZT9EL9p_ijvv2MyHSp7P
yFyeHPlFEWVLT0Q-lBii3gcL66ScNnMWyncDH_-9il8NFxOwoHaQ5P0O3x3d23km
13TaKbZ-FCdC6AcK5NN55A"}},
    "Devices": [{
        "Identifier": "MCPNS-U434L-3RPDP-TSJ55-INCDD-UW6GF",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNQTlMt
VTQzNEwtM1JQRFAtVFNKNTUtSU5DREQtVVc2R0YiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
S25FevDrNoEKTmI4mbBc_xsXOYHvFzW9nI6aoDvnsDiVPGR0R0_FJxbbDzpClgqS
1Q1lGJK7hwyI1MPR4fUDIqQ6Wb8wWO4YX_4cGEinFmXrL_TpFJdLgtvWdOFwbqSu
se6rENaxECI4IhIH1Qp2Sxg-VheFrWEjNadHNlwqnUghn10S0zLCDpGjytlEolQf
HemG44JX5XEbPvPpgG1DJCD9wMN0ToV-a6xAOvlj5c3xGqp33cNhvIwIZlH7LRRe
tWhrZS0jOXGpv7NFWT8niztFOZhIOWBF8cJqQOleqP6Ul67l0J1Ajg9rmnxP9fDQ
3biW965CFRJUmvD4pm8zHQ"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlpE
My1LNk5ONi1QTkNLWC1WVTUySC1BSE5DTS03WDMyRiIsCiAgICAiU2lnbmVkTWFz
...
SlVtdkQ0cG04ekhRIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
      "signature": "
bzzUZ6VvrxICdUmMQ7r9EYOPN0k1eaRi_SCRBvDtg2ZuCNcMDRCuLkVWr3AKH-tm
2RoiiMS-d1OStD4IN_5BeJa-zcTzINTiTSP9yVg6-RAMFojHVvSH54YHXKZlv82O
PLPEZml6gAIWR_BZXkpUM2wlRD8nAmDdHY_-OMTZmuPARibQfPunD3osvIQ6TQpz
yXQ5c6y3a3LkOwFeJrQ8wDRVfnonzmIXiOfCYxioHw6UVBwH2UYPWI33En49vUNN
Wn7VgQBe5M1-1wVDDmlgRQXZnlDXlrDFOaIffpse14o_TO9FioI055bcag9PKKZq
Ytl4-2a9Bkvz_LWEWIi4Zw"}}}
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
        "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlpE
My1LNk5ONi1QTkNLWC1WVTUySC1BSE5DTS03WDMyRiIsCiAgICAiU2lnbmVkTWFz
...
SlVtdkQ0cG04ekhRIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
bzzUZ6VvrxICdUmMQ7r9EYOPN0k1eaRi_SCRBvDtg2ZuCNcMDRCuLkVWr3AKH-tm
2RoiiMS-d1OStD4IN_5BeJa-zcTzINTiTSP9yVg6-RAMFojHVvSH54YHXKZlv82O
PLPEZml6gAIWR_BZXkpUM2wlRD8nAmDdHY_-OMTZmuPARibQfPunD3osvIQ6TQpz
yXQ5c6y3a3LkOwFeJrQ8wDRVfnonzmIXiOfCYxioHw6UVBwH2UYPWI33En49vUNN
Wn7VgQBe5M1-1wVDDmlgRQXZnlDXlrDFOaIffpse14o_TO9FioI055bcag9PKKZq
Ytl4-2a9Bkvz_LWEWIi4Zw"}}}}}
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
    "Identifier": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
          "n": "
yveVqH-bkElYY_OOywf8ateOz3tUKLL3xfGbqpcxezUYdO0N539Tg47RPBBV6150
lJRT4a2fGEIBV4n-A0jrHrOsXzx7FW0v3RkaTZ9EQic10cO-bn4-pWrBXK-9hzaD
4NP05LQepD27rlzf0U9NKBOJtgOs9pBS6dEHAEgSopgE6B65fITTqOOyISMXgQrh
JaB_HXl5Sd9P5YsnfKM-1AJjkvi3Kfmkb7vr22StdMUr_n2BsGQzO-6VFExb0cy8
oYP7jSyMi5-Q60AN8eFlMMnEpE49uMA5gzXGMAqyxICT30Od6o4lI2F4N_EPWosB
jr7AFzwbtJVpTNN2BmgI3Q",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MA5EN-UPAFN-47A44-KCKJN-5U665-PNS7R",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MA5EN-UPAFN-47A44-KCKJN-5U665-PNS7R",
          "n": "
uNZEu6n_4IVAiL6WkSIGfpD55fQygpy6P-7kJRaUJS8v8GqHh2UJ2xeiZUmMNZ2Y
HGtw0fAWZehhowgdbw6K5AbtKcszY4doLukEnmOYyCMQrb3ZXVB1l6S4bce2OpU6
RtRmXiLl1zZFAJJatCCfz-0HJDC0B11ZDShug76hFa3VHgwmczX12Xtn0_q_Ryqp
InSNaFzU8it4YlMgP96vMpHwiyjrIMG3Zow8faBXfsaFQ7v_46LKITtGy6f2dGMv
XyCGyL2mtSm3fqGbeH-NFNrBvcrvz0Rp2h7xNcRUxyiODAa5aRbxrB-hnqU8he0D
gMgF_baoDHVVAgVT9SnkLQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MB73U-P57KU-BTYHQ-4WZN7-7M34X-MRORG",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MB73U-P57KU-BTYHQ-4WZN7-7M34X-MRORG",
          "n": "
11m8rkCFzd159w8oh-oIX17UFNaP5SvSyTSaaA28UKIkURbInTauvkJR-BBSHVOF
pyiOKBynb6vO0FbUNdIFR9ZrLFJgcBxkSUGCZZ0QbS_Hu0RkgXicSaRICDdhPPIh
92Bm2Pk5a4--yuP7ZqggXgMS7gJ4bxePdNJff918XPLifmXfI5bE9kHBcxoQ5-IN
aWokzRE0Vt8GU57KF7i6MAP2dUZejFQVhhMdYDGFKgjnQPEYhaok-uo9eRhofefE
EO-ewYsAt8g0Dg9C117czUZEv9TTf7Q86tlwaFQzHW4ZSZwKkIrrp3RPByQym3t9
7i3GRXRpzONlAetw9-OVVQ",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFON0MtWVVTSTMtSVZDT1Yt
V0UzRTQtUEZTRkYtNzZaTU0ifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFON0Mt
WVVTSTMtSVZDT1YtV0UzRTQtUEZTRkYtNzZaTU0iLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
G1O5xK841EXqj_zSGJzGoTk2M5IcrxdOkSzlA2jw4TregnVXCGffnB1kLwvbcJnh
F20FrEy7WMTUEVsO-Gs0WVhWloj4iOkPW0orudDdazWxMFgcWAwS6gZY1YKC5lBq
GGWAZXpyYr4TxhyphyhgGIZ1EQzmprmHVT6cpt9zHXEF7nKoO52QhoJ_vOOZfuLA
BaOEN56Mw4jEOdaLcl97f2zB-09G-ga-Ska67xZMG_tJW7Qw2tV9colGovbwgV6T
pkxuTnRsWDvOAD8eW1RuuHu8oc07Vj4TEiZmBlSETKFMw9jyaDsOn7S7WgXpuh0V
SZXOdUf797Z-xab7ocFLCQ"}}}
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
          "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlpE
My1LNk5ONi1QTkNLWC1WVTUySC1BSE5DTS03WDMyRiIsCiAgICAiU2lnbmVkTWFz
...
SlVtdkQ0cG04ekhRIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
            "signature": "
bzzUZ6VvrxICdUmMQ7r9EYOPN0k1eaRi_SCRBvDtg2ZuCNcMDRCuLkVWr3AKH-tm
2RoiiMS-d1OStD4IN_5BeJa-zcTzINTiTSP9yVg6-RAMFojHVvSH54YHXKZlv82O
PLPEZml6gAIWR_BZXkpUM2wlRD8nAmDdHY_-OMTZmuPARibQfPunD3osvIQ6TQpz
yXQ5c6y3a3LkOwFeJrQ8wDRVfnonzmIXiOfCYxioHw6UVBwH2UYPWI33En49vUNN
Wn7VgQBe5M1-1wVDDmlgRQXZnlDXlrDFOaIffpse14o_TO9FioI055bcag9PKKZq
Ytl4-2a9Bkvz_LWEWIi4Zw"}}}]}}
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
      "Identifier": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFON0MtWVVTSTMtSVZDT1Yt
V0UzRTQtUEZTRkYtNzZaTU0ifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFON0Mt
...
Q1EifX19fQ",
        "signature": "
ES_xaeRhJ02dEO_L_lHMn8e54yYpveoxyFeVc36FJyIvxkfuLkWoNM-5XdZLmJS_
Elb9Y0MTHMUY8EwWIzfb2uwfnm-HzRmksdg8OLrNwsLIGn4jiCDl0yEly2K-cGI5
p4Vo1rD1HhGn1U_ZtfmjlkAKqAKg6FzJ8cNJOC9NRCZp1pGdPWyigDAkQ20_VLQH
SVqjzisLn9gFem6Rms0Y643rQV75pJiFdCcZ8W-GfUYpjGTVkPRLwVHFbcQTGbyf
ciXU4HUGZXKI_xPIzyTLkatS2RJ3kx3QmDanLFJMjZPKyCJISLPSWi8z7jpoQ3r-
TupfXqDA4uJ3dTIaLNXxaQ"}},
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
        "Identifier": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFON0MtWVVTSTMtSVZDT1Yt
V0UzRTQtUEZTRkYtNzZaTU0ifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFON0Mt
...
Q1EifX19fQ",
          "signature": "
ES_xaeRhJ02dEO_L_lHMn8e54yYpveoxyFeVc36FJyIvxkfuLkWoNM-5XdZLmJS_
Elb9Y0MTHMUY8EwWIzfb2uwfnm-HzRmksdg8OLrNwsLIGn4jiCDl0yEly2K-cGI5
p4Vo1rD1HhGn1U_ZtfmjlkAKqAKg6FzJ8cNJOC9NRCZp1pGdPWyigDAkQ20_VLQH
SVqjzisLn9gFem6Rms0Y643rQV75pJiFdCcZ8W-GfUYpjGTVkPRLwVHFbcQTGbyf
ciXU4HUGZXKI_xPIzyTLkatS2RJ3kx3QmDanLFJMjZPKyCJISLPSWi8z7jpoQ3r-
TupfXqDA4uJ3dTIaLNXxaQ"}}]}}
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
        "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlpE
My1LNk5ONi1QTkNLWC1WVTUySC1BSE5DTS03WDMyRiIsCiAgICAiU2lnbmVkTWFz
...
Zjc5N1oteGFiN29jRkxDUSJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
GRIDn1O8z5J79l3v_TSmYEx84XgovJLq4yZ6bggxptt4-68I-PLWZq27v4xC_DhR
0eWQcRCFqvpmmj5hMBpidc1Z0YXQaPBQRhYoWqehub--x_ucjY5wo87UcOlohPR-
8qGFTnIc6EucQxbWeNhVRK6lKfWd3VYOQa8R8lIj2z5SsysxL17sOgDpVCh9-Ek6
lPuI2TZQqXVLHWhqNLsDYWfFEXrsMl6jAr-jJSkUxm10vzhSotpq8L0mPMeuh3tH
QsTpysslJj62hrjxFQ7f9KHVAMHmbS-LPy7OSshbnKHiOiJZRkPaVLTV0ogHOleP
wnqGtTfCpzJTF4N7TeeiUA"}}}}}
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
      "Identifier": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFON0MtWVVTSTMtSVZDT1YtV0UzRTQtUEZTRkYtNzZa
...
dGVkIn19",
        "signature": "
IK8MlTTzzVXXV5NzsqNBHFHCY8ByJp3d1wGI6eyb7MGRrQCxV9Ha8p3bJtdhaOKW
khqqHA0oIEHL7MvnUCTHy6hOl5TGev89ok7HBRJy9JkwN1u1CsnpbqkX7zWIi8Pt
CA4WHzmUMJmeTJWmyEJg7pNN9_Us9GhCQgM7hujvsnqJ_VDY6ib9q_QfU4rhZBtx
fMY8zDDje61_P_5A4MuGR8lSziMkJ5deF9IEkT8oClBEj8TeX4nUtnHvQUEyFNAY
_kKANoqgvXB8gjYTHHu9b4yXhanchlGnMRt6lixzBn4YoYLRYdjj0V3QmTQPc0kw
QvM3FPBV2fX9D46RHS1ySQ"}},
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
    "DeviceID": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MAN7C-YUSI3-IVCOV-WE3E4-PFSFF-76ZMM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFON0MtWVVTSTMtSVZDT1YtV0UzRTQtUEZTRkYtNzZa
...
dGVkIn19",
        "signature": "
IK8MlTTzzVXXV5NzsqNBHFHCY8ByJp3d1wGI6eyb7MGRrQCxV9Ha8p3bJtdhaOKW
khqqHA0oIEHL7MvnUCTHy6hOl5TGev89ok7HBRJy9JkwN1u1CsnpbqkX7zWIi8Pt
CA4WHzmUMJmeTJWmyEJg7pNN9_Us9GhCQgM7hujvsnqJ_VDY6ib9q_QfU4rhZBtx
fMY8zDDje61_P_5A4MuGR8lSziMkJ5deF9IEkT8oClBEj8TeX4nUtnHvQUEyFNAY
_kKANoqgvXB8gjYTHHu9b4yXhanchlGnMRt6lixzBn4YoYLRYdjj0V3QmTQPc0kw
QvM3FPBV2fX9D46RHS1ySQ"}}}}
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
    "Identifier": "MBH6H-CFHZY-OCOKM-GZQEP-LBZDF-7PBPM-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
rcBftqDLPmBONvHbHqkYqw",
      "ciphertext": "
9wRv_5N7wWARUHdlstJ4CI-k08Y6ntBjLvwLimGYP8NLX2qYpDHA7uoc2-i79NgK",
      "recipients": [{
          "Header": {
            "kid": "MDBF6-U6PPM-4YVCJ-LUJQC-7OCXJ-2UNWZ"},
          "encrypted_key": "
JLS5jTRLZT3YBjWaqf_KjtpknNYU5nj2RcwQ9W2kQ5DiQQhKi5NVjw9h0yScH9gq
epYOiPmEgFGqAG6EarYj9tjNJiU7GyyKVdhh4NMOguwdJMiT8vW5fVSNbJmR0EiC
HRU2cyY8h86g7jbTkUjxJhrcYHoPmj928kLlaZmIR-qbXwAeqQmCRPUJQuzDrWBT
L55Q3bX9DnNkr7k39XxmnkanaYhQbym_tY54Uqu98IMmWYYmdji284gWrX_iYNNf
RfrZ4zL2USSUZ4GK-b8mh9PqiSXQfA2mfS6ZN4IHxJrgGkIGuT_6nJJyFClomwlG
RKMEe24wtGfXA0414T5QVw"},
        {
          "Header": {
            "kid": "MB73U-P57KU-BTYHQ-4WZN7-7M34X-MRORG"},
          "encrypted_key": "
qyPAwo9OmWaAIJEuM84AuqIvV0gLbF1noRlw64PVaPQPXwrDQFEyADul5nHESUcO
_BqGXIqbranWuxslo6IxdG5AWQIS8w-KVbUYoceXTqz7fRkEvusLkt54rwH0jWUY
Jfa7MvpBKAznj3y4xi9LTutgZrWAZEaeiBZ6-UC0otutv6zqFKzpHKyGJa9Wc1uA
gG7WCWqmcRMqR6QRxew6ljyUM1NekBF8CUkP3NDJY81dX2_IiOTC3uYbF74DE6VX
ZTMB75HE5uR33TXMCvmgw8ttnBwWrvetcHArO2C0IW7_f82K1CMIH0Y6XiOh3Pe1
Xn78Ve5N_A1bzDSsfjlvLQ"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MBH6H-CFHZY-OCOKM-GZQEP-LBZDF-7PBPM-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkg2
SC1DRkhaWS1PQ09LTS1HWlFFUC1MQlpERi03UEJQTS1BIiwKICAgICJFbmNyeXB0
...
SUgwWTZYaU9oM1BlMQpYbjc4VmU1Tl9BMWJ6RFNzZmpsdkxRIn1dfX19",
          "signature": "
GqsOluuE8CwQF2SHBBiWDfhK__yb7D7gQyd8nSs7nqja5DMSYdqeKIb_1WqdN2An
ri_5zUW9jeRblHw7XW-lev_2J4TmkarrlyXC0CmpznGFFgFSF832ZfyUH4mHuyn7
jynrfPYOJxNtZslxcQHNajA4lD_z5s_kRvmmapZt-ICvk1kT0DWqw8091Ehul3J3
69NWcYZ6xtESWfjEifMBVPt6nLJSnNX1dzPVMHXyHdllrKU2yFvNCno4f02RghB1
1-EDF-nZg7ZQTfM7KVIJc13I7RTiUr10iNfHTi748SnhB5ziUxNi2leEbKnA_OOH
CpBca6XQk29Mkad_L-3PHA"}}}}}
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
        "Identifier": "MBZD3-K6NN6-PNCKX-VU52H-AHNCM-7X32F",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNQTlMtVTQzNEwtM1JQRFAt
VFNKNTUtSU5DREQtVVc2R0YifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlpE
My1LNk5ONi1QTkNLWC1WVTUySC1BSE5DTS03WDMyRiIsCiAgICAiU2lnbmVkTWFz
...
Zjc5N1oteGFiN29jRkxDUSJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
GRIDn1O8z5J79l3v_TSmYEx84XgovJLq4yZ6bggxptt4-68I-PLWZq27v4xC_DhR
0eWQcRCFqvpmmj5hMBpidc1Z0YXQaPBQRhYoWqehub--x_ucjY5wo87UcOlohPR-
8qGFTnIc6EucQxbWeNhVRK6lKfWd3VYOQa8R8lIj2z5SsysxL17sOgDpVCh9-Ek6
lPuI2TZQqXVLHWhqNLsDYWfFEXrsMl6jAr-jJSkUxm10vzhSotpq8L0mPMeuh3tH
QsTpysslJj62hrjxFQ7f9KHVAMHmbS-LPy7OSshbnKHiOiJZRkPaVLTV0ogHOleP
wnqGtTfCpzJTF4N7TeeiUA"}}}}}
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
        "Identifier": "MAFAP-DZLNH-R3WXV-D22Q7-PVZIO-FWFZK",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
HvW7i3wuBAQOkfB6WM8GFw",
          "ciphertext": "
pRaVhS7ag0zZ3PrW1WLW-1YmwF5erOMOhO0SA65WWNKXJ0gX4gnTf_4tQowHUdmn
QpQp1qzgskAmIG_HUPuxvlPZ41c7KBCD5G0xvvbSpiwiLlrdcLc8otFFb4_8PEmc
...
SuoOUXXAPgr7A_FX3L6Q2iVl65gM6fmyf1Cu3_VHa8AJHHlAJBk3gtbhuBPZdXFS"}}}}}
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
    "Identifier": "MAFAP-DZLNH-R3WXV-D22Q7-PVZIO-FWFZK",
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
          "Identifier": "MAFAP-DZLNH-R3WXV-D22Q7-PVZIO-FWFZK",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
HvW7i3wuBAQOkfB6WM8GFw",
            "ciphertext": "
pRaVhS7ag0zZ3PrW1WLW-1YmwF5erOMOhO0SA65WWNKXJ0gX4gnTf_4tQowHUdmn
QpQp1qzgskAmIG_HUPuxvlPZ41c7KBCD5G0xvvbSpiwiLlrdcLc8otFFb4_8PEmc
...
SuoOUXXAPgr7A_FX3L6Q2iVl65gM6fmyf1Cu3_VHa8AJHHlAJBk3gtbhuBPZdXFS"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


