
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MCLR-4G7H-RKAE-TSVS-2YFY-QLC5-DBDY
Message ID: NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
Response ID: MATH-MOWW-BSXS-NM2E-EP7K-QWJ2-YNG5
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDLR-BUDO-M7WU-JBTA-W4G2-AAOU-4NJB
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MATH-MOWW-BSXS-NM2E-EP7K-QWJ2-YNG5
<rsp>Accept
</div>
~~~~

