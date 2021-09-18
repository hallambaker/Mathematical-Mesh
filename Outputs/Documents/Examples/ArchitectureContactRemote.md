
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MBM5-2VUI-XP3G-M454-XAXN-TN5J-5C27
Message ID: ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
Response ID: MC64-Z7IF-PTCH-AD6F-COHT-RFSY-TORG
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
        Contact Request::
        MessageID: ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
        To: alice@example.com From: bob@example.com
        PIN: ADUQ-WHRC-BS2A-V4XK-TEFX-52VJ-JKYQ
<cmd>Alice> message accept ND3S-QR42-LWJ7-ORBD-3DMN-ZBTH-RMFI
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
  Person MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
  Anchor MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
  Address alice@example.com

Entry<CatalogedContact>: NDYH-SIW2-T5V6-WY2F-EZ3J-Y5ZA-K2PW
  Person 
  Anchor MDVX-L2LX-EYAP-2FJG-GU3B-PNZ4-HBH5
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MDVX-L2LX-EYAP-2FJG-GU3B-PNZ4-HBH5
  Person MDVX-L2LX-EYAP-2FJG-GU3B-PNZ4-HBH5
  Anchor MDVX-L2LX-EYAP-2FJG-GU3B-PNZ4-HBH5
  Address bob@example.com

Entry<CatalogedContact>: NA5R-A4ZM-L3AU-YYSP-5ECF-GLJW-ECNL
  Person 
  Anchor MBMJ-7X6T-DWE7-6EGQ-2QGZ-RSYR-553Q
  Address alice@example.com

</div>
~~~~

