
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: ND4E-AZFT-VO2I-T2EM-EMJH-ORID-PX76
        Contact Request::
        MessageID: ND4E-AZFT-VO2I-T2EM-EMJH-ORID-PX76
        To: alice@example.com From: bob@example.com
        PIN: ABJG-3RTO-7KLS-ZEW3-UF64-RPQ3-NS5A
<cmd>Alice> message accept ND4E-AZFT-VO2I-T2EM-EMJH-ORID-PX76
</div>
~~~~

