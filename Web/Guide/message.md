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
<rsp>Envelope ID: MBAU-H34I-FU2B-3TEF-LTMG-RT5T-GYRC
Message ID: NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
Response ID: MBR6-OL3R-4XVW-T26E-DT2C-S6SB-D4QI
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NADI-GEER-FWSC-XCKV-PJX6-GNFT-CZPV
        Contact Request::
        MessageID: NADI-GEER-FWSC-XCKV-PJX6-GNFT-CZPV
        To: alice@example.com From: mallet@example.com
        PIN: AAYS-2FTM-ZVBZ-BJVP-PUAF-YJGN-IPWQ
MessageID: NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
        Contact Request::
        MessageID: NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
        To: alice@example.com From: bob@example.com
        PIN: AABI-JVOW-MNSQ-TKJ3-UJ7T-HKTF-T3PQ
MessageID: NCDS-JZQ5-N633-ZKWA-7U5I-6LNU-PFT5
<cmd>Alice> meshman message accept NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Person MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Anchor MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Address alice@example.com

Entry<CatalogedContact>: NCQT-M4X2-LSIJ-GRPC-FUXJ-YIK7-KV33
  Person 
  Anchor MBQN-O35O-S5NJ-XZ5K-7RRD-NAMW-VN6H
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Person MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Anchor MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Address alice@example.com

Entry<CatalogedContact>: NCQT-M4X2-LSIJ-GRPC-FUXJ-YIK7-KV33
  Person 
  Anchor MBQN-O35O-S5NJ-XZ5K-7RRD-NAMW-VN6H
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
<cmd>Alice> meshman message reject NADI-GEER-FWSC-XCKV-PJX6-GNFT-CZPV
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
<rsp>Envelope ID: MAUG-SBGB-ESSM-LNTK-7W4N-TZOR-QPRT
Message ID: NCCP-EY2P-JOLB-Y6CP-62LW-N66N-LJ2K
Response ID: MBCT-5DTN-PGSG-FHIA-7KM6-YEF4-BD7J
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NCXJ-O4KW-TYR2-NLAH-IMBE-XRMZ-6LEW
        Confirmation Request::
        MessageID: NCXJ-O4KW-TYR2-NLAH-IMBE-XRMZ-6LEW
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCCP-EY2P-JOLB-Y6CP-62LW-N66N-LJ2K
        Confirmation Request::
        MessageID: NCCP-EY2P-JOLB-Y6CP-62LW-N66N-LJ2K
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NBO6-PMM3-RAWS-FXXA-OGRB-2RSW-U32O
        Contact Request::
        MessageID: NBO6-PMM3-RAWS-FXXA-OGRB-2RSW-U32O
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBVM-E7SA-FVGJ-BOHH-FV7P-YI5C-RFP2
MessageID: NBHK-3QNB-UGZT-H5XN-2CXU-RIL7-XJZY
MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        Confirmation Request::
        MessageID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDYX-HZYP-X7E3-4UR4-LH7A-BQMT-PQXJ
MessageID: NDXB-RN25-2RVC-F3FL-FULX-GQNG-TAYB
MessageID: NCDS-JZQ5-N633-ZKWA-7U5I-6LNU-PFT5
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NCCP-EY2P-JOLB-Y6CP-62LW-N66N-LJ2K
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status MBCT-5DTN-PGSG-FHIA-7KM6-YEF4-BD7J
<rsp>Accept
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NCXJ-O4KW-TYR2-NLAH-IMBE-XRMZ-6LEW
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status MCQW-Q2SB-PRMW-EBHX-3R6B-UCMR-X7ZU
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

