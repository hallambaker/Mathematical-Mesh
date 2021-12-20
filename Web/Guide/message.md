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
<rsp>Envelope ID: MBD2-SNOX-GQ4O-EP2P-KPXY-4OMJ-EPI4
Message ID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
Response ID: MBB7-ZU3T-CLUR-BTNY-3UI5-FNEH-FDUV
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
        Contact Request::
        MessageID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
        To: alice@example.com From: bob@example.com
        PIN: AB4L-U4J7-LLTR-ERNG-QPQP-DHZO-CGLQ
MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        Group invitation::
        MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        To: alice@example.com From: alice@example.com
MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        Confirmation Request::
        MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
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
<rsp>Entry<CatalogedContact>: MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Person MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Anchor MDKO-KEIN-OCN2-C6UB-VS2K-TNA4-WXVJ
  Address alice@example.com

Entry<CatalogedContact>: ND3C-FKIQ-OBU3-V4JR-DEKG-XMPY-TQMH
  Person 
  Anchor MCP6-3M76-EWWZ-BD3D-VAMF-HJ6X-H7A4
  Address bob@example.com

Entry<CatalogedContact>: NCLZ-GAKI-BJC2-IHNB-RPF6-LOZP-YRSE
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
  Address groupw@example.com

Entry<CatalogedContact>: NDTC-2PDB-IB3B-MKSY-E4NR-ZJQB-UKOF
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
  Address groupw@example.com

Entry<CatalogedContact>: NBEH-4E2S-U5T2-6IFK-BZSV-SISO-AY5X
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
  Address groupw@example.com

Entry<CatalogedContact>: NBNJ-CW7O-UPNW-UAOF-LWME-TWPL-2QTQ
  Person 
  Anchor MDXI-T5OT-YIXR-OLTB-YW7L-HKZC-OOT7
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
<rsp>Envelope ID: MCG6-KORP-RH2E-275I-PCMR-PNOH-HSEM
Message ID: NCSF-HZDX-U33H-7DDN-3GTI-N6Z7-43G4
Response ID: MAK3-SFSS-JZ25-E26S-VC6T-NYY6-AQLK
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NCSF-HZDX-U33H-7DDN-3GTI-N6Z7-43G4
        Confirmation Request::
        MessageID: NCSF-HZDX-U33H-7DDN-3GTI-N6Z7-43G4
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
        Contact Request::
        MessageID: NAMZ-G5FP-OHEH-74PH-ZIII-IYCP-IOJ4
        To: alice@example.com From: bob@example.com
        PIN: AB4L-U4J7-LLTR-ERNG-QPQP-DHZO-CGLQ
MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        Group invitation::
        MessageID: NBLB-D3DX-6Z6Z-PQCS-4NEO-RQGQ-HQUL
        To: alice@example.com From: alice@example.com
MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        Confirmation Request::
        MessageID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        Contact Request::
        MessageID: NAHB-XJ7W-IEJY-NB4D-27UK-Y2HS-WPEA
        To: alice@example.com From: bob@example.com
        PIN: AA3C-HQL4-JNCZ-BJTD-IVOS-G5KU-2YIA
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
<rsp>Envelope ID: MC3R-ARND-HP2H-OYNE-CAEV-6DXM-CBNT
Message ID: NBQI-7KHS-7VFB-ZIFC-NDNO-2IUX-UUHT
Response ID: MDH4-DX42-VZ5W-63OS-XHF5-RLTJ-F4RY
</div>
~~~~

Mallet cannot respond to the request sent by Bob because he can't read Alice's
messages to discover the request to reply to. Nor can he create a valid signature
on the response should this information be accidentally disclosed.

