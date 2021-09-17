
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MDVV-ESFG-IXKT-BAV4-M3U6-LS6B-ZQPV
Message ID: NA4W-P4SA-YCM2-VPZO-NGVS-MKNS-S7VM
Response ID: MCY6-QQ4D-HNVB-WJ27-IQ5R-T6VH-2TCP
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NA4W-P4SA-YCM2-VPZO-NGVS-MKNS-S7VM
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MCY6-QQ4D-HNVB-WJ27-IQ5R-T6VH-2TCP
<rsp>Accept
</div>
~~~~

