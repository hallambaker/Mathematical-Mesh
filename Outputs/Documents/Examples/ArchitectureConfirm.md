
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MC3T-B47G-VJH4-I2XT-REAE-SXUU-EYWG
Message ID: NCSP-ACXT-MDPB-QLOC-TPGQ-TFNH-M7KR
Response ID: MDTQ-SQ2G-4ESB-X7YK-53KP-A5HM-OLOR
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NCSP-ACXT-MDPB-QLOC-TPGQ-TFNH-M7KR
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MDTQ-SQ2G-4ESB-X7YK-53KP-A5HM-OLOR
<rsp>Accept
</div>
~~~~

