
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MACN-R7IW-JPYU-XLMI-6KPN-5I3W-3WB4
Message ID: NAFH-QPYP-5OAV-WXPX-RCKO-KIKS-RYJG
Response ID: MBQO-USUV-X27A-CFLD-RXKE-LZMD-GT7T
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NAFH-QPYP-5OAV-WXPX-RCKO-KIKS-RYJG
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MBQO-USUV-X27A-CFLD-RXKE-LZMD-GT7T
<rsp>Accept
</div>
~~~~

