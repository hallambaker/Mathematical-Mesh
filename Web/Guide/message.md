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
<rsp>Envelope ID: MAE2-VMU3-PDAH-HZX7-CGYV-75XQ-Z4EA
Message ID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
Response ID: MDNG-ME2U-6X4T-FEVR-46MH-2RLM-WCOP
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
        Contact Request::
        MessageID: ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
        To: alice@example.com From: mallet@example.com
        PIN: ACGN-LZXP-H2WB-R5UE-VGMF-VGQD-AR5Q
MessageID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
        Contact Request::
        MessageID: NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
        To: alice@example.com From: bob@example.com
        PIN: AAAZ-RZSW-ZMBI-A6R6-WTPY-INAA-OZLQ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
<cmd>Alice> meshman message accept NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Person MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

Entry<CatalogedContact>: NCIO-3ZRE-NYUC-XRNS-CDLI-HL42-EDBR
  Person 
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
  Address bob@example.com

</div>
~~~~

Alice sees the request from Bob and accepts it with the `message accept` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NAQL-6SJP-VLQD-7BNN-EB6L-DLQQ-K2ZE
</div>
~~~~

Bob's contact information has been added to Alice's address book:


~~~~
<div="terminal">
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Person MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Anchor MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2
  Address alice@example.com

Entry<CatalogedContact>: NCIO-3ZRE-NYUC-XRNS-CDLI-HL42-EDBR
  Person 
  Anchor MDCR-A2UE-SKQA-3HBF-YFO6-VQ6H-E72X
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
<cmd>Alice> meshman message reject ND2G-PHUE-PLPY-QAPP-UU6P-BAXW-EOBS
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
<rsp>Envelope ID: MDMJ-B52P-PMGN-YGIX-GRFG-I4CJ-LPIJ
Message ID: NAGC-HVFG-US7J-BANB-YHPP-7DYJ-BJAZ
Response ID: MA5G-3V7Z-BXSO-ZBLQ-V43K-EZ7Z-NR2X
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NB2W-DI3Y-VGDZ-GURG-D3AZ-LUOX-MAE5
        Confirmation Request::
        MessageID: NB2W-DI3Y-VGDZ-GURG-D3AZ-LUOX-MAE5
        To: alice@example.com From: mallet@example.com
        Text: "Purchase
MessageID: NAGC-HVFG-US7J-BANB-YHPP-7DYJ-BJAZ
        Confirmation Request::
        MessageID: NAGC-HVFG-US7J-BANB-YHPP-7DYJ-BJAZ
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NAUI-IGWS-LQDM-K2DR-2FX6-I6M6-HF7O
        Contact Request::
        MessageID: NAUI-IGWS-LQDM-K2DR-2FX6-I6M6-HF7O
        To: alice@example.com From: carol@example.com
        PIN: 
MessageID: NBON-HCPF-EYY4-FCUG-XA4H-UCSZ-SVMR
MessageID: NCUD-3ROZ-X7UK-MMRA-CTYI-YHOE-UJCM
MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        Confirmation Request::
        MessageID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4Y-TGCW-2QO3-KIQM-N3AN-DMIO-2CFT
MessageID: NCVI-FDFU-ZYPN-5274-YBHY-V6WI-FTEJ
MessageID: NA7V-2XT2-2ZJO-IDUY-GK6W-CTVX-HDDM
</div>
~~~~

Alice she accepts Bob's request using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NAGC-HVFG-US7J-BANB-YHPP-7DYJ-BJAZ
</div>
~~~~

Bob receives Alice's approval using the `message status` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message status MA5G-3V7Z-BXSO-ZBLQ-V43K-EZ7Z-NR2X
<rsp>Accept
</div>
~~~~

In a full workflow system, Bob might include the response from Alice in a message to
the accounts department asking them to place the order.

Alice can also reject requests using the `message reject` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message reject NB2W-DI3Y-VGDZ-GURG-D3AZ-LUOX-MAE5
</div>
~~~~

Bob receives a reply telling him the request was rejected:


~~~~
<div="terminal">
<cmd>Mallet> meshman message status MDXW-4MAF-VMYO-TJQA-4YKB-QSSW-4TAI
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

