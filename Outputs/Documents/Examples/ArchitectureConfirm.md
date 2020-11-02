
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
<cmd>Alice> message accept NB3R-KF4X-PLYG-VDF5-ZMLZ-OQG3-5COU
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Alice> $message status {confirmResponseID}
<rsp>ERROR - The command System.Object[] is not known.
</div>
~~~~

