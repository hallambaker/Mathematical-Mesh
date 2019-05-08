
# Using the `contacts` Command Set

The `contacts` command set is used to manage the user's contacts catalogue.

The contacts catalogue plays an important role in Mesh messaging as it is used to 
determine the security policy for sending outbound messages and is one of the
sources used to perform access control (i.e. spam filtering) on inbound messages.

Although the `meshman` tool is capable of adding, deleting and retrieving
contact entries, it is intended to serve as a component to be used to build user
interfaces rather than a tool designed for daily use.

## Adding contacts

The `contact add` command adds a contact entry to a catalog from
a file. 


````
>contact add carol-contact.json
ERROR - The feature has not been implemented
````

The file carol-contact.json contains Carol's contact information in
JSON format:

~~~~
[Carol's contact information]
~~~~

The `/self` option is used to mark the contact as being the user's own contact
details:


````
>contact add alice-contact.json
ERROR - The feature has not been implemented
````

Contacts may also be added by accepting contact request messages using the 
`message accept` command:


````
>message accept tbs
````

## Finding contacts

The `contact get` command retreives a contact by the contact's 
email address or label:


````
>contact get carol@example.com
Empty
````

## Listing contacts

A complete list of contacts is obtained using the  `contact list` command:


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

## Deleting contacts

Contact entries may be deleted using the  `contact delete` command:


````
>contact delete carol@example.com
ERROR - Object reference not set to an instance of an object.
````



## Adding devices

Devices are given authorization to access the contacts catalog using the 
 `device auth` command:

 %  ConsoleExample (Examples.ContactAuth);

 The newly authorized device can now access the contacts catalog:

 %  ConsoleExample (Examples.ContactList2);

