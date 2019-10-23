
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
Bob> message contact alice@example.com
````

Alice reviews her pending messages using the `message pending` command:


````
Alice> message pending
````

Alice sees the request from Bob and accepts it with the `message accept` command:


````
Alice> message accept tbs
````

Bob's contact information has been added to Alice's address book:


````
Alice> contact list
{
  "Self": true,
  "Key": "NBPF-4GB4-72MA-2CPF-U2NR-5KBX-GFPK",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}{
  "Self": false,
  "Key": "NDZH-TUDS-B6TS-R2YL-VQYH-E6F4-ULN5",
  "EnvelopedContact": [{},
    "ewogICJDb250YWN0IjogewogICAgIkFkZHJlc3Nlcy
  I6IFt7CiAgICAgICAgIlVSSSI6ICJtYWlsdG86e2VtYWlsfSJ9XX19"]}````

Bob can find out if Alice has accepted his contact request using the 
`message status` command:


````
Bob> message status tbs
ERROR - The feature has not been implemented
````

Alice has accepted Bob's request and added him to her contacts list. She has also sent
Bob a contact request which for the sake of convenience, is accepted automatically.

Alice isn't required to accept contact requests. She rejects the request from Mallet 
using the `message reject` command:


````
Alice> message reject tbs
````

For good measure, she decides to block further requests:


````
Alice> message block mallet@example.com
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
Bob> message confirm alice@example.com "Purchase equipment for $6,000?"
````

Alice reviews her pending messages using the using the `message pending` command:


````
Alice> message pending
````

Alice she accepts Bob's request using the `message pending` command:


````
Alice> message accept tbs
````

Bob receives Alice's approval using the `message status` command:


````
Bob> message status tbs
ERROR - The feature has not been implemented
````

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


````
Alice> message reject tbs
````

Bob receives a reply telling him the request was rejected:


````
Bob> message status tbs
ERROR - The feature has not been implemented
````

As with all Mesh messages, confirmation requests are subject to access control.
When Mallet attempts to make a request of Alice, it is rejected because Alice
hasn't accepted his credentials or authorized him to send confirmation requests:


````
Mallet> message confirm alice@example.com "Purchase equipment for $6,000?"
ERROR - The feature has not been implemented
````


