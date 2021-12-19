
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MAVA-YC46-S4IK-DNG4-ZNW7-J6RT-ANGC
Message ID: NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
Response ID: MABU-Y3OX-IZRP-XCUQ-C5NY-POKX-HXVT
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBW3-QGBQ-U26Q-ECMH-3BAD-BYI5-7J4J
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MABU-Y3OX-IZRP-XCUQ-C5NY-POKX-HXVT
<rsp>Accept
</div>
~~~~

