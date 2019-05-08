
# Using the Message Command Set

The `message` command set contains commands that send, receive and respond to 
Mesh transactional messages. Currently, two Mesh messaging applications are defined:

<dl>
<dt>Contact
<dd>Contact messages allow exchange of contact information. If a contact request
is accepted, the contact details are added to the recipient's contact catalog.
<dt>Confirmation
<dd>Confirmation messages allow authorized senders to ask for a specific request 
to be accepted or denied. If the recpient replies to a confirmation message, a
signed response is returned stating the user's response.
</dl>

For production use, most users will of course prefer a command line tool or that
the Mesh functionality be built into their prefered messaging/mail client.

# Contact Request

The Contacts catalog plays an important role in Mesh messaging as it is used to
determine the recipient's security policy to be applied to outbound messages and 
perform access control on inbound messages.

Having created a Mesh profile, Bob asks Alice to add him to her contacts catalog
using the `message contact` command:


````
>message contact alice@example.com
````

Alice reviews her pending messages using the `message pending` command:


````
>message pending
````

Alice sees the request from Bob and accepts it with the `message accept` command:


````
>message accept tbs
````

Bob's contact information has been added to Alice's address book:


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

Bob can find out if Alice has accepted his contact request using the 
`message status` command:


````
>message status tbs
````

Alice has accepted Bob's request and added him to her contacts list. She has also sent
Bob a contact request which for the sake of convenience, is accepted automatically.

Alice isn't required to accept contact requests. She rejects the request from Mallet 
using the `message reject` command:


````
>message reject tbs
````

For good measure, she decides to block further requests:


````
>message block mallet@example.com
````

The Mesh Confirmation protocol allows a message sender to ask the recipient a short
question. If the user chooses to respond, the sender receives back a non-repudiable 
answer to the question.

Currently, questions and responses are constrained to the simple binary choice 
Accept or Reject. It is possible that future versions of the protocol will permit 
more complex questions to be asked but such extension will only be considered after 
the base protocol has been extensively field tested.

Confirmation requests provide a superset of the funtionality afforded by traditional
second factor authentication systems. As with a second factor authentication system,
a confirmation response provides proof that the user approved a request but unlike
traditional systems, the proof provided is non repudiable and demonstrates that
a specific request was approved using a specific device belonging to the user.

As with the Mesh Contact application, the Confirmation application is designed for 
implementation on personal mobile devices such as watches or smartphonees making full 
use of the available graphics and other affordances.

# ConfirmationRequest

Alice sends Bob an email asking him to buy some equipment costing $6,000. Since this
is a significant sum, Bob needs an authorization for the purchase. He sends Alice
a confirmation request `Purchase equipment for $6,000?` using the  
`message confirm` command:


````
>message confirm alice@example.com "Purchase equipment for $6,000?"
````

Alice reviews her pending messages using the using the `message pending` command:


````
>message pending
````

Alice she accepts Bob's request using the `message pending` command:


````
>message accept tbs
````

Bob receives Alice's approval using the `message status` command:


````
>message status tbs
````

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


````
>message reject tbs
````

Bob receives a reply telling him the request was rejected:


````
>message status tbs
````

As with all Mesh messages, confirmation requests are subject to access control.
When Mallet attempts to make a request of Alice, it is rejected because Alice
hasn't accepted his credentials or authorized him to send confirmation requests:


````
>message confirm alice@example.com "Purchase equipment for $6,000?"
````


