
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
<rsp>MessageID: NBFX-IA4R-ZISZ-6MWZ-KGO4-GZGB-32KL
        Contact Request::
        MessageID: NBFX-IA4R-ZISZ-6MWZ-KGO4-GZGB-32KL
        To: alice@example.com From: bob@example.com
        PIN: ACGU-5HGL-PNEN-QN2A-WIGY-6BBM-I3XA
<cmd>Alice> message accept NBFX-IA4R-ZISZ-6MWZ-KGO4-GZGB-32KL
</div>
~~~~

