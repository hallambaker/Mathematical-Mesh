
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MBFM-RPD5-MYYX-UK3M-2SCV-GUYR-J446
Message ID: NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
Response ID: MA6X-RZBB-RBT7-EWC2-ZPDV-ZUJI-3BRE
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NBGK-6BGU-5C5H-4WUR-OGDF-NZTH-ZLCW
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MA6X-RZBB-RBT7-EWC2-ZPDV-ZUJI-3BRE
<rsp>Accept
</div>
~~~~

