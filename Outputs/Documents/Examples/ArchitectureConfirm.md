
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MCDS-ZYU5-TXDG-FAHW-BAVA-VFRM-XOXD
Message ID: NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
Response ID: MDRR-IKIO-BXGJ-Y2QA-ZLJI-YDA2-HC4I
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NAZG-5KBV-D32X-O24L-XTYS-26GV-FC6Z
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MDRR-IKIO-BXGJ-Y2QA-ZLJI-YDA2-HC4I
<rsp>Accept
</div>
~~~~

