
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MDJE-QKTM-LW6Z-COYF-MLTG-EJ3H-KCG7
Message ID: NDVC-UG5R-VV3H-OPDO-QCX6-JBTE-X3FG
Response ID: MBS2-NSUQ-DC32-QHPQ-ITQI-2AJQ-II7X
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NDVC-UG5R-VV3H-OPDO-QCX6-JBTE-X3FG
        Contact Request::
        MessageID: NDVC-UG5R-VV3H-OPDO-QCX6-JBTE-X3FG
        To: alice@example.com From: bob@example.com
        PIN: AB6R-7PRK-EJOE-ZJ5N-MJPI-WMPD-YEEA
<cmd>Alice> message accept NDVC-UG5R-VV3H-OPDO-QCX6-JBTE-X3FG
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MB45-LKLC-XVV6-2KDX-UX3D-D6IR-6GNN
  Person MB45-LKLC-XVV6-2KDX-UX3D-D6IR-6GNN
  Anchor MB45-LKLC-XVV6-2KDX-UX3D-D6IR-6GNN
  Address alice@example.com

Entry<CatalogedContact>: NDBV-6XZJ-J724-IEJX-3YHQ-I3MP-QOCV
  Person 
  Anchor MBHK-KYK3-7L7C-7ZI6-ACME-XST5-JJAA
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MBHK-KYK3-7L7C-7ZI6-ACME-XST5-JJAA
  Person MBHK-KYK3-7L7C-7ZI6-ACME-XST5-JJAA
  Anchor MBHK-KYK3-7L7C-7ZI6-ACME-XST5-JJAA
  Address bob@example.com

Entry<CatalogedContact>: NCN4-HW56-FXLO-2WWC-QZMD-52YJ-TYZL
  Person 
  Anchor MB45-LKLC-XVV6-2KDX-UX3D-D6IR-6GNN
  Address alice@example.com

</div>
~~~~

