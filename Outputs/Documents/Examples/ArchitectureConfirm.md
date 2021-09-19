
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MCNH-IVIE-CUBG-ZRTX-TRVT-N2Q5-SP3U
Message ID: NC5O-E23U-BF3F-VDVE-O3GU-WJB7-OWBW
Response ID: MCJC-ULB5-OTT6-HR23-H4BG-KNKG-GHQZ
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NC5O-E23U-BF3F-VDVE-O3GU-WJB7-OWBW
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MCJC-ULB5-OTT6-HR23-H4BG-KNKG-GHQZ
<rsp>Accept
</div>
~~~~

