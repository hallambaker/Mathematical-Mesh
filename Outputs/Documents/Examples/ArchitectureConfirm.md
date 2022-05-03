
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MD5E-FTHA-N7K2-HEBG-S5U6-3CKT-NIRE
Message ID: NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
Response ID: MCYE-BSU4-GBBY-O5J4-CCVD-ZHYF-VKGH
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NAJ7-2JAE-5VND-GLM3-YYHF-FQX2-TCF7
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MCYE-BSU4-GBBY-O5J4-CCVD-ZHYF-VKGH
<rsp>Accept
</div>
~~~~

