<title>Message
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


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S
        Contact Request::
        MessageID: NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S
        To: alice@example.com From: bob@example.com
        PIN: AAU2-ZQK6-Z347-NRY6-IOV5-W2P2-O5EQ
MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        Confirmation Request::
        MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        Contact Request::
        MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        To: alice@example.com From: bob@example.com
        PIN: AADZ-27RV-SGJA-5LIO-GHVA-2QPC-ORRA
</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH
  Person MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH
  Anchor MCDH-FIPQ-XWI3-2MLS-KZ6U-SAVO-EVSH
  Address alice@example.com

</div>
~~~~

Bob can find out if Alice has accepted his contact request using the 
`message status` command:


~~~~
<div="terminal">
<cmd>Bob> message status tbs
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

Alice has accepted Bob's request and added him to her contacts list. She has also sent
Bob a contact request which for the sake of convenience, is accepted automatically.

Alice isn't required to accept contact requests. She rejects the request from Mallet 
using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> message reject tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

For good measure, she decides to block further requests:


~~~~
<div="terminal">
<cmd>Alice> message block mallet@example.com
</div>
~~~~

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


~~~~
<div="terminal">
<cmd>Bob> message confirm alice@example.com "Purchase equipment for $6,000?"
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> message pending
<rsp>MessageID: NBPA-4YJD-P7RN-2SJJ-ZQFO-NIAD-VOEE
        Confirmation Request::
        MessageID: NBPA-4YJD-P7RN-2SJJ-ZQFO-NIAD-VOEE
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S
        Contact Request::
        MessageID: NCAR-PVBH-FMFN-NK5Y-SOLP-6WOV-VO6S
        To: alice@example.com From: bob@example.com
        PIN: AAU2-ZQK6-Z347-NRY6-IOV5-W2P2-O5EQ
MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        Confirmation Request::
        MessageID: NA3M-FCCF-P67J-CHXN-NUYJ-X267-RCH5
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        Contact Request::
        MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        To: alice@example.com From: bob@example.com
        PIN: AADZ-27RV-SGJA-5LIO-GHVA-2QPC-ORRA
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> message status tbs
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> message reject tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Bob> message status tbs
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

As with all Mesh messages, confirmation requests are subject to access control.
When Mallet attempts to make a request of Alice, it is rejected because Alice
hasn't accepted his credentials or authorized him to send confirmation requests:


~~~~
Missing example 49
~~~~


