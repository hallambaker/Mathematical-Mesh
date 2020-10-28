
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
<rsp>MessageID: NACO-OIRC-75YQ-GTK7-PZMM-CK5I-PXCY
        Contact Request::
        MessageID: NACO-OIRC-75YQ-GTK7-PZMM-CK5I-PXCY
        To: alice@example.com From: bob@example.com
        PIN: ABV3-UC25-G5WU-V3IV-3D6M-QEFA-AQLA
<cmd>Alice> message accept NACO-OIRC-75YQ-GTK7-PZMM-CK5I-PXCY
<rsp></div>
~~~~

