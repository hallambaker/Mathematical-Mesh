
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MCSH-WAX3-U5YR-2PAU-7EIB-5B3K-JARW
Message ID: NADS-LI53-GDCV-2WZL-GW3K-62QU-KW4X
Response ID: MCAO-L2QO-J2OM-3J77-SBL6-ONFN-MNHG
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NADS-LI53-GDCV-2WZL-GW3K-62QU-KW4X
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MCAO-L2QO-J2OM-3J77-SBL6-ONFN-MNHG
<rsp>Accept
</div>
~~~~

