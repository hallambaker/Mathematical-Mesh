
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
<cmd>Alice> message accept NDDR-3DMR-QFGH-5NTT-W6V4-WAWM-ERSN
<rsp>ERROR - The specified message could not be found.
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Alice> message status MA77-BZ24-EDBS-EVN7-QOJV-M53E-ZJ53
<rsp>ERROR - The feature has not been implemented
</div>
~~~~

