
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
Date: Fri 01 Jul 2016 07:23:22
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
    "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
    "MasterSignatureKey": {
      "UDF": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAKaJrPZIoa-Mliu6JtFdxo0wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUNZU1gtTjJaSkUtUUxERE4tUUtDS0stQlg2V0ktU0g1RFQw
...
bRoEQoJhOkFVHiykvfRjeh0uCXRUbBPCUc2SO-9gbuEHgJUdhBRtY7B9Ng",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
          "n": "
pbxbcO_Wdw7uJ8hvxU_wNpw9AzpPLFj6PMssrewohM6oHBANi6IljBqTnUlUDzw9
c6bkWRDh9vS6YuL7GvhpFipVHE6DdM8lTQTypShlrDe6Wv4S9e0Wtj74K3RKaRnr
SksS-q9ihEY2XqssyAL9idQpzQa7TzfrIPraIOfm2QGym6jJ_5qU_-n3R6KYwuBq
mLq_psBS5kZtsB3JIhE9r1oJ6sQWrTB6FcB2yLDbev7h6FYTvRRJD2uONL7LjA7p
rX7A9QjyzrAhuSzhR0AhZW978SYLGqwEzg0z133Co-CW_3hPNABN0b3ebct3m6a6
28GkdzkcECsMtwNEe8fkZQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MDY7B-3HQDU-MYU7X-HSDAM-VY2VP-EVXI6",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQbPuH6A55zboWyBlc9OQKTjANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQ1lTWC1OMlpKRS1RTERETi1RS0NLSy1CWDZXSS1TSDVEVDAe
...
qNcshHKyF3ILQsJoK131J_YRkvHR3T0GKodUAwH6R72jeGhEMGqQ0iR3",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDY7B-3HQDU-MYU7X-HSDAM-VY2VP-EVXI6",
            "n": "
sUEsHxL_MIaURLJYqMDM3Yk1e7qA-sPyy3-j2Ar74OuMKqB08wBtytXaK4EoNqZk
tW0HOYK_xu6toGf5krkXMxDE_dkP8-u6ZTpaRul59NVS4k8deJlEeg9dvXS6fthU
0mPd8L_ku244zFnT8lp4i42td8vVKClGvPVRQ-Cf9EF3WA9Jy90A5fzhC8ciBuTy
7Hvc_-0PVjmjPx6ytTuCH62EDRHCsO24iTPPkkFc99d38p_8PYEekprGkMfJ7KAe
Y2Qr5T8dpZ-WWhnD-QWumkFZfAbmb1iM90ePrHrrUMr8BJsTSaY2ggFGw0DmWNCn
sfSaCMyYqgHr6608XSEPdQ",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MBKFC-ZYNBY-MVTTW-KGNIZ-QY6BI-22M6N",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQXuCKus7X_6IrCran_3uq0jANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQ1lTWC1OMlpKRS1RTERETi1RS0NLSy1CWDZXSS1TSDVEVDAe
...
Orx4s3zDZs5nVV3aWO-VDJraQ804Yp9MkE4iQ9uyo_O5nq6cfa32btXq",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBKFC-ZYNBY-MVTTW-KGNIZ-QY6BI-22M6N",
            "n": "
tQEZ4ql78x3af0qfIIyQ5fK-PuuCuncjd61FJT7zpsr90ZUhnpHQxbGqmHX67r9r
-eHel-occpXSwDuonSUhXSIaV3xfb2Rf-vxx0aJn87WBSuhLqC4ijiCR6rrsopAs
WYVLtSJWBsRtMiKW4VJkxXPNdskgjVKkZSiSbO2C3G25oRQQ-B9FnNs6I0hhbgM2
Zq8EXd6TbbBf8hqU-W_MzHvuP6ud9071vaKud2EqdqEUeiUy_oSO8Y4jtNTgGgZK
9uJbjb7WPYTUas4S_RzqFRrovvLWm9r5ak-IVxcAsPKroBAXFzZcb6NqhPXTqOef
AOzwY6s028B6lVuNd87SgQ",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNZU1gtTjJaSkUtUUxERE4t
UUtDS0stQlg2V0ktU0g1RFQifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNZU1gt
TjJaSkUtUUxERE4tUUtDS0stQlg2V0ktU0g1RFQiLAogICAgIk1hc3RlclNpZ25h
...
QVFBQiJ9fX1dfX0",
      "signature": "
Z62JdrViWelP6DTmi5gsrPezivFyj7NJjjqsACLWYdetcTR7s3dHnmeBDUOBc9w7
aNVPGqWIdrkTRjojnj7fL6S3MCgBhtCsgKYIFPQvd5kzCnoYLTH0eTi_Y2CwPLJN
Y2pbROk-8H5UNJeALbggasQtJ0OnI1_K8thPHQowa8E7oxWKYIkdv2BkwRrXn4Gt
0DXulOx1-ZLgCtacbaCGv_p5J9oA5b7po8viV9IYHLQUngWkZnzzxT8t2JvX2nDK
Z-JseezZl_kKGtzoYvjV_BNehHj9sXIPldme6pzg-E_c2ZYUbQTXNFAlrPPh7M4D
fhmFSnafqKOcVkrRCCxIiw"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MDHG2-56YEL-PD6MX-MBGEG-62KMZ-MNOYS",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MDHG2-56YEL-PD6MX-MBGEG-62KMZ-MNOYS",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDHG2-56YEL-PD6MX-MBGEG-62KMZ-MNOYS",
          "n": "
rqEP4jgOKXsfMtH70JO7vXNQ82g_3PgJq3BtRUk5LUvhTxXL3f7Y7GHbLXgIBa2a
z6OYnAi8A1lkj5bj4J-FnNGVbugc0Mb-T_7Szm8Frn24qPw1JHv3AEXy1zScjfK_
QvDF8LlbMUyBXohtzblKf-V8V2xuw65cM0DXzwWFXmtRnoPbcVUv6XCz-LXOKzk3
JzA4TR0jWZJEtbo5ithU7l0f39p8qPeM431iMZFwrXOSCekRgBGuDvoNOkRci1x7
qJsZyceEjIIN7sdlv8Lccpq-fVogVZgYbhCJ6Oqmzi3b3sDNKm-3U5RhIXMyEJRG
T9V547zEJNzSJ0bazILAWw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MBTNL-NIJJL-TZNK7-FLY6S-RW4CY-YVLJZ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBTNL-NIJJL-TZNK7-FLY6S-RW4CY-YVLJZ",
          "n": "
qN_WInjR4z0tk0YBiEirJtc0v-w7adbitUJsCxAinE2e7lmF515PFbPRoC1SPQhO
TTdRnV-w225OCYZoWA6xOQfXdSkT0vuwiGPC9ThZ4shC7uylRmUekqDcuRR6Aew7
RppBiWzpvWTpNpGhOCuFOYh8leycSzpTprixqnbA60olKAwyfkg6gtWkKsJazlno
DTkQjtdkztrinlQMcEicRdFJoPzzOxSTFzDCBcninlZ7SoK0pfm2W3me_sATHS0b
pG3pMR56ek3DKvgMTZgs51Qy6XInPPZhhIb3G_fB8iYGqt3D_A7dyJn-vJDZO1it
j-qYCnvcNJBJ2xQcoxHkfQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MCK5Y-7KP4O-UNALP-ZPN6B-NWIRD-W4WWO",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCK5Y-7KP4O-UNALP-ZPN6B-NWIRD-W4WWO",
          "n": "
rIqI12aBC1rZhvTbD6lHjCXHbc4ZXZB_NdWgQKz1_Lym3PPVhYavmuH-ee6FqVQe
OtVBAW6AoslagDEP9BokOrizA8iXa-_08-saMzzKd9F1Ti5Z8haxUNfOlOnpgwJT
bjg-rf0qlWVJDOX5OvEsdw3G-3qt_fwBd5evoGR1RxzjSWgMdr5VXpBxFES9_s_L
zcHrvj9MAVP3eCO9tuUoM0vFsR6nE10CiLjT2kxYbQfrS9IiYH5DKaBSXiy2a72P
ubHlf2mhFGyikxoovNInAvSkOvZQAgctuVpX-_FwzTCky_V6qdIKtuEJs9aOxeLu
ETEpCGHA4rjd66QihXGLzQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MDHG2-56YEL-PD6MX-MBGEG-62KMZ-MNOYS",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURIRzIt
NTZZRUwtUEQ2TVgtTUJHRUctNjJLTVotTU5PWVMiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
idvd-0t_ryaIsLb05sgn7trprxfIta_a3EmBYG_RaraxKOoNTsOAj665AWiDCaBm
12prub2aw5CNh_BrPGbEQ813iQiiv4HcKAcG6ExEz3D7bGoo7oPJEsZW1vVyhjPI
IdHpyNGiLski0lIn5suYvciKN2MIxzyPGiqIFKQqQu_m2IEZyiRv83I7tHyjwgyS
O3bJ81bccJwJW7to_FEcrJIX062T1mdpZnVcBxLltFDv6BD3Ohg2qJWtsliv4hSc
CnxIvVaguJZLF9_UxzoM_6G1FW41G7XeD7Xjs1Fn1WfcbexjQLbb6pwvvAdf2jTp
Ujii5jakDUEEIiaigGYdag"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
    "SignedMasterProfile": {
      "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNZU1gtTjJaSkUtUUxERE4t
UUtDS0stQlg2V0ktU0g1RFQifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNZU1gt
TjJaSkUtUUxERE4tUUtDS0stQlg2V0ktU0g1RFQiLAogICAgIk1hc3RlclNpZ25h
...
QVFBQiJ9fX1dfX0",
        "signature": "
Z62JdrViWelP6DTmi5gsrPezivFyj7NJjjqsACLWYdetcTR7s3dHnmeBDUOBc9w7
aNVPGqWIdrkTRjojnj7fL6S3MCgBhtCsgKYIFPQvd5kzCnoYLTH0eTi_Y2CwPLJN
Y2pbROk-8H5UNJeALbggasQtJ0OnI1_K8thPHQowa8E7oxWKYIkdv2BkwRrXn4Gt
0DXulOx1-ZLgCtacbaCGv_p5J9oA5b7po8viV9IYHLQUngWkZnzzxT8t2JvX2nDK
Z-JseezZl_kKGtzoYvjV_BNehHj9sXIPldme6pzg-E_c2ZYUbQTXNFAlrPPh7M4D
fhmFSnafqKOcVkrRCCxIiw"}},
    "Devices": [{
        "Identifier": "MDHG2-56YEL-PD6MX-MBGEG-62KMZ-MNOYS",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURIRzIt
NTZZRUwtUEQ2TVgtTUJHRUctNjJLTVotTU5PWVMiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
idvd-0t_ryaIsLb05sgn7trprxfIta_a3EmBYG_RaraxKOoNTsOAj665AWiDCaBm
12prub2aw5CNh_BrPGbEQ813iQiiv4HcKAcG6ExEz3D7bGoo7oPJEsZW1vVyhjPI
IdHpyNGiLski0lIn5suYvciKN2MIxzyPGiqIFKQqQu_m2IEZyiRv83I7tHyjwgyS
O3bJ81bccJwJW7to_FEcrJIX062T1mdpZnVcBxLltFDv6BD3Ohg2qJWtsliv4hSc
CnxIvVaguJZLF9_UxzoM_6G1FW41G7XeD7Xjs1Fn1WfcbexjQLbb6pwvvAdf2jTp
Ujii5jakDUEEIiaigGYdag"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQ1lT
WC1OMlpKRS1RTERETi1RS0NLSy1CWDZXSS1TSDVEVCIsCiAgICAiU2lnbmVkTWFz
...
RUVJaWFpZ0dZZGFnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
      "signature": "
lw5hDAGCQKDBmcrywjgpYiLaR1jI8Lh9L9h4c1qOxdK0Vup3bZnN7MQ3uj8JQQKi
-QC6L7otuPQXAYHQC9qZAv7nsbqZyziudh30XgIj0fp-vv4gRzNray_bVhTGf2IJ
TkuFfudzJeiLx7YH-tiGbQG7dXNteZxtx3OAO7E-GecZEtHYZVInLC8K_B0iyg89
O8wDHhlbnbfaBhXnp3-ey_AKDmHCAngu6PJMaqKcOrOqYcEPhiBDbzDVGk_Nvf5M
F0aYS5s44qyj0CS-2ELvY_ng8e4OcybinPymYQzmRT3ewqQH_35ej_yKRYEXF9Mb
5jnLuBB0vssaUfCruWc10w"}}}
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
        "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQ1lT
WC1OMlpKRS1RTERETi1RS0NLSy1CWDZXSS1TSDVEVCIsCiAgICAiU2lnbmVkTWFz
...
RUVJaWFpZ0dZZGFnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
lw5hDAGCQKDBmcrywjgpYiLaR1jI8Lh9L9h4c1qOxdK0Vup3bZnN7MQ3uj8JQQKi
-QC6L7otuPQXAYHQC9qZAv7nsbqZyziudh30XgIj0fp-vv4gRzNray_bVhTGf2IJ
TkuFfudzJeiLx7YH-tiGbQG7dXNteZxtx3OAO7E-GecZEtHYZVInLC8K_B0iyg89
O8wDHhlbnbfaBhXnp3-ey_AKDmHCAngu6PJMaqKcOrOqYcEPhiBDbzDVGk_Nvf5M
F0aYS5s44qyj0CS-2ELvY_ng8e4OcybinPymYQzmRT3ewqQH_35ej_yKRYEXF9Mb
5jnLuBB0vssaUfCruWc10w"}}}}}
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
    "Identifier": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
          "n": "
xRZAYn1-fFaF9USY4jbiRdbliR4Q5-hVTZsGcMD1rCQC2qVO4EpE6O1ooRaxDJsO
dxgvaxTc6FFplaeq_UGr0VWKwBldRRnhEPH1h_0ntVzLrCoN4iiFlp5d202u5bGF
MqTiqOcrNmLNKfxZKWYRD6AOXGEKdqzPNJXt2FcrCySF6OwpfqK2YaSuVbT-7jmQ
XfpRmKBPG3Es_3s25erbpYaZ4akrVYfkbpqb1cizXjU6DpQh3YeBp1dBITvHqGJ4
6ioOXtqaBz7z_FkR9uLLKItnfC1_juZ-ZGx23KV3GlqgbPSkokfO9Bx0iAaOjQF2
nGQoUKLSs8F8m1ZtDOih3Q",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCH3P-MHV4V-GT4JP-NISSF-TDZIT-ZFI22",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCH3P-MHV4V-GT4JP-NISSF-TDZIT-ZFI22",
          "n": "
u6oeqakO9dqxNXQ-BuDhzWfHz2Zho7Q2Un0qBe6ynvTCAWiSC92OZIa35aqvG68s
Bh8FP9z-11-6xlSBlDZnLQL0lwoIBvoCvh026puzUKvxc_Ku8vgCa8JcLeUNC4RM
2phBNQnhCSfsaf0dn4hXXr4njKkim2Rsd2PZGIWZnsIFZiCIf68REqQQIynvnCEr
2bo7TJD6VT7I0gR9-z-TfKL_X0z9wp2wFp2eDqlOUiXlb31xjVaqIPnZQDYKwWhV
fn2QMj1LUd4rat-S-uLcQi3rf0YWaAL-yZIDSDokDjPd7SCrMkpQ3R3XlZglg9Hw
7GqE5yQn1fG9jT8oodmuaQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MA2LR-P56A6-2FFKZ-VPENT-FQQIE-36JKL",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MA2LR-P56A6-2FFKZ-VPENT-FQQIE-36JKL",
          "n": "
w31eutmZcwTg5-ydqqZATGFQYDIMtGsNeXYH12f4MSNpn8qpfxmjUnrz49OLB8HV
lYNSAYE9xJJvN9_ld0KweUpUlob2eA3vstAg88SsobBAfvVzg7IGSzkm4hv9kP5_
OPxmlFd3ST-PNipGDO2EGAHsKDWMR_GX0XXMFMbBKeK5BdISygsSmcRVYdIsAjxu
HWTSALVbZ1eZ7oJbjhFZtmg2FZQ9vEofjLHMvYeecQrwRgqdowDqNMBWUUoF6PYG
C2oGBToD-9oLAWNmHRzrR_Bqpe8Ca0yf0HP4VwjwZKf1w1oKusUPxZjF767dGOm9
0XBUsNKZ2AqjGOHDil5vLQ",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQzWTQtVklOQU8tWFVYRlkt
WFhWTEctUDJTM1AtRFdGN0IifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQzWTQt
VklOQU8tWFVYRlktWFhWTEctUDJTM1AtRFdGN0IiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
icn0yA_KyQzIpL1C0xsH6s8ToPOinOo6Nw9fLmpx5t2UwT2JQIWUx_s75JGVpNzF
2xQ7k08PEYKCn3wCdQ2BD0J1oPeBc8zNHcF_72Yyni3NtSSnVvjTZc3Qh5uajpuR
ZHJ6f4S-lafM39qEbXLl3SexqKZMeoQsNPuDVUg8woXF50JAaVYqJv7PABYnmdz3
NhdE46wPVoyUs8D9eTBPfpLV9EGOs-C_9p7fzq_yT2zA36xF35A86IUUxcCWEGW0
LoyWkSiXM7CfSey-O8AU4bMpZZ7LI2XbQLPw3_4jUM48g0JDCP887PF_nDBZ1xyD
-SiNHaxUCw3hT-ls8w8jLQ"}}}
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
          "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQ1lT
WC1OMlpKRS1RTERETi1RS0NLSy1CWDZXSS1TSDVEVCIsCiAgICAiU2lnbmVkTWFz
...
RUVJaWFpZ0dZZGFnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
            "signature": "
lw5hDAGCQKDBmcrywjgpYiLaR1jI8Lh9L9h4c1qOxdK0Vup3bZnN7MQ3uj8JQQKi
-QC6L7otuPQXAYHQC9qZAv7nsbqZyziudh30XgIj0fp-vv4gRzNray_bVhTGf2IJ
TkuFfudzJeiLx7YH-tiGbQG7dXNteZxtx3OAO7E-GecZEtHYZVInLC8K_B0iyg89
O8wDHhlbnbfaBhXnp3-ey_AKDmHCAngu6PJMaqKcOrOqYcEPhiBDbzDVGk_Nvf5M
F0aYS5s44qyj0CS-2ELvY_ng8e4OcybinPymYQzmRT3ewqQH_35ej_yKRYEXF9Mb
5jnLuBB0vssaUfCruWc10w"}}}]}}
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
      "Identifier": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQzWTQtVklOQU8tWFVYRlkt
WFhWTEctUDJTM1AtRFdGN0IifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUQzWTQt
...
TFEifX19fQ",
        "signature": "
Gi_02CTSxzyb_QKanU89a0ZuavOGzvtn6Lt-6A0xrlOeq1bcYsVdUG5j1d8SQDBI
yiwZTCQGpzSPPCOjvHbPyr9dxzrPklJS81VznkMbZuSx6TSfqbspEd9oKiUyULEQ
2hpjYAQOalBVKDOBa0VR8jqO5WXNVQ5P-ebs3EpCzl7V4o6f_OpUOYkZWPhX6ViH
9aw1xUSeFBUPfMfgLOv11hoaQFcZPc54QUXNqr4SHIsZgBTNqlbjpVBa7OKA3rsL
phsuzEW9KzMoUw6uPQGCU6iUxgkhWh-g1OI61BkkEJehajLK3U9CiCUP01oraofj
zqYKnQnU_aljrfAQ-46JjA"}},
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
        "Identifier": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQzWTQtVklOQU8tWFVYRlkt
WFhWTEctUDJTM1AtRFdGN0IifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUQzWTQt
...
TFEifX19fQ",
          "signature": "
Gi_02CTSxzyb_QKanU89a0ZuavOGzvtn6Lt-6A0xrlOeq1bcYsVdUG5j1d8SQDBI
yiwZTCQGpzSPPCOjvHbPyr9dxzrPklJS81VznkMbZuSx6TSfqbspEd9oKiUyULEQ
2hpjYAQOalBVKDOBa0VR8jqO5WXNVQ5P-ebs3EpCzl7V4o6f_OpUOYkZWPhX6ViH
9aw1xUSeFBUPfMfgLOv11hoaQFcZPc54QUXNqr4SHIsZgBTNqlbjpVBa7OKA3rsL
phsuzEW9KzMoUw6uPQGCU6iUxgkhWh-g1OI61BkkEJehajLK3U9CiCUP01oraofj
zqYKnQnU_aljrfAQ-46JjA"}}]}}
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
        "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQ1lT
WC1OMlpKRS1RTERETi1RS0NLSy1CWDZXSS1TSDVEVCIsCiAgICAiU2lnbmVkTWFz
...
eFVDdzNoVC1sczh3OGpMUSJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
i-zKSN2SQsNkZ436urCOOssErZbBZ366p_7YMSr1UeOevzRrMJECfpmPwKMLz8uf
VLKz2IQd3WDAqFVXE329X81ksn_ny-LYwdCkky8tkZLZAV80BxxzCwOCxZosJQ6U
KjXw-XBfP8vacKMoFTI3inlqirMg9DFLhI0xpCfdADmi3h_zbjAJEiGMduDGzoN1
Mfo06IjNznmwP2l8EiO8NU9HBO1DxmbEGXfxXfeoMbxwvatg88zS3kruAlP9ZCTR
kGrw-Gz3agKMnkUiqz-AGAxHBKwR3g-tX53clWh68BbRoVxIePsdNllS0GeFl6QA
nb7SPHHMqU_rmj4g6XnmwQ"}}}}}
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
      "Identifier": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUQzWTQtVklOQU8tWFVYRlktWFhWTEctUDJTM1AtRFdG
...
dGVkIn19",
        "signature": "
P55MLHQaAl5dYtezIIJ9TORlsWzUHPzWWDyuwLwRzEdCd0nkYifinimy-iRJJtvf
A7KCy2-owOz5OajVfr08UZq_9FYjmYYLfod9va2OkrK2V7RlzBVz33i4EV7ZBrER
gQJSf9uKZyUPUGSqOvz2psour4iNJmB34Ux3cOuYFa1lPt5QnpvBPBZ5YCjMDZWi
enSiQJIS9-h4TEiZ1-4z6nnXA-OUbfg7oRa7xaiX0RXcSWXhtBKLYC8J0XhF3elm
zZoaiQ-X_MKNETau4BxRMuZ7BGKClmjLPqI3pLZN-WBY6_FY77LmMmF-trfhLvOA
pScZan-nUUy3ALqeSnhkIA"}},
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
    "DeviceID": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MD3Y4-VINAO-XUXFY-XXVLG-P2S3P-DWF7B",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUQzWTQtVklOQU8tWFVYRlktWFhWTEctUDJTM1AtRFdG
...
dGVkIn19",
        "signature": "
P55MLHQaAl5dYtezIIJ9TORlsWzUHPzWWDyuwLwRzEdCd0nkYifinimy-iRJJtvf
A7KCy2-owOz5OajVfr08UZq_9FYjmYYLfod9va2OkrK2V7RlzBVz33i4EV7ZBrER
gQJSf9uKZyUPUGSqOvz2psour4iNJmB34Ux3cOuYFa1lPt5QnpvBPBZ5YCjMDZWi
enSiQJIS9-h4TEiZ1-4z6nnXA-OUbfg7oRa7xaiX0RXcSWXhtBKLYC8J0XhF3elm
zZoaiQ-X_MKNETau4BxRMuZ7BGKClmjLPqI3pLZN-WBY6_FY77LmMmF-trfhLvOA
pScZan-nUUy3ALqeSnhkIA"}}}}
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
    "Identifier": "MDSYN-PXEKK-QTTTR-3AS3H-MQLHC-DTO7G-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
YhjmV0bW-w12tbGXvh-7tQ",
      "ciphertext": "
x7a9uxSL6F8KuFUhD75SrA3rQyucqgarZhBItIbr5BEmwt0Av3JHgdSJsZQhu2Wm",
      "recipients": [{
          "Header": {
            "kid": "MCK5Y-7KP4O-UNALP-ZPN6B-NWIRD-W4WWO"},
          "encrypted_key": "
n10q6FXujbyVwEiNLFVayIEdc5WkRTsl5Tnw4Va0hgbBmybSnOlH-JusvNl_YxIr
dkwqVokQbq0H6pTlE4J_Vn00T4tsM4nYj3iuUvZi1_mf35-cKQpqbHGWbdA8FFpU
hd-3GuA2wkvwnJBua-skOuZdZV1pYOycZXySZYyK2me5H7H8Q6_URhBbVZf8mqfv
0Tqw3Jq3Q5PwOKhBHRG8EmmV6RPFgPPSPLb_NMCeX5w4NXTzQnwVdXc5hzyhIYHO
VaoauB3rv9rcu2V3gmmSMzqTDkpAmoXBL1a9ybAoOPP_CtF2lg01FWs21FRMea8h
Y40qz6OVHlzx-s4oWbXQyQ"},
        {
          "Header": {
            "kid": "MA2LR-P56A6-2FFKZ-VPENT-FQQIE-36JKL"},
          "encrypted_key": "
GV0tSrCJDBdvaEPPClEqTFt8s3xLPT6b7toIDu0EfBxFOAv_Ok23Gh87zlzzjWFM
ljqz3r1DP30s4WQO8c2HaRTQ10vUIUal4SidobA-VQ-A1dm8b3q64WG1rkAA60sJ
PxjTDEiNxamL03mMacdJ83MXGgA2Ob59JVyJjRaFLCBaL-vhE73A-NuEYpr1fLwp
J-L1nqcKyHMzr6PWQtHkEw2T2icGN5cgNTSFhZH8YjtYzBAcE_wFjj1QaDXBCWYq
BlMfZj1G-UolV0V5Pfk2IpLG_FVvXSNH7t1j7IDKtkoN2FityEXV-QQM4ui8rCBZ
wSp6-m9PO1_ZvEIGXiWqsg"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MDSYN-PXEKK-QTTTR-3AS3H-MQLHC-DTO7G-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRFNZ
Ti1QWEVLSy1RVFRUUi0zQVMzSC1NUUxIQy1EVE83Ry1BIiwKICAgICJFbmNyeXB0
...
Vi1RUU00dWk4ckNCWgp3U3A2LW05UE8xX1p2RUlHWGlXcXNnIn1dfX19",
          "signature": "
W4gtRKsZ5bzv3kWjqNYwcbIVFEkOJFaptQYJVfU9q4lrbU6X44Iqy_CiL3Gcs_GF
vt-WOnNnze8X7C72e_drqHeBA8aLDBmRZ7h9lLH8K0TsA6ZqKhHDr567bqil1H73
x4t1R2gSJ9Lo_wIDi9pZx3r7BfMp_spQjiexlL88ETalUGgU0zm3Go2ndkxdNLm1
ZZHG61vyEqkepqw6LfNUxOCGUmG2MXyh1Rg-N9ZAtKXQBeN1plZXPK_Xkhy7dL36
43qCnDhwaUxFfT9cUBr83NF1AkIbwdBsu1mPat62DbZhq0qLWz3auYPCcnTJA9FY
5rq2uxpDHyZkBabelTc0Ig"}}}}}
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
        "Identifier": "MCYSX-N2ZJE-QLDDN-QKCKK-BX6WI-SH5DT",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRzItNTZZRUwtUEQ2TVgt
TUJHRUctNjJLTVotTU5PWVMifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQ1lT
WC1OMlpKRS1RTERETi1RS0NLSy1CWDZXSS1TSDVEVCIsCiAgICAiU2lnbmVkTWFz
...
eFVDdzNoVC1sczh3OGpMUSJ9fV0sCiAgICAiQXBwbGljYXRpb25zIjogW119fQ",
          "signature": "
i-zKSN2SQsNkZ436urCOOssErZbBZ366p_7YMSr1UeOevzRrMJECfpmPwKMLz8uf
VLKz2IQd3WDAqFVXE329X81ksn_ny-LYwdCkky8tkZLZAV80BxxzCwOCxZosJQ6U
KjXw-XBfP8vacKMoFTI3inlqirMg9DFLhI0xpCfdADmi3h_zbjAJEiGMduDGzoN1
Mfo06IjNznmwP2l8EiO8NU9HBO1DxmbEGXfxXfeoMbxwvatg88zS3kruAlP9ZCTR
kGrw-Gz3agKMnkUiqz-AGAxHBKwR3g-tX53clWh68BbRoVxIePsdNllS0GeFl6QA
nb7SPHHMqU_rmj4g6XnmwQ"}}}}}
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
        "Identifier": "MBDX3-63TCV-RO5RV-QMR6G-MI4AQ-LBYQS",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
FElCo3Cf5Ux3uIIL-uFd0A",
          "ciphertext": "
T4NJQZiGiZNfxdmz6R15zWRRCC5PiBbEM3PDnEbNHfaS0hrTNndAWIg5H5YujmfT
mJHWrkCR1r0_HNrniwUEb3BjbeK6DzJsqasYJLP5i798m0jLoxbISh1J9Ld6OeoU
...
0wxkGrh3HHXyhxtGGhZwUk9849UuEl-7j6pBpKPT2PRDr0rQSm9FdbU-k07t9TJB"}}}}}
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
    "Identifier": "MBDX3-63TCV-RO5RV-QMR6G-MI4AQ-LBYQS",
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
          "Identifier": "MBDX3-63TCV-RO5RV-QMR6G-MI4AQ-LBYQS",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
FElCo3Cf5Ux3uIIL-uFd0A",
            "ciphertext": "
T4NJQZiGiZNfxdmz6R15zWRRCC5PiBbEM3PDnEbNHfaS0hrTNndAWIg5H5YujmfT
mJHWrkCR1r0_HNrniwUEb3BjbeK6DzJsqasYJLP5i798m0jLoxbISh1J9Ld6OeoU
...
0wxkGrh3HHXyhxtGGhZwUk9849UuEl-7j6pBpKPT2PRDr0rQSm9FdbU-k07t9TJB"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


