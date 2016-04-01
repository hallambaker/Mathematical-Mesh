
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
Date: Fri 01 Apr 2016 07:20:12
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
    "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
    "MasterSignatureKey": {
      "UDF": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
      "X509Certificate": "
MIIDJTCCAg2gAwIBAgIPjRj8YQWejQ_29SMhTCqMMA0GCSqGSIb3DQEBDQUAMC4x
LDAqBgNVBAMWI01EMkQ2LTVKU1FSLVBQNEg3LVZGRVVGLVo2NFQ1LU5ST1A0MB4X
...
4kAZFhExCBvpv5C9iPg06LdUjeouNkeYRkAm87VmVgtzbXaAp-fusv4",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
          "n": "
wZMN1ujLjPWoGwI5Rabb4DD9Vq7m_vOH0sWrURwmOubOsUPp6TLdWJJ0jX0wsChM
dz400atUNTRRbPgWfpb2SfHmNZVdhSpwG5GFw5c0--9DPbuZlOLvhbIsV26z_tNI
LipavkupMpJZ6fyTfE_c-2llqO3eK7DB90L9Wb6soHbUV4vMGwdKgaR4z4pozlWk
TNqkTALSAMNEtKinfc24054GSlySkLvQCOpZEZjrNY-Qzuv6twChCy3DpRxMGrRJ
RQMklQjw1MQhMYDIF2K_zB5UYYaNARiux6DypotF-zdG0U-4jF_ZiBmUynwmZCuC
ydp75HZBP6YEoUyzgc6Qlw",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MDLFZ-OTUXF-CBGRX-2LQZX-NGWTS-XAFP2",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAMP12qaXEflFJRZxebuYp-AwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUQyRDYtNUpTUVItUFA0SDctVkZFVUYtWjY0VDUtTlJPUDQw
...
I-r4z4P2U1IiDbXI1H0zAhedrI84QYe2sQiWbGOyxnQ6BYjRSAKCEwerfw",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDLFZ-OTUXF-CBGRX-2LQZX-NGWTS-XAFP2",
            "n": "
sRJfsTiqLo6TJIAe5X3UuuOaSZXIIMyrIZERWK9d13FWO9pHAlmZL2WhnEnZTUyb
DZwGIchn3pGrWP4LqXlD2G6TwhYPsvqvA_82GCJTM-W2J4EtodDfgQg4X9VyEvtW
6RiBUKsHSlzlzWcJeb-kSPwUNeYBtv08rYAhomwtOyETH9bIaUfh00a-dDh2TrtM
UNL0e4doqrrijiAtNnUkStOO1xsFN4FsPHOaaQvtnw1UKGvOLgn5AB-3YlRuqlyu
0R9xMd9Y2vlw9F7g9B2wZ-9IM1blA4rosNLfqE4kwMfJNdfBZicq23p8lLQ1xQsi
rkc-_cxR3KF5_J852Ii1Pw",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MABRF-3OJ3L-HFT3O-VGATW-PAOEM-H6ODB",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQQQ0MqAEl-1tXOwlHFh0p-TANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNRDJENi01SlNRUi1QUDRINy1WRkVVRi1aNjRUNS1OUk9QNDAe
...
3u02RCWzqgxz7SjvKsgJGRsaydUiKNAja8ij4Mlm32m_ydVVjESrXosb",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MABRF-3OJ3L-HFT3O-VGATW-PAOEM-H6ODB",
            "n": "
sYvcYwKPNVnqcq1dzEZUWAOAN2gNxUJ8Zh8_EFAuvitR0lG0v8bLd2ZPx-Wrvgxu
ZXzJHRKbSpDqyQfK8kUrZM4hZNy_lARke-bKVsUlINVv_sKYNSpzNUn2uG-fX58r
XIs_Y6fzU74XOugG9O7yHwSCem18TDVUhQQQcXSfOTnOd_ncL5iP5Mhw1QQ-R6Lv
cLN76vTqrgfM-I125CihXk9cnts64WhEqhCJGZyXb2zEkXFinssEJvuYEHIG6cZP
6GeccNcM-euUvm2t4mF0fbTcKaPhpr0W01cew7ov0q7Rdblxefo2P-Y2WdZhceLi
DjnduQ7vQdjaHYXFzFThJw",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQyRDYtNUpTUVItUFA0SDct
VkZFVUYtWjY0VDUtTlJPUDQifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQyRDYt
NUpTUVItUFA0SDctVkZFVUYtWjY0VDUtTlJPUDQiLAogICAgIk1hc3RlclNpZ25h
...
UUFCIn19fV19fQ",
      "signature": "
PMdrmkUA5ZdIG9tthCuQZJBld_ZFspZm73lotw5qKNy6R_BCjqxwgM52HCS3nBss
vVU6-9FIQdzaW8PGsveayGu72LcAMsUrCiBHpZ1AXUtE76We1fWHPKEufxom66vC
0dG5koNU3Vn01gvYd3rqb0kfOB2Z56q6FsCEWZqqZfSXxaXh0yb6k6KSKWnwPC5R
kJ2WkDNDQcxBMve--PV7H_rekJVrThens2OwK9-EOwTyhZoPLIpW-m2T_wUB_6dc
0RgFME1acPnQQW5lqUXlJVfXDNyiCUNoryBHUcmo68-5_8wIMfoOn-RB-oskVYqP
bs6-5ZxHx5huhHGAvMd3Jg"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MDHD4-GL272-FRJR4-JLXNS-FNUZP-ZNAUC",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MDHD4-GL272-FRJR4-JLXNS-FNUZP-ZNAUC",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDHD4-GL272-FRJR4-JLXNS-FNUZP-ZNAUC",
          "n": "
wirO-Ro1mFdTbrr9VObe1tuvBibi6PRyi3yF4Zp7DseW48wD0-CZ9DlCA0ZwjP7g
koIHxL7B0btKC8h_R3IYcytOD1_iRR8c1Nro195S6iuxzpf9ay-FVysL8NkbcjTc
KlPWJ6PsQ7iKtVp_lQnv-mUITPZ1ss0KgHjVe4ONl8oJ1fjU4EHbu6zGB1Bak2Wy
4EFOVaTPFuK1O4x6oND33GdtOiuAEjwH6RWu-ZS-8qq7fa95XMTYzt5p49jtS-la
QnX6hpeJRwWwqt4PZ0Np8vRhsrZ3HJdw7QEoqimjAoVafqQxsk911arj5djHiZdL
EBqsO4A99Q2xtM8gj3s0QQ",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCFJS-VM76O-QY5GW-BKU7F-BGF7Q-WS6AR",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCFJS-VM76O-QY5GW-BKU7F-BGF7Q-WS6AR",
          "n": "
3qP_kUbWA46GFAkb0_tChtVS4PrWyzBC87XqHB0R7h9u_7xOzVKvNbsAwIMCA6yA
EUcq8P-qniByrIz2crrhL5x573uPsEzeU8SRWl2CiJtMS8Fk2K1LZwv2Pfp-GOLg
2jfyMU1QJWMSUsJZOMfP5oiyUXyjsBniOSBTOrSuNwLg5KYJbEYhlX9Xb5dI8S72
psgwHViGiLn_J3jyA3Plf8Xoosf1ONS_xxRrlt4r4tBeHjp9aGrNulZ6RnIq5XtY
0NBgA7GXPAf2KEb-A-nD7T9d0yJ2ub6y15QdFPZL79OGw6XExVU8HfUv1W_YGzl2
fDpx3ztAHeVECIA6zx2r6Q",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MCEBZ-37BLM-SLH7Z-UADWQ-L66NH-EKBPB",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCEBZ-37BLM-SLH7Z-UADWQ-L66NH-EKBPB",
          "n": "
laGyyDmgrOMYmSJlncZ6_P91d2aZ707mP2irRYEnFMmFKoFrEnBsyWf1Q2YWXC4M
lIcCkCi8hFn1fbysqaJTUcR77p9-sk-GzdxhX5CctZVgKMo5HVsOk2Qo3lE8PzTt
sHuogI6YzBLxpohmgoLhNhtwBri-YBjQCdKfMwNivO8TysX6Qyw1P_iHOL2FLKXR
_aSqVay_E_4MBHcvMXV-f6dfoU5o4m9hADdfrFSqyI-p0tpOevOGJvL5lzJnD-41
RYl2SluqfdjujpA8ltyYOeXuT4pHJIzAyQO5QFvNq0eqL2XdSO85WvjhoNr1mL5K
g3u3q-oO4A3y6-qichyEMw",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MDHD4-GL272-FRJR4-JLXNS-FNUZP-ZNAUC",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURIRDQt
R0wyNzItRlJKUjQtSkxYTlMtRk5VWlAtWk5BVUMiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
jwu-a7fBp6NdpdcQXzRyGuD9xBLKC7DDeqKtRHn_5O4nVz6l5OP6u2Or10Zpv7p7
twaNslsOZasaZNf6uVgxgCxMv7rgfkVjS6FtAXPRGlgWUG-FFjJ39gTt3tLOHZUm
atNbNBrsj2MNLdwzjv2BxbP6JP6Jwy-nHgEcX4fVp5Usol3qhU183szbJH7liGnK
DCsn_6J-UPpM0sJ2dcKRXmrOnVXYUaGDEvvpKNr0a9ORiEMab3XYxD8Jq9I-zWMM
VHtEDQV4sgtB6TdCV81PgpCdTudMF68KFdEttSbSjoIou4qSCW0NW6O7TPUfYY5H
BaiPLsb2qo4KqtOvf-J5_w"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
    "SignedMasterProfile": {
      "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUQyRDYtNUpTUVItUFA0SDct
VkZFVUYtWjY0VDUtTlJPUDQifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUQyRDYt
NUpTUVItUFA0SDctVkZFVUYtWjY0VDUtTlJPUDQiLAogICAgIk1hc3RlclNpZ25h
...
UUFCIn19fV19fQ",
        "signature": "
PMdrmkUA5ZdIG9tthCuQZJBld_ZFspZm73lotw5qKNy6R_BCjqxwgM52HCS3nBss
vVU6-9FIQdzaW8PGsveayGu72LcAMsUrCiBHpZ1AXUtE76We1fWHPKEufxom66vC
0dG5koNU3Vn01gvYd3rqb0kfOB2Z56q6FsCEWZqqZfSXxaXh0yb6k6KSKWnwPC5R
kJ2WkDNDQcxBMve--PV7H_rekJVrThens2OwK9-EOwTyhZoPLIpW-m2T_wUB_6dc
0RgFME1acPnQQW5lqUXlJVfXDNyiCUNoryBHUcmo68-5_8wIMfoOn-RB-oskVYqP
bs6-5ZxHx5huhHGAvMd3Jg"}},
    "Devices": [{
        "Identifier": "MDHD4-GL272-FRJR4-JLXNS-FNUZP-ZNAUC",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURIRDQt
R0wyNzItRlJKUjQtSkxYTlMtRk5VWlAtWk5BVUMiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
jwu-a7fBp6NdpdcQXzRyGuD9xBLKC7DDeqKtRHn_5O4nVz6l5OP6u2Or10Zpv7p7
twaNslsOZasaZNf6uVgxgCxMv7rgfkVjS6FtAXPRGlgWUG-FFjJ39gTt3tLOHZUm
atNbNBrsj2MNLdwzjv2BxbP6JP6Jwy-nHgEcX4fVp5Usol3qhU183szbJH7liGnK
DCsn_6J-UPpM0sJ2dcKRXmrOnVXYUaGDEvvpKNr0a9ORiEMab3XYxD8Jq9I-zWMM
VHtEDQV4sgtB6TdCV81PgpCdTudMF68KFdEttSbSjoIou4qSCW0NW6O7TPUfYY5H
BaiPLsb2qo4KqtOvf-J5_w"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDJE
Ni01SlNRUi1QUDRINy1WRkVVRi1aNjRUNS1OUk9QNCIsCiAgICAiU2lnbmVkTWFz
...
S3F0T3ZmLUo1X3cifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
      "signature": "
s35MsAPE-Y8MoctKgVmHJGXLFiTskYsJlQj8pVFOOia8Dqk-_wuKdO8yHXodae8b
108iWMIKVkhKS9bUO6p9dsaK4_b_pf1RgoayuAiwZ6gFyqOLAuqDOi_of_47Qmp_
0Hx1KDGv6DtotM6NcFeFu9lkUC1KMA_FUkqgWWoHmUfqyXn2TyNr95TlnA2d2z9b
_Y9NjufCJqjTAP6KagWdIf5LrYlMcGl56zb7gccxAbICybJBxGqa1IL3H0dex_v2
hy4aHcpl-xQTOjEiuTr6AoSVI7l5ZgoM4LlGeQqhlWEIQO3ZbTmTtR0775eCPKv5
wd0k2zOVvUVTEyzrkaWtKQ"}}}
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
        "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDJE
Ni01SlNRUi1QUDRINy1WRkVVRi1aNjRUNS1OUk9QNCIsCiAgICAiU2lnbmVkTWFz
...
S3F0T3ZmLUo1X3cifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
          "signature": "
s35MsAPE-Y8MoctKgVmHJGXLFiTskYsJlQj8pVFOOia8Dqk-_wuKdO8yHXodae8b
108iWMIKVkhKS9bUO6p9dsaK4_b_pf1RgoayuAiwZ6gFyqOLAuqDOi_of_47Qmp_
0Hx1KDGv6DtotM6NcFeFu9lkUC1KMA_FUkqgWWoHmUfqyXn2TyNr95TlnA2d2z9b
_Y9NjufCJqjTAP6KagWdIf5LrYlMcGl56zb7gccxAbICybJBxGqa1IL3H0dex_v2
hy4aHcpl-xQTOjEiuTr6AoSVI7l5ZgoM4LlGeQqhlWEIQO3ZbTmTtR0775eCPKv5
wd0k2zOVvUVTEyzrkaWtKQ"}}}}}
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
    "Identifier": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
          "n": "
kIS3OcXOQtCjwYzf1CyMsVwdvFeF46-ldRfLo9Ua5pa60XJ90xBWTszZjuQ52R6g
gvcO3i3jyQbAq4fGr3f7E6ZtJfecpZO_tR_gEktuPTqVgvIjCYTlATaB3g4oqBGE
UF08gbtKima-SI2KWBn6FYpJ0p6E62tpbvNtczhFLnt9VpmHCIPjLg6Tow96GFJx
mJPt0Wov7LIxUI4WDaz8iBQF48h1epn0ObcHHa8RI8bJ7grxFLTdYW-axiYYf6L6
VsZl8BocTasPscVogCss-xV_GZMLDo1yam5u8EeajkuxmQlDt0zS3tLeRJCGeyMY
sKyhuchO8BOZXTXknpsaOw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MAQU6-2D3YQ-H6ZWD-MDIBY-GTBY4-QBGML",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAQU6-2D3YQ-H6ZWD-MDIBY-GTBY4-QBGML",
          "n": "
oAeJyT5hY0xMhzxXh5tvs1w3D3UjGwPt-3XDt1CKRMclEHSrVCvyor08_ce05CeG
JNdwKIS2xWCkkElTKibdtCRFFS-U3k1rdmyLiXtSsZPIKKM6RafE4VizTiTti50z
EnUS45WrWhgxYtnrRbXKArKhsAwt3NFuqfcNWBLAxQAHFEnXn8OJ7gNVX6MMQNB6
P00qxOwydWS1Iy_o4fzqjyDmoIHtv9flM7fri18W1xjaALffcXz_miR4gqWJwOyY
zmcKz09rRcn8in_zywjs_y37FL3qOD74Wv27GO3UdPjO4anycOlJl5npOfXdCG3Z
uArKcOhd5wNpNVE2Lj7RCQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MDQ5A-P2YHS-54PZ6-JAL2X-IQ6VD-KA5PY",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDQ5A-P2YHS-54PZ6-JAL2X-IQ6VD-KA5PY",
          "n": "
1-6fNDJMH77XosN9WBXNCWnEi1CxG8iDQ2PX5c-T3p3DOoBbR6RiUeRfWX1DjfeE
kbS3gJ423STFwws5pCavYeAwcqdpSghoSLFqVp5iKI2tgjiP3U8W9wHaxO552IdD
S60jBVE8Sc87XPHKCFrVjc1xWq9uuAJl8ekiZos1k1yzN-TIbeFynN6HW1XeX98C
ENwtcCKT7jJ2GGpUp-H78ekwb-D8xygUO5xosNBSxUqM83Q1-gJ6hYHXUFmfYN_G
7t86gPwnzHvzz8dsVI74ZQjOBO6hl73yeYsIKd_iPOBAT85fsNyqGildddX1dYEk
rB47NAIirHnnOdUvmT6ZvQ",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJLUTctSzVLWk4tNVZMV1Yt
RUlVNjQtSkpFU1UtRERBV00ifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJLUTct
SzVLWk4tNVZMV1YtRUlVNjQtSkpFU1UtRERBV00iLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
a09ankIPaXpqBCGZ05Q6f6iNHEfulhbXv4JfrG_JqAQITZdgMtODY42q4JSvcb-w
EOCngwK1pW5SFtEmSngQVjkILvBlQN9VMjgrhul8jXBD_ffVCIE4C_2NYo_0_DNY
9_lKUXtBqqqaMHqUmty5zeOTmyUXGx_Iko5lCahJxIS3ZjZw8ymfJslYu94ikpzg
c8fdHjEu0G6mI9IApWS7uLGuxtiVNudb2PIlr3OpIMeHgbH00totJtXCKApZqjzE
fmm1I8mOHVr9dEhYP5psu7ByPGl_cBScQWb595Qk-dY4s9pGE_68dBOvi3uIbn40
Cwo5fiojepDBeiMQC_BnwA"}}}
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
          "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDJE
Ni01SlNRUi1QUDRINy1WRkVVRi1aNjRUNS1OUk9QNCIsCiAgICAiU2lnbmVkTWFz
...
S3F0T3ZmLUo1X3cifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
            "signature": "
s35MsAPE-Y8MoctKgVmHJGXLFiTskYsJlQj8pVFOOia8Dqk-_wuKdO8yHXodae8b
108iWMIKVkhKS9bUO6p9dsaK4_b_pf1RgoayuAiwZ6gFyqOLAuqDOi_of_47Qmp_
0Hx1KDGv6DtotM6NcFeFu9lkUC1KMA_FUkqgWWoHmUfqyXn2TyNr95TlnA2d2z9b
_Y9NjufCJqjTAP6KagWdIf5LrYlMcGl56zb7gccxAbICybJBxGqa1IL3H0dex_v2
hy4aHcpl-xQTOjEiuTr6AoSVI7l5ZgoM4LlGeQqhlWEIQO3ZbTmTtR0775eCPKv5
wd0k2zOVvUVTEyzrkaWtKQ"}}}]}}
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
      "Identifier": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJLUTctSzVLWk4tNVZMV1Yt
RUlVNjQtSkpFU1UtRERBV00ifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUJLUTct
...
d0EifX19fQ",
        "signature": "
NsBFq8NMr4n4U_FGfmFIqRzx8LbzxOwSWEcigirGuqEWd9cy32W0uCHy2nz13ThK
y0I5plUFtD-p0_MDc6aGPMJxS5oud_jBuaLUXWceS38lnDW28OhgNLCojFFysqw1
HwYf7AhbOSpTsLXW9VxPmB-NXZr-FBc70NXtbLM5mWRAQBYKXfLfhk90GZ2noYDH
fyjw9X8IbxrCgUFnC6sZVotUV65uMd9sS0HId_-ngV3Kf3e_c8Hl6sJmLxSaux3a
xpyXtTZ7fr70-A3k3CPnpO5xCWel5B7SUNtB4M3tag2DIUkk0FS38EE6f7m1rNCJ
DRC3qHp-B95rAPyMy9SLDg"}},
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
        "Identifier": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJLUTctSzVLWk4tNVZMV1Yt
RUlVNjQtSkpFU1UtRERBV00ifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUJLUTct
...
d0EifX19fQ",
          "signature": "
NsBFq8NMr4n4U_FGfmFIqRzx8LbzxOwSWEcigirGuqEWd9cy32W0uCHy2nz13ThK
y0I5plUFtD-p0_MDc6aGPMJxS5oud_jBuaLUXWceS38lnDW28OhgNLCojFFysqw1
HwYf7AhbOSpTsLXW9VxPmB-NXZr-FBc70NXtbLM5mWRAQBYKXfLfhk90GZ2noYDH
fyjw9X8IbxrCgUFnC6sZVotUV65uMd9sS0HId_-ngV3Kf3e_c8Hl6sJmLxSaux3a
xpyXtTZ7fr70-A3k3CPnpO5xCWel5B7SUNtB4M3tag2DIUkk0FS38EE6f7m1rNCJ
DRC3qHp-B95rAPyMy9SLDg"}}]}}
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
        "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDJE
Ni01SlNRUi1QUDRINy1WRkVVRi1aNjRUNS1OUk9QNCIsCiAgICAiU2lnbmVkTWFz
...
amVwREJlaU1RQ19CbndBIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
KueYlDP_4qTDRRmcpyHTua9s5AUzT0QyKFxKi3WECvR8g_z0spZ86rHfIw4WSbTJ
33_pS8MHb6xui_l1oZMAQtmPbiR_tRfRs5_YPuRsgIEMfoQyjBYLCaROCEZEUfDi
reGfTe1AdOHtP51IaOqkeLtatzIB8TMsXx9mLWdWl6nDIMrX7wU0ADIk3xtGvnvy
bZEM18MImUuWGDYwkao79m7l1Z3GczHL1LhKlMRGwbnHsx3-5dV0y0mBybmum9hL
wFpwETacwGA6LubO5nTM71mRw5SesNgdgMJooEIRCZcec7CZX1U14jeFHB80-X7V
tpPXmlkqEjoFGkGc_pILeA"}}}}}
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
      "Identifier": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJLUTctSzVLWk4tNVZMV1YtRUlVNjQtSkpFU1UtRERB
...
dGVkIn19",
        "signature": "
lwTvrvt7TAIdotzgr3uhjA2Qf785ayKWEid7uIY8oloS1VJzOLM8DZ_uookGY5xT
3MwQIB4eL8CNr-HmCyrm77aavFAGTKurifRiECJZ5GFrzEb0On9-26x5vWSI8oLH
XrMnYKddCxGDsVURsYywEHIf_8Kme2WscjNJV0fNlD3BaG7DvMLudDeP_452Kf14
S_FpQWGD-f7Hvmvnk0zAHarXLPwMDqvKlWGmhNJXmXc0xVQpKSxAUCA6C6hh7kKg
YpWk1hd0W4OvhJIzO8v-A7dx2IAjscBFBANfDXzEIKJuROIBgVVuzmJzSgCAsjIQ
g7vIm3ypGtV9YhtsnzPFOA"}},
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
    "DeviceID": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MBKQ7-K5KZN-5VLWV-EIU64-JJESU-DDAWM",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJLUTctSzVLWk4tNVZMV1YtRUlVNjQtSkpFU1UtRERB
...
dGVkIn19",
        "signature": "
lwTvrvt7TAIdotzgr3uhjA2Qf785ayKWEid7uIY8oloS1VJzOLM8DZ_uookGY5xT
3MwQIB4eL8CNr-HmCyrm77aavFAGTKurifRiECJZ5GFrzEb0On9-26x5vWSI8oLH
XrMnYKddCxGDsVURsYywEHIf_8Kme2WscjNJV0fNlD3BaG7DvMLudDeP_452Kf14
S_FpQWGD-f7Hvmvnk0zAHarXLPwMDqvKlWGmhNJXmXc0xVQpKSxAUCA6C6hh7kKg
YpWk1hd0W4OvhJIzO8v-A7dx2IAjscBFBANfDXzEIKJuROIBgVVuzmJzSgCAsjIQ
g7vIm3ypGtV9YhtsnzPFOA"}}}}
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
    "Identifier": "MBOQQ-Z2N6N-S5NNV-P5VIR-G3XXN-O2GFS-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
YrWvnE-6CsRmdg70sVdgnA",
      "ciphertext": "
Z4rqHUmgDNP3bAg5nelzMOwkPGHf7ESkBa8OL5UhyFV1qGwmXv5ziM5f3fDyJcpn",
      "recipients": [{
          "Header": {
            "kid": "MCEBZ-37BLM-SLH7Z-UADWQ-L66NH-EKBPB"},
          "encrypted_key": "
cSMiPnJtwsTKfS80sKGP5bsX9DiZgzBZSay63z1OB8KayB6nYr6Mau79LQThwKEz
Cj5NUERXEVdPp8gyvPAwjuoGA3ScACMo2qbd37bsQ3Z9A3zW9s2aPSHi8GVN7giJ
Br-0sdy6HCDspNTRsiHg-43fz9vQmVh_2dXIvgxxJKv2I-ZnF9tuYw3oHgf73Ddh
kxzUc6eji6_4PaL73yuHckCFoteyPz7DMMPuqXz3EMwH4VyHYg89UWkJfag7nWjJ
66kE_CwCKYnE1vumzcLKrBOyVzTvx4bipwJoysTo_8U5BFIdPACug6h2xPUgG2BC
7ALqhCFOnCtBCBZyb60Wpg"},
        {
          "Header": {
            "kid": "MDQ5A-P2YHS-54PZ6-JAL2X-IQ6VD-KA5PY"},
          "encrypted_key": "
h88SigpKI1Fc_Vz_JNz-SuSpf-d_cCppkbEGuYJuYUqawMn_PWQ7TMaZsd4gTeFj
Np98mZYhjc0RNw4hSv7nYr7JY8ooJpl7Dt9QsRMD9KHspyHp-iLOJvezX_G932Yn
RU7Z3bnsVtvhLMl5Dczu8xprGmh5c23H2ftnkJFqrIYdrPen80r4c6QDAHEXkV7I
l7tcKICqH37XJvkuEzu9_F0ju40-zYKRIkj79c1J2i6dk5QHeyg-oh5HfDZ0sFAi
5d4fhXQInRhTN41o-IrKA7AwOyO7aJSzo2jZ8inqbLSeKMqwN1a9_yislSMw4VnI
2WLe-DQ7jQw9p0h2HXPxbw"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MBOQQ-Z2N6N-S5NNV-P5VIR-G3XXN-O2GFS-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQk9R
US1aMk42Ti1TNU5OVi1QNVZJUi1HM1hYTi1PMkdGUy1BIiwKICAgICJFbmNyeXB0
...
OV95aXNsU013NFZuSQoyV0xlLURRN2pRdzlwMGgySFhQeGJ3In1dfX19",
          "signature": "
BlY4wDzhSBFcD6bdGEPoidk7o-BhuewS9MNickh40QfRb45Z8C97EozfbyZVCdq6
TQEcyO8yjuCilQSpiPjecFsHt4onfLr9HcUxnG7eRjqUeM3S7B-BjfXxlvUJmpZo
p-sUcjXKVfrTDeflvPueiz7o5UocgbsZsd7dWMBZtWmiXTRHxwVEwK7TmoyJGWnE
oqetjCjMSNDr1kkLa7G-2-cvGvf5WYeGIw39aAF4CxlVJyDPJSP4XSMsRDtEgzCf
P2Ekinzwv85hNSZWLq0tAqWZo6K4Ly5bBbrUZDvX5ewwMhVtGvMTSbFhYijk0kJJ
-ItXf1m-53fE9pdKd8TOMg"}}}}}
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
        "Identifier": "MD2D6-5JSQR-PP4H7-VFEUF-Z64T5-NROP4",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURIRDQtR0wyNzItRlJKUjQt
SkxYTlMtRk5VWlAtWk5BVUMifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNRDJE
Ni01SlNRUi1QUDRINy1WRkVVRi1aNjRUNS1OUk9QNCIsCiAgICAiU2lnbmVkTWFz
...
amVwREJlaU1RQ19CbndBIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
KueYlDP_4qTDRRmcpyHTua9s5AUzT0QyKFxKi3WECvR8g_z0spZ86rHfIw4WSbTJ
33_pS8MHb6xui_l1oZMAQtmPbiR_tRfRs5_YPuRsgIEMfoQyjBYLCaROCEZEUfDi
reGfTe1AdOHtP51IaOqkeLtatzIB8TMsXx9mLWdWl6nDIMrX7wU0ADIk3xtGvnvy
bZEM18MImUuWGDYwkao79m7l1Z3GczHL1LhKlMRGwbnHsx3-5dV0y0mBybmum9hL
wFpwETacwGA6LubO5nTM71mRw5SesNgdgMJooEIRCZcec7CZX1U14jeFHB80-X7V
tpPXmlkqEjoFGkGc_pILeA"}}}}}
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
        "Identifier": "MC4OM-TFHNH-YPYKB-HYKUE-6OMAI-RLGIO",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
cFubEctbG0i-lY91Uwj_lw",
          "ciphertext": "
8rnF680scr0kTCty_SxHEQ1zohbfoK3pHay0FksAIDXtvGWzDmj1WUp57oj4UyZb
WofNA2qzxjZEQ5mb0L9psXpBVwT_6wYVgbCu-gYNplTBOroNcv_Tavnp4cVoW05U
...
T6LjN3DR1UJW0UfC5Bv0jP6abThd-awIgxU2e_bzhNKIFJ1z1YCjUh1qVf2utgZc"}}}}}
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
    "Identifier": "MC4OM-TFHNH-YPYKB-HYKUE-6OMAI-RLGIO",
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
          "Identifier": "MC4OM-TFHNH-YPYKB-HYKUE-6OMAI-RLGIO",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
cFubEctbG0i-lY91Uwj_lw",
            "ciphertext": "
8rnF680scr0kTCty_SxHEQ1zohbfoK3pHay0FksAIDXtvGWzDmj1WUp57oj4UyZb
WofNA2qzxjZEQ5mb0L9psXpBVwT_6wYVgbCu-gYNplTBOroNcv_Tavnp4cVoW05U
...
T6LjN3DR1UJW0UfC5Bv0jP6abThd-awIgxU2e_bzhNKIFJ1z1YCjUh1qVf2utgZc"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


