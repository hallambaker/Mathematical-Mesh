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
<rsp>Envelope ID: MA6Z-6YGY-7TJB-CADG-SZN3-Q6IS-6BHF
Message ID: NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
Response ID: MCN2-CAZY-X3PZ-673C-QCYR-MIQ5-TAHN
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBDK-G2OV-7H3S-BO6N-NXUZ-3PE6-ZNE4
        Contact Request::
        MessageID: NBDK-G2OV-7H3S-BO6N-NXUZ-3PE6-ZNE4
        To: alice@example.com From: mallet@example.com
        PIN: ACRO-GLXA-VJ3P-4CZ2-KQRO-J3LU-TESA
MessageID: NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
        Contact Request::
        MessageID: NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
        To: alice@example.com From: bob@example.com
        PIN: ABMH-MBQP-GX34-A7AG-ZEOL-R4XO-VGYQ
<cmd>Alice> meshman message accept NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Person MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Anchor MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Address alice@example.com

Entry<CatalogedContact>: NBL7-CLVR-MT2M-EWR5-U2NY-NWEN-IF7S
  Person 
  Anchor MDLP-RRZJ-ZASG-GUBZ-PP2K-5YDH-EMGE
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDRX-MOGE-HQ5D-FZHD-R42W-2U6V-OTKD
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Person MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Anchor MDRR-5W72-3RJO-VZB3-VUVQ-IOEC-6UNA
  Address alice@example.com

Entry<CatalogedContact>: NBL7-CLVR-MT2M-EWR5-U2NY-NWEN-IF7S
  Person 
  Anchor MDLP-RRZJ-ZASG-GUBZ-PP2K-5YDH-EMGE
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
<cmd>Alice> meshman message reject NBDK-G2OV-7H3S-BO6N-NXUZ-3PE6-ZNE4
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
<rsp>Envelope ID: MBRP-WJGJ-D2PR-SDRG-NVAU-F7RD-RULW
Message ID: NDTG-NFEV-6O5F-ATRV-HF4Z-5HMN-ADOI
Response ID: MAC5-EKZ2-SHNE-C7KE-O2VN-GHU4-GF6Q
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NAAN-AMII-QI36-DSX5-GWJ3-QQ6A-6X37
        Confirmation Request::
        MessageID: NAAN-AMII-QI36-DSX5-GWJ3-QQ6A-6X37
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NDTG-NFEV-6O5F-ATRV-HF4Z-5HMN-ADOI
        Confirmation Request::
        MessageID: NDTG-NFEV-6O5F-ATRV-HF4Z-5HMN-ADOI
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NDAN-32MX-AACC-PTBG-NYMD-7TQ4-T2UD
        Contact Request::
        MessageID: NDAN-32MX-AACC-PTBG-NYMD-7TQ4-T2UD
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
        Confirmation Request::
        MessageID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
        To: alice@example.com From: console@example.com
        Text: start
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NAAN-AMII-QI36-DSX5-GWJ3-QQ6A-6X37
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status NAAN-AMII-QI36-DSX5-GWJ3-QQ6A-6X37
<rsp>Pending
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NDTG-NFEV-6O5F-ATRV-HF4Z-5HMN-ADOI
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status NDTG-NFEV-6O5F-ATRV-HF4Z-5HMN-ADOI
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

