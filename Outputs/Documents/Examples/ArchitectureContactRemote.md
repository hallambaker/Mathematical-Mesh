
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MDVW-DPQF-T6KB-FUAK-7JIR-2ZHS-556H
Message ID: NBQG-WCE5-PTI5-5AAG-QYRE-Q367-6XXT
Response ID: MDFQ-PVWB-KMS4-YD7M-VQH2-MRQN-V4BF
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NBQG-WCE5-PTI5-5AAG-QYRE-Q367-6XXT
        Contact Request::
        MessageID: NBQG-WCE5-PTI5-5AAG-QYRE-Q367-6XXT
        To: alice@example.com From: bob@example.com
        PIN: ABES-44VB-H6RL-4SXI-B2A3-OTGC-GKIA
<cmd>Alice> message accept NBQG-WCE5-PTI5-5AAG-QYRE-Q367-6XXT
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MCWD-QCM6-5QUW-4NWK-J4T4-VOMT-6WF3
  Person MCWD-QCM6-5QUW-4NWK-J4T4-VOMT-6WF3
  Anchor MCWD-QCM6-5QUW-4NWK-J4T4-VOMT-6WF3
  Address alice@example.com

Entry<CatalogedContact>: NAQA-YQ4R-GDDX-UDRI-T2DE-4DD4-LNTD
  Person 
  Anchor MAPZ-TCD3-BMXZ-MQAZ-OV4M-UHYK-ZAPH
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MAPZ-TCD3-BMXZ-MQAZ-OV4M-UHYK-ZAPH
  Person MAPZ-TCD3-BMXZ-MQAZ-OV4M-UHYK-ZAPH
  Anchor MAPZ-TCD3-BMXZ-MQAZ-OV4M-UHYK-ZAPH
  Address bob@example.com

Entry<CatalogedContact>: NCVH-6QQU-DQ4P-BF4C-GIIK-AJE3-TFF2
  Person 
  Anchor MCWD-QCM6-5QUW-4NWK-J4T4-VOMT-6WF3
  Address alice@example.com

</div>
~~~~

