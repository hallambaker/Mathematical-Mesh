
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MB2P-CF2L-7MG6-LDVH-2VXR-H2B7-G6UZ
Message ID: NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
Response ID: MDNA-3FWM-EU32-YVSQ-FETM-AFPL-QNW5
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBUX-DOPM-JJKG-NKMV-K24G-MX24-4QNW
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MDNA-3FWM-EU32-YVSQ-FETM-AFPL-QNW5
<rsp>Accept
</div>
~~~~

