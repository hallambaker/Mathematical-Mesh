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
<rsp>Envelope ID: MBVY-XORI-2GVR-6J4M-RNXQ-RSQJ-XPTU
Message ID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
Response ID: MAHD-CP2A-XRAI-REOV-ILAZ-A3SE-BAPP
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBUX-W5FA-DICN-CBHX-FENN-7TIV-IITD
        Contact Request::
        MessageID: NBUX-W5FA-DICN-CBHX-FENN-7TIV-IITD
        To: alice@example.com From: mallet@example.com
        PIN: ADN2-K5ZO-TB4H-RTCQ-S3Q6-LKEA-FAKQ
MessageID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
        Contact Request::
        MessageID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
        To: alice@example.com From: bob@example.com
        PIN: AAIS-4C4B-ZHY7-JJKX-A3RK-NQQU-WOGA
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
<cmd>Alice> meshman message accept NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Person MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

Entry<CatalogedContact>: NBWO-LXHG-76BJ-76A3-2S4Q-VHQF-J6BJ
  Person 
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Person MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

Entry<CatalogedContact>: NBWO-LXHG-76BJ-76A3-2S4Q-VHQF-J6BJ
  Person 
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

</div>
~~~~

Bob can find out if Alice has accepted his contact request using the 
`message status` command:


~~~~
Missing example 5
~~~~

Alice has accepted Bob's request and added him to her contacts list. She has also sent
Bob a contact request which for the sake of convenience, is accepted automatically.

Alice isn't required to accept contact requests. She rejects the request from Mallet 
using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NBUX-W5FA-DICN-CBHX-FENN-7TIV-IITD
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
<rsp>Envelope ID: MAAS-6YC7-DAAG-L3L2-WBL7-GBSQ-V6ZY
Message ID: NCUU-OQR5-XQHS-FFJY-E23R-MSEV-GENU
Response ID: MC3C-6L5B-UYS2-KSGP-BL5I-CALU-KTKK
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NABA-V3FF-P7VT-YAWQ-OPCO-VDGA-SGEW
        Confirmation Request::
        MessageID: NABA-V3FF-P7VT-YAWQ-OPCO-VDGA-SGEW
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCUU-OQR5-XQHS-FFJY-E23R-MSEV-GENU
        Confirmation Request::
        MessageID: NCUU-OQR5-XQHS-FFJY-E23R-MSEV-GENU
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NB4E-NQIR-FRPV-6XCH-GMCZ-NTB7-RHZW
        Contact Request::
        MessageID: NB4E-NQIR-FRPV-6XCH-GMCZ-NTB7-RHZW
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBB4-CUJO-MBE4-ZYUM-SJR2-W2IE-JKAO
MessageID: NDN7-5NYH-LD43-4TCU-YJWW-Z37V-GYTG
MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        Confirmation Request::
        MessageID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NBJL-SNE5-XPQV-PO5I-RN52-SZHY-E4DZ
MessageID: NDCJ-UV2Z-2FNH-WOK3-46NP-M4PY-MMTJ
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NCUU-OQR5-XQHS-FFJY-E23R-MSEV-GENU
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status MC3C-6L5B-UYS2-KSGP-BL5I-CALU-KTKK
<rsp>Accept
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NABA-V3FF-P7VT-YAWQ-OPCO-VDGA-SGEW
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status MDIQ-KWSM-V4NT-7OX3-NZC7-F5XQ-VPOZ
<rsp>Reject
</div>
~~~~

As with all Mesh messages, confirmation requests are subject to access control.
When Mallet attempts to make a request of Alice, it is rejected because Alice
hasn't accepted his credentials or authorized him to send confirmation requests:


~~~~
Missing example 6
~~~~

Mallet cannot respond to the request sent by Bob because he can't read Alice's
messages to discover the request to reply to. Nor can he create a valid signature
on the response should this information be accidentally disclosed.

