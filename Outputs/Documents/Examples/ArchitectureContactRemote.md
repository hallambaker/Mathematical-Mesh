
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
<rsp>MessageID: NANV-6BQI-F7VF-DATH-IA46-XNTZ-7NX2
        Contact Request::
        MessageID: NANV-6BQI-F7VF-DATH-IA46-XNTZ-7NX2
        To: alice@example.com From: bob@example.com
        PIN: ABUZ-THFJ-NAPN-HWGX-LB5H-PPG5-G5VQ
<cmd>Alice> message accept NANV-6BQI-F7VF-DATH-IA46-XNTZ-7NX2
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

