
Alice wants to exchange Mesh messages with Bob. Although Alice knows Bob's Mesh address 
(bob@example.com), she does not (yet) have permission to send any message to Bob
excepting a request to exchange contact information.

Bob sends Alice a contact exchange request:


~~~~
<div="terminal">
<cmd>Bob> message contact alice@example.com
<rsp>Envelope ID: MDWV-73WN-EVRJ-X7LD-LHPK-XGLN-CQ5S
Message ID: NC7T-SBTN-ZUL4-Z7LB-DMN4-LUFW-5MQF
Response ID: MCRD-XXXX-Y2UZ-4ZHB-DWNI-WGZI-FKRO
</div>
~~~~

Alice checks his Mesh messages and approves Bob's request:


~~~~
<div="terminal">
<cmd>Alice> account sync
<cmd>Alice> message pending
<rsp>MessageID: NC7T-SBTN-ZUL4-Z7LB-DMN4-LUFW-5MQF
        Contact Request::
        MessageID: NC7T-SBTN-ZUL4-Z7LB-DMN4-LUFW-5MQF
        To: alice@example.com From: bob@example.com
        PIN: AABR-4QTD-CQQK-A3T6-EVBJ-HVRS-FFSQ
<cmd>Alice> message accept NC7T-SBTN-ZUL4-Z7LB-DMN4-LUFW-5MQF
<cmd>Alice> contact list
<rsp>Entry<CatalogedContact>: MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR
  Person MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR
  Anchor MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR
  Address alice@example.com

Entry<CatalogedContact>: NAN3-LJW4-PU6O-V532-ACI4-OKA6-R27X
  Person 
  Anchor MDUO-EPBE-B77S-K6F4-TG22-5N4N-XQIB
  Address bob@example.com

</div>
~~~~

Bob can now collect Alice's contact:


~~~~
<div="terminal">
<cmd>Bob> account sync /auto
<cmd>Bob> contact list
<rsp>Entry<CatalogedContact>: MDUO-EPBE-B77S-K6F4-TG22-5N4N-XQIB
  Person MDUO-EPBE-B77S-K6F4-TG22-5N4N-XQIB
  Anchor MDUO-EPBE-B77S-K6F4-TG22-5N4N-XQIB
  Address bob@example.com

Entry<CatalogedContact>: NDV2-3BUI-WT3T-5OAH-JN6M-WHBQ-PQDY
  Person 
  Anchor MANR-I5NN-5ZQH-APAD-4XOK-HR3F-L2FR
  Address alice@example.com

</div>
~~~~

