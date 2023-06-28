
Alice attempts to log into a secure console in the control room. The secure console recognizes 
Alice but a second factor is required. The console issues a challenge to Alice at her
registered account asking if she would like to log into the secure console:


~~~~
<div="terminal">
<cmd>Console> meshman message confirm alice@example.com start
<rsp>Envelope ID: MBRF-HV6Z-UAXU-IUP5-4B6A-XIRE-UHGZ
Message ID: NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
Response ID: MB7S-ZUPK-XJ6Q-N42Y-4UTW-7CQI-33HL
</div>
~~~~

Alice checks her pending messages and accepts the request:


~~~~
<div="terminal">
<cmd>Alice> meshman message accept NDTU-IIPR-L5SK-L6CZ-JJGF-XA6L-565H
</div>
~~~~

The secure console verifies the response and grants access:


~~~~
<div="terminal">
<cmd>Console> meshman message status MB7S-ZUPK-XJ6Q-N42Y-4UTW-7CQI-33HL
<rsp>Accept
</div>
~~~~

