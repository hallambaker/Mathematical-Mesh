
The ConnectionDevice assertion is used by the device to authenticate it to other 
devices connected to the account. This connection assertion specifies the
Encryption, Authentication, and Signature keys the device is to use in the context of
the account and the list of roles that have been authorized for the device..

~~~~
{
  "ConnectionDevice":{
    "Authentication":{
      "Udf":"MCDT-NNBH-TGDN-SES3-2WAO-QJQJ-QCEJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"C51qqCgU6UmfgQdjv-v6SXqVxBUhiH_XduUndgGTFcr3z
  siCR8tJUMg5Dp1T9QfrWBuH5TqYXgSA"}}},
    "Roles":["message",
      "web"
      ],
    "Signature":{
      "Udf":"MCSY-YAUQ-RFTW-LG6L-FN3N-HRZO-3EQM",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"Ed448",
          "Public":"MNsbb8Q8KyOW6ourA6bZix4QLbtSktMX1sHQtAJDEm9k1
  EZOLzrZtL-x08CZ2jcqkaf4DoShweKA"}}},
    "Encryption":{
      "Udf":"MBX5-M76T-UKXP-XJ24-S6LW-GUAC-K4VM",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"hmv9p6YeKcR8Tp3VKHrCxA4WGXyXkEw2UnICrQIFjw8Pz
  aAhD7BiYL98-VeIdgk1UWxofxQ3atgA"}}}}}
~~~~

The ConnectionService assertion is used to authenticate the device to the 
Mesh service. In order to allow the assertion to fit in a single packet, it
is important that this assertion be as small as possible. Only the 
Authentication key is specified.

The corresponding ConnectionService assertion is:

~~~~
{
  "ConnectionService":{
    "Authentication":{
      "Udf":"MCDT-NNBH-TGDN-SES3-2WAO-QJQJ-QCEJ",
      "PublicParameters":{
        "PublicKeyECDH":{
          "crv":"X448",
          "Public":"C51qqCgU6UmfgQdjv-v6SXqVxBUhiH_XduUndgGTFcr3z
  siCR8tJUMg5Dp1T9QfrWBuH5TqYXgSA"}}}}}
~~~~

