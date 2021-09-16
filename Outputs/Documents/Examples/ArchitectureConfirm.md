
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MCDO-HQ5K-5DD2-KXRC-K2PV-7HNS-7DUM
Message ID: NCMC-GNG4-64SP-OIG5-OM54-B2WF-QNCK
Response ID: MBWM-RFGS-JBIB-G5IN-T53Z-FRWW-LYJM
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NCMC-GNG4-64SP-OIG5-OM54-B2WF-QNCK
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MBWM-RFGS-JBIB-G5IN-T53Z-FRWW-LYJM
<rsp>Accept
</div>
~~~~

