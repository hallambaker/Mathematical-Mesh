
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
Date: Mon 19 Sep 2016 09:00:33
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
    "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
    "MasterSignatureKey": {
      "UDF": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
      "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAIfYVuUUSogxe1GiyLqqu1MwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTURMNTQtTjJMWDUtMjVRSVMtVEJVVlItQjVWTjctRDJBWFkw
...
VqW8r6bTyjibeFiDyUQGMpB1nqums_NbiYQ0A4Zsu1H-6rrs8y6f6HG6oA"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
          "n": "
zTjCcO-QvcZjO7L2EF0J6sLYzDuhvOy0Yl0aX-r9-3s61xKGbvYt3rv5NwI44Wdd
Clq9KDjZCPMTTm_gYFopSfUWwvs5GyU8HiG5ZG8VJq7fJy-FdagKEX_9KbEVLff5
EdZH_R28EU47keLItXJ3TTz2SXZwuEsMMVWnhl-T6zzscUm_vsGaBeImuS_9KOoQ
7qEebEkUKlirLKv1CerV8osNaNJsR4eUqZ_SFSyEqtgGFgn3u1O99OgNNiDCRR_q
dxJHatcBepREag9Y3Tp5dz2PhjYsWUGPG0C5Le0L-2goiuwK33Mna3CFYibqU9d2
zB4iKM4EjSucgY-aOoSNIQ"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MCIQ4-F7JCR-DIUHN-5QZLR-52BMP-DQBI3",
        "X509Certificate": "
MIIDJjCCAg6gAwIBAgIQT5klM7cMNKPuoQSghOYsgzANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNREw1NC1OMkxYNS0yNVFJUy1UQlVWUi1CNVZONy1EMkFYWTAe
...
4G5RLIWE9dszHIa_0BF9C-KqFM4mIfP8txKflSYrHqfhDu0Zp3FL07cT"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCIQ4-F7JCR-DIUHN-5QZLR-52BMP-DQBI3",
            "n": "
4CpFv7yGjDj3dS5svPhzTJNUir-B9ArIIVcmZibt8f02i3QFdSIQNNhJ6KI5hgNh
NzuXrktgiAlUJ6N_R3F2uDK9AEJpjwRaiSOAEdSfr7C8Asd-QxwPN6dXYgO7D8cd
2RhBmDFl4NKXxuPeiHexlMMftEdeMyb9QpNnnAN8Rt6_s1a-Ln-pCDTWZCAxDiw4
JVdejUp_sTM2UgcP7uGDUjlz8Pg328O-WBlS_PT95lLXalFE_lVoMJmRXR0p6_kF
rt0es_gqW0n2sZhFb1UjLuq9bRcqn7e9JTmqhxVeD43aPvvyY6V12B3wz1-E3JYH
REAyZe3vJKsWenGlfcdJAw"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MCY5V-LHCTW-F6HZ6-5PDXQ-HYZYM-YPW6N",
        "X509Certificate": "
MIIDJzCCAg-gAwIBAgIRAOs8crO4N3ufO16_pm2hva4wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTURMNTQtTjJMWDUtMjVRSVMtVEJVVlItQjVWTjctRDJBWFkw
...
HHBIJHq324BLTY7vBrQR62QJfMdtFcTfNiroa3RjV57jeLqP6bfqr3Owsg"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MCY5V-LHCTW-F6HZ6-5PDXQ-HYZYM-YPW6N",
            "n": "
-q8C1cRoc2nEv2xM8QChTXD71SQmABJkS0UfBKTv7N6ecxYsZvcfifEo1oY7QuPZ
n6HHZb5qrISUBO3JUcEYpuhKbMYmXXFPCSluTnvRatQxRtK0PsaahUSk29XsNgQF
lqdtUF5G_l9u_Ih6ODRf3B2MkH0Wpw3TKI9ZngtARApBFdZ52IOH9NNWfYeUNZXx
BWzlEuXGfIrtNnA1o7MtCWatrAk-an2BiRtK_mf9bzG3pn1zCI6rRs_NqelOX7pa
b1TFXcIkD5PTRDS0VbN2x8F4pZPihJSnXWtZJwPS3oLC6rFQGUZVChQhiJXe3GTI
GSiDwESeuLGvlNnQX1IrxQ"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURMNTQtTjJMWDUtMjVRSVMt
VEJVVlItQjVWTjctRDJBWFkifQ"
,
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURMNTQt
TjJMWDUtMjVRSVMtVEJVVlItQjVWTjctRDJBWFkiLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ"
,
      "signature": "
wl8GnlbPI99C1LanNv8220NPltpDW4fjOlCcKj0PDMCrH_rQ3749UXdHv0Dfjrpa
Pvd0gnUL-4_QcPzRcegsZ-buGEgKliabvzr-xTYIbxdJmge9aezvXToWFUVwkWV7
KPgAMApFPEVomf8o80_bhfl8_E1fO9hEca6-8JkDkOKXxZzT8ngLXdqQNcnZcSon
5dZRCJmGdOmCDmADv8gPeNoCCXOK-fJwzsIBY78zcY7nvJDC-ScWeCIZlXmXkSnR
4gCK75tzJlSbAPI7V2Tlm4B5gPOk4fE00TNvCZdRtQS8KKMmbDVP2dtfpARGc9rZ
-620TtBEeYnex5AaU5BJHA"
}}}
~~~~

Since the device used to create the personal profile is typically
connected to the profile, a Device profile entry is created 
for it. This contains a Device Signing Key, a Device Encryption Key
and a Device Authentication Key:

~~~~
{
  "DeviceProfile": {
    "Identifier": "MC7SA-FWMVR-WHGHR-2CZUT-TDLDW-TLBDO",
    "Names": ["Alice Desktop"],
    "Description": "A desktop computer built by Acme Computer Co.",
    "DeviceSignatureKey": {
      "UDF": "MC7SA-FWMVR-WHGHR-2CZUT-TDLDW-TLBDO",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MC7SA-FWMVR-WHGHR-2CZUT-TDLDW-TLBDO",
          "n": "
k-igeP99Z8CiyQm4ZNnPFCutCHKOZm4VNhqmliZKYciSRTMw4bhe7ySN8T3pQgdX
Ib8ii55WaQIxvXlqcYBFfJ5YmrfmoA7OVp96ayaMzY3Ll3sKCCm6a0X11CX9an1Y
FZi_iJlDRLSkH__7Ulgq2IbeZ4GTlhX7i-28s03a9b1HIo-gF8BywJM2ewmACp0s
_JPpRLVpVSpzfgChh3fFchuC1M0u1QuUAR_G7mNgiZJm9cwSLfU5sh9dzm6LBVfR
vXEtrgNaD-dUWPZNcuoq4Iu3hZCOqrtO7MI908c14vQxcjfCTjVwAIzbce1RWXll
U-dgLdR5C4fSkjTrzLmJew"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MAPO7-SK5VI-PC3NK-MRGWS-HTGBJ-ZRTFA",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAPO7-SK5VI-PC3NK-MRGWS-HTGBJ-ZRTFA",
          "n": "
n2DEEO5Xt8GpwHPWSspajsE8PQ2Lol_xhvTdzGJwo_iLvHUbpGz9TD2HdD4QQ8ws
vOn1nAvesWNlWhEWXg1FR8aZ4OA3INOYlPvcJ1spRCJtJLffVk9lCoW4xH92cJEC
eCDGAmedZEo8nUNdpyMk4C1FwtMiX1bxT_FP-0mqG8Z_CL0P30xvG0wmYk2mZBxo
gqR8FhRohuvSp6w0JOdKNqRMCIWg-cXJMfKmg_rohf2g1aunrPujsfy3WAioYFYb
aYsDl4MmQxn8XF8HgrKtCJ5pbVn7WPWZypRx9DznXtixdBqWlmLawt13PmCXcRIl
e0eFfh6D4I5iWo07dhDgiQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MAMNH-KGSPE-RDKMQ-TEKRS-5RRVC-FNIMV",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MAMNH-KGSPE-RDKMQ-TEKRS-5RRVC-FNIMV",
          "n": "
zYY8R-12ETEcRLsYxpxECAE7o9GDrUMGv4g1W9e7Uw64lc78MldatvAg30xjdKIJ
KYw3PCSfX1c2i-C2lo7Nl8ZGgtnm_SsUvcqh_DIk5risdCnXl0DGTwz8VLDoyg_h
OmyPMDwpMWriZ5DxLDv26VjOF3oP5vMRruz9ooqM8neone6ctKic2EE668XREEwm
jUKz-EyOz4Tm4vjcClihSyOd-vpSaudMcgLhC6A_hlRKdB2lAHKUyyLQpOX4Dae2
kmYn0rwNuF8T3ahk4tbxG0To_azhWQtFdYYg2W1FTIsEKWute9tjkUBq9BWol_RD
WjZrm5fq6JcGtqxxr3E46Q"
,
          "e": "
AQAB"
}}}}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MC7SA-FWMVR-WHGHR-2CZUT-TDLDW-TLBDO",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUM3U0Et
RldNVlItV0hHSFItMkNaVVQtVERMRFctVExCRE8iLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ"
,
      "signature": "
ARJOACdfRq9VgHy5gNy3bryFIlmCk4QWjqSMQSIPpXgOzghXYizIk4H4j2loxNNS
jfVEQHB9bwd767RTgnhayVRzI9TfeUDi7GDYpMvpJOl6rUfXXpwECROxyGUnhQfa
eXzfYB6B3dbfYWFqYHHl3_cqjre_sp2EjkZEZ7Y1qiM1U1JQGzdtQrgdOhyXULZY
vSjCVoyCdMIq4it1v5Dri3MxbMwL48B7mBaGKOWPyV-NzFxF0bG4cjgEUOO1YjYG
o-LDehwwVxwu590Y1i6KI3OvUBVobA5BqAHztWXKlswABkGvZhDYH09q_oxGYx3e
h_ObMDoOtZPoYUn-F__Fbw"
}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
    "SignedMasterProfile": {
      "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTURMNTQtTjJMWDUtMjVRSVMt
VEJVVlItQjVWTjctRDJBWFkifQ"
,
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTURMNTQt
TjJMWDUtMjVRSVMtVEJVVlItQjVWTjctRDJBWFkiLAogICAgIk1hc3RlclNpZ25h
...
IgpBUUFCIn19fV19fQ"
,
        "signature": "
wl8GnlbPI99C1LanNv8220NPltpDW4fjOlCcKj0PDMCrH_rQ3749UXdHv0Dfjrpa
Pvd0gnUL-4_QcPzRcegsZ-buGEgKliabvzr-xTYIbxdJmge9aezvXToWFUVwkWV7
KPgAMApFPEVomf8o80_bhfl8_E1fO9hEca6-8JkDkOKXxZzT8ngLXdqQNcnZcSon
5dZRCJmGdOmCDmADv8gPeNoCCXOK-fJwzsIBY78zcY7nvJDC-ScWeCIZlXmXkSnR
4gCK75tzJlSbAPI7V2Tlm4B5gPOk4fE00TNvCZdRtQS8KKMmbDVP2dtfpARGc9rZ
-620TtBEeYnex5AaU5BJHA"
}},
    "Devices": [{
        "Identifier": "MC7SA-FWMVR-WHGHR-2CZUT-TDLDW-TLBDO",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUM3U0Et
RldNVlItV0hHSFItMkNaVVQtVERMRFctVExCRE8iLAogICAgIk5hbWVzIjogWyJB
...
ICAgICAiZSI6ICIKQVFBQiJ9fX19fQ"
,
          "signature": "
ARJOACdfRq9VgHy5gNy3bryFIlmCk4QWjqSMQSIPpXgOzghXYizIk4H4j2loxNNS
jfVEQHB9bwd767RTgnhayVRzI9TfeUDi7GDYpMvpJOl6rUfXXpwECROxyGUnhQfa
eXzfYB6B3dbfYWFqYHHl3_cqjre_sp2EjkZEZ7Y1qiM1U1JQGzdtQrgdOhyXULZY
vSjCVoyCdMIq4it1v5Dri3MxbMwL48B7mBaGKOWPyV-NzFxF0bG4cjgEUOO1YjYG
o-LDehwwVxwu590Y1i6KI3OvUBVobA5BqAHztWXKlswABkGvZhDYH09q_oxGYx3e
h_ObMDoOtZPoYUn-F__Fbw"
}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREw1
NC1OMkxYNS0yNVFJUy1UQlVWUi1CNVZONy1EMkFYWSIsCiAgICAiU2lnbmVkTWFz
...
T3RaUG9ZVW4tRl9fRmJ3In19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19"
,
      "signature": "
MNxXLSp07njavPlAmUNcysBp0JSLFFNQzEBB4RYp_JZue8RThqFqU8424kMtoHI1
HqsQP_QhezA6GFQqJuxxDqv80j0YLE05uYsN7kyVxyeRjD7YensHS5QslaALWTb-
bl8DZBafC9i7lJ6u35pDYdIuvIhCDh8ZsADwMh0-96QzpoTZHJlSh0f6XxaDhYkY
aZvxxOimIfKnAXJ3rAeaj-eo_L5UTJinRMzEJ0ICpMTwskpBRf01cQP46RHcxqAy
NcDBo5-4-gU9CG6A-eD9YbOqFRBoET1v_jw2b2huj_SFZ5oZ4OaHSLaFuNhZs77D
i1A5KqezpwAikbRoGRWICA"
}}}
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
        "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREw1
NC1OMkxYNS0yNVFJUy1UQlVWUi1CNVZONy1EMkFYWSIsCiAgICAiU2lnbmVkTWFz
...
T3RaUG9ZVW4tRl9fRmJ3In19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19"
,
          "signature": "
MNxXLSp07njavPlAmUNcysBp0JSLFFNQzEBB4RYp_JZue8RThqFqU8424kMtoHI1
HqsQP_QhezA6GFQqJuxxDqv80j0YLE05uYsN7kyVxyeRjD7YensHS5QslaALWTb-
bl8DZBafC9i7lJ6u35pDYdIuvIhCDh8ZsADwMh0-96QzpoTZHJlSh0f6XxaDhYkY
aZvxxOimIfKnAXJ3rAeaj-eo_L5UTJinRMzEJ0ICpMTwskpBRf01cQP46RHcxqAy
NcDBo5-4-gU9CG6A-eD9YbOqFRBoET1v_jw2b2huj_SFZ5oZ4OaHSLaFuNhZs77D
i1A5KqezpwAikbRoGRWICA"
}}}}}
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
    "Identifier": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
    "Names": ["Alice Ring"],
    "Description": "A wearable ring computer bought.",
    "DeviceSignatureKey": {
      "UDF": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
          "n": "
3r_b_iNt7h88KzATdEOH1zR4AHXA-ATjEzmvwFQTb2RErece37Ca5iQKwuuWgcKu
LRxqgplvuDYiuXGDL9DIJs2aHaSf9hZldLWdm-LduCcuF5oFKfNcNCdywD1j6xTa
RgnEd_dmV4Dnwn_ep80wBx-iQgDS1SW0AgoQo2867VNg26kElzi46CX7GGmDSXwB
pIfndEMv6xTm07omUzUueVwFleNRUQ48ESZzAzqF6GR993imAYisPZMFoFXZElXf
KBFZpA57X8g6cAlmzcMayxXwh27K-3v_8S0RfOUlo4GQ8yO2I-X2ix1lTbzopeSO
cJ1HoGojVCRlvbIEXO4PEw"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCE2J-BZZ6K-63MVK-WRODF-KCJAC-MA424",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCE2J-BZZ6K-63MVK-WRODF-KCJAC-MA424",
          "n": "
uulQYNaIyNPLCaAVH2yQZdeHIdOqurEZCrMoCuTDRFu4Ie3KBB-VyicGSKICp0uI
b2fhXheFdW8vX4f98oO0WR-UjzKszkKAdxi3P3JCsTLAwkcSB4GqzBULmxBt576r
qfLAHYI8QYx5uPZPhABqI02IZefxYZ06jgAWEp44jtOQHe9rARxdQJLbgzVR1H23
E9VDF-10CVBegmTrmK_-Sj8HZV6fAeLtOISVmTEsFZnHobddwkTSOd34DhY0cQg7
Y2ftdKcIwdQCRdTv5_n1NsE7nrKcNngWgULJbfSw0cHOYiE7_Og8Ljy1puWEZMSN
e0UajeSrrkUtw6ZnNcDGxQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MB6UF-V26OG-ME234-PHNWP-NS4RQ-V64YO",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MB6UF-V26OG-ME234-PHNWP-NS4RQ-V64YO",
          "n": "
8YOoeYiiTUppFMnrYfzmDHGTOhulBKQtKsZ-Pdbwd6NWuwZNt6LAT5XpcatcfWZ0
3mulQPY6Dwk90jNtyfyROOf-7nvPRdQneYzBRScFa02M_aL8Paw9gJQ9dHBZ7p62
SHTzFUHTXQMOK1gzV2QQSHdu-j1qY7osjuNPboJsYczCGa3TJBhfwC6l83EfrsP-
NaiByIUESIRhgnfqoD2XTL-d0GC5HwMMLi6PUnQfWTyOPsoU_xB-JRVllYs-YD9t
jmAXQSqU98GdbNWBxJG7EM-QOvrgPIVYOXQE_wHP3e8GMMGCidc4fMQCkWACNeGi
Pe5Io_ViR17JzoH0voX3DQ"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
    "SignedData": {
      "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJPRVItNEZaVlAtSjNEVlEt
Wkg0U1otTjROUEctQzdNQUkifQ"
,
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJPRVIt
NEZaVlAtSjNEVlEtWkg0U1otTjROUEctQzdNQUkiLAogICAgIk5hbWVzIjogWyJB
...
In19fX19"
,
      "signature": "
NTUVKrhLqpQkd6yoo8Lc7dwMTPDcRKXWfsuOUYbqi3Lm3tl4PSULNm-mv0yHStCb
hD3qXhh89-Tk3cijsU6T56_h8boqlFnSfc_UNxdSAyUxKXkjCs6b8BLWa6NxDu6I
79FoWn4jNt7JB-dBi0IS5SW_4Wl1kzHuEjaDL4hZs17h7TDmHX_gB6iF_p5wR1sT
GqpxINpOW6l9v6lNfEUeQQOU1dvzeK8_3dYQX25rnURA5wnSUxWhRSieGeXvAR8k
7J8IY4jxNaGH8ncSe2g4JNCsrC0PpwqjzVuCye1Mf_Kr35e1JgwzXMTxhURegC_-
ejdf6vcSl9GuFQz57KeZYg"
}}}
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
          "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
          "SignedData": {
            "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREw1
NC1OMkxYNS0yNVFJUy1UQlVWUi1CNVZONy1EMkFYWSIsCiAgICAiU2lnbmVkTWFz
...
T3RaUG9ZVW4tRl9fRmJ3In19XSwKICAgICJBcHBsaWNhdGlvbnMiOiBbXX19"
,
            "signature": "
MNxXLSp07njavPlAmUNcysBp0JSLFFNQzEBB4RYp_JZue8RThqFqU8424kMtoHI1
HqsQP_QhezA6GFQqJuxxDqv80j0YLE05uYsN7kyVxyeRjD7YensHS5QslaALWTb-
bl8DZBafC9i7lJ6u35pDYdIuvIhCDh8ZsADwMh0-96QzpoTZHJlSh0f6XxaDhYkY
aZvxxOimIfKnAXJ3rAeaj-eo_L5UTJinRMzEJ0ICpMTwskpBRf01cQP46RHcxqAy
NcDBo5-4-gU9CG6A-eD9YbOqFRBoET1v_jw2b2huj_SFZ5oZ4OaHSLaFuNhZs77D
i1A5KqezpwAikbRoGRWICA"
}}}]}}
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
      "Identifier": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJPRVItNEZaVlAtSjNEVlEt
Wkg0U1otTjROUEctQzdNQUkifQ"
,
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUJPRVIt
...
WWcifX19fQ"
,
        "signature": "
PHQjSWlP_mCIycmIppZQYkHssweytf1ala7Ypq2D1u7-8GyYH1HcOrkIyZRskt4G
5X7P352MfSBBSAZT99ME0fTS4-otg8K5Ctn8jBY5IVD6PLB07cF8lGYIPTUpRnJJ
qVJ2FeGUJqFb8kHd1qF0AfbJL3LbZq3zljhEjgfUHEwzefaX1nwpV2S6muqFC3rQ
WRJnHd8I9Uoxvr310lQ7PXQC0ZswzOkBSaQQEfntLorZHDnVf4m_cTOsYTbqg9fJ
EvPVhRAT0Fyw_lYp_Byc-5P9D7A0IqK8feJvGFIxPhbktfmIoLGLP-ooCO9082ln
oW4OFywAleIcbWEq8sbu0g"
}},
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
        "Identifier": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUJPRVItNEZaVlAtSjNEVlEt
Wkg0U1otTjROUEctQzdNQUkifQ"
,
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiYWxp
Y2UiLAogICAgIkRldmljZSI6IHsKICAgICAgIklkZW50aWZpZXIiOiAiTUJPRVIt
...
WWcifX19fQ"
,
          "signature": "
PHQjSWlP_mCIycmIppZQYkHssweytf1ala7Ypq2D1u7-8GyYH1HcOrkIyZRskt4G
5X7P352MfSBBSAZT99ME0fTS4-otg8K5Ctn8jBY5IVD6PLB07cF8lGYIPTUpRnJJ
qVJ2FeGUJqFb8kHd1qF0AfbJL3LbZq3zljhEjgfUHEwzefaX1nwpV2S6muqFC3rQ
WRJnHd8I9Uoxvr310lQ7PXQC0ZswzOkBSaQQEfntLorZHDnVf4m_cTOsYTbqg9fJ
EvPVhRAT0Fyw_lYp_Byc-5P9D7A0IqK8feJvGFIxPhbktfmIoLGLP-ooCO9082ln
oW4OFywAleIcbWEq8sbu0g"
}}]}}
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
        "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREw1
NC1OMkxYNS0yNVFJUy1UQlVWUi1CNVZONy1EMkFYWSIsCiAgICAiU2lnbmVkTWFz
...
fQ"
,
          "signature": "
iGGQq3WSIt4ktFXXt2taK7YFjiuyAQDVWeD12T5KaC1Vor2SzDWq_VIU8nnCH9pD
V_mzARHOfbOwvSGKSB1eeD0bS4Ttzuc3utz_5DnqQaExP87S2wbbeEAZ4y6LxznR
ZR6XiV0UN_HL_wJ4CmqVtCdhipgBZ2e_Vmnyzr5ZEZX0jg9HbbkB7y6FbRcJdPmU
mR7r6delPUh5NXrSotozdQQpUsPqxbkyMzsfRlVeAif1myeC0colzJflPitKkzX7
47EDyZLhREMvo6DcNBhgyO7E-XALPi4CNeqjGpcvV4ik6SMGUVEeeJYhDHj8vGHr
jpwEFkmFKFeMwHa-aCWaiA"
}}}}}
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
      "Identifier": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJPRVItNEZaVlAtSjNEVlEtWkg0U1otTjROUEctQzdN
...
dGVkIn19"
,
        "signature": "
Pc633ic76UzfiHsCOakNC35TUGAJG8f3t-Qmgjlb6LNfsWGhuu_L3LoP5Eq2R0QK
Xh3TPZPLZcs4PbWKt21IAoU36pFrmHNO3jhKpZJ3leTYVmFmnaVuX4r_qWHMGvfF
98w-6wAMd_vL5VZ9TQQv_l9FJ_H7E4Fpk35Dee0R_ZGKr8rxh0qoyucTB-BghifM
U7tpHza-OzYyeUu9_doPNW4smV8zQNgARerOR6iimYoyO_riTAroMe8C02HbfLkl
ia8mansWUnKKXUvSNHYsEbCmh91C72HqiJX2UUfD_4XMqDs0-ANubRnWQzkqFGAf
_1waHhp7TFfY51T7IVnUdw"
}},
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
    "DeviceID": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MBOER-4FZVP-J3DVQ-ZH4SZ-N4NPG-C7MAI",
      "SignedData": {
        "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJPRVItNEZaVlAtSjNEVlEtWkg0U1otTjROUEctQzdN
...
dGVkIn19"
,
        "signature": "
Pc633ic76UzfiHsCOakNC35TUGAJG8f3t-Qmgjlb6LNfsWGhuu_L3LoP5Eq2R0QK
Xh3TPZPLZcs4PbWKt21IAoU36pFrmHNO3jhKpZJ3leTYVmFmnaVuX4r_qWHMGvfF
98w-6wAMd_vL5VZ9TQQv_l9FJ_H7E4Fpk35Dee0R_ZGKr8rxh0qoyucTB-BghifM
U7tpHza-OzYyeUu9_doPNW4smV8zQNgARerOR6iimYoyO_riTAroMe8C02HbfLkl
ia8mansWUnKKXUvSNHYsEbCmh91C72HqiJX2UUfD_4XMqDs0-ANubRnWQzkqFGAf
_1waHhp7TFfY51T7IVnUdw"
}}}}
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
    "Identifier": "MBSHO-5D2GR-T7TNK-XHJV6-BHX5I-KA6TX-A",
    "EncryptedData": {
      "protected": "
ewogICJhbGciOiAiQUUxMjgifQ",
      "iv": "
9LOpFHTVI9-wtPECFHpRoA",
      "ciphertext": "
-jwZ9rngzGV2Gu7x-IwDXGksDFwIm01TJqSPkR_5CacxMB-r0MzVyeomjMmpCImg",
      "recipients": [{
          "Header": {
            "kid": "MAMNH-KGSPE-RDKMQ-TEKRS-5RRVC-FNIMV"},
          "encrypted_key": "
Y5glmB3szauorgusT293C7CAaHMcHtn1PqtmRz7OVcmjz39-xItg0xzhC6-VPXhS
1ye9qJSwmNHv8sQQ8vNi7pWijM-NKFUJhkjEo5iM6CKcpxlphh4gW8exEH-HScvB
5TNZk0wYmmR9LdTribgNlWAwu-n3I9xN9tZAr9icaggGH7GbSO9C9l8IgjpbZsDh
B7bBAuOGNviOy-3mIIF0bXo3EBCS3a_TGFtMicEtWa0AdgpM8hDdOCLZ738HBuxN
vku5SWIGCdx29povPuSalkBuPBX5CFnkq2IqR51QUTRyJtkEl6ts9oprPcJ4GEZd
fgASNb4g4LEP8JC7WmJeQg"},
        {
          "Header": {
            "kid": "MB6UF-V26OG-ME234-PHNWP-NS4RQ-V64YO"},
          "encrypted_key": "
fTFLdjuIw-8uFFmwm5twpiK05F6_tZMO6ZrDjVnjsi_VfOoCPP8hFFemfvx9XqSg
KmhVMysq_sJ6tw40duUNkOZcgaXpkfbBPFlobQPLMIfQydklq_njTTFYHWQhT-ui
aRTu4vUZ_n_R478fF7gKEn5LSCFIDH52AZWgpnRfMsIGdrKJUhPwbQV4vuwd4FFK
uRwLlTMVPfGOUSww38VZx0uIAJdqHztl5gKP3rP2Ld1lpDcGxX-ZYwDQQCdSlH0j
-Z8wezlnbLtTV5ri3TrYpZYEto_TYDVQlPWNArmQhjhrX8q9-pyAxBaEMFA4MhbP
BMN4sq6M34sC6Yc5nS3s1Q"}]}}}
~~~~

The application profile is published to the Mesh in the same
way as any other profile update, via a a Publish transaction:


~~~~
{
  "PublishRequest": {
    "Entry": {
      "SignedApplicationProfile": {
        "Identifier": "MBSHO-5D2GR-T7TNK-XHJV6-BHX5I-KA6TX-A",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
          "payload": "
ewogICJQYXNzd29yZFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlNI
Ty01RDJHUi1UN1ROSy1YSEpWNi1CSFg1SS1LQTZUWC1BIiwKICAgICJFbmNyeXB0
...
QXhCYUVNRkE0TWhiUApCTU40c3E2TTM0c0M2WWM1blMzczFRIn1dfX19"
,
          "signature": "
dOPSeM2MsLRE50l7rcStAAMbqOk2i-AQizwcK9EtAkeCKiYYyspnoD2WEzHDd9K9
mYaKlDvHr4YZ5fPF-tCyqHgNeMO0WjVuaCwSykqwZ-VvQ0IklSwiwTT9IHUYf8S8
WlFYgQOZLfCSropvsbbcBaAH5vZb_OgxXmoZtSzFdn89LQ1W7OiLvj8WLaMZNTcf
x2ChJ0lb3uVs59oUe3NIpaRHjsRvuDIjijN8ga-5tkwOwyfCk7W1u22n9GLEDTSH
DchYRIUUAjd8dxhpyOk_cxcEg263diQvlMGQ7tketBZqdIQZnRZISY5HCAsglgNo
sb-mV33TGfAcf9oOTZp1vw"
}}}}}
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
        "Identifier": "MDL54-N2LX5-25QIS-TBUVR-B5VN7-D2AXY",
        "SignedData": {
          "header": "
ewogICJhbGciOiAiUlM1MTIiLAogICJraWQiOiAiTUM3U0EtRldNVlItV0hHSFIt
MkNaVVQtVERMRFctVExCRE8ifQ"
,
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNREw1
NC1OMkxYNS0yNVFJUy1UQlVWUi1CNVZONy1EMkFYWSIsCiAgICAiU2lnbmVkTWFz
...
fQ"
,
          "signature": "
iGGQq3WSIt4ktFXXt2taK7YFjiuyAQDVWeD12T5KaC1Vor2SzDWq_VIU8nnCH9pD
V_mzARHOfbOwvSGKSB1eeD0bS4Ttzuc3utz_5DnqQaExP87S2wbbeEAZ4y6LxznR
ZR6XiV0UN_HL_wJ4CmqVtCdhipgBZ2e_Vmnyzr5ZEZX0jg9HbbkB7y6FbRcJdPmU
mR7r6delPUh5NXrSotozdQQpUsPqxbkyMzsfRlVeAif1myeC0colzJflPitKkzX7
47EDyZLhREMvo6DcNBhgyO7E-XALPi4CNeqjGpcvV4ik6SMGUVEeeJYhDHj8vGHr
jpwEFkmFKFeMwHa-aCWaiA"
}}}}}
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
        "Identifier": "MBOB3-WIZNV-MH3UA-OQLEI-L44SF-HFGEA",
        "EncryptedData": {
          "protected": "
ewogICJhbGciOiAiQUUxMjgifQ"
,
          "iv": "
1TsjnS6BN3rPH_i4xfh5jQ"
,
          "ciphertext": "
S0WBeEvG0zT8PWQfj3ls_HRt1av-mjYtpem1Q04IdvXCdWMyfAxk5fEUv-TXP-DU
GXlNi70UHLC9dtiAcFQiUcrCjQVJIb6qW6GtzdHrYcZGw8ibgcWKnAFbxk6VK-il
...
9oMj00zipIDIz156EtRo7tl3WTzy6lSJn6aHLjRHYCT6FOyBmSsoamQyP0yE3EyR"
}}}}}
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
    "Identifier": "MBOB3-WIZNV-MH3UA-OQLEI-L44SF-HFGEA",
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
          "Identifier": "MBOB3-WIZNV-MH3UA-OQLEI-L44SF-HFGEA",
          "EncryptedData": {
            "protected": "
ewogICJhbGciOiAiQUUxMjgifQ"
,
            "iv": "
1TsjnS6BN3rPH_i4xfh5jQ"
,
            "ciphertext": "
S0WBeEvG0zT8PWQfj3ls_HRt1av-mjYtpem1Q04IdvXCdWMyfAxk5fEUv-TXP-DU
GXlNi70UHLC9dtiAcFQiUcrCjQVJIb6qW6GtzdHrYcZGw8ibgcWKnAFbxk6VK-il
...
9oMj00zipIDIz156EtRo7tl3WTzy6lSJn6aHLjRHYCT6FOyBmSsoamQyP0yE3EyR"
}}}]}}
~~~~


The client can now decrypt the OfflineEscrowEntry to recover the 
private key(s).


