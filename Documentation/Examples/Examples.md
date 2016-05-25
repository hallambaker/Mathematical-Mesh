
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
Date: Wed 25 May 2016 07:20:13
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
    "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
    "MasterSignatureKey": {
      "UDF": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAKk0qvis2jJAHyMKL98NKW4wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUE0N1AtSlVWMzItU0JKV1gtMjRKMlYtRjdaU0wtS0E3UVYw
...
h5p9HlaSAVDIF5Sm0UUwTR0a0zSVZJE-hvrrhAqFgWgEzcjKDNfujcEnnw",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
          "n": "
y7qwkh2kGxza-5EQF6SJ-Ib2-gA-FFcjM1kPb-9y7FQCCt0w4RXy09xz9x2y8EvN
6ekC-z6GaM3sDH3bs63b4SDrr81PKSKmzLZBSLIZRttgOOjgxRl7VYydoHfi4Ntd
WtXkPp4qjyCAWL3-mkmJSMp6hbBl8z7Y5MSTE4ZWpMJTYW5hkZS0Rb0ANsyVGZUV
pTTU-9qddB1Y6yctnqLj69vc2j_viHuKGE5PbKobzFyncU1keQiqCIJ7Z6Io1bad
DRoDGgSr4-1XL3uI3jzEDNd9KZgCtWlSn3eslHQJ0mPZkrbUy-tU9YfJvDdBLv2r
7n3dqquSgPkw0vm1SCd4XQ",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MBHX3-JH2JM-ZOUPL-SETYH-Z3T46-QZH5G",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAOL9giYbpdDK2BsdLt8dfYEwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUE0N1AtSlVWMzItU0JKV1gtMjRKMlYtRjdaU0wtS0E3UVYw
...
RFoOBwvbHJWJ3EjcZ1GMTvUJfA5BJ9h5sB_LdpzKiwFiZKnnHJE7zNyUZQ",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBHX3-JH2JM-ZOUPL-SETYH-Z3T46-QZH5G",
            "n": "
5fJLkjxAYnxw5f2uwNmRLu-yzmdF7hjxnRAc0HHGD7rqiT5I-zd147p_0Ma0IYk8
YVU25vBdrIIjGmyhiPsW6arVCjLJWQzE6wndroOddY24SkHiq5RTSD8mVbRC3oqo
NBEixDrf0s1anTpuTbZbCl4GaU_gGw6eAGUA6IVz_UYwaMKy4kj5DZ_Q5pj5uHvC
WfTXPgw9Ygoa2zoy2jgknln8z9GEhD_hDkyL8HpRWZYOi5JTZGMk0QAQipcRRpjq
UOfb5foVRfdTaoffXl_0SghNSUGuLoCnomUwU5nna0m-huzf_TyoNLY8qhIhKFrx
dmbpTTH-kpJD_5tmS5csjQ",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MCVNN-GKONB-QPBWM-FCLVU-63J3X-IP3TY",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRANjT7QjEDnkXohes82DeWVowDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUE0N1AtSlVWMzItU0JKV1gtMjRKMlYtRjdaU0wtS0E3UVYw
...
7h5KWiGerNu6SIrdZAUSGWKItoCPqva_7ZXT3ps9710253mZckSOM4-HtA",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCVNN-GKONB-QPBWM-FCLVU-63J3X-IP3TY",
            "n": "
mAX712O--Bn-e4VUhP6I-wALI8BK1AaK-VsdJrtTNbSy3a4RxYGHRnVMXXlDNya7
mHEciD9w60C1UNYztxEFEm-q4hhjXscukrqakkW_AjRmYow0-rLX6xI9TLMW2jUN
xhwikyQ2oOYDpICkfQIEsKzM8bVYFyqpuN5Yud5OJJvmaYSsz4FCNTuqyH3wNnLz
7I0tK5hOpCDHQWPZJlLpICpDGLBe2ZGj9jvNf8VjKYJQXJVVuPI8dYtbXUM33nzj
gMOUtJKOPePXRLznRS1LBoioNUOZl8s1denpvLcvSTO1MNUfIFKnaGIAkxsbX-vb
4gDP3m98q5SoHVA8oC9rSw",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUE0N1AtSlVWMzItU0JKV1gt
MjRKMlYtRjdaU0wtS0E3UVYifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUE0N1At
SlVWMzItU0JKV1gtMjRKMlYtRjdaU0wtS0E3UVYiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
      "signature": "
i39gKgXzywNSqaax_FolfDF7d-3DndK6TfKeOceBP2dkwDFPnXi1yckRB6u53p--
PXmAcnNa-OarNmXZm00jCT0cHbSCzW5P56mNCFb1Q2GlzZ-TILF_tVTtuFCcDTE7
xk_TvbpQSk2L9wJImx4ZBHtTuIzrP9L3DvNdNT9_uJ4a5GAat5uONHYDRWQ0QEZi
AA3B3gpCxBMjXuZHQzC24ax9lVXUmk6hWaEyGRxDCqv1ZQiT_TsPeeDYH-11JuZ0
MkIBO6QCCYV6K8s_oal6vfyv7irEoLOeaG8Y5ChXK0wdjy3ewg0enlH4KY7SvvPA
JvATxZAhdnEMU6YT0KEhwQ"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MCFTE-4WT55-SOFKH-VMOPS-ZFW5Z-SPJCQ",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MCFTE-4WT55-SOFKH-VMOPS-ZFW5Z-SPJCQ",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCFTE-4WT55-SOFKH-VMOPS-ZFW5Z-SPJCQ",
          "n": "
y9RrmLNVYacth5oYMneLe3iGKMcxgIU8MKDhdnxYQLLqqMFqz0iRnTpblkvcN2fE
-bIMgsDLKUDgojBGxf2uJN7VYXvzdCQDQsPE_LDRAR3HGdqPnffPYu6KSvHphNNG
CBFQQBAkRpwHxhkTWg2rBth_ECiR1GcKbPBujSdb5SF3woeZNY7Ex_fO2QFkOOT_
FUU2UpOX072zdeUhBqtWwNhXtVkxNISE1qLFqncsjtKs5ExA_1v676G0uGlqLtRW
g-JNGPsz5HBeVvRfT2N51F31tn7eZ1DN7NkMkZzuWrKOW1ZYx_hjAV-sskjG4ugR
eI7TI2Otq6B5UXh4avfkNw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MBFHA-YA2A5-XW4VR-SUFZX-4BPZG-EOGRD",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBFHA-YA2A5-XW4VR-SUFZX-4BPZG-EOGRD",
          "n": "
s2LtasdtqcMVkxx6ut04Bi3iGazAPtMp9uj4ioLYcHeyphh89uLanh1REZ-6CMMj
m9-5MZFVePh89HfUls6qE8RB7N70JkU5KBKkCKKdPzV-05R4m0uR6EYvnfy9b0kn
db0I0IHdJF6BLZxP4XkZIVuNwcalj6B55y_b0_iW24J7A84hsnjg7dvemiFCEDao
zEOO-FzmatSt4rtPKYsbA4qbyKHIKRIsXVOjBwnV8P843sl96oUGB0vkaEVoDr4y
v1Zg0osw-qNOG7x-OVXMh7laA-rS5o0-ehay0xe0fYZskYrI1EPH-3sqPERL0c6B
65EmA4ng_q-dXU52QrTP7Q",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MB5IA-O5A7G-2VS6R-5XUDD-PNF4Q-6T4BP",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MB5IA-O5A7G-2VS6R-5XUDD-PNF4Q-6T4BP",
          "n": "
p2L-Adk2N-v-tpswprLPH9cRBozGLroZq3YxWkkvBi5IP5kmaU1DnPRSkIykqYTY
-CyY7bGKP9oUG0xJ89s6678rx4KM0IE0qNT-27J_90ampDafL1SFVY9XjvwWWi2G
89_RqIr9NAZt8DZh_UBg64_Crrr0JxZNNrdPjayTLW05ScdpOMguZmMdZq9HrYQV
g8Sft-6XrdxhMscq_0U_8G7-Jri3i3FOlsiFLtC7mT5DqQqUjNlL-0hQfK72zo_s
CdSlvLhxPXFHIjSIMoDUP7S7rJSbiY4ePqjN99A99VbAlkLTkRHvp05F10MwiMrF
GtI7SEC8z-rAlDwI_m7PRw",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MCFTE-4WT55-SOFKH-VMOPS-ZFW5Z-SPJCQ",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNGVEUt
NFdUNTUtU09GS0gtVk1PUFMtWkZXNVotU1BKQ1EiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
JWe50RE6mSFToX_v0xrZ39biv7XZkByZNd1rkZTLOk5dceuFXIZ_BBmI-z5ZJFYQ
r8-AaDmFpdS3VFF81xAhj6kojyxSMyvzmC9WsVph970j8KggO8uC7Am2xVTkkK94
oxQC-O8bqKvwZgsG5t0G1K26sXnGTm9LUsN-3rVT3k_4s1t3Gud7eB7HRTi5PmST
_BzQhDDRbFkhI6CqhrYxR8m1_YyCgX3bK1XQqc-AIJDG-KwSLpXLXm4idL-Ui3zy
lyLrYsFgjm4DI_PbKP6bUQijfRJEEwcs7CvyPcBaJABgECpQ5Y3VJ4BsB4k9UXZz
QwfZnOMKUfehObPhWAzKAA"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
    "SignedMasterProfile": {
      "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUE0N1AtSlVWMzItU0JKV1gt
MjRKMlYtRjdaU0wtS0E3UVYifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUE0N1At
SlVWMzItU0JKV1gtMjRKMlYtRjdaU0wtS0E3UVYiLAogICAgIk1hc3RlclNpZ25h
...
OiAiCkFRQUIifX19XX19",
        "signature": "
i39gKgXzywNSqaax_FolfDF7d-3DndK6TfKeOceBP2dkwDFPnXi1yckRB6u53p--
PXmAcnNa-OarNmXZm00jCT0cHbSCzW5P56mNCFb1Q2GlzZ-TILF_tVTtuFCcDTE7
xk_TvbpQSk2L9wJImx4ZBHtTuIzrP9L3DvNdNT9_uJ4a5GAat5uONHYDRWQ0QEZi
AA3B3gpCxBMjXuZHQzC24ax9lVXUmk6hWaEyGRxDCqv1ZQiT_TsPeeDYH-11JuZ0
MkIBO6QCCYV6K8s_oal6vfyv7irEoLOeaG8Y5ChXK0wdjy3ewg0enlH4KY7SvvPA
JvATxZAhdnEMU6YT0KEhwQ"}},
    "Devices": [{
        "Identifier": "MCFTE-4WT55-SOFKH-VMOPS-ZFW5Z-SPJCQ",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUNGVEUt
NFdUNTUtU09GS0gtVk1PUFMtWkZXNVotU1BKQ1EiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
JWe50RE6mSFToX_v0xrZ39biv7XZkByZNd1rkZTLOk5dceuFXIZ_BBmI-z5ZJFYQ
r8-AaDmFpdS3VFF81xAhj6kojyxSMyvzmC9WsVph970j8KggO8uC7Am2xVTkkK94
oxQC-O8bqKvwZgsG5t0G1K26sXnGTm9LUsN-3rVT3k_4s1t3Gud7eB7HRTi5PmST
_BzQhDDRbFkhI6CqhrYxR8m1_YyCgX3bK1XQqc-AIJDG-KwSLpXLXm4idL-Ui3zy
lyLrYsFgjm4DI_PbKP6bUQijfRJEEwcs7CvyPcBaJABgECpQ5Y3VJ4BsB4k9UXZz
QwfZnOMKUfehObPhWAzKAA"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTQ3
UC1KVVYzMi1TQkpXWC0yNEoyVi1GN1pTTC1LQTdRViIsCiAgICAiU2lnbmVkTWFz
...
T01LVWZlaE9iUGhXQXpLQUEifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
      "signature": "
XK-I_84BmsDaUHjZ4SnnX63j_V9RxEj0dlDM6F4Sri8ail6YztwvJEoLVLVQwkeg
rZXaAt1H9gB6sr68I73Tv5WuJblL-dXaTBQy8i0jVc7mTx40TSky1HIgWosJ_BlL
c7vbC9KWNqVokAKHoYYTNskMW-M8vHFqopxpI328T0ijsR5kYNwaNo3WJ1JB-jiT
U15_-MVgczgImYxeIfZSUyNITrXHv4iiK0sNXEBQaWC8QJcPut6usL1ntZBvVqOR
RleFha2c1XzQbvMksiMQU0hzyF_IGt9cdAnfzfysVYqw98WNg23WciS0iZnruoFn
Fmcvq4eHCWhfEubTaiSH0g"}}}
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
        "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTQ3
UC1KVVYzMi1TQkpXWC0yNEoyVi1GN1pTTC1LQTdRViIsCiAgICAiU2lnbmVkTWFz
...
T01LVWZlaE9iUGhXQXpLQUEifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
          "signature": "
XK-I_84BmsDaUHjZ4SnnX63j_V9RxEj0dlDM6F4Sri8ail6YztwvJEoLVLVQwkeg
rZXaAt1H9gB6sr68I73Tv5WuJblL-dXaTBQy8i0jVc7mTx40TSky1HIgWosJ_BlL
c7vbC9KWNqVokAKHoYYTNskMW-M8vHFqopxpI328T0ijsR5kYNwaNo3WJ1JB-jiT
U15_-MVgczgImYxeIfZSUyNITrXHv4iiK0sNXEBQaWC8QJcPut6usL1ntZBvVqOR
RleFha2c1XzQbvMksiMQU0hzyF_IGt9cdAnfzfysVYqw98WNg23WciS0iZnruoFn
Fmcvq4eHCWhfEubTaiSH0g"}}}}}
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
    "Identifier": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
          "n": "
03-RQTIaLcToU1J9vkVGsSwfDdjtg2VPxrBdwm3senuS0F_gxvBw7qOx3jWidiSi
sM1qkBIIH4s3T6tREzNA8unyM7KbO_2NSx7CIJIqKifYg1yZObE0Xnpt0OG8QGWm
erc_fOEztrXoHyZt8xiLl8Cw7qKHlKcJTq444JZFqn85ys5ggg3_4uJDcTyfRV6-
P7H45qJVJBdAXkBAWRbI83vJRMPI0y_C7fhOwAwjVWseDib63C-3v95zI5FmYLnM
bu6OH5iOy8TsZSZUwkQ-4PXPcE24B2IM1wJnhypC8Q90ey_Ct4tOzG4kLjNHvUe9
0kdisJqpAdJFGhdLhW6Yxw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCHJS-M7B6W-NSNCV-7W4VE-I5KFF-TDPA4",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCHJS-M7B6W-NSNCV-7W4VE-I5KFF-TDPA4",
          "n": "
wYOlei5IfbHGkMs7z1bWJpYaxxV9hdr2pmQqY8jcYlw4pvQ5-kmLtrKpMo8hxrio
cXnSS2ymYR6aQzSkgtMfn4dLLtoWTgq0zpFnV6_dNl_Ubb1yPaqBpw6XxM7yACHL
DJV6cZkcQOWUwVKaaBmZpNrXAPpFVl50sk7CKfD9q809zs9VsNIQjIr0IxIwNJ6G
FiznmdZIvSr9Ps9qVBh1v0017YU544sZ-RRN8n3E7pjgQAKHbTmL8L0eLT_U520O
qJBdJAKpzgIJn-6LqZJxrd89VDK70DLQYbeYZYe_RY3WZVf4djGjUXqV17mD0Ipg
qPeW4YzsnMJgBLtBwMf3aw",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MCRZ4-FMFCN-YVZIS-FUH7G-SXZA3-ZNMA4",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCRZ4-FMFCN-YVZIS-FUH7G-SXZA3-ZNMA4",
          "n": "
xxeqbooXycaBZQzOtiDcax6Gmja2lSDGksQ1S1jF6ZiSzogqMbzz8pAt26T998Ha
6StOgMOgBmVyejDe3yVlvLc4S862pfgZxye2W75mrv0-HWvD5T3uv-9-_1TTG5yq
XgyDPOSPIKdxpRtjScUyHJWg2AjiPK7XrxiVimJOSCl51V0RYHnYc3fDvORP5bbc
FXGkFGFdhGmczfQK_AoylE56jRbq9OwrHURAJOBdHyMXZT8NPeD6QDDsfmpZYmuK
3v3Jv6PiVkr0Eb1Y-Ha08aQ0A2WAgD9j4KZQa7tzAQbHb3BZprgsdSapQ8QrdrlH
8p4I8zdbQhK2PlrE59RjLQ",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQM0gtSDVGSVItV0tQUlct
VkFUS0ktRlVZWVktWFVUSk4ifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURQM0gt
SDVGSVItV0tQUlctVkFUS0ktRlVZWVktWFVUSk4iLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
GchB0Y3XMBRfS_0XO6d2uUQ3Wu5t4MM7KMfUPzA6cy3UBaNzs9u90vrthNMo8vRj
CNPta9sa7zjiu9v2XWgjtJYN4ZipbZ6yL0TJbu_6yxsytQyzWFz_JNx37iLJmj7s
Y-ei8Gak4TVOSIy42jHjpO_d8yYIVSaJsKpJ4trxRDM7eNUgA15Xvd7p9SjKTqdu
sydSzlu-8mUzS2YPKhwhgl7mxyG6G8qmm4Arfgf1ehH0xXVVMKtBNXD66Qsh5m6d
0Mnm7Pb1hX46-oCKL9FP4Fo7O2HdEkmm5n8K20UXcabqgjNwEdKV51pC6-kRIKd2
pA9ZHjWUO7YYfw6JWcAO4g"}}}
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
          "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTQ3
UC1KVVYzMi1TQkpXWC0yNEoyVi1GN1pTTC1LQTdRViIsCiAgICAiU2lnbmVkTWFz
...
T01LVWZlaE9iUGhXQXpLQUEifX1dLAogICAgIkFwcGxpY2F0aW9ucyI6IFtdfX0",
            "signature": "
XK-I_84BmsDaUHjZ4SnnX63j_V9RxEj0dlDM6F4Sri8ail6YztwvJEoLVLVQwkeg
rZXaAt1H9gB6sr68I73Tv5WuJblL-dXaTBQy8i0jVc7mTx40TSky1HIgWosJ_BlL
c7vbC9KWNqVokAKHoYYTNskMW-M8vHFqopxpI328T0ijsR5kYNwaNo3WJ1JB-jiT
U15_-MVgczgImYxeIfZSUyNITrXHv4iiK0sNXEBQaWC8QJcPut6usL1ntZBvVqOR
RleFha2c1XzQbvMksiMQU0hzyF_IGt9cdAnfzfysVYqw98WNg23WciS0iZnruoFn
Fmcvq4eHCWhfEubTaiSH0g"}}}]}}
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
      "Identifier": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQM0gtSDVGSVItV0tQUlct
VkFUS0ktRlVZWVktWFVUSk4ifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTURQM0gt
...
NGcifX19fQ",
        "signature": "
PdvUNvUEf8FN3KF3K37QKMmc40fM_Vqj9mZmRKJC1FSD4F6_PIQ_JDZk5sRI1OO3
ef_ObaF4TVxAR4ZpO89ee9t6_2IRSdi5cLB_tCY45PVC-0HCn1H86ITXCAYjZZpe
9NAbARGrxR5PghzHtxeVlurJhe9MzUl3qVgRVORa7OMH_ktB8-7N-9jqa9xSFX9I
EY6dY4tCkNbs2vYi_hZw6Gttkjj7-FKwIsjDy2q9yk-PGp41D_6sKM_c35e65bQI
JUUqkkXCfiqDH4gWTW1FgmGRBpuppV56gOnMcQkgJzTy-7BYCmgv4WNKO6RHFOaB
FtimRQM1HObyXWHLVr7fpQ"}},
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
        "Identifier": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURQM0gtSDVGSVItV0tQUlct
VkFUS0ktRlVZWVktWFVUSk4ifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTURQM0gt
...
NGcifX19fQ",
          "signature": "
PdvUNvUEf8FN3KF3K37QKMmc40fM_Vqj9mZmRKJC1FSD4F6_PIQ_JDZk5sRI1OO3
ef_ObaF4TVxAR4ZpO89ee9t6_2IRSdi5cLB_tCY45PVC-0HCn1H86ITXCAYjZZpe
9NAbARGrxR5PghzHtxeVlurJhe9MzUl3qVgRVORa7OMH_ktB8-7N-9jqa9xSFX9I
EY6dY4tCkNbs2vYi_hZw6Gttkjj7-FKwIsjDy2q9yk-PGp41D_6sKM_c35e65bQI
JUUqkkXCfiqDH4gWTW1FgmGRBpuppV56gOnMcQkgJzTy-7BYCmgv4WNKO6RHFOaB
FtimRQM1HObyXWHLVr7fpQ"}}]}}
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
        "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTQ3
UC1KVVYzMi1TQkpXWC0yNEoyVi1GN1pTTC1LQTdRViIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
UwOHLDegjApoiKY7MxTd1ZtJXQIOzJ0qLFmW6d80L6U8XJbccGUqZzTxbf0v4nnZ
Xpm65YK07NsXw1Dus14CTe2iIygPz-OSIweFG5BxLdaNMC70qrWF0nVbFpJLdPSm
h_l0pZ4-yBsa9MbNTOMydbSaXoCHz-57i3B-nyelpJ9WDO2WT-GUX94h_Hn08OPa
auRRKb697VBnX9HHx6it0e8LLPZLP2zAPUxoPxeAbpTJK4vcq8C9qoFnXQKsd4Us
HCcnnRQ3OdwBGhWsC08ftB0uwLBCoHiDNq591iJjcjQMmnGaCLvVdwMQCDgrBcz4
1K263gM2fXhFsw_Je4Glnw"}}}}}
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
      "Identifier": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTURQM0gtSDVGSVItV0tQUlctVkFUS0ktRlVZWVktWFVU
...
dGVkIn19",
        "signature": "
JfPfo89TsGTIXEOiB8GzHuybbnzgx85l-dQh0hnNAhFEHcsbZ5oWfkNEU8C3vXjy
yY7M5ZbYBNf7Wpb8pnGYd7smQ6Lga8DNCBUyGWygU6X5Cyuk3C4zGwFulbTu8Fg-
nyJU8deVMwi9YQ7lQ3fvzcNQkcdCWfRHreHf9aEsoRpRPA3JHwFlZFjR4OiV8thM
PCVJ08Z2UULcJw_pnwlDXSRYtZ6m80lxZDUqFdZjWttG8ocAXz0HdaUB0LuaWNrN
054LBpdpEurtwRPbsx_qH09agQEDRKHM0-um-6yoXS9J5A4N8KbjT2QhwzEtQFha
iTLtRod0Oey1fHo3HsDzxQ"}},
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
    "DeviceID": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MDP3H-H5FIR-WKPRW-VATKI-FUYYY-XUTJN",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTURQM0gtSDVGSVItV0tQUlctVkFUS0ktRlVZWVktWFVU
...
dGVkIn19",
        "signature": "
JfPfo89TsGTIXEOiB8GzHuybbnzgx85l-dQh0hnNAhFEHcsbZ5oWfkNEU8C3vXjy
yY7M5ZbYBNf7Wpb8pnGYd7smQ6Lga8DNCBUyGWygU6X5Cyuk3C4zGwFulbTu8Fg-
nyJU8deVMwi9YQ7lQ3fvzcNQkcdCWfRHreHf9aEsoRpRPA3JHwFlZFjR4OiV8thM
PCVJ08Z2UULcJw_pnwlDXSRYtZ6m80lxZDUqFdZjWttG8ocAXz0HdaUB0LuaWNrN
054LBpdpEurtwRPbsx_qH09agQEDRKHM0-um-6yoXS9J5A4N8KbjT2QhwzEtQFha
iTLtRod0Oey1fHo3HsDzxQ"}}}}
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
    "Identifier": "MCALO-N2EJW-DO2MB-SFFVI-OARRD-QCPU3-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
kQVPWWcA7VHyBrp9MZ-ygQ",
      "ciphertext": "
pB_nByxbJVLPk4O7YRSlLaL9VKvw6IVKWC6Aor-SHyWVGJsSgvordw5BbNV9Kjfk",
      "recipients": [{
          "Header": {
            "kid": "MB5IA-O5A7G-2VS6R-5XUDD-PNF4Q-6T4BP"},
          "encrypted_key": "
f9zAt0TtbFdM8JItDiSppSF8gfOEQhfVZu7SU7LVX4fOSd7RvGMi-QULPWK6i0Qz
FesVXVTQ0p14gWWOkaTb4lrYcolwKMvbZlt8raB8bWmM6VNiHpfve4dIL7Hi_9Iy
3nxV3shGJoD5fwu4LZaUrBHbBymVs_lu-Mc-D75_iXrT6wSbi7wunoQSlgYoBa4b
y7q7SJ80ES9m6gXktgueFju_UKYpV5yi8yPZL7Eh3sTO-QOAtDjM5UPGydQvGcNE
nZ3O0O3HcUEgifqK8Z1VrVa_gKzxdgWy0tL1psIMPL4_Bdtwwg6vTZkffB3f93Lj
719zijUVrAU5ktivXecuxw"},
        {
          "Header": {
            "kid": "MCRZ4-FMFCN-YVZIS-FUH7G-SXZA3-ZNMA4"},
          "encrypted_key": "
wHgRcS_8ZgC10hIpkNV9uSuw5MSjT0ahu2f373m7XNJ0y6_q74Y2e2EpZWbPY1r_
a87Q4EnufzeK2k9LVmTti02tqm4fw7DUuHG80gZEzlQuYSziEdx7P11Dodtm3dZa
gPQYpcTDW8uFNZWki4jiIr6LRirMUlD58mOLwHA3CdZ_Dr8DSvslM1laBoDB_bKR
PbHZy8UWYgmBeURnYFrM3MvjRzvu6ua5LU5b19JCfxpdrT7-meQt-uqWgmNLDMlW
3p0bMwXnPXa99f76hQkLJKmL4eTwLw0XEUpFEEarp66Ir_IIlSpXzMiYSH7zi9CE
Qg2fCm_THC2mmQog9XPpNw"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MCALO-N2EJW-DO2MB-SFFVI-OARRD-QCPU3-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQ0FM
Ty1OMkVKVy1ETzJNQi1TRkZWSS1PQVJSRC1RQ1BVMy1BIiwKICAgICJFbmNyeXB0
...
WHpNaVlTSDd6aTlDRQpRZzJmQ21fVEhDMm1tUW9nOVhQcE53In1dfX19",
          "signature": "
m15kbcauS7Kb9FV2m85CFotZS58cF-HrQVvWC5R_Pr5y8my3xOTtNKLUM_du5l7E
9W_dB4aq-66wpY8B7k4DOcYsfUrYABJmCV92i_KNDbgrAegMdqKF06qCelUK5Mcn
gxIU9rxRbmTcd83kbZC2mITHu3p_KvgIwGyRhfWLvo4aJpJtz8O8m1fkWb48tW9c
NJlSg4JGadiCBZrHiBvQeqqNQq_JQH2Zj3U5WNi8TR0tnMz8NJi8ta8iGL5JcE7c
6MhvD16GWAn2rTbXphw1UVppCOpP6WHKcOgCyWSsGS4jxMqtNOz2FB_4JCwjJQ2u
CjRCPXlDABXTQhyR2LfrtA"}}}}}
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
        "Identifier": "MA47P-JUV32-SBJWX-24J2V-F7ZSL-KA7QV",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUNGVEUtNFdUNTUtU09GS0gt
Vk1PUFMtWkZXNVotU1BKQ1EifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQTQ3
UC1KVVYzMi1TQkpXWC0yNEoyVi1GN1pTTC1LQTdRViIsCiAgICAiU2lnbmVkTWFz
...
XX19",
          "signature": "
UwOHLDegjApoiKY7MxTd1ZtJXQIOzJ0qLFmW6d80L6U8XJbccGUqZzTxbf0v4nnZ
Xpm65YK07NsXw1Dus14CTe2iIygPz-OSIweFG5BxLdaNMC70qrWF0nVbFpJLdPSm
h_l0pZ4-yBsa9MbNTOMydbSaXoCHz-57i3B-nyelpJ9WDO2WT-GUX94h_Hn08OPa
auRRKb697VBnX9HHx6it0e8LLPZLP2zAPUxoPxeAbpTJK4vcq8C9qoFnXQKsd4Us
HCcnnRQ3OdwBGhWsC08ftB0uwLBCoHiDNq591iJjcjQMmnGaCLvVdwMQCDgrBcz4
1K263gM2fXhFsw_Je4Glnw"}}}}}
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
        "Identifier": "MDHRA-JZWUG-BBUWB-XTPNC-JGG6B-5GUTZ",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
zxhdGJqZf23FhlR7gEg6tw",
          "ciphertext": "
8cD4Ne_slUziDf12V4TqY3x1Cy5-uq5gwODo8ycZPqZWcYAlqhnvzwzJ4X7CIPi1
W5hVWTH6LcC0_iQf0yHH26mOpD5Es_Cy7I5KMXYymhA-Ii3c9qIx4uNSO61tEl4k
...
F2YjFucSTdNkZW7YqxlUBawbxmT0d_lAfoKETEX0j7zk3gDqLf6ivNOVd22N3L9_"}}}}}
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
    "Identifier": "MDHRA-JZWUG-BBUWB-XTPNC-JGG6B-5GUTZ",
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
          "Identifier": "MDHRA-JZWUG-BBUWB-XTPNC-JGG6B-5GUTZ",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
zxhdGJqZf23FhlR7gEg6tw",
            "ciphertext": "
8cD4Ne_slUziDf12V4TqY3x1Cy5-uq5gwODo8ycZPqZWcYAlqhnvzwzJ4X7CIPi1
W5hVWTH6LcC0_iQf0yHH26mOpD5Es_Cy7I5KMXYymhA-Ii3c9qIx4uNSO61tEl4k
...
F2YjFucSTdNkZW7YqxlUBawbxmT0d_lAfoKETEX0j7zk3gDqLf6ivNOVd22N3L9_"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


