
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MDSR-PBRN-JUCJ-FCBV-RGPG-YROS-FO2T
Message ID: NDN5-UX7M-5YHV-IZAK-DELS-YYMS-RNWD
Response ID: MCZ7-KSJY-SCWO-ELRR-IKRU-TMWE-2MW6
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NDN5-UX7M-5YHV-IZAK-DELS-YYMS-RNWD
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MCZ7-KSJY-SCWO-ELRR-IKRU-TMWE-2MW6
<rsp>Accept
</div>
~~~~

