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
<rsp>Envelope ID: MDN4-KZU4-YSH5-HFIZ-7Y5K-TKXM-TLRE
Message ID: NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
Response ID: MANS-AVVY-VD36-MFEX-3XUR-PPTU-KSPD
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: ND6M-OIPE-KYSW-HJCU-C6VY-XXBC-BCKU
        Contact Request::
        MessageID: ND6M-OIPE-KYSW-HJCU-C6VY-XXBC-BCKU
        To: alice@example.com From: mallet@example.com
        PIN: AB5G-ONJA-7REW-O3HH-XGTD-N47M-TPQQ
MessageID: NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
        Contact Request::
        MessageID: NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
        To: alice@example.com From: bob@example.com
        PIN: AB3A-ETHW-4RGL-GEYG-KEAP-TLEM-UKDQ
MessageID: NDHA-E73C-WZUG-QCMR-5IPX-52JV-WYX6
<cmd>Alice> meshman message accept NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Person MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Anchor MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Address alice@example.com

Entry<CatalogedContact>: NCUE-TSMR-TL3E-7MV6-N3KA-YQX3-UTZ4
  Person 
  Anchor MBQM-MRAS-TBEC-OOLM-NPQY-XF7O-KQME
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NAJJ-X5FX-POHN-TTR4-3TXK-KTE7-3KKM
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Person MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Anchor MBQC-7OHA-RNBA-FRDL-R4GI-YQHA-DL36
  Address alice@example.com

Entry<CatalogedContact>: NCUE-TSMR-TL3E-7MV6-N3KA-YQX3-UTZ4
  Person 
  Anchor MBQM-MRAS-TBEC-OOLM-NPQY-XF7O-KQME
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
<cmd>Alice> meshman message reject ND6M-OIPE-KYSW-HJCU-C6VY-XXBC-BCKU
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
<rsp>Envelope ID: MDOV-RZKZ-3YB5-DOUQ-MN3A-ADG5-CONV
Message ID: NA4S-PTKA-TB7E-ZKBG-2A2H-XTBY-7JUM
Response ID: MALF-PURQ-NMLN-6Z3C-VBH7-5MCI-WPHH
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NBOA-TY35-OY5Y-C5ZH-PXZ6-BVKU-4YGO
        Confirmation Request::
        MessageID: NBOA-TY35-OY5Y-C5ZH-PXZ6-BVKU-4YGO
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NA4S-PTKA-TB7E-ZKBG-2A2H-XTBY-7JUM
        Confirmation Request::
        MessageID: NA4S-PTKA-TB7E-ZKBG-2A2H-XTBY-7JUM
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NCEV-GJQW-H2J5-OXM5-MDFG-VLS5-7BQ2
        Contact Request::
        MessageID: NCEV-GJQW-H2J5-OXM5-MDFG-VLS5-7BQ2
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NDVR-22QE-MJFX-NIXO-VWED-H5PP-HFMI
MessageID: NCX7-ADC5-L2CD-W5IY-SFT4-NX2U-XZQL
MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        Confirmation Request::
        MessageID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANN-LZ5N-6AHO-AOBD-VD6I-X7C3-GJHY
MessageID: NBCN-N55H-QYZX-F2TB-U5R3-2T6B-5W47
MessageID: NDHA-E73C-WZUG-QCMR-5IPX-52JV-WYX6
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NA4S-PTKA-TB7E-ZKBG-2A2H-XTBY-7JUM
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status MALF-PURQ-NMLN-6Z3C-VBH7-5MCI-WPHH
<rsp>Accept
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NBOA-TY35-OY5Y-C5ZH-PXZ6-BVKU-4YGO
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status MCCY-PMNS-63D3-MNFI-PO2K-GGQ5-ZTUY
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

