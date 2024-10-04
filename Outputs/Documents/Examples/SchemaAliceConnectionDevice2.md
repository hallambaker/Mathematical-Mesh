
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MCE7-2NH5-N2UD-LK5B-Q2IU-2G5O-5NPH",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"c-uoL_64olcjuQPK5YMff6uOmlCVV2sfdHchdrqQyP-1v
  icbBRiEBSFsmNCvmxmgvv_DD1qchhSA"}}},
    "Encryption":{
      "Udf":"MDKH-VEF5-NGE4-6VBJ-2XFG-GFGC-PXA3",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"QWqGtDGk6NaCTTR1_q5G2ozp2dFcMZ-5hEQegmLxhnely
  AZYBE2LQa0A0tt9DFInObQ1uC3Juo0A"}}},
    "ProfileUdf":"MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU",
    "Authentication":{
      "Udf":"MCQQ-D7WM-KUN7-GGBZ-BYWA-NLOF-FNFJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"g0hPd-XJs5U-TfgRopKe9XHw2uw8G0Lx5mKB88JgOITr8
  9H4V8ba1k0m0XGLLJSwk3XBn5QqYOWA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "ProfileUdf":"MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU",
    "Authentication":{
      "Udf":"MCQQ-D7WM-KUN7-GGBZ-BYWA-NLOF-FNFJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"g0hPd-XJs5U-TfgRopKe9XHw2uw8G0Lx5mKB88JgOITr8
  9H4V8ba1k0m0XGLLJSwk3XBn5QqYOWA"}}}}}
~~~~

