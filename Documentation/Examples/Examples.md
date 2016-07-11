
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
Date: Sun 10 Jul 2016 02:51:39
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
    "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
    "MasterSignatureKey": {
      "UDF": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
      "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQNuN8MYSceklaANAOZ8AVDDANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQU1PTy1USTNCVy00VFBTTi1aRVFVMy03Q0hNWC1UQlBRUjAe
...
RIroBK7s_NlwLAh0QfPhnS8LLXNjuCqb-dOMYRZZK8vW0xFUOZnn1Efg",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
          "n": "
qKVFwwlNfhRg83uEcGPIIszKWbUKf7c2JBvasWRLeUgRF9MIyJlY91HFSp_XI44v
xA7O60dLx3LNLihaej3GGtk2z69ElVagCiltpKZFQe8wyQGxA77VerikavcYvL8G
nJC8pI4zdcb1cZsMErlTqiYK83PEhx3Nv3JQ-5szcxt7onCVk32rBFEp9Kz6BNZu
aisSaGA9tM04l9LiU07ML8xIH0RW4nrPHlEA_UimhnSFRaPeNNz2ZgDT1l6q4XIR
s_94GnSx_s6BtFo2CdH-1cSieykNHwqF_IzoqAWgJ5jEwwAABSC4ESgNHHKQmXck
xmLHIBVZMYeF7kYV5Hqkuw",
          "e": "
AQAB"}}},
    "MasterEscrowKeys": [{
        "UDF": "MATW6-6SF7O-EQUUH-7WG6G-SIPR2-NPQOD",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAMXI6UbePG8xBJk75BtoUOgwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUFNT08tVEkzQlctNFRQU04tWkVRVTMtN0NITVgtVEJQUVIw
...
gEVejITPY1juvbL8b7QscmCA3L6B2_49b26W21lKHpj7D_aeXFTFxadHGw",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MATW6-6SF7O-EQUUH-7WG6G-SIPR2-NPQOD",
            "n": "
2Pgs3YmamAukchrZ7YO1IFFxuBwdPT_DnNrSsdhhvULpeON55T7QR8_s3U1ZSVs7
3r-r21B3oXHVXWpcmCtOswYy4zKeHkXrfRUdhOKoOuXeP7Utc7dqPRAi8KDkqnFf
9A6eB4ffAWRtYDPeDO1QJpW9zMs4oYpIUGJpQ2tt0pZN54CEot1ZLXoKipe7eVaP
7MwtP_-J1lg4Kk-oNOLUOmac8lEwdP8cHJ4pFK1sd6wp_orHrcSnzSjvOkj565Eo
h_WWHQJJ1trmaa3zYCsK7mC8f6jfoDU3yVtxO9caNGzznfjlQDaW2mDHa--VWYt9
lGrM9sYt-WLHwtLbwp37XQ",
            "e": "
AQAB"}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MBFYU-BAIW5-AYTOE-OWM34-3W5A7-OVJ4Q",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAP55OrI-sbVC6NVL9M1cyacwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUFNT08tVEkzQlctNFRQU04tWkVRVTMtN0NITVgtVEJQUVIw
...
_LZqwN86Zp_VqJdyyIRvATzjCWFJAXaOjFVjZhOQos_CxnVP9Fwf3TLX1w",
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBFYU-BAIW5-AYTOE-OWM34-3W5A7-OVJ4Q",
            "n": "
rkzVPU-JqPdh2VlcEJjmORpJLxmxHd7wEpxADow4fWQzKSL-WzG1b_cBRMa6CTVW
2GAnQsfsF7cfnto17_EYgVEe7gdli35HQIsEi-qf2r-Fy8VsVnC1hqTlW7G43JoX
jdeJ2wUyWGCpsYehKKnZDsUCB7pIVEiDAIFcuL3DWr4teFfEWVyrCGmG0LzoFoeK
bky5x7TjPxqbT7E_NpqBiLj6Zb95yV9shjwrPDx84bzMYs-2h9ctcX0h5h8tzdOh
0NeluhIBky_4pZEYDfJTYyPCM_TZTQ6qKRuTcdCpVtT96DNlNx96iZzYLhkqw7Pk
jNsxiiDbeGj9LEr3dwhhKw",
            "e": "
AQAB"}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFNT08tVEkzQlctNFRQU04t
WkVRVTMtN0NITVgtVEJQUVIifQ",
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFNT08t
VEkzQlctNFRQU04tWkVRVTMtN0NITVgtVEJQUVIiLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ",
      "signature": "
BCYOKI33C8QdEBfO53x4zd54D23plIY7hAWOEJUR6WnTiRXTBiFRI1M9RNDz68Ke
3hLy5JEGGCSJUfp0gc4-KJnos-eeUbuE6w2WVXxrX8tHJ0NMY1bTj49_dHTF5q-V
mfR4YuRM4HfN97e-Hd4vzS2OHRX7UUkmtMwSn_2R5nFwCqkjWfI9mpyURx7mtpBs
L3Qs0o1LJ8exjFODsazkhS4uWNV4JmX6o8-cE_T2tGaT3gxp4dqpZta_MqzKN4td
QeC7Fx0VC1P7LkasxxyvPhXmGOqa57r8I6XqsCOekpvhO27lz6teASaDDYOZvglV
5nspl_QrZKdvWJHw4Su6Gw"}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MDE6L-FQ6ZE-TLNOO-5MN2H-6VTHF-PAEZK",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MDE6L-FQ6ZE-TLNOO-5MN2H-6VTHF-PAEZK",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDE6L-FQ6ZE-TLNOO-5MN2H-6VTHF-PAEZK",
          "n": "
lmQpogZoVBMaw4OHcXUWMurJ8CSIjKpd_ggasbDnvjz9jyDq4OYzStb6Hc4herMF
gLjTxok2jnoxh-5WmJyHooeF1KQWHQvxaIC0Qk6SSAbQjH-891pdb8aUSZ31fIVj
pciJJCjAhg3gn_Sj1immcC76dRFoXIjP8FQD7-tFdgdCbXIHsCjC7HTTOE2Mfm8t
CIiFQf4jOzIKyjBcjhFg00mOR7sZMNYO5VeKeuX9tG2xbQhXnfLbBhG25QNdZKnQ
ihvhLaGxSWNRyhE30yAIibw8L6g40Y5XouaglIn-oWLPhzKzRpGKpCIQejiroyke
LklQvMDTWi6ssIUGO5LrFw",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MAC3D-NFKEY-EBWIA-6SG6G-FEVJW-YKSM3",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAC3D-NFKEY-EBWIA-6SG6G-FEVJW-YKSM3",
          "n": "
j9MpDv4JhYu6klXNaYkSmiKMpnx5srw2KC21KSVR6P3z_0w4-cSxROh0YtuAnL8N
FYrDiKNr-OQR6jaz5Rp_LNtDbN4b9rKINAJFBeFiTjKzj1Sk913Qnc_x8nIBOt-a
BqE69aCJT_73QpL8KmqOtf2LRVuomKuvCMmIOii73WTfoVu5V9PonLoTfbgp8JBK
Mcf5ECz5ZjuN1ND6iVFq03cOZerRrllgvDLH_Z9rCuNmJY7n8pmHctjpk9N14Pey
UasmKpbbHDZ_QW8TMIhXwXJTfHg7PmRw8PL8FABQLZg5ea6xGFJ-H_xX10MCL2AX
qY_gYCLYdgXgWvgqQa3yGQ",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MCEWX-F352S-NDFEU-3F2FN-T7EGP-ZJLQW",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCEWX-F352S-NDFEU-3F2FN-T7EGP-ZJLQW",
          "n": "
jPVrQEvP44dsaxxGYLRc7wL1KjnnT7Wq-cM20fbNhy78ctqWw4HmTwUPmONo7YlE
8eCgeXfXW9y81UnTBxGHjY3AV3eH8TlWtXDlYEOfywvkthc8G9j3mTboDVN8zTtO
rVZoyS-PEg4mZe96P9RpHn6jdyh4vmWF_XHRIlN-EmDYeeuKXzLragxKxkv8sYBS
nwr8I7JHkwdq18mToLmOh2EWORHDM_xEbshsegmgYbJkhkjRdTnHLT8YMVuZlXrj
vH7z3_KYHSP_LCiLAImaMNbkYbQXpCebsEHeRyYBOWmmR3NGVj4MpFt1Cx0DM_oS
2G6j_MKWmlRJof7VOgELlQ",
          "e": "
AQAB"}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MDE6L-FQ6ZE-TLNOO-5MN2H-6VTHF-PAEZK",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURFNkwt
RlE2WkUtVExOT08tNU1OMkgtNlZUSEYtUEFFWksiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
      "signature": "
XSjBLnZ2kfWnM0HSnJ345xexIdF0iEyFHKTuNZ0XNHGttq_Ky2Jg6WFvbVN2hLHA
n1mRn7t1nd4Nf7MdJnl73h5P06N9NNn8yINoA78c2uHdiBG45BA7bADReRLl3Flb
mzDtpnjvxeykjJ-tUMqIyKNsBCOX5wx-bdXJpkljWcoyKpM4V4K4yc2ffkSsHwaF
0kvCxi5bRvJE-CIsXBhtN6KWtLT2CkDu0quz8Bn_pklakt5Naeue_W8in40FDvhP
Id9Pc69RdEB6Q4hwgGFQa25WzLAd0Kr8wc1_M3aJwolldlbf7fl3e82zxJ5h2udD
kVNrkuJ7qvLF4OdiTUU8Fg"}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
    "SignedMasterProfile": {
      "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFNT08tVEkzQlctNFRQU04t
WkVRVTMtN0NITVgtVEJQUVIifQ",
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFNT08t
VEkzQlctNFRQU04tWkVRVTMtN0NITVgtVEJQUVIiLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ",
        "signature": "
BCYOKI33C8QdEBfO53x4zd54D23plIY7hAWOEJUR6WnTiRXTBiFRI1M9RNDz68Ke
3hLy5JEGGCSJUfp0gc4-KJnos-eeUbuE6w2WVXxrX8tHJ0NMY1bTj49_dHTF5q-V
mfR4YuRM4HfN97e-Hd4vzS2OHRX7UUkmtMwSn_2R5nFwCqkjWfI9mpyURx7mtpBs
L3Qs0o1LJ8exjFODsazkhS4uWNV4JmX6o8-cE_T2tGaT3gxp4dqpZta_MqzKN4td
QeC7Fx0VC1P7LkasxxyvPhXmGOqa57r8I6XqsCOekpvhO27lz6teASaDDYOZvglV
5nspl_QrZKdvWJHw4Su6Gw"}},
    "Devices": [{
        "Identifier": "MDE6L-FQ6ZE-TLNOO-5MN2H-6VTHF-PAEZK",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURFNkwt
RlE2WkUtVExOT08tNU1OMkgtNlZUSEYtUEFFWksiLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ",
          "signature": "
XSjBLnZ2kfWnM0HSnJ345xexIdF0iEyFHKTuNZ0XNHGttq_Ky2Jg6WFvbVN2hLHA
n1mRn7t1nd4Nf7MdJnl73h5P06N9NNn8yINoA78c2uHdiBG45BA7bADReRLl3Flb
mzDtpnjvxeykjJ-tUMqIyKNsBCOX5wx-bdXJpkljWcoyKpM4V4K4yc2ffkSsHwaF
0kvCxi5bRvJE-CIsXBhtN6KWtLT2CkDu0quz8Bn_pklakt5Naeue_W8in40FDvhP
Id9Pc69RdEB6Q4hwgGFQa25WzLAd0Kr8wc1_M3aJwolldlbf7fl3e82zxJ5h2udD
kVNrkuJ7qvLF4OdiTUU8Fg"}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU1P
Ty1USTNCVy00VFBTTi1aRVFVMy03Q0hNWC1UQlBRUiIsCiAgICAiU2lnbmVkTWFz
...
N3F2TEY0T2RpVFVVOEZnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
      "signature": "
lZcyQpLShx7ir9UTqpoAuPmc2hsvMh4Bf2KAPq2J4piry5v00XWo5oH9CGEMg9Q2
ma1YZljXOPeXpR5Lxg73XHrxILejQUxMo1VvRhXeBZPG4Jx_94hcWgf1OB2qU79J
JlRrTr70LcNhvtsHnC21GZLD-r2elh8pCUkEtjkCngQRwdIeaSUYOBV3q1DGCQDb
3rvLGfz7QixLXX_PMoQeDfvCHR6GMUy-S2jfs7wO0EsdpcpkjleRrN88foSJI8L5
E4H8YFEnpg_kedcmCUqthC-MkQSZpu4PNqWGKNemh2mev0bWFo_QoMQ6xG9ZMqUi
aK6SHEUr5ITiqO_4luSsvw"}}}
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
        "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU1P
Ty1USTNCVy00VFBTTi1aRVFVMy03Q0hNWC1UQlBRUiIsCiAgICAiU2lnbmVkTWFz
...
N3F2TEY0T2RpVFVVOEZnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
          "signature": "
lZcyQpLShx7ir9UTqpoAuPmc2hsvMh4Bf2KAPq2J4piry5v00XWo5oH9CGEMg9Q2
ma1YZljXOPeXpR5Lxg73XHrxILejQUxMo1VvRhXeBZPG4Jx_94hcWgf1OB2qU79J
JlRrTr70LcNhvtsHnC21GZLD-r2elh8pCUkEtjkCngQRwdIeaSUYOBV3q1DGCQDb
3rvLGfz7QixLXX_PMoQeDfvCHR6GMUy-S2jfs7wO0EsdpcpkjleRrN88foSJI8L5
E4H8YFEnpg_kedcmCUqthC-MkQSZpu4PNqWGKNemh2mev0bWFo_QoMQ6xG9ZMqUi
aK6SHEUr5ITiqO_4luSsvw"}}}}}
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
    "Identifier": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
          "n": "
4WNSVaLBSaWI35RUjzdTOFvnALoN6K-sd29zrxnn8WpAA5U_bTfnjQk3ao4_lZ50
EqyGJm-NN-k6LgNeSA-bAxgVyaXEuZkxCf-T_yxy8kVbnkGRD9mGJYjjyuqnuRup
6FQMOUVoYcqxs9bHo3AejKiM_kPXiQxLpIAm1sOjQ0DcW6iKiIDJ5RvOhCOZJlLq
iDe1KBOVPiAbdmjkOiemx1ODePLY5UilnTHp6l6wgzcWHb-jtj1Cxae9I3rBexWv
AEoHC66RAR2q-nfHaiRFNKyZIrLAfAxnv3Yo8w6boABGL1XwNr3KWFWlWZ74Njnt
hgKIE5qzaWgSAV_G4nSh4Q",
          "e": "
AQAB"}}},
    "DeviceAuthenticationKey": {
      "UDF": "MD4TQ-K54GG-C6VZD-2J727-7CWUX-XES6I",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MD4TQ-K54GG-C6VZD-2J727-7CWUX-XES6I",
          "n": "
0_bt8Ha4VTfUJ-yf99GX2czFQcbDSaav1b_aQR6oiFDSppdEKkM573Q4ObcYLmBq
sjrby9yNpAhpJ-NYJXbeP14VipV_vwVtc0m48T_feIj-xEitCHy8d82ymMC0Xr9U
VnySWB57X1KJP0_FNJgzBA8GcmPJY0SSg2cxzxZzWxNmtP2HeD5g5Q3dcP55_JsC
O5Fr0PIRsQklNrmJ_AO9-EnULHf3JI8sNO2VhpIvISHeBCtpqNu4RIp6w6jt-Trw
TRZvpajdjVYVFRUNiink7aoRzHfn4IDW90OY8vXYlIKKVWywpJ9KCTMHPXQ1mrxS
NygXqDY1_AVD1_EaOE_K2w",
          "e": "
AQAB"}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MAR6R-6FP2S-CT42Y-L2PQC-KOCBY-EWIJT",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAR6R-6FP2S-CT42Y-L2PQC-KOCBY-EWIJT",
          "n": "
vhqzaDFxln5mv0hKtd6Cv6l_mJiLsNPIm-nDuQShg3PIosD7YpzfmqBmdzZTDGhz
0a6w-jsiiiEVbWh3nlQyh0QsjoaoJqE5z59sXPTe_GBz_LMTe5IAJAj406y9ZMEw
oAtkJn269udr92FUng6k3g5henSU6CwEPMtEgIiCEkSAVqOVnAXagsNZUMW7jb_s
oP7D4ax0kz3KaMcLb52RyM8fnLPO9JKThLz43sYVs3_cjh8ErnW3uBARLWbV6qgK
52WVHVMw7USCYAhdhaCedesSTSLUaTXcVAGI80p1_t4YGWiakFtOp6pET33CddT6
X_WEL4v6pKtdVPuW8zYs1Q",
          "e": "
AQAB"}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFDN1AtSE5TSUUtUzdRNkUt
VkZPM1ktVEJMNU4tWlVSMjUifQ",
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUFDN1At
SE5TSUUtUzdRNkUtVkZPM1ktVEJMNU4tWlVSMjUiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19",
      "signature": "
U8p6maXGszOgAp1ns-glFh0EaIU8HpJwKenMj9I94Es-2qzErUfxrv4HkODfMEIO
lyU4-k0qAqr8Da2cZMasdvsrO6xMDXgulss7cih1tdNvtnaAJm2W_DnOOpDggnjK
E3odsBawe7vNvi0lgjJ-mEWp4dvCyrRZ3clLCKfZoCI2nI5KNPU3_YI0wJA2XD_m
56gl-V9LQgqFnLrnfyfhpaE-poGHm_aU57Bv10DeSp-oTJ0mPlbBMS1GzrWKk4e8
lJ9dIfLUhwmgT0a7OkNp9HIlYGURAGGWjvG33CIBwmH0MWN4PiT9MNTABliafs4a
kDZq1kaqzPIQ3ClepKFyPA"}}}
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
          "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU1P
Ty1USTNCVy00VFBTTi1aRVFVMy03Q0hNWC1UQlBRUiIsCiAgICAiU2lnbmVkTWFz
...
N3F2TEY0T2RpVFVVOEZnIn19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19",
            "signature": "
lZcyQpLShx7ir9UTqpoAuPmc2hsvMh4Bf2KAPq2J4piry5v00XWo5oH9CGEMg9Q2
ma1YZljXOPeXpR5Lxg73XHrxILejQUxMo1VvRhXeBZPG4Jx_94hcWgf1OB2qU79J
JlRrTr70LcNhvtsHnC21GZLD-r2elh8pCUkEtjkCngQRwdIeaSUYOBV3q1DGCQDb
3rvLGfz7QixLXX_PMoQeDfvCHR6GMUy-S2jfs7wO0EsdpcpkjleRrN88foSJI8L5
E4H8YFEnpg_kedcmCUqthC-MkQSZpu4PNqWGKNemh2mev0bWFo_QoMQ6xG9ZMqUi
aK6SHEUr5ITiqO_4luSsvw"}}}]}}
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
      "Identifier": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFDN1AtSE5TSUUtUzdRNkUt
VkZPM1ktVEJMNU4tWlVSMjUifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFDN1At
...
UEEifX19fQ",
        "signature": "
FIbmkogkCCnEpwcCliz3ySxWoCU4atq8s75q4aryOSruXzU9W_mZspsCMp250yw1
aFQHmK9Z4B_sTaVpIMgzJg_EmT8ATAf_kG7HziZE6sx9HYj7YmWsynr0jSxr7dg0
BFltu43HxVfRAAX1bNoIarCGbWa7b8dI937Sw_9bj2ftRnRjIogdtRBpX2xgEj_2
4ZLEsNNqXZZ0pHGkEqAPFFRBVpu94WkIquuZY5OWNd6Fu98J4aiErpnD1Ng-HYnp
yG79wX6qEvKr9rcN0OWCQS3Lif33UoT-4XCHq67jf5wCHVfatZ1BQyBI6rzEGZhc
QVrvyibn0KqTmsj6cREAmQ"}},
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
        "Identifier": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUFDN1AtSE5TSUUtUzdRNkUt
VkZPM1ktVEJMNU4tWlVSMjUifQ",
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUFDN1At
...
UEEifX19fQ",
          "signature": "
FIbmkogkCCnEpwcCliz3ySxWoCU4atq8s75q4aryOSruXzU9W_mZspsCMp250yw1
aFQHmK9Z4B_sTaVpIMgzJg_EmT8ATAf_kG7HziZE6sx9HYj7YmWsynr0jSxr7dg0
BFltu43HxVfRAAX1bNoIarCGbWa7b8dI937Sw_9bj2ftRnRjIogdtRBpX2xgEj_2
4ZLEsNNqXZZ0pHGkEqAPFFRBVpu94WkIquuZY5OWNd6Fu98J4aiErpnD1Ng-HYnp
yG79wX6qEvKr9rcN0OWCQS3Lif33UoT-4XCHq67jf5wCHVfatZ1BQyBI6rzEGZhc
QVrvyibn0KqTmsj6cREAmQ"}}]}}
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
        "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU1P
Ty1USTNCVy00VFBTTi1aRVFVMy03Q0hNWC1UQlBRUiIsCiAgICAiU2lnbmVkTWFz
...
fQ",
          "signature": "
jbOrhz0CwqMJk6hvZfdzm4z-6gm6ouhR9uib6kxY_XU5yHXwS4ze3_QGYAop6kUw
0dlwnHNRBZSeNr1tv7flH7avVAeU2fgMO9gwztTcJG33C19uEe8lpZEksPEcvKxl
aHcMwsKjy67zWSr5i-xImAXe9X81m4qnU05niPivsvrBwzUP47aIxAhFgyBi9Gh9
tr4wX1BMHVIHzMrjWWJh2Y-ueCBQ2uhU-3o2-O_zM1HJ2Vniv4wMZmFJnEGx-RKc
rOvfC1tpanMyZ8h1KW2lpNf7lBvMZiX04U4ov8fEfI0Hk3FlJpZgJaVVtYtX_23Q
WHI5jxApPJi992ItlbSdLQ"}}}}}
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
      "Identifier": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFDN1AtSE5TSUUtUzdRNkUtVkZPM1ktVEJMNU4tWlVS
...
dGVkIn19",
        "signature": "
I3DnAeNz7h99-gQsxBB2MSs_0hvU3D7i_3k2XtI5w-AeUrQXDbmx5wP_uVvft0tb
_nQFlDpjW1dVAojt9wvLBpqvkLmV7amK8CjyAE7H0wzs5MFJ1w0RGeCeZOO7tjrb
rKAm8NKkTI9VsPWS4dRDBqi2PRpOjbYsuVUCL7j71VCodKRT_GFYEfxKDs_MjwSE
LnrIpar0hwGnglZod61G3EEkpFf_8Xm38WnPYdM6GYc2HHNUWHbnPBhQj3X2uX64
W56vID5O72Ekl9ONz_WEJoXrD1MJFgjBINpmx-vIcJ8TWvvNFGfD4X0mgoSQYr4R
ibS4OUCj-euBEQrK9Wwcug"}},
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
    "DeviceID": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MAC7P-HNSIE-S7Q6E-VFO3Y-TBL5N-ZUR25",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUFDN1AtSE5TSUUtUzdRNkUtVkZPM1ktVEJMNU4tWlVS
...
dGVkIn19",
        "signature": "
I3DnAeNz7h99-gQsxBB2MSs_0hvU3D7i_3k2XtI5w-AeUrQXDbmx5wP_uVvft0tb
_nQFlDpjW1dVAojt9wvLBpqvkLmV7amK8CjyAE7H0wzs5MFJ1w0RGeCeZOO7tjrb
rKAm8NKkTI9VsPWS4dRDBqi2PRpOjbYsuVUCL7j71VCodKRT_GFYEfxKDs_MjwSE
LnrIpar0hwGnglZod61G3EEkpFf_8Xm38WnPYdM6GYc2HHNUWHbnPBhQj3X2uX64
W56vID5O72Ekl9ONz_WEJoXrD1MJFgjBINpmx-vIcJ8TWvvNFGfD4X0mgoSQYr4R
ibS4OUCj-euBEQrK9Wwcug"}}}}
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
    "Identifier": "MAQLH-YXEBA-OSNJ3-2ZCWB-QDEMW-KXLQY-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
qcnH2tPivg5JIrIzWa_KQA",
      "ciphertext": "
aute6ZbMgsxIkYb3V9x6BkQr-84f_jPfYFgFFdU3WCInPQAmKfbdZYbjOz0chqFw",
      "recipients": [{
          "Header": {
            "kid": "MCEWX-F352S-NDFEU-3F2FN-T7EGP-ZJLQW"},
          "encrypted_key": "
azhfOvb-gef3_n3lhsTPpOEozl9aM7h4jFHfPBbAvSDDkv2ap5pwsMsekpC1xjkA
sEFXG4EOX3QCpGNiijlO3qA4DF7s-qfm84r7z4jkx62HND7q-UHY6MDPgv3OXFBL
OQi2WmQ7wZq-GTYZJCNkZn6p1U0dkT19Sj_cay4RuFXrGuroHCOk0kJBJm8cbJh4
Rstb2FcsCarjPR8FOWQewIO_sPGxF7YON1F1NzoYoN-ydlLOdP5oxcq2oESZYyc9
Q8l6muv922tuzrsCGGfQp44Dcgw4OfFo6iXQd0IRDKLzztSXZR5QJErwIqPaynHf
UohO1W4fOcs1LlLyE9vA2w"},
        {
          "Header": {
            "kid": "MAR6R-6FP2S-CT42Y-L2PQC-KOCBY-EWIJT"},
          "encrypted_key": "
I1rKI6QZjojR-cm5xYUYdtK2XL4G74sswWk7hgESWPiR0JEneWKmnvM2N_MsY2LS
7FqFcNCBo3qGm8vT3nTSgeJrVnjY6XFSdZpOw9tShrOlxhpneES1cTh_PI6gVxDF
NVPa6gNoPVroXwDZ967km7IwI0khgemHdPEiJAQW_r7uOE5bqZjD_jCiNhV6D1-y
_eto96WOZ54OgPFvnIPqqvTCCWsypEfZYc7HCBQohtJ1q0ba5j9Hxr8SFB1IrkNx
cm-O0KbUqgLsy1K9RfZf7VCK8pW2e3vNYOD4lDxB4hkA7-AsxB2OJnCghVb1Ko5Q
SpVqSUbL5rxobSjx_xG2cA"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MAQLH-YXEBA-OSNJ3-2ZCWB-QDEMW-KXLQY-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQVFM
SC1ZWEVCQS1PU05KMy0yWkNXQi1RREVNVy1LWExRWS1BIiwKICAgICJFbmNyeXB0
...
T0puQ2doVmIxS281UQpTcFZxU1ViTDVyeG9iU2p4X3hHMmNBIn1dfX19",
          "signature": "
Gjgk0ZpGDjR-4xHMGUCXphaOVnM4jRNuFQtXfzlGRB2E3MsFytA5nTVD7qVXb5aT
usADj4m5u440Kc-lNKo7rwqfI3l-a22DrVdonN6siJw5eugZZwLDsfhoWLAbwY1a
MueU3OPDogHixTJ_xuEoQMo_dQWjssx_uO1nb0bgu-b71tfkRxUyPtWaE0ICn5Tr
EgyPBQrsHWoqMGdFzQ3eMCKATVCPWrZPAoDx5TTnKMe5K8xf9CA7tftY5rwGzuia
OA_O6I4jFG-lm68G7ggJ0S_b8LkJ3qcINXuSjc-A7GKTe90gL8uAlHU5dZEQ_rUV
tdzf4psTLfTvJKB__3QecA"}}}}}
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
        "Identifier": "MAMOO-TI3BW-4TPSN-ZEQU3-7CHMX-TBPQR",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURFNkwtRlE2WkUtVExOT08t
NU1OMkgtNlZUSEYtUEFFWksifQ",
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQU1P
Ty1USTNCVy00VFBTTi1aRVFVMy03Q0hNWC1UQlBRUiIsCiAgICAiU2lnbmVkTWFz
...
fQ",
          "signature": "
jbOrhz0CwqMJk6hvZfdzm4z-6gm6ouhR9uib6kxY_XU5yHXwS4ze3_QGYAop6kUw
0dlwnHNRBZSeNr1tv7flH7avVAeU2fgMO9gwztTcJG33C19uEe8lpZEksPEcvKxl
aHcMwsKjy67zWSr5i-xImAXe9X81m4qnU05niPivsvrBwzUP47aIxAhFgyBi9Gh9
tr4wX1BMHVIHzMrjWWJh2Y-ueCBQ2uhU-3o2-O_zM1HJ2Vniv4wMZmFJnEGx-RKc
rOvfC1tpanMyZ8h1KW2lpNf7lBvMZiX04U4ov8fEfI0Hk3FlJpZgJaVVtYtX_23Q
WHI5jxApPJi992ItlbSdLQ"}}}}}
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
        "Identifier": "MDN6L-CPQV2-CILJB-BCPAY-JHWQQ-O2D5Q",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
          "iv": "
s8qcSEkm94Gbu2BupNZRxA",
          "ciphertext": "
Bb-0iQ4w1tGk526FuiwjKve7qebKXa9ppFSo2hYVVchZC98xLWNbN5VSkgbzBioW
QJ-Q0N2cwDJkEGLhYGX1B9AOASNN1cysYMMzFCVLR7Ot2qAFV23eyvoFDTBCXDwV
...
ijDhfNoMyOKs8Pji795DId3_5vHnt3-UE9KqQyL6es1IlrRhQ7u0Nk2iq3YCZhNm"}}}}}
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
    "Identifier": "MDN6L-CPQV2-CILJB-BCPAY-JHWQQ-O2D5Q",
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
          "Identifier": "MDN6L-CPQV2-CILJB-BCPAY-JHWQQ-O2D5Q",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
            "iv": "
s8qcSEkm94Gbu2BupNZRxA",
            "ciphertext": "
Bb-0iQ4w1tGk526FuiwjKve7qebKXa9ppFSo2hYVVchZC98xLWNbN5VSkgbzBioW
QJ-Q0N2cwDJkEGLhYGX1B9AOASNN1cysYMMzFCVLR7Ot2qAFV23eyvoFDTBCXDwV
...
ijDhfNoMyOKs8Pji795DId3_5vHnt3-UE9KqQyL6es1IlrRhQ7u0Nk2iq3YCZhNm"}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


