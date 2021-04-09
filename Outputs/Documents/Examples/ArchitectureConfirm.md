
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MDSV-QO4B-LMKN-ZGFY-ZFQ4-VTWS-RZGD
Message ID: NCPO-3N4E-UOMN-TIPQ-UWCJ-MSUB-345F
Response ID: MBUB-AIUZ-NWQU-UYDM-CBWB-CKCV-IAKS
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NCPO-3N4E-UOMN-TIPQ-UWCJ-MSUB-345F
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MBUB-AIUZ-NWQU-UYDM-CBWB-CKCV-IAKS
<rsp>Accept
</div>
~~~~

