
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MANZ-CZCQ-BZU4-FT5Q-ELDK-SPNE-S7SN
Message ID: NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
Response ID: MDRC-MK3S-7RYC-JEHG-CAWE-2N7E-JKWS
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NCM5-RFA7-MCBH-UTRQ-2DPH-RIUN-DZEE
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MDRC-MK3S-7RYC-JEHG-CAWE-2N7E-JKWS
<rsp>Accept
</div>
~~~~

