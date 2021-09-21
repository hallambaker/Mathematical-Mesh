
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MA3Z-2HY4-ARAX-PQP3-SALJ-WZC4-PFSQ
Message ID: NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
Response ID: MB2A-ACXF-XW3Q-2XUC-BTRG-6SIY-MAOT
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
        Contact Request::
        MessageID: NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
        To: alice@example.com From: bob@example.com
        PIN: ADVA-25BJ-2FZG-LMV3-IUVO-QRF4-JHXA
<cmd>Alice> message accept NCKJ-A26T-F457-ZDUM-KCLY-DI3W-LICQ
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
  Person MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
  Anchor MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
  Address alice@example.com

Entry<CatalogedContact>: NDJR-EAB7-AXSL-GEIH-PTG2-2MCU-44YC
  Person 
  Anchor MC3D-YVUI-DVMZ-PGO6-DRMI-TYGY-KMFL
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MC3D-YVUI-DVMZ-PGO6-DRMI-TYGY-KMFL
  Person MC3D-YVUI-DVMZ-PGO6-DRMI-TYGY-KMFL
  Anchor MC3D-YVUI-DVMZ-PGO6-DRMI-TYGY-KMFL
  Address bob@example.com

Entry<CatalogedContact>: NC6K-ZUNP-PDMR-5HZM-BRN5-FWNO-HOSQ
  Person 
  Anchor MCST-2JUP-UNOG-O4A3-Q6KS-O2V5-HSQL
  Address alice@example.com

</div>
~~~~

