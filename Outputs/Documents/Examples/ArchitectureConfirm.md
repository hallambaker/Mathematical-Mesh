
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MBSL-BNHU-3RQN-L6VA-FTKE-5WPV-UC3H
Message ID: NDJX-VDBF-7LTL-EJ3L-BVQE-H7GG-6P2E
Response ID: MASC-PMET-3ZWF-W554-NKJV-7YLN-NLYK
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NDJX-VDBF-7LTL-EJ3L-BVQE-H7GG-6P2E
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MASC-PMET-3ZWF-W554-NKJV-7YLN-NLYK
<rsp>Accept
</div>
~~~~

