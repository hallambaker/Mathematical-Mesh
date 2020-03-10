
<h1>Using Recryption

Use of recryption is essentially the same as the use of public key encryption with the
proviso that instead of one private key being sufficient to decrypt the message,
two are required. For the sake of convenience, these are refered to as the recryption
key (held by the key service) and the decryption key (held by the end user).

<h2>Creating a Recryption Group

A recryption group consists of 

<ul>
<li>A public key pair for an encryption algorithm that supports
recryption
<li>An address in &<user>@&<domain> format that specifies the Key service and 
user account.
<li>A set of user entries.
</ul>

To create a recryption group with the recryption tool, Alice enters:

~~~~
recrypt create recrypt@example.com alice@example.com
~~~~

A recryption group is created and registered to the Key service. A new public key pair 
is generated for the group.
The list of user
entries consists of an entry for Alice as the administrator of the group. Although
Alice has custody of the corresponding decryption key and can decrypt messages
without the use of the recryption service, she might not want to provision this key
to every one of her devices. So she creates a recryption user entry for herself.

The client requests creation of the recryption group at the key service. The request
is authenticated under an authentication key connected to Alice's account for use in 
recryption:



~~~~
POST /.well-known/recrypt/HTTP/1.1
Host: example.com
Content-Length: 12521

{
  "CreateGroupRequest": {
    "RecryptionGroup": {
      "GroupName": "recrypt@example.com",
      "Master": {
        "Identifier": "MBWMZ-A7GMP-GFSEZ-I5RRR-NZ3G2-I2VCN",
        "MasterSignatureKey": {
          "UDF": "MBWMZ-A7GMP-GFSEZ-I5RRR-NZ3G2-I2VCN",
          "X509Certificate": "
MIIFXDCCBESgAwIBAgIQUfJWmPiBlYNuRt3tjZn60jANBgkqhkiG9w0BAQ0FADAu
MSwwKgYDVQQDFiNNQldNWi1BN0dNUC1HRlNFWi1JNVJSUi1OWjNHMi1JMlZDTjAe
Fw0xNzExMDgxMjAwMDFaFw0zNzExMjQwMjQ4MDdaMC4xLDAqBgNVBAMWI01CV01a
LUE3R01QLUdGU0VaLUk1UlJSLU5aM0cyLUkyVkNOMIIBIDANBgkqhkiG9w0BAQEF
AAMPADCCAQoCggEBAKD48F46wI_i6gmkmlpQg97kyrK4wyLbz-5lqObb7XwN2lfx
Qqz4X3gLVpHuQaQiQa9R2y4nfViO3CDzexuRWBQRAhcgJS-jphvk_IK6qRcI-rXl
PF_yp4mW9Ja7Exd0gD0-xp8_UB84HzroRRlvaRqPYMtntjt4B2xgubdbY73zHgXQ
1Qef45nCw4BahnZlWa-xtl19H-LVb8Yy-8wqC_kTtvVt2jskGP4N9wevo5QYOWDr
FOM-F3uB7bt3T5P8ZR7mprXyYVFusSzxnwpKsvPLzgloRLzsN79NdEh7c2KR7S1k
gHEmSY1I1brHN3YB_Si4VIEGspmpiWdLGPfWRRUCAwEAAaOCAnYwggJyMIIBNwYD
VR0jBIIBLjCCASqAggEmMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA
oPjwXjrAj-LqCaSaWlCD3uTKsrjDItvP7mWo5tvtfA3aV_FCrPhfeAtWke5BpCJB
r1HbLid9WI7cIPN7G5FYFBECFyAlL6OmG-T8grqpFwj6teU8X_KniZb0lrsTF3SA
PT7Gnz9QHzgfOuhFGW9pGo9gy2e2O3gHbGC5t1tjvfMeBdDVB5_jmcLDgFqGdmVZ
r7G2XX0f4tVvxjL7zCoL-RO29W3aOyQY_g33B6-jlBg5YOsU4z4Xe4Htu3dPk_xl
HuamtfJhUW6xLPGfCkqy88vOCWhEvOw3v010SHtzYpHtLWSAcSZJjUjVusc3dgH9
KLhUgQaymamJZ0sY99ZFFQIDAQABMIIBMwYDVR0OBIIBKgSCASYwggEiMA0GCSqG
SIb3DQEBAQUAA4IBDwAwggEKAoIBAQCg-PBeOsCP4uoJpJpaUIPe5MqyuMMi28_u
Zajm2-18DdpX8UKs-F94C1aR7kGkIkGvUdsuJ31Yjtwg83sbkVgUEQIXICUvo6Yb
5PyCuqkXCPq15Txf8qeJlvSWuxMXdIA9PsafP1AfOB866EUZb2kaj2DLZ7Y7eAds
YLm3W2O98x4F0NUHn-OZwsOAWoZ2ZVmvsbZdfR_i1W_GMvvMKgv5E7b1bdo7JBj-
DfcHr6OUGDlg6xTjPhd7ge27d0-T_GUe5qa18mFRbrEs8Z8KSrLzy84JaES87De_
TXRIe3Nike0tZIBxJkmNSNW6xzd2Af0ouFSBBrKZqYlnSxj31kUVAgMBAAEwDQYJ
KoZIhvcNAQENBQADggEBAAwyqi3PvVb2BO9DTsshgOcCOx8KuAfVxds77Kbl6g1P
dm84Bs3eM8BCchLAPomkza2xYawR1kSFVjXO0lqA6Bu2BumIJ6IIRc3c08fiVv74
pLYQ7BYDKtsmkAHtY16wAYgYU1LucpoEOHd9QcImj4RGnQte6Bbwn_VIPp2lmcfY
ihCPUggSZsWAjMPe5B51RsjAr6eQUR0WLdB0Vn4XYj9JCjXGqBDCqyEseV78_Dp3
46pDwOhHVIDoZvE1nnS4XkuTu9kg8AnauPZKcnu6doN_gUwpfnsAXywzeqNINwBk
mHGvIQB3Z3O5Fc9cgrHMSAJ3Su-Qo9rPCvm02-6A1NM",
          "PublicParameters": {
            "PublicKeyRSA": {
              "kid": "MBWMZ-A7GMP-GFSEZ-I5RRR-NZ3G2-I2VCN",
              "n": "
oPjwXjrAj-LqCaSaWlCD3uTKsrjDItvP7mWo5tvtfA3aV_FCrPhfeAtWke5BpCJB
r1HbLid9WI7cIPN7G5FYFBECFyAlL6OmG-T8grqpFwj6teU8X_KniZb0lrsTF3SA
PT7Gnz9QHzgfOuhFGW9pGo9gy2e2O3gHbGC5t1tjvfMeBdDVB5_jmcLDgFqGdmVZ
r7G2XX0f4tVvxjL7zCoL-RO29W3aOyQY_g33B6-jlBg5YOsU4z4Xe4Htu3dPk_xl
HuamtfJhUW6xLPGfCkqy88vOCWhEvOw3v010SHtzYpHtLWSAcSZJjUjVusc3dgH9
KLhUgQaymamJZ0sY99ZFFQ",
              "e": "
AQAB"}}},
        "MasterEscrowKeys": [{
            "UDF": "MAEYW-XMUJP-IWIPX-NND45-YHVRG-JMPUJ",
            "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAIfXe_wa1-2TDxAIWj6rB_UwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJXTVotQTdHTVAtR0ZTRVotSTVSUlItTlozRzItSTJWQ04w
HhcNMTcxMTA4MTIwMDAxWhcNMzcxMTI0MDI0ODA4WjAuMSwwKgYDVQQDFiNNQUVZ
Vy1YTVVKUC1JV0lQWC1OTkQ0NS1ZSFZSRy1KTVBVSjCCASAwDQYJKoZIhvcNAQEB
BQADDwAwggEKAoIBAQCtzWGkbAIOQ9G3KcAG9RVpm_18_RxSd0wq2D3IFI0wK9Vu
c0_WXfheQSgQBJT_UAMpx7m46hVzqtxO8iXMW_UPbuimQaOI-iQqcbXna7aBeGmR
-zf_i_SQF0JVCZEwuxgln-keMCUlhZh4PWHVIX7EGv_5JaL6a3jPuGU33riVyrsB
u1N7Li-L4FmlvP6zkpe0u6joH9YKader7DuKmByS7nRBLDO5BSfZ7aWyVqQZfMvw
BOKykCxSFwdmsfZUac6VQNBDL2p11AXdlqnrK5j7VGR-smaLrdOfXZMs0FNVnYc6
bcouh-LcA1kpk_szvbYoT06rCVXNpHYfSovBjcNpAgMBAAGjggJ2MIICcjCCATcG
A1UdIwSCAS4wggEqgIIBJjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEB
AKD48F46wI_i6gmkmlpQg97kyrK4wyLbz-5lqObb7XwN2lfxQqz4X3gLVpHuQaQi
Qa9R2y4nfViO3CDzexuRWBQRAhcgJS-jphvk_IK6qRcI-rXlPF_yp4mW9Ja7Exd0
gD0-xp8_UB84HzroRRlvaRqPYMtntjt4B2xgubdbY73zHgXQ1Qef45nCw4BahnZl
Wa-xtl19H-LVb8Yy-8wqC_kTtvVt2jskGP4N9wevo5QYOWDrFOM-F3uB7bt3T5P8
ZR7mprXyYVFusSzxnwpKsvPLzgloRLzsN79NdEh7c2KR7S1kgHEmSY1I1brHN3YB
_Si4VIEGspmpiWdLGPfWRRUCAwEAATCCATMGA1UdDgSCASoEggEmMIIBIjANBgkq
hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEArc1hpGwCDkPRtynABvUVaZv9fP0cUndM
Ktg9yBSNMCvVbnNP1l34XkEoEASU_1ADKce5uOoVc6rcTvIlzFv1D27opkGjiPok
KnG152u2gXhpkfs3_4v0kBdCVQmRMLsYJZ_pHjAlJYWYeD1h1SF-xBr_-SWi-mt4
z7hlN964lcq7AbtTey4vi-BZpbz-s5KXtLuo6B_WCmnXq-w7ipgcku50QSwzuQUn
2e2lslakGXzL8ATispAsUhcHZrH2VGnOlUDQQy9qddQF3Zap6yuY-1RkfrJmi63T
n12TLNBTVZ2HOm3KLofi3ANZKZP7M722KE9OqwlVzaR2H0qLwY3DaQIDAQABMA0G
CSqGSIb3DQEBDQUAA4IBAQB9o8-ib11GUwMrv0dbyMg0onhdx4Z_ZcGV5ptInNwt
0bXN9eqMcVZ6MnSv79Cg2bfvSd_FbAHnV-Zd3pUQOl-iid7lM_XzkjkSMqHqErnT
E1k-jWR_zglJKqmxfIZpMuXs2MrxbsUve8ijtRhD5eaP58wAX7ERTHOjvttq0VPV
Z92cGaNV7tvKwj2SVHu9y0rSXbLpkAToJEpM1vFmHB-li7_Xhla3VCHYcdkwDAaG
Xv40yjIO6XtaGDmzfCem6h26igqub9lG4VfZ3u5ebIVWoj8CKsVzAt3QZ7TLWZ5P
dOieRUHei2j3zpKibSoP5sZzFBKOkQTVNZ9gPVk05obe",
            "PublicParameters": {
              "PublicKeyRSA": {
                "kid": "MAEYW-XMUJP-IWIPX-NND45-YHVRG-JMPUJ",
                "n": "
rc1hpGwCDkPRtynABvUVaZv9fP0cUndMKtg9yBSNMCvVbnNP1l34XkEoEASU_1AD
Kce5uOoVc6rcTvIlzFv1D27opkGjiPokKnG152u2gXhpkfs3_4v0kBdCVQmRMLsY
JZ_pHjAlJYWYeD1h1SF-xBr_-SWi-mt4z7hlN964lcq7AbtTey4vi-BZpbz-s5KX
tLuo6B_WCmnXq-w7ipgcku50QSwzuQUn2e2lslakGXzL8ATispAsUhcHZrH2VGnO
lUDQQy9qddQF3Zap6yuY-1RkfrJmi63Tn12TLNBTVZ2HOm3KLofi3ANZKZP7M722
KE9OqwlVzaR2H0qLwY3DaQ",
                "e": "
AQAB"}}}],
        "OnlineSignatureKeys": [{
            "UDF": "MD2WG-JIM5J-MUEEL-RMKZB-2HLLZ-CBPSN",
            "X509Certificate": "
MIIFXTCCBEWgAwIBAgIRAJe48flw5DPuc1RNnhud4LYwDQYJKoZIhvcNAQENBQAw
LjEsMCoGA1UEAxYjTUJXTVotQTdHTVAtR0ZTRVotSTVSUlItTlozRzItSTJWQ04w
HhcNMTcxMTA4MTIwMDAxWhcNMzcxMTI0MDI0ODA4WjAuMSwwKgYDVQQDFiNNRDJX
Ry1KSU01Si1NVUVFTC1STUtaQi0ySExMWi1DQlBTTjCCASAwDQYJKoZIhvcNAQEB
BQADDwAwggEKAoIBAQDBEHyKY5_uENZVEagHv0oYDss_K2mfz5aKeF0gEkeies4Y
vEDIALLxnTXGbf3jX9EtjQa9ZqDCwvARmqVsiowigrKb7dqbJ_qCgKkYV9wIYo8p
XE-d_jrHlLIH0CXBKIrDq5MV1rY50wKxchiJI0Wdp1ETbA-aVopv13qOR8B-X_sl
ZP_ECsj8RVMX4tRFDrogFy3Cv-Fu7dVuaK-WNXtDTvwG6KcGYS25UUXxqp1l5Grb
732DO9wc8iC9kXCfVRU5AcGnKy4uaWIMmC710sFb7-krx8MTWE-Fd3sAdPEoAcHh
UWOi2nRD1ACne9E11cKateWlgzVnsdYUo5L9LFOhAgMBAAGjggJ2MIICcjCCATcG
A1UdIwSCAS4wggEqgIIBJjCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEB
AKD48F46wI_i6gmkmlpQg97kyrK4wyLbz-5lqObb7XwN2lfxQqz4X3gLVpHuQaQi
Qa9R2y4nfViO3CDzexuRWBQRAhcgJS-jphvk_IK6qRcI-rXlPF_yp4mW9Ja7Exd0
gD0-xp8_UB84HzroRRlvaRqPYMtntjt4B2xgubdbY73zHgXQ1Qef45nCw4BahnZl
Wa-xtl19H-LVb8Yy-8wqC_kTtvVt2jskGP4N9wevo5QYOWDrFOM-F3uB7bt3T5P8
ZR7mprXyYVFusSzxnwpKsvPLzgloRLzsN79NdEh7c2KR7S1kgHEmSY1I1brHN3YB
_Si4VIEGspmpiWdLGPfWRRUCAwEAATCCATMGA1UdDgSCASoEggEmMIIBIjANBgkq
hkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwRB8imOf7hDWVRGoB79KGA7LPytpn8-W
inhdIBJHonrOGLxAyACy8Z01xm3941_RLY0GvWagwsLwEZqlbIqMIoKym-3amyf6
goCpGFfcCGKPKVxPnf46x5SyB9AlwSiKw6uTFda2OdMCsXIYiSNFnadRE2wPmlaK
b9d6jkfAfl_7JWT_xArI_EVTF-LURQ66IBctwr_hbu3VbmivljV7Q078BuinBmEt
uVFF8aqdZeRq2-99gzvcHPIgvZFwn1UVOQHBpysuLmliDJgu9dLBW-_pK8fDE1hP
hXd7AHTxKAHB4VFjotp0Q9QAp3vRNdXCmrXlpYM1Z7HWFKOS_SxToQIDAQABMA0G
CSqGSIb3DQEBDQUAA4IBAQCdIZjvziLtxSlevxnBs4y7uieSD35YXiVxYBraIo6q
a31IZXsgBSQcyrLUcl8ENkbD3HMHbT6yjDqml_0exWqQ45DkehgwP-e0VduP5IYv
GHTCIRPF7GzI61ajm6DiRM5xw-GKkqeYS9y3q-JwPyuT673Wf-86L0hNftdsid38
M7rhe1ILqINigR0pdd5LIcRO3roqiVNxOO1Maz9_xKh1Pa05_ZNv-3Z2_UQOl2WG
M35QY3jZcqbkEA34IWDcfJrZ4t04pD-MUWfvfcaDz8g0Qe7sgQJmuTQI47UmgSmq
ipMeggBhSm3GxwkzoYi-YyTdmCHcRczo5DznvKVhWuT-",
            "PublicParameters": {
              "PublicKeyRSA": {
                "kid": "MD2WG-JIM5J-MUEEL-RMKZB-2HLLZ-CBPSN",
                "n": "
wRB8imOf7hDWVRGoB79KGA7LPytpn8-WinhdIBJHonrOGLxAyACy8Z01xm3941_R
LY0GvWagwsLwEZqlbIqMIoKym-3amyf6goCpGFfcCGKPKVxPnf46x5SyB9AlwSiK
w6uTFda2OdMCsXIYiSNFnadRE2wPmlaKb9d6jkfAfl_7JWT_xArI_EVTF-LURQ66
IBctwr_hbu3VbmivljV7Q078BuinBmEtuVFF8aqdZeRq2-99gzvcHPIgvZFwn1UV
OQHBpysuLmliDJgu9dLBW-_pK8fDE1hPhXd7AHTxKAHB4VFjotp0Q9QAp3vRNdXC
mrXlpYM1Z7HWFKOS_SxToQ",
                "e": "
AQAB"}}}]},
      "Members": [{
          "UDF": "MAGNR-IB6EU-AEGSN-LYRGP-FTKB4-FRW53",
          "RecryptUDF": "RDXBT-Q3NEW-ERHRA-V5RBB-VIS2P-RB36K",
          "Status": "Active",
          "Entries": [{
              "EncryptionKeyUDF": "MAKT6-DHL2R-XL4GQ-FIRW6-4DLMD-3U4LQ",
              "MemberKeyUDF": "MCEL2-KO3TO-KV645-DTLIN-PEONH-7YERD",
              "RecryptionKey": {
                "PrivateKeyDH": {
                  "kid": "MBBSK-AOB3X-GZXD3-IADJW-GCRYW-WK5CD",
                  "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
                  "Public": "
mCCQganzKJN-QqCVmasTP7GxWVzd2orNVSgoXTAqw57suMY90-Xs6LtEBqbkSrwj
XodOcF-rD1Dte2UuR5wUcHVBVfL2mnIFJKQHRj97OUgcAZaToQIQLB8dmpN9aPSb
jX4WF0dOrgIAqlVvOzA0O38K6WDGpLxV6EqwpQHmPv3GWPz935GcAwJq_NNwKlGo
QII5nPo7thNv7g-8t4--YPJpeHl1BOqV7P6biSciUN7pxwjazqFbj_cZSOPIjfPz
3a88v46HffcCDQf4d37A-TPeHTSGQBLyNfTx78pge_DJLNxNqoIpGZMZaFx7rDSC
Jck7WLWC93GD64GuojvUDA",
                  "Private": "
hB7LUdh3AP_jWVJ1GwgkHVwSpcBY_oek3KiTA2XwQoBMHiH1EgioGfeMKKn_k-uq
AqqEP_FTe2Bmyk4AL3uISTgAmj5lUXaP8IpiXoGjwr7u5IIJUL746ZKvf6JyTQce
x5YeiNvq7XHY4exHbAqu345VFA8yyWcccNlwCYJ-abVG14BjpcbZJq1P-2QTOAZ9
gh8h67dtj5NzJldUiJCVMCgX6Y-vyhwkwXNJy5JwAC-7n2q97vhgZnqk9hVzaj5M
1Mj-i8DQVZlZeQQ7GY7bEMJGA5RDGVvT0QxkcIHd1L4wQZdIfE5OMQvzOfJSs4Mz
12hhX2mPDpoZLQEUoOSQlQA"}},
              "DecryptionKey": {
                "protected": "
ewogICJlbmMiOiAiQTI1NkNCQyJ9",
                "iv": "
s0zYech-noDw6ClRUvDl9Q",
                "recipients": [{
                    "Header": {
                      "alg": "RSA-OAEP",
                      "kid": "MCEL2-KO3TO-KV645-DTLIN-PEONH-7YERD"},
                    "encrypted_key": "
VWHtVi2ATWVE1mIx9tqtPnqtX1oaadTzAJfWR8DfgckCFw3l_mOKpaRFzifk0ftq
3UxwUGirKTV3bjqEaQ2jQzTy17Knqu8-m5vkq8qpF4chRuTinLMwwfa6Wx8wBUfA
R7rGD2RFppyoBnlJXmmmmk39PCmzTBWp_F4XoT26GGY50Cb6D7qYk2I-7sUQP4_A
Vr88dq7eJSjb4Ceenv6-iRo7upNXANWLN8QDDjFOyzXKN0xbPPnGN1iOTU_cAw-x
5CzjD3VivfhjAAEMjcA55R0rRLzmVgwJT69vPixXRt_YOpfsz8_xCZEI1mgKfwqY
BaFJgG_w6ODMa-x2mh9GxA"}],
                "ciphertext": "
ZzO-hBIfY_Uazk-mWSD3coRXSIyx57nPQNy0Orhh5oYv7smgoBbLxStRisTQI9g5
xvUeqhxvuSjmocJMw8o2twGpRerwhx3a9Jj-WS7mHT_UOma7jx9xcqc-IlpVmgXR
HY9IEGkFVYbTCK7eMHxcZ6QfNV8NVkdWZh6tcDu0sNRwZDZcGz--jEadGKOWGwnD
C-WDiwsCuJPs_9PA0eFCFKhc4xOzIG3PAVJNIyH6NxVac5MTQ_tlEY5TCy-0wQSS
tsr33YTqBfWgDylRoBOWyq2tUoxQBCh_8z068GwQiBkvSWZVhTcbR3t29fyrn-lI
QIijq18-2fwPlbJZdxIVZqEKHaKxx4EwBm49eJza8ScJ8r0EdNO4ZrQ2yvN2VhqL
2pZ6s3WI10stq7Ocw1kNwUDCqBXQ0Jy3S09phVM8jaKHwWt-6-kuOTpkaH3dFObp
xu805u8OTXvV2CebKGdhFe4qcapLOHk9x88aWN2A-sdvP9xcrh7j_XYMGkFCxbh2
fXdGwBjYaJ9CGKBvZFA-Qo_oFVAZa33Ea72rUaoVSiJ7yxJSJYcteK857NFOYu0C
kkudinlaSqPSE6joitPBPszcHzP2dss8U3MBvCOfPj64WSvZt6IVHNHuCF6WjC4y
yfdc27pWL0S9c3Zgh8yEg4Lr3b_PTVrPfS2EFC-KAzx601uDwZl3pgmiwiB126dT
-NB6qyuqTfEScHmhPjfSEh-x3wE33Pmx0qbL-Lso19KW1j0DpLLiNwq1P1dT6qZ-
fZKWoFHoDcVbXjb11iPIWdUnhSIOH8NAlTwop1vECDWS4VEW245BbB8Z-vl139Br
zc49xVX-4BobHaLmO_atzAWZE-FofYAG8dYK7R3jkZ-JdrefHFCo3Ph7kG7RRKUD
SPdOFEh1z6o0DbDXKeOhQOd2DqAp0oB_ORGA8ZBfZGfknpGVlWZ0C4fTDJLjevws
l2UV-Mmdtz8cp56Ep_8C0mhJdOe7NtQNN3ZcuwLblbi9TzfJLmfqFYgNiYNTKRGV
Ix0YatxNB8wg_SUosBbuL4Nw5V1d5hF0xmb0NpTiZrLrn-Rr1PBkSG7fhCYfMm4J
O2FSvATFNW5N5A3f3gn-mvlSxG8kNRBiUzrYQZhwhC5156NCjjwxLIJcWpHvDrNZ"}}]}],
      "CurrentEncryptionKey": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJSZWNyeXB0aW9uS2V5IjogewogICAgIkVuY3J5cHRpb25LZXkiOiB7CiAg
ICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlESCI6
IHsKICAgICAgICAgICJraWQiOiAiTUFLVDYtREhMMlItWEw0R1EtRklSVzYtNERM
TUQtM1U0TFEiLAogICAgICAgICAgIkRvbWFpbiI6ICIKWUU2Ym5xMU1sWDVvamFK
dG82UExQX1BFd0EiLAogICAgICAgICAgIlB1YmxpYyI6ICIKc2UtX25GaHI3RlVZ
YkxXcWpxZG1vaHh6SXF6aUEwcGlVUXFRMDVzQ0J2N0VJdElMMXRtOHZOekZmQUZr
V08wNgpBYm8weThybXdyaHphWkV4ZWwybnBZdUt4QnlxbllmWjVfNFdsa3FFWk9B
bzJLUWVqMXpEcEhzZWVENTZrYVNJCmlBS3dEMmNDcTZwYUpKbG9ObUZTTnJLRFlv
SHlRUHBpazcwNm5WelpMbGZCMjVocU9yQTZHOGZmYUg3WGFTd3AKYUhIY293anZG
eUl3MlhEMzFHV0RrdWpUSk9sZ3hrNS1UQW1PVm9aSkxVTkJoRHZlVk5iRFozQlhw
bzMtTU5YVAp6SEMzd0ZGWVVJR1l1WGpNUHhjdFBJTHQ3UkkycHpwSkcwQ0k1WUEx
N1c1OWx4enkwOG1WSlJ2STEwbmtNajdNClJIUndXVnBiWE56SEppdy1iUjBvZ1FB
In19fX19",
        "signatures": [{
            "header": {
              "kid": "MD2WG-JIM5J-MUEEL-RMKZB-2HLLZ-CBPSN"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjlXdTk2Szk4WnRacFJYTjdE
LVN6QktLZzlWNC04SERFdlZrUmJyTm5xY2JlZjd4d0dYblVMcXhKODZpTGMzM0cK
d3BsSlhlMXg2Y2txOGxMWnVwQnhlQSJ9",
            "signature": "
GU0MN3b29e-e_7F7CyugT2dEEN3nrunqaLWj7e1AKHyGSEzWwr84wFKBTnm_maOi
ykTFcmtUCC0CnjwJlseoJyo4hxfywH1FxWGmvBw5J4BnVa_RXseM7rLAuCwIj3gH
MJhZfOz_MVUAVp2zqvqS6bH_tLoS5dmhTM2SzkZvs8pzZEfU0PxSXl9_qkJVEIIH
DrDqK3SbRZknFlOvEX7n2IwhYmRXrBJZ9IVum0_mkG7RHOQQb2E53pvs9ngr-Xya
dslrhpWNd_AyQ9vbwH3mGBG9RaFUTArm6UqZ2D-yxUeH3jMegPikExK4JIUnhZ9x
9Uu7wG86uturHB14H-81wA"}]}}}}
~~~~


The service authenticates the request, determines if Alice is authorized to create 
new recryption groups and if these are satisfactory creates the group entry,
returns the result of the transaction:



~~~~
HTTP/1.1 200 OK
Date: Thu 09 Nov 2017 02:48:09
Content-Length: 109

{
  "CreateGroupResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~



<h2>Encrypting files

At this point, anyone who knows the recryption key can start sending encrypted messages.

To encrypt a test message, Bob enters:

~~~~
recrypt encrypt recrypt@example.com /in=file1.txt
~~~~

The plaintext file, <tt>file1.txt</tt> contains the following text.

~~~~
This is a test
~~~~

The UTF representation of the text is:

54, 68, 69, 73, 20, 69, 73, 20, 61, 20, 74, 65, 73, 74

The client feteches the encryption key from the service:


~~~~
POST /.well-known/recrypt/HTTP/1.1
Host: example.com
Content-Length: 61

{
  "GetKeyRequest": {
    "GroupID": "recrypt@example.com"}}
~~~~


The service responds with the key:


~~~~
HTTP/1.1 200 OK
Date: Thu 09 Nov 2017 02:48:10
Content-Length: 1009

{
  "GetKeyResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "SignedKey": {
      "unprotected": {
        "dig": "S512"},
      "payload": "
ewogICJSZWNyeXB0aW9uS2V5IjogewogICAgIkVuY3J5cHRpb25LZXkiOiB7CiAg
ICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlESCI6
...
In19fX19"
,
      "signatures": [{
          "header": {
            "kid": "MD2WG-JIM5J-MUEEL-RMKZB-2HLLZ-CBPSN"},
          "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCjlXdTk2Szk4WnRacFJYTjdE
LVN6QktLZzlWNC04SERFdlZrUmJyTm5xY2JlZjd4d0dYblVMcXhKODZpTGMzM0cK
d3BsSlhlMXg2Y2txOGxMWnVwQnhlQSJ9"
,
          "signature": "
GU0MN3b29e-e_7F7CyugT2dEEN3nrunqaLWj7e1AKHyGSEzWwr84wFKBTnm_maOi
ykTFcmtUCC0CnjwJlseoJyo4hxfywH1FxWGmvBw5J4BnVa_RXseM7rLAuCwIj3gH
MJhZfOz_MVUAVp2zqvqS6bH_tLoS5dmhTM2SzkZvs8pzZEfU0PxSXl9_qkJVEIIH
DrDqK3SbRZknFlOvEX7n2IwhYmRXrBJZ9IVum0_mkG7RHOQQb2E53pvs9ngr-Xya
dslrhpWNd_AyQ9vbwH3mGBG9RaFUTArm6UqZ2D-yxUeH3jMegPikExK4JIUnhZ9x
9Uu7wG86uturHB14H-81wA"
}]}}}
~~~~


The encryption key is used to encrypt the data:

~~~~
{
  "protected": "
ewogICJlbmMiOiAiQTI1NkNCQyJ9",
  "iv": "
XCHNrAaG2G3DRXm8wXsQ4Q",
  "recipients": [{
      "Header": {
        "alg": "DH",
        "kid": "recrypt@example.com.mm--masq6-i75dd-wl3na-mwps2-vpiir-3w4u2",
        "epk": {
          "PublicKeyDH": {
            "kid": "MDZYK-XHSK3-RFLQB-UBOIX-AVXKX-SWASA",
            "Domain": "
YE6bnq1MlX5ojaJto6PLP_PEwA",
            "Public": "
1Tk2BJDPP_wAaxjCjVx3tg3kCkSDtftxsTbdtfd_55J6mhnU5WTLvgEiMeuu5ffb
nb29lKEJneP4Fy5Lewu-v6M50IEWJ46QXMfgUhojF16fV-IyqCOMo4uLh-fquCve
CeYFQR5sJUT1pgqKMvF_d6s1IUsHbhu6YMI6TP3tgOT30e2JatW1pyyhG9jqnlke
IzrCwM01s0gY_RwdLRivcRIkIgIN3HT99R9DNj42z-8VabkVvEUuRtQdRf4VwBRI
x32MdpXSMq63hZsLlNTNOko_qwgDqPws20CzkqahkLikw-xh1IkYSp8PrNtxQnoh
L4bWPc7Ps_7TlUCJcLlA-QA"}}},
      "encrypted_key": "
tr3PlqXZv_i8MfvxZqKFbdKCL13Lk65ripdivcgWU1VWgdtMHoRpSw"}],
  "ciphertext": "
XXQoLExvW-CYNZGuJhuyVe-ByMGUdQiyTLuMXUz5jtc"}
~~~~

Here, an ephemeral key has been generated to encrypt the data against the public
group key. An ephemeral key MAY be used to establish a shared secret used to 
encrypt multiple pieces of data.

<h2>Adding users to a recryption group

Alice can add members to the group at any time. To add  Mallet, she uses the commands:

~~~~
recrypt add recrypt@example.com mallet@example.com
~~~~

This creates a recryption entry for Mallet which is pushed to the service:



~~~~
POST /.well-known/recrypt/HTTP/1.1
Host: example.com
Content-Length: 63

{
  "GetGroupRequest": {
    "GroupID": "recrypt@example.com"}}
~~~~



Mallet can now decrypt the message Bob sent before he was added to the group.

<h2>Decrypting files

To decrypt Bob's message, Mallet uses the command:

~~~~
recrypt decrypt /in=file1.txt.mmx  /out=file1m.txt
~~~~

The client reads the message and determines that it needs recryption data from
the key server example.com. It requests the necessary material.

{Point.Messages[0].String()}

The key server checks to see that Mallet is authorized to read the message. If
the user entry for the group included additional constraints such as limiting
the number of documents Mallet could read in a day, these would also be checked.

The Key server accepts the request and returns the response:

{Point.Messages[1].String()}

The client decrypts the recryption blob using Mallet's private key and uses the
decrypted key and the recryption data to complete the decryption of the data

<h2>Deleting a user



