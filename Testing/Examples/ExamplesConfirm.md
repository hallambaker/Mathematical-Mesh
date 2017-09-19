
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
              "kid": "MCLWY-HFJ3T-7WCAY-5EA4I-J6OOO-SXXVA"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmpHWmlYMU5EeGxLMmtfUm1H
dUV4NEtWSTMybkxMUmZYVnJZbXVUMDQwR1VIa3p6dEVtWG43eW1pQXh3dVl0cEUK
ZXBpUGNNNEhWMFRZbTM4TlFRdjlodyJ9",
            "signature": "
SsLXlMp4waBNebvtQSdGInBS2JjQUiTMqrqfMjt22oIIAlqLU-IK_NXAJAumnta2
DbU-5yqEJmkFGBgwo9IV4hv1qC25u5JbHanfGLlZAneYraeididFIXnK4XTOtk3U
kk_sVA0xp47o0SZfKbCNt9ZP-fpgZZ2KfcxNx8YsMDv8dChpQjz4BwHACQIdQ1Yx
RNxYUAK4gQ-LcYDWFPINa0jM6xz-r8uwSGtP26ukdHuujTl1BtBYySPcRaFo7Ph2
6tpwsRcF3TanJhKlWB2LYb6Mg3S1v8CjrzdcTEYfq7jA-bgse5oQm58kaB-n5f5E
HUgxbnLD4ka1TBQ7LRWRfA"}]},
      "ResponderAccount": "bob@example.com",
      "Expire": "2017-06-24T06:00:13Z"}}}
~~~~


A confirmation service SHOULD perform some form of request filtering
to prevent abuse (e.g. spam, denial of service). In this case the request 
comes from a user with a local account which is implictly authorized to
post request messages without limit.

The confirmation service verifies the signature on the request and 
returns a response message specifying the broker identifier.



~~~~
HTTP/1.1 200 OK
Date: Sat 24 Jun 2017 02:00:13
Content-Length: 162

{
  "EnquireResponse": {
    "Status": 201,
    "StatusDescription": "Operation completed successfully",
    "BrokerID": "MDXJR-HVMO2-V5CPT-2M7BN-54ZI3-PDJSU-A"}}
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
    "BrokerID": "MDXJR-HVMO2-V5CPT-2M7BN-54ZI3-PDJSU-A"}}
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
      "BrokerID": "MDXJR-HVMO2-V5CPT-2M7BN-54ZI3-PDJSU-A",
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
      "BrokerID": "MDXJR-HVMO2-V5CPT-2M7BN-54ZI3-PDJSU-A",
      "RequestStatus": "Reply",
      "Response": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJUQlNSZXNwb25zZSI6IHsKICAgICJTaWduZWRSZXF1ZXN0IjogewogICAg
ICAidW5wcm90ZWN0ZWQiOiB7CiAgICAgICAgImRpZyI6ICJTNTEyIn0sCiAgICAg
...
MVRCUTdMUldSZkEifV19LAogICAgIlZhbHVlIjogdHJ1ZX19"
,
        "signatures": [{
            "header": {
              "kid": "MCGN2-CNR2S-XBPYD-M6M44-URSSY-VPYFO"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm4wcXZOOGZvRlU2cUI4VEpS
SmxxUnk4YmRWSkEydDllVnFJNDFxOFQ0WVVxY3ZmbXFmaVlYUGZwcjRRRXRaX3AK
UHV0cG0zQUFEVEZPNWUtTWs3dzFJdyJ9"
,
            "signature": "
VrAtI86e1pjxa6fAX9amph-5GQsDIZ0EN7XQbQT2cdWXKQWQdjXbtOTpaQ3t8QV4
fO8NA6lFkBqzT-wWA38QTjf1V2-Q2IB0mLSvMKYCWrHNHygBkdis7FHmP68XXo9E
Nd3j4RhB2cl-72lDHXF0YKL6u3KnFG7MHgScT-SRxLQ0YLQzT1Pz-PbUWWCXK0pJ
5Jra78gEFLQt_vtF7WKwQ5a_FhQkTPdDlCzXYlX-XIgmEVzYq5RV7QwU8wB3gWxs
byWMUTC23W1xne1fkZ-5o72NbYc3cLUAV8cK2-YS5kVnYU6gDVxrLGbh36erll41
n2fy_4XVWGo7uf3aZpRAUA"
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
        "BrokerID": "MDXJR-HVMO2-V5CPT-2M7BN-54ZI3-PDJSU-A",
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
                "kid": "MCLWY-HFJ3T-7WCAY-5EA4I-J6OOO-SXXVA"},
              "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCmpHWmlYMU5EeGxLMmtfUm1H
dUV4NEtWSTMybkxMUmZYVnJZbXVUMDQwR1VIa3p6dEVtWG43eW1pQXh3dVl0cEUK
ZXBpUGNNNEhWMFRZbTM4TlFRdjlodyJ9"
,
              "signature": "
SsLXlMp4waBNebvtQSdGInBS2JjQUiTMqrqfMjt22oIIAlqLU-IK_NXAJAumnta2
DbU-5yqEJmkFGBgwo9IV4hv1qC25u5JbHanfGLlZAneYraeididFIXnK4XTOtk3U
kk_sVA0xp47o0SZfKbCNt9ZP-fpgZZ2KfcxNx8YsMDv8dChpQjz4BwHACQIdQ1Yx
RNxYUAK4gQ-LcYDWFPINa0jM6xz-r8uwSGtP26ukdHuujTl1BtBYySPcRaFo7Ph2
6tpwsRcF3TanJhKlWB2LYb6Mg3S1v8CjrzdcTEYfq7jA-bgse5oQm58kaB-n5f5E
HUgxbnLD4ka1TBQ7LRWRfA"
}]},
        "ResponderAccount": "bob@example.com",
        "Expire": "2017-06-24T06:00:13Z"}]}}
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
      "BrokerID": "MDXJR-HVMO2-V5CPT-2M7BN-54ZI3-PDJSU-A",
      "RequestStatus": "Reply",
      "Response": {
        "unprotected": {
          "dig": "S512"},
        "payload": "
ewogICJUQlNSZXNwb25zZSI6IHsKICAgICJTaWduZWRSZXF1ZXN0IjogewogICAg
ICAidW5wcm90ZWN0ZWQiOiB7CiAgICAgICAgImRpZyI6ICJTNTEyIn0sCiAgICAg
...
MVRCUTdMUldSZkEifV19LAogICAgIlZhbHVlIjogdHJ1ZX19"
,
        "signatures": [{
            "header": {
              "kid": "MCGN2-CNR2S-XBPYD-M6M44-URSSY-VPYFO"},
            "protected": "
ewogICJhbGciOiAiUlM1MTIiLAogICJ2YWwiOiAiCm4wcXZOOGZvRlU2cUI4VEpS
SmxxUnk4YmRWSkEydDllVnFJNDFxOFQ0WVVxY3ZmbXFmaVlYUGZwcjRRRXRaX3AK
UHV0cG0zQUFEVEZPNWUtTWs3dzFJdyJ9"
,
            "signature": "
VrAtI86e1pjxa6fAX9amph-5GQsDIZ0EN7XQbQT2cdWXKQWQdjXbtOTpaQ3t8QV4
fO8NA6lFkBqzT-wWA38QTjf1V2-Q2IB0mLSvMKYCWrHNHygBkdis7FHmP68XXo9E
Nd3j4RhB2cl-72lDHXF0YKL6u3KnFG7MHgScT-SRxLQ0YLQzT1Pz-PbUWWCXK0pJ
5Jra78gEFLQt_vtF7WKwQ5a_FhQkTPdDlCzXYlX-XIgmEVzYq5RV7QwU8wB3gWxs
byWMUTC23W1xne1fkZ-5o72NbYc3cLUAV8cK2-YS5kVnYU6gDVxrLGbh36erll41
n2fy_4XVWGo7uf3aZpRAUA"
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








