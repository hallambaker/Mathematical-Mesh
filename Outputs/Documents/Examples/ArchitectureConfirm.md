
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MDBL-RH6P-BKQC-DNC7-UD6W-AADU-LTGU
Message ID: ND4F-UBBB-4TSK-2TQO-IOJ6-3LQY-45YB
Response ID: MBWY-T4QW-UVCT-UMJO-APHN-NFLB-IEWZ
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept ND4F-UBBB-4TSK-2TQO-IOJ6-3LQY-45YB
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MBWY-T4QW-UVCT-UMJO-APHN-NFLB-IEWZ
<rsp>Accept
</div>
~~~~

