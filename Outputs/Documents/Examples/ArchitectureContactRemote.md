
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MDHG-3COZ-CAJL-APEB-TOW7-Y3CS-MLQJ
Message ID: NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
Response ID: MBNN-KXQL-KNKZ-YJZK-OFS7-PRWY-46MC
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<rsp>ERROR - The entry already exists in the store.
<cmd>Alice> message pending
<rsp>MessageID: NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
        Contact Request::
        MessageID: NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
        To: alice@example.com From: bob@example.com
        PIN: AAIE-IVI5-54XO-5PHG-VE62-FFS7-62GQ
<cmd>Alice> message accept NAP7-MRKY-LGHV-W6C2-IDAX-ELNG-V5NT
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
  Person MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
  Anchor MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
  Address alice@example.com

Entry<CatalogedContact>: NCZX-ORU3-D4LQ-S3AZ-7PXM-OF6V-DUGA
  Person 
  Anchor MBXW-NPWV-V7JQ-QR7F-FP5K-P5SA-JB4H
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MBXW-NPWV-V7JQ-QR7F-FP5K-P5SA-JB4H
  Person MBXW-NPWV-V7JQ-QR7F-FP5K-P5SA-JB4H
  Anchor MBXW-NPWV-V7JQ-QR7F-FP5K-P5SA-JB4H
  Address bob@example.com

Entry<CatalogedContact>: NCJE-TC7E-EUWI-6GYX-BYU6-NY3U-VOND
  Person 
  Anchor MB5I-R24M-QXJT-KDBF-XFOA-DGC3-U3AA
  Address alice@example.com

</div>
~~~~

