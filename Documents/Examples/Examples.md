
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
Date: Wed 25 Oct 2017 08:29:49
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
    "Identifier": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
    "MasterSignatureKey": {
      "UDF": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
      "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAPMn9uTzKAzZhBH9SNZiQH8wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTURGNzctNVFKT1ctVkxET1gtVU9OUUYtQUhOTVUtQlpDN1Qw
...
zG_gA7CuoH2Jr2t4VcQ3k4rFWA18SiMPMdH46EdUAL71"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
          "n": "
s6BhFGJU56mWHgKidTSdOr0mYqKn1FV1zNjw84MZ8kinxlK5S6vYQsMiLA25M7BX
StrbjU11w42RQaFp7SJALWY2nXrSEAxCFLSjN6AoFJZU0V3XADtAFftFuKExLS6H
MR1UqlSyL_5w2LwshaiHdAkwHjp7mGgrKxNYX4vGgWMlLlh1pGkk7KXs_ojAgz-v
j1Swn39JI3mv_0agxZFn41tkOfDtEiEVwu1PWufjW1hZT892sVyJxnY2VBrPZjMq
Scdo2yJK1ap8yq_tinLdsRjkdRlAsN_jg2c89KGKqUXIpjyk-z82f0MvRB3p6V6S
GV5f-gS9waO1Z_Waxc_DHQ"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MAO67-B2YKD-3ZFYQ-C6A24-6A2WX-3B6RM",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQfbQrFuWscC00AfAVm5gKYDANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNREY3Ny01UUpPVy1WTERPWC1VT05RRi1BSE5NVS1CWkM3VDAe
...
yQ8xnJZYzuFQKTtwRZvcxRYfSf2r_3pTCptaNAO_hgI"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MAO67-B2YKD-3ZFYQ-C6A24-6A2WX-3B6RM",
            "n": "
tGQvV_eEKNaPBYXS_DlO5stGuWIPwxwu59-1LacWGS8mWgUGsCj98GUIzTWPf2va
5UGYq8ejm63ytIumcQ0xnkT41tJJkmX5xRzJGa3eUfsJx7ZMYMrLmTcYVn_wOMFv
q9JEinoD0tlbJPX7Kgse9NQ_tP04LJKkCsK3hvgabPRkl7bq_521EC_NSE0GHYIN
uwoGhu2PBH_dyYF1MNQeBjELEoXFyxjEwRONt3_MAMVnylun6AEyOiRtx7LCEQuQ
fnscnifpP4i1CXk32Q_Jz2peBxkZ90uzOjG0sdST8cLB86JHC5SW7nJghb-56i1l
XHmf-mkmp9lrSYVEBEMZiQ"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MDZTG-QA4FQ-D3OBI-EY7X2-KMNEY-WFLID",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQJPICtJqkVXOsJ89EcTsSNjANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNREY3Ny01UUpPVy1WTERPWC1VT05RRi1BSE5NVS1CWkM3VDAe
...
Fu3lTmMo90HJZOf5euDIabdDdFyBiIYeUGGipCwoJP8"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDZTG-QA4FQ-D3OBI-EY7X2-KMNEY-WFLID",
            "n": "
ux8bWMF0-DyEUwfg-m64LqqVCK3nY1uL8RrFXUBSQBgrlp9R2bVa_KrqpQZhJa1K
dGTbEEgKTj2sYNhaOZD4lxTtkg-fA_EHcJKgjhwTP0sMzW6t7avc5gnTFrU4x-p_
UBQuasskK_znJYdHhNza63oq3dyzfXpTmictKRPg9KI6vGmkutXcJqssvzIaY06I
Y9b9fYb8c10WyCFhS_3OHbmx4XCtWNb6iDvk5FGncJjXWrbqG8xRkUVDwpHBLTck
NX6S4BjUg0CSUC3zVKSpxDzJL0AB49G_a0C0lo4GcQsJOWYHmugq-Ex43bVFs6Kd
Hxryk0mX3Uf1kLtZJrt2YQ"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURGNzct
NVFKT1ctVkxET1gtVU9OUUYtQUhOTVUtQlpDN1QiLAogICAgIk1hc3RlclNpZ25h
...
In19fV19fQ"
,
      "signatures": [{
          "header": {
            "kid": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjRkbkVqY3FlR01FRW01ekNh
cURCcWhUVVNuTGtCTk9GblRtdmZIOVZkQkRnZlNUS2NBUTZWWGJ2NTd3UDdiZHEK
MnNNQmx0Vjk1YkVra2M0OGVFd0FidyJ9"
,
          "signature": "
BXA65zVG2PZEltUcw2K2WwYygAX1z3wd2gH9ySwYgxfwjoZKel9ERYxw1tAmxnd3
rQOAZhEH4xKMx2RILwdrsZ6u5hdv58pJSM6Lyza0pwE42EC89-ki5SHctPCWt0k7
ZNQ_pw0B4M-chQkIaCz9WbOOMucELkd0WgvhXHdIlylgmRUF-t_6GbB7SFFLRRNG
EOOXiyJOLQbpznuMori1qhbM3S-oRSvfpqnMDjWQdWrcLqPeIBQLeauq1mO_pC9W
2jN6SSW4LWyPkdqo6pjQmmy1uXDUm-w5jq7pARaXzoByHmR5hPpPcApYgCbKQwtl
oyu9XKmd5sl7J66yKVEnxw"
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
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNBT0Mt
U0dRWEctNVREUjUtNzVJUzYtVVFFQjMtUVVTSkQiLAogICAgIk5hbWVzIjogWyJE
...
UTVPWXNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
    "signatures": [{
        "header": {
          "kid": "MCAOC-SGQXG-5TDR5-75IS6-UQEB3-QUSJD"},
        "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCk5ZcFdSeFFFaHhsU09qLTA4
SXdpOU9hVTNGWGFfcUVfOGRxVzFES3QwU2F3c0tlUjZ5ZHBscFdrc1Z1enBBZ2kK
S3ZmUHprZ3Z6RVdpNnhvRHNZSHA0QSJ9"
,
        "signature": "
H30EevLQITOwV6pF7v9NAwJ_MVVH-zamcQcx5o7cMZWwvgtRary59NuyOETI6zP6
0utwO4t2AmZyViGcn5z-tSE5kW2k5VkW6wm7ZKMaYmTgDn4k1juiiwKknNmpiSf0
zZaJQc5VXpfpHfgklWEp6ARIqa7GvOzRTQZXZxfuinNw5W5AntFPpxSvejIW4Kka
_vVBzIcjWr8gpsBoPLH-NZjtAg8-uBAvNcZzloMzslXwMbqKWB_rRm0j91DZE52c
vV834YrTA2BY8l2nUehLSopNR5g0r_o8QvhXW8hWIN-p2GQRP6mUBNlMk7Ie4F0F
_ZfAhBb6LzIKwUFzf7uJag"
}]}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCAOC-SGQXG-5TDR5-75IS6-UQEB3-QUSJD",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNBT0Mt
U0dRWEctNVREUjUtNzVJUzYtVVFFQjMtUVVTSkQiLAogICAgIk5hbWVzIjogWyJE
...
UTVPWXNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MCAOC-SGQXG-5TDR5-75IS6-UQEB3-QUSJD"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCk5ZcFdSeFFFaHhsU09qLTA4
SXdpOU9hVTNGWGFfcUVfOGRxVzFES3QwU2F3c0tlUjZ5ZHBscFdrc1Z1enBBZ2kK
S3ZmUHprZ3Z6RVdpNnhvRHNZSHA0QSJ9"
,
          "signature": "
H30EevLQITOwV6pF7v9NAwJ_MVVH-zamcQcx5o7cMZWwvgtRary59NuyOETI6zP6
0utwO4t2AmZyViGcn5z-tSE5kW2k5VkW6wm7ZKMaYmTgDn4k1juiiwKknNmpiSf0
zZaJQc5VXpfpHfgklWEp6ARIqa7GvOzRTQZXZxfuinNw5W5AntFPpxSvejIW4Kka
_vVBzIcjWr8gpsBoPLH-NZjtAg8-uBAvNcZzloMzslXwMbqKWB_rRm0j91DZE52c
vV834YrTA2BY8l2nUehLSopNR5g0r_o8QvhXW8hWIN-p2GQRP6mUBNlMk7Ie4F0F
_ZfAhBb6LzIKwUFzf7uJag"
}]}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
    "SignedMasterProfile": {
      "Identifier": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURGNzct
NVFKT1ctVkxET1gtVU9OUUYtQUhOTVUtQlpDN1QiLAogICAgIk1hc3RlclNpZ25h
...
In19fV19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjRkbkVqY3FlR01FRW01ekNh
cURCcWhUVVNuTGtCTk9GblRtdmZIOVZkQkRnZlNUS2NBUTZWWGJ2NTd3UDdiZHEK
MnNNQmx0Vjk1YkVra2M0OGVFd0FidyJ9"
,
            "signature": "
BXA65zVG2PZEltUcw2K2WwYygAX1z3wd2gH9ySwYgxfwjoZKel9ERYxw1tAmxnd3
rQOAZhEH4xKMx2RILwdrsZ6u5hdv58pJSM6Lyza0pwE42EC89-ki5SHctPCWt0k7
ZNQ_pw0B4M-chQkIaCz9WbOOMucELkd0WgvhXHdIlylgmRUF-t_6GbB7SFFLRRNG
EOOXiyJOLQbpznuMori1qhbM3S-oRSvfpqnMDjWQdWrcLqPeIBQLeauq1mO_pC9W
2jN6SSW4LWyPkdqo6pjQmmy1uXDUm-w5jq7pARaXzoByHmR5hPpPcApYgCbKQwtl
oyu9XKmd5sl7J66yKVEnxw"
}]}},
    "Devices": [{
        "Identifier": "MCAOC-SGQXG-5TDR5-75IS6-UQEB3-QUSJD",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNBT0Mt
U0dRWEctNVREUjUtNzVJUzYtVVFFQjMtUVVTSkQiLAogICAgIk5hbWVzIjogWyJE
...
UTVPWXNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
          "signatures": [{
              "header": {
                "kid": "MCAOC-SGQXG-5TDR5-75IS6-UQEB3-QUSJD"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCk5ZcFdSeFFFaHhsU09qLTA4
SXdpOU9hVTNGWGFfcUVfOGRxVzFES3QwU2F3c0tlUjZ5ZHBscFdrc1Z1enBBZ2kK
S3ZmUHprZ3Z6RVdpNnhvRHNZSHA0QSJ9"
,
              "signature": "
H30EevLQITOwV6pF7v9NAwJ_MVVH-zamcQcx5o7cMZWwvgtRary59NuyOETI6zP6
0utwO4t2AmZyViGcn5z-tSE5kW2k5VkW6wm7ZKMaYmTgDn4k1juiiwKknNmpiSf0
zZaJQc5VXpfpHfgklWEp6ARIqa7GvOzRTQZXZxfuinNw5W5AntFPpxSvejIW4Kka
_vVBzIcjWr8gpsBoPLH-NZjtAg8-uBAvNcZzloMzslXwMbqKWB_rRm0j91DZE52c
vV834YrTA2BY8l2nUehLSopNR5g0r_o8QvhXW8hWIN-p2GQRP6mUBNlMk7Ie4F0F
_ZfAhBb6LzIKwUFzf7uJag"
}]}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREY3
Ny01UUpPVy1WTERPWC1VT05RRi1BSE5NVS1CWkM3VCIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
      "signatures": [{
          "header": {
            "kid": "MDZTG-QA4FQ-D3OBI-EY7X2-KMNEY-WFLID"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjNYQi01eDFuNDlFOHp1VkR6
bDdOS3FJTTcyeUNhT3lmS3pxZk13Zy1iZ2tqMzFVRW8tdG50WlBqaVQxT2l3OUoK
VHVHU1prYzRTbng2Y0xGX0JEVWhhZyJ9"
,
          "signature": "
FlEwoyD9rBxJgd9TNTes_QLDk0Ow3FuaQC_ekxkS3zO4rSC5_6qhclHcnwDT-VIB
E_9osIz2KTz-JSUNWA_6DjKO2PSQFUKrhdngH7BvDTSf0KM3arUnNasEh33lxo-e
UyCXsLHNqiFHBc5fPUNcexxNFv0utT-fArWMDsZY4Ykb2rDOsxkqtri5zXMRvn70
pmYhJf70-MNlR7wGS-_4ngJhqa6QXmIAlDifiPG9FlGnApuHicOv8N3k_t2685Cz
D6epfRuPnVkikAZJvOEXi9JtA-F_BFQe3J5l9iQ3nOn-xq2nATl3eliMJ3i_hgxJ
p9_cUMWW7IO97xcSnDMRjQ"
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
        "Identifier": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREY3
Ny01UUpPVy1WTERPWC1VT05RRi1BSE5NVS1CWkM3VCIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
          "signatures": [{
              "header": {
                "kid": "MDZTG-QA4FQ-D3OBI-EY7X2-KMNEY-WFLID"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjNYQi01eDFuNDlFOHp1VkR6
bDdOS3FJTTcyeUNhT3lmS3pxZk13Zy1iZ2tqMzFVRW8tdG50WlBqaVQxT2l3OUoK
VHVHU1prYzRTbng2Y0xGX0JEVWhhZyJ9"
,
              "signature": "
FlEwoyD9rBxJgd9TNTes_QLDk0Ow3FuaQC_ekxkS3zO4rSC5_6qhclHcnwDT-VIB
E_9osIz2KTz-JSUNWA_6DjKO2PSQFUKrhdngH7BvDTSf0KM3arUnNasEh33lxo-e
UyCXsLHNqiFHBc5fPUNcexxNFv0utT-fArWMDsZY4Ykb2rDOsxkqtri5zXMRvn70
pmYhJf70-MNlR7wGS-_4ngJhqa6QXmIAlDifiPG9FlGnApuHicOv8N3k_t2685Cz
D6epfRuPnVkikAZJvOEXi9JtA-F_BFQe3J5l9iQ3nOn-xq2nATl3eliMJ3i_hgxJ
p9_cUMWW7IO97xcSnDMRjQ"
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
    "Identifier": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
    "Names": ["Default"],
    "Description": "Unknown",
    "DeviceSignatureKey": {
      "UDF": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
          "n": "
sVmlNK1B5eDfGxHBq2OhnPZ2hxvj4dSfJKxbQx3Hw8PEk_UGO4qOjtEPtFc8DjdL
NzJw2VbjWD1DB02MCCwZEEqOcqW-Dwflwim0DKPEZrBIcggx57KfRpTq-NwCt67I
cRf-LQ0dXtrvFDTl6Zx6OeHmK7CXztxsjQD8bMq9koiqyOBNg8FckNq1srKHdJsx
Bu6ZAfz_1ES2c2A1JCPUvZtF63DH4wDstGEvxW2VWiPDKCjalyRppORTf5lhybZZ
WWqZYo85zpq1bT4FD38u6hje2rnNgPZOoa6oURwDsUBW2S9Xl5XKX49vR8hAuRm_
muH-np4iOT5S1nn0fGkaVQ"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MAEJB-6JAMV-UK2IN-SXDYP-ESXOD-UYOYM",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAEJB-6JAMV-UK2IN-SXDYP-ESXOD-UYOYM",
          "n": "
6hwAMpB5aO4Pyoy_q6D_SiSTz6yqzJN9K1j9v8rHcPrtfTDlvpUQrN9a4IdrwHa4
T9CtJ5gaebPy4t90_Vw0JY0NVROhK6aorIo1US-ENBIQ4KXPSca-8lJnQxpgLHyI
fcsbsXOpoXITmKnZZtsfGFKD-y7tJ-a0rHHAQczQ-agwb1a-3R_3KhHMXbwjB-mP
qsTTWbzuA51X45D6jt9NjI0qnfo7FnYsFHhbW8NiR1jQQxdMWYv4a5qu_7hODDDY
F4OO28ftOyYsVO_Oj7zDhk4C2e_EUHJ34uwpFa6OzPOzweV6X3TB0s84xL1CPJL_
UWY8NLsGP88VCZIi8TtVsQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MBPXW-A4OAB-LNUNN-CTKBQ-KA57J-AVV77",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBPXW-A4OAB-LNUNN-CTKBQ-KA57J-AVV77",
          "n": "
ycIvA9iGT3TfXSpyVYwYj7QO_G2XfyTYsvpXPclgrQ9a6wz2g33mbCINmJM_cD00
wT78FIgrN5d-Q8N0izKaG1woAdcc7gmV5eTMnRM9bUOmUgUXt340uuuF458OPptw
bNDotEkVhy19abf12RTrlApk4deqhejk7fjTnTmZL2MQL4pBgZgNsQ6mSok2j41z
pAhI4P5V9bKp_J3JtuUNo0CxUc6x-iCbDstH2RiVUeMz4mJVfkAxNKSOT1ZSdMun
JWNvyObJt45oRLWQCugEFkdfVLBadcTi5YJ2DDQtU0vLSAxxOuNrlm_pTKzC_fmU
AfKmzZHAkZrbGFs6-GpelQ"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFBVTQt
VVJaQ1ctNDVRQUItWEJPTE8tNlcySTYtRjJRS1kiLAogICAgIk5hbWVzIjogWyJE
...
ICAgICAgICAgImUiOiAiCkFRQUIifX19fX0"
,
      "signatures": [{
          "header": {
            "kid": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnBVdDd1aWh0UGduR3pTR2tC
c2YwakVQN1dZdU1GQktLTmRkdnBZRV9kVTFuMnhoYktJeWdwcjRLOUFyQ3l0OHoK
M1NCczlPbktwZnhrRElTVDExRW1RZyJ9"
,
          "signature": "
kLnDePnoKSdzDaeInClHuzpr4MGDa-lKWx1dG3mKd-HtvAk1-FIDbHWBmKcVLna7
yFhP3OVTT1MrN0-GJPgW2OkWCM_E557HxzUMM4q2u7vwC6tMHl0yzJRNs9EPyTQx
BouB9QwX4Pek0U-WSWfRn3X-UmUKgmcbGH0BM6_ioQ75FgqHfSVCrJuC8MptUSf7
DLKJcXoM6HaeXJQLCQpFYpP2xoLJydlFwYBUkKE4Ue1E-_1lhdaqTcjdpkz88W3G
IgTOj2AjJMb2ZViIROddiX0lIfeAC2JukEf817QCH2aS5kXYZewEX8ce1pypO2nn
rrcuEhFTTJEs6ELWWLfJ8g"
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
          "Identifier": "MDF77-5QJOW-VLDOX-UONQF-AHNMU-BZC7T",
          "SignedData": {
            "unprotected": {
              "dig": "S512"},
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREY3
Ny01UUpPVy1WTERPWC1VT05RRi1BSE5NVS1CWkM3VCIsCiAgICAiU2lnbmVkTWFz
...
b25zIjogW119fQ"
,
            "signatures": [{
                "header": {
                  "kid": "MDZTG-QA4FQ-D3OBI-EY7X2-KMNEY-WFLID"},
                "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjNYQi01eDFuNDlFOHp1VkR6
bDdOS3FJTTcyeUNhT3lmS3pxZk13Zy1iZ2tqMzFVRW8tdG50WlBqaVQxT2l3OUoK
VHVHU1prYzRTbng2Y0xGX0JEVWhhZyJ9"
,
                "signature": "
FlEwoyD9rBxJgd9TNTes_QLDk0Ow3FuaQC_ekxkS3zO4rSC5_6qhclHcnwDT-VIB
E_9osIz2KTz-JSUNWA_6DjKO2PSQFUKrhdngH7BvDTSf0KM3arUnNasEh33lxo-e
UyCXsLHNqiFHBc5fPUNcexxNFv0utT-fArWMDsZY4Ykb2rDOsxkqtri5zXMRvn70
pmYhJf70-MNlR7wGS-_4ngJhqa6QXmIAlDifiPG9FlGnApuHicOv8N3k_t2685Cz
D6epfRuPnVkikAZJvOEXi9JtA-F_BFQe3J5l9iQ3nOn-xq2nATl3eliMJ3i_hgxJ
p9_cUMWW7IO97xcSnDMRjQ"
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
      "Identifier": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTURG
NzctNVFKT1ctVkxET1gtVU9OUUYtQUhOTVUtQlpDN1QiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
        "signatures": [{
            "header": {
              "kid": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjdaRlFiekpRMjNMMUVFMGdY
R3ZqZ0V1cnFDdzFObGtrVHJEOV9aWTFvdEtUNHR5Z0lRcGFpcDhXc3loUmEwSy0K
MnRCUXk2VzA2TGxDMUhnUDBLSGtWdyJ9"
,
            "signature": "
rUshcjpgNx8SXrfZtgw9bXLRIfzvUbiAarplWhLwKz8IWKxf6-KDaMtq6BBi9mwV
fTlAS5iY1H4J38VK3Wszon9UChk7wC6cmKs1XOz3DnajNLyg-tI83YXsnVZZmkwj
d5GH6wFanZNDp-BswelpdvdF9PoJ6286_0STLg4_gFJrWXmZm37texq8ksXW2efu
3Yw2T_HDtkPAYiIXlt0238fByZFiA1bTOJyrg5o30tAYnDv5z8kGFbiAE42UoQ3D
gjyk5843ynsSOlrSCWr5ljIpWGL9AvtMv60SMNrZCSSFwqFpzoRW51bOOm4V5-wc
9GE1IpVENJsgk6Oprn3R1g"
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
        "Identifier": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTURG
NzctNVFKT1ctVkxET1gtVU9OUUYtQUhOTVUtQlpDN1QiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjdaRlFiekpRMjNMMUVFMGdY
R3ZqZ0V1cnFDdzFObGtrVHJEOV9aWTFvdEtUNHR5Z0lRcGFpcDhXc3loUmEwSy0K
MnRCUXk2VzA2TGxDMUhnUDBLSGtWdyJ9"
,
              "signature": "
rUshcjpgNx8SXrfZtgw9bXLRIfzvUbiAarplWhLwKz8IWKxf6-KDaMtq6BBi9mwV
fTlAS5iY1H4J38VK3Wszon9UChk7wC6cmKs1XOz3DnajNLyg-tI83YXsnVZZmkwj
d5GH6wFanZNDp-BswelpdvdF9PoJ6286_0STLg4_gFJrWXmZm37texq8ksXW2efu
3Yw2T_HDtkPAYiIXlt0238fByZFiA1bTOJyrg5o30tAYnDv5z8kGFbiAE42UoQ3D
gjyk5843ynsSOlrSCWr5ljIpWGL9AvtMv60SMNrZCSSFwqFpzoRW51bOOm4V5-wc
9GE1IpVENJsgk6Oprn3R1g"
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
        "Identifier": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTURG
NzctNVFKT1ctVkxET1gtVU9OUUYtQUhOTVUtQlpDN1QiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjdaRlFiekpRMjNMMUVFMGdY
R3ZqZ0V1cnFDdzFObGtrVHJEOV9aWTFvdEtUNHR5Z0lRcGFpcDhXc3loUmEwSy0K
MnRCUXk2VzA2TGxDMUhnUDBLSGtWdyJ9"
,
              "signature": "
rUshcjpgNx8SXrfZtgw9bXLRIfzvUbiAarplWhLwKz8IWKxf6-KDaMtq6BBi9mwV
fTlAS5iY1H4J38VK3Wszon9UChk7wC6cmKs1XOz3DnajNLyg-tI83YXsnVZZmkwj
d5GH6wFanZNDp-BswelpdvdF9PoJ6286_0STLg4_gFJrWXmZm37texq8ksXW2efu
3Yw2T_HDtkPAYiIXlt0238fByZFiA1bTOJyrg5o30tAYnDv5z8kGFbiAE42UoQ3D
gjyk5843ynsSOlrSCWr5ljIpWGL9AvtMv60SMNrZCSSFwqFpzoRW51bOOm4V5-wc
9GE1IpVENJsgk6Oprn3R1g"
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
      "Identifier": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFBVTQtVVJaQ1ctNDVRQUItWEJPTE8tNlcySTYtRjJR
...
CmxaeGRWdDBJNG9PQk0tSW83d3ctdncifV19fX19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MDZTG-QA4FQ-D3OBI-EY7X2-KMNEY-WFLID"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjMwU3dhVzRURURXVnNuWW1X
UlhRU0ZhV083VmstMXBERkFiSFNGWmhPVGdrV25QRGszUWMzVVhVZjJ1OG1yQUcK
MHF0SlpRNXNlZzFNMG1EbE5kRnBfdyJ9"
,
            "signature": "
bTn5PGf7FR1B4cdQeuM22p7iQIsSQVGL9kxEl2OyfrAgAWdVy-qjJdHGmeF52_Td
GI51XmUZY-gsuQv2JISZmOrYN9XFoWEL6fdW0B_gHjsHU0eK92lDqHGgihjyc1Oa
a5R_UWRy3t0Ph3D3oUr-upNSoQaOzc1ffxz291WPgXG2mWhnLaO8j-FMUH4BXO19
RL-d9ImESQ_xfzvpaXwGy8kPSkboUNLXNGwMIUXxC04wHLgtiCExlgD2_uus3clG
mTNCVijhlELj4qn2u8o8XwpQEs6yozk9ll5V0SeWduCg_vXFKL2hn-0DG81V9tiT
k-KrJkVElrlySVaqiZNCgw"
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
    "DeviceID": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MAAU4-URZCW-45QAB-XBOLO-6W2I6-F2QKY",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFBVTQtVVJaQ1ctNDVRQUItWEJPTE8tNlcySTYtRjJR
...
CmxaeGRWdDBJNG9PQk0tSW83d3ctdncifV19fX19fQ"
,
        "signatures": [{
            "header": {
              "kid": "MDZTG-QA4FQ-D3OBI-EY7X2-KMNEY-WFLID"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjMwU3dhVzRURURXVnNuWW1X
UlhRU0ZhV083VmstMXBERkFiSFNGWmhPVGdrV25QRGszUWMzVVhVZjJ1OG1yQUcK
MHF0SlpRNXNlZzFNMG1EbE5kRnBfdyJ9"
,
            "signature": "
bTn5PGf7FR1B4cdQeuM22p7iQIsSQVGL9kxEl2OyfrAgAWdVy-qjJdHGmeF52_Td
GI51XmUZY-gsuQv2JISZmOrYN9XFoWEL6fdW0B_gHjsHU0eK92lDqHGgihjyc1Oa
a5R_UWRy3t0Ph3D3oUr-upNSoQaOzc1ffxz291WPgXG2mWhnLaO8j-FMUH4BXO19
RL-d9ImESQ_xfzvpaXwGy8kPSkboUNLXNGwMIUXxC04wHLgtiCExlgD2_uus3clG
mTNCVijhlELj4qn2u8o8XwpQEs6yozk9ll5V0SeWduCg_vXFKL2hn-0DG81V9tiT
k-KrJkVElrlySVaqiZNCgw"
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


