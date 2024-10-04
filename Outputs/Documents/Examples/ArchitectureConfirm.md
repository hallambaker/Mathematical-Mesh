
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MDCG-C2DB-DTMH-MPP7-NGOG-AC5J-M6BO
Message ID: NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
Response ID: MBJK-3QH6-T4TQ-WFOK-UUZW-5HOI-ZBK3
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDPC-BWU4-ULAU-DUSZ-PDP5-7QOH-H53L
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MBJK-3QH6-T4TQ-WFOK-UUZW-5HOI-ZBK3
<rsp>Accept
</div>
~~~~

