
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MDV7-4MW6-EJCI-64VG-T4SE-JXSL-YUH4
Message ID: ND6A-CEXE-CXZU-ECGN-FELV-6GWO-LH64
Response ID: MASB-GM6Z-YQTX-HUHG-DVZT-N3CF-5XQX
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept ND6A-CEXE-CXZU-ECGN-FELV-6GWO-LH64
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MASB-GM6Z-YQTX-HUHG-DVZT-N3CF-5XQX
<rsp>Accept
</div>
~~~~

