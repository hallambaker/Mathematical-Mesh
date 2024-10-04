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
<rsp>Envelope ID: MAQZ-5I5U-RM2L-A6L5-HDQL-GPP5-LYKY
Message ID: NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
Response ID: MBIU-SC6Z-NNEF-4463-L2WK-UUQ6-5ELH
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NAF3-GGMH-PTI3-NHTN-F5SU-XMHC-UCU5
        Contact Request::
        MessageID: NAF3-GGMH-PTI3-NHTN-F5SU-XMHC-UCU5
        To: alice@example.com From: mallet@example.com
        PIN: ABUK-CGY3-NTGJ-QMIM-LPTM-RDCE-CVMA
MessageID: NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
        Contact Request::
        MessageID: NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
        To: alice@example.com From: bob@example.com
        PIN: ADUJ-IRU6-RAPP-K6KB-EJ3U-DRDB-KWKA
MessageID: NADD-B6K4-SDGI-BSJX-SKLV-R2X5-IPYH
<cmd>Alice> meshman message accept NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Person MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Anchor MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Address alice@example.com

Entry<CatalogedContact>: NB4A-ZXEH-I6SL-XNQ6-MN5E-C5MB-JNJ6
  Person 
  Anchor MBQN-CAEX-IDBY-ZSEK-HCAC-OBZB-JLSA
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NCXX-LH2E-SJMD-H2LI-J7KB-DJV2-45UR
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Person MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Anchor MBQK-54VC-H3HR-TYBH-ZIE6-VVIY-ZNPA
  Address alice@example.com

Entry<CatalogedContact>: NB4A-ZXEH-I6SL-XNQ6-MN5E-C5MB-JNJ6
  Person 
  Anchor MBQN-CAEX-IDBY-ZSEK-HCAC-OBZB-JLSA
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
<cmd>Alice> meshman message reject NAF3-GGMH-PTI3-NHTN-F5SU-XMHC-UCU5
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
<rsp>Envelope ID: MDTV-BRGV-DILE-POGZ-JZPE-X3OL-SKUW
Message ID: NA26-KNMO-Y5GI-HLZL-SROC-OZMC-TEDT
Response ID: MDFN-2P5U-GTV7-TG7T-JO4S-CSTN-RYOO
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NAUT-J3JS-GKV6-YH3V-7WIU-46W4-Y6ZM
        Confirmation Request::
        MessageID: NAUT-J3JS-GKV6-YH3V-7WIU-46W4-Y6ZM
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NA26-KNMO-Y5GI-HLZL-SROC-OZMC-TEDT
        Confirmation Request::
        MessageID: NA26-KNMO-Y5GI-HLZL-SROC-OZMC-TEDT
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAHP-52ZQ-2W3U-GZ36-FUXX-UCFU-4GY5
        Contact Request::
        MessageID: NAHP-52ZQ-2W3U-GZ36-FUXX-UCFU-4GY5
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NDR2-72HA-DLC7-JBPZ-3UGL-BGJ5-FFYC
MessageID: NAPX-XU4B-T4ET-JQOC-TTUN-EXCZ-2BSR
MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        Confirmation Request::
        MessageID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NANH-ZJY3-4XRC-G3WA-WMFB-DFU6-HW3X
MessageID: NA5L-OBCK-V3V3-VRBZ-4ISE-GB3B-VR64
MessageID: NADD-B6K4-SDGI-BSJX-SKLV-R2X5-IPYH
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NA26-KNMO-Y5GI-HLZL-SROC-OZMC-TEDT
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status MDFN-2P5U-GTV7-TG7T-JO4S-CSTN-RYOO
<rsp>Accept
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NAUT-J3JS-GKV6-YH3V-7WIU-46W4-Y6ZM
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status MCVQ-MMZP-LSCH-CL7M-VT6S-N3D3-OMY6
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

