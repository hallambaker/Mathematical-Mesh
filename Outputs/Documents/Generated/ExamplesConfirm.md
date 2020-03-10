
#Confirmation Protocol

(Configuration).

##Creating a confirmation profile

[First step is to create a mesh profile and add a confirmation profile.
This is not currently supported by the reference code, the implementation
uses the device profile instead.]


##Posting a request

An Enquirer initiates a confirmation request using the EnquireRequest 
message. This specifies the request to be posted, the account to which 
it is posted and (optionally) the time at which the enquirer has no
further interest in receiving a response.

The signed request is a JsonWebSignature object that contains a payload 
of type TBSRequest that specifies the confirmation text to be presented
to the user in SRML format, the account identifier of the requestor and
the account identifier as the responder. The TBSRequest object MAY be 
encrypted.

The Responder identifier is thus specified in two separate places, in
the signed TBSRequest and in the enclosing EnquireRequest message. Following
the terminology introduced to describe the SMTP protocol, these 
correspond to the 'Message to' and 'Envelope to' addresses respectively.
Separating these two functions is useful because it allows the unsigned 
envelope to address to be modified to support request routing capabilities 
such as aliases and group addresses while maintaining the ability to 
authenticate the message to address.

For example, a party claiming to be 'Bob' calls Alice asking her to open
the pod bay doors. Following procedure, Alice requires Bob to provide a non-repudiable
confirmation of this request. Accordingly, she uses her confirmation account
alice@example.com to post a request to Bob's confirmation
account bob@example.com asking him to confirm the action.

Alice uses the client supplied by the reference implementation to post this 
request. This client does not form part of the normative Mesh/Confirm 
specification and is used here purely to illustrate the information that
a user or script needs to pass to request a transaction.

The console command is:

confirm post bob@example.com "Open pod bay doors"

The TBSRequest is:

$$$$ extract TBS part here.

The HTTP request message is:


~~~~
POST /.well-known/confirm/HTTP/1.1
Host: example.com
Content-Length: 1095

{
  "EnquireRequest": {
    "Request": {
      "Request": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJUQlNSZXF1ZXN0IjogewogICAgIlRleHQiOiAiPHNybWw-PGgxPk9wZW4g
cG9kIGJheSBkb29yczwvaDE-PC9zcm1sPiIsCiAgICAiRnJvbUlEIjogImFsaWNl
QGV4YW1wbGUubmV0IiwKICAgICJUb0lEIjogImJvYkBleGFtcGxlLmNvbSJ9fQ",
        "signatures": [{
            "header": {
              "kid": "MCP7Y-PTSWC-RLIYY-ECVFD-IZ6BZ-GUW5M"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmpHWmlYMU5EeGxLMmtfUm1H
dUV4NEtWSTMybkxMUmZYVnJZbXVUMDQwR1VIa3p6dEVtWG43eW1pQXh3dVl0cEUK
ZXBpUGNNNEhWMFRZbTM4TlFRdjlodyJ9",
            "signature": "
q84_k_Dtt6zXR0VMyWKzkemz6B4c62aFnXmwsVXQCpczcSVt9EJMqUXvzT2dhzEy
scDDU1_Z7OVPIbnuHoEvXz2FheYROhL33mquf9T9kQ5vrRwHuaXwHvhqLlUt6WLc
MUB0o2-WpkGzkijtJjwwBxemt8XQ2z6Mty1MIXajWfdfwFG7Bk3GxX5weHzPV4MK
kavGGeOXIO49nNsjDQkCE_Gvdzp2WvVqw128X4yId6rLNkNXsHY_tKlVOA-A9ifM
aqVXUzNtJKryg4a5Do6Dksl9rD1z1hwmLD3_baC8g3Qwex2iXLenCrUbD0_BUSk_
Ze-K-GB_Wusbe-t0lhK38A"}]},
      "ResponderAccount": "bob@example.com",
      "Expire": "2017-11-09T18:48:10Z"}}}
~~~~


A confirmation service SHOULD perform some form of request filtering
to prevent abuse (e.g. spam, denial of service). In this case the request 
comes from a user with a local account which is implictly authorized to
post request messages without limit.

The confirmation service verifies the signature on the request and 
returns a response message specifying the broker identifier.



~~~~
HTTP/1.1 200 OK
Date: Thu 09 Nov 2017 02:48:10
Content-Length: 160

{
  "EnquireResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "BrokerID": "RBA5D-4AWLX-QWLZA-P6YG7-ZDGVV-PE52R"}}
~~~~


[Note that for the sake of concise presentation, the HTTP binding
information is omitted from future examples.]


##Obtaining request status.

Having posted a request, the enquirer needs to discover the result. Since
the protocol assumes that the response will be posted by a person rather
than a machine, it is likely that there will be a delay of several seconds
at least and possibly many minutes. For certain types of confirmation, the 
responder might take hours or even days.

A status request is posted using the StatusRequest message. The enquirer 
specifies the BrokerID of the request being enquired of.


~~~~
{
  "StatusRequest": {
    "Cancel": false,
    "BrokerID": "RBA5D-4AWLX-QWLZA-P6YG7-ZDGVV-PE52R"}}
~~~~


The service responds with the status of the request and the Responder's response
if they have replied. The first time the enquirer asks, the request is still
pending:


~~~~
{
  "StatusResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Response": {
      "BrokerID": "RBA5D-4AWLX-QWLZA-P6YG7-ZDGVV-PE52R",
      "RequestStatus": "PENDING"}}}
~~~~


When the enquirer repeats the status request a short time later, the responder
has posted a response. The service returns the response message returned:


~~~~
{
  "StatusResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Response": {
      "BrokerID": "RBA5D-4AWLX-QWLZA-P6YG7-ZDGVV-PE52R",
      "RequestStatus": "Reply",
      "Response": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJUQlNSZXNwb25zZSI6IHsKICAgICJTaWduZWRSZXF1ZXN0IjogewogICAg
ICAidW5wcm90ZWN0ZWQiOiB7CiAgICAgICAgImRpZyI6ICJTNTEyIn0sCiAgICAg
...
YmUtdDBsaEszOEEifV19LAogICAgIlZhbHVlIjogdHJ1ZX19"
,
        "signatures": [{
            "header": {
              "kid": "MCUJI-GNXNA-2UNWU-U6EVR-HK6MN-YJOBP"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm8waVdGYjRLVld4SGRGUnZG
QjBFYU5waDJFcEpROEFKdlVPbU13VzNvLUxHaHYyRHhqbnk3WTRNaWNWWEExbjQK
S0hRUW9wZUg0LUlRSlRydHFrbWdyQSJ9"
,
            "signature": "
SA1Kri_ZNsSdCFdX5-OnaxI5mdWfnYyUA5umqHJsuLbrvqyCGqn1MpgerF37BgCt
L0d_6mPUzD_0buCWmLS2eBFY93vE-W0hz-zL_OkXFwtNggbpC6PPeUzA0tk14iex
DQDyL3Smtm2e1oIemA_zTb8X_J8NRC-0QJ4DIlpVNORVdX5WmMRqg-X6fNoh_zQl
SHUxK-PrzvqXaaoc0dpM2zHZYI2DoSbW7PkIwteNq6j7zg6Qc13GP-FeffGuWWAg
WRFk7x6e01dGrPG6I7TX1mAvmQ4uQOEwv12tPwdvUheE1CCiXidO0i20dd1crbRj
7u4ojNOtk9cO4pdDasDdOQ"
}]}}}}
~~~~



##List pending requests.

From the enquirer's point of view, the confirmation protocol is like a very limited
version of email.

The enquirer periodically polls the confirmation service to retrieve a list of 
pending messages using ther PendingRequest message.


~~~~
{
  "PendingRequest": {
    "Responder": "bob@example.com"}}
~~~~


The response contains a list of pending responses:


~~~~
{
  "PendingResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "Entries": [{
        "BrokerID": "RBA5D-4AWLX-QWLZA-P6YG7-ZDGVV-PE52R",
        "Request": {
          "unprotected": {
            "dig": "S512"},
          "payload": "
ewogICJUQlNSZXF1ZXN0IjogewogICAgIlRleHQiOiAiPHNybWw-PGgxPk9wZW4g
cG9kIGJheSBkb29yczwvaDE-PC9zcm1sPiIsCiAgICAiRnJvbUlEIjogImFsaWNl
QGV4YW1wbGUubmV0IiwKICAgICJUb0lEIjogImJvYkBleGFtcGxlLmNvbSJ9fQ"
,
          "signatures": [{
              "header": {
                "kid": "MCP7Y-PTSWC-RLIYY-ECVFD-IZ6BZ-GUW5M"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmpHWmlYMU5EeGxLMmtfUm1H
dUV4NEtWSTMybkxMUmZYVnJZbXVUMDQwR1VIa3p6dEVtWG43eW1pQXh3dVl0cEUK
ZXBpUGNNNEhWMFRZbTM4TlFRdjlodyJ9"
,
              "signature": "
q84_k_Dtt6zXR0VMyWKzkemz6B4c62aFnXmwsVXQCpczcSVt9EJMqUXvzT2dhzEy
scDDU1_Z7OVPIbnuHoEvXz2FheYROhL33mquf9T9kQ5vrRwHuaXwHvhqLlUt6WLc
MUB0o2-WpkGzkijtJjwwBxemt8XQ2z6Mty1MIXajWfdfwFG7Bk3GxX5weHzPV4MK
kavGGeOXIO49nNsjDQkCE_Gvdzp2WvVqw128X4yId6rLNkNXsHY_tKlVOA-A9ifM
aqVXUzNtJKryg4a5Do6Dksl9rD1z1hwmLD3_baC8g3Qwex2iXLenCrUbD0_BUSk_
Ze-K-GB_Wusbe-t0lhK38A"
}]},
        "ResponderAccount": "bob@example.com",
        "Expire": "2017-11-09T18:48:10Z"}]}}
~~~~


##Post a response

The responder posts their response using the RespondRequest message. This contains a
ResponseEntry object which contains the response status and the signed response.

The payload of the signed response is a TBSResponse message which contains the 
signed request and the response value. Currently only Accept/Reject confirmations
are supported and the response value is returnes as a boolean.

The TBSResponse object is:

$$$$$ TBS extract

The request message is:


~~~~
{
  "RespondRequest": {
    "Response": {
      "BrokerID": "RBA5D-4AWLX-QWLZA-P6YG7-ZDGVV-PE52R",
      "RequestStatus": "Reply",
      "Response": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJUQlNSZXNwb25zZSI6IHsKICAgICJTaWduZWRSZXF1ZXN0IjogewogICAg
ICAidW5wcm90ZWN0ZWQiOiB7CiAgICAgICAgImRpZyI6ICJTNTEyIn0sCiAgICAg
...
YmUtdDBsaEszOEEifV19LAogICAgIlZhbHVlIjogdHJ1ZX19"
,
        "signatures": [{
            "header": {
              "kid": "MCUJI-GNXNA-2UNWU-U6EVR-HK6MN-YJOBP"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm8waVdGYjRLVld4SGRGUnZG
QjBFYU5waDJFcEpROEFKdlVPbU13VzNvLUxHaHYyRHhqbnk3WTRNaWNWWEExbjQK
S0hRUW9wZUg0LUlRSlRydHFrbWdyQSJ9"
,
            "signature": "
SA1Kri_ZNsSdCFdX5-OnaxI5mdWfnYyUA5umqHJsuLbrvqyCGqn1MpgerF37BgCt
L0d_6mPUzD_0buCWmLS2eBFY93vE-W0hz-zL_OkXFwtNggbpC6PPeUzA0tk14iex
DQDyL3Smtm2e1oIemA_zTb8X_J8NRC-0QJ4DIlpVNORVdX5WmMRqg-X6fNoh_zQl
SHUxK-PrzvqXaaoc0dpM2zHZYI2DoSbW7PkIwteNq6j7zg6Qc13GP-FeffGuWWAg
WRFk7x6e01dGrPG6I7TX1mAvmQ4uQOEwv12tPwdvUheE1CCiXidO0i20dd1crbRj
7u4ojNOtk9cO4pdDasDdOQ"
}]}}}}
~~~~


The response value contains only the status code and description showing the success 
or failure of the request.


~~~~
{
  "RespondResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully"}}
~~~~








