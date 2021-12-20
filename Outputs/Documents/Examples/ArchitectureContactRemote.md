
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> meshman message contact alice@example.com
<rsp>Envelope ID: MBRI-MR7H-YZXV-ZGOJ-SLJC-A43Y-ZAWY
Message ID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
Response ID: MAT4-XKXH-W3Y4-WIMV-6IBE-WGUB-NSAG
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> meshman account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> meshman message pending
<rsp>MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        Contact Request::
        MessageID: NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
        To: alice@example.com From: bob@example.com
        PIN: ABS6-M3HZ-3XC3-T2MP-5KAC-7UQW-M65A
<cmd>Alice> meshman message accept NDA2-TF33-S2GI-CUQB-W7MD-7SUH-TMHU
<cmd>Alice> meshman contact list
<rsp>Entry<CatalogedContact>: MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Person MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Anchor MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Address alice@example.com

Entry<CatalogedContact>: NDEM-WE24-3HOC-XLZC-GC2G-ZXOF-C6HU
  Person 
  Anchor MAEP-FJ5L-ZDUD-4PA4-MLEF-ZZJG-LDER
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> meshman account sync /auto
<cmd>Bob> meshman contact list
<rsp>Entry<CatalogedContact>: MAEP-FJ5L-ZDUD-4PA4-MLEF-ZZJG-LDER
  Person MAEP-FJ5L-ZDUD-4PA4-MLEF-ZZJG-LDER
  Anchor MAEP-FJ5L-ZDUD-4PA4-MLEF-ZZJG-LDER
  Address bob@example.com

Entry<CatalogedContact>: NAD2-KDRO-4J26-YXZ4-ZS2J-EHUU-F23N
  Person 
  Anchor MB4A-XOLR-2SXR-2HGA-G65C-OIEI-R53H
  Address alice@example.com

</div>
~~~~

