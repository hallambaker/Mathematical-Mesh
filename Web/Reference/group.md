

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
  "Key": "groupw@example.com",
  "Profile": {
    "KeyOfflineSignature": {
      "UDF": "MDJM-V7WN-CTDQ-3LFZ-VPGW-R6UC-N5BG",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "Ed448",
          "Public": "_4bw7qHu4vvDAfQtX-N7mEI84zwmCvqADVbM2XghLfRbMI1rltRx
  1buHl6HQAQhWKUvZ3OHPNi-A"}}},
    "KeyEncryption": {
      "UDF": "MDF3-CQX5-LUNL-COHG-UP75-UFAG-UNZ3",
      "PublicParameters": {
        "PublicKeyECDH": {
          "crv": "X448",
          "Public": "72HkuTKQn3Jc2Afp_kpDGlohhpb2zsSwBl_dRbACmXDrbMkCNmqq
  oUokJ3Rry7tJeywR7bvSrdoA"}}}}}</div>
~~~~

Specifying the /json option returns a result of type ResultEntry:

~~~~
<div="terminal">
<cmd>Alice> group create groupw@example.com /json
<rsp>{
  "ResultEntry": {
    "Success": true,
    "CatalogEntry": {
      "CatalogedGroup": {
        "Key": "groupw@example.com",
        "Profile": {
          "KeyOfflineSignature": {
            "UDF": "MDJM-V7WN-CTDQ-3LFZ-VPGW-R6UC-N5BG",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "Ed448",
                "Public": "_4bw7qHu4vvDAfQtX-N7mEI84zwmCvqADVbM2XghLfRbMI1rltRx
  1buHl6HQAQhWKUvZ3OHPNi-A"}}},
          "KeyEncryption": {
            "UDF": "MDF3-CQX5-LUNL-COHG-UP75-UFAG-UNZ3",
            "PublicParameters": {
              "PublicKeyECDH": {
                "crv": "X448",
                "Public": "72HkuTKQn3Jc2Afp_kpDGlohhpb2zsSwBl_dRbACmXDrbMkCNmqq
  oUokJ3Rry7tJeywR7bvSrdoA"}}}}}}}}
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
<rsp>ERROR - Object reference not set to an instance of an object.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> group add groupw@example.com bob@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
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
<rsp>ERROR - The entry could not be found in the store.
</div>
~~~~

Specifying the /json option returns a result of type Result:

~~~~
<div="terminal">
<cmd>Alice> group delete groupw@example.com bob@example.com /json
<rsp>{
  "Result": {
    "Success": false,
    "Reason": "The entry could not be found in the store."}}
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
<rsp></div>
~~~~

Specifying the /json option returns a result of type ResultDump:

~~~~
<div="terminal">
<cmd>Alice> group list groupw@example.com /json
<rsp>{
  "ResultDump": {
    "Success": true,
    "CatalogedEntries": []}}
</div>
~~~~


