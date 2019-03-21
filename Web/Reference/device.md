

# device

````
device    Device management commands.
    accept   Accept a pending connection
    auth   Authorize device to use application
    create   Create new device profile
    delete   Remove device from device catalog
    earl   Connect a new device by means of an EARL
    init   Create an initialization 
    list   List devices in the device catalog
    pending   Get list of pending connection requests
    pin   Accept a pending connection
    pre   Create a preconnection request
    reject   Reject a pending connection
    request   Connect to an existing profile registered at a portal
````

# device accept

````
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

Accept a pending connection request.


````
>device accept tbs
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>device accept tbs /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# device auth

````
auth   Authorize device to use application
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device auth` command changes the set of authorizations given to the
specified device, adding or removing authorizations according to the 
flags specified on the command line.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.

The `/id` option may be used to specify a friendly name for the device.

Specifying the `/all` option causes the device to be granted all the 
available device authorizations except for those explicitly denied 
by means of a negative authorization grant (e.g. `/nobookmark`).

Specifying the `/noall` option causes the device to be granted no 
available device authorizations except for those explicitly granted 
by means of a positive authorization grant (e.g. `/bookmark`).

If neither the `/all` option or the `/noall` option is specified, the 
device authorizations remain unchanged except where explicitly 
granted or denied.

The following authorizations may be granted or denied:

* `bookmark`: Authorize response to confirmation requests
* `calendar`: Authorize access to calendar catalog
* `contact`: Authorize access to contacts catalog
* `confirm`: Authorize response to confirmation requests
* `mail`: Authorize access to configure SMTP mail services.
* `network`: Authorize access to the network catalog
* `password`: Authorize access to password catalog
* `ssh`: Authorize use of SSH

**Missing Example***

# device accept

````
accept   Accept a pending connection
       Fingerprint of connection to accept
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device accept` command accepts the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.

The `/id` option may be used to specify a friendly name for the device.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


````
>device accept tbs
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>device accept tbs /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# device create

````
create   Create new device profile
       Device identifier
       Device description
    /alg   List of algorithm specifiers
    /default   Make the new device profile the default
````

The `device create` command creates a new device profile without attempting
to connect the profile to a Mesh service account or profile.

This command allows a device to be preconfigured during manufacture or
site configuration before delivery or assignment to an indivdual user.

The `/id` and `/dd` options allow a device identifier and description to be 
assigned to the device.

The profile is made the default profile for the device if either there is
no previous default device profile or the`/default` option is specified.


````
>device create /id="IoTDevice"
ERROR - The option  is not known.
````

Specifying the /json option returns a result of type Result:

````
>device create /id="IoTDevice" /json
{
  "Result": {
    "Success": false,
    "Reason": "The option  is not known."}}
````

# device delete

````
delete   Remove device from device catalog
       Device identifier
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device delete` command removes the specified device from the catalog.

The parameter specifies the device being configured by means of either
the UDF of the device profile or the device identifier.


````
>device delete tbs
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device delete tbs /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device earl

````
earl   Connect a new device by means of an EARL
       The EARL locator
       Device identifier
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
````

The `device earl` command attempts to connect a device to a personal profile
by means of an EARL UDF.

The EARL is typically presented to the administration device in the form of
a QR code which is decoded and passed to the meshman application.

The `/id` option may be used to specify a friendly name for the device if the
connection attempt succeeds.

The authorizations to be granted to the device may be specified using
the same syntax as for the `device auth` command with the default authorization
being that all authorizations are denied.


````
>device earl udf://example.com/EAAX-4L7C-FUGC-ZGOO-BFPD-Z46G-CHXN-AR
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>device earl udf://example.com/EAAX-4L7C-FUGC-ZGOO-BFPD-Z46G-CHXN-AR /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# device list

````
list   List devices in the device catalog
       Recryption group name in user@example.com format
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device list` command lists the device profiles in the device catalog.


````
>device list
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device list /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device pending

````
pending   Get list of pending connection requests
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device pending` command lists the pending device connection requests in
the inbound message spool.


````
>device pending
OK
````

Specifying the /json option returns a result of type ResultPending:

````
>device pending /json
{
  "ResultPending": {
    "Success": true,
    "Messages": [{
        "MessageID": "NCDV-E3FL-FI6G-FWQ6-GOPK-SQFN-KGOO-GFTS-4KE7-ZQ3V-P4",
        "Account": "alice@example.com",
        "DeviceProfile": [{
            "dig": "S512",
            "cty": "application/mmm"},
          "ewogICJQcm9maWxlRGV2aWNlIjogewogICAgIkRldmljZVNpZ25hdHVyZUtleSI6IHsKICAgICAgIlVERiI6ICJNRFBMLVM2TzItV0RZUS1ERUJWLTZUSE0tWVJTWS1YUEpHIiwKICAgICAgIlB1YmxpY1BhcmFtZXRlcnMiOiB7CiAgICAgICAgIlB1YmxpY0tleUVDREgiOiB7CiAgICAgICAgICAiY3J2IjogIkVkNDQ4IiwKICAgICAgICAgICJQdWJsaWMiOiAiR1otcVBXZnFZSnljSjVBRU52dEdMLXBtcklnRGQzRzQwWmNJN0hGZFZ1OFFOZnhZTEQ0T2phM2xiYjBUSnZjODMzVl9hbkR6cE04QSJ9fX0sCiAgICAiRGV2aWNlQXV0aGVudGljYXRpb25LZXkiOiB7CiAgICAgICJVREYiOiAiTUNHTS1XRVVYLUE0TEItRDJXTy01N1FCLURLNE4tM1BPSyIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogImdDbmNaVzJXVzNVY0lIMXF3WkdpMkRmTmlmby1TeUZtTHQ1RU1jX1lKQnFEWncxeWNGQWM1NmVPT0lycE51QU9HYXFtTXBNbVlFaUEifX19LAogICAgIkRldmljZUVuY3J5cHRpb25LZXkiOiB7CiAgICAgICJVREYiOiAiTURYUC1VUTROLUNFTUgtUElaRy1ETVdBLVQ2SVItWUVTNiIsCiAgICAgICJQdWJsaWNQYXJhbWV0ZXJzIjogewogICAgICAgICJQdWJsaWNLZXlFQ0RIIjogewogICAgICAgICAgImNydiI6ICJFZDQ0OCIsCiAgICAgICAgICAiUHVibGljIjogIm11aW1XZXpXNWJ1VVhQMzh5SXY1cFF2LW9MYkFEQ0JzX0MzdW55a00yWS1IcXYybEJLR3FyWl9GMW9xck5VbUE0ZHBpclhtYlY0UUEifX19fX0",
          {
            "signatures": [{
                "signature": "14pjqdxkzA-8JQD19pSFtbSvw8r9LrIhaY_EAX9k_9XUTyHcPzYTwupNuvb77Aur08vrIjB_qeoAcFn4NlsgCityJtyWfX1CiDtvWwNLJHjHLaSWsBqscpWKKm0ARkXkxEd28-7R93J_Frqgdcf1BikA"}],
            "PayloadDigest": "ehLcYwCf8PWldDzwClUMFV_6VcjhbCPAj_LONuLDLgVkLF3WS1cidcG3cztu2hhroSz0xM2izkmaTYrs-y7IJw"}],
        "ClientNonce": "474SQBVCThbQJdZqFLys0g",
        "ServerNonce": "nbln9k9q99EQoxpw6_P2CQ",
        "Witness": "FJ7Z-KNLZ-C37J-FADL-R5GF-I7WK-ITCR"}]}}
````

# device reject

````
reject   Reject a pending connection
       Fingerprint of connection to reject
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device reject` command rejects the specified connection request.

The command must specify the connection identifier of the request 
being accepted. The connection identifier may be abbreviated provided that
this uniquely identifies the connection being accepted and that at least 
four characters are given.


````
>device reject tbs
ERROR - The feature has not been implemented
````

Specifying the /json option returns a result of type Result:

````
>device reject tbs /json
{
  "Result": {
    "Success": false,
    "Reason": "The feature has not been implemented"}}
````

# device pin

````
pin   Accept a pending connection
    /length   Length of PIN to generate (default is 8 characters)
    /expire   <Unspecified>
    /mesh   Account identifier (e.g. alice@example.com) or profile fingerprint
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
````

The `device pin` command generates and registers a new PIN code that may be used
to authenticate a device connection request.

The `/length` option specifies the length of the generated PIN in (significant)
characters.

The '/expire' option specifies an expiry time for the request as an integer 
followed by the letter m, h or d for minutes, hours and days respectively.


````
>device pin
OK
````

Specifying the /json option returns a result of type ResultPIN:

````
>device pin /json
{
  "ResultPIN": {
    "Success": true,
    "MessageConnectionPIN": {
      "MessageID": "NBI3-PUW4-BT4M-7LUW-34QR-DFBD-7LJ6-QOCH-LLFV-TXRC-QU",
      "Account": "alice@example.com",
      "Expires": "2019-03-21T03:11:47Z",
      "PIN": "NAVH-4RJ5-6YQH-E4LO-VQ7F-VLWJ-O6R"}}}
````

# device pre

````
pre   Create a preconnection request
       New portal account
    /key   Encryption key for use in generating an EARL connector.
    /export   Export the device configuration information to the specified file
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /cty   Content Type
    /encrypt   Encrypt data for specified recipient
    /sign   Sign data with specified key
    /hash   Compute hash of content
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
````

The `device pre \<account\>` command requests connection of a device to a mesh hailing
account supporting the EARL connection profile.

The \<account\> parameter specifies the hailing account for which the connection request is
made.

The `/key` option may be used to generate the encryption key to be used.

If the `/export` option is specified, the device profile and private keys are written to
a DARE container archive under the specified encryption options rather than the device 
on which the command is issued. This allows a host machine to be used to perform 
offline initialization of device profiles in batch mode during manufacture.


````
>device pre devices@example.com /key=udf://example.com/EAAX-4L7C-FUGC-ZGOO-BFPD-Z46G-CHXN-AR
ERROR - Object reference not set to an instance of an object.
````

Specifying the /json option returns a result of type Result:

````
>device pre devices@example.com /key=udf://example.com/EAAX-4L7C-FUGC-ZGOO-BFPD-Z46G-CHXN-AR /json
{
  "Result": {
    "Success": false,
    "Reason": "Object reference not set to an instance of an object."}}
````

# device request

````
request   Connect to an existing profile registered at a portal
       New portal account
    /pin   One time use authenticator
    /verbose   Verbose reports (default)
    /report   Report output (default)
    /json   Report output in JSON format
    /new   Force creation of new device profile
    /dudf   Device profile fingerprint
    /did   Device identifier
    /dd   Device description
    /auth   Authorize the specified function
    /admin   Authorize device as administration device
    /all   Authorize device for all application catalogs
    /bookmark   Authorize response to confirmation requests
    /calendar   Authorize access to calendar catalog
    /contact   Authorize access to contacts catalog
    /confirm   Authorize response to confirmation requests
    /mail   Authorize access to configure SMTP mail services.
    /network   Authorize access to the network catalog
    /password   Authorize access to the password catalog
    /ssh   Authorize use of SSH
````

The `device request \<account\>` command requests connection of a device to a mesh profile.

The \<account\> parameter specifies the account for which the connection request is
made.

If the account holder has generated an authentication code, this is specified by means of 
the `/pin` option.




````
>device request alice@example.com
OK
````

Specifying the /json option returns a result of type ResultConnect:

````
>device request alice@example.com /json
{
  "ResultConnect": {
    "Success": true}}
````


