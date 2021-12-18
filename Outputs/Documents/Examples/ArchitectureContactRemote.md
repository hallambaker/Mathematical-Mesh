
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MD6O-HQ75-OMLP-7W22-P7VD-VADS-LCQY
Message ID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
Response ID: MAWJ-CQGL-SA3D-4GMF-BSCF-QSGG-5CSM
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        Contact Request::
        MessageID: NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
        To: alice@example.com From: bob@example.com
        PIN: AB3F-U7X5-Q2PE-ESFS-S2PH-7AGC-TKBA
<cmd>Alice> meshman message accept NDCL-O2LD-ODCU-MB2I-6EY3-RXRR-OSSK
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Person MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Anchor MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Address alice@example.com

Entry<CatalogedContact>: NAWB-M7G7-OXPC-I6YS-SIXH-JQ7E-OOXA
  Person 
  Anchor MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG
  Person MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG
  Anchor MBYX-JPOL-7H24-YL2Z-LOHO-7MWV-IFGG
  Address bob@example.com

Entry<CatalogedContact>: NAEF-7UJO-67XF-HIVD-I3V5-XJG5-APHS
  Person 
  Anchor MCF2-WY7A-YHLR-W2N3-4GXF-4PUO-ZO7N
  Address alice@example.com

</div>
~~~~

