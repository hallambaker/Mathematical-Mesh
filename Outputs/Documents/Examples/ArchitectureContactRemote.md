
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MBGV-J2XR-A2RQ-TJA3-TQAG-F5F4-5XJ4
Message ID: NC6H-T53E-BTUF-ZQH6-DTD6-GFG3-B6VS
Response ID: MAXH-BHYT-Z7EU-MEKX-L5LV-UFXH-LHGV
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NC6H-T53E-BTUF-ZQH6-DTD6-GFG3-B6VS
        Contact Request::
        MessageID: NC6H-T53E-BTUF-ZQH6-DTD6-GFG3-B6VS
        To: alice@example.com From: bob@example.com
        PIN: ACHG-NUXX-FQIJ-W5AP-BXMS-BXZB-VVGA
<cmd>Alice> message accept NC6H-T53E-BTUF-ZQH6-DTD6-GFG3-B6VS
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MCHZ-TWR3-D4HY-EDKL-XI6S-PEWG-TSOJ
  Person MCHZ-TWR3-D4HY-EDKL-XI6S-PEWG-TSOJ
  Anchor MCHZ-TWR3-D4HY-EDKL-XI6S-PEWG-TSOJ
  Address alice@example.com

Entry<CatalogedContact>: NCQ3-O46F-VGUV-GEPK-VHFV-2EHM-GI2P
  Person 
  Anchor MDE7-UNCZ-KMM7-EORW-6CPQ-C4YQ-MSS5
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MDE7-UNCZ-KMM7-EORW-6CPQ-C4YQ-MSS5
  Person MDE7-UNCZ-KMM7-EORW-6CPQ-C4YQ-MSS5
  Anchor MDE7-UNCZ-KMM7-EORW-6CPQ-C4YQ-MSS5
  Address bob@example.com

Entry<CatalogedContact>: NAMN-BA46-SAQY-WIF5-F4WA-DGIW-VVVY
  Person 
  Anchor MCHZ-TWR3-D4HY-EDKL-XI6S-PEWG-TSOJ
  Address alice@example.com

</div>
~~~~

