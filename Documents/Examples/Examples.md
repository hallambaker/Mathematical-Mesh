
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
Date: Sun 01 Oct 2017 03:12:27
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
    "Identifier": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
    "MasterSignatureKey": {
      "UDF": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
      "X509Certificate": "
MIIFXDCCBESgAwIBAgIQCUsP4LiTh07NgjzzrPXgBzANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQVpJRS1NRU1XTC1BVjRSRi1GU05EWS1GS0VLVy00SElZNTAe
...
0XRdfe8Gt0rrCQ-jJojvt0d1rNP-ZychHSOC1Al7b9U"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
          "n": "
wHhghT-nV9-kXjtnh95690iShOpa22375_DG4qqYGeo61w3TvZsdlqDtJMYMHgUY
E8Cj5xMV5KO3a3jW8Af0HJeZM2gwjn2gxD3u99bfsTZSezesf44RykCtYrmHsD7t
D5bvOA0JeplvAf4P7E5Hzqlg9CY5HtbeXnIT-uqtK1KrZ0yU0cg_bo3zGzTv_-CE
P-cc8ZKMta0mC7CVbNN8fuzM3zlq_YJHlTR8gHjni8rRUyVNbfy36gXsuekSx61w
CwH-9V7V7dya3f2LF7sTvs4OVbAT_BHX8AzQhDAYcpYROv9b3TN686q2j7b9A528
2cflzw3Bv3e0otNexeyHCQ"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MDUO2-J356K-HZNHN-27PSJ-NMJ6F-PFOQG",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQLC1loYPdp1U-m61dBy-6jjANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQVpJRS1NRU1XTC1BVjRSRi1GU05EWS1GS0VLVy00SElZNTAe
...
lrwzKLxLvmgNa0B83R0g2gTSKuKvf4qy8BsWtRE5xxs"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDUO2-J356K-HZNHN-27PSJ-NMJ6F-PFOQG",
            "n": "
zTg4eSXaJ3yb-IblvltFLjLj0mau1otfIgfbk3lyA2C19Ew52_nVYbFF6CmTALMK
aOLTgU4VmACQhWOPOhdJxVMnVv0ru_sfJnsyyILB2MWaIXGTX9JIbibx4OqCIeEy
G6FmcYAk1RBtEVgZQIWXZAsFxFwI2YIMGisCA402FwnElH9eo5szPrEU_MwGtd40
CzzfZpEN9-AX5BIVUKUrj2fuo5dh8MOf5OPT9yGYnSUb9P9-GIKvu2gl1r23MGqd
C7mWu-DR_mmXLwLF3ZHT2W9PAJR-0zX4lUfBAvofc0j0pXyvRUf2yWHnI-boIf4e
rGWYVaVi9g5cf2of7Q9oQQ"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MCFEP-GYAFG-T7QP3-SVI2U-W72P2-ORD4J",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQeczvFOI5Wyqt5i1IcyQyajANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQVpJRS1NRU1XTC1BVjRSRi1GU05EWS1GS0VLVy00SElZNTAe
...
YpKFOffwviA2cM-uLXtgM8Eg7tfn04dXnwsoseMmhA8"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCFEP-GYAFG-T7QP3-SVI2U-W72P2-ORD4J",
            "n": "
3FxlrGytOj_cZXxkM_HbuDUK1KU0rIdG9Cd6wk5lHbvJ86E6WXXIpaPvdXypAg2P
Y41oenYjtt0jxOOMRepnNRN36jpkuJxUAlTkQaBi-FgKGQCpuHgNNPRNUpwKAoBd
XlalnaqISIUhMl64wG9Sxll_EkFGL13I49ZcitiKw38UuFkCBaw_iXTpUUfH5g4q
E8-0F1yZLTdLUQhNpBHZqk0Tg5TK4MhIE1M_wV8omyLrsvj6pP7mUWUa1y4LpAeR
w7B9MoZ_lZBVtPg2udGmCmBn35WImFbKazpJm1EIZZQadZqZvMyQyDmgciu5WCn6
nHfsnpMvNHhxjhdomZRJTQ"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFaSUUt
TUVNV0wtQVY0UkYtRlNORFktRktFS1ctNEhJWTUiLAogICAgIk1hc3RlclNpZ25h
...
fX19XX19"
,
      "signatures": [{
          "header": {
            "kid": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnhfUUg4aTdxTWM1RC1iM3Np
RVRIQWowTlo3Q25jeGdZZVF6dk15OEhyLUFCVy1tcmtVaW1yS2tXRHpoOUt1QkoK
emM1RmxDY1hkbmdHVzJqVDZ5RGNSUSJ9"
,
          "signature": "
QAMl9eJ_4LOTLk8oqmH0vTSDBpB2wFIDRuL_FpfeQCBDSU_4WOEMLCW0W4D-4Vio
bXSOLEnNzGihY7CsxhBa5b6lYLJHpujRjcdBlJVcE9bs3rpWots7m6NPvn2HT07o
4VR5ckfb9HcGlCsNY3F-8AI5UCmo_raMGYTjIKPLW8INBcxzyOXws1cI5qMRRD7i
eHJU9h-4mmVKjQGser1lm0bTdRjcJffYvW9b4DUZ2jN0ClnIaV7g8nUk22g0poFi
5uce5xbRbERVodHr358VS-XY-_X__DLH_oahRzGQoHhTSx59pXg30vMecLoYw9xO
mjR4-57mMQxeu3TIDOxkaw"
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
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNLTkYt
Q0hOUlUtQTVCSEEtV0pPSkstUko3VjQtSzdGSVoiLAogICAgIk5hbWVzIjogWyJE
...
UDlMS2JRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
    "signatures": [{
        "header": {
          "kid": "MCKNF-CHNRU-A5BHA-WJOJK-RJ7V4-K7FIZ"},
        "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCktGbjgtX3NUenRJVWVDUmZp
T1cxVnpndVl6RXdQQjJhZmlWajFnRzdMZ29kVXJhRVNPTzZzc3pZbDVxNDJJSGYK
RUNTSW5mR3NzV2F5WGNqX0VTUnVYdyJ9"
,
        "signature": "
hvuxuinNyWOA9NadqbcN1gc7-V2nm0IcnuCQYQjW2h57WuAwqkqt_kTu7JoAavy4
Whkb8a74rFKFtrD6tM7A93jPcmGj01GSfddu_tUTcBsghcPNyUwmBdlRvGDcFSza
XRfVsr1EpDWV8xfelYUvWKoBdxoZOi8vDyAZ00ppfkmgXdPTGckiEv50LBd_6pyc
YJoHf-o6J6zzMK-RMFmtzvIFjytkpk9qzT2tvfclPiW9hPZWcOrcFfQEmWc6rgpv
OLI7AOc6JiQOFjKL8qVg7_kbFSpfiQaMiToLrXVbChQNrpFvzPNgRIuLO3BX_7Et
wBZvv-TmqvcbeBZ_8fZeRw"
}]}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCKNF-CHNRU-A5BHA-WJOJK-RJ7V4-K7FIZ",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNLTkYt
Q0hOUlUtQTVCSEEtV0pPSkstUko3VjQtSzdGSVoiLAogICAgIk5hbWVzIjogWyJE
...
UDlMS2JRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MCKNF-CHNRU-A5BHA-WJOJK-RJ7V4-K7FIZ"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCktGbjgtX3NUenRJVWVDUmZp
T1cxVnpndVl6RXdQQjJhZmlWajFnRzdMZ29kVXJhRVNPTzZzc3pZbDVxNDJJSGYK
RUNTSW5mR3NzV2F5WGNqX0VTUnVYdyJ9"
,
          "signature": "
hvuxuinNyWOA9NadqbcN1gc7-V2nm0IcnuCQYQjW2h57WuAwqkqt_kTu7JoAavy4
Whkb8a74rFKFtrD6tM7A93jPcmGj01GSfddu_tUTcBsghcPNyUwmBdlRvGDcFSza
XRfVsr1EpDWV8xfelYUvWKoBdxoZOi8vDyAZ00ppfkmgXdPTGckiEv50LBd_6pyc
YJoHf-o6J6zzMK-RMFmtzvIFjytkpk9qzT2tvfclPiW9hPZWcOrcFfQEmWc6rgpv
OLI7AOc6JiQOFjKL8qVg7_kbFSpfiQaMiToLrXVbChQNrpFvzPNgRIuLO3BX_7Et
wBZvv-TmqvcbeBZ_8fZeRw"
}]}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
    "SignedMasterProfile": {
      "Identifier": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFaSUUt
TUVNV0wtQVY0UkYtRlNORFktRktFS1ctNEhJWTUiLAogICAgIk1hc3RlclNpZ25h
...
fX19XX19"
,
        "signatures": [{
            "header": {
              "kid": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnhfUUg4aTdxTWM1RC1iM3Np
RVRIQWowTlo3Q25jeGdZZVF6dk15OEhyLUFCVy1tcmtVaW1yS2tXRHpoOUt1QkoK
emM1RmxDY1hkbmdHVzJqVDZ5RGNSUSJ9"
,
            "signature": "
QAMl9eJ_4LOTLk8oqmH0vTSDBpB2wFIDRuL_FpfeQCBDSU_4WOEMLCW0W4D-4Vio
bXSOLEnNzGihY7CsxhBa5b6lYLJHpujRjcdBlJVcE9bs3rpWots7m6NPvn2HT07o
4VR5ckfb9HcGlCsNY3F-8AI5UCmo_raMGYTjIKPLW8INBcxzyOXws1cI5qMRRD7i
eHJU9h-4mmVKjQGser1lm0bTdRjcJffYvW9b4DUZ2jN0ClnIaV7g8nUk22g0poFi
5uce5xbRbERVodHr358VS-XY-_X__DLH_oahRzGQoHhTSx59pXg30vMecLoYw9xO
mjR4-57mMQxeu3TIDOxkaw"
}]}},
    "Devices": [{
        "Identifier": "MCKNF-CHNRU-A5BHA-WJOJK-RJ7V4-K7FIZ",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNLTkYt
Q0hOUlUtQTVCSEEtV0pPSkstUko3VjQtSzdGSVoiLAogICAgIk5hbWVzIjogWyJE
...
UDlMS2JRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
          "signatures": [{
              "header": {
                "kid": "MCKNF-CHNRU-A5BHA-WJOJK-RJ7V4-K7FIZ"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCktGbjgtX3NUenRJVWVDUmZp
T1cxVnpndVl6RXdQQjJhZmlWajFnRzdMZ29kVXJhRVNPTzZzc3pZbDVxNDJJSGYK
RUNTSW5mR3NzV2F5WGNqX0VTUnVYdyJ9"
,
              "signature": "
hvuxuinNyWOA9NadqbcN1gc7-V2nm0IcnuCQYQjW2h57WuAwqkqt_kTu7JoAavy4
Whkb8a74rFKFtrD6tM7A93jPcmGj01GSfddu_tUTcBsghcPNyUwmBdlRvGDcFSza
XRfVsr1EpDWV8xfelYUvWKoBdxoZOi8vDyAZ00ppfkmgXdPTGckiEv50LBd_6pyc
YJoHf-o6J6zzMK-RMFmtzvIFjytkpk9qzT2tvfclPiW9hPZWcOrcFfQEmWc6rgpv
OLI7AOc6JiQOFjKL8qVg7_kbFSpfiQaMiToLrXVbChQNrpFvzPNgRIuLO3BX_7Et
wBZvv-TmqvcbeBZ_8fZeRw"
}]}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVpJ
RS1NRU1XTC1BVjRSRi1GU05EWS1GS0VLVy00SElZNSIsCiAgICAiU2lnbmVkTWFz
...
cyI6IFtdfX0"
,
      "signatures": [{
          "header": {
            "kid": "MCFEP-GYAFG-T7QP3-SVI2U-W72P2-ORD4J"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjhQRFNZSVJnV2tjUlZITVdo
WE9tZi10U3pXOHFtbTB1ZWtKR0t4YnkwdmFSNUZ1THBtSzhMUnN5b21JVHZUSEoK
MzRNWjJyZUoxdjBNTEJZZXMxQnFBUSJ9"
,
          "signature": "
ScbulGYePwVeG1osWzBefRJ4y5hi8jxGdsywFuDvDIMOxQfy_RsCQT9ealAFPt2p
hGQ6M36B5ei2sEEThSQG27pBfsdJU26fCZ-zF_Iod4Y-y0UT6cnGxUqy3SPZfXk2
1a_DeI8kIOp0GK2abK7nlPQzR7xIFGQhSrvMHne6Nw1EnPVB9ps-OC_MjPEFCMS7
fMB9KSSp7fY2U5FdneOgwvXIyykeGEiUq1sS-B5-omxZqApbK5JFVY0xj6f2UQal
GpVBsoMFvoJWJIdfA22TN47IULToFQsc-w187vJzKWUA1xA4yeNScay-0sVxTRno
LgUlY0UKm_I2zw_-J6r2NQ"
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
        "Identifier": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVpJ
RS1NRU1XTC1BVjRSRi1GU05EWS1GS0VLVy00SElZNSIsCiAgICAiU2lnbmVkTWFz
...
cyI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MCFEP-GYAFG-T7QP3-SVI2U-W72P2-ORD4J"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjhQRFNZSVJnV2tjUlZITVdo
WE9tZi10U3pXOHFtbTB1ZWtKR0t4YnkwdmFSNUZ1THBtSzhMUnN5b21JVHZUSEoK
MzRNWjJyZUoxdjBNTEJZZXMxQnFBUSJ9"
,
              "signature": "
ScbulGYePwVeG1osWzBefRJ4y5hi8jxGdsywFuDvDIMOxQfy_RsCQT9ealAFPt2p
hGQ6M36B5ei2sEEThSQG27pBfsdJU26fCZ-zF_Iod4Y-y0UT6cnGxUqy3SPZfXk2
1a_DeI8kIOp0GK2abK7nlPQzR7xIFGQhSrvMHne6Nw1EnPVB9ps-OC_MjPEFCMS7
fMB9KSSp7fY2U5FdneOgwvXIyykeGEiUq1sS-B5-omxZqApbK5JFVY0xj6f2UQal
GpVBsoMFvoJWJIdfA22TN47IULToFQsc-w187vJzKWUA1xA4yeNScay-0sVxTRno
LgUlY0UKm_I2zw_-J6r2NQ"
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
    "Identifier": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
    "Names": ["Default"],
    "Description": "Unknown",
    "DeviceSignatureKey": {
      "UDF": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
          "n": "
2J0wv5YowtIcHSwLLYKPMcQt7VtffX1qiDG1L_Kz6mFaDDa-1vM29JtXI16GNf2z
e95taMfyQaMrMlnmPqBnGum2WPcnhzyXHeVWKg8-7arK4DieSRys6uZz8IsRCgtf
hG5xwu2HM0iGLYQyW-0ZBcyt_5aHAwBUzGTgIIkFMexNkd7yM9WMx8r2_KFqIEBH
kpnQ6PhAzMIq4cHyaf8pe86BtBnWStpb0iSVhJEIff67ExZDxs380uT6I-NEAX40
wDmc-Xte-hknhFurMeE5kM7syaEL5zNE4iSxCvkdflcP14YOM95JuvdJKWfigsT_
Lzl38bvyD-PFDDA5VwhH3Q"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MDNNQ-KB2XP-6DGA3-3JXYT-YJIST-6BKNQ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDNNQ-KB2XP-6DGA3-3JXYT-YJIST-6BKNQ",
          "n": "
v-FwLPsLRa1b_lptCf4H7NomXzxd1RFIUWGk4P6J011ozRtLrDgU9VxQAYwqyBSE
TDjXDNDiA16lzHSajoXWaiP5Jh6H4-hyMOMvtSeedRDEp0KOcvQqZxTy7lLKWRTF
sEvQt__tzH70CxQn5Ffb9PUYZgF1S-y8ZkBRBkYCvKDLT-ooBnK5AhcBNFeuRYk1
5FZ7e44ieCyHJ8Pvwhnr3RFmlGDgO9Uyck8ogHUavGisxxFXxuxF9Vv3GE374fx0
wW4fztAwew7uwtjmjUOrgGrEpXH130cvDJx9DGZsXx4jaUxof7yj-8EdjKk-jw8C
qp5vTJ8XI-pq_GWlJZiOTQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MC4F7-3KBTZ-52NHX-LYPYL-4FMC2-YOVAV",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC4F7-3KBTZ-52NHX-LYPYL-4FMC2-YOVAV",
          "n": "
mw3ZvHG4WQWXa0lhs7LPB6w-JUpOZGogo4_HoFaGvPeSR5WovgHMIBalvhxX-CLj
-1nijKJLpLC3h_MpFMZiZjh6gpAk90ZsQtz_51IPFswuyRsH4G32J3OBFou_O8Pj
GzLe6EKPgokTIYCPcvU97t1XqOLstiIA_dypsPPGZD6nal9i6iXJgJRK6hnqtnir
Ioax2quBkfPsIiIyz6RpFLbG7JsHjV_nhhIOYKKKfbpyBZEXfB8DeiTdnxmH0M5h
oe5GKGoweYFiAK5przz-J7jAPb0Ya2Z6fGx_lZcjsiCq4pHjp5yQ2vgtWt338QN9
V21XEI-mFM-7Lki7Mw1PsQ"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURUQUst
WjNaVE8tTk4ySDQtVk9OVkktUFVMUDItU0RXWUoiLAogICAgIk5hbWVzIjogWyJE
...
ICAgICAgICAgImUiOiAiCkFRQUIifX19fX0"
,
      "signatures": [{
          "header": {
            "kid": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnN5NmhmNU91U3dPaDFjVkk5
WFRyZzE3Xy1wRnZYcHJKemNDSWloV29xSzJnc2VfMGp6a1lETXVldlV1ck5hREMK
WFpMclAxQ3dfUnAtRldrQTZQQWhfdyJ9"
,
          "signature": "
rHUyKocaJiQV1BuUOXtTYWyaxMZ1eQBaAPbT5OuIs2DKneora0MTKyuDlUsnzJbE
KbFak7A0y-ibzcRjncemN-IIHooCyadK7WtHf6qqRzLOrPnw59yty-vvZ_KomMhD
aZQ0fqTnnYPpkL021U53ZfKx8_oWT1NBII6Ndmh4L2ytkfruJmv1lpU7HZR-lzUe
N8KUt6eFL4bZqzaESJzMBMefs4aCiKYsPn0BAguBJclntDbWg-Atafvhh9DEasP5
Pe-C9lQCvn0OTjTbvUAv5Lt6POr85oqsFzKk0Q9FPtCxlxdLZtd-2eAwRgIlO5Yu
oQp39jVHe7Fv1RpETeg1Jw"
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
          "Identifier": "MAZIE-MEMWL-AV4RF-FSNDY-FKEKW-4HIY5",
          "SignedData": {
            "unprotected": {
              "dig": "S512"},
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVpJ
RS1NRU1XTC1BVjRSRi1GU05EWS1GS0VLVy00SElZNSIsCiAgICAiU2lnbmVkTWFz
...
cyI6IFtdfX0"
,
            "signatures": [{
                "header": {
                  "kid": "MCFEP-GYAFG-T7QP3-SVI2U-W72P2-ORD4J"},
                "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjhQRFNZSVJnV2tjUlZITVdo
WE9tZi10U3pXOHFtbTB1ZWtKR0t4YnkwdmFSNUZ1THBtSzhMUnN5b21JVHZUSEoK
MzRNWjJyZUoxdjBNTEJZZXMxQnFBUSJ9"
,
                "signature": "
ScbulGYePwVeG1osWzBefRJ4y5hi8jxGdsywFuDvDIMOxQfy_RsCQT9ealAFPt2p
hGQ6M36B5ei2sEEThSQG27pBfsdJU26fCZ-zF_Iod4Y-y0UT6cnGxUqy3SPZfXk2
1a_DeI8kIOp0GK2abK7nlPQzR7xIFGQhSrvMHne6Nw1EnPVB9ps-OC_MjPEFCMS7
fMB9KSSp7fY2U5FdneOgwvXIyykeGEiUq1sS-B5-omxZqApbK5JFVY0xj6f2UQal
GpVBsoMFvoJWJIdfA22TN47IULToFQsc-w187vJzKWUA1xA4yeNScay-0sVxTRno
LgUlY0UKm_I2zw_-J6r2NQ"
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
      "Identifier": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUFa
SUUtTUVNV0wtQVY0UkYtRlNORFktRktFS1ctNEhJWTUiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
        "signatures": [{
            "header": {
              "kid": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnozMXQxdExqOWxVRkRjZTNm
QnRhR0VIVU5TQVlwclM3eUZ2dF9uanlFZmtZR3MzMGh5Yk1vMlJYVXNKZE9kbVgK
QnpPazAtLVJuNE5pbUVvb3FTTUR1dyJ9"
,
            "signature": "
yPTkwsKOehh_s8Xe4l0VrmWyU-xnFqDMyvqBHAsdXgg9f-4UQKscKy7P6gLleEY-
mqGB79a3gPk1kgrSqrZetbfZ9mFe3Ulsmvmpl8ye6FdosnuL7cdnDZMfAA7nFz-B
9Q95-wnH969x6PoRRMSiueZSiTmqb0nkRl93cZEtZU7CBpZauRrb64tTinhPP8xA
UZ6FAkNzVoNopDBwdkAhaRDriWWTqg3nFVYrKcORv-ITnnagc7WgQrVp6J5PF3bA
lQmxPF0fU0JlFJwhAZee0ARhTvt5kNFcTZzOityzJ7vwZiwphDeQ5clktfc0GCP2
HH4bY3H9tHh51b5wnuAslw"
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
        "Identifier": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUFa
SUUtTUVNV0wtQVY0UkYtRlNORFktRktFS1ctNEhJWTUiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnozMXQxdExqOWxVRkRjZTNm
QnRhR0VIVU5TQVlwclM3eUZ2dF9uanlFZmtZR3MzMGh5Yk1vMlJYVXNKZE9kbVgK
QnpPazAtLVJuNE5pbUVvb3FTTUR1dyJ9"
,
              "signature": "
yPTkwsKOehh_s8Xe4l0VrmWyU-xnFqDMyvqBHAsdXgg9f-4UQKscKy7P6gLleEY-
mqGB79a3gPk1kgrSqrZetbfZ9mFe3Ulsmvmpl8ye6FdosnuL7cdnDZMfAA7nFz-B
9Q95-wnH969x6PoRRMSiueZSiTmqb0nkRl93cZEtZU7CBpZauRrb64tTinhPP8xA
UZ6FAkNzVoNopDBwdkAhaRDriWWTqg3nFVYrKcORv-ITnnagc7WgQrVp6J5PF3bA
lQmxPF0fU0JlFJwhAZee0ARhTvt5kNFcTZzOityzJ7vwZiwphDeQ5clktfc0GCP2
HH4bY3H9tHh51b5wnuAslw"
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
        "Identifier": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUFa
SUUtTUVNV0wtQVY0UkYtRlNORFktRktFS1ctNEhJWTUiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCnozMXQxdExqOWxVRkRjZTNm
QnRhR0VIVU5TQVlwclM3eUZ2dF9uanlFZmtZR3MzMGh5Yk1vMlJYVXNKZE9kbVgK
QnpPazAtLVJuNE5pbUVvb3FTTUR1dyJ9"
,
              "signature": "
yPTkwsKOehh_s8Xe4l0VrmWyU-xnFqDMyvqBHAsdXgg9f-4UQKscKy7P6gLleEY-
mqGB79a3gPk1kgrSqrZetbfZ9mFe3Ulsmvmpl8ye6FdosnuL7cdnDZMfAA7nFz-B
9Q95-wnH969x6PoRRMSiueZSiTmqb0nkRl93cZEtZU7CBpZauRrb64tTinhPP8xA
UZ6FAkNzVoNopDBwdkAhaRDriWWTqg3nFVYrKcORv-ITnnagc7WgQrVp6J5PF3bA
lQmxPF0fU0JlFJwhAZee0ARhTvt5kNFcTZzOityzJ7vwZiwphDeQ5clktfc0GCP2
HH4bY3H9tHh51b5wnuAslw"
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
      "Identifier": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTURUQUstWjNaVE8tTk4ySDQtVk9OVkktUFVMUDItU0RX
...
eWlXTkE3V2ZQQUQ0WkQ1NzNVWWVnIn1dfX19fX0"
,
        "signatures": [{
            "header": {
              "kid": "MCFEP-GYAFG-T7QP3-SVI2U-W72P2-ORD4J"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCkRpa0NYU0xTN3NSMUh2UmRX
STVnd3dQNHNRWURRcGVfV2w0d0wtcmY2a2ZBbU9aZ25keTBfRnBkWHNZUjk0UjcK
U2x1bnh3Yi1VNy1SSWdoaWpXYnRVZyJ9"
,
            "signature": "
Q3KRPameCTD4kOXWHtdi8qnGhChnpPHnJciKuKiUbH2IC6xPzPyWay77vq6oURQk
FVKWsrhdYBWjH6-3uYK_ikac8NFooC6OiXa7Ih62sHFGmEy4HXVNY0cFUovnS4Sb
mtqD_U_rElBNUq7TtV6JMjet4Gvq37AnAmAbxg5VeEF73r6r22Ie13R2Mbgw6C8t
RkspabvWF6sa_KjztI5oGGglKqGjYBsgAtkMW_nu-B2IXwur-o5nDQJY2RLWfWJk
zzh1FiZexBGm5eHONl3oMgNl1YKt1m6byBwPilfY65E1mDs-17M2ZWRBOSXfZhiN
ndVG3FqGoOdPoBGTSf6qRw"
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
    "DeviceID": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MDTAK-Z3ZTO-NN2H4-VONVI-PULP2-SDWYJ",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTURUQUstWjNaVE8tTk4ySDQtVk9OVkktUFVMUDItU0RX
...
eWlXTkE3V2ZQQUQ0WkQ1NzNVWWVnIn1dfX19fX0"
,
        "signatures": [{
            "header": {
              "kid": "MCFEP-GYAFG-T7QP3-SVI2U-W72P2-ORD4J"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCkRpa0NYU0xTN3NSMUh2UmRX
STVnd3dQNHNRWURRcGVfV2w0d0wtcmY2a2ZBbU9aZ25keTBfRnBkWHNZUjk0UjcK
U2x1bnh3Yi1VNy1SSWdoaWpXYnRVZyJ9"
,
            "signature": "
Q3KRPameCTD4kOXWHtdi8qnGhChnpPHnJciKuKiUbH2IC6xPzPyWay77vq6oURQk
FVKWsrhdYBWjH6-3uYK_ikac8NFooC6OiXa7Ih62sHFGmEy4HXVNY0cFUovnS4Sb
mtqD_U_rElBNUq7TtV6JMjet4Gvq37AnAmAbxg5VeEF73r6r22Ie13R2Mbgw6C8t
RkspabvWF6sa_KjztI5oGGglKqGjYBsgAtkMW_nu-B2IXwur-o5nDQJY2RLWfWJk
zzh1FiZexBGm5eHONl3oMgNl1YKt1m6byBwPilfY65E1mDs-17M2ZWRBOSXfZhiN
ndVG3FqGoOdPoBGTSf6qRw"
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


