<title>Message
# Using the Message Command Set

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

For production use, most users will of course prefer a command line tool or that
the Mesh functionality be built into their prefered messaging/mail client.

# Contact Request

The Contacts catalog plays an important role in Mesh messaging as it is used to
determine the recipient's security policy to be applied to outbound messages and 
perform access control on inbound messages.

Having created a Mesh profile, Bob asks Alice to add him to her contacts catalog
using the `message contact` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MAGS-FJA4-B3DP-75QH-LDH6-EVXN-EXLO
Message ID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
Response ID: MBNB-C33D-LD54-SUK7-UJ7Y-UZPZ-ZPPZ
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
        Contact Request::
        MessageID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
        To: alice@example.com From: bob@example.com
        PIN: ADLY-QWJJ-CIZZ-P4PP-4MA5-CGRF-OCUQ
MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        Group invitation::
        MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        To: alice@example.com From: alice@example.com
MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        Confirmation Request::
        MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
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
<rsp>Entry<CatalogedContact>: MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Person MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Anchor MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Address alice@example.com

Entry<CatalogedContact>: NDEM-WE24-3HOC-XLZC-GC2G-ZXOF-C6HU
  Person 
  Anchor MAEP-FJ5L-ZDUD-4PA4-MLEF-ZZJG-LDER
  Address bob@example.com

Entry<CatalogedContact>: NBMX-PJ74-OQ3W-ZBM3-U525-RJYR-2QCG
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NDRA-RYQ6-BGI6-S6ST-3EQO-SIHS-SZ5N
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NBR7-T7B7-5BPM-Q6CO-4W7F-PCSK-CHMN
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
  Address groupw@example.com

Entry<CatalogedContact>: NCNT-D7WI-7OGD-Q4X5-VKN5-2GYO-NQ6M
  Person 
  Anchor MD2J-ZY5P-QMLE-2UBT-X7QH-C5OO-37K4
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

Alice sends Bob an email asking him to buy some equipment costing $6,000. Since this
is a significant sum, Bob needs an authorization for the purchase. He sends Alice
a confirmation request `Purchase equipment for $6,000?` using the  
`message confirm` command:


~~~~
<div="terminal">
<cmd>Bob> meshman message confirm alice@example.com "Purchase equipment for ^
    $6,000?"
<rsp>Envelope ID: MA2M-E7MJ-5DPC-TWHA-2WC4-3WKS-GZV7
Message ID: NDL3-WREK-BPQQ-ZTOH-FSOR-FHD2-OYNW
Response ID: MDB2-IBLG-657S-K43Q-IQVY-5UAF-3CHS
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NDL3-WREK-BPQQ-ZTOH-FSOR-FHD2-OYNW
        Confirmation Request::
        MessageID: NDL3-WREK-BPQQ-ZTOH-FSOR-FHD2-OYNW
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
        Contact Request::
        MessageID: NBMT-K2BY-N7SO-2V7J-A2AF-LSDD-IIOV
        To: alice@example.com From: bob@example.com
        PIN: ADLY-QWJJ-CIZZ-P4PP-4MA5-CGRF-OCUQ
MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        Group invitation::
        MessageID: NDVT-POHA-PJWP-AABG-YXO2-JU2C-4LYT
        To: alice@example.com From: alice@example.com
MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        Confirmation Request::
        MessageID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
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
Missing example 9
~~~~


