
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MD7M-K4BX-IKCM-Y2X4-H4SP-4AYS-I2TQ
Message ID: NAB7-ZDLN-ZHMR-VOCR-MCBV-ZELE-7RZD
Response ID: MCNA-DD5N-R4OJ-TXY7-JKHI-SUHY-NJ7D
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NAB7-ZDLN-ZHMR-VOCR-MCBV-ZELE-7RZD
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MCNA-DD5N-R4OJ-TXY7-JKHI-SUHY-NJ7D
<rsp>Accept
</div>
~~~~

