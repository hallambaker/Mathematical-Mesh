
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
<rsp>MessageID: NACV-TW2M-ICI2-5VBJ-QKAS-44FO-BRIP
        Contact Request::
        MessageID: NACV-TW2M-ICI2-5VBJ-QKAS-44FO-BRIP
        To: alice@example.com From: bob@example.com
        PIN: AADY-YL2H-5LIT-6PDV-USRI-74XS-YVJA
<cmd>Alice> message accept NACV-TW2M-ICI2-5VBJ-QKAS-44FO-BRIP
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

