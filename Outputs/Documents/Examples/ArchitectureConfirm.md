
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MDOD-KSMY-EZZE-TTOD-EHJB-JESO-A56I
Message ID: NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
Response ID: MCF4-6SUJ-F74P-IUAC-PNAW-RL3C-5IIS
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NC75-ZYCL-N3BL-FVYI-TFSW-FFJV-DZHW
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MCF4-6SUJ-F74P-IUAC-PNAW-RL3C-5IIS
<rsp>Accept
</div>
~~~~

