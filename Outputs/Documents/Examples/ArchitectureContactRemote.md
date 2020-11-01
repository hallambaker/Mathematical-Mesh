
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
<rsp>MessageID: NBI3-FCGJ-V33K-MFMV-JCQX-PNJ6-RYX7
        Contact Request::
        MessageID: NBI3-FCGJ-V33K-MFMV-JCQX-PNJ6-RYX7
        To: alice@example.com From: bob@example.com
        PIN: ABU5-EVOM-WLLX-4XCU-HEWO-EZ5R-5KAQ
<cmd>Alice> message accept NBI3-FCGJ-V33K-MFMV-JCQX-PNJ6-RYX7
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

