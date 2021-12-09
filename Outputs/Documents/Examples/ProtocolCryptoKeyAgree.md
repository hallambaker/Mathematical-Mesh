
Alice added Bob to groupw@example.com as a member. This resulted in Bob receiving the
invitation described in section ??? and the following access entry being added
to the Access catalog of the group account:

~~~~
{
  "CatalogedAccess":{
    "Capability":{
      "CapabilityDecryptServiced":{
        "Id":"MAJG-TYPX-QNJH-AX6Q-LVTW-J7DL-SV3U",
        "Active":true,
        "GranteeUdf":"bob@example.com",
        "EnvelopedKeyShare":[{
            "enc":"A256CBC",
            "kid":"EBQA-NJJL-FNBZ-2YCO-CA2J-ZJJV-6YLW",
            "Salt":"RPm9x7bVfvFLa8jNwt8mGg",
            "recipients":[{
                "kid":"MALQ-QHDH-TKMG-LP5R-GYSK-GIP6-BGHB",
                "epk":{
                  "PublicKeyECDH":{
                    "crv":"X448",
                    "Public":"4ZnEet1pE9bSwa9h86y2LRatuGP0ugjblv_
  FZLKPEeVYa6cIJizh1fWyVnpuzOp2GQKK_xZhmM8A"}},
                "wmk":"mLIX7Hb7NZCQVjaauNafrPHRh8xIgXxNlBh5tNHliR
  VrjDMFYoslVg"}
              ],
            "ContentMetaData":"ewogICJNZXNzYWdlVHlwZSI6ICJLZXlEYX
  RhIiwKICAiY3R5IjogImFwcGxpY2F0aW9uL21tbS9vYmplY3QiLAogICJDcmVhdGV
  kIjogIjIwMjEtMTItMDlUMTY6NDY6MTRaIn0"},
          "OkZTdkil3-lIkQOQKfWmixrC0Qlba-r-rIjSiL5_b7wo6sKyCuKghp
  qONVcZYcfSgPhX55mShzYWy-Cz2wf2s3KnMch2eCfa1FXQRAiOlKedqvad9Is9maq
  aGH8Jc3zwi56qa3jMMLsfVyoig9c78KAwFhBXr5aRFw1SI3Lljci2RNKtFVt7g9y3
  Bn3jnRiTZmzM-uW9voz4q2b5Ix07Ff5oJzXQM81u0vK1hudfKYsl4XqNQ1poBqXdV
  ktpz-_8VCZGa6cLbCUel_A4XN2oWovvod_DTH72XRPZL6jEzTDZjhQGgIYIO6nw-P
  8uNJTgCO5O5KymOyBovBbUHnR-29JLhDpq7AfG3mBHCPhSxmxGshHbXtC0WqRst3T
  HRXXyZHIlKPpvIRxMtOBD9Y34g5Hqn-NA6cQc2Xoc7-WPa6oabTgsjkxqu5ow_z-m
  h_op6jen6GbSXiVKyQOydv0Bwg1B8BR8w4fR8UrfFIyrfGilIzNJbx3-flG91wdRU
  MDlVouvszGpsdUT9hc3330-XWyb6dojHVj08q77i_LWaiWCgXTt0kgq9vd5EOEbNF
  _HnEOMlo-Ccvgw0URgOR-_8iSq8IflhnDJELE_7elsbCmomoJZNw6N-_ASOQ7q1Z5
  J6gsmI2AGsjxpZo_F4liL2FaI4HBCnP_IdzOg1Rd3492QTpj75Wi7Sy6PVGEsFaRq
  k9XqdxT2qpIxUFSFyC4n9A"
          ]}}}}
~~~~

The private key (in this case a key share) is encrypted under the service key.

To make use of the access entry, a request is made that specifies the key share
to be operated on and the public key parameters to perform the agreement with.

The request payload:


~~~~
{
  "OperateRequest":{
    "AccountAddress":"groupw@example.com",
    "Operations":[{
        "CryptographicOperationKeyAgreement":{
          "KeyId":"MAJG-TYPX-QNJH-AX6Q-LVTW-J7DL-SV3U",
          "PublicKey":{
            "PublicKeyECDH":{
              "crv":"X448",
              "Public":"twCsBka6qNDPSa9-69VOqgOiO1zR2C2iaL8tu_jBN
  3jf4LwHnCCMH_CApINF22oJcgW3sLEBer-A"}}}}
      ]}}
~~~~


The service checks to see if the request is authorized and if so, performs the
operation and returns the result:


~~~~
{
  "OperateResponse":{
    "Status":201,
    "StatusDescription":"Operation completed successfully",
    "Results":[{
        "CryptographicResultKeyAgreement":{
          "KeyAgreement":{
            "KeyAgreementECDH":{
              "Curve":"X448",
              "Result":"vUwJETwYAg_dlU-ylXk5ud45GdsRZSLUAO012tYjG
  x7TAs5wgwFcjbe8hEQhUqOr1XgUC26nfe0A"}}}}
      ]}}
~~~~

