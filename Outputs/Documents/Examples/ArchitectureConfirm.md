
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NDMR-EEV6-A4FE-TPXO-DHXZ-LWK4-EWTE
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
Missing example 2
~~~~

