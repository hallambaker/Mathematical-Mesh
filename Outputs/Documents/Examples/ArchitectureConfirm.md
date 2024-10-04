
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MA67-3RLI-BFGR-X64H-SNKH-GI2S-PQ4R
Message ID: NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
Response ID: MAB6-RYAQ-MHZJ-25S7-34ZY-JRFR-OI6P
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDQ7-UANN-QSPT-CRYP-B4YY-4PNG-N2Z7
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MAB6-RYAQ-MHZJ-25S7-34ZY-JRFR-OI6P
<rsp>Accept
</div>
~~~~

