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
<rsp>MessageID: ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7
        Contact Request::
        MessageID: ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7
        To: alice@example.com From: bob@example.com
        PIN: AC2Z-MDNH-J3CC-T2OP-Z36L-CJF4-75WQ
MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        Confirmation Request::
        MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        Contact Request::
        MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        To: alice@example.com From: bob@example.com
        PIN: ACQ6-HOEL-5EOQ-OKX4-XIX5-ZUSS-JGIA
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
<rsp>Entry<CatalogedContact>: MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Person MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Anchor MCR2-U4OO-FBV3-6BSP-WKEQ-4QOG-QSAV
  Address alice@example.com

Entry<CatalogedContact>: NC6S-FHAS-TTJX-5VFB-B57Z-JOG3-DJDA
  Person 
  Anchor MCNN-EDO6-GYYF-2H2H-IJTV-KXQZ-TXXJ
  Address bob@example.com

Entry<CatalogedContact>: NBYD-QOZ3-BUQJ-QTYU-YPZJ-SCXL-LA64
  Person 
  Anchor MCL5-XUKG-CQ6T-ASVR-6RP5-X2C3-BL2L
  Address groupw@example.com

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
<rsp>MessageID: NDUY-KIYX-RINT-7N5B-JY3H-JERJ-QVQG
        Confirmation Request::
        MessageID: NDUY-KIYX-RINT-7N5B-JY3H-JERJ-QVQG
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7
        Contact Request::
        MessageID: ND5A-QIRU-VE3S-DA6R-CJDO-3RUB-KIR7
        To: alice@example.com From: bob@example.com
        PIN: AC2Z-MDNH-J3CC-T2OP-Z36L-CJF4-75WQ
MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        Confirmation Request::
        MessageID: NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        Contact Request::
        MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        To: alice@example.com From: bob@example.com
        PIN: ACQ6-HOEL-5EOQ-OKX4-XIX5-ZUSS-JGIA
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


