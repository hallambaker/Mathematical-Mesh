
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MCKT-ZJE6-OZQU-NYUU-H3T7-WESB-RTUW
Message ID: NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
Response ID: MCMX-6JO6-PCIQ-MVHU-2YW5-D4GM-QE35
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDI6-772L-UUBU-RIFV-S5GM-3B3J-4LFV
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MCMX-6JO6-PCIQ-MVHU-2YW5-D4GM-QE35
<rsp>Accept
</div>
~~~~

