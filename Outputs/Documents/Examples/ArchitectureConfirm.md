
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MBSA-DAEF-DJP6-PYDV-RYVK-QNEF-BY32
Message ID: NDHX-5YUA-2EG6-MBOH-CFA3-7ZZS-G7SI
Response ID: MARN-UKW4-BU7W-OCCW-Z23O-TYLX-GC36
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NDHX-5YUA-2EG6-MBOH-CFA3-7ZZS-G7SI
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MARN-UKW4-BU7W-OCCW-Z23O-TYLX-GC36
<rsp>Accept
</div>
~~~~

