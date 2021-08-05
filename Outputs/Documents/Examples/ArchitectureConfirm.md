
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> message confirm alice@example.com start
<rsp>Envelope ID: MAHP-YGCF-WQAV-CSRH-Y6GA-AAP3-VKLY
Message ID: NBLG-QNFG-5NRO-K2PT-JIBB-4AVX-X2L6
Response ID: MDKO-2LBI-LVRI-6F7K-FSQC-NYLV-E76L
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> message accept NBLG-QNFG-5NRO-K2PT-JIBB-4AVX-X2L6
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> message status MDKO-2LBI-LVRI-6F7K-FSQC-NYLV-E76L
<rsp>Accept
</div>
~~~~

