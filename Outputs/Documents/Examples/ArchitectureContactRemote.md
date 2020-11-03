
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
<rsp>MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        Contact Request::
        MessageID: NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
        To: alice@example.com From: bob@example.com
        PIN: AADZ-27RV-SGJA-5LIO-GHVA-2QPC-ORRA
<cmd>Alice> message accept NAEZ-UOXO-KBH7-MT7I-KKA2-S37A-RGEZ
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

