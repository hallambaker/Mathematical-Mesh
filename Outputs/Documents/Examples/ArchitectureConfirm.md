
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MD7A-HE2G-YPVC-HPKG-RTSV-M5Z6-7ZWX
Message ID: NBEC-S26E-KFLR-WMRH-67RO-XEQI-3EGC
Response ID: MADI-KSCW-HBSV-UVSX-GYDY-3XZP-CCQP
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NBEC-S26E-KFLR-WMRH-67RO-XEQI-3EGC
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MADI-KSCW-HBSV-UVSX-GYDY-3XZP-CCQP
<rsp>Accept
</div>
~~~~

