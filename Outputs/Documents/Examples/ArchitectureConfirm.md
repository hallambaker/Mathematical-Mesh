
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MBCR-K34K-52QD-LFR4-2NUR-LAB5-4U5R
Message ID: NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
Response ID: MBCG-IK56-CZ3R-SHDG-ARCZ-5CMX-LMSW
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDSA-RD52-JIV2-RVRU-BY4U-3SAN-HZWQ
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MBCG-IK56-CZ3R-SHDG-ARCZ-5CMX-LMSW
<rsp>Accept
</div>
~~~~

