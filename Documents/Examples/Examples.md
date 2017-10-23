
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
Date: Sun 08 Oct 2017 10:11:41
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
    "Identifier": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
    "MasterSignatureKey": {
      "UDF": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
      "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAP9D19zOobGAhQczcKprdDQwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJWNjMtR0RFTDMtN003V1QtTDRTMkctU0Q2T1UtSlEyWUYw
...
Aarh-Elzmb875vwCW51vsgzvLIMqmZt0WhTKi9W0zKNT"
,
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
          "n": "
s6342wiRHCQzBFcxUEaTioYHIARLkqYk6Pl8vX2qUev-sGywIovpUtJfgE2zNs9t
6lbtU_yqnnzBYN8f73eINDR_l7OPr3bBjAAeT-XQWWPMEtbg6OLbsr_Utt-oWouB
hSjGuH8i0cFbNVhfwW3tL6tqOTkKbe-14KWOfEagxsgN5Z9bzx064KekIG9la1Vn
Mkc2GaJO7pJmHyoxLPMLBT182JnjI_ruxYZn8uYxjIKMgofJYKhGbauZBFFNzspi
IF8pFpj4b2Oq1VCot3Mrl3GqbxESJwoRDYQXy07OKhA-nbkPuza0E6flvqySoPxP
R_9MCKy6H_XlpHJD4qxFAQ"
,
          "e": "
AQAB"
}}},
    "MasterEscrowKeys": [{
        "UDF": "MDJUP-HS3YI-5KO6C-QMASR-DU2Z4-YGTC4",
        "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAJ2kbSkopAEG2RsaNFgFtA8wDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJWNjMtR0RFTDMtN003V1QtTDRTMkctU0Q2T1UtSlEyWUYw
...
bETIS0msaOxywMT-0kMiHBTni3oHPaxhtgPCtXd8GOrf"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MDJUP-HS3YI-5KO6C-QMASR-DU2Z4-YGTC4",
            "n": "
1LV6uF-sutoxVIjiLGz342EZPyxCgYnM-obQfeMyHmfsq6ZfMzG0WcH7D4a5NPJK
g6ze5966cLYObK5s05TieFcgMzA1BNyic_tX1F0p3XUYXrljG0IBHt-cJl62nY_2
P6KqCS7UMFwi0CEKUMXCbqaulRmdRMdkS2LJSGgviC8VJanTet_c87ke8PfXhP-v
dqRBUGZJe5P16whqJgH6bEPdIxSJDNJC7jD73ty8UFoEeoYbXL_wmd6DEiOM1EE8
v3-cSnpadvr1HY9hLdP4iGuPRv7VYItzMynWlCrSLRr4HQo5tOgpJuYEf_6O6TV7
3_tZ-CX5tbkNR9YNi_YDDQ"
,
            "e": "
AQAB"
}}}],
    "OnlineSignatureKeys": [{
        "UDF": "MBJTA-KAQ4D-NYXOI-ZRXYN-FVF2G-Q2FDI",
        "X509Certificate": "
MIIFXDCCBESgAwIBAgIQdY0fmCviWoahDMOQtIb42jANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQlY2My1HREVMMy03TTdXVC1MNFMyRy1TRDZPVS1KUTJZRjAe
...
_OFX9ySWRw9k_wMEL3BIwXzhN6yL7KIvW7mzVwRhJGw"
,
        "PublicParameters": {
          "PublicKeyRSA": {
            "kid": "MBJTA-KAQ4D-NYXOI-ZRXYN-FVF2G-Q2FDI",
            "n": "
zGyWD_WxRMowppd9TsxG8qrziGHEG555fUnE90YxvXKPHh_GMKznRkBQAOKQhoj9
8FtpTEgsqCRvLxfQqoYiSyPanKeIp5yA2tFZlKuUPfHr1uqDVWLVdSjDGGksLhRy
80DSHBTkN84FE-Y5xajyVGGf5Ig4QBBOTnGbaOLaNuH20KhaNpguQaQEMEeD4GX0
Vk7dOFfF_pBEiHvO-Uc2grQaFhnhxQrae5GMmAZ-vL_ZOQHaSQ9SjvvSOl4UtHg-
6tKEr4nXGN_BlYbwZHSwzRwJonXKbJbgwlQt5GFleSP6CySxSvGMuWhQYrZYecoc
qmbaeFw6DG3EZAapvzShcQ"
,
            "e": "
AQAB"
}}}]}}
~~~~

The Master Profile is always signed using the Master Signing Key:

~~~~
{
  "SignedMasterProfile": {
    "Identifier": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJWNjMt
R0RFTDMtN003V1QtTDRTMkctU0Q2T1UtSlEyWUYiLAogICAgIk1hc3RlclNpZ25h
...
QiJ9fX1dfX0"
,
      "signatures": [{
          "header": {
            "kid": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm1saGIxY1RxTHNaUDUzYXF4
QW9EbnNPaUktaS1jZmZZbzc0aW5kazItdTRBS3NWeDFFY1FCOGpIX0p3YkZJSE4K
SmhCMjJDaTEtZDFPSUYydFNOTXExQSJ9"
,
          "signature": "
fnhC55U5fXEFSUa8W1bHcxSdcHDD3GIjyPlfrEW3ygz9_4Z1qqm5b8eCkOul8cni
33y3hMm0l6wX0hbzYK1m4Ii3ZhhvP3-aq16mkBlwJA1xmb8mMGSCFwndjbnvWM58
BbNMAyJTAPwd4V0_RcmSvE_0t14BqHF5zqZxtXPAbp5Qq8wVEG0QtDZi0U7nQm_M
BcZrYbCCNKGrPdFyosZ14ccuUeMPp5udFadmCtVfVzm7dGaBACrdDvPv7JAsia3h
BLXKYAno_L5y_Tylrs00ul6SA10uFlT5qzb_QA48Hc9AyNALBg4lVHOAUKxz0gns
vgcYAka9Au21-RJGMlXkVQ"
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
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJBTUYt
WDdZS0ktS05DTEItSEdSWkktTU5TNlItNEVZTkUiLAogICAgIk5hbWVzIjogWyJE
...
S1EzYVNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
    "signatures": [{
        "header": {
          "kid": "MBAMF-X7YKI-KNCLB-HGRZI-MNS6R-4EYNE"},
        "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmtPWlp2X0RTNUI4QjNsMjVM
dkl5R0c3VG1OeUpsYks4b3FBdzFRN05FQWdrOV9MNjJsek41NkFSLVc2R1Z2SE4K
LWNQYmlBVUZTamlOa1hMcVlhb05LZyJ9"
,
        "signature": "
j7z3NGdEJXaDvgu5oQqbHmX5ko0m89gp4-ksjvIpoBCiTyxip-mMQLMKF94WrAJX
icP4CBhKoVAR5W-BHtruTfw1P43TxSZKjtMF31YNtzZ0G5wdJqS0ETWOWyFSIiA2
332qhbE3ar6yO9nLLa3ak2LjiYtPb4vVdzlqd6JxtrfP-x58cuCuPTtttqyBWDDq
8yETp8N3gTvqxSf09M6Sx-SiMBoryV1qnT5Lgq2SaC7Qm6LhNkc2T_pkJVZXRHyu
3cceGVn1o1m0MmFJ7-vSlFQzjuynQWgCzD33kzHdg0KlebAqmCq4OzjDIOnpXJmA
zcCbeUj_0XdOhN1hRrbFWg"
}]}}
~~~~

The Device Profile is signed using the Device Signing Key:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBAMF-X7YKI-KNCLB-HGRZI-MNS6R-4EYNE",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJBTUYt
WDdZS0ktS05DTEItSEdSWkktTU5TNlItNEVZTkUiLAogICAgIk5hbWVzIjogWyJE
...
S1EzYVNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MBAMF-X7YKI-KNCLB-HGRZI-MNS6R-4EYNE"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmtPWlp2X0RTNUI4QjNsMjVM
dkl5R0c3VG1OeUpsYks4b3FBdzFRN05FQWdrOV9MNjJsek41NkFSLVc2R1Z2SE4K
LWNQYmlBVUZTamlOa1hMcVlhb05LZyJ9"
,
          "signature": "
j7z3NGdEJXaDvgu5oQqbHmX5ko0m89gp4-ksjvIpoBCiTyxip-mMQLMKF94WrAJX
icP4CBhKoVAR5W-BHtruTfw1P43TxSZKjtMF31YNtzZ0G5wdJqS0ETWOWyFSIiA2
332qhbE3ar6yO9nLLa3ak2LjiYtPb4vVdzlqd6JxtrfP-x58cuCuPTtttqyBWDDq
8yETp8N3gTvqxSf09M6Sx-SiMBoryV1qnT5Lgq2SaC7Qm6LhNkc2T_pkJVZXRHyu
3cceGVn1o1m0MmFJ7-vSlFQzjuynQWgCzD33kzHdg0KlebAqmCq4OzjDIOnpXJmA
zcCbeUj_0XdOhN1hRrbFWg"
}]}}}
~~~~

A personal profile would typically contain at least one application
when first created. For the sake of demonstration, we will do this later.

The personal profile thus consists of the master profile and 
the device profile:

~~~~
{
  "PersonalProfile": {
    "Identifier": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
    "SignedMasterProfile": {
      "Identifier": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJNYXN0ZXJQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJWNjMt
R0RFTDMtN003V1QtTDRTMkctU0Q2T1UtSlEyWUYiLAogICAgIk1hc3RlclNpZ25h
...
QiJ9fX1dfX0"
,
        "signatures": [{
            "header": {
              "kid": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm1saGIxY1RxTHNaUDUzYXF4
QW9EbnNPaUktaS1jZmZZbzc0aW5kazItdTRBS3NWeDFFY1FCOGpIX0p3YkZJSE4K
SmhCMjJDaTEtZDFPSUYydFNOTXExQSJ9"
,
            "signature": "
fnhC55U5fXEFSUa8W1bHcxSdcHDD3GIjyPlfrEW3ygz9_4Z1qqm5b8eCkOul8cni
33y3hMm0l6wX0hbzYK1m4Ii3ZhhvP3-aq16mkBlwJA1xmb8mMGSCFwndjbnvWM58
BbNMAyJTAPwd4V0_RcmSvE_0t14BqHF5zqZxtXPAbp5Qq8wVEG0QtDZi0U7nQm_M
BcZrYbCCNKGrPdFyosZ14ccuUeMPp5udFadmCtVfVzm7dGaBACrdDvPv7JAsia3h
BLXKYAno_L5y_Tylrs00ul6SA10uFlT5qzb_QA48Hc9AyNALBg4lVHOAUKxz0gns
vgcYAka9Au21-RJGMlXkVQ"
}]}},
    "Devices": [{
        "Identifier": "MBAMF-X7YKI-KNCLB-HGRZI-MNS6R-4EYNE",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJBTUYt
WDdZS0ktS05DTEItSEdSWkktTU5TNlItNEVZTkUiLAogICAgIk5hbWVzIjogWyJE
...
S1EzYVNRIiwKICAgICAgICAgICJlIjogIgpBUUFCIn19fX19"
,
          "signatures": [{
              "header": {
                "kid": "MBAMF-X7YKI-KNCLB-HGRZI-MNS6R-4EYNE"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmtPWlp2X0RTNUI4QjNsMjVM
dkl5R0c3VG1OeUpsYks4b3FBdzFRN05FQWdrOV9MNjJsek41NkFSLVc2R1Z2SE4K
LWNQYmlBVUZTamlOa1hMcVlhb05LZyJ9"
,
              "signature": "
j7z3NGdEJXaDvgu5oQqbHmX5ko0m89gp4-ksjvIpoBCiTyxip-mMQLMKF94WrAJX
icP4CBhKoVAR5W-BHtruTfw1P43TxSZKjtMF31YNtzZ0G5wdJqS0ETWOWyFSIiA2
332qhbE3ar6yO9nLLa3ak2LjiYtPb4vVdzlqd6JxtrfP-x58cuCuPTtttqyBWDDq
8yETp8N3gTvqxSf09M6Sx-SiMBoryV1qnT5Lgq2SaC7Qm6LhNkc2T_pkJVZXRHyu
3cceGVn1o1m0MmFJ7-vSlFQzjuynQWgCzD33kzHdg0KlebAqmCq4OzjDIOnpXJmA
zcCbeUj_0XdOhN1hRrbFWg"
}]}}],
    "Applications": []}}
~~~~

The personal profile is then signed using the Online Signing Key:


~~~~
{
  "SignedPersonalProfile": {
    "Identifier": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlY2
My1HREVMMy03TTdXVC1MNFMyRy1TRDZPVS1KUTJZRiIsCiAgICAiU2lnbmVkTWFz
...
aW9ucyI6IFtdfX0"
,
      "signatures": [{
          "header": {
            "kid": "MBJTA-KAQ4D-NYXOI-ZRXYN-FVF2G-Q2FDI"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClN4cVY0S0lvZy13aHk0S080
SFhXWlowN2VBM2tnZlBHVmc5YUoySjlrQURHZTBIREhtYWNUajJycGV0bVloUGYK
QldKYk5DSG9vdktFQ1ZpR1o0RVkyQSJ9"
,
          "signature": "
ieTIfcjqtbmMiuLZl2KFwZOUMLAJzvJTfyhPRbOKr7ArIc06Y29XBVBAKOOUSZ-p
8a13BeuatguLPu8UzoMFaVgE1ABeTgVPM2_tAIHqfxGm5aTTLwwcL7R1IHNNh5_e
Tlq3k2FEtbFYY0EdYSmMJ6N7JCmxXwEkzvrT4gGdNpzAnmYGyYOG5c4dvVL_hIxu
7Kk57D1VCVnySX_8phx882rUcpaZ-cqCZdxXBKL_oUqvpThQ_G6QUxogKTNHOe66
Bzve2alCgRZ60fHfR_j2fu5cW7_DiiPp8Iiy0T8h42dSek_QVw77_psZqq3D3fmP
LS-6npLlcd1OF3gjCEsuYA"
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
        "Identifier": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlY2
My1HREVMMy03TTdXVC1MNFMyRy1TRDZPVS1KUTJZRiIsCiAgICAiU2lnbmVkTWFz
...
aW9ucyI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MBJTA-KAQ4D-NYXOI-ZRXYN-FVF2G-Q2FDI"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClN4cVY0S0lvZy13aHk0S080
SFhXWlowN2VBM2tnZlBHVmc5YUoySjlrQURHZTBIREhtYWNUajJycGV0bVloUGYK
QldKYk5DSG9vdktFQ1ZpR1o0RVkyQSJ9"
,
              "signature": "
ieTIfcjqtbmMiuLZl2KFwZOUMLAJzvJTfyhPRbOKr7ArIc06Y29XBVBAKOOUSZ-p
8a13BeuatguLPu8UzoMFaVgE1ABeTgVPM2_tAIHqfxGm5aTTLwwcL7R1IHNNh5_e
Tlq3k2FEtbFYY0EdYSmMJ6N7JCmxXwEkzvrT4gGdNpzAnmYGyYOG5c4dvVL_hIxu
7Kk57D1VCVnySX_8phx882rUcpaZ-cqCZdxXBKL_oUqvpThQ_G6QUxogKTNHOe66
Bzve2alCgRZ60fHfR_j2fu5cW7_DiiPp8Iiy0T8h42dSek_QVw77_psZqq3D3fmP
LS-6npLlcd1OF3gjCEsuYA"
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
    "Identifier": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
    "Names": ["Default"],
    "Description": "Unknown",
    "DeviceSignatureKey": {
      "UDF": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
          "n": "
tvNjyBAjhzD6r9oOhxADc0VvN83CSfB8gRJK5jqeJgX7tAOXhI1rGJS5K8H0hY0c
W-IqMMYUzy7rCc0ciisbTpPhdKKFvkxx5UOyrEBce2drHsAcflGs8BhmkexDel_V
iSK8UHC5rt0z76FBfMpSOC8yqXAxYY6Rt1Jk2NX9D-5m9LaaKWU3QPf_tV2RI2nB
Rt3Q1o3J02I3fzlNs_4pHgvCTaKpw01SOoM0pYHr19_IVkbfoPZXAvKcdvgOqUtN
CkAiQO4Y4rCnQjZatRzRfcftwpAMA9U8U5Evju684cevDNBrR05kR55m8S7p5Sxa
xGSRkpHegBHJhQrUWVO_RQ"
,
          "e": "
AQAB"
}}},
    "DeviceAuthenticationKey": {
      "UDF": "MCTQT-GL3QX-HNKEQ-VVXSP-4KFCD-DXPDD",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MCTQT-GL3QX-HNKEQ-VVXSP-4KFCD-DXPDD",
          "n": "
8YkFMAAF_nLycGGJwGDCn-BUVzHAhBj6DjLLFdkOiG4-8LLeHiSCVa0KJvtsORKR
tkMI7NBqKM1szbiKOfD_ALw4mkzMRgimz0l5_ENuzuGfSqO3DgWKIprZvm1bHS2e
e6BpccE1qJSvBEaMBWNWJU_PtGv_RGsL0lI-QqF8OL25OBjjZ40gJuBhI8Wjm6vC
qcRM68_k0SMpGkGYb_nKDt6embOTVOxi3SowkJohgvIxChiDRkywyjZrOd6zGAiE
Y8ZY-KAGhqvSktj0-EDwRYKS_zMirBV3pUpOd39uL5iz4xvQNzn7REnUUpKza5RS
fC8_6C0B4aUDF69Sc_NIoQ"
,
          "e": "
AQAB"
}}},
    "DeviceEncryptiontionKey": {
      "UDF": "MANMA-EHESQ-XBYRV-VYPKH-T37E4-6GPXO",
      "PublicParameters": {
        "PublicKeyRSA": {
          "kid": "MANMA-EHESQ-XBYRV-VYPKH-T37E4-6GPXO",
          "n": "
3aKA_TGeR8FH9346zaYuUy98apgDjw3BTw-Wy_FDn0ubdkH0-Z5jfDO4ML4f4NqX
jWxxmD2VWve9EpdEjeHuMN3ARR8cf9QZlFK3b1p_dk85IxvlQOdc16ywWipkB8v6
tHVs0uW0aURG1xlawjHHHSbMjnRdOhP9o10y-beDhx2CpN5YFKPS6nX3dJrItBGV
3zfbB-J8oAnbkcebp4_IytHouPSkFWzR5g82qlCMFxlD4zY8Ms4LLovbMRj-jwVI
gtzwFeFAy9isGJ__DsTDOBnGDdz_3h11NZMLBxJc5iY3rY6GEr6dmtWbqP0yrqih
-ARIpaTfIz9vIk-ZlIAMTQ"
,
          "e": "
AQAB"
}}}}}
~~~~

The device profile is then signed:

~~~~
{
  "SignedDeviceProfile": {
    "Identifier": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
    "SignedData": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJEZXZpY2VQcm9maWxlIjogewogICAgIklkZW50aWZpZXIiOiAiTUJJSDUt
M0Y1WVktR09OUVAtUU9CQ0YtQlZUN0YtTjVGTTIiLAogICAgIk5hbWVzIjogWyJE
...
ICAgICAgICAgImUiOiAiCkFRQUIifX19fX0"
,
      "signatures": [{
          "header": {
            "kid": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCllzLUExSGFDZWY5N2g3bDU3
V1dBY21CTFZObF83SGFQU1NMMk1GeVV4Z1NGZGtWcEFWWmhvaFZIbzN6ZHA5MTQK
bEx0MnJCejlNclJET3U5c3ZGdk9jdyJ9"
,
          "signature": "
M0UdFs9ABjMjjGSU9nGrvneDFoBLVaqBBQLlzacPHQKQV_7TUj4IfU3lBkbImR01
pcV4zkCijK6CFxGVGaG93y-_UTJ___IrEuXv6CBEzF8vnMMx73gbhXxQjUrGAXjs
B9LRrXUIduufxVKKFF_tPbRxmP6lWpKkGcodWX6hO13m-oReyE3Ksi5_4uYPPlUB
csJtROCvts4KT75_WBhh2hA2_vzWKQnj_TzTAmmwq-0KPve-WbyzwpujBI3219o9
6h_x_-XaQnZXFe-jo5zA_jF7e81RMQ4DgsIG6ax_l8_-uPvdyiPqKTdVPdgrGZUU
SnLUvvD5K56swO54YaI5Iw"
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
          "Identifier": "MBV63-GDEL3-7M7WT-L4S2G-SD6OU-JQ2YF",
          "SignedData": {
            "unprotected": {
              "dig": "S512"},
            "payload": "
ewogICJQZXJzb25hbFByb2ZpbGUiOiB7CiAgICAiSWRlbnRpZmllciI6ICJNQlY2
My1HREVMMy03TTdXVC1MNFMyRy1TRDZPVS1KUTJZRiIsCiAgICAiU2lnbmVkTWFz
...
aW9ucyI6IFtdfX0"
,
            "signatures": [{
                "header": {
                  "kid": "MBJTA-KAQ4D-NYXOI-ZRXYN-FVF2G-Q2FDI"},
                "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClN4cVY0S0lvZy13aHk0S080
SFhXWlowN2VBM2tnZlBHVmc5YUoySjlrQURHZTBIREhtYWNUajJycGV0bVloUGYK
QldKYk5DSG9vdktFQ1ZpR1o0RVkyQSJ9"
,
                "signature": "
ieTIfcjqtbmMiuLZl2KFwZOUMLAJzvJTfyhPRbOKr7ArIc06Y29XBVBAKOOUSZ-p
8a13BeuatguLPu8UzoMFaVgE1ABeTgVPM2_tAIHqfxGm5aTTLwwcL7R1IHNNh5_e
Tlq3k2FEtbFYY0EdYSmMJ6N7JCmxXwEkzvrT4gGdNpzAnmYGyYOG5c4dvVL_hIxu
7Kk57D1VCVnySX_8phx882rUcpaZ-cqCZdxXBKL_oUqvpThQ_G6QUxogKTNHOe66
Bzve2alCgRZ60fHfR_j2fu5cW7_DiiPp8Iiy0T8h42dSek_QVw77_psZqq3D3fmP
LS-6npLlcd1OF3gjCEsuYA"
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
      "Identifier": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUJW
NjMtR0RFTDMtN003V1QtTDRTMkctU0Q2T1UtSlEyWUYiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
        "signatures": [{
            "header": {
              "kid": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmROVVAwblc5WktYcENfX1JI
aDRPcWRYQllSMEh4aXA4WngxQkxiZURadDVvaXZ2RGV6WWlnV3VRZzBVbkE1WnAK
S0dIUzVNX0lISmpVQ3ZYUFdWMXg3dyJ9"
,
            "signature": "
rzc_V9qgZdIEnXTA4yyTF43G3Hb2LlEbpnxgC15zrIudqvlDtM5xixVbgDf35jqI
f62jmwfs6tUi2dWg-Ngr6n_myHgw3XogM9vh03BoVYG_WXXU2wMZmdT334u9reqM
oSWnixyOsscxriUGPkU7k_-Yl-mI-WGYzRxdWQNuMpjXhhZBT2LjL_j5Ez0KGE4G
L6cyxtPGFGlv3X-LPDzVhXMWNN_pZlVrTsX6WgnfbyhL5GVNCsJrSeRHOrj1CZnM
m9Bf4HW64BqSZdIc4wSw4GDGJ_odfbqYOdqg-wf7S_O6-ypSIfD2Ibz-7lLZ9elR
QkIEUAPgUAdRpsk8XT1gpg"
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
        "Identifier": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUJW
NjMtR0RFTDMtN003V1QtTDRTMkctU0Q2T1UtSlEyWUYiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmROVVAwblc5WktYcENfX1JI
aDRPcWRYQllSMEh4aXA4WngxQkxiZURadDVvaXZ2RGV6WWlnV3VRZzBVbkE1WnAK
S0dIUzVNX0lISmpVQ3ZYUFdWMXg3dyJ9"
,
              "signature": "
rzc_V9qgZdIEnXTA4yyTF43G3Hb2LlEbpnxgC15zrIudqvlDtM5xixVbgDf35jqI
f62jmwfs6tUi2dWg-Ngr6n_myHgw3XogM9vh03BoVYG_WXXU2wMZmdT334u9reqM
oSWnixyOsscxriUGPkU7k_-Yl-mI-WGYzRxdWQNuMpjXhhZBT2LjL_j5Ez0KGE4G
L6cyxtPGFGlv3X-LPDzVhXMWNN_pZlVrTsX6WgnfbyhL5GVNCsJrSeRHOrj1CZnM
m9Bf4HW64BqSZdIc4wSw4GDGJ_odfbqYOdqg-wf7S_O6-ypSIfD2Ibz-7lLZ9elR
QkIEUAPgUAdRpsk8XT1gpg"
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
        "Identifier": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
        "SignedData": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJDb25uZWN0aW9uUmVxdWVzdCI6IHsKICAgICJQYXJlbnRVREYiOiAiTUJW
NjMtR0RFTDMtN003V1QtTDRTMkctU0Q2T1UtSlEyWUYiLAogICAgIkRldmljZSI6
...
fX0sCiAgICAiRGV2aWNlRGF0YSI6IFtdfX0"
,
          "signatures": [{
              "header": {
                "kid": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmROVVAwblc5WktYcENfX1JI
aDRPcWRYQllSMEh4aXA4WngxQkxiZURadDVvaXZ2RGV6WWlnV3VRZzBVbkE1WnAK
S0dIUzVNX0lISmpVQ3ZYUFdWMXg3dyJ9"
,
              "signature": "
rzc_V9qgZdIEnXTA4yyTF43G3Hb2LlEbpnxgC15zrIudqvlDtM5xixVbgDf35jqI
f62jmwfs6tUi2dWg-Ngr6n_myHgw3XogM9vh03BoVYG_WXXU2wMZmdT334u9reqM
oSWnixyOsscxriUGPkU7k_-Yl-mI-WGYzRxdWQNuMpjXhhZBT2LjL_j5Ez0KGE4G
L6cyxtPGFGlv3X-LPDzVhXMWNN_pZlVrTsX6WgnfbyhL5GVNCsJrSeRHOrj1CZnM
m9Bf4HW64BqSZdIc4wSw4GDGJ_odfbqYOdqg-wf7S_O6-ypSIfD2Ibz-7lLZ9elR
QkIEUAPgUAdRpsk8XT1gpg"
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
      "Identifier": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJJSDUtM0Y1WVktR09OUVAtUU9CQ0YtQlZUN0YtTjVG
...
ZmIKVzROS1JqLVZ3MEJ0TGpoUGxVVjJQQSJ9XX19fX19"
,
        "signatures": [{
            "header": {
              "kid": "MBJTA-KAQ4D-NYXOI-ZRXYN-FVF2G-Q2FDI"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClJWTHduQU9KOEZHZzF2OGhm
LVJXRGk5WVRoSUFuVFlub2FnT3BvclUtajBpcGxXUUwzc2szOExwZWxUQTk1NkcK
c1NOZktSVWE0MTlyYWotOWRiMUNSQSJ9"
,
            "signature": "
Y--h_u8hUKKoqICff_peHC84fa5o4qeRS8V9WmBsYuZ3ptD33eMDwr-xir4mf-DD
N917vdpf22indgMLx6p6ZMHPqL2wqus1kL2LiQjjvsMcFdbzxvT8eZhQ1Ku0RK1n
qFizq3igA024kwusv9uiRxliQTxkJ8JgO23ihWFIiDi6Ph1Dmmtd_cMsCY83mjrR
3agIJLxiyr0ZwENE1mCbLXvyjaEGBhcsOVPlkl9PeSqNkaFVzajhffBDsJy5TiDD
MU5Ng2DFhMwXUs6KbMFSGhCwsSySIj1ktLEeTjNkhAbNjNCIZ4YGqXHqXc7bs6U5
OoySAeESVmcqvIAMTGFkAw"
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
    "DeviceID": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2"}}
~~~~


If the response is that the connection status has not changed,
the service MAY return a response that specifies a minimum 
retry interval. In this case however there is a connection result: 


~~~~
{
  "ConnectStatusResponse": {
    "Result": {
      "Identifier": "MBIH5-3F5YY-GONQP-QOBCF-BVT7F-N5FM2",
      "SignedData": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJDb25uZWN0aW9uUmVzdWx0IjogewogICAgIkRldmljZSI6IHsKICAgICAg
IklkZW50aWZpZXIiOiAiTUJJSDUtM0Y1WVktR09OUVAtUU9CQ0YtQlZUN0YtTjVG
...
ZmIKVzROS1JqLVZ3MEJ0TGpoUGxVVjJQQSJ9XX19fX19"
,
        "signatures": [{
            "header": {
              "kid": "MBJTA-KAQ4D-NYXOI-ZRXYN-FVF2G-Q2FDI"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiClJWTHduQU9KOEZHZzF2OGhm
LVJXRGk5WVRoSUFuVFlub2FnT3BvclUtajBpcGxXUUwzc2szOExwZWxUQTk1NkcK
c1NOZktSVWE0MTlyYWotOWRiMUNSQSJ9"
,
            "signature": "
Y--h_u8hUKKoqICff_peHC84fa5o4qeRS8V9WmBsYuZ3ptD33eMDwr-xir4mf-DD
N917vdpf22indgMLx6p6ZMHPqL2wqus1kL2LiQjjvsMcFdbzxvT8eZhQ1Ku0RK1n
qFizq3igA024kwusv9uiRxliQTxkJ8JgO23ihWFIiDi6Ph1Dmmtd_cMsCY83mjrR
3agIJLxiyr0ZwENE1mCbLXvyjaEGBhcsOVPlkl9PeSqNkaFVzajhffBDsJy5TiDD
MU5Ng2DFhMwXUs6KbMFSGhCwsSySIj1ktLEeTjNkhAbNjNCIZ4YGqXHqXc7bs6U5
OoySAeESVmcqvIAMTGFkAw"
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


