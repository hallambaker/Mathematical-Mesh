

# contact

````
contact    Manage contact catalogs connected to an account
    add   Add contact entry from file
    delete   Delete contact entry
    get   Lookup contact entry
    list   List contact entries
````


# contact add

````
add   Add contact entry from file
       <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>contact add carol-contact.json
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>contact add carol-contact.json /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# contact delete

````
delete   Delete contact entry
       Contact entry identifier
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>contact delete carol@example.com
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>contact delete carol@example.com /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# contact get

````
get   Lookup contact entry
       Contact entry identifier
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /encrypt   Encrypt the contact under the specified key
````

````
>contact get carol@example.com
Empty
````

Specifying the /json option returns a result of type ResultEntry:

````
>contact get carol@example.com /json
{
  "ResultEntry": {
    "Success": false}}
````

# contact list

````
list   List contact entries
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

````
>contact list
{
  "Key": "alice@example.com",
  "Permissions": [{
      "Name": "self"}],
  "Contact": [{
      "dig": "S512",
      "cty": "application/mmm"},
    "ewogICJDb250YWN0IjogewogICAgIklkZW50aWZpZXIiOiAiTUNZNy1
  WR1ZWLUsyWlotS1FXQi01NjZELUY0UEQtV0tSMyIsCiAgICAiQWNjb3VudCI6I
  CJhbGljZUBleGFtcGxlLmNvbSJ9fQ",
    {
      "signatures": [{
          "signature": "uKfOtAgEHkRdBI6aj29hBx1y-agzZQ721eVg0bOn0ZA8zTXoC
  KY3Yh7t_V5Sd6so8UG2jFp42lMAf0vrjpknAemi66vnAePm_HT5GB-Dt0-63N3
  cvvxKFh1tRLhcNrTh7jQ8-LWgIIqM9tK6hZSh8SIA"}],
      "PayloadDigest": "pn2o3KqaBDdHcWDpRw5Lj-IEdj9kGFL7m2F2VVfWKt_tN
  8ZbTdPuQjC_1lpLg33w_lLlG0eLJnCrjCQ8p6FYLA"}]}
{
  "Key": "alice@example.net",
  "Permissions": [{
      "Name": "self"}],
  "Contact": [{
      "dig": "S512",
      "cty": "application/mmm"},
    "ewogICJDb250YWN0IjogewogICAgIklkZW50aWZpZXIiOiAiTUNZNy1
  WR1ZWLUsyWlotS1FXQi01NjZELUY0UEQtV0tSMyIsCiAgICAiQWNjb3VudCI6I
  CJhbGljZUBleGFtcGxlLm5ldCJ9fQ",
    {
      "signatures": [{
          "signature": "Mc6DcXDIYblxSbsowSEHl_0x3M9F6UhU0YIBt49crkolAT8_H
  v9JxnlTQK6bfUWC6VUiH_ye_fSApW7uDGefpkyUeY1vkyRN1BlZQXaPDBbz2EJ
  jeqlMl7jArGyXozB4sdVvkJyQmr038ijIzvQtVSsA"}],
      "PayloadDigest": "yHfXaJnUbLAk-8qPwP0-bs8y9yL_mRXTMp-RNLWFoiFdV
  rn4yOfX-z_9fUtxL_NEAZA-sQnF4qpIWGSBhPFYtw"}]}
````

Specifying the /json option returns a result of type ResultDump:

````
>contact list /json
{
  "ResultDump": {
    "Success": true,
    "CatalogEntries": [{
        "Key": "alice@example.com",
        "Permissions": [{
            "Name": "self"}],
        "Contact": [{
            "dig": "S512",
            "cty": "application/mmm"},
          "ewogICJDb250YWN0IjogewogICAgIklkZW50aWZpZXIiOiAiTUNZNy1
  WR1ZWLUsyWlotS1FXQi01NjZELUY0UEQtV0tSMyIsCiAgICAiQWNjb3VudCI6I
  CJhbGljZUBleGFtcGxlLmNvbSJ9fQ",
          {
            "signatures": [{
                "signature": "uKfOtAgEHkRdBI6aj29hBx1y-agzZQ721eVg0bOn0ZA8zTXoC
  KY3Yh7t_V5Sd6so8UG2jFp42lMAf0vrjpknAemi66vnAePm_HT5GB-Dt0-63N3
  cvvxKFh1tRLhcNrTh7jQ8-LWgIIqM9tK6hZSh8SIA"}],
            "PayloadDigest": "pn2o3KqaBDdHcWDpRw5Lj-IEdj9kGFL7m2F2VVfWKt_tN
  8ZbTdPuQjC_1lpLg33w_lLlG0eLJnCrjCQ8p6FYLA"}]},
      {
        "Key": "alice@example.net",
        "Permissions": [{
            "Name": "self"}],
        "Contact": [{
            "dig": "S512",
            "cty": "application/mmm"},
          "ewogICJDb250YWN0IjogewogICAgIklkZW50aWZpZXIiOiAiTUNZNy1
  WR1ZWLUsyWlotS1FXQi01NjZELUY0UEQtV0tSMyIsCiAgICAiQWNjb3VudCI6I
  CJhbGljZUBleGFtcGxlLm5ldCJ9fQ",
          {
            "signatures": [{
                "signature": "Mc6DcXDIYblxSbsowSEHl_0x3M9F6UhU0YIBt49crkolAT8_H
  v9JxnlTQK6bfUWC6VUiH_ye_fSApW7uDGefpkyUeY1vkyRN1BlZQXaPDBbz2EJ
  jeqlMl7jArGyXozB4sdVvkJyQmr038ijIzvQtVSsA"}],
            "PayloadDigest": "yHfXaJnUbLAk-8qPwP0-bs8y9yL_mRXTMp-RNLWFoiFdV
  rn4yOfX-z_9fUtxL_NEAZA-sQnF4qpIWGSBhPFYtw"}]}]}}
````

