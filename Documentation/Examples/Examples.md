
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
Date: Tue 26 Jul 2016 05:22:27
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
    "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
    "MasterSignatureKey": {
      "UDF": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAIX7aqN7YsG_Yec9zLEufy8wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTURFM0wtTVE1MkEtVktVS1ctU0wzUlYtQVEzQkQtTlhWVVYw
...
9kg54crlehHrxh3w9IK8HUgXqmPV1tVh9bXi34HUTxTSQOSa6XlBbrvIJg",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
          "n": "
2tF8B-WtkqJ0twapn1lwhIpKt1p1IcTtzO76Vr1avVT1N0BtNUgvhxOXC3t151Ug
CkC_vYwAIuOwl06vwbR4LGbvaWTVSq8xOJFeuX4Xf_zVoFfprRcAYQ-odH7TSGJA
yfDiuhYtSe_ju261HcErjT6afMA0c20fqppThdMJDjxHp2aPrnLmO2axFSVUh_Nq
Vznut1ru7SCuU12mNI7Cv0ZCLz--fiEbuFoQJbyi6G4ITvUWZnr-EnYr--B4ZyKK
AoRyfw-2_8L5leYM4QGKvTf-R3LZQwMPFp9Yyxtta6WPBgI4RaRLtauONBLEI9xU
ko2L4U1MJy-AVRWvoo2L3w",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MDZDV-CBWA7-BGDM3-ER3DO-QGCXS-LOJAU",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAPCbqV9xE-iUq2xmQk0BxZgwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTURFM0wtTVE1MkEtVktVS1ctU0wzUlYtQVEzQkQtTlhWVVYw
...
tcnTqsxBdNYO5SrCIfHwPJP7JujaBzBXnlCwc3wPyhaiBaMEQA2fnOAPHg",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDZDV-CBWA7-BGDM3-ER3DO-QGCXS-LOJAU",
            "n": "
tSgc99jmwL9nvIK3m-9CKuHpTHWbeuJtZj_y6cSmcVPH2i6yexOfk6Kp_iio8d8C
r-fN4lduAN2TuuZPNe4vAejJu7la5l4UfxaTTegJSq_7Tnk6wiqTqKY0ay-_9L3-
qhBHE_FaRHYWWBwGKIUxJNSxKr43ua5H3Lg6L32HBxsC8Z9Va5teXaZClrcZU3Wx
5-Q5iuhTnwSUgoGpZ2qNMMSJOexW327wEvtCgtbD06gZyHgjM0e-cbKToqFYr1vs
9QO1TSnHAV6TA7lVe7GENMeIQaYGjV0UpKml-QyisjJBO4-xfpJd1kc2DI7DXGBC
Yb1C2vsQVn0y3asI5Iv_Qw",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MDEJ3-D6FOT-5INW7-AKFMT-TUYMP-4G2YM",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRANgefRcISeXM6F0P8lgsOScwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTURFM0wtTVE1MkEtVktVS1ctU0wzUlYtQVEzQkQtTlhWVVYw
...
6dSQYztFKxebnxYa3b_fqGv_sSD5fAOjbL9OemLFsKYCrOU704A3ZZrgbg",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDEJ3-D6FOT-5INW7-AKFMT-TUYMP-4G2YM",
            "n": "
u4KdM8ipppueIMGKZHIpoPyd7p3_yXe2GQGfw4fp5VQbnWPSxWuSRz8u4IZKTjVU
IQHLtsFopesAAYTzFMRyS2qjbO6CYUFN7YcdO2AvWRv-vgTukMRQ21shfGtVT9hZ
6Jkdc1JryatK2uiPBeMjuYzPhCCg7i5jcsNhk494xzsiNIW1LkAjVVcxsuU6x2NJ
RMZWul9ErQJR9EXdl2pB-WqgLC-FBmlhKRcSOmFlAsirlzOqbPaayFh2iSh2IBub
0RyNlcK7qgfEykoJZO1FKVWjXyKJSyJaSRWl0ayOqOYxQlWKB4LlCEOfo7MYvjoV
Qwtdia43wu2dBuB-_yQONw",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFM0wtTVE1MkEtVktVS1ct
U0wzUlYtQVEzQkQtTlhWVVYifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURFM0wt
TVE1MkEtVktVS1ctU0wzUlYtQVEzQkQtTlhWVVYiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
      "signature": "
MjiG_61xtM0T3gUPO4bZ1KCpEzc52pYb2Zk2eMYCwjUGNnSc3-f8mey9SB0HUOJb
o91lJ8NcN5_Z786DsCbKzgnRD5GkKQwMsQJx_15S4QSPSSNexzTj2IErLx8Qyh2f
PWTLVJUT8k5FICGLalb_d69zY0peENxjrvJYIiADCUaqQZOndfaLnvt3Lq7-0juV
jqoPSqCldDLFls5Ujzhc3ajCdyVGcblWFNK0h6Ffkm1DjmaUcgdwS0_XrHJkE01_
jWwlD23VyjEglGmXuvXwuTHMkDQlXyj5HcdD5vuwHOdH3eO6qfIv2dWQAq1HNiOB
WXMPMLCHgS6zr2WO7LEEQA"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MBYA2-FXBIC-D26SO-FCTI6-6BT27-6WY7H",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MBYA2-FXBIC-D26SO-FCTI6-6BT27-6WY7H",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBYA2-FXBIC-D26SO-FCTI6-6BT27-6WY7H",
          "n": "
22D1KjASE76TbsC979bmdpjcD63UGi4-xsvE4bMnBNsRvM4jl8oI5u7UUOl7Gq56
pyFxiPx7QkEyBjMooO16bzMQEiW-1ssVWRHIjDZ3HfJ-cdldLtRGgKpRK4mZq5QT
E1s25oJdPjfQEpoinqptsM5FYDWVdw-mNJsDraKdu_0qJS9McKg3kzq08zv4aBX3
X4uhz-ytDiUO8tv8eUNI_1H-t_4QbIMsuyrlilVxuTBcZf8Lx0kqAw9d6w3o0XaC
Ft1hkIHqdEuDDHSd4vF9Ebdr1LwGi1ao8aBHSOvefZR88QVaX8OX_BYw15Bx_JK1
q9oWWIFy90ndmW21UN3pfw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MALC2-KTV2H-VWLFX-OPVLB-PJENA-QSEXO",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MALC2-KTV2H-VWLFX-OPVLB-PJENA-QSEXO",
          "n": "
vTz1yO1o0v_hHvu2UaC_YEDly8luh8C4Xzm7750KALW08q4W0gx1h8ecC8DXYBhn
BD6NyB6Th_EDOsjylwexjEn84Qpw0p5UIcAkuByOV1w0yKoMrjfcthNTlAC8VWT7
3K99kp-xIPc4pjkr3Y75lSoD897I1MMOx8amVCVuprA3LPtAOzVVqkfzB3eeOMiQ
1mdOR8y8J_0jFBMam8hkQGcoTLv01vUxUbTodi-q42d2agkgWjBlcAH2dGJlT5EE
tZre-7jRYAnd2Z0vrQvgC1in6_tAO9FgQBHj0Cbay7lC2KtKxVEq23Xdt51TVEPk
9Os_9850CR6rCp_Gz50KCw",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MAEPJ-2YTTP-UIVVR-DG4U7-DT3TX-L2JAO",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAEPJ-2YTTP-UIVVR-DG4U7-DT3TX-L2JAO",
          "n": "
6V_jDRKOYhRmiVGZsRPTGxQf4ucTen0kzHIi9xE2TDIRq-jBlPazDSF-VeGdi2-J
KDftXJTtdWOL7NGgOOTJ3FeOsQWVFb7kbv8rIaaMjIw4bFQiVx3rH7gz9O5x9Pdk
1UnEixZkuoKMSxdZ_NkGy955yMKILoMu_sD0c0bzpFY15U4C2tHioHIpz3E7EMvq
ncEvE1IYSv_i8Y5Fuu-HnuS8ohXFqIA3nYPsS0tfPgA8jgwsuua8kdlA9w13aFpx
sbSn9HZ3rab25Yq7RifV85SwmCiQ51JIIAW8qghpADa2A9-vpl9NdXYfVwXoba8H
YzncB7GvTfGquPbM7-xzyQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBYA2-FXBIC-D26SO-FCTI6-6BT27-6WY7H",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJZQTIt
RlhCSUMtRDI2U08tRkNUSTYtNkJUMjctNldZN0giLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
bT1HWmxxcyZA8q9ULN-icQntTXNBlUilMb5lRsTcEXOY5Arci-wnrcLm1Vqm4oox
MHfTRacbFcqGzvbBvg_rENktk-wwgZCBEn8Itay5uW8HsgWPthiMIdnrkFnW7vfl
fgL96H1R8b-Wu4T7nvezx_zVpmUce6Fk_3iM0uw0gGMzQoVpzPVfpyVzQ8mz_hOY
B75wdIyR53ZZBE3QjRgLu1k3X2fbUbyMuN5ZzgOvE24HCU86wd1DR5nR9Re7kYxe
GDcbl_AufDoqEYbGwz3kY8I1UuYlAi16DLg9cUcosylF9N29XD6ofcDCe9GXwuwF
kilx0JTHuU5rJTPhZE5ymw"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
    "SignedMasterProfile": {
      "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFM0wtTVE1MkEtVktVS1ct
U0wzUlYtQVEzQkQtTlhWVVYifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURFM0wt
TVE1MkEtVktVS1ctU0wzUlYtQVEzQkQtTlhWVVYiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
        "signature": "
MjiG_61xtM0T3gUPO4bZ1KCpEzc52pYb2Zk2eMYCwjUGNnSc3-f8mey9SB0HUOJb
o91lJ8NcN5_Z786DsCbKzgnRD5GkKQwMsQJx_15S4QSPSSNexzTj2IErLx8Qyh2f
PWTLVJUT8k5FICGLalb_d69zY0peENxjrvJYIiADCUaqQZOndfaLnvt3Lq7-0juV
jqoPSqCldDLFls5Ujzhc3ajCdyVGcblWFNK0h6Ffkm1DjmaUcgdwS0_XrHJkE01_
jWwlD23VyjEglGmXuvXwuTHMkDQlXyj5HcdD5vuwHOdH3eO6qfIv2dWQAq1HNiOB
WXMPMLCHgS6zr2WO7LEEQA"}},
    "Devices": [{
        "Identifier": "MBYA2-FXBIC-D26SO-FCTI6-6BT27-6WY7H",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJZQTIt
RlhCSUMtRDI2U08tRkNUSTYtNkJUMjctNldZN0giLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
bT1HWmxxcyZA8q9ULN-icQntTXNBlUilMb5lRsTcEXOY5Arci-wnrcLm1Vqm4oox
MHfTRacbFcqGzvbBvg_rENktk-wwgZCBEn8Itay5uW8HsgWPthiMIdnrkFnW7vfl
fgL96H1R8b-Wu4T7nvezx_zVpmUce6Fk_3iM0uw0gGMzQoVpzPVfpyVzQ8mz_hOY
B75wdIyR53ZZBE3QjRgLu1k3X2fbUbyMuN5ZzgOvE24HCU86wd1DR5nR9Re7kYxe
GDcbl_AufDoqEYbGwz3kY8I1UuYlAi16DLg9cUcosylF9N29XD6ofcDCe9GXwuwF
kilx0JTHuU5rJTPhZE5ymw"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREUz
TC1NUTUyQS1WS1VLVy1TTDNSVi1BUTNCRC1OWFZVViIsCiAgICAiU2lnbmVkTWFz
...
SlRIdVU1ckpUUGhaRTV5bXcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
      "signature": "
D-bbS_xYkAYKPK5bJPoA0EWesDJ2c5Sy0ww2kZCi9J9_B-i4IRjgszwQU5hdsNrG
mn0QsWe3oqQy1MiMxZ2dwsD8Pu4AdQ60pFYFhECP1hwjMvThEaydmp9nKKMFC6VJ
lZfKguC4kSd6Ffmr4SBf-B9Jp7uFre6VJFtcWuXjYGIrc_hH0cEZaHFaXuyAjiqd
CA4Z-Fz0Si9kgEFvaO4IO_8pgwyPXjUrpNBputWGAIFSmu6K8dVHHl6c-Z1QTgwb
sQrkyRLokN8RgMHwDPSsO571so0lLQTNRkYnnBeD6t2CjRSiL5KAVeA_eFBirF-L
NeNByQpS1d7a-iwlvaeS4A"}}}
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
        "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREUz
TC1NUTUyQS1WS1VLVy1TTDNSVi1BUTNCRC1OWFZVViIsCiAgICAiU2lnbmVkTWFz
...
SlRIdVU1ckpUUGhaRTV5bXcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
          "signature": "
D-bbS_xYkAYKPK5bJPoA0EWesDJ2c5Sy0ww2kZCi9J9_B-i4IRjgszwQU5hdsNrG
mn0QsWe3oqQy1MiMxZ2dwsD8Pu4AdQ60pFYFhECP1hwjMvThEaydmp9nKKMFC6VJ
lZfKguC4kSd6Ffmr4SBf-B9Jp7uFre6VJFtcWuXjYGIrc_hH0cEZaHFaXuyAjiqd
CA4Z-Fz0Si9kgEFvaO4IO_8pgwyPXjUrpNBputWGAIFSmu6K8dVHHl6c-Z1QTgwb
sQrkyRLokN8RgMHwDPSsO571so0lLQTNRkYnnBeD6t2CjRSiL5KAVeA_eFBirF-L
NeNByQpS1d7a-iwlvaeS4A"}}}}}
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
    "Identifier": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
          "n": "
5D3To43RX0nk1ZhATeW38ktYARM4oCRV09O4iGIprn2C1r8TbP5RpkLMzko_IUr6
Sw_Q_-WxtyjnakkD-p7OAixgfjz4QOlAyjKoxaDwS9bxpsxREJEWEEJPSvU9Ri93
aLFzFuSUGB14MPo-7Ud240wXDH93xPiVlPlYh3-aG8PkUfIfhVcPLbVW93aE8Z0X
lg_GOUUZfXfMdwysVLI3r4u2WsMNAY109exvrurorHoLeYQcfQknGHTrsrXdvIP9
hfmhWmJwh_12BSTQF_lnUGrCPLylLmguh98dMJ3RT_Wzp6T-BXRzK5JJSxq5kkkM
m9aVFee-PRcimdbCI5XmMw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MDBK6-QFIOS-FC2KC-CPJC7-YU64G-MU2TM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDBK6-QFIOS-FC2KC-CPJC7-YU64G-MU2TM",
          "n": "
v5g0FjeWUpjSbNRl8b9K3wI0xY-IojYYMqCU9mg7oJHviFNZr_oHk87xYuFx-apy
kHNyR5abbnE4cveT1ZI4tDkZ205kFkfTm8srtH1x_n6dlq5cRWCXVoltHDmdKP02
GGLv-mQz204l0NTqQHf7GeEYGcnwmokJ8W6yXDB0eE7GoA20WisKiFFhQREmCF9s
ZT0M1X99eEY3i63s1PTK3IlwPV09OpOlK1O0dV9XLRbK5rL7uEri_cNKluhGho3n
14YwOIj3d3EedtffF2qpAWcPO6yXu0FIRljLCpfJc3GtuvcPpgmyC2gQ1yZ8-um3
wY4qAhntR3rYghwh-SNsgQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MC7TP-QRHUB-42UY6-OAPV5-WRQ5K-AJLOM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC7TP-QRHUB-42UY6-OAPV5-WRQ5K-AJLOM",
          "n": "
zZEMb-0LEf8JLWNqLIEoK-DgbHq2IX0gGymCLg6UVGDcpLOOfDjIHferU3IkZdhp
gzmDUJACSLjq_z19xGxxjGracEItCRtg9xFPZxr4KXRCawMtPOjo_d9T6s3K1tgf
rBjMMJlALDrIKFeKgGPkbuZfaGhFqYKTMVmrjJFW6JBsinzuOrF1VIfiwBSMicoU
oLumzriXj6im4Ti3mB26OOdj9gqPyI9LRd_-2xwX49_Kb7yaJbNmbZNsL7e64qCI
tKX4FB9Nov0lK7kOHWaDBDUi3oJRwzLY2-ucGetYctDwvaZ__1wp1iwbFhfGukHP
kSYh3lUT4VJuBRI_WXsFEw",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFKUVctTVFIR0otNTRVVEUt
Szc1WjMtUTJNSUotSkJPWTIifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFKUVct
TVFIR0otNTRVVEUtSzc1WjMtUTJNSUotSkJPWTIiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
KE2dBGtR-7N0mEy2k_TD9OQoKuK3jDF_eDEFroZevT9JnDnxeikGWEEDrTFRYy7J
egP9A0CdUrRVoQTJv4Lipah_FaAKFa9TR-ygQeIxpgaijydrQOo8XsOcOku66MGy
wQPDefWPsJLd1wBgZjpYLa08wmETxF2RJDjtC7hUNFbIX2OQmnY3ILdrFxxaM4LT
5AkSm-xCwz-xq2T4XY39ISW2mFRvNnY6NvmrteuW0kk6KLHetN3nuRBYWJkuVXyP
nmlaFEPesmaUZUneAIXzHviz9PVQKMjEcWm5kQN8VG93PcgiiKaeoLC2ZOM-h58_
bcDIpKJ9XMQL5bSdGhrwxA"}}}
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
          "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREUz
TC1NUTUyQS1WS1VLVy1TTDNSVi1BUTNCRC1OWFZVViIsCiAgICAiU2lnbmVkTWFz
...
SlRIdVU1ckpUUGhaRTV5bXcifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
            "signature": "
D-bbS_xYkAYKPK5bJPoA0EWesDJ2c5Sy0ww2kZCi9J9_B-i4IRjgszwQU5hdsNrG
mn0QsWe3oqQy1MiMxZ2dwsD8Pu4AdQ60pFYFhECP1hwjMvThEaydmp9nKKMFC6VJ
lZfKguC4kSd6Ffmr4SBf-B9Jp7uFre6VJFtcWuXjYGIrc_hH0cEZaHFaXuyAjiqd
CA4Z-Fz0Si9kgEFvaO4IO_8pgwyPXjUrpNBputWGAIFSmu6K8dVHHl6c-Z1QTgwb
sQrkyRLokN8RgMHwDPSsO571so0lLQTNRkYnnBeD6t2CjRSiL5KAVeA_eFBirF-L
NeNByQpS1d7a-iwlvaeS4A"}}}]}}
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
      "Identifier": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFKUVctTVFIR0otNTRVVEUt
Szc1WjMtUTJNSUotSkJPWTIifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFKUVct
...
eEEifX19fQ",
        "signature": "
yGWl6DfjSJWtPsSx1wb0DkFiYOQDvCAAwcy8OfzbFJNPAGG6qoesAb8m4LIETxmq
BkAF3J_AatTjx3rwQ_R0Bt5bVomv8mZzQxH4lMbHLXT5Afxjgute6dn0lCF0lytS
RoEPtmKdYiLugg59BrfACyS1YU_qgp_t4cycAUOTi2kU5O_xmqe-wcTrSr5lteUj
Qc0dKSWl_6khQrzES76XftJIlFu2nnJ0bzWszXI9eK0tXZdbFKB4jJBOeKqNIW0G
6fIsXswraCO3gbFNUNtEqGTbKjWToUWBFBg__PB8mkmAFHX6p7n8HlubclIm5tsZ
4r5udQH8Lth5waUwENOmow"}},
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
        "Identifier": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFKUVctTVFIR0otNTRVVEUt
Szc1WjMtUTJNSUotSkJPWTIifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFKUVct
...
eEEifX19fQ",
          "signature": "
yGWl6DfjSJWtPsSx1wb0DkFiYOQDvCAAwcy8OfzbFJNPAGG6qoesAb8m4LIETxmq
BkAF3J_AatTjx3rwQ_R0Bt5bVomv8mZzQxH4lMbHLXT5Afxjgute6dn0lCF0lytS
RoEPtmKdYiLugg59BrfACyS1YU_qgp_t4cycAUOTi2kU5O_xmqe-wcTrSr5lteUj
Qc0dKSWl_6khQrzES76XftJIlFu2nnJ0bzWszXI9eK0tXZdbFKB4jJBOeKqNIW0G
6fIsXswraCO3gbFNUNtEqGTbKjWToUWBFBg__PB8mkmAFHX6p7n8HlubclIm5tsZ
4r5udQH8Lth5waUwENOmow"}}]}}
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
        "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREUz
TC1NUTUyQS1WS1VLVy1TTDNSVi1BUTNCRC1OWFZVViIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
ElTedwe5ExLT7SVeVY7ROVFx6U71IGtFTdIbArL7YwBIrSG_ZleA8b-CvuXdkt3R
d5w71Su_ltbnE1JloDhpKFpB43O9vqLmET5I3zTxW9REjVaBc1bTU4NA21pNASm2
RzhzV0o0ng51eGVBwvhnO5T12Ho3LO1LHPvZtJ7KdxuanAU3L6-ZwEPsU0NVEj-M
H5J0kA80rwRy93UcFYH1ayP6iS6VhNvUMW-t9zGHEfgqHXx-NAMGU_XpQj1ra27T
lZJaqYLxYU_3xJg3WaZAMUQ58RYEn-N4R5CoYg58EFAiNMBmptjVEjRODzhM8FM7
hViwoMzUsvbv19l1szdyHQ"}}}}}
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
      "Identifier": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFKUVctTVFIR0otNTRVVEUtSzc1WjMtUTJNSUotSkJP
...
dGVkIn19",
        "signature": "
yUZ73vapRDyUA70HULhGhth4flZ7d6vGRHIKzlypKsA_X1yLCjgFm558Rc-Ox7mx
uYUDSIOJdezbqKby5tQkluYTv2c8-r8jSxO8771qhISyVxUqJ_5h591eE3SB9Mm-
mHUXatGbTAv35QS7CGQacve1KrP-fdf6H_la24wLG-7sodf3r5vBcHjM1w0gQzjt
gYczj90Baj1NCsWb6Gr9dJ6sT6n5tO4wdDrkhwPrMzOtypQkOIZ7LXmzNSyO1FAU
c5UPzdeB8P4fiNb0WJWK7VJjNX3wXx0wHGzyzesSbNgVzPiT6Qv09BVj7OmzpaLC
sSZMzjU4zHKi7EEjkDAPfg"}},
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
    "DeviceID": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MAJQW-MQHGJ-54UTE-K75Z3-Q2MIJ-JBOY2",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFKUVctTVFIR0otNTRVVEUtSzc1WjMtUTJNSUotSkJP
...
dGVkIn19",
        "signature": "
yUZ73vapRDyUA70HULhGhth4flZ7d6vGRHIKzlypKsA_X1yLCjgFm558Rc-Ox7mx
uYUDSIOJdezbqKby5tQkluYTv2c8-r8jSxO8771qhISyVxUqJ_5h591eE3SB9Mm-
mHUXatGbTAv35QS7CGQacve1KrP-fdf6H_la24wLG-7sodf3r5vBcHjM1w0gQzjt
gYczj90Baj1NCsWb6Gr9dJ6sT6n5tO4wdDrkhwPrMzOtypQkOIZ7LXmzNSyO1FAU
c5UPzdeB8P4fiNb0WJWK7VJjNX3wXx0wHGzyzesSbNgVzPiT6Qv09BVj7OmzpaLC
sSZMzjU4zHKi7EEjkDAPfg"}}}}
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
    "Identifier": "MDMTS-FZHC3-EFGDT-NT4Y2-FTLRK-YNGVA-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
sqoXhPpS4ONLUNcR0YmGAw",
      "ciphertext": "
DlsSziENqPvPFrbG3UquqwBR2EOtlgZljRE48yZs4Orz04mrEaadlZ9ZfHjsscxB",
      "recipients": [{
          "Header": {
            "kid": "MAEPJ-2YTTP-UIVVR-DG4U7-DT3TX-L2JAO"},
          "encrypted_key": "
50J_xfrIpVBdAS5rN06xcuo5j2MZybZLMaBCBcpEtoDphYuRA_it6WVLT-ae3NQY
GuXDkiRWCWMxHyArV1sW4W6Vp7yar8FZsyLCxmeMG3wL2TslXxvqP6KRTPxnTs7y
v0w9Lvk_YGMJFeA2GmqWwIoIKkze6MDDWDjjkMpLC32wiDK7nwnvZA4NiYs_LSTT
3yPNNBsNCFvjNFX4ycLpz5ej_WekSgr7F-N9LsDUgQOiz-D760nvuvFlYeoMTo31
CHD4rlTxhvwOkfswMkwYsP2HU19l10BXVn1uUdrItJqthuSyxhidauCtaU8DkrbN
gqfy4yy0HD6hVtxKN93XLQ"},
        {
          "Header": {
            "kid": "MC7TP-QRHUB-42UY6-OAPV5-WRQ5K-AJLOM"},
          "encrypted_key": "
yR4k8eWKqvSOaf_Ckjdzq7yDQn_1-u6YiR3T4t_2keZVZdVGVKnra1mS_9cMgtxK
ezb_0Y6e9tYL_WS7cacHjs7RXmvc0kmd0oLx6mxCWWB4Eys3cjm9e9xZcwOlvOP0
Cbdkzga57W3V9dpdMs2Q8xJfYGJrAtQzjw6HEWvDQFezzR9etV-rVcjCiScwQa4f
jkSr7-IQsXP0nh4RXfifoQmHNNMPlnLoAITWNZ3Vf-qBWgVEUV8ZF_fWp2j8SsZh
mae7zSx1ik0wh8vm7r5TpnlVUsicW5RiwtACTQLT67uTOc8QGdnwcSN8qUNE_bTV
bTfYNdkixDfFXz4TPBgirg"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MDMTS-FZHC3-EFGDT-NT4Y2-FTLRK-YNGVA-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRE1U
Uy1GWkhDMy1FRkdEVC1OVDRZMi1GVExSSy1ZTkdWQS1BIiwKICAgICJFbmNyeXB0
...
d2NTTjhxVU5FX2JUVgpiVGZZTmRraXhEZkZYejRUUEJnaXJnIn1dfX19",
          "signature": "
Eqr7-fv-Ms-0wLMbAKkF_ioIRE5xkZImALAwsFojcJhRwEtLjY1ZEgSjSJhJRv-o
mcBRF_e82Pv99lu76cYz2PFlGy0gCqBTDMR5oQlgAwOWie92j5MlBuIit4_lDAwh
877fsfK7pwsMlduN2aaMpLygxcyyjCtHBeDoPl0K7X0yRZLOzfdq-0mlOhbKq0XQ
LkCfjwXwtnkeG99CwSq7YEMD96lrmblUFFjpWJbBsZmyVHMwBcw-qPZcKSmlVl39
sONWLh6vajzEvFwytOxsaEqYckaKj43Oed6GdpiZ4ig80ONKDwisg8nrBNjdrRof
1KYgZiRaL5NFo0Tvc_9rJw"}}}}}
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
        "Identifier": "MDE3L-MQ52A-VKUKW-SL3RV-AQ3BD-NXVUV",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJZQTItRlhCSUMtRDI2U08t
RkNUSTYtNkJUMjctNldZN0gifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREUz
TC1NUTUyQS1WS1VLVy1TTDNSVi1BUTNCRC1OWFZVViIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
ElTedwe5ExLT7SVeVY7ROVFx6U71IGtFTdIbArL7YwBIrSG_ZleA8b-CvuXdkt3R
d5w71Su_ltbnE1JloDhpKFpB43O9vqLmET5I3zTxW9REjVaBc1bTU4NA21pNASm2
RzhzV0o0ng51eGVBwvhnO5T12Ho3LO1LHPvZtJ7KdxuanAU3L6-ZwEPsU0NVEj-M
H5J0kA80rwRy93UcFYH1ayP6iS6VhNvUMW-t9zGHEfgqHXx-NAMGU_XpQj1ra27T
lZJaqYLxYU_3xJg3WaZAMUQ58RYEn-N4R5CoYg58EFAiNMBmptjVEjRODzhM8FM7
hViwoMzUsvbv19l1szdyHQ"}}}}}
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
        "Identifier": "MC5XS-MYZXB-GUFQE-SOE6Q-7LAIV-COLIN",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
8nqRpZpJX_z4tjqhFifukg",
          "ciphertext": "
nJAL2xUnop9Uq3c0Opa6F9CnbHpiluQMgO5uUa8SXEazb576iLszreMenRn2vVIM
qoGQ76wVZgcHvasmlWSCVtHDoOHPmkd-N-RXtiu1D1a4O7trfKGq4uNMmxgtiqwU
...
lWfJBgkYHIXQVnh-TAFeNA_tDgfGVNyRYF-WlkoEGP_l2b26PoiGfOCTaW8NYAZ-"}}}}}
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
    "Identifier": "MC5XS-MYZXB-GUFQE-SOE6Q-7LAIV-COLIN",
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
          "Identifier": "MC5XS-MYZXB-GUFQE-SOE6Q-7LAIV-COLIN",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
8nqRpZpJX_z4tjqhFifukg",
            "ciphertext": "
nJAL2xUnop9Uq3c0Opa6F9CnbHpiluQMgO5uUa8SXEazb576iLszreMenRn2vVIM
qoGQ76wVZgcHvasmlWSCVtHDoOHPmkd-N-RXtiu1D1a4O7trfKGq4uNMmxgtiqwU
...
lWfJBgkYHIXQVnh-TAFeNA_tDgfGVNyRYF-WlkoEGP_l2b26PoiGfOCTaW8NYAZ-"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


