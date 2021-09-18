
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MBPW-Y67R-DCNB-2AI3-7JL6-F4ND-KNA6
Message ID: NC5F-OQN2-OLFI-HL4E-LRUR-QCA5-KOHC
Response ID: MBMY-UJIJ-3PBK-CRMC-RG6E-FS77-AUZ6
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NC5F-OQN2-OLFI-HL4E-LRUR-QCA5-KOHC
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MBMY-UJIJ-3PBK-CRMC-RG6E-FS77-AUZ6
<rsp>Accept
</div>
~~~~

