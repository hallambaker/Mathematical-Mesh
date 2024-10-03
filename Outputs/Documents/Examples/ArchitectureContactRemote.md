
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MBAU-H34I-FU2B-3TEF-LTMG-RT5T-GYRC
Message ID: NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
Response ID: MBR6-OL3R-4XVW-T26E-DT2C-S6SB-D4QI
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NADI-GEER-FWSC-XCKV-PJX6-GNFT-CZPV
        Contact Request::
        MessageID: NADI-GEER-FWSC-XCKV-PJX6-GNFT-CZPV
        To: alice@example.com From: mallet@example.com
        PIN: AAYS-2FTM-ZVBZ-BJVP-PUAF-YJGN-IPWQ
MessageID: NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
        Contact Request::
        MessageID: NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
        To: alice@example.com From: bob@example.com
        PIN: AABI-JVOW-MNSQ-TKJ3-UJ7T-HKTF-T3PQ
MessageID: NCDS-JZQ5-N633-ZKWA-7U5I-6LNU-PFT5
<cmd>Alice> meshman message accept NBWN-4HLV-RURQ-O7TC-ANA2-D5K4-4UFH
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Person MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Anchor MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Address alice@example.com

Entry<CatalogedContact>: NCQT-M4X2-LSIJ-GRPC-FUXJ-YIK7-KV33
  Person 
  Anchor MBQN-O35O-S5NJ-XZ5K-7RRD-NAMW-VN6H
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MBQN-O35O-S5NJ-XZ5K-7RRD-NAMW-VN6H
  Person MBQN-O35O-S5NJ-XZ5K-7RRD-NAMW-VN6H
  Anchor MBQN-O35O-S5NJ-XZ5K-7RRD-NAMW-VN6H
  Address bob@example.com

Entry<CatalogedContact>: NAMQ-QA5Y-CHLH-C3LH-PC4X-GWG2-S4QB
  Person 
  Anchor MBQE-UNZP-5RH2-WYHY-IO5Q-JRAD-WTE3
  Address alice@example.com

</div>
~~~~

