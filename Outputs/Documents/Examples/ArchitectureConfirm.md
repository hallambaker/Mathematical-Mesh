
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp></div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NA6X-QQCS-7LVU-VGBR-J3Z6-VU7S-NXAS
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
Missing example 4
~~~~

