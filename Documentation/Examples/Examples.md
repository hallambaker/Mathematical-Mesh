
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
Date: Tue 05 Jul 2016 02:03:24
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
    "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
    "MasterSignatureKey": {
      "UDF": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAJiIYgkcbzif-euD5qpfPncwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJNRTctNVFMS1otRjJTNUgtNjVXNlQtNTYyNDItNjRYR0ww
...
g7f3bhvDgi_Y6XGX7EXcJlnH3K4UsQoLv7SPOdeqUqe00il7UCHYj_daqw",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
          "n": "
2Jcvn2pTOWD-VVDZVKbUVLKj5TFs_E14rnrv6zHMrLWsdZ9dQUgoJTjmdbJ_v8mY
quxXehpMuV0DbBx34J4OKYQNIx8L0qN-ajKRBRRlfuSURtugnkU4p6vxi6Hc-UdV
AQw8wA7T-p0vpDSpKSZlAD58G6rgLyd905KbYQB5b8R92ZiIAnUkHN8FvJI8pD3B
uCkwE0MG23v-PBXJ2Thfm2eVadvRi-39KvAfhyCPhdkzolTNzS_lRSLI9QJG2TQV
eZbYqalrJpUteYNEAcexY03PnPR-z9LGj-NFfRdPEB98iwLchgihKIcNUk4t1JHi
MABmeArOzG-ySdZ5jspgiQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MDHZI-N2HBC-J62QO-ODHWV-MFSN2-TCOKP",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAPzf-Jxk_iunZaBM7V38nrswDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJNRTctNVFMS1otRjJTNUgtNjVXNlQtNTYyNDItNjRYR0ww
...
NgNQkBYeyXnFCsUb4rFh_0qhqyjRs3pRI6aDlYNAyycNXn9XOmPofPlctA",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDHZI-N2HBC-J62QO-ODHWV-MFSN2-TCOKP",
            "n": "
n9ED1J-EBgPVV6xSnNk-RS6qoG1aNdSWLPcMftN-f0ERkBQn1yu6go5CQ0q9ZyBe
M34vCnCI9_dR96Uibos6V-0HRyZ1A-aVndRP_XLqkmc94FvgeDiGs9ATWoXtFarV
lCkuyLm-npxu13EFmphViVb7maz7zlEv4GJ5Claob34sdM4qySr35ZZAuq9Q_IAH
6PlR5Jh6bgMfB0S7xlMS2MR3hV0-smWbbs6sp4xRSH3j5kOHrYY85DGaqQRMZ4lf
3FoO5MvndaeRm_xWwvuEFUAnOrFYbub4FXxpmxKNh9FfgQnme4lsYkOtyJw5DDzT
kuoOm-F8af1Vx-LouY8u1w",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MBGGH-N4EF5-L7S2D-U4IHC-QBSDR-M6QHY",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAJnbFqrPmUhGwKClDVtRzLIwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJNRTctNVFMS1otRjJTNUgtNjVXNlQtNTYyNDItNjRYR0ww
...
UkVaXR7pMxLvWzBKibic0LAzOpEgbrvjLHCTbf04CkKrGwU7JWsI1kglCA",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBGGH-N4EF5-L7S2D-U4IHC-QBSDR-M6QHY",
            "n": "
0dtLjf7IxEjN-NbiFvwx-Gz3YPc9Z5udsCm4cr7vLyV1F74G7lOOW6vvzHduVwNS
LgDSSdTMZDL_SCxXOu0kUQP6dZ4D1dUxRG50la8KIrKsYhzLgnllVuct5YL93Fl0
1-tTTFOycCX--x5fDNe_fuypM-e7OkNWwfdvxzu260Hy_l8Z7Ptgf4y5xheROpVB
R-QCYjSP9o-8ioh2TDIbJWr1J8FuyDg0ideVivgH3rv2mT48xUpOEJhzKf09amLH
7VnE550u6VuAvIMsoIQpOi1PcKdFWzXokifaZSQgVIFbheJUTn4rNmC0uHQqLeWF
c8UaMgpvBwBd84sGOndUpQ",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJNRTctNVFMS1otRjJTNUgt
NjVXNlQtNTYyNDItNjRYR0wifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJNRTct
NVFMS1otRjJTNUgtNjVXNlQtNTYyNDItNjRYR0wiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
      "signature": "
bfMrHcF7jA8D3zI_tPV9lgbEdlL1SA6iH38DhT1RWoog6UTKV49U8_RH0YM446PN
Mxjtwr0wEaGTYyM_D-8jHQMd2QsKG5Ioq9r8IIPIBggRDzu81NTiSDVP1KzHH04w
cNfFg6HtIKrH9lbc6HwVyNfcKL9tTlDwSbasXxrMIWJfdpQ1_zhHgtblCBF862oY
L_S9Tx4SlKYVqRqUgcKlitY6xxp1HLm-mA56ZbRLhbS9Dkx40Kck8OULjoZtyR4_
U9N5PHhMzXc7x2R6wZ0eBIbBY5MHgA3x_PdvfvHier7MrJ7d0XdsbuIfzkEjx69-
6xra2Doj-BTXASJjbqr7xg"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MD5KV-HBVOU-RZ3WQ-IRLXU-2GDWW-DESDT",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MD5KV-HBVOU-RZ3WQ-IRLXU-2GDWW-DESDT",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD5KV-HBVOU-RZ3WQ-IRLXU-2GDWW-DESDT",
          "n": "
vPvLLyOsftTkmG3X3vPqv4E0GArrA1KeCsRoo9HuWgsO-PIVxIXPNXEeaJZAd-FT
-GGuJENTyIWsxYBwwg9IxkLAtUPB3d-TpZXoczdQmBwbezC3t_AOWAntGRx0Brq_
EdD9_UNE8KvsqiFXbzdY4Kd8xFsBCNy1NRUmkRWi_PVjX_mQY6tLQPBajQ0Ab_10
etb5gOqgn2MT4MS2RcdhD-u-Ic2mIYDMvmBpITPT8hu_D89Faidap0szBtikoCyQ
g86rE5CC8k1jaNjHBGwxZJSj8_2ZnmmvP4asubHrtmHi0RKdfllikUqUHEZA8MRZ
G5cRg-qWwSE8Igs1pOsQIQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MDBNB-5AANR-D4AY4-U5DAT-H33PG-FROBG",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDBNB-5AANR-D4AY4-U5DAT-H33PG-FROBG",
          "n": "
3dJ2tlKGO02eW0EzY0tVojmoIxIv8hVLP1sJc1VJvZW0z2fzAQ1TfTCE_fqNuvYM
BYOeOpPkqAt7K8mtd9JAkrOLxXZuUOgCO5WHnsdzoXMHoK8OiCsDUmoh_Dl-5XJY
vIUEAwME2kGHtJaqCr5K2XFbydkzMoJDnCGv1KSEsLDEYVyCydKjRhBjsoOCUuvI
hkt-5ewrRUDJS-ZzZKXa6zx2XvXVRiacvyU6X-_kQPC5ilXTL4i9TdvJk-gKg_Te
OwDSiTjAqkE5O4iZyEmEZQvc4IZRuHaWalaf_s8edYbO26iF4pMxzos3EeEveH7W
mCrXTvGuakzay9udKHjTHQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MCW27-PQHPW-74AOT-RXCIX-CUIXZ-7EBUB",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCW27-PQHPW-74AOT-RXCIX-CUIXZ-7EBUB",
          "n": "
r23uNrtz9PJLF1zjJGeLUDAfYD8DLrwyDdgje3_9YZwcHdSsvcIQSDRR7jyDQX1S
fOW5pMlQCZhaiZxa6t-6f9GG6XAb_CfSEV32dNG_e8fjV25VaKNoVRrnmvFebG6V
c0RJ9kyULLNoGVKypQkW19ewxOjH2KwmehL5OYQvLYdxDNsYXO0SB-24iTQVFmUj
qS8p2A-GF0LwyqaVK-hG-Wtt10HlXVwB3eWwyuA8b2BUGAYrY0l1GIq9pU80i12f
KpHtagYO__aseIeN6MQoaJsqi10UuA3r0duyiwtfFQchHWeUIC5tecbYZmGaXtLc
XYgHGOtijUWA76ekSizEKQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MD5KV-HBVOU-RZ3WQ-IRLXU-2GDWW-DESDT",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQ1S1Yt
SEJWT1UtUlozV1EtSVJMWFUtMkdEV1ctREVTRFQiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
bVoMuXOqJPS2UpztTNjPnIXOyq5M-mJRpeQzdVUeR42d4qP5NyQraicnuA9mx7ve
Va2F_fVbPFAatUEHPODkPvkjXlDGp8BjfGdEwUBP7wIAJt_Ct2xlQxR8V5LGvRfj
RgNVsx1ggP3oe4bNlmifizA9OfFlwmInt-KXjqNMSAb2-KzeXsUe7KteEh1SGRPN
uY2swGwNk4II9UdK-Okf7COOmCG46r-ALbfKO7rFrM7n6pqkFIiIYoUfl8eO820u
ri92py33k_4-Z3wYi0ggqZC3EUZpRpr-t7sYcrFa-dQj1L677L77AnMqbAp53pEY
yu2JkCdpzffaGxZuf6yXXw"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
    "SignedMasterProfile": {
      "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJNRTctNVFMS1otRjJTNUgt
NjVXNlQtNTYyNDItNjRYR0wifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJNRTct
NVFMS1otRjJTNUgtNjVXNlQtNTYyNDItNjRYR0wiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
        "signature": "
bfMrHcF7jA8D3zI_tPV9lgbEdlL1SA6iH38DhT1RWoog6UTKV49U8_RH0YM446PN
Mxjtwr0wEaGTYyM_D-8jHQMd2QsKG5Ioq9r8IIPIBggRDzu81NTiSDVP1KzHH04w
cNfFg6HtIKrH9lbc6HwVyNfcKL9tTlDwSbasXxrMIWJfdpQ1_zhHgtblCBF862oY
L_S9Tx4SlKYVqRqUgcKlitY6xxp1HLm-mA56ZbRLhbS9Dkx40Kck8OULjoZtyR4_
U9N5PHhMzXc7x2R6wZ0eBIbBY5MHgA3x_PdvfvHier7MrJ7d0XdsbuIfzkEjx69-
6xra2Doj-BTXASJjbqr7xg"}},
    "Devices": [{
        "Identifier": "MD5KV-HBVOU-RZ3WQ-IRLXU-2GDWW-DESDT",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQ1S1Yt
SEJWT1UtUlozV1EtSVJMWFUtMkdEV1ctREVTRFQiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
bVoMuXOqJPS2UpztTNjPnIXOyq5M-mJRpeQzdVUeR42d4qP5NyQraicnuA9mx7ve
Va2F_fVbPFAatUEHPODkPvkjXlDGp8BjfGdEwUBP7wIAJt_Ct2xlQxR8V5LGvRfj
RgNVsx1ggP3oe4bNlmifizA9OfFlwmInt-KXjqNMSAb2-KzeXsUe7KteEh1SGRPN
uY2swGwNk4II9UdK-Okf7COOmCG46r-ALbfKO7rFrM7n6pqkFIiIYoUfl8eO820u
ri92py33k_4-Z3wYi0ggqZC3EUZpRpr-t7sYcrFa-dQj1L677L77AnMqbAp53pEY
yu2JkCdpzffaGxZuf6yXXw"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQk1F
Ny01UUxLWi1GMlM1SC02NVc2VC01NjI0Mi02NFhHTCIsCiAgICAiU2lnbmVkTWFz
...
Q2RwemZmYUd4WnVmNnlYWHcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
      "signature": "
eHD-qDjWV3ya2wkwrnpVq6Dl80iPgowgT9IXym4ZHVBnRPJ2t3N6hSVVDQ5LIq6G
XT5SAEvc0AQaXg6sIEYp9Wxe-joGjsRUc-cS22XGBllCn2WPz0a2Rp2Qu7X34VqI
U49TlKx-YAAKM5fAnZ5DJT86DpwXrQBhrH0D1HG48wOVVUpliKN9czIb7Tu2bvbC
6jxO-Oj7wJCnnkpH4_jXRLkcS1O9m6bIWhZ6oWf5EL0PHQxhrgfxuAfQxbuXgIyz
byGmEcRD-OSl1bGMMzCPjgDhqvi7qQXqQynUo8k3ZpK-D2vChdUPs7LXhLisL2mM
Ng_1pKoR7LHkTn3NES8LpQ"}}}
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
        "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQk1F
Ny01UUxLWi1GMlM1SC02NVc2VC01NjI0Mi02NFhHTCIsCiAgICAiU2lnbmVkTWFz
...
Q2RwemZmYUd4WnVmNnlYWHcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
          "signature": "
eHD-qDjWV3ya2wkwrnpVq6Dl80iPgowgT9IXym4ZHVBnRPJ2t3N6hSVVDQ5LIq6G
XT5SAEvc0AQaXg6sIEYp9Wxe-joGjsRUc-cS22XGBllCn2WPz0a2Rp2Qu7X34VqI
U49TlKx-YAAKM5fAnZ5DJT86DpwXrQBhrH0D1HG48wOVVUpliKN9czIb7Tu2bvbC
6jxO-Oj7wJCnnkpH4_jXRLkcS1O9m6bIWhZ6oWf5EL0PHQxhrgfxuAfQxbuXgIyz
byGmEcRD-OSl1bGMMzCPjgDhqvi7qQXqQynUo8k3ZpK-D2vChdUPs7LXhLisL2mM
Ng_1pKoR7LHkTn3NES8LpQ"}}}}}
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
    "Identifier": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
          "n": "
yI2IE3XwztAedhbQPd7lmDSarAphFyjS8WtjN_M1U7F15oUA0I6OA9ragkuP_uHG
1oZwwJJtAaT__3ZhOra1p4z-aD9M-oskkjriKD_Lsk-T-gB7RTsvnhV9J8zy1s8N
4tJCoq15N9mer5kDq3GZNTvknW2C6kWxZs1atj09lpqPVEf1cdrbWNiZGHkF4PfV
m_9ze5lWloxVUJDQnIStVVJM4wk6_4H-18U7aMu53nN35OyvZct_0mMZJwfgE5d3
MLWfQOMUzxGpOr1nc4yfczCJ8mCFgIds9LwW3ZITGGzr2-63h-uP6vbEUuMPRcRc
INsHzCPxnnZnx1FU6-Gb5Q",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MDH7T-2RHBX-X6G4K-52G4Z-4EF6A-PSTPI",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDH7T-2RHBX-X6G4K-52G4Z-4EF6A-PSTPI",
          "n": "
2jxA95p7DVmxyWl9uQI2CubzelVbhvHTL07WzfyGAn3GpY2lm-EQWUAPWFp4ENgJ
aWPh8Bkd2pAFHPk0ptMRwBt9NksLtSfY1ww6HFDF9ovbtnezVa-lU2RMZ60jGwV3
7MoWxqhMi51_XsbNzq__YsYOnicYAodvEicWrgl5WRkLR68c4kOR399m-u_HWfkK
9p6mEhWRIbPp8baqkmNZCwRESQzow63fQLlo9wRANBgk3QXpFw0JM2Doj1YbcvX2
gSLxBrWR2Ms-8pvuymRp0S47rCvMYgw65zQHu9SWwGZOktbC90ufSIdHQs2wz2O3
jdlXrF6-O6FCadprIiVDmw",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MAGNJ-JRPDN-AUY6X-6TL3E-GMDCB-IWW2X",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAGNJ-JRPDN-AUY6X-6TL3E-GMDCB-IWW2X",
          "n": "
xE6MD8YzTg3JAGgT1SV-IfOgQlFxlatXCzNtTR11aDSqEvGHF0-tTMHYb5YRUr_7
ALMS0LcM6mDHBZky_x5eGLqllMwVY4j2aEe8KvJDOHX7i7vFXJuITPAJdfHF6TD3
PSzHJKTWHB0UnCm41T29YBGgRKqjsdSJ9q6QZJ2v00AJtyoxEKAdsVeR8Hxe7ViW
79vBN1Ks6qlTLYfYgRaBUPaRbKTwh9JwS4rfs2wBEAcz4SFSZB621_Lg2p52pAnT
emNs7gaN4qJzK9g61TOPIryJ7UNejghyIsPkdXO4_7If0K2ZKEzaJXDEQR-9BGHh
z-gg03MvfBa08Kc534bVSw",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNWSUwtQ1RHQjQtUFo1QzYt
SEVWTlctNktEWUMtRE9XVEwifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNWSUwt
Q1RHQjQtUFo1QzYtSEVWTlctNktEWUMtRE9XVEwiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
TvOi_iILPNwTQxV65BVUadggB1OepKHlh8Pde8lzVBRBJIQhGGU2GWOogYDQVdE6
a-23xs0ERPAzZmaMSy0-5S-VBO12H2tkz9CejqKFBuSq22hTejuLXmiWf5RjT2WV
rUKvGgnqNldChFapd8FcCAiZ6g8J3LUO3hCQBThPpE0Z_-zXxBMJRA8d65WcIbL1
QtZdUIyYfX69L-SptwaOW3Yvrn0q7a71KDnPv-FS5BUN9-lykM9Qvj_9K-epdxe8
Aex3QdSdPpPeFL6RzLSiMvCu6veKs7X8OPaFaBN0NIcN6QhmNOfkk4giepDjSVDr
5nqAHHqq-ndID7yRHJeVMA"}}}
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
          "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQk1F
Ny01UUxLWi1GMlM1SC02NVc2VC01NjI0Mi02NFhHTCIsCiAgICAiU2lnbmVkTWFz
...
Q2RwemZmYUd4WnVmNnlYWHcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
            "signature": "
eHD-qDjWV3ya2wkwrnpVq6Dl80iPgowgT9IXym4ZHVBnRPJ2t3N6hSVVDQ5LIq6G
XT5SAEvc0AQaXg6sIEYp9Wxe-joGjsRUc-cS22XGBllCn2WPz0a2Rp2Qu7X34VqI
U49TlKx-YAAKM5fAnZ5DJT86DpwXrQBhrH0D1HG48wOVVUpliKN9czIb7Tu2bvbC
6jxO-Oj7wJCnnkpH4_jXRLkcS1O9m6bIWhZ6oWf5EL0PHQxhrgfxuAfQxbuXgIyz
byGmEcRD-OSl1bGMMzCPjgDhqvi7qQXqQynUo8k3ZpK-D2vChdUPs7LXhLisL2mM
Ng_1pKoR7LHkTn3NES8LpQ"}}}]}}
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
      "Identifier": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNWSUwtQ1RHQjQtUFo1QzYt
SEVWTlctNktEWUMtRE9XVEwifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUNWSUwt
...
TUEifX19fQ",
        "signature": "
fqo-gPmatR1SiIYjPJlPixWsDrp2PyLIJz8NgErqXSLKsOPoxLxlu-lJLZUCTk14
hWgmb7ZI4c2WnEziHnuCQxJSLuFhF5mXWqE8Zb2Vun_OiQMiozzMSPYzRFraXA0U
R8NG5J31nlvDmCBaD6O6dtDnqbTCFAPByydn1mQLeqmgmcVw4YYASt8NbOPaaLwM
jASwQmGrk3vFJ4eh7ybU9RKlLNjbMDXubIkXUCnQzC3ipcveq-_6kM-bUxdpcTC1
tq8G-aWDVGuMP1WweA86rjVQXkh8O-f4x2_96tWfmubS97EunBHBGs_xSo8AU26Y
jRAgxs-76gXSN9-wJH77wA"}},
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
        "Identifier": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNWSUwtQ1RHQjQtUFo1QzYt
SEVWTlctNktEWUMtRE9XVEwifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUNWSUwt
...
TUEifX19fQ",
          "signature": "
fqo-gPmatR1SiIYjPJlPixWsDrp2PyLIJz8NgErqXSLKsOPoxLxlu-lJLZUCTk14
hWgmb7ZI4c2WnEziHnuCQxJSLuFhF5mXWqE8Zb2Vun_OiQMiozzMSPYzRFraXA0U
R8NG5J31nlvDmCBaD6O6dtDnqbTCFAPByydn1mQLeqmgmcVw4YYASt8NbOPaaLwM
jASwQmGrk3vFJ4eh7ybU9RKlLNjbMDXubIkXUCnQzC3ipcveq-_6kM-bUxdpcTC1
tq8G-aWDVGuMP1WweA86rjVQXkh8O-f4x2_96tWfmubS97EunBHBGs_xSo8AU26Y
jRAgxs-76gXSN9-wJH77wA"}}]}}
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
        "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQk1F
Ny01UUxLWi1GMlM1SC02NVc2VC01NjI0Mi02NFhHTCIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
KBtucC5HTlN6iAo6f28D2mSyD098n4vPywR_zKFIcrDhTrvv92fu7fUGnhQQ7FrA
mzZxMC0mSX9B435y5qGF5V9OmPkAttF1kOIJDGF2ukGTGJb9sdxlsG70sVfNh7Hw
ICoHHQAWz-SPWs144yRQ6GR7oTNZQ59hAztvz7sWZyDDhC14hYTqjE0wMwM42m9i
hx4JHarupkh8QhD_PHchkYEvpNpHWMBjnTL_CoTF11hyfeP8XdSfaevr6IG97aR7
SRY9pBX992Fa_d7emn-1zFfpGM726KPPqXPoRYZH4wUBwn4VeZPVFxvtN8HxhbJf
DbTtcCNnvq1gE_KRdvFleg"}}}}}
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
      "Identifier": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNWSUwtQ1RHQjQtUFo1QzYtSEVWTlctNktEWUMtRE9X
...
dGVkIn19",
        "signature": "
CA5sAV3sJwAN5lN0X7Mm8HfUiGQ0tnRW-SEU05h50BnsgX1-KusdIwEc3eRKDRgl
Rqxjx5Pwthisqw0kUG8zWKEW3pv1ODCnQQjobkxGWtd-QswMVITydQUS-d4iqo0h
Pz3i3Zi_ojmd-XlHbsoy69W-XSztgohZ_9o6dP8wbjoKsHCKfcdaxXHrXNqBAM2t
g7ZG6nN5br2tB3f1wE_0kfaXatBKFfmYLTjP1Izn7zpGZYf_aOWma406E7O1AK--
vgQYlvGumeZLZ7tW1xqZT8dKgHHpcSX__f4cHo4XxdkO50EFlmrxDNzyyhptZBc1
ksIRPzFoLpjZB38p8RmRfw"}},
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
    "DeviceID": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MCVIL-CTGB4-PZ5C6-HEVNW-6KDYC-DOWTL",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNWSUwtQ1RHQjQtUFo1QzYtSEVWTlctNktEWUMtRE9X
...
dGVkIn19",
        "signature": "
CA5sAV3sJwAN5lN0X7Mm8HfUiGQ0tnRW-SEU05h50BnsgX1-KusdIwEc3eRKDRgl
Rqxjx5Pwthisqw0kUG8zWKEW3pv1ODCnQQjobkxGWtd-QswMVITydQUS-d4iqo0h
Pz3i3Zi_ojmd-XlHbsoy69W-XSztgohZ_9o6dP8wbjoKsHCKfcdaxXHrXNqBAM2t
g7ZG6nN5br2tB3f1wE_0kfaXatBKFfmYLTjP1Izn7zpGZYf_aOWma406E7O1AK--
vgQYlvGumeZLZ7tW1xqZT8dKgHHpcSX__f4cHo4XxdkO50EFlmrxDNzyyhptZBc1
ksIRPzFoLpjZB38p8RmRfw"}}}}
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
    "Identifier": "MBVBG-SM37C-7P5OT-VRAUN-ZSQG5-3BAJW-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
WSE2zrH3Fz8snMqzno2zLQ",
      "ciphertext": "
SRIoO5rXXBEwHKwWyeXO3xItPBDJv5e3EIuWomBX7gv2-f13l4q7SdpacyfENR8R",
      "recipients": [{
          "Header": {
            "kid": "MCW27-PQHPW-74AOT-RXCIX-CUIXZ-7EBUB"},
          "encrypted_key": "
N7175Zjy5dDK48fc_Li7VCqXNt-wOe-st9JXRziYdL1mOQBrO-6Qhof0DzuX0tvO
yZjuCTpUUj6ZQxhr2dUy0n22WCwk5b309uT2Sa-QQRe_2glICb1vpp0CLOiFU64V
L08eg_Wy_9DG90jhIDWf-L5JoxD7BI2dZaGaEm51PU7nPu5DBPhdMejH-K_ZICNZ
5YKBpQ5JlWnN0d3kK6NlYDCFakUCXLqZwj-SefNgobwAUIio3kn8_rlNfEFbBs8f
9opA2k4w_e3bNs5fqsxW2iWQ_9P19l1IgefJioqWt9RniaSopYvJqyBTZiNC5IAY
EJMZ4MnQqXcf7OCY02ddOw"},
        {
          "Header": {
            "kid": "MAGNJ-JRPDN-AUY6X-6TL3E-GMDCB-IWW2X"},
          "encrypted_key": "
FZluqAmcbm4F2uaTDNbRlBWe86MYLLCForKQBGdpEjTAZhoTlh80fPPg-VZHXZPm
lM34SLrFBR4Fu-I13oRDzhluKSOoPviolzbBQOWJT4Z24fvqF7kNvkOa4c0NfQ5r
g09gtitVO-w_xAH7cZw4f0Dz1nN1SosSRp9gAPnF5Pc91gjr5mxd-pf4iMBanfAq
KTxq81FZRErCFoeFPOPZZ-bdIOmyt4jhd3_ILS_pvU_uZgBY2Rix2pWa6_ua5uGx
OQ24h5fwKSJB6ibrl1FrGBn6Pgvg05FCJo-4LwoKCo6woGFNT-ubHz_tP0OcyPsE
9RYsGzahx6XyTgXO_m7_Cg"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MBVBG-SM37C-7P5OT-VRAUN-ZSQG5-3BAJW-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlZC
Ry1TTTM3Qy03UDVPVC1WUkFVTi1aU1FHNS0zQkFKVy1BIiwKICAgICJFbmNyeXB0
...
Ykh6X3RQME9jeVBzRQo5UllzR3phaHg2WHlUZ1hPX203X0NnIn1dfX19",
          "signature": "
EyUDZ1nV-NmTzLSSOpbdPwdQMPA9dIY670l6MaH8Y6ZMsxniXdZ2lnVeRh3G0PHx
FLyBRuZ_YfkcIc93DE03EghRHQjot61GiwyjCS5PQxd-8tgJ2VaNRFHATjDEXaN6
tPzG-NIE2wovDG_oqd5sm5i0OSD8ajI7Wn2t-UCGNYbNT8P8vQUB5TY6FxyH1V-v
9mpbiq-ZnHgPWTCvA0ryUuTPhMKdmB-nGJVUizRTUqli0YKgFI5nsFhjsRzooHPS
w0noHsAISW4nakvV2i0Zf6gZm79UdR1s410c7A6t-qnGFDaUssrrQMb8v1rVUZXO
CxmgtW3EEUFjE_GVv830ow"}}}}}
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
        "Identifier": "MBME7-5QLKZ-F2S5H-65W6T-56242-64XGL",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQ1S1YtSEJWT1UtUlozV1Et
SVJMWFUtMkdEV1ctREVTRFQifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQk1F
Ny01UUxLWi1GMlM1SC02NVc2VC01NjI0Mi02NFhHTCIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
KBtucC5HTlN6iAo6f28D2mSyD098n4vPywR_zKFIcrDhTrvv92fu7fUGnhQQ7FrA
mzZxMC0mSX9B435y5qGF5V9OmPkAttF1kOIJDGF2ukGTGJb9sdxlsG70sVfNh7Hw
ICoHHQAWz-SPWs144yRQ6GR7oTNZQ59hAztvz7sWZyDDhC14hYTqjE0wMwM42m9i
hx4JHarupkh8QhD_PHchkYEvpNpHWMBjnTL_CoTF11hyfeP8XdSfaevr6IG97aR7
SRY9pBX992Fa_d7emn-1zFfpGM726KPPqXPoRYZH4wUBwn4VeZPVFxvtN8HxhbJf
DbTtcCNnvq1gE_KRdvFleg"}}}}}
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
        "Identifier": "MBV4Z-UA6GF-V6CNW-4NUXK-2OUXY-WXQBI",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
Fax_AbuoHWJeo-mRmR6byw",
          "ciphertext": "
PDgUy1j1aohZKEJauezEYlhbw3N9AuIfNgaDgED8xvL539HceNxtJC7IF1b5vv_P
UQMLbgp6ja5xr8oFlTl4HMLZQd0-5uJVPZ-swrfCjq5pdvfzsIE6-u3isB2ol1pm
...
1Ei4FQqmTZyFuH6oKiKqGRek4q_yuOmS3fhIzuKp1ov-d5j_Nzmyi0uJ_zUO_dQm"}}}}}
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
    "Identifier": "MBV4Z-UA6GF-V6CNW-4NUXK-2OUXY-WXQBI",
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
          "Identifier": "MBV4Z-UA6GF-V6CNW-4NUXK-2OUXY-WXQBI",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
Fax_AbuoHWJeo-mRmR6byw",
            "ciphertext": "
PDgUy1j1aohZKEJauezEYlhbw3N9AuIfNgaDgED8xvL539HceNxtJC7IF1b5vv_P
UQMLbgp6ja5xr8oFlTl4HMLZQd0-5uJVPZ-swrfCjq5pdvfzsIE6-u3isB2ol1pm
...
1Ei4FQqmTZyFuH6oKiKqGRek4q_yuOmS3fhIzuKp1ov-d5j_Nzmyi0uJ_zUO_dQm"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


