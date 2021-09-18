
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MCSX-D62M-TZXI-PCTO-HH3Q-EXXB-VRA5
   Witness value = 6ZZX-J4T5-O7QM-IQSL-3OPZ-F23B-UN3X
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 6ZZX-J4T5-O7QM-IQSL-3OPZ-F23B-UN3X
        Connection Request::
        MessageID: 6ZZX-J4T5-O7QM-IQSL-3OPZ-F23B-UN3X
        To:  From: 
        Device:  MCSX-D62M-TZXI-PCTO-HH3Q-EXXB-VRA5
        Witness: 6ZZX-J4T5-O7QM-IQSL-3OPZ-F23B-UN3X
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept 6ZZX-J4T5-O7QM-IQSL-3OPZ-F23B-UN3X /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MCSX-D62M-TZXI-PCTO-HH3Q-EXXB-VRA5
   Account = alice@example.com
   Account UDF = MD6V-5HNC-LHGP-7T7N-V2MK-N7BV-5AV4
</div>
~~~~

