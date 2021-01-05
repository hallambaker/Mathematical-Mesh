
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
<rsp>MessageID: NAYL-CPBL-XTBK-HFVR-IKAS-GH3A-TA2V
        Contact Request::
        MessageID: NAYL-CPBL-XTBK-HFVR-IKAS-GH3A-TA2V
        To: alice@example.com From: bob@example.com
        PIN: AA2V-M76R-UA6A-7TZF-SLNV-GLLN-JIEA
<cmd>Alice> message accept NAYL-CPBL-XTBK-HFVR-IKAS-GH3A-TA2V
</div>
~~~~

