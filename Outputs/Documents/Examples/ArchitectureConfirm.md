
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MDVA-HSIH-UJBT-PEVO-GZNQ-JF3O-YHTM
Message ID: NDAD-KLJY-C5JO-JGXL-VUWG-Y6PP-PSFJ
Response ID: MCT4-SVZ2-BL5Y-DR5B-TF4S-WIGH-CJTM
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NDAD-KLJY-C5JO-JGXL-VUWG-Y6PP-PSFJ
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MCT4-SVZ2-BL5Y-DR5B-TF4S-WIGH-CJTM
<rsp>Accept
</div>
~~~~

