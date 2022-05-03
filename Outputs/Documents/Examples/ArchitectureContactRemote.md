
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MCJW-X2TB-QWWK-XEJY-NARU-GI5V-W7XA
Message ID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
Response ID: MBUW-RS2J-YLXC-R7S5-B6LV-2O7Z-IJCK
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBQQ-VHXI-3DZX-6KA3-UN3O-4J7B-MHKG
        Contact Request::
        MessageID: NBQQ-VHXI-3DZX-6KA3-UN3O-4J7B-MHKG
        To: alice@example.com From: mallet@example.com
        PIN: ADFW-BULY-6SM6-BWJ7-FI4H-COZ4-RLBA
MessageID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
        Contact Request::
        MessageID: NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
        To: alice@example.com From: bob@example.com
        PIN: ADHE-RV4P-ETST-FW3C-RIY3-MUQF-NC6Q
<cmd>Alice> meshman message accept NBS4-ZWR7-F5JR-DCOK-C5PN-XKDT-WB46
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Person MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

Entry<CatalogedContact>: NBE6-3ZYP-G52L-B6HG-EIRK-XZ7H-73HR
  Person 
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Person MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Anchor MDDO-B6Z7-4YXY-BJLQ-WFQZ-BOMG-QB6Y
  Address bob@example.com

Entry<CatalogedContact>: NDS3-QDKW-ZXAB-7NWJ-KOP5-LSOW-Y5GF
  Person 
  Anchor MARP-HH6B-D2JW-WLQ6-RWPQ-2SLS-AI2V
  Address alice@example.com

</div>
~~~~

