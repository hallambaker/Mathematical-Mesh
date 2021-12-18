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
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MATB-4AMD-PDBP-VKTJ-SNIZ-ZRZB-WWRR
Message ID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
Response ID: MB5A-R3RP-B2KE-YFC5-U3JU-T5TO-GICN
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
        Contact Request::
        MessageID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
        To: alice@example.com From: bob@example.com
        PIN: AAPI-4OUO-YUQZ-7SXT-PRM7-KOAM-2EGA
MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        Group invitation::
        MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        To: alice@example.com From: alice@example.com
MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        Confirmation Request::
        MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        Contact Request::
        MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        To: alice@example.com From: bob@example.com
        PIN: AB3F-U7X5-Q2PE-ESFS-S2PH-7AGC-TKBA
</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Person MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Anchor MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Address alice@example.com

Entry<CatalogedContact>: NAWB-M7G7-OXPC-I6YS-SIXH-JQ7E-OOXA
  Person 
  Anchor MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG
  Address bob@example.com

Entry<CatalogedContact>: NBLD-QB2F-UVQD-MHP5-PHY3-J2MO-YUKD
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

Entry<CatalogedContact>: NDXP-NDKS-PFFD-WBA7-VQ74-5KM5-355Y
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

Entry<CatalogedContact>: NCC4-BLBH-RHO3-UHOG-YRJO-W4J2-JCNL
  Person 
  Anchor MCIG-57G4-CKMG-SLW5-I75I-LQNC-J5MK
  Address groupw@example.com

</div>
~~~~

Bob can find out if Alice has accepted his contact request using the 
`message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status tbs
<rsp>Pending
</div>
~~~~

Alice has accepted Bob's request and added him to her contacts list. She has also sent
Bob a contact request which for the sake of convenience, is accepted automatically.

Alice isn't required to accept contact requests. She rejects the request from Mallet 
using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject tbs
<rsp>ERROR - The specified message could not be found.
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

Alice sends Bob an email asking him to buy some equipment costing $6,000. Since this
is a significant sum, Bob needs an authorization for the purchase. He sends Alice
a confirmation request `Purchase equipment for $6,000?` using the  
`message confirm` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for ^
    $6,000?"
<rsp>Envelope ID: MCTO-U5LM-SCZU-GEQ6-VGRE-2VWP-ALZT
Message ID: NAIC-ZEKO-AOAR-2DMY-5B3W-J3MD-LHH4
Response ID: MCS5-G7NX-KTKD-RE6X-7YZX-BIQF-I55E
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NAIC-ZEKO-AOAR-2DMY-5B3W-J3MD-LHH4
        Confirmation Request::
        MessageID: NAIC-ZEKO-AOAR-2DMY-5B3W-J3MD-LHH4
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
        Contact Request::
        MessageID: NAPF-EUXY-TEQV-J34J-QTFZ-HBJI-GHNM
        To: alice@example.com From: bob@example.com
        PIN: AAPI-4OUO-YUQZ-7SXT-PRM7-KOAM-2EGA
MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        Group invitation::
        MessageID: NDZE-G3GP-G45D-WAOM-SXOH-24EC-JED2
        To: alice@example.com From: alice@example.com
MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        Confirmation Request::
        MessageID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        Contact Request::
        MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        To: alice@example.com From: bob@example.com
        PIN: AB3F-U7X5-Q2PE-ESFS-S2PH-7AGC-TKBA
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status tbs
<rsp>Pending
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject tbs
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Bob> meshman message status tbs
<rsp>Pending
</div>
~~~~

As with all Mesh messages, confirmation requests are subject to access control.
When Mallet attempts to make a request of Alice, it is rejected because Alice
hasn't accepted his credentials or authorized him to send confirmation requests:


~~~~
Missing example 52
~~~~


