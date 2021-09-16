
### Phase 1:

There are no first phase actions.

### Phase 2:

Alice enters the connection request on the device to be connected. This specifies the 
address of the account to which she wishes to connect:


~~~~
<div="terminal">
<cmd>Alice2> device request alice@example.com
<rsp>   Device UDF = MAF2-7KXX-JCZD-PWUH-NLBP-IWGQ-3E43
   Witness value = 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
</div>
~~~~


### Phase 3:

The user reviews their pending messages:


~~~~
<div="terminal">
<cmd>Alice> device pending
<rsp>MessageID: 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
        Connection Request::
        MessageID: 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
        To:  From: 
        Device:  MAF2-7KXX-JCZD-PWUH-NLBP-IWGQ-3E43
        Witness: 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG
</div>
~~~~

The administration device receives the AcknowledgeConnection message from the service 
and verifies that the signature is valid and the witness value correctly computed.

The user verifies that the witness value presented in the AcknowledgeConnection message
matches the one presented on the device. Since they match, the request is accepted:


~~~~
<div="terminal">
<cmd>Alice> device accept 4T6D-MWAA-GS5Q-QLQ6-SZIG-XPHO-54IG /message /web
</div>
~~~~

### Phase 4

The device completes the connection as before:


~~~~
<div="terminal">
<cmd>Alice2> device complete
<rsp>   Device UDF = MAF2-7KXX-JCZD-PWUH-NLBP-IWGQ-3E43
   Account = alice@example.com
   Account UDF = MALV-QFP7-3VYX-IGEC-O5EN-QI5L-QZLC
</div>
~~~~

