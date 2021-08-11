
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MBEJ-XXAW-NER2-SGBJ-YCP3-ZINM-TQX4
Message ID: NDVO-DXSU-MR6A-YLIT-CZGQ-GOPO-WIZE
Response ID: MBTC-33KM-LEFT-EZHG-5IO2-3O2Q-IXAS
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NDVO-DXSU-MR6A-YLIT-CZGQ-GOPO-WIZE
        Contact Request::
        MessageID: NDVO-DXSU-MR6A-YLIT-CZGQ-GOPO-WIZE
        To: alice@example.com From: bob@example.com
        PIN: ABCA-X5D2-ELEC-GDX6-HHYD-BXPC-YQNA
<cmd>Alice> message accept NDVO-DXSU-MR6A-YLIT-CZGQ-GOPO-WIZE
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MAQT-OUN5-5QSY-7ST3-BLD3-XVWV-NEID
  Person MAQT-OUN5-5QSY-7ST3-BLD3-XVWV-NEID
  Anchor MAQT-OUN5-5QSY-7ST3-BLD3-XVWV-NEID
  Address alice@example.com

Entry<CatalogedContact>: NDY2-5YJK-XJ3T-L75W-67QW-TN5C-LHED
  Person 
  Anchor MBFF-PPOW-MNSP-3LDK-EXNO-NXAI-2RLN
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MBFF-PPOW-MNSP-3LDK-EXNO-NXAI-2RLN
  Person MBFF-PPOW-MNSP-3LDK-EXNO-NXAI-2RLN
  Anchor MBFF-PPOW-MNSP-3LDK-EXNO-NXAI-2RLN
  Address bob@example.com

Entry<CatalogedContact>: NCVG-5STC-TF7U-AEP2-PTBR-F22Z-IVYX
  Person 
  Anchor MAQT-OUN5-5QSY-7ST3-BLD3-XVWV-NEID
  Address alice@example.com

</div>
~~~~

