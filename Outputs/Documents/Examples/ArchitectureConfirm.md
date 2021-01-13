
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MCDL-YDFD-GEC4-MJZO-FONM-AC2D-HNM7
Message ID: NCHB-PAFY-23JU-UWSK-Q4NK-LEKY-MFZX
Response ID: MBX5-PSU2-MPUA-IRVR-WIJL-CS4Q-5YUS
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NCHB-PAFY-23JU-UWSK-Q4NK-LEKY-MFZX
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MBX5-PSU2-MPUA-IRVR-WIJL-CS4Q-5YUS
<rsp>Accept
</div>
~~~~

