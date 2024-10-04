
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MBVY-XORI-2GVR-6J4M-RNXQ-RSQJ-XPTU
Message ID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
Response ID: MAHD-CP2A-XRAI-REOV-ILAZ-A3SE-BAPP
</div>
~~~~

Alice checks her Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NBUX-W5FA-DICN-CBHX-FENN-7TIV-IITD
        Contact Request::
        MessageID: NBUX-W5FA-DICN-CBHX-FENN-7TIV-IITD
        To: alice@example.com From: mallet@example.com
        PIN: ADN2-K5ZO-TB4H-RTCQ-S3Q6-LKEA-FAKQ
MessageID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
        Contact Request::
        MessageID: NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
        To: alice@example.com From: bob@example.com
        PIN: AAIS-4C4B-ZHY7-JJKX-A3RK-NQQU-WOGA
MessageID: NDIR-FXO6-NGSV-7UJL-5TOG-V3ON-2VPX
<cmd>Alice> meshman message accept NA5B-6Z6O-F74O-X2AA-CTW2-I7C2-CCRX
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Person MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

Entry<CatalogedContact>: NBWO-LXHG-76BJ-76A3-2S4Q-VHQF-J6BJ
  Person 
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Person MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Anchor MBQM-POZD-73H4-KCMN-Y4DB-WQXW-YALS
  Address bob@example.com

Entry<CatalogedContact>: NAOY-KU74-B43S-RFMU-R3D5-62EQ-MVOE
  Person 
  Anchor MBQB-2H3J-6QK6-ZRL3-ZPFQ-KYCG-LTBU
  Address alice@example.com

</div>
~~~~

