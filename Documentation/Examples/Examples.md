
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
Date: Mon 07 Mar 2016 09:55:13
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
    "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
    "MasterSignatureKey": {
      "UDF": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
      "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQTd8uSz4Vi_wr6u0oNPlkzDANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQkU2RS1HVDdTTi1NSzc0UC03NE5JUi01WEk1VS1KTk5KUjAe
...
PnbUbH_eWEdbxYGTqAIyU5BGYuVO5BzYjBYtOmL6TY5_CTfo_C1ndZSy",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
          "n": "
nGIt3V1bp9g47Ce43H4K4Y7E0bCpJqvk5_xwdCenueByentHwTJLxwOodaeIZFr_
ypJpeO5OXkyjM6IeaicPXe5hfn6DEv8Bdg4139HGaaOz1X0N0UVQ23cRCCFZGUJ_
bQwEhvA1LROg-mOJ8ZK13Jqo1P6iT2HRZ04NdzWIVrhnodotHfN843iJfjv300Y6
yavw_wco8aRA6kyuPLV3THTt5RxBweiFSSVGqkOQeg-0mnEI6sPn3N_Av59NjvPD
_KyzmNkXIT1poVMW0kCoaDl9czEFG3bP-a-3BQZELtYqz_e-_CJ0s3v7h09Ndkss
ot6tCegjoqLHlj4rwuglbQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MBMNY-BWO45-HDFCN-USWES-KFNAJ-KLLM2",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAIUO37r79ZqdS_dIZmLWyeowDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJFNkUtR1Q3U04tTUs3NFAtNzROSVItNVhJNVUtSk5OSlIw
...
QUQm_y3ZQrg5EooW-uzWV1SkE1YhDqgg3hWjojG4XvvSuuAyg-YvQ7UNpQ",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBMNY-BWO45-HDFCN-USWES-KFNAJ-KLLM2",
            "n": "
sENXIp2tD0jYog0_WXfHqef3swqxdO2BnkGSJ1pokXhtaXWApA-wl__tiM75rW_Y
qRZzUcreSOH-ObNbtjDmzRODlJrHzMdgV7kI5PCrIoOPf0g67Kh62p_JSH7-MiTg
UYfuLnz1dgILQWrBToLEtKRKsSAnfEuXBsVMWVW0PHJ_8v4bKIsrVrxU4eoPTnUr
deXRys_cPmrGadPW84vMzEvng2vmUmBTA_Aop6ebXryHATvrig9HwQpsIG2Y6pmk
gLTdbFS3QqN3d0Yi91g6HY4kw7YGpia_tnglZaXtbCBE8nILrD8cbFTMCHoT-HKt
JrBmVX_MJJm3GbNlsjCFaQ",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MCPIV-22IHS-74ZZE-64IPE-3VH67-VOJ6K",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAJEsOhUFJt2cF5pnSjsWJ8kwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJFNkUtR1Q3U04tTUs3NFAtNzROSVItNVhJNVUtSk5OSlIw
...
OeqtA55UIOuS2QtXj8ZKtkvXTMONbdyMs2W7sPQ42JDOqLijkPycyg9OWQ",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCPIV-22IHS-74ZZE-64IPE-3VH67-VOJ6K",
            "n": "
4ByhwNfPqvcq21GZijSjusu-TVcWDT_AIo9v3FOzJAWPl1NAXV9vL-L21FVYkwJy
HwTJJSYJfWDaDYaBO3z_1-TF-kYpRLtqwFTyKv73WEt1qyF10uwJ0Y_AwqWFRhVH
m4RlDWo2v035Pd3jMrECESV0yFfG4ea8PWL_99vGhgoR5T8_kXIxVbwaDBy468Zu
ORTyfoEGeWnYwwbdCkSWbDxWvxgjqJhTOgkMbD8Ji3BXV3qbR52xVbPujg-1_SrH
E2TmPtgOD0wqVn21YV44mXoP4bMrnc9Fi0ZTLWoeqUcrToFZ8xkKt7c5-FdYZCd9
SvdeJnd3pC6cwpyMQpT9hQ",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJFNkUtR1Q3U04tTUs3NFAt
NzROSVItNVhJNVUtSk5OSlIifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJFNkUt
R1Q3U04tTUs3NFAtNzROSVItNVhJNVUtSk5OSlIiLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ",
      "signature": "
FJsVIQyh1VavjnqKVkWkaVv2WPAyVKSFW-uX442lWJ6jwRTS_KdCe3qQcxR-oHph
_x26lnCLl67tQI9UyN4Wf7xSMOASx2UXdZW8ahIu5tsldShMPtI9Er7hXORwY39h
jeo5quBOxkWaNEBBMhlWJxEZ8SSjjf5VH1xz7LhL-vL0-2YPtwgmP_qjYyBgqZ-4
7pCtOWg7xXVIJH1YmMw7raaetIoLQQcDh1DWxA0L2oFnD5XVhtLHMVCy1UbTkUUc
uoz8rNdU30h2hQP-iwnnd_tOssnTvL8bXzVWNzHLUIIkqrr0j3XHRTzd7M4u2egF
O-NzIDnTndKpF2zt7LRXtg"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MAZNC-UNLFK-LQ5MU-CNW34-BUKNG-FLPQE",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MAZNC-UNLFK-LQ5MU-CNW34-BUKNG-FLPQE",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAZNC-UNLFK-LQ5MU-CNW34-BUKNG-FLPQE",
          "n": "
sVo3r6oc5OtrjtH9WVLix0vkO9AwxlUatYpcdmjCb9Pr1DD3Pey8whtTMlrHSIf-
hz3lu5kw96XveGSmB9mqcIgOaK1AKAnoais7Z394HkdD6wuB148nt6JUKQ2lylAg
lSTrm298lT706-1hYQnYBlJFz2WBuQsETDLlpJ0iKo38xAJe4D15cAgkKsFiCi6r
mlv9Ebe3D1olhSbyAsuQHnXeRLPoQFwcB0D3J-3EIJSZiKggMCjn9meXLNe-haz4
tRD1O-5WBwFrMmabXgxxEp0hiP4o-UswH1XxjU_IqiJWFC113Y9jNLJqiS5fxHLZ
0ls6Ag078CHJsSHlp-fLww",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MANI4-O6YX2-RSAZL-UETQX-P7ZIK-R3BOO",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MANI4-O6YX2-RSAZL-UETQX-P7ZIK-R3BOO",
          "n": "
0CMP9QBJ-T3phVkwriZ4KdhcN6Rl9iYRlVwNkF1-K9QDSMQVnkvzbvUG2SVw6dgw
QAOtfu6FREjW4_v6iwBfdlrh4vOikEUsQhebeaW9AjU_TbqPp01OUJcPQzQ3-6PX
8JOgtt8yP01UcAabJP31UZwdfDsTa_5029NwIAKIYb0e0BBHqrTO1EWqjL5iJOxf
GEkbVyl8hIYm0BIaCdgNtNY9z0HyrDWxGWIiFRI_zIqr0J5LNlv0LuUnKtYn-j05
5-QM_t5D46eA0tH_F1PNJ37Tz0-0NgUv-iWFd7IvWpeuxTk-zDeprC1jiwLnZGDi
aSC2GcXItUbzQVtJWUZoEQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MBR27-Q5CT4-V4JWN-IOWRM-Q2ORL-NVN7F",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBR27-Q5CT4-V4JWN-IOWRM-Q2ORL-NVN7F",
          "n": "
xAA5i1_r6rph_BrcwxbgnjSJsgDBvBEIqA-kIji4ubdhJuNu6kS3Yu0qlsNGndyY
cgN8tB1HzEmC-CUqGHVJle5QktC4-kJHzQXXgXApmMb1KOwW81pBWLYmSJ39VnRu
n4G9N8MnFAiqb9wgjTe8yQv4WWpXoc5yUe3_ZVkX5DfVYqyg5VwxgxjbcVBpMIUG
1IH-u4Ip2mj_hFlG_M4CRhFmt5LSEZnWuaPfs_Q-sAA7A6cpmkvTfJOtN7SsrWSu
kMz8TGQgtNfPwxKhwidhN22zjPAbCp5ZMDIWeBXgLjIJ_EGUOQsnKKJlnLTy_j3V
ytYqfCAC8FKm82rV9cMDEQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAZNC-UNLFK-LQ5MU-CNW34-BUKNG-FLPQE",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFaTkMt
VU5MRkstTFE1TVUtQ05XMzQtQlVLTkctRkxQUUUiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
m_MWAJmM3W7pjvtLGKJxz7mdEPSuMzQDvrHpBT4i6acWD71KlCuih8rgFGyaSAbD
22b9dNUjnNx6zDz0lQOU8BsmNuR0tVnecpCk_pDZkrTudiqZcwDzLMIU6u-7-s3p
b8L732wIK6nRymR7oMq5Lc8iRdQWOWIEuM8oCEeXnaX_S0np73ekQRVIKJq6Ls1l
lAiUscIcuXjCMpBe0fgBOMmoMTlXsBK7oMGvshZfnhHMEmHmXcPO5RdtYZ7v1y5i
jA3Txf9d9hhqxvcVzbbIYFt3D8GyDAaYEcVz5kNaiGybVQSKEPYmVCS2AyNWNnjd
J3Wj5O9hnB3139Ad7L8a2g"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
    "SignedMasterProfile": {
      "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJFNkUtR1Q3U04tTUs3NFAt
NzROSVItNVhJNVUtSk5OSlIifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJFNkUt
R1Q3U04tTUs3NFAtNzROSVItNVhJNVUtSk5OSlIiLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ",
        "signature": "
FJsVIQyh1VavjnqKVkWkaVv2WPAyVKSFW-uX442lWJ6jwRTS_KdCe3qQcxR-oHph
_x26lnCLl67tQI9UyN4Wf7xSMOASx2UXdZW8ahIu5tsldShMPtI9Er7hXORwY39h
jeo5quBOxkWaNEBBMhlWJxEZ8SSjjf5VH1xz7LhL-vL0-2YPtwgmP_qjYyBgqZ-4
7pCtOWg7xXVIJH1YmMw7raaetIoLQQcDh1DWxA0L2oFnD5XVhtLHMVCy1UbTkUUc
uoz8rNdU30h2hQP-iwnnd_tOssnTvL8bXzVWNzHLUIIkqrr0j3XHRTzd7M4u2egF
O-NzIDnTndKpF2zt7LRXtg"}},
    "Devices": [{
        "Identifier": "MAZNC-UNLFK-LQ5MU-CNW34-BUKNG-FLPQE",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFaTkMt
VU5MRkstTFE1TVUtQ05XMzQtQlVLTkctRkxQUUUiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
m_MWAJmM3W7pjvtLGKJxz7mdEPSuMzQDvrHpBT4i6acWD71KlCuih8rgFGyaSAbD
22b9dNUjnNx6zDz0lQOU8BsmNuR0tVnecpCk_pDZkrTudiqZcwDzLMIU6u-7-s3p
b8L732wIK6nRymR7oMq5Lc8iRdQWOWIEuM8oCEeXnaX_S0np73ekQRVIKJq6Ls1l
lAiUscIcuXjCMpBe0fgBOMmoMTlXsBK7oMGvshZfnhHMEmHmXcPO5RdtYZ7v1y5i
jA3Txf9d9hhqxvcVzbbIYFt3D8GyDAaYEcVz5kNaiGybVQSKEPYmVCS2AyNWNnjd
J3Wj5O9hnB3139Ad7L8a2g"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkU2
RS1HVDdTTi1NSzc0UC03NE5JUi01WEk1VS1KTk5KUiIsCiAgICAiU2lnbmVkTWFz
...
aG5CMzEzOUFkN0w4YTJnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
      "signature": "
K8mCEKshLuNoQGV42XglPpSoe_AA-Du5To4x-pYZ4IU0kYie_Gj6tlmZmsBerIQU
_S4oWTnxqvDDo6AHZ4nEoNQr9HjJkbZmvahL3BW9zTZQoyerxBvMmN2oiLQkkc3k
8vKjLnHb6QgYn0js0h0qhTptyKXNIwHyiXOsIs2vbzROcsRDkunRwZ5_aIFIQNP6
GsphuJbQjLzDryUDA8U3Bex69r-6Z0Ai_C-F2RZ6wskBWkY40gW373RB4eFzhp2s
AlYKxDizutwIkONpXHX5xNBcIL3jpidvp9WIRRZ8MPrpUAghcxgke0VyaoKtHJ9U
RI7lifCXuGXN-dIewAUdig"}}}
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
        "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkU2
RS1HVDdTTi1NSzc0UC03NE5JUi01WEk1VS1KTk5KUiIsCiAgICAiU2lnbmVkTWFz
...
aG5CMzEzOUFkN0w4YTJnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
K8mCEKshLuNoQGV42XglPpSoe_AA-Du5To4x-pYZ4IU0kYie_Gj6tlmZmsBerIQU
_S4oWTnxqvDDo6AHZ4nEoNQr9HjJkbZmvahL3BW9zTZQoyerxBvMmN2oiLQkkc3k
8vKjLnHb6QgYn0js0h0qhTptyKXNIwHyiXOsIs2vbzROcsRDkunRwZ5_aIFIQNP6
GsphuJbQjLzDryUDA8U3Bex69r-6Z0Ai_C-F2RZ6wskBWkY40gW373RB4eFzhp2s
AlYKxDizutwIkONpXHX5xNBcIL3jpidvp9WIRRZ8MPrpUAghcxgke0VyaoKtHJ9U
RI7lifCXuGXN-dIewAUdig"}}}}}
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
    "Identifier": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
          "n": "
3qzoLzEeH-HgSOl11SN6DKZn7citl42NE4W7eNnrIXnJetz__DB-QQQbi49KRLGT
sl-7K_Z5nvrgurf49TmKmTvAuMkwU95JYRwgGqg1iMKCxvTfrbB2JUAEjuFhXZZZ
n1Fz1hjGf0OvGmyEKfROOwvv7oqJs8Xmyri2tWG39qU55t00IAQwhGiou77fNeUz
KSsKgMFW1PtTjNmplT0AN0AGO-ZaSNEd017XmoYR7l6wh7ryIzM4EM4bbvSqgLJJ
8KP3RoxrSM3V2R8lhRMIZ7oZhDCUe-5ea3Ajo-sOkWCFVoLO2j7nvS8wNwiPQEDi
khjg8mSErY1FZMTgwshTRw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MC2TH-YLL4Y-A32WX-USL4Y-ODL6S-JVDVF",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC2TH-YLL4Y-A32WX-USL4Y-ODL6S-JVDVF",
          "n": "
z3UDF2xLHS98_YkE_0kh7aZE_CRNBYKtP4ykWZo9UFlhalgw7zd6YtQBDJ51JFZz
4QHjdJSYRhPgY4KRfs2j72_P3sYPEVrB2unCOJomqv4G1A0O4TWrXxJCoudQFTBS
HoXsJU__upnAZrOh_eUsmJkFEgIzK4r0ExeCmdLWkq6FZWj_-Sfhq9h16LK_Y2eK
Mqy2KBV42tYEF4vOuYu40YjVsc886l9G33gEBK2FKnvvOAZipEYgzx4B8PqFDR7b
G352St5l6AVF3WX5pSYGkDFGqMW58Xm5HK6RZOJbiq-NHTDD9oBkXEb_AQrl5vGF
pXFyI-hC2L3H-gjMOeTipw",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MBK3F-PIUEO-RMIG5-H676A-OUURB-XSQXS",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBK3F-PIUEO-RMIG5-H676A-OUURB-XSQXS",
          "n": "
4lrvy672efXw3Czr9LQgmAeFDIrf6fsN7Si5ngrwT2kSRKdI_Lz8KmywRHE2u3VH
BPzAUBjDmbxH76toFBA_Nu53XI4Pr4uO2DMydYguCSqtkFC03Epngw4ffBKhiM1s
_lvj5xHLXsjbQC9umMkMhoxJRzO9T-d0fYhf6IQ48EA3sgUsQx6OkY5FwnLqN8A9
aV0xeXo7EIiHqKhTMlfYC8NR2B-Luu3QeDDpG_vo9o1cxv7joU6HU0VeTWGGUnG8
jbdJbmYFPjqFBxSjIrz3toCizWXdcCZ0H95O_msBW5eiR2UAWiWXor7SWQ7zbbsW
chUDKXNfFQDWNtQaIJo1cQ",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNIVTMtNUNGNVAtTURQNVQt
SFhDRkctVVU1SU8tSDdVSEEifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNIVTMt
NUNGNVAtTURQNVQtSFhDRkctVVU1SU8tSDdVSEEiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
brcZgPub67P5Vo-jxNNV46aCTG9X7lAOQbpPwe5SyU87kcEEovYV9PF0v0qV4Sx0
9RIZe_XnAc1GTnxNw2kdxqk1v2Y75aifW6jHdsGbr8pcs0iamqdcdaguPFvi2Beh
lTa1LNuTFfQ_4EaktKpWPDosYse_eJI-us81XI6hZU3l69IPTwXXQ9h_cVnDarqP
cFoPAcS1XDqUw5Am8bEbf6dlH5pHCfuEReCU_vDOKwXVEQiqy16XCOxVJXkBr1-B
_bRXDkiui3G5AhQHfg2ELByYUyTJ7sYmBVqqG3RATTINr9rkpDPHp1eHHUUti5hT
KXQSjLSS5q4XuF4juhohRQ"}}}
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
          "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkU2
RS1HVDdTTi1NSzc0UC03NE5JUi01WEk1VS1KTk5KUiIsCiAgICAiU2lnbmVkTWFz
...
aG5CMzEzOUFkN0w4YTJnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
            "signature": "
K8mCEKshLuNoQGV42XglPpSoe_AA-Du5To4x-pYZ4IU0kYie_Gj6tlmZmsBerIQU
_S4oWTnxqvDDo6AHZ4nEoNQr9HjJkbZmvahL3BW9zTZQoyerxBvMmN2oiLQkkc3k
8vKjLnHb6QgYn0js0h0qhTptyKXNIwHyiXOsIs2vbzROcsRDkunRwZ5_aIFIQNP6
GsphuJbQjLzDryUDA8U3Bex69r-6Z0Ai_C-F2RZ6wskBWkY40gW373RB4eFzhp2s
AlYKxDizutwIkONpXHX5xNBcIL3jpidvp9WIRRZ8MPrpUAghcxgke0VyaoKtHJ9U
RI7lifCXuGXN-dIewAUdig"}}}]}}
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
      "Identifier": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNIVTMtNUNGNVAtTURQNVQt
SFhDRkctVVU1SU8tSDdVSEEifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUNIVTMt
...
UlEifX19fQ",
        "signature": "
P9JsGwGKQBQ655Cod9PAHQSTeF6Du6M0Fasvmgkw3ZzaWPTuUy8wUClEh7kM5EKA
91o3wrUe4WRVN5uCn7Vq246JMIwS5lhl4iiaoHYzBbWSyM_14Qidx16_JhMRNbZe
04204fu14IC3Q7wMZiof-FkkqRMD0GjspLpmUfd7Af0d-2_0lhE6LB0a3nHV6BgK
29JPyf6UBxbznwatXirsZCkdELRBvYFJ_0T-dLmPevHUteQ9gtX6IiaK9lgG2FS0
YdLgaNVzlz0RnRRFSVMqguyLXro2yRID_tgegn165PPblZc4fV2M0yQOHBOwhpRV
czheyzpFcB2URNs9F9fJ9Q"}},
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
        "Identifier": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNIVTMtNUNGNVAtTURQNVQt
SFhDRkctVVU1SU8tSDdVSEEifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUNIVTMt
...
UlEifX19fQ",
          "signature": "
P9JsGwGKQBQ655Cod9PAHQSTeF6Du6M0Fasvmgkw3ZzaWPTuUy8wUClEh7kM5EKA
91o3wrUe4WRVN5uCn7Vq246JMIwS5lhl4iiaoHYzBbWSyM_14Qidx16_JhMRNbZe
04204fu14IC3Q7wMZiof-FkkqRMD0GjspLpmUfd7Af0d-2_0lhE6LB0a3nHV6BgK
29JPyf6UBxbznwatXirsZCkdELRBvYFJ_0T-dLmPevHUteQ9gtX6IiaK9lgG2FS0
YdLgaNVzlz0RnRRFSVMqguyLXro2yRID_tgegn165PPblZc4fV2M0yQOHBOwhpRV
czheyzpFcB2URNs9F9fJ9Q"}}]}}
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
        "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkU2
RS1HVDdTTi1NSzc0UC03NE5JUi01WEk1VS1KTk5KUiIsCiAgICAiU2lnbmVkTWFz
...
fQ",
          "signature": "
SdH4UGULcbuelUric3-4V_7AR0zaZzHHRcJXT-zYTm7ywKZMvU7KOWefrsOIttmf
9wG83u5CQ8qOM6PQjKuXTMR-beqDHaq0OlBxq5FxuGNaItdh7F3u8SA8hh0fH7lV
Ipp9OAq3szZ3Gn8kLwuENvAB9lofJ_wjxycI3Fo-LfszX3d2VI1lLLUuwkIwGJ8h
sqoBlpe2lWZs2lNE2_ipZCE7E0OP3ONtPIeuM-Ug75L6byEe3ajpuivDx-lsLxfm
q67ctxATZLZbDbMmzBSH9w5dhjegsYvovzAwu4IBpVhY3km-Apjv77PxaqaoTQID
JaYDAzwOZsq2kWmYixjuNg"}}}}}
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
      "Identifier": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNIVTMtNUNGNVAtTURQNVQtSFhDRkctVVU1SU8tSDdV
...
dGVkIn19",
        "signature": "
Ivx503XE1dobuixWgagWErSUVoxADfIi8wBcFLK2j4XDFlARtUu6HXs-7kKEapGe
GDngU7MFLtw9YSrlsaRXPk85OuE_sxKpoaU_7_wlxehHMDPIJnyaHd3M8Zic3eo8
jMPglE8UniBF7oEBKkUULNvHZj5tVXoSt7UbGS6_6U7CXvM9Uc4sFBCnxzakmZmO
1aAJBKyeyI2qY1qFR1gqxJxetuTJjonporGIcQdL5uw-LQUnGEIBRzU22FNcQjCW
qxvxvQVjNvK4DRGbxpI-bo2cBLg4n5VsPSymeRAyQop729fZ-rpR5b7Rht02qc_d
bHHgUTfaFI9y5CS-WfLC_g"}},
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
    "DeviceID": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MCHU3-5CF5P-MDP5T-HXCFG-UU5IO-H7UHA",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUNIVTMtNUNGNVAtTURQNVQtSFhDRkctVVU1SU8tSDdV
...
dGVkIn19",
        "signature": "
Ivx503XE1dobuixWgagWErSUVoxADfIi8wBcFLK2j4XDFlARtUu6HXs-7kKEapGe
GDngU7MFLtw9YSrlsaRXPk85OuE_sxKpoaU_7_wlxehHMDPIJnyaHd3M8Zic3eo8
jMPglE8UniBF7oEBKkUULNvHZj5tVXoSt7UbGS6_6U7CXvM9Uc4sFBCnxzakmZmO
1aAJBKyeyI2qY1qFR1gqxJxetuTJjonporGIcQdL5uw-LQUnGEIBRzU22FNcQjCW
qxvxvQVjNvK4DRGbxpI-bo2cBLg4n5VsPSymeRAyQop729fZ-rpR5b7Rht02qc_d
bHHgUTfaFI9y5CS-WfLC_g"}}}}
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
    "Identifier": "MDEN2-UTGDH-QLQVK-WLWNZ-5PUEJ-ENBMZ-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
WsltYIEfrpyP6rxBA_VtKA",
      "ciphertext": "
7ss3PCJbMqWsRUo5685GFfzTBD3jETyPba6wasmJ8E-CZKbfpf2xLojht5_iF_XN",
      "recipients": [{
          "Header": {
            "kid": "MBR27-Q5CT4-V4JWN-IOWRM-Q2ORL-NVN7F"},
          "encrypted_key": "
ur3mcZ03WPjp9lot67i8e6WUlC1yPh6QT1vtyaRwkbczPD9I7n08SiEIWXe4HqxV
GNjVEY1sqlxaRTCBiTyx_C4bx4KD4NTSPYd0I5BrKDVQXdRAwNFTWCtuTrdbi9Hv
3iUlEGg2MT8rNgbdChRNuhZAxFOOYCuBS8TacEJsbD5dFzQe5fDSQvJp3Bo87C8C
siB1VNJj0f4MSgJ6CzA2hmw2jHwQYVIe8ogEXtle3z_2y2tK_gVUO9J4cVsAYdCN
AGgz06GwV6jpMz0v3fvDh0o2KlVNI7BEHEk5jv7nCbUxW_t135hJpZrM2OC1Yzcd
4uYA_-m4SUfNgsgLWZGxLA"},
        {
          "Header": {
            "kid": "MBK3F-PIUEO-RMIG5-H676A-OUURB-XSQXS"},
          "encrypted_key": "
qwHELAziioKXrkbMUJV0n5HxsU7eoruNoJR_LFGHYu_8i9Wx-le5RT3Wx-Cj6rTr
lnDwzGEsmKIbwKyEDqND6pUpMrZe_NhmY0Bitc0tq9_IFUgGaVHl70elcTm2-JlO
IFmTFAZb1vVq4YbSOUkPgJI_Yx_AXgyTtsYHKpsrEXJzm6meznuFx26GSbDEDOh2
uWa9r0VTnwMMZK2k9MTfKqHGuF3pMXMgwmjT4xAcOSrLv_Mvp8316DOxWYyWHPjA
nw-zo-NPC2CaXHec_vJEhwezksn1r2cT5m5VHjc1KTbs1PlNu_vy58p8S-1XUWxd
hYeNVTG6Kv0KqRdzjbVyjg"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MDEN2-UTGDH-QLQVK-WLWNZ-5PUEJ-ENBMZ-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREVO
Mi1VVEdESC1RTFFWSy1XTFdOWi01UFVFSi1FTkJNWi1BIiwKICAgICJFbmNyeXB0
...
eTU4cDhTLTFYVVd4ZApoWWVOVlRHNkt2MEtxUmR6amJWeWpnIn1dfX19",
          "signature": "
WtTxAEiNlQUbweTuQ54kD5Ev1mBxwRCc5o2P_hd64bA-k0UISqroxCsRk-I0_C0y
qMUOwuTCWyT3YTVOVWy5vd0_hLpJiAgKxa1UH1VmEAf_NZ9weHA_wDAwZMRhrHDz
yfJsABozwf-zeujONaqlnOru5X4rbaO-qiQhzDnysujg9fb1PzVMOHxzqcX3g1au
wB0S4I0KURYnlW8i_XJn4OO0KmNYg_4fqRkLdt1JDWqhPcCAiTZnPBHfYH09WAIb
oMuyNT7ON40yFxggx5rO3w1hy6niFEcG-1fohEBR7S9v1r3n4u95yH0UgVShJcsB
aBM7ghJO1S4Gl6RWXJ-5oA"}}}}}
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
        "Identifier": "MBE6E-GT7SN-MK74P-74NIR-5XI5U-JNNJR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFaTkMtVU5MRkstTFE1TVUt
Q05XMzQtQlVLTkctRkxQUUUifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQkU2
RS1HVDdTTi1NSzc0UC03NE5JUi01WEk1VS1KTk5KUiIsCiAgICAiU2lnbmVkTWFz
...
fQ",
          "signature": "
SdH4UGULcbuelUric3-4V_7AR0zaZzHHRcJXT-zYTm7ywKZMvU7KOWefrsOIttmf
9wG83u5CQ8qOM6PQjKuXTMR-beqDHaq0OlBxq5FxuGNaItdh7F3u8SA8hh0fH7lV
Ipp9OAq3szZ3Gn8kLwuENvAB9lofJ_wjxycI3Fo-LfszX3d2VI1lLLUuwkIwGJ8h
sqoBlpe2lWZs2lNE2_ipZCE7E0OP3ONtPIeuM-Ug75L6byEe3ajpuivDx-lsLxfm
q67ctxATZLZbDbMmzBSH9w5dhjegsYvovzAwu4IBpVhY3km-Apjv77PxaqaoTQID
JaYDAzwOZsq2kWmYixjuNg"}}}}}
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
        "Identifier": "MBI3I-VVSEN-37UWI-XZ64K-OFG53-GRGL6",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
R_u1uCRkfAz6VEG17C9oiw",
          "ciphertext": "
kwoKDHyjOL9MEr7UdKE3D-prGHj-JL2_sdrA3vVTJcBLKgRrLgCLPUBCl9-mO2_d
fRoM1d9L1haHMrjBqaWZ0CxTL3boINUClfsoQ7T28I7fl5DcXKETZh-0hUZxkjRv
...
lzkw7q7LtmMB_NbJlSsVBCi1aTvC125Xhxs_zHAwKhjEzB7Ea6yGMY-WqwHn-_Ww"}}}}}
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
    "Identifier": "MBI3I-VVSEN-37UWI-XZ64K-OFG53-GRGL6",
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
          "Identifier": "MBI3I-VVSEN-37UWI-XZ64K-OFG53-GRGL6",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
R_u1uCRkfAz6VEG17C9oiw",
            "ciphertext": "
kwoKDHyjOL9MEr7UdKE3D-prGHj-JL2_sdrA3vVTJcBLKgRrLgCLPUBCl9-mO2_d
fRoM1d9L1haHMrjBqaWZ0CxTL3boINUClfsoQ7T28I7fl5DcXKETZh-0hUZxkjRv
...
lzkw7q7LtmMB_NbJlSsVBCi1aTvC125Xhxs_zHAwKhjEzB7Ea6yGMY-WqwHn-_Ww"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


