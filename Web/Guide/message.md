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
signed response is returned stating the user's response.
</dl>


# Contact Request

The Contacts catalog plays an important role in Mesh messaging as it is used to
determine the recipient's security policy to be applied to outbound messages and 
perform access control on inbound messages.

Having created a Mesh profile, Bob asks Alice to add him to her contacts catalog
using the `message contact` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MCRS-QOBP-HDE4-LOXR-CZ72-YGSZ-UI6B
Message ID: NAI7-GORK-6QDL-CRCT-XJHC-CG4P-VNIS
Response ID: MD6W-HVP4-COYF-AXM5-5TE7-GHUJ-DZFA
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NAI7-GORK-6QDL-CRCT-XJHC-CG4P-VNIS
        Contact Request::
        MessageID: NAI7-GORK-6QDL-CRCT-XJHC-CG4P-VNIS
        To: alice@example.com From: bob@example.com
        PIN: ACJZ-GFMD-MOFZ-RQKP-IQ3L-56BK-WURA
MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        Group invitation::
        MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        To: alice@example.com From: alice@example.com
MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        Confirmation Request::
        MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
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
<rsp>Entry<CatalogedContact>: MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Person MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Anchor MDLW-3UK4-IFWN-QV3C-LUAP-2JXB-VYXM
  Address alice@example.com

Entry<CatalogedContact>: NAQN-NQDL-LKHW-DY3U-QAFS-N2LW-6DHS
  Person 
  Anchor MCKB-VDWV-FXBV-ZEQC-62VO-UWU7-RKYC
  Address bob@example.com

Entry<CatalogedContact>: NBJM-J77F-WGI4-U42M-A273-L4LO-KUL4
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBYB-VQJX-5JFD-M35Q-OFJD-TXNQ-R3A2
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
  Address groupw@example.com

Entry<CatalogedContact>: NBDI-IEHI-35UN-DNGC-KVZN-37NZ-DCIH
  Person 
  Anchor MCXX-WFN3-4M63-LOT6-PO7W-PDME-JZCK
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
<rsp>Envelope ID: MDAB-MZBA-CXZJ-SWFW-TNFI-J5YP-V4WT
Message ID: NDS6-NWK7-4JYJ-ZQG3-VAEZ-JEYX-YSAE
Response ID: MAT5-O3G2-YC2V-TATX-VAXN-TVBD-2G3A
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NDS6-NWK7-4JYJ-ZQG3-VAEZ-JEYX-YSAE
        Confirmation Request::
        MessageID: NDS6-NWK7-4JYJ-ZQG3-VAEZ-JEYX-YSAE
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAI7-GORK-6QDL-CRCT-XJHC-CG4P-VNIS
        Contact Request::
        MessageID: NAI7-GORK-6QDL-CRCT-XJHC-CG4P-VNIS
        To: alice@example.com From: bob@example.com
        PIN: ACJZ-GFMD-MOFZ-RQKP-IQ3L-56BK-WURA
MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        Group invitation::
        MessageID: NCUH-QEYI-3V6A-IQ7Z-6RHR-IPLZ-4MMK
        To: alice@example.com From: alice@example.com
MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        Confirmation Request::
        MessageID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        Contact Request::
        MessageID: NB37-AILO-UATX-5MSL-SE5J-VW2M-ZIYL
        To: alice@example.com From: bob@example.com
        PIN: ACPD-YENT-3EM4-PUHD-D4Q4-4TX5-C25A
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
<div="terminal">
<cmd>Mallet> meshman message confirm alice@example.com "Purchase equipment ^
    for $6,000?"
<rsp>Envelope ID: MC4Y-MBEX-AESY-O7KD-RIHX-LOHB-BW3N
Message ID: NAGW-UCHM-Y4IZ-A44R-NQ6Y-JF47-FOVC
Response ID: MAPP-H6J7-HEB5-S4EW-EIEO-GTWK-D7IW
</div>
~~~~

Mallet cannot respond to the request sent by Bob because he can't read Alice's
messages to discover the request to reply to. Nor can he create a valid signature
on the response should this information be accidentally disclosed.

