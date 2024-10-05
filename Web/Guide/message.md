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
<rsp>Envelope ID: MBXA-LC4Y-JPOL-566F-XHFH-UKHT-CPYS
Message ID: NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
Response ID: MCKR-A3VX-WNTE-BPWX-7KJN-U5XF-B356
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NCJ2-ZO44-ATSC-DUIY-PYQF-HNUN-2HJC
        Contact Request::
        MessageID: NCJ2-ZO44-ATSC-DUIY-PYQF-HNUN-2HJC
        To: alice@example.com From: mallet@example.com
        PIN: ACNM-L4LA-JHOZ-HRMM-XANW-BKWF-26DA
MessageID: NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
        Contact Request::
        MessageID: NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
        To: alice@example.com From: bob@example.com
        PIN: ACGU-5FLZ-EUCZ-EBAY-LA4U-VT2K-KJQA
MessageID: ND2F-I3BZ-645E-OSBR-Z5NI-MIUG-4IRN
<cmd>Alice> meshman message accept NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Person MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Anchor MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Address alice@example.com

Entry<CatalogedContact>: NBYF-NJLS-POE7-YZJT-CWOW-T4DV-MJPQ
  Person 
  Anchor MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBQT-BJ65-V3KT-VIW7-3CPD-PLUW-VTE7
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Person MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Anchor MBQK-4S2G-TCNG-YIOL-IUI5-DTRW-IOKZ
  Address alice@example.com

Entry<CatalogedContact>: NBYF-NJLS-POE7-YZJT-CWOW-T4DV-MJPQ
  Person 
  Anchor MBQL-4JMF-6I3J-ZEZ4-YFNC-H32E-RDP5
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
<cmd>Alice> meshman message reject NCJ2-ZO44-ATSC-DUIY-PYQF-HNUN-2HJC
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
<rsp>Envelope ID: MBCK-5GUT-7VCN-PVZI-5AJ2-NCC2-BXYT
Message ID: NCWS-U7X5-KH5X-GJGQ-YMRS-JDDX-VUGY
Response ID: MBJE-NBQ6-IOXH-HHCF-JHTQ-RFCX-GL2P
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NCKP-YT3W-P6UO-RMXC-AADI-UMZU-MXHM
        Confirmation Request::
        MessageID: NCKP-YT3W-P6UO-RMXC-AADI-UMZU-MXHM
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NCWS-U7X5-KH5X-GJGQ-YMRS-JDDX-VUGY
        Confirmation Request::
        MessageID: NCWS-U7X5-KH5X-GJGQ-YMRS-JDDX-VUGY
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NCNQ-GNZL-T5OB-LMG3-QRLO-ZJJS-HLUN
        Contact Request::
        MessageID: NCNQ-GNZL-T5OB-LMG3-QRLO-ZJJS-HLUN
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NCJE-CLT3-KBMJ-PTYB-YIKW-Y776-MFA6
MessageID: NDW4-S5EU-3BER-BTL2-EA2D-C4LL-TKLA
MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        Confirmation Request::
        MessageID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NA2W-XWGB-F4LB-MUSW-MC4I-YK2G-GAJT
MessageID: NBTZ-WSA2-2OFC-QMTP-LA2D-FMRE-P4N5
MessageID: ND2F-I3BZ-645E-OSBR-Z5NI-MIUG-4IRN
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NCWS-U7X5-KH5X-GJGQ-YMRS-JDDX-VUGY
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status MBJE-NBQ6-IOXH-HHCF-JHTQ-RFCX-GL2P
<rsp>Accept
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NCKP-YT3W-P6UO-RMXC-AADI-UMZU-MXHM
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status MDLA-DA6B-I5UE-T27P-NJK5-JR3B-G35Z
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

