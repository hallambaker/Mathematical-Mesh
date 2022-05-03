<title>message
# Using the message Command Set

The `message` command set contains commands that send, receive and respond to 
Mesh transactional messages. Currently, two Mesh messaging applications are defined:

<dl>
<dt>Contact
<dd>Contact messages allow exchange of contact information. If a contact request
is accepted, the contact details are added to the recipient's contact catalog.
<dt>Confirmation
<dd>Confirmation messages allow authorized senders to ask for a specific request 
to be accepted or denied. If the recpient replies to a confirmation message, a
signed response is returned stating the user's response.</dd>
</dl>


# Contact Request

The Contacts catalog plays an important role in Mesh messaging as it is used to
determine the recipient's security policy to be applied to outbound messages and 
perform access control on inbound messages.

Having created a Mesh profile, Bob asks Alice to add him to her contacts catalog
using the `message contact` command:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MCJW-X2TB-QWWK-XEJY-NARU-GI5V-W7XA
Message ID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
Response ID: MBUW-RS2J-YLXC-R7S5-B6LV-2O7Z-IJCK
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBQQ-VHXI-3DZX-6KA3-UN3O-4J7B-MHKG
        Contact Request::
        MessageID: NBQQ-VHXI-3DZX-6KA3-UN3O-4J7B-MHKG
        To: alice@example.com From: mallet@example.com
        PIN: ADFW-BULY-6SM6-BWJ7-FI4H-COZ4-RLBA
MessageID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
        Contact Request::
        MessageID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
        To: alice@example.com From: bob@example.com
        PIN: ADHE-RV4P-ETST-FW3C-RIY3-MUQF-NC6Q
<cmd>Alice> meshman message accept NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

</div>
~~~~

Bob can find out if Alice has accepted his contact request using the 
`message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status
<rsp>Pending
</div>
~~~~

Alice has accepted Bob's request and added him to her contacts list. She has also sent
Bob a contact request which for the sake of convenience, is accepted automatically.

Alice isn't required to accept contact requests. She rejects the request from Mallet 
using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NBQQ-VHXI-3DZX-6KA3-UN3O-4J7B-MHKG
</div>
~~~~

For good measure, she decides to block further requests:


~~~~
<div="terminal">
<cmd>Alice> meshman message block mallet@example.com
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

The confirmation message exchange provides a form of second factor authentication in
which the user provides explicit, non-repudiable authorization for a specific action.

Alice sends Bob an email asking him to buy some equipment costing $6,000. Since this
is a significant sum, Bob needs an authorization for the purchase. He sends Alice
a confirmation request `Purchase equipment for $6,000?` using the  
`message confirm` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for ^
    $6,000?"
<rsp>Envelope ID: MBTA-FL7V-7BFD-L4YT-PDQV-4B6H-NMH7
Message ID: NAGI-LWB2-E2YE-YCOX-E5AQ-W6KJ-KWC5
Response ID: MC3K-EBK7-WJCL-LDN4-BXJ4-XYPN-O4QZ
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NBT7-KOGL-6HG3-KLNO-SXJN-3TRC-WD5W
        Confirmation Request::
        MessageID: NBT7-KOGL-6HG3-KLNO-SXJN-3TRC-WD5W
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NAGI-LWB2-E2YE-YCOX-E5AQ-W6KJ-KWC5
        Confirmation Request::
        MessageID: NAGI-LWB2-E2YE-YCOX-E5AQ-W6KJ-KWC5
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NBSD-MRON-A3ED-M7Y6-M7N6-YMV3-J4RZ
        Contact Request::
        MessageID: NBSD-MRON-A3ED-M7Y6-M7N6-YMV3-J4RZ
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        Confirmation Request::
        MessageID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
        To: alice@example.com From: console@example.com
        Text: start
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBT7-KOGL-6HG3-KLNO-SXJN-3TRC-WD5W
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status NBT7-KOGL-6HG3-KLNO-SXJN-3TRC-WD5W
<rsp>Pending
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NAGI-LWB2-E2YE-YCOX-E5AQ-W6KJ-KWC5
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status NAGI-LWB2-E2YE-YCOX-E5AQ-W6KJ-KWC5
<rsp>Pending
</div>
~~~~

As with all Mesh messages, confirmation requests are subject to access control.
When Mallet attempts to make a request of Alice, it is rejected because Alice
hasn't accepted his credentials or authorized him to send confirmation requests:


~~~~
Missing example 5
~~~~

Mallet cannot respond to the request sent by Bob because he can't read Alice's
messages to discover the request to reply to. Nor can he create a valid signature
on the response should this information be accidentally disclosed.

