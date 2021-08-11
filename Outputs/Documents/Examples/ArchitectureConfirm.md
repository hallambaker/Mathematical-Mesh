
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MBR5-UNSX-BHKQ-WQIX-4HQE-C2PC-QAQI
Message ID: NA4G-MREL-3334-UPIK-V6OL-EDCH-WMGR
Response ID: MCKI-6SNF-Y6OR-FTW4-NLJO-AWBV-APJU
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NA4G-MREL-3334-UPIK-V6OL-EDCH-WMGR
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MCKI-6SNF-Y6OR-FTW4-NLJO-AWBV-APJU
<rsp>Accept
</div>
~~~~

