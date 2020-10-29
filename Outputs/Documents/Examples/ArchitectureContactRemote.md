
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp></div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<rsp><cmd>Alice> message pending
<rsp>MessageID: NBIX-IJMA-JKJ4-JR7G-W2J4-72NU-2IPM
        Contact Request::
        MessageID: NBIX-IJMA-JKJ4-JR7G-W2J4-72NU-2IPM
        To: alice@example.com From: bob@example.com
        PIN: AASW-PCWN-HAUG-MSTC-ZLAI-JKJO-EGNA
<cmd>Alice> message accept NBIX-IJMA-JKJ4-JR7G-W2J4-72NU-2IPM
<rsp></div>
~~~~

