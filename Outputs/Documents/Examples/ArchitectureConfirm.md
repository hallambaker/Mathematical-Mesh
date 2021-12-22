
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MDTI-Q7TA-QT6J-OHML-O6AA-VXPH-Z3QL
Message ID: NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
Response ID: MCCD-FYHQ-JHAC-KCJZ-22PW-E3W2-E6WH
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NCQL-ONQW-YLJE-NZ5P-2ENL-K5YY-3I4K
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MCCD-FYHQ-JHAC-KCJZ-22PW-E3W2-E6WH
<rsp>Accept
</div>
~~~~

