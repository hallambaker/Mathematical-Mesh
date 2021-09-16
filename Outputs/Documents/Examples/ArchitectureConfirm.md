
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MD5A-4CQC-BKZA-2M4D-JK45-CB54-2PJR
Message ID: NAK7-3ZB7-KTHV-37M4-DVEI-TJFA-WD4T
Response ID: MA66-V2N5-PE3E-2XY6-BKHT-PNDN-MZRH
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NAK7-3ZB7-KTHV-37M4-DVEI-TJFA-WD4T
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MA66-V2N5-PE3E-2XY6-BKHT-PNDN-MZRH
<rsp>Accept
</div>
~~~~

