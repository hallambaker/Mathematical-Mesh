
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MBIH-NNZB-MCZA-LWIW-4S3A-HOE5-IAUE
Message ID: NBQB-3S4U-QIJU-A2YB-HDPL-SGGM-CPKY
Response ID: MD7Q-AVXU-6XC7-WXCS-MWYD-IJ55-BUFB
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NBQB-3S4U-QIJU-A2YB-HDPL-SGGM-CPKY
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MD7Q-AVXU-6XC7-WXCS-MWYD-IJ55-BUFB
<rsp>Accept
</div>
~~~~

