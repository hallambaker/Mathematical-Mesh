
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
<rsp>MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        Contact Request::
        MessageID: NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
        To: alice@example.com From: bob@example.com
        PIN: ACQ6-HOEL-5EOQ-OKX4-XIX5-ZUSS-JGIA
<cmd>Alice> message accept NB2L-XW4K-7HZ3-5UHJ-B46U-2ZUJ-KXWC
</div>
~~~~

