
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
<rsp>MessageID: NAEX-I6PT-PAPW-DIHU-I4XK-WP5U-KO5V
        Contact Request::
        MessageID: NAEX-I6PT-PAPW-DIHU-I4XK-WP5U-KO5V
        To: alice@example.com From: bob@example.com
        PIN: ABII-UOYN-BS3E-FXM5-3HSW-FCQQ-2DTA
<cmd>Alice> message accept NAEX-I6PT-PAPW-DIHU-I4XK-WP5U-KO5V
</div>
~~~~

