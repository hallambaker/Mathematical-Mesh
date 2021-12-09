
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MB5O-RPD7-T7WG-7W4R-NBDV-L4OM-GSEN
Message ID: NDW5-TTEF-B4JG-BZQN-FNPA-CQRM-3AEE
Response ID: MASC-XJTW-W6W3-SCZM-M27S-APLS-I46I
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDW5-TTEF-B4JG-BZQN-FNPA-CQRM-3AEE
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MASC-XJTW-W6W3-SCZM-M27S-APLS-I46I
<rsp>Accept
</div>
~~~~

