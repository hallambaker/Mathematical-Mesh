
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MAWU-5FMM-ZN6O-FXE5-TVC4-LO6I-RJ4D
Message ID: NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
Response ID: MBO5-GGWR-XOSQ-M6AO-WRP7-CJWT-V6LN
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDBB-CHFG-OWNI-2WWK-RJI2-KMF7-6AW7
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MBO5-GGWR-XOSQ-M6AO-WRP7-CJWT-V6LN
<rsp>Accept
</div>
~~~~

