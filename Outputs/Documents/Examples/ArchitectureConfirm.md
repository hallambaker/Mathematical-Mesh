
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
<cmd>Alice> message accept NDAZ-JLVP-HE53-RYKS-M2Q2-3QO6-JC75
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MDID-CENP-LBXW-423P-BL7U-HFNS-BORW
<rsp>Accept
</div>
~~~~

