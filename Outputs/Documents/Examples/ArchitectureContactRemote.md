
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MDR6-KBEI-XQMN-RR7F-MXND-I3PJ-KS74
Message ID: NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
Response ID: MADL-FXEZ-65YA-L6SZ-N7GL-UMLO-I3ZO
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
        Contact Request::
        MessageID: NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
        To: alice@example.com From: bob@example.com
        PIN: ADN6-CJ3X-KEFJ-BMMU-TKN3-J3JS-73ZA
<cmd>Alice> message accept NDAP-F3KS-HNFO-7I3L-2ZHA-IGKR-3RGZ
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW
  Person MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW
  Anchor MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW
  Address alice@example.com

Entry<CatalogedContact>: NCV5-EEX7-NUXG-XSCC-W76U-ZZJ4-5WNS
  Person 
  Anchor MBDZ-QPJN-S5CR-LUFO-VPOQ-5ZK2-ENE6
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MBDZ-QPJN-S5CR-LUFO-VPOQ-5ZK2-ENE6
  Person MBDZ-QPJN-S5CR-LUFO-VPOQ-5ZK2-ENE6
  Anchor MBDZ-QPJN-S5CR-LUFO-VPOQ-5ZK2-ENE6
  Address bob@example.com

Entry<CatalogedContact>: NBOV-SEBU-YMQP-OYOR-3EDV-QODY-44M6
  Person 
  Anchor MC6L-GFYJ-7EOP-2OWN-24ZJ-4RC7-EXTW
  Address alice@example.com

</div>
~~~~

