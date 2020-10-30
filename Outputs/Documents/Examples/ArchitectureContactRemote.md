
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
<rsp>MessageID: ND3L-P2YT-V5ZQ-MGRY-S4HB-DLNZ-6CBN
        Contact Request::
        MessageID: ND3L-P2YT-V5ZQ-MGRY-S4HB-DLNZ-6CBN
        To: alice@example.com From: bob@example.com
        PIN: ACIJ-ARU3-4SNO-4TKP-TRIE-GFPH-3XBA
<cmd>Alice> message accept ND3L-P2YT-V5ZQ-MGRY-S4HB-DLNZ-6CBN
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

