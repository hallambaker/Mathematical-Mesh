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
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MAB6-SCSL-XSMY-KDEV-E6IW-KADQ-YONX
Message ID: NDGG-BP7T-FBI6-C4FJ-N6LN-PX2U-MV5G
Response ID: MBTC-3L6R-CPOP-P3JY-Y34N-3PHS-UDYC
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NDGG-BP7T-FBI6-C4FJ-N6LN-PX2U-MV5G
        Contact Request::
        MessageID: NDGG-BP7T-FBI6-C4FJ-N6LN-PX2U-MV5G
        To: alice@example.com From: bob@example.com
        PIN: ACUN-WB2H-GIIO-ZMDB-WGEI-MFDX-73MA
MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        Group invitation::
        MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        To: alice@example.com From: alice@example.com
MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        Confirmation Request::
        MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        Contact Request::
        MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        To: alice@example.com From: bob@example.com
        PIN: AARR-TR4W-I3P2-Y5OF-KVMP-7KEJ-RVIQ
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
<rsp>Entry<CatalogedContact>: MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Person MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Anchor MDKS-LLL5-WPDJ-UKE2-4PPM-Y66V-2LIJ
  Address alice@example.com

Entry<CatalogedContact>: NDI6-Y4Q5-3K7C-UFFO-ZIZP-HFCS-R34U
  Person 
  Anchor MBNR-RPGE-7V2C-JI4N-F3NF-OD32-MV7R
  Address bob@example.com

Entry<CatalogedContact>: NDAW-LPN7-CMK6-JNTR-A573-CIFE-K34V
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NB2Y-J5D4-SHIA-WBWE-2EDA-D45R-56AU
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NA4V-YEYP-3K74-6ESA-M22I-FFBL-3WWB
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
  Address groupw@example.com

Entry<CatalogedContact>: NDX2-WVUN-C26G-UUXC-JJAA-2ZLD-23K2
  Person 
  Anchor MDLU-46TL-V47W-BWT7-PSUV-FCKP-BEE6
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
<rsp>Envelope ID: MDXL-CQM2-QN3Q-QNSA-IGHG-AOGC-XIUN
Message ID: NDVI-DOXS-3TK3-LGKN-XP6N-KRNU-ZPXK
Response ID: MCNK-NIPX-SKWW-ADMX-45VJ-6P5O-ID7C
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NDVI-DOXS-3TK3-LGKN-XP6N-KRNU-ZPXK
        Confirmation Request::
        MessageID: NDVI-DOXS-3TK3-LGKN-XP6N-KRNU-ZPXK
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NDGG-BP7T-FBI6-C4FJ-N6LN-PX2U-MV5G
        Contact Request::
        MessageID: NDGG-BP7T-FBI6-C4FJ-N6LN-PX2U-MV5G
        To: alice@example.com From: bob@example.com
        PIN: ACUN-WB2H-GIIO-ZMDB-WGEI-MFDX-73MA
MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        Group invitation::
        MessageID: NBNO-T2AC-LSGA-MRRH-JN3O-V4YQ-RJLQ
        To: alice@example.com From: alice@example.com
MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        Confirmation Request::
        MessageID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
        To: alice@example.com From: console@example.com
        Text: start
MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        Contact Request::
        MessageID: ND4S-KDPC-PUNU-4X3I-PTRT-LJSO-XGHV
        To: alice@example.com From: bob@example.com
        PIN: AARR-TR4W-I3P2-Y5OF-KVMP-7KEJ-RVIQ
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
<rsp>Envelope ID: MDWO-Y6YL-FLXM-2ACK-UG2P-P653-FT6Y
Message ID: NDWD-5CWJ-KV7A-HHB4-3TOO-S4OJ-445C
Response ID: MAQR-HQZD-ITHD-SWB3-ICTX-UZ5C-WKSI
</div>
~~~~

Mallet cannot respond to the request sent by Bob because he can't read Alice's
messages to discover the request to reply to. Nor can he create a valid signature
on the response should this information be accidentally disclosed.

