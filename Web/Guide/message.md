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
<rsp>Envelope ID: MCYQ-CVAT-J4F3-DFAE-5R6T-JTKG-4VI6
Message ID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
Response ID: MBST-46UM-4A2W-TQMR-TW77-7DWP-LQQG
</div>
~~~~

Alice reviews her pending messages using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
        Contact Request::
        MessageID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
        To: alice@example.com From: bob@example.com
        PIN: ABII-GHTL-WP4P-XBLL-4RA2-AWIE-GFEA
MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        Group invitation::
        MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        To: alice@example.com From: alice@example.com
MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        Confirmation Request::
        MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        Contact Request::
        MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        To: alice@example.com From: bob@example.com
        PIN: ADXO-VQ4V-WNRY-WD65-PHYE-GK2E-TWZQ
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
<rsp>Entry<CatalogedContact>: MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Person MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Anchor MCF4-6VUT-NOPK-4UIX-N5VC-6MYF-RMVT
  Address alice@example.com

Entry<CatalogedContact>: NDF5-DIN6-FBRI-UI2D-XLQF-SKWC-TCB5
  Person 
  Anchor MDBR-EJYT-5KJY-Z73B-IG7E-WFSN-MRKH
  Address bob@example.com

Entry<CatalogedContact>: NCPX-63X3-SRNM-KJDU-VED6-MYU2-EUG6
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
  Address groupw@example.com

Entry<CatalogedContact>: NCPH-YMTN-5HKG-E3GR-YFZC-RDC5-ZM4D
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
  Address groupw@example.com

Entry<CatalogedContact>: NDR4-XO5G-PIYW-6H47-ZAGK-ISPY-H2ES
  Person 
  Anchor MCVG-W4LF-4BAI-2ZCY-NHCU-E3HO-VVHY
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
<rsp>Envelope ID: MCK7-MAGD-TRMF-QQPS-NG64-IGG4-CXUS
Message ID: NCAV-N6DG-ZWX2-VIPG-IBFH-JTKM-5YWR
Response ID: MDL3-PED3-HL55-C62T-DANJ-SA67-BAZC
</div>
~~~~

Alice reviews her pending messages using the using the `message pending` command:


~~~~
<div="terminal">
<cmd>Alice> meshman message pending
<rsp>MessageID: NCAV-N6DG-ZWX2-VIPG-IBFH-JTKM-5YWR
        Confirmation Request::
        MessageID: NCAV-N6DG-ZWX2-VIPG-IBFH-JTKM-5YWR
        To: alice@example.com From: bob@example.com
        Text: "Purchase
MessageID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
        Contact Request::
        MessageID: NARA-7QXY-OIUO-A4VX-WRSG-FWED-W37V
        To: alice@example.com From: bob@example.com
        PIN: ABII-GHTL-WP4P-XBLL-4RA2-AWIE-GFEA
MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        Group invitation::
        MessageID: NBKK-WDGA-Z36W-IOD6-HZBW-DSNB-2CR5
        To: alice@example.com From: alice@example.com
MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        Confirmation Request::
        MessageID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
        To: alice@example.com From: console@example.com
        Text: start
MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        Contact Request::
        MessageID: NDRW-AINC-CW2Z-REBY-UILU-O2EI-MZPK
        To: alice@example.com From: bob@example.com
        PIN: ADXO-VQ4V-WNRY-WD65-PHYE-GK2E-TWZQ
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
Missing example 30
~~~~


