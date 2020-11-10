
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
<rsp>MessageID: NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK
        Contact Request::
        MessageID: NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK
        To: alice@example.com From: bob@example.com
        PIN: ACJP-PFU2-2O4N-73XX-J3KN-E7K4-FV3A
<cmd>Alice> message accept NDGZ-J52O-DPPK-JG7R-2YZQ-JUPS-3GJK
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

