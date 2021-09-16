
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MCV4-BJJ5-YM3I-CP3X-TEJM-VGHL-6NZZ
Message ID: NCVX-SJVN-NP77-WNFG-3LA6-S23D-NYW5
Response ID: MDAM-WKM7-QYPI-DEAF-UKNF-AP4Q-BMMZ
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NCVX-SJVN-NP77-WNFG-3LA6-S23D-NYW5
        Contact Request::
        MessageID: NCVX-SJVN-NP77-WNFG-3LA6-S23D-NYW5
        To: alice@example.com From: bob@example.com
        PIN: AD7G-KXQ7-HICD-M5YI-7TR3-77DV-2S4A
<cmd>Alice> message accept NCVX-SJVN-NP77-WNFG-3LA6-S23D-NYW5
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MDMM-67AC-QTZJ-THVJ-XHCR-EO6U-QBHU
  Person MDMM-67AC-QTZJ-THVJ-XHCR-EO6U-QBHU
  Anchor MDMM-67AC-QTZJ-THVJ-XHCR-EO6U-QBHU
  Address alice@example.com

Entry<CatalogedContact>: NDDU-HT2Q-NEGG-OSVO-ZVNY-MDVL-VVVZ
  Person 
  Anchor MDSZ-7BFN-TVPB-D5GA-VP5H-V3FK-YVKD
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MDSZ-7BFN-TVPB-D5GA-VP5H-V3FK-YVKD
  Person MDSZ-7BFN-TVPB-D5GA-VP5H-V3FK-YVKD
  Anchor MDSZ-7BFN-TVPB-D5GA-VP5H-V3FK-YVKD
  Address bob@example.com

Entry<CatalogedContact>: NCUK-BMXG-5DBX-B3HE-UA7B-5I23-OECM
  Person 
  Anchor MDMM-67AC-QTZJ-THVJ-XHCR-EO6U-QBHU
  Address alice@example.com

</div>
~~~~

