
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman contact request alice@example.com
<rsp>Envelope ID: MCB5-SD6X-OUXX-JAQI-6ZBM-G4FS-TYAE
Message ID: NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
Response ID: MAPM-XKGB-KZ4A-ZAST-JLFX-N4WD-RMIT
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<cmd>Alice> meshman message pending
<rsp>MessageID: NAUE-PMNN-4RNJ-E3AW-J4KO-QIVG-PRO6
        Contact Request::
        MessageID: NAUE-PMNN-4RNJ-E3AW-J4KO-QIVG-PRO6
        To: alice@example.com From: mallet@example.com
        PIN: ADCN-FXJI-Q27K-AI5W-O4P7-KU6H-AIGA
MessageID: NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
        Contact Request::
        MessageID: NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
        To: alice@example.com From: bob@example.com
        PIN: ADFZ-RDXJ-IICY-KX57-X6LH-ABQY-IBKQ
<cmd>Alice> meshman message accept NBBX-LUP5-63JW-AJ6G-5UFG-TYWA-Y6IY
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Person MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Anchor MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Address alice@example.com

Entry<CatalogedContact>: NA2N-NMA3-3OLA-B65Y-JSYR-WDIO-DGBE
  Person 
  Anchor MDRS-IKMP-S6SZ-MR5M-GOIJ-SIHS-W5SJ
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MDRS-IKMP-S6SZ-MR5M-GOIJ-SIHS-W5SJ
  Person MDRS-IKMP-S6SZ-MR5M-GOIJ-SIHS-W5SJ
  Anchor MDRS-IKMP-S6SZ-MR5M-GOIJ-SIHS-W5SJ
  Address bob@example.com

Entry<CatalogedContact>: NAUR-M73V-JMIE-ZQV4-OIIT-ICJV-ZZSQ
  Person 
  Anchor MAMQ-ETEA-JBL3-6UKE-LRNT-DGC3-OIDF
  Address alice@example.com

</div>
~~~~

