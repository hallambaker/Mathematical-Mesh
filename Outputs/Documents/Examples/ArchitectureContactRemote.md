
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
<rsp>MessageID: NAJ2-5SHJ-3XAG-3G3H-KZFT-Z2H4-AO3F
        Contact Request::
        MessageID: NAJ2-5SHJ-3XAG-3G3H-KZFT-Z2H4-AO3F
        To: alice@example.com From: bob@example.com
        PIN: ADNS-6YJX-O75K-CKUJ-V5BA-SOCZ-A57Q
<cmd>Alice> message accept NAJ2-5SHJ-3XAG-3G3H-KZFT-Z2H4-AO3F
<rsp>ERROR - Cannot access a closed file.
</div>
~~~~

