
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MBSA-WCDX-YHZX-7DLU-H3X3-QJHA-XTV2
Message ID: NBQW-47EI-Q2NL-N7UY-BUSA-47RX-AWVG
Response ID: MDJE-DO7A-RBM7-3HSM-7VQA-XX65-HGO2
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NBQW-47EI-Q2NL-N7UY-BUSA-47RX-AWVG
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MDJE-DO7A-RBM7-3HSM-7VQA-XX65-HGO2
<rsp>Accept
</div>
~~~~

