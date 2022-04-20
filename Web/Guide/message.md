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
<rsp>Envelope ID: MCB5-SD6X-OUXX-JAQI-6ZBM-G4FS-TYAE
Message ID: NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
Response ID: MAPM-XKGB-KZ4A-ZAST-JLFX-N4WD-RMIT
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NAUE-PMNN-4RNJ-E3AW-J4KO-QIVG-PRO6
        Contact Request::
        MessageID: NAUE-PMNN-4RNJ-E3AW-J4KO-QIVG-PRO6
        To: alice@example.com From: mallet@example.com
        PIN: ADCN-FXJI-Q27K-AI5W-O4P7-KU6H-AIGA
MessageID: NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
        Contact Request::
        MessageID: NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
        To: alice@example.com From: bob@example.com
        PIN: ADFZ-RDXJ-IICY-KX57-X6LH-ABQY-IBKQ
<cmd>Alice> meshman message accept NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Person MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Anchor MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Address alice@example.com

Entry<CatalogedContact>: NA2N-NMA3-3OLA-B65Y-JSYR-WDIO-DGBE
  Person 
  Anchor MDRS-IKMP-S6SZ-MR5M-GOIJ-SIHS-W5SJ
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Person MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Anchor MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Address alice@example.com

Entry<CatalogedContact>: NA2N-NMA3-3OLA-B65Y-JSYR-WDIO-DGBE
  Person 
  Anchor MDRS-IKMP-S6SZ-MR5M-GOIJ-SIHS-W5SJ
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
<cmd>Alice> meshman message reject NAUE-PMNN-4RNJ-E3AW-J4KO-QIVG-PRO6
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
<rsp>Envelope ID: MBZW-OH3K-VUVV-PNTO-46U7-3WQT-U5PZ
Message ID: NCOI-775L-BMOW-ZEKQ-YPJQ-IFKG-7MKQ
Response ID: MALI-ZFTF-2THP-PJVA-BWLG-TAEB-2363
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NCEW-LXRK-IUA3-DHU5-CDU6-VZNB-C2GP
        Confirmation Request::
        MessageID: NCEW-LXRK-IUA3-DHU5-CDU6-VZNB-C2GP
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCOI-775L-BMOW-ZEKQ-YPJQ-IFKG-7MKQ
        Confirmation Request::
        MessageID: NCOI-775L-BMOW-ZEKQ-YPJQ-IFKG-7MKQ
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: ND3G-IANC-6HYG-RWHJ-V3QD-33XI-PL5N
        Contact Request::
        MessageID: ND3G-IANC-6HYG-RWHJ-V3QD-33XI-PL5N
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        Confirmation Request::
        MessageID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
        To: alice@example.com From: console@example.com
        Text: start
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NCEW-LXRK-IUA3-DHU5-CDU6-VZNB-C2GP
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status NCEW-LXRK-IUA3-DHU5-CDU6-VZNB-C2GP
<rsp>Pending
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NCOI-775L-BMOW-ZEKQ-YPJQ-IFKG-7MKQ
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status NCOI-775L-BMOW-ZEKQ-YPJQ-IFKG-7MKQ
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

