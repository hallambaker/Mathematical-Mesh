

# group

~~~~
<div="helptext">
<over>
group    Group management commands
    add   Add user to recryption group
    create   Create recryption group
    delete   Remove user from recryption group
    get   Find member in recryption group
    list   List members of a recryption group
<over>
</div>
~~~~


# group create

~~~~
<div="helptext">
<over>
create   Create recryption group
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /alg   List of algorithm specifiers
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com
<rsp>{
  "Profile": {
    "KeyOfflineSignature": {
      "UDF": "MAZW-YIWQ-I46E-2NUB-4YRL-SX3O-FXQK",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "yO4Lqx_Q0A07evC7v9qxgcWR5oWld_3ZJViOE2wT_UfCcZegF33k
  ImBpcyZgcm-QyNatdeArEByA"}}},
    "KeyEncryption": {
      "UDF": "MDAA-MKLP-S7T5-5LD5-NSOE-JX2L-GVHY",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "FYPiybVQ-I7zdMxFl3Ol96WlnTig1V18eY2dyfgu9Nantpxd6H8k
  fhJpGR0XwyjJDBzfR4hHAGQA"}}}}}</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "Profile": {
        "KeyOfflineSignature": {
          "UDF": "MAZW-YIWQ-I46E-2NUB-4YRL-SX3O-FXQK",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "yO4Lqx_Q0A07evC7v9qxgcWR5oWld_3ZJViOE2wT_UfCcZegF33k
  ImBpcyZgcm-QyNatdeArEByA"}}},
        "KeyEncryption": {
          "UDF": "MDAA-MKLP-S7T5-5LD5-NSOE-JX2L-GVHY",
          "PublicParameters": {
            "PublicKeyECDH": {
              "crv": "Ed448",
              "Public": "FYPiybVQ-I7zdMxFl3Ol96WlnTig1V18eY2dyfgu9Nantpxd6H8k
  fhJpGR0XwyjJDBzfR4hHAGQA"}}}}}}}
</div>
~~~~


# group add

~~~~
<div="helptext">
<over>
add   Add user to recryption group
       Recryption group name in user@example.com format
       User to add
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> group add groupw@example.com bob@example.com
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> group add groupw@example.com bob@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# group delete

~~~~
<div="helptext">
<over>
delete   Remove user from recryption group
       Recryption group name in user@example.com format
       User to delete
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


# group list

~~~~
<div="helptext">
<over>
list   List members of a recryption group
       Recryption group name in user@example.com format
    /account   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
<over>
</div>
~~~~

~~~~
<div="terminal">
<cmd>Alice> group list groupw@example.com
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> group list groupw@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
</div>
~~~~


